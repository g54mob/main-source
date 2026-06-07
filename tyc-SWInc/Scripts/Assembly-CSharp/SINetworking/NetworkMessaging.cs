using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using DevConsole;
using UnityEngine;

namespace SINetworking
{
	public static class NetworkMessaging
	{
		[AttributeUsage(AttributeTargets.Method)]
		public class RPCCall : Attribute
		{
			public bool ContinueIfNotOnline = true;

			public bool OnlyInGame;
		}

		[AttributeUsage(AttributeTargets.Parameter)]
		public class OptimizeParameter : Attribute
		{
			public string DefaultValue;

			public OptimizeParameter(string defaultValue)
			{
				DefaultValue = defaultValue;
			}
		}

		public enum ControlType
		{
			ReadyForPlay = 0,
			SkipToNextDay = 1,
			KeepAlive = 2,
			VoteToSkip = 3,
			FixCashflow = 4,
			UUIDDirty = 5
		}

		public enum MessageTarget
		{
			Everyone = 0,
			EveryoneButMe = 1,
			EveryoneExcept = 2,
			Specifically = 3,
			Host = 4
		}

		public enum SyncType
		{
			Deal = 0,
			Plot = 1,
			Stock = 2,
			ProductIP = 3,
			AddonIP = 4,
			FrameworkIP = 5,
			Employee = 6
		}

		public enum DiagnosticSheet
		{
			Company = 0
		}

		public enum MessageType
		{
			AssignID = 0,
			ModMessage = 1,
			NewConnection = 2,
			NetworkMetaData = 3,
			SaveData = 4,
			PlayerCompany = 5,
			DisconnectPlayer = 6,
			ControlStatement = 7,
			BroadCastPlayer = 8,
			PlayerMessage = 9,
			PlayerSync = 10,
			PlayerReady = 11,
			PlayerTime = 12,
			PlotOwner = 13,
			DestroyLandmark = 14,
			PlaceRoad = 15,
			SetGhostCar = 16,
			ClearGhostCar = 17,
			MakeTransaction = 18,
			AddTax = 19,
			NetworkIDCallback = 20,
			LeadDesigner = 21,
			RequestNetworkID = 22,
			MoveLeadDesigner = 23,
			FinishLeadProject = 24,
			AddSimulatedCompany = 25,
			TradeStock = 26,
			ExtraWorth = 27,
			BuyOut = 28,
			AddTechLevel = 29,
			TransferPatent = 30,
			AddResearch = 31,
			TransferFramework = 32,
			AddFramework = 33,
			AddProduct = 34,
			AddAddOn = 35,
			UpdateSubMarkets = 36,
			TradeIP = 37,
			ProductCashflow = 38,
			ProductUserbase = 39,
			AddFans = 40,
			ArchiveProduct = 41,
			ChangeFollowers = 42,
			UpdateMarketing = 43,
			ProductPrototype = 44,
			StartDev = 45,
			ReleaseDev = 46,
			AddonPrototype = 47,
			EndAddonDev = 48,
			UpdateStockMarket = 49,
			AddStockMarket = 50,
			UpdateProduct = 51,
			UpdateFramework = 52,
			ChangeBugs = 53,
			ChangePhysicalCopies = 54,
			RunProductScripts = 55,
			RunCopyScripts = 56,
			CreateDigitalPlatform = 57,
			SignDigitalPlatform = 58,
			RegisterLocalPlayerPlatformQuery = 59,
			DistributionCut = 60,
			DistributionState = 61,
			DistributionStats = 62,
			ChangePlatformAccept = 63,
			DistributionLoad = 64,
			DistributionSales = 65,
			ExclusiveStore = 66,
			DistributionBandwidth = 67,
			SoftwareID = 68,
			ChangePrice = 69,
			MakeSubsidiary = 70,
			ScheduleRelease = 71,
			AddDeal = 72,
			CancelDeal = 73,
			UpdateProtoQuality = 74,
			Port = 75,
			RequestSync = 76,
			RequestSyncVerify = 77,
			AddLoss = 78,
			AddonSimulation = 79,
			AddProductLoadIncident = 80,
			AddProductRep = 81,
			FrameworkPayment = 82,
			AIResearch = 83,
			DividendStats = 84,
			BroadcastUUID = 85,
			InitialGameSettings = 86,
			RainSync = 87,
			AwardWinners = 88,
			EmployerScore = 89,
			BusinessRep = 90,
			TakeOverData = 91,
			NewspaperTakeover = 92,
			TryReconnection = 93,
			Notification = 94,
			Diagnostics = 95,
			SyncMoney = 96,
			NewRoom = 97,
			NewRoomSegment = 98,
			NewFurniture = 99,
			MoveFurniture = 100,
			DestroyNetworkObject = 101,
			UpdateRoomAtrium = 102,
			ObjectStyle = 103,
			RoomEdges = 104,
			VerifyRoomData = 105,
			NewTrade = 106,
			TradeState = 107,
			AllIDs = 108,
			NewNetworkDeal = 109,
			NetworkDealComplete = 110,
			NetworkDealCancel = 111,
			NetworkDealSync = 112,
			VerifyDeal = 113,
			UpdateWorkItem = 114,
			AddWorkRoyalty = 115,
			BeginTakeover = 116,
			UpdateCompanyLogo = 117,
			LeadDesignerSync = 118,
			PublishingDeal = 119,
			PublishingEcoChange = 120,
			UpdateCompanyBuildingSign = 121,
			StartLeadPoach = 122,
			UpdateRoundLimit = 123,
			UpdateRoundType = 124,
			GenerateProductReview = 125,
			HostGameTime = 126,
			UpdateCloudService = 127,
			UpdateCloudUsage = 128,
			NetworkPrintDealChange = 129,
			CancelNetworkPrintDeal = 130,
			VerifyPrintDeals = 131,
			ChangePrintMarkup = 132,
			MarketEventData = 133,
			SetAIAutonomy = 134,
			AddReviews = 135
		}

		private static Dictionary<KeyValuePair<SyncType, uint>, float> _syncTimer = new Dictionary<KeyValuePair<SyncType, uint>, float>();

		private static Dictionary<KeyValuePair<SyncType, uint>, Action<bool>> _syncCallbacks = new Dictionary<KeyValuePair<SyncType, uint>, Action<bool>>();

		private static Dictionary<KeyValuePair<SyncType, uint>, Action> _syncNetworkMessage = new Dictionary<KeyValuePair<SyncType, uint>, Action>();

		private static TwoWayDictionary<byte, ModController.DLLMod> _modMapping = new TwoWayDictionary<byte, ModController.DLLMod>();

		private static Dictionary<DiagnosticSheet, ValueTuple<string, Func<object, string>>[]> _sheetColumns = new Dictionary<DiagnosticSheet, ValueTuple<string, Func<object, string>>[]> { 
		{
			DiagnosticSheet.Company,
			new ValueTuple<string, Func<object, string>>[8]
			{
				new ValueTuple<string, Func<object, string>>("Name", (object x) => ((Company)x).Name),
				new ValueTuple<string, Func<object, string>>("Bank", (object x) => ((Company)x).Money.ToString("F2")),
				new ValueTuple<string, Func<object, string>>("Worth", (object x) => ((Company)x).GetMoneyWithInsurance(true, true).ToString("F2")),
				new ValueTuple<string, Func<object, string>>("Fans", (object x) => ((Company)x).Fans.ToString("F0")),
				new ValueTuple<string, Func<object, string>>("Products", (object x) => ((Company)x).Products.Count.ToString()),
				new ValueTuple<string, Func<object, string>>("Patents", (object x) => ((Company)x).Patents.Count.ToString()),
				new ValueTuple<string, Func<object, string>>("Listed", (object x) => (1.0 - ((Company)x).GetShare()).ToPercent()),
				new ValueTuple<string, Func<object, string>>("Owner", delegate(object x)
				{
					Company ownerCompany = ((Company)x).OwnerCompany;
					return ((ownerCompany != null) ? ownerCompany.Name : null) ?? "N/A";
				})
			}
		} };

		private static MemoryStream _stream = new MemoryStream();

		public const int MessageTypeCount = 136;

		public static Dictionary<uint, SoftwareProduct> DigitalPlatforms = new Dictionary<uint, SoftwareProduct>();

		public static void RegisterMod(byte id, ModController.DLLMod mod)
		{
			ModController.DLLMod value;
			if (_modMapping.TryGetValue(id, out value))
			{
				ModController.HandleException(mod.ItemTitle, new Exception("Can't register mod network id " + id + " for " + mod.ItemTitle + " as it is already registered to " + value.ItemTitle));
			}
			else
			{
				_modMapping[id] = mod;
			}
		}

		public static void UnRegisterMod(byte id, ModController.DLLMod mod)
		{
			ModController.DLLMod value;
			if (_modMapping.TryGetValue(id, out value) && value == mod)
			{
				_modMapping.Remove(id);
			}
		}

		public static bool IsSyncing(SyncType type, uint id)
		{
			return _syncCallbacks.ContainsKey(new KeyValuePair<SyncType, uint>(type, id));
		}

		public static void CleanUpSync()
		{
			_syncTimer.Clear();
			foreach (KeyValuePair<KeyValuePair<SyncType, uint>, Action<bool>> syncCallback in _syncCallbacks)
			{
				try
				{
					syncCallback.Value(false);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			_syncCallbacks.Clear();
			_syncNetworkMessage.Clear();
		}

		private static bool CanSync(SyncType type, uint id)
		{
			KeyValuePair<SyncType, uint> key = new KeyValuePair<SyncType, uint>(type, id);
			float value;
			if (_syncTimer.TryGetValue(key, out value))
			{
				if (Time.realtimeSinceStartup - value >= 0f)
				{
					_syncTimer.Remove(key);
					return true;
				}
				return false;
			}
			return true;
		}

		private static void ApplySync(SyncType type, uint id, float wait = 3f)
		{
			_syncTimer[new KeyValuePair<SyncType, uint>(type, id)] = Time.realtimeSinceStartup + wait;
		}

		private static void SyncApproved(SyncType type, uint id, bool approved)
		{
			if (!approved)
			{
				Debug.Log(string.Concat("Request for ", type, ": ", id, " was denied"));
			}
			KeyValuePair<SyncType, uint> key = new KeyValuePair<SyncType, uint>(type, id);
			Action<bool> value;
			if (_syncCallbacks.TryGetValue(key, out value))
			{
				value(approved);
				_syncCallbacks.Remove(key);
			}
			Action value2;
			if (_syncNetworkMessage.TryGetValue(key, out value2))
			{
				if (approved)
				{
					value2();
				}
				_syncNetworkMessage.Remove(key);
			}
		}

		public static void GetGlobalNetworkID(INetworkID o, Action<uint> callback)
		{
			if (NetworkManager.IsHost)
			{
				NetworkManager.Instance.SetAndRegisterNetworkObject(o);
				callback(o.NetworkID);
			}
			else
			{
				SendRequestNetworkID(NetworkManager.Instance.AddIDCallback(o, callback), NetworkManager.NetworkIDType.GlobalObject, MessageTarget.Host, 0);
			}
		}

		public static void GetGlobalNetworkID(Action<uint> callback, NetworkManager.NetworkIDType type)
		{
			if (NetworkManager.IsHost)
			{
				callback(NetworkManager.Instance.GetNetworkID(type));
			}
			else
			{
				SendRequestNetworkID(NetworkManager.Instance.AddIDCallback(callback), type, MessageTarget.Host, 0);
			}
		}

		public static void SyncedNetworkMessage(SyncType type, uint id, Action<bool> callback, Action message, Action wait)
		{
			if (!NetworkManager.IsConnected)
			{
				callback(true);
				return;
			}
			if (NetworkManager.IsHost)
			{
				bool flag = CanSync(type, id);
				callback(flag);
				if (flag && message != null)
				{
					message();
				}
				ApplySync(type, id, flag ? 2f : 1f);
				return;
			}
			KeyValuePair<SyncType, uint> key = new KeyValuePair<SyncType, uint>(type, id);
			if (callback != null)
			{
				_syncCallbacks[key] = callback;
			}
			if (message != null)
			{
				_syncNetworkMessage[key] = message;
			}
			if (wait != null)
			{
				wait();
			}
			SendRequestSync(type, id, false, MessageTarget.Host, 0);
		}

		private static bool VerifyMessageID(SyncType type, uint id, uint verification, uint newValue)
		{
			switch (type)
			{
			case SyncType.Employee:
			{
				Employee res2;
				if (TryGet(NetworkManager.Instance.GetNetworkObject(id) as Employee, "verify lead designer hire", id, out res2))
				{
					if (res2.EmployerID.RealID == verification)
					{
						res2.EmployerID.TempID = newValue;
						return true;
					}
					return false;
				}
				return false;
			}
			case SyncType.Plot:
			{
				PlotArea res;
				if (TryGet(GameSettings.Instance.GetPlot(id), "verify plot purchase", id, out res))
				{
					return res.CheckOwner((byte)verification, (byte)newValue);
				}
				return false;
			}
			default:
				return false;
			}
		}

		public static void VerifiedNetworkMessage(SyncType type, uint id, uint verification, uint newValue, Action<bool> callback, Action message, Action wait)
		{
			if (!NetworkManager.IsConnected)
			{
				callback(true);
				return;
			}
			if (NetworkManager.IsHost)
			{
				callback(true);
				if (message != null)
				{
					message();
				}
				return;
			}
			KeyValuePair<SyncType, uint> key = new KeyValuePair<SyncType, uint>(type, id);
			if (callback != null)
			{
				_syncCallbacks[key] = callback;
			}
			if (message != null)
			{
				_syncNetworkMessage[key] = message;
			}
			if (wait != null)
			{
				wait();
			}
			SendRequestSyncVerify(type, id, verification, newValue, false, MessageTarget.Host, 0);
		}

		public static void HandleHostDisconnection(bool inGame, string hostName, bool kicked)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				GameSettings.Instance.NetworkData.ReRegisterAllPlayers();
				MarketSimulation.Active.ResetSoftwareIDs();
				SaveGameManager.Instance.QuickSave("HostDisconnectSave".Loc(hostName));
				NetworkMeta.SetDirty();
				GameSettings.Instance.NetworkData.ReRegisterAllPlayers();
			}
			NetworkManager.Instance.Connected = false;
			NetworkPlayer.ReadyStatus ready = NetworkManager.Self.Ready;
			NetworkManager.Instance.CleanUpEverything(false, false);
			NetworkManager.Self.Ready = ready;
			NetworkManager.Instance.ResetNetworkIDs();
			NetworkManager.Instance.ResetWorkIDs();
			CheckIfDaySkip();
			WindowManager.Instance.ShowMessageBox((kicked ? "HostKicked" : (inGame ? "HostDisconnectInGame" : "HostDisconnect")).Loc(), true, DialogWindow.DialogType.Information, new KeyValuePair<string, Action>("OK", delegate
			{
				if (ActorCustomization.Instance != null)
				{
					ActorCustomization.Instance.CancelDirectly();
				}
			}));
		}

		public static void Disconnect(NetworkPlayer player, bool proper, bool kicked)
		{
			Debug.Log((player.Host ? "You" : player.Name) + " got " + (kicked ? "kicked" : "disconnected"));
			if (player.InGame)
			{
				PlayerMessage(player, "PlayerDisconnect".Loc().FontColor(Color.red), true, 0u);
			}
			NetworkManager.Instance.ResetIDMap();
			NetworkManager.Instance.TradeController.CancelAllTradesFor(player, true);
			player.Connected = false;
			if (!GameSettings.Instance.IsReferenceNull())
			{
				GameSettings.Instance.NetworkData.ReRegisterAllPlayers();
				foreach (RoadNode item in RoadManager.Instance.GetParkingMesh())
				{
					if (item.GhostCar != null && item.GhostCar.OwnerPlayer == player.ID)
					{
						RoadManager.Instance.DestroyCar(item.GhostCar);
						item.GhostCar = null;
					}
				}
			}
			if (player.Host)
			{
				bool flag = true;
				if (ActorCustomization.Instance != null)
				{
					ActorCustomization.Instance.LoadingPanel.SetActive(false);
					flag = false;
				}
				if (MainMenuController.Instance != null)
				{
					NetworkManager.Instance.HandleCancelLobby();
					flag = false;
				}
				if (flag && proper && !kicked && NetworkManager.Instance.Players.Count > 2)
				{
					GameSettings.ForcePause = true;
					NetworkManager.Instance.Players.Remove(player);
					NetworkManager.Instance.Players.RemoveAll((NetworkPlayer x) => !x.InGame);
					NetworkManager.Instance.ResetIDMap();
					NetworkManager.Instance.Players.ForEach(delegate(NetworkPlayer x)
					{
						x.SendQueue.Clear();
					});
					if (NetworkManager.Instance.Players.MinInstance((NetworkPlayer x) => (int)x.ID) == NetworkManager.Self)
					{
						if (NetworkManager.Instance.MakeHost())
						{
							SaveGameManager.Instance.QuickSave("HostDisconnectSave".Loc(player.Name));
							NetworkMeta.SetDirty();
							NetworkManager.Instance.Players.Where((NetworkPlayer x) => !x.Self).ForEachEnum(delegate(NetworkPlayer x)
							{
								x.WaitingForReconnection = true;
							});
							NetworkManager.Instance.WaitingForReconnection = true;
						}
						else
						{
							GameSettings.ForcePause = false;
							HandleHostDisconnection(true, player.Name, false);
						}
					}
					else
					{
						SaveGameManager.Instance.QuickSave("HostDisconnectSave".Loc(player.Name));
						NetworkManager.Instance.ReconnectionTries = 3;
						NetworkManager.Instance.ReconnectionTimer = 5f;
					}
				}
				else
				{
					HandleHostDisconnection(flag, player.Name, kicked);
				}
			}
			else
			{
				player.Connected = false;
				NetworkManager.Instance.ClearPlayer(player);
				NetworkManager.Instance.Players.Remove(player);
				NetworkManager.Instance.RemoveFromMap(player);
				CheckIfDaySkip();
				if (NetworkManager.IsHost && player.InGame && !GameSettings.Instance.IsReferenceNull())
				{
					SaveGameManager.Instance.QuickSave("ClientDisconnectSave".Loc(player.Name));
					NetworkMeta.SetDirty();
					NetworkManager.SetLobbyMetaData("Players", NetworkManager.Instance.Players.Count.ToString());
					NetworkManager.SetLobbyMetaData("AvailableSpots", NetworkManager.Instance.GetAvailableSpots().ToString());
					NetworkManager.SetLobbyMetaData("SaveIDs", string.Join("|", GameSettings.Instance.NetworkData.GetSomeUUIDs()));
				}
			}
			if (!GameSettings.Instance.IsReferenceNull())
			{
				GameSettings.Instance.RemovePlayerFromCloudService(player.ID);
			}
			NetworkManager.Instance.UpdateSyncScreen();
		}

		public static void SendData(MessageType type, byte[] data, bool onlyInGame, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			SendData(NetworkManager.Self.ID, type, data, onlyInGame, target, targetID);
		}

		public static void SendData(byte sender, MessageType type, byte[] data, bool onlyInGame, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (NetworkManager.Instance.Host)
			{
				for (int i = 0; i < NetworkManager.Instance.Players.Count; i++)
				{
					NetworkPlayer networkPlayer = NetworkManager.Instance.Players[i];
					if ((!onlyInGame || networkPlayer.InGame) && ForPlayer(networkPlayer, target, targetID) && !networkPlayer.Self)
					{
						ActuallySendData(networkPlayer, sender, type, data, MessageTarget.Everyone, 0);
					}
				}
				return;
			}
			NetworkPlayer self = NetworkManager.Self;
			switch (target)
			{
			case MessageTarget.Everyone:
				ActuallySendData(NetworkManager.Instance.HostPlayer, sender, type, data, MessageTarget.EveryoneExcept, self.ID);
				break;
			case MessageTarget.EveryoneButMe:
				ActuallySendData(NetworkManager.Instance.HostPlayer, sender, type, data, MessageTarget.EveryoneExcept, self.ID);
				break;
			case MessageTarget.EveryoneExcept:
				ActuallySendData(NetworkManager.Instance.HostPlayer, sender, type, data, target, targetID);
				break;
			case MessageTarget.Specifically:
				if (targetID != self.ID)
				{
					ActuallySendData(NetworkManager.Instance.HostPlayer, sender, type, data, target, targetID);
				}
				break;
			case MessageTarget.Host:
				ActuallySendData(NetworkManager.Instance.HostPlayer, sender, type, data, MessageTarget.Host, 0);
				break;
			default:
				throw new ArgumentOutOfRangeException("target", target, null);
			}
		}

		public static bool ReconnectMessage(NetworkPlayer player)
		{
			try
			{
				if (NetworkLayer.Active.SendData(player, GetSendData(NetworkManager.Self.ID, MessageType.TryReconnection, new byte[2]
				{
					0,
					NetworkManager.Self.ID
				}, MessageTarget.Specifically, player.ID), true))
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
				return false;
			}
			return true;
		}

		public static byte[] GetSendData(byte sender, MessageType type, byte[] data, MessageTarget target, byte targetID)
		{
			byte[] bytes = BitConverter.GetBytes(data.Length + 4);
			byte[] array = new byte[data.Length + 8];
			for (int i = 0; i < 4; i++)
			{
				array[i] = bytes[i];
			}
			array[4] = (byte)type;
			array[5] = (byte)target;
			array[6] = targetID;
			array[7] = sender;
			for (int j = 0; j < data.Length; j++)
			{
				array[j + 8] = data[j];
			}
			return array;
		}

		private static void ActuallySendData(NetworkPlayer player, byte sender, MessageType type, byte[] data, MessageTarget target, byte targetID, bool includeMeta = true)
		{
			lock (player)
			{
				if (includeMeta)
				{
					player.SentPerType[(int)type] += (uint)(data.Length + 8);
					byte[] bytes = BitConverter.GetBytes(data.Length + 4);
					player.SendQueue.Add(new NetworkPlayer.SendBuffer(bytes));
					player.SendQueue.Add(new NetworkPlayer.SendBuffer(new byte[4]
					{
						(byte)type,
						(byte)target,
						targetID,
						sender
					}));
					player.SendQueue.Add(new NetworkPlayer.SendBuffer(data));
				}
				else
				{
					player.SentPerType[(int)type] += (uint)(data.Length + 4);
					byte[] bytes2 = BitConverter.GetBytes(data.Length);
					player.SendQueue.Add(new NetworkPlayer.SendBuffer(bytes2));
					player.SendQueue.Add(new NetworkPlayer.SendBuffer(data));
				}
				player.Overhead += 4u;
				uint currentQueued = player.CurrentQueued;
				if (currentQueued > player.MaxQueued)
				{
					player.MaxQueued = currentQueued;
				}
			}
		}

		private static bool ForPlayer(NetworkPlayer player, MessageTarget target, byte targetID)
		{
			switch (target)
			{
			case MessageTarget.Everyone:
				return true;
			case MessageTarget.EveryoneButMe:
				return !player.Self;
			case MessageTarget.EveryoneExcept:
				return player.ID != targetID;
			case MessageTarget.Specifically:
				return player.ID == targetID;
			case MessageTarget.Host:
				return player.Host;
			default:
				return false;
			}
		}

		private static bool ForSelf(MessageTarget target, byte targetID)
		{
			if (NetworkManager.IsConnected)
			{
				return ForPlayer(NetworkManager.Self, target, targetID);
			}
			switch (target)
			{
			case MessageTarget.Everyone:
				return true;
			case MessageTarget.EveryoneButMe:
				return false;
			case MessageTarget.EveryoneExcept:
				return true;
			case MessageTarget.Specifically:
				return targetID == ((!GameSettings.Instance.IsReferenceNull()) ? GameSettings.Instance.MyCompany.NetworkPlayerID : NetworkManager.LocalPlayerID);
			case MessageTarget.Host:
				return false;
			default:
				return false;
			}
		}

		private static bool ShouldSend(MessageTarget target, byte targetID, bool onlyInGame)
		{
			if (NetworkManager.IsConnected && NetworkManager.Instance.Players.Count > 1)
			{
				switch (target)
				{
				case MessageTarget.Everyone:
					if (onlyInGame)
					{
						return NetworkManager.Instance.Players.Any((NetworkPlayer x) => !x.Self && x.InGame);
					}
					return true;
				case MessageTarget.EveryoneButMe:
					if (onlyInGame)
					{
						return NetworkManager.Instance.Players.Any((NetworkPlayer x) => !x.Self && x.InGame);
					}
					return true;
				case MessageTarget.EveryoneExcept:
					if (onlyInGame)
					{
						return NetworkManager.Instance.Players.Any((NetworkPlayer x) => !x.Self && x.ID != targetID && x.InGame);
					}
					return true;
				case MessageTarget.Specifically:
					if (targetID != NetworkManager.Self.ID)
					{
						if (onlyInGame)
						{
							NetworkPlayer player = NetworkManager.GetPlayer(targetID);
							if (player == null)
							{
								return false;
							}
							return player.InGame;
						}
						return true;
					}
					return false;
				case MessageTarget.Host:
					return !NetworkManager.IsHost;
				}
			}
			return false;
		}

