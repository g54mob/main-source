using System;

namespace DV.Radio
{
	[Serializable]
	public class RadioStationInfo
	{
		public string Name = "";

		public string URL = "";

		public AudioFormat Format = AudioFormat.MP3;

		[NonSerialized]
		public string ServerName = "";

		[NonSerialized]
		public string ServerURL = "";

		[NonSerialized]
		public string ServerNotice = "";

		[NonSerialized]
		public string ServerGenres = "";

		[NonSerialized]
		public int ServerBitrate = -1;

		private const char splitCharText = ';';

		public RadioStationInfo()
		{
		}

		public RadioStationInfo(string name, string url, AudioFormat format)
			: this()
		{
			Name = name;
			URL = url;
			Format = format;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			return URL == ((RadioStationInfo)obj).URL;
		}

		public override int GetHashCode()
		{
			if (URL != null)
			{
				return URL.GetHashCode();
			}
			return base.GetHashCode();
		}

		public static string Validate(RadioStationInfo s)
		{
			if (s == null)
			{
				return "RadioStationInfo instance is null";
			}
			if (string.IsNullOrEmpty(s.URL))
			{
				return "RadioStationInfo URL is null or empty";
			}
			if (!IsValidURL(s.URL))
			{
				return "RadioStationInfo URL is not valid '" + s.URL + "'";
			}
			if (s.Format != AudioFormat.MP3 && s.Format != AudioFormat.OGG)
			{
				return "RadioStationInfo '" + s.URL + "' audio format '" + s.URL + "' is not supported";
			}
			return null;
		}

		private static bool IsValidURL(string url)
		{
			if (!string.IsNullOrEmpty(url))
			{
				if (!url.StartsWith("file://", StringComparison.OrdinalIgnoreCase) && !url.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
				{
					return url.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
				}
				return true;
			}
			return false;
		}
	}
}
