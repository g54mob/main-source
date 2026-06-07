using System.Windows.Forms;

namespace NAudio.Wave
{
	internal class WaveWindowNative : NativeWindow
	{
		private WaveInterop.WaveCallback waveCallback;

		public WaveWindowNative(WaveInterop.WaveCallback waveCallback)
		{
		}

		protected override void WndProc(ref Message m)
		{
		}
	}
}