		public static void ReceiveMessage(NetworkPlayer from, byte[] data)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				MessageType messageType = (MessageType)memoryStream.ReadByte();
				MessageTarget target = (MessageTarget)memoryStream.ReadByte();
				byte targetID = (byte)memoryStream.ReadByte();
				NetworkPlayer networkPlayer = NetworkManager.GetPlayer((byte)memoryStream.ReadByte()) ?? from;
				from.ReceivedPerType[(int)messageType] += (uint)(data.Length + 4);
				from.Overhead += 4u;
				if (messageType == MessageType.TryReconnection && data[4] == 0)
				{
					networkPlayer = from;
				}
				if (NetworkManager.Instance.Host)
				{
					for (int i = 0; i < NetworkManager.Instance.Players.Count; i++)
					{
						NetworkPlayer networkPlayer2 = NetworkManager.Instance.Players[i];
						if (ForPlayer(networkPlayer2, target, targetID))
						{
							if (networkPlayer2.Self)
							{
								ActuallyReceiveMessage(networkPlayer, messageType, memoryStream);
							}
							else if (from.HandshakeComplete)
							{
								ActuallySendData(networkPlayer2, networkPlayer.ID, messageType, data, target, targetID, false);
							}
						}
					}
				}
				else if (ForPlayer(NetworkManager.Self, target, targetID))
				{
					ActuallyReceiveMessage(networkPlayer, messageType, memoryStream);
				}
			}
		}

		private static void ActuallyReceiveMessage(NetworkPlayer from, MessageType type, byte[] data)
		{
			using (MemoryStream stream = new MemoryStream(data))
			{
				ActuallyReceiveMessage(from, type, stream);
			}
		}

		public static string[] GetDiagnosticSheet(DiagnosticSheet type)
		{
			object[] array = null;
			ValueTuple<string, Func<object, string>>[] columns = _sheetColumns.GetOrNull(type);
			if (columns == null)
			{
				return Array.Empty<string>();
			}
			if (type == DiagnosticSheet.Company)
			{
				array = (from object x in MarketSimulation.Active.GetAllCompanies()
					orderby columns[0].Item2(x)
					select x).ToArray();
			}
			if (array == null)
			{
				return Array.Empty<string>();
			}
			string[] array2 = new string[columns.Length * (array.Length + 1)];
			for (int num = 0; num < columns.Length; num++)
			{
				ValueTuple<string, Func<object, string>> valueTuple = columns[num];
				SetDiagnosticData(array2, valueTuple.Item1, 0, num, columns.Length);
			}
			for (int num2 = 0; num2 < array.Length; num2++)
			{
				for (int num3 = 0; num3 < columns.Length; num3++)
				{
					SetDiagnosticData(array2, columns[num3].Item2(array[num2]), num2 + 1, num3, columns.Length);
				}
			}
			return array2;
		}

		private static string GetDiagnosticData(string[] data, int row, int column, int columns)
		{
			return data[row * columns + column];
		}

		private static void SetDiagnosticData(string[] data, string value, int row, int column, int columns)
		{
			data[row * columns + column] = value;
		}

		public static string CompareDiagnosticSheets(DiagnosticSheet type, string[] mine, string[] theirs)
		{
			ValueTuple<string, Func<object, string>>[] orNull = _sheetColumns.GetOrNull(type);
			if (orNull == null)
			{
				return "Couldn't find type " + type;
			}
			int num = orNull.Length;
			StringBuilder stringBuilder = new StringBuilder();
			int num2 = mine.Length / num;
			int num3 = theirs.Length / num;
			for (int i = 0; i < num; i++)
			{
				string diagnosticData = GetDiagnosticData(mine, 0, i, num);
				if (i == 0)
				{
					stringBuilder.Append(diagnosticData + "\t");
					continue;
				}
				stringBuilder.Append(diagnosticData + " mine\t");
				stringBuilder.Append(diagnosticData + " theirs\t");
			}
			stringBuilder.AppendLine();
			int num4 = 1;
			bool flag = false;
			for (int j = 1; j < num2; j++)
			{
				bool flag2 = false;
				string diagnosticData2 = GetDiagnosticData(mine, j, 0, num);
				for (int k = num4; k < num3; k++)
				{
					if (!diagnosticData2.Equals(GetDiagnosticData(theirs, k, 0, num)))
					{
						continue;
					}
					int num5 = 0;
					num4 = k + 1;
					flag2 = true;
					for (int l = 1; l < num; l++)
					{
						string diagnosticData3 = GetDiagnosticData(mine, j, l, num);
						string diagnosticData4 = GetDiagnosticData(theirs, k, l, num);
						if (!diagnosticData3.Equals(diagnosticData4))
						{
							if (num5 == 0)
							{
								stringBuilder.Append(diagnosticData2 + "\t");
								num5++;
							}
							for (int m = num5; m < l; m++)
							{
								stringBuilder.Append('\t');
								stringBuilder.Append('\t');
							}
							stringBuilder.Append(diagnosticData3 + "\t" + diagnosticData4 + "\t");
							num5 = l + 1;
							flag = true;
						}
					}
					if (num5 > 0)
					{
						stringBuilder.AppendLine();
					}
					break;
				}
				if (!flag2)
				{
					flag = true;
					stringBuilder.AppendLine("Missing object from theirs: " + diagnosticData2);
				}
			}
			if (!flag)
			{
				return "No discrepancies found";
			}
			return stringBuilder.ToString().TrimEnd();
		}

		public static void SendAllIDsNow()
		{
			if (NetworkManager.IsHost && !GameSettings.Instance.IsReferenceNull())
			{
				uint swID;
				uint frameworkID;
				uint companyID;
				uint dealID;
				GameSettings.Instance.simulation.GetIDS(out swID, out frameworkID, out companyID, out dealID);
				SendAllIDs(NetworkManager.Instance.GetIDOfType(NetworkManager.NetworkIDType.Trade), NetworkManager.Instance.GetIDOfType(NetworkManager.NetworkIDType.GlobalObject), NetworkManager.Instance.GetIDOfType(NetworkManager.NetworkIDType.WorkItem), swID, frameworkID, dealID, companyID, MessageTarget.EveryoneButMe, 0);
			}
		}

		public static void DisconnectMyself()
		{
			SendAllIDsNow();
			if (!GameSettings.Instance.IsReferenceNull())
			{
				SendBusinessRep(GameSettings.Instance.MyCompany.BusinessReputation, MessageTarget.EveryoneButMe, 0);
			}
			SendDisconnectPlayer(false, MessageTarget.EveryoneButMe, 0);
		}

		public static void SendAllNow()
		{
			while (Tick(true, false))
			{
				Thread.Sleep(10);
			}
		}

		public static bool Tick(bool forceSends, bool receive)
		{
			bool result = false;
			while (receive)
			{
				NetworkPlayer from;
				byte[] array = NetworkLayer.Active.ReceiveData(out from);
				if (array == null)
				{
					break;
				}
				if (!from.Connected)
				{
					NetworkManager.Instance.ResetIDMap();
					Debug.Log("Got message from disconnected, but existing user: " + from.Name);
					continue;
				}
				try
				{
					lock (from)
					{
						from.KeepAlive = 0f;
						from.ReceiveData(array);
					}
				}
				catch (Exception ex)
				{
					if (NetworkManager.IsHost && from.HandshakeComplete)
					{
						SendData(from.ID, MessageType.DisconnectPlayer, new byte[1], false, MessageTarget.Everyone, 0);
					}
					Disconnect(from, false, false);
					from.SendQueue.Clear();
					Debug.Log(ex.ToString());
				}
			}
			for (int i = 0; i < NetworkManager.Instance.Players.Count; i++)
			{
				NetworkPlayer networkPlayer = NetworkManager.Instance.Players[i];
				if (networkPlayer.Self)
				{
					continue;
				}
				lock (networkPlayer)
				{
					int num = NetworkLayer.Active.GetMaxPacketSize();
					for (int j = 0; j < networkPlayer.SendQueue.Count; j++)
					{
						NetworkPlayer.SendBuffer sendBuffer = networkPlayer.SendQueue[j];
						int num2 = Mathf.Min(num, sendBuffer.Data.Length - sendBuffer.Offset);
						byte[] data = sendBuffer.GetData(num2);
						bool flag;
						try
						{
							result = true;
							flag = NetworkLayer.Active.SendData(networkPlayer, data, forceSends);
							if (!flag)
							{
								sendBuffer.MoveOffset(num2);
								networkPlayer.Sent += (uint)data.Length;
							}
							networkPlayer.KeepAlive = 0f;
						}
						catch (Exception ex2)
						{
							if (NetworkManager.IsHost && networkPlayer.HandshakeComplete)
							{
								SendData(networkPlayer.ID, MessageType.DisconnectPlayer, new byte[1], false, MessageTarget.Everyone, 0);
							}
							Disconnect(networkPlayer, false, false);
							networkPlayer.SendQueue.Clear();
							Debug.Log(ex2.ToString());
							continue;
						}
						if (flag)
						{
							break;
						}
						num -= num2;
						if (sendBuffer.Offset >= sendBuffer.Data.Length)
						{
							networkPlayer.SendQueue.RemoveAt(j);
							j--;
						}
						if (num == 0)
						{
							break;
						}
					}
				}
			}
			return result;
		}

		public static void SendModMessage(byte[] data, ModController.DLLMod mod, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			bool num = ShouldSend(target, targetID, true);
			bool flag = ForSelf(target, targetID);
			if (num || flag)
			{
				_stream.SetLength(0L);
				_stream.WriteByte(mod.NetworkID);
				_stream.Write(data, 0, data.Length);
			}
			if (num)
			{
				SendData(MessageType.ModMessage, _stream.ToArray(), true, target, targetID);
			}
			if (flag)
			{
				mod.ReceiveNetworkMessage(NetworkManager.Self, _stream);
			}
		}

		public static void SendNewConnection(string name, string uniqueID, string connectionData, string password, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				_stream.WriteStringUTF8(name);
				_stream.WriteStringUTF8(uniqueID);
				_stream.WriteStringUTF8(connectionData);
				_stream.WriteStringUTF8(password);
				SendData(MessageType.NewConnection, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				NewConnection(NetworkManager.Self, name, uniqueID, connectionData, password);
			}
		}

		private static void ReceiveNewConnection(NetworkPlayer from, MemoryStream data)
		{
			string name = data.ReadStringUTF8();
			string uniqueID = data.ReadStringUTF8();
			string connectionData = data.ReadStringUTF8();
			string password = data.ReadStringUTF8();
			NewConnection(from, name, uniqueID, connectionData, password);
		}

		public static void SendNetworkMetaData(NetworkMeta networkData, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				if (networkData != null)
				{
					_stream.WriteByteObject(networkData);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.NetworkMetaData, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				NetworkMetaData(NetworkManager.Self, networkData);
			}
		}

		private static void ReceiveNetworkMetaData(NetworkPlayer from, MemoryStream data)
		{
			NetworkMeta networkData = NetworkMeta.ReadData(data);
			NetworkMetaData(from, networkData);
		}

		public static void SendSaveData(byte[] save, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				SendData(MessageType.SaveData, save, false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				SaveData(NetworkManager.Self, save);
			}
		}

		private static void ReceiveSaveData(NetworkPlayer from, MemoryStream data)
		{
			SaveData(from, data.ReadRest());
		}

		public static void SendPlayerCompany(byte playerID, uint id, string name, double money, byte[] logo, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				_stream.WriteByte(playerID);
				_stream.WriteUInt(id);
				_stream.WriteStringUTF8(name);
				_stream.WriteDouble(money);
				_stream.WriteBytes(logo);
				SendData(MessageType.PlayerCompany, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				PlayerCompany(NetworkManager.Self, playerID, id, name, money, logo);
			}
		}

		private static void ReceivePlayerCompany(NetworkPlayer from, MemoryStream data)
		{
			int num = data.ReadByte();
			uint id = data.ReadUInt();
			string name = data.ReadStringUTF8();
			double money = data.ReadDouble();
			byte[] logo = data.ReadBytes();
			PlayerCompany(from, (byte)num, id, name, money, logo);
		}

		public static void SendDisconnectPlayer(bool kicked, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				SendData(MessageType.DisconnectPlayer, new byte[1] { (byte)(kicked ? 1 : 0) }, false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				DisconnectPlayer(NetworkManager.Self, kicked);
			}
		}

		private static void ReceiveDisconnectPlayer(NetworkPlayer from, MemoryStream data)
		{
			bool kicked = data.ReadBool();
			DisconnectPlayer(from, kicked);
		}

		public static void SendControlStatement(ControlType statement, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				SendData(MessageType.ControlStatement, new byte[1] { (byte)statement }, false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ControlStatement(NetworkManager.Self, statement);
			}
		}

		private static void ReceiveControlStatement(NetworkPlayer from, MemoryStream data)
		{
			ControlType statement = data.ReadEnum<ControlType>(true);
			ControlStatement(from, statement);
		}

		public static void SendBroadCastPlayer(string name, string uniqueID, string connectionData, NetworkPlayer.ReadyStatus ready, byte id, bool syncing, bool host, bool inGame, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (syncing)
				{
					b |= 1;
				}
				if (host)
				{
					b |= 2;
				}
				if (inGame)
				{
					b |= 4;
				}
				_stream.WriteByte(b);
				_stream.WriteStringUTF8(name);
				_stream.WriteStringUTF8(uniqueID);
				_stream.WriteStringUTF8(connectionData);
				_stream.WriteEnum(ready, true);
				_stream.WriteByte(id);
				SendData(MessageType.BroadCastPlayer, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				BroadCastPlayer(NetworkManager.Self, name, uniqueID, connectionData, ready, id, syncing, host, inGame);
			}
		}

		private static void ReceiveBroadCastPlayer(NetworkPlayer from, MemoryStream data)
		{
			int num = data.ReadByte();
			string name = data.ReadStringUTF8();
			string uniqueID = data.ReadStringUTF8();
			string connectionData = data.ReadStringUTF8();
			NetworkPlayer.ReadyStatus ready = data.ReadEnum<NetworkPlayer.ReadyStatus>(true);
			int num2 = data.ReadByte();
			bool syncing = (num & 1) > 0;
			bool host = (num & 2) > 0;
			bool inGame = (num & 4) > 0;
			BroadCastPlayer(from, name, uniqueID, connectionData, ready, (byte)num2, syncing, host, inGame);
		}

		public static void SendPlayerMessage(string msg, bool isPublic, uint trade, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				_stream.WriteStringUTF8(msg);
				_stream.WriteBool(isPublic);
				_stream.WriteUInt(trade);
				SendData(MessageType.PlayerMessage, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				PlayerMessage(NetworkManager.Self, msg, isPublic, trade);
			}
		}

		private static void ReceivePlayerMessage(NetworkPlayer from, MemoryStream data)
		{
			string msg = data.ReadStringUTF8();
			bool isPublic = data.ReadBool();
			uint trade = data.ReadUInt();
			PlayerMessage(from, msg, isPublic, trade);
		}

		public static void SendPlayerSync(byte id, bool isSyncing, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				SendData(MessageType.PlayerSync, new byte[2]
				{
					id,
					(byte)(isSyncing ? 1 : 0)
				}, false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				PlayerSync(NetworkManager.Self, id, isSyncing);
			}
		}

		private static void ReceivePlayerSync(NetworkPlayer from, MemoryStream data)
		{
			int num = data.ReadByte();
			bool isSyncing = data.ReadBool();
			PlayerSync(from, (byte)num, isSyncing);
		}

		public static void SendPlayerReady(NetworkPlayer.ReadyStatus status, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				SendData(MessageType.PlayerReady, new byte[1] { (byte)status }, false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				PlayerReady(NetworkManager.Self, status);
			}
		}

		private static void ReceivePlayerReady(NetworkPlayer from, MemoryStream data)
		{
			NetworkPlayer.ReadyStatus status = data.ReadEnum<NetworkPlayer.ReadyStatus>(true);
			PlayerReady(from, status);
		}

		public static bool SendPlayerTime(int hour, float minute, float speed, bool buildMode, bool afk, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (buildMode)
				{
					b |= 1;
				}
				if (afk)
				{
					b |= 2;
				}
				_stream.WriteByte(b);
				_stream.WriteInt(hour);
				_stream.WriteFloat(minute);
				_stream.WriteFloat(speed);
				SendData(MessageType.PlayerTime, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				PlayerTime(NetworkManager.Self, hour, minute, speed, buildMode, afk);
			}
			return true;
		}

		private static void ReceivePlayerTime(NetworkPlayer from, MemoryStream data)
		{
			int num = data.ReadByte();
			int hour = data.ReadInt();
			float minute = data.ReadFloat();
			float speed = data.ReadFloat();
			bool buildMode = (num & 1) > 0;
			bool afk = (num & 2) > 0;
			PlayerTime(from, hour, minute, speed, buildMode, afk);
		}

		public static bool SendPlotOwner(uint plotID, byte owner, bool starting, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(plotID);
				_stream.WriteByte(owner);
				_stream.WriteBool(starting);
				SendData(MessageType.PlotOwner, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				PlotOwner(NetworkManager.Self, plotID, owner, starting);
			}
			return true;
		}

		private static void ReceivePlotOwner(NetworkPlayer from, MemoryStream data)
		{
			uint plotID = data.ReadUInt();
			int num = data.ReadByte();
			bool starting = data.ReadBool();
			PlotOwner(from, plotID, (byte)num, starting);
		}

		public static bool SendDestroyLandmark(uint localID, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(localID);
				SendData(MessageType.DestroyLandmark, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				DestroyLandmark(NetworkManager.Self, localID);
			}
			return true;
		}

		private static void ReceiveDestroyLandmark(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint localID = data.ReadUInt();
				DestroyLandmark(from, localID);
			}
		}

		public static void SendPlaceRoad(int x, int y, int floor, byte type, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteInt(x);
				_stream.WriteInt(y);
				_stream.WriteInt(floor);
				_stream.WriteByte(type);
				SendData(MessageType.PlaceRoad, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				PlaceRoad(NetworkManager.Self, x, y, floor, type);
			}
		}

		private static void ReceivePlaceRoad(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int x = data.ReadInt();
				int y = data.ReadInt();
				int floor = data.ReadInt();
				int num = data.ReadByte();
				PlaceRoad(from, x, y, floor, (byte)num);
			}
		}

		public static bool SendSetGhostCar(int x, int y, int floor, int parking, int type, Vector3 p, float rot, Color color, uint logoCompany, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteInt(x);
				_stream.WriteInt(y);
				_stream.WriteInt(floor);
				_stream.WriteInt(parking);
				_stream.WriteInt(type);
				_stream.WriteVector(p);
				_stream.WriteFloat(rot);
				_stream.WriteColor(color);
				_stream.WriteUInt(logoCompany);
				SendData(MessageType.SetGhostCar, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				SetGhostCar(NetworkManager.Self, x, y, floor, parking, type, p, rot, color, logoCompany);
			}
			return true;
		}

		private static void ReceiveSetGhostCar(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int x = data.ReadInt();
				int y = data.ReadInt();
				int floor = data.ReadInt();
				int parking = data.ReadInt();
				int type = data.ReadInt();
				SVector3 sVector = data.ReadVector();
				float rot = data.ReadFloat();
				Color32 color = data.ReadColor();
				uint logoCompany = data.ReadUInt();
				SetGhostCar(from, x, y, floor, parking, type, sVector, rot, color, logoCompany);
			}
		}

		public static bool SendClearGhostCar(int x, int y, int floor, int parking, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteInt(x);
				_stream.WriteInt(y);
				_stream.WriteInt(floor);
				_stream.WriteInt(parking);
				SendData(MessageType.ClearGhostCar, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ClearGhostCar(NetworkManager.Self, x, y, floor, parking);
			}
			return true;
		}

		private static void ReceiveClearGhostCar(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int x = data.ReadInt();
				int y = data.ReadInt();
				int floor = data.ReadInt();
				int parking = data.ReadInt();
				ClearGhostCar(from, x, y, floor, parking);
			}
		}

		public static bool SendMakeTransaction(uint company, double amount, Company.TransactionCategory category, TaxReport.TaxType taxes, string bill, bool valuated, SDateTime time, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (category != Company.TransactionCategory.Distribution)
				{
					b |= 1;
				}
				if (taxes != TaxReport.TaxType.Operation)
				{
					b |= 2;
				}
				if (bill != null)
				{
					b |= 4;
				}
				if (valuated)
				{
					b |= 8;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(company);
				_stream.WriteDouble(amount);
				if ((b & 1) > 0)
				{
					_stream.WriteEnum(category, true);
				}
				if ((b & 2) > 0)
				{
					_stream.WriteEnum(taxes, true);
				}
				if ((b & 4) > 0)
				{
					_stream.WriteStringUTF8(bill);
				}
				_stream.WriteByteObject(time);
				SendData(MessageType.MakeTransaction, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				MakeTransaction(NetworkManager.Self, company, amount, category, taxes, bill, valuated, time);
			}
			return true;
		}

		private static void ReceiveMakeTransaction(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint company = data.ReadUInt();
				double amount = data.ReadDouble();
				Company.TransactionCategory category = Company.TransactionCategory.Distribution;
				if ((num & 1) > 0)
				{
					category = data.ReadEnum<Company.TransactionCategory>(true);
				}
				TaxReport.TaxType taxes = TaxReport.TaxType.Operation;
				if ((num & 2) > 0)
				{
					taxes = data.ReadEnum<TaxReport.TaxType>(true);
				}
				string bill = null;
				if ((num & 4) > 0)
				{
					bill = data.ReadStringUTF8();
				}
				bool valuated = (num & 8) > 0;
				SDateTime time = SDateTime.ReadData(data);
				MakeTransaction(from, company, amount, category, taxes, bill, valuated, time);
			}
		}

		public static bool SendAddTax(uint company, TaxReport.TaxType type, double amount, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteEnum(type, true);
				_stream.WriteDouble(amount);
				SendData(MessageType.AddTax, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddTax(NetworkManager.Self, company, type, amount);
			}
			return true;
		}

		private static void ReceiveAddTax(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				TaxReport.TaxType type = data.ReadEnum<TaxReport.TaxType>(true);
				double amount = data.ReadDouble();
				AddTax(from, company, type, amount);
			}
		}

		public static void SendNetworkIDCallback(uint id, uint newID, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteUInt(newID);
				SendData(MessageType.NetworkIDCallback, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				NetworkIDCallback(NetworkManager.Self, id, newID);
			}
		}

		private static void ReceiveNetworkIDCallback(NetworkPlayer from, MemoryStream data)
		{
			uint id = data.ReadUInt();
			uint newID = data.ReadUInt();
			NetworkIDCallback(from, id, newID);
		}

		public static void SendLeadDesigner(uint callback, Employee emp, uint company, bool freeLead, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (callback != 0)
				{
					b |= 1;
				}
				if (company != 0)
				{
					b |= 2;
				}
				if (freeLead)
				{
					b |= 4;
				}
				_stream.WriteByte(b);
				if ((b & 1) > 0)
				{
					_stream.WriteUInt(callback);
				}
				_stream.WriteObject(emp);
				if ((b & 2) > 0)
				{
					_stream.WriteUInt(company);
				}
				SendData(MessageType.LeadDesigner, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				LeadDesigner(NetworkManager.Self, callback, emp, company, freeLead);
			}
		}

		private static void ReceiveLeadDesigner(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint callback = 0u;
				if ((num & 1) > 0)
				{
					callback = data.ReadUInt();
				}
				Employee emp = data.ReadObject<Employee>();
				uint company = 0u;
				if ((num & 2) > 0)
				{
					company = data.ReadUInt();
				}
				bool freeLead = (num & 4) > 0;
				LeadDesigner(from, callback, emp, company, freeLead);
			}
		}

		public static void SendRequestNetworkID(uint callback, NetworkManager.NetworkIDType type, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(callback);
				_stream.WriteEnum(type, true);
				SendData(MessageType.RequestNetworkID, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				RequestNetworkID(NetworkManager.Self, callback, type);
			}
		}

		private static void ReceiveRequestNetworkID(NetworkPlayer from, MemoryStream data)
		{
			uint callback = data.ReadUInt();
			NetworkManager.NetworkIDType type = data.ReadEnum<NetworkManager.NetworkIDType>(true);
			RequestNetworkID(from, callback, type);
		}

		public static void SendMoveLeadDesigner(uint designer, uint company, bool freeLead, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (company != 0)
				{
					b |= 1;
				}
				if (freeLead)
				{
					b |= 2;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(designer);
				if ((b & 1) > 0)
				{
					_stream.WriteUInt(company);
				}
				SendData(MessageType.MoveLeadDesigner, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				MoveLeadDesigner(NetworkManager.Self, designer, company, freeLead);
			}
		}

		private static void ReceiveMoveLeadDesigner(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint designer = data.ReadUInt();
				uint company = 0u;
				if ((num & 1) > 0)
				{
					company = data.ReadUInt();
				}
				bool freeLead = (num & 2) > 0;
				MoveLeadDesigner(from, designer, company, freeLead);
			}
		}

		public static bool SendFinishLeadProject(uint designer, uint product, float amount, bool owner, int rnd, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(designer);
				_stream.WriteUInt(product);
				_stream.WriteFloat(amount);
				_stream.WriteBool(owner);
				_stream.WriteInt(rnd);
				SendData(MessageType.FinishLeadProject, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				FinishLeadProject(NetworkManager.Self, designer, product, amount, owner, rnd);
			}
			return true;
		}

		private static void ReceiveFinishLeadProject(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint designer = data.ReadUInt();
				uint product = data.ReadUInt();
				float amount = data.ReadFloat();
				bool owner = data.ReadBool();
				int rnd = data.ReadInt();
				FinishLeadProject(from, designer, product, amount, owner, rnd);
			}
		}

		public static bool SendAddSimulatedCompany(uint id, string name, SDateTime time, double startingMoney, string stype, float avgQual, float businessSavy, byte[] logo, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteStringUTF8(name);
				_stream.WriteByteObject(time);
				_stream.WriteDouble(startingMoney);
				_stream.WriteStringUTF8(stype);
				_stream.WriteFloat(avgQual);
				_stream.WriteFloat(businessSavy);
				_stream.WriteBytes(logo);
				SendData(MessageType.AddSimulatedCompany, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddSimulatedCompany(NetworkManager.Self, id, name, time, startingMoney, stype, avgQual, businessSavy, logo);
			}
			return true;
		}

		private static void ReceiveAddSimulatedCompany(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				string name = data.ReadStringUTF8();
				SDateTime time = SDateTime.ReadData(data);
				double startingMoney = data.ReadDouble();
				string stype = data.ReadStringUTF8();
				float avgQual = data.ReadFloat();
				float businessSavy = data.ReadFloat();
				byte[] logo = data.ReadBytes();
				AddSimulatedCompany(from, id, name, time, startingMoney, stype, avgQual, businessSavy, logo);
			}
		}

		public static bool SendTradeStock(uint company, uint buyer, uint shares, uint currentShares, double offer, uint existing, SDateTime time, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(buyer);
				_stream.WriteUInt(shares);
				_stream.WriteUInt(currentShares);
				_stream.WriteDouble(offer);
				_stream.WriteUInt(existing);
				_stream.WriteByteObject(time);
				SendData(MessageType.TradeStock, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				TradeStock(NetworkManager.Self, company, buyer, shares, currentShares, offer, existing, time);
			}
			return true;
		}

		private static void ReceiveTradeStock(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint buyer = data.ReadUInt();
				uint shares = data.ReadUInt();
				uint currentShares = data.ReadUInt();
				double offer = data.ReadDouble();
				uint existing = data.ReadUInt();
				SDateTime time = SDateTime.ReadData(data);
				TradeStock(from, company, buyer, shares, currentShares, offer, existing, time);
			}
		}

		public static bool SendExtraWorth(uint company, double extraWorth, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteDouble(extraWorth);
				SendData(MessageType.ExtraWorth, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ExtraWorth(NetworkManager.Self, company, extraWorth);
			}
			return true;
		}

		private static void ReceiveExtraWorth(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				double extraWorth = data.ReadDouble();
				ExtraWorth(from, company, extraWorth);
			}
		}

		public static bool SendBuyOut(uint company, uint buyer, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(buyer);
				SendData(MessageType.BuyOut, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				BuyOut(NetworkManager.Self, company, buyer);
			}
			return true;
		}

		private static void ReceiveBuyOut(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint buyer = data.ReadUInt();
				BuyOut(from, company, buyer);
			}
		}

		public static bool SendAddTechLevel(string spec, int year, SDateTime time, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteStringUTF8(spec);
				_stream.WriteInt(year);
				_stream.WriteByteObject(time);
				SendData(MessageType.AddTechLevel, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddTechLevel(NetworkManager.Self, spec, year, time);
			}
			return true;
		}

		private static void ReceiveAddTechLevel(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				string spec = data.ReadStringUTF8();
				int year = data.ReadInt();
				SDateTime time = SDateTime.ReadData(data);
				AddTechLevel(from, spec, year, time);
			}
		}

		public static bool SendTransferPatent(string spec, int year, uint company, SDateTime time, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteStringUTF8(spec);
				_stream.WriteInt(year);
				_stream.WriteUInt(company);
				_stream.WriteByteObject(time);
				SendData(MessageType.TransferPatent, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				TransferPatent(NetworkManager.Self, spec, year, company, time);
			}
			return true;
		}

		private static void ReceiveTransferPatent(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				string spec = data.ReadStringUTF8();
				int year = data.ReadInt();
				uint company = data.ReadUInt();
				SDateTime time = SDateTime.ReadData(data);
				TransferPatent(from, spec, year, company, time);
			}
		}

		public static bool SendAddResearch(uint company, string spec, int year, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteStringUTF8(spec);
				_stream.WriteInt(year);
				SendData(MessageType.AddResearch, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddResearch(NetworkManager.Self, company, spec, year);
			}
			return true;
		}

		private static void ReceiveAddResearch(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				string spec = data.ReadStringUTF8();
				int year = data.ReadInt();
				AddResearch(from, company, spec, year);
			}
		}

		public static bool SendTransferFramework(uint company, uint framework, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(framework);
				SendData(MessageType.TransferFramework, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				TransferFramework(NetworkManager.Self, company, framework);
			}
			return true;
		}

		private static void ReceiveTransferFramework(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint framework = data.ReadUInt();
				TransferFramework(from, company, framework);
			}
		}

		public static bool SendAddFramework(string name, uint id, uint type, uint cat, Dictionary<uint, double> features, Dictionary<string, int> techs, SDateTime releaseDate, byte playerID, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteStringUTF8(name);
				_stream.WriteUInt(id);
				_stream.WriteUInt(type);
				_stream.WriteUInt(cat);
				if (features != null)
				{
					_stream.WriteInt(features.Count);
					foreach (KeyValuePair<uint, double> feature in features)
					{
						uint key = feature.Key;
						_stream.WriteUInt(key);
						double value = feature.Value;
						_stream.WriteDouble(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				if (techs != null)
				{
					_stream.WriteInt(techs.Count);
					foreach (KeyValuePair<string, int> tech in techs)
					{
						string key2 = tech.Key;
						_stream.WriteStringUTF8(key2);
						int value2 = tech.Value;
						_stream.WriteInt(value2);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteByteObject(releaseDate);
				_stream.WriteByte(playerID);
				SendData(MessageType.AddFramework, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddFramework(NetworkManager.Self, name, id, type, cat, features, techs, releaseDate, playerID);
			}
			return true;
		}

		private static void ReceiveAddFramework(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			string name = data.ReadStringUTF8();
			uint id = data.ReadUInt();
			uint type = data.ReadUInt();
			uint cat = data.ReadUInt();
			Dictionary<uint, double> dictionary = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				dictionary = new Dictionary<uint, double>(num);
				for (int i = 0; i < num; i++)
				{
					uint key = data.ReadUInt();
					double value = data.ReadDouble();
					dictionary[key] = value;
				}
			}
			Dictionary<string, int> dictionary2 = null;
			int num2 = data.ReadInt();
			if (num2 >= 0)
			{
				dictionary2 = new Dictionary<string, int>(num2);
				for (int j = 0; j < num2; j++)
				{
					string key2 = data.ReadStringUTF8();
					int value2 = data.ReadInt();
					dictionary2[key2] = value2;
				}
			}
			SDateTime releaseDate = SDateTime.ReadData(data);
			int num3 = data.ReadByte();
			AddFramework(from, name, id, type, cat, dictionary, dictionary2, releaseDate, (byte)num3);
		}

		public static bool SendAddProduct(string name, uint type, uint category, uint[] os, float randomFactor, float awareness, double codeProgress, double artProgress, double codeQuality, double artQuality, double[] marketQuality, double creativityScore, float price, bool subscription, double[] submarkets, SDateTime start, SDateTime release, int bugs, bool inHouse, uint company, uint sequelto, double sequelBonus, uint id, uint[] features, Dictionary<string, int> techs, uint followers, uint framework, float frameworkRoyalty, Dictionary<uint, float> tools, byte[] hardwareDesign, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteStringUTF8(name);
				_stream.WriteUInt(type);
				_stream.WriteUInt(category);
				if (os != null)
				{
					_stream.WriteInt(os.Length);
					foreach (uint value in os)
					{
						_stream.WriteUInt(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteFloat(randomFactor);
				_stream.WriteFloat(awareness);
				_stream.WriteDouble(codeProgress);
				_stream.WriteDouble(artProgress);
				_stream.WriteDouble(codeQuality);
				_stream.WriteDouble(artQuality);
				if (marketQuality != null)
				{
					_stream.WriteInt(marketQuality.Length);
					foreach (double value2 in marketQuality)
					{
						_stream.WriteDouble(value2);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteDouble(creativityScore);
				_stream.WriteFloat(price);
				_stream.WriteBool(subscription);
				if (submarkets != null)
				{
					_stream.WriteInt(submarkets.Length);
					foreach (double value3 in submarkets)
					{
						_stream.WriteDouble(value3);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteByteObject(start);
				_stream.WriteByteObject(release);
				_stream.WriteInt(bugs);
				_stream.WriteBool(inHouse);
				_stream.WriteUInt(company);
				_stream.WriteUInt(sequelto);
				_stream.WriteDouble(sequelBonus);
				_stream.WriteUInt(id);
				if (features != null)
				{
					_stream.WriteInt(features.Length);
					foreach (uint value4 in features)
					{
						_stream.WriteUInt(value4);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				if (techs != null)
				{
					_stream.WriteInt(techs.Count);
					foreach (KeyValuePair<string, int> tech in techs)
					{
						string key = tech.Key;
						_stream.WriteStringUTF8(key);
						int value5 = tech.Value;
						_stream.WriteInt(value5);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteUInt(followers);
				_stream.WriteUInt(framework);
				_stream.WriteFloat(frameworkRoyalty);
				if (tools != null)
				{
					_stream.WriteInt(tools.Count);
					foreach (KeyValuePair<uint, float> tool in tools)
					{
						uint key2 = tool.Key;
						_stream.WriteUInt(key2);
						float value6 = tool.Value;
						_stream.WriteFloat(value6);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteBytes(hardwareDesign);
				SendData(MessageType.AddProduct, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddProduct(NetworkManager.Self, name, type, category, os, randomFactor, awareness, codeProgress, artProgress, codeQuality, artQuality, marketQuality, creativityScore, price, subscription, submarkets, start, release, bugs, inHouse, company, sequelto, sequelBonus, id, features, techs, followers, framework, frameworkRoyalty, tools, hardwareDesign);
			}
			return true;
		}

		private static void ReceiveAddProduct(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			string name = data.ReadStringUTF8();
			uint type = data.ReadUInt();
			uint category = data.ReadUInt();
			uint[] array = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				array = new uint[num];
				for (int i = 0; i < num; i++)
				{
					uint num2 = data.ReadUInt();
					array[i] = num2;
				}
			}
			float randomFactor = data.ReadFloat();
			float awareness = data.ReadFloat();
			double codeProgress = data.ReadDouble();
			double artProgress = data.ReadDouble();
			double codeQuality = data.ReadDouble();
			double artQuality = data.ReadDouble();
			double[] array2 = null;
			int num3 = data.ReadInt();
			if (num3 >= 0)
			{
				array2 = new double[num3];
				for (int j = 0; j < num3; j++)
				{
					double num4 = data.ReadDouble();
					array2[j] = num4;
				}
			}
			double creativityScore = data.ReadDouble();
			float price = data.ReadFloat();
			bool subscription = data.ReadBool();
			double[] array3 = null;
			int num5 = data.ReadInt();
			if (num5 >= 0)
			{
				array3 = new double[num5];
				for (int k = 0; k < num5; k++)
				{
					double num6 = data.ReadDouble();
					array3[k] = num6;
				}
			}
			SDateTime start = SDateTime.ReadData(data);
			SDateTime release = SDateTime.ReadData(data);
			int bugs = data.ReadInt();
			bool inHouse = data.ReadBool();
			uint company = data.ReadUInt();
			uint sequelto = data.ReadUInt();
			double sequelBonus = data.ReadDouble();
			uint id = data.ReadUInt();
			uint[] array4 = null;
			int num7 = data.ReadInt();
			if (num7 >= 0)
			{
				array4 = new uint[num7];
				for (int l = 0; l < num7; l++)
				{
					uint num8 = data.ReadUInt();
					array4[l] = num8;
				}
			}
			Dictionary<string, int> dictionary = null;
			int num9 = data.ReadInt();
			if (num9 >= 0)
			{
				dictionary = new Dictionary<string, int>(num9);
				for (int m = 0; m < num9; m++)
				{
					string key = data.ReadStringUTF8();
					int value = data.ReadInt();
					dictionary[key] = value;
				}
			}
			uint followers = data.ReadUInt();
			uint framework = data.ReadUInt();
			float frameworkRoyalty = data.ReadFloat();
			Dictionary<uint, float> dictionary2 = null;
			int num10 = data.ReadInt();
			if (num10 >= 0)
			{
				dictionary2 = new Dictionary<uint, float>(num10);
				for (int n = 0; n < num10; n++)
				{
					uint key2 = data.ReadUInt();
					float value2 = data.ReadFloat();
					dictionary2[key2] = value2;
				}
			}
			byte[] hardwareDesign = data.ReadBytes();
			AddProduct(from, name, type, category, array, randomFactor, awareness, codeProgress, artProgress, codeQuality, artQuality, array2, creativityScore, price, subscription, array3, start, release, bugs, inHouse, company, sequelto, sequelBonus, id, array4, dictionary, followers, framework, frameworkRoyalty, dictionary2, hardwareDesign);
		}

		public static bool SendAddAddOn(string name, uint id, uint swType, uint type, uint parent, uint[] features, uint[] featureFactors, SDateTime devStart, SDateTime release, float price, float awareness, double loss, double[] quality, uint devCompany, uint physicalCopies, float distributionLoss, uint followers, double codeProgress, double artProgress, double codeQuality, double artQuality, bool forced, byte[] hardwareDesign, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteStringUTF8(name);
				_stream.WriteUInt(id);
				_stream.WriteUInt(swType);
				_stream.WriteUInt(type);
				_stream.WriteUInt(parent);
				if (features != null)
				{
					_stream.WriteInt(features.Length);
					foreach (uint value in features)
					{
						_stream.WriteUInt(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				if (featureFactors != null)
				{
					_stream.WriteInt(featureFactors.Length);
					foreach (uint value2 in featureFactors)
					{
						_stream.WriteUInt(value2);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteByteObject(devStart);
				_stream.WriteByteObject(release);
				_stream.WriteFloat(price);
				_stream.WriteFloat(awareness);
				_stream.WriteDouble(loss);
				if (quality != null)
				{
					_stream.WriteInt(quality.Length);
					foreach (double value3 in quality)
					{
						_stream.WriteDouble(value3);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteUInt(devCompany);
				_stream.WriteUInt(physicalCopies);
				_stream.WriteFloat(distributionLoss);
				_stream.WriteUInt(followers);
				_stream.WriteDouble(codeProgress);
				_stream.WriteDouble(artProgress);
				_stream.WriteDouble(codeQuality);
				_stream.WriteDouble(artQuality);
				_stream.WriteBool(forced);
				_stream.WriteBytes(hardwareDesign);
				SendData(MessageType.AddAddOn, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddAddOn(NetworkManager.Self, name, id, swType, type, parent, features, featureFactors, devStart, release, price, awareness, loss, quality, devCompany, physicalCopies, distributionLoss, followers, codeProgress, artProgress, codeQuality, artQuality, forced, hardwareDesign);
			}
			return true;
		}

		private static void ReceiveAddAddOn(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			string name = data.ReadStringUTF8();
			uint id = data.ReadUInt();
			uint swType = data.ReadUInt();
			uint type = data.ReadUInt();
			uint parent = data.ReadUInt();
			uint[] array = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				array = new uint[num];
				for (int i = 0; i < num; i++)
				{
					uint num2 = data.ReadUInt();
					array[i] = num2;
				}
			}
			uint[] array2 = null;
			int num3 = data.ReadInt();
			if (num3 >= 0)
			{
				array2 = new uint[num3];
				for (int j = 0; j < num3; j++)
				{
					uint num4 = data.ReadUInt();
					array2[j] = num4;
				}
			}
			SDateTime devStart = SDateTime.ReadData(data);
			SDateTime release = SDateTime.ReadData(data);
			float price = data.ReadFloat();
			float awareness = data.ReadFloat();
			double loss = data.ReadDouble();
			double[] array3 = null;
			int num5 = data.ReadInt();
			if (num5 >= 0)
			{
				array3 = new double[num5];
				for (int k = 0; k < num5; k++)
				{
					double num6 = data.ReadDouble();
					array3[k] = num6;
				}
			}
			uint devCompany = data.ReadUInt();
			uint physicalCopies = data.ReadUInt();
			float distributionLoss = data.ReadFloat();
			uint followers = data.ReadUInt();
			double codeProgress = data.ReadDouble();
			double artProgress = data.ReadDouble();
			double codeQuality = data.ReadDouble();
			double artQuality = data.ReadDouble();
			bool forced = data.ReadBool();
			byte[] hardwareDesign = data.ReadBytes();
			AddAddOn(from, name, id, swType, type, parent, array, array2, devStart, release, price, awareness, loss, array3, devCompany, physicalCopies, distributionLoss, followers, codeProgress, artProgress, codeQuality, artQuality, forced, hardwareDesign);
		}

		public static bool SendUpdateSubMarkets(Dictionary<KeyValuePair<uint, uint>, double[]> submarkets, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				if (submarkets != null)
				{
					_stream.WriteInt(submarkets.Count);
					foreach (KeyValuePair<KeyValuePair<uint, uint>, double[]> submarket in submarkets)
					{
						KeyValuePair<uint, uint> key = submarket.Key;
						_stream.WriteUInt(key.Key);
						_stream.WriteUInt(key.Value);
						double[] value = submarket.Value;
						if (value != null)
						{
							_stream.WriteInt(value.Length);
							foreach (double value2 in value)
							{
								_stream.WriteDouble(value2);
							}
						}
						else
						{
							_stream.WriteInt(-1);
						}
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.UpdateSubMarkets, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateSubMarkets(NetworkManager.Self, submarkets);
			}
			return true;
		}

		private static void ReceiveUpdateSubMarkets(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			Dictionary<KeyValuePair<uint, uint>, double[]> dictionary = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				dictionary = new Dictionary<KeyValuePair<uint, uint>, double[]>(num);
				for (int i = 0; i < num; i++)
				{
					uint key = data.ReadUInt();
					uint value = data.ReadUInt();
					KeyValuePair<uint, uint> key2 = new KeyValuePair<uint, uint>(key, value);
					double[] array = null;
					int num2 = data.ReadInt();
					if (num2 >= 0)
					{
						array = new double[num2];
						for (int j = 0; j < num2; j++)
						{
							double num3 = data.ReadDouble();
							array[j] = num3;
						}
					}
					dictionary[key2] = array;
				}
			}
			UpdateSubMarkets(from, dictionary);
		}

		public static bool SendTradeIP(uint company, uint id, uint addon, SDateTime time, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(id);
				_stream.WriteUInt(addon);
				_stream.WriteByteObject(time);
				SendData(MessageType.TradeIP, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				TradeIP(NetworkManager.Self, company, id, addon, time);
			}
			return true;
		}

		private static void ReceiveTradeIP(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint id = data.ReadUInt();
				uint addon = data.ReadUInt();
				SDateTime time = SDateTime.ReadData(data);
				TradeIP(from, company, id, addon, time);
			}
		}

		public static bool SendProductCashflow(uint id, int onlineUnits, int offlineUnits, int refunds, float gross, float profit, float license, SDateTime now, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (onlineUnits != 0)
				{
					b |= 1;
				}
				if (offlineUnits != 0)
				{
					b |= 2;
				}
				if (refunds != 0)
				{
					b |= 4;
				}
				if (gross != 0f)
				{
					b |= 8;
				}
				if (profit != 0f)
				{
					b |= 0x10;
				}
				if (license != 0f)
				{
					b |= 0x20;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(id);
				if ((b & 1) > 0)
				{
					_stream.WriteInt(onlineUnits);
				}
				if ((b & 2) > 0)
				{
					_stream.WriteInt(offlineUnits);
				}
				if ((b & 4) > 0)
				{
					_stream.WriteInt(refunds);
				}
				if ((b & 8) > 0)
				{
					_stream.WriteFloat(gross);
				}
				if ((b & 0x10) > 0)
				{
					_stream.WriteFloat(profit);
				}
				if ((b & 0x20) > 0)
				{
					_stream.WriteFloat(license);
				}
				_stream.WriteByteObject(now);
				SendData(MessageType.ProductCashflow, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ProductCashflow(NetworkManager.Self, id, onlineUnits, offlineUnits, refunds, gross, profit, license, now);
			}
			return true;
		}

		private static void ReceiveProductCashflow(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint id = data.ReadUInt();
				int onlineUnits = 0;
				if ((num & 1) > 0)
				{
					onlineUnits = data.ReadInt();
				}
				int offlineUnits = 0;
				if ((num & 2) > 0)
				{
					offlineUnits = data.ReadInt();
				}
				int refunds = 0;
				if ((num & 4) > 0)
				{
					refunds = data.ReadInt();
				}
				float gross = 0f;
				if ((num & 8) > 0)
				{
					gross = data.ReadFloat();
				}
				float profit = 0f;
				if ((num & 0x10) > 0)
				{
					profit = data.ReadFloat();
				}
				float license = 0f;
				if ((num & 0x20) > 0)
				{
					license = data.ReadFloat();
				}
				SDateTime now = SDateTime.ReadData(data);
				ProductCashflow(from, id, onlineUnits, offlineUnits, refunds, gross, profit, license, now);
			}
		}

		public static bool SendProductUserbase(uint id, int userbase, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteInt(userbase);
				SendData(MessageType.ProductUserbase, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ProductUserbase(NetworkManager.Self, id, userbase);
			}
			return true;
		}

		private static void ReceiveProductUserbase(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				int userbase = data.ReadInt();
				ProductUserbase(from, id, userbase);
			}
		}

		public static bool SendAddFans(uint id, uint software, uint category, int amount, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteUInt(software);
				_stream.WriteUInt(category);
				_stream.WriteInt(amount);
				SendData(MessageType.AddFans, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddFans(NetworkManager.Self, id, software, category, amount);
			}
			return true;
		}

		private static void ReceiveAddFans(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				uint software = data.ReadUInt();
				uint category = data.ReadUInt();
				int amount = data.ReadInt();
				AddFans(from, id, software, category, amount);
			}
		}

		public static bool SendArchiveProduct(uint id, bool delete, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteBool(delete);
				SendData(MessageType.ArchiveProduct, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ArchiveProduct(NetworkManager.Self, id, delete);
			}
			return true;
		}

		private static void ReceiveArchiveProduct(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				bool delete = data.ReadBool();
				ArchiveProduct(from, id, delete);
			}
		}

		public static bool SendChangeFollowers(uint id, uint addon, uint followers, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (addon != 0)
				{
					b |= 1;
				}
				if (followers != 0)
				{
					b |= 2;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(id);
				if ((b & 1) > 0)
				{
					_stream.WriteUInt(addon);
				}
				if ((b & 2) > 0)
				{
					_stream.WriteUInt(followers);
				}
				SendData(MessageType.ChangeFollowers, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ChangeFollowers(NetworkManager.Self, id, addon, followers);
			}
			return true;
		}

		private static void ReceiveChangeFollowers(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint id = data.ReadUInt();
				uint addon = 0u;
				if ((num & 1) > 0)
				{
					addon = data.ReadUInt();
				}
				uint followers = 0u;
				if ((num & 2) > 0)
				{
					followers = data.ReadUInt();
				}
				ChangeFollowers(from, id, addon, followers);
			}
		}

		public static bool SendUpdateMarketing(uint id, uint addon, float marketing, bool simulate, bool awarenessChange, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (addon != 0)
				{
					b |= 1;
				}
				if (marketing != 0f)
				{
					b |= 2;
				}
				if (simulate)
				{
					b |= 4;
				}
				if (awarenessChange)
				{
					b |= 8;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(id);
				if ((b & 1) > 0)
				{
					_stream.WriteUInt(addon);
				}
				if ((b & 2) > 0)
				{
					_stream.WriteFloat(marketing);
				}
				SendData(MessageType.UpdateMarketing, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateMarketing(NetworkManager.Self, id, addon, marketing, simulate, awarenessChange);
			}
			return true;
		}

		private static void ReceiveUpdateMarketing(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint id = data.ReadUInt();
				uint addon = 0u;
				if ((num & 1) > 0)
				{
					addon = data.ReadUInt();
				}
				float marketing = 0f;
				if ((num & 2) > 0)
				{
					marketing = data.ReadFloat();
				}
				bool simulate = (num & 4) > 0;
				bool awarenessChange = (num & 8) > 0;
				UpdateMarketing(from, id, addon, marketing, simulate, awarenessChange);
			}
		}

		public static bool SendProductPrototype(string name, uint id, uint type, uint category, Dictionary<string, uint> needs, uint[] os, double codeProgress, double artProgress, double codeQuality, double artQuality, float price, bool subscription, double[] submarkets, uint company, bool inHouse, float reception, uint sequelTo, uint[] feats, Dictionary<string, int> techs, double loss, uint framework, string newFramework, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteStringUTF8(name);
				_stream.WriteUInt(id);
				_stream.WriteUInt(type);
				_stream.WriteUInt(category);
				if (needs != null)
				{
					_stream.WriteInt(needs.Count);
					foreach (KeyValuePair<string, uint> need in needs)
					{
						string key = need.Key;
						_stream.WriteStringUTF8(key);
						uint value = need.Value;
						_stream.WriteUInt(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				if (os != null)
				{
					_stream.WriteInt(os.Length);
					foreach (uint value2 in os)
					{
						_stream.WriteUInt(value2);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteDouble(codeProgress);
				_stream.WriteDouble(artProgress);
				_stream.WriteDouble(codeQuality);
				_stream.WriteDouble(artQuality);
				_stream.WriteFloat(price);
				_stream.WriteBool(subscription);
				if (submarkets != null)
				{
					_stream.WriteInt(submarkets.Length);
					foreach (double value3 in submarkets)
					{
						_stream.WriteDouble(value3);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteUInt(company);
				_stream.WriteBool(inHouse);
				_stream.WriteFloat(reception);
				_stream.WriteUInt(sequelTo);
				if (feats != null)
				{
					_stream.WriteInt(feats.Length);
					foreach (uint value4 in feats)
					{
						_stream.WriteUInt(value4);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				if (techs != null)
				{
					_stream.WriteInt(techs.Count);
					foreach (KeyValuePair<string, int> tech in techs)
					{
						string key2 = tech.Key;
						_stream.WriteStringUTF8(key2);
						int value5 = tech.Value;
						_stream.WriteInt(value5);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteDouble(loss);
				_stream.WriteUInt(framework);
				_stream.WriteStringUTF8(newFramework);
				SendData(MessageType.ProductPrototype, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ProductPrototype(NetworkManager.Self, name, id, type, category, needs, os, codeProgress, artProgress, codeQuality, artQuality, price, subscription, submarkets, company, inHouse, reception, sequelTo, feats, techs, loss, framework, newFramework);
			}
			return true;
		}

		private static void ReceiveProductPrototype(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			string name = data.ReadStringUTF8();
			uint id = data.ReadUInt();
			uint type = data.ReadUInt();
			uint category = data.ReadUInt();
			Dictionary<string, uint> dictionary = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				dictionary = new Dictionary<string, uint>(num);
				for (int i = 0; i < num; i++)
				{
					string key = data.ReadStringUTF8();
					uint value = data.ReadUInt();
					dictionary[key] = value;
				}
			}
			uint[] array = null;
			int num2 = data.ReadInt();
			if (num2 >= 0)
			{
				array = new uint[num2];
				for (int j = 0; j < num2; j++)
				{
					uint num3 = data.ReadUInt();
					array[j] = num3;
				}
			}
			double codeProgress = data.ReadDouble();
			double artProgress = data.ReadDouble();
			double codeQuality = data.ReadDouble();
			double artQuality = data.ReadDouble();
			float price = data.ReadFloat();
			bool subscription = data.ReadBool();
			double[] array2 = null;
			int num4 = data.ReadInt();
			if (num4 >= 0)
			{
				array2 = new double[num4];
				for (int k = 0; k < num4; k++)
				{
					double num5 = data.ReadDouble();
					array2[k] = num5;
				}
			}
			uint company = data.ReadUInt();
			bool inHouse = data.ReadBool();
			float reception = data.ReadFloat();
			uint sequelTo = data.ReadUInt();
			uint[] array3 = null;
			int num6 = data.ReadInt();
			if (num6 >= 0)
			{
				array3 = new uint[num6];
				for (int l = 0; l < num6; l++)
				{
					uint num7 = data.ReadUInt();
					array3[l] = num7;
				}
			}
			Dictionary<string, int> dictionary2 = null;
			int num8 = data.ReadInt();
			if (num8 >= 0)
			{
				dictionary2 = new Dictionary<string, int>(num8);
				for (int m = 0; m < num8; m++)
				{
					string key2 = data.ReadStringUTF8();
					int value2 = data.ReadInt();
					dictionary2[key2] = value2;
				}
			}
			double loss = data.ReadDouble();
			uint framework = data.ReadUInt();
			string newFramework = data.ReadStringUTF8();
			ProductPrototype(from, name, id, type, category, dictionary, array, codeProgress, artProgress, codeQuality, artQuality, price, subscription, array2, company, inHouse, reception, sequelTo, array3, dictionary2, loss, framework, newFramework);
		}

		public static bool SendStartDev(uint company, uint project, SDateTime start, SDateTime release, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(project);
				_stream.WriteByteObject(start);
				_stream.WriteByteObject(release);
				SendData(MessageType.StartDev, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				StartDev(NetworkManager.Self, company, project, start, release);
			}
			return true;
		}

		private static void ReceiveStartDev(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint project = data.ReadUInt();
				SDateTime start = SDateTime.ReadData(data);
				SDateTime release = SDateTime.ReadData(data);
				StartDev(from, company, project, start, release);
			}
		}

		public static bool SendReleaseDev(uint company, uint project, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(project);
				SendData(MessageType.ReleaseDev, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ReleaseDev(NetworkManager.Self, company, project);
			}
			return true;
		}

		private static void ReceiveReleaseDev(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint project = data.ReadUInt();
				ReleaseDev(from, company, project);
			}
		}

		public static bool SendAddonPrototype(string name, uint type, uint parent, Dictionary<string, uint> needs, double codeProgress, double artProgress, double codeQuality, double artQuality, float price, uint company, float reception, uint[] feats, uint[] factors, double loss, SDateTime releaseDate, SDateTime devStart, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteStringUTF8(name);
				_stream.WriteUInt(type);
				_stream.WriteUInt(parent);
				if (needs != null)
				{
					_stream.WriteInt(needs.Count);
					foreach (KeyValuePair<string, uint> need in needs)
					{
						string key = need.Key;
						_stream.WriteStringUTF8(key);
						uint value = need.Value;
						_stream.WriteUInt(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteDouble(codeProgress);
				_stream.WriteDouble(artProgress);
				_stream.WriteDouble(codeQuality);
				_stream.WriteDouble(artQuality);
				_stream.WriteFloat(price);
				_stream.WriteUInt(company);
				_stream.WriteFloat(reception);
				if (feats != null)
				{
					_stream.WriteInt(feats.Length);
					foreach (uint value2 in feats)
					{
						_stream.WriteUInt(value2);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				if (factors != null)
				{
					_stream.WriteInt(factors.Length);
					foreach (uint value3 in factors)
					{
						_stream.WriteUInt(value3);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteDouble(loss);
				_stream.WriteByteObject(releaseDate);
				_stream.WriteByteObject(devStart);
				SendData(MessageType.AddonPrototype, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddonPrototype(NetworkManager.Self, name, type, parent, needs, codeProgress, artProgress, codeQuality, artQuality, price, company, reception, feats, factors, loss, releaseDate, devStart);
			}
			return true;
		}

		private static void ReceiveAddonPrototype(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			string name = data.ReadStringUTF8();
			uint type = data.ReadUInt();
			uint parent = data.ReadUInt();
			Dictionary<string, uint> dictionary = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				dictionary = new Dictionary<string, uint>(num);
				for (int i = 0; i < num; i++)
				{
					string key = data.ReadStringUTF8();
					uint value = data.ReadUInt();
					dictionary[key] = value;
				}
			}
			double codeProgress = data.ReadDouble();
			double artProgress = data.ReadDouble();
			double codeQuality = data.ReadDouble();
			double artQuality = data.ReadDouble();
			float price = data.ReadFloat();
			uint company = data.ReadUInt();
			float reception = data.ReadFloat();
			uint[] array = null;
			int num2 = data.ReadInt();
			if (num2 >= 0)
			{
				array = new uint[num2];
				for (int j = 0; j < num2; j++)
				{
					uint num3 = data.ReadUInt();
					array[j] = num3;
				}
			}
			uint[] array2 = null;
			int num4 = data.ReadInt();
			if (num4 >= 0)
			{
				array2 = new uint[num4];
				for (int k = 0; k < num4; k++)
				{
					uint num5 = data.ReadUInt();
					array2[k] = num5;
				}
			}
			double loss = data.ReadDouble();
			SDateTime releaseDate = SDateTime.ReadData(data);
			SDateTime devStart = SDateTime.ReadData(data);
			AddonPrototype(from, name, type, parent, dictionary, codeProgress, artProgress, codeQuality, artQuality, price, company, reception, array, array2, loss, releaseDate, devStart);
		}

		public static bool SendEndAddonDev(uint company, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				SendData(MessageType.EndAddonDev, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				EndAddonDev(NetworkManager.Self, company);
			}
			return true;
		}

		private static void ReceiveEndAddonDev(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				EndAddonDev(from, company);
			}
		}

		public static bool SendUpdateStockMarket(string market, bool metal, float value, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteStringUTF8(market);
				_stream.WriteBool(metal);
				_stream.WriteFloat(value);
				SendData(MessageType.UpdateStockMarket, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateStockMarket(NetworkManager.Self, market, metal, value);
			}
			return true;
		}

		private static void ReceiveUpdateStockMarket(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				string market = data.ReadStringUTF8();
				bool metal = data.ReadBool();
				float value = data.ReadFloat();
				UpdateStockMarket(from, market, metal, value);
			}
		}

		public static bool SendAddStockMarket(string market, float range, float factor, float[] values, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteStringUTF8(market);
				_stream.WriteFloat(range);
				_stream.WriteFloat(factor);
				if (values != null)
				{
					_stream.WriteInt(values.Length);
					foreach (float value in values)
					{
						_stream.WriteFloat(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.AddStockMarket, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddStockMarket(NetworkManager.Self, market, range, factor, values);
			}
			return true;
		}

		private static void ReceiveAddStockMarket(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			string market = data.ReadStringUTF8();
			float range = data.ReadFloat();
			float factor = data.ReadFloat();
			float[] array = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				array = new float[num];
				for (int i = 0; i < num; i++)
				{
					float num2 = data.ReadFloat();
					array[i] = num2;
				}
			}
			AddStockMarket(from, market, range, factor, array);
		}

		public static bool SendUpdateProduct(uint id, Dictionary<string, int> techs, SDateTime time, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				if (techs != null)
				{
					_stream.WriteInt(techs.Count);
					foreach (KeyValuePair<string, int> tech in techs)
					{
						string key = tech.Key;
						_stream.WriteStringUTF8(key);
						int value = tech.Value;
						_stream.WriteInt(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteByteObject(time);
				SendData(MessageType.UpdateProduct, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateProduct(NetworkManager.Self, id, techs, time);
			}
			return true;
		}

		private static void ReceiveUpdateProduct(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			uint id = data.ReadUInt();
			Dictionary<string, int> dictionary = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				dictionary = new Dictionary<string, int>(num);
				for (int i = 0; i < num; i++)
				{
					string key = data.ReadStringUTF8();
					int value = data.ReadInt();
					dictionary[key] = value;
				}
			}
			SDateTime time = SDateTime.ReadData(data);
			UpdateProduct(from, id, dictionary, time);
		}

		public static bool SendUpdateFramework(uint id, Dictionary<string, int> techs, SDateTime time, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				if (techs != null)
				{
					_stream.WriteInt(techs.Count);
					foreach (KeyValuePair<string, int> tech in techs)
					{
						string key = tech.Key;
						_stream.WriteStringUTF8(key);
						int value = tech.Value;
						_stream.WriteInt(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteByteObject(time);
				SendData(MessageType.UpdateFramework, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateFramework(NetworkManager.Self, id, techs, time);
			}
			return true;
		}

		private static void ReceiveUpdateFramework(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			uint id = data.ReadUInt();
			Dictionary<string, int> dictionary = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				dictionary = new Dictionary<string, int>(num);
				for (int i = 0; i < num; i++)
				{
					string key = data.ReadStringUTF8();
					int value = data.ReadInt();
					dictionary[key] = value;
				}
			}
			SDateTime time = SDateTime.ReadData(data);
			UpdateFramework(from, id, dictionary, time);
		}

		public static bool SendChangeBugs(uint id, int startBugs, int bugs, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteInt(startBugs);
				_stream.WriteInt(bugs);
				SendData(MessageType.ChangeBugs, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ChangeBugs(NetworkManager.Self, id, startBugs, bugs);
			}
			return true;
		}

		private static void ReceiveChangeBugs(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				int startBugs = data.ReadInt();
				int bugs = data.ReadInt();
				ChangeBugs(from, id, startBugs, bugs);
			}
		}

		public static bool SendChangePhysicalCopies(uint id, uint addon, uint copies, uint proto, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (addon != 0)
				{
					b |= 1;
				}
				if (copies != 0)
				{
					b |= 2;
				}
				if (proto != 0)
				{
					b |= 4;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(id);
				if ((b & 1) > 0)
				{
					_stream.WriteUInt(addon);
				}
				if ((b & 2) > 0)
				{
					_stream.WriteUInt(copies);
				}
				if ((b & 4) > 0)
				{
					_stream.WriteUInt(proto);
				}
				SendData(MessageType.ChangePhysicalCopies, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ChangePhysicalCopies(NetworkManager.Self, id, addon, copies, proto);
			}
			return true;
		}

		private static void ReceiveChangePhysicalCopies(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint id = data.ReadUInt();
				uint addon = 0u;
				if ((num & 1) > 0)
				{
					addon = data.ReadUInt();
				}
				uint copies = 0u;
				if ((num & 2) > 0)
				{
					copies = data.ReadUInt();
				}
				uint proto = 0u;
				if ((num & 4) > 0)
				{
					proto = data.ReadUInt();
				}
				ChangePhysicalCopies(from, id, addon, copies, proto);
			}
		}

		public static bool SendRunProductScripts(uint id, uint feature, ScriptSystem.EntryPoint entry, ScriptSystem.ProductScope scope, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteUInt(feature);
				_stream.WriteEnum(entry, true);
				if (scope != null)
				{
					_stream.WriteByteObject(scope);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.RunProductScripts, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				RunProductScripts(NetworkManager.Self, id, feature, entry, scope);
			}
			return true;
		}

		private static void ReceiveRunProductScripts(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				uint feature = data.ReadUInt();
				ScriptSystem.EntryPoint entry = data.ReadEnum<ScriptSystem.EntryPoint>(true);
				ScriptSystem.ProductScope scope = ScriptSystem.ProductScope.ReadData(data);
				RunProductScripts(from, id, feature, entry, scope);
			}
		}

		public static bool SendRunCopyScripts(uint id, uint feature, ScriptSystem.EntryPoint entry, ScriptSystem.CopyScope scope, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteUInt(feature);
				_stream.WriteEnum(entry, true);
				if (scope != null)
				{
					_stream.WriteByteObject(scope);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.RunCopyScripts, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				RunCopyScripts(NetworkManager.Self, id, feature, entry, scope);
			}
			return true;
		}

		private static void ReceiveRunCopyScripts(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				uint feature = data.ReadUInt();
				ScriptSystem.EntryPoint entry = data.ReadEnum<ScriptSystem.EntryPoint>(true);
				ScriptSystem.CopyScope scope = ScriptSystem.CopyScope.ReadData(data);
				RunCopyScripts(from, id, feature, entry, scope);
			}
		}

		public static bool SendCreateDigitalPlatform(uint owner, uint software, float cut, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(owner);
				_stream.WriteUInt(software);
				_stream.WriteFloat(cut);
				SendData(MessageType.CreateDigitalPlatform, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				CreateDigitalPlatform(NetworkManager.Self, owner, software, cut);
			}
			return true;
		}

		private static void ReceiveCreateDigitalPlatform(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint owner = data.ReadUInt();
				uint software = data.ReadUInt();
				float cut = data.ReadFloat();
				CreateDigitalPlatform(from, owner, software, cut);
			}
		}

		public static bool SendSignDigitalPlatform(uint company, uint platform, bool sign, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(platform);
				_stream.WriteBool(sign);
				SendData(MessageType.SignDigitalPlatform, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				SignDigitalPlatform(NetworkManager.Self, company, platform, sign);
			}
			return true;
		}

		private static void ReceiveSignDigitalPlatform(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint platform = data.ReadUInt();
				bool sign = data.ReadBool();
				SignDigitalPlatform(from, company, platform, sign);
			}
		}

		public static bool SendRegisterLocalPlayerPlatformQuery(uint company, uint platformC, bool interested, int quarantine, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(platformC);
				_stream.WriteBool(interested);
				_stream.WriteInt(quarantine);
				SendData(MessageType.RegisterLocalPlayerPlatformQuery, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				RegisterLocalPlayerPlatformQuery(NetworkManager.Self, company, platformC, interested, quarantine);
			}
			return true;
		}

		private static void ReceiveRegisterLocalPlayerPlatformQuery(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint platformC = data.ReadUInt();
				bool interested = data.ReadBool();
				int quarantine = data.ReadInt();
				RegisterLocalPlayerPlatformQuery(from, company, platformC, interested, quarantine);
			}
		}

		public static bool SendDistributionCut(uint platform, float cut, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(platform);
				_stream.WriteFloat(cut);
				SendData(MessageType.DistributionCut, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				DistributionCut(NetworkManager.Self, platform, cut);
			}
			return true;
		}

		private static void ReceiveDistributionCut(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint platform = data.ReadUInt();
				float cut = data.ReadFloat();
				DistributionCut(from, platform, cut);
			}
		}

		public static bool SendDistributionState(uint platform, bool open, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(platform);
				_stream.WriteBool(open);
				SendData(MessageType.DistributionState, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				DistributionState(NetworkManager.Self, platform, open);
			}
			return true;
		}

		private static void ReceiveDistributionState(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint platform = data.ReadUInt();
				bool open = data.ReadBool();
				DistributionState(from, platform, open);
			}
		}

		public static bool SendDistributionStats(uint platform, uint targetUsers, uint penalty, uint actualUsers, int userBase, bool penaltyOnly, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (platform != 0)
				{
					b |= 1;
				}
				if (targetUsers != 0)
				{
					b |= 2;
				}
				if (penalty != 0)
				{
					b |= 4;
				}
				if (actualUsers != 0)
				{
					b |= 8;
				}
				if (userBase != 0)
				{
					b |= 0x10;
				}
				if (penaltyOnly)
				{
					b |= 0x20;
				}
				_stream.WriteByte(b);
				if ((b & 1) > 0)
				{
					_stream.WriteUInt(platform);
				}
				if ((b & 2) > 0)
				{
					_stream.WriteUInt(targetUsers);
				}
				if ((b & 4) > 0)
				{
					_stream.WriteUInt(penalty);
				}
				if ((b & 8) > 0)
				{
					_stream.WriteUInt(actualUsers);
				}
				if ((b & 0x10) > 0)
				{
					_stream.WriteInt(userBase);
				}
				SendData(MessageType.DistributionStats, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				DistributionStats(NetworkManager.Self, platform, targetUsers, penalty, actualUsers, userBase, penaltyOnly);
			}
			return true;
		}

		private static void ReceiveDistributionStats(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint platform = 0u;
				if ((num & 1) > 0)
				{
					platform = data.ReadUInt();
				}
				uint targetUsers = 0u;
				if ((num & 2) > 0)
				{
					targetUsers = data.ReadUInt();
				}
				uint penalty = 0u;
				if ((num & 4) > 0)
				{
					penalty = data.ReadUInt();
				}
				uint actualUsers = 0u;
				if ((num & 8) > 0)
				{
					actualUsers = data.ReadUInt();
				}
				int userBase = 0;
				if ((num & 0x10) > 0)
				{
					userBase = data.ReadInt();
				}
				bool penaltyOnly = (num & 0x20) > 0;
				DistributionStats(from, platform, targetUsers, penalty, actualUsers, userBase, penaltyOnly);
			}
		}

		public static bool SendChangePlatformAccept(uint company, bool client, bool value, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (client)
				{
					b |= 1;
				}
				if (value)
				{
					b |= 2;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(company);
				SendData(MessageType.ChangePlatformAccept, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ChangePlatformAccept(NetworkManager.Self, company, client, value);
			}
			return true;
		}

		private static void ReceiveChangePlatformAccept(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint company = data.ReadUInt();
				bool client = (num & 1) > 0;
				bool value = (num & 2) > 0;
				ChangePlatformAccept(from, company, client, value);
			}
		}

		public static bool SendDistributionLoad(Dictionary<uint, float> loads, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				if (loads != null)
				{
					_stream.WriteInt(loads.Count);
					foreach (KeyValuePair<uint, float> load in loads)
					{
						uint key = load.Key;
						_stream.WriteUInt(key);
						float value = load.Value;
						_stream.WriteFloat(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.DistributionLoad, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				DistributionLoad(NetworkManager.Self, loads);
			}
			return true;
		}

		private static void ReceiveDistributionLoad(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			Dictionary<uint, float> dictionary = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				dictionary = new Dictionary<uint, float>(num);
				for (int i = 0; i < num; i++)
				{
					uint key = data.ReadUInt();
					float value = data.ReadFloat();
					dictionary[key] = value;
				}
			}
			DistributionLoad(from, dictionary);
		}

		public static bool SendDistributionSales(uint platform, float sales, float actualSales, uint total, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (actualSales != 0f)
				{
					b |= 1;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(platform);
				_stream.WriteFloat(sales);
				if ((b & 1) > 0)
				{
					_stream.WriteFloat(actualSales);
				}
				_stream.WriteUInt(total);
				SendData(MessageType.DistributionSales, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				DistributionSales(NetworkManager.Self, platform, sales, actualSales, total);
			}
			return true;
		}

		private static void ReceiveDistributionSales(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint platform = data.ReadUInt();
				float sales = data.ReadFloat();
				float actualSales = 0f;
				if ((num & 1) > 0)
				{
					actualSales = data.ReadFloat();
				}
				uint total = data.ReadUInt();
				DistributionSales(from, platform, sales, actualSales, total);
			}
		}

		public static bool SendExclusiveStore(uint product, uint platform, SDateTime end, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(product);
				_stream.WriteUInt(platform);
				_stream.WriteByteObject(end);
				SendData(MessageType.ExclusiveStore, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ExclusiveStore(NetworkManager.Self, product, platform, end);
			}
			return true;
		}

		private static void ReceiveExclusiveStore(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint product = data.ReadUInt();
				uint platform = data.ReadUInt();
				SDateTime end = SDateTime.ReadData(data);
				ExclusiveStore(from, product, platform, end);
			}
		}

		public static bool SendDistributionBandwidth(uint platform, float bandwidth, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(platform);
				_stream.WriteFloat(bandwidth);
				SendData(MessageType.DistributionBandwidth, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				DistributionBandwidth(NetworkManager.Self, platform, bandwidth);
			}
			return true;
		}

		private static void ReceiveDistributionBandwidth(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint platform = data.ReadUInt();
				float bandwidth = data.ReadFloat();
				DistributionBandwidth(from, platform, bandwidth);
			}
		}

		public static bool SendSoftwareID(uint id, bool framework, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (id != 0)
				{
					b |= 1;
				}
				if (framework)
				{
					b |= 2;
				}
				_stream.WriteByte(b);
				if ((b & 1) > 0)
				{
					_stream.WriteUInt(id);
				}
				SendData(MessageType.SoftwareID, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				SoftwareID(NetworkManager.Self, id, framework);
			}
			return true;
		}

		private static void ReceiveSoftwareID(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint id = 0u;
				if ((num & 1) > 0)
				{
					id = data.ReadUInt();
				}
				bool framework = (num & 2) > 0;
				SoftwareID(from, id, framework);
			}
		}

		public static bool SendChangePrice(uint id, uint addon, float newPrice, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteUInt(addon);
				_stream.WriteFloat(newPrice);
				SendData(MessageType.ChangePrice, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ChangePrice(NetworkManager.Self, id, addon, newPrice);
			}
			return true;
		}

		private static void ReceiveChangePrice(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				uint addon = data.ReadUInt();
				float newPrice = data.ReadFloat();
				ChangePrice(from, id, addon, newPrice);
			}
		}

		public static bool SendMakeSubsidiary(uint company, uint newOwner, SDateTime time, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(newOwner);
				_stream.WriteByteObject(time);
				SendData(MessageType.MakeSubsidiary, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				MakeSubsidiary(NetworkManager.Self, company, newOwner, time);
			}
			return true;
		}

		private static void ReceiveMakeSubsidiary(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint newOwner = data.ReadUInt();
				SDateTime time = SDateTime.ReadData(data);
				MakeSubsidiary(from, company, newOwner, time);
			}
		}

		public static bool SendScheduleRelease(uint company, uint id, string name, uint swType, uint swCat, uint sequelTo, SDateTime? date, bool reschedule, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (name != null)
				{
					b |= 1;
				}
				if (swType != 0)
				{
					b |= 2;
				}
				if (swCat != 0)
				{
					b |= 4;
				}
				if (sequelTo != 0)
				{
					b |= 8;
				}
				if (date.HasValue)
				{
					b |= 0x10;
				}
				if (reschedule)
				{
					b |= 0x20;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(company);
				_stream.WriteUInt(id);
				if ((b & 1) > 0)
				{
					_stream.WriteStringUTF8(name);
				}
				if ((b & 2) > 0)
				{
					_stream.WriteUInt(swType);
				}
				if ((b & 4) > 0)
				{
					_stream.WriteUInt(swCat);
				}
				if ((b & 8) > 0)
				{
					_stream.WriteUInt(sequelTo);
				}
				if ((b & 0x10) > 0)
				{
					_stream.WriteByteObject(date.Value);
				}
				SendData(MessageType.ScheduleRelease, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ScheduleRelease(NetworkManager.Self, company, id, name, swType, swCat, sequelTo, date, reschedule);
			}
			return true;
		}

		private static void ReceiveScheduleRelease(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint company = data.ReadUInt();
				uint id = data.ReadUInt();
				string name = null;
				if ((num & 1) > 0)
				{
					name = data.ReadStringUTF8();
				}
				uint swType = 0u;
				if ((num & 2) > 0)
				{
					swType = data.ReadUInt();
				}
				uint swCat = 0u;
				if ((num & 4) > 0)
				{
					swCat = data.ReadUInt();
				}
				uint sequelTo = 0u;
				if ((num & 8) > 0)
				{
					sequelTo = data.ReadUInt();
				}
				SDateTime? date = null;
				if ((num & 0x10) > 0)
				{
					date = SDateTime.ReadData(data);
				}
				bool reschedule = (num & 0x20) > 0;
				ScheduleRelease(from, company, id, name, swType, swCat, sequelTo, date, reschedule);
			}
		}

		public static bool SendAddDeal(Deal deal, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				if (deal != null)
				{
					_stream.WriteByteObject(deal);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.AddDeal, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddDeal(NetworkManager.Self, deal);
			}
			return true;
		}

		private static void ReceiveAddDeal(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				Deal deal = Deal.ReadData(data);
				AddDeal(from, deal);
			}
		}

		public static bool SendCancelDeal(uint deal, bool repercussion, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(deal);
				_stream.WriteBool(repercussion);
				SendData(MessageType.CancelDeal, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				CancelDeal(NetworkManager.Self, deal, repercussion);
			}
			return true;
		}

		private static void ReceiveCancelDeal(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint deal = data.ReadUInt();
				bool repercussion = data.ReadBool();
				CancelDeal(from, deal, repercussion);
			}
		}

		public static bool SendUpdateProtoQuality(uint company, uint product, double codeP, double artP, double codeQ, double artQ, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(product);
				_stream.WriteDouble(codeP);
				_stream.WriteDouble(artP);
				_stream.WriteDouble(codeQ);
				_stream.WriteDouble(artQ);
				SendData(MessageType.UpdateProtoQuality, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateProtoQuality(NetworkManager.Self, company, product, codeP, artP, codeQ, artQ);
			}
			return true;
		}

		private static void ReceiveUpdateProtoQuality(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint product = data.ReadUInt();
				double codeP = data.ReadDouble();
				double artP = data.ReadDouble();
				double codeQ = data.ReadDouble();
				double artQ = data.ReadDouble();
				UpdateProtoQuality(from, company, product, codeP, artP, codeQ, artQ);
			}
		}

		public static bool SendPort(uint product, uint OS, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(product);
				_stream.WriteUInt(OS);
				SendData(MessageType.Port, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				Port(NetworkManager.Self, product, OS);
			}
			return true;
		}

		private static void ReceivePort(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint product = data.ReadUInt();
				uint oS = data.ReadUInt();
				Port(from, product, oS);
			}
		}

		public static void SendRequestSync(SyncType type, uint id, bool approved, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				_stream.WriteEnum(type, true);
				_stream.WriteUInt(id);
				_stream.WriteBool(approved);
				SendData(MessageType.RequestSync, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				RequestSync(NetworkManager.Self, type, id, approved);
			}
		}

		private static void ReceiveRequestSync(NetworkPlayer from, MemoryStream data)
		{
			SyncType type = data.ReadEnum<SyncType>(true);
			uint id = data.ReadUInt();
			bool approved = data.ReadBool();
			RequestSync(from, type, id, approved);
		}

		public static void SendRequestSyncVerify(SyncType type, uint id, uint verification, uint newValue, bool approved, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				_stream.WriteEnum(type, true);
				_stream.WriteUInt(id);
				_stream.WriteUInt(verification);
				_stream.WriteUInt(newValue);
				_stream.WriteBool(approved);
				SendData(MessageType.RequestSyncVerify, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				RequestSyncVerify(NetworkManager.Self, type, id, verification, newValue, approved);
			}
		}

		private static void ReceiveRequestSyncVerify(NetworkPlayer from, MemoryStream data)
		{
			SyncType type = data.ReadEnum<SyncType>(true);
			uint id = data.ReadUInt();
			uint verification = data.ReadUInt();
			uint newValue = data.ReadUInt();
			bool approved = data.ReadBool();
			RequestSyncVerify(from, type, id, verification, newValue, approved);
		}

		public static bool SendAddLoss(uint id, float loss, SoftwareProduct.LossType type, uint addon, uint license, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (type != SoftwareProduct.LossType.Other)
				{
					b |= 1;
				}
				if (addon != 0)
				{
					b |= 2;
				}
				if (license != 0)
				{
					b |= 4;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(id);
				_stream.WriteFloat(loss);
				if ((b & 1) > 0)
				{
					_stream.WriteEnum(type, true);
				}
				if ((b & 2) > 0)
				{
					_stream.WriteUInt(addon);
				}
				if ((b & 4) > 0)
				{
					_stream.WriteUInt(license);
				}
				SendData(MessageType.AddLoss, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddLoss(NetworkManager.Self, id, loss, type, addon, license);
			}
			return true;
		}

		private static void ReceiveAddLoss(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint id = data.ReadUInt();
				float loss = data.ReadFloat();
				SoftwareProduct.LossType type = SoftwareProduct.LossType.Other;
				if ((num & 1) > 0)
				{
					type = data.ReadEnum<SoftwareProduct.LossType>(true);
				}
				uint addon = 0u;
				if ((num & 2) > 0)
				{
					addon = data.ReadUInt();
				}
				uint license = 0u;
				if ((num & 4) > 0)
				{
					license = data.ReadUInt();
				}
				AddLoss(from, id, loss, type, addon, license);
			}
		}

		public static bool SendAddonSimulation(uint id, uint addon, double gross, int refunds, int online, int offline, float lastMonthIncome, float lastDayLoss, float lastDayIncome, SDateTime time, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (gross != 0.0)
				{
					b |= 1;
				}
				if (refunds != 0)
				{
					b |= 2;
				}
				if (online != 0)
				{
					b |= 4;
				}
				if (offline != 0)
				{
					b |= 8;
				}
				if (lastMonthIncome != 0f)
				{
					b |= 0x10;
				}
				if (lastDayLoss != 0f)
				{
					b |= 0x20;
				}
				if (lastDayIncome != 0f)
				{
					b |= 0x40;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(id);
				_stream.WriteUInt(addon);
				if ((b & 1) > 0)
				{
					_stream.WriteDouble(gross);
				}
				if ((b & 2) > 0)
				{
					_stream.WriteInt(refunds);
				}
				if ((b & 4) > 0)
				{
					_stream.WriteInt(online);
				}
				if ((b & 8) > 0)
				{
					_stream.WriteInt(offline);
				}
				if ((b & 0x10) > 0)
				{
					_stream.WriteFloat(lastMonthIncome);
				}
				if ((b & 0x20) > 0)
				{
					_stream.WriteFloat(lastDayLoss);
				}
				if ((b & 0x40) > 0)
				{
					_stream.WriteFloat(lastDayIncome);
				}
				_stream.WriteByteObject(time);
				SendData(MessageType.AddonSimulation, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddonSimulation(NetworkManager.Self, id, addon, gross, refunds, online, offline, lastMonthIncome, lastDayLoss, lastDayIncome, time);
			}
			return true;
		}

		private static void ReceiveAddonSimulation(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint id = data.ReadUInt();
				uint addon = data.ReadUInt();
				double gross = 0.0;
				if ((num & 1) > 0)
				{
					gross = data.ReadDouble();
				}
				int refunds = 0;
				if ((num & 2) > 0)
				{
					refunds = data.ReadInt();
				}
				int online = 0;
				if ((num & 4) > 0)
				{
					online = data.ReadInt();
				}
				int offline = 0;
				if ((num & 8) > 0)
				{
					offline = data.ReadInt();
				}
				float lastMonthIncome = 0f;
				if ((num & 0x10) > 0)
				{
					lastMonthIncome = data.ReadFloat();
				}
				float lastDayLoss = 0f;
				if ((num & 0x20) > 0)
				{
					lastDayLoss = data.ReadFloat();
				}
				float lastDayIncome = 0f;
				if ((num & 0x40) > 0)
				{
					lastDayIncome = data.ReadFloat();
				}
				SDateTime time = SDateTime.ReadData(data);
				AddonSimulation(from, id, addon, gross, refunds, online, offline, lastMonthIncome, lastDayLoss, lastDayIncome, time);
			}
		}

		public static bool SendAddProductLoadIncident(uint id, bool add, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteBool(add);
				SendData(MessageType.AddProductLoadIncident, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddProductLoadIncident(NetworkManager.Self, id, add);
			}
			return true;
		}

		private static void ReceiveAddProductLoadIncident(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				bool add = data.ReadBool();
				AddProductLoadIncident(from, id, add);
			}
		}

		public static bool SendAddProductRep(uint id, int change, SDateTime time, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (change != 0)
				{
					b |= 1;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(id);
				if ((b & 1) > 0)
				{
					_stream.WriteInt(change);
				}
				_stream.WriteByteObject(time);
				SendData(MessageType.AddProductRep, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddProductRep(NetworkManager.Self, id, change, time);
			}
			return true;
		}

		private static void ReceiveAddProductRep(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint id = data.ReadUInt();
				int change = 0;
				if ((num & 1) > 0)
				{
					change = data.ReadInt();
				}
				SDateTime time = SDateTime.ReadData(data);
				AddProductRep(from, id, change, time);
			}
		}

		public static bool SendFrameworkPayment(uint id, uint product, float amount, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteUInt(product);
				_stream.WriteFloat(amount);
				SendData(MessageType.FrameworkPayment, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				FrameworkPayment(NetworkManager.Self, id, product, amount);
			}
			return true;
		}

		private static void ReceiveFrameworkPayment(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				uint product = data.ReadUInt();
				float amount = data.ReadFloat();
				FrameworkPayment(from, id, product, amount);
			}
		}

		public static bool SendAIResearch(uint company, SimulatedCompany.TechResearch t, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				if (t != null)
				{
					_stream.WriteByteObject(t);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.AIResearch, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AIResearch(NetworkManager.Self, company, t);
			}
			return true;
		}

		private static void ReceiveAIResearch(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				SimulatedCompany.TechResearch t = SimulatedCompany.TechResearch.ReadData(data);
				AIResearch(from, company, t);
			}
		}

		public static bool SendDividendStats(Dictionary<uint, Dictionary<uint, float>> div, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				if (div != null)
				{
					_stream.WriteInt(div.Count);
					foreach (KeyValuePair<uint, Dictionary<uint, float>> item in div)
					{
						uint key = item.Key;
						_stream.WriteUInt(key);
						Dictionary<uint, float> value = item.Value;
						if (value != null)
						{
							_stream.WriteInt(value.Count);
							foreach (KeyValuePair<uint, float> item2 in value)
							{
								uint key2 = item2.Key;
								_stream.WriteUInt(key2);
								float value2 = item2.Value;
								_stream.WriteFloat(value2);
							}
						}
						else
						{
							_stream.WriteInt(-1);
						}
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.DividendStats, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				DividendStats(NetworkManager.Self, div);
			}
			return true;
		}

		private static void ReceiveDividendStats(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			Dictionary<uint, Dictionary<uint, float>> dictionary = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				dictionary = new Dictionary<uint, Dictionary<uint, float>>(num);
				for (int i = 0; i < num; i++)
				{
					uint key = data.ReadUInt();
					Dictionary<uint, float> dictionary2 = null;
					int num2 = data.ReadInt();
					if (num2 >= 0)
					{
						dictionary2 = new Dictionary<uint, float>(num2);
						for (int j = 0; j < num2; j++)
						{
							uint key2 = data.ReadUInt();
							float value = data.ReadFloat();
							dictionary2[key2] = value;
						}
					}
					dictionary[key] = dictionary2;
				}
			}
			DividendStats(from, dictionary);
		}

		public static bool SendBroadcastUUID(string uuid, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteStringUTF8(uuid);
				SendData(MessageType.BroadcastUUID, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				BroadcastUUID(NetworkManager.Self, uuid);
			}
			return true;
		}

		private static void ReceiveBroadcastUUID(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				string uuid = data.ReadStringUTF8();
				BroadcastUUID(from, uuid);
			}
		}

		public static void SendInitialGameSettings(InitialNetworkSettings settings, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				if (settings != null)
				{
					_stream.WriteByteObject(settings);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.InitialGameSettings, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				InitialGameSettings(NetworkManager.Self, settings);
			}
		}

		private static void ReceiveInitialGameSettings(NetworkPlayer from, MemoryStream data)
		{
			InitialNetworkSettings settings = InitialNetworkSettings.ReadData(data);
			InitialGameSettings(from, settings);
		}

		public static bool SendRainSync(Vector2 windiness, float sunSize, float cloudy, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteVector(windiness);
				_stream.WriteFloat(sunSize);
				_stream.WriteFloat(cloudy);
				SendData(MessageType.RainSync, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				RainSync(NetworkManager.Self, windiness, sunSize, cloudy);
			}
			return true;
		}

		private static void ReceiveRainSync(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				SVector3 sVector = data.ReadVector();
				float sunSize = data.ReadFloat();
				float cloudy = data.ReadFloat();
				RainSync(from, sVector, sunSize, cloudy);
			}
		}

		public static bool SendAwardWinners(List<KeyValuePair<uint, string>>[] winners, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				if (winners != null)
				{
					_stream.WriteInt(winners.Length);
					foreach (List<KeyValuePair<uint, string>> list in winners)
					{
						if (list != null)
						{
							_stream.WriteInt(list.Count);
							for (int j = 0; j < list.Count; j++)
							{
								KeyValuePair<uint, string> keyValuePair = list[j];
								_stream.WriteUInt(keyValuePair.Key);
								_stream.WriteStringUTF8(keyValuePair.Value);
							}
						}
						else
						{
							_stream.WriteInt(-1);
						}
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.AwardWinners, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AwardWinners(NetworkManager.Self, winners);
			}
			return true;
		}

		private static void ReceiveAwardWinners(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			List<KeyValuePair<uint, string>>[] array = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				array = new List<KeyValuePair<uint, string>>[num];
				for (int i = 0; i < num; i++)
				{
					List<KeyValuePair<uint, string>> list = null;
					int num2 = data.ReadInt();
					if (num2 >= 0)
					{
						list = new List<KeyValuePair<uint, string>>(num2);
						for (int j = 0; j < num2; j++)
						{
							uint key = data.ReadUInt();
							string value = data.ReadStringUTF8();
							KeyValuePair<uint, string> item = new KeyValuePair<uint, string>(key, value);
							list.Add(item);
						}
					}
					array[i] = list;
				}
			}
			AwardWinners(from, array);
		}

		public static bool SendEmployerScore(float score, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteFloat(score);
				SendData(MessageType.EmployerScore, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				EmployerScore(NetworkManager.Self, score);
			}
			return true;
		}

		private static void ReceiveEmployerScore(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				float score = data.ReadFloat();
				EmployerScore(from, score);
			}
		}

		public static bool SendBusinessRep(float pct, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteFloat(pct);
				SendData(MessageType.BusinessRep, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				BusinessRep(NetworkManager.Self, pct);
			}
			return true;
		}

		private static void ReceiveBusinessRep(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				float pct = data.ReadFloat();
				BusinessRep(from, pct);
			}
		}

		public static bool SendTakeOverData(uint company, Company.TakeOverData takeOverData, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				if (takeOverData != null)
				{
					_stream.WriteByteObject(takeOverData);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.TakeOverData, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				TakeOverData(NetworkManager.Self, company, takeOverData);
			}
			return true;
		}

		private static void ReceiveTakeOverData(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				Company.TakeOverData takeOverData = Company.TakeOverData.ReadData(data);
				TakeOverData(from, company, takeOverData);
			}
		}

		public static bool SendNewspaperTakeover(uint company, uint[] buyers, double amount, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				if (buyers != null)
				{
					_stream.WriteInt(buyers.Length);
					foreach (uint value in buyers)
					{
						_stream.WriteUInt(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteDouble(amount);
				SendData(MessageType.NewspaperTakeover, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				NewspaperTakeover(NetworkManager.Self, company, buyers, amount);
			}
			return true;
		}

		private static void ReceiveNewspaperTakeover(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			uint company = data.ReadUInt();
			uint[] array = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				array = new uint[num];
				for (int i = 0; i < num; i++)
				{
					uint num2 = data.ReadUInt();
					array[i] = num2;
				}
			}
			double amount = data.ReadDouble();
			NewspaperTakeover(from, company, array, amount);
		}

		public static void SendTryReconnection(bool host, byte id, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				SendData(MessageType.TryReconnection, new byte[2]
				{
					(byte)(host ? 1 : 0),
					id
				}, false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				TryReconnection(NetworkManager.Self, host, id);
			}
		}

		private static void ReceiveTryReconnection(NetworkPlayer from, MemoryStream data)
		{
			bool host = data.ReadBool();
			int num = data.ReadByte();
			TryReconnection(from, host, (byte)num);
		}

		public static void SendNotification(NotificationMessage msg, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				if (msg != null)
				{
					_stream.WriteByteObject(msg);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.Notification, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				Notification(NetworkManager.Self, msg);
			}
		}

		private static void ReceiveNotification(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				NotificationMessage msg = NotificationMessage.ReadData(data);
				Notification(from, msg);
			}
		}

		public static void SendDiagnostics(DiagnosticSheet type, string[] theirs, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteEnum(type, true);
				if (theirs != null)
				{
					_stream.WriteInt(theirs.Length);
					foreach (string value in theirs)
					{
						_stream.WriteStringUTF8(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.Diagnostics, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				Diagnostics(NetworkManager.Self, type, theirs);
			}
		}

		private static void ReceiveDiagnostics(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			DiagnosticSheet type = data.ReadEnum<DiagnosticSheet>(true);
			string[] array = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				array = new string[num];
				for (int i = 0; i < num; i++)
				{
					string text = data.ReadStringUTF8();
					array[i] = text;
				}
			}
			Diagnostics(from, type, array);
		}

		public static void SendSyncMoney(uint[] companies, double[] money, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				if (companies != null)
				{
					_stream.WriteInt(companies.Length);
					foreach (uint value in companies)
					{
						_stream.WriteUInt(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				if (money != null)
				{
					_stream.WriteInt(money.Length);
					foreach (double value2 in money)
					{
						_stream.WriteDouble(value2);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.SyncMoney, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				SyncMoney(NetworkManager.Self, companies, money);
			}
		}

		private static void ReceiveSyncMoney(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			uint[] array = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				array = new uint[num];
				for (int i = 0; i < num; i++)
				{
					uint num2 = data.ReadUInt();
					array[i] = num2;
				}
			}
			double[] array2 = null;
			int num3 = data.ReadInt();
			if (num3 >= 0)
			{
				array2 = new double[num3];
				for (int j = 0; j < num3; j++)
				{
					double num4 = data.ReadDouble();
					array2[j] = num4;
				}
			}
			SyncMoney(from, array, array2);
		}

		public static bool SendNewRoom(BuildingPrefab prefab, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				if (prefab != null)
				{
					_stream.WriteByteObject(prefab);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.NewRoom, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				NewRoom(NetworkManager.Self, prefab);
			}
			return true;
		}

		private static void ReceiveNewRoom(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				BuildingPrefab prefab = BuildingPrefab.ReadData(data);
				NewRoom(from, prefab);
			}
		}

		public static bool SendNewRoomSegment(BuildingPrefab.SegmentObject segment, uint parentRoom, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				if (segment != null)
				{
					_stream.WriteByteObject(segment);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteUInt(parentRoom);
				SendData(MessageType.NewRoomSegment, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				NewRoomSegment(NetworkManager.Self, segment, parentRoom);
			}
			return true;
		}

		private static void ReceiveNewRoomSegment(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				BuildingPrefab.SegmentObject segment = BuildingPrefab.SegmentObject.ReadData(data);
				uint parentRoom = data.ReadUInt();
				NewRoomSegment(from, segment, parentRoom);
			}
		}

		public static bool SendNewFurniture(BuildingPrefab.FurnitureObject furn, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				if (furn != null)
				{
					_stream.WriteByteObject(furn);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.NewFurniture, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				NewFurniture(NetworkManager.Self, furn);
			}
			return true;
		}

		private static void ReceiveNewFurniture(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				BuildingPrefab.FurnitureObject furn = BuildingPrefab.FurnitureObject.ReadData(data);
				NewFurniture(from, furn);
			}
		}

		public static bool SendMoveFurniture(uint id, Vector3 position, int floor, float rot, float rotOffset, uint room, uint parent, int snapID, bool isReversed, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (rotOffset != 0f)
				{
					b |= 1;
				}
				if (room != 0)
				{
					b |= 2;
				}
				if (parent != 0)
				{
					b |= 4;
				}
				if (snapID != 0)
				{
					b |= 8;
				}
				if (isReversed)
				{
					b |= 0x10;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(id);
				_stream.WriteVector(position);
				_stream.WriteInt(floor);
				_stream.WriteFloat(rot);
				if ((b & 1) > 0)
				{
					_stream.WriteFloat(rotOffset);
				}
				if ((b & 2) > 0)
				{
					_stream.WriteUInt(room);
				}
				if ((b & 4) > 0)
				{
					_stream.WriteUInt(parent);
				}
				if ((b & 8) > 0)
				{
					_stream.WriteInt(snapID);
				}
				SendData(MessageType.MoveFurniture, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				MoveFurniture(NetworkManager.Self, id, position, floor, rot, rotOffset, room, parent, snapID, isReversed);
			}
			return true;
		}

		private static void ReceiveMoveFurniture(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint id = data.ReadUInt();
				SVector3 sVector = data.ReadVector();
				int floor = data.ReadInt();
				float rot = data.ReadFloat();
				float rotOffset = 0f;
				if ((num & 1) > 0)
				{
					rotOffset = data.ReadFloat();
				}
				uint room = 0u;
				if ((num & 2) > 0)
				{
					room = data.ReadUInt();
				}
				uint parent = 0u;
				if ((num & 4) > 0)
				{
					parent = data.ReadUInt();
				}
				int snapID = 0;
				if ((num & 8) > 0)
				{
					snapID = data.ReadInt();
				}
				bool isReversed = (num & 0x10) > 0;
				MoveFurniture(from, id, sVector, floor, rot, rotOffset, room, parent, snapID, isReversed);
			}
		}

		public static bool SendDestroyNetworkObject(uint id, bool local, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteBool(local);
				SendData(MessageType.DestroyNetworkObject, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				DestroyNetworkObject(NetworkManager.Self, id, local);
			}
			return true;
		}

		private static void ReceiveDestroyNetworkObject(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				bool local = data.ReadBool();
				DestroyNetworkObject(from, id, local);
			}
		}

		public static bool SendUpdateRoomAtrium(uint room, int floors, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(room);
				_stream.WriteInt(floors);
				SendData(MessageType.UpdateRoomAtrium, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateRoomAtrium(NetworkManager.Self, room, floors);
			}
			return true;
		}

		private static void ReceiveUpdateRoomAtrium(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint room = data.ReadUInt();
				int floors = data.ReadInt();
				UpdateRoomAtrium(from, room, floors);
			}
		}

		public static bool SendObjectStyle(uint id, bool local, string material, string material2, Color c, Color c2, Color c3, Color c4, int atlasIndex, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (local)
				{
					b |= 1;
				}
				if (material != null)
				{
					b |= 2;
				}
				if (material2 != null)
				{
					b |= 4;
				}
				if (c != Color.black)
				{
					b |= 8;
				}
				if (c2 != Color.black)
				{
					b |= 0x10;
				}
				if (c3 != Color.black)
				{
					b |= 0x20;
				}
				if (c4 != Color.black)
				{
					b |= 0x40;
				}
				if (atlasIndex != 0)
				{
					b |= 0x80;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(id);
				if ((b & 2) > 0)
				{
					_stream.WriteStringUTF8(material);
				}
				if ((b & 4) > 0)
				{
					_stream.WriteStringUTF8(material2);
				}
				if ((b & 8) > 0)
				{
					_stream.WriteColor(c);
				}
				if ((b & 0x10) > 0)
				{
					_stream.WriteColor(c2);
				}
				if ((b & 0x20) > 0)
				{
					_stream.WriteColor(c3);
				}
				if ((b & 0x40) > 0)
				{
					_stream.WriteColor(c4);
				}
				if ((b & 0x80) > 0)
				{
					_stream.WriteInt(atlasIndex);
				}
				SendData(MessageType.ObjectStyle, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ObjectStyle(NetworkManager.Self, id, local, material, material2, c, c2, c3, c4, atlasIndex);
			}
			return true;
		}

		private static void ReceiveObjectStyle(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint id = data.ReadUInt();
				bool local = (num & 1) > 0;
				string material = null;
				if ((num & 2) > 0)
				{
					material = data.ReadStringUTF8();
				}
				string material2 = null;
				if ((num & 4) > 0)
				{
					material2 = data.ReadStringUTF8();
				}
				Color c = Color.black;
				if ((num & 8) > 0)
				{
					c = data.ReadColor();
				}
				Color c2 = Color.black;
				if ((num & 0x10) > 0)
				{
					c2 = data.ReadColor();
				}
				Color c3 = Color.black;
				if ((num & 0x20) > 0)
				{
					c3 = data.ReadColor();
				}
				Color c4 = Color.black;
				if ((num & 0x40) > 0)
				{
					c4 = data.ReadColor();
				}
				int atlasIndex = 0;
				if ((num & 0x80) > 0)
				{
					atlasIndex = data.ReadInt();
				}
				ObjectStyle(from, id, local, material, material2, c, c2, c3, c4, atlasIndex);
			}
		}

		public static bool SendRoomEdges(uint room, Vector2[] ps, bool[] smooth, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(room);
				if (ps != null)
				{
					_stream.WriteInt(ps.Length);
					foreach (Vector2 vector in ps)
					{
						_stream.WriteVector(vector);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				if (smooth != null)
				{
					_stream.WriteInt(smooth.Length);
					foreach (bool value in smooth)
					{
						_stream.WriteBool(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.RoomEdges, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				RoomEdges(NetworkManager.Self, room, ps, smooth);
			}
			return true;
		}

		private static void ReceiveRoomEdges(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			uint room = data.ReadUInt();
			Vector2[] array = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				array = new Vector2[num];
				for (int i = 0; i < num; i++)
				{
					SVector3 sVector = data.ReadVector();
					array[i] = sVector;
				}
			}
			bool[] array2 = null;
			int num2 = data.ReadInt();
			if (num2 >= 0)
			{
				array2 = new bool[num2];
				for (int j = 0; j < num2; j++)
				{
					bool flag = data.ReadBool();
					array2[j] = flag;
				}
			}
			RoomEdges(from, room, array, array2);
		}

		public static bool SendVerifyRoomData(uint[] rooms, uint[] roofs, bool check, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				if (rooms != null)
				{
					_stream.WriteInt(rooms.Length);
					foreach (uint value in rooms)
					{
						_stream.WriteUInt(value);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				if (roofs != null)
				{
					_stream.WriteInt(roofs.Length);
					foreach (uint value2 in roofs)
					{
						_stream.WriteUInt(value2);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				_stream.WriteBool(check);
				SendData(MessageType.VerifyRoomData, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				VerifyRoomData(NetworkManager.Self, rooms, roofs, check);
			}
			return true;
		}

		private static void ReceiveVerifyRoomData(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			uint[] array = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				array = new uint[num];
				for (int i = 0; i < num; i++)
				{
					uint num2 = data.ReadUInt();
					array[i] = num2;
				}
			}
			uint[] array2 = null;
			int num3 = data.ReadInt();
			if (num3 >= 0)
			{
				array2 = new uint[num3];
				for (int j = 0; j < num3; j++)
				{
					uint num4 = data.ReadUInt();
					array2[j] = num4;
				}
			}
			bool check = data.ReadBool();
			VerifyRoomData(from, array, array2, check);
		}

		public static void SendNewTrade(NetworkTrade trade, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				if (trade != null)
				{
					_stream.WriteByteObject(trade);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.NewTrade, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				NewTrade(NetworkManager.Self, trade);
			}
		}

		private static void ReceiveNewTrade(NetworkPlayer from, MemoryStream data)
		{
			NetworkTrade trade = NetworkTrade.ReadData(data);
			NewTrade(from, trade);
		}

		public static void SendTradeState(uint id, NetworkTrade.Status st, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteEnum(st, true);
				SendData(MessageType.TradeState, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				TradeState(NetworkManager.Self, id, st);
			}
		}

		private static void ReceiveTradeState(NetworkPlayer from, MemoryStream data)
		{
			uint id = data.ReadUInt();
			NetworkTrade.Status st = data.ReadEnum<NetworkTrade.Status>(true);
			TradeState(from, id, st);
		}

		public static void SendAllIDs(uint tradeID, uint objectID, uint workItemID, uint softwareID, uint frameworkID, uint dealID, uint companyID, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(tradeID);
				_stream.WriteUInt(objectID);
				_stream.WriteUInt(workItemID);
				_stream.WriteUInt(softwareID);
				_stream.WriteUInt(frameworkID);
				_stream.WriteUInt(dealID);
				_stream.WriteUInt(companyID);
				SendData(MessageType.AllIDs, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AllIDs(NetworkManager.Self, tradeID, objectID, workItemID, softwareID, frameworkID, dealID, companyID);
			}
		}

		private static void ReceiveAllIDs(NetworkPlayer from, MemoryStream data)
		{
			uint tradeID = data.ReadUInt();
			uint objectID = data.ReadUInt();
			uint workItemID = data.ReadUInt();
			uint softwareID = data.ReadUInt();
			uint frameworkID = data.ReadUInt();
			uint dealID = data.ReadUInt();
			uint companyID = data.ReadUInt();
			AllIDs(from, tradeID, objectID, workItemID, softwareID, frameworkID, dealID, companyID);
		}

		public static void SendNewNetworkDeal(WorkItem item, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				if (item != null)
				{
					_stream.WriteByteObject(item);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.NewNetworkDeal, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				NewNetworkDeal(NetworkManager.Self, item);
			}
		}

		private static void ReceiveNewNetworkDeal(NetworkPlayer from, MemoryStream data)
		{
			WorkItem item = WorkItem.ReadData(data);
			NewNetworkDeal(from, item);
		}

		public static void SendNetworkDealComplete(uint id, byte[] workData, bool amicably, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteBytes(workData);
				_stream.WriteBool(amicably);
				SendData(MessageType.NetworkDealComplete, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				NetworkDealComplete(NetworkManager.Self, id, workData, amicably);
			}
		}

		private static void ReceiveNetworkDealComplete(NetworkPlayer from, MemoryStream data)
		{
			uint id = data.ReadUInt();
			byte[] workData = data.ReadBytes();
			bool amicably = data.ReadBool();
			NetworkDealComplete(from, id, workData, amicably);
		}

		public static void SendNetworkDealCancel(uint id, bool accepted, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteBool(accepted);
				SendData(MessageType.NetworkDealCancel, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				NetworkDealCancel(NetworkManager.Self, id, accepted);
			}
		}

		private static void ReceiveNetworkDealCancel(NetworkPlayer from, MemoryStream data)
		{
			uint id = data.ReadUInt();
			bool accepted = data.ReadBool();
			NetworkDealCancel(from, id, accepted);
		}

		public static bool SendNetworkDealSync(uint id, byte[] dealData, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteBytes(dealData);
				SendData(MessageType.NetworkDealSync, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				NetworkDealSync(NetworkManager.Self, id, dealData);
			}
			return true;
		}

		private static void ReceiveNetworkDealSync(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				byte[] dealData = data.ReadBytes();
				NetworkDealSync(from, id, dealData);
			}
		}

		public static bool SendVerifyDeal(uint id, bool check, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteBool(check);
				SendData(MessageType.VerifyDeal, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				VerifyDeal(NetworkManager.Self, id, check);
			}
			return true;
		}

		private static void ReceiveVerifyDeal(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				bool check = data.ReadBool();
				VerifyDeal(from, id, check);
			}
		}

		public static void SendUpdateWorkItem(uint id, byte[] progressData, float prog, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				_stream.WriteBytes(progressData);
				_stream.WriteFloat(prog);
				SendData(MessageType.UpdateWorkItem, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateWorkItem(NetworkManager.Self, id, progressData, prog);
			}
		}

		private static void ReceiveUpdateWorkItem(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				byte[] progressData = data.ReadBytes();
				float prog = data.ReadFloat();
				UpdateWorkItem(from, id, progressData, prog);
			}
		}

		public static void SendAddWorkRoyalty(uint company, uint id, uint addon, bool work, float r, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(id);
				_stream.WriteUInt(addon);
				_stream.WriteBool(work);
				_stream.WriteFloat(r);
				SendData(MessageType.AddWorkRoyalty, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddWorkRoyalty(NetworkManager.Self, company, id, addon, work, r);
			}
		}

		private static void ReceiveAddWorkRoyalty(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint id = data.ReadUInt();
				uint addon = data.ReadUInt();
				bool work = data.ReadBool();
				float r = data.ReadFloat();
				AddWorkRoyalty(from, company, id, addon, work, r);
			}
		}

		public static void SendBeginTakeover(uint company, uint taker, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(taker);
				SendData(MessageType.BeginTakeover, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				BeginTakeover(NetworkManager.Self, company, taker);
			}
		}

		private static void ReceiveBeginTakeover(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint taker = data.ReadUInt();
				BeginTakeover(from, company, taker);
			}
		}

		public static bool SendUpdateCompanyLogo(uint c, byte[] logo, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(c);
				_stream.WriteBytes(logo);
				SendData(MessageType.UpdateCompanyLogo, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateCompanyLogo(NetworkManager.Self, c, logo);
			}
			return true;
		}

		private static void ReceiveUpdateCompanyLogo(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint c = data.ReadUInt();
				byte[] logo = data.ReadBytes();
				UpdateCompanyLogo(from, c, logo);
			}
		}

		public static void SendLeadDesignerSync(bool query, uint[] ids, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (query)
				{
					b |= 1;
				}
				if (ids != null)
				{
					b |= 2;
				}
				_stream.WriteByte(b);
				if ((b & 2) > 0)
				{
					if (ids != null)
					{
						_stream.WriteInt(ids.Length);
						foreach (uint value in ids)
						{
							_stream.WriteUInt(value);
						}
					}
					else
					{
						_stream.WriteInt(-1);
					}
				}
				SendData(MessageType.LeadDesignerSync, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				LeadDesignerSync(NetworkManager.Self, query, ids);
			}
		}

		private static void ReceiveLeadDesignerSync(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			int num = data.ReadByte();
			bool query = (num & 1) > 0;
			uint[] array = null;
			if ((num & 2) > 0)
			{
				array = null;
				int num2 = data.ReadInt();
				if (num2 >= 0)
				{
					array = new uint[num2];
					for (int i = 0; i < num2; i++)
					{
						uint num3 = data.ReadUInt();
						array[i] = num3;
					}
				}
			}
			LeadDesignerSync(from, query, array);
		}

		public static bool SendPublishingDeal(PublisherDeal deal, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				if (deal != null)
				{
					_stream.WriteByteObject(deal);
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.PublishingDeal, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				PublishingDeal(NetworkManager.Self, deal);
			}
			return true;
		}

		private static void ReceivePublishingDeal(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				PublisherDeal deal = PublisherDeal.ReadData(data);
				PublishingDeal(from, deal);
			}
		}

		public static bool SendPublishingEcoChange(uint product, bool cut, double amount, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(product);
				_stream.WriteBool(cut);
				_stream.WriteDouble(amount);
				SendData(MessageType.PublishingEcoChange, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				PublishingEcoChange(NetworkManager.Self, product, cut, amount);
			}
			return true;
		}

		private static void ReceivePublishingEcoChange(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint product = data.ReadUInt();
				bool cut = data.ReadBool();
				double amount = data.ReadDouble();
				PublishingEcoChange(from, product, cut, amount);
			}
		}

		public static bool SendUpdateCompanyBuildingSign(uint networkObject, float thickness, float outline, float shadowSize, float shadowX, float shadowY, float shadowOpacity, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(networkObject);
				_stream.WriteFloat(thickness);
				_stream.WriteFloat(outline);
				_stream.WriteFloat(shadowSize);
				_stream.WriteFloat(shadowX);
				_stream.WriteFloat(shadowY);
				_stream.WriteFloat(shadowOpacity);
				SendData(MessageType.UpdateCompanyBuildingSign, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateCompanyBuildingSign(NetworkManager.Self, networkObject, thickness, outline, shadowSize, shadowX, shadowY, shadowOpacity);
			}
			return true;
		}

		private static void ReceiveUpdateCompanyBuildingSign(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint networkObject = data.ReadUInt();
				float thickness = data.ReadFloat();
				float outline = data.ReadFloat();
				float shadowSize = data.ReadFloat();
				float shadowX = data.ReadFloat();
				float shadowY = data.ReadFloat();
				float shadowOpacity = data.ReadFloat();
				UpdateCompanyBuildingSign(from, networkObject, thickness, outline, shadowSize, shadowX, shadowY, shadowOpacity);
			}
		}

		public static void SendStartLeadPoach(uint company, uint employee, float offer, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(employee);
				_stream.WriteFloat(offer);
				SendData(MessageType.StartLeadPoach, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				StartLeadPoach(NetworkManager.Self, company, employee, offer);
			}
		}

		private static void ReceiveStartLeadPoach(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint employee = data.ReadUInt();
				float offer = data.ReadFloat();
				StartLeadPoach(from, company, employee, offer);
			}
		}

		public static void SendUpdateRoundLimit(float newLimit, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteFloat(newLimit);
				SendData(MessageType.UpdateRoundLimit, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateRoundLimit(NetworkManager.Self, newLimit);
			}
		}

		private static void ReceiveUpdateRoundLimit(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				float newLimit = data.ReadFloat();
				UpdateRoundLimit(from, newLimit);
			}
		}

		public static void SendUpdateRoundType(NetworkLobby.RoundLimitType roundType, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				SendData(MessageType.UpdateRoundType, new byte[1] { (byte)roundType }, true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateRoundType(NetworkManager.Self, roundType);
			}
		}

		private static void ReceiveUpdateRoundType(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				NetworkLobby.RoundLimitType roundType = data.ReadEnum<NetworkLobby.RoundLimitType>(true);
				UpdateRoundType(from, roundType);
			}
		}

		public static bool SendGenerateProductReview(uint product, uint addon, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(product);
				_stream.WriteUInt(addon);
				SendData(MessageType.GenerateProductReview, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				GenerateProductReview(NetworkManager.Self, product, addon);
			}
			return true;
		}

		private static void ReceiveGenerateProductReview(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint product = data.ReadUInt();
				uint addon = data.ReadUInt();
				GenerateProductReview(from, product, addon);
			}
		}

		public static void SendHostGameTime(SDateTime time, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, false))
			{
				_stream.SetLength(0L);
				_stream.WriteByteObject(time);
				SendData(MessageType.HostGameTime, _stream.ToArray(), false, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				HostGameTime(NetworkManager.Self, time);
			}
		}

		private static void ReceiveHostGameTime(NetworkPlayer from, MemoryStream data)
		{
			SDateTime time = SDateTime.ReadData(data);
			HostGameTime(from, time);
		}

		public static bool SendUpdateCloudService(byte provider, float markup, float power, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (markup != -1f)
				{
					b |= 1;
				}
				_stream.WriteByte(b);
				_stream.WriteByte(provider);
				if ((b & 1) > 0)
				{
					_stream.WriteFloat(markup);
				}
				_stream.WriteFloat(power);
				SendData(MessageType.UpdateCloudService, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateCloudService(NetworkManager.Self, provider, markup, power);
			}
			return true;
		}

		private static void ReceiveUpdateCloudService(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				int num2 = data.ReadByte();
				float markup = -1f;
				if ((num & 1) > 0)
				{
					markup = data.ReadFloat();
				}
				float power = data.ReadFloat();
				UpdateCloudService(from, (byte)num2, markup, power);
			}
		}

		public static bool SendUpdateCloudUsage(byte client, byte provider, float usage, bool forHost, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteByte(client);
				_stream.WriteByte(provider);
				_stream.WriteFloat(usage);
				_stream.WriteBool(forHost);
				SendData(MessageType.UpdateCloudUsage, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				UpdateCloudUsage(NetworkManager.Self, client, provider, usage, forHost);
			}
			return true;
		}

		private static void ReceiveUpdateCloudUsage(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				int num2 = data.ReadByte();
				float usage = data.ReadFloat();
				bool forHost = data.ReadBool();
				UpdateCloudUsage(from, (byte)num, (byte)num2, usage, forHost);
			}
		}

		public static bool SendNetworkPrintDealChange(uint id, uint copies, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (copies != 0)
				{
					b |= 1;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(id);
				if ((b & 1) > 0)
				{
					_stream.WriteUInt(copies);
				}
				SendData(MessageType.NetworkPrintDealChange, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				NetworkPrintDealChange(NetworkManager.Self, id, copies);
			}
			return true;
		}

		private static void ReceiveNetworkPrintDealChange(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint id = data.ReadUInt();
				uint copies = 0u;
				if ((num & 1) > 0)
				{
					copies = data.ReadUInt();
				}
				NetworkPrintDealChange(from, id, copies);
			}
		}

		public static bool SendCancelNetworkPrintDeal(uint id, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(id);
				SendData(MessageType.CancelNetworkPrintDeal, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				CancelNetworkPrintDeal(NetworkManager.Self, id);
			}
			return true;
		}

		private static void ReceiveCancelNetworkPrintDeal(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint id = data.ReadUInt();
				CancelNetworkPrintDeal(from, id);
			}
		}

		public static bool SendVerifyPrintDeals(HashSet<uint> ids, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				if (ids != null)
				{
					_stream.WriteInt(ids.Count);
					foreach (uint id in ids)
					{
						_stream.WriteUInt(id);
					}
				}
				else
				{
					_stream.WriteInt(-1);
				}
				SendData(MessageType.VerifyPrintDeals, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				VerifyPrintDeals(NetworkManager.Self, ids);
			}
			return true;
		}

		private static void ReceiveVerifyPrintDeals(NetworkPlayer from, MemoryStream data)
		{
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			HashSet<uint> hashSet = null;
			int num = data.ReadInt();
			if (num >= 0)
			{
				hashSet = new HashSet<uint>();
				for (int i = 0; i < num; i++)
				{
					uint item = data.ReadUInt();
					hashSet.Add(item);
				}
			}
			VerifyPrintDeals(from, hashSet);
		}

		public static bool SendChangePrintMarkup(uint company, uint swID, uint subID, bool addon, float markup, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (!NetworkManager.IsConnected)
			{
				return false;
			}
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteUInt(swID);
				_stream.WriteUInt(subID);
				_stream.WriteBool(addon);
				_stream.WriteFloat(markup);
				SendData(MessageType.ChangePrintMarkup, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				ChangePrintMarkup(NetworkManager.Self, company, swID, subID, addon, markup);
			}
			return true;
		}

		private static void ReceiveChangePrintMarkup(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				uint swID = data.ReadUInt();
				uint subID = data.ReadUInt();
				bool addon = data.ReadBool();
				float markup = data.ReadFloat();
				ChangePrintMarkup(from, company, swID, subID, addon, markup);
			}
		}

		public static void SendMarketEventData(MarketEvent ev, byte targetType, uint eventTarget, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteByteObject(ev);
				_stream.WriteByte(targetType);
				_stream.WriteUInt(eventTarget);
				SendData(MessageType.MarketEventData, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				MarketEventData(NetworkManager.Self, ev, targetType, eventTarget);
			}
		}

		private static void ReceiveMarketEventData(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				MarketEvent ev = MarketEvent.ReadData(data);
				int num = data.ReadByte();
				uint eventTarget = data.ReadUInt();
				MarketEventData(from, ev, (byte)num, eventTarget);
			}
		}

		public static void SendSetAIAutonomy(uint company, bool value, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				_stream.WriteUInt(company);
				_stream.WriteBool(value);
				SendData(MessageType.SetAIAutonomy, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				SetAIAutonomy(NetworkManager.Self, company, value);
			}
		}

		private static void ReceiveSetAIAutonomy(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				uint company = data.ReadUInt();
				bool value = data.ReadBool();
				SetAIAutonomy(from, company, value);
			}
		}

		public static void SendAddReviews(uint id, uint addon, int positive, int negative, SDateTime time, MessageTarget target = MessageTarget.Everyone, byte targetID = 0)
		{
			if (ShouldSend(target, targetID, true))
			{
				_stream.SetLength(0L);
				byte b = 0;
				if (addon != 0)
				{
					b |= 1;
				}
				if (positive != 0)
				{
					b |= 2;
				}
				if (negative != 0)
				{
					b |= 4;
				}
				_stream.WriteByte(b);
				_stream.WriteUInt(id);
				if ((b & 1) > 0)
				{
					_stream.WriteUInt(addon);
				}
				if ((b & 2) > 0)
				{
					_stream.WriteInt(positive);
				}
				if ((b & 4) > 0)
				{
					_stream.WriteInt(negative);
				}
				_stream.WriteByteObject(time);
				SendData(MessageType.AddReviews, _stream.ToArray(), true, target, targetID);
			}
			if (ForSelf(target, targetID))
			{
				AddReviews(NetworkManager.Self, id, addon, positive, negative, time);
			}
		}

		private static void ReceiveAddReviews(NetworkPlayer from, MemoryStream data)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				int num = data.ReadByte();
				uint id = data.ReadUInt();
				uint addon = 0u;
				if ((num & 1) > 0)
				{
					addon = data.ReadUInt();
				}
				int positive = 0;
				if ((num & 2) > 0)
				{
					positive = data.ReadInt();
				}
				int negative = 0;
				if ((num & 4) > 0)
				{
					negative = data.ReadInt();
				}
				SDateTime time = SDateTime.ReadData(data);
				AddReviews(from, id, addon, positive, negative, time);
			}
		}

		private static void ActuallyReceiveMessage(NetworkPlayer player, MessageType type, MemoryStream stream)
		{
			switch (type)
			{
			case MessageType.AssignID:
			{
				byte b = (byte)stream.ReadByte();
				NetworkManager.Self.ID = b;
				Debug.Log("Got ID: " + b);
				if (NetworkManager.Instance.JoinStatus == NetworkManager.WaitStatus.WaitingForSaveData)
				{
					SendControlStatement(ControlType.ReadyForPlay, MessageTarget.Host, 0);
				}
				break;
			}
			case MessageType.ModMessage:
			{
				byte key = (byte)stream.ReadByte();
				ModController.DLLMod value;
				if (_modMapping.TryGetValue(key, out value))
				{
					value.ReceiveNetworkMessage(player, stream);
				}
				break;
			}
			case MessageType.NewConnection:
				ReceiveNewConnection(player, stream);
				break;
			case MessageType.NetworkMetaData:
				ReceiveNetworkMetaData(player, stream);
				break;
			case MessageType.SaveData:
				ReceiveSaveData(player, stream);
				break;
			case MessageType.PlayerCompany:
				ReceivePlayerCompany(player, stream);
				break;
			case MessageType.DisconnectPlayer:
				ReceiveDisconnectPlayer(player, stream);
				break;
			case MessageType.ControlStatement:
				ReceiveControlStatement(player, stream);
				break;
			case MessageType.BroadCastPlayer:
				ReceiveBroadCastPlayer(player, stream);
				break;
			case MessageType.PlayerMessage:
				ReceivePlayerMessage(player, stream);
				break;
			case MessageType.PlayerSync:
				ReceivePlayerSync(player, stream);
				break;
			case MessageType.PlayerReady:
				ReceivePlayerReady(player, stream);
				break;
			case MessageType.PlayerTime:
				ReceivePlayerTime(player, stream);
				break;
			case MessageType.PlotOwner:
				ReceivePlotOwner(player, stream);
				break;
			case MessageType.DestroyLandmark:
				ReceiveDestroyLandmark(player, stream);
				break;
			case MessageType.PlaceRoad:
				ReceivePlaceRoad(player, stream);
				break;
			case MessageType.SetGhostCar:
				ReceiveSetGhostCar(player, stream);
				break;
			case MessageType.ClearGhostCar:
				ReceiveClearGhostCar(player, stream);
				break;
			case MessageType.MakeTransaction:
				ReceiveMakeTransaction(player, stream);
				break;
			case MessageType.AddTax:
				ReceiveAddTax(player, stream);
				break;
			case MessageType.NetworkIDCallback:
				ReceiveNetworkIDCallback(player, stream);
				break;
			case MessageType.LeadDesigner:
				ReceiveLeadDesigner(player, stream);
				break;
			case MessageType.RequestNetworkID:
				ReceiveRequestNetworkID(player, stream);
				break;
			case MessageType.MoveLeadDesigner:
				ReceiveMoveLeadDesigner(player, stream);
				break;
			case MessageType.FinishLeadProject:
				ReceiveFinishLeadProject(player, stream);
				break;
			case MessageType.AddSimulatedCompany:
				ReceiveAddSimulatedCompany(player, stream);
				break;
			case MessageType.TradeStock:
				ReceiveTradeStock(player, stream);
				break;
			case MessageType.ExtraWorth:
				ReceiveExtraWorth(player, stream);
				break;
			case MessageType.BuyOut:
				ReceiveBuyOut(player, stream);
				break;
			case MessageType.AddTechLevel:
				ReceiveAddTechLevel(player, stream);
				break;
			case MessageType.TransferPatent:
				ReceiveTransferPatent(player, stream);
				break;
			case MessageType.AddResearch:
				ReceiveAddResearch(player, stream);
				break;
			case MessageType.TransferFramework:
				ReceiveTransferFramework(player, stream);
				break;
			case MessageType.AddFramework:
				ReceiveAddFramework(player, stream);
				break;
			case MessageType.AddProduct:
				ReceiveAddProduct(player, stream);
				break;
			case MessageType.AddAddOn:
				ReceiveAddAddOn(player, stream);
				break;
			case MessageType.UpdateSubMarkets:
				ReceiveUpdateSubMarkets(player, stream);
				break;
			case MessageType.TradeIP:
				ReceiveTradeIP(player, stream);
				break;
			case MessageType.ProductCashflow:
				ReceiveProductCashflow(player, stream);
				break;
			case MessageType.ProductUserbase:
				ReceiveProductUserbase(player, stream);
				break;
			case MessageType.AddFans:
				ReceiveAddFans(player, stream);
				break;
			case MessageType.ArchiveProduct:
				ReceiveArchiveProduct(player, stream);
				break;
			case MessageType.ChangeFollowers:
				ReceiveChangeFollowers(player, stream);
				break;
			case MessageType.UpdateMarketing:
				ReceiveUpdateMarketing(player, stream);
				break;
			case MessageType.ProductPrototype:
				ReceiveProductPrototype(player, stream);
				break;
			case MessageType.StartDev:
				ReceiveStartDev(player, stream);
				break;
			case MessageType.ReleaseDev:
				ReceiveReleaseDev(player, stream);
				break;
			case MessageType.AddonPrototype:
				ReceiveAddonPrototype(player, stream);
				break;
			case MessageType.EndAddonDev:
				ReceiveEndAddonDev(player, stream);
				break;
			case MessageType.UpdateStockMarket:
				ReceiveUpdateStockMarket(player, stream);
				break;
			case MessageType.AddStockMarket:
				ReceiveAddStockMarket(player, stream);
				break;
			case MessageType.UpdateProduct:
				ReceiveUpdateProduct(player, stream);
				break;
			case MessageType.UpdateFramework:
				ReceiveUpdateFramework(player, stream);
				break;
			case MessageType.ChangeBugs:
				ReceiveChangeBugs(player, stream);
				break;
			case MessageType.ChangePhysicalCopies:
				ReceiveChangePhysicalCopies(player, stream);
				break;
			case MessageType.RunProductScripts:
				ReceiveRunProductScripts(player, stream);
				break;
			case MessageType.RunCopyScripts:
				ReceiveRunCopyScripts(player, stream);
				break;
			case MessageType.CreateDigitalPlatform:
				ReceiveCreateDigitalPlatform(player, stream);
				break;
			case MessageType.SignDigitalPlatform:
				ReceiveSignDigitalPlatform(player, stream);
				break;
			case MessageType.RegisterLocalPlayerPlatformQuery:
				ReceiveRegisterLocalPlayerPlatformQuery(player, stream);
				break;
			case MessageType.DistributionCut:
				ReceiveDistributionCut(player, stream);
				break;
			case MessageType.DistributionState:
				ReceiveDistributionState(player, stream);
				break;
			case MessageType.DistributionStats:
				ReceiveDistributionStats(player, stream);
				break;
			case MessageType.ChangePlatformAccept:
				ReceiveChangePlatformAccept(player, stream);
				break;
			case MessageType.DistributionLoad:
				ReceiveDistributionLoad(player, stream);
				break;
			case MessageType.DistributionSales:
				ReceiveDistributionSales(player, stream);
				break;
			case MessageType.ExclusiveStore:
				ReceiveExclusiveStore(player, stream);
				break;
			case MessageType.DistributionBandwidth:
				ReceiveDistributionBandwidth(player, stream);
				break;
			case MessageType.SoftwareID:
				ReceiveSoftwareID(player, stream);
				break;
			case MessageType.ChangePrice:
				ReceiveChangePrice(player, stream);
				break;
			case MessageType.MakeSubsidiary:
				ReceiveMakeSubsidiary(player, stream);
				break;
			case MessageType.ScheduleRelease:
				ReceiveScheduleRelease(player, stream);
				break;
			case MessageType.AddDeal:
				ReceiveAddDeal(player, stream);
				break;
			case MessageType.CancelDeal:
				ReceiveCancelDeal(player, stream);
				break;
			case MessageType.UpdateProtoQuality:
				ReceiveUpdateProtoQuality(player, stream);
				break;
			case MessageType.Port:
				ReceivePort(player, stream);
				break;
			case MessageType.RequestSync:
				ReceiveRequestSync(player, stream);
				break;
			case MessageType.RequestSyncVerify:
				ReceiveRequestSyncVerify(player, stream);
				break;
			case MessageType.AddLoss:
				ReceiveAddLoss(player, stream);
				break;
			case MessageType.AddonSimulation:
				ReceiveAddonSimulation(player, stream);
				break;
			case MessageType.AddProductLoadIncident:
				ReceiveAddProductLoadIncident(player, stream);
				break;
			case MessageType.AddProductRep:
				ReceiveAddProductRep(player, stream);
				break;
			case MessageType.FrameworkPayment:
				ReceiveFrameworkPayment(player, stream);
				break;
			case MessageType.AIResearch:
				ReceiveAIResearch(player, stream);
				break;
			case MessageType.DividendStats:
				ReceiveDividendStats(player, stream);
				break;
			case MessageType.BroadcastUUID:
				ReceiveBroadcastUUID(player, stream);
				break;
			case MessageType.InitialGameSettings:
				ReceiveInitialGameSettings(player, stream);
				break;
			case MessageType.RainSync:
				ReceiveRainSync(player, stream);
				break;
			case MessageType.AwardWinners:
				ReceiveAwardWinners(player, stream);
				break;
			case MessageType.EmployerScore:
				ReceiveEmployerScore(player, stream);
				break;
			case MessageType.BusinessRep:
				ReceiveBusinessRep(player, stream);
				break;
			case MessageType.TakeOverData:
				ReceiveTakeOverData(player, stream);
				break;
			case MessageType.NewspaperTakeover:
				ReceiveNewspaperTakeover(player, stream);
				break;
			case MessageType.TryReconnection:
				ReceiveTryReconnection(player, stream);
				break;
			case MessageType.Notification:
				ReceiveNotification(player, stream);
				break;
			case MessageType.Diagnostics:
				ReceiveDiagnostics(player, stream);
				break;
			case MessageType.SyncMoney:
				ReceiveSyncMoney(player, stream);
				break;
			case MessageType.NewRoom:
				ReceiveNewRoom(player, stream);
				break;
			case MessageType.NewRoomSegment:
				ReceiveNewRoomSegment(player, stream);
				break;
			case MessageType.NewFurniture:
				ReceiveNewFurniture(player, stream);
				break;
			case MessageType.MoveFurniture:
				ReceiveMoveFurniture(player, stream);
				break;
			case MessageType.DestroyNetworkObject:
				ReceiveDestroyNetworkObject(player, stream);
				break;
			case MessageType.UpdateRoomAtrium:
				ReceiveUpdateRoomAtrium(player, stream);
				break;
			case MessageType.ObjectStyle:
				ReceiveObjectStyle(player, stream);
				break;
			case MessageType.RoomEdges:
				ReceiveRoomEdges(player, stream);
				break;
			case MessageType.VerifyRoomData:
				ReceiveVerifyRoomData(player, stream);
				break;
			case MessageType.NewTrade:
				ReceiveNewTrade(player, stream);
				break;
			case MessageType.TradeState:
				ReceiveTradeState(player, stream);
				break;
			case MessageType.AllIDs:
				ReceiveAllIDs(player, stream);
				break;
			case MessageType.NewNetworkDeal:
				ReceiveNewNetworkDeal(player, stream);
				break;
			case MessageType.NetworkDealComplete:
				ReceiveNetworkDealComplete(player, stream);
				break;
			case MessageType.NetworkDealCancel:
				ReceiveNetworkDealCancel(player, stream);
				break;
			case MessageType.NetworkDealSync:
				ReceiveNetworkDealSync(player, stream);
				break;
			case MessageType.VerifyDeal:
				ReceiveVerifyDeal(player, stream);
				break;
			case MessageType.UpdateWorkItem:
				ReceiveUpdateWorkItem(player, stream);
				break;
			case MessageType.AddWorkRoyalty:
				ReceiveAddWorkRoyalty(player, stream);
				break;
			case MessageType.BeginTakeover:
				ReceiveBeginTakeover(player, stream);
				break;
			case MessageType.UpdateCompanyLogo:
				ReceiveUpdateCompanyLogo(player, stream);
				break;
			case MessageType.LeadDesignerSync:
				ReceiveLeadDesignerSync(player, stream);
				break;
			case MessageType.PublishingDeal:
				ReceivePublishingDeal(player, stream);
				break;
			case MessageType.PublishingEcoChange:
				ReceivePublishingEcoChange(player, stream);
				break;
			case MessageType.UpdateCompanyBuildingSign:
				ReceiveUpdateCompanyBuildingSign(player, stream);
				break;
			case MessageType.StartLeadPoach:
				ReceiveStartLeadPoach(player, stream);
				break;
			case MessageType.UpdateRoundLimit:
				ReceiveUpdateRoundLimit(player, stream);
				break;
			case MessageType.UpdateRoundType:
				ReceiveUpdateRoundType(player, stream);
				break;
			case MessageType.GenerateProductReview:
				ReceiveGenerateProductReview(player, stream);
				break;
			case MessageType.HostGameTime:
				ReceiveHostGameTime(player, stream);
				break;
			case MessageType.UpdateCloudService:
				ReceiveUpdateCloudService(player, stream);
				break;
			case MessageType.UpdateCloudUsage:
				ReceiveUpdateCloudUsage(player, stream);
				break;
			case MessageType.NetworkPrintDealChange:
				ReceiveNetworkPrintDealChange(player, stream);
				break;
			case MessageType.CancelNetworkPrintDeal:
				ReceiveCancelNetworkPrintDeal(player, stream);
				break;
			case MessageType.VerifyPrintDeals:
				ReceiveVerifyPrintDeals(player, stream);
				break;
			case MessageType.ChangePrintMarkup:
				ReceiveChangePrintMarkup(player, stream);
				break;
			case MessageType.MarketEventData:
				ReceiveMarketEventData(player, stream);
				break;
			case MessageType.SetAIAutonomy:
				ReceiveSetAIAutonomy(player, stream);
				break;
			case MessageType.AddReviews:
				ReceiveAddReviews(player, stream);
				break;
			}
		}

		private static bool TryGet<T>(T obj, string action, uint id, out T res) where T : class
		{
			res = obj;
			if (res == null)
			{
				Debug.Log("Tried to get non-existent " + typeof(T).Name + ": " + id + " for " + action);
				return false;
			}
			return true;
		}

		private static bool HasBeenInvited(string connectionInfo)
		{
			ulong result;
			if (NetworkLayer.Active is SteamLayer && ulong.TryParse(connectionInfo, out result))
			{
				return GameSettings.Instance.SteamInvitedToGame.Contains(result);
			}
			return false;
		}

		[RPCCall]
		private static void NewConnection(NetworkPlayer player, string name, string uniqueID, string connectionData, string password)
		{
			NetworkManager.Instance.ResetIDMap();
			player.Name = name;
			player.UniqueID = uniqueID;
			player.ReconnectionData = connectionData;
			if (!HasBeenInvited(connectionData) && !GameSettings.Instance.NetworkData.VerifyPassword(password))
			{
				player.Connected = false;
				ActuallySendData(player, 1, MessageType.DisconnectPlayer, new byte[1] { 1 }, MessageTarget.Everyone, 0);
				SendAllNow();
				Disconnect(player, true, true);
				Debug.Log(player.Name + " could not be verified");
				return;
			}
			ChatWindow.ForceInit(player);
			Debug.Log("Received connection from: " + player.Name);
			if (!NetworkManager.Instance.Host)
			{
				return;
			}
			if (!GameSettings.Instance.IsReferenceNull())
			{
				bool flag = true;
				byte value;
				if (GameSettings.Instance.NetworkData.PlayerIDs.TryGetValue(uniqueID, out value))
				{
					player.ID = value;
					flag = NetworkManager.Instance.CanJoin(player, value);
					Debug.Log(player.Name + " was already in meta and was reassigned: " + value);
				}
				else if (NetworkManager.OutOfIDs())
				{
					flag = false;
					Debug.Log(player.Name + " couldn't join because we're all out of IDs");
				}
				else if (NetworkManager.Instance.CanJoin(player))
				{
					player.ID = NetworkManager.GetAvailableID();
					Debug.Log(player.Name + " was new to the game and was assigned: " + player.ID);
				}
				else
				{
					flag = false;
				}
				if (!flag)
				{
					player.Connected = false;
					ActuallySendData(player, 1, MessageType.DisconnectPlayer, new byte[1] { 1 }, MessageTarget.Everyone, 0);
					SendAllNow();
					Disconnect(player, true, false);
					return;
				}
				player.HandshakeComplete = true;
				NetworkMeta networkData = GameSettings.Instance.NetworkData;
				networkData.PlayerIDs[uniqueID] = player.ID;
				ActuallySendData(player, 1, MessageType.AssignID, new byte[1] { player.ID }, MessageTarget.Everyone, 0);
				SendInitialGameSettings(InitialNetworkSettings.GetCurrentSettings(), MessageTarget.Specifically, player.ID);
				networkData.IncludePassword = true;
				SendNetworkMetaData(networkData, MessageTarget.Specifically, player.ID);
				networkData.IncludePassword = false;
			}
			else
			{
				player.ID = NetworkManager.GetAvailableID();
				player.HandshakeComplete = true;
				ActuallySendData(player, 1, MessageType.AssignID, new byte[1] { player.ID }, MessageTarget.Everyone, 0);
				SendNetworkMetaData(null, MessageTarget.Specifically, player.ID);
				Debug.LogError("Player joined before we're in-game, shouldn't happen!");
			}
			NetworkPlayer self = NetworkManager.Self;
			SendBroadCastPlayer(self.Name.StripRichTags(), self.ActualUniqueID, self.ReconnectionData, self.Ready, self.ID, false, true, true, MessageTarget.Specifically, player.ID);
			for (int i = 0; i < NetworkManager.Instance.Players.Count; i++)
			{
				NetworkPlayer networkPlayer = NetworkManager.Instance.Players[i];
				if (!networkPlayer.Self && networkPlayer != player && networkPlayer.HandshakeComplete)
				{
					SendBroadCastPlayer(networkPlayer.Name, networkPlayer.UniqueID, networkPlayer.ReconnectionData, networkPlayer.Ready, networkPlayer.ID, networkPlayer.SendingSave, false, networkPlayer.InGame, MessageTarget.Specifically, player.ID);
				}
			}
			SendBroadCastPlayer(player.Name, player.UniqueID, player.ReconnectionData, player.Ready, player.ID, player.SendingSave, false, player.InGame, MessageTarget.EveryoneExcept, player.ID);
		}

		[RPCCall]
		private static void NetworkMetaData(NetworkPlayer player, NetworkMeta networkData)
		{
			if (networkData == null)
			{
				if (NetworkManager.IsHost)
				{
					using (MemoryStream memoryStream = new MemoryStream())
					{
						GameSettings.Instance.NetworkData.WriteData(memoryStream);
						ActuallySendData(player, 1, MessageType.NetworkMetaData, memoryStream.ToArray(), MessageTarget.Everyone, 0);
						memoryStream.SetLength(0L);
						InitialNetworkSettings.GetCurrentSettings().WriteData(memoryStream);
						ActuallySendData(player, 1, MessageType.InitialGameSettings, memoryStream.ToArray(), MessageTarget.Everyone, 0);
						memoryStream.SetLength(0L);
						SDateTime.Now().WriteData(memoryStream);
						ActuallySendData(player, 1, MessageType.HostGameTime, memoryStream.ToArray(), MessageTarget.Everyone, 0);
						return;
					}
				}
				if (MainMenuController.Instance != null)
				{
					if (NetworkManager.Instance.JoinStatus != NetworkManager.WaitStatus.None)
					{
						Debug.Log("Host told player to skip initialization, this should not happen");
						NetworkManager.Instance.JoinStatus = NetworkManager.WaitStatus.Skipped;
					}
					else
					{
						Debug.Log("Got JoinStatus = skip message, but was not waiting for it");
					}
				}
			}
			else
			{
				Debug.Log("Received meta data from host");
				GameData.NetworkData = networkData;
				GameData.NetworkData.LocalUniqueID = NetworkManager.Self.ActualUniqueID;
			}
		}

		[RPCCall]
		private static void SaveData(NetworkPlayer player, byte[] save)
		{
			GameData.NetworkSaveData = GameReader.Decompress(save);
			GameData.LoadBuildingOnLoad = true;
			Debug.Log("Received save file");
		}

		[RPCCall]
		private static void PlayerCompany(NetworkPlayer player, byte playerID, uint id, string name, double money, byte[] logo)
		{
			if (NetworkManager.IsHost)
			{
				if (GameSettings.Instance.IsReferenceNull())
				{
					return;
				}
				Company playerCompany = MarketSimulation.Active.GetPlayerCompany(playerID);
				if (playerCompany != null)
				{
					List<Company> list = playerCompany.GenerateStockCompanyList();
					playerCompany.BuyOut((list == null || list.Count == 0) ? null : list, false, SDateTime.Now(), false);
					GameSettings.Instance.ClearBuyouts();
				}
				Company company = new Company(NetworkManager.Instance.Layer.FilterName(name, player), money, SDateTime.Now(), MarketSimulation.Active)
				{
					NetworkPlayerID = playerID,
					Logo = logo,
					Player = true,
					LocalPlayer = false
				};
				MarketSimulation.Active.AddCompany(company);
				GameSettings.Instance.NetworkData.RegisterCompany(playerID, company.ID);
				foreach (NetworkPlayer player2 in NetworkManager.Instance.Players)
				{
					if (!player2.Self && player2 != player)
					{
						SendPlayerCompany(playerID, company.ID, name, money, logo, MessageTarget.Specifically, player2.ID);
					}
				}
				{
					foreach (DistributionPlatform distributionPlatform in MarketSimulation.Active.DistributionPlatforms)
					{
						company.MarkInterested(distributionPlatform.Owner, true, 0);
					}
					return;
				}
			}
			if (GameSettings.Instance.IsReferenceNull() || !SelectorController.Instance.DoneLoading)
			{
				NetworkPlayer res;
				if (TryGet(NetworkManager.GetPlayer(playerID), "create player company", playerID, out res))
				{
					res.DeferredCompany.CompanyID = id;
					res.DeferredCompany.CompanyName = NetworkManager.Instance.Layer.FilterName(name, player);
					res.DeferredCompany.CompanyMoney = money;
					res.DeferredCompany.CompanyLogo = logo;
				}
			}
			else
			{
				Company company2 = new Company(NetworkManager.Instance.Layer.FilterName(name, player), money, SDateTime.Now(), id)
				{
					NetworkPlayerID = playerID,
					Logo = logo,
					Player = true,
					LocalPlayer = false
				};
				MarketSimulation.Active.AddCompany(company2);
				GameSettings.Instance.NetworkData.RegisterCompany(playerID, id);
			}
		}

		[RPCCall]
		private static void DisconnectPlayer(NetworkPlayer player, bool kicked)
		{
			Disconnect(player, true, kicked);
		}

		[RPCCall]
		private static void ControlStatement(NetworkPlayer player, ControlType statement)
		{
			switch (statement)
			{
			case ControlType.ReadyForPlay:
				player.WaitingToJoin = true;
				break;
			case ControlType.SkipToNextDay:
				NetworkManager.Instance.Players.ForEach(delegate(NetworkPlayer x)
				{
					x.VoteToSkip = false;
				});
				if (!GameSettings.Instance.IsReferenceNull())
				{
					TimeOfDay.Instance.SkipToNextDayNetwork();
				}
				break;
			case ControlType.VoteToSkip:
				player.VoteToSkip = true;
				break;
			case ControlType.FixCashflow:
				if (!GameSettings.Instance.IsReferenceNull())
				{
					Company playerCompany = player.GetPlayerCompany();
					if (playerCompany != null)
					{
						playerCompany.EndDay(SDateTime.Now(), true);
					}
				}
				break;
			case ControlType.UUIDDirty:
				if (NetworkManager.IsHost)
				{
					NetworkMeta.CheckDirty();
				}
				break;
			default:
				Debug.LogError("Got control statement with no handling: statement");
				break;
			case ControlType.KeepAlive:
				break;
			}
		}

		[RPCCall]
		private static void BroadCastPlayer(NetworkPlayer player, string name, string uniqueID, string connectionData, NetworkPlayer.ReadyStatus ready, byte id, [OptimizeParameter("true")] bool syncing, [OptimizeParameter("true")] bool host, [OptimizeParameter("true")] bool inGame)
		{
			if (NetworkManager.Instance.Players.Count == 1 && TimeOfDay.Instance != null)
			{
				TimeOfDay.Instance.RealTimeDayStart = Time.realtimeSinceStartup;
			}
			if (host)
			{
				NetworkPlayer hostPlayer = NetworkManager.Instance.HostPlayer;
				hostPlayer.Name = name;
				hostPlayer.UniqueID = uniqueID;
				hostPlayer.ID = id;
				hostPlayer.InGame = true;
				hostPlayer.ReconnectionData = connectionData;
				hostPlayer.HandshakeComplete = true;
				hostPlayer.Ready = ready;
				NetworkLayer.Active.UpdateNewPlayer(hostPlayer);
				ChatWindow.ForceInit(hostPlayer);
				Debug.Log("Received new host data: " + name + ": " + id);
			}
			else
			{
				NetworkPlayer networkPlayer = NetworkManager.GetPlayer(id);
				if (networkPlayer == null)
				{
					networkPlayer = new NetworkPlayer(name, uniqueID, id, connectionData);
					NetworkLayer.Active.UpdateNewPlayer(networkPlayer);
					NetworkManager.Instance.Players.Add(networkPlayer);
					NetworkManager.Instance.ResetIDMap();
					if (!GameSettings.Instance.IsReferenceNull())
					{
						NetworkMeta networkMeta = GameSettings.Instance.NetworkData ?? GameData.NetworkData;
						if (networkMeta != null)
						{
							networkMeta.NextID = (byte)Mathf.Max(networkMeta.NextID, id);
						}
					}
					ChatWindow.ForceInit(networkPlayer);
					Debug.Log("Received new client data: " + name + ": " + id);
				}
				networkPlayer.InGame = inGame;
				networkPlayer.HandshakeComplete = true;
				networkPlayer.SendingSave = syncing;
				networkPlayer.Ready = ready;
			}
			if (!GameSettings.Instance.IsReferenceNull())
			{
				NetworkMeta networkMeta2 = GameSettings.Instance.NetworkData ?? GameData.NetworkData;
				if (networkMeta2 != null)
				{
					networkMeta2.PlayerIDs[uniqueID] = id;
					networkMeta2.OldPlayers.Remove(id);
					networkMeta2.ReRegisterAllPlayers();
				}
			}
		}

		[RPCCall]
		private static void PlayerMessage(NetworkPlayer player, string msg, bool isPublic, uint trade)
		{
			ChatWindow.ReceiveMessage(player, player.Self, isPublic, NetworkManager.Instance.Layer.FilterMessage(msg, player), (trade != 0) ? NetworkManager.Instance.TradeController.Trades.GetOrNull(trade) : null);
		}

		[RPCCall]
		private static void PlayerSync(NetworkPlayer player, byte id, bool isSyncing)
		{
			NetworkPlayer res;
			if (!TryGet(NetworkManager.GetPlayer(id), "player sync", id, out res))
			{
				return;
			}
			res.SendingSave = isSyncing;
			res.InGame = true;
			NetworkManager.Instance.UpdateSyncScreen();
			if (!GameSettings.Instance.IsReferenceNull())
			{
				GameSettings.Instance.MyCompany.WorkItems.ForEachEnum(delegate(WorkItem x)
				{
					if (x.NetworkDeal != null && x.NetworkDeal.ReceiverID == player.ID)
					{
						SendVerifyDeal(x.NetworkDeal.ID, true, MessageTarget.Specifically, player.ID);
					}
				});
			}
			if (NetworkManager.IsHost && !isSyncing)
			{
				for (int num = 0; num < 5; num++)
				{
					SendSoftwareID(MarketSimulation.Active.GetID(), false, MessageTarget.Specifically, res.ID);
					SendSoftwareID(MarketSimulation.Active.GetFrameworkID(), true, MessageTarget.Specifically, res.ID);
				}
				TimeOfDay.Instance.SyncRain(MessageTarget.Specifically, player.ID);
			}
		}

		public static void CheckIfDaySkip()
		{
			if (NetworkManager.Instance.Host)
			{
				if (NetworkManager.Instance.Players.All((NetworkPlayer x) => (!x.Self && !x.InGame) || x.Ready == NetworkPlayer.ReadyStatus.ReadyForSync))
				{
					ControlStatement(NetworkManager.Self, ControlType.SkipToNextDay);
				}
				else if (NetworkManager.Instance.Players.All((NetworkPlayer x) => (!x.Self && !x.InGame) || x.Ready == NetworkPlayer.ReadyStatus.Ready || (!x.Self && x.Ready == NetworkPlayer.ReadyStatus.ReadyForSync)))
				{
					SendPlayerReady(NetworkPlayer.ReadyStatus.ReadyForSync, MessageTarget.Everyone, 0);
				}
			}
		}

		private static void ClientPresimSync()
		{
			DistributionPlatform distribution = GameSettings.Instance.MyCompany.Distribution;
			if (distribution != null)
			{
				SendDistributionCut(distribution.Software.ID, distribution.GetCut(), MessageTarget.EveryoneButMe, 0);
				distribution.UpdateBandwidth(SDateTime.Now());
				SendDistributionBandwidth(distribution.Software.ID, distribution.AvailableBandwidth, MessageTarget.Host, 0);
			}
			if (TimeOfDay.Instance.Month == 4 && TimeOfDay.Instance.Day == GameSettings.DaysPerMonth - 1)
			{
				float score = (GameSettings.Instance.EmployerAwardDis ? 0f : GameSettings.Instance.ApplicantScore.GetAwardScore());
				GameSettings.Instance.EmployerAwardDis = false;
				SendEmployerScore(score, MessageTarget.Host, 0);
			}
			TimeOfDay.Instance.UpdateMarketingPlans();
			foreach (IMarketable item in NetworkManager.Instance.DirtyMarketing)
			{
				SoftwareProduct softwareProduct;
				if ((softwareProduct = item as SoftwareProduct) != null)
				{
					SendUpdateMarketing(softwareProduct.ID, 0u, softwareProduct.Marketing, false, false, MessageTarget.Host, 0);
					continue;
				}
				AddOnProduct addOnProduct = (AddOnProduct)item;
				SendUpdateMarketing(addOnProduct.Parent.ID, addOnProduct.ID, addOnProduct.Marketing, false, false, MessageTarget.Host, 0);
			}
			foreach (SoftwareProduct allProduct in MarketSimulation.Active.GetAllProducts(false))
			{
				allProduct.LastMonthPhysical = 0;
			}
			NetworkManager.Instance.DirtyMarketing.Clear();
			NotificationManager.Instance.RollDay();
		}

		[RPCCall]
		private static void PlayerReady(NetworkPlayer player, NetworkPlayer.ReadyStatus status)
		{
			player.Ready = status;
			player.ReadyTiming = DateTime.Now;
			if (NetworkManager.Instance.Host)
			{
				CheckIfDaySkip();
			}
			if (player.Host && status == NetworkPlayer.ReadyStatus.ReadyForSync && !GameSettings.Instance.IsReferenceNull())
			{
				GameSettings.Instance.TransmitExtraWorth();
				SendBusinessRep(GameSettings.Instance.MyCompany.BusinessReputation, MessageTarget.EveryoneButMe, 0);
				if (NetworkManager.IsClient)
				{
					foreach (KeyValuePair<KeyValuePair<ILossable, SoftwareProduct.LossType>, float> item in NetworkManager.Instance.DirtyLoss)
					{
						AddOnProduct addOnProduct;
						SoftwareProduct softwareProduct;
						if ((addOnProduct = item.Key.Key as AddOnProduct) != null)
						{
							SendAddLoss(addOnProduct.Parent.ID, item.Value, item.Key.Value, addOnProduct.ID, 0u, MessageTarget.EveryoneButMe, 0);
						}
						else if ((softwareProduct = item.Key.Key as SoftwareProduct) != null)
						{
							SendAddLoss(softwareProduct.ID, item.Value, item.Key.Value, 0u, 0u, MessageTarget.EveryoneButMe, 0);
						}
					}
					NetworkManager.Instance.DirtyLoss.Clear();
					ClientPresimSync();
					PlayerReady(NetworkManager.Self, NetworkPlayer.ReadyStatus.ReadyForSync);
					SendPlayerReady(NetworkPlayer.ReadyStatus.ReadyForSync, MessageTarget.Host, 0);
				}
			}
			if (NetworkManager.IsHostingPlayers && NetworkManager.Instance.Players.All((NetworkPlayer x) => x.Self || x.Ready == NetworkPlayer.ReadyStatus.OkayToSave))
			{
				NetworkManager.Instance.Players.Where((NetworkPlayer x) => !x.Self).ForEachEnum(delegate(NetworkPlayer x)
				{
					x.Ready = NetworkPlayer.ReadyStatus.NotReady;
				});
				SaveGameManager.Instance.AutoSave();
			}
		}

		[RPCCall(ContinueIfNotOnline = false)]
		private static void PlayerTime(NetworkPlayer player, int hour, float minute, float speed, [OptimizeParameter("false")] bool buildMode, [OptimizeParameter("false")] bool afk)
		{
			player.CurrentHour = hour;
			player.CurrentMinute = minute;
			player.CurrentGameSpeed = speed;
			player.InBuildMode = buildMode;
			player.AFK = afk;
		}

		[RPCCall(ContinueIfNotOnline = false)]
		private static void PlotOwner(NetworkPlayer player, uint plotID, byte owner, bool starting)
		{
			if (starting && NetworkManager.LocalPlayerID == owner)
			{
				NetworkManager.Self.StartPlot = plotID;
			}
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			PlotArea plot = GameSettings.Instance.GetPlot(plotID);
			if (plot != null)
			{
				if (plot.Owner == NetworkManager.LocalPlayerID)
				{
					GameSettings.Instance.SellPlot(plot, PlotController.FindDestroyedRooms(plot), false);
					GameSettings.Instance.ResetUndo();
				}
				plot.AddonCost = 0f;
				plot.SetOwner(owner);
				if (owner == NetworkManager.LocalPlayerID)
				{
					GameSettings.Instance.BuyPlot(plot, false);
				}
				RoadManager.Instance.UpdateParkingAvailability(false);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void DestroyLandmark(NetworkPlayer player, uint localID)
		{
			Landmark res;
			if (RoadManager.Instance != null && localID != 0 && TryGet(RoadManager.Instance.Landmarks.FirstOrDefault((Landmark x) => x.LocalID == localID), "destroy landmark", localID, out res))
			{
				res.DestroyGO();
			}
		}

		[RPCCall(OnlyInGame = true)]
		private static void PlaceRoad(NetworkPlayer player, int x, int y, int floor, byte type)
		{
			RoadManager.Instance.PlaceRoad(x, y, floor, type);
			if (floor == 0)
			{
				GameSettings.Instance.sRoomManager.Outside.DirtyNavMesh = true;
				GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
				GrassSystem.Instance.InvalidateArea();
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void SetGhostCar(NetworkPlayer player, int x, int y, int floor, int parking, int type, Vector3 p, float rot, Color color, uint logoCompany)
		{
			if (RoadManager.Instance != null)
			{
				RoadManager.Instance.SpawnGhostCar(x, y, floor, parking, type, p, rot, color, logoCompany, player.ID);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ClearGhostCar(NetworkPlayer player, int x, int y, int floor, int parking)
		{
			if (RoadManager.Instance != null)
			{
				RoadManager.Instance.ClearGhostCar(x, y, floor, parking);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void MakeTransaction(NetworkPlayer player, uint company, double amount, [OptimizeParameter("Company.TransactionCategory.Distribution")] Company.TransactionCategory category, [OptimizeParameter("TaxReport.TaxType.Operation")] TaxReport.TaxType taxes, [OptimizeParameter("(string)null")] string bill, [OptimizeParameter("false")] bool valuated, SDateTime time)
		{
			Company res;
			if (TryGet(MarketSimulation.Active.GetCompany(company), string.Concat(category, " money transaction "), company, out res))
			{
				res.ActuallyMakeTransaction(amount, category, taxes, time, bill, valuated);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddTax(NetworkPlayer player, uint company, TaxReport.TaxType type, double amount)
		{
			Company res;
			if (TryGet(MarketSimulation.Active.GetCompany(company), string.Concat(type, " tax addition"), company, out res))
			{
				res.ActuallyAddTax(type, amount);
			}
		}

		[RPCCall]
		private static void NetworkIDCallback(NetworkPlayer player, uint id, uint newID)
		{
			NetworkManager.Instance.RunIDCallback(id, newID);
		}

		[RPCCall(OnlyInGame = true)]
		private static void LeadDesigner(NetworkPlayer player, [OptimizeParameter("0u")] uint callback, Employee emp, [OptimizeParameter("0u")] uint company, [OptimizeParameter("false")] bool freeLead)
		{
			if (callback != 0)
			{
				NetworkManager.Instance.SetAndRegisterNetworkObject(emp);
				SendNetworkIDCallback(callback, emp.NetworkID, MessageTarget.Specifically, player.ID);
				SendLeadDesigner(0u, emp, company, freeLead, MessageTarget.EveryoneExcept, player.ID);
			}
			else
			{
				NetworkManager.Instance.RegisterNetworkObject(emp);
				MoveLeadDesigner(player, emp.NetworkID, company, freeLead);
			}
		}

		[RPCCall]
		private static void RequestNetworkID(NetworkPlayer player, uint callback, NetworkManager.NetworkIDType type)
		{
			SendNetworkIDCallback(callback, NetworkManager.Instance.GetNetworkID(type), MessageTarget.Specifically, player.ID);
		}

		[RPCCall(OnlyInGame = true)]
		private static void MoveLeadDesigner(NetworkPlayer player, uint designer, [OptimizeParameter("0u")] uint company, [OptimizeParameter("false")] bool freeLead)
		{
			Employee res;
			if (!TryGet(NetworkManager.Instance.GetNetworkObject(designer) as Employee, "move lead designer", designer, out res))
			{
				return;
			}
			if (HUD.Instance != null && HUD.Instance.hireWindow.HireWin.Window.Shown)
			{
				HUD.Instance.hireWindow.HireWin.EmployeeList.Items.Remove(res);
			}
			Company myEmployer = res.MyEmployer;
			if (company != 0)
			{
				MarketSimulation.Active.FreeLeads.Remove(res);
				Company res2;
				if (!TryGet(MarketSimulation.Active.GetCompany(company), "move lead designer " + res.FullName, company, out res2))
				{
					return;
				}
				if (myEmployer != null && myEmployer != res2)
				{
					SimulatedCompany simulatedCompany;
					if ((simulatedCompany = myEmployer as SimulatedCompany) != null && simulatedCompany.LeadDesigner.NetworkID == res.NetworkID)
					{
						simulatedCompany.LeadDesigner = null;
					}
					else if (myEmployer.Player)
					{
						myEmployer.NetworkEmployees.Remove(res);
					}
					res.Dismiss(false);
					res.CleanUp();
					res.MyEmployer = null;
				}
				res.UpfrontDemand = 0f;
				res.Employ(res2, SDateTime.Now(), false);
				SimulatedCompany simulatedCompany2;
				if ((simulatedCompany2 = res2 as SimulatedCompany) != null)
				{
					simulatedCompany2.LeadDesigner = res;
				}
				else if (res2.Player && !res2.LocalPlayer)
				{
					res2.NetworkEmployees.Add(res);
				}
				return;
			}
			if (myEmployer != null)
			{
				SimulatedCompany simulatedCompany3;
				if ((simulatedCompany3 = myEmployer as SimulatedCompany) != null && simulatedCompany3.LeadDesigner.NetworkID == res.NetworkID)
				{
					simulatedCompany3.LeadDesigner = null;
				}
				else if (myEmployer.Player)
				{
					myEmployer.NetworkEmployees.Remove(res);
				}
				res.Dismiss(false);
				res.CleanUp();
				res.MyEmployer = null;
			}
			if (freeLead)
			{
				MarketSimulation.Active.FreeLeads.Add(res);
			}
		}

		public static void RegisterLeadDesigner(Employee emp)
		{
			if (emp.NetworkID == 0)
			{
				if (NetworkManager.IsHost)
				{
					NetworkManager.Instance.SetAndRegisterNetworkObject(emp);
					SendLeadDesigner(0u, emp, emp.EmployerID, false, MessageTarget.EveryoneButMe, 0);
				}
				else
				{
					SendLeadDesigner(NetworkManager.Instance.AddIDCallback(emp), emp, emp.EmployerID, false, MessageTarget.Host, 0);
				}
			}
		}

		public static void MoveLeadDesigner(Employee emp, Company target, bool refresh, bool freeLead)
		{
			uint company = ((target != null) ? target.ID : 0u);
			if (NetworkManager.IsHost)
			{
				if (emp.NetworkID == 0 || refresh)
				{
					if (emp.NetworkID == 0)
					{
						NetworkManager.Instance.SetAndRegisterNetworkObject(emp);
					}
					SendLeadDesigner(0u, emp, company, freeLead, MessageTarget.EveryoneButMe, 0);
				}
				else
				{
					SendMoveLeadDesigner(emp.NetworkID, company, freeLead, MessageTarget.EveryoneButMe, 0);
				}
			}
			else if (NetworkManager.IsClient)
			{
				if (emp.NetworkID == 0)
				{
					SendLeadDesigner(NetworkManager.Instance.AddIDCallback(emp), emp, company, freeLead, MessageTarget.Host, 0);
				}
				else if (refresh)
				{
					SendLeadDesigner(0u, emp, company, freeLead, MessageTarget.EveryoneButMe, 0);
				}
				else
				{
					SendMoveLeadDesigner(emp.NetworkID, company, freeLead, MessageTarget.EveryoneButMe, 0);
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void FinishLeadProject(NetworkPlayer player, uint designer, uint product, float amount, bool owner, int rnd)
		{
			Employee res;
			SoftwareProduct res2;
			if (TryGet(NetworkManager.Instance.GetNetworkObject(designer) as Employee, "finish lead project", designer, out res) && TryGet(MarketSimulation.Active.GetProduct(product, false), "finish lead project " + res.FullName, designer, out res2))
			{
				res.ActuallyFinishLeadProject(res2, amount, owner, rnd);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddSimulatedCompany(NetworkPlayer player, uint id, string name, SDateTime time, double startingMoney, string stype, float avgQual, float businessSavy, byte[] logo)
		{
			SimulatedCompany company = new SimulatedCompany(id, name, time, startingMoney, MarketSimulation.Active.CompanyTypes[stype], avgQual, businessSavy)
			{
				Logo = logo
			};
			MarketSimulation.Active.AddCompany(company);
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void TradeStock(NetworkPlayer player, uint company, uint buyer, uint shares, uint currentShares, double offer, uint existing, SDateTime time)
		{
			Company res;
			if (!TryGet(MarketSimulation.Active.GetCompany(company), "stocks", company, out res))
			{
				return;
			}
			res.Shares = currentShares;
			Company res2;
			if (!TryGet(MarketSimulation.Active.GetCompany(buyer), "stocks in " + res.Name, buyer, out res2))
			{
				return;
			}
			NewStock existing2 = null;
			if (existing != 0)
			{
				existing2 = res.NewStock.FirstOrDefault((NewStock x) => x.Buyer.ID == existing);
			}
			res.ActuallyTradeStock(res2, shares, time, (offer < 0.0) ? ((double?)null) : new double?(offer), existing2);
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ExtraWorth(NetworkPlayer player, uint company, double extraWorth)
		{
			Company res;
			if (TryGet(MarketSimulation.Active.GetCompany(company), "extra worth", company, out res))
			{
				res.ExtraWorth = extraWorth;
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void BuyOut(NetworkPlayer player, uint company, uint buyer)
		{
			Company company2 = MarketSimulation.Active.GetCompany(buyer);
			MarketSimulation.Active.GetCompany(company).NetworkBuyout(((company2 != null) ? company2.Name : null) ?? "");
			if (company2 != null)
			{
				company2.CompaniesBought++;
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddTechLevel(NetworkPlayer player, string spec, int year, SDateTime time)
		{
			TechLevel orDefault = MarketSimulation.Active.TechLevels.GetOrDefault(spec, (List<TechLevel> x) => x.Last());
			if (orDefault != null && orDefault.Year >= year)
			{
				if (orDefault.Year == year)
				{
					orDefault.CanPatent = false;
				}
			}
			else
			{
				MarketSimulation.Active.ActuallyAddTechLevel(spec, year, time);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void TransferPatent(NetworkPlayer player, string spec, int year, uint company, SDateTime time)
		{
			Company res = null;
			TechLevel res2;
			if ((company == 0 || TryGet(MarketSimulation.Active.GetCompany(company), spec + " " + year + " patent", company, out res)) && TryGet(MarketSimulation.Active.GetTechLevel(spec, year), spec + " " + year + " patent", (uint)year, out res2))
			{
				res2.ActuallyTransferPatent(res, time);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddResearch(NetworkPlayer player, uint company, string spec, int year)
		{
			Company res;
			if (TryGet(MarketSimulation.Active.GetCompany(company), spec + " " + year + " research", company, out res))
			{
				res.AddResearch(spec, year, true);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void TransferFramework(NetworkPlayer player, uint company, uint framework)
		{
			Company res = null;
			SoftwareFramework res2;
			if ((company == 0 || TryGet(MarketSimulation.Active.GetCompany(company), "trade framework", company, out res)) && TryGet(MarketSimulation.Active.GetFramework(framework), "trade framework", framework, out res2))
			{
				res2.ActuallyTransfer(res);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddFramework(NetworkPlayer player, string name, uint id, uint type, uint cat, Dictionary<uint, double> features, Dictionary<string, int> techs, SDateTime releaseDate, byte playerID)
		{
			if (playerID != 0 && playerID != NetworkManager.LocalPlayerID)
			{
				name = NetworkManager.Instance.Layer.FilterName(name, NetworkManager.GetPlayer(playerID));
			}
			MarketSimulation.Active.AddFramework(name, id, type, cat, features, techs, releaseDate);
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddProduct(NetworkPlayer player, string name, uint type, uint category, uint[] os, float randomFactor, float awareness, double codeProgress, double artProgress, double codeQuality, double artQuality, double[] marketQuality, double creativityScore, float price, bool subscription, double[] submarkets, SDateTime start, SDateTime release, int bugs, bool inHouse, uint company, uint sequelto, double sequelBonus, uint id, uint[] features, Dictionary<string, int> techs, uint followers, uint framework, float frameworkRoyalty, Dictionary<uint, float> tools, byte[] hardwareDesign)
		{
			Company company2 = MarketSimulation.Active.GetCompany(company);
			if (company2 != null && company2.Player && !company2.LocalPlayer)
			{
				name = NetworkManager.Instance.Layer.FilterName(name, NetworkManager.GetPlayer(company2.NetworkPlayerID));
			}
			SoftwareProduct softwareProduct = new SoftwareProduct(name, type, category, os, randomFactor, awareness, codeProgress, artProgress, codeQuality, artQuality, marketQuality, creativityScore, price, subscription, submarkets, start, release, bugs, inHouse, company, sequelto, sequelBonus, id, features, techs, followers, framework, frameworkRoyalty, tools, hardwareDesign);
			if (softwareProduct.Type == MarketSimulation.Active.DigitalDistSoft)
			{
				DigitalPlatforms[softwareProduct.ID] = softwareProduct;
				return;
			}
			MarketSimulation.Active.AddProduct(softwareProduct, false);
			softwareProduct.DevCompany.Products.Add(softwareProduct);
			if (softwareProduct.DevCompany.Player && !softwareProduct.DevCompany.LocalPlayer)
			{
				softwareProduct.DevCompany.ReleaseNow(softwareProduct.Category, release);
				HUD.Instance.ApplyProductWindowFilters();
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddAddOn(NetworkPlayer player, string name, uint id, uint swType, uint type, uint parent, uint[] features, uint[] featureFactors, SDateTime devStart, SDateTime release, float price, float awareness, double loss, double[] quality, uint devCompany, uint physicalCopies, float distributionLoss, uint followers, double codeProgress, double artProgress, double codeQuality, double artQuality, bool forced, byte[] hardwareDesign)
		{
			Company company = MarketSimulation.Active.GetCompany(devCompany);
			if (company != null && company.Player && !company.LocalPlayer)
			{
				name = NetworkManager.Instance.Layer.FilterName(name, NetworkManager.GetPlayer(company.NetworkPlayerID));
			}
			AddOnProduct addOnProduct = new AddOnProduct(name, id, swType, type, parent, features, featureFactors, devStart, release, price, awareness, loss, quality, devCompany, physicalCopies, distributionLoss, followers, codeProgress, artProgress, codeQuality, artQuality, forced, hardwareDesign);
			addOnProduct.Owner.AddOns.Add(addOnProduct);
			MarketSimulation.Active.AddAddOn(addOnProduct);
			if (addOnProduct.Owner.Player && !addOnProduct.Owner.LocalPlayer)
			{
				addOnProduct.Owner.ReleaseNow(addOnProduct.Parent.Category, release);
				HUD.Instance.ApplyProductWindowFilters();
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void UpdateSubMarkets(NetworkPlayer player, Dictionary<KeyValuePair<uint, uint>, double[]> submarkets)
		{
			MarketSimulation.Active.RefreshMarkets(submarkets, SDateTime.Now());
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void TradeIP(NetworkPlayer player, uint company, uint id, uint addon, SDateTime time)
		{
			Company res = null;
			SoftwareProduct res2;
			if ((company != 0 && !TryGet(MarketSimulation.Active.GetCompany(company), "trade IP", company, out res)) || !TryGet(MarketSimulation.Active.GetProduct(id, false), "trade IP", id, out res2))
			{
				return;
			}
			if (addon != 0)
			{
				AddOnProduct res3;
				if (TryGet(res2.GetAddon(addon), "trade IP " + res2.Name, addon, out res3))
				{
					res3.ActuallyTrade(res);
				}
			}
			else
			{
				res2.ActuallyTrade(res, time);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ProductCashflow(NetworkPlayer player, uint id, [OptimizeParameter("0")] int onlineUnits, [OptimizeParameter("0")] int offlineUnits, [OptimizeParameter("0")] int refunds, [OptimizeParameter("0f")] float gross, [OptimizeParameter("0f")] float profit, [OptimizeParameter("0f")] float license, SDateTime now)
		{
			SoftwareProduct res;
			if (TryGet(MarketSimulation.Active.GetProduct(id, false), "cashflow", id, out res))
			{
				res.ActuallyAddToCashflow(onlineUnits, offlineUnits, refunds, gross, profit, license, now);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ProductUserbase(NetworkPlayer player, uint id, int userbase)
		{
			SoftwareProduct res;
			if (TryGet(MarketSimulation.Active.GetProduct(id, false), "userbase", id, out res))
			{
				res.Userbase = userbase;
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddFans(NetworkPlayer player, uint id, uint software, uint category, int amount)
		{
			Company res;
			SoftwareType res2;
			SoftwareCategory res3;
			if (TryGet(MarketSimulation.Active.GetCompany(id), "fans", id, out res) && TryGet(MarketSimulation.Active.GetSoftwareType(software), "fans for " + res.Name, id, out res2) && TryGet(res2.GetCategory(category), res2.Name + " fans for " + res.Name, id, out res3))
			{
				res.ActuallyAddFans(amount, res3);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ArchiveProduct(NetworkPlayer player, uint id, bool delete)
		{
			SoftwareProduct res;
			if (!TryGet(MarketSimulation.Active.GetProduct(id, false, false, true), "archive", id, out res))
			{
				return;
			}
			if (res.Type == MarketSimulation.Active.DigitalDistSoft)
			{
				DistributionPlatform res2;
				if (TryGet(MarketSimulation.Active.GetDistributionPlatform(id), "Close digital platform", id, out res2))
				{
					MarketSimulation.Active.ClosePlatform(res2, true);
					DigitalPlatforms.Remove(res2.Software.ID);
				}
			}
			else
			{
				if (delete)
				{
					res.ActuallyRemoveFromGame();
				}
				else
				{
					res.ActuallyArchive();
				}
				MarketSimulation.Active.ArchiveProduct(res, delete);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ChangeFollowers(NetworkPlayer player, uint id, [OptimizeParameter("0u")] uint addon, [OptimizeParameter("0u")] uint followers)
		{
			SoftwareProduct res;
			if (!TryGet(MarketSimulation.Active.GetProduct(id, false), "followers", id, out res))
			{
				return;
			}
			if (addon != 0)
			{
				AddOnProduct res2;
				if (TryGet(res.GetAddon(addon), "followers for " + res.Name, addon, out res2))
				{
					res2.Followers = followers;
				}
			}
			else
			{
				res.Followers = followers;
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void UpdateMarketing(NetworkPlayer player, uint id, [OptimizeParameter("0u")] uint addon, [OptimizeParameter("0f")] float marketing, [OptimizeParameter("true")] bool simulate, [OptimizeParameter("false")] bool awarenessChange)
		{
			SoftwareProduct res;
			if (!TryGet(MarketSimulation.Active.GetProduct(id, false), "marketing", id, out res))
			{
				return;
			}
			if (addon != 0)
			{
				AddOnProduct res2;
				if (!TryGet(res.GetAddon(addon), "marketing for " + res.Name, addon, out res2))
				{
					return;
				}
				if (awarenessChange)
				{
					res2.SetAwareness(marketing);
					return;
				}
				res2.Marketing = marketing;
				if (simulate)
				{
					res2.SimulateAwareness(true);
				}
			}
			else if (awarenessChange)
			{
				res.SetAwareness(marketing, true);
			}
			else
			{
				res.Marketing = marketing;
				if (simulate)
				{
					res.SimulateAwareness(true);
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ProductPrototype(NetworkPlayer player, string name, uint id, uint type, uint category, Dictionary<string, uint> needs, uint[] os, double codeProgress, double artProgress, double codeQuality, double artQuality, float price, bool subscription, double[] submarkets, uint company, bool inHouse, float reception, uint sequelTo, uint[] feats, Dictionary<string, int> techs, double loss, uint framework, string newFramework)
		{
			SimulatedCompany.ProductPrototype productPrototype = new SimulatedCompany.ProductPrototype(name, id, type, category, needs, os, codeProgress, artProgress, codeQuality, artQuality, price, subscription, submarkets, company, inHouse, reception, sequelTo, feats, techs, loss, framework, newFramework);
			productPrototype.DevCompany.ProjectQueue.Add(productPrototype);
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void StartDev(NetworkPlayer player, uint company, uint project, SDateTime start, SDateTime release)
		{
			SimulatedCompany res;
			SimulatedCompany.ProductPrototype res2;
			if (TryGet(MarketSimulation.Active.GetCompany(company) as SimulatedCompany, "start development", company, out res) && TryGet(res.GetPrototype(project), "start development for " + res.Name, project, out res2))
			{
				res2.StartDev(start, release, true);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ReleaseDev(NetworkPlayer player, uint company, uint project)
		{
			SimulatedCompany res;
			SimulatedCompany.ProductPrototype res2;
			if (TryGet(MarketSimulation.Active.GetCompany(company) as SimulatedCompany, "release project", company, out res) && TryGet(res.GetPrototype(project), "release project for " + res.Name, project, out res2))
			{
				res2.RemoveProject(true);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddonPrototype(NetworkPlayer player, string name, uint type, uint parent, Dictionary<string, uint> needs, double codeProgress, double artProgress, double codeQuality, double artQuality, float price, uint company, float reception, uint[] feats, uint[] factors, double loss, SDateTime releaseDate, SDateTime devStart)
		{
			SimulatedCompany.AddonPrototype addonPrototype = new SimulatedCompany.AddonPrototype(name, type, parent, needs, codeProgress, artProgress, codeQuality, artQuality, price, company, reception, feats, factors, loss, releaseDate, devStart);
			addonPrototype.DevCompany.CurrentAddonProject = addonPrototype;
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void EndAddonDev(NetworkPlayer player, uint company)
		{
			SimulatedCompany res;
			if (TryGet(MarketSimulation.Active.GetCompany(company) as SimulatedCompany, "end addon development", company, out res))
			{
				res.CurrentAddonProject.RemoveProject(true);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void UpdateStockMarket(NetworkPlayer player, string market, bool metal, float value)
		{
			List<StockMarket> list = (metal ? GameSettings.Instance.MetalMarkets : GameSettings.Instance.StockMarkets);
			StockMarket sm;
			if (!TryGet(list.FirstOrDefault((StockMarket x) => x.Name.Equals(market)), "update stock market " + market, 0u, out sm))
			{
				return;
			}
			if (value < 0f)
			{
				GameSettings.Instance.Investments.RemoveAll((Investment x) => x.Stock == sm);
				list.Remove(sm);
				HUD.Instance.insuranceWindow.UpdateInvestments();
			}
			else
			{
				sm.SetValue(value);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddStockMarket(NetworkPlayer player, string market, float range, float factor, float[] values)
		{
			GameSettings.Instance.StockMarkets.Add(new StockMarket(market, range, factor, values));
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void UpdateProduct(NetworkPlayer player, uint id, Dictionary<string, int> techs, SDateTime time)
		{
			SoftwareProduct res;
			if (TryGet(MarketSimulation.Active.GetProduct(id, false, false, true), "product update", id, out res))
			{
				res.ActuallyUpdate(0, 0, techs.ToDictionary((KeyValuePair<string, int> x) => x.Key, (KeyValuePair<string, int> x) => MarketSimulation.Active.GetTechLevel(x.Key, x.Value)), time);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void UpdateFramework(NetworkPlayer player, uint id, Dictionary<string, int> techs, SDateTime time)
		{
			SoftwareFramework res;
			if (TryGet(MarketSimulation.Active.GetFramework(id), "framework update", id, out res))
			{
				res.ActuallyUpdate(techs.ToDictionary((KeyValuePair<string, int> x) => x.Key, (KeyValuePair<string, int> x) => MarketSimulation.Active.GetTechLevel(x.Key, x.Value)), time);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ChangeBugs(NetworkPlayer player, uint id, int startBugs, int bugs)
		{
			SoftwareProduct res;
			if (TryGet(MarketSimulation.Active.GetProduct(id, false, false, true), "bug change", id, out res))
			{
				res.ActuallyChangeBugs(startBugs, bugs);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ChangePhysicalCopies(NetworkPlayer player, uint id, [OptimizeParameter("0u")] uint addon, [OptimizeParameter("0u")] uint copies, [OptimizeParameter("0u")] uint proto)
		{
			if (proto != 0)
			{
				SimulatedCompany res;
				SimulatedCompany.ProductPrototype res2;
				if (TryGet(MarketSimulation.Active.GetCompany(proto) as SimulatedCompany, "physical proto copy change", proto, out res) && TryGet(res.GetPrototype(id), "physical proto copy change for " + res.Name, id, out res2))
				{
					res2.ChangePhysicalCopiesDirectly(copies);
				}
			}
			else
			{
				SoftwareProduct res3;
				if (!TryGet(MarketSimulation.Active.GetProduct(id, false), "physical copy change", id, out res3))
				{
					return;
				}
				if (addon != 0)
				{
					AddOnProduct res4;
					if (TryGet(res3.GetAddon(addon), "physical addon change for " + res3.Name, addon, out res4))
					{
						res4.ChangePhysicalCopiesDirectly(copies);
					}
				}
				else
				{
					res3.ChangePhysicalCopiesDirectly(copies);
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void RunProductScripts(NetworkPlayer player, uint id, uint feature, ScriptSystem.EntryPoint entry, ScriptSystem.ProductScope scope)
		{
			SoftwareProduct res;
			SubFeature res2;
			if (TryGet(MarketSimulation.Active.GetProduct(id, false), "run product script " + entry, id, out res) && TryGet(res.Type.GetFeature(feature) as SubFeature, string.Concat("run product script ", entry, " for ", res.Name), id, out res2))
			{
				res2.ActuallyRunScript(entry, scope);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void RunCopyScripts(NetworkPlayer player, uint id, uint feature, ScriptSystem.EntryPoint entry, ScriptSystem.CopyScope scope)
		{
			SoftwareProduct res;
			SubFeature res2;
			if (TryGet(MarketSimulation.Active.GetProduct(id, false), "run copy script " + entry, id, out res) && TryGet(res.Type.GetFeature(feature) as SubFeature, string.Concat("run copy script ", entry, " for ", res.Name), id, out res2))
			{
				res2.ActuallyRunScript(entry, scope);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void CreateDigitalPlatform(NetworkPlayer player, uint owner, uint software, float cut)
		{
			DistributionPlatform distributionPlatform = MarketSimulation.Active.GetDistributionPlatform(software);
			Company res = null;
			SoftwareProduct res2;
			if ((distributionPlatform != null || TryGet(MarketSimulation.Active.GetCompany(owner), "create digital platform", owner, out res)) && TryGet(DigitalPlatforms.GetOrNull(software), "create digital platform", owner, out res2))
			{
				if (distributionPlatform != null)
				{
					MarketSimulation.Active.UpdatePlatform(distributionPlatform, res2, true);
				}
				else
				{
					MarketSimulation.Active.CreatePlatform(res, res2, cut, true);
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void SignDigitalPlatform(NetworkPlayer player, uint company, uint platform, bool sign)
		{
			Company res;
			DistributionPlatform res2;
			if (TryGet(MarketSimulation.Active.GetCompany(company), "sign digital platform", company, out res) && TryGet(MarketSimulation.Active.GetDistributionPlatform(platform), "sign digital platform for " + res.Name, platform, out res2))
			{
				res.SignPlatform(res2, sign, true);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void RegisterLocalPlayerPlatformQuery(NetworkPlayer player, uint company, uint platformC, bool interested, int quarantine)
		{
			Company res;
			Company res2;
			if (TryGet(MarketSimulation.Active.GetCompany(company), "query digital platform company", company, out res) && TryGet(MarketSimulation.Active.GetCompany(platformC), "query digital platform", company, out res2))
			{
				res.MarkInterested(res2, interested, quarantine, true);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void DistributionCut(NetworkPlayer player, uint platform, float cut)
		{
			DistributionPlatform res;
			if (TryGet(MarketSimulation.Active.GetDistributionPlatform(platform), "sign platform cut", platform, out res))
			{
				res.SetCut(cut, true);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void DistributionState(NetworkPlayer player, uint platform, bool open)
		{
			DistributionPlatform res;
			if (TryGet(MarketSimulation.Active.GetDistributionPlatform(platform), "change platform open", platform, out res))
			{
				res.Open = open;
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void DistributionStats(NetworkPlayer player, [OptimizeParameter("0u")] uint platform, [OptimizeParameter("0u")] uint targetUsers, [OptimizeParameter("0u")] uint penalty, [OptimizeParameter("0u")] uint actualUsers, [OptimizeParameter("0")] int userBase, [OptimizeParameter("false")] bool penaltyOnly)
		{
			DistributionPlatform res;
			if (TryGet(MarketSimulation.Active.GetDistributionPlatform(platform), "sign platform cut", platform, out res))
			{
				if (penaltyOnly)
				{
					res.UserPenalty = penalty;
				}
				else
				{
					res.SyncTargetUsers(targetUsers, penalty, actualUsers, userBase);
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ChangePlatformAccept(NetworkPlayer player, uint company, [OptimizeParameter("true")] bool client, [OptimizeParameter("true")] bool value)
		{
			Company res;
			if (!TryGet(MarketSimulation.Active.GetCompany(company), "Change platform acceptance", company, out res))
			{
				return;
			}
			if (client)
			{
				DistributionPlatform distribution = res.Distribution;
				if (distribution != null)
				{
					distribution.SetAutoAcceptClients(value, true);
				}
			}
			else
			{
				res.SetAutoAcceptPlatforms(value, true);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void DistributionLoad(NetworkPlayer player, Dictionary<uint, float> loads)
		{
			foreach (KeyValuePair<uint, float> load in loads)
			{
				MarketSimulation.Active.GetCompany(load.Key).DistributionLoad = load.Value;
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void DistributionSales(NetworkPlayer player, uint platform, float sales, [OptimizeParameter("0f")] float actualSales, uint total)
		{
			DistributionPlatform res;
			if (TryGet(MarketSimulation.Active.GetDistributionPlatform(platform), "platform sales", platform, out res))
			{
				res.ItemSales = sales;
				res.ActualItemSales = actualSales;
				res.MarketShare = ((total != 0) ? Mathf.Clamp01(res.ItemSales / (float)total) : 0f);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ExclusiveStore(NetworkPlayer player, uint product, uint platform, SDateTime end)
		{
			SoftwareProduct res;
			DistributionPlatform res2;
			if (TryGet(MarketSimulation.Active.GetProduct(product, false), "exclusivity", platform, out res) && TryGet(MarketSimulation.Active.GetDistributionPlatform(platform), "exclusivity for " + res.Name, platform, out res2))
			{
				res.ExclusiveStore = res2;
				res.ExclusiveEnd = end;
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void DistributionBandwidth(NetworkPlayer player, uint platform, float bandwidth)
		{
			DistributionPlatform res;
			if (TryGet(MarketSimulation.Active.GetDistributionPlatform(platform), "platform bandwidth", platform, out res))
			{
				res.AvailableBandwidth = bandwidth;
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void SoftwareID(NetworkPlayer player, [OptimizeParameter("0u")] uint id, [OptimizeParameter("false")] bool framework)
		{
			if (id == 0)
			{
				if (NetworkManager.IsHost)
				{
					SendSoftwareID(framework ? MarketSimulation.Active.GetFrameworkID() : MarketSimulation.Active.GetID(), framework, MessageTarget.Specifically, player.ID);
				}
			}
			else
			{
				MarketSimulation.Active.AddNetworkID(id, framework);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ChangePrice(NetworkPlayer player, uint id, uint addon, float newPrice)
		{
			SoftwareProduct res;
			if (!TryGet(MarketSimulation.Active.GetProduct(id, false), "change price", id, out res))
			{
				return;
			}
			if (addon != 0)
			{
				AddOnProduct res2;
				if (TryGet(res.GetAddon(addon), "change addon price " + res.Name, addon, out res2))
				{
					res2.ActuallyChangePrice(newPrice);
				}
			}
			else
			{
				res.ActuallyChangePrice(newPrice);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void MakeSubsidiary(NetworkPlayer player, uint company, uint newOwner, SDateTime time)
		{
			Company res = null;
			Company res2;
			if (TryGet(MarketSimulation.Active.GetCompany(company), "subsidiary", company, out res2) && (newOwner == 0 || TryGet(MarketSimulation.Active.GetCompany(newOwner), "subsidiary", company, out res)))
			{
				res2.MakeSubsidiaryNetwork(res, time);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ScheduleRelease(NetworkPlayer player, uint company, uint id, [OptimizeParameter("(string)null")] string name, [OptimizeParameter("0u")] uint swType, [OptimizeParameter("0u")] uint swCat, [OptimizeParameter("0u")] uint sequelTo, [OptimizeParameter("(SDateTime?)null")] SDateTime? date, [OptimizeParameter("false")] bool reschedule)
		{
			Company res;
			if (!TryGet(MarketSimulation.Active.GetCompany(company), "schedule release", company, out res))
			{
				return;
			}
			SoftwareType res2;
			SoftwareCategory res3;
			if (reschedule)
			{
				if (!date.HasValue)
				{
					res.UnscheduleRelease(id, true);
				}
				else
				{
					res.RescheduleRelease(id, date, true);
				}
			}
			else if (TryGet(MarketSimulation.Active.GetSoftwareType(swType), "schedule release for " + res.Name, company, out res2) && TryGet(res2.GetCategory(swCat), "schedule release for " + res.Name, company, out res3))
			{
				res.ScheduleRelease(name, id, res3, MarketSimulation.Active.GetProduct(sequelTo, false), date, true);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddDeal(NetworkPlayer player, Deal deal)
		{
			if (deal != null)
			{
				deal.RecalculateWorth();
				HUD.Instance.dealWindow.AddDeal(deal, true);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void CancelDeal(NetworkPlayer player, uint deal, bool repercussion)
		{
			foreach (Actor item in GameSettings.Instance.sActorManager.Others["Guests"])
			{
				if (item.deal != null && item.deal.ID == deal)
				{
					if (item.isActiveAndEnabled)
					{
						item.deal = null;
					}
					else
					{
						item.DestroyGO();
					}
				}
			}
			HUD.Instance.dealWindow.CancelDeal(deal, repercussion);
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void UpdateProtoQuality(NetworkPlayer player, uint company, uint product, double codeP, double artP, double codeQ, double artQ)
		{
			SimulatedCompany res;
			SimulatedCompany.ProductPrototype res2;
			if (TryGet(MarketSimulation.Active.GetCompany(company) as SimulatedCompany, "proto quality change", company, out res) && TryGet(res.GetPrototype(product), "proto quality change for " + res.Name, product, out res2))
			{
				res2.SetQuality(codeP, artP, codeQ, artQ, true);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void Port(NetworkPlayer player, uint product, uint OS)
		{
			SoftwareProduct p;
			SoftwareProduct res;
			if (!TryGet(MarketSimulation.Active.GetProduct(product, false), "porting", product, out p) || !TryGet(MarketSimulation.Active.GetProduct(OS, false), "porting " + p.Name, OS, out res))
			{
				return;
			}
			GameSettings.Instance.CheckOSLicenses = true;
			if (!p.HasOS(res))
			{
				GameSettings.Instance.simulation.RegisterOSSupport(p.Category, res);
				p.AddOS(res);
				ProductDetailWindow productDetailWindow = WindowManager.FindWindowType<ProductDetailWindow>().FirstOrDefault((ProductDetailWindow x) => x.product == p);
				if (productDetailWindow != null)
				{
					productDetailWindow.UpdateMe();
				}
			}
		}

		[RPCCall]
		private static void RequestSync(NetworkPlayer player, SyncType type, uint id, bool approved)
		{
			if (player.Host)
			{
				SyncApproved(type, id, approved);
				return;
			}
			bool flag = CanSync(type, id);
			SendRequestSync(type, id, flag, MessageTarget.Specifically, player.ID);
			ApplySync(type, id, flag ? 2f : 1f);
		}

		[RPCCall]
		private static void RequestSyncVerify(NetworkPlayer player, SyncType type, uint id, uint verification, uint newValue, bool approved)
		{
			if (player.Host)
			{
				SyncApproved(type, id, approved);
			}
			else
			{
				SendRequestSync(type, id, VerifyMessageID(type, id, verification, newValue), MessageTarget.Specifically, player.ID);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddLoss(NetworkPlayer player, uint id, float loss, [OptimizeParameter("SoftwareProduct.LossType.Other")] SoftwareProduct.LossType type, [OptimizeParameter("0u")] uint addon, [OptimizeParameter("0u")] uint license)
		{
			SoftwareProduct res;
			if (!TryGet(MarketSimulation.Active.GetProduct(id, false), "adding loss", id, out res))
			{
				return;
			}
			if (addon != 0)
			{
				AddOnProduct res2;
				if (TryGet(res.GetAddon(addon), "adding addon loss for " + res.Name, addon, out res2))
				{
					res2.AddLoss(loss, type, true, true);
				}
			}
			else if (license != 0)
			{
				SoftwareProduct res3;
				if (TryGet(MarketSimulation.Active.GetProduct(license, false), "Adding license cost", license, out res3))
				{
					res.AddLicenseCost(res3, loss, true);
				}
			}
			else
			{
				res.AddLoss(loss, type, true, true);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddonSimulation(NetworkPlayer player, uint id, uint addon, [OptimizeParameter("0.0")] double gross, [OptimizeParameter("0")] int refunds, [OptimizeParameter("0")] int online, [OptimizeParameter("0")] int offline, [OptimizeParameter("0f")] float lastMonthIncome, [OptimizeParameter("0f")] float lastDayLoss, [OptimizeParameter("0f")] float lastDayIncome, SDateTime time)
		{
			SoftwareProduct res;
			AddOnProduct res2;
			if (TryGet(MarketSimulation.Active.GetProduct(id, false), "syncing addon sim", id, out res) && TryGet(res.GetAddon(addon), "syncing addon sim for " + res.Name, addon, out res2))
			{
				res2.SyncSimulation(gross, refunds, online, offline, lastMonthIncome, lastDayIncome, lastDayLoss, time);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddProductLoadIncident(NetworkPlayer player, uint id, bool add)
		{
			SoftwareProduct res;
			if (TryGet(MarketSimulation.Active.GetProduct(id, false), "load incident", id, out res))
			{
				if (add)
				{
					res.LoadIncidents++;
					res.MaxLoadIncidents = Mathf.Max(res.LoadIncidents, res.MaxLoadIncidents);
				}
				else
				{
					res.LoadIncidents--;
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AddProductRep(NetworkPlayer player, uint id, [OptimizeParameter("0")] int change, SDateTime time)
		{
			SoftwareProduct res;
			if (TryGet(MarketSimulation.Active.GetProduct(id, false), "rep change", id, out res))
			{
				res.ActuallyAddRepChange(change, time);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void FrameworkPayment(NetworkPlayer player, uint id, uint product, float amount)
		{
			SoftwareFramework res;
			SoftwareProduct res2;
			if (TryGet(MarketSimulation.Active.GetFramework(id), "framework payment", id, out res) && TryGet(MarketSimulation.Active.GetProduct(product, false), "framework payment for " + res.Name, product, out res2))
			{
				res.Income += amount;
				res2.FrameworkPayout += amount;
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AIResearch(NetworkPlayer player, uint company, SimulatedCompany.TechResearch t)
		{
			SimulatedCompany res;
			if (TryGet(MarketSimulation.Active.GetCompany(company) as SimulatedCompany, "AI research", company, out res))
			{
				res.SpecResearch = t;
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void DividendStats(NetworkPlayer player, Dictionary<uint, Dictionary<uint, float>> div)
		{
			foreach (Company allCompany in MarketSimulation.Active.GetAllCompanies())
			{
				Dictionary<uint, float> value;
				if (div.TryGetValue(allCompany.ID, out value))
				{
					for (int i = 0; i < allCompany.NewStock.Count; i++)
					{
						NewStock newStock = allCompany.NewStock[i];
						newStock.Payout = value.GetOrDefault(newStock.Buyer.ID, 0f);
					}
				}
				else
				{
					allCompany.NewStock.ForEach(delegate(NewStock x)
					{
						x.Payout = 0f;
					});
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void BroadcastUUID(NetworkPlayer player, string uuid)
		{
			GameSettings.Instance.NetworkData.AddUUID(uuid);
		}

		[RPCCall]
		private static void InitialGameSettings(NetworkPlayer player, InitialNetworkSettings settings)
		{
			GameData.NetworkSettings = settings;
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void RainSync(NetworkPlayer player, Vector2 windiness, float sunSize, float cloudy)
		{
			TimeOfDay.Instance.Windiness = windiness;
			TimeOfDay.Instance.Offset = Vector2.zero;
			TimeOfDay.Instance.SunLight.cookieSize = sunSize;
			TimeOfDay.Instance.Cloudiness = cloudy;
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void AwardWinners(NetworkPlayer player, List<KeyValuePair<uint, string>>[] winners)
		{
			GameSettings.Instance.AwardWinners = new List<KeyValuePair<Company, string>>[winners.Length];
			for (int i = 0; i < winners.Length; i++)
			{
				GameSettings.Instance.AwardWinners[i] = winners[i].SelectInPlaceList((KeyValuePair<uint, string> x) => new ValueTuple<Company, string>(MarketSimulation.Active.GetCompany(x.Key), x.Value).ToKeyValuePair());
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void EmployerScore(NetworkPlayer player, float score)
		{
			Company res;
			if (TryGet(player.GetPlayerCompany(), "employer score", player.ID, out res))
			{
				res.EmployerScore = score;
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void BusinessRep(NetworkPlayer player, float pct)
		{
			Company res;
			if (TryGet(player.GetPlayerCompany(), "business rep", player.ID, out res))
			{
				float num = pct - res.BusinessReputation;
				res.ChangeBusinessRep(num * 6f, null, 6f);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void TakeOverData(NetworkPlayer player, uint company, Company.TakeOverData takeOverData)
		{
			Company res;
			if (TryGet(MarketSimulation.Active.GetCompany(company), "Take over data", company, out res))
			{
				Company.GenerateTakeOverMessage(res, takeOverData);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void NewspaperTakeover(NetworkPlayer player, uint company, uint[] buyers, double amount)
		{
			Company res;
			if (TryGet(MarketSimulation.Active.GetCompany(company), "Newspaper take over", company, out res))
			{
				Newspaper.GenerateStockBuyout(res, buyers.SelectNotNull(MarketSimulation.Active.GetCompany).ToArray(), amount);
			}
		}

		[RPCCall]
		private static void TryReconnection(NetworkPlayer player, bool host, byte id)
		{
			if (host)
			{
				Debug.Log("Received reconnection message from host: " + player.Name);
				NetworkManager.Instance.WaitingForReconnection = false;
				GameSettings.Instance.NetworkData.ReRegisterAllPlayers();
				WindowManager.ShowFullScreenMessage(null);
				GameSettings.ForcePause = false;
			}
			else
			{
				Debug.Log("Received reconnection message from client: " + player.Name);
				player = NetworkLayer.Active.HandleReconnection(player, id);
				player.WaitingForReconnection = false;
				SendBroadcastUUID(GameSettings.Instance.NetworkData.CurrentUUID, MessageTarget.Specifically, id);
			}
		}

		[RPCCall(OnlyInGame = true)]
		private static void Notification(NetworkPlayer player, NotificationMessage msg)
		{
			if (msg != null)
			{
				msg.CheckAddAggregate();
			}
		}

		[RPCCall(OnlyInGame = true)]
		private static void Diagnostics(NetworkPlayer player, DiagnosticSheet type, string[] theirs)
		{
			if (theirs == null)
			{
				SendDiagnostics(type, GetDiagnosticSheet(type), MessageTarget.Specifically, player.ID);
				return;
			}
			string[] diagnosticSheet = GetDiagnosticSheet(type);
			DevConsole.Console.Log(GUIUtility.systemCopyBuffer = CompareDiagnosticSheets(type, diagnosticSheet, theirs));
		}

		[RPCCall(OnlyInGame = true)]
		private static void SyncMoney(NetworkPlayer player, uint[] companies, double[] money)
		{
			if (!player.Host)
			{
				if (companies == null)
				{
					List<Company> list = MarketSimulation.Active.GetAllCompanies().ToList();
					uint[] array = new uint[list.Count];
					double[] array2 = new double[list.Count];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = list[i].ID;
						array2[i] = list[i].Money;
					}
					SendSyncMoney(array, array2, MessageTarget.Specifically, player.ID);
				}
			}
			else
			{
				if (companies == null)
				{
					return;
				}
				for (int j = 0; j < companies.Length; j++)
				{
					Company res;
					if (TryGet(MarketSimulation.Active.GetCompany(companies[j]), "sync money", companies[j], out res))
					{
						double num = money[j];
						double num2 = Math.Abs(num - res.Money);
						if (num2 > 5000.0)
						{
							Debug.Log(string.Concat("Large ", num2.Currency(), " money discrepancy for ", res, " between host and client"));
						}
						res.HostChangeMoney(num);
					}
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void NewRoom(NetworkPlayer player, BuildingPrefab prefab)
		{
			GameSettings.Instance.sRoomManager.GetMap(player).Sync(prefab);
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void NewRoomSegment(NetworkPlayer player, BuildingPrefab.SegmentObject segment, uint parentRoom)
		{
			PlayerMap map = GameSettings.Instance.sRoomManager.GetMap(player);
			NetworkRoom res;
			if (TryGet(map.Rooms.GetOrNull(parentRoom), "New room segment", player.ID, out res))
			{
				map.SyncSegment(segment, res);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void NewFurniture(NetworkPlayer player, BuildingPrefab.FurnitureObject furn)
		{
			GameSettings.Instance.sRoomManager.GetMap(player).SyncFurniture(furn);
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void MoveFurniture(NetworkPlayer player, uint id, Vector3 position, int floor, float rot, [OptimizeParameter("0f")] float rotOffset, [OptimizeParameter("0u")] uint room, [OptimizeParameter("0u")] uint parent, [OptimizeParameter("0")] int snapID, [OptimizeParameter("false")] bool isReversed)
		{
			PlayerMap res;
			Furniture res2;
			if (TryGet(GameSettings.Instance.sRoomManager.PlayerMaps.GetOrNull(player.ID), "Move furniture", player.ID, out res) && TryGet(res.Furnitures.GetOrNull(id), "Move furniture", player.ID, out res2))
			{
				if (res2 == null)
				{
					res.Furnitures.Remove(id);
				}
				else
				{
					res.MoveFurniture(res2, position, floor, rot, rotOffset, room, parent, snapID, isReversed);
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void DestroyNetworkObject(NetworkPlayer player, uint id, bool local)
		{
			INetworkID res;
			if (local)
			{
				PlayerMap value;
				if (GameSettings.Instance.sRoomManager.PlayerMaps.TryGetValue(player.ID, out value))
				{
					if (id == 0)
					{
						value.Destroy();
						GameSettings.Instance.sRoomManager.PlayerMaps.Remove(player.ID);
					}
					else
					{
						value.DestroyObject(id);
					}
				}
			}
			else if (TryGet(NetworkManager.Instance.GetNetworkObject(id), "Destroy network object", id, out res))
			{
				if (res.GO != null)
				{
					UnityEngine.Object.Destroy(res.GO);
				}
				else
				{
					Debug.Log("Tried to destroy non-existent global network GameObject: " + res.GetType().Name);
				}
				NetworkManager.Instance.UnregisterNetworkObject(res, true);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void UpdateRoomAtrium(NetworkPlayer player, uint room, int floors)
		{
			PlayerMap res;
			NetworkRoom res2;
			if (TryGet(GameSettings.Instance.sRoomManager.PlayerMaps.GetOrNull(player.ID), "Update atrium", player.ID, out res) && TryGet(res.Rooms.GetOrNull(room), "Update atrium", player.ID, out res2))
			{
				res2.FloorHeight = floors;
				res2.RefreshAtriums(false);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ObjectStyle(NetworkPlayer player, uint id, [OptimizeParameter("true")] bool local, [OptimizeParameter("(string)null")] string material, [OptimizeParameter("(string)null")] string material2, [OptimizeParameter("Color.black")] Color c, [OptimizeParameter("Color.black")] Color c2, [OptimizeParameter("Color.black")] Color c3, [OptimizeParameter("Color.black")] Color c4, [OptimizeParameter("0")] int atlasIndex)
		{
			Writeable res2;
			if (local)
			{
				PlayerMap res;
				if (!TryGet(GameSettings.Instance.sRoomManager.PlayerMaps.GetOrNull(player.ID), "Update local style", player.ID, out res))
				{
					return;
				}
				NetworkRoom value;
				Roof value2;
				RoomSegment value3;
				Furniture value4;
				if (res.Rooms.TryGetValue(id, out value))
				{
					if (value != null)
					{
						if (value.Outdoors)
						{
							value.SetInsideMaterial(material);
							value.SetOutsideMaterial(material2);
							value.SetColor(c, Color.black, true);
							value.SetColor(c2, c3, false);
						}
						else
						{
							value.SetOutsideMaterial(material);
							value.SetColor(c, c2, true);
						}
					}
				}
				else if (res.Roofs.TryGetValue(id, out value2))
				{
					if (value2 != null)
					{
						value2.ApplyNetworkStyle(material, material2, c, c2, c3, c4, atlasIndex);
					}
				}
				else if (res.Segments.TryGetValue(id, out value3))
				{
					if (value3 != null)
					{
						value3.ApplyNetworkStyle(material, material2, c, c2, c3, c4, atlasIndex);
					}
				}
				else if (res.Furnitures.TryGetValue(id, out value4) && value4 != null)
				{
					value4.ApplyNetworkStyle(material, material2, c, c2, c3, c4, atlasIndex);
				}
			}
			else if (TryGet(NetworkManager.Instance.GetNetworkObject(id) as Writeable, "Update global style", id, out res2))
			{
				res2.ApplyNetworkStyle(material, material2, c, c2, c3, c4, atlasIndex);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void RoomEdges(NetworkPlayer player, uint room, Vector2[] ps, bool[] smooth)
		{
			PlayerMap res;
			NetworkRoom res2;
			if (TryGet(GameSettings.Instance.sRoomManager.PlayerMaps.GetOrNull(player.ID), "Update room edges", player.ID, out res) && TryGet(res.Rooms.GetOrNull(room), "Update room edges", player.ID, out res2))
			{
				res2.SetEdges(ps, smooth);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void VerifyRoomData(NetworkPlayer player, uint[] rooms, uint[] roofs, bool check)
		{
			if (rooms.Length == 0)
			{
				return;
			}
			if (check)
			{
				PlayerMap orNull = GameSettings.Instance.sRoomManager.PlayerMaps.GetOrNull(player.ID);
				if (orNull == null)
				{
					SendVerifyRoomData(rooms, roofs, false, MessageTarget.Specifically, player.ID);
					return;
				}
				List<uint> list = new List<uint>();
				List<uint> list2 = new List<uint>();
				list2.AddRange(orNull.Rooms.Keys);
				foreach (uint item in list2)
				{
					if (!rooms.Contains(item))
					{
						orNull.DestroyObject(item);
					}
				}
				list2.Clear();
				list2.AddRange(orNull.Roofs.Keys);
				foreach (uint item2 in list2)
				{
					if (!roofs.Contains(item2))
					{
						orNull.DestroyObject(item2);
					}
				}
				foreach (uint num in rooms)
				{
					if (!orNull.Rooms.ContainsKey(num))
					{
						list.Add(num);
					}
				}
				List<uint> list3 = new List<uint>();
				foreach (uint num2 in roofs)
				{
					if (!orNull.Roofs.ContainsKey(num2))
					{
						list3.Add(num2);
					}
				}
				if (list.Count > 0 || list.Count > 0)
				{
					SendVerifyRoomData(list.ToArray(), list3.ToArray(), false, MessageTarget.Specifically, player.ID);
				}
				return;
			}
			SendNewRoom(BuildingPrefab.SaveRoomsForNetwork(rooms.SelectNotNull((uint x) => GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room z) => z.NetworkID == x)).ToArray(), roofs.SelectNotNull((uint x) => GameSettings.Instance.sRoomManager.Roofs.FirstOrDefault((Roof z) => z.NetworkID == x)).ToArray(), false), MessageTarget.Specifically, player.ID);
		}

		[RPCCall]
		private static void NewTrade(NetworkPlayer player, NetworkTrade trade)
		{
			if (trade == null)
			{
				Debug.LogError("Got empty trade offer from " + player.ID + ", connected: " + string.Join(", ", NetworkManager.Instance.Players.Select((NetworkPlayer x) => x.ID.ToString())));
			}
			else
			{
				NetworkManager.Instance.TradeController.Trades[trade.ID] = trade;
				ChatWindow.ReceiveMessage(player, false, false, trade.GetReceiveMessage(), trade);
			}
		}

		[RPCCall]
		private static void TradeState(NetworkPlayer player, uint id, NetworkTrade.Status st)
		{
			NetworkTrade res;
			if (TryGet(NetworkManager.Instance.TradeController.Trades.GetOrNull(id), "trade state change " + st, id, out res))
			{
				if (st != res.State && (st == NetworkTrade.Status.Accepted || st == NetworkTrade.Status.Rejected))
				{
					ChatWindow.Instance.Ping(player.ActualUniqueID);
				}
				res.State = st;
				if (res.State != NetworkTrade.Status.Waiting && (res.State != NetworkTrade.Status.Accepted || !res.KeepOnAccept))
				{
					NetworkManager.Instance.TradeController.Trades.Remove(id);
				}
				if (res.State == NetworkTrade.Status.Cancelled)
				{
					res.OnCancelled();
				}
				if (res.CancelForSender)
				{
					NetworkManager.Instance.TradeController.CancelAllTradesFor(res.GetResource(), res);
				}
				if (res.State == NetworkTrade.Status.Accepted && res.Sender.Self)
				{
					res.AcceptTradeSender();
				}
			}
		}

		[RPCCall]
		private static void AllIDs(NetworkPlayer player, uint tradeID, uint objectID, uint workItemID, uint softwareID, uint frameworkID, uint dealID, uint companyID)
		{
			if (player.Host)
			{
				NetworkManager.Instance.SetIDOfType(NetworkManager.NetworkIDType.GlobalObject, objectID);
				NetworkManager.Instance.SetIDOfType(NetworkManager.NetworkIDType.Trade, tradeID);
				NetworkManager.Instance.SetIDOfType(NetworkManager.NetworkIDType.WorkItem, workItemID);
				if (!GameSettings.Instance.IsReferenceNull())
				{
					MarketSimulation.Active.SetIDS(softwareID, frameworkID, companyID, dealID);
				}
			}
		}

		[RPCCall]
		private static void NewNetworkDeal(NetworkPlayer player, WorkItem item)
		{
			GameSettings.Instance.MyCompany.WorkItems.Add(item);
			item.UpdateDealSender();
		}

		[RPCCall]
		private static void NetworkDealComplete(NetworkPlayer player, uint id, byte[] workData, bool amicably)
		{
			NetworkDeal res;
			if (!TryGet(NetworkManager.Instance.TradeController.Trades.GetOrNull(id) as NetworkDeal, "network deal complete", id, out res))
			{
				return;
			}
			NetworkManager.Instance.TradeController.Trades.Remove(id);
			WorkItem res2;
			if (!TryGet(res.GetWorkItem(), "network deal complete", id, out res2))
			{
				return;
			}
			if (workData != null)
			{
				using (MemoryStream st = new MemoryStream(workData))
				{
					res2.OnNetworkComplete(st);
				}
			}
			res2.NetworkDeal = null;
			res2.guiItem.InitButtons();
			if (amicably)
			{
				if (res.OnComplete > 0f)
				{
					res.ReceiverCompany.MakeTransaction(res.OnComplete, Company.TransactionCategory.Deals, res.Sender.Name);
					res.SenderCompany.MakeTransaction(0f - res.OnComplete, Company.TransactionCategory.Deals, res.Receiver.Name);
				}
				if (res.Royalty > 0f)
				{
					IRoyaltyItem royaltyItem = res2.GetRoyaltyItem();
					SoftwareProduct softwareProduct;
					AddOnProduct addOnProduct;
					SoftwareWorkItem softwareWorkItem;
					if ((softwareProduct = royaltyItem as SoftwareProduct) != null)
					{
						SendAddWorkRoyalty(res.ReceiverCompany.ID, softwareProduct.ID, 0u, false, res.Royalty, MessageTarget.Everyone, 0);
					}
					else if ((addOnProduct = royaltyItem as AddOnProduct) != null)
					{
						SendAddWorkRoyalty(res.ReceiverCompany.ID, addOnProduct.Parent.ID, addOnProduct.ID, false, res.Royalty, MessageTarget.Everyone, 0);
					}
					else if ((softwareWorkItem = royaltyItem as SoftwareWorkItem) != null)
					{
						SendAddWorkRoyalty(res.ReceiverCompany.ID, softwareWorkItem.WorkItemID.ID, 0u, true, res.Royalty, MessageTarget.Everyone, 0);
					}
				}
				NotificationManager.AddNotification(new WorkItemNotification(res2, "NetworkDealComplete".Loc(player.Name, res2.Name), "Server", NotificationManager.NotificationType.Good));
			}
			else
			{
				NotificationManager.AddNotification(new WorkItemNotification(res2, "NetworkDealCancel".Loc(player.Name, res2.Name), "Server", NotificationManager.NotificationType.Neutral));
			}
		}

		[RPCCall]
		private static void NetworkDealCancel(NetworkPlayer player, uint id, bool accepted)
		{
			NetworkDeal res;
			if (!TryGet(NetworkManager.Instance.TradeController.Trades.GetOrNull(id) as NetworkDeal, "network deal cancel", id, out res))
			{
				return;
			}
			NetworkManager.Instance.TradeController.Trades.Remove(id);
			WorkItem res2;
			if (TryGet(res.GetWorkItem(), "network deal cancel", id, out res2))
			{
				res2.SendNetworkDealSync();
				res2.HandleUnitPayout();
				SendNetworkDealComplete(id, res2.GetNetworkCompletionData(accepted), accepted, MessageTarget.Specifically, res.Sender.ID);
				res2.Kill();
				if (accepted)
				{
					NotificationManager.AddNotification("NetworkDealComplete".Loc(player.Name, res2.Name), "Server", NotificationManager.NotificationType.Good);
				}
				else
				{
					NotificationManager.AddNotification("NetworkDealCancel".Loc(player.Name, res2.Name), "Server", NotificationManager.NotificationType.Neutral);
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void NetworkDealSync(NetworkPlayer player, uint id, byte[] dealData)
		{
			NetworkDeal res;
			if (TryGet(NetworkManager.Instance.TradeController.Trades.GetOrNull(id) as NetworkDeal, "network deal sync", id, out res))
			{
				using (MemoryStream st = new MemoryStream(dealData))
				{
					res.GetWorkItem().ReceiveNetworkDealSync(st);
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void VerifyDeal(NetworkPlayer player, uint id, bool check)
		{
			NetworkTrade orNull = NetworkManager.Instance.TradeController.Trades.GetOrNull(id);
			if (orNull != null)
			{
				if (!check)
				{
					NetworkManager.Instance.TradeController.CancelTrade(orNull, false);
				}
			}
			else if (check)
			{
				SendVerifyDeal(id, false, MessageTarget.Specifically, player.ID);
			}
		}

		[RPCCall(OnlyInGame = true)]
		private static void UpdateWorkItem(NetworkPlayer player, uint id, byte[] progressData, float prog)
		{
			WorkItem res;
			if (TryGet(GameSettings.Instance.MyCompany.WorkItems.FirstOrDefault((WorkItem x) => x.WorkItemID != null && x.WorkItemID.ID == id), "update work item", id, out res))
			{
				if (progressData != null)
				{
					res.DeserializeProgressData(progressData);
				}
				res.NetworkProgress = prog;
			}
		}

		[RPCCall(OnlyInGame = true)]
		private static void AddWorkRoyalty(NetworkPlayer player, uint company, uint id, uint addon, bool work, float r)
		{
			Company res;
			if (!TryGet(MarketSimulation.Active.GetCompany(company), "add work royalty", company, out res))
			{
				return;
			}
			SoftwareProduct res3;
			if (work)
			{
				SoftwareWorkItem res2;
				if (TryGet(GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>().FirstOrDefault((SoftwareWorkItem x) => x.WorkItemID != null && x.WorkItemID.ID == id), "add work royalty", id, out res2))
				{
					res2.AddWorkRoyalty(res, r);
				}
			}
			else if (TryGet(MarketSimulation.Active.GetProduct(id, false), "add work royalty", id, out res3))
			{
				AddOnProduct res4;
				if (addon == 0)
				{
					res3.AddWorkRoyalty(res, r);
				}
				else if (TryGet(res3.GetAddon(addon), "add work royalty", id, out res4))
				{
					res4.AddWorkRoyalty(res, r);
				}
			}
		}

		[RPCCall(OnlyInGame = true)]
		private static void BeginTakeover(NetworkPlayer player, uint company, uint taker)
		{
			Company res;
			if (TryGet(MarketSimulation.Active.GetCompany(company), "begin takeover", company, out res))
			{
				if (taker != 0)
				{
					res.BeginTakeover(MarketSimulation.Active.GetCompany(taker), true);
				}
				else
				{
					res.TakeOver = null;
				}
			}
		}

		[RPCCall(OnlyInGame = true, ContinueIfNotOnline = false)]
		private static void UpdateCompanyLogo(NetworkPlayer player, uint c, byte[] logo)
		{
			Company res;
			if (TryGet(MarketSimulation.Active.GetCompany(c), "update logo", c, out res))
			{
				res.Logo = logo;
				LogoController.Instance.DirtyLogo(res);
			}
		}

		[RPCCall(OnlyInGame = true)]
		private static void LeadDesignerSync(NetworkPlayer player, [OptimizeParameter("true")] bool query, [OptimizeParameter("(uint[])null")] uint[] ids)
		{
			if (query)
			{
				if (ids == null)
				{
					List<uint> list = null;
					for (int i = 0; i < GameSettings.Instance.sActorManager.Actors.Count; i++)
					{
						Actor actor = GameSettings.Instance.sActorManager.Actors[i];
						if (actor.employee.NetworkID != 0)
						{
							if (list == null)
							{
								list = new List<uint>();
							}
							list.Add(actor.employee.NetworkID);
						}
					}
					if (list != null)
					{
						SendLeadDesignerSync(false, list.ToArray(), MessageTarget.Specifically, player.ID);
					}
					return;
				}
				for (int j = 0; j < ids.Length; j++)
				{
					Employee emp;
					if ((emp = NetworkManager.Instance.GetNetworkObject(ids[j]) as Employee) != null)
					{
						SendLeadDesigner(0u, emp, GameSettings.Instance.MyCompany.ID, false, MessageTarget.Specifically, player.ID);
					}
				}
			}
			else
			{
				if (ids == null)
				{
					return;
				}
				List<uint> list2 = null;
				for (int k = 0; k < ids.Length; k++)
				{
					if (NetworkManager.Instance.GetNetworkObject(ids[k]) == null)
					{
						if (list2 == null)
						{
							list2 = new List<uint>();
						}
						list2.Add(ids[k]);
					}
				}
				if (list2 != null)
				{
					SendLeadDesignerSync(true, list2.ToArray(), MessageTarget.Specifically, player.ID);
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void PublishingDeal(NetworkPlayer player, PublisherDeal deal)
		{
			if (deal != null)
			{
				deal.Publisher.Publishing.Add(deal);
				deal.ProductTarget.Publishing = deal;
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void PublishingEcoChange(NetworkPlayer player, uint product, bool cut, double amount)
		{
			SoftwareProduct res;
			if (TryGet(MarketSimulation.Active.GetProduct(product, true), "Publisher investment", product, out res) && res.Publishing != null)
			{
				if (cut)
				{
					res.Publishing.Cut += amount;
					res.Publishing.AddRelationshipFromCut(amount);
				}
				else
				{
					res.Publishing.Invested += amount;
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void UpdateCompanyBuildingSign(NetworkPlayer player, uint networkObject, float thickness, float outline, float shadowSize, float shadowX, float shadowY, float shadowOpacity)
		{
			PlayerMap res;
			Furniture res2;
			CompanySignage res3;
			if (TryGet(GameSettings.Instance.sRoomManager.PlayerMaps.GetOrNull(player.ID), "Company sign style update", player.ID, out res) && TryGet(res.Furnitures.GetOrNull(networkObject), "Company sign style update", networkObject, out res2) && TryGet(res2.GetComponent<CompanySignage>(), "Company sign style update", networkObject, out res3) && !res3.JustLogo)
			{
				res3.Thickness = thickness;
				res3.Outline = outline;
				res3.ShadowSize = shadowSize;
				res3.ShadowHor = shadowX;
				res3.ShadowVert = shadowY;
				res3.ShadowOpacity = shadowOpacity;
				res3.Apply();
				res3.Furn.UpdateMaterials();
			}
		}

		[RPCCall(OnlyInGame = true)]
		private static void StartLeadPoach(NetworkPlayer player, uint company, uint employee, float offer)
		{
			SimulatedCompany res;
			Employee res2;
			if (TryGet(MarketSimulation.Active.GetCompany(company) as SimulatedCompany, "Lead poaching", company, out res) && TryGet(NetworkManager.Instance.GetNetworkObject(employee) as Employee, "Lead poaching", employee, out res2))
			{
				ActuallyStartLeadPoach(res, res2, offer);
			}
		}

		public static void ActuallyStartLeadPoach(SimulatedCompany c, Employee a, float offer)
		{
			GameSettings.Instance.MyCompany.LeadBidHappening = true;
			DialogWindow diag = WindowManager.SpawnDialog();
			diag.Show("PlayerLeadPoach".LocColor(c, a, offer.Currency()), false, DialogWindow.DialogType.Question, new KeyValuePair<string, Action>("Yes", delegate
			{
				GameSettings.Instance.MyCompany.MakeTransaction(0f - offer, Company.TransactionCategory.Salaries, true);
				GameSettings.Instance.MyCompany.LeadBidHappening = false;
				if (Options.ShouldAutoSave)
				{
					SaveGameManager.Instance.AutoSave();
				}
				diag.Window.Close();
			}), new KeyValuePair<string, Action>("Details", delegate
			{
				if (a.MyActor != null)
				{
					HUD.Instance.DetailWindow.Show(a.MyActor, true, false);
				}
			}), new KeyValuePair<string, Action>("No", delegate
			{
				GameSettings.Instance.MyCompany.LeadBidHappening = false;
				if (c.LeadDesigner != null && c.LeadDesigner.MyEmployer == c)
				{
					c.LeadDesigner.Dismiss(false);
					c.LeadDesigner.CleanUp();
					c.LeadDesigner.MyEmployer = null;
					bool flag = c.LeadDesigner.Creativity >= 0.85f;
					if (flag)
					{
						MarketSimulation.Active.FreeLeads.Add(c.LeadDesigner);
					}
					MoveLeadDesigner(c.LeadDesigner, null, true, flag);
				}
				c.LeadDesigner = a;
				Actor myActor = a.MyActor;
				if ((object)myActor != null)
				{
					myActor.Fire(true, true);
				}
				a.Employ(c, SDateTime.Now(), false);
				MoveLeadDesigner(c.LeadDesigner, c, true, false);
				if (Options.ShouldAutoSave)
				{
					SaveGameManager.Instance.AutoSave();
				}
				diag.Window.Close();
			}));
		}

		[RPCCall(OnlyInGame = true)]
		private static void UpdateRoundLimit(NetworkPlayer player, float newLimit)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				GameSettings.Instance.RoundLimit = newLimit;
			}
		}

		[RPCCall(OnlyInGame = true)]
		private static void UpdateRoundType(NetworkPlayer player, NetworkLobby.RoundLimitType roundType)
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				GameSettings.Instance.RoundType = roundType;
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void GenerateProductReview(NetworkPlayer player, uint product, uint addon)
		{
			SoftwareProduct res;
			if (!TryGet(MarketSimulation.Active.GetProduct(product, false), "Product review", product, out res))
			{
				return;
			}
			if (addon != 0)
			{
				AddOnProduct res2;
				if (TryGet(res.GetAddon(addon), "product review addon " + addon, product, out res2))
				{
					Newspaper.GenerateProductReview(res2);
				}
			}
			else
			{
				Newspaper.GenerateProductReview(res);
			}
		}

		[RPCCall]
		private static void HostGameTime(NetworkPlayer player, SDateTime time)
		{
			GameData.HostDate = time;
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void UpdateCloudService(NetworkPlayer player, byte provider, [OptimizeParameter("-1f")] float markup, float power)
		{
			Company res;
			if (TryGet(MarketSimulation.Active.GetPlayerCompany(provider), "Update cloud service", provider, out res))
			{
				if (power < 0f)
				{
					if (res.CloudService != null)
					{
						if (provider != NetworkManager.LocalPlayerID)
						{
							ServerGroup serverGroup = GameSettings.Instance.GetServerGroup(res.CloudService.ServerName);
							if (serverGroup != null && serverGroup.Items.Count > 0)
							{
								NotificationManager.AddNotification("CloudServiceClosed".Loc(res.Name), "Server", NotificationManager.NotificationType.Warning);
							}
							GameSettings.Instance.RemoveServer(res.CloudService);
						}
						res.CloudService = null;
					}
				}
				else if (res.CloudService != null)
				{
					ServerGroup serverGroup2 = GameSettings.Instance.GetServerGroup(res.CloudService.ServerName);
					if (markup >= 0f && markup != res.CloudService.Markup)
					{
						if (provider != NetworkManager.LocalPlayerID && serverGroup2.Items.Count > 0 && markup > res.CloudService.Markup)
						{
							NotificationManager.AddNotification("CloudServiceMarkup".Loc(res.Name, NetworkServer.GetCost(res.CloudService.Markup).Currency(), NetworkServer.GetCost(markup).Currency()), "Server", NotificationManager.NotificationType.Warning);
						}
						res.CloudService.Markup = markup;
					}
					res.CloudService.Power = power;
					if (serverGroup2 != null)
					{
						serverGroup2.RefreshPower();
					}
				}
				else
				{
					res.CloudService = new NetworkServer(provider, markup, power);
					if (provider != NetworkManager.LocalPlayerID)
					{
						GameSettings.Instance.AddServer(res.CloudService);
					}
				}
			}
			NetworkMeta.CheckDirty();
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void UpdateCloudUsage(NetworkPlayer player, byte client, byte provider, float usage, bool forHost)
		{
			ServerGroup res2;
			NetworkPlayer res3;
			if (forHost)
			{
				if (NetworkManager.IsPlayerOffline(provider))
				{
					Company res;
					if (usage > 0f && TryGet(MarketSimulation.Active.GetPlayerCompany(provider), "Cloud usage host update", provider, out res))
					{
						res.MakeTransaction((0f - usage * Server.GetISPCost()) / 24f / (float)GameSettings.DaysPerMonth, Company.TransactionCategory.Bills, true, "Internet");
					}
				}
				else
				{
					SendUpdateCloudUsage(client, provider, usage, false, MessageTarget.Specifically, provider);
				}
			}
			else if (TryGet(GameSettings.Instance.GetCloud(), "Cloud usage provider update", 0u, out res2) && TryGet(NetworkManager.GetPlayer(client), "Cloud usage provider update", client, out res3))
			{
				NetworkServerItem networkServerItem = res2.GetItemFor(client);
				if (networkServerItem == null)
				{
					networkServerItem = new NetworkServerItem(res3);
					GameSettings.Instance.RegisterWithServer(res2.Name, networkServerItem);
				}
				networkServerItem.CurrentLoad = usage / 1f.BandwidthFactor(SDateTime.Now());
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void NetworkPrintDealChange(NetworkPlayer player, uint id, [OptimizeParameter("0u")] uint copies)
		{
			NetworkPrintDeal res;
			if (TryGet(GameSettings.Instance.NetworkPrintOrders.GetOrNull(id), "Network print deal", id, out res))
			{
				if (res.Printer == NetworkManager.LocalPlayerID)
				{
					res.SetPhysicalCopies(copies);
				}
				else if (res.Target != null)
				{
					res.Target.PhysicalCopies += copies;
					res.AddPhysicalCopies(copies);
				}
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void CancelNetworkPrintDeal(NetworkPlayer player, uint id)
		{
			NetworkPrintDeal value;
			if (GameSettings.Instance.NetworkPrintOrders.TryGetValue(id, out value))
			{
				GameSettings.Instance.CancelPrintOrder(value, false);
				GameSettings.Instance.NetworkPrintOrders.Remove(id);
				HUD.Instance.distributionWindow.RefreshDeals();
				HUD.Instance.distributionWindow.RefreshOrders();
				NotificationManager.AddNotification(new NotificationMessage("FinishedPrintingJob".LocColor(value), "Box", SDateTime.Now(), NotificationManager.NotificationType.Good));
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void VerifyPrintDeals(NetworkPlayer player, HashSet<uint> ids)
		{
			if (ids == null)
			{
				SendVerifyPrintDeals(GameSettings.Instance.NetworkPrintOrders.List.Where((NetworkPrintDeal n) => n.Client == player.ID || n.Printer == player.ID).Select(delegate(NetworkPrintDeal x)
				{
					x.PurgeBuffer();
					return x.DealID;
				}).ToHashSet(), MessageTarget.Specifically, player.ID);
				return;
			}
			for (int num = 0; num < GameSettings.Instance.NetworkPrintOrders.List.Count; num++)
			{
				NetworkPrintDeal networkPrintDeal = GameSettings.Instance.NetworkPrintOrders.List[num];
				if (networkPrintDeal.Client == player.ID || networkPrintDeal.Printer == player.ID)
				{
					if (!ids.Remove(networkPrintDeal.DealID))
					{
						GameSettings.Instance.NetworkPrintOrders.Remove(networkPrintDeal.DealID);
						GameSettings.Instance.CancelPrintOrder(networkPrintDeal, false);
						HUD.Instance.distributionWindow.RefreshDeals();
						HUD.Instance.distributionWindow.RefreshOrders();
						num--;
					}
					else
					{
						networkPrintDeal.PurgeBuffer();
					}
				}
			}
			foreach (uint id in ids)
			{
				SendCancelNetworkPrintDeal(id, MessageTarget.Specifically, player.ID);
			}
		}

		[RPCCall(ContinueIfNotOnline = false, OnlyInGame = true)]
		private static void ChangePrintMarkup(NetworkPlayer player, uint company, uint swID, uint subID, bool addon, float markup)
		{
			Company res;
			if (!TryGet(MarketSimulation.Active.GetCompany(company), "Change print markup", company, out res))
			{
				return;
			}
			IManufacturable manufacturable = null;
			if (swID != 0)
			{
				SoftwareType softwareType = MarketSimulation.Active.GetSoftwareType(swID);
				manufacturable = ((!addon) ? ((IManufacturable)softwareType.GetCategory(subID)) : ((IManufacturable)softwareType.GetAddon(subID)));
			}
			if (markup >= 0f)
			{
				if (manufacturable == null)
				{
					res.SoftwarePrintMarkup = markup;
				}
				else
				{
					res.HardwarePrintMarkup[manufacturable] = markup;
				}
			}
			else if (manufacturable == null)
			{
				res.SoftwarePrintMarkup = null;
			}
			else
			{
				res.HardwarePrintMarkup.Remove(manufacturable);
			}
		}

		[RPCCall(ContinueIfNotOnline = true, OnlyInGame = true)]
		private static void MarketEventData(NetworkPlayer player, MarketEvent ev, byte targetType, uint eventTarget)
		{
			switch (targetType)
			{
			case 0:
				MarketSimulation.Active.MarketEvents.Add(ev);
				break;
			case 1:
			{
				Company res;
				if (TryGet(MarketSimulation.Active.GetCompany(eventTarget), "company event", eventTarget, out res))
				{
					res.MarketEvents.Add(ev);
				}
				break;
			}
			case 2:
			{
				SoftwareProduct product = MarketSimulation.Active.GetProduct(eventTarget, true, false, true);
				if (product != null)
				{
					product.MarketEvents.Add(ev);
				}
				break;
			}
			}
		}

		[RPCCall(ContinueIfNotOnline = true, OnlyInGame = true)]
		private static void SetAIAutonomy(NetworkPlayer player, uint company, bool value)
		{
			SimulatedCompany res;
			if (TryGet(MarketSimulation.Active.GetCompany(company) as SimulatedCompany, "company autonomy", company, out res))
			{
				res.SetAutonomy(value, false);
			}
		}

		[RPCCall(ContinueIfNotOnline = true, OnlyInGame = true)]
		private static void AddReviews(NetworkPlayer player, uint id, [OptimizeParameter("0u")] uint addon, [OptimizeParameter("0")] int positive, [OptimizeParameter("0")] int negative, SDateTime time)
		{
			SoftwareProduct res;
			if (!TryGet(MarketSimulation.Active.GetProduct(id, false), "Software reviews", id, out res))
			{
				return;
			}
			if (addon != 0)
			{
				AddOnProduct res2;
				if (TryGet(res.GetAddon(addon), "Addon reviews", id, out res2))
				{
					res2.ActuallyAddReviews(positive, negative, time);
				}
			}
			else
			{
				res.ActuallyAddReviews(positive, negative, time);
			}
		}
	}
}
