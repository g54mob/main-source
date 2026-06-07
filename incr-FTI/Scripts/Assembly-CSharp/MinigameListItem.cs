using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MinigameListItem : SelectableButton
{
	public LabelButton playButton;

	public Image iconImage;

	public TextMeshProUGUI title;

	[NonSerialized]
	public MenuPanelType panelType;

	public LayoutGroup itemLayoutGroup;

	public CapacityRegion energyCapacityRegion;

	public CapacityRegion levelRegion;

	public UnityAction<MinigameListItem> playDelegate;

	private EnergyTracker energyTracker;

	private LevelStat levelStat;

	public TextMeshProUGUI levelText;

	private readonly List<EntityIcon> rewardEntityIcons = new List<EntityIcon>();

	public bool isLevelLabelStale;

	public MenuPanel linkedPanel;

	protected override void Awake()
	{
		LoadAlert(title.transform);
		playButton.buttonState = CustomButtonState.Default;
	}

	public void LoadPanel(MenuPanelType panel, EnergyTracker energy)
	{
		panelType = panel;
		iconImage.sprite = IconManager.SpriteForMenuPanel(panel);
		playButton.AddPointerClickTrigger(OnPointerClick);
		if (MenuManager.Instance.menuPanels.TryGetValue(panel, out var value))
		{
			linkedPanel = value;
			if (!(linkedPanel is MinigamePanelParent minigamePanelParent))
			{
				return;
			}
			levelRegion.iconImage.sprite = IconManager.SpriteForItem(minigamePanelParent.levelStat.iconItem);
			levelStat = minigamePanelParent.levelStat;
			energyCapacityRegion.iconImage.sprite = IconManager.SpriteForItem(minigamePanelParent.energyTracker.energyType);
			energyTracker = minigamePanelParent.energyTracker;
			{
				foreach (KeyValuePair<ItemType, double> item in minigamePanelParent.rewardEntities.items)
				{
					ItemType key = item.Key;
					if (MenuManager.GetMenuObject(MenuManager.Instance.entityIconPrefab, itemLayoutGroup.transform).TryGetComponent<EntityIcon>(out var component))
					{
						EntityId id = EntityId.FromItem(key);
						component.LoadEntity(id);
						component.tooltipEntity = id;
						component.buttonState = CustomButtonState.Background;
						rewardEntityIcons.Add(component);
					}
				}
				return;
			}
		}
		Debug.LogError("No panel for " + panel);
	}

	public void UpdateDynamicDisplay()
	{
		energyCapacityRegion.TryUpdateDisplay(Math.Floor(energyTracker.currentCount), energyTracker.maxCount);
		levelRegion.TryUpdateDisplay(levelStat);
		if (isLevelLabelStale)
		{
			ReloadLabels();
		}
	}

	public void ReloadLabels()
	{
		title.text = TextDisplay.LabelForMenuPanel(panelType);
		playButton.label.text = "Play".Localized();
		if (levelStat != null)
		{
			TextDisplay.FormatLevelAbbreviation(levelText, levelStat.level);
		}
		isLevelLabelStale = false;
	}

	private void OnPointerClick()
	{
		playDelegate?.Invoke(this);
	}

	public void SetAlert(bool state)
	{
		alert.gameObject.SetActive(state);
	}

	public void UpdateItemAvailability()
	{
		foreach (EntityIcon rewardEntityIcon in rewardEntityIcons)
		{
			if (rewardEntityIcon.tooltipEntity.TryAsItem(out var i) && GameManager.Instance.activeTown.inventory.TryGetValue(i, out var value))
			{
				rewardEntityIcon.gameObject.SetActive(!value.isLocked);
			}
		}
	}
}
