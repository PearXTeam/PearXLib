﻿using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PearXLib.Engine.Bases;

namespace PearXLib.Engine
{
    /// <summary>
    /// A beatiful gradient-style button.
    /// </summary>
    public class XButton : XButtonBase
    {
        private Color _GradientColor1 = Color.FromArgb(102, 204, 0);
        private Color _GradientColor2 = Color.White;
        private Color _GradientColorFocused1 = Color.FromArgb(132, 234, 0);
        private Color _GradientColorFocused2 = Color.White;
        private Color _ColorPressed = Color.FromArgb(102, 204, 0);

        #region Properties.
        /// <summary>
        /// The button's gradient color 1.
        /// </summary>
        [DefaultValue(typeof(Color), "102, 204, 0")]
        public Color GradientColor1
        {
            get { return _GradientColor1; }
            set { _GradientColor1 = value; Refresh(); }
        }

        /// <summary>
        /// The button's gradient color 2.
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        public Color GradientColor2
        {
            get { return _GradientColor2; }
            set { _GradientColor2 = value; Refresh(); }
        }

        /// <summary>
        /// The focused button's gradient color 1.
        /// </summary>
        [DefaultValue(typeof(Color), "132, 234, 0")]
        public Color GradientColorFocused1
        {
            get { return _GradientColorFocused1; }
            set { _GradientColorFocused1 = value; Refresh(); }
        }

        /// <summary>
        /// The focused button's gradient color 2.
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        public Color GradientColorFocused2
        {
            get { return _GradientColorFocused2; }
            set { _GradientColorFocused2 = value; Refresh(); }
        }

        /// <summary>
        /// A color of the pressed button.
        /// </summary>
        [DefaultValue(typeof(Color), "102, 204, 0")]
        public Color ColorPressed
        {
            get { return _ColorPressed; }
            set { _ColorPressed = value; Refresh(); }
        }
        #endregion

        /// <summary>
        /// Initializes a new XButton component.
        /// </summary>
        public XButton()
        {
            Size = new Size(128, 64);
            Paint += ControlPaint;
        }

        private void ControlPaint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Brushes.Black, 2) {LineJoin = LineJoin.Round};
            Rectangle rect = new Rectangle(1, 1, Width - 2, Height - 2);
            Brush br = null;
            switch (State)
            {
                case XButtonState.NONE:
                    br = new LinearGradientBrush(new PointF(0, 0), new PointF(Width, Height), GradientColor1, GradientColor2);
                    break;
                case XButtonState.FOCUSED:
                    br = new LinearGradientBrush(new PointF(0, 0), new PointF(Width, Height), GradientColorFocused1, GradientColorFocused2);
                    break;
                case XButtonState.CLICKED:
                    br = new SolidBrush(ColorPressed);
                    break;
            }
            e.Graphics.FillRectangle(br, rect);
            e.Graphics.DrawRectangle(p, rect);
            PaintBase(e);
        }
    }
}
