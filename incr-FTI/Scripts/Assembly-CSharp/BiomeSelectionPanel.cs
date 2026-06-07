using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiomeSelectionPanel : MenuListPanel
{
	public LayoutGroup tooltipLayoutGroup;

	public GameObject tooltipPrefab;

	public GameObject biomeListItemPrefab;

	public LabelButton confirmButton;

	public LabelButton cancelButton;

	private BiomeType selectedBiomeType;

	private ListItemPool<TooltipIconLabelListItem> tooltipIconLabelItemPool;

	private readonly Dictionary<BiomeType, EntityButton> biomeListItems = new Dictionary<BiomeType, EntityButton>(new BiomeEqualityComparer());

	private int placementIndex;

	public override void Initialize()
	{
		base.Initialize();
		confirmButton.AddPointerClickTrigger(OnConfirmPressed);
		confirmButton.buttonState = CustomButtonState.Default;
		tooltipIconLabelItemPool = new ListItemPool<TooltipIconLabelListItem>(tooltipPrefab);
		foreach (KeyValuePair<BiomeType, Biome> item in Crafting.biomeCache)
		{
			EntityButton component = MenuManager.GetMenuObject(biomeListItemPrefab, layoutGroup.transform).GetComponent<EntityButton>();
			component.LoadSelectionManager(selectionManager);
			component.Initialize();
			component.LoadEntity(EntityId.FromBiome(item.Key));
			biomeListItems[item.Key] = component;
			component.onClickedDelegate = OnClickedBiome;
		}
	}

	private void OnClickedBiome(EntityButton sender)
	{
		if (sender.loadedEntity.TryAsBiome(out var t))
		{
			selectedBiomeType = t;
			ShowSelectedBiomeTooltip();
		}
	}

	protected override SelectableButton VisibleListItemWithEntity(EntityId seekEntity)
	{
		if (seekEntity.TryAsBiome(out var t) && biomeListItems.TryGetValue(t, out var value))
		{
			return value;
		}
		return null;
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		confirmButton.label.text = "OK".Localized();
		foreach (KeyValuePair<BiomeType, EntityButton> biomeListItem in biomeListItems)
		{
			biomeListItem.Value.primaryLabel.text = TextDisplay.LabelForBiome(biomeListItem.Key);
		}
	}

	public new void ShowForTown(Town t)
	{
		selectedBiomeType = t.biomeType;
		ShowSelectedBiomeTooltip();
		Show();
	}

	private void ShowSelectedBiomeTooltip()
	{
		placementIndex = 0;
		tooltipIconLabelItemPool.Reset();
		if (!Crafting.biomeCache.TryGetValue(selectedBiomeType, out var value))
		{
			return;
		}
		foreach (BiomeModifier entityModifier in value.entityModifiers)
		{
			GetIconLabelItem().LoadBiomeModifier(entityModifier, panelStringBuilder);
		}
	}

	private TooltipIconLabelListItem GetIconLabelItem()
	{
		TooltipIconLabelListItem item = tooltipIconLabelItemPool.GetItem(placementIndex, tooltipLayoutGroup.transform);
		placementIndex++;
		return item;
	}

	public void OnConfirmPressed()
	{
		MenuPanel.gm.activeTown.biomeType = selectedBiomeType;
		MenuManager.Instance.FlagAllCostsStale();
		MenuPanel.gm.activeTown.RefreshAllTownMetadata();
		MenuManager.Instance.townStatsPanel.ReloadBiomeInfo();
		Hide();
	}
}
