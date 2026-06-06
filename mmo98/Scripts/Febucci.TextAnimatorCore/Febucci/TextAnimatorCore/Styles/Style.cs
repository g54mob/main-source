using System;

namespace Febucci.TextAnimatorCore.Styles
{
	[Serializable]
	public struct Style
	{
		public string styleTag;

		public string openingTag;

		public string closingTag;

		public Style(string styleTag, string openingTag, string closingTag)
		{
			this.styleTag = styleTag;
			this.openingTag = openingTag;
			this.closingTag = closingTag;
		}
	}
}
