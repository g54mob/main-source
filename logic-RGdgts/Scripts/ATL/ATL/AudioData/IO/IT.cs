using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class IT : MetaDataIO, IAudioDataIO
	{
		private sealed class Instrument
		{
			public string FileName;

			public string DisplayName;
		}

		private sealed class Event
		{
			public int Channel;

			public byte Command;

			public byte Info;
		}

		private static readonly byte[] IT_SIGNATURE;

		private IList<byte> patternTable;

		private IList<IList<IList<Event>>> patterns;

		private IList<Instrument> instruments;

		private byte initialSpeed;

		private byte initialTempo;

		private double bitrate;

		private double duration;

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

		protected void resetData()
		{
		}

		public IT(string filePath, Format format)
		{
		}

		private double calculateDuration()
		{
			return 0.0;
		}

		private void readSamples(BufferedBinaryReader source, IList<uint> samplePointers)
		{
		}

		private void readInstruments(BufferedBinaryReader source, IList<uint> instrumentPointers)
		{
		}

		private void readInstrumentsOld(BufferedBinaryReader source, IList<uint> instrumentPointers)
		{
		}

		private void readPatterns(BufferedBinaryReader source, IList<uint> patternPointers)
		{
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
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
