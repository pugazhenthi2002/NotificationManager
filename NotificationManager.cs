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

                if(value == FromNotificationAlignment.RightDown)
                {
                    startX = screenWidth - notificationWidth - 50; startY = screenHeight - notificationHeight - 10; stepX = 0; stepY = - notificationHeight - 10;
                }
                else if(value == FromNotificationAlignment.RightUp)
                {
                    startX = screenWidth - notificationWidth - 50; startY = 10; stepX = 0; stepY = notificationHeight + 10;
                }
                else if(value == FromNotificationAlignment.LeftDown)
                {
                    startX = 10; startY = screenHeight - notificationHeight - 50; stepX = 0; stepY = -notificationHeight - 10;
                }
                else if(value == FromNotificationAlignment.LeftUp)
                {
                    startX = 50; startY = 50; stepX = 0; stepY = notificationHeight + 10;
                }
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

        private int startX, startY, stepX, stepY;
        private int notificationWidth, notificationHeight;
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
            newNotification.NotificationClosed += OnNotificationClosed;
            newNotification.TopMost = true;

            if (startY <= 0 && (notificationAlignment == FromNotificationAlignment.LeftDown || notificationAlignment == FromNotificationAlignment.RightDown))
            {
                NotificationQueue.Enqueue(newNotification);
            }
            else if ((startY + notificationHeight >= screenHeight && (notificationAlignment == FromNotificationAlignment.LeftUp || notificationAlignment == FromNotificationAlignment.RightUp)))
            {
                NotificationQueue.Enqueue(newNotification);
            }
            else
            {
                newNotification.Location = new Point(startX, startY); startY += stepY; startX += stepX;
                newNotification.TickCount = 0;
                NotificationOnScreenList.Add(newNotification);
                newNotification.Show();
            }
        }

        private void OnNotificationClosed(object sender, EventArgs e)
        {
            int Iter = NotificationOnScreenList.Count - 1;

            for (int ctr = 0; ctr < NotificationOnScreenList.Count; ctr++)
            {
                if(NotificationOnScreenList[ctr] == (sender as NotificationTemplate))
                {
                    Iter = ctr;
                }
            }

            for (int ctr = NotificationOnScreenList.Count-1; ctr>=Iter+1; ctr--)
            {
                NotificationOnScreenList[ctr].Location = NotificationOnScreenList[ctr-1].Location;
            }
            startY -= stepY; startX -= stepX;


            if(NotificationQueue.Count>0)
            {
                NotificationTemplate newNotification  = NotificationQueue.Peek();
                newNotification.TickCount = 0;
                newNotification.Location = new Point(startX, startY); startY += stepY; startX += stepX;
                NotificationOnScreenList.Add(newNotification);
                NotificationQueue.Dequeue();
                newNotification.Show();
            }

            NotificationOnScreenList.Remove(sender as NotificationTemplate);

        }
    }
}
