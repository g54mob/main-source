using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NavigationButton : SelectableButton
{
	public Image iconImage;

	[NonSerialized]
	public EntityId linkedMenuPanel;

	public TextMeshProUGUI label;

	public Slider slider;

	public Image labelBackground;

	public bool isInAlertState;

	public Transform alertRegion;

	[NonSerialized]
	public bool isModalPanelTrigger;

	private bool includesText;

	public void LoadCategory(BuildingCategory c)
	{
		includesText = true;
		linkedMenuPanel = EntityId.FromBuildingCategory(c);
		iconImage.sprite = IconManager.SpriteForBuildingCategory(c);
		AddPointerDownTrigger(OnButtonPressed);
		selectionHandle = EntityId.FromBuildingCategory(c);
		LoadAlert(alertRegion);
		ReloadLabels();
	}

	public void LoadMenu(MenuPanelType p, bool includeNav = true)
	{
		includesText = true;
		linkedMenuPanel = EntityId.FromMenuPanel(p);
		if (includeNav)
		{
			AddPointerDownTrigger(OnButtonPressed);
		}
		selectionHandle = EntityId.FromMenuPanel(p);
		LoadAlert(alertRegion);
		ReloadLabels();
	}

	private string Hotkey()
	{
		if (LocalizationManager.IsEnglish() && linkedMenuPanel.TryAsMenuPanel(out var p))
		{
			switch (p)
			{
			case MenuPanelType.QuestsPopup:
				return TextDisplay.LabelForInput(KeyCode.Q);
			case MenuPanelType.Research:
				return TextDisplay.LabelForInput(KeyCode.R);
			case MenuPanelType.InventoryPopup:
				return TextDisplay.LabelForInput(KeyCode.V);
			case MenuPanelType.Upgrades:
				return TextDisplay.LabelForInput(KeyCode.G);
			case MenuPanelType.TownPerks:
				return TextDisplay.LabelForInput(KeyCode.T);
			case MenuPanelType.Log:
				return TextDisplay.LabelForInput(KeyCode.F);
			case MenuPanelType.Perks:
				return TextDisplay.LabelForInput(KeyCode.W);
			case MenuPanelType.Buildings:
				return TextDisplay.LabelForInput(KeyCode.C);
			case MenuPanelType.TimeTokens:
				return TextDisplay.LabelForInput(KeyCode.E);
			case MenuPanelType.World:
				return TextDisplay.LabelForInput(KeyCode.Tab);
			case MenuPanelType.GameMenu:
				return TextDisplay.LabelForInput(KeyCode.Escape);
			}
		}
		return null;
	}

	public override string HighlightText()
	{
		if (linkedMenuPanel.TryAsMenuPanel(out var p))
		{
			LocalizationManager.IsEnglish();
			string text = Hotkey();
			if (text != null)
			{
				return TextDisplay.LabelForMenuPanel(p) + " (" + text + ")";
			}
			return TextDisplay.LabelForMenuPanel(p);
		}
		if (linkedMenuPanel.TryAsBuildingCategory(out var c))
		{
			if (LocalizationManager.IsEnglish())
			{
				string text2 = TextDisplay.LabelforBuildingCategory(c);
				return c switch
				{
					BuildingCategory.Housing => text2 + " (" + TextDisplay.LabelForInput(KeyCode.Alpha1) + ")", 
					BuildingCategory.Harvesting => text2 + " (" + TextDisplay.LabelForInput(KeyCode.Alpha4) + ")", 
					BuildingCategory.Production => text2 + " (" + TextDisplay.LabelForInput(KeyCode.Alpha5) + ")", 
					BuildingCategory.Cultivation => text2 + " (" + TextDisplay.LabelForInput(KeyCode.Alpha2) + ")", 
					BuildingCategory.Prospecting => text2 + " (" + TextDisplay.LabelForInput(KeyCode.Alpha3) + ")", 
					BuildingCategory.Markets => text2 + " (" + TextDisplay.LabelForInput(KeyCode.Alpha6) + ")", 
					BuildingCategory.Trading => text2 + " (" + TextDisplay.LabelForInput(KeyCode.Alpha7) + ")", 
					BuildingCategory.Research => text2 + " (" + TextDisplay.LabelForInput(KeyCode.Alpha8) + ")", 
					BuildingCategory.Storage => text2 + " (" + TextDisplay.LabelForInput(KeyCode.Alpha9) + ")", 
					_ => text2, 
				};
			}
			return TextDisplay.LabelforBuildingCategory(c);
		}
		return base.HighlightText();
	}

	public void ReloadLabels()
	{
		BuildingCategory c;
		if (includesText && linkedMenuPanel.TryAsMenuPanel(out var p))
		{
			switch (p)
			{
			case MenuPanelType.TimeTokens:
				MenuManager.Instance.navigationPanel.UpdateTimeTokensButton(GameManager.Instance.DisplayedTimeTokens());
				break;
			case MenuPanelType.Perks:
				MenuManager.Instance.navigationPanel.UpdateQuestCoinsButton();
				break;
			default:
				label.text = TextDisplay.LabelForMenuPanel(p);
				break;
			}
		}
		else if (includesText && linkedMenuPanel.TryAsBuildingCategory(out c))
		{
			label.text = TextDisplay.LabelforBuildingCategory(c);
		}
		else
		{
			label.enabled = false;
		}
	}

	public void OnButtonPressed()
	{
		if (base.shouldIgnoreAction)
		{
			return;
		}
		if (isModalPanelTrigger && linkedMenuPanel.TryAsMenuPanel(out var p))
		{
			if (MenuManager.Instance.menuPanels.TryGetValue(p, out var value))
			{
				value.ToggleDisplayForTown(MenuManager.Instance.navigationPanel.displayedTown);
			}
		}
		else if (isSelected)
		{
			MenuManager.Instance.navigationPanel.selectionManager.ClearSelection();
			MenuManager.Instance.combinedProductionPanel.ClearAllSearchProperties();
			MenuManager.Instance.OnSearchPropertiesChanged();
		}
		else
		{
			PerformSelection();
		}
		base.buttonState = CustomButtonState.Background;
	}

	public void ShowLabel()
	{
		if (null != labelBackground)
		{
			labelBackground.gameObject.SetActive(value: true);
			label.enabled = true;
		}
	}

	public void HideLabel()
	{
		if (null != labelBackground)
		{
			labelBackground.gameObject.SetActive(value: false);
		}
	}

	public void SetAlertState(bool nextState)
	{
		isInAlertState = nextState;
	}

	public override void PlaySound()
	{
		SoundManager.PlayMenuChange();
	}

	public override bool DelayTooltip()
	{
		return false;
	}

	public void SetActionAvailability(bool nextState, bool useFlash = false)
	{
		if (useFlash)
		{
			base.buttonState = (nextState ? CustomButtonState.HighlightFlashing : CustomButtonState.Background);
		}
		else
		{
			base.buttonState = (nextState ? CustomButtonState.Default : CustomButtonState.Background);
		}
	}
}
