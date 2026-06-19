using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class ExtraInventorySizeAuthoring : MonoBehaviour
{
	[Tooltip("If not set, the size will be computed from the item's level.")]
	public OptionalValue<int> sameSizeForAllLevels;

	public List<ObjectCategoryTag> canOnlyContainObjectsWithCategoryTags;

	public bool isPouch;

	public static int GetSizeFromLevel(int level)
	{
		if (level > 5)
		{
			switch (level)
			{
			case 6:
			case 7:
				return 11;
			case 8:
				return 12;
			case 9:
				return 13;
			case 10:
				return 15;
			case 11:
				return 17;
			default:
				return 20;
			}
		}
		return 10;
	}
}
