using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class S3M : MetaDataIO, IAudioDataIO
	{
		private sealed class Instrument
		{
			public byte Type;

			public string FileName;

			public string DisplayName;
		}

		private sealed class S3MEvent
		{
			public byte Command;

			public byte Info;
		}

		private IList<byte> FChannelTable;

		private IList<byte> FPatternTable;

		private IList<IList<IList<S3MEvent>>> FPatterns;

		private IList<Instrument> FInstruments;

		private byte initialSpeed;

		private byte initialTempo;

		private string trackerName;

		private double bitrate;

		private double duration;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		private readonly Format audioFormat;

		public int SampleRate => 0;

		public bool IsVBR => false;

		public Format AudioFormat => null;

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

		public S3M(string filePath, Format format)
		{
		}

		private double calculateDuration()
		{
			return 0.0;
		}

		private string getTrackerName(ushort trackerVersion)
		{
			return null;
		}

		private void readInstruments(BufferedBinaryReader source, IList<ushort> instrumentPointers)
		{
		}

		private void readPatterns(BufferedBinaryReader source, IList<ushort> patternPointers)
		{
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
