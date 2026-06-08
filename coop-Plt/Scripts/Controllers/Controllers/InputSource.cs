using System;
using System.Collections.Generic;
using System.Linq;
using Platforms;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.Utilities;

namespace Controllers
{
	public class InputSource : BaseInputSource
	{
		protected struct CachedState
		{
			public InputState State;

			public float Time;
		}

		public HashSet<int> RejectedDevices;

		protected Dictionary<int, CachedState> StateCache = new Dictionary<int, CachedState>();

		private bool IsAddingDevice;

		private Dictionary<InputActionMap, Func<InputActionMap>> ActionMaps;

		private List<IInputConsumer> Consumers = new List<IInputConsumer>();

		public bool _UseAlternateControllerLayout;

		private HashSet<int> ActHoldUsersCurrentlyHolding = new HashSet<int>();

		public override void Setup(bool register_as_default = true)
		{
			base.Setup(register_as_default);
			ActionMaps = new Dictionary<InputActionMap, Func<InputActionMap>>
			{
				{
					Maps.NewGamepad(InputSourceIdentifier.UseAlternateControllerLayout),
					() => Maps.NewGamepad(InputSourceIdentifier.UseAlternateControllerLayout)
				},
				{
					Maps.NewKeyboard(),
					Maps.NewKeyboard
				}
			};
			RejectedDevices = new HashSet<int>();
			InputSystem.onDeviceChange += OnDeviceChange;
			InputUser.listenForUnpairedDeviceActivity = 4;
			InputUser.onUnpairedDeviceUsed += NewDeviceUsed;
			Players = new Dictionary<int, PlayerData>();
			foreach (InputUser item in InputUser.all)
			{
				if (item.valid)
				{
					item.UnpairDevicesAndRemoveUser();
				}
			}
			InputSourceIdentifier.DefaultInputSource = this;
			Platform.OnUserSignOut += OnPlatformUserSignOut;
		}

		public void SetActHoldMode(int player_id, bool mode_active)
		{
			if (Players.TryGetValue(player_id, out var value))
			{
				value.IsActHoldUser = mode_active;
			}
		}

		private void OnDeviceChange(InputDevice device, InputDeviceChange event_type)
		{
			Platform.Current.HandleControllerEvent(device, event_type);
		}

		public override void Destroy()
		{
			base.Destroy();
			foreach (InputUser item in InputUser.all)
			{
				if (item.valid)
				{
					item.UnpairDevicesAndRemoveUser();
				}
			}
			InputUser.onUnpairedDeviceUsed -= NewDeviceUsed;
			InputSystem.onDeviceChange -= OnDeviceChange;
		}

		public void ConsumeAllInputs()
		{
			foreach (KeyValuePair<int, PlayerData> player in Players)
			{
				player.Value.InputState = InputState.Consumed;
			}
		}

		public override void Update()
		{
			base.Update();
			if (InputSourceIdentifier.UseAlternateControllerLayout != _UseAlternateControllerLayout)
			{
				_UseAlternateControllerLayout = InputSourceIdentifier.UseAlternateControllerLayout;
				UpdateControllerMaps();
			}
			bool gameHasFocus = Platform.Current.GameHasFocus;
			using Dictionary<int, PlayerData>.KeyCollection.Enumerator enumerator = Players.Keys.GetEnumerator();
			PlayerData playerData;
			InputState inputState2;
			for (; enumerator.MoveNext(); playerData.InputState = inputState2)
			{
				int current = enumerator.Current;
				playerData = Players[current];
				UserInputData inputData = playerData.InputData;
				InputState inputState = playerData.InputState;
				inputState2 = GetData(inputData.Map, inputState);
				bool flag = false;
				if (gameHasFocus)
				{
					foreach (IInputConsumer item in LocalInputSourceConsumers.Consumers.CopyTo(Consumers, reverse: true))
					{
						InputConsumerState inputConsumerState = item.TakeInput(current, inputState2);
						if (inputConsumerState != InputConsumerState.NotConsumed)
						{
							flag = true;
							if (inputConsumerState == InputConsumerState.Terminated)
							{
								inputState2 = InputState.Consumed;
							}
							break;
						}
					}
				}
				else
				{
					flag = true;
					inputState2 = InputState.Neutral;
				}
				if (!flag && !base.GlobalLock.IsLocked && !playerData.Lock.IsLocked)
				{
					ReadOnlyArray<InputDevice>? devices = inputData.Map.devices;
					if (devices.HasValue && devices.GetValueOrDefault().Count > 0)
					{
						SetInputUpdate(current, playerData.IsActHoldUser, inputState2);
						continue;
					}
				}
				InputState neutral = InputState.Neutral;
				neutral.Request = ((playerData.Lock.LockState >= PlayerLockState.PauseAll || base.GlobalLock.LockState >= PlayerLockState.PauseAll) ? GameStateRequest.InLocalMenu : GameStateRequest.None);
				SetInputUpdate(current, playerData.IsActHoldUser, neutral);
			}
		}

