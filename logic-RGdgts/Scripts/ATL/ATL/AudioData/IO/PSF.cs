using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ATL.AudioData.IO
{
	internal class PSF : MetaDataIO, IAudioDataIO
	{
		private sealed class PSFHeader
		{
			public byte[] FormatTag;

			public byte VersionByte;

			public uint ReservedAreaLength;

			public uint CompressedProgramLength;

			public void Reset()
			{
			}
		}

		private sealed class PSFTag
		{
			public string TagHeader;

			public int size;

			public void Reset()
			{
			}
		}

		private static readonly byte[] PSF_FORMAT_TAG;

		private byte version;

		private int sampleRate;

		private double bitrate;

		private double duration;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		private readonly Format audioFormat;

		private static IDictionary<string, TagData.Field> frameMapping;

		private static IList<string> playbackFrames;

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

		public PSF(string filePath, Format format)
		{
		}

		private string subformat()
		{
			return null;
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		private bool readHeader(Stream source, ref PSFHeader header)
		{
			return false;
		}

		private string readPSFLine(Stream source, Encoding encoding)
		{
			return null;
		}

		private bool readTag(Stream source, ref PSFTag tag, ReadTagParams readTagParams)
		{
			return false;
		}

		private double parsePSFDuration(string durationStr)
		{
			return 0.0;
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
