using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace NAudio.Gui
{
	public class VolumeSlider : UserControl
	{
		private Container components;

		private float volume;

		private float MinDb;

		[DefaultValue(1f)]
		public float Volume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public event EventHandler VolumeChanged
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

		protected override void Dispose(bool disposing)
		{
		}

		private void InitializeComponent()
		{
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
		}

		private void SetVolumeFromMouse(int x)
		{
		}
	}
}
