using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class SplashScreen : MonoBehaviour
{
	private enum SplashScreenStage
	{
		LoadScene = 0,
		WaitForVideoComplete = 1,
		TextFadeIn = 2,
		TextHold = 3,
		TextFadeOut = 4,
		WaitForSceneLoad = 5,
		WaitForFrames = 6,
		SkippedVideoFadeOut = 7,
		HoldOnBlackScreen = 8,
		Fade = 9,
		DestroyGameObject = 10,
		Finished = 11
	}

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("SplashScreen");

	private const string UILayerName = "UI";

	private const string HasAdjustedResolutionForSafeAreaKey = "HasAdjustedResolutionForSafeArea";

	public MultiResolutionVideoPlayer splashScreenVideo;

	[CanBeNull]
	[SerializeField]
	private Image _fadeImage;

	public string sceneStringToLoad = "main";

	public float videoFadeOutDurationSeconds = 0.35f;

	public float gameFadeInDurationSeconds = 0.35f;

	private float _fadeTimer;

	[Tooltip("The number of frames to wait before fading.")]
	public float waitFramesBeforeFade = 1f;

	private int _waitFrames;

	[SerializeField]
	private bool _showDemoDisclaimer;

	[SerializeField]
	private BakedLocalizer _localizer;

	[SerializeField]
	private Canvas _canvas;

	[SerializeField]
	private CanvasGroup _textCanvasGroup;

	[SerializeField]
	private TMP_Text _displayText;

	[SerializeField]
	private float _textFadeInDurationSeconds = 1.5f;

	[SerializeField]
	private float _textHoldDurationSeconds = 3f;

	[SerializeField]
	private float _textFadeOutDurationSeconds = 1.5f;

	private AsyncOperation _sceneLoadOperation;

	private SplashScreenStage _splashScreenStage;

	private bool _hasFinishedSplashVideo;

	private bool _canStartFade;

	private bool _isFadeComplete;

	private const string IsFirstRunPlayerPrefsKey = "IsFirstRun";

	private const int OpenedBefore = 1;

	private const int NotOpenedBefore = 0;

	private static readonly UnitBezier AppleArcadeFadeInAnimationFunction = new UnitBezier(0f, 0f, 0.6f, 1f);

	private GameObject _splashScreenCanvas;

	private static bool IsFirstRun => PlayerPrefs.GetInt("IsFirstRun", 0) != 1;

	private Color FadeImageColor
	{
		set
		{
			if (_fadeImage != null)
			{
				_fadeImage.color = value;
			}
		}
	}

	private static void UpdateFirstRunFlag()
	{
		if (IsFirstRun)
		{
			PlayerPrefs.SetInt("IsFirstRun", 1);
			PlayerPrefs.Save();
		}
	}

	private void Awake()
	{
		if (_showDemoDisclaimer && _localizer.GetLocalization(StringId.AppleDemo_SplashScreenNotice, out var localizedString, out var fontAsset))
		{
			localizedString = localizedString.Replace("{Name}", "Mini Motorways");
			_displayText.font = fontAsset;
			_displayText.text = localizedString;
		}
		if (_textCanvasGroup != null)
		{
			_textCanvasGroup.alpha = 0f;
		}
		if (Screen.fullScreen)
		{
			Vector2Int resolution = Vector2Int.zero;
			if (!DesktopHardwareCapabilities.HasHighPowerGpu && !PlayerPrefs.HasKey("HasEnforcedMaxResolution"))
			{
				resolution = new Vector2Int(1920, 1080);
			}
			if (DesktopHardwareCapabilities.SafeAreaHeight > 0 && !PlayerPrefs.HasKey("HasAdjustedResolutionForSafeArea"))
			{
				resolution = DesktopHardwareCapabilities.SafeAreaDimensions;
			}
			if (resolution.x > 0 && resolution.y > 0)
			{
				Vector2Int closestResolution = DesktopHardwareCapabilities.GetClosestResolution(resolution);
				if (closestResolution.x > 0 && closestResolution.y > 0)
				{
					Debug.LogFormat("Changing resolution to {0}x{1}.", closestResolution.x, closestResolution.y);
					Screen.SetResolution(closestResolution.x, closestResolution.y, Screen.fullScreen);
				}
			}
			PlayerPrefs.SetInt("HasAdjustedResolutionForSafeArea", 1);
		}
		if (!DllUtilities.AreLibrariesLoaded(out var missingLibraryFilename))
		{
			ShowLibraryNotLoadedPopup(_canvas, missingLibraryFilename);
			base.enabled = false;
		}
		else
		{
			FadeImageColor = Color.clear;
		}
	}

	private void ShowLibraryNotLoadedPopup(Canvas canvas, string missingLibraryFilename)
	{
		Debug.LogFormat("Mini Motorways cannot launch because it cannot load the file: {0}.", missingLibraryFilename);
		if (!(canvas == null))
		{
			canvas.gameObject.AddComponent<GraphicRaycaster>();
			GameObject obj = new GameObject("EventSystem");
			obj.transform.parent = null;
			obj.AddComponent<EventSystem>();
			obj.AddComponent<StandaloneInputModule>();
			GameObject gameObject = UnityEngine.Object.Instantiate(AssetBundleUtility.LoadAsset<GameObject>("core", "CouldNotLoadLibrariesPopup"), canvas.transform);
			if (!(gameObject == null))
			{
				gameObject.GetComponent<CouldNotLoadLibrariesPopup>().SetMissingLibraryFilename(missingLibraryFilename);
				RectTransform component = gameObject.GetComponent<RectTransform>();
				component.offsetMin = new Vector2(0f, 0f);
				component.offsetMax = new Vector2(0f, 0f);
				LayoutRebuilder.ForceRebuildLayoutImmediate(canvas.GetComponent<RectTransform>());
			}
		}
	}

	private void Start()
	{
		if (splashScreenVideo != null && splashScreenVideo.videoPlayer != null && ((bool)splashScreenVideo.videoPlayer.clip || !string.IsNullOrEmpty(splashScreenVideo.videoPlayer.url)))
		{
			splashScreenVideo.videoPlayer.errorReceived += OnVideoError;
			if (!splashScreenVideo.videoPlayer.isPrepared)
			{
				splashScreenVideo.videoPlayer.prepareCompleted += OnVideoPrepared;
			}
			else
			{
				OnVideoPrepared(splashScreenVideo.videoPlayer);
			}
		}
		else
		{
			Log.Error("Splash screen failed to play video ");
			OnSplashVideoComplete((splashScreenVideo != null) ? splashScreenVideo.videoPlayer : null);
		}
		_sceneLoadOperation = SceneManager.LoadSceneAsync(sceneStringToLoad, LoadSceneMode.Additive);
		_sceneLoadOperation.allowSceneActivation = false;
		if (_showDemoDisclaimer)
		{
			_splashScreenStage = SplashScreenStage.WaitForVideoComplete;
		}
		else
		{
			_splashScreenStage = SplashScreenStage.WaitForSceneLoad;
		}
	}

	private void Update()
	{
		if (_splashScreenStage == SplashScreenStage.WaitForVideoComplete)
		{
			if (!_hasFinishedSplashVideo)
			{
				return;
			}
			_fadeTimer = 0f;
			_splashScreenStage = SplashScreenStage.TextFadeIn;
		}
		else if (_splashScreenStage == SplashScreenStage.TextFadeIn)
		{
			_fadeTimer += Time.deltaTime;
			_textCanvasGroup.alpha = FadeAnimationFunction(_fadeTimer / _textFadeInDurationSeconds);
			if (_fadeTimer >= _textFadeInDurationSeconds)
			{
				_splashScreenStage = SplashScreenStage.TextHold;
				_fadeTimer = 0f;
			}
		}
		else if (_splashScreenStage == SplashScreenStage.TextHold)
		{
			_fadeTimer += Time.deltaTime;
			if (_fadeTimer >= _textHoldDurationSeconds)
			{
				_splashScreenStage = SplashScreenStage.TextFadeOut;
				_fadeTimer = 0f;
			}
		}
		else if (_splashScreenStage == SplashScreenStage.TextFadeOut)
		{
			_fadeTimer += Time.deltaTime;
			_textCanvasGroup.alpha = 1f - FadeAnimationFunction(_fadeTimer / _textFadeOutDurationSeconds);
			if (_fadeTimer >= _textFadeOutDurationSeconds)
			{
				_splashScreenStage = SplashScreenStage.WaitForSceneLoad;
				_fadeTimer = 0f;
			}
		}
		else if (_splashScreenStage == SplashScreenStage.WaitForSceneLoad)
		{
			if (!IsFirstRun && Input.anyKey)
			{
				_fadeTimer = 0f;
				_splashScreenStage = SplashScreenStage.SkippedVideoFadeOut;
			}
			else
			{
				if (!(_sceneLoadOperation.progress >= 0.9f) || !_hasFinishedSplashVideo)
				{
					return;
				}
				_sceneLoadOperation.allowSceneActivation = true;
				_splashScreenStage = SplashScreenStage.HoldOnBlackScreen;
			}
		}
		if (_splashScreenStage == SplashScreenStage.SkippedVideoFadeOut)
		{
			if (_fadeTimer <= videoFadeOutDurationSeconds)
			{
				FadeImageColor = Color.Lerp(Color.clear, Color.black, FadeAnimationFunction(_fadeTimer / videoFadeOutDurationSeconds));
				_fadeTimer += Time.deltaTime;
				return;
			}
			if (_sceneLoadOperation.progress < 0.9f)
			{
				return;
			}
			OnSplashVideoComplete((splashScreenVideo != null) ? splashScreenVideo.videoPlayer : null);
			_sceneLoadOperation.allowSceneActivation = true;
			_splashScreenStage = SplashScreenStage.HoldOnBlackScreen;
		}
		if (_splashScreenStage == SplashScreenStage.HoldOnBlackScreen)
		{
			if (!_canStartFade)
			{
				return;
			}
			_fadeTimer = 0f;
			_splashScreenStage = ((waitFramesBeforeFade <= 0f) ? SplashScreenStage.Fade : SplashScreenStage.WaitForFrames);
		}
		if (_splashScreenStage == SplashScreenStage.WaitForFrames)
		{
			if ((float)_waitFrames < waitFramesBeforeFade)
			{
				_waitFrames++;
				return;
			}
			_splashScreenStage = SplashScreenStage.Fade;
		}
		if (_splashScreenStage == SplashScreenStage.Fade)
		{
			if (_fadeTimer <= gameFadeInDurationSeconds)
			{
				FadeImageColor = Color.Lerp(Color.black, Color.clear, FadeAnimationFunction(_fadeTimer / gameFadeInDurationSeconds));
				_fadeTimer += Time.deltaTime;
				return;
			}
			FadeImageColor = Color.clear;
			_isFadeComplete = true;
			_splashScreenStage = SplashScreenStage.DestroyGameObject;
		}
		if (_splashScreenStage == SplashScreenStage.DestroyGameObject)
		{
			UpdateFirstRunFlag();
			UnityEngine.Object.Destroy(base.gameObject);
			_splashScreenStage = SplashScreenStage.Finished;
		}
	}

	private float FadeAnimationFunction(float x)
	{
		return AppleArcadeFadeInAnimationFunction.Solve(x, UnitBezier.SolveEpsilon(gameFadeInDurationSeconds));
	}

	public void StartFade()
	{
		_canStartFade = true;
	}

	public bool IsFadeComplete()
	{
		return _isFadeComplete;
	}

	private void OnVideoPrepared(VideoPlayer videoPlayer)
	{
		splashScreenVideo.videoPlayer.Play();
		splashScreenVideo.videoPlayer.loopPointReached += OnSplashVideoComplete;
		VideoTimeout();
	}

	private async Task VideoTimeout()
	{
		await Task.Delay(TimeSpan.FromSeconds(5.0));
		OnSplashVideoComplete(null);
	}

	private void OnVideoError(VideoPlayer source, string message)
	{
		Log.Error("Splash video error " + message);
		OnSplashVideoComplete(source);
	}

	private void OnSplashVideoComplete(VideoPlayer source)
	{
		if (source != null)
		{
			source.enabled = false;
		}
		if (!_hasFinishedSplashVideo)
		{
			_hasFinishedSplashVideo = true;
			FadeImageColor = Color.black;
			if (!(splashScreenVideo == null))
			{
				UnityEngine.Object.Destroy(splashScreenVideo);
			}
		}
	}
}
