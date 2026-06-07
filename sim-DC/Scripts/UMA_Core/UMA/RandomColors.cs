using System;

namespace UMA
{
	[Serializable]
	public class RandomColors
	{
		public string ColorName;

		public SharedColorTable ColorTable;

		public RandomColors(string name, SharedColorTable sct)
		{
		}

		public RandomColors(RandomWardrobeSlot rws)
		{
		}
	}
}
