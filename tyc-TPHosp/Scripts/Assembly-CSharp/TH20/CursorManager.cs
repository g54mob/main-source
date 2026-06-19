using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class CursorManager : MustCallDestroy, IGameEventsBase
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public GameObject CursorDefaultPrefab;

			public GameObject CursorRoomBuildPrefab;

			public GameObject CursorRoomLowBuildPrefab;

			public GameObject CursorRoomBuildSubtractPrefab;

			public GameObject CursorRoomLowBuildSubtractPrefab;

			public Texture2D CursorIconDefault;

			public Texture2D CursorIconAddRoom;

			public Texture2D CursorIconSubRoom;

			public Texture2D CursorIconMoveRoom;

			public Texture2D CursorIconMovingRoom;

			public Texture2D CursorIconSelectionInvalid;

			public Texture2D CursorIconCrosshair;

			public Texture2D CursorIconVaccinate;

			public Texture2D GetIcon(CursorIcon icon)
			{
				return icon switch
				{
					CursorIcon.Default => CursorIconDefault, 
					CursorIcon.AddRoom => CursorIconAddRoom, 
					CursorIcon.SubRoom => CursorIconSubRoom, 
					CursorIcon.MoveRoom => CursorIconMoveRoom, 
					CursorIcon.MovingRoom => CursorIconMovingRoom, 
					CursorIcon.SelectionInvalid => CursorIconSelectionInvalid, 
					CursorIcon.Crosshair => CursorIconCrosshair, 
					CursorIcon.Vaccinate => CursorIconVaccinate, 
					_ => throw new ArgumentOutOfRangeException("icon", icon, null), 
				};
			}
		}

		private readonly Config _config;

		private readonly InputManager _inputManager;

		private GameObject _visualisation;

		private readonly GameObject[] _visualisations;

		private Vector2 _screenPosition;

		private Vector3 _worldPosition;

		private Vector3 _worldPositionSmoothed;

		private Vector3 _worldLastPosition;

		private GridCoord _gridPosition;

		private CursorMode _mode;

		private bool _visible;

		private bool _iconVisible;

		private readonly List<CursorMode> _modeStack = new List<CursorMode>();

		private Vector3 _positionDampVelocity = Vector3.zero;

		private CursorIcon _icon;

		private float _planeOffset;

		public Action<CursorMode> OnModeBecomeActive;

		public Action<CursorMode> OnModeBecomeInactive;

		public static bool HideCursorOverride;

		public Vector3 WorldPosition => _worldPosition;

		public Vector3 WorldPositionDelta => _worldPosition - _worldLastPosition;

		public GridCoord GridPosition => _gridPosition;

		public Vector3 WorldPositionSmoothed => _worldPositionSmoothed;

		public Vector2 ScreenPosition => _screenPosition;

		public CursorManager(Config config, InputManager inputManager)
		{
			_config = config;
			_inputManager = inputManager;
			_visualisations = new GameObject[5];
			_visualisations[0] = UnityEngine.Object.Instantiate(config.CursorDefaultPrefab);
			_visualisations[1] = UnityEngine.Object.Instantiate(config.CursorRoomBuildPrefab);
			_visualisations[2] = UnityEngine.Object.Instantiate(config.CursorRoomLowBuildPrefab);
			_visualisations[3] = UnityEngine.Object.Instantiate(config.CursorRoomBuildSubtractPrefab);
			_visualisations[4] = UnityEngine.Object.Instantiate(config.CursorRoomLowBuildSubtractPrefab);
			_visible = true;
			_iconVisible = true;
			SetCursorModel(CursorModel.Default);
			GameEventsRegistry.RegisterLevelEvent(this);
		}

		public override void Destroy()
		{
			GameObject[] visualisations = _visualisations;
			for (int i = 0; i < visualisations.Length; i++)
			{
				UnityEngine.Object.Destroy(visualisations[i]);
			}
			if (_mode != null)
			{
				_mode.Destroy();
			}
			_modeStack.ClearAndCallDestroy();
			base.Destroy();
		}

		public void Update()
		{
			UpdateCursorPosition();
			if (_visualisation != null)
			{
				GameObjectUtils.SetActive(_visualisation, IsCursorVisible());
			}
			Texture2D icon = _config.GetIcon((!_inputManager.IsMouseOverGuiOrDraggingScrollbar()) ? _icon : CursorIcon.Default);
			switch (_icon)
			{
			case CursorIcon.Crosshair:
			{
				Vector2 hotspot = ((icon != null) ? new Vector2((float)icon.width * 0.5f, (float)icon.height * 0.5f) : Vector2.zero);
				Cursor.SetCursor(icon, hotspot, UnityEngine.CursorMode.Auto);
				break;
			}
			case CursorIcon.Vaccinate:
				Cursor.SetCursor(icon, Vector2.zero, UnityEngine.CursorMode.Auto);
				break;
			default:
				Cursor.SetCursor(icon, Vector2.zero, UnityEngine.CursorMode.Auto);
				break;
			}
			Cursor.visible = IsCursorIconVisible();
			if (_mode != null)
			{
				_mode.CursorUpdate(_inputManager);
			}
		}

		private bool IsCursorVisible()
		{
			if (!_inputManager.IsMouseOverGuiOrDraggingScrollbar())
			{
				return _visible;
			}
			return false;
		}

		public bool IsCursorIconVisible()
		{
			if (DebugVars.DisableCursor.Value || HideCursorOverride)
			{
				return false;
			}
			if (!_inputManager.IsMouseOverGuiOrDraggingScrollbar())
			{
				return _iconVisible;
			}
			return true;
		}

		private void UpdateCursorPosition()
		{
			Plane plane = new Plane(Vector3.up, new Vector3(0f, _planeOffset, 0f));
			Ray ray = Camera.main.ScreenPointToRay(_inputManager.GetMousePos());
			_worldLastPosition = _worldPosition;
			if (plane.Raycast(ray, out var enter))
			{
				_worldPosition = ray.GetPoint(enter);
				_worldPosition.y -= _planeOffset;
				_gridPosition = _worldPosition.ToGridCoord();
				_worldPositionSmoothed = Vector3.SmoothDamp(_worldPositionSmoothed, _gridPosition.ToWorldPosition(), ref _positionDampVelocity, GameAlgorithms.Config.CursorPositionDampTime, float.PositiveInfinity, Time.unscaledDeltaTime);
				if ((bool)_visualisation)
				{
					_visualisation.transform.position = _worldPositionSmoothed;
				}
			}
			_screenPosition = Camera.main.WorldToScreenPoint(WorldPosition);
		}

		public void DebugDraw()
		{
			DebugDrawUtils.Marker(WorldPosition, Color.grey);
			DebugDrawUtils.Circle(WorldPosition, 0.1f, Color.white);
			DebugDrawUtils.Circle(WorldPosition + Vector3.up * 0.05f, 0.1f, Color.grey);
			DebugDrawUtils.Circle(WorldPosition + Vector3.up * 0.1f, 0.1f, Color.black);
		}

		public void DebugGUI()
		{
			if (_mode != null)
			{
				Rect position = new Rect(_screenPosition.x, (float)Screen.height - _screenPosition.y - 32f, 300f, 100f);
				string text = _mode.ToString();
				for (int num = _modeStack.Count - 1; num >= 0; num--)
				{
					text = text + "\n" + _modeStack[num];
				}
				GUI.Label(position, text);
				_mode.DebugDraw();
			}
		}

		public void OnGUI()
		{
			if (_mode != null)
			{
				_mode.OnGUI();
			}
		}

		public void PushMode(CursorMode newMode)
		{
			_inputManager.Flush();
			if (_mode != null)
			{
				_mode.OnBecomeInactive();
				OnModeBecomeInactive.InvokeSafe(_mode);
				_modeStack.Add(_mode);
			}
			_mode = newMode;
			_mode.OnBecomeActive();
			OnModeBecomeActive.InvokeSafe(_mode);
		}

		public void PopMode<T>() where T : CursorMode
		{
			_inputManager.Flush();
			if (_mode is T)
			{
				OnModeBecomeInactive.InvokeSafe(_mode);
				_mode.Destroy();
				SetCurrentMode();
				return;
			}
			foreach (CursorMode item in _modeStack)
			{
				if (item is T)
				{
					item.Destroy();
					if (!_modeStack.Remove(item) && _mode is T)
					{
						SetCurrentMode();
					}
					break;
				}
			}
		}

		public bool TryGetActiveMode<T>(out T activeMode) where T : CursorMode
		{
			activeMode = _mode as T;
			return activeMode != null;
		}

		private void SetCurrentMode()
		{
			if (_modeStack.Count == 0)
			{
				_mode = null;
				return;
			}
			_mode = _modeStack[_modeStack.Count - 1];
			_mode.OnBecomeActive();
			_modeStack.RemoveAt(_modeStack.Count - 1);
			OnModeBecomeActive.InvokeSafe(_mode);
		}

		public bool IsModeActive<T>() where T : CursorMode
		{
			return _mode is T;
		}

		public void SetCursorVisible(bool visible)
		{
			_visible = visible;
		}

		public void SetCursorIconVisible(bool visible)
		{
			_iconVisible = visible;
		}

		public void SetPlaneOffset(float offset)
		{
			_planeOffset = offset;
		}

		public void SetCursorIcon(CursorIcon icon)
		{
			_icon = icon;
		}

		public void SetCursorModel(CursorModel model)
		{
			GameObject[] visualisations = _visualisations;
			for (int i = 0; i < visualisations.Length; i++)
			{
				GameObjectUtils.SetActive(visualisations[i], isActive: false);
			}
			_visualisation = _visualisations[(int)model];
			if ((bool)_visualisation)
			{
				_visualisation.transform.position = _worldPositionSmoothed;
			}
			GameObjectUtils.SetActive(_visualisation, IsCursorVisible());
		}

		public void VerifyEvents()
		{
			OnModeBecomeActive.VerifyIsNull();
			OnModeBecomeInactive.VerifyIsNull();
		}
	}
}
