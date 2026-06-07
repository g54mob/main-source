using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ATL
{
	public class TagData
	{
		public enum Field
		{
			NO_FIELD = -1,
			GENERAL_DESCRIPTION = 0,
			TITLE = 1,
			ARTIST = 2,
			COMPOSER = 3,
			COMMENT = 4,
			GENRE = 5,
			ALBUM = 6,
			RECORDING_YEAR = 7,
			RECORDING_DATE = 8,
			RECORDING_DATE_OR_YEAR = 9,
			RECORDING_DAYMONTH = 10,
			RECORDING_TIME = 11,
			TRACK_NUMBER = 12,
			DISC_NUMBER = 13,
			RATING = 14,
			ORIGINAL_ARTIST = 15,
			ORIGINAL_ALBUM = 16,
			COPYRIGHT = 17,
			ALBUM_ARTIST = 18,
			PUBLISHER = 19,
			CONDUCTOR = 20,
			TRACK_TOTAL = 21,
			TRACK_NUMBER_TOTAL = 22,
			DISC_TOTAL = 23,
			DISC_NUMBER_TOTAL = 24,
			CHAPTERS_TOC_DESCRIPTION = 25,
			LYRICS_UNSYNCH = 26,
			PUBLISHING_DATE = 27,
			PRODUCT_ID = 28,
			SORT_ALBUM = 29,
			SORT_ALBUM_ARTIST = 30,
			SORT_ARTIST = 31,
			SORT_TITLE = 32,
			GROUP = 33,
			SERIES_TITLE = 34,
			SERIES_PART = 35,
			LONG_DESCRIPTION = 36
		}

		private static readonly ICollection<Field> numericFields;

		[CompilerGenerated]
		private int _003CTrackDigitsForLeadingZeroes_003Ek__BackingField;

		[CompilerGenerated]
		private int _003CDiscDigitsForLeadingZeroes_003Ek__BackingField;

		[CompilerGenerated]
		private long _003CPaddingSize_003Ek__BackingField;

		[CompilerGenerated]
		private double _003CDurationMs_003Ek__BackingField;

		public IList<ChapterInfo> Chapters { get; set; }

		public LyricsInfo Lyrics { get; set; }

		public IList<PictureInfo> Pictures { get; set; }

		protected IDictionary<Field, string> Fields { get; set; }

		public IList<MetaFieldInfo> AdditionalFields { get; set; }

		public int TrackDigitsForLeadingZeroes
		{
			[CompilerGenerated]
			set
			{
				_003CTrackDigitsForLeadingZeroes_003Ek__BackingField = value;
			}
		}

		public int DiscDigitsForLeadingZeroes
		{
			[CompilerGenerated]
			set
			{
				_003CDiscDigitsForLeadingZeroes_003Ek__BackingField = value;
			}
		}

		public long PaddingSize
		{
			[CompilerGenerated]
			set
			{
				_003CPaddingSize_003Ek__BackingField = value;
			}
		}

		public double DurationMs
		{
			[CompilerGenerated]
			set
			{
				_003CDurationMs_003Ek__BackingField = value;
			}
		}

		public string Item => null;

		private bool isNumeric(Field f)
		{
			return false;
		}

		public void IntegrateValue(Field key, string value)
		{
		}

		public bool hasKey(Field id)
		{
			return false;
		}

		public IDictionary<Field, string> ToMap()
		{
			return null;
		}

		public void Clear()
		{
		}

		private string emptyIfZero(string s)
		{
			return null;
		}
	}
}
