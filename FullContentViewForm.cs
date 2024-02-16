using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewPractice
{
    public partial class FullContentViewForm : Form
    {
        public string TitleName { get; set; }
        public string Content
        {
            get
            { return content; }
            set
            { content = value; label1.Text = value; }
        }
       
        public FullContentViewForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            titleFont = new Font(new FontFamily("Microsoft PhagsPa"), 20, FontStyle.Bold);
            contentFont = new Font(new FontFamily("Microsoft PhagsPa"), 12);
            typeof(Label).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, label1, new object[] { true });
            var x = label1.Height;
        }

        private void fullContentTitleBarPanel_Paint(object sender, PaintEventArgs e)
        {
            SFormat = new StringFormat();
            SFormat.Alignment = StringAlignment.Near;
            SFormat.LineAlignment = StringAlignment.Center;

            titleBrush = new SolidBrush(Color.FromArgb(52, 104, 192));
            rec = new Rectangle(0, 0, fullContentTitleBarPanel.Width, fullContentTitleBarPanel.Height);

            e.Graphics.DrawString(TitleName, titleFont, titleBrush, rec, SFormat);
        }

        //private List<string> wordArray = new List<string>();
        private Font titleFont, contentFont;
        private Brush titleBrush;

        private void closeButton1_Click(object sender, EventArgs e)
        {
            NotificationTemplate.isFullContentDisplayed = false;
            this.Close();
        }

        private StringFormat SFormat;

        private void FullContentFormPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Brush b = new SolidBrush(Color.FromArgb(253, 240, 209));
            Rectangle rectangle = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
            FillRoundRectangle(e.Graphics, rectangle, b, 10);
            b.Dispose();
            //this.Paint -= FullContentFormPaint;
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

        private void FullContentViewForm_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.FromArgb(1, 1, 1);
            this.BackColor = Color.FromArgb(1, 1, 1);
            //this.Paint -= FullContentFormPaint;
        }

        private void fullContentMessagePanel_Paint(object sender, PaintEventArgs e)
        {
            var x = Location.X;
        }

        private string content;
        private Rectangle rec;
    }
}
