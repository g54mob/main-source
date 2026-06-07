using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DV.Radio
{
	[Serializable]
	public class RecordInfo
	{
		public string rawInfo = string.Empty;

		public float durationSeconds;

		private string title;

		private string artist;

		private string streamTitle;

		private string streamUrl;

		private const string streamTitleString = "StreamTitle='";

		private const string streamUrlString = "StreamUrl='";

		private static readonly char[] splitChar = new char[1] { '-' };

		private static readonly Regex lyricsRegex = new Regex("[^A-Za-z0-9]+");

		public string Title
		{
			get
			{
				if (title == null)
				{
					ParseStreamTitle();
				}
				return title;
			}
			set
			{
				title = value;
			}
		}

		public string Artist
		{
			get
			{
				if (artist == null)
				{
					ParseStreamTitle();
				}
				return artist;
			}
			set
			{
				artist = value;
			}
		}

		public string StreamTitle
		{
			get
			{
				if (streamTitle == null)
				{
					ParseStreamTitle();
				}
				return streamTitle;
			}
			set
			{
				streamTitle = value;
			}
		}

		public string StreamUrl
		{
			get
			{
				if (streamUrl == null)
				{
					ParseStreamUrl();
				}
				return streamUrl;
			}
			set
			{
				streamUrl = value;
			}
		}

		public RecordInfo()
		{
		}

		public RecordInfo(string rawInfo)
			: this()
		{
			this.rawInfo = rawInfo.Trim();
			ParseStreamTitle();
		}

		private void ParseStreamTitle()
		{
			title = string.Empty;
			artist = string.Empty;
			streamTitle = string.Empty;
			int num = rawInfo.IndexOf("StreamTitle='", StringComparison.OrdinalIgnoreCase);
			if (num == -1)
			{
				return;
			}
			string text = rawInfo.Substring(num + "StreamTitle='".Length);
			int num2 = text.IndexOf("';");
			if (num2 == -1)
			{
				return;
			}
			streamTitle = text.Substring(0, num2).Replace('\u02d7', '-').Replace('@', ' ')
				.Replace('*', ' ')
				.Replace('+', ' ')
				.Replace('\\', '-')
				.Replace('/', '-')
				.Trim();
			string[] array = streamTitle.Split(splitChar, 2);
			if (array.Length >= 2)
			{
				artist = array[0].Trim();
				string text2 = array[array.Length - 1];
				int num3 = text2.IndexOf('|');
				if (num3 > 0)
				{
					text2 = text2.Substring(0, num3);
				}
				title = text2.Trim();
			}
			else if (array.Length == 1)
			{
				title = array[0].Trim();
			}
		}

		private void ParseStreamUrl()
		{
			streamUrl = string.Empty;
			int num = rawInfo.IndexOf("StreamUrl='", StringComparison.OrdinalIgnoreCase);
			if (num != -1)
			{
				string text = rawInfo.Substring(num + "StreamUrl='".Length);
				int num2 = text.IndexOf("'");
				if (num2 != -1)
				{
					streamUrl = text.Substring(0, num2);
				}
			}
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			RecordInfo recordInfo = (RecordInfo)obj;
			if (title == recordInfo.title && artist == recordInfo.artist && streamTitle == recordInfo.streamTitle)
			{
				return streamUrl == recordInfo.streamUrl;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = 0;
			if (title != null)
			{
				num += title.GetHashCode();
			}
			if (artist != null)
			{
				num += artist.GetHashCode();
			}
			if (streamTitle != null)
			{
				num += streamTitle.GetHashCode();
			}
			if (streamUrl != null)
			{
				num += streamUrl.GetHashCode();
			}
			return num;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(GetType().Name);
			stringBuilder.Append("{");
			stringBuilder.Append("Duration='");
			stringBuilder.Append(durationSeconds);
			stringBuilder.Append(", ");
			stringBuilder.Append("Title='");
			stringBuilder.Append(Title);
			stringBuilder.Append(", ");
			stringBuilder.Append("Artist='");
			stringBuilder.Append(Artist);
			stringBuilder.Append(", ");
			stringBuilder.Append("StreamTitle='");
			stringBuilder.Append(streamTitle);
			stringBuilder.Append(", ");
			stringBuilder.Append("StreamUrl='");
			stringBuilder.Append(StreamUrl);
			stringBuilder.Append(", ");
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}
	}
}
