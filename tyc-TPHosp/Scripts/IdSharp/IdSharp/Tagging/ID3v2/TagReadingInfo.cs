namespace IdSharp.Tagging.ID3v2
{
	public sealed class TagReadingInfo
	{
		private ID3v2TagVersion m_TagVersion;

		private TagVersionOptions m_TagVersionOptions;

		public ID3v2TagVersion TagVersion
		{
			get
			{
				return m_TagVersion;
			}
			set
			{
				m_TagVersion = value;
			}
		}

		public TagVersionOptions TagVersionOptions
		{
			get
			{
				return m_TagVersionOptions;
			}
			set
			{
				m_TagVersionOptions = value;
			}
		}

		public TagReadingInfo(ID3v2TagVersion tagVersion, TagVersionOptions tagVersionOptions)
		{
			m_TagVersion = tagVersion;
			m_TagVersionOptions = tagVersionOptions;
		}

		public TagReadingInfo(ID3v2TagVersion tagVersion)
			: this(tagVersion, TagVersionOptions.None)
		{
		}
	}
}
