using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NAudio.Gui
{
	public class VolumeMeter : Control
	{
		private Brush foregroundBrush;

		private float amplitude;

		private IContainer components;

		[DefaultValue(-3.0)]
		public float Amplitude
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[DefaultValue(-60.0)]
		public float MinDb { get; set; }

		[DefaultValue(18.0)]
		public float MaxDb { get; set; }

		[DefaultValue(Orientation.Vertical)]
		public Orientation Orientation { get; set; }

		protected override void OnForeColorChanged(EventArgs e)
		{
		}

		protected override void OnPaint(PaintEventArgs pe)
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
