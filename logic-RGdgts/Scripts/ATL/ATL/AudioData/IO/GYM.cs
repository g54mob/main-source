using System.IO;

namespace ATL.AudioData.IO
{
	internal class GYM : MetaDataIO, IAudioDataIO
	{
		private static readonly byte[] GYM_SIGNATURE;

		private static uint LOOP_COUNT_DEFAULT;

		private static uint FADEOUT_DURATION_DEFAULT;

		private static uint PLAYBACK_RATE_DEFAULT;

		private static byte[] CORE_SIGNATURE;

		private int sampleRate;

		private double bitrate;

		private double duration;

		private uint loopStart;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		public int SampleRate => 0;

		public bool IsVBR => false;

		public Format AudioFormat { get; }

		public int CodecFamily => 0;

		public string FileName => null;

		public double BitRate => 0.0;

		public int BitDepth => 0;

		public double Duration => 0.0;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public long AudioDataOffset { get; set; }

		public long AudioDataSize { get; set; }

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		protected override MetaDataIOFactory.TagType getImplementedTagType()
		{
			return default(MetaDataIOFactory.TagType);
		}

		protected override TagData.Field getFrameMapping(string zone, string ID, byte tagVersion)
		{
			return default(TagData.Field);
		}

		private void resetData()
		{
		}

		public GYM(string filePath, Format format)
		{
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		private bool readHeader(BufferedBinaryReader source, ReadTagParams readTagParams)
		{
			return false;
		}

		private uint calculateDuration(BufferedBinaryReader source, uint loopStart, uint nbLoops)
		{
			return 0u;
		}

		public bool Read(Stream source, AudioDataManager.SizeInfo sizeInfo, ReadTagParams readTagParams)
		{
			return false;
		}

		protected override bool read(Stream source, ReadTagParams readTagParams)
		{
			return false;
		}
	}
}
