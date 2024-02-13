using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewPractice
{
    public partial class NotificationTemplate : Form
    {
        public string NotificationHeader
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
                notificationHeaderLabel.Text = header;
            }
        }
        public string ContentMessage
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
                notificationMessageLabel.Text = message;
            }
        }
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }

            set
            {
                borderRadius = value;
            }
        }

        public DateTime NotificationTime
        {
            get
            {
                return notificationTime;
            }

            set
            {
                notificationTime = value;
                notificationDateTimeLabel.Text = value.ToString();
            }
        }
        public int TickCount = 0;

        public event EventHandler NotificationClosed;

        public NotificationTemplate()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }

        private void NotificationTemplate_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.FromArgb(1,1,1);
            this.BackColor = Color.FromArgb(1,1,1);
        }

        private void NotificationTemplate_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Brush b = new SolidBrush(Color.FromArgb(253, 240, 209));

            Rectangle rectangle = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
            FillRoundRectangle(e.Graphics, rectangle, b, BorderRadius);
            b.Dispose();
        }

        private static GraphicsPath GetRoundRectangle(Rectangle rectangle, int r)
        {
            int l = 2 * r;
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(new Point(rectangle.X + r, rectangle.Y), new Point(rectangle.Right - r, rectangle.Y));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Y, l, l), 270F, 90F);

            gp.AddLine(new Point(rectangle.Right, rectangle.Y + r), new Point(rectangle.Right, rectangle.Bottom - r));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Bottom - l, l, l), 0F, 90F);

            gp.AddLine(new Point(rectangle.Right - r, rectangle.Bottom), new Point(rectangle.X + r, rectangle.Bottom));
            gp.AddArc(new Rectangle(rectangle.X, rectangle.Bottom - l, l, l), 90F, 90F);

            gp.AddLine(new Point(rectangle.X, rectangle.Bottom - r), new Point(rectangle.X, rectangle.Y + r));
            gp.AddArc(new Rectangle(rectangle.X, rectangle.Y, l, l), 180F, 90F);

            return gp;
        }

        private void FillRoundRectangle(Graphics g, Rectangle rectangle, Brush b, int r)
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            g.FillPath(b, GetRoundRectangle(rectangle, r));
            Pen p = new Pen(Color.Black, 3);
            p.DashStyle = DashStyle.Solid;
            g.DrawPath(p, GetRoundRectangle(rectangle, r));
            p.Dispose();
        }

        private void OnNotificationClosed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotificationTemplate_FormClosed(object sender, FormClosedEventArgs e)
        {
            NotificationClosed?.Invoke(this, e);
        }

        private void frmFadeClose_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Opacity > 0.01f)
            {
                e.Cancel = true;
                fadeOutTimer.Tick += Timer1_Tick;
                fadeOutTimer.Interval = 50;
                fadeOutTimer.Start();
            }
            else
            {
                fadeOutTimer.Enabled = false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.01)
                this.Opacity = this.Opacity - 0.1f;
            else
                this.Close();
        }

        private int borderRadius;
        private string header;
        private string message;
        private DateTime notificationTime;
        private Timer fadeOutTimer = new Timer();
    }
}
