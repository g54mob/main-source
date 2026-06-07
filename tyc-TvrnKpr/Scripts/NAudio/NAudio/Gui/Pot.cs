using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace NAudio.Gui
{
	public class Pot : UserControl
	{
		private double minimum;

		private double maximum;

		private double value;

		private int beginDragY;

		private double beginDragValue;

		private bool dragging;

		private IContainer components;

		public double Minimum
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Maximum
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Value
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public event EventHandler ValueChanged
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

		private void SetValue(double newValue, bool raiseEvents)
		{
		}

		protected override void OnPaint(PaintEventArgs e)
		{
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
		}

		protected override void OnMouseMove(MouseEventArgs e)
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
