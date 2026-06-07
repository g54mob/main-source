using System.Windows.Forms;

namespace NAudio.Wave
{
	internal class WaveWindow : Form
	{
		private WaveInterop.WaveCallback waveCallback;

		public WaveWindow(WaveInterop.WaveCallback waveCallback)
		{
		}

		protected override void WndProc(ref Message m)
		{
		}
	}
}
