using System.ComponentModel;
using System.Windows.Forms;
using NAudio.Wave;

namespace NAudio.Gui
{
	public class WaveViewer : UserControl
	{
		private Container components;

		private WaveStream waveStream;

		private int samplesPerPixel;

		private long startPosition;

		private int bytesPerSample;

		public WaveStream WaveStream
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int SamplesPerPixel
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public long StartPosition
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		protected override void Dispose(bool disposing)
		{
		}

		protected override void OnPaint(PaintEventArgs e)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
