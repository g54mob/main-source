using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Ookii.Dialogs
{
	internal class InputDialogForm : ExtendedForm
	{
		private SizeF _textMargin;

		private string _mainInstruction;

		private string _content;

		private IContainer components;

		private Panel _primaryPanel;

		private Panel _secondaryPanel;

		private Button _cancelButton;

		private Button _okButton;

		private TextBox _inputTextBox;

		public string MainInstruction
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Content
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Input
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int MaxLength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool UsePasswordMasking
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event EventHandler<OkButtonClickedEventArgs> OkButtonClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected virtual void OnOkButtonClicked(OkButtonClickedEventArgs e)
		{
		}

		protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
		{
		}

		private void SizeDialog()
		{
		}

		private static void DrawThemeBackground(IDeviceContext dc, VisualStyleElement element, Rectangle bounds, Rectangle clipRectangle)
		{
		}

		private void DrawText(IDeviceContext dc, ref Point location, bool measureOnly, int width)
		{
		}

		private void _primaryPanel_Paint(object sender, PaintEventArgs e)
		{
		}

		private void _secondaryPanel_Paint(object sender, PaintEventArgs e)
		{
		}

		private void NewInputBoxForm_Load(object sender, EventArgs e)
		{
		}

		private void _okButton_Click(object sender, EventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
