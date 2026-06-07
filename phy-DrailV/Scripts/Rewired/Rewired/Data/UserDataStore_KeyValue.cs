using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DV.RewiredExtensions;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	public abstract class UserDataStore_KeyValue : UserDataStore
	{
		private class ControllerAssignmentSaveInfo
		{
			public class PlayerInfo
			{
				public int id;

				public bool hasKeyboard;

				public bool hasMouse;

				public JoystickInfo[] joysticks;

				public JoystickInfo[] customControllers;

				public int joystickCount
				{
					get
					{
						if (joysticks == null)
						{
							return 0;
						}
						return joysticks.Length;
					}
				}

				public int customControllerCount
				{
					get
					{
						if (customControllers == null)
						{
							return 0;
						}
						return customControllers.Length;
					}
				}

				public int IndexOfJoystick(int joystickId)
				{
					for (int i = 0; i < joystickCount; i++)
					{
						if (joysticks[i] != null && joysticks[i].id == joystickId)
						{
							return i;
						}
					}
					return -1;
				}

				public bool ContainsJoystick(int joystickId)
				{
					return IndexOfJoystick(joystickId) >= 0;
				}
			}

			public class JoystickInfo
			{
				public Guid instanceGuid;

				public string hardwareIdentifier;

				public int id;
			}

			public PlayerInfo[] players;

			public int playerCount
			{
				get
				{
					if (players == null)
					{
						return 0;
					}
					return players.Length;
				}
			}

			public ControllerAssignmentSaveInfo()
			{
			}

			public ControllerAssignmentSaveInfo(int playerCount)
			{
				players = new PlayerInfo[playerCount];
				for (int i = 0; i < playerCount; i++)
				{
					players[i] = new PlayerInfo();
				}
			}

			public int IndexOfPlayer(int playerId)
			{
				for (int i = 0; i < playerCount; i++)
				{
					if (players[i] != null && players[i].id == playerId)
					{
						return i;
					}
				}
				return -1;
			}

			public bool ContainsPlayer(int playerId)
			{
				return IndexOfPlayer(playerId) >= 0;
			}
		}

		private class JoystickAssignmentHistoryInfo
		{
			public readonly Joystick joystick;

			public readonly int oldJoystickId;

			public JoystickAssignmentHistoryInfo(Joystick joystick, int oldJoystickId)
			{
				if (joystick == null)
				{
					throw new ArgumentNullException("joystick");
				}
				this.joystick = joystick;
				this.oldJoystickId = oldJoystickId;
			}
		}

		protected interface IDataStore
		{
			bool Save();

			bool Load();

			bool Clear();

			bool TryGetValue(string key, out object result);

			bool SetValue(string key, object value);
		}

		private static readonly string thisScriptName = typeof(UserDataStore_KeyValue).Name;

		private const string logPrefix = "Rewired: ";

		private const string key_controllerAssignments = "ControllerAssignments";

		private const int controllerMapKeyVersion = 0;

		[Tooltip("Should this script be used? If disabled, nothing will be saved or loaded.")]
		[SerializeField]
		private bool _isEnabled = true;

		[Tooltip("Should saved data be loaded on start?")]
		[SerializeField]
		private bool _loadDataOnStart = true;

		[Tooltip("Should Player Joystick assignments be saved and loaded? This is not totally reliable for all Joysticks on all platforms. Some platforms/input sources do not provide enough information to reliably save assignments from session to session and reboot to reboot.")]
		[SerializeField]
		private bool _loadJoystickAssignments = true;

		[Tooltip("Should Player Keyboard assignments be saved and loaded?")]
		[SerializeField]
		private bool _loadKeyboardAssignments = true;

		[Tooltip("Should Player Mouse assignments be saved and loaded?")]
		[SerializeField]
		private bool _loadMouseAssignments = true;

		[NonSerialized]
		private bool _allowImpreciseJoystickAssignmentMatching = true;

		[NonSerialized]
		private bool _deferredJoystickAssignmentLoadPending;

		[NonSerialized]
		private bool _wasJoystickEverDetected;

		[NonSerialized]
		private List<int> __allActionIds;

		[NonSerialized]
		private string __allActionIdsString;

		[NonSerialized]
		private readonly StringBuilder _sb = new StringBuilder();

		public bool isEnabled
		{
			get
			{
				return _isEnabled;
			}
			set
			{
				_isEnabled = value;
			}
		}

		public bool loadDataOnStart
		{
			get
			{
				return _loadDataOnStart;
			}
			set
			{
				_loadDataOnStart = value;
			}
		}

		public bool loadJoystickAssignments
		{
			get
			{
				return _loadJoystickAssignments;
			}
			set
			{
				_loadJoystickAssignments = value;
			}
		}

		public bool loadKeyboardAssignments
		{
			get
			{
				return _loadKeyboardAssignments;
			}
			set
			{
				_loadKeyboardAssignments = value;
			}
		}

		public bool loadMouseAssignments
		{
			get
			{
				return _loadMouseAssignments;
			}
			set
			{
				_loadMouseAssignments = value;
			}
		}

		protected abstract IDataStore dataStore { get; }

		private bool loadControllerAssignments
		{
			get
			{
				if (!_loadKeyboardAssignments && !_loadMouseAssignments)
				{
					return _loadJoystickAssignments;
				}
				return true;
			}
		}

		private List<int> allActionIds
		{
			get
			{
				if (__allActionIds != null)
				{
					return __allActionIds;
				}
				List<int> list = new List<int>();
				IList<InputAction> actions = ReInput.mapping.Actions;
				for (int i = 0; i < actions.Count; i++)
				{
					list.Add(actions[i].id);
				}
				__allActionIds = list;
				return list;
			}
		}

		private string allActionIdsString
		{
			get
			{
				if (!string.IsNullOrEmpty(__allActionIdsString))
				{
					return __allActionIdsString;
				}
				StringBuilder stringBuilder = new StringBuilder();
				List<int> list = allActionIds;
				for (int i = 0; i < list.Count; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(list[i]);
				}
				__allActionIdsString = stringBuilder.ToString();
				return __allActionIdsString;
			}
		}

		public override void Save()
		{
			if (!_isEnabled)
			{
				Debug.LogWarning("Rewired: " + thisScriptName + " is disabled and will not save any data.", this);
			}
			else
			{
				SaveAll();
			}
		}

		public override void SaveControllerData(int playerId, ControllerType controllerType, int controllerId)
		{
			if (!_isEnabled)
			{
				Debug.LogWarning("Rewired: " + thisScriptName + " is disabled and will not save any data.", this);
			}
			else
			{
				SaveControllerDataNow(playerId, controllerType, controllerId);
			}
		}

		public override void SaveControllerData(ControllerType controllerType, int controllerId)
		{
			if (!_isEnabled)
			{
				Debug.LogWarning("Rewired: " + thisScriptName + " is disabled and will not save any data.", this);
			}
			else
			{
				SaveControllerDataNow(controllerType, controllerId);
			}
		}

		public override void SavePlayerData(int playerId)
		{
			if (!_isEnabled)
			{
				Debug.LogWarning("Rewired: " + thisScriptName + " is disabled and will not save any data.", this);
			}
			else
			{
				SavePlayerDataNow(playerId);
			}
		}

		public override void SaveInputBehavior(int playerId, int behaviorId)
		{
			if (!_isEnabled)
			{
				Debug.LogWarning("Rewired: " + thisScriptName + " is disabled and will not save any data.", this);
			}
			else
			{
				SaveInputBehaviorNow(playerId, behaviorId);
			}
		}

		public override void Load()
		{
			if (!_isEnabled)
			{
				Debug.LogWarning("Rewired: " + thisScriptName + " is disabled and will not load any data.", this);
			}
			else
			{
				LoadAll();
			}
		}

		public override void LoadControllerData(int playerId, ControllerType controllerType, int controllerId)
		{
			if (!_isEnabled)
			{
				Debug.LogWarning("Rewired: " + thisScriptName + " is disabled and will not load any data.", this);
			}
			else
			{
				LoadControllerDataNow(playerId, controllerType, controllerId);
			}
		}

		public override void LoadControllerData(ControllerType controllerType, int controllerId)
		{
			if (!_isEnabled)
			{
				Debug.LogWarning("Rewired: " + thisScriptName + " is disabled and will not load any data.", this);
			}
			else
			{
				LoadControllerDataNow(controllerType, controllerId);
			}
		}

		public override void LoadPlayerData(int playerId)
		{
			if (!_isEnabled)
			{
				Debug.LogWarning("Rewired: " + thisScriptName + " is disabled and will not load any data.", this);
			}
			else
			{
				LoadPlayerDataNow(playerId);
			}
		}

		public override void LoadInputBehavior(int playerId, int behaviorId)
		{
			if (!_isEnabled)
			{
				Debug.LogWarning("Rewired: " + thisScriptName + " is disabled and will not load any data.", this);
			}
			else
			{
				LoadInputBehaviorNow(playerId, behaviorId);
			}
		}

		protected override void OnInitialize()
		{
			if (_loadDataOnStart)
			{
				Load();
				if (loadControllerAssignments && ReInput.controllers.joystickCount > 0)
				{
					_wasJoystickEverDetected = true;
					SaveControllerAssignments();
				}
			}
		}

		protected override void OnControllerConnected(ControllerStatusChangedEventArgs args)
		{
			if (_isEnabled && args.controllerType == ControllerType.Joystick)
			{
				LoadJoystickData(args.controllerId);
				if (_loadDataOnStart && _loadJoystickAssignments && !_wasJoystickEverDetected)
				{
					StartCoroutine(LoadJoystickAssignmentsDeferred());
				}
				if (_loadJoystickAssignments && !_deferredJoystickAssignmentLoadPending)
				{
					SaveControllerAssignments();
				}
				_wasJoystickEverDetected = true;
			}
		}

		protected override void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args)
		{
			if (_isEnabled)
			{
				if (args.controllerType == ControllerType.Joystick)
				{
					SaveJoystickData(args.controllerId);
				}
				if (args.controllerType == ControllerType.Custom)
				{
					SaveCustomControllerData(args.controllerId);
				}
			}
		}

		protected override void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
		{
			if (_isEnabled && loadControllerAssignments)
			{
				SaveControllerAssignments();
			}
		}

		public override void SaveControllerMap(int playerId, ControllerMap controllerMap)
		{
			if (controllerMap != null)
			{
				Player player = ReInput.players.GetPlayer(playerId);
				if (player != null)
				{
					SaveControllerMap(player, controllerMap);
					dataStore.Save();
				}
			}
		}

		public override ControllerMap LoadControllerMap(int playerId, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return null;
			}
			return LoadControllerMap(player, controllerIdentifier, categoryId, layoutId);
		}

		public virtual void ClearSaveData()
		{
			dataStore.Clear();
		}

		private int LoadAll()
		{
			int num = 0;
			if (loadControllerAssignments && LoadControllerAssignmentsNow())
			{
				num++;
			}
			IList<Player> allPlayers = ReInput.players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				num += LoadPlayerDataNow(allPlayers[i]);
			}
			num += LoadAllJoystickCalibrationData();
			return num + LoadAllCustomControllerCalibrationData();
		}

		private int LoadPlayerDataNow(int playerId)
		{
			return LoadPlayerDataNow(ReInput.players.GetPlayer(playerId));
		}

		private int LoadPlayerDataNow(Player player)
		{
			if (player == null)
			{
				return 0;
			}
			int num = 0;
			num += LoadInputBehaviors(player.id);
			num += LoadControllerMaps(player.id, ControllerType.Keyboard, 0);
			num += LoadControllerMaps(player.id, ControllerType.Mouse, 0);
			foreach (Joystick joystick in player.controllers.Joysticks)
			{
				num += LoadControllerMaps(player.id, ControllerType.Joystick, joystick.id);
			}
			foreach (CustomController customController in player.controllers.CustomControllers)
			{
				num += LoadControllerMaps(player.id, ControllerType.Custom, customController.id);
			}
			RefreshLayoutManager(player.id);
			return num;
		}

		private int LoadAllJoystickCalibrationData()
		{
			int num = 0;
			IList<Joystick> joysticks = ReInput.controllers.Joysticks;
			for (int i = 0; i < joysticks.Count; i++)
			{
				num += LoadJoystickCalibrationData(joysticks[i]);
			}
			return num;
		}

		private int LoadAllCustomControllerCalibrationData()
		{
			int num = 0;
			IList<CustomController> customControllers = ReInput.controllers.CustomControllers;
			for (int i = 0; i < customControllers.Count; i++)
			{
				num += LoadCustomControllerCalibrationData(customControllers[i]);
			}
			return num;
		}

		private int LoadJoystickCalibrationData(Joystick joystick)
		{
			if (joystick == null)
			{
				return 0;
			}
			if (!joystick.ImportCalibrationMapFromJsonString(GetJoystickCalibrationMapJson(joystick)))
			{
				return 0;
			}
			return 1;
		}

		private int LoadCustomControllerCalibrationData(CustomController controller)
		{
			if (controller == null)
			{
				return 0;
			}
			if (!controller.ImportCalibrationMapFromJsonString(GetCustomControllerCalibrationMapJson(controller)))
			{
				return 0;
			}
			return 1;
		}

		private int LoadJoystickCalibrationData(int joystickId)
		{
			return LoadJoystickCalibrationData(ReInput.controllers.GetJoystick(joystickId));
		}

		private int LoadCustomControllerCalibrationData(int joystickId)
		{
			return LoadCustomControllerCalibrationData(ReInput.controllers.GetCustomController(joystickId));
		}

		private int LoadJoystickData(int joystickId)
		{
			int num = 0;
			IList<Player> allPlayers = ReInput.players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				Player player = allPlayers[i];
				if (player.controllers.ContainsController(ControllerType.Joystick, joystickId))
				{
					num += LoadControllerMaps(player.id, ControllerType.Joystick, joystickId);
					RefreshLayoutManager(player.id);
				}
			}
			return num + LoadJoystickCalibrationData(joystickId);
		}

		private int LoadControllerDataNow(int playerId, ControllerType controllerType, int controllerId)
		{
			int num = 0 + LoadControllerMaps(playerId, controllerType, controllerId);
			RefreshLayoutManager(playerId);
			return num + LoadControllerDataNow(controllerType, controllerId);
		}

		private int LoadControllerDataNow(ControllerType controllerType, int controllerId)
		{
			int num = 0;
			if (controllerType == ControllerType.Joystick)
			{
				num += LoadJoystickCalibrationData(controllerId);
			}
			return num;
		}

		private int LoadControllerMaps(int playerId, ControllerType controllerType, int controllerId)
		{
			int num = 0;
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return num;
			}
			Controller controller = ReInput.controllers.GetController(controllerType, controllerId);
			if (controller == null)
			{
				return num;
			}
			IList<InputMapCategory> mapCategories = ReInput.mapping.MapCategories;
			for (int i = 0; i < mapCategories.Count; i++)
			{
				InputMapCategory inputMapCategory = mapCategories[i];
				if (!inputMapCategory.userAssignable)
				{
					continue;
				}
				IList<InputLayout> list = ReInput.mapping.MapLayouts(controller.type);
				for (int j = 0; j < list.Count; j++)
				{
					InputLayout inputLayout = list[j];
					ControllerMap controllerMap = LoadControllerMap(player, controller.identifier, inputMapCategory.id, inputLayout.id);
					if (controllerMap != null)
					{
						player.controllers.maps.AddMap(controller, controllerMap);
						num++;
					}
				}
			}
			return num;
		}

		private ControllerMap LoadControllerMap(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
		{
			if (player == null)
			{
				return null;
			}
			string controllerMapJson = GetControllerMapJson(player, controllerIdentifier, categoryId, layoutId);
			if (string.IsNullOrEmpty(controllerMapJson))
			{
				return null;
			}
			ControllerMap controllerMap = ControllerMap.CreateFromJson(controllerIdentifier.controllerType, controllerMapJson);
			if (controllerMap == null)
			{
				return null;
			}
			List<int> controllerMapKnownActionIds = GetControllerMapKnownActionIds(player, controllerIdentifier, categoryId, layoutId);
			AddDefaultMappingsForNewActions(controllerIdentifier, controllerMap, controllerMapKnownActionIds);
			return controllerMap;
		}

		private int LoadInputBehaviors(int playerId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return 0;
			}
			int num = 0;
			IList<InputBehavior> inputBehaviors = ReInput.mapping.GetInputBehaviors(player.id);
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				num += LoadInputBehaviorNow(player, inputBehaviors[i]);
			}
			return num;
		}

		private int LoadInputBehaviorNow(int playerId, int behaviorId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return 0;
			}
			InputBehavior inputBehavior = ReInput.mapping.GetInputBehavior(playerId, behaviorId);
			if (inputBehavior == null)
			{
				return 0;
			}
			return LoadInputBehaviorNow(player, inputBehavior);
		}

		private int LoadInputBehaviorNow(Player player, InputBehavior inputBehavior)
		{
			if (player == null || inputBehavior == null)
			{
				return 0;
			}
			string inputBehaviorJson = GetInputBehaviorJson(player, inputBehavior.id);
			if (inputBehaviorJson == null || inputBehaviorJson == string.Empty)
			{
				return 0;
			}
			if (!inputBehavior.ImportJsonString(inputBehaviorJson))
			{
				return 0;
			}
			return 1;
		}

		private bool LoadControllerAssignmentsNow()
		{
			try
			{
				ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = LoadControllerAssignmentData();
				if (controllerAssignmentSaveInfo == null)
				{
					return false;
				}
				if (_loadKeyboardAssignments || _loadMouseAssignments)
				{
					LoadKeyboardAndMouseAssignmentsNow(controllerAssignmentSaveInfo);
				}
				if (_loadJoystickAssignments)
				{
					LoadJoystickAssignmentsNow(controllerAssignmentSaveInfo);
				}
			}
			catch
			{
			}
			return true;
		}

		private bool LoadKeyboardAndMouseAssignmentsNow(ControllerAssignmentSaveInfo data)
		{
			try
			{
				if (data == null && (data = LoadControllerAssignmentData()) == null)
				{
					return false;
				}
				foreach (Player allPlayer in ReInput.players.AllPlayers)
				{
					if (data.ContainsPlayer(allPlayer.id))
					{
						ControllerAssignmentSaveInfo.PlayerInfo playerInfo = data.players[data.IndexOfPlayer(allPlayer.id)];
						if (_loadKeyboardAssignments)
						{
							allPlayer.controllers.hasKeyboard = playerInfo.hasKeyboard;
						}
						if (_loadMouseAssignments)
						{
							allPlayer.controllers.hasMouse = playerInfo.hasMouse;
						}
					}
				}
			}
			catch
			{
			}
			return true;
		}

		private bool LoadJoystickAssignmentsNow(ControllerAssignmentSaveInfo data)
		{
			try
			{
				if (ReInput.controllers.joystickCount == 0)
				{
					return false;
				}
				if (data == null && (data = LoadControllerAssignmentData()) == null)
				{
					return false;
				}
				foreach (Player allPlayer in ReInput.players.AllPlayers)
				{
					allPlayer.controllers.ClearControllersOfType(ControllerType.Joystick);
				}
				List<JoystickAssignmentHistoryInfo> list = (_loadJoystickAssignments ? new List<JoystickAssignmentHistoryInfo>() : null);
				foreach (Player allPlayer2 in ReInput.players.AllPlayers)
				{
					if (!data.ContainsPlayer(allPlayer2.id))
					{
						continue;
					}
					ControllerAssignmentSaveInfo.PlayerInfo playerInfo = data.players[data.IndexOfPlayer(allPlayer2.id)];
					for (int i = 0; i < playerInfo.joystickCount; i++)
					{
						ControllerAssignmentSaveInfo.JoystickInfo joystickInfo = playerInfo.joysticks[i];
						if (joystickInfo == null)
						{
							continue;
						}
						Joystick joystick = FindJoystickPrecise(joystickInfo);
						if (joystick != null)
						{
							if (list.Find((JoystickAssignmentHistoryInfo x) => x.joystick == joystick) == null)
							{
								list.Add(new JoystickAssignmentHistoryInfo(joystick, joystickInfo.id));
							}
							allPlayer2.controllers.AddController(joystick, removeFromOtherPlayers: false);
						}
					}
				}
				if (_allowImpreciseJoystickAssignmentMatching)
				{
					foreach (Player allPlayer3 in ReInput.players.AllPlayers)
					{
						if (!data.ContainsPlayer(allPlayer3.id))
						{
							continue;
						}
						ControllerAssignmentSaveInfo.PlayerInfo playerInfo2 = data.players[data.IndexOfPlayer(allPlayer3.id)];
						for (int num = 0; num < playerInfo2.joystickCount; num++)
						{
							ControllerAssignmentSaveInfo.JoystickInfo joystickInfo2 = playerInfo2.joysticks[num];
							if (joystickInfo2 == null)
							{
								continue;
							}
							Joystick joystick2 = null;
							int num2 = list.FindIndex((JoystickAssignmentHistoryInfo x) => x.oldJoystickId == joystickInfo2.id);
							if (num2 >= 0)
							{
								joystick2 = list[num2].joystick;
							}
							else
							{
								if (!TryFindJoysticksImprecise(joystickInfo2, out var matches))
								{
									continue;
								}
								foreach (Joystick match in matches)
								{
									if (list.Find((JoystickAssignmentHistoryInfo x) => x.joystick == match) == null)
									{
										joystick2 = match;
										break;
									}
								}
								if (joystick2 == null)
								{
									continue;
								}
								list.Add(new JoystickAssignmentHistoryInfo(joystick2, joystickInfo2.id));
							}
							allPlayer3.controllers.AddController(joystick2, removeFromOtherPlayers: false);
						}
					}
				}
			}
			catch
			{
			}
			if (ReInput.configuration.autoAssignJoysticks)
			{
				ReInput.controllers.AutoAssignJoysticks();
			}
			return true;
		}

		private ControllerAssignmentSaveInfo LoadControllerAssignmentData()
		{
			try
			{
				if (!TryGetString(dataStore, "ControllerAssignments", out var result))
				{
					return null;
				}
				if (string.IsNullOrEmpty(result))
				{
					return null;
				}
				ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = JsonParser.FromJson<ControllerAssignmentSaveInfo>(result);
				if (controllerAssignmentSaveInfo == null || controllerAssignmentSaveInfo.playerCount == 0)
				{
					return null;
				}
				return controllerAssignmentSaveInfo;
			}
			catch
			{
				return null;
			}
		}

		private IEnumerator LoadJoystickAssignmentsDeferred()
		{
			_deferredJoystickAssignmentLoadPending = true;
			yield return new WaitForEndOfFrame();
			if (ReInput.isReady)
			{
				LoadJoystickAssignmentsNow(null);
				SaveControllerAssignments();
				_deferredJoystickAssignmentLoadPending = false;
			}
		}

		private void SaveAll()
		{
			IList<Player> allPlayers = ReInput.players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				SavePlayerDataNow(allPlayers[i]);
			}
			SaveAllJoystickCalibrationData();
			if (loadControllerAssignments)
			{
				SaveControllerAssignments();
			}
			dataStore.Save();
		}

		private void SavePlayerDataNow(int playerId)
		{
			SavePlayerDataNow(ReInput.players.GetPlayer(playerId));
			dataStore.Save();
		}

		private void SavePlayerDataNow(Player player)
		{
			if (player != null)
			{
				PlayerSaveData saveData = player.GetSaveData(userAssignableMapsOnly: true);
				SaveInputBehaviors(player, saveData);
				SaveControllerMaps(player, saveData);
			}
		}

		private void SaveAllJoystickCalibrationData()
		{
			IList<Joystick> joysticks = ReInput.controllers.Joysticks;
			for (int i = 0; i < joysticks.Count; i++)
			{
				SaveJoystickCalibrationData(joysticks[i]);
			}
			foreach (CustomController customController in ReInput.controllers.CustomControllers)
			{
				SaveCustomControllerCalibrationData(customController);
			}
		}

		private void SaveJoystickCalibrationData(int joystickId)
		{
			SaveJoystickCalibrationData(ReInput.controllers.GetJoystick(joystickId));
		}

		private void SaveJoystickCalibrationData(Joystick joystick)
		{
			if (joystick != null)
			{
				JoystickCalibrationMapSaveData calibrationMapSaveData = joystick.GetCalibrationMapSaveData();
				string joystickCalibrationMapKey = GetJoystickCalibrationMapKey(joystick);
				dataStore.SetValue(joystickCalibrationMapKey, calibrationMapSaveData.map.ToJsonString());
			}
		}

		private void SaveCustomControllerCalibrationData(int controllerId)
		{
			SaveCustomControllerCalibrationData(ReInput.controllers.GetCustomController(controllerId));
		}

		private void SaveCustomControllerCalibrationData(CustomController customController)
		{
			if (customController != null)
			{
				CustomControllerCalibrationMapSaveData calibrationMapSaveData = customController.GetCalibrationMapSaveData();
				string customControllerCalibrationMapKey = GetCustomControllerCalibrationMapKey(customController);
				dataStore.SetValue(customControllerCalibrationMapKey, calibrationMapSaveData.map.ToJsonString());
			}
		}

		private void SaveJoystickData(int joystickId)
		{
			IList<Player> allPlayers = ReInput.players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				Player player = allPlayers[i];
				if (player.controllers.ContainsController(ControllerType.Joystick, joystickId))
				{
					SaveControllerMaps(player.id, ControllerType.Joystick, joystickId);
				}
			}
			SaveJoystickCalibrationData(joystickId);
		}

		private void SaveCustomControllerData(int joystickId)
		{
			IList<Player> allPlayers = ReInput.players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				Player player = allPlayers[i];
				if (player.controllers.ContainsController(ControllerType.Custom, joystickId))
				{
					SaveControllerMaps(player.id, ControllerType.Custom, joystickId);
				}
			}
			SaveCustomControllerCalibrationData(joystickId);
		}

		private void SaveControllerDataNow(int playerId, ControllerType controllerType, int controllerId)
		{
			SaveControllerMaps(playerId, controllerType, controllerId);
			SaveControllerData(controllerType, controllerId);
		}

		private void SaveControllerDataNow(ControllerType controllerType, int controllerId)
		{
			if (controllerType == ControllerType.Joystick)
			{
				SaveJoystickCalibrationData(controllerId);
			}
		}

		private void SaveControllerMaps(Player player, PlayerSaveData playerSaveData)
		{
			foreach (ControllerMapSaveData allControllerMapSaveDatum in playerSaveData.AllControllerMapSaveData)
			{
				SaveControllerMap(player, allControllerMapSaveDatum.map);
			}
		}

		private void SaveControllerMaps(int playerId, ControllerType controllerType, int controllerId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null || !player.controllers.ContainsController(controllerType, controllerId))
			{
				return;
			}
			ControllerMapSaveData[] mapSaveData = player.controllers.maps.GetMapSaveData(controllerType, controllerId, userAssignableMapsOnly: true);
			if (mapSaveData != null)
			{
				for (int i = 0; i < mapSaveData.Length; i++)
				{
					SaveControllerMap(player, mapSaveData[i].map);
				}
			}
		}

		private void SaveControllerMap(Player player, ControllerMap controllerMap)
		{
			string controllerMapKey = GetControllerMapKey(player, controllerMap.controller.identifier, controllerMap.categoryId, controllerMap.layoutId, 0);
			dataStore.SetValue(controllerMapKey, controllerMap.ToJsonString());
			controllerMapKey = GetControllerMapKnownActionIdsKey(player, controllerMap.controller.identifier, controllerMap.categoryId, controllerMap.layoutId, 0);
			dataStore.SetValue(controllerMapKey, allActionIdsString);
		}

		private void SaveInputBehaviors(Player player, PlayerSaveData playerSaveData)
		{
			if (player != null)
			{
				InputBehavior[] inputBehaviors = playerSaveData.inputBehaviors;
				for (int i = 0; i < inputBehaviors.Length; i++)
				{
					SaveInputBehaviorNow(player, inputBehaviors[i]);
				}
			}
		}

		private void SaveInputBehaviorNow(int playerId, int behaviorId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player != null)
			{
				InputBehavior inputBehavior = ReInput.mapping.GetInputBehavior(playerId, behaviorId);
				if (inputBehavior != null)
				{
					SaveInputBehaviorNow(player, inputBehavior);
					dataStore.Save();
				}
			}
		}

		private void SaveInputBehaviorNow(Player player, InputBehavior inputBehavior)
		{
			if (player != null && inputBehavior != null)
			{
				string inputBehaviorKey = GetInputBehaviorKey(player, inputBehavior.id);
				dataStore.SetValue(inputBehaviorKey, inputBehavior.ToJsonString());
			}
		}

		private bool SaveControllerAssignments()
		{
			try
			{
				ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = new ControllerAssignmentSaveInfo(ReInput.players.allPlayerCount);
				for (int i = 0; i < ReInput.players.allPlayerCount; i++)
				{
					Player player = ReInput.players.AllPlayers[i];
					ControllerAssignmentSaveInfo.PlayerInfo playerInfo = new ControllerAssignmentSaveInfo.PlayerInfo();
					controllerAssignmentSaveInfo.players[i] = playerInfo;
					playerInfo.id = player.id;
					playerInfo.hasKeyboard = player.controllers.hasKeyboard;
					playerInfo.hasMouse = player.controllers.hasMouse;
					ControllerAssignmentSaveInfo.JoystickInfo[] array = (playerInfo.joysticks = new ControllerAssignmentSaveInfo.JoystickInfo[player.controllers.joystickCount]);
					for (int j = 0; j < player.controllers.joystickCount; j++)
					{
						Joystick joystick = player.controllers.Joysticks[j];
						ControllerAssignmentSaveInfo.JoystickInfo joystickInfo = new ControllerAssignmentSaveInfo.JoystickInfo();
						joystickInfo.instanceGuid = joystick.deviceInstanceGuid;
						joystickInfo.id = joystick.id;
						joystickInfo.hardwareIdentifier = joystick.hardwareIdentifier;
						array[j] = joystickInfo;
					}
					ControllerAssignmentSaveInfo.JoystickInfo[] array2 = (playerInfo.customControllers = new ControllerAssignmentSaveInfo.JoystickInfo[player.controllers.customControllerCount]);
					for (int k = 0; k < player.controllers.customControllerCount; k++)
					{
						CustomController customController = player.controllers.CustomControllers[k];
						ControllerAssignmentSaveInfo.JoystickInfo joystickInfo2 = new ControllerAssignmentSaveInfo.JoystickInfo();
						joystickInfo2.instanceGuid = customController.deviceInstanceGuid;
						joystickInfo2.id = customController.id;
						joystickInfo2.hardwareIdentifier = customController.hardwareIdentifier;
						array2[k] = joystickInfo2;
					}
				}
				dataStore.SetValue("ControllerAssignments", JsonWriter.ToJson(controllerAssignmentSaveInfo));
				dataStore.Save();
			}
			catch
			{
			}
			return true;
		}

		private static void AppendBaseKey(StringBuilder sb, Player player)
		{
			sb.Append("playerId=");
			sb.Append(player.id);
		}

		private string GetControllerMapKey(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
		{
			_sb.Length = 0;
			AppendBaseKey(_sb, player);
			_sb.Append("|dataType=ControllerMap");
			AppendControllerMapKeyCommonSuffix(_sb, player, controllerIdentifier, categoryId, layoutId, ppKeyVersion);
			return _sb.ToString();
		}

		private string GetControllerMapKnownActionIdsKey(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
		{
			_sb.Length = 0;
			AppendBaseKey(_sb, player);
			_sb.Append("|dataType=ControllerMap_KnownActionIds");
			AppendControllerMapKeyCommonSuffix(_sb, player, controllerIdentifier, categoryId, layoutId, ppKeyVersion);
			return _sb.ToString();
		}

		private static void AppendControllerMapKeyCommonSuffix(StringBuilder sb, Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int keyVersion)
		{
			sb.Append("|kv=");
			sb.Append(keyVersion);
			sb.Append("|controllerMapType=");
			sb.Append((int)controllerIdentifier.controllerType);
			sb.Append("|categoryId=");
			sb.Append(categoryId);
			sb.Append("|");
			sb.Append("layoutId=");
			sb.Append(layoutId);
			sb.Append("|hardwareGuid=");
			sb.Append(controllerIdentifier.hardwareTypeGuid);
			if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
			{
				sb.Append("|hardwareIdentifier=");
				sb.Append(controllerIdentifier.hardwareIdentifier);
			}
			if (controllerIdentifier.controllerType == ControllerType.Joystick)
			{
				sb.Append("|duplicate=");
				sb.Append(GetDuplicateIndex(player, controllerIdentifier).ToString());
			}
		}

		private string GetJoystickCalibrationMapKey(Joystick joystick)
		{
			_sb.Length = 0;
			_sb.Append("dataType=CalibrationMap");
			_sb.Append("|controllerType=");
			_sb.Append((int)joystick.type);
			_sb.Append("|hardwareIdentifier=");
			_sb.Append(joystick.hardwareIdentifier);
			_sb.Append("|hardwareGuid=");
			_sb.Append(joystick.hardwareTypeGuid.ToString());
			return _sb.ToString();
		}

		private string GetCustomControllerCalibrationMapKey(CustomController customController)
		{
			_sb.Length = 0;
			_sb.Append("dataType=CalibrationMap");
			_sb.Append("|controllerType=");
			_sb.Append((int)customController.type);
			_sb.Append("|hardwareIdentifier=");
			_sb.Append(customController.hardwareIdentifier);
			_sb.Append("|hardwareGuid=");
			_sb.Append(customController.hardwareTypeGuid.ToString());
			return _sb.ToString();
		}

		private string GetInputBehaviorKey(Player player, int inputBehaviorId)
		{
			_sb.Length = 0;
			AppendBaseKey(_sb, player);
			_sb.Append("|dataType=InputBehavior");
			_sb.Append("|id=");
			_sb.Append(inputBehaviorId);
			return _sb.ToString();
		}

		private string GetControllerMapJson(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
		{
			for (int num = 0; num >= 0; num--)
			{
				string controllerMapKey = GetControllerMapKey(player, controllerIdentifier, categoryId, layoutId, num);
				if (TryGetString(dataStore, controllerMapKey, out var result) && !string.IsNullOrEmpty(result))
				{
					return result;
				}
			}
			return null;
		}

		private List<int> GetControllerMapKnownActionIds(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
		{
			List<int> list = new List<int>();
			string result = null;
			bool flag = false;
			for (int num = 0; num >= 0; num--)
			{
				string controllerMapKnownActionIdsKey = GetControllerMapKnownActionIdsKey(player, controllerIdentifier, categoryId, layoutId, num);
				if (TryGetString(dataStore, controllerMapKnownActionIdsKey, out result))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return list;
			}
			if (string.IsNullOrEmpty(result))
			{
				return list;
			}
			string[] array = result.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && int.TryParse(array[i], out var result2))
				{
					list.Add(result2);
				}
			}
			return list;
		}

		private string GetJoystickCalibrationMapJson(Joystick joystick)
		{
			string joystickCalibrationMapKey = GetJoystickCalibrationMapKey(joystick);
			TryGetString(dataStore, joystickCalibrationMapKey, out var result);
			return result;
		}

		private string GetCustomControllerCalibrationMapJson(CustomController controller)
		{
			string customControllerCalibrationMapKey = GetCustomControllerCalibrationMapKey(controller);
			TryGetString(dataStore, customControllerCalibrationMapKey, out var result);
			return result;
		}

		private string GetInputBehaviorJson(Player player, int id)
		{
			string inputBehaviorKey = GetInputBehaviorKey(player, id);
			TryGetString(dataStore, inputBehaviorKey, out var result);
			return result;
		}

		private void AddDefaultMappingsForNewActions(ControllerIdentifier controllerIdentifier, ControllerMap controllerMap, List<int> knownActionIds)
		{
			if (controllerMap == null || knownActionIds == null || knownActionIds == null || knownActionIds.Count == 0)
			{
				return;
			}
			ControllerMap controllerMapInstance = ReInput.mapping.GetControllerMapInstance(controllerIdentifier, controllerMap.categoryId, controllerMap.layoutId);
			if (controllerMapInstance == null)
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (int allActionId in allActionIds)
			{
				if (!knownActionIds.Contains(allActionId))
				{
					list.Add(allActionId);
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			foreach (ActionElementMap allMap in controllerMapInstance.AllMaps)
			{
				if (list.Contains(allMap.actionId) && !controllerMap.DoesElementAssignmentConflict(allMap))
				{
					ElementAssignment elementAssignment = new ElementAssignment(controllerMap.controllerType, allMap.elementType, allMap.elementIdentifierId, allMap.axisRange, allMap.keyCode, allMap.modifierKeyFlags, allMap.actionId, allMap.axisContribution, allMap.invert);
					controllerMap.CreateElementMap(elementAssignment);
				}
			}
		}

		private Joystick FindJoystickPrecise(ControllerAssignmentSaveInfo.JoystickInfo joystickInfo)
		{
			if (joystickInfo == null)
			{
				return null;
			}
			if (joystickInfo.instanceGuid == Guid.Empty)
			{
				return null;
			}
			IList<Joystick> joysticks = ReInput.controllers.Joysticks;
			for (int i = 0; i < joysticks.Count; i++)
			{
				if (joysticks[i].deviceInstanceGuid == joystickInfo.instanceGuid)
				{
					return joysticks[i];
				}
			}
			return null;
		}

		private bool TryFindJoysticksImprecise(ControllerAssignmentSaveInfo.JoystickInfo joystickInfo, out List<Joystick> matches)
		{
			matches = null;
			if (joystickInfo == null)
			{
				return false;
			}
			if (string.IsNullOrEmpty(joystickInfo.hardwareIdentifier))
			{
				return false;
			}
			IList<Joystick> joysticks = ReInput.controllers.Joysticks;
			for (int i = 0; i < joysticks.Count; i++)
			{
				if (string.Equals(joysticks[i].hardwareIdentifier, joystickInfo.hardwareIdentifier, StringComparison.OrdinalIgnoreCase))
				{
					if (matches == null)
					{
						matches = new List<Joystick>();
					}
					matches.Add(joysticks[i]);
				}
			}
			return matches != null;
		}

		private void RefreshLayoutManager(int playerId)
		{
			ReInput.players.GetPlayer(playerId)?.controllers.maps.layoutManager.Apply();
		}

		private static int GetDuplicateIndex(Player player, ControllerIdentifier controllerIdentifier)
		{
			Controller controller = ReInput.controllers.GetController(controllerIdentifier);
			if (controller == null)
			{
				return 0;
			}
			int num = 0;
			foreach (Controller controller2 in player.controllers.Controllers)
			{
				if (controller2.type != controller.type)
				{
					continue;
				}
				bool flag = false;
				if (controller.type == ControllerType.Joystick)
				{
					if ((controller2 as Joystick).hardwareTypeGuid != controller.hardwareTypeGuid)
					{
						continue;
					}
					if (controller.hardwareTypeGuid != Guid.Empty)
					{
						flag = true;
					}
				}
				if (flag || !(controller2.hardwareIdentifier != controller.hardwareIdentifier))
				{
					if (controller2 == controller)
					{
						return num;
					}
					num++;
				}
			}
			return num;
		}

		private static bool TryGetString(IDataStore store, string key, out string result)
		{
			if (store == null || string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			if (!store.TryGetValue(key, out var result2))
			{
				result = null;
				return false;
			}
			result = result2 as string;
			return result2 is string;
		}
	}
}
