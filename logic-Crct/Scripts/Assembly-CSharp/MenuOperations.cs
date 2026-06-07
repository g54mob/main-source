using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coffee.UISoftMask;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuOperations : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRefresh_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CRefresh_003Ed__43(int _003C_003E1__state)
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
	private sealed class _003CPause_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuOperations _003C_003E4__this;

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
		public _003CPause_003Ed__70(int _003C_003E1__state)
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
	private sealed class _003CDragEnd_003Ed__85 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuOperations _003C_003E4__this;

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
		public _003CDragEnd_003Ed__85(int _003C_003E1__state)
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
	private sealed class _003C_DisplayMenu_003Ed__92 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuOperations _003C_003E4__this;

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
		public _003C_DisplayMenu_003Ed__92(int _003C_003E1__state)
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
	private sealed class _003CRequestRate_003Ed__112 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CRequestRate_003Ed__112(int _003C_003E1__state)
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

	[Header("Menu Display")]
	public CanvasGroup menuDisplayGroup;

	public RectTransform menuDisplayTransform;

	public AnimationCurve easingCurve;

	public Vector2 menuDisplayPosition;

	public float menuDisplaySpeed;

	private float menuDisplayT;

	private bool transitioning;

	private bool menuDisplayed;

	private InteractionMode _iMode;

	[Header("New Design")]
	public GameObject NewDesignDialogGameObject;

	public CameraControlMobile cameraControlMobile;

	public ToolBase currentTool;

	[Header("Tools")]
	public ToolBase[] tools;

	[Header("QuitDialog")]
	public GameObject quitDialogGameObject;

	public PinHint_Unity templatePin;

	public Transform pinHintContainer;

	public List<PinHint_Unity> pinHints;

	public int pinFontSize;

	public int anodeFontSize;

	public int labelSize;

	public Color labelColor;

	public Font labelFont;

	private GameObject[] pins;

	private GameObject[] anodes;

	private BaseComponent selectedComp;

	private readonly int compMask;

	private readonly int interactMask;

	private Ray ray;

	private RaycastHit hit;

	private InteractionEvent interactEvent;

	[Header("Scope")]
	public ScopeMobile scope;

	[Header("Control Type")]
	public ControlType controlType;

	public GameObject trackPads;

	public RectTransform viewportTool;

	public LayoutElement viewportToolLayout;

	public Vector3 viewportToolPositions;

	public Toggle[] controlToggles;

	private bool viewportHasCursor;

	private Touch orbitTouch;

	private BaseComponent prevHighlight;

	private bool wasTwo;

	private bool pause;

	private bool zoomTouchInit;

	private bool blockInteraction;

	private bool interactDrag;

	private bool orbitDrag;

	[Header("Canvas Aspect")]
	public CanvasScaler[] canvasScalers;

	public float aspectThreshold;

	[Header("Save Design")]
	public GameObject SaveAsDialog;

	public InputField SaveAsName;

	public Camera snapshotCamera;

	public RenderTexture snapshotTexture;

	public GameObject overwriteWarningGameObject;

	public Texture2D tex;

	[Header("Open Design")]
	public GameObject openDesignDialog;

	public GameObject localDesignTemplate;

	public GameObject exampleDesignTemplate;

	public Transform localContentTransform;

	public Transform exampleContentTransform;

	public GameObject deleteDialog;

	public GameObject nothingSaved;

	public SoftMask[] softMasks;

	[Header("Local/Examples")]
	public Text[] leTexts;

	public Image[] leButtons;

	public bool local;

	public GameObject[] leScrollviews;

	public Color leTextColorOn;

	public Color leTextColorOff;

	public TextAsset[] exampleFiles;

	public OpenDesignTemplate[] exampleDesignTemplates;

	private string[] designList;

	private int pendingOpenId;

	private bool pendingLocal;

	private int pendingDeleteId;

	[Header("Add Components")]
	public GameObject addComponentsGameObject;

	[Header("Unsaved Changes")]
	public GameObject unsavedGameobject;

	[Header("Settings")]
	public GameObject settingsObj;

	private static MenuOperations inst { get; set; }

	public static InteractionMode InteractionMode
	{
		get
		{
			return default(InteractionMode);
		}
		set
		{
		}
	}

	public static ToolBase CurrentTool => null;

	public static bool BlockInteraction => false;

	public static bool DraggedOrbit => false;

	public static TextAsset[] ExampleFiles => null;

	public static void IPC_SetInteractionType(string data)
	{
	}

	public static ToolBase Tool(int id)
	{
		return null;
	}

	public static void SetTool(ToolBase tool)
	{
	}

	public void DisplayQuitDialog()
	{
	}

	public void ConfirmQuit()
	{
	}

	public void CancelQuit()
	{
	}

	private void Update()
	{
	}

	private PinHint_Unity GetPinHint(int i)
	{
		return null;
	}

	public static void DisplayPinHints()
	{
	}

	public static void RefreshPinHints()
	{
	}

	[IteratorStateMachine(typeof(_003CRefresh_003Ed__43))]
	private IEnumerator Refresh()
	{
		return null;
	}

	public static void HidePinHints()
	{
	}

	public static void ResetCurrentTool()
	{
	}

	public static void CancelEdit()
	{
	}

	public void ToggleControl(int n)
	{
	}

	public void ViewportEnter()
	{
	}

	public void ViewportExit()
	{
	}

	public void ViewportClicked()
	{
	}

	public void ViewportInitDrag()
	{
	}

	public void ViewportHighlight()
	{
	}

	public void ViewportScroll(BaseEventData eventData)
	{
	}

	[IteratorStateMachine(typeof(_003CPause_003Ed__70))]
	private IEnumerator Pause()
	{
		return null;
	}

	public void ViewportDrag()
	{
	}

	public void ViewportEndDrag()
	{
	}

	public void ViewportPointerDown()
	{
	}

	public void ViewportPointerUp()
	{
	}

	[IteratorStateMachine(typeof(_003CDragEnd_003Ed__85))]
	private IEnumerator DragEnd()
	{
		return null;
	}

	public static void DeselectComponent()
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void DisplayMenu()
	{
	}

	[IteratorStateMachine(typeof(_003C_DisplayMenu_003Ed__92))]
	private IEnumerator _DisplayMenu()
	{
		return null;
	}

	public void DisplayNewDesignDialog()
	{
	}

	public void ConfirmNewDesignDialog()
	{
	}

	public static void IPC_NewDesign()
	{
	}

	public void CancelNewDesignDialog()
	{
	}

	public void CloseMenu()
	{
	}

	public void SaveClicked()
	{
	}

	public static void IPC_SaveClicked(string filePath)
	{
	}

	public static void IPC_SaveAsClicked(string filePath)
	{
	}

	public void DisplaySaveAsDialog()
	{
	}

	public void RemoveIllegalNameCharacters()
	{
	}

	public void SaveAsCheck()
	{
	}

	public static byte[] ReturnCurrentSaveCamera()
	{
		return null;
	}

	private void SaveAs()
	{
	}

	[IteratorStateMachine(typeof(_003CRequestRate_003Ed__112))]
	private IEnumerator RequestRate()
	{
		return null;
	}

	public void ConfirmOverwriteDialog()
	{
	}

	public void CloseOverwriteDialog()
	{
	}

	public void CloseSaveAsDialog()
	{
	}

	public void OpenDesignDialog()
	{
	}

	public void ToggleLocalExample()
	{
	}

	private void SetLocalExample(bool loc)
	{
	}

	private void PopulateLocalList()
	{
	}

	private void PopulateExampleList()
	{
	}

	public static void OpenDesign(int id)
	{
	}

	public static void OpenExample(int id)
	{
	}

	public void ConfirmUnsavedChanges()
	{
	}

	public void CloseUnsavedChanges()
	{
	}

	public void CloseOpenDesignDialog()
	{
	}

	public static void DisplayDeleteDialog(int id)
	{
	}

	public void CloseDeleteDialog()
	{
	}

	public void ConfirmDelete()
	{
	}

	public void DisplayAddComponents()
	{
	}

	public void CancelAddComponents()
	{
	}

	public void SettingsButton()
	{
	}

	public void CloseSettings()
	{
	}

	public void ResetPlayerPrefs()
	{
	}

	public void LateUpdate()
	{
	}
}
