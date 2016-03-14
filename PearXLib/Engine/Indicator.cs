﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PearXLib.Engine
{
    /// <summary>
    /// Type of the Indicator
    /// </summary>
    public enum IndicatorType
    {
        /// <summary>
        /// Red, Yellow, Green lines on the Indicator.
        /// </summary>
        ThreeLines,
        /// <summary>
        /// Red => Green gradient.
        /// </summary>
        Gradient
    }

    public partial class Indicator : UserControl
    {
        private IndicatorType it = IndicatorType.Gradient;
        private Color c1 = Color.Green;
        private Color c2 = Color.Yellow;
        private Color c3 = Color.Red;

        #region Params.
        public IndicatorType Type
        {
            get { return it; }
            set { it = value; Refresh(); }
        }

        public Color Color1
        {
            get { return c1; }
            set { c1 = value; Refresh(); }
        }

        public Color Color2
        {
            get { return c2; }
            set { c2 = value; Refresh(); }
        }

        public Color Color3
        {
            get { return c3; }
            set { c3 = value; Refresh(); }
        }
        #endregion

        /// <summary>
        /// Initializes a new Indicator.
        /// </summary>
        public Indicator()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            switch(Type)
            {
                case IndicatorType.Gradient:
                    LinearGradientBrush lgb = new LinearGradientBrush(new Point(0, 0), new Point(Width, Height), Color3, Color1);
                    e.Graphics.FillRectangle(lgb, 0, 0, Width, Height);
                    break;
                case IndicatorType.ThreeLines:
                    SolidBrush b1 = new SolidBrush(Color1);
                    SolidBrush b2 = new SolidBrush(Color2);
                    SolidBrush b3 = new SolidBrush(Color3);
                    e.Graphics.FillRectangle(b3, 0, 0, 3, Width);
                    e.Graphics.FillRectangle(b1, Width - 3, 0, 3, Height);
                    e.Graphics.FillRectangle(b2, (Width - 3) / 2, 0, 3, Height);
                    break;
            }
            base.OnPaint(e);
        }
    }
}
