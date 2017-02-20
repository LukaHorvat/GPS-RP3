﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPS.Views
{
    public class LocationStreetButton : RadioButton
    {
        public GPSStreet street { get; set; }
        public GraphMainForm creator { get; set; }

        public LocationStreetButton(Color outerColor, Color innerColor) : this(outerColor, innerColor, 24, 24) { }

        public LocationStreetButton(Color outerColor, Color innerColor, int width, int height) : base()
        {
            this.Size = new Size(width, height);
            this.Text = "";
            this.OuterColor = outerColor;
            this.InnerColor = innerColor;
            this.AutoSize = false;
            Font = new Font("Arial", 8);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            this.MouseClick += LocationNodeButton_MouseClick;
            ContextMenu menu = new ContextMenu();
            MenuItem itemShow = menu.MenuItems.Add("Show street details");
            itemShow.Click += ItemShow_Click;
            MenuItem itemAddCharacteristic = menu.MenuItems.Add("Add characteristic");
            itemAddCharacteristic.Click += ItemAddCharacteristic_Click;
            this.ContextMenu = menu;
        }

        private void ItemAddCharacteristic_Click(object sender, EventArgs e)
        {
            var addCharacteristicDialog = new AddStreetCharacteristicDialog(street);
            addCharacteristicDialog.ShowDialog();
        }

        private void ItemShow_Click(object sender, EventArgs e)
        {
            var showDetailsDialog = new StreetDetailForm(street);
            showDetailsDialog.ShowDialog();
        }

        private void LocationNodeButton_MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
            }
            else if (me.Button == MouseButtons.Left)
            {
                var basicForm = new StreetBasicForm(street);
                basicForm.ShowDialog();
            }
        }

        public Color InnerColor { get; set; }
        public Color OuterColor { get; set; }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            PaintParentBackground(pevent);
            int diameter = ClientRectangle.Height - 1;

            RectangleF innerRect = new RectangleF(1F, 1F, diameter - 2, diameter - 2);
            g.FillEllipse(new SolidBrush(this.OuterColor), innerRect);

            Rectangle outerRect = new Rectangle(0, 0, diameter, diameter);
            g.DrawEllipse(new Pen(Color.Transparent), outerRect);

            if (Checked)
            {
                innerRect.Inflate(-3, -3);
                g.FillEllipse(new SolidBrush(InnerColor), innerRect);
            }

            g.DrawString(Text, Font, new SolidBrush(ForeColor), diameter + 5, 1);
        }

        private void PaintParentBackground(PaintEventArgs e)
        {
            if (Parent == null)
            {
                e.Graphics.FillRectangle(SystemBrushes.Control, ClientRectangle);
                return;
            }


            Rectangle rect = new Rectangle(Left, Top, Width, Height);
            e.Graphics.TranslateTransform(-rect.X, -rect.Y);

            try
            {
                using (PaintEventArgs pea = new PaintEventArgs(e.Graphics, rect))
                {
                    pea.Graphics.SetClip(rect);
                    InvokePaintBackground(Parent, pea);
                    InvokePaint(Parent, pea);
                }
            }
            finally
            {
                e.Graphics.TranslateTransform(rect.X, rect.Y);
            }
        }
    }
}
