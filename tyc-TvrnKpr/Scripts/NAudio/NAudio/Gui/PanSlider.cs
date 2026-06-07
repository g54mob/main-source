using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace NAudio.Gui
{
	public class PanSlider : UserControl
	{
		private Container components;

		private float pan;

		public float Pan
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public event EventHandler PanChanged
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

		private void SetPanFromMouse(int x)
		{
		}
	}
}
