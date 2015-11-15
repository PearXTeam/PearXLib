﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using PearXLib.Properties;

namespace PearXLib.Engine
{
    /// <summary>
    /// An expanding icon from PearX Engine.
    /// </summary>
    public partial class XIcon : UserControl
    {
        private Image _Icon;
        private bool _PlaySound = true;
        private string _Title = String.Empty;
        /// <summary>
        /// Initializes a new XIcon component.
        /// </summary>
        public XIcon() 
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
        }

        #region Properties.
        /// <summary>
        /// Icon image.
        /// </summary>
        [DefaultValue(null), Description("Icon image.")]
        public Image Icon
        {
            get { return _Icon; }
            set
            {
                _Icon = value;
                Refresh();
            }
        }

        /// <summary>
        /// Play sound, when mouse focused on this component?
        /// </summary>
        [DefaultValue(true), Description("Play sound, when mouse focused on this component?")]
        public bool PlaySound
        {
            get { return _PlaySound; }
            set { _PlaySound = value; }
        }

        /// <summary>
        /// Icon title (will be displayed on the control).
        /// </summary>
        [DefaultValue(""), Description("Icon title (will be displayed on the control).")]
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                Refresh();
            }
        }
        
        /// <summary>
        /// Title font.
        /// </summary>
        [Description("Title font.")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                Refresh();
            }
        }
        #endregion

        private void XIcon_MouseEnter(object sender, EventArgs e)
        {
            Size = new Size(Size.Width + 20, Size.Height + 20);
            Location = new Point(Location.X - 10, Location.Y - 10);
            BringToFront();
            if (PlaySound)
            {
                SoundPlayer sp = new SoundPlayer(Resources.bd);
                sp.Play();
            }
        }

        private void XIcon_MouseLeave(object sender, EventArgs e)
        {
            Size = new Size(Size.Width - 20, Size.Height - 20);
            Location = new Point(Location.X + 10, Location.Y + 10);
        }

        private void XIcon_Paint(object sender, PaintEventArgs e)
        {
            if (Icon != null)
            {
                if (!String.IsNullOrEmpty(Title))
                {
                    Brush b = new SolidBrush(ForeColor);
                    SizeF strWH = e.Graphics.MeasureString(Title, Font);
                    e.Graphics.DrawImage(Icon, 0, 0, Size.Width, Size.Height - strWH.Height);
                    e.Graphics.DrawString(Title, Font, b, (Size.Width - strWH.Width) / 2, Size.Height - strWH.Height);
                }
                else
                {
                    e.Graphics.DrawImage(Icon, 0, 0, Size.Width, Size.Height);
                }
            }
        }
    }
}
