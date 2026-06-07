using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSetupPanel : MenuPanel
{
	public TextMeshProUGUI fileNameEntryLabel;

	public TextMeshProUGUI townNameEntryLabel;

	public TextMeshProUGUI modifiersLabel;

	public TMP_InputField fileNameInputField;

	public TMP_InputField townNameInputField;

	public LabelButton modifierButton;

	public LabelButton confirmButton;

	public LabelButton cancelButton;

	private bool modifierDisplayState;

	public GameObject modifierPanel;

	public Image modifierCollapseImage;

	public const float modifierRegionHeight = 300f;

	public const float initialHeight = 550f;

	public RectTransform panelRectTransform;

	public GameModifierListItem gameModifierNoBiomeModifiers;

	public GameModifierListItem gameModifierExtremeBiomes;

	public GameModifierListItem gameModifierEasyMode;

	public GameModifierListItem gameModifierHardMode;

	public GameModifierListItem gameModifierPopulation;

	public GameModifierListItem gameModifierNoStorageLimit;

	public GameModifierListItem gameModifierExtraIdle;

	public GameModifierListItem gameModifierExtraActive;

	public GameModifierListItem gameModifierPermanentPerks;

	public GameModifierListItem gameModifierInfiniteLand;

	public GameModifierListItem gameModifierInfiniteConsumption;

	public GameModifierListItem gameModifierNoBiomes;

	public GameModifierListItem gameModifierAutoAssign;

	public GameModifierListItem gameModifierTradingTokens;

	private readonly List<GameModifierListItem> modifierListItems = new List<GameModifierListItem>();

	private readonly List<GameModifier> activeModifiers = new List<GameModifier>();

	private Requirement requirementLevel25;

	private Requirement requirementLevel50;

	public override void Initialize()
	{
		base.Initialize();
		confirmButton.InitializeButton();
		confirmButton.AddPointerClickTrigger(OnConfirmPressed);
		confirmButton.buttonState = CustomButtonState.Default;
		cancelButton.InitializeButton();
		cancelButton.AddPointerClickTrigger(OnCancelPressed);
		cancelButton.buttonState = CustomButtonState.Default;
		modifierButton.InitializeButton();
		modifierButton.AddPointerClickTrigger(OnModifiersPressed);
		modifierButton.buttonState = CustomButtonState.Default;
		ConfigureListItem(gameModifierNoBiomeModifiers, GameModifier.MildBiomes);
		ConfigureListItem(gameModifierExtremeBiomes, GameModifier.ExtremeBiomes);
		ConfigureListItem(gameModifierNoBiomes, GameModifier.NoBiomes);
		ConfigureListItem(gameModifierEasyMode, GameModifier.EasyMode);
		ConfigureListItem(gameModifierHardMode, GameModifier.HardMode);
		ConfigureListItem(gameModifierPopulation, GameModifier.LowPopulation);
		ConfigureListItem(gameModifierNoStorageLimit, GameModifier.NoStorageLimits);
		ConfigureListItem(gameModifierExtraActive, GameModifier.ExtraActive);
		ConfigureListItem(gameModifierExtraIdle, GameModifier.ExtraIdle);
		ConfigureListItem(gameModifierPermanentPerks, GameModifier.PermanentPerks);
		ConfigureListItem(gameModifierInfiniteLand, GameModifier.InfiniteLand);
		ConfigureListItem(gameModifierInfiniteConsumption, GameModifier.InfiniteConsumption);
		ConfigureListItem(gameModifierAutoAssign, GameModifier.AutoAssignDefault);
		ConfigureListItem(gameModifierTradingTokens, GameModifier.ExchangeTokens);
		foreach (GameModifierListItem modifierListItem in modifierListItems)
		{
			modifierListItem.highlightTextDelegate = modifierListItem.GetTooltip;
		}
	}

	private void ConfigureListItem(GameModifierListItem listItem, GameModifier modifier)
	{
		listItem.Initialize();
		listItem.InitializeButton();
		listItem.LoadModifier(modifier);
		listItem.clickDelegate = ToggleModifier;
		modifierListItems.Add(listItem);
	}

	private void ToggleModifier(GameModifierListItem sender)
	{
		GameModifier displayedModifier = sender.displayedModifier;
		if (activeModifiers.Contains(displayedModifier))
		{
			activeModifiers.Remove(displayedModifier);
			sender.isSelected = false;
			return;
		}
		activeModifiers.Add(displayedModifier);
		sender.isSelected = true;
		switch (displayedModifier)
		{
		case GameModifier.ExtremeBiomes:
			RemoveModifier(GameModifier.MildBiomes);
			RemoveModifier(GameModifier.NoBiomes);
			break;
		case GameModifier.MildBiomes:
			RemoveModifier(GameModifier.ExtremeBiomes);
			RemoveModifier(GameModifier.NoBiomes);
			break;
		case GameModifier.NoBiomes:
			RemoveModifier(GameModifier.ExtremeBiomes);
			RemoveModifier(GameModifier.MildBiomes);
			break;
		case GameModifier.EasyMode:
			RemoveModifier(GameModifier.HardMode);
			break;
		case GameModifier.HardMode:
			RemoveModifier(GameModifier.EasyMode);
			break;
		case GameModifier.ExtraActive:
			RemoveModifier(GameModifier.ExtraIdle);
			break;
		case GameModifier.ExtraIdle:
			RemoveModifier(GameModifier.ExtraActive);
			break;
		}
	}

	private void RemoveModifier(GameModifier modifier)
	{
		activeModifiers.Remove(modifier);
		foreach (GameModifierListItem modifierListItem in modifierListItems)
		{
			if (modifierListItem.displayedModifier == modifier)
			{
				modifierListItem.isSelected = false;
				break;
			}
		}
	}

	public override void Show()
	{
		base.Show();
		UpdateModifierDisplayState();
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		confirmButton.buttonState = (string.IsNullOrEmpty(fileNameInputField.text) ? CustomButtonState.Disabled : CustomButtonState.BlueFlashing);
		foreach (GameModifierListItem modifierListItem in modifierListItems)
		{
			modifierListItem.UpdateDynamicDisplay();
		}
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		header.headerText.text = "MenuFunctionNewGame".Localized();
		townNameEntryLabel.text = "TownName".Localized() + ":";
		fileNameEntryLabel.text = "FileName".Localized() + ":";
		confirmButton.label.text = "Create".Localized();
		cancelButton.label.text = "Cancel".Localized();
		modifiersLabel.text = "Modifiers".Localized();
		foreach (GameModifierListItem modifierListItem in modifierListItems)
		{
			modifierListItem.ReloadLabels();
		}
	}

	public void LoadDefaultFileName()
	{
		string prefix = "slot";
		FileSource fileSource = Platform.Instance.GetFileSource();
		FileMetadata fileMetadata = Platform.Instance.NextAvailableFileMetadata(prefix, fileSource, FileType.SaveFile);
		fileNameInputField.text = fileMetadata.displayName;
	}

	private void OnModifiersPressed()
	{
		modifierDisplayState = !modifierDisplayState;
		UpdateModifierDisplayState();
	}

	private void UpdateModifierDisplayState()
	{
		if (modifierDisplayState)
		{
			modifierPanel.gameObject.SetActive(value: true);
			modifierButton.isSelected = true;
		}
		else
		{
			modifierPanel.gameObject.SetActive(value: false);
			modifierButton.isSelected = false;
		}
		foreach (GameModifierListItem modifierListItem in modifierListItems)
		{
			modifierListItem.UpdateLockedState();
		}
	}

	private void OnCancelPressed()
	{
		Hide();
		MenuManager.Instance.welcomePanel.OnCancelledNewTown();
	}

	private void OnConfirmPressed()
	{
		string nameWithExtension = FileManager.AddExtension(fileNameInputField.text, FileType.SaveFile);
		FileSource fileSource = Platform.Instance.GetFileSource();
		if (Platform.Instance.FileExists(nameWithExtension, fileSource, FileType.SaveFile, out var _))
		{
			MenuManager.Instance.ShowMessage(InvalidReason.FileAlreadyExists);
			return;
		}
		Hide();
		MenuManager.Instance.welcomePanel.OnConfirmedNewTownName();
	}

	public void ApplyActiveModifiersToGameState()
	{
		GameManager.Instance.appliedModifiers.Clear();
		foreach (GameModifier activeModifier in activeModifiers)
		{
			GameManager.Instance.ApplyModifierToGameState(activeModifier);
		}
	}

	public void OnFileNameModified()
	{
		if (townNameInputField.placeholder is TextMeshProUGUI textMeshProUGUI)
		{
			textMeshProUGUI.text = fileNameInputField.text;
		}
	}

	public string DerivedTownName()
	{
		if (!string.IsNullOrEmpty(townNameInputField.text))
		{
			return townNameInputField.text;
		}
		if (townNameInputField.placeholder is TextMeshProUGUI textMeshProUGUI)
		{
			return textMeshProUGUI.text;
		}
		return string.Empty;
	}
}
