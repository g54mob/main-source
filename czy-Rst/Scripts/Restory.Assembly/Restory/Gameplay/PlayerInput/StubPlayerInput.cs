using System;
using System.Collections.Generic;
using Restory.Utils;
using Rewired;
using Rewired.Components;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.PlayerInput
{
	public sealed class StubPlayerInput : IPlayerInput, IInitializable, IDisposable
	{
		private int playerId;

		private bool enable = true;

		private Player player;

		private Rewired.Components.PlayerMouse playerMouse;

		public int Id => playerId;

		public int ControllerId => GetLastActiveControllerId();

		public string Name
		{
			get
			{
				if (player != null)
				{
					return player.name;
				}
				return string.Empty;
			}
		}

		public bool Enable
		{
			get
			{
				return enable;
			}
			set
			{
				enable = value;
			}
		}

		public Player.ControllerHelper Controllers
		{
			get
			{
				if (player != null)
				{
					return player.controllers;
				}
				return null;
			}
		}

		public Rewired.Components.PlayerMouse PlayerMouse
		{
			get
			{
				return playerMouse;
			}
			set
			{
				playerMouse = value;
			}
		}

		public event Action<int> ControllerAddedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private event Action<int> controllerAddedEvent;

		public event Action<int> ControllerRemovedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private event Action<int> controllerRemovedEvent;

		internal StubPlayerInput(int playerId)
			: this(playerId, null)
		{
		}

		internal StubPlayerInput(int playerId, Rewired.Components.PlayerMouse playerMouse)
		{
			this.playerId = playerId;
			this.playerMouse = playerMouse;
			ReInput.InitializedEvent += ReInput_InitializedEvent;
			ReInput.PreShutDownEvent += ReInput_PreShutDownEvent;
			if (ReInput.isReady)
			{
				ReInput_InitializedEvent();
			}
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
			ReInput.InitializedEvent -= ReInput_InitializedEvent;
			ReInput.PreShutDownEvent -= ReInput_PreShutDownEvent;
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback)
		{
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
		{
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId, params object[] args)
		{
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType)
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.IsCurrentInputSource(actionId, controllerType);
		}

		public bool GetAnyButton()
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetAnyButton();
		}

		public bool GetAnyButtonDown()
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetAnyButtonDown();
		}

		public bool GetAnyButtonUp()
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetAnyButtonUp();
		}

		public bool GetAnyNegativeButton()
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetAnyNegativeButton();
		}

		public bool GetAnyNegativeButtonDown()
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetAnyNegativeButtonDown();
		}

		public bool GetAnyNegativeButtonUp()
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetAnyNegativeButtonUp();
		}

		public float GetAxis(int actionId)
		{
			if (player == null || !enable)
			{
				return 0f;
			}
			return player.GetAxis(actionId);
		}

		public float GetAxis(string actionName)
		{
			if (player == null || !enable)
			{
				return 0f;
			}
			return player.GetAxis(actionName);
		}

		public Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId)
		{
			if (player == null || !enable)
			{
				return Vector2.zero;
			}
			return player.GetAxis2D(xAxisActionId, yAxisActionId);
		}

		public Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName)
		{
			if (player == null || !enable)
			{
				return Vector2.zero;
			}
			return player.GetAxis2D(xAxisActionName, yAxisActionName);
		}

		public float GetAxisDelta(int actionId)
		{
			if (player == null || !enable)
			{
				return 0f;
			}
			return player.GetAxisDelta(actionId);
		}

		public float GetAxisDelta(string actionName)
		{
			if (player == null || !enable)
			{
				return 0f;
			}
			return player.GetAxisDelta(actionName);
		}

		public float GetAxisRaw(int actionId)
		{
			if (player == null || !enable)
			{
				return 0f;
			}
			return player.GetAxisRaw(actionId);
		}

		public float GetAxisRaw(string actionName)
		{
			if (player == null || !enable)
			{
				return 0f;
			}
			return player.GetAxisRaw(actionName);
		}

		public float GetAxisRawDelta(int actionId)
		{
			if (player == null || !enable)
			{
				return 0f;
			}
			return player.GetAxisRawDelta(actionId);
		}

		public float GetAxisRawDelta(string actionName)
		{
			if (player == null || !enable)
			{
				return 0f;
			}
			return player.GetAxisRawDelta(actionName);
		}

		public bool GetButton(int actionId)
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetButton(actionId);
		}

		public bool GetButtonUp(int actionId)
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetButtonUp(actionId);
		}

		public bool GetButtonDown(int actionId)
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetButtonDown(actionId);
		}

		public bool GetButtonTimedPress(int actionId, float time)
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetButtonTimedPress(actionId, time);
		}

		public bool GetButtonTimedPressDown(int actionId, float time)
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetButtonTimedPressDown(actionId, time);
		}

		public bool GetButtonTimedPressUp(int actionId, float time)
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetButtonTimedPressUp(actionId, time);
		}

		public bool GetButtonPrev(int actionId)
		{
			return false;
		}

		public bool GetNegativeButton(int actionId)
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetNegativeButton(actionId);
		}

		public bool GetNegativeButtonDown(int actionId)
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetNegativeButtonDown(actionId);
		}

		public bool GetNegativeButtonUp(int actionId)
		{
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetNegativeButtonUp(actionId);
		}

		public Vector2 GetMousePosition()
		{
			if (player == null || !enable)
			{
				return Vector2.zero;
			}
			if (playerMouse != null)
			{
				return playerMouse.screenPosition;
			}
			if (player.controllers.hasMouse)
			{
				return player.controllers.Mouse.screenPosition;
			}
			return Vector2.zero;
		}

		public bool GetLeftMouseButtonDown(int index = 0)
		{
			if (player == null || !enable)
			{
				return false;
			}
			if (playerMouse != null)
			{
				return playerMouse.GetButtonDown(index);
			}
			if (player.controllers.hasMouse)
			{
				return player.controllers.Mouse.GetButtonDown(index);
			}
			return false;
		}

		public string GetMapEnableTag()
		{
			if (player == null)
			{
				return string.Empty;
			}
			return player.CurrentTag();
		}

		public bool SetMapEnableTag(string tag)
		{
			if (player == null)
			{
				return false;
			}
			return player.SwitchRuleWithTag(tag);
		}

		public void ResetToDefaults(ControllerType controllerType)
		{
			if (player != null)
			{
				player.ResetToDefaults(controllerType);
			}
		}

		public ControllerMap GetMap(Controller controller, int categoryId)
		{
			if (player == null)
			{
				return null;
			}
			return player.controllers.maps.GetMap(controller, categoryId, 0);
		}

		public ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId)
		{
			if (player == null)
			{
				return null;
			}
			return player.controllers.maps.GetMap(controllerType, controllerId, categoryId, 0);
		}

		public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId)
		{
			if (player == null)
			{
				return null;
			}
			return player.controllers.maps.GetAllMapsInCategory(categoryId);
		}

		public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
		{
		}

		public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
		{
		}

		public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
		{
		}

		public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
		{
		}

		public Controller GetController(ControllerType controllerType, int controllerId)
		{
			if (player == null)
			{
				return null;
			}
			return player.controllers.GetController(controllerType, controllerId);
		}

		public Controller GetLastActiveController()
		{
			if (player == null)
			{
				return null;
			}
			return player.controllers.GetLastActiveController();
		}

		public Controller GetLastActiveController(ControllerType controllerType)
		{
			if (player == null)
			{
				return null;
			}
			return player.controllers.GetLastActiveController(controllerType);
		}

		private void ReInput_InitializedEvent()
		{
			player = ReInput.players.GetPlayer(playerId);
			player.controllers.ControllerAddedEvent += Controllers_ControllerAddedEvent;
			player.controllers.ControllerRemovedEvent += Controllers_ControllerRemovedEvent;
			ReInput.ControllerConnectedEvent += ResolveOnControllerConnectedEvent;
			ReInput.ControllerDisconnectedEvent += ResolveOnControllerDisconnectedEvent;
		}

		private void ReInput_PreShutDownEvent()
		{
			player.controllers.ControllerAddedEvent -= Controllers_ControllerAddedEvent;
			player.controllers.ControllerRemovedEvent -= Controllers_ControllerRemovedEvent;
			ReInput.ControllerConnectedEvent -= ResolveOnControllerConnectedEvent;
			ReInput.ControllerDisconnectedEvent -= ResolveOnControllerDisconnectedEvent;
			player = null;
		}

		private void Controllers_ControllerAddedEvent(ControllerAssignmentChangedEventArgs args)
		{
			this.controllerAddedEvent?.Invoke(args.controller.id);
		}

		private void Controllers_ControllerRemovedEvent(ControllerAssignmentChangedEventArgs args)
		{
			this.controllerRemovedEvent?.Invoke(args.controller.id);
		}

		private void ResolveOnControllerConnectedEvent(ControllerStatusChangedEventArgs args)
		{
			this.controllerAddedEvent?.Invoke(args.controller.id);
		}

		private void ResolveOnControllerDisconnectedEvent(ControllerStatusChangedEventArgs args)
		{
			int obj = -1;
			if (args != null)
			{
				obj = args.controllerId;
			}
			this.controllerRemovedEvent?.Invoke(obj);
		}

		private int GetLastActiveControllerId()
		{
			if (player == null || player.controllers == null)
			{
				return 0;
			}
			return player.controllers.GetLastActiveController(ControllerType.Joystick)?.id ?? 0;
		}
	}
}
