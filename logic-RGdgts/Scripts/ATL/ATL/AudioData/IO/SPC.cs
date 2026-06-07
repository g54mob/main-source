using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class SPC : MetaDataIO, IAudioDataIO
	{
		private sealed class SpcHeader
		{
			public long Size;

			public byte TagInHeader;

			public void Reset()
			{
			}
		}

		private sealed class SpcExTags
		{
			public string FormatTag;

			public uint Size;

			public void Reset()
			{
			}
		}

		private static readonly byte[] SPC_FORMAT_TAG;

		private int sampleRate;

		private double bitrate;

		private double duration;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		private static IDictionary<byte, TagData.Field> extendedFrameMapping;

		private static IDictionary<byte, TagData.Field> headerFrameMapping;

		private static IList<byte> playbackFrames;

		private static IDictionary<byte, byte> extendedFrameTypes;

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

		public SPC(string filePath, Format format)
		{
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		private bool readHeader(Stream source, ref SpcHeader header)
		{
			return false;
		}

		private void readHeaderTags(Stream source, ref SpcHeader header, ReadTagParams readTagParams)
		{
		}

		private int isText(byte[] data)
		{
			return 0;
		}

		private void readExtendedData(Stream source, ref SpcExTags footer, ReadTagParams readTagParams)
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
