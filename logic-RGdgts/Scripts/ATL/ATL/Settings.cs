using System.Text;
using ATL.AudioData;

namespace ATL
{
	public static class Settings
	{
		public static int FileBufferSize;

		public static bool ForceDiskIO;

		public static bool NullAbsentValues;

		public static bool OutputStacktracesToConsole;

		public static bool AddNewPadding;

		public static int PaddingSize;

		internal static readonly char InternalValueSeparator;

		public static char DisplayValueSeparator;

		public static bool ReadAllMetaFrames;

		public static Encoding DefaultTextEncoding;

		public static MetaDataIOFactory.TagType[] DefaultTagsWhenNoMetadata;

		public static bool UseFileNameWhenNoTitle;

		public static bool AutoFormatAdditionalDates;

		public static bool UseLeadingZeroes;

		public static bool OverrideExistingLeadingZeroesFormat;

		public static bool EnrichID3v1;

		public static bool ID3v2_useExtendedHeaderRestrictions;

		public static bool ID3v2_alwaysWriteCTOCFrame;

		public static byte ID3v2_tagSubVersion;

		public static bool ID3v2_forceAPICEncodingToLatin1;

		public static bool ID3v2_forceUnsynchronization;

		public static bool MP4_createNeroChapters;

		public static bool MP4_capNeroChapters;

		public static bool MP4_createQuicktimeChapters;

		public static bool MP4_keepExistingChapters;

		public static int MP4_readChaptersExclusive;

		public static bool ASF_keepNonWMFieldsWhenRemovingTag;

		public static int GYM_VGM_playbackRate;

		public static bool M3U_useExtendedFormat;
	}
}
