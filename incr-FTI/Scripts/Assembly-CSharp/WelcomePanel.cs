using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WelcomePanel : MenuPanel, IPointerDownHandler, IEventSystemHandler
{
	public Image blurBackground;

	public RectTransform versionRegionTransform;

	public Image versionRegionImage;

	public LabelButton newGameButton;

	public LabelButton loadButton;

	public LabelButton continueButton;

	public LabelButton optionsButton;

	public LabelButton quitButton;

	public LabelButton backFromSlotsButton;

	public LabelButton steamButton;

	public LabelButton creditsButton;

	public LabelButton patchNotesButton;

	public LabelButton discordButton;

	public LabelButton ft2Button;

	public LabelButton versionCollapseButton;

	public Image versionCollapseImage;

	public LayoutGroup buttonGroup;

	public Transform slotRegion;

	public LayoutGroup slotGroup;

	public List<LabelButton> mainButtons;

	public List<SlotButton> slotButtons;

	public List<LabelButton> linkButtons;

	private FileMetadata selectedFileMetadata;

	private int selectedTown;

	private string selectedTownName;

	private bool isSelectedSlotEmpty;

	public RectTransform versionBox;

	public TextMeshProUGUI versionLabel;

	public TextMeshProUGUI platformLabel;

	public TextMeshProUGUI anyKeyLabel;

	public CanvasGroup titleTextGroup;

	public CanvasGroup interfaceGroup;

	public float blurFadeInProgress;

	public bool targetTitleTextState;

	public float titleTextProgress;

	public float anyKeyCountdown;

	public CanvasGroup anyKeyGroup;

	public bool targetAnyKeyState;

	public float anyKeyProgress;

	protected override void Update()
	{
		base.Update();
		if (blurFadeInProgress > 0f && blurFadeInProgress < 1f)
		{
			blurFadeInProgress = Mathf.Clamp01(blurFadeInProgress + TimeManager.MenuDelta * 1f);
			blurBackground.color = new Color(1f, 1f, 1f, blurFadeInProgress);
			interfaceGroup.alpha = blurFadeInProgress;
		}
		if (targetTitleTextState)
		{
			if (titleTextProgress < 1f)
			{
				titleTextProgress = Mathf.Clamp01(titleTextProgress + TimeManager.MenuDelta * 1.5f);
				titleTextGroup.alpha = titleTextProgress;
			}
		}
		else if (titleTextProgress > 0f)
		{
			titleTextProgress = Mathf.Clamp01(titleTextProgress - TimeManager.MenuDelta * 2f);
			titleTextGroup.alpha = titleTextProgress;
		}
		if (anyKeyCountdown > 0f)
		{
			anyKeyCountdown -= TimeManager.MenuDelta;
			if (anyKeyCountdown <= 0f)
			{
				targetAnyKeyState = true;
			}
		}
		if (targetAnyKeyState)
		{
			if (anyKeyProgress < 1f)
			{
				anyKeyProgress = Mathf.Clamp01(anyKeyProgress + TimeManager.MenuDelta * 1.5f);
				anyKeyGroup.alpha = anyKeyProgress;
			}
		}
		else if (anyKeyProgress > 0f)
		{
			anyKeyProgress = Mathf.Clamp01(anyKeyProgress - TimeManager.MenuDelta * 2f);
			anyKeyGroup.alpha = anyKeyProgress;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		newGameButton.AddPointerClickTrigger(OnNewGameButtonPressed);
		loadButton.AddPointerClickTrigger(OnLoadButtonPressed);
		continueButton.AddPointerClickTrigger(OnContinueButtonPressed);
		optionsButton.AddPointerClickTrigger(Options);
		backFromSlotsButton.AddPointerClickTrigger(BackFromSlots);
		quitButton.AddPointerClickTrigger(OnQuitPressed);
		backFromSlotsButton.buttonState = CustomButtonState.Default;
		steamButton.AddPointerClickTrigger(OnStoreButtonPressed);
		patchNotesButton.AddPointerClickTrigger(OnPatchNotesPressed);
		creditsButton.AddPointerClickTrigger(OnCreditsPressed);
		discordButton.AddPointerClickTrigger(OnDiscordPressed);
		ft2Button.AddPointerClickTrigger(OnFT2ButtonPressed);
		ft2Button.animateSize = true;
		versionCollapseButton.AddPointerClickTrigger(OnVersionCollapseButtonPressed);
		newGameButton.animateSize = true;
		loadButton.animateSize = true;
		continueButton.animateSize = true;
		optionsButton.animateSize = true;
		backFromSlotsButton.animateSize = true;
		quitButton.animateSize = true;
		foreach (LabelButton mainButton in mainButtons)
		{
			mainButton.buttonState = CustomButtonState.Default;
		}
		foreach (LabelButton linkButton in linkButtons)
		{
			linkButton.buttonState = CustomButtonState.Background;
		}
		targetTitleTextState = true;
		titleTextProgress = 1f;
		titleTextGroup.alpha = 1f;
	}

	public void SetToAwakeState()
	{
		slotRegion.gameObject.SetActive(value: false);
		buttonGroup.gameObject.SetActive(value: true);
		blurBackground.color = new Color(1f, 1f, 1f, 0f);
		interfaceGroup.blocksRaycasts = false;
		interfaceGroup.alpha = 0f;
		targetAnyKeyState = false;
		anyKeyCountdown = 3f;
		anyKeyGroup.alpha = 0f;
	}

	public void SetToWelcomeState()
	{
		SetCollapseState(Preferences.HasKey("CollapseVersionDetails"));
		steamButton.gameObject.SetActive(Platform.Instance.isPlaytest || true);
		if (blurFadeInProgress <= 0f)
		{
			SetToAwakeState();
		}
		else
		{
			slotRegion.gameObject.SetActive(value: false);
			buttonGroup.gameObject.SetActive(value: true);
			versionBox.gameObject.SetActive(value: true);
		}
		targetTitleTextState = true;
		ReloadLabels();
		continueButton.gameObject.SetActive(GetContinueFile() != null);
	}

	public FileMetadata GetContinueFile()
	{
		string text = PlayerPrefs.GetString("lastFileName", string.Empty);
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		int num = PlayerPrefs.GetInt("lastFileSource", 0);
		if (num <= 0)
		{
			return null;
		}
		if (Platform.Instance.FileExists(text, (FileSource)num, FileType.SaveFile, out var resultMetadata))
		{
			return resultMetadata;
		}
		return null;
	}

	public override void ReloadLabels()
	{
		newGameButton.label.text = "MenuFunctionNewGame".Localized();
		loadButton.label.text = "MenuFunctionLoad".Localized();
		continueButton.label.text = "MenuFunctionResumeLastGame".Localized();
		optionsButton.label.text = "MenuFunctionOptions".Localized();
		backFromSlotsButton.label.text = "Back".Localized();
		quitButton.label.text = "MenuFunctionQuit".Localized();
		versionLabel.text = TextDisplay.FormattedKeyValue("CurrentVersion", "1.3.6a");
		platformLabel.text = Platform.Instance.DisplayLabel();
		if (LocalizationManager.Instance.currentLanguage == UserLanguage.SimplifiedChinese || LocalizationManager.Instance.currentLanguage == UserLanguage.TraditionalChinese)
		{
			patchNotesButton.label.text = "更新日志";
			discordButton.label.text = "反馈报告";
		}
		else if (LocalizationManager.Instance.currentLanguage == UserLanguage.Japanese)
		{
			patchNotesButton.label.text = "パッチノート";
			discordButton.label.text = "フィードバックを報告";
		}
		else
		{
			patchNotesButton.label.text = "Patch Notes";
			discordButton.label.text = "Send Feedback (Discord)";
		}
		creditsButton.label.text = "MenuCredits".Localized();
		steamButton.label.text = "FullVersionDetails".Localized();
		foreach (SlotButton slotButton in slotButtons)
		{
			slotButton.ReloadLabels();
		}
		anyKeyLabel.text = "PressAnyKey".Localized();
		base.ReloadLabels();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnAnyKeyDown()
	{
		targetAnyKeyState = false;
		MusicPlayer.Instance.BeginForGameLaunch();
		if (blurFadeInProgress <= 0f)
		{
			blurFadeInProgress = 0.01f;
			interfaceGroup.blocksRaycasts = true;
			anyKeyCountdown = 0f;
		}
	}

	private void OnContinueButtonPressed()
	{
		FileMetadata continueFile = GetContinueFile();
		if (continueFile != null)
		{
			MenuManager.Instance.welcomePanel.BeginLoadOfMetadata(continueFile);
		}
		continueButton.isPointerInsideButton = false;
	}

	private void OnLoadButtonPressed()
	{
		loadButton.isPointerInsideButton = false;
		slotRegion.gameObject.SetActive(value: false);
		buttonGroup.gameObject.SetActive(value: false);
		versionBox.gameObject.SetActive(value: false);
		targetTitleTextState = false;
		MenuPanel.m.fileListPanel.ShowForMode(FilePanelMode.Load, OnCancelledNewTown);
		MenuPanel.m.fileListPanel.CreateLayout();
		MenuPanel.m.fileListPanel.inputField.text = string.Empty;
	}

	private void OnNewGameButtonPressed()
	{
		newGameButton.isPointerInsideButton = false;
		slotRegion.gameObject.SetActive(value: false);
		buttonGroup.gameObject.SetActive(value: false);
		versionBox.gameObject.SetActive(value: false);
		targetTitleTextState = false;
		MenuPanel.m.gameSetupPanel.Show();
		MenuPanel.m.gameSetupPanel.LoadDefaultFileName();
	}

	public void LoadSlotDetails()
	{
		List<FileMetadata> list = Platform.Instance.CloudFiles(FileType.SaveFile);
		if (list == null)
		{
			Debug.Log("Load all slot details. No cloud files detected");
		}
		else
		{
			Debug.Log("Load all slot details. Cloud save file count: " + list.Count);
		}
		for (int i = 0; i < slotButtons.Count; i++)
		{
			SlotButton slotButton = slotButtons[i];
			int slotNumber = slotButton.slotNumber;
			int townIndex = 0;
			FileMetadata fileMetadata = Platform.Instance.CreateFileMetadata(slotNumber, townIndex);
			string fileContents;
			LoadResultStatus loadResultStatus = Platform.Instance.TryGetFileContents(fileMetadata, out fileContents);
			Debug.Log("Load slot " + slotNumber + " source " + fileMetadata.fileSource.ToString() + " result " + loadResultStatus);
			if (loadResultStatus == LoadResultStatus.OK)
			{
				GameDataContainer gameDataFromContents = FileManager.GetGameDataFromContents(fileMetadata, fileContents);
				slotButton.ConfigureFromGameData(gameDataFromContents);
			}
			else
			{
				slotButton.SetToEmptyState(state: true);
			}
		}
	}

	private void Options()
	{
		MenuPanel.m.optionsPanel.Show();
	}

	private void OnQuitPressed()
	{
		Application.Quit();
	}

	private void OnCreditsPressed()
	{
		MenuPanel.m.creditsPanel.ReloadLabels();
		MenuPanel.m.creditsPanel.Show();
	}

	private void OnPatchNotesPressed()
	{
		if (Platform.Instance.isPlaytest)
		{
			Application.OpenURL("https://steamcommunity.com/games/2258240/announcements/");
		}
		else
		{
			Application.OpenURL("https://steamcommunity.com/games/2207490/announcements/");
		}
	}

	private void OnStoreButtonPressed()
	{
		if (!MenuPanel.m.fullGameVersionPanel.hasCreatedItems)
		{
			MenuPanel.m.fullGameVersionPanel.CreateItems();
		}
		MenuPanel.m.fullGameVersionPanel.Show();
	}

	private void OnTwitterPressed()
	{
		Application.OpenURL("https://twitter.com/82apps");
	}

	private void OnDiscordPressed()
	{
		Application.OpenURL("https://discord.gg/t3KXHD3scF");
	}

	private void OnFT2ButtonPressed()
	{
		string url = "https://store.steampowered.com/app/3312130/Factory_Town_2_Paradise/?utm_source=ftIdle";
		if (Platform.Instance is PlatformSteam platformSteam)
		{
			platformSteam.OpenGamePageURL(url);
		}
		else
		{
			Application.OpenURL(url);
		}
	}

	private void OnVersionCollapseButtonPressed()
	{
		bool flag = !PlayerPrefs.HasKey("CollapseVersionDetails");
		if (flag)
		{
			PlayerPrefs.SetInt("CollapseVersionDetails", 1);
		}
		else
		{
			PlayerPrefs.DeleteKey("CollapseVersionDetails");
		}
		SetCollapseState(flag);
	}

	private void SetCollapseState(bool collapsedState)
	{
		versionCollapseImage.sprite = (collapsedState ? IconManager.Instance.caratDown : IconManager.Instance.caratUp);
		patchNotesButton.gameObject.SetActive(!collapsedState);
		ft2Button.gameObject.SetActive(!collapsedState);
		creditsButton.gameObject.SetActive(!collapsedState);
		discordButton.gameObject.SetActive(!collapsedState);
		platformLabel.gameObject.SetActive(!collapsedState);
		versionLabel.gameObject.SetActive(!collapsedState);
		versionRegionTransform.SetHeight(collapsedState ? 0f : 286f);
		versionRegionTransform.SetWidth(collapsedState ? 100f : 400f);
		versionRegionImage.enabled = !collapsedState;
	}

	private void BackFromSlots()
	{
		SetToWelcomeState();
		targetTitleTextState = true;
	}

	public void BeginLoadOfMetadata(FileMetadata fileMetadata)
	{
		MenuPanel.gm.overrideFileName = fileMetadata.displayName;
		selectedFileMetadata = fileMetadata;
		MenuManager.Instance.queuedLoadingMenuAction = 1;
		MenuManager.Instance.FadeLoadingCoverIn();
	}

	public void PerformLoadOfSelectedSlot()
	{
		FileManager.ClearAndLoadCurrent(selectedFileMetadata, FileManager.OnLoadResult);
		ClearSelections();
	}

	public void PerformCreateGameOfSelectedSlot()
	{
		FileManager.InitializeAndReset();
		MenuPanel.m.gameSetupPanel.ApplyActiveModifiersToGameState();
		Crafting.LoadDefaults();
		Crafting.LoadAllGameData();
		MenuPanel.gm.InitializeGameStates();
		MenuPanel.gm.ResetGameState();
		MenuManager.Instance.ResetMenuState();
		MenuPanel.gm.overrideFileName = MenuPanel.m.gameSetupPanel.fileNameInputField.text;
		MenuPanel.gm.PrepareInitialTown(MenuPanel.m.gameSetupPanel.DerivedTownName());
		MenuPanel.gm.worldCreationTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		isSelectedSlotEmpty = false;
		FileManager.Save();
		MenuPanel.gm.FinalizeNewWorld();
		ClearSelections();
	}

	private void ClearSelections()
	{
		foreach (SlotButton slotButton in slotButtons)
		{
			slotButton.isSelected = false;
			slotButton.AnimateInstant();
		}
	}

	public void OnCancelledNewTown()
	{
		targetTitleTextState = true;
		slotRegion.gameObject.SetActive(value: false);
		buttonGroup.gameObject.SetActive(value: true);
		versionBox.gameObject.SetActive(value: true);
	}

	public void OnConfirmedNewTownName()
	{
		MenuManager.Instance.queuedLoadingMenuAction = 2;
		MenuManager.Instance.FadeLoadingCoverIn();
	}

	public override bool ShouldBecomeInactiveOnHide()
	{
		return true;
	}
}
