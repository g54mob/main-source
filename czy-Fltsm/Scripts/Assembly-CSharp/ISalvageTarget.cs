using System.Collections.Generic;

public interface ISalvageTarget
{
	Dictionary<ItemProperties, bool> ItemFilter { get; }

	void PopulateItemsToHaul(ProjectAssignment assignment);

	int PopulateItemList(Itemlist itemList);

	void ToggleItemFilter(ItemProperties itemProperties);

	ProjectBlocker ReturnProjectBlockers(Project project);

	bool ReturnIsSalvageableItem(Item item);

	bool ReturnIsItemFilterToggled(ItemProperties item);

	bool ReturnHasSalvageableItems(Project project, Agent agent);

	bool ReturnIsSalvaged();

	float ReturnSalvageItemExperience(Item item);
}
