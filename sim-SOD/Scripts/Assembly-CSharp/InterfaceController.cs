using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
	public enum GameMessageType
	{
		notification = 0,
		gameHeader = 1,
		keyMerge = 2,
		helpPointer = 3,
		socialCredit = 4
	}

	public class GameMessage
	{
		public GameMessageType messageType;

		public int numerical;

		public string message;

		public Sprite graphic;

		public AudioEvent additionalSFX;

		public bool colourOverride;

		public Color col;

		public int mergeType;

		public float delay;

		public RectTransform moveOnDestroy;

		public GameMessageController.PingOnComplete ping;

		public bool keyMerge;

		public bool socCredit;

		public Evidence keyMergeEvidence;

		public List<Evidence.DataKey> mergedKeys;
	}

	public enum AwarenessType
	{
		actor = 0,
		transform = 1,
		position = 2
	}

	public enum AwarenessBehaviour
	{
		alwaysVisible = 0,
		invisibleInfront = 1
	}

	[Serializable]
	public class AwarenessIcon
	{
		public AwarenessType awarenessType;

		public AwarenessBehaviour awarenessBehaviour;

		public Actor actor;

		public Transform targetTransform;

		public Vector3 targetPosition;

		public GameObject spawned;

		public Transform imageTransform;

		public Material imageMaterial;

		public Transform arrowTransform;

		public Material arrowMaterial;

		public Texture overrideTexture;

		public float fadeIn;

		public float springAction;

		public float removalProgress;

		public bool removalFlag;

		public float alpha;

		public float displayAlpha;

		public float maxDistance;

		public bool setup;

		public int priority;

		public bool triggerAlert;

		public float alertProgress;

		public void Remove(bool instant = false)
		{
		}

		public void SetAlpha(float val)
		{
		}

		public void SetTexture(Texture tex)
		{
		}

		public float GetActualAlpha()
		{
			return 0f;
		}

		public void TriggerAlert()
		{
		}
	}

	public enum ScreenDisplayType
	{
		missionComplete = 0,
		missionFailed = 1,
		newMurderCase = 2,
		socialCreditLevelUp = 3,
		unsolved = 4,
		displayResolve = 5,
		apartmentPurchase = 6,
		gameOver = 7,
		coverUpSuccess = 8,
		coverUpFailed = 9
	}

	public delegate void InputCode(List<int> code);

	public delegate void NewActiveCodeInput(KeypadController keypad);

	[CompilerGenerated]
	private sealed class _003CWindowScaleAnimation_003Ed__188 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InfoWindow window;

		public Vector2 toPosition;

		public Vector2 toPivot;

		public Vector3 toScale;

		public bool removeAtEnd;

		private RectTransform _003CitemCanvas_003E5__2;

		private GraphicRaycaster _003Cgr_003E5__3;

		private Vector2 _003CmovementDirection_003E5__4;

		private Vector3 _003CstartScale_003E5__5;

		private float _003Cprogress_003E5__6;

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
		public _003CWindowScaleAnimation_003Ed__188(int _003C_003E1__state)
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
	private sealed class _003CDisplayLocText_003Ed__191 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool forceUpdate;

		public InterfaceController _003C_003E4__this;

		public float duration;

		private float _003CtimeDisplayed_003E5__2;

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
		public _003CDisplayLocText_003Ed__191(int _003C_003E1__state)
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
	private sealed class _003CLocationTextFade_003Ed__194 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool show;

		public InterfaceController _003C_003E4__this;

		public float fadeSpeed;

		private float _003CsnapProgress_003E5__2;

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
		public _003CLocationTextFade_003Ed__194(int _003C_003E1__state)
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
	private sealed class _003CGameMessages_003Ed__209 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InterfaceController _003C_003E4__this;

		private bool _003CwaitedAFrame_003E5__2;

		private AudioController.LoopingSoundInfo _003CtypewriterSoundTriggered_003E5__3;

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
		public _003CGameMessages_003Ed__209(int _003C_003E1__state)
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
	private sealed class _003CFadeGame_003Ed__219 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InterfaceController _003C_003E4__this;

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
		public _003CFadeGame_003Ed__219(int _003C_003E1__state)
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
	private sealed class _003CDesktopModeTransition_003Ed__220 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InterfaceController _003C_003E4__this;

		private RectTransform _003CcanvasRect_003E5__2;

		private RectTransform _003CwindowRect_003E5__3;

		private bool _003CsetControlDisplay_003E5__4;

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
		public _003CDesktopModeTransition_003Ed__220(int _003C_003E1__state)
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
	private sealed class _003CExecutePing_003Ed__234 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RectTransform pingRect;

		public JuiceController pingJuice;

		public TextMeshProUGUI textPing;

		public int originalValue;

		public bool isMoney;

		public List<CanvasRenderer> renderers;

		public InterfaceController _003C_003E4__this;

		private float _003Cprogress_003E5__2;

		private string _003CmoneyStr_003E5__3;

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
		public _003CExecutePing_003Ed__234(int _003C_003E1__state)
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
	private sealed class _003CDisplayMissionEndText_003Ed__254 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ScreenDisplayType newType;

		public InterfaceController _003C_003E4__this;

		public Case forCase;

		private CanvasRenderer _003Crend_003E5__2;

		private float _003ClastsFor_003E5__3;

		private float _003Ctimer_003E5__4;

		private bool _003CfirstFrame_003E5__5;

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
		public _003CDisplayMissionEndText_003Ed__254(int _003C_003E1__state)
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

	[Header("Canvases")]
	public Canvas caseCanvas;

	public CanvasGroup caseCanvasGroup;

	public GraphicRaycaster caseCanvasRaycaster;

	public Canvas minimapCanvas;

	public CanvasGroup minimapCanvasGroup;

	public Canvas controlsCanvas;

	public CanvasGroup controlsCanvasGroup;

	public Canvas controlPanelCanvas;

	public CanvasGroup controlPanelCanvasGroup;

	public Canvas gameWorldCanvas;

	public CanvasGroup gameWorldCanvasGroup;

	public Canvas windowCanvas;

	public GraphicRaycaster windowRaycaster;

	public CanvasGroup windowCanvasGroup;

	public Canvas statusCanvas;

	public CanvasGroup statusCanvasGroup;

	public Canvas upgradesCanvas;

	public CanvasGroup upgradesCanvasGroup;

	public Canvas dialogCanvas;

	public CanvasGroup dialogCanvasGroup;

	public Canvas interactionProgressCanvas;

	public CanvasGroup interactionProgressCanvasGroup;

	public RectTransform fingerprintDisplayCanvas;

	[Header("UI Scaling Transforms")]
	[ReorderableList]
	public List<RectTransform> uiScaling;

	[Header("References")]
	public ButtonController notebookButton;

	public ButtonController upgradesButton;

	public ButtonController mapButton;

	public ButtonController personButton;

	public RectTransform firstPersonUI;

	public RectTransform caseReferenceAnchor;

	public GameObject backgroundBlur;

	public RectTransform speechDisplayAnchor;

	public RectTransform objectiveSideAnchor;

	public RectTransform objectiveTextBackground;

	public TextMeshProUGUI objectiveTitleText;

	public CanvasRenderer objectiveTitleTextRenderer;

	public CanvasRenderer objectiveBackgroundRenderer;

	public RectTransform uiPointerContainer;

	public Image takeDamageIndicatorImg;

	public JuiceController takeDamageIndicatorJuice;

	public Image lowHealthIndicatorImg;

	public RectTransform movieBarTop;

	public RectTransform movieBarBottom;

	public JuiceController movieBarJuice;

	public TextMeshProUGUI timeText;

	public RectTransform speechAnchor;

	public RectTransform objectCycleAnchor;

	public TextMeshProUGUI timerText;

	public ControllerViewRectScroll caseScrollingViewRect;

	public ControllerViewRectScroll mapScrollingViewRect;

	[Space(7f)]
	public SoundIndicatorController footstepAudioIndicator;

	[Header("States")]
	public bool desktopMode;

	public float desktopModeTransition;

	public float desktopModeDesiredTransition;

	public bool showDesktopMap;

	public bool showDesktopCaseBoard;

	public ButtonController selectedElement;

	public string selectedElementTag;

	public List<MonoBehaviour> currentMouseOverElement;

	private InfoWindow detectiveNotebook;

	public bool crosshairVisible;

	public bool playerTextInputActive;

	public List<SpeechBubbleController> activeSpeechBubbles;

	public bool interfaceIsActive;

	public static int assignStickyNoteID;

	[Header("Location Text")]
	public TextMeshProUGUI locationText;

	private Coroutine displayedTextCoroutine;

	public bool locationTextDisplayed;

	[Header("In-Game Title Text")]
	public TextMeshProUGUI titleText;

	public CanvasRenderer titleTextRenderer;

	[Header("Game Message System")]
	public RectTransform gameMessageParent;

	public bool messageCoroutineRunning;

	public List<GameMessage> notificationQueue;

	public List<GameMessage> gameHeaderQueue;

	public List<GameMessage> helpPointerQueue;

	public GameObject currentNotification;

	public GameMessage currentGameHeader;

	private float gameHeaderDelay;

	public float gameHeaderTimer;

	private float typewriterDelay;

	private float gameHeaderFadeDelay;

	public bool gameHeaderDisplayed;

	public bool gameSceenDisplayed;

	public bool gameScreenQueued;

	public bool levelUpScreenActive;

	public ScreenDisplayType currentGameScreen;

	[Space(7f)]
	public RectTransform notebookNotificationIcon;

	public JuiceController notebookNotificationJuice;

	public RectTransform syncDiskNotificationIcon;

	public JuiceController syncDiskNotificationJuice;

	public RectTransform lockpicksNotificationIcon;

	public TextMeshProUGUI lockpicksNotificationText;

	public JuiceController lockpicksNotificationJuice;

	public List<CanvasRenderer> lockpicksNotificationRenderers;

	public bool lockpickNotificationActive;

	public int lastLockpicks;

	public RectTransform moneyNotificationIcon;

	public TextMeshProUGUI moneyNotificationText;

	public JuiceController moneyNotificationJuice;

	public List<CanvasRenderer> moneyNotificationRenderers;

	public bool moneyNotificationActive;

	public int lastMoney;

	public RectTransform bioNotificationIcon;

	[Space(7f)]
	private GameMessage currentHelpPointer;

	public RectTransform helpPointerRect;

	public List<CanvasRenderer> helpPointerRenderers;

	public TextMeshProUGUI helpPointerText;

	private string helpPointerTextDisplay;

	private float helpPointerProgress;

	private float helpPointerFadeOut;

	private float helpPointerTimer;

	private float helpPointerDesiredHeight;

	[NonSerialized]
	[Header("Objective System")]
	public Objective currentlyDisplaying;

	public List<Objective> displayedObjectives;

	public List<ChecklistButtonController> objectiveList;

	[Header("Radial Selection")]
	public AnimationCurve radialActivateScale;

	[Header("Dragging")]
	public GameObject dragged;

	public string draggedTag;

	public Vector2 dragCursorOffset;

	public PinnedItemController pinnedBeingDragged;

	public float windowFadeProgress;

	public bool windowFullFade;

	[Header("Display Objectives")]
	public float objectivesDisplayTimer;

	public float objectivesAlpha;

	[Header("Box Select")]
	public bool boxSelectActive;

	public RectTransform boxSelect;

	public List<PinnedItemController> selectedPinned;

	[Header("Active Windows")]
	public Dictionary<string, WindowStylePreset> windowDictionary;

	public List<InfoWindow> activeWindows;

	public string openHelpToPage;

	public RectTransform windowFocus;

	public KeypadController activeCodeInput;

	[Header("Game Fading")]
	public CanvasRenderer fadeOverlay;

	public AnimationCurve fadeOverlayAlphaCurve;

	public float desiredFade;

	private float fadeTime;

	private bool fadeAudio;

	public float fade;

	[Header("Pause Rendering")]
	private CameraClearFlags savedCameraClear;

	[Header("Awareness Compass")]
	public GameObject compassContainer;

	public Transform backgroundTransform;

	public MeshRenderer compassMeshRend;

	public Material compassMaterial;

	public float compassDesiredAlpha;

	public float compassActualAlpha;

	public List<AwarenessIcon> awarenessIcons;

	public List<SpeechBubbleController> anchoredSpeech;

	[Header("First Person Item")]
	public GameObject firstPersonModel;

	public Animator firstPersonAnimator;

	[Header("Depth of Field")]
	public float desiredDofNearStart;

	public float desiredDofNearEnd;

	public float desiredDofFarStart;

	public float desiredDofFarEnd;

	public float dofProgress;

	[Header("Popup Messages")]
	public PopupMessageController popupController;

	[Header("Debug")]
	public int debugLevel;

	private static InterfaceController _instance;

	public static InterfaceController Instance => null;

	public event InputCode OnInputCode
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

	public event NewActiveCodeInput OnNewActiveCodeInput
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

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void UpdateDOF()
	{
	}

	public void DeselectAllPins()
	{
	}

	public void UpdateAnchoredSpeechPositions()
	{
	}

	public AwarenessIcon AddAwarenessIcon(AwarenessType newType, AwarenessBehaviour newBehaviour, Actor newActor, Transform newTransform, Vector3 newPosition, Material newMat, int newPriority, bool forceMaxDistance = false, float maxDist = 20f)
	{
		return null;
	}

	public UIPointerController AddUIPointer(Objective newObjective)
	{
		return null;
	}

	public InfoWindow SpawnWindow(Evidence passedEvidence, Evidence.DataKey passedEvidenceKey = Evidence.DataKey.name, List<Evidence.DataKey> passedEvidenceKeys = null, string presetName = "", bool worldInteraction = false, bool autoPosition = true, Vector2 forcePosition = default(Vector2), Interactable passedInteractable = null, Case passedCase = null, Case.CaseElement forcedPinnedElement = null, bool passDialogSuccess = true)
	{
		return null;
	}

	public void SetDragged(GameObject drag, string tag, Vector2 dCursorOffset)
	{
	}

	public InfoWindow GetWindow(Evidence winEntry)
	{
		return null;
	}

	public InfoWindow GetWindow(Evidence winEntry, List<Evidence.DataKey> evKeys)
	{
		return null;
	}

	public void MinimizeWindow(InfoWindow window)
	{
	}

	public void RestoreWindow(InfoWindow window)
	{
	}

	[IteratorStateMachine(typeof(_003CWindowScaleAnimation_003Ed__188))]
	private IEnumerator WindowScaleAnimation(InfoWindow window, Vector2 toPosition, Vector2 toPivot, Vector3 toScale, bool removeAtEnd)
	{
		return null;
	}

	public void RemoveAllMouseInteractionComponents()
	{
	}

	public void DisplayLocationText(float duration, bool forceUpdate)
	{
	}

	[IteratorStateMachine(typeof(_003CDisplayLocText_003Ed__191))]
	private IEnumerator DisplayLocText(float duration, bool forceUpdate = false)
	{
		return null;
	}

	public void ShowLocationText(float fadeSpeed)
	{
	}

	public void HideLocationText(float fadeSpeed)
	{
	}

	[IteratorStateMachine(typeof(_003CLocationTextFade_003Ed__194))]
	private IEnumerator LocationTextFade(bool show = true, float fadeSpeed = 1f)
	{
		return null;
	}

	public void OpenCurrentLocationAsEvidence()
	{
	}

	public void OpenApartmentAsEvidence()
	{
	}

	public void SetInterfaceActive(bool val)
	{
	}

	public void SetDesktopMode(bool val, bool showPanels)
	{
	}

	public void ToggleSetShowDesktopMap()
	{
	}

	public void SetShowDesktopMap(bool val, bool playSound)
	{
	}

	public void ShowDesktopMap(bool val, bool playSound)
	{
	}

	public void ToggleShowInventory()
	{
	}

	public void ToggleSetShowDesktopCaseBoard()
	{
	}

	public void SetShowDesktopCaseBoard(bool val)
	{
	}

	public void ShowCaseBoard(bool val)
	{
	}

	public void SetBackgroundBlur(bool val)
	{
	}

	public void NewHelpPointer(string helpSection)
	{
	}

	public void NewGameMessage(GameMessageType newType, int newNumerical, string newMessage, InterfaceControls.Icon newIcon = InterfaceControls.Icon.agent, AudioEvent additionalSFX = null, bool colourOverride = false, Color col = default(Color), int newMergeType = -1, float newMessageDelay = 0f, RectTransform moveToOnDestroy = null, GameMessageController.PingOnComplete ping = GameMessageController.PingOnComplete.none, Evidence keyMergeEvidence = null, List<Evidence.DataKey> keyMergeKeys = null, Sprite iconOverride = null)
	{
	}

	[IteratorStateMachine(typeof(_003CGameMessages_003Ed__209))]
	private IEnumerator GameMessages()
	{
		return null;
	}

	private void PlayTypewriterKey()
	{
	}

	private void PlayTypewriterSpace()
	{
	}

	public void ToggleNotebookButton()
	{
	}

	public void ToggleNotebook(string startingPage = "", bool openHelpSection = false)
	{
	}

	public void OpenNotebookNoPause(string startingPage = "", bool openHelpSection = false)
	{
	}

	public void ResetToggleNotebookButton()
	{
	}

	public void ToggleUpgrades()
	{
	}

	public void EvaluateActiveControllerViewRectScroll()
	{
	}

	public void Fade(float fadeVal, float newFadeTime = 2f, bool newFadeAudio = false)
	{
	}

	[IteratorStateMachine(typeof(_003CFadeGame_003Ed__219))]
	private IEnumerator FadeGame()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CDesktopModeTransition_003Ed__220))]
	private IEnumerator DesktopModeTransition()
	{
		return null;
	}

	public void InputCodeButton(List<int> code)
	{
	}

	public void AddMouseOverElement(MonoBehaviour mono)
	{
	}

	public void RemoveMouseOverElement(MonoBehaviour mono)
	{
	}

	public void ClearAllMouseOverElements()
	{
	}

	public void UpdateCursorSprite()
	{
	}

	public void SetCursorGraphic(Texture2D mouseImage, Vector2 size, CursorMode cursorMode = CursorMode.Auto)
	{
	}

	public void MinimizeAll()
	{
	}

	public void ShowWindowFocus()
	{
	}

	public void RemoveWindowFocus()
	{
	}

	public void CrosshairReaction()
	{
	}

	public Color GetEvidenceColour(InterfaceControls.EvidenceColours col)
	{
		return default(Color);
	}

	public void PingLockpicks()
	{
	}

	public void PingMoney()
	{
	}

	[IteratorStateMachine(typeof(_003CExecutePing_003Ed__234))]
	private IEnumerator ExecutePing(RectTransform pingRect, JuiceController pingJuice, TextMeshProUGUI textPing, int originalValue, List<CanvasRenderer> renderers, bool isMoney)
	{
		return null;
	}

	public void SetCrosshairVisible(bool val)
	{
	}

	public void SetPlayerTextInput(bool val)
	{
	}

	public void SetActiveCodeInput(KeypadController keypad)
	{
	}

	public void ActivateObjectivesDisplay()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void NewMurderCaseDisplay()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void MissionCompleteDisplay()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ApartmentPurchaseDisplay()
	{
	}

	public void ExecuteMissionCompleteDisplay(Case forCase)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SocialCreditLevelUpDisplay()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void MissionFailedDisplay()
	{
	}

	public void ExecuteMissionFailedDisplay(Case forCase)
	{
	}

	public void ExecuteGameOverDisplay()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UnsolvedDisplay()
	{
	}

	public void ExecuteMissionUnsolvedDisplay(Case forCase)
	{
	}

	public void ExecuteResolveDisplay(Case forCase)
	{
	}

	public void ExecuteCoverUpFailedDisplay()
	{
	}

	public void ExecuteCoverUpSuccessDisplay()
	{
	}

	public void UpdateAvailableCanvases()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DisplayCreditThresholdForLevel()
	{
	}

	[IteratorStateMachine(typeof(_003CDisplayMissionEndText_003Ed__254))]
	private IEnumerator DisplayMissionEndText(ScreenDisplayType newType, Case forCase = null)
	{
		return null;
	}

	public bool StupidUnityChangeToTheWayOnPointerExitHandles(PointerEventData eventData, Transform t)
	{
		return false;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void PromptGlyphTest()
	{
	}
}
