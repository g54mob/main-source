using System;
using NAudio.Dmo;
using NAudio.Wave;

namespace NAudio.FileFormats.Mp3
{
	public class DmoMp3FrameDecompressor : IMp3FrameDecompressor, IDisposable
	{
		private WindowsMediaMp3Decoder mp3Decoder;

		private WaveFormat pcmFormat;

		private MediaBuffer inputMediaBuffer;

		private DmoOutputDataBuffer outputBuffer;

		private bool reposition;

		public WaveFormat OutputFormat => null;

		public DmoMp3FrameDecompressor(WaveFormat sourceFormat)
		{
		}

		public int DecompressFrame(Mp3Frame frame, byte[] dest, int destOffset)
		{
			return 0;
		}

		public void Reset()
		{
		}

		public void Dispose()
		{
		}
	}
}
