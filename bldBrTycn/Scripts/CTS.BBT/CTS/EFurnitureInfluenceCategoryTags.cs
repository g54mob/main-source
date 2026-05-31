using System;

namespace CTS
{
	[Flags]
	public enum EFurnitureInfluenceCategoryTags
	{
		None = 0,
		LowPrice = 1,
		HighPrice = 2,
		LowEthics = 4,
		HighEthics = 8
	}
}
