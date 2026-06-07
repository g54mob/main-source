using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryView : InventoryViewBase<CreationView, CreationModel>
{
	private TextMeshProUGUI blocksText;

	private TextMeshProUGUI costText;

	private TextMeshProUGUI weightText;

	public override void Initialize()
	{
		base.Initialize();
		blocksText = mainPanel.transform.FindComponent<TextMeshProUGUI>("BlocksText", isRecursively: true);
		costText = mainPanel.transform.FindComponent<TextMeshProUGUI>("CostText", isRecursively: true);
		weightText = mainPanel.transform.FindComponent<TextMeshProUGUI>("WeightText", isRecursively: true);
	}

	protected override void ActionBeforeClearAllTabsAndSlots()
	{
		inventorySlotsPanels.ForEach(delegate(List<InventorySlotBase<CreationView, CreationModel>> tab)
		{
			tab.ForEach(delegate(InventorySlotBase<CreationView, CreationModel> slot)
			{
				slot.ItemView.RecycleAllBlocksBeforeDestroying();
			});
		});
	}

	protected override void ActionBeforeRemoveSlot(InventorySlotBase<CreationView, CreationModel> slot)
	{
		slot.ItemView.RecycleAllBlocksBeforeDestroying();
	}

	protected override void ActionBeforeRemoveOldItemView()
	{
		itemParentFolder.transform.GetComponentInChildren<CreationView>(includeInactive: true)?.RecycleAllBlocksBeforeDestroying();
	}

	protected override CreationView SetSelectedItemModelHandler(CreationModel selectedItemModel)
	{
		itemNameText.text = selectedItemModel.Name;
		descriptionText.text = selectedItemModel.Description;
		int count = selectedItemModel.GetAllBlockModel().Count;
		blocksText.text = ((count > 1) ? ("\uf1b3 " + count) : "");
		costText.text = "\uf0eb " + selectedItemModel.TotalCost().ToString("0.##");
		weightText.text = "\ue908 " + selectedItemModel.TotalWeight().ToString("0.##");
		CreationController creationController = CreationControllerBuilder.BuildModelController(selectedItemModel, itemParentFolder.transform);
		GameObject gameObject = creationController.view.gameObject;
		gameObject.SetLayersRecursively(LayerNames.UI);
		gameObject.transform.SetParent(itemParentFolder.transform);
		CreationUtil.NormalizeCreationScale(creationController.view, referenceBlockObject.transform.localScale.x);
		gameObject.transform.localPosition = referenceBlockObject.transform.localPosition;
		gameObject.transform.localRotation = referenceBlockObject.transform.localRotation;
		if (!selectedItemModel.IsOriginatedFromSchematic)
		{
			gameObject.transform.localRotation = Quaternion.Euler(22.5f, 225f, 22.5f);
		}
		if (selectedItemModel.IsDeletable)
		{
			deleteItemButton.gameObject.SetActive(value: true);
		}
		else
		{
			deleteItemButton.gameObject.SetActive(value: false);
		}
		return creationController.view;
	}
}
