﻿namespace PearXLib.Engine
{
    partial class XImgButton
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // XImgButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Name = "XImgButton";
            this.Size = new System.Drawing.Size(128, 64);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.XImgButton_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XImgButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.XImgButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.XImgButton_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XImgButton_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}