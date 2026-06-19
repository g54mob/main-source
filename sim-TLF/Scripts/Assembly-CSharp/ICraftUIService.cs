using System;
using System.Collections.Generic;
using AssembleSystem;
using UI.Craft;

public interface ICraftUIService
{
	List<CraftItemViewModel> CraftItems { get; }

	Dictionary<CraftItemViewModel, CraftItemView> CraftItemsToView { get; }

	event Action<CraftItemViewModel> OnItemButtonCliked;

	CraftItemView CrateUICraftItem(AssembleObjectParent parent);

	void RemoveCraftItem(AssembleObjectParent parent);

	bool IsCraftItemExists(AssembleObjectParent parent);
}