		private void UpdateControllerMaps()
		{
			foreach (KeyValuePair<int, PlayerData> player in Players)
			{
				KeyValuePair<InputActionMap, Func<InputActionMap>> keyValuePair = ActionMaps.FirstOrDefault((KeyValuePair<InputActionMap, Func<InputActionMap>> m) => m.Key.IsUsableWithDevice(player.Value.InputData.Device));
				if (keyValuePair.Key != null)
				{
					player.Value.InputData.Map.Disable();
					player.Value.InputData.Map = keyValuePair.Value();
					player.Value.InputData.Map.Enable();
					player.Value.InputData.User.AssociateActionsWithUser(player.Value.InputData.Map);
					HandleBindingChange(player.Key, "");
				}
			}
		}

		public PlatformUser GetPlatformUser(int input_id)
		{
			if (Players.TryGetValue(input_id, out var value))
			{
				return value.User;
			}
			return default(PlatformUser);
		}

		public int GetUserID(PlatformUser user)
		{
			foreach (KeyValuePair<int, PlayerData> player in Players)
			{
				if (player.Value.User == user)
				{
					return player.Key;
				}
			}
			return 0;
		}

		public void MakeRequest(PlatformUser user, GameStateRequest request)
		{
			int userID = GetUserID(user);
			if (userID != 0)
			{
				MakeRequest(userID, request);
			}
		}

		protected void SetInputUpdate(int player_id, bool act_hold_mode, InputState state)
		{
			if (act_hold_mode)
			{
				bool flag = ActHoldUsersCurrentlyHolding.Contains(player_id);
				if (state.InteractAction == ButtonState.Pressed)
				{
					if (flag)
					{
						state.InteractAction = ButtonState.Released;
						ActHoldUsersCurrentlyHolding.Remove(player_id);
					}
					else
					{
						state.InteractAction = ButtonState.Pressed;
						ActHoldUsersCurrentlyHolding.Add(player_id);
					}
				}
				else if (flag)
				{
					state.InteractAction = ButtonState.Held;
				}
			}
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (!StateCache.TryGetValue(player_id, out var value) || !(realtimeSinceStartup - value.Time < 3f) || !(state == value.State))
			{
				StateCache[player_id] = new CachedState
				{
					State = state,
					Time = realtimeSinceStartup
				};
				TriggerInputUpdate(new InputUpdateEvent
				{
					User = player_id,
					State = state
				});
			}
		}

		public override bool CanPerformRebinding(int player)
		{
			if (!Players.TryGetValue(player, out var _))
			{
				return false;
			}
			return true;
		}

		public override void RequestRebinding(int player, string action_name, Action<RebindResult> callback)
		{
			if (!Players.TryGetValue(player, out var value))
			{
				return;
			}
			InputAction inputAction = value.InputData.Map.FindAction(action_name);
			if (inputAction == null)
			{
				return;
			}
			Maps.PerformRebinding(value.InputData.Device, inputAction, delegate(RebindResult result)
			{
				if (result == RebindResult.Success)
				{
					HandleBindingChange(player, action_name);
				}
				callback(result);
			});
		}

