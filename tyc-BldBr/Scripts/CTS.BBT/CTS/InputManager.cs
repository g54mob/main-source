using System;
using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	[DefaultExecutionOrder(-99)]
	[RequireComponent(typeof(PlayerInput))]
	[ExecuteAlways]
	public sealed class InputManager : MonoBehaviour
	{
		public abstract class ActionMap
		{
			private int _lockState;

			public abstract bool IsDummy { get; }

			public virtual void Lock(bool p_recursive = false)
			{
				_lockState++;
				if (IsActive())
				{
					SetActive(p_value: false);
				}
			}

			public virtual void Unlock(bool p_recursive = false)
			{
				_lockState = Math.Max(0, _lockState - 1);
				if (_lockState <= 0 && !IsActive())
				{
					SetActive(p_value: true);
				}
			}

			protected abstract void SetActive(bool p_value);

			public abstract bool IsActive();

			protected ActionMap(EMap p_map)
			{
				_mapsDictionary.Add(p_map, this);
			}

			public virtual void Subscribe(PlayerInput p_inputComponent)
			{
			}

			public virtual void Unsubscribe(PlayerInput p_inputComponent)
			{
			}
		}

		[Flags]
		public enum EMap
		{
			General = 1,
			Pause = 2,
			Game = 4,
			[InspectorName("Game/Live")]
			GameLive = 8,
			[InspectorName("Game/Build")]
			GameBuild = 0x10,
			Menus = 0x20,
			[InspectorName("InGamePause")]
			Ingamepause = 0x40
		}

		public class InputMapGeneral : ActionMap
		{
			private InputActionMap _actionMap;

			public override bool IsDummy => false;

			public InputProxy console { get; }

			public InputProxy editor { get; }

			public InputProxy mouseDelta { get; }

			public override bool IsActive()
			{
				return _actionMap.enabled;
			}

			public InputMapGeneral(EMap p_map, InputActionAsset p_inputAsset)
				: base(p_map)
			{
				_actionMap = p_inputAsset.FindActionMap("General");
				_actionMap.Enable();
				console = new InputProxy(_actionMap.FindAction("Console"));
				editor = new InputProxy(_actionMap.FindAction("Editor"));
				mouseDelta = new InputProxy(_actionMap.FindAction("Mouse Delta"));
			}

			protected override void SetActive(bool p_value)
			{
				if (p_value != _actionMap.enabled)
				{
					if (p_value)
					{
						_actionMap.Enable();
					}
					else
					{
						_actionMap.Disable();
					}
				}
			}

			private void Console(InputAction.CallbackContext ctx)
			{
				console.Invoke(ctx);
			}

			private void Editor(InputAction.CallbackContext ctx)
			{
				editor.Invoke(ctx);
			}

			private void MouseDelta(InputAction.CallbackContext ctx)
			{
				mouseDelta.Invoke(ctx);
			}

			public override void Subscribe(PlayerInput p_inputComponent)
			{
				p_inputComponent.actionEvents[0].AddListener(Console);
				p_inputComponent.actionEvents[21].AddListener(Editor);
				p_inputComponent.actionEvents[9].AddListener(MouseDelta);
			}

			public override void Unsubscribe(PlayerInput p_inputComponent)
			{
				p_inputComponent.actionEvents[0].RemoveListener(Console);
				p_inputComponent.actionEvents[21].RemoveListener(Editor);
				p_inputComponent.actionEvents[9].RemoveListener(MouseDelta);
			}
		}

		public class InputMapPause : ActionMap
		{
			private InputActionMap _actionMap;

			public override bool IsDummy => false;

			public InputProxy pause { get; }

			public override bool IsActive()
			{
				return _actionMap.enabled;
			}

			public InputMapPause(EMap p_map, InputActionAsset p_inputAsset)
				: base(p_map)
			{
				_actionMap = p_inputAsset.FindActionMap("Pause");
				_actionMap.Enable();
				pause = new InputProxy(_actionMap.FindAction("Pause"));
			}

			protected override void SetActive(bool p_value)
			{
				if (p_value != _actionMap.enabled)
				{
					if (p_value)
					{
						_actionMap.Enable();
					}
					else
					{
						_actionMap.Disable();
					}
				}
			}

			private void Pause(InputAction.CallbackContext ctx)
			{
				pause.Invoke(ctx);
			}

			public override void Subscribe(PlayerInput p_inputComponent)
			{
				p_inputComponent.actionEvents[1].AddListener(Pause);
			}

			public override void Unsubscribe(PlayerInput p_inputComponent)
			{
				p_inputComponent.actionEvents[1].RemoveListener(Pause);
			}
		}

		public class InputMapGame : ActionMap
		{
			public class InputMapLive : ActionMap
			{
				private InputActionMap _actionMap;

				public override bool IsDummy => false;

				public InputProxy pause { get; }

				public InputProxy contextAction { get; }

				public InputProxy timeControlPause { get; }

				public InputProxy timeControlSlow { get; }

				public InputProxy timeControlNormal { get; }

				public InputProxy timeControlFast { get; }

				public override bool IsActive()
				{
					return _actionMap.enabled;
				}

				public InputMapLive(EMap p_map, InputActionAsset p_inputAsset)
					: base(p_map)
				{
					_actionMap = p_inputAsset.FindActionMap("Game/Live");
					_actionMap.Enable();
					pause = new InputProxy(_actionMap.FindAction("Pause"));
					contextAction = new InputProxy(_actionMap.FindAction("Context Action"));
					timeControlPause = new InputProxy(_actionMap.FindAction("Time Control Pause"));
					timeControlSlow = new InputProxy(_actionMap.FindAction("Time Control Slow"));
					timeControlNormal = new InputProxy(_actionMap.FindAction("Time Control Normal"));
					timeControlFast = new InputProxy(_actionMap.FindAction("Time Control Fast"));
				}

				protected override void SetActive(bool p_value)
				{
					if (p_value != _actionMap.enabled)
					{
						if (p_value)
						{
							_actionMap.Enable();
						}
						else
						{
							_actionMap.Disable();
						}
					}
				}

				private void Pause(InputAction.CallbackContext ctx)
				{
					pause.Invoke(ctx);
				}

				private void ContextAction(InputAction.CallbackContext ctx)
				{
					contextAction.Invoke(ctx);
				}

				private void TimeControlPause(InputAction.CallbackContext ctx)
				{
					timeControlPause.Invoke(ctx);
				}

				private void TimeControlSlow(InputAction.CallbackContext ctx)
				{
					timeControlSlow.Invoke(ctx);
				}

				private void TimeControlNormal(InputAction.CallbackContext ctx)
				{
					timeControlNormal.Invoke(ctx);
				}

				private void TimeControlFast(InputAction.CallbackContext ctx)
				{
					timeControlFast.Invoke(ctx);
				}

				public override void Subscribe(PlayerInput p_inputComponent)
				{
					p_inputComponent.actionEvents[4].AddListener(Pause);
					p_inputComponent.actionEvents[5].AddListener(ContextAction);
					p_inputComponent.actionEvents[24].AddListener(TimeControlPause);
					p_inputComponent.actionEvents[25].AddListener(TimeControlSlow);
					p_inputComponent.actionEvents[26].AddListener(TimeControlNormal);
					p_inputComponent.actionEvents[27].AddListener(TimeControlFast);
				}

				public override void Unsubscribe(PlayerInput p_inputComponent)
				{
					p_inputComponent.actionEvents[4].RemoveListener(Pause);
					p_inputComponent.actionEvents[5].RemoveListener(ContextAction);
					p_inputComponent.actionEvents[24].RemoveListener(TimeControlPause);
					p_inputComponent.actionEvents[25].RemoveListener(TimeControlSlow);
					p_inputComponent.actionEvents[26].RemoveListener(TimeControlNormal);
					p_inputComponent.actionEvents[27].RemoveListener(TimeControlFast);
				}
			}

			public class InputMapBuild : ActionMap
			{
				private InputActionMap _actionMap;

				public override bool IsDummy => false;

				public InputProxy place { get; }

				public InputProxy rotateclockwise { get; }

				public InputProxy rotatecounterclockwise { get; }

				public InputProxy cancelplacement { get; }

				public InputProxy buying { get; }

				public InputProxy duplicate { get; }

				public InputProxy gridplacement { get; }

				public override bool IsActive()
				{
					return _actionMap.enabled;
				}

				public InputMapBuild(EMap p_map, InputActionAsset p_inputAsset)
					: base(p_map)
				{
					_actionMap = p_inputAsset.FindActionMap("Game/Build");
					_actionMap.Enable();
					place = new InputProxy(_actionMap.FindAction("Place"));
					rotateclockwise = new InputProxy(_actionMap.FindAction("RotateClockwise"));
					rotatecounterclockwise = new InputProxy(_actionMap.FindAction("RotateCounterClockwise"));
					cancelplacement = new InputProxy(_actionMap.FindAction("CancelPlacement"));
					buying = new InputProxy(_actionMap.FindAction("Buying"));
					duplicate = new InputProxy(_actionMap.FindAction("Duplicate"));
					gridplacement = new InputProxy(_actionMap.FindAction("GridPlacement"));
				}

				protected override void SetActive(bool p_value)
				{
					if (p_value != _actionMap.enabled)
					{
						if (p_value)
						{
							_actionMap.Enable();
						}
						else
						{
							_actionMap.Disable();
						}
					}
				}

				private void Place(InputAction.CallbackContext ctx)
				{
					place.Invoke(ctx);
				}

				private void Rotateclockwise(InputAction.CallbackContext ctx)
				{
					rotateclockwise.Invoke(ctx);
				}

				private void Rotatecounterclockwise(InputAction.CallbackContext ctx)
				{
					rotatecounterclockwise.Invoke(ctx);
				}

				private void Cancelplacement(InputAction.CallbackContext ctx)
				{
					cancelplacement.Invoke(ctx);
				}

				private void Buying(InputAction.CallbackContext ctx)
				{
					buying.Invoke(ctx);
				}

				private void Duplicate(InputAction.CallbackContext ctx)
				{
					duplicate.Invoke(ctx);
				}

				private void Gridplacement(InputAction.CallbackContext ctx)
				{
					gridplacement.Invoke(ctx);
				}

				public override void Subscribe(PlayerInput p_inputComponent)
				{
					p_inputComponent.actionEvents[12].AddListener(Place);
					p_inputComponent.actionEvents[13].AddListener(Rotateclockwise);
					p_inputComponent.actionEvents[15].AddListener(Rotatecounterclockwise);
					p_inputComponent.actionEvents[14].AddListener(Cancelplacement);
					p_inputComponent.actionEvents[29].AddListener(Buying);
					p_inputComponent.actionEvents[30].AddListener(Duplicate);
					p_inputComponent.actionEvents[31].AddListener(Gridplacement);
				}

				public override void Unsubscribe(PlayerInput p_inputComponent)
				{
					p_inputComponent.actionEvents[12].RemoveListener(Place);
					p_inputComponent.actionEvents[13].RemoveListener(Rotateclockwise);
					p_inputComponent.actionEvents[15].RemoveListener(Rotatecounterclockwise);
					p_inputComponent.actionEvents[14].RemoveListener(Cancelplacement);
					p_inputComponent.actionEvents[29].RemoveListener(Buying);
					p_inputComponent.actionEvents[30].RemoveListener(Duplicate);
					p_inputComponent.actionEvents[31].RemoveListener(Gridplacement);
				}
			}

			private InputActionMap _actionMap;

			public override bool IsDummy => false;

			public InputProxy select { get; }

			public InputProxy unselect { get; }

			public InputProxy cameraMovement { get; }

			public InputProxy cameraRotation { get; }

			public InputProxy cameraMousePan { get; }

			public InputProxy cameraMouseRotation { get; }

			public InputProxy cameraZoom { get; }

			public InputProxy cameraMouseZoom { get; }

			public InputProxy nextFloor { get; }

			public InputProxy previousFloor { get; }

			public InputProxy toggleTracking { get; }

			public InputProxy fastForwardDialogue { get; }

			public InputProxy multiSelection { get; }

			public InputProxy wallDisplayToggle { get; }

			public InputProxy closepanel { get; }

			public InputMapLive live { get; private set; }

			public InputMapBuild build { get; private set; }

			public override bool IsActive()
			{
				return _actionMap.enabled;
			}

			public InputMapGame(EMap p_map, InputActionAsset p_inputAsset)
				: base(p_map)
			{
				_actionMap = p_inputAsset.FindActionMap("Game");
				_actionMap.Enable();
				select = new InputProxy(_actionMap.FindAction("Select"));
				unselect = new InputProxy(_actionMap.FindAction("Unselect"));
				cameraMovement = new InputProxy(_actionMap.FindAction("Camera Movement"));
				cameraRotation = new InputProxy(_actionMap.FindAction("Camera Rotation"));
				cameraMousePan = new InputProxy(_actionMap.FindAction("Camera Mouse Pan"));
				cameraMouseRotation = new InputProxy(_actionMap.FindAction("Camera Mouse Rotation"));
				cameraZoom = new InputProxy(_actionMap.FindAction("Camera Zoom"));
				cameraMouseZoom = new InputProxy(_actionMap.FindAction("Camera Mouse Zoom"));
				nextFloor = new InputProxy(_actionMap.FindAction("Next Floor"));
				previousFloor = new InputProxy(_actionMap.FindAction("Previous Floor"));
				toggleTracking = new InputProxy(_actionMap.FindAction("Toggle Tracking"));
				fastForwardDialogue = new InputProxy(_actionMap.FindAction("Fast Forward Dialogue"));
				multiSelection = new InputProxy(_actionMap.FindAction("Multi Selection"));
				wallDisplayToggle = new InputProxy(_actionMap.FindAction("Wall Display Toggle"));
				closepanel = new InputProxy(_actionMap.FindAction("ClosePanel"));
				live = new InputMapLive(EMap.GameLive, p_inputAsset);
				build = new InputMapBuild(EMap.GameBuild, p_inputAsset);
			}

			public override void Lock(bool p_recursive = false)
			{
				base.Lock();
				if (p_recursive)
				{
					live.Lock(p_recursive: true);
					build.Lock(p_recursive: true);
				}
			}

			public override void Unlock(bool p_recursive = false)
			{
				base.Unlock();
				if (p_recursive)
				{
					live.Unlock(p_recursive: true);
					build.Unlock(p_recursive: true);
				}
			}

			protected override void SetActive(bool p_value)
			{
				if (p_value != _actionMap.enabled)
				{
					if (p_value)
					{
						_actionMap.Enable();
					}
					else
					{
						_actionMap.Disable();
					}
				}
			}

			private void Select(InputAction.CallbackContext ctx)
			{
				select.Invoke(ctx);
			}

			private void Unselect(InputAction.CallbackContext ctx)
			{
				unselect.Invoke(ctx);
			}

			private void CameraMovement(InputAction.CallbackContext ctx)
			{
				cameraMovement.Invoke(ctx);
			}

			private void CameraRotation(InputAction.CallbackContext ctx)
			{
				cameraRotation.Invoke(ctx);
			}

			private void CameraMousePan(InputAction.CallbackContext ctx)
			{
				cameraMousePan.Invoke(ctx);
			}

			private void CameraMouseRotation(InputAction.CallbackContext ctx)
			{
				cameraMouseRotation.Invoke(ctx);
			}

			private void CameraZoom(InputAction.CallbackContext ctx)
			{
				cameraZoom.Invoke(ctx);
			}

			private void CameraMouseZoom(InputAction.CallbackContext ctx)
			{
				cameraMouseZoom.Invoke(ctx);
			}

			private void NextFloor(InputAction.CallbackContext ctx)
			{
				nextFloor.Invoke(ctx);
			}

			private void PreviousFloor(InputAction.CallbackContext ctx)
			{
				previousFloor.Invoke(ctx);
			}

			private void ToggleTracking(InputAction.CallbackContext ctx)
			{
				toggleTracking.Invoke(ctx);
			}

			private void FastForwardDialogue(InputAction.CallbackContext ctx)
			{
				fastForwardDialogue.Invoke(ctx);
			}

			private void MultiSelection(InputAction.CallbackContext ctx)
			{
				multiSelection.Invoke(ctx);
			}

			private void WallDisplayToggle(InputAction.CallbackContext ctx)
			{
				wallDisplayToggle.Invoke(ctx);
			}

			private void Closepanel(InputAction.CallbackContext ctx)
			{
				closepanel.Invoke(ctx);
			}

			public override void Subscribe(PlayerInput p_inputComponent)
			{
				p_inputComponent.actionEvents[2].AddListener(Select);
				p_inputComponent.actionEvents[3].AddListener(Unselect);
				p_inputComponent.actionEvents[6].AddListener(CameraMovement);
				p_inputComponent.actionEvents[7].AddListener(CameraRotation);
				p_inputComponent.actionEvents[8].AddListener(CameraMousePan);
				p_inputComponent.actionEvents[18].AddListener(CameraMouseRotation);
				p_inputComponent.actionEvents[16].AddListener(CameraZoom);
				p_inputComponent.actionEvents[17].AddListener(CameraMouseZoom);
				p_inputComponent.actionEvents[10].AddListener(NextFloor);
				p_inputComponent.actionEvents[11].AddListener(PreviousFloor);
				p_inputComponent.actionEvents[19].AddListener(ToggleTracking);
				p_inputComponent.actionEvents[20].AddListener(FastForwardDialogue);
				p_inputComponent.actionEvents[22].AddListener(MultiSelection);
				p_inputComponent.actionEvents[23].AddListener(WallDisplayToggle);
				p_inputComponent.actionEvents[28].AddListener(Closepanel);
				live.Subscribe(p_inputComponent);
				build.Subscribe(p_inputComponent);
			}

			public override void Unsubscribe(PlayerInput p_inputComponent)
			{
				p_inputComponent.actionEvents[2].RemoveListener(Select);
				p_inputComponent.actionEvents[3].RemoveListener(Unselect);
				p_inputComponent.actionEvents[6].RemoveListener(CameraMovement);
				p_inputComponent.actionEvents[7].RemoveListener(CameraRotation);
				p_inputComponent.actionEvents[8].RemoveListener(CameraMousePan);
				p_inputComponent.actionEvents[18].RemoveListener(CameraMouseRotation);
				p_inputComponent.actionEvents[16].RemoveListener(CameraZoom);
				p_inputComponent.actionEvents[17].RemoveListener(CameraMouseZoom);
				p_inputComponent.actionEvents[10].RemoveListener(NextFloor);
				p_inputComponent.actionEvents[11].RemoveListener(PreviousFloor);
				p_inputComponent.actionEvents[19].RemoveListener(ToggleTracking);
				p_inputComponent.actionEvents[20].RemoveListener(FastForwardDialogue);
				p_inputComponent.actionEvents[22].RemoveListener(MultiSelection);
				p_inputComponent.actionEvents[23].RemoveListener(WallDisplayToggle);
				p_inputComponent.actionEvents[28].RemoveListener(Closepanel);
				live.Unsubscribe(p_inputComponent);
				build.Unsubscribe(p_inputComponent);
			}
		}

		public class InputMapMenus : ActionMap
		{
			private InputActionMap _actionMap;

			public override bool IsDummy => false;

			public override bool IsActive()
			{
				return _actionMap.enabled;
			}

			public InputMapMenus(EMap p_map, InputActionAsset p_inputAsset)
				: base(p_map)
			{
				_actionMap = p_inputAsset.FindActionMap("Menus");
				_actionMap.Enable();
			}

			protected override void SetActive(bool p_value)
			{
				if (p_value != _actionMap.enabled)
				{
					if (p_value)
					{
						_actionMap.Enable();
					}
					else
					{
						_actionMap.Disable();
					}
				}
			}
		}

		public class InputMapIngamepause : ActionMap
		{
			private InputActionMap _actionMap;

			public override bool IsDummy => false;

			public InputProxy pause { get; }

			public override bool IsActive()
			{
				return _actionMap.enabled;
			}

			public InputMapIngamepause(EMap p_map, InputActionAsset p_inputAsset)
				: base(p_map)
			{
				_actionMap = p_inputAsset.FindActionMap("InGamePause");
				_actionMap.Enable();
				pause = new InputProxy(_actionMap.FindAction("Pause"));
			}

			protected override void SetActive(bool p_value)
			{
				if (p_value != _actionMap.enabled)
				{
					if (p_value)
					{
						_actionMap.Enable();
					}
					else
					{
						_actionMap.Disable();
					}
				}
			}

			private void Pause(InputAction.CallbackContext ctx)
			{
				pause.Invoke(ctx);
			}

			public override void Subscribe(PlayerInput p_inputComponent)
			{
				p_inputComponent.actionEvents[32].AddListener(Pause);
			}

			public override void Unsubscribe(PlayerInput p_inputComponent)
			{
				p_inputComponent.actionEvents[32].RemoveListener(Pause);
			}
		}

		[SerializeField]
		private bool _debug;

		[SerializeField]
		private InputActionAsset _inputAsset;

		private static InputManager instance;

		private PlayerInput _playerInputComponent;

		public const string SCHEME_KEYBOARD = "Keyboard";

		public const string SCHEME_GAMEPAD = "Gamepad";

		[SerializeField]
		private EMap _defaultMaps = (EMap)(-1);

		private static Dictionary<EMap, ActionMap> _mapsDictionary = new Dictionary<EMap, ActionMap>();

		public static float mouseSensitivity { get; set; }

		public static float stickSensitivity { get; set; }

		public static string currentScheme => instance._playerInputComponent.currentControlScheme;

		public static ReadOnlyDictionary<EMap, ActionMap> ActionMaps => _mapsDictionary;

		public static InputMapGeneral general { get; private set; }

		public static InputMapPause pause { get; private set; }

		public static InputMapGame game { get; private set; }

		public static InputMapMenus menus { get; private set; }

		public static InputMapIngamepause ingamepause { get; private set; }

		public static event Action<string> onControlSchemeChanged;

		public static event Action<string> onActionMapChanged;

		private void Awake()
		{
			if (this.Singleton(ref instance))
			{
				_playerInputComponent = base.gameObject.GetComponent<PlayerInput>();
				_playerInputComponent.controlsChangedEvent.AddListener(ControlSchemeChange);
				_playerInputComponent.hideFlags = HideFlags.NotEditable;
				_playerInputComponent.enabled = true;
				AwakePartial();
			}
		}

		private void OnDestroy()
		{
			_playerInputComponent.controlsChangedEvent.RemoveListener(ControlSchemeChange);
			OnDestroyPartial();
		}

		private void AwakePartial()
		{
			general = new InputMapGeneral(EMap.General, _inputAsset);
			general.Subscribe(_playerInputComponent);
			pause = new InputMapPause(EMap.Pause, _inputAsset);
			pause.Subscribe(_playerInputComponent);
			game = new InputMapGame(EMap.Game, _inputAsset);
			game.Subscribe(_playerInputComponent);
			menus = new InputMapMenus(EMap.Menus, _inputAsset);
			menus.Subscribe(_playerInputComponent);
			ingamepause = new InputMapIngamepause(EMap.Ingamepause, _inputAsset);
			ingamepause.Subscribe(_playerInputComponent);
			if (!_defaultMaps.HasFlag(EMap.General))
			{
				general.Lock();
			}
			if (!_defaultMaps.HasFlag(EMap.Pause))
			{
				pause.Lock();
			}
			if (!_defaultMaps.HasFlag(EMap.Game))
			{
				game.Lock();
			}
			if (!_defaultMaps.HasFlag(EMap.GameLive))
			{
				game.live.Lock();
			}
			if (!_defaultMaps.HasFlag(EMap.GameBuild))
			{
				game.build.Lock();
			}
			if (!_defaultMaps.HasFlag(EMap.Menus))
			{
				menus.Lock();
			}
			if (!_defaultMaps.HasFlag(EMap.Ingamepause))
			{
				ingamepause.Lock();
			}
		}

		private void OnDestroyPartial()
		{
			general.Unsubscribe(_playerInputComponent);
			pause.Unsubscribe(_playerInputComponent);
			game.Unsubscribe(_playerInputComponent);
			menus.Unsubscribe(_playerInputComponent);
			ingamepause.Unsubscribe(_playerInputComponent);
			_mapsDictionary.Clear();
		}

		private void ControlSchemeChange(PlayerInput p_input)
		{
			InputManager.onControlSchemeChanged?.Invoke(p_input.currentControlScheme);
		}

		public static void EnableInputs()
		{
		}

		public static void DisableInputs()
		{
		}

		public static EMap GetActiveMaps()
		{
			EMap eMap = (EMap)0;
			foreach (KeyValuePair<EMap, ActionMap> item in _mapsDictionary)
			{
				if (item.Value.IsActive() && !item.Value.IsDummy)
				{
					eMap |= item.Key;
				}
			}
			return eMap;
		}
	}
}
