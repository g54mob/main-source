using System.IO;

namespace ATL.AudioData.IO
{
	internal class MPEGaudio : IAudioDataIO
	{
		public sealed class VBRData
		{
			public bool Found;

			public char[] ID;

			public int Frames;

			public int Bytes;

			public byte Scale;

			public string VendorID;

			public void Reset()
			{
			}
		}

		public sealed class FrameHeader
		{
			public bool Found;

			public long Position;

			public int Size;

			public bool Xing;

			public byte VersionID;

			public byte LayerID;

			public bool ProtectionBit;

			public ushort BitRateID;

			public ushort SampleRateID;

			public bool PaddingBit;

			public bool PrivateBit;

			public byte ModeID;

			public byte ModeExtensionID;

			public bool CopyrightBit;

			public bool OriginalBit;

			public byte EmphasisID;

			public void Reset()
			{
			}

			public void LoadFromByteArray(byte[] data)
			{
			}
		}

		public static readonly ushort[,,] MPEG_BIT_RATE;

		public static readonly ushort[,] MPEG_SAMPLE_RATE;

		public static readonly string[] MPEG_VERSION;

		public static readonly string[] MPEG_LAYER;

		public static readonly string[] MPEG_CM_MODE;

		public static readonly string[] MPEG_EMPHASIS;

		public static readonly string[] MPEG_ENCODER;

		private VBRData vbrData;

		private FrameHeader HeaderFrame;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		private readonly Format audioFormat;

		public bool IsVBR => false;

		public double BitRate => 0.0;

		public int BitDepth => 0;

		public double Duration => 0.0;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public int SampleRate => 0;

		public string FileName => null;

		public long AudioDataOffset { get; set; }

		public long AudioDataSize { get; set; }

		public Format AudioFormat => null;

		public int CodecFamily => 0;

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		protected void resetData()
		{
		}

		public MPEGaudio(string filePath, Format format)
		{
		}

		public static bool IsValidFrameHeader(byte[] data)
		{
			return false;
		}

		private static byte getCoefficient(FrameHeader Frame)
		{
			return 0;
		}

		private static ushort getBitRate(FrameHeader Frame)
		{
			return 0;
		}

		private static ushort getSampleRate(FrameHeader Frame)
		{
			return 0;
		}

		private static byte getPadding(FrameHeader Frame)
		{
			return 0;
		}

		private double getBitRate()
		{
			return 0.0;
		}

		private ushort getSampleRate()
		{
			return 0;
		}

		private static int getFrameSize(FrameHeader Frame)
		{
			return 0;
		}

		private static VBRData getXingInfo(Stream source)
		{
			return null;
		}

		private static VBRData getFhGInfo(Stream source)
		{
			return null;
		}

		private static VBRData findVBR(Stream source, long position)
		{
			return null;
		}

		private string getLayer()
		{
			return null;
		}

		private static byte getVBRDeviation(FrameHeader Frame)
		{
			return 0;
		}

		private double getDuration()
		{
			return 0.0;
		}

		private ChannelsArrangements.ChannelsArrangement getChannelsArrangement(FrameHeader frame)
		{
			return null;
		}

		public static bool HasValidFrame(Stream source)
		{
			return false;
		}

		private static FrameHeader findFrame(Stream source, ref VBRData oVBR, AudioDataManager.SizeInfo sizeInfo)
		{
			return null;
		}

		public bool Read(Stream source, AudioDataManager.SizeInfo sizeInfo, MetaDataIO.ReadTagParams readTagParams)
		{
			return false;
		}
	}
}