		public override string GetBindingName(int player, string action_name)
		{
			if (!Players.TryGetValue(player, out var value))
			{
				return "?";
			}
			InputAction inputAction = value.InputData.Map.FindAction(action_name);
			if (inputAction == null)
			{
				return "?";
			}
			return Maps.GetBindingName(inputAction);
		}

		public override string GetBindingString(int player)
		{
			if (!Players.TryGetValue(player, out var value))
			{
				return "";
			}
			return Maps.SaveBindingOverridesAsJson(value.InputData.Map);
		}

		public override void SetBindingString(int player, string json)
		{
			if (json != null && Players.TryGetValue(player, out var value))
			{
				if ((value.ControllerType & ControllerType.Keyboard) != ControllerType.None)
				{
					Maps.LoadBindingOverridesFromJson(value.InputData.Map, json);
				}
				else
				{
					value.InputData.Map.RemoveAllBindingOverrides();
				}
			}
		}

		public override void ClearBindings(int player)
		{
			if (Players.TryGetValue(player, out var value))
			{
				value.InputData.Map.RemoveAllBindingOverrides();
			}
		}

		private async void AssignController(InputDevice device)
		{
			if (RejectedDevices.Contains(device.deviceId) || IsAddingDevice)
			{
				return;
			}
			ControllerType controller_type = DeriveType(device);
			if ((controller_type & ControllerType.Mouse) != ControllerType.None)
			{
				return;
			}
			PlatformUser platformUser;
			try
			{
				IsAddingDevice = true;
				platformUser = await Platform.Current.GetUserUsingDevice(device);
				if (!platformUser.IsValidUser)
				{
					return;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return;
			}
			finally
			{
				IsAddingDevice = false;
			}
			try
			{
				if (!PlatformSettings.UseAdvancedProfilesMode)
				{
					bool has_valid_user = false;
					while (!has_valid_user)
					{
						has_valid_user = true;
						foreach (KeyValuePair<int, PlayerData> player in Players)
						{
							if (player.Value.User == platformUser)
							{
								if (IsPlayerDisconnected(player.Key))
								{
									Players.Remove(player.Key);
								}
								else
								{
									has_valid_user = false;
								}
							}
						}
						if (!has_valid_user)
						{
							platformUser = await Platform.Current.RequestDeviceNewUser(device);
							if (!platformUser.IsValidUser)
							{
								return;
							}
						}
					}
				}
			}
			finally
			{
				IsAddingDevice = false;
			}
			InputActionMap inputActionMap;
			try
			{
				KeyValuePair<InputActionMap, Func<InputActionMap>> keyValuePair = ActionMaps.FirstOrDefault((KeyValuePair<InputActionMap, Func<InputActionMap>> m) => m.Key.IsUsableWithDevice(device));
				if (keyValuePair.Key == null)
				{
					return;
				}
				inputActionMap = keyValuePair.Value();
			}
			finally
			{
				RejectedDevices.Add(device.deviceId);
				IsAddingDevice = false;
			}
			InputUser user = InputUser.PerformPairingWithDevice(device);
			if (device.path == "/Keyboard")
			{
				foreach (InputDevice device2 in InputSystem.devices)
				{
					if (device2.path == "/Mouse")
					{
						InputUser.PerformPairingWithDevice(device2, user);
					}
				}
			}
			user.AssociateActionsWithUser(inputActionMap);
			int num = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			if (num == 0)
			{
				num = 1;
			}
			PrintControllerDebugInfo(device);
			inputActionMap.Enable();
			Players.Add(num, new PlayerData
			{
				User = platformUser,
				InputData = new UserInputData
				{
					Map = inputActionMap,
					Device = device,
					User = user
				},
				Lock = new InputLock(),
				ControllerType = controller_type
			});
			IsAddingDevice = false;
			Debug.Log($"Controller {device}, assigned to {num} as {controller_type}");
		}

		private void NewDeviceUsed(InputControl control, InputEventPtr event_ptr)
		{
			if (control is ButtonControl)
			{
				AssignController(control.device);
			}
		}

		private InputState GetData(InputActionMap map, InputState old)
		{
			string alternate = Controls.Interact1Crane;
			ReadOnlyArray<InputBinding> bindings = map.FindAction(Controls.Interact1Crane).bindings;
			string alternate2 = Controls.Interact2Crane;
			ReadOnlyArray<InputBinding> bindings2 = map.FindAction(Controls.Interact2Crane).bindings;
			foreach (string rebindableControl in Controls.RebindableControls)
			{
				foreach (InputBinding binding in map.FindAction(rebindableControl).bindings)
				{
					foreach (InputBinding item in bindings)
					{
						if (item.effectivePath == binding.effectivePath)
						{
							alternate = null;
							break;
						}
					}
					foreach (InputBinding item2 in bindings2)
					{
						if (item2.effectivePath == binding.effectivePath)
						{
							alternate2 = null;
							break;
						}
					}
				}
			}
			return new InputState
			{
				GrabAction = GetButtonState(map, Controls.Interact1, old.GrabAction, alternate),
				InteractAction = GetButtonState(map, Controls.Interact2, old.InteractAction, alternate2),
				SecondaryAction1 = GetButtonState(map, Controls.Interact3, old.SecondaryAction1),
				SecondaryAction2 = GetButtonState(map, Controls.Interact4, old.SecondaryAction2),
				Movement = GetMovement(map, Controls.Movement),
				StopMoving = GetButtonState(map, Controls.StopMoving, old.StopMoving),
				MenuTrigger = GetButtonState(map, Controls.MenuTrigger, old.MenuTrigger),
				MenuUp = GetButtonState(map, Controls.MenuUp, old.MenuUp),
				MenuDown = GetButtonState(map, Controls.MenuDown, old.MenuDown),
				MenuLeft = GetButtonState(map, Controls.MenuLeft, old.MenuLeft),
				MenuRight = GetButtonState(map, Controls.MenuRight, old.MenuRight),
				MenuSelect = GetButtonState(map, Controls.MenuSelect, old.MenuSelect),
				MenuCancel = GetButtonState(map, Controls.MenuCancel, old.MenuCancel)
			};
		}

		private Vector2 GetMovement(InputActionMap map, string action)
		{
			return map.FindAction(action).ReadValue<Vector2>();
		}

		private ButtonState GetButtonState(InputActionMap map, string action, ButtonState old, string alternate = null)
		{
			bool flag = map.FindAction(action).ReadValue<float>() > 0.5f;
			bool flag2 = alternate != null && map.FindAction(alternate).ReadValue<float>() > 0.5f;
			flag = flag || flag2;
			if (old == ButtonState.Consumed)
			{
				if (flag)
				{
					return ButtonState.Consumed;
				}
				return ButtonState.Up;
			}
			if (flag)
			{
				if (old != ButtonState.Held && old != ButtonState.Pressed)
				{
					return ButtonState.Pressed;
				}
				return ButtonState.Held;
			}
			if (old != ButtonState.Up && old != ButtonState.Released)
			{
				return ButtonState.Released;
			}
			return ButtonState.Up;
		}

		private void PrintControllerDebugInfo(InputDevice device)
		{
			Debug.Log("Device info: " + device.description.ToJson());
		}

		private ControllerType DeriveType(InputDevice device)
		{
			return Platform.Current.GetControllerType(device);
		}

		private void OnPlatformUserSignOut(PlatformUser user)
		{
			foreach (KeyValuePair<int, PlayerData> player in Players)
			{
				if (player.Value.User != user)
				{
					continue;
				}
				MakeRequest(player.Key, GameStateRequest.Disconnect);
				foreach (InputDevice pairedDevice in player.Value.InputData.User.pairedDevices)
				{
					player.Value.InputData.User.UnpairDevice(pairedDevice);
				}
				Players.Remove(player.Key);
			}
		}
	}
}
