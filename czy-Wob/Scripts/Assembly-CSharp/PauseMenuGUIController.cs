using System.Collections;
using TMPro;
using UnityEngine;

public class PauseMenuGUIController : MonoBehaviour
{
	public Animator savingAnimator;

	public TextMeshProUGUI savingText;

	public TextMeshProUGUI savingFailedText;

	public TextMeshProUGUI savingCompleteText;

	public GameObject saveHolder;

	public CoreButtonUnityGUI closeGUIButton;

	public GameObject quitPrompt;

	public GameObject mainMenuPrompt;

	public GameObject optionsMenuPanel;

	public GameObject languageMenuPanel;

	public GameObject controlsMenuPanel;

	public GameObject gameplayOptionsMenuPanel;

	public GameObject menuBlocker;

	public CoreButtonUnityGUI saveGameButton;

	public GameObject saveButtonTextEnabled;

	public GameObject saveButtonTextDisabled;

	public GameObject saveButtonTextBreedingDisabled;

	private string saveGameSound = "game_saved";

	private string windowOpenSound = "incubator_window_open";

	private string windowCloseSound = "incubator_window_close";

	private string savingCompleteAnimBool = "SavingComplete";

	private bool isSaving;

	private bool quitPromptOpen;

	private bool optionsMenuOpen;

	private bool languageMenuOpen;

	private bool controlsMenuOpen;

	private bool mainMenuPromptOpen;

	private bool gameplayOptionsMenuOpen;

	private Coroutine currentControlsClosingRoutine;

	private Coroutine currentGameplayOptionsClosingRoutine;

	private PenFocus penFocusRef;

	private GUIManagerPens guiManagerRef;

	private SaveLoadManager saveLoadManager;

	private void Awake()
	{
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		saveLoadManager = registrationScript.saveLoadManager;
		SceneManagerBase globalComponent = registrationScript.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
		guiManagerRef.DisableBG(LockReason.PAUSE_MENU);
		SFXOverlord.LockInWorldSFX(LockReason.PAUSE_MENU);
		penFocusRef.SetInputAllowed(val: false, LockReason.PAUSE_MENU);
		guiManagerRef.RegisterNewPopup(LockReason.PAUSE_MENU, stomp: true, CloseGUI);
		AudioController.Play(windowOpenSound);
		quitPrompt.SetActive(value: false);
		saveHolder.SetActive(value: false);
		menuBlocker.SetActive(value: false);
		mainMenuPrompt.SetActive(value: false);
		optionsMenuPanel.SetActive(value: false);
		languageMenuPanel.SetActive(value: false);
		controlsMenuPanel.SetActive(value: false);
		gameplayOptionsMenuPanel.SetActive(value: false);
		if (TutorialController.IsTutorialActive())
		{
			saveGameButton.interactable = false;
			saveButtonTextEnabled.SetActive(value: false);
			saveButtonTextDisabled.SetActive(value: true);
			saveButtonTextBreedingDisabled.SetActive(value: false);
		}
		else if (globalComponent.GetGameMode() == GameMode.BREEDING)
		{
			saveGameButton.interactable = false;
			saveButtonTextEnabled.SetActive(value: false);
			saveButtonTextDisabled.SetActive(value: false);
			saveButtonTextBreedingDisabled.SetActive(value: true);
		}
		else
		{
			saveGameButton.interactable = true;
			saveButtonTextEnabled.SetActive(value: true);
			saveButtonTextDisabled.SetActive(value: false);
			saveButtonTextBreedingDisabled.SetActive(value: false);
		}
	}

	public void CloseGUI()
	{
		guiManagerRef.EnableBG(LockReason.PAUSE_MENU);
		SFXOverlord.UnlockInWorldSFX(LockReason.PAUSE_MENU);
		penFocusRef.SetInputAllowed(val: true, LockReason.PAUSE_MENU);
		guiManagerRef.ClearPopupRegistration(LockReason.PAUSE_MENU);
		Object.Destroy(base.gameObject);
		AudioController.Play(windowCloseSound);
	}

	private void Update()
	{
		CheckCloseGUI();
	}

	public void OnOptionsButtonPressed()
	{
		optionsMenuOpen = true;
		optionsMenuPanel.SetActive(value: true);
		menuBlocker.SetActive(value: true);
		closeGUIButton.interactable = false;
	}

	public void OnCloseOptionsButtonPressed()
	{
		optionsMenuOpen = false;
		optionsMenuPanel.SetActive(value: false);
		menuBlocker.SetActive(value: false);
		closeGUIButton.interactable = true;
	}

	public void OnControlsButtonPressed()
	{
		controlsMenuOpen = true;
		controlsMenuPanel.SetActive(value: true);
		menuBlocker.SetActive(value: true);
		closeGUIButton.interactable = false;
	}

	public void OnCloseControlsButtonPressed()
	{
		if (currentControlsClosingRoutine == null)
		{
			ControlsMenuController component = controlsMenuPanel.GetComponent<ControlsMenuController>();
			if (!component.StealCloseInputIfNeeded())
			{
				controlsMenuOpen = false;
				currentControlsClosingRoutine = StartCoroutine(component.SaveOnClose(OnSaveControlsFinished));
			}
		}
	}

	private void OnSaveControlsFinished()
	{
		currentControlsClosingRoutine = null;
		controlsMenuPanel.SetActive(value: false);
		menuBlocker.SetActive(value: false);
		closeGUIButton.interactable = true;
		if (guiManagerRef != null)
		{
			guiManagerRef.UpdateControlVisuals();
		}
	}

