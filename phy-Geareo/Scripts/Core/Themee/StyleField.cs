using System;

namespace Themee
{
	[Serializable]
	public class StyleField
	{
		public StyleEntry entry;

		public StyleConfig inline;

		public string path;

		public StyleConfig GetStyle(Theme theme)
		{
			return null;
		}
	}
}
