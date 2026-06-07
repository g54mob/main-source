using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class WMA : MetaDataIO, IAudioDataIO
	{
		private sealed class FileData
		{
			public long HeaderSize;

			public int FormatTag;

			public ushort Channels;

			public int SampleRate;

			public uint ObjectCount;

			public long ObjectListOffset;

			public void Reset()
			{
			}
		}

		private static readonly byte[] WMA_HEADER_ID;

		private static readonly byte[] WMA_HEADER_EXTENSION_ID;

		private static readonly byte[] WMA_METADATA_OBJECT_ID;

		private static readonly byte[] WMA_METADATA_LIBRARY_OBJECT_ID;

		private static readonly byte[] WMA_FILE_PROPERTIES_ID;

		private static readonly byte[] WMA_STREAM_PROPERTIES_ID;

		private static readonly byte[] WMA_CONTENT_DESCRIPTION_ID;

		private static readonly byte[] WMA_EXTENDED_CONTENT_DESCRIPTION_ID;

		private static readonly byte[] WMA_LANGUAGE_LIST_OBJECT_ID;

		private FileData fileData;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private int sampleRate;

		private bool isVBR;

		private bool isLossless;

		private double bitrate;

		private double duration;

		public static readonly IDictionary<string, TagData.Field> frameMapping;

		private static readonly IList<string> embeddedFields;

		private static ConcurrentDictionary<string, ushort> frameClasses;

		private IList<string> languages;

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

		protected override byte ratingConvention => 0;

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		protected override TagData.Field getFrameMapping(string zone, string ID, byte tagVersion)
		{
			return default(TagData.Field);
		}

		protected override MetaDataIOFactory.TagType getImplementedTagType()
		{
			return default(MetaDataIOFactory.TagType);
		}

		private void resetData()
		{
		}

		public WMA(string filePath, Format format)
		{
		}

		private static void addFrameClass(string frameCode, ushort frameClass)
		{
		}

		private void cacheLanguageIndex(Stream source)
		{
		}

		private string decodeLanguage(Stream source, ushort languageIndex)
		{
			return null;
		}

		private void readContentDescription(BufferedBinaryReader source, ReadTagParams readTagParams)
		{
		}

		private void readHeaderExtended(BufferedBinaryReader source, long sizePosition1, ulong size1, long sizePosition2, ulong size2, ReadTagParams readTagParams)
		{
		}

		private void readExtendedContentDescription(BufferedBinaryReader source, ReadTagParams readTagParams)
		{
		}

		public void readTagField(BufferedBinaryReader source, string zoneCode, string fieldName, ushort fieldDataType, int fieldDataSize, ReadTagParams readTagParams, bool isExtendedHeader = false, ushort languageIndex = 0, ushort streamNumber = 0)
		{
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		private bool readData(Stream source, ReadTagParams readTagParams)
		{
			return false;
		}

		private bool isValid(FileData Data)
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
