using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class CAF : MetaDataIO, IAudioDataIO
	{
		private static Dictionary<uint, ChannelsArrangements.ChannelsArrangement> channelsMapping;

		private static Dictionary<string, KeyValuePair<int, string>> formatsMapping;

		private static Dictionary<string, TagData.Field> frameMapping;

		private Format containerAudioFormat;

		private KeyValuePair<int, string> containeeAudioFormat;

		private uint sampleRate;

		private bool isVbr;

		private int codecFamily;

		private double bitrate;

		private double duration;

		private uint channelsPerFrame;

		private uint bitsPerChannel;

		private double secondsPerByte;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private readonly string filePath;

		public bool IsVBR => false;

		public Format AudioFormat => null;

		public int CodecFamily => 0;

		public string FileName => null;

		public double BitRate => 0.0;

		public int BitDepth => 0;

		public double Duration => 0.0;

		public int SampleRate => 0;

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

		public CAF(string filePath, Format format)
		{
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		private bool readFileHeader(BufferedBinaryReader source)
		{
			return false;
		}

		private void readAudioDescriptionChunk(BufferedBinaryReader source)
		{
		}

		private void readChannelLayoutChunk(BufferedBinaryReader source)
		{
		}

		private void readStringChunk(BufferedBinaryReader source, string id, long chunkSize)
		{
		}

		private void readStringsChunk(BufferedBinaryReader source)
		{
		}

		private void readInfoChunk(BufferedBinaryReader source, bool readAllMetaFrames)
		{
		}

		private void readPaktChunk(BufferedBinaryReader source)
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
