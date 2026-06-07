using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigameRewardSelectionPanel : MonoBehaviour
{
	public TextMeshProUGUI descriptionLabel;

	public TextMeshProUGUI selectResourcePrompt;

	public CostIcon energyCostIcon;

	public LabelButton beginButton;

	public MinigamePanel parentPanel;

	public GameObject entityIconPrefab;

	public LayoutGroup resourceSelectionGroup;

	[NonSerialized]
	private SingleSelectionManager selectionManager;

	private readonly Dictionary<ItemType, EntityIcon> rewardSelectionIcons = new Dictionary<ItemType, EntityIcon>(new ItemEqualityComparer());

	private ItemType selectedItem => parentPanel.rewardItem;

	public void LoadPanel(MinigamePanel p)
	{
		parentPanel = p;
		beginButton.AddPointerClickTrigger(OnBeginPressed);
		beginButton.buttonState = CustomButtonState.Disabled;
		AddSelectionForRewardEntities();
	}

	public void ResetPanel()
	{
		selectionManager?.ClearSelection();
	}

	public void ReloadLabels()
	{
		beginButton.label.text = "Begin".Localized();
		descriptionLabel.text = parentPanel.instructionsLocalizationKey.Localized();
		selectResourcePrompt.text = "SelectResource".Localized() + ":";
	}

	public void UpdateItemAvailability()
	{
		foreach (KeyValuePair<ItemType, EntityIcon> rewardSelectionIcon in rewardSelectionIcons)
		{
			if (GameManager.Instance.activeTown.inventory.TryGetValue(rewardSelectionIcon.Key, out var value))
			{
				rewardSelectionIcon.Value.gameObject.SetActive(!value.isLocked);
			}
		}
		SelectNaturalResourceButton();
	}

	private void OnBeginPressed()
	{
		if (beginButton.allowsAction)
		{
			parentPanel.energyTracker.Subtract(10.0);
			parentPanel.OnBeginPressed();
		}
		else if (parentPanel.energyTracker.currentCount < 10.0)
		{
			MenuManager.Instance.ShowMessage(InvalidReason.NotEnoughEnergy);
		}
	}

	public void UpdateDynamicDisplay()
	{
		energyCostIcon.UpdateSinglePurchaseAffordability();
		if (parentPanel.energyTracker.currentCount >= 10.0)
		{
			beginButton.buttonState = CustomButtonState.Default;
		}
		else
		{
			beginButton.buttonState = CustomButtonState.Disabled;
		}
	}

	public void AddSelectionForResource(NaturalResource r)
	{
		AddSelectionForItem(Item.ItemFromNaturalResource(r));
	}

	public void AddSelectionForRewardEntities()
	{
		foreach (KeyValuePair<ItemType, double> item in parentPanel.rewardEntities.items)
		{
			AddSelectionForItem(item.Key);
		}
	}

	public void AddSelectionForItem(ItemType r)
	{
		GameObject menuObject = MenuManager.GetMenuObject(entityIconPrefab, resourceSelectionGroup.transform);
		if (selectionManager == null)
		{
			selectionManager = new SingleSelectionManager(OnRewardChangedByManager);
		}
		if (menuObject.TryGetComponent<EntityIcon>(out var component))
		{
			EntityId id = EntityId.FromItem(r);
			component.LoadEntity(id);
			component.LoadSelectionManager(selectionManager);
			component.buttonState = CustomButtonState.Background;
			component.tooltipEntity = EntityId.FromItem(r);
			rewardSelectionIcons[r] = component;
		}
	}

	private void OnRewardChangedByManager(EntityId id, bool nextState)
	{
		if (id.TryAsItem(out var i) && rewardSelectionIcons.TryGetValue(i, out var value))
		{
			if (nextState)
			{
				OnSelectedEntity(id);
			}
			else
			{
				value.RemoveSelection();
			}
		}
	}

	private void OnSelectedEntity(EntityId id)
	{
		if (id.TryAsItem(out var i))
		{
			parentPanel.SetReward(i);
			parentPanel.ReloadLabels();
			OnSelectedResourceChanged();
		}
		else
		{
			Debug.LogError("SELECTED REWARD WAS NOT ITEM");
		}
	}

	private void OnSelectedResourceChanged()
	{
		beginButton.buttonState = ((selectedItem != ItemType.None) ? CustomButtonState.Default : CustomButtonState.Disabled);
	}

	public void EnterSelectionState()
	{
		base.gameObject.SetActive(value: true);
		SelectNaturalResourceButton();
	}

	public void OnActiveTownChanged()
	{
		if (parentPanel.minigameState == MinigameState.RewardSelection)
		{
			SelectNaturalResourceButton();
		}
	}

	public void SelectNaturalResourceButton()
	{
		foreach (KeyValuePair<ItemType, EntityIcon> rewardSelectionIcon in rewardSelectionIcons)
		{
			rewardSelectionIcon.Value.buttonState = CustomButtonState.Background;
			if (GameManager.Instance.activeTown.inventory.TryGetValue(rewardSelectionIcon.Key, out var value) && !value.isLocked && (selectedItem == ItemType.None || rewardSelectionIcon.Key == selectedItem))
			{
				rewardSelectionIcon.Value.PerformSelection(sendEvent: false);
				OnSelectedEntity(EntityId.FromItem(rewardSelectionIcon.Key));
				break;
			}
		}
	}
}
