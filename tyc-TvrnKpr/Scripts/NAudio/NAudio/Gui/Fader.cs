using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NAudio.Gui
{
	public class Fader : Control
	{
		private int minimum;

		private int maximum;

		private float percent;

		private Orientation orientation;

		private Container components;

		private readonly int SliderHeight;

		private readonly int SliderWidth;

		private Rectangle sliderRectangle;

		private bool dragging;

		private int dragY;

		public int Minimum
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Maximum
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Orientation Orientation
		{
			get
			{
				return default(Orientation);
			}
			set
			{
			}
		}

		protected override void Dispose(bool disposing)
		{
		}

		private void DrawSlider(Graphics g)
		{
		}

		protected override void OnPaint(PaintEventArgs e)
		{
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
