using System.Collections.Generic;

namespace ATL
{
	public class LyricsInfo
	{
		public enum LyricsType
		{
			OTHER = 0,
			LYRICS = 1,
			TRANSCRIPTION = 2,
			MOVEMENT_NAME = 3,
			EVENT = 4,
			CHORD = 5,
			TRIVIA = 6,
			WEBPAGE_URL = 7,
			IMAGE_URL = 8
		}

		public class LyricsPhrase
		{
			public int TimestampMs { get; set; }

			public string Text { get; set; }

			public LyricsPhrase(int timestampMs, string text)
			{
			}
		}

		private bool isRemoval;

		public LyricsType ContentType { get; set; }

		public string Description { get; set; }

		public string LanguageCode { get; set; }

		public string UnsynchronizedLyrics { get; set; }

		public IList<LyricsPhrase> SynchronizedLyrics { get; set; }

		public LyricsInfo()
		{
		}

		public LyricsInfo(LyricsInfo info)
		{
		}

		public void Clear()
		{
		}
	}
}
