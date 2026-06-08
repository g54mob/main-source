using UnityEngine;

public class MainMenu : MonoBehaviour, IPostAsciiRendererEffect
{
	public enum State
	{
		FadeIn = 0,
		Normal = 1,
		OptionsMenu = 2,
		SettingsScreen = 3,
		SaveFilesScreen = 4,
		LanguageSelectionScreen = 5,
		CodeRedemptionScreen = 6,
		Credits = 7,
		TransitionToNewGame = 8,
		TransitionToContinue = 9,
		SmallBlankPause = 10,
		SubscriptionInfo = 11,
		Done = 12
	}

	private const float FADE_IN_DURATION = 2f;

	private const float TRANSITION_TO_NEW_GAME_DURATION = 5f;

	private const float TRANSITION_TO_CONTINUE_DURATION = 0.5f;

	public AsciiSprite background;

	public MainMenuButtons buttonsPC;

	public MainMenuButtons buttonsMobile;

	private MainMenuButtons menuButtons;

	public MainMenuOptions optionsMenu;

	public SaveFilesScreen saveFilesScreen;

	public CodeRedemptionScreen codeRedemptionScreen;

	public EventInfoDialog eventInfoDialog;

	public OfflineFarmMainMenuCard offlineFarmCard;

	public EventPremiumInfoDialog subscriptionInfoDialog;

	public AsciiString pendingPurchasesLabel;

	public AsciiSprite loadingIcon;

	private int stateElapsedTics;

	private float fadeInElapsedTime;

	private float circleElapsedTime;

	private float circleTransitionDuration;

	private NavigationGroup navigationGroup;

	private int moonClickCount;

	private float moonLastClickTime;

	private float moonFirstClickTime;

	public State currentState { get; private set; }

	public void Activate(bool fadeIn = true)
	{
		eventInfoDialog.UpdateContents();
		OfflineFarmController.OfflineRunSummary activeRunSummary = OfflineFarmController.singleton.GetActiveRunSummary();
		if (activeRunSummary != null)
		{
			offlineFarmCard.Show(activeRunSummary);
		}
		else
		{
			offlineFarmCard.Hide();
		}
		if (menuButtons.subscriptionButton != null)
		{
			menuButtons.subscriptionButton.enabled = activeRunSummary == null;
			if (SubscriptionController.singleton.HasSubscription(SubscriptionController.EVENTS_SUBSCRIPTION_ID))
			{
				menuButtons.ResetSubscriptionButtonBadge();
			}
		}
		if (fadeIn)
		{
			SetState(State.FadeIn);
		}
		else
		{
			SetState(State.Normal);
		}
		UpdateCodesButtonState();
	}

