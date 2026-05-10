using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Ookii.Dialogs
{
	public class ExtendedForm : Form
	{
		private bool _useSystemFont;

		private Padding _glassMargin;

		private bool _allowGlassDragging;

		[DefaultValue(false)]
		[Category("Appearance")]
		[Description("Indicates whether or not the form automatically uses the system default font.")]
		public bool UseSystemFont
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Category("Appearance")]
		[Description("The glass margins of the form.")]
		public Padding GlassMargin
		{
			get
			{
				return default(Padding);
			}
			set
			{
			}
		}

		[Category("Behavior")]
		[Description("Indicates whether the form can be dragged by the glass areas inside the client area.")]
		[DefaultValue(true)]
		public bool AllowGlassDragging
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event EventHandler DwmCompositionChanged
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

		protected virtual void OnDwmCompositionChanged(EventArgs e)
		{
		}

		protected override void OnLoad(EventArgs e)
		{
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
		}

		protected override void OnResize(EventArgs e)
		{
		}

		protected override void OnHandleCreated(EventArgs e)
		{
		}

		protected override void WndProc(ref Message m)
		{
		}

		protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
		{
		}

		private void EnableGlass()
		{
		}

		private void PaintGlassArea(PaintEventArgs pevent, Brush brush)
		{
		}

		private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
		{
		}
	}
}
