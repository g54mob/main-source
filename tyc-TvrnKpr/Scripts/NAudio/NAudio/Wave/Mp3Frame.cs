using System.IO;

namespace NAudio.Wave
{
	public class Mp3Frame
	{
		private static readonly int[,,] bitRates;

		private static readonly int[,] samplesPerFrame;

		private static readonly int[] sampleRatesVersion1;

		private static readonly int[] sampleRatesVersion2;

		private static readonly int[] sampleRatesVersion25;

		private const int MaxFrameLength = 16384;

		public int SampleRate { get; private set; }

		public int FrameLength { get; private set; }

		public int BitRate { get; private set; }

		public byte[] RawData { get; private set; }

		public MpegVersion MpegVersion { get; private set; }

		public MpegLayer MpegLayer { get; private set; }

		public ChannelMode ChannelMode { get; private set; }

		public int SampleCount { get; private set; }

		public int ChannelExtension { get; private set; }

		public int BitRateIndex { get; private set; }

		public bool Copyright { get; private set; }

		public bool CrcPresent { get; private set; }

		public long FileOffset { get; private set; }

		public static Mp3Frame LoadFromStream(Stream input)
		{
			return null;
		}

		public static Mp3Frame LoadFromStream(Stream input, bool readData)
		{
			return null;
		}

		private Mp3Frame()
		{
		}

		private static bool IsValidHeader(byte[] headerBytes, Mp3Frame frame)
		{
			return false;
		}
	}
}