	public void OnGameplayOptionsButtonPressed()
	{
		OnCloseOptionsButtonPressed();
		gameplayOptionsMenuOpen = true;
		gameplayOptionsMenuPanel.SetActive(value: true);
		menuBlocker.SetActive(value: true);
		closeGUIButton.interactable = false;
	}

	public void OnCloseGameplayOptionsButtonPressed()
	{
		if (currentGameplayOptionsClosingRoutine == null)
		{
			gameplayOptionsMenuOpen = false;
			GameplayOptionsMenuController component = gameplayOptionsMenuPanel.GetComponent<GameplayOptionsMenuController>();
			currentGameplayOptionsClosingRoutine = StartCoroutine(component.SaveOnClose(OnSaveGameplaySettingsFinished));
		}
	}

	private void OnSaveGameplaySettingsFinished(bool result)
	{
		currentGameplayOptionsClosingRoutine = null;
		gameplayOptionsMenuPanel.SetActive(value: false);
		menuBlocker.SetActive(value: false);
		closeGUIButton.interactable = true;
		OnOptionsButtonPressed();
	}

	public void OnLanguageButtonPressed()
	{
		OnCloseOptionsButtonPressed();
		languageMenuOpen = true;
		languageMenuPanel.SetActive(value: true);
		menuBlocker.SetActive(value: true);
		closeGUIButton.interactable = false;
	}

	public void OnCloseLanguageButtonPressed()
	{
		languageMenuOpen = false;
		languageMenuPanel.SetActive(value: false);
		menuBlocker.SetActive(value: false);
		closeGUIButton.interactable = true;
		OnOptionsButtonPressed();
	}

	public void OnSaveButtonPressed()
	{
		if (!TutorialController.IsTutorialActive())
		{
			saveHolder.SetActive(value: true);
			menuBlocker.SetActive(value: true);
			closeGUIButton.interactable = false;
			StartCoroutine(SaveRoutine());
		}
	}

	public void OnExitToMainMenuButtonPressed()
	{
		mainMenuPromptOpen = true;
		mainMenuPrompt.SetActive(value: true);
		menuBlocker.SetActive(value: true);
		closeGUIButton.interactable = false;
	}

	public void OnCancelMainMenuButtonPressed()
	{
		mainMenuPromptOpen = false;
		mainMenuPrompt.SetActive(value: false);
		menuBlocker.SetActive(value: false);
		closeGUIButton.interactable = true;
	}

	public void OnConfirmMainMenuButtonPressed()
	{
		Object.Destroy(base.gameObject);
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER).GoToTitle();
	}

	public void OnQuitButtonPressed()
	{
		quitPromptOpen = true;
		quitPrompt.SetActive(value: true);
		menuBlocker.SetActive(value: true);
		closeGUIButton.interactable = false;
	}

	public void OnCancelQuitButtonPressed()
	{
		quitPromptOpen = false;
		quitPrompt.SetActive(value: false);
		menuBlocker.SetActive(value: false);
		closeGUIButton.interactable = true;
	}

	public void OnConfirmQuitButtonPressed()
	{
		Application.Quit();
	}

	private IEnumerator SaveRoutine()
	{
		isSaving = true;
		savingAnimator.SetBool(savingCompleteAnimBool, value: false);
		savingText.gameObject.SetActive(value: true);
		savingFailedText.gameObject.SetActive(value: false);
		savingCompleteText.gameObject.SetActive(value: false);
		TextScaleInEffect.ScaleInText(savingText);
		yield return new WaitForSecondsRealtime(1f);
		yield return saveLoadManager.SaveEverything(SaveRoutineFinishedCallback);
	}

	private void SaveRoutineFinishedCallback(bool saveResult)
	{
		savingText.gameObject.SetActive(value: false);
		if (saveResult)
		{
			AudioController.Play(saveGameSound);
			savingCompleteText.gameObject.SetActive(value: true);
			TextScaleInEffect.ScaleInText(savingCompleteText, null, null, 0.25f, 0.015f, null, scaleOut: false, 0.1f);
		}
		else
		{
			savingFailedText.gameObject.SetActive(value: true);
			TextScaleInEffect.ScaleInText(savingFailedText, null, null, 0.25f, 0.015f, null, scaleOut: false, 0.1f);
			Debug.LogError("Manual save failed.");
		}
		StartCoroutine(SaveRoutineFinal());
	}

	private IEnumerator SaveRoutineFinal()
	{
		yield return new WaitForSecondsRealtime(1f);
		savingAnimator.SetBool(savingCompleteAnimBool, value: true);
		yield return new WaitForSecondsRealtime(1f);
		OnSaveComplete();
		savingAnimator.SetBool(savingCompleteAnimBool, value: false);
	}

	private void OnSaveComplete()
	{
		isSaving = false;
		closeGUIButton.interactable = true;
		saveHolder.SetActive(value: false);
		menuBlocker.SetActive(value: false);
	}

	private void CheckCloseGUI()
	{
		if (currentControlsClosingRoutine == null && currentGameplayOptionsClosingRoutine == null && (GameControls.actions.Pause.WasPressed || GameControls.actions.CloseMenu.WasPressed))
		{
			if (optionsMenuOpen)
			{
				OnCloseOptionsButtonPressed();
			}
			else if (gameplayOptionsMenuOpen)
			{
				OnCloseGameplayOptionsButtonPressed();
			}
			else if (languageMenuOpen)
			{
				OnCloseLanguageButtonPressed();
			}
			else if (controlsMenuOpen)
			{
				OnCloseControlsButtonPressed();
			}
			else if (!isSaving && !quitPromptOpen && !mainMenuPromptOpen)
			{
				CloseGUI();
			}
		}
	}
}
