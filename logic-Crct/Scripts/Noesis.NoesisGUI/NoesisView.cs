using System;
using System.Runtime.InteropServices;
using Noesis;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Profiling;
using UnityEngine.Rendering;

[DisallowMultipleComponent]
[HelpURL("https://www.noesisengine.com/docs")]
[AddComponentMenu("NoesisGUI/Noesis View")]
public class NoesisView : MonoBehaviour, ISerializationCallbackReceiver
{
	private static class Profiling
	{
		public static readonly CustomSampler UpdateSampler;

		public static readonly CustomSampler RenderOnScreenSampler;

		public static readonly string RegisterView;

		public static readonly string UnregisterView;

		public static readonly string UpdateRenderTree;

		public static readonly string RenderOffScreen;

		public static readonly string RenderOnScreen;

		public static readonly string RenderTexture;
	}

	[Flags]
	private enum GamepadButtons
	{
		Up = 1,
		Down = 2,
		Left = 4,
		Right = 8,
		Accept = 0x10,
		Cancel = 0x20,
		Menu = 0x40,
		View = 0x80,
		PageUp = 0x100,
		PageDown = 0x200,
		PageLeft = 0x400,
		PageRight = 0x800
	}

	private struct ButtonState
	{
		public GamepadButtons button;

		public Noesis.Key key;

		public float t;
	}

	private CommandBuffer _commands;

	private Camera _camera;

	private PointerEventData _pointerData;

	private Vector3 _mousePos;

	private int _activeDisplay;

	private ButtonState[] _buttonStates;

	private GamepadButtons _gamepadButtons;

	private int _viewSizeX;

	private int _viewSizeY;

	private float _viewScale;

	public float UIScale;

	public bool DPIAuto;

	private bool _visible;

	private bool _updatePending;

	private EventModifiers _modifiers;

	private View _uiView;

	private bool _needsRendering;

	[SerializeField]
	private NoesisXaml _xaml;

	[SerializeField]
	private RenderTexture _texture;

	[SerializeField]
	private bool _isPPAAEnabled;

	[SerializeField]
	private float _tessellationMaxPixelError;

	[SerializeField]
	private RenderFlags _renderFlags;

	[SerializeField]
	private bool _dpiScale;

	[SerializeField]
	private bool _continuousRendering;

	[SerializeField]
	private bool _enableExternalUpdate;

	[SerializeField]
	private bool _enableKeyboard;

	[SerializeField]
	private bool _enableMouse;

	[SerializeField]
	private bool _enableTouch;

	[SerializeField]
	private bool _enableGamepad;

	[SerializeField]
	private bool _emulateTouch;

	[SerializeField]
	private bool _useRealTimeClock;

	[SerializeField]
	private InputActionAsset _actions;

	[SerializeField]
	private float _gamepadRepeatDelay;

	[SerializeField]
	private float _gamepadRepeatRate;

	private InputAction _upAction;

	private InputAction _downAction;

	private InputAction _leftAction;

	private InputAction _rightAction;

	private InputAction _acceptAction;

	private InputAction _cancelAction;

	private InputAction _menuAction;

	private InputAction _viewAction;

	private InputAction _pageLeftAction;

	private InputAction _pageRightAction;

	private InputAction _pageUpAction;

	private InputAction _pageDownAction;

	private InputAction _vScrollAction;

	private InputAction _hScrollAction;

	public NoesisXaml Xaml
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public RenderTexture Texture
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float TessellationMaxPixelError
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public RenderFlags RenderFlags
	{
		get
		{
			return default(RenderFlags);
		}
		set
		{
		}
	}

	public bool DPIScale
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool ContinuousRendering
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool EnableExternalUpdate
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool NeedsRendering
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool EnableKeyboard
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool EnableMouse
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool EnableTouch
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool EnableGamepad
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public InputActionAsset GamepadActions
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float GamepadRepeatDelay
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float GamepadRepeatRate
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool EmulateTouch
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool UseRealTimeClock
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public FrameworkElement Content => null;

	public event RenderingEventHandler Rendering
	{
		add
		{
		}
		remove
		{
		}
	}

	public bool IsRenderToTexture()
	{
		return false;
	}

	public ViewStats GetStats()
	{
		return default(ViewStats);
	}

	public bool KeyDown(Noesis.Key key)
	{
		return false;
	}

	public bool KeyUp(Noesis.Key key)
	{
		return false;
	}

	public bool Char(uint ch)
	{
		return false;
	}

	public bool MouseMove(int x, int y)
	{
		return false;
	}

	public bool MouseButtonDown(int x, int y, MouseButton button)
	{
		return false;
	}

	public bool MouseButtonUp(int x, int y, MouseButton button)
	{
		return false;
	}

	public bool MouseDoubleClick(int x, int y, MouseButton button)
	{
		return false;
	}

	public bool MouseWheel(int x, int y, int wheelRotation)
	{
		return false;
	}

	public bool TouchMove(int x, int y, uint touchId)
	{
		return false;
	}

	public bool TouchDown(int x, int y, uint touchId)
	{
		return false;
	}

	public bool TouchUp(int x, int y, uint touchId)
	{
		return false;
	}

	public void LoadXaml(bool force)
	{
	}

	private void Reset()
	{
	}

	private void Start()
	{
	}

	private void EnableActions()
	{
	}

	private void DisableActions()
	{
	}

	private void EnsureCommandBuffer()
	{
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private Vector2 ProjectPointer(float x, float y)
	{
		return default(Vector2);
	}

	private Vector3 MousePosition(Vector3 mousePosition)
	{
		return default(Vector3);
	}

	private void UpdateMouse()
	{
	}

	private void UpdateTouch()
	{
	}

	private void UpdateGamepad(float t)
	{
	}

	private void UpdateInputs(float t)
	{
	}

	private void UpdateSize()
	{
	}

	private void LateUpdate()
	{
	}

	public void ExternalUpdate()
	{
	}

	private void ExternalUpdateInternal()
	{
	}

	private void OnBecameInvisible()
	{
	}

	private void OnBecameVisible()
	{
	}

	private void PreRender(Camera cam)
	{
	}

	private void ForceRestoreCameraRenderTarget()
	{
	}

	private void RenderOffscreen()
	{
	}

	private static bool IsGL()
	{
		return false;
	}

	private bool FlipRender()
	{
		return false;
	}

	private void RenderOnscreen()
	{
	}

	private void OnPostRender()
	{
	}

	private void ProcessModifierKey(EventModifiers modifiers, EventModifiers delta, EventModifiers flag, Noesis.Key key)
	{
	}

	private bool HitTest(float x, float y)
	{
		return false;
	}

	private void ProcessEvent(Event ev, bool enableKeyboard, bool enableMouse)
	{
	}

	private void OnGUI()
	{
	}

	private void OnApplicationFocus(bool focused)
	{
	}

	private void CreateView(FrameworkElement content)
	{
	}

	private void DestroyView()
	{
	}

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
	}

	[PreserveSig]
	private static extern void Noesis_UnityUpdate();
}
