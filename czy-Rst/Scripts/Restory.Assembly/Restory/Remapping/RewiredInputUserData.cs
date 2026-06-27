using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Remapping;
using Restory.Data.SaveLoad.Containers;
using Restory.Gameplay.GameSettings;
using Restory.Gameplay.PlayerInput.Observers;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Remapping
{
	public class RewiredInputUserData : MonoBehaviour, IInputUserData
	{
		[Serializable]
		private class InputData
		{
			[SerializeField]
			private Dictionary<int, PlayerData> players = new Dictionary<int, PlayerData>();

			public Dictionary<int, PlayerData> Players => players;

			public bool TryGetControllerData(int playerId, ControllerType controllerType, int controllerId, out ControllerData controllerData)
			{
				if (!players.TryGetValue(playerId, out var value))
				{
					controllerData = null;
					return false;
				}
				return value.TryGetControllerData(controllerType, controllerId, out controllerData);
			}

			public void SetControllerData(int playerId, ControllerType controllerType, int controllerId, ControllerData controllerData)
			{
				if (!players.TryGetValue(playerId, out var value))
				{
					value = (players[playerId] = new PlayerData());
				}
				value.SetControllerData(controllerType, controllerId, controllerData);
			}

			public static InputData CreateFromSaveData(InputSaveData saveData)
			{
				InputData inputData = new InputData();
				foreach (KeyValuePair<int, InputSaveData.PlayerData> player in saveData.Players)
				{
					inputData.players[player.Key] = PlayerData.CreateFromSaveData(player.Value);
				}
				return inputData;
			}

			public static InputSaveData ToSaveData(InputData data)
			{
				InputSaveData inputSaveData = new InputSaveData();
				foreach (KeyValuePair<int, PlayerData> player in data.Players)
				{
					inputSaveData.Players[player.Key] = PlayerData.ToSaveData(player.Value);
				}
				return inputSaveData;
			}

			public static bool operator ==(InputData obj1, InputData obj2)
			{
				if (obj1.players.Count == obj2.players.Count)
				{
					return obj1.players.Keys.All((int player1) => obj2.players.ContainsKey(player1) && obj1.players[player1] == obj2.players[player1]);
				}
				return false;
			}

			public static bool operator !=(InputData obj1, InputData obj2)
			{
				return !(obj1 == obj2);
			}

			public override bool Equals(object obj)
			{
				if (obj == null)
				{
					return false;
				}
				if (!(obj is InputData inputData))
				{
					return false;
				}
				return this == inputData;
			}

			public override int GetHashCode()
			{
				return players.GetHashCode();
			}
		}

		[Serializable]
		private class PlayerData
		{
			[SerializeField]
			private Dictionary<ControllerType, ControllersData> controllers = new Dictionary<ControllerType, ControllersData>();

			public Dictionary<ControllerType, ControllersData> Controllers => controllers;

			public bool TryGetControllerData(ControllerType controllerType, int controllerId, out ControllerData controllerData)
			{
				if (!controllers.TryGetValue(controllerType, out var value))
				{
					controllerData = null;
					return false;
				}
				return value.TryGetControllerData(controllerId, out controllerData);
			}

			public void SetControllerData(ControllerType controllerType, int controllerId, ControllerData controllerData)
			{
				if (!controllers.TryGetValue(controllerType, out var value))
				{
					value = (controllers[controllerType] = new ControllersData());
				}
				value.SetControllerData(controllerId, controllerData);
			}

			public static PlayerData CreateFromSaveData(InputSaveData.PlayerData saveData)
			{
				PlayerData playerData = new PlayerData();
				foreach (KeyValuePair<ControllerType, InputSaveData.ControllersData> controller in saveData.Controllers)
				{
					playerData.controllers[controller.Key] = ControllersData.CreateFromSaveData(controller.Value);
				}
				return playerData;
			}

			public static InputSaveData.PlayerData ToSaveData(PlayerData data)
			{
				InputSaveData.PlayerData playerData = new InputSaveData.PlayerData();
				foreach (KeyValuePair<ControllerType, ControllersData> controller in data.Controllers)
				{
					playerData.Controllers[controller.Key] = ControllersData.ToSaveData(controller.Value);
				}
				return playerData;
			}

			public static bool operator ==(PlayerData obj1, PlayerData obj2)
			{
				if (obj1.controllers.Count == obj2.controllers.Count)
				{
					return obj1.controllers.Keys.All((ControllerType player1) => obj2.controllers.ContainsKey(player1) && obj1.controllers[player1] == obj2.controllers[player1]);
				}
				return false;
			}

			public static bool operator !=(PlayerData obj1, PlayerData obj2)
			{
				return !(obj1 == obj2);
			}

			public override bool Equals(object obj)
			{
				if (obj == null)
				{
					return false;
				}
				if (!(obj is PlayerData playerData))
				{
					return false;
				}
				return this == playerData;
			}

			public override int GetHashCode()
			{
				return controllers.GetHashCode();
			}
		}

		[Serializable]
		private class ControllersData
		{
			[SerializeField]
			private Dictionary<int, ControllerData> controllers = new Dictionary<int, ControllerData>();

			public IReadOnlyDictionary<int, ControllerData> Controllers => controllers;

			public bool TryGetControllerData(int controllerId, out ControllerData controllerData)
			{
				return controllers.TryGetValue(controllerId, out controllerData);
			}

			public void SetControllerData(int controllerId, ControllerData controllerData)
			{
				controllers[controllerId] = controllerData;
			}

			public static ControllersData CreateFromSaveData(InputSaveData.ControllersData saveData)
			{
				ControllersData controllersData = new ControllersData();
				foreach (KeyValuePair<int, InputSaveData.ControllerData> controller in saveData.Controllers)
				{
					controllersData.controllers[controller.Key] = ControllerData.CreateFromSaveData(controller.Value);
				}
				return controllersData;
			}

			public static InputSaveData.ControllersData ToSaveData(ControllersData data)
			{
				InputSaveData.ControllersData controllersData = new InputSaveData.ControllersData();
				foreach (KeyValuePair<int, ControllerData> controller in data.Controllers)
				{
					controllersData.Controllers[controller.Key] = ControllerData.ToSaveData(controller.Value);
				}
				return controllersData;
			}

			public static bool operator ==(ControllersData obj1, ControllersData obj2)
			{
				if (obj1.controllers.Count == obj2.controllers.Count)
				{
					return obj1.controllers.Keys.All((int player1) => obj2.controllers.ContainsKey(player1) && obj1.controllers[player1] == obj2.controllers[player1]);
				}
				return false;
			}

			public static bool operator !=(ControllersData obj1, ControllersData obj2)
			{
				return !(obj1 == obj2);
			}

			public override bool Equals(object obj)
			{
				if (obj == null)
				{
					return false;
				}
				if (!(obj is ControllersData controllersData))
				{
					return false;
				}
				return this == controllersData;
			}

			public override int GetHashCode()
			{
				return controllers.GetHashCode();
			}
		}

		[Serializable]
		private class ControllerData
		{
			[SerializeField]
			private Dictionary<InputButtonIdentifier, InputButtonData> inputButtons = new Dictionary<InputButtonIdentifier, InputButtonData>();

			public IReadOnlyDictionary<InputButtonIdentifier, InputButtonData> InputButtons => inputButtons;

			public bool TryGetInputButtonData(InputButtonIdentifier buttonIdentifier, out InputButtonData inputButtonData)
			{
				return inputButtons.TryGetValue(buttonIdentifier, out inputButtonData);
			}

			public void SetInputActionData(InputButtonIdentifier buttonIdentifier, InputButtonData inputButtonData)
			{
				inputButtons[buttonIdentifier] = inputButtonData;
			}

			public static ControllerData CreateFromSaveData(InputSaveData.ControllerData saveData)
			{
				return new ControllerData
				{
					inputButtons = new Dictionary<InputButtonIdentifier, InputButtonData>(saveData.InputButtons)
				};
			}

			public static InputSaveData.ControllerData ToSaveData(ControllerData data)
			{
				return new InputSaveData.ControllerData
				{
					InputButtons = new Dictionary<InputButtonIdentifier, InputButtonData>(data.inputButtons)
				};
			}

			public static bool operator ==(ControllerData obj1, ControllerData obj2)
			{
				if (obj1.inputButtons.Count == obj2.inputButtons.Count)
				{
					return obj1.inputButtons.Keys.All((InputButtonIdentifier player1) => obj2.inputButtons.ContainsKey(player1) && obj1.inputButtons[player1] == obj2.inputButtons[player1]);
				}
				return false;
			}

			public static bool operator !=(ControllerData obj1, ControllerData obj2)
			{
				return !(obj1 == obj2);
			}

			public override bool Equals(object obj)
			{
				if (obj == null)
				{
					return false;
				}
				if (!(obj is ControllerData controllerData))
				{
					return false;
				}
				return this == controllerData;
			}

			public override int GetHashCode()
			{
				return inputButtons.GetHashCode();
			}
		}

		[SerializeField]
		private RemappingButtonsList remappingButtons;

		[SerializeField]
		private ActionsRewiredDependencyMap dependencyMap;

		[Tooltip("Should saved data be loaded on start?")]
		[SerializeField]
		private bool loadDataOnStart = true;

		private GameSettingsDataSaveLoadSystem saveLoadSystem;

		private RewiredInitializedObserver initializedObserver;

		private InputData inputData = new InputData();

		private InputData defaultInputData = new InputData();

		public RemappingButtonsList RemappingButtonsList => remappingButtons;

		public ActionsRewiredDependencyMap ActionsDependencyMap => dependencyMap;

		public bool LoadDataOnStart
		{
			get
			{
				return loadDataOnStart;
			}
			set
			{
				loadDataOnStart = value;
			}
		}

		[Inject]
		private void Construct(GameSettingsDataSaveLoadSystem saveLoadSystem, RewiredInitializedObserver initializedObserver)
		{
			this.saveLoadSystem = saveLoadSystem;
			this.initializedObserver = initializedObserver;
		}

		private void Awake()
		{
			initializedObserver.AddSubscriber(this, ReInput_InitializedEvent);
			if (initializedObserver.IsReady)
			{
				ReInput_InitializedEvent();
			}
		}

		private void OnDestroy()
		{
			initializedObserver.RemoveSubscriber(this);
		}

		private void ReInput_InitializedEvent()
		{
			UpdateDefaultInputData();
			if (loadDataOnStart)
			{
				Load();
			}
		}

		public bool IsDefault()
		{
			return inputData == defaultInputData;
		}

		public void LoadDefault()
		{
			inputData = defaultInputData;
			RewiredSetUserData(inputData);
			UpdateInputData();
		}

		public async void Load()
		{
			InputSaveData inputSaveData = await saveLoadSystem.LoadInputUserData<InputSaveData>();
			InputData inputData = ((inputSaveData != null) ? InputData.CreateFromSaveData(inputSaveData) : defaultInputData);
			RewiredSetUserData(inputData);
			UpdateInputData();
		}

		public async void Save()
		{
			InputSaveData data = InputData.ToSaveData(inputData);
			await saveLoadSystem.SaveInputUserData(data);
		}

		private void UpdateInputData()
		{
			RewiredGetUserData(out var inputData);
			this.inputData = inputData;
		}

		private void UpdateDefaultInputData()
		{
			RewiredGetUserData(out var inputData);
			defaultInputData = inputData;
		}

		public string GetButtonName(int playerId, ControllerType controllerType, int controllerId, Restory.Data.Remapping.InputAction action, AxisRange axisRange)
		{
			if (dependencyMap.GetRewiredFirstActionElementMap(playerId, controllerType, controllerId, action, axisRange, out var actionElementMap))
			{
				return actionElementMap.elementIdentifierName;
			}
			return string.Empty;
		}

		public bool TryGetInputButtonData(int playerId, ControllerType controllerType, int controllerId, Restory.Data.Remapping.InputAction action, AxisRange axisRange, out InputButtonData inputButtonData)
		{
			InputButtonIdentifier buttonIdentifier = new InputButtonIdentifier
			{
				ActionId = action.Id,
				AxisRange = axisRange
			};
			inputButtonData = default(InputButtonData);
			if (!inputData.TryGetControllerData(playerId, controllerType, controllerId, out var controllerData))
			{
				return false;
			}
			return controllerData.TryGetInputButtonData(buttonIdentifier, out inputButtonData);
		}

		public void SetInputButtonData(int playerId, ControllerType controllerType, int controllerId, Restory.Data.Remapping.InputAction action, AxisRange axisRange, InputButtonData inputButtonData)
		{
			if (dependencyMap.SetRewiredInputButtonData(playerId, controllerType, controllerId, action, axisRange, inputButtonData))
			{
				InputButtonIdentifier buttonIdentifier = new InputButtonIdentifier
				{
					ActionId = action.Id,
					AxisRange = axisRange
				};
				if (!inputData.TryGetControllerData(playerId, controllerType, controllerId, out var controllerData))
				{
					controllerData = new ControllerData();
					inputData.SetControllerData(playerId, controllerType, controllerId, controllerData);
				}
				controllerData.SetInputActionData(buttonIdentifier, inputButtonData);
			}
		}

		public bool CheckConflict(int playerId, ControllerType controllerType, int controllerId, Restory.Data.Remapping.InputAction action, AxisRange axisRange)
		{
			InputButtonIdentifier inputButtonIdentifier = new InputButtonIdentifier
			{
				ActionId = action.Id,
				AxisRange = axisRange
			};
			if (!inputData.TryGetControllerData(playerId, controllerType, controllerId, out var controllerData))
			{
				return false;
			}
			if (!controllerData.TryGetInputButtonData(inputButtonIdentifier, out var inputButtonData))
			{
				return false;
			}
			foreach (KeyValuePair<InputButtonIdentifier, InputButtonData> inputButton in controllerData.InputButtons)
			{
				if (inputButton.Key != inputButtonIdentifier && inputButton.Value == inputButtonData)
				{
					return true;
				}
			}
			return false;
		}

		private void RewiredGetUserData(out InputData inputData)
		{
			inputData = new InputData();
			foreach (Player allPlayer in ReInput.players.AllPlayers)
			{
				if (RewiredGetPlayerData(allPlayer, out var playerData))
				{
					inputData.Players.Add(allPlayer.id, playerData);
				}
			}
		}

		private bool RewiredGetPlayerData(Player player, out PlayerData playerData)
		{
			int num = 0;
			playerData = new PlayerData();
			if (RewiredGetKeyboardData(player.id, out var controllersData))
			{
				playerData.Controllers.Add(ControllerType.Keyboard, controllersData);
				num++;
			}
			return num > 0;
		}

		private bool RewiredGetKeyboardData(int playerId, out ControllersData controllersData)
		{
			if (RewiredGetControllerData(playerId, ControllerType.Keyboard, 0, out var controllerData))
			{
				controllersData = new ControllersData();
				controllersData.SetControllerData(0, controllerData);
				return true;
			}
			controllersData = null;
			return false;
		}

		private bool RewiredGetControllerData(int playerId, ControllerType controllerType, int controllerId, out ControllerData controllerData)
		{
			controllerData = new ControllerData();
			int num = 0;
			if (remappingButtons.TryGetRemappingButtons(controllerType, out var buttons))
			{
				foreach (RemappingButton item in buttons)
				{
					if (dependencyMap.GetRewiredInputButtonData(playerId, controllerType, controllerId, item.Action, item.AxisRange, out var inputButtonData))
					{
						InputButtonIdentifier buttonIdentifier = new InputButtonIdentifier
						{
							ActionId = item.Action.Id,
							AxisRange = item.AxisRange
						};
						controllerData.SetInputActionData(buttonIdentifier, inputButtonData);
						num++;
					}
				}
			}
			return num > 0;
		}

		private bool RewiredSetUserData(InputData inputData)
		{
			int num = 0;
			foreach (Player allPlayer in ReInput.players.AllPlayers)
			{
				if (inputData.Players.TryGetValue(allPlayer.id, out var value) && RewiredSetPlayerData(allPlayer.id, value))
				{
					num++;
				}
			}
			return num > 0;
		}

		private bool RewiredSetPlayerData(int playerId, PlayerData playerData)
		{
			if (!playerData.Controllers.TryGetValue(ControllerType.Keyboard, out var value))
			{
				return false;
			}
			return RewiredSetKeyboardData(playerId, value);
		}

		private bool RewiredSetKeyboardData(int playerId, ControllersData controllersData)
		{
			if (!controllersData.Controllers.TryGetValue(0, out var value))
			{
				return false;
			}
			return RewiredSetControllerData(playerId, ControllerType.Keyboard, 0, value);
		}

		private bool RewiredSetControllerData(int playerId, ControllerType controllerType, int controllerId, ControllerData controllerData)
		{
			if (!remappingButtons.TryGetRemappingButtons(controllerType, out var buttons))
			{
				return false;
			}
			int num = 0;
			foreach (RemappingButton item in buttons)
			{
				InputButtonIdentifier buttonIdentifier = new InputButtonIdentifier
				{
					ActionId = item.Action.Id,
					AxisRange = item.AxisRange
				};
				if (controllerData.TryGetInputButtonData(buttonIdentifier, out var inputButtonData) && dependencyMap.SetRewiredInputButtonData(playerId, controllerType, controllerId, item.Action, item.AxisRange, inputButtonData))
				{
					num++;
				}
			}
			return num > 0;
		}
	}
}
