using System.IO;

namespace ATL.AudioData.IO
{
	internal class MPEGplus : IAudioDataIO
	{
		private sealed class HeaderRecord
		{
			public byte[] ByteArray;

			public int[] IntegerArray;

			private int version;

			public int Version => 0;

			public static int GetVersion(byte[] data)
			{
				return 0;
			}

			public void computeVersion()
			{
			}
		}

		private static readonly int[] MPP_SAMPLERATES;

		private int frameCount;

		private int sampleRate;

		private double bitrate;

		private double duration;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		public bool IsVBR => false;

		public Format AudioFormat { get; }

		public int CodecFamily => 0;

		public string FileName => null;

		public double BitRate => 0.0;

		public int BitDepth => 0;

		public double Duration => 0.0;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public int SampleRate => 0;

		public long AudioDataOffset { get; set; }

		public long AudioDataSize { get; set; }

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		private void resetData()
		{
		}

		public MPEGplus(string filePath, Format format)
		{
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		private bool readHeader(Stream source, ref HeaderRecord header)
		{
			return false;
		}

		private static int getSV7SampleRate(HeaderRecord header)
		{
			return 0;
		}

		private static ChannelsArrangements.ChannelsArrangement getSV7ChannelsArrangement(HeaderRecord header)
		{
			return null;
		}

		private static int getSV7FrameCount(HeaderRecord header)
		{
			return 0;
		}

		private double getSV7BitRate()
		{
			return 0.0;
		}

		private double calculateAverageBitrate(double duration)
		{
			return 0.0;
		}

		private double getSV7Duration()
		{
			return 0.0;
		}

		public bool Read(Stream source, AudioDataManager.SizeInfo sizeInfo, MetaDataIO.ReadTagParams readTagParams)
		{
			return false;
		}

		private static long readVariableSizeInteger(Stream source)
		{
			return 0L;
		}
	}
}
