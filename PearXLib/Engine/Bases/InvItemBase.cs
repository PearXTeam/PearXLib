﻿using System.ComponentModel;
using System.Drawing;

namespace PearXLib.Engine.Bases
{
    /// <summary>
    /// Inventory Item event handler.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">InvItem event args. <see cref="InvItemEventArgs"/></param>
    public delegate void InvItemEventHandler(object sender, InvItemEventArgs e);

    /// <summary>
    /// A base for all InvItem controls.
    /// </summary>
    /// <seealso cref="XTextControlBase" />
    public class InvItemBase : XTextControlBase
    {
        private Image _ItemImage;
        private string _ItemDesc = "Cake - a lie.";
        private int _ItemAmount;
        private string _ItemName = "Cake";
        private Color _ColorName = Color.Red;
        private Color _ColorDesc = Color.Blue;
        private Color _ColorAmount = Color.Green;
        private bool _ShowAmount = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvItemBase"/> class.
        /// </summary>
        public InvItemBase()
        {
            ResizeRedraw = true;
        }

        #region Params
        /// <summary>
        /// Performs on item amount changed.
        /// </summary>
        public event InvItemEventHandler AmountChanged;

        /// <summary>
        /// Item image.
        /// </summary>
        [DefaultValue(null)]
        public virtual Image ItemImage
        {
            get
            {
                return _ItemImage;
            }
            set
            {
                _ItemImage = value;
                Refresh();
            }
        }

        /// <summary>
        /// Item description.
        /// </summary>
        [DefaultValue("Cake - a lie.")]
        public virtual string ItemDesc
        {
            get
            {
                return _ItemDesc;
            }
            set
            {
                _ItemDesc = value;
                Refresh();
            }
        }

        /// <summary>
        /// Item amount.
        /// </summary>
        [DefaultValue(0)]
        public virtual int ItemAmount
        {
            get
            {
                return _ItemAmount;
            }
            set
            {
                _ItemAmount = value;
                Refresh();
                OnAmountChanged(new InvItemEventArgs(value));
            }
        }

        /// <summary>
        /// Item name.
        /// </summary>
        [DefaultValue("Cake")]
        public virtual string ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;
                Refresh();
            }
        }

        /// <summary>
        /// Name label color.
        /// </summary>
        [DefaultValue(typeof(Color), "Red")]
        public virtual Color ColorName
        {
            get
            {
                return _ColorName;
            }
            set
            {
                _ColorName = value;
                Refresh();
            }
        }

        /// <summary>
        /// Description label color.
        /// </summary>
        [DefaultValue(typeof(Color), "Blue")]
        public virtual Color ColorDesc
        {
            get
            {
                return _ColorDesc;
            }
            set
            {
                _ColorDesc = value;
                Refresh();
            }
        }

        /// <summary>
        /// Amount label color.
        /// </summary>
        [DefaultValue(typeof(Color), "Green")]
        public virtual Color ColorAmount
        {
            get
            {
                return _ColorAmount;
            }
            set
            {
                _ColorAmount = value;
                Refresh();
            }
        }

        /// <summary>
        /// Show Item Amount?
        /// </summary>
        [DefaultValue(true)]
        public virtual bool ShowAmount
        {
            get { return _ShowAmount; }
            set { _ShowAmount = value; Refresh(); }
        }

        /// <summary>
        /// Control background color.
        /// </summary>
        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor { get; set; } = Color.Transparent;
        #endregion Props

        /// <summary>
        /// Raises the <see cref="E:AmountChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="InvItemEventArgs"/> instance containing the event data.</param>
        public void OnAmountChanged(InvItemEventArgs e)
        {
            AmountChanged?.Invoke(this, e);
        }
    }

    /// <summary>
    /// Inventory Item event arguments.
    /// </summary>
    public class InvItemEventArgs
    {
        /// <summary>
        /// Inventory Item event arguments.
        /// </summary>
        /// <param name="amount">Item amount.</param>
        public InvItemEventArgs(int amount)
        {
            Amount = amount;
        }

        /// <summary>
        /// Item amount.
        /// </summary>
        public int Amount { get; private set; }
    }
}
