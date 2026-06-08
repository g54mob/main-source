using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DG.Tweening;
using Dorfromantik;
using Dorfromantik.UI;
using Dorfromantik.UI.MainMenu;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class MainMenuUi : Singleton<MainMenuUi>
{
	private sealed class _003CShowingSavingLabel_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainMenuUi _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CShowingSavingLabel_003Ed__59(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			MainMenuUi mainMenuUi = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				mainMenuUi.savingLabel.Show(shouldShow: true);
				_003C_003E2__current = new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				mainMenuUi.savingLabel.Show(shouldShow: false);
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private LoadingScreen loadingScreen;

	[SerializeField]
	private HideableUi savingLabel;

	[SerializeField]
	private HideableUi scoreScreen;

	[SerializeField]
	private HideableUi statsScreen;

	[SerializeField]
	private TooltipManager tooltipManager;

	[SerializeField]
	public SessionQuestScreen challengeScreen;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private SceneLoader sceneLoader;

	[SerializeField]
	private SessionQuestManager sessionQuestManager;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private LoadingProgressRouter loadingProgressRouter;

	[SerializeField]
	private VfxManager vfxManager;

	[SerializeField]
	private AudioClipOptions menuSlideSound;

	[SerializeField]
	private bool debug_alwaysShowAnalyticsScreen;

	private ConfirmationScreen activeConfirmationScreen;

	private Dictionary<MainMenuScreenType, MainMenuScreen> menuScreenByType;

	private Dictionary<ConfirmationScreenType, ConfirmationScreen> confirmationScreenByType;

	private List<MainMenuScreenType> activeScreens = new List<MainMenuScreenType>();

	private GameMode targetGameMode;

	[SerializeField]
	private VolumeProfile cameraVolumeProfile;

	private Vignette cameraVolumeProfileVignette;

	private Vector2Parameter originCameraVolumeVignetteCenter;

	private ClampedFloatParameter originCameraVolumeIntensity;

	private Sequence brightnessChangeSequence;

	internal MainMenuScreenType ActiveScreen
	{
		get
		{
			if (activeScreens.Count <= 0)
			{
				return MainMenuScreenType.None;
			}
			return Enumerable.Last(activeScreens);
		}
	}

	public TooltipManager TooltipManager => tooltipManager;

	public SettingsRouter SettingsRouter => settingsRouter;

	public ConfirmationScreen ActiveConfirmationScreen => activeConfirmationScreen;

	public event Action<MainMenuScreen> OnLeaveMenuScreen;

	public event Action<MainMenuScreen> OnSwitchActiveScreen;

	protected override void Awake()
	{
		base.Awake();
		menuScreenByType = new Dictionary<MainMenuScreenType, MainMenuScreen>();
		MainMenuScreen[] componentsInChildren = GetComponentsInChildren<MainMenuScreen>(includeInactive: true);
		foreach (MainMenuScreen mainMenuScreen in componentsInChildren)
		{
			menuScreenByType.Add(mainMenuScreen.screenType, mainMenuScreen);
		}
		confirmationScreenByType = new Dictionary<ConfirmationScreenType, ConfirmationScreen>();
		ConfirmationScreen[] componentsInChildren2 = GetComponentsInChildren<ConfirmationScreen>(includeInactive: true);
		foreach (ConfirmationScreen confirmationScreen in componentsInChildren2)
		{
			confirmationScreenByType.Add(confirmationScreen.type, confirmationScreen);
		}
		inputRouter.OnToggleMenu += ToggleMainMenu;
		inputRouter.OnMenuCancel += CancelMenu;
		loadingProgressRouter.OnCompleted += HideLoadingScreen;
		Debug.Log("Dorfromantik v" + Application.version + "\nOS:" + SystemInfo.operatingSystem + $"\nCPU:{SystemInfo.processorType} ({SystemInfo.processorCount} x {SystemInfo.processorFrequency} MB)" + $"\n{SystemInfo.graphicsDeviceName}, {SystemInfo.graphicsMemorySize} MB - {SystemInfo.graphicsDeviceType}" + $"\nRAM: {SystemInfo.systemMemorySize} MB\n" + $"\nShaderLevel: {SystemInfo.graphicsShaderLevel}" + $"\nRendering Threaded Mode: {SystemInfo.renderingThreadingMode}" + $"\nSupports 3D RenderTextures: {SystemInfo.supports3DRenderTextures}" + $"\nMulti threaded Rendering: {SystemInfo.graphicsMultiThreaded}\n");
	}

	public void CancelMenu()
	{
		Debug.Log($"Cancel Menu - Active Conformation Screen? {activeConfirmationScreen}, Active Screen? {ActiveScreen}");
		if ((bool)activeConfirmationScreen)
		{
			activeConfirmationScreen.HideConfirmationScreen(returnToPreviousScreen: true);
			return;
		}
		switch (ActiveScreen)
		{
		case MainMenuScreenType.None:
			break;
		case MainMenuScreenType.NavigationBar:
		case MainMenuScreenType.CreativeMode_Configuration:
		case MainMenuScreenType.CreativeMode_Configuration_Gamepad:
			SwitchToScreen(MainMenuScreenType.None);
			break;
		case MainMenuScreenType.CustomMode_Configuration:
		case MainMenuScreenType.CustomMode_Configuration_Gamepad:
			SwitchToScreen(MainMenuScreenType.GameSelection_Custom);
			break;
		default:
			SwitchToScreen(MainMenuScreenType.NavigationBar);
			break;
		}
	}

	private void Start()
	{
		foreach (KeyValuePair<MainMenuScreenType, MainMenuScreen> item in menuScreenByType)
		{
			item.Value.Show(shouldShow: false, shouldAnimate: false);
		}
		SwitchToScreen(settingsRouter.defaultSettings.defaultStartupScreen, animate: false);
		savingLabel.Show(shouldShow: false, shouldAnimate: false);
		GetInitialCameraVolumeData();
		loadingScreen.Show(newShow: true, animate: false);
		if (OverwritingSingleton<IngameUi>.Instance == null)
		{
			sceneLoader.OnSceneLoaded += InitialSceneLoadFinished;
		}
		else
		{
			InitialSceneLoadFinished(default(Scene));
		}
	}

	private void OnApplicationQuit()
	{
		ResetCameraVolumeData();
	}

	public void ToggleMainMenu()
	{
		MainMenuScreenType activeScreen = ActiveScreen;
		SwitchToScreen((activeScreen == MainMenuScreenType.None || activeScreen == MainMenuScreenType.CreativeMode_Configuration || activeScreen == MainMenuScreenType.CreativeMode_Configuration_Gamepad) ? MainMenuScreenType.NavigationBar : MainMenuScreenType.None);
	}

	public void SwitchToScreen(int screenIndex)
	{
		SwitchToScreen((MainMenuScreenType)screenIndex);
	}

	public void SwitchToScreen(MainMenuScreenType newActiveScreenType, bool animate = true)
	{
		ShowConfirmationScreen(ConfirmationScreenType.None);
		if (ActiveScreen == newActiveScreenType || IsChildScreen(ActiveScreen, newActiveScreenType))
		{
			switch (newActiveScreenType)
			{
			case MainMenuScreenType.None:
				ChangeIngameBrightness(shouldMakeDarker: false);
				return;
			case MainMenuScreenType.CreativeMode_Configuration:
			case MainMenuScreenType.CreativeMode_Configuration_Gamepad:
				newActiveScreenType = MainMenuScreenType.None;
				break;
			default:
				newActiveScreenType = MainMenuScreenType.NavigationBar;
				break;
			}
		}
		if (newActiveScreenType != MainMenuScreenType.None && menuScreenByType[newActiveScreenType].layer >= 2)
		{
			MainMenuScreenType parentScreen = GetParentScreen(newActiveScreenType);
			if (parentScreen != MainMenuScreenType.None && !activeScreens.Contains(parentScreen))
			{
				SwitchToScreen(parentScreen, animate);
			}
		}
		inputRouter.ShowRadialMenu(show: false, executeSelectedCommand: false);
		scoreScreen.Show(newActiveScreenType == MainMenuScreenType.NavigationBar || rewardSystem.IsGameOver, animate);
		statsScreen.Show(newActiveScreenType == MainMenuScreenType.NavigationBar, animate);
		MainMenuScreen mainMenuScreen = ((newActiveScreenType == MainMenuScreenType.None) ? null : menuScreenByType[newActiveScreenType]);
		for (int num = activeScreens.Count - 1; num >= 0; num--)
		{
			MainMenuScreen mainMenuScreen2 = menuScreenByType[activeScreens[num]];
			if (mainMenuScreen == null || mainMenuScreen2.layer >= mainMenuScreen.layer)
			{
				mainMenuScreen2.Show(shouldShow: false);
				activeScreens.RemoveAt(num);
				this.OnLeaveMenuScreen?.Invoke(mainMenuScreen2);
			}
		}
		if (mainMenuScreen != null)
		{
			activeScreens.Add(newActiveScreenType);
			mainMenuScreen.Show(shouldShow: true);
		}
		switch (newActiveScreenType)
		{
		case MainMenuScreenType.None:
			inputRouter.SetInputState(GameState.Playing);
			ChangeIngameBrightness(shouldMakeDarker: false);
			if ((bool)vfxManager.ActiveChallengeFx)
			{
				vfxManager.ActiveChallengeFx.SelectDefault();
			}
			else if (rewardSystem.IsGameOver)
			{
				OverwritingSingleton<IngameUi>.Instance.SelectGameOverScreenDefault();
			}
			break;
		case MainMenuScreenType.CreativeMode_Configuration:
			inputRouter.SetInputState(GameState.Playing);
			ChangeIngameBrightness(shouldMakeDarker: false);
			break;
		case MainMenuScreenType.CreativeMode_Configuration_Gamepad:
			inputRouter.SetInputState(GameState.NavigationBar);
			ChangeIngameBrightness(shouldMakeDarker: false);
			break;
		case MainMenuScreenType.NavigationBar:
			inputRouter.SetInputState(GameState.NavigationBar);
			ChangeIngameBrightness(shouldMakeDarker: true);
			break;
		default:
			inputRouter.SetInputState(GameState.Menu);
			ChangeIngameBrightness(shouldMakeDarker: true);
			break;
		}
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			OverwritingSingleton<IngameUi>.Instance.ShowUi((newActiveScreenType == MainMenuScreenType.None && !loadingProgressRouter.IsLoading) || newActiveScreenType == MainMenuScreenType.CreativeMode_Configuration || newActiveScreenType == MainMenuScreenType.CreativeMode_Configuration_Gamepad);
		}
		if (ActiveScreen == newActiveScreenType)
		{
			this.OnSwitchActiveScreen?.Invoke(mainMenuScreen);
		}
		if ((bool)AudioManager.Instance)
		{
			AudioManager.Instance.PlayGlobalSound(menuSlideSound);
		}
	}

	private MainMenuScreenType GetParentScreen(MainMenuScreenType childScreenType)
	{
		switch (childScreenType)
		{
		case MainMenuScreenType.GameSelection_Custom:
		case MainMenuScreenType.GameSelection_Classic:
		case MainMenuScreenType.GameSelection_Creative:
		case MainMenuScreenType.GameSelection_Tutorial:
		case MainMenuScreenType.GameSelection_Quick:
		case MainMenuScreenType.GameSelection_Hard:
		case MainMenuScreenType.GameSelection_Monthly:
			return MainMenuScreenType.GameSelection;
		case MainMenuScreenType.Settings_Graphics:
		case MainMenuScreenType.Settings_Audio:
		case MainMenuScreenType.Settings_Controls:
		case MainMenuScreenType.Settings_Other:
		case MainMenuScreenType.Settings_Controls_Gamepad:
			return MainMenuScreenType.Settings;
		default:
			return MainMenuScreenType.None;
		}
	}

	private bool IsChildScreen(MainMenuScreenType potentialChildScreen, MainMenuScreenType potentialParentScreen)
	{
		if (potentialParentScreen == MainMenuScreenType.GameSelection && (potentialChildScreen == MainMenuScreenType.GameSelection_Classic || potentialChildScreen == MainMenuScreenType.GameSelection_Creative || potentialChildScreen == MainMenuScreenType.GameSelection_Quick || potentialChildScreen == MainMenuScreenType.GameSelection_Hard || potentialChildScreen == MainMenuScreenType.GameSelection_Custom || potentialChildScreen == MainMenuScreenType.GameSelection_Monthly || potentialChildScreen == MainMenuScreenType.GameSelection_Tutorial))
		{
			return true;
		}
		if (potentialParentScreen == MainMenuScreenType.Settings && (potentialChildScreen == MainMenuScreenType.Settings_Audio || potentialChildScreen == MainMenuScreenType.Settings_Controls || potentialChildScreen == MainMenuScreenType.Settings_Controls_Gamepad || potentialChildScreen == MainMenuScreenType.Settings_Graphics || potentialChildScreen == MainMenuScreenType.Settings_Other))
		{
			return true;
		}
		return false;
	}

	private void SceneLoadStarted(AsyncOperation obj)
	{
		ShowConfirmationScreen(ConfirmationScreenType.None);
		loadingScreen.Show(newShow: true);
	}

	private void HideLoadingScreen()
	{
		loadingScreen.Show(newShow: false);
	}

	private void InitialSceneLoadFinished(Scene obj)
	{
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			sceneLoader.OnSceneLoaded -= InitialSceneLoadFinished;
			sceneLoader.OnSceneLoadStarted += SceneLoadStarted;
			sceneLoader.OnSceneLoaded += SceneLoadFinished;
		}
	}

	private void SceneLoadFinished(Scene obj)
	{
		SwitchToScreen(MainMenuScreenType.None);
	}

	public void ChangeIngameBrightness(bool shouldMakeDarker)
	{
		if (!cameraVolumeProfileVignette)
		{
			GetInitialCameraVolumeData();
		}
		Sequence sequence = brightnessChangeSequence;
		if (sequence != null)
		{
			TweenExtensions.Kill(sequence);
		}
		brightnessChangeSequence = DOTween.Sequence();
		if (shouldMakeDarker)
		{
			TweenSettingsExtensions.Insert(brightnessChangeSequence, 0f, DOTween.To(() => cameraVolumeProfileVignette.center.value, delegate(Vector2 value)
			{
				cameraVolumeProfileVignette.center.Override(value);
			}, new Vector2(-1.65f, -0.5f), 0.5f));
			TweenSettingsExtensions.Insert(brightnessChangeSequence, 0f, DOTween.To(() => cameraVolumeProfileVignette.intensity.value, delegate(float value)
			{
				cameraVolumeProfileVignette.intensity.Override(value);
			}, 0.1f, 0.5f));
		}
		else
		{
			TweenSettingsExtensions.Insert(brightnessChangeSequence, 0f, DOTween.To(() => cameraVolumeProfileVignette.center.value, delegate(Vector2 value)
			{
				cameraVolumeProfileVignette.center.Override(value);
			}, (Vector2)originCameraVolumeVignetteCenter, 0.5f));
			TweenSettingsExtensions.Insert(brightnessChangeSequence, 0f, DOTween.To(() => cameraVolumeProfileVignette.intensity.value, delegate(float value)
			{
				cameraVolumeProfileVignette.intensity.Override(value);
			}, (float)originCameraVolumeIntensity, 0.5f));
		}
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			TweenSettingsExtensions.OnUpdate(brightnessChangeSequence, OverwritingSingleton<IngameUi>.Instance.UpdateCameraVolumeStack);
		}
	}

	private void GetInitialCameraVolumeData()
	{
		if (!cameraVolumeProfile)
		{
			throw new NullReferenceException("VolumeProfile");
		}
		if (cameraVolumeProfileVignette == null && !cameraVolumeProfile.TryGet<Vignette>(out cameraVolumeProfileVignette))
		{
			throw new NullReferenceException("cameraVolumeProfileVignette");
		}
		if (originCameraVolumeVignetteCenter == null)
		{
			originCameraVolumeVignetteCenter = new Vector2Parameter((Vector2)cameraVolumeProfileVignette.center, overrideState: true);
		}
		if (originCameraVolumeIntensity == null)
		{
			originCameraVolumeIntensity = new ClampedFloatParameter((float)cameraVolumeProfileVignette.intensity, 0f, 1f, overrideState: true);
		}
	}

	private void ResetCameraVolumeData()
	{
		if ((bool)cameraVolumeProfileVignette)
		{
			cameraVolumeProfileVignette.center.SetValue(originCameraVolumeVignetteCenter);
			cameraVolumeProfileVignette.intensity.SetValue(originCameraVolumeIntensity);
		}
	}

	private void DebugActiveScene()
	{
		Debug.Log(SceneManager.GetActiveScene().name);
	}

	public void ShowConfirmationScreen(int screenIndex)
	{
		ShowConfirmationScreen((ConfirmationScreenType)screenIndex);
	}

	public void ShowConfirmationScreen(ConfirmationScreenType targetType)
	{
		if ((bool)activeConfirmationScreen && activeConfirmationScreen.type == targetType && activeConfirmationScreen.Shown)
		{
			return;
		}
		if ((bool)activeConfirmationScreen && activeConfirmationScreen.Shown)
		{
			activeConfirmationScreen.Show(newShow: false);
		}
		if (targetType == ConfirmationScreenType.None)
		{
			activeConfirmationScreen = null;
			if (ActiveScreen != MainMenuScreenType.None)
			{
				menuScreenByType[ActiveScreen].SelectLastOrDefaultSelectable();
			}
			else if (rewardSystem.IsGameOver && (bool)OverwritingSingleton<IngameUi>.Instance)
			{
				OverwritingSingleton<IngameUi>.Instance.SelectGameOverScreenDefault();
			}
		}
		else
		{
			activeConfirmationScreen = confirmationScreenByType[targetType];
			confirmationScreenByType[targetType].Show(newShow: true);
		}
	}

	public void ShowSavingLabel()
	{
		StartCoroutine(ShowingSavingLabel());
	}

	private IEnumerator ShowingSavingLabel()
	{
		return new _003CShowingSavingLabel_003Ed__59(0)
		{
			_003C_003E4__this = this
		};
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		inputRouter.OnToggleMenu -= ToggleMainMenu;
		sceneLoader.OnSceneLoadStarted -= SceneLoadStarted;
		sceneLoader.OnSceneLoaded -= SceneLoadFinished;
		sceneLoader.OnSceneLoaded -= InitialSceneLoadFinished;
		loadingProgressRouter.OnCompleted -= HideLoadingScreen;
		inputRouter.OnMenuCancel -= CancelMenu;
	}

	public void ShowScoreScreen(bool show, bool showStatsScreen)
	{
		scoreScreen.Show(show);
		statsScreen.Show(showStatsScreen);
	}

	private Vector2 _003CChangeIngameBrightness_003Eb__52_0()
	{
		return cameraVolumeProfileVignette.center.value;
	}

	private void _003CChangeIngameBrightness_003Eb__52_1(Vector2 value)
	{
		cameraVolumeProfileVignette.center.Override(value);
	}

	private float _003CChangeIngameBrightness_003Eb__52_2()
	{
		return cameraVolumeProfileVignette.intensity.value;
	}

	private void _003CChangeIngameBrightness_003Eb__52_3(float value)
	{
		cameraVolumeProfileVignette.intensity.Override(value);
	}

	private Vector2 _003CChangeIngameBrightness_003Eb__52_4()
	{
		return cameraVolumeProfileVignette.center.value;
	}

	private void _003CChangeIngameBrightness_003Eb__52_5(Vector2 value)
	{
		cameraVolumeProfileVignette.center.Override(value);
	}

	private float _003CChangeIngameBrightness_003Eb__52_6()
	{
		return cameraVolumeProfileVignette.intensity.value;
	}

	private void _003CChangeIngameBrightness_003Eb__52_7(float value)
	{
		cameraVolumeProfileVignette.intensity.Override(value);
	}
}
