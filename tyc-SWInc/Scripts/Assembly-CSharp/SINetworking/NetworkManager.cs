using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevConsole;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SINetworking
{
	public class NetworkManager : MonoBehaviour
	{
		public enum WaitStatus
		{
			None = 0,
			WaitingForMeta = 1,
			WaitingForSaveData = 2,
			Skipped = 3,
			WaitingForNewGameMeta = 4
		}

		public enum NetworkIDType
		{
			GlobalObject = 0,
			Trade = 1,
			WorkItem = 2
		}

		public const string ProtocolRevision = "";

		public const int MaxReconnectionTries = 3;

		public const int ReconnectionTimeOut = 5;

		public static NetworkManager Instance;

		public static bool Ready;

		public static byte FloatingID = byte.MaxValue;

		public static bool CanSkipPassword = false;

		public bool Host = true;

		public bool Connected;

		[NonSerialized]
		public NetworkTradeController TradeController = new NetworkTradeController();

		[NonSerialized]
		private NetworkLayer _layer;

		[NonSerialized]
		public List<NetworkPlayer> Players = new List<NetworkPlayer>();

		[NonSerialized]
		public NetworkPlayer Myself;

		[NonSerialized]
		public NetworkPlayer HostPlayer;

		[NonSerialized]
		private Dictionary<uint, INetworkID> _networkObjects = new Dictionary<uint, INetworkID>();

		[NonSerialized]
		private Dictionary<uint, INetworkID> _idCallbacks = new Dictionary<uint, INetworkID>();

		[NonSerialized]
		private Dictionary<uint, Action<uint>> _advancedIDCallbacks = new Dictionary<uint, Action<uint>>();

		[NonSerialized]
		private uint _nextNetworkID = 1u;

		[NonSerialized]
		private uint _localIDCallback = 1u;

		[NonSerialized]
		private uint _workItemID = 1u;

		[NonSerialized]
		public WaitStatus JoinStatus;

		[NonSerialized]
		public int ReconnectionTries;

		[NonSerialized]
		public float ReconnectionTimer;

		[NonSerialized]
		public bool WaitingForReconnection;

		private const float PingDelay = 1f;

		private float _pingTimer = 1f;

		private bool _syncScreenActive;

		private Dictionary<string, NetworkPlayer> _idMap = new Dictionary<string, NetworkPlayer>();

		private Dictionary<object, NetworkPlayer> _connectionMap = new Dictionary<object, NetworkPlayer>();

		[NonSerialized]
		public HashSet<IMarketable> DirtyMarketing = new HashSet<IMarketable>();

		[NonSerialized]
		public Dictionary<KeyValuePair<ILossable, SoftwareProduct.LossType>, float> DirtyLoss = new Dictionary<KeyValuePair<ILossable, SoftwareProduct.LossType>, float>();

		private static bool _joinWarned = false;

		public static bool IsConnected
		{
			get
			{
				if (Ready)
				{
					return Instance.Connected;
				}
				return false;
			}
		}

		public static bool IsHost
		{
			get
			{
				if (IsConnected)
				{
					return Instance.Host;
				}
				return false;
			}
		}

		public static bool IsClient
		{
			get
			{
				if (IsConnected)
				{
					return !Instance.Host;
				}
				return false;
			}
		}

		public static bool NotConnectedOrHost
		{
			get
			{
				if (IsConnected)
				{
					return Instance.Host;
				}
				return true;
			}
		}

		public static bool IsHostingPlayers
		{
			get
			{
				if (IsHost)
				{
					return Instance.Players.Count > 1;
				}
				return false;
			}
		}

		public static bool IsConnectedToAnyone
		{
			get
			{
				if (IsConnected)
				{
					return Instance.Players.Count > 1;
				}
				return false;
			}
		}

		public static NetworkPlayer Self
		{
			get
			{
				NetworkManager instance = Instance;
				if ((object)instance == null)
				{
					return null;
				}
				return instance.Myself;
			}
		}

		public static byte LocalPlayerID
		{
			get
			{
				NetworkPlayer self = Self;
				if (self == null)
				{
					return 1;
				}
				return self.ID;
			}
		}

		public NetworkLayer Layer
		{
			get
			{
				return _layer;
			}
		}

		private void LoadCustomization()
		{
			if (MainMenuController.Instance != null)
			{
				MainMenuController.Instance.MainMenu.Action(0);
				return;
			}
			ErrorLogging.FirstOfScene = true;
			ErrorLogging.SceneChanging = true;
			DevConsole.Console.SaveConsole();
			SceneManager.LoadScene("Customization");
		}

		public void HandleJoinLobby(NetworkLobby lobby)
		{
			GameData.ResetLobbyData();
			GameData.MultiplayerMode = true;
			JoinStatus = WaitStatus.WaitingForMeta;
			WindowManager.ShowFullScreenMessage("Pleasewait".Loc());
			NetworkLayer.Active.JoinLobby(lobby);
		}

		public void HandleCancelLobby()
		{
			GameData.ResetLobbyData();
			GameData.NetworkData = null;
			CanSkipPassword = false;
			WindowManager.ShowFullScreenMessage(null);
			JoinStatus = WaitStatus.None;
		}

		private static bool ValidSave(SaveGame x, NetworkMeta meta, HashSet<string> uuids)
		{
			uint company;
			uint company2;
			if (!x.Broken && x.NetworkData != null && !meta.IsPlaying(x.NetworkData.LocalUniqueID) && meta.PlayerIDs.ContainsKey(x.NetworkData.LocalUniqueID) && meta.TryGetPlayerCompany(x.NetworkData.LocalUniqueID, out company) && x.NetworkData.TryGetPlayerCompany(x.NetworkData.LocalUniqueID, out company2) && company == company2)
			{
				return uuids.Contains(x.NetworkData.CurrentUUID);
			}
			return false;
		}

		private static bool ValidSaveFallback(SaveGame x, NetworkMeta meta, SDateTime hostTime, HashSet<string> uuids)
		{
			uint company;
			uint company2;
			if (!x.Broken && x.NetworkData != null && x.InGameTime <= hostTime && !meta.IsPlaying(x.NetworkData.LocalUniqueID) && meta.PlayerIDs.ContainsKey(x.NetworkData.LocalUniqueID) && meta.TryGetPlayerCompany(x.NetworkData.LocalUniqueID, out company) && x.NetworkData.TryGetPlayerCompany(x.NetworkData.LocalUniqueID, out company2) && company == company2)
			{
				return x.NetworkData.SaveUUIDs.TakeLast(2).Any(uuids.Contains);
			}
			return false;
		}

		private void HandleJoining()
		{
			switch (JoinStatus)
			{
			case WaitStatus.WaitingForMeta:
				if (!Layer.IsLobbyValid())
				{
					Debug.Log("Lobby became invalid while WaitingForMeta, cancel join");
					Layer.LeaveLobby();
					WindowManager.Instance.ShowMessageBox("FailedJoiningGame".Loc(), true, DialogWindow.DialogType.Error);
					HandleCancelLobby();
				}
				else
				{
					if (GameData.NetworkData == null)
					{
						break;
					}
					if (Layer.CurrentLobby == null)
					{
						Debug.Log("JoinStatus WaitingForMeta on empty lobby");
						HandleCancelLobby();
						break;
					}
					if (GameData.NetworkData.OldPlayers.ContainsKey(Self.ID))
					{
						Debug.Log("Player was bankrupted on host since they last played, start new company");
						JoinStatus = WaitStatus.Skipped;
						break;
					}
					if (!GameData.NetworkData.AllowCodeMods)
					{
						ModController.Instance.UnloadAllMods();
					}
					HashSet<string> uuids = GameData.NetworkData.SaveUUIDs.ToHashSet();
					SaveGame previous = SaveGameManager.SaveGames.Where((SaveGame x) => ValidSave(x, GameData.NetworkData, uuids)).MaxInstance((SaveGame x) => x.InGameTime.ToInt());
					bool flag = false;
					string[] files = Directory.GetFiles(SaveGameManager.SaveFolder, "*.bak");
					foreach (string filename in files)
					{
						try
						{
							SaveGame saveGame = SaveGame.LoadGame(filename, false, true);
							if (ValidSave(saveGame, GameData.NetworkData, uuids) && (previous == null || saveGame.InGameTime > previous.InGameTime))
							{
								previous = saveGame;
								flag = true;
							}
						}
						catch (Exception)
						{
						}
					}
					bool flag2 = false;
					if (previous == null && GameData.HostDate.HasValue)
					{
						previous = SaveGameManager.SaveGames.Where((SaveGame x) => ValidSaveFallback(x, GameData.NetworkData, GameData.HostDate.Value, uuids)).MaxInstance((SaveGame x) => x.InGameTime.ToInt());
						if (previous != null)
						{
							flag2 = true;
							Debug.Log("Found fallback compatible save file");
						}
					}
					if (previous != null)
					{
						if (flag2)
						{
							WindowManager.ShowFullScreenMessage(null);
							JoinStatus = WaitStatus.None;
							DialogWindow dialogWindow = WindowManager.Instance.ShowMessageBox("AlmostCompatibleNetworkSave".Loc(), true, DialogWindow.DialogType.Warning, delegate
							{
								Debug.Log("Player has semi compatible save");
								HandleFinalJoin(delegate(string x)
								{
									HandleJoinSendSave(x, previous);
								}, previous.NetworkData.Password);
							}, null, NoCompatibleSaves);
							if (MainMenuController.Instance != null)
							{
								dialogWindow.Window.SetParentWindow(MainMenuController.Instance.NetworkWindow.Window);
							}
						}
						else
						{
							Debug.Log(flag ? "Player has compatible backup save" : "Player has compatible save");
							HandleFinalJoin(delegate(string x)
							{
								HandleJoinSendSave(x, previous);
							}, previous.NetworkData.Password);
						}
					}
					else
					{
						NoCompatibleSaves();
					}
				}
				break;
			case WaitStatus.WaitingForSaveData:
			{
				float receiveMessageProgress = GetReceiveMessageProgress(4);
				if (receiveMessageProgress < 0f)
				{
					WindowManager.ShowFullScreenMessage("Pleasewait".Loc());
				}
				else
				{
					WindowManager.ShowFullScreenMessage("Synchronizing".Loc() + ":\n" + receiveMessageProgress.ToPercent());
				}
				if (GameData.NetworkSaveData != null)
				{
					MainMenuController instance2 = MainMenuController.Instance;
					if ((object)instance2 != null)
					{
						instance2.NetworkWindow.Window.Close();
					}
					JoinStatus = WaitStatus.None;
					FrameTransition.StartTransition(true);
					ErrorLogging.FirstOfScene = true;
					ErrorLogging.SceneChanging = true;
					GameData.EditMode = false;
					GameData.LoadBackup = false;
					DevConsole.Console.SaveConsole();
					SceneManager.LoadScene("MainScene");
				}
				break;
			}
			case WaitStatus.Skipped:
				if (Layer.CurrentLobby == null)
				{
					Debug.Log("JoinStatus Skipped on empty lobby");
					HandleCancelLobby();
				}
				else
				{
					HandleFinalJoin(HandleJoinSendCustomization);
				}
				break;
			case WaitStatus.WaitingForNewGameMeta:
				if (Layer.CurrentLobby == null)
				{
					Debug.Log("JoinStatus WaitingForNewGameMeta on empty lobby");
					HandleCancelLobby();
				}
				else if (!Layer.IsLobbyValid())
				{
					Debug.Log("Lobby became invalid while WaitingForNewGameMeta, cancel join");
					Layer.LeaveLobby();
					WindowManager.Instance.ShowMessageBox("FailedJoiningGame".Loc(), true, DialogWindow.DialogType.Error);
					HandleCancelLobby();
				}
				else if (GameData.NetworkData != null)
				{
					Debug.Log("Player successfully finished joining, actually start new company now");
					JoinStatus = WaitStatus.None;
					MainMenuController instance = MainMenuController.Instance;
					if ((object)instance != null)
					{
						instance.NetworkWindow.Window.Close();
					}
					WindowManager.ShowFullScreenMessage(null);
					LoadCustomization();
				}
				break;
			}
		}

		private void NoCompatibleSaves()
		{
			if (!GameData.NetworkData.IsPlaying(Self.UniqueID))
			{
				Debug.Log("Player had no compatible saves, start new company");
				HandleFinalJoin(HandleJoinSendCustomization);
				return;
			}
			Debug.Log("Somebody with the same ID as player was already playing this game, get kicked");
			NetworkMessaging.SendDisconnectPlayer(false, NetworkMessaging.MessageTarget.Host, 0);
			NetworkMessaging.SendAllNow();
			CleanUpEverything(true);
			HandleCancelLobby();
			WindowManager.Instance.ShowMessageBox("HostDisconnect".Loc(), true, DialogWindow.DialogType.Error);
		}

		private void HandleFinalJoin(Action<string> onJoin, string defaultPass = "")
		{
			if (Layer.CurrentLobby == null)
			{
				Debug.Log("Lobby was gone before final join could happen");
				HandleCancelLobby();
			}
			else if (!CanSkipPassword && (Layer.CurrentLobby.PasswordProtected || (GameData.NetworkData != null && GameData.NetworkData.Password != null)))
			{
				Debug.Log("Server was password protected");
				JoinStatus = WaitStatus.None;
				WindowManager.ShowFullScreenMessage(null);
				WindowManager.SpawnInputDialog("PasswordPrompt".Loc(), "Password".Loc(), defaultPass, onJoin, delegate
				{
					JoinStatus = WaitStatus.None;
					NetworkMessaging.SendDisconnectPlayer(false, NetworkMessaging.MessageTarget.Host, 0);
					NetworkMessaging.SendAllNow();
					CleanUpEverything(true);
					HandleCancelLobby();
				}, 24, (MainMenuController.Instance != null) ? MainMenuController.Instance.NetworkWindow.Window : null).InputBox.contentType = InputField.ContentType.Password;
			}
			else
			{
				onJoin(null);
			}
		}

		private void HandleJoinSendCustomization(string pass)
		{
			JoinStatus = WaitStatus.WaitingForNewGameMeta;
			NetworkMessaging.SendNewConnection(Self.Name.StripRichTags(), Self.ActualUniqueID, Self.ReconnectionData, pass, NetworkMessaging.MessageTarget.Host, 0);
			CanSkipPassword = false;
			GameData.NetworkData = null;
		}

		private void HandleJoinSendSave(string pass, SaveGame previous)
		{
			Self.UniqueIDOverride = previous.NetworkData.LocalUniqueID;
			NetworkMessaging.SendNewConnection(Self.Name.StripRichTags(), Self.ActualUniqueID, Self.ReconnectionData, pass, NetworkMessaging.MessageTarget.Host, 0);
			CanSkipPassword = false;
			GameData.LoadFile = previous;
			MainMenuController instance = MainMenuController.Instance;
			if ((object)instance != null)
			{
				instance.NetworkWindow.Window.Close();
			}
			JoinStatus = WaitStatus.WaitingForSaveData;
		}

		private void Awake()
		{
			if (Instance != null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			Instance = this;
		}

		private void OnApplicationQuit()
		{
			if (IsConnected)
			{
				NetworkMessaging.DisconnectMyself();
				NetworkMessaging.SendAllNow();
				Layer.LeaveLobby();
				Connected = false;
			}
		}

		public void ClearPlayer(NetworkPlayer player)
		{
			Layer.CleanPlayer(player);
			player.ClearAvatar();
			player.Ping = null;
		}

		private void OnDestroy()
		{
			if (Instance == this)
			{
				for (int i = 0; i < Players.Count; i++)
				{
					ClearPlayer(Players[i]);
				}
				Instance = null;
				Ready = false;
			}
		}

		public uint GetIDOfType(NetworkIDType type)
		{
			switch (type)
			{
			case NetworkIDType.GlobalObject:
				return _nextNetworkID;
			case NetworkIDType.Trade:
				return TradeController.NextTradeID;
			case NetworkIDType.WorkItem:
				return _workItemID;
			default:
				throw new ArgumentOutOfRangeException("type", type, null);
			}
		}

		public void SetIDOfType(NetworkIDType type, uint value)
		{
			switch (type)
			{
			case NetworkIDType.GlobalObject:
				_nextNetworkID = value;
				break;
			case NetworkIDType.Trade:
				TradeController.NextTradeID = value;
				break;
			case NetworkIDType.WorkItem:
				_workItemID = value;
				break;
			}
		}

		public uint GetNetworkID(NetworkIDType type)
		{
			switch (type)
			{
			case NetworkIDType.GlobalObject:
				lock (_networkObjects)
				{
					uint nextNetworkID = _nextNetworkID;
					_nextNetworkID++;
					return nextNetworkID;
				}
			case NetworkIDType.Trade:
				return TradeController.GetTradeID();
			case NetworkIDType.WorkItem:
			{
				uint workItemID = _workItemID;
				_workItemID++;
				return workItemID;
			}
			default:
				throw new Exception("Failed to generate network ID for type: " + type);
			}
		}

		public void SerializeNetworkIDs(WriteDictionary result)
		{
			result["NetworkID"] = _nextNetworkID;
			result["NetworkTradeID"] = TradeController.NextTradeID;
			result["NetworkWorkID"] = _workItemID;
		}

		public void DeserializeNetworkIDs(WriteDictionary result)
		{
			uint val;
			if (result.TryGet<uint>("NetworkID", out val))
			{
				_nextNetworkID = val;
			}
			if (result.TryGet<uint>("NetworkTradeID", out val))
			{
				TradeController.NextTradeID = val;
			}
			if (result.TryGet<uint>("NetworkWorkID", out val))
			{
				_workItemID = val;
			}
		}

		public void ResetNetworkIDs()
		{
			lock (_networkObjects)
			{
				_nextNetworkID = 1u;
				foreach (uint key in _networkObjects.Keys)
				{
					if (key > _nextNetworkID)
					{
						_nextNetworkID = key + 1;
					}
				}
			}
		}

		public void ResetWorkIDs()
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				_workItemID = GameSettings.Instance.MyCompany.WorkItems.MaxSafeUint(delegate(WorkItem x)
				{
					NetworkDeal.NetworkWorkItemID workItemID = x.WorkItemID;
					return (workItemID != null) ? workItemID.ID : 0u;
				}) + 1;
			}
			else
			{
				_workItemID = 1u;
			}
		}

		public void RegisterNetworkObject(INetworkID o)
		{
			lock (_networkObjects)
			{
				if (o.NetworkID != 0)
				{
					_networkObjects[o.NetworkID] = o;
					if (o.NetworkID >= _nextNetworkID)
					{
						_nextNetworkID = o.NetworkID + 1;
					}
				}
			}
		}

		public void SetAndRegisterNetworkObject(INetworkID o)
		{
			lock (_networkObjects)
			{
				if (o.NetworkID == 0)
				{
					o.NetworkID = GetNetworkID(NetworkIDType.GlobalObject);
					if (o.NetworkID >= _nextNetworkID)
					{
						_nextNetworkID = o.NetworkID + 1;
					}
				}
				_networkObjects[o.NetworkID] = o;
			}
		}

		public void UnregisterNetworkObject(INetworkID o, bool resetID)
		{
			lock (_networkObjects)
			{
				if (o.NetworkID != 0)
				{
					_networkObjects.Remove(o.NetworkID);
					if (resetID)
					{
						o.NetworkID = 0u;
					}
				}
			}
		}

		public void UnregisterNetworkObject(uint id)
		{
			lock (_networkObjects)
			{
				if (id != 0)
				{
					_networkObjects.Remove(id);
				}
			}
		}

		public INetworkID GetNetworkObject(uint id)
		{
			return _networkObjects.GetOrNull(id);
		}

		public bool HasNetworkObject(uint id)
		{
			return _networkObjects.ContainsKey(id);
		}

		public void RunIDCallback(uint id, uint newID)
		{
			INetworkID value;
			if (_idCallbacks.TryGetValue(id, out value))
			{
				lock (_networkObjects)
				{
					value.NetworkID = newID;
					_networkObjects[newID] = value;
				}
				_idCallbacks.Remove(id);
			}
			Action<uint> value2;
			if (_advancedIDCallbacks.TryGetValue(id, out value2))
			{
				value2(newID);
				_advancedIDCallbacks.Remove(id);
			}
		}

		public uint AddIDCallback(INetworkID o, Action<uint> a = null)
		{
			uint localIDCallback = _localIDCallback;
			_idCallbacks[localIDCallback] = o;
			if (a != null)
			{
				_advancedIDCallbacks[localIDCallback] = a;
			}
			if (_localIDCallback == uint.MaxValue)
			{
				_localIDCallback = 1u;
			}
			else
			{
				_localIDCallback++;
			}
			return localIDCallback;
		}

		public uint AddIDCallback(Action<uint> a)
		{
			uint localIDCallback = _localIDCallback;
			_advancedIDCallbacks[localIDCallback] = a;
			if (_localIDCallback == uint.MaxValue)
			{
				_localIDCallback = 1u;
			}
			else
			{
				_localIDCallback++;
			}
			return localIDCallback;
		}

		public void CleanUpEverything(bool resetPlayerID, bool clearChat = true)
		{
			NetworkMessaging.DigitalPlatforms.Clear();
			NetworkMessaging.CleanUpSync();
			_nextNetworkID = 1u;
			_workItemID = 1u;
			FloatingID = byte.MaxValue;
			_localIDCallback = 1u;
			_networkObjects.Clear();
			_idCallbacks.Clear();
			DirtyMarketing.Clear();
			DirtyLoss.Clear();
			Connected = false;
			Host = true;
			TradeController.Reset();
			if (clearChat)
			{
				ChatWindow.ClearAllMessages();
			}
			ResetIDMap();
			for (int i = 0; i < Players.Count; i++)
			{
				NetworkPlayer networkPlayer = Players[i];
				ClearPlayer(networkPlayer);
				if (networkPlayer.Self)
				{
					if (resetPlayerID)
					{
						networkPlayer.ID = 1;
					}
					networkPlayer.Host = true;
					networkPlayer.UniqueIDOverride = null;
					HostPlayer = networkPlayer;
					networkPlayer.ResetStats();
				}
				else
				{
					networkPlayer.Connected = false;
					Players.RemoveAt(i);
					i--;
				}
			}
			Self.Ready = NetworkPlayer.ReadyStatus.NotReady;
			Layer.LeaveLobby();
		}

		public void RemovePlayer(NetworkPlayer player)
		{
			Players.Remove(player);
			RemoveFromMap(player);
		}

		public bool InitLayer(NetworkLayer layer)
		{
			_layer = layer;
			_layer.OnLobbyCreated += OnLobbyCreated;
			_layer.OnLobbyQuery += OnLobbyQuery;
			_layer.OnLobbyJoined += OnLobbyJoined;
			Ready = true;
			return true;
		}

		private void OnLobbyJoined(object sender, NetworkLobby e)
		{
			if (e == null)
			{
				HandleCancelLobby();
				if (MainMenuController.Instance != null && MainMenuController.Instance.NetworkWindow.Window.Shown)
				{
					MainMenuController.Instance.NetworkWindow.RefreshLobbies();
				}
			}
			else
			{
				Debug.Log("Joined lobby: " + e.Name);
				Connected = true;
				Host = false;
				Myself.Host = false;
				Myself.ID = byte.MaxValue;
				NetworkMessaging.SendNetworkMetaData(null, NetworkMessaging.MessageTarget.Host, 0);
				Options.RunInBackground = true;
			}
		}

		private void OnLobbyQuery(object sender, EventArgs e)
		{
			if (MainMenuController.Instance != null)
			{
				MainMenuController.Instance.NetworkWindow.UpdateLobbies();
			}
		}

		private void OnLobbyCreated(object sender, EventArgs e)
		{
			Debug.Log("Created lobby");
			Connected = true;
			Host = true;
			Self.InGame = true;
			Options.RunInBackground = true;
			if (!GameSettings.Instance.IsReferenceNull())
			{
				GameSettings.Instance.MyCompany.NetworkPlayerID = Self.ID;
				UpdateAllMeta();
			}
		}

		public void UpdateAllMeta()
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				SetLobbyMetaData("AvailableSpots", GetAvailableSpots().ToString());
				SetLobbyMetaData("Players", Players.Count.ToString());
				SetLobbyMetaData("CurrentYear", TimeOfDay.GetDateLocked().Year.ToString());
				SetLobbyMetaData("SaveIDs", string.Join("|", GameSettings.Instance.NetworkData.GetSomeUUIDs()));
				SetLobbyMetaData("ProtocolVersion", Versioning.SimpleNetworkVersionString);
				SetLobbyMetaData("DataMods", MarketSimulation.Active.SoftwareTypes.Values.Any((SoftwareType x) => x.Modded) ? "1" : "0");
				SetLobbyMetaData("Difficulty", Array.IndexOf(DifficultyValues.NetworkDifficultyComp, DifficultyValues.FindClosest(Options.Difficulty, DifficultyValues.NetworkDifficultyComp)).ToString());
				SetLobbyMetaData("DaysPerMonth", GameSettings.DaysPerMonth.ToString());
				SetLobbyMetaData("ForcedIPO", (GameSettings.Instance.YearlyNetworkIPO ?? 0f).ToString());
				SetLobbyMetaData("RoundLimit", GameSettings.Instance.RoundLimit.ToString());
				int roundType = (int)GameSettings.Instance.RoundType;
				SetLobbyMetaData("RoundType", roundType.ToString());
				SetLobbyMetaData("Host", Self.Name);
				SetLobbyMetaData("PasswordProtected", (GameSettings.Instance.NetworkData.Password != null) ? "1" : "0");
				SetLobbyMetaData("CodeMods", GameSettings.Instance.NetworkData.AllowCodeMods ? "1" : "0");
				SetLobbyMetaData("FurnitureMods", GameSettings.Instance.NetworkData.AllowModdedFurniture ? "1" : "0");
			}
		}

		private void Start()
		{
			GameObject gameObject = new GameObject("NetworkLayer");
			NetworkLayer networkLayer;
			if (SteamManager.Initialized)
			{
				if (!Options.ForceLAN)
				{
					networkLayer = gameObject.AddComponent<SteamLayer>();
				}
				else
				{
					Debug.Log("Using -LanMode toggle");
					networkLayer = gameObject.AddComponent<LANLayer>();
				}
			}
			else
			{
				Debug.Log("Steamworks was not initialized, falling back to LAN");
				networkLayer = gameObject.AddComponent<LANLayer>();
			}
			ValueTuple<string, string> nameAndIdentifier = networkLayer.GetNameAndIdentifier();
			string item = nameAndIdentifier.Item1;
			string item2 = nameAndIdentifier.Item2;
			Myself = (HostPlayer = new NetworkPlayer(item, item2, networkLayer.GetLocalConnectionData()));
			Myself.HandshakeComplete = true;
			Players.Add(Myself);
		}

		private void ClearWaiting()
		{
			for (int i = 0; i < Players.Count; i++)
			{
				NetworkPlayer networkPlayer = Players[i];
				if (networkPlayer.WaitingForReconnection)
				{
					networkPlayer.Connected = false;
					Players.RemoveAt(i);
					i--;
				}
			}
			_idMap.Clear();
			_connectionMap.Clear();
		}

		private static void SkipToSync()
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			bool flag = false;
			do
			{
				if (TimeOfDay.Instance.WaitingOnNetwork())
				{
					if (!Self.IsReady)
					{
						float minuteDelta = 60f - TimeOfDay.Instance.Minute;
						TimeOfDay.Instance.SimulateMinutes(minuteDelta);
						TimeOfDay.Instance.SetupTimeSync();
						TimeOfDay.SyncPlayerTime();
					}
					break;
				}
				flag |= TimeOfDay.Instance.AddHour(!flag, 60f);
			}
			while (!flag);
		}

		private void FixedUpdate()
		{
			if (!Ready)
			{
				return;
			}
			if (WaitingForReconnection)
			{
				if (Host)
				{
					if (Input.GetKeyDown(KeyCode.Escape))
					{
						ReconnectionTimer = 0f;
						ClearWaiting();
						NetworkMessaging.SendTryReconnection(true, Self.ID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
						WaitingForReconnection = false;
						GameSettings.ForcePause = false;
						WindowManager.ShowFullScreenMessage(null);
						NetworkMessaging.CheckIfDaySkip();
						return;
					}
					WindowManager.ShowFullScreenMessage("ReconnectMessage".Loc(Mathf.RoundToInt(15f - ReconnectionTimer)));
					ReconnectionTimer += Time.deltaTime;
					if (ReconnectionTimer >= 15f)
					{
						ReconnectionTimer = 0f;
						ClearWaiting();
						GameSettings.Instance.NetworkData.ReRegisterAllPlayers();
						WaitingForReconnection = false;
						GameSettings.ForcePause = false;
						WindowManager.ShowFullScreenMessage(null);
						NetworkMessaging.SendTryReconnection(true, Self.ID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
						NetworkMessaging.CheckIfDaySkip();
					}
					else if (Players.None((NetworkPlayer x) => x.WaitingForReconnection))
					{
						ReconnectionTimer = 0f;
						NetworkMessaging.SendTryReconnection(true, Self.ID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
						WaitingForReconnection = false;
						GameSettings.ForcePause = false;
						WindowManager.ShowFullScreenMessage(null);
						NetworkMessaging.CheckIfDaySkip();
					}
					else
					{
						NetworkMessaging.Tick(false, true);
					}
				}
				else
				{
					WindowManager.ShowFullScreenMessage("ReconnectMessage".Loc("?"));
					if (Input.GetKeyDown(KeyCode.Escape))
					{
						GameSettings.ForcePause = false;
						WaitingForReconnection = false;
						NetworkMessaging.DisconnectMyself();
						NetworkMessaging.SendAllNow();
						NetworkPlayer hostPlayer = HostPlayer;
						NetworkMessaging.HandleHostDisconnection(true, (hostPlayer != null) ? hostPlayer.Name : null, false);
					}
					else
					{
						NetworkMessaging.Tick(false, true);
					}
				}
				return;
			}
			if (ReconnectionTries > 0)
			{
				if (Input.GetKeyDown(KeyCode.Escape) || Players.Count <= 1)
				{
					GameSettings.ForcePause = false;
					NetworkPlayer hostPlayer2 = HostPlayer;
					NetworkMessaging.HandleHostDisconnection(true, (hostPlayer2 != null) ? hostPlayer2.Name : null, false);
					ReconnectionTimer = 0f;
					ReconnectionTries = 0;
					WindowManager.ShowFullScreenMessage(null);
					return;
				}
				WindowManager.ShowFullScreenMessage("ReconnectMessage".Loc(Mathf.RoundToInt((float)((ReconnectionTries - 1) * 5) + (5f - ReconnectionTimer))));
				ReconnectionTimer += Time.deltaTime;
				if (!(ReconnectionTimer >= 5f))
				{
					return;
				}
				ReconnectionTimer = 0f;
				ReconnectionTries--;
				if (ReconnectionTries > 0)
				{
					NetworkPlayer networkPlayer = Players.Where((NetworkPlayer x) => !x.Self).MinInstance((NetworkPlayer x) => (int)x.ID);
					if (Layer.TryReconnection(networkPlayer))
					{
						Debug.Log("Successfully sent reconnection message to " + networkPlayer.Name);
						WaitingForReconnection = true;
						ReconnectionTries = 0;
						NetworkMessaging.SendPlayerReady(Self.Ready, NetworkMessaging.MessageTarget.Everyone, 0);
					}
				}
				else
				{
					GameSettings.ForcePause = false;
					NetworkPlayer hostPlayer3 = HostPlayer;
					NetworkMessaging.HandleHostDisconnection(true, (hostPlayer3 != null) ? hostPlayer3.Name : null, false);
					WindowManager.ShowFullScreenMessage(null);
				}
				return;
			}
			HandleJoining();
			NetworkMessaging.Tick(false, true);
			_pingTimer -= Time.deltaTime;
			bool flag = false;
			if (_pingTimer < 0f)
			{
				flag = true;
				_pingTimer = 1f;
			}
			for (int num = 0; num < Players.Count; num++)
			{
				NetworkPlayer networkPlayer2 = Players[num];
				if (networkPlayer2.Self)
				{
					continue;
				}
				if (flag)
				{
					Layer.UpdatePing(networkPlayer2);
				}
				if (Host || networkPlayer2.Host)
				{
					networkPlayer2.KeepAlive += Time.deltaTime;
					if (networkPlayer2.KeepAlive > 10f)
					{
						NetworkMessaging.SendControlStatement(NetworkMessaging.ControlType.KeepAlive, NetworkMessaging.MessageTarget.Specifically, networkPlayer2.ID);
						networkPlayer2.KeepAlive = 0f;
					}
				}
				networkPlayer2.CurrentMinute += Time.deltaTime * networkPlayer2.CurrentGameSpeed;
				if (networkPlayer2.CurrentMinute >= 60f)
				{
					networkPlayer2.CurrentMinute -= 60f;
					networkPlayer2.CurrentHour++;
					if (networkPlayer2.CurrentHour >= 24)
					{
						networkPlayer2.CurrentHour = 0;
					}
				}
			}
			if (!(SelectorController.Instance != null) || !SelectorController.Instance.DoneLoading || GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			if (IsConnected && Players.Count > 1 && !Self.IsReady)
			{
				if (Players.Any((NetworkPlayer x) => x.VoteToSkip) && Players.All((NetworkPlayer x) => x.Self || x.VoteToSkip || x.AFK))
				{
					SkipToSync();
				}
				else if (!float.IsInfinity(GameSettings.Instance.RoundLimit) && Time.realtimeSinceStartup - TimeOfDay.Instance.RealTimeDayStart > GameSettings.Instance.RoundLimit)
				{
					TimeOfDay.Instance.RealTimeDayStart = Time.realtimeSinceStartup;
					switch (GameSettings.Instance.RoundType)
					{
					case NetworkLobby.RoundLimitType.DisablePause:
						GameSettings.Instance.EnforceTime(1);
						break;
					case NetworkLobby.RoundLimitType.ForceFullSpeed:
						GameSettings.Instance.EnforceTime(2);
						break;
					case NetworkLobby.RoundLimitType.Skipday:
						SkipToSync();
						break;
					}
				}
			}
			if (!GameSettings.Instance.PreSimActive)
			{
				for (int num2 = 0; num2 < Players.Count; num2++)
				{
					NetworkPlayer player = Players[num2];
					if (!player.WaitingToJoin)
					{
						continue;
					}
					player.WaitingToJoin = false;
					NetworkMessaging.SendPlayerSync(player.ID, true, NetworkMessaging.MessageTarget.Everyone, 0);
					foreach (Company allCompany in MarketSimulation.Active.GetAllCompanies())
					{
						if (allCompany.Logo == null)
						{
							allCompany.GenerateLogo();
						}
					}
					PlotArea plotArea = GameSettings.Instance.Plots.FirstOrDefault((PlotArea x) => x.PlayerStarterPlot && x.Owner == player.ID) ?? GameSettings.Instance.Plots.FirstOrDefault((PlotArea x) => x.PlayerStarterPlot && x.Owner == 0);
					if (plotArea != null)
					{
						NetworkMessaging.SendPlotOwner(plotArea.ID, player.ID, true, NetworkMessaging.MessageTarget.Everyone, player.ID);
					}
					GameSettings.Instance.MyCompany.ExtraWorth = GameSettings.Instance.MyCompany.GetPlayerExtraWorth();
					byte[] save = GameReader.Compress(GameReader.CreateDictionaryData(GameReader.NewLoadMode.Full, Writeable.LoadType.NetworkHost, player.ID));
					GameSettings.Instance.MyCompany.ExtraWorth = 0.0;
					NetworkMeta networkData = GameSettings.Instance.NetworkData;
					networkData.IncludePassword = true;
					NetworkMessaging.SendNetworkMetaData(networkData, NetworkMessaging.MessageTarget.Specifically, player.ID);
					networkData.IncludePassword = false;
					NetworkMessaging.SendSaveData(save, NetworkMessaging.MessageTarget.Specifically, player.ID);
					SetLobbyMetaData("AvailableSpots", GetAvailableSpots().ToString());
				}
			}
			if (!Players.Any((NetworkPlayer x) => x.SendingSave))
			{
				return;
			}
			int num3 = 0;
			float prog = -1f;
			for (int num4 = 0; num4 < Players.Count; num4++)
			{
				NetworkPlayer networkPlayer3 = Players[num4];
				if (!networkPlayer3.SendingSave)
				{
					continue;
				}
				num3++;
				lock (networkPlayer3)
				{
					if (networkPlayer3.SendQueue.Count <= 0)
					{
						continue;
					}
					NetworkPlayer.SendBuffer sendBuffer = networkPlayer3.SendQueue[0];
					int num5 = networkPlayer3.SendQueue[0].Data.Length;
					for (int num6 = 0; num6 < networkPlayer3.SendQueue.Count; num6++)
					{
						NetworkPlayer.SendBuffer sendBuffer2 = networkPlayer3.SendQueue[num6];
						if (sendBuffer2.Data.Length > num5)
						{
							num5 = sendBuffer2.Data.Length;
							sendBuffer = sendBuffer2;
						}
					}
					prog = (float)sendBuffer.Offset / (float)sendBuffer.Data.Length;
					break;
				}
			}
			WindowManager.ShowFullScreenMessage("SynchronizingPlayers".Loc(num3), prog);
		}

		public void FreeFloatingID()
		{
			while (FloatingID < byte.MaxValue)
			{
				if (Players.None((NetworkPlayer x) => x.ID == FloatingID + 1))
				{
					FloatingID++;
				}
			}
		}

		public void UpdateSyncScreen()
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = Players.Count((NetworkPlayer x) => x.SendingSave);
				bool flag = num > 0;
				if (flag != _syncScreenActive)
				{
					_syncScreenActive = flag;
					GameSettings.ForcePause = flag;
					WindowManager.ShowFullScreenMessage(flag ? "SynchronizingPlayers".Loc(num) : null);
				}
				else if (flag && !WindowManager.FullScreenMessageActive())
				{
					WindowManager.ShowFullScreenMessage("SynchronizingPlayers".Loc(num));
				}
			}
		}

		public float GetReceiveMessageProgress(byte type)
		{
			for (int i = 0; i < Players.Count; i++)
			{
				NetworkPlayer networkPlayer = Players[i];
				if (networkPlayer.BufferLength > 0 && networkPlayer.CurrentBuffer[0] == type)
				{
					return (float)networkPlayer.BufferOffset / (float)networkPlayer.BufferLength;
				}
			}
			return -1f;
		}

		public static NetworkPlayer GetPlayer(byte id)
		{
			if (id == byte.MaxValue)
			{
				return null;
			}
			for (int i = 0; i < Instance.Players.Count; i++)
			{
				NetworkPlayer networkPlayer = Instance.Players[i];
				if (networkPlayer.ID == id)
				{
					return networkPlayer;
				}
			}
			return null;
		}

		public static bool IsPlayerOffline(byte id)
		{
			if (id == byte.MaxValue)
			{
				return true;
			}
			for (int i = 0; i < Instance.Players.Count; i++)
			{
				NetworkPlayer networkPlayer = Instance.Players[i];
				if (networkPlayer.ID == id)
				{
					return !networkPlayer.Connected;
				}
			}
			return true;
		}

		public static NetworkPlayer GetPlayer(string uniqueID)
		{
			NetworkPlayer value;
			if (Instance._idMap.TryGetValue(uniqueID, out value))
			{
				if (value.Connected)
				{
					return value;
				}
				Instance._idMap.Remove(uniqueID);
			}
			NetworkPlayer networkPlayer = Instance.Players.FirstOrDefault((NetworkPlayer x) => uniqueID.Equals(x.ActualUniqueID));
			if (networkPlayer != null)
			{
				Instance._idMap[uniqueID] = networkPlayer;
			}
			return networkPlayer;
		}

		public static NetworkPlayer GetPlayer(object connection)
		{
			connection = Instance.Layer.TransformConnection(connection);
			NetworkPlayer value;
			if (Instance._connectionMap.TryGetValue(connection, out value))
			{
				if (value.Connected)
				{
					return value;
				}
				Instance._connectionMap.Remove(connection);
			}
			NetworkPlayer networkPlayer = Instance.Players.FirstOrDefault((NetworkPlayer x) => connection.Equals(Instance.Layer.TransformConnection(x.ConnectionObject)));
			if (networkPlayer != null)
			{
				Instance._connectionMap[connection] = networkPlayer;
			}
			return networkPlayer;
		}

		public void RemoveFromMap(NetworkPlayer pl)
		{
			if (pl.ActualUniqueID != null)
			{
				_idMap.Remove(pl.ActualUniqueID);
			}
			if (pl.ConnectionObject != null)
			{
				_connectionMap.Remove(pl.ConnectionObject);
			}
		}

		public void ResetIDMap()
		{
			_idMap.Clear();
			_connectionMap.Clear();
		}

		public static bool OutOfIDs()
		{
			return GameSettings.Instance.NetworkData.NextID == 254;
		}

		public static byte GetAvailableID()
		{
			NetworkMeta networkData = GameSettings.Instance.NetworkData;
			networkData.NextID++;
			return networkData.NextID;
		}

		public static void AddDirtyLoss(ILossable l, SoftwareProduct.LossType type, float val)
		{
			if (IsConnected)
			{
				Instance.DirtyLoss.AddUp(new KeyValuePair<ILossable, SoftwareProduct.LossType>(l, type), val);
			}
		}

		public static void AddDirtyMarketing(IMarketable p)
		{
			if (IsClient)
			{
				Instance.DirtyMarketing.Add(p);
			}
		}

		public int GetAvailableSpots(NetworkPlayer excluding = null)
		{
			return Mathf.Max(0, GameSettings.Instance.Plots.Count((PlotArea x) => x.PlayerStarterPlot && x.Owner == 0) - Players.Count((NetworkPlayer x) => x != excluding && !x.InGame));
		}

		public bool CanJoin(NetworkPlayer player, int? id = null)
		{
			if (id.HasValue)
			{
				if (Players.Any((NetworkPlayer x) => x != player && x.ID == id.Value))
				{
					Debug.Log(player.Name + " could not join since somebody was already using their ID");
					return false;
				}
				if (GameSettings.Instance.Plots.Any((PlotArea x) => x.Owner == id.Value))
				{
					return true;
				}
			}
			if (GetAvailableSpots(player) > 0)
			{
				return true;
			}
			Debug.Log(player.Name + " could not join since there are no spots left");
			if (!_joinWarned && Players.Count < 4)
			{
				ChatWindow.ReceiveMessage(new NetworkPlayer("Software Inc.", null, null), false, true, "JoinFullFail".Loc(player.Name), null);
				_joinWarned = true;
			}
			return false;
		}

		public static void SetLobbyMetaData(string var, string value)
		{
			if (IsHost && NetworkLayer.Active.CurrentLobby != null)
			{
				NetworkLayer.Active.CurrentLobby.UpdateLobbyMeta(var, value);
				NetworkLayer.Active.SetLobbyMeta(NetworkLayer.Active.CurrentLobby, var, value);
			}
		}

		public bool MakeHost()
		{
			try
			{
				Layer.MakeHost();
				HostPlayer = Self;
				Self.Host = true;
				Host = true;
				UpdateAllMeta();
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
				return false;
			}
			return true;
		}

		public void KickPlayer(NetworkPlayer player, bool ban)
		{
			if (!IsHost || !player.Connected)
			{
				return;
			}
			if (ban)
			{
				string banInfo = Layer.GetBanInfo(player);
				if (banInfo != null)
				{
					GameSettings.Instance.BanList.Add(banInfo);
				}
			}
			NetworkMessaging.SendDisconnectPlayer(true, NetworkMessaging.MessageTarget.Specifically, player.ID);
			if (player.HandshakeComplete)
			{
				NetworkMessaging.SendData(player.ID, NetworkMessaging.MessageType.DisconnectPlayer, new byte[1] { 1 }, false, NetworkMessaging.MessageTarget.EveryoneExcept, player.ID);
			}
			NetworkMessaging.SendAllNow();
			NetworkMessaging.Disconnect(player, true, true);
			if (ban)
			{
				Company playerCompany = player.GetPlayerCompany();
				if (playerCompany != null)
				{
					List<Company> list = playerCompany.GenerateStockCompanyList();
					playerCompany.BuyOut((list == null || list.Count == 0) ? null : list, false, SDateTime.Now(), false);
					GameSettings.Instance.ClearBuyouts();
				}
			}
		}
	}
}
