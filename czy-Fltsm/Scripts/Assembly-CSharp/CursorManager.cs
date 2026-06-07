using System;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : SceneBehaviour
{
	public delegate void CursorEvent(CursorProperties cursorProperties, bool cancelled);

	[SerializeField]
	private CursorContext[] _contextsPrefabs;

	[SerializeField]
	private float _raycastDistance = 500f;

	private CursorState _cursorState;

	private bool _cursorStateLocked;

	private Selector _selector;

	private bool _hasCursorProperties;

	private CursorEvent OnCursorDeactivation;

	private CursorContext[] _contexts;

	private SelectionLinkCursorContext _selectionLinkContext;

	private bool _wasActiveThisFrame;

	public CursorSettings Settings { get; private set; }

	public CursorProperties Properties { get; private set; }

	public Vector3 Position { get; private set; }

	public Ray Ray { get; private set; }

	public float RaycastDistance => _raycastDistance;

	public static Vector3 BuildingPosition { get; private set; } = Vector3.zero;

	public CursorContext Context { get; private set; }

	public SelectionLink SelectionLink { get; private set; }

	public void Initialize()
	{
		Settings = GameManager.Settings.CursorSettings;
		_contexts = new CursorContext[_contextsPrefabs.Length];
		for (int i = 0; i < _contexts.Length; i++)
		{
			CursorContext cursorContext = UnityEngine.Object.Instantiate(_contextsPrefabs[i]);
			if (cursorContext is SelectionLinkCursorContext selectionLinkContext)
			{
				_selectionLinkContext = selectionLinkContext;
			}
			_contexts[i] = cursorContext;
		}
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
	}

	private void Start()
	{
		_selector = Selector.CreateInstance();
		OnActiveInputUpdated();
	}

	private void Update()
	{
		Position = FlotsamInputManager.MousePosition;
		Ray = CameraController.MainCamera.ScreenPointToRay(FlotsamInputManager.MousePosition);
		if (Physics.Raycast(Ray, out var hitInfo, RaycastDistance, Settings.BuildingPositionMask))
		{
			BuildingPosition = hitInfo.point.Vector3TopDown();
		}
		if (Physics.Raycast(Ray, out var hitInfo2, RaycastDistance, Settings.SelectionMask))
		{
			SelectionLink = hitInfo2.collider.GetComponentInChildren<SelectionLink>();
		}
		else
		{
			SelectionLink = null;
		}
		UpdateCursorContext();
		if ((bool)Context && Context.Interactable)
		{
			Context.EnableRadialMenu();
		}
		if (FlotsamInputManager.HasActiveInput(InputFlags.MouseAndKeyboard))
		{
			_selector.Update(Position, _selectionLinkContext.SelectionLink);
		}
		UpdateCursorProperties();
	}

	private void OnDrawGizmos()
	{
		if (_hasCursorProperties)
		{
			Properties.DrawGizmos();
		}
	}

	private void OnDestroy()
	{
		Selector.DestroyInstance();
	}

	public void Activate(CursorProperties properties, CursorEvent deactivatedEvent = null, bool checkProperties = false)
	{
		if (checkProperties && properties == Properties)
		{
			OnCursorDeactivation?.Invoke(Properties, cancelled: false);
			OnCursorDeactivation = null;
			if (deactivatedEvent != null)
			{
				OnCursorDeactivation = (CursorEvent)Delegate.Combine(OnCursorDeactivation, deactivatedEvent);
			}
			return;
		}
		if (_hasCursorProperties)
		{
			Deactivate(cancelled: true);
		}
		Properties = properties;
		Properties.InitializeCursorState();
		Properties.ActivateRewiredActions();
		Properties.Activate();
		SetCursorState(properties._defaultCursor);
		_cursorStateLocked = true;
		_hasCursorProperties = true;
		_wasActiveThisFrame = true;
		if (deactivatedEvent != null)
		{
			OnCursorDeactivation = (CursorEvent)Delegate.Combine(OnCursorDeactivation, deactivatedEvent);
		}
	}

	private void UpdateCursorContext()
	{
		bool flag = UIManager.HasFlagsSet(PanelContainerFlags.BlockCursorContext);
		Crosshair.SetBlocked(flag);
		if (_hasCursorProperties || EventSystem.current.IsPointerOverGameObject() || flag)
		{
			SetCursorContext(null);
			return;
		}
		CursorContext[] contexts = _contexts;
		foreach (CursorContext cursorContext in contexts)
		{
			if (cursorContext.TryActivate(this))
			{
				SetCursorContext(cursorContext);
				return;
			}
		}
		SetCursorContext(null);
	}

	private void SetCursorContext(CursorContext cursorContext)
	{
		if (!(Context == cursorContext))
		{
			if ((bool)Context)
			{
				Context.Deactivate();
			}
			Context = cursorContext;
			Crosshair.SetContext(cursorContext);
			if (Context == null)
			{
				SetCursorState(CursorState.Normal);
			}
		}
	}

	public void UpdateBuildPosition(Ray ray, float maxDistance)
	{
		if (Physics.Raycast(ray, out var hitInfo, maxDistance, Settings.BuildingPositionMask))
		{
			BuildingPosition = hitInfo.point.Vector3TopDown();
		}
	}

	private void UpdateCursorProperties()
	{
		if (_hasCursorProperties)
		{
			_wasActiveThisFrame = true;
			if (!Properties.TryToDeactivate(this))
			{
				Properties.UpdateCursor(this);
				if (!(Properties == null))
				{
					SetCursorState(Properties.Cursor, ignoreLock: true);
				}
			}
		}
		else
		{
			_wasActiveThisFrame = false;
		}
	}

	public void Deactivate(bool cancelled = false)
	{
		if (_hasCursorProperties)
		{
			_hasCursorProperties = false;
			Properties.DeactivateImmediately();
			OnCursorDeactivation?.Invoke(Properties, cancelled);
			OnCursorDeactivation = null;
			Properties = null;
			_cursorStateLocked = false;
			SetCursorState(CursorState.Normal);
		}
	}

	private void SetCursorState(CursorState cursorState, bool ignoreLock = false)
	{
		if (_cursorState != cursorState && (!_cursorStateLocked || ignoreLock))
		{
			_cursorState = cursorState;
			SetCursorVisual(cursorState);
		}
	}

	private void SetCursorVisual(CursorState cursorState)
	{
		Texture2D texture2D = Settings.ReturnCursorTexture(cursorState);
		if (texture2D == null)
		{
			Debug.LogWarningFormat("No texture found for cursor state '{0}'!", cursorState);
		}
		Cursor.SetCursor(texture2D, Settings.CursorHotSpot, CursorMode.Auto);
		JoystickCursor.SetCursor(texture2D);
		Crosshair.SetCursorState(cursorState);
	}

	private void OnActiveInputUpdated(GameEvent gameEvent = null)
	{
		if (FlotsamInputManager.ActiveInput == InputFlags.Joystick)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			Crosshair.Enable();
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Crosshair.Disable();
		}
	}

	public bool TryDisplayExitPanel()
	{
		if ((bool)Properties && !Properties.CanBeDeactivated)
		{
			return Properties.DisplayExitPanel();
		}
		return false;
	}

	public static void RaycastBuildPosition(Ray ray, float maxDistance = float.MaxValue)
	{
		if (TryReturnInstance(out var instance))
		{
			instance.UpdateBuildPosition(ray, maxDistance);
		}
	}

	public static void SetCursorState(CursorState cursorState)
	{
		if (TryReturnInstance(out var instance))
		{
			instance.SetCursorState(cursorState, false);
		}
	}

	public static void LockCursorState()
	{
		if (TryReturnInstance(out var instance))
		{
			instance._cursorStateLocked = true;
		}
	}

	public static void UnlockCursorState()
	{
		if (TryReturnInstance(out var instance))
		{
			instance._cursorStateLocked = false;
		}
	}

	public static bool WasActiveThisFrame()
	{
		if (TryReturnInstance(out var instance))
		{
			return instance._wasActiveThisFrame;
		}
		return false;
	}

	private static bool TryReturnInstance(out CursorManager instance)
	{
		instance = GameManager.CursorManager;
		return instance != null;
	}
}
