using DataGridViewPractice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotificationGenerator
{
    public enum FromNotificationAlignment
    {
        LeftUp,
        LeftDown,
        RightUp,
        RightDown
    }

    class NotificationManager:Component
    {
        public FromNotificationAlignment NotificationAlignment
        {
            get
            {
                return notificationAlignment;
            }
            set
            {
                notificationAlignment = value;
                InitialisePositions();
            }
        }
        public int NotificationScreenTime
        {
            get
            {
                return notificationScreenTime;
            }

            set
            {
                notificationScreenTime = value;
            }
        }
        public int BorderRadius { get; set; }

        public NotificationManager()
        {
            notificationWidth = 400;
            notificationHeight = 175;

            screenWidth = Screen.PrimaryScreen.Bounds.Width;
            screenHeight = Screen.PrimaryScreen.Bounds.Height;
            remainingHeight = screenHeight;

            NotifyManagerTimer = new Timer();
            NotifyManagerTimer.Interval = 1000;
            NotifyManagerTimer.Tick += OnNotifyScreenTimerChecker;
            NotifyManagerTimer.Start();
        }

        private void OnNotifyScreenTimerChecker(object sender, EventArgs e)
        {
            for(int ctr= 0; ctr < NotificationOnScreenList.Count; ctr++)
            {
                NotificationTemplate Iter = NotificationOnScreenList[ctr];
                Iter.TickCount += 1;

                if(Iter.TickCount>notificationScreenTime)
                {
                    Iter.Close();
                }
            }
        }

        private int startX, startY, stepX, stepY, prevX, prevY;
        private int sX, sY;
        private int notificationWidth, notificationHeight;
        private int remainingHeight;
        private int screenWidth, screenHeight;
        private int notificationScreenTime = 5;
        private FromNotificationAlignment notificationAlignment;
        private List<NotificationTemplate> NotificationOnScreenList = new List<NotificationTemplate>();
        private Queue<NotificationTemplate> NotificationQueue = new Queue<NotificationTemplate>();
        private Timer NotifyManagerTimer;

        public void AddNotification(string header, string content)
        {
            NotificationTemplate newNotification = new NotificationTemplate();
            newNotification.BorderRadius = BorderRadius;
            newNotification.Padding = new Padding(BorderRadius / 10);
            newNotification.NotificationHeader = header;
            newNotification.ContentMessage = content;
            newNotification.NotificationTime = DateTime.Now;
            newNotification.Size = newNotification.SetNotificationSize();
            newNotification.NotificationClosed += OnNotificationClosed;
            newNotification.TopMost = true;
            if(newNotification.isContentOutOfHeight)
            {
                newNotification.Size = new Size(400, 175);
            }
            
            if ((prevY + (10 + newNotification.Height) * sY) <= 0 && (notificationAlignment == FromNotificationAlignment.LeftDown || notificationAlignment == FromNotificationAlignment.RightDown))
            {
                NotificationQueue.Enqueue(newNotification);
            }
            else if ((startY + notificationHeight >= screenHeight && (notificationAlignment == FromNotificationAlignment.LeftUp || notificationAlignment == FromNotificationAlignment.RightUp)))
            {
                NotificationQueue.Enqueue(newNotification);
            }
            else if(NotificationQueue.Count>0)
            {
                NotificationQueue.Enqueue(newNotification);
            }
            else
            {
                startX = prevX + (10 + newNotification.Width) * sX;
                startY = prevY + (10 + newNotification.Height) * sY;
                newNotification.Location = new Point(startX, startY); /*startY += stepY; startX += stepX;*/
                prevX = startX; prevY = startY;
                
                newNotification.TickCount = 0;
                NotificationOnScreenList.Add(newNotification);
                newNotification.Show();
            }
        }

        private void OnNotificationClosed(object sender, EventArgs e)
        {
            int Iter = NotificationOnScreenList.Count - 1;
            InitialisePositions();
            for (int ctr = 0; ctr < NotificationOnScreenList.Count; ctr++)
            {
                if(NotificationOnScreenList[ctr] == (sender as NotificationTemplate))
                {
                    Iter = ctr;
                    break;
                }
                else
                {
                    prevX = NotificationOnScreenList[ctr].Location.X;
                    prevY = NotificationOnScreenList[ctr].Location.Y;
                }
            }

            for (int ctr = Iter + 1; ctr < NotificationOnScreenList.Count; ctr++)
            {
                startX = prevX + (10 + NotificationOnScreenList[ctr].Width) * sX;
                startY = prevY + (10 + NotificationOnScreenList[ctr].Height) * sY;
                NotificationOnScreenList[ctr].Location = new Point(startX, startY);
                prevX = startX;
                prevY = startY;
            }
            NotificationOnScreenList.Remove(sender as NotificationTemplate);

            while (NotificationQueue.Count>0 && (prevY + (10 + NotificationQueue.Peek().Height) * sY) > 0)
            {
                NotificationTemplate newNotification  = NotificationQueue.Peek();
                newNotification.TickCount = 0;

                startX = prevX + (10 + NotificationQueue.Peek().Width) * sX;
                startY = prevY + (10 + NotificationQueue.Peek().Height) * sY;
                newNotification.Location = new Point(startX, startY);
                prevX = startX;
                prevY = startY;
                NotificationOnScreenList.Add(newNotification);
                NotificationQueue.Dequeue();
                newNotification.Show();
            }

        }

        private void InitialisePositions()
        {
            if (notificationAlignment == FromNotificationAlignment.RightDown)
            {
                prevX = screenWidth - notificationWidth - 10; prevY = screenHeight; stepX = 0; stepY = -notificationHeight - 10; sY = -1; sX = 0;
            }
            else if (notificationAlignment == FromNotificationAlignment.RightUp)
            {
                startX = screenWidth - notificationWidth - 50; startY = 10; stepX = 0; stepY = notificationHeight + 10;
            }
            else if (notificationAlignment == FromNotificationAlignment.LeftDown)
            {
                startX = 10; startY = screenHeight - notificationHeight - 50; stepX = 0; stepY = -notificationHeight - 10;
            }
            else if (notificationAlignment == FromNotificationAlignment.LeftUp)
            {
                startX = 50; startY = 50; stepX = 0; stepY = notificationHeight + 10;
            }
        }
    }
}
