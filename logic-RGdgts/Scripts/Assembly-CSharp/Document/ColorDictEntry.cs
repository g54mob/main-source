using System;

namespace Document
{
	[Serializable]
	public struct ColorDictEntry
	{
		[ColorEntity]
		public int holderColor;
	}
}
