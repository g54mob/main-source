using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ATL.AudioData.IO
{
	public class ID3v2 : MetaDataIO
	{
		private sealed class FrameHeader
		{
			public string ID;

			public int Size;

			public ushort Flags;
		}

		private sealed class TagInfo
		{
			public byte[] ID;

			public byte Version;

			public byte Revision;

			public byte Flags;

			public byte[] Size;

			public long FileSize;

			public long HeaderEnd;

			public long PaddingOffset;

			public long ActualEnd;

			public int ExtendedHeaderSize;

			public int ExtendedFlags;

			public int CRC;

			public int TagRestrictions;

			public bool UsesUnsynchronisation => false;

			public bool HasExtendedHeader => false;

			public bool HasFooter => false;

			public int GetSize(bool includeFooter = true)
			{
				return 0;
			}

			public long GetPaddingSize()
			{
				return 0L;
			}
		}

		private sealed class BomProperties
		{
			public bool Found;

			public int Size;

			public Encoding Encoding;
		}

		private sealed class RichStructure
		{
			public string LanguageCode;

			public string ContentDescriptor;

			public int Size;

			public byte TimestampFormat;

			public byte ContentType;
		}

		private TagInfo tagHeader;

		private static readonly byte[] BOM_UTF16_LE;

		private static readonly byte[] BOM_UTF16_BE;

		private static readonly byte[] BOM_NONE;

		private static readonly byte[] NULLTERMINATOR;

		private static readonly byte[] NULLTERMINATOR_2;

		private static readonly ICollection<string> standardFrames_v23;

		private static readonly ICollection<string> standardFrames_v24;

		private static readonly ICollection<string> commentsFields;

		private static readonly ICollection<string> noTextEncodingFields;

		private static readonly ICollection<string> misencodedSizev4Fields;

		private static readonly ICollection<string> multipleValuev23Fields;

		private static readonly IDictionary<string, TagData.Field> frameMapping_v22;

		private static readonly IDictionary<string, TagData.Field> frameMapping_v23;

		private static readonly IDictionary<string, TagData.Field> frameMapping_v24;

		private static readonly IDictionary<string, string> frameMapping_v22_4;

		private static readonly IDictionary<string, string> frameMapping_v23_4;

		private static readonly IDictionary<string, string> frameMapping_v22_3;

		private static readonly IDictionary<string, string> frameMapping_v24_3;

		public override IList<Format> MetadataFormats => null;

		protected override MetaDataIOFactory.TagType getImplementedTagType()
		{
			return default(MetaDataIOFactory.TagType);
		}

		static ID3v2()
		{
		}

		protected override TagData.Field getFrameMapping(string zone, string ID, byte tagVersion)
		{
			return default(TagData.Field);
		}

		public static bool isValidHeader(byte[] data)
		{
			return false;
		}

		private bool readHeader(BufferedBinaryReader SourceFile, TagInfo Tag, long offset)
		{
			return false;
		}

		private static RichStructure readCommentStructure(BufferedBinaryReader source, int tagVersion, int encodingCode, Encoding encoding)
		{
			return null;
		}

		private static RichStructure readSynchedLyricsStructure(BufferedBinaryReader source, int tagVersion, int encodingCode, Encoding encoding)
		{
			return null;
		}

		private static LyricsInfo.LyricsPhrase readLyricsPhrase(BufferedBinaryReader source, Encoding encoding)
		{
			return null;
		}

		private bool readFrame(BufferedBinaryReader source, TagInfo tag, ReadTagParams readTagParams, ref IList<MetaFieldInfo> comments, bool inChapter = false)
		{
			return false;
		}

		private void readFrames(BufferedBinaryReader source, TagInfo tag, long offset, ReadTagParams readTagParams)
		{
		}

		protected override bool read(Stream source, ReadTagParams readTagParams)
		{
			return false;
		}

		public bool Read(Stream source, long offset, ReadTagParams readTagParams)
		{
			return false;
		}

		private static string extractGenreFromID3v2Code(string iGenre)
		{
			return null;
		}

		private static int readRatingInPopularityMeter(BufferedBinaryReader Source, Encoding encoding)
		{
			return 0;
		}

		private static BomProperties readBOM(Stream source)
		{
			return null;
		}

		public static PictureInfo.PIC_TYPE DecodeID3v2PictureType(int picCode)
		{
			return default(PictureInfo.PIC_TYPE);
		}

		private static byte[] decodeUnsynchronizedStream(BufferedBinaryReader from, int length)
		{
			return null;
		}

		private static Encoding decodeID3v2CharEncoding(byte encoding)
		{
			return null;
		}

		private static bool isUpperAlpha(string str)
		{
			return false;
		}
	}
}
