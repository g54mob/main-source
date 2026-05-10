using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LTHUD : InGameHUD
{
	[Header("UIs")]
	[SerializeField]
	private HUDMenu storeUI;

	[SerializeField]
	private HUDMenu settingsUI;

	[SerializeField]
	private HUDMenu upgradesUI;

	[SerializeField]
	private HUDMenu endGameUI;

	[SerializeField]
	private HUDMenu gameOverUI;

	[SerializeField]
	private HUDMenu endGameAnimationUI;

	[SerializeField]
	private NotificationsManager notificationsManager;

	[Header("Demo")]
	[SerializeField]
	private HUDMenu demoStoreUI;

	[Header("Sound")]
	[SerializeField]
	private AudioClip switchModeClip;

	[SerializeField]
	private AudioClip openStoreClip;

	[SerializeField]
	private AudioClip pauseClip;

	private LTPlayerController ltPlayerController;

	private TooltipManager tooltipManager;

	private RectTransform buildingsTooltipsContainer;

	private bool isHotbarDragLocked;

	public TooltipManager TooltipManager => tooltipManager;

	public LTPlayerController LtPlayerController
	{
		get
		{
			return ltPlayerController;
		}
		private set
		{
			ltPlayerController = value;
		}
	}

	public RectTransform BuildingsTooltipsContainer
	{
		get
		{
			return buildingsTooltipsContainer;
		}
		private set
		{
			buildingsTooltipsContainer = value;
		}
	}

	private HUDMenu StoreUI
	{
		get
		{
			return demoStoreUI;
		}
		set
		{
			storeUI = value;
		}
	}

	public bool IsHotbarDragLocked
	{
		get
		{
			return isHotbarDragLocked;
		}
		set
		{
			isHotbarDragLocked = value;
			PlayerPrefs.SetInt("hotbarLocked", IsHotbarDragLocked ? 1 : 0);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		tooltipManager = GetComponent<TooltipManager>();
		BuildingsTooltipsContainer = new GameObject("BuildingsTooltips", typeof(RectTransform)).GetComponent<RectTransform>();
		BuildingsTooltipsContainer.SetParent(base.transform);
		BuildingsTooltipsContainer.SetSiblingIndex(1);
		BuildingsTooltipsContainer.sizeDelta = GetComponent<RectTransform>().sizeDelta;
		BuildingsTooltipsContainer.anchoredPosition = Vector3.zero;
		BuildingsTooltipsContainer.AddComponent<Canvas>();
		BuildingsTooltipsContainer.localScale = Vector3.one;
	}

	protected override void Start()
	{
		LtPlayerController = base.PlayerController as LTPlayerController;
		if (PlayerPrefs.HasKey("hotbarLocked"))
		{
			IsHotbarDragLocked = ((PlayerPrefs.GetInt("hotbarLocked") != 0) ? true : false);
		}
		base.Start();
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		lTGameManager.onGameEnded = (Action)Delegate.Combine(lTGameManager.onGameEnded, new Action(OnGameEnded));
		LTGameManager lTGameManager2 = LTFunctionLibrary.GetLTGameManager();
		lTGameManager2.onGameOver = (Action)Delegate.Combine(lTGameManager2.onGameOver, new Action(OnGameOver));
		LtPlayerController.onInputModeChanged += OnInputModeChanged;
		StartCoroutine(DelayedStartCoroutine());
	}

	private IEnumerator DelayedStartCoroutine()
	{
		yield return new WaitForEndOfFrame();
		base.FadeInOut.FadeOut(1f);
		yield return new WaitForSeconds(1f);
		ShowLevelInfoMessage();
	}

	public override void ShowInGameUI()
	{
		ShowStandardModeUI();
	}

	public void ShowStandardModeUI()
	{
		LtPlayerController.IsPlayerInputLocked = false;
		LtPlayerController.IsMouseBorderMovementLocked = false;
		base.ShowInGameUI();
		LtPlayerController.SwitchInputMode(EInputMode.Standard);
		(base.CurrentUI as InGameUI).ShowStandarModeUI();
	}

	public void ShowEditModeUI()
	{
		LtPlayerController.IsPlayerInputLocked = false;
		LtPlayerController.IsMouseBorderMovementLocked = false;
		base.ShowInGameUI();
		LtPlayerController.SwitchInputMode(EInputMode.EditMode);
		(base.CurrentUI as InGameUI).ShowEditModeUI();
	}

	public void ShowBuyModeUI()
	{
		LtPlayerController.IsPlayerInputLocked = false;
		LtPlayerController.IsMouseBorderMovementLocked = false;
		base.ShowInGameUI();
		LtPlayerController.SwitchInputMode(EInputMode.BuyMode);
		(base.CurrentUI as InGameUI).ShowBuyModeUI();
	}

	public void ShowStoreUI()
	{
		LtPlayerController.IsPlayerInputLocked = false;
		LtPlayerController.IsMouseBorderMovementLocked = true;
		LtPlayerController.SwitchInputMode(EInputMode.Standard);
		ShowMenu(demoStoreUI);
	}

	public void ShowSettingsUI()
	{
		ShowMenu(settingsUI);
	}

	public void ShowGameOverUI()
	{
		ShowMenu(gameOverUI);
	}

	public void ShowEndGameUI()
	{
		ShowMenu(endGameUI);
	}

	public void ShowUpgradesUI()
	{
		ShowMenu(upgradesUI);
	}

	public void ShowEndGameAnimationUI()
	{
		LtPlayerController.SwitchInputMode(EInputMode.Standard);
		LtPlayerController.IsPlayerInputLocked = true;
		LtPlayerController.IsMouseBorderMovementLocked = true;
		ShowMenu(endGameAnimationUI);
	}

	protected override void OnGamePaused()
	{
		LtPlayerController.IsPlayerInputLocked = true;
		if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
		{
			AudioSystem.Instance.PlaySound2D(pauseClip, AudioSystem.EAudioMixerGroup.UI, 1f, 1.15f);
			base.OnGamePaused();
		}
	}

	protected override void OnGameResumed()
	{
		if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
		{
			AudioSystem.Instance.PlaySound2D(pauseClip, AudioSystem.EAudioMixerGroup.UI, 1f, 0.85f);
			base.OnGameResumed();
		}
	}

	private void OnGameEnded()
	{
		LtPlayerController.IsPlayerInputLocked = true;
		ShowMenu(endGameUI);
	}

	private void OnGameOver()
	{
		LtPlayerController.IsPlayerInputLocked = true;
		ShowMenu(gameOverUI);
	}

	public void SwitchMode()
	{
		if (!LtPlayerController.IsPlayerInputLocked && !base.IsPauseMenuOpen)
		{
			switch (LtPlayerController.CurrentInputMode.InputModeType)
			{
			case EInputMode.Standard:
				LtPlayerController.SwitchInputMode(EInputMode.EditMode);
				AudioSystem.Instance.PlaySound2D(switchModeClip, AudioSystem.EAudioMixerGroup.UI, 1f, 1.15f);
				break;
			case EInputMode.EditMode:
				LtPlayerController.SwitchInputMode(EInputMode.Standard);
				AudioSystem.Instance.PlaySound2D(switchModeClip, AudioSystem.EAudioMixerGroup.UI, 1f, 0.85f);
				break;
			case EInputMode.BuyMode:
				LtPlayerController.SwitchInputMode(EInputMode.Standard);
				AudioSystem.Instance.PlaySound2D(switchModeClip, AudioSystem.EAudioMixerGroup.UI, 1f, 0.85f);
				break;
			}
		}
	}

	public void OpenStore()
	{
		if (LtPlayerController.IsPlayerInputLocked || base.IsPauseMenuOpen)
		{
			return;
		}
		if (StoreUI.gameObject.activeSelf)
		{
			switch (LtPlayerController.CurrentInputMode.InputModeType)
			{
			case EInputMode.Standard:
				ShowStandardModeUI();
				break;
			case EInputMode.EditMode:
				ShowEditModeUI();
				break;
			case EInputMode.BuyMode:
				ShowEditModeUI();
				break;
			}
		}
		else
		{
			switch (LtPlayerController.CurrentInputMode.InputModeType)
			{
			case EInputMode.Standard:
				(LtPlayerController.CurrentInputMode as StandardInputMode).SelectedObject = null;
				break;
			case EInputMode.BuyMode:
				LtPlayerController.SwitchInputMode(EInputMode.Standard);
				break;
			}
			ShowStoreUI();
		}
		AudioSystem.Instance.PlaySound2D(openStoreClip, AudioSystem.EAudioMixerGroup.UI);
	}

	public void ShowNotification(string message, ENotificationType notificationType)
	{
		notificationsManager.ShowNotification(message, notificationType);
	}

	public void ShowNotification(string message, ENotificationType notificationType, float duration)
	{
		notificationsManager.ShowNotification(message, notificationType, duration);
	}

	private void ShowLevelInfoMessage()
	{
		if ((bool)MatchInfo.instance.CurrentLevelData && !LTFunctionLibrary.GetLevelsProgressionManager().HasPlayedLevel(MatchInfo.instance.CurrentLevelData.Id) && MatchInfo.instance.CurrentLevelData.InfoMessage != "")
		{
			LevelData currentLevelData = MatchInfo.instance.CurrentLevelData;
			string localizedString = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_ok").Entry.GetLocalizedString();
			Action yesAction = delegate
			{
				LTFunctionLibrary.GetLTGameManager().PauseGame(pause: false, sendEvents: false);
				LTFunctionLibrary.GetLTPlayerController().IsPlayerInputLocked = false;
			};
			ShowModalWindowOneButton(currentLevelData.InfoMessage, currentLevelData.InfoMessageTitle, currentLevelData.InfoMessageImage, yesAction, localizedString);
			LTFunctionLibrary.GetLTGameManager().PauseGame(pause: true, sendEvents: false);
			LTFunctionLibrary.GetLTPlayerController().IsPlayerInputLocked = true;
		}
	}

	private void OnInputModeChanged(InputMode newInputMode, InputMode oldInputMode)
	{
		switch (newInputMode.InputModeType)
		{
		case EInputMode.Standard:
			ShowInGameUI();
			break;
		case EInputMode.EditMode:
			ShowEditModeUI();
			break;
		case EInputMode.BuyMode:
			ShowBuyModeUI();
			break;
		}
	}
}
