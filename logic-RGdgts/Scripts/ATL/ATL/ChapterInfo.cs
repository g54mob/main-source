using System.Runtime.CompilerServices;

namespace ATL
{
	public class ChapterInfo
	{
		public class UrlInfo
		{
			public string Description { get; set; }

			public string Url { get; set; }

			public UrlInfo(string description, string url)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private uint _003CEndOffset_003Ek__BackingField;

		[CompilerGenerated]
		private bool _003CUseOffset_003Ek__BackingField;

		[CompilerGenerated]
		private string _003CSubtitle_003Ek__BackingField;

		[CompilerGenerated]
		private UrlInfo _003CUrl_003Ek__BackingField;

		[CompilerGenerated]
		private PictureInfo _003CPicture_003Ek__BackingField;

		public uint StartTime { get; set; }

		public uint EndTime { get; set; }

		public uint StartOffset { get; set; }

		public uint EndOffset
		{
			[CompilerGenerated]
			set
			{
				_003CEndOffset_003Ek__BackingField = value;
			}
		}

		public bool UseOffset
		{
			[CompilerGenerated]
			set
			{
				_003CUseOffset_003Ek__BackingField = value;
			}
		}

		public string Title { get; set; }

		public string UniqueID { get; set; }

		public string Subtitle
		{
			[CompilerGenerated]
			set
			{
				_003CSubtitle_003Ek__BackingField = value;
			}
		}

		public UrlInfo Url
		{
			[CompilerGenerated]
			set
			{
				_003CUrl_003Ek__BackingField = value;
			}
		}

		public PictureInfo Picture
		{
			[CompilerGenerated]
			set
			{
				_003CPicture_003Ek__BackingField = value;
			}
		}

		public ChapterInfo(uint startTime = 0u, string title = "")
		{
		}
	}
}
