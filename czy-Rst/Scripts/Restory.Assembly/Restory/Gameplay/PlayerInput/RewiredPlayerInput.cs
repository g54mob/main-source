using System;
using System.Collections.Generic;
using Restory.Utils;
using Rewired;
using Rewired.Components;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.PlayerInput
{
	public sealed class RewiredPlayerInput : IPlayerInput, IInitializable, IDisposable
	{
		private class InputEventTest
		{
			public struct EventKey
			{
				public int actionId;

				public InputActionEventType eventType;

				public EventKey(int actionId, InputActionEventType eventType)
				{
					this.actionId = actionId;
					this.eventType = eventType;
				}
			}

			public List<Action<InputActionEventData>> events = new List<Action<InputActionEventData>>();

			public Dictionary<int, List<Action<InputActionEventData>>> actionEvents = new Dictionary<int, List<Action<InputActionEventData>>>();

			public Dictionary<InputActionEventType, List<Action<InputActionEventData>>> typeEvents = new Dictionary<InputActionEventType, List<Action<InputActionEventData>>>();

			public Dictionary<EventKey, List<Action<InputActionEventData>>> typeAndActionEvents = new Dictionary<EventKey, List<Action<InputActionEventData>>>();

			public void Add(Action<InputActionEventData> action)
			{
				events.Add(action);
			}

			public void Remove(Action<InputActionEventData> action)
			{
				events.Remove(action);
			}

			public void Add(Action<InputActionEventData> action, int actonId)
			{
				if (!actionEvents.TryGetValue(actonId, out var value))
				{
					value = new List<Action<InputActionEventData>>();
					actionEvents[actonId] = value;
				}
				value.Add(action);
			}

			public void Remove(Action<InputActionEventData> action, int actonId)
			{
				if (actionEvents.TryGetValue(actonId, out var value))
				{
					value.Remove(action);
				}
			}

			public void Add(Action<InputActionEventData> action, InputActionEventType type)
			{
				if (!typeEvents.TryGetValue(type, out var value))
				{
					value = new List<Action<InputActionEventData>>();
					typeEvents[type] = value;
				}
				value.Add(action);
			}

			public void Remove(Action<InputActionEventData> action, InputActionEventType type)
			{
				if (typeEvents.TryGetValue(type, out var value))
				{
					value.Remove(action);
				}
			}

			public void Add(Action<InputActionEventData> action, InputActionEventType type, int actonId)
			{
				EventKey key = new EventKey(actonId, type);
				if (!typeAndActionEvents.TryGetValue(key, out var value))
				{
					value = new List<Action<InputActionEventData>>();
					typeAndActionEvents[key] = value;
				}
				value.Add(action);
			}

			public void Remove(Action<InputActionEventData> action, InputActionEventType type, int actonId)
			{
				EventKey key = new EventKey(actonId, type);
				if (typeAndActionEvents.TryGetValue(key, out var value))
				{
					value.Remove(action);
				}
			}

			public void Clear()
			{
				events.Clear();
				actionEvents.Clear();
				typeEvents.Clear();
				typeAndActionEvents.Clear();
			}
		}

		private class ActiveControllerEvent
		{
			public HashSet<PlayerActiveControllerChangedDelegate> events = new HashSet<PlayerActiveControllerChangedDelegate>();

			public Dictionary<ControllerType, HashSet<PlayerActiveControllerChangedDelegate>> typeEvents = new Dictionary<ControllerType, HashSet<PlayerActiveControllerChangedDelegate>>();

			public void Add(PlayerActiveControllerChangedDelegate action)
			{
				events.Add(action);
			}

			public void Remove(PlayerActiveControllerChangedDelegate action)
			{
				events.Remove(action);
			}

			public void Add(PlayerActiveControllerChangedDelegate action, ControllerType type)
			{
				if (!typeEvents.TryGetValue(type, out var value))
				{
					value = new HashSet<PlayerActiveControllerChangedDelegate>();
					typeEvents[type] = value;
				}
				value.Add(action);
			}

			public void Remove(PlayerActiveControllerChangedDelegate action, ControllerType type)
			{
				if (typeEvents.TryGetValue(type, out var value))
				{
					value.Remove(action);
				}
			}

			public void Clear()
			{
				events.Clear();
				typeEvents.Clear();
			}
		}

		private class InputEvent
		{
			private struct EventKey
			{
				public int actionId;

				public InputActionEventType eventType;

				public EventKey(int actionId, InputActionEventType eventType)
				{
					this.actionId = actionId;
					this.eventType = eventType;
				}
			}

			private class EventValue
			{
				private event Action<InputActionEventData> actions;

				public void Invoke(InputActionEventData eventData)
				{
					this.actions?.Invoke(eventData);
				}

				public void Add(Action<InputActionEventData> kDelegate)
				{
					actions += kDelegate;
				}

				public void Remove(Action<InputActionEventData> kDelegate)
				{
					actions -= kDelegate;
				}
			}

			private Dictionary<int, EventValue> actionEvents = new Dictionary<int, EventValue>();

			private Dictionary<InputActionEventType, EventValue> typeEvents = new Dictionary<InputActionEventType, EventValue>();

			private Dictionary<EventKey, EventValue> typeAndActionEvents = new Dictionary<EventKey, EventValue>();

			public void Clear()
			{
				actionEvents.Clear();
				typeEvents.Clear();
				typeAndActionEvents.Clear();
			}

			public void Invoke(InputActionEventData eventData)
			{
				if (actionEvents.TryGetValue(eventData.actionId, out var value))
				{
					value?.Invoke(eventData);
				}
				if (typeEvents.TryGetValue(eventData.eventType, out value))
				{
					value?.Invoke(eventData);
				}
				if (typeAndActionEvents.TryGetValue(new EventKey(eventData.actionId, eventData.eventType), out value))
				{
					value?.Invoke(eventData);
				}
			}

			public void Add(Action<InputActionEventData> action, int actonId)
			{
				if (!actionEvents.TryGetValue(actonId, out var value))
				{
					value = new EventValue();
					actionEvents[actonId] = value;
				}
				value.Add(action);
			}

			public void Remove(Action<InputActionEventData> action, int actonId)
			{
				if (actionEvents.TryGetValue(actonId, out var value))
				{
					value.Remove(action);
				}
			}

			public void Add(Action<InputActionEventData> action, InputActionEventType type)
			{
				if (!typeEvents.TryGetValue(type, out var value))
				{
					value = new EventValue();
					typeEvents[type] = value;
				}
				value.Add(action);
			}

			public void Remove(Action<InputActionEventData> action, InputActionEventType type)
			{
				if (typeEvents.TryGetValue(type, out var value))
				{
					value.Remove(action);
				}
			}

			public void Add(Action<InputActionEventData> action, InputActionEventType type, int actonId)
			{
				EventKey key = new EventKey(actonId, type);
				if (!typeAndActionEvents.TryGetValue(key, out var value))
				{
					value = new EventValue();
					typeAndActionEvents[key] = value;
				}
				value.Add(action);
			}

			public void Remove(Action<InputActionEventData> action, InputActionEventType type, int actonId)
			{
				EventKey key = new EventKey(actonId, type);
				if (typeAndActionEvents.TryGetValue(key, out var value))
				{
					value.Remove(action);
				}
			}
		}

		public class OperatorFactory : IFactory<IPlayerInput>, IFactory
		{
			public IPlayerInput Create()
			{
				return new RewiredPlayerInput(1);
			}
		}

		public class PlayerFactory : IFactory<IPlayerInput>, IFactory
		{
			private int playerId;

			private Rewired.Components.PlayerMouse playerMouse;

			[Inject]
			private void Construct([Inject(Id = "PlayerInputId")] int playerId, Rewired.Components.PlayerMouse playerMouse)
			{
				this.playerId = playerId;
				this.playerMouse = playerMouse;
			}

			public IPlayerInput Create()
			{
				return new RewiredPlayerInput(playerId, playerMouse);
			}
		}

		public class StubPlayerFactory : IFactory<IPlayerInput>, IFactory
		{
			private int playerId;

			private Rewired.Components.PlayerMouse playerMouse;

			[Inject]
			private void Construct([Inject(Id = "PlayerInputId")] int playerId, Rewired.Components.PlayerMouse playerMouse)
			{
				this.playerId = playerId;
				this.playerMouse = playerMouse;
			}

			public IPlayerInput Create()
			{
				return new StubPlayerInput(playerId, playerMouse);
			}
		}

		public class StubOperatorPlayerFactory : IFactory<IPlayerInput>, IFactory
		{
			public IPlayerInput Create()
			{
				return new StubPlayerInput(1);
			}
		}

		private int playerId;

		private bool enable = true;

		private InputEventTest inputEventCache = new InputEventTest();

		private ActiveControllerEvent activeControllerEventCache = new ActiveControllerEvent();

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

		public event Action<int> ControllerAddedEvent = delegate
		{
		};

		public event Action<int> ControllerRemovedEvent = delegate
		{
		};

		internal RewiredPlayerInput(int playerId)
			: this(playerId, null)
		{
		}

		internal RewiredPlayerInput(int playerId, Rewired.Components.PlayerMouse playerMouse)
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
			ReInput_PreShutDownEvent();
			this.ControllerAddedEvent = null;
			this.ControllerRemovedEvent = null;
			inputEventCache.Clear();
			activeControllerEventCache.Clear();
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback)
		{
			inputEventCache.Add(callback);
			player?.AddInputEventDelegate(callback, UpdateLoopType.Update);
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
		{
			inputEventCache.Remove(callback);
			player?.RemoveInputEventDelegate(callback, UpdateLoopType.Update);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
			if (actionId >= 0)
			{
				inputEventCache.Add(callback, actionId);
				player?.AddInputEventDelegate(callback, UpdateLoopType.Update, actionId);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
			if (actionId >= 0)
			{
				inputEventCache.Remove(callback, actionId);
				player?.RemoveInputEventDelegate(callback, UpdateLoopType.Update, actionId);
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
			inputEventCache.Add(callback, eventType);
			player?.AddInputEventDelegate(callback, UpdateLoopType.Update, eventType);
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
			inputEventCache.Remove(callback, eventType);
			player?.RemoveInputEventDelegate(callback, UpdateLoopType.Update, eventType);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
			if (actionId >= 0)
			{
				inputEventCache.Add(callback, eventType, actionId);
				player?.AddInputEventDelegate(callback, UpdateLoopType.Update, eventType, actionId);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
			if (actionId >= 0)
			{
				inputEventCache.Remove(callback, eventType, actionId);
				player?.RemoveInputEventDelegate(callback, UpdateLoopType.Update, eventType, actionId);
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId, params object[] args)
		{
			if (actionId >= 0)
			{
				inputEventCache.Add(callback, eventType, actionId);
				player?.AddInputEventDelegate(callback, UpdateLoopType.Update, eventType, actionId, args);
			}
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
			if (player == null || !enable)
			{
				return false;
			}
			return player.GetButtonPrev(actionId);
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
			activeControllerEventCache.Add(callback);
			player?.controllers.AddLastActiveControllerChangedDelegate(callback, controllerType);
		}

		public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
		{
			activeControllerEventCache.Remove(callback);
			player?.controllers.RemoveLastActiveControllerChangedDelegate(callback, controllerType);
		}

		public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
		{
			activeControllerEventCache.Add(callback);
			player?.controllers.AddLastActiveControllerChangedDelegate(callback);
		}

		public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
		{
			activeControllerEventCache.Remove(callback);
			player?.controllers.RemoveLastActiveControllerChangedDelegate(callback);
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
			if (player == null)
			{
				Debug.LogException(new Exception(string.Format("[{0}] Failed to get player with ID {1}.", "RewiredPlayerInput", playerId) + $" ReInput.isReady={ReInput.isReady}"));
			}
			foreach (Action<InputActionEventData> @event in inputEventCache.events)
			{
				player.AddInputEventDelegate(@event, UpdateLoopType.Update);
			}
			foreach (KeyValuePair<int, List<Action<InputActionEventData>>> actionEvent in inputEventCache.actionEvents)
			{
				foreach (Action<InputActionEventData> item in actionEvent.Value)
				{
					player.AddInputEventDelegate(item, UpdateLoopType.Update, actionEvent.Key);
				}
			}
			foreach (KeyValuePair<InputActionEventType, List<Action<InputActionEventData>>> typeEvent in inputEventCache.typeEvents)
			{
				foreach (Action<InputActionEventData> item2 in typeEvent.Value)
				{
					player.AddInputEventDelegate(item2, UpdateLoopType.Update, typeEvent.Key);
				}
			}
			foreach (KeyValuePair<InputEventTest.EventKey, List<Action<InputActionEventData>>> typeAndActionEvent in inputEventCache.typeAndActionEvents)
			{
				foreach (Action<InputActionEventData> item3 in typeAndActionEvent.Value)
				{
					player.AddInputEventDelegate(item3, UpdateLoopType.Update, typeAndActionEvent.Key.eventType, typeAndActionEvent.Key.actionId);
				}
			}
			foreach (PlayerActiveControllerChangedDelegate event2 in activeControllerEventCache.events)
			{
				player?.controllers.AddLastActiveControllerChangedDelegate(event2);
			}
			foreach (KeyValuePair<ControllerType, HashSet<PlayerActiveControllerChangedDelegate>> typeEvent2 in activeControllerEventCache.typeEvents)
			{
				foreach (PlayerActiveControllerChangedDelegate item4 in typeEvent2.Value)
				{
					player?.controllers.AddLastActiveControllerChangedDelegate(item4, typeEvent2.Key);
				}
			}
			player.controllers.ControllerAddedEvent += Controllers_ControllerAddedEvent;
			player.controllers.ControllerRemovedEvent += Controllers_ControllerRemovedEvent;
			ReInput.ControllerConnectedEvent += ResolveOnControllerConnectedEvent;
			ReInput.ControllerDisconnectedEvent += ResolveOnControllerDisconnectedEvent;
		}

		private void ReInput_PreShutDownEvent()
		{
			if (player != null)
			{
				foreach (Action<InputActionEventData> @event in inputEventCache.events)
				{
					player.RemoveInputEventDelegate(@event, UpdateLoopType.Update);
				}
				foreach (KeyValuePair<int, List<Action<InputActionEventData>>> actionEvent in inputEventCache.actionEvents)
				{
					foreach (Action<InputActionEventData> item in actionEvent.Value)
					{
						player.RemoveInputEventDelegate(item, UpdateLoopType.Update, actionEvent.Key);
					}
				}
				foreach (KeyValuePair<InputActionEventType, List<Action<InputActionEventData>>> typeEvent in inputEventCache.typeEvents)
				{
					foreach (Action<InputActionEventData> item2 in typeEvent.Value)
					{
						player.RemoveInputEventDelegate(item2, UpdateLoopType.Update, typeEvent.Key);
					}
				}
				foreach (KeyValuePair<InputEventTest.EventKey, List<Action<InputActionEventData>>> typeAndActionEvent in inputEventCache.typeAndActionEvents)
				{
					foreach (Action<InputActionEventData> item3 in typeAndActionEvent.Value)
					{
						player.RemoveInputEventDelegate(item3, UpdateLoopType.Update, typeAndActionEvent.Key.eventType, typeAndActionEvent.Key.actionId);
					}
				}
				foreach (PlayerActiveControllerChangedDelegate event2 in activeControllerEventCache.events)
				{
					player?.controllers.RemoveLastActiveControllerChangedDelegate(event2);
				}
				foreach (KeyValuePair<ControllerType, HashSet<PlayerActiveControllerChangedDelegate>> typeEvent2 in activeControllerEventCache.typeEvents)
				{
					foreach (PlayerActiveControllerChangedDelegate item4 in typeEvent2.Value)
					{
						player?.controllers.RemoveLastActiveControllerChangedDelegate(item4, typeEvent2.Key);
					}
				}
				player.controllers.ControllerAddedEvent -= Controllers_ControllerAddedEvent;
				player.controllers.ControllerRemovedEvent -= Controllers_ControllerRemovedEvent;
			}
			ReInput.ControllerConnectedEvent -= ResolveOnControllerConnectedEvent;
			ReInput.ControllerDisconnectedEvent -= ResolveOnControllerDisconnectedEvent;
			player = null;
		}

		private void Controllers_ControllerAddedEvent(ControllerAssignmentChangedEventArgs args)
		{
			this.ControllerAddedEvent?.Invoke(args.controller.id);
		}

		private void Controllers_ControllerRemovedEvent(ControllerAssignmentChangedEventArgs args)
		{
			this.ControllerRemovedEvent?.Invoke(args.controller.id);
		}

		private void ResolveOnControllerConnectedEvent(ControllerStatusChangedEventArgs args)
		{
			this.ControllerAddedEvent?.Invoke(args.controller.id);
		}

		private void ResolveOnControllerDisconnectedEvent(ControllerStatusChangedEventArgs args)
		{
			int obj = -1;
			if (args != null)
			{
				obj = args.controllerId;
			}
			this.ControllerRemovedEvent?.Invoke(obj);
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
