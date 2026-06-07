using System.Collections.Generic;

public class SatisfactionCategory
{
	public ItemType satisfactionCategoryType;

	public readonly HashSet<ItemType> componentItems;

	public int[] maxHappiness;

	public SatisfactionCategory(ItemType categoryType)
	{
		satisfactionCategoryType = categoryType;
		componentItems = new HashSet<ItemType>(new ItemEqualityComparer());
	}
}
