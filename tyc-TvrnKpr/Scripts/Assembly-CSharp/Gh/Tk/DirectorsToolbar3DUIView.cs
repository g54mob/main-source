using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk.UI;
using I18n;
using RenderHeads.Media.AVProMovieCapture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gh.Tk
{
	public class DirectorsToolbar3DUIView : ShowHideAnimation3DUIView
	{
		[Serializable]
		public class CameraPresetData
		{
			public string name;

			public float fieldOfView;

			public bool includeCameraTransformData;

			public CameraTransformData CameraTransformData;

			public bool includeCameraEffectsData;

			public CameraEffectsData CameraEffectsData;

			public float audioListenerDistanceOverride;
		}

		[Serializable]
		public class CameraEffectsData
		{
			public float tiltShiftBlur;

			public float tiltShiftFocusPoint;

			public float cameraRoll;

			public float greyscale;

			public float bloom;

			public float vignette;

			public float lutBlend;

			public int colourLutIndex;

			public int overlayIndex;
		}

		[Serializable]
		public class LUTOption
		{
			public string label;

			public Texture2D lut;

			public LUTOption()
			{
			}

			public LUTOption(string label, Texture2D lut)
			{
			}
		}

		[Serializable]
		public class OverlayOption
		{
			public string label;

			public Sprite image;

			public float cropToHeight;

			public float cropToWidth;
		}

		public static class AnimNames
		{
			public static string OrbitLeft;

			public static string OrbitRight;

			public static string PanForward;

			public static string PanLeft;

			public static string PanBack;

			public static string PanRight;

			public static string ZoomIn;

			public static string ZoomOut;
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass107_0
		{
			public RenderTexture rt;

			internal RenderTexture _003CCreateScreenshot_003Eb__0(Camera x)
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CCreateScreenshot_003Ed__107 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public int width;

			public int height;

			public DirectorsToolbar3DUIView _003C_003E4__this;

			private _003C_003Ec__DisplayClass107_0 _003C_003E8__1;

			private Camera[] _003CrenderCams_003E5__2;

			private RenderTexture[] _003CpreviousRenderTargets_003E5__3;

			private bool _003CpreviousToolbarState_003E5__4;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CCreateScreenshot_003Ed__107(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CTakeScreenshot_003Ed__103 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DirectorsToolbar3DUIView _003C_003E4__this;

			private string _003CscreenshotFolder_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CTakeScreenshot_003Ed__103(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private List<GameObject> _devToolsSection;

		private CameraRigBase _currentCamera;

		[SerializeField]
		private Button3DUIView _closeButton;

		[SerializeField]
		private Camera _toolbarCamera;

		[SerializeField]
		private Camera _overlayCamera;

		[SerializeField]
		private DayTimeSlider _dayTimeSlider;

		[Header("PostFX")]
		[SerializeField]
		private TMP_DropdownI18n _overlayDropdown;

		[SerializeField]
		private Image _overlayImage;

		[SerializeField]
		private TMP_DropdownI18n _colourLUTDropdown;

		[SerializeField]
		private Slider3DUIView _bloomSlider;

		[SerializeField]
		private Slider3DUIView _tiltShiftBlurSlider;

		[SerializeField]
		private Slider3DUIView _tiltShiftFocusPointSlider;

		[SerializeField]
		private CheckBox3DUIView _tiltShiftMouseModeCheckbox;

		[SerializeField]
		private Slider3DUIView _greySlider;

		[SerializeField]
		private Slider3DUIView _lutSlider;

		[SerializeField]
		private Slider3DUIView _vignetteSlider;

		[SerializeField]
		private Slider3DUIView _cameraRollSlider;

		[SerializeField]
		private Slider3DUIView _cameraFOVSlider;

		public List<Texture2D> _generatedLutOptions;

		public List<LUTOption> _lutOptions;

		public List<OverlayOption> _overlayOptions;

		private float _worldMapCameraDefaultFOV;

		private float _tavernCameraDefaultFOV;

		private float _tavernFreeCameraDefaultFOV;

		private float _worldMapFreeCameraDefaultFOV;

		[Header("Camera Animation")]
		[SerializeField]
		private TMP_DropdownI18n _cameraAnimDropdown;

		[SerializeField]
		private TMP_DropdownI18n _cameraAnimPresetEaseDropdown;

		[SerializeField]
		private Slider3DUIView _cameraAnimSpeedSlider;

		[SerializeField]
		private Button3DUIView _cameraAnimPlayPauseButton;

		[SerializeField]
		private CheckBox3DUIView _useQuickToggleCheckbox;

		private float _minSecondsPerRotationLoop;

		private float _minSecondsPerPanLoop;

		private float _minSecondsPerZoomLoop;

		private Tween _cameraAnimTween;

		private FixedDeltaTimeTweenUpdater _fixedUpdater;

		private List<(string label, Func<Tween> factory)> _cameraAnimFactories;

		public static List<string> cameraAnimLabels;

		[Header("Decor Animation")]
		private bool _loopDecorAnimTimelapse;

		[SerializeField]
		private CheckBox3DUIView _timelapseLoopCheckbox;

		[SerializeField]
		private Button3DUIView _timelapsePlayButton;

		[SerializeField]
		private TMP_DropdownI18n _timelapseAnimationMode;

		[SerializeField]
		private GameObject _timelapseModeIndividualOptions;

		[SerializeField]
		private GameObject _timelapseModeGroupedOptions;

		[SerializeField]
		private TMP_DropdownI18n _timelapseTargetMode;

		[SerializeField]
		private TMP_DropdownI18n _timelapseDecorEasing;

		[SerializeField]
		private TMP_DropdownI18n _timelapsePropDelayEasing;

		[SerializeField]
		private TMP_InputField _timelapseIndividualTotalDurationInput;

		[SerializeField]
		private TMP_InputField _timelapsePropStartDelayInput;

		[SerializeField]
		private TMP_InputField _timelapseMaxIntervalPerDecorInput;

		[SerializeField]
		private TMP_InputField _timelapseMaxDurationPerPropInput;

		private Sequence _currentDecorTimelapseSequence;

		public static readonly Ease[] CameraAnimEaseOptions;

		public static readonly Ease[] TimelapseEaseOptions;

		[SerializeField]
		private TMP_InputField _timescaleOverrideInput;

		[Header("Rendering")]
		[SerializeField]
		private Button3DUIView _takeScreenshotButton;

		[SerializeField]
		private CheckBox3DUIView _showUICheckbox;

		[SerializeField]
		private GameObject _gameUIWarning;

		[SerializeField]
		private CheckBox3DUIView _showWatermarkCheckbox;

		[SerializeField]
		private GameObject _tkWatermarkObj;

		[SerializeField]
		private TMP_DropdownI18n _resolutionDropdown;

		[SerializeField]
		private TMP_DropdownI18n _fileTypeDropdown;

		private byte[] _imageData;

		private string _screenshotFileType;

		[Header("Output")]
		[SerializeField]
		private TMP_InputField _folderInput;

		[SerializeField]
		private Button3DUIView _openFolderButton;

		[SerializeField]
		private TextMeshProI18n _feedbackText;

		[Header("Tabs")]
		[SerializeField]
		private List<Button3DUIView> _tabButtons;

		[SerializeField]
		private List<GameObject> _tabPages;

		[SerializeField]
		private Canvas _overlayCanvas;

		[SerializeField]
		private Button3DUIView _disableAllButton;

		[Header("AVPRO")]
		[SerializeField]
		private TMP_InputField _avproOutputPathInput;

		[SerializeField]
		private TMP_DropdownI18n _avproRecordingToggleKeyDropdown;

		[SerializeField]
		private CheckBox3DUIView _animateDirectorsToolbarOnFixedFrameRate;

		[SerializeField]
		private Button3DUIView _avproToggleRecordButton;

		[SerializeField]
		private Button3DUIView _avproOpenOutputFolderButton;

		[SerializeField]
		private GameObject _avproPrefab;

		protected CaptureBase _avproCapture;

		public bool IsCameraAnimActive => false;

		public bool IsUIMasked => false;

		public static event EventHandler ToolbarToggled
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		public void Init()
		{
		}

		public void UpdateCameraPresetsInput()
		{
		}

		public void UpdateInput()
		{
		}

		private void LoadCameraPreset(int presetIndex)
		{
		}

		private void SaveCameraPreset(int presetIndex)
		{
		}

		public static void ApplyCameraPreset(CameraPresetData data, CameraRigBase camRig = null)
		{
		}

		public void ApplyEffectsPreset(CameraEffectsData data)
		{
		}

		public static CameraPresetData GetCameraPreset(CameraPresetData data = null)
		{
			return null;
		}

		public CameraEffectsData GetCameraEffectsData(CameraEffectsData data)
		{
			return null;
		}

		private void SetGameUIWarningVisibility(bool visible)
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void UpdateControls()
		{
		}

		private void InitToolbar()
		{
		}

		private void InitPostFXSettings()
		{
		}

		private void InitCameraAnimSettings()
		{
		}

		private void PlayCameraAnim()
		{
		}

		public void PlayCameraAnim(Ease easing, float speed, Tween animTween, bool loop)
		{
		}

		private void StopCameraAnim()
		{
		}

		public Tween GetCameraAnim(string name)
		{
			return null;
		}

		private void RegisterCameraAnims()
		{
		}

		private Tween GetChosenCameraAnim()
		{
			return null;
		}

		private void UpdateLocalizedVisuals()
		{
		}

		private void InitTimelapseSettings()
		{
		}

		private void PlayTimelapse()
		{
		}

		private void PlayTimelapseOnSelected()
		{
		}

		private void PlayTimelapseOnObjects(GameObjectX[] objs)
		{
		}

		private void PlayTimelapseOnAll()
		{
		}

		private void InitConfigPage()
		{
		}

		[IteratorStateMachine(typeof(_003CTakeScreenshot_003Ed__103))]
		private IEnumerator TakeScreenshot()
		{
			return null;
		}

		private void OpenInFileBrowser(string filepath)
		{
		}

		private IEnumerator CreateScreenshot()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CCreateScreenshot_003Ed__107))]
		private IEnumerator CreateScreenshot(int width, int height)
		{
			return null;
		}

		public void SetUIVisibility(bool isVisible)
		{
		}

		private void InitRenderingSettings()
		{
		}

		private void InitOutputSettings()
		{
		}

		private string GetScreenshotFolder()
		{
			return null;
		}

		private void ApplyTabButtonListeners()
		{
		}

		private void OpenTab(int index)
		{
		}

		private void UpdateOverlayCamera()
		{
		}

		private void DisableAll()
		{
		}

		private void ResetCamera()
		{
		}

		private void Update()
		{
		}

		public bool IsMouseOnDirectorsToolbar()
		{
			return false;
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public Tween TweenCameraToPreset(CameraPresetData presetData, CameraRigBase camRig, Action onFinished, Ease easing, float duration)
		{
			return null;
		}

		private void InitAVPROPage()
		{
		}

		private void OnInputModeChanged(object sender, EventArgs<InputMode> e)
		{
		}

		private void RefreshAVPROCameras()
		{
		}

		private void OnAvproToggleRecordClicked()
		{
		}

		private void OnAvproOpenOutputFolderClicked()
		{
		}

		private void OnAvproOutputResolutionChanged(KeyCode keyCode)
		{
		}

		private void OnAvproOutputPathChanged(string newPath)
		{
		}

		private void UpdateAVPROPage()
		{
		}
	}
}
