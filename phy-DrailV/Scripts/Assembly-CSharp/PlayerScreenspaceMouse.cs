using DV;
using DV.HUD;
using DV.Hovering;
using DV.Interaction;
using DV.Interaction.Inputs;
using DV.UI;
using DV.UI.ContextMenu;
using DV.Utils;
using UnityEngine;

public class PlayerScreenspaceMouse : MonoBehaviour
{
	public bool disallowEscapingScreenspace;

	private GrabberMouseCursor grabberCursor;

	private Grabber grabber;

	private GrabberInteractionHandlerDV grabberInteractionHandler;

	private Camera cam;

	private JunctionSwitcher switcher;

	private CustomFirstPersonController controller;

	private HUDTurntableContextMenuProvider turntableProvider;

	private TurntableControlKeyboardInput hoveredTurntable;

	private bool tempDisable;

	private bool mouseDragScreenspaceMode;

	private GameParams gameParams;

	private bool ShouldScreenspace
	{
		get
		{
			if (SingletonBehaviour<ScreenspaceMouse>.Instance.on)
			{
				return mouseDragScreenspaceMode;
			}
			return false;
		}
	}

	private bool UseScreenCoordinates => SingletonBehaviour<ScreenspaceMouse>.Instance.on;

	private void Awake()
	{
		cam = PlayerManager.PlayerCamera;
		controller = GetComponent<CustomFirstPersonController>();
		grabberCursor = GetComponentInChildren<GrabberMouseCursor>();
		grabber = GetComponentInChildren<Grabber>();
		grabberInteractionHandler = grabber.GetComponent<GrabberInteractionHandlerDV>();
		switcher = new GameObject("JunctionSwitcher of PlayerScreenspaceMouse").AddComponent<JunctionSwitcher>();
		switcher.pointerOrigin = switcher.transform;
		switcher.transform.parent = base.transform;
		gameParams = Globals.G.GameParams;
		GamePreferences.RegisterToPreferenceUpdated(Preferences.MouseDrag, MouseDragUpdated);
		MouseDragUpdated();
	}

	private void Start()
	{
		turntableProvider = SingletonBehaviour<HUDInterfacer>.Instance.GetComponent<HUDTurntableContextMenuProvider>();
	}

	private void OnEnable()
	{
		SetupListeners(on: true);
	}

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<ScreenspaceMouse>.Instance.RemoveRequest(this);
			grabberInteractionHandler.RequestEndInteraction();
			SetupListeners(on: false);
			switcher.enabled = false;
			if (hoveredTurntable != null)
			{
				hoveredTurntable = null;
				turntableProvider.TurntableChanged(null);
			}
		}
	}

	private void OnDestroy()
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.MouseDrag, MouseDragUpdated);
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged += ScreenspaceChanged;
			grabber.GrabStarted += OnGrabStarted;
			grabber.GrabStopped += OnGrabStopped;
		}
		else
		{
			SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged -= ScreenspaceChanged;
			grabber.GrabStarted -= OnGrabStarted;
			grabber.GrabStopped -= OnGrabStopped;
		}
		ScreenspaceChanged(SingletonBehaviour<ScreenspaceMouse>.Instance.on);
	}

	private void MouseDragUpdated()
	{
		mouseDragScreenspaceMode = (float)GamePreferences.Get<int>(Preferences.MouseDrag) > 0.5f;
		RefreshGrabberScreenspaceMode();
	}

	private void OnGrabStopped(AGrabHandler obj)
	{
		if (!obj.IsItem && (bool)obj)
		{
			SingletonBehaviour<CursorManager>.Instance.RemoveRequest(this);
			controller.m_MouseLook.RemoveRequest(this);
		}
	}

	private void OnGrabStarted(AGrabHandler obj)
	{
		if (!obj.IsItem && ShouldScreenspace)
		{
			SingletonBehaviour<CursorManager>.Instance.RequestCursor(this, visible: false, 1);
			controller.m_MouseLook.RequestMouseSensitivityState(this, MouseSensitivityState.Locked, 1);
		}
	}

	private void ScreenspaceChanged(bool on)
	{
		RefreshGrabberScreenspaceMode();
	}

	private void RefreshGrabberScreenspaceMode()
	{
		grabberCursor.useCursorScreenCoordinates = UseScreenCoordinates;
		grabber.screenspaceDraggingAllowed = ShouldScreenspace;
	}

	private void Update()
	{
		if (cam.enabled)
		{
			bool flag = SingletonBehaviour<ScreenspaceMouse>.Instance.on && gameParams.SwitchJunctionsViaMouse && !grabber.IsDragging();
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			switcher.transform.position = ray.origin;
			switcher.transform.forward = ray.direction;
			switcher.enabled = flag;
			if (flag && InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InteractionPrimary))
			{
				switcher.Use();
			}
			(NonVRHoverManager.HoverType, object) currentlyHovered = SingletonBehaviour<NonVRHoverManager>.Instance.CurrentlyHovered;
			TurntableControlKeyboardInput turntableControlKeyboardInput = ((currentlyHovered.Item1 == NonVRHoverManager.HoverType.Turntable) ? (currentlyHovered.Item2 as TurntableControlKeyboardInput) : null);
			if (!SingletonBehaviour<ScreenspaceMouse>.Instance.on)
			{
				turntableControlKeyboardInput = null;
			}
			if (!CursorManager.Visible)
			{
				turntableControlKeyboardInput = null;
			}
			if (turntableControlKeyboardInput != hoveredTurntable)
			{
				hoveredTurntable = turntableControlKeyboardInput;
				turntableProvider.TurntableChanged(hoveredTurntable);
			}
			bool num = InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InteractionSecondary) || InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InteractionMiddle);
			bool flag2 = InputManager.NewPlayer.GetButton(InputManager.Actions.InteractionSecondary) || InputManager.NewPlayer.GetButton(InputManager.Actions.InteractionMiddle);
			if (num && SingletonBehaviour<ScreenspaceMouse>.Instance.on && !disallowEscapingScreenspace)
			{
				tempDisable = true;
				SingletonBehaviour<CursorManager>.Instance.RequestCursor(this, visible: false, 1);
				controller.m_MouseLook.RequestMouseSensitivityState(this, MouseSensitivityState.Normal, 2);
			}
			if (tempDisable && !flag2)
			{
				tempDisable = false;
				SingletonBehaviour<CursorManager>.Instance.RemoveRequest(this);
				controller.m_MouseLook.RemoveRequest(this);
			}
		}
	}
}
