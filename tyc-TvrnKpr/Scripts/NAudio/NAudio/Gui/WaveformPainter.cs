using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NAudio.Gui
{
	public class WaveformPainter : Control
	{
		private Pen foregroundPen;

		private List<float> samples;

		private int maxSamples;

		private int insertPos;

		private IContainer components;

		protected override void OnResize(EventArgs e)
		{
		}

		protected override void OnForeColorChanged(EventArgs e)
		{
		}

		public void AddMax(float maxSample)
		{
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
		}

		private float GetSample(int index)
		{
			return 0f;
		}

		protected override void Dispose(bool disposing)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
