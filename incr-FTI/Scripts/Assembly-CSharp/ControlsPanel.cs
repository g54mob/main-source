using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsPanel : MenuPanel
{
	public GameObject listItemPrefab;

	public LayoutGroup layoutGroup;

	public LabelButton confirmButton;

	private readonly List<ControlsListItem> listItems = new List<ControlsListItem>();

	public override void Initialize()
	{
		base.Initialize();
		confirmButton.InitializeButton();
		confirmButton.AddPointerClickTrigger(OnConfirmPressed);
		confirmButton.buttonState = CustomButtonState.Default;
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		confirmButton.label.text = "OK".Localized();
		foreach (ControlsListItem listItem in listItems)
		{
			if (listItem.labelTextDelegate != null)
			{
				listItem.label.text = listItem.labelTextDelegate();
			}
			if (listItem.requiresControl)
			{
				if (listItem.mappedInput == KeyCode.None)
				{
					listItem.controlButton.label.text = "InputBindingControl".Localized();
				}
				else
				{
					listItem.controlButton.label.text = "InputBindingControl".Localized() + " + " + TextDisplay.LabelForInput(listItem.mappedInput);
				}
			}
			else
			{
				listItem.controlButton.label.text = TextDisplay.LabelForInput(listItem.mappedInput);
			}
		}
	}

	private string GameSpeedString(string suffix)
	{
		return TextDisplay.FormattedKeyValue("GameSpeed", suffix);
	}

	public override void CreateItems()
	{
		base.CreateItems();
		AddControlItem(() => "AdjustmentMultiple".Localized() + " x5", KeyCode.LeftShift);
		AddControlItem(() => "AdjustmentMultiple".Localized() + " x10", KeyCode.None, requiresControl: true);
		AddControlItem(() => "AdjustmentMultiple".Localized() + " x50", KeyCode.LeftShift, requiresControl: true);
		AddControlItem(() => GameSpeedString("Paused".Localized()), KeyCode.F1);
		AddControlItem(() => GameSpeedString("Normal".Localized()), KeyCode.F2);
		AddControlItem(() => GameSpeedString("TurboMode".Localized()), KeyCode.F3);
		AddControlItem(() => GameSpeedString("TurboMode".Localized() + " " + "Max".Localized()), KeyCode.F4);
		AddControlItem(() => Strings.Def("Quicksave", "MenuFunctionSave".Localized()), KeyCode.F5);
		AddControlItem(() => "Quests".Localized(), KeyCode.Q);
		AddControlItem(() => "Research".Localized(), KeyCode.R);
		AddControlItem(() => "Inventory".Localized(), KeyCode.V);
		AddControlItem(() => "Upgrades".Localized(), KeyCode.G);
		AddControlItem(() => "TownPerks".Localized(), KeyCode.T);
		AddControlItem(() => "Notifications".Localized(), KeyCode.F);
		AddControlItem(() => "Perks".Localized(), KeyCode.W);
		AddControlItem(() => "Buildings".Localized(), KeyCode.C);
		AddControlItem(() => "TimeManagement".Localized(), KeyCode.E);
		AddControlItem(() => "Housing".Localized(), KeyCode.Alpha1);
		AddControlItem(() => "Cultivation".Localized(), KeyCode.Alpha2);
		AddControlItem(() => "Prospecting".Localized(), KeyCode.Alpha3);
		AddControlItem(() => "Harvesting".Localized(), KeyCode.Alpha4);
		AddControlItem(() => "Crafting".Localized(), KeyCode.Alpha5);
		AddControlItem(() => "Markets".Localized(), KeyCode.Alpha6);
		AddControlItem(() => "Trading".Localized(), KeyCode.Alpha7);
		AddControlItem(() => "Research".Localized() + " " + "Production".Localized(), KeyCode.Alpha8);
		AddControlItem(() => "Storage".Localized(), KeyCode.Alpha9);
		AddControlItem(() => "World".Localized(), KeyCode.Tab);
		AddControlItem(() => "Menu".Localized(), KeyCode.Escape);
		AddControlItem(TownPrev, KeyCode.LeftArrow, requiresControl: true);
		AddControlItem(TownNext, KeyCode.RightArrow, requiresControl: true);
		AddControlItem(() => "PlayerActionPreviousSong".Localized(), KeyCode.LeftBracket, requiresControl: true);
		AddControlItem(() => "PlayerActionNextSong".Localized(), KeyCode.RightBracket, requiresControl: true);
	}

	private string TownPrev()
	{
		if (LocalizationManager.IsEnglish())
		{
			return "Cycle Town: Previous";
		}
		return "Biome".Localized() + "-";
	}

	private string TownNext()
	{
		if (LocalizationManager.IsEnglish())
		{
			return "Cycle Town: Next";
		}
		return "Biome".Localized() + "+";
	}

	private void AddControlItem(ControlsListItem.StringDelegate labelDelegate, KeyCode inputCode, bool requiresControl = false)
	{
		ControlsListItem component = MenuManager.GetMenuObject(listItemPrefab, layoutGroup.transform).GetComponent<ControlsListItem>();
		component.labelTextDelegate = labelDelegate;
		component.mappedInput = inputCode;
		component.requiresControl = requiresControl;
		listItems.Add(component);
	}

	private void OnConfirmPressed()
	{
		Hide();
	}
}