	private void SetState(State newState)
	{
		if (currentState == State.Credits)
		{
			GameStates.Singleton.demoCreditsScreen.gameObject.SetActive(value: false);
			MusicController.singleton.FadeToSilence();
		}
		switch (newState)
		{
		case State.FadeIn:
			fadeInElapsedTime = 0f;
			circleElapsedTime = 0f;
			AmbianceController.singleton.AddAmbient("cross_deadwood_wind");
			GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			navigationGroup.selectedIndex = -1;
			break;
		case State.OptionsMenu:
			optionsMenu.Show();
			break;
		case State.SettingsScreen:
			GameStates.Singleton.settingsScreen.Show();
			break;
		case State.SaveFilesScreen:
			saveFilesScreen.Show();
			break;
		case State.LanguageSelectionScreen:
			LanguageSelectionScreen.singleton.canBack = true;
			LanguageSelectionScreen.singleton.Show();
			break;
		case State.CodeRedemptionScreen:
			codeRedemptionScreen.Show();
			break;
		case State.Credits:
			AmbianceController.singleton.StopAllAmbient();
			MusicController.singleton.Play("credits");
			GameStates.Singleton.demoCreditsScreen.gameObject.SetActive(value: true);
			GameStates.Singleton.demoCreditsScreen.Activate();
			break;
		case State.TransitionToNewGame:
		case State.TransitionToContinue:
			GameStates.Singleton.HideMouse();
			circleElapsedTime = 0f;
			GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			if (newState == State.TransitionToNewGame)
			{
				circleTransitionDuration = 5f;
				NotificationMacros.FTUE();
			}
			else
			{
				circleTransitionDuration = 0.5f;
			}
			break;
		case State.SmallBlankPause:
			AmbianceController.singleton.StopAllAmbient();
			break;
		case State.SubscriptionInfo:
			subscriptionInfoDialog.Show();
			break;
		case State.Done:
			GameStates.Singleton.asciiRenderer.RemovePostEffect(this);
			GameStates.Singleton.ShowMouse();
			break;
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public void UpdateTic()
	{
		stateElapsedTics++;
		eventInfoDialog.UpdateTic();
		offlineFarmCard.UpdateTic();
		if (currentState == State.FadeIn)
		{
			if (SaveFiles.singleton.storage.GetState() == AStorage.State.StorageMerge)
			{
				(SaveFiles.singleton.storage as CloudOneStorage).ConcludeMerge();
				SetState(State.SaveFilesScreen);
			}
			if (fadeInElapsedTime > 2f)
			{
				SetState(State.Normal);
			}
			UpdateButtons();
		}
		else if (currentState == State.Normal)
		{
			UpdateButtons();
			UpdateMoonClick();
		}
		else if (currentState == State.OptionsMenu)
		{
			optionsMenu.UpdateTic();
			if (optionsMenu.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.SettingsScreen)
		{
			GameStates.Singleton.settingsScreen.UpdateTic();
			if (GameStates.Singleton.settingsScreen.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.SaveFilesScreen)
		{
			saveFilesScreen.UpdateTic();
			if (saveFilesScreen.CurrentState == DialogNineSlice.State.Disabled)
			{
				if (saveFilesScreen.selectedSaveFile != null)
				{
					GameSave.selectedSaveFile = saveFilesScreen.selectedSaveFile;
					saveFilesScreen.selectedSaveFile = null;
					HandlePlayPressed(null);
				}
				else
				{
					SetState(State.Normal);
				}
			}
		}
		else if (currentState == State.LanguageSelectionScreen)
		{
			LanguageSelectionScreen.singleton.UpdateTic();
			if (LanguageSelectionScreen.singleton.IsDone())
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.CodeRedemptionScreen)
		{
			codeRedemptionScreen.UpdateTic();
			if (codeRedemptionScreen.currentState == PopUpModalScreen.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.Credits)
		{
			GameStates.Singleton.demoCreditsScreen.UpdateTic();
			if (GameStates.Singleton.demoCreditsScreen.isDone)
			{
				SetState(State.FadeIn);
			}
		}
		else if (currentState == State.TransitionToNewGame && circleElapsedTime >= 5f)
		{
			SetState(State.SmallBlankPause);
		}
		else if (currentState == State.TransitionToContinue && circleElapsedTime >= 0.5f)
		{
			SetState(State.SmallBlankPause);
		}
		else if (currentState == State.SmallBlankPause && stateElapsedTics >= 5)
		{
			SetState(State.Done);
		}
		else if (currentState == State.SubscriptionInfo)
		{
			subscriptionInfoDialog.UpdateTic();
			if (subscriptionInfoDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
	}

	private void UpdateButtons()
	{
		menuButtons.UpdateTic();
		navigationGroup.UpdateTic();
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentState == State.Credits)
		{
			GameStates.Singleton.demoCreditsScreen.Draw(r, r.width / 2, r.height / 2);
		}
		else if (currentState != State.SmallBlankPause && currentState != State.Done)
		{
			background.Draw(r, offsetX, offsetY);
			if (offlineFarmCard.CurrentState != DialogNineSlice.State.Disabled && menuButtons.signInButton != null && menuButtons.signInButton.enabled)
			{
				menuButtons.Draw(r, offsetX, offsetY + 2);
			}
			else
			{
				menuButtons.Draw(r, offsetX, offsetY);
			}
			eventInfoDialog.Draw(r, offsetX, offsetY);
			offlineFarmCard.Draw(r, offsetX, offsetY);
			if (currentState == State.OptionsMenu)
			{
				optionsMenu.Draw(r, r.width / 2, r.height / 2);
			}
			else if (currentState == State.SettingsScreen)
			{
				GameStates.Singleton.settingsScreen.Draw(r, r.width / 2, r.height / 2);
			}
			else if (currentState == State.SaveFilesScreen)
			{
				saveFilesScreen.Draw(r, r.width / 2, r.height / 2);
			}
			else if (currentState == State.LanguageSelectionScreen)
			{
				LanguageSelectionScreen.singleton.Draw(r, r.width >> 1, 0);
			}
			else if (currentState == State.CodeRedemptionScreen)
			{
				codeRedemptionScreen.Draw(r, r.width / 2, 0);
			}
			else if (currentState == State.SubscriptionInfo)
			{
				subscriptionInfoDialog.Draw(r, r.width / 2, r.height / 2);
			}
			else
			{
				navigationGroup.Draw(r, offsetX, offsetY);
			}
			bool flag = InAppPurchaseController.singleton.HasPendingPurchases();
			if (flag)
			{
				loadingIcon.Draw(r, 0, 0);
				pendingPurchasesLabel.Draw(r, 0, 0);
			}
			if (menuButtons.subscriptionButton != null)
			{
				menuButtons.subscriptionButton.isDisabledState = flag;
			}
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		float num = Mathf.Clamp01(fadeInElapsedTime / 2f);
		float num2 = Mathf.Clamp01(circleElapsedTime / circleTransitionDuration);
		int num3 = r.width / 2;
		int num4 = r.height / 2;
		float num5 = (1f - num2) * (float)num3;
		num5 -= 1f;
		for (int i = 0; i < r.width; i++)
		{
			float num6 = num3 - i;
			float num7 = num6 * num6;
			for (int j = 0; j < r.height; j++)
			{
				float t = num;
				if (currentState == State.TransitionToNewGame || currentState == State.TransitionToContinue)
				{
					float num8 = (float)(num4 - j) / 0.5f;
					float num9 = Mathf.Sqrt(num7 + num8 * num8) - num5;
					if (num9 > 0f)
					{
						t = 1f - num9;
						t = Mathf.Clamp01(t);
					}
				}
				AsciiCellProcedural cell = r.GetCell(i, j);
				Color foreground = cell.GetForeground();
				Color b = cell.GetBackground();
				cell.SetForeground(Color.Lerp(ColorConstants.black, foreground, t));
				cell.SetBackground(Color.Lerp(ColorConstants.black, b, t));
			}
		}
	}

	private void Update()
	{
		fadeInElapsedTime += Time.deltaTime;
		if (currentState == State.TransitionToNewGame || currentState == State.TransitionToContinue)
		{
			circleElapsedTime += Time.deltaTime;
		}
	}

	private void UpdateMoonClick()
	{
		AsciiMouse singleton = AsciiMouse.singleton;
		if (!singleton.down0)
		{
			return;
		}
		AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
		int num = asciiRenderer.width / 2 + 7;
		if (singleton.x < num - 3 || singleton.x > num + 3)
		{
			return;
		}
		int num2 = ((asciiRenderer.height == 25) ? 2 : 3);
		if (singleton.y >= num2 - 1 && singleton.y <= num2 + 1)
		{
			float num3 = Time.realtimeSinceStartup - moonLastClickTime;
			moonLastClickTime = Time.realtimeSinceStartup;
			if (num3 > 1f)
			{
				moonClickCount = 0;
				moonFirstClickTime = Time.realtimeSinceStartup;
			}
			moonClickCount++;
			float num4 = (Time.realtimeSinceStartup - moonFirstClickTime) / (float)moonClickCount;
			if (moonClickCount >= 5 && num4 < 0.25f)
			{
				moonClickCount = 0;
				Features.CODES_SCREEN_ENABLED = true;
				string text = Te.xt("Codes");
				text = "\n" + new string(' ', (asciiRenderer.width - text.Length) / 2) + text;
				GameplayActionMessages.SetMessage(text, ColorConstants.rarityHeroic);
			}
		}
	}

	public void HandlePlayPressed(DialogButton btn)
	{
		SaveFiles.SaveFileMeta selectedSaveFile = GameSave.selectedSaveFile;
		if (selectedSaveFile != null && !string.IsNullOrEmpty(selectedSaveFile.version) && Version.FromString(selectedSaveFile.version) > Features.VERSION && (saveFilesScreen.fileFromFutureConfirmationDialog.saveFileRow == null || selectedSaveFile != saveFilesScreen.fileFromFutureConfirmationDialog.saveFileRow.saveFile))
		{
			SetState(State.SaveFilesScreen);
			saveFilesScreen.ShowFileFromTheFuture(selectedSaveFile);
		}
		else if (selectedSaveFile == null || !selectedSaveFile.IsNew())
		{
			SetState(State.TransitionToContinue);
		}
		else
		{
			SetState(State.TransitionToNewGame);
		}
		AnalyticsMacros.MainMenuPlayPressed();
	}

	private void HandleOptionsPressed(DialogButton btn)
	{
		SetState(State.OptionsMenu);
	}

	private void HandleExitPressed(DialogButton btn)
	{
		Application.Quit();
	}

	private void HandleSettingsButtonPressed(DialogButton btn)
	{
		SetState(State.SettingsScreen);
	}

	private void HandleSaveFilesButtonPressed(DialogButton btn)
	{
		SetState(State.SaveFilesScreen);
	}

	private void HandleLanguageButtonPressed(DialogButton btn)
	{
		SetState(State.LanguageSelectionScreen);
	}

	private void UpdateCodesButtonState()
	{
		optionsMenu.codesButton.isDisabledState = GameSave.selectedSaveFile == null || GameSave.selectedSaveFile.progressData == null;
	}

	private void HandleCodesButtonPressed(DialogButton btn)
	{
		if (GameSave.selectedSaveFile != null && GameSave.selectedSaveFile.progressData != null)
		{
			SetState(State.CodeRedemptionScreen);
		}
	}

	private void HandleCreditsButtonPressed(DialogButton btn)
	{
		SetState(State.Credits);
	}

	private void HandleSubscriptionButtonPressed(DialogButton btn)
	{
		SetState(State.SubscriptionInfo);
	}

	private void HandleSettingsSubscriptionButtonPressed(DialogButton btn)
	{
		if (SubscriptionController.singleton.HasSubscription(SubscriptionController.EVENTS_SUBSCRIPTION_ID))
		{
			Application.OpenURL("https://play.google.com/store/account/subscriptions");
		}
		else
		{
			SetState(State.SubscriptionInfo);
		}
	}

	private void Start()
	{
		AsciiParticleEmitter[] componentsInChildren = background.GetComponentsInChildren<AsciiParticleEmitter>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].layerType = AsciiParticleEmitter.LayerType.UI;
		}
		if (GameStates.Singleton.settingsScreen.subscriptionButton != null)
		{
			GameStates.Singleton.settingsScreen.subscriptionButton.OnPressed += HandleSettingsSubscriptionButtonPressed;
		}
	}

	private void Awake()
	{
		menuButtons = buttonsPC;
		menuButtons.playButton.OnPressed += HandlePlayPressed;
		menuButtons.optionsButton.OnPressed += HandleOptionsPressed;
		if (menuButtons.exitButton != null)
		{
			menuButtons.exitButton.OnPressed += HandleExitPressed;
		}
		navigationGroup = GetComponent<NavigationGroup>();
		navigationGroup.Add(menuButtons.playButton);
		navigationGroup.Add(menuButtons.optionsButton);
		if (menuButtons.exitButton != null)
		{
			navigationGroup.Add(menuButtons.exitButton);
		}
		optionsMenu.settingsButton.OnPressed += HandleSettingsButtonPressed;
		optionsMenu.saveFilesButton.OnPressed += HandleSaveFilesButtonPressed;
		optionsMenu.languageButton.OnPressed += HandleLanguageButtonPressed;
		optionsMenu.codesButton.OnPressed += HandleCodesButtonPressed;
		optionsMenu.creditsButton.OnPressed += HandleCreditsButtonPressed;
		if (menuButtons.subscriptionButton != null)
		{
			menuButtons.subscriptionButton.OnPressed += HandleSubscriptionButtonPressed;
		}
	}

	private void OnDestroy()
	{
		menuButtons.playButton.OnPressed -= HandlePlayPressed;
		menuButtons.optionsButton.OnPressed -= HandleOptionsPressed;
		if (menuButtons.exitButton != null)
		{
			menuButtons.exitButton.OnPressed -= HandleExitPressed;
		}
		optionsMenu.settingsButton.OnPressed -= HandleSettingsButtonPressed;
		optionsMenu.saveFilesButton.OnPressed -= HandleSaveFilesButtonPressed;
		optionsMenu.languageButton.OnPressed -= HandleLanguageButtonPressed;
		optionsMenu.codesButton.OnPressed -= HandleCodesButtonPressed;
		optionsMenu.creditsButton.OnPressed -= HandleCreditsButtonPressed;
	}
}
