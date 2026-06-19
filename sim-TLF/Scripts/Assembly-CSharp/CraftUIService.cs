using System;
using System.Collections.Generic;
using AssembleSystem;
using Loxodon.Framework.Binding;
using UI.Craft;
using UnityEngine.UI;
using Zenject;

public class CraftUIService : ICraftUIService
{
	private List<CraftItemViewModel> _craftItems = new List<CraftItemViewModel>();

	private Dictionary<CraftItemViewModel, CraftItemView> _craftItemsToView = new Dictionary<CraftItemViewModel, CraftItemView>();

	[Inject]
	private ICraftItemFactory _craftItemFactory;

	List<CraftItemViewModel> ICraftUIService.CraftItems => _craftItems;

	Dictionary<CraftItemViewModel, CraftItemView> ICraftUIService.CraftItemsToView => _craftItemsToView;

	public event Action<CraftItemViewModel> OnItemButtonCliked;

	CraftItemView ICraftUIService.CrateUICraftItem(AssembleObjectParent parent)
	{
		CraftItemViewModel craftItemViewModel = new CraftItemViewModel(parent, InvokeOnItemCrafted);
		craftItemViewModel.Name = parent.ItemConfig.name;
		CraftItemView craftItemView = _craftItemFactory.Create();
		craftItemView.GetComponent<Button>().interactable = false;
		craftItemView.SetDataContext(craftItemViewModel);
		craftItemView.CreateBinding();
		_craftItems.Add(craftItemViewModel);
		_craftItemsToView.Add(craftItemViewModel, craftItemView);
		return craftItemView;
	}

	void ICraftUIService.RemoveCraftItem(AssembleObjectParent parent)
	{
		CraftItemViewModel craftItemViewModel = _craftItems.Find((CraftItemViewModel x) => x.Parent == parent);
		if (craftItemViewModel != null)
		{
			_craftItemsToView[craftItemViewModel].gameObject.SetActive(value: false);
			_craftItems.Remove(craftItemViewModel);
			_craftItemsToView.Remove(craftItemViewModel);
		}
	}

	private void InvokeOnItemCrafted(CraftItemViewModel vm)
	{
		this.OnItemButtonCliked?.Invoke(vm);
	}

	bool ICraftUIService.IsCraftItemExists(AssembleObjectParent parent)
	{
		return _craftItems.Exists((CraftItemViewModel x) => x.Parent == parent);
	}
}
