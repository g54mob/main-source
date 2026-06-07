using System;

namespace UI
{
	[Serializable]
	public struct ColorScheme
	{
		public TextColorMapper normal;

		public TextColorMapper highlighted;

		public TextColorMapper pressed;

		public TextColorMapper selected;

		public TextColorMapper disabled;
	}
}
