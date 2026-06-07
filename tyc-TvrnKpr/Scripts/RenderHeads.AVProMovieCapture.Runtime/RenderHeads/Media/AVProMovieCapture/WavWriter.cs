using System;
using System.IO;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class WavWriter : IDisposable
	{
		public enum SampleFormat
		{
			PCM16 = 2,
			Float32 = 4
		}

		private static byte[] RIFF_HEADER;

		private static byte[] FORMAT_WAVE;

		private static byte[] FORMAT_TAG;

		private static byte[] AUDIO_FORMAT_PCM;

		private static byte[] AUDIO_FORMAT_FLOAT;

		private static byte[] SUBCHUNK_ID;

		private static byte[] FACTCHUNK_ID;

		private const int BufferDuration = 4;

		private FileStream _stream;

		private byte[] _outBytes;

		private int _byteCount;

		private int _byteCountTotal;

		private int _channelCount;

		private int _sampleRate;

		private SampleFormat _sampleFormat;

		private int _headerSize;

		public WavWriter(string path, int channelCount, int sampleRate, SampleFormat sampleFormat = SampleFormat.Float32)
		{
		}

		public void Dispose()
		{
		}

		public void WriteInterleaved(float[] data, int dataLength = -1)
		{
		}

		public void WriteHeader(int byteStreamSize)
		{
		}

		private static byte[] PackageInt(int source, int length = 2)
		{
			return null;
		}
	}
}
