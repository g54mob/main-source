using System;
using System.Collections.Generic;
using Platforms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
	public abstract class BaseInputSource : IInputSource
	{
		private InputLock _GlobalLock = new InputLock();

		protected bool GameHasFocus;

		protected List<IInputConsumer> InputConsumers = new List<IInputConsumer>();

		protected Dictionary<int, PlayerData> Players = new Dictionary<int, PlayerData>();

		public InputLock GlobalLock => _GlobalLock;

		public event EventHandler<InputUpdateEvent> OnInputUpdate = delegate
		{
		};

		public event Action<int, string> OnBindingChange = delegate
		{
		};

		protected void TriggerInputUpdate(InputUpdateEvent evt)
		{
			this.OnInputUpdate(null, evt);
		}

		public virtual void Setup(bool register_as_default = true)
		{
			if (register_as_default)
			{
				InputSourceIdentifier.DefaultInputSource = this;
			}
		}

		public virtual void Destroy()
		{
		}

		public virtual void Update()
		{
			if (Platform.Current != null)
			{
				if (GameHasFocus != Platform.Current.GameHasFocus)
				{
					ResetInputs();
				}
				GameHasFocus = Platform.Current.GameHasFocus;
			}
		}

		public void MakeRequest(int player, GameStateRequest request)
		{
			GetCurrentInputData(player, out var input_state);
			input_state.Request = request;
			this.OnInputUpdate(null, new InputUpdateEvent
			{
				User = player,
				State = input_state
			});
		}

		public InputLock.Lock SetInputLock(int player, PlayerLockState type)
		{
			if (Players.TryGetValue(player, out var value))
			{
				return value.Lock.NewLock(type);
			}
			return default(InputLock.Lock);
		}

		public void ReleaseLock(int player, InputLock.Lock input_lock)
		{
			if (Players.TryGetValue(player, out var value))
			{
				value.Lock.ReleaseLock(input_lock);
			}
		}

		public InputLock.Lock SetLock(PlayerLockState type)
		{
			return GlobalLock.NewLock(type);
		}

		public void ReleaseLock(InputLock.Lock input_lock)
		{
			GlobalLock.ReleaseLock(input_lock);
		}

		public bool IsValidLock(InputLock.Lock input_lock)
		{
			return GlobalLock.HasLock(input_lock);
		}

		public int GetMenuRequester()
		{
			foreach (KeyValuePair<int, PlayerData> player in Players)
			{
				if (player.Value.InputState.MenuTrigger == ButtonState.Pressed)
				{
					return player.Key;
				}
			}
			return 0;
		}

		public void DisconnectedPlayers(List<int> players)
		{
			players.Clear();
			foreach (KeyValuePair<int, PlayerData> player in Players)
			{
				if (player.Value.InputData.Device == null || !player.Value.InputData.Device.added)
				{
					players.Add(player.Key);
				}
			}
		}

		public bool IsPlayerDisconnected(int player)
		{
			if (Players.TryGetValue(player, out var value))
			{
				if (value.InputData.Device != null)
				{
					return !value.InputData.Device.added;
				}
				return true;
			}
			return false;
		}

		public bool AnyPlayerPressingMenu()
		{
			foreach (KeyValuePair<int, PlayerData> player in Players)
			{
				if (player.Value.InputState.MenuTrigger == ButtonState.Pressed || player.Value.InputState.MenuTrigger == ButtonState.Held)
				{
					return true;
				}
			}
			return false;
		}

		public Vector2 GetMousePosition()
		{
			if (Mouse.current != null)
			{
				return Mouse.current.position.ReadValue();
			}
			return Vector2.zero;
		}

		public bool GetCurrentInputData(int player_id, out InputState input_state, InputLock.Lock input_lock = default(InputLock.Lock))
		{
			input_state = default(InputState);
			if (Players.TryGetValue(player_id, out var value))
			{
				if ((input_lock.Type == PlayerLockState.PauseAndLockMenu || !GlobalLock.IsLocked) && !value.Lock.IsLockedFor(input_lock))
				{
					input_state = value.InputState;
					return true;
				}
				return true;
			}
			return false;
		}

		public ControllerType GetCurrentController(int player_id)
		{
			if (Players.TryGetValue(player_id, out var value))
			{
				return value.ControllerType;
			}
			return ControllerType.None;
		}

		public ControllerType GetAllLocalControllers()
		{
			ControllerType controllerType = ControllerType.None;
			foreach (KeyValuePair<int, PlayerData> player in Players)
			{
				controllerType |= player.Value.ControllerType;
			}
			return controllerType;
		}

		public Dictionary<int, ControllerType> GetLocalPlayerControllersDebug()
		{
			Dictionary<int, ControllerType> dictionary = new Dictionary<int, ControllerType>();
			foreach (KeyValuePair<int, PlayerData> player in Players)
			{
				dictionary.Add(player.Key, player.Value.ControllerType);
			}
			return dictionary;
		}

		protected void HandleBindingChange(int i, string a)
		{
			this.OnBindingChange(i, a);
		}

		public virtual string GetBindingString(int player)
		{
			return "";
		}

		public virtual void SetBindingString(int player, string json)
		{
		}

		public virtual void ClearBindings(int player)
		{
		}

		public void ResetInputs()
		{
			foreach (InputDevice device in InputSystem.devices)
			{
				InputSystem.ResetDevice(device);
			}
		}

		public virtual bool CanPerformRebinding(int player)
		{
			return false;
		}

		public virtual void RequestRebinding(int player, string action_name, Action<RebindResult> callback)
		{
			Debug.LogError("Rebinding is not implemented by BaseInputSource");
		}

		public virtual string GetBindingName(int player, string action_name)
		{
			Debug.LogError("Rebinding is not implemented by BaseInputSource");
			return "?";
		}
	}
}
