using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Multiplayer.Lobbies.Events;
using Assets.Scripts.Storage;
using Assets.Scripts.UI;
using FishNet.Managing;
using FishNet.Serializing;
using Jundroo.Common.Cryptography;
using Jundroo.Common.Platform;
using Jundroo.DevConsole;
using Jundroo.SocialPlatforms;
using Jundroo.SocialPlatforms.Steam;
using Jundroo.SocialPlatforms.Steam.Multiplayer;
using Jundroo.SocialPlatforms.Steam.Multiplayer.Events;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.Lobbies
{
	public class SteamLobbyManager : ILobbyManager, IDisposable
	{
		private enum SteamNetworkingMessageType : byte
		{
			TestMessage = 0,
			ReportServer = 1
		}

		private static class LobbyDataKeys
		{
			public const string LobbyOwner = "LobbyOwner";

			public const string MaxCraftPartCount = "MaxCraftPartCount";

			public const string PasswordProtected = "PasswordProtected";

			public const string PingLocation = "PingLocation";

			public const string ReportCount = "ReportCount";

			public const string ServerName = "ServerName";
		}

		private const string SteamPlayerBansFileName = "SteamPlayerBans.xml";

		private static List<(ulong SteamUserId, string SteamUserName)> _bannedUsers;

		private static List<ulong> _kickedUsers;

		private bool _disposed;

		private string _hostServerName;

		private bool _joinLobbyRequestAutoLoadScene;

		private List<SteamNetworkingMessage> _messageBuffer;

		private string _serverPasswordHash;

		private ISteamPlatform _steam;

		private ISteamPlatformMultiplayer _steamMP;

		private HashSet<ulong> _usersReportingCurrentLobby;

		public static IReadOnlyList<(ulong SteamUserId, string SteamUserName)> BannedUsers => _bannedUsers;

		public static IReadOnlyList<ulong> KickedUsers => _kickedUsers;

		public bool IsInLobby => LobbyId != 0;

		public bool IsLobbyOwner => LobbyOwnerId == LocalUserId;

		public ulong LobbyId { get; private set; }

		public ulong LobbyOwnerId { get; private set; }

		public ulong LocalUserId { get; private set; }

		public string ServerPasswordHash => _serverPasswordHash;

		public event EventHandler<EventArgs> LobbyCreated;

		public event EventHandler<SteamLobbyJoinedEventArgs> LobbyJoined;

		public event EventHandler<EventArgs> LobbyLeft;

		public event EventHandler<LobbyListEventArgs> LobbyListReceived;

		public event EventHandler<EventArgs> LobbyOwnerChanged;

		static SteamLobbyManager()
		{
			_bannedUsers = new List<(ulong, string)>();
			_kickedUsers = new List<ulong>();
			LoadBannedUsers();
		}

		public SteamLobbyManager()
		{
			_steam = SocialExt.Steam;
			_steamMP = _steam.Multiplayer;
			LocalUserId = _steam.LocalUserId;
			_messageBuffer = new List<SteamNetworkingMessage>();
			_usersReportingCurrentLobby = new HashSet<ulong>();
			_steamMP.CreateLobbyResult += OnCreateLobby;
			_steamMP.JoinLobbyResult += OnJoinLobby;
			_steamMP.LobbyChatMessageReceived += OnChatMessageReceived;
			_steamMP.LobbyChatUpdate += OnChatUpdate;
			_steamMP.LobbyDataUpdate += OnLobbyDataUpdate;
			_steamMP.LobbyMemberDataUpdate += OnLobbyMemberDataUpdate;
			_steamMP.RequestLobbyListResult += OnLobbyListRequest;
			_steamMP.JoinLobbyRequested += OnJoinLobbyRequested;
			_steamMP.NetworkingMessagesSessionRequest += OnNetworkingMessagesSessionRequest;
			if (Device.IsDebugBuild)
			{
				DevConsoleApi.RegisterCommand("STEAM_TestMessage", delegate(ulong user, string msg)
				{
					SendTestMessage(user, msg);
				});
				DevConsoleApi.RegisterCommand("STEAM_ReportServer", delegate(ulong serverOwnerSteamId)
				{
					ReportServer(serverOwnerSteamId);
				});
			}
		}

		public void CreateLobby(LobbyType type, int maxMembers, string serverName, string password)
		{
			LeaveLobby();
			_hostServerName = serverName;
			_serverPasswordHash = password;
			_steamMP.CreateLobby((Jundroo.SocialPlatforms.Steam.Multiplayer.LobbyType)type, maxMembers);
		}

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				_steamMP.CreateLobbyResult -= OnCreateLobby;
				_steamMP.JoinLobbyResult -= OnJoinLobby;
				_steamMP.LobbyChatMessageReceived -= OnChatMessageReceived;
				_steamMP.LobbyChatUpdate -= OnChatUpdate;
				_steamMP.LobbyDataUpdate -= OnLobbyDataUpdate;
				_steamMP.LobbyMemberDataUpdate -= OnLobbyMemberDataUpdate;
				_steamMP.RequestLobbyListResult -= OnLobbyListRequest;
				_steamMP.JoinLobbyRequested -= OnJoinLobbyRequested;
				_steamMP.NetworkingMessagesSessionRequest -= OnNetworkingMessagesSessionRequest;
				if (Device.IsDebugBuild)
				{
					DevConsoleApi.UnregisterCommand("STEAM_TestMessage");
					DevConsoleApi.UnregisterCommand("STEAM_ReportServer");
				}
			}
		}

		public ulong? GetCommandLineLobbyId()
		{
			string[] commandLineArgs = System.Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
				if (commandLineArgs[i] == "+connect_lobby" && commandLineArgs.Length > i + 1 && ulong.TryParse(commandLineArgs[i + 1], out var result))
				{
					return result;
				}
			}
			return null;
		}

		public void GetLobbyList(int maxResults, bool includeWorldwideLobbies, string lobbyNameFilter)
		{
			LobbyFilters lobbyFilters = new LobbyFilters();
			lobbyFilters.MaxResults = maxResults;
			lobbyFilters.Distance = ((!includeWorldwideLobbies) ? LobbyDistanceFilterType.Default : LobbyDistanceFilterType.Worldwide);
			if (!string.IsNullOrWhiteSpace(lobbyNameFilter))
			{
				lobbyFilters.StringFilters.Add(("ServerName", lobbyNameFilter, LobbyComparisonType.Equal));
			}
			if (!Device.IsUnityEditor)
			{
				lobbyFilters.NumericalFilters.Add(("ReportCount", 7, LobbyComparisonType.LessThan));
			}
			_steamMP.RequestLobbyList(lobbyFilters);
		}

		public void JoinLobby(ulong lobbyId, bool autoLoadScene, string password)
		{
			LeaveLobby();
			_joinLobbyRequestAutoLoadScene = autoLoadScene;
			_serverPasswordHash = password;
			_steamMP.JoinLobby(lobbyId);
		}

		public void LeaveLobby()
		{
			if (LobbyId != 0L)
			{
				_steamMP.LeaveLobby(LobbyId);
				ClearCurrentLobbyData();
				this.LobbyLeft?.Invoke(this, EventArgs.Empty);
			}
		}

		public void OnLobbySettingsChanged()
		{
			if (!_disposed && LobbyId != 0L)
			{
				_steamMP.SetLobbyData(LobbyId, "MaxCraftPartCount", (FlightSceneScript.Instance?.FlightSceneNetwork?.ServerMaxPartCount).GetValueOrDefault().ToString());
			}
		}

		public void OnPlayerBanned(ulong steamId, string steamUserName)
		{
			if (steamId != 0L)
			{
				_bannedUsers.Add((steamId, steamUserName));
				SaveBannedUsers();
			}
		}

		public void OnPlayerKicked(ulong steamId)
		{
			if (steamId != 0L)
			{
				_kickedUsers.Add(steamId);
			}
		}

		public void OpenInviteFriendsDialog()
		{
			if (LobbyId == 0L)
			{
				Debug.LogError("Cannot open the invite friends dialog when not in a lobby.");
			}
			else
			{
				_steamMP.ActivateGameOverlayInviteDialog(LobbyId);
			}
		}

		public void ReportServer(ulong serverOwnerSteamId)
		{
			using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = WriterPool.Retrieve().AsDisposable();
			pooledWriterDisposableWrapper.Writer.WriteEnum(SteamNetworkingMessageType.ReportServer);
			ArraySegment<byte> arraySegment = pooledWriterDisposableWrapper.Writer.GetArraySegment();
			SendMessageResult sendMessageResult = _steamMP.SendMessageToUser(serverOwnerSteamId, arraySegment, SteamNetworkingSendFlags.ReliableNoNagle, 0);
			if (sendMessageResult != SendMessageResult.Success)
			{
				Debug.LogError($"Failed to send Steam networking report server message to user {serverOwnerSteamId}. Result: {sendMessageResult}");
			}
		}

		public void SendTestMessage(ulong steamUserId, string message)
		{
			using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = WriterPool.Retrieve().AsDisposable();
			pooledWriterDisposableWrapper.Writer.WriteEnum(SteamNetworkingMessageType.TestMessage);
			pooledWriterDisposableWrapper.Writer.WriteString(message);
			ArraySegment<byte> arraySegment = pooledWriterDisposableWrapper.Writer.GetArraySegment();
			SendMessageResult sendMessageResult = _steamMP.SendMessageToUser(steamUserId, arraySegment, SteamNetworkingSendFlags.ReliableNoNagle, 0);
			if (sendMessageResult != SendMessageResult.Success)
			{
				Debug.LogError($"Failed to send Steam networking test message to user {steamUserId}. Result: {sendMessageResult}");
			}
		}

		public void Update()
		{
			if (_steamMP.ReceiveMessagesOnChannel(0, 8, _messageBuffer) <= 0)
			{
				return;
			}
			foreach (SteamNetworkingMessage item in _messageBuffer)
			{
				try
				{
					ProcessSteamNetworkingMessage(item);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			_messageBuffer.Clear();
		}

		private static void LoadBannedUsers()
		{
			string path = GameData.GetPath("SteamPlayerBans.xml");
			try
			{
				XDocument xDocument = GameData.LoadXml(path, throwFileNotFoundException: false);
				if (xDocument == null)
				{
					return;
				}
				foreach (XElement item2 in xDocument.Root.Elements("Ban"))
				{
					ulong valueOrDefault = ((ulong?)item2.Attribute("SteamUserId")).GetValueOrDefault();
					string item = ((string)item2.Attribute("SteamUserName")) ?? string.Empty;
					if (valueOrDefault != 0L)
					{
						_bannedUsers.Add((valueOrDefault, item));
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogError("Unable to load SteamPlayerBans.xml from '" + path + "'.");
				Debug.LogException(exception);
			}
		}

		private static void SaveBannedUsers()
		{
			XDocument xDocument = new XDocument(new XElement("SteamPlayerBans"));
			foreach (var bannedUser in _bannedUsers)
			{
				if (bannedUser.SteamUserId != 0L)
				{
					xDocument.Root.Add(new XElement("Ban", new XAttribute("SteamUserId", bannedUser.SteamUserId), new XAttribute("SteamUserName", bannedUser.SteamUserName)));
				}
			}
			try
			{
				GameData.SaveXml(xDocument, GameData.GetPath("SteamPlayerBans.xml"));
			}
			catch (Exception exception)
			{
				Debug.LogError("Unable to save SteamPlayerBans.xml.");
				Debug.LogException(exception);
			}
		}

		private void ClearCurrentLobbyData()
		{
			LobbyId = 0uL;
			LobbyOwnerId = 0uL;
			_usersReportingCurrentLobby.Clear();
			_hostServerName = null;
			_serverPasswordHash = null;
		}

		private bool IsServerReportedByAdmin(ulong reportingUserId)
		{
			if (reportingUserId == 76561198232725984L || reportingUserId == 76561198059940024L || reportingUserId == 76561198271223340L || reportingUserId == 76561198850434638L || reportingUserId == 76561198002595541L)
			{
				return true;
			}
			return false;
		}

		private void OnChatMessageReceived(object sender, LobbyChatMessageEventArgs e)
		{
		}

		private void OnChatUpdate(object sender, LobbyChatUpdateEventArgs e)
		{
			if (e.Type == ChatMemberStateChangeType.Entered && e.ChangedUserId != LocalUserId)
			{
				_steamMP.SetPlayedWith(e.ChangedUserId);
			}
		}

		private void OnCreateLobby(object sender, CreateLobbyResultEventArgs e)
		{
			if (e.Result != CreateLobbyResultType.Ok)
			{
				ClearCurrentLobbyData();
				Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, $"Failed to create a Steam multiplayer lobby. Result: {e.Result}");
				return;
			}
			LobbyId = e.LobbyId;
			LobbyOwnerId = LocalUserId;
			_serverPasswordHash = (string.IsNullOrEmpty(_serverPasswordHash) ? null : Hash.SHA512(_serverPasswordHash, e.LobbyId.ToString()));
			_steamMP.SetLobbyData(e.LobbyId, "ServerName", string.IsNullOrWhiteSpace(_hostServerName) ? LocalUserId.ToString() : _hostServerName);
			_steamMP.SetLobbyData(e.LobbyId, "LobbyOwner", LobbyOwnerId.ToString());
			_steamMP.SetLobbyData(e.LobbyId, "PingLocation", _steam.Multiplayer.GetLocalPingLocation());
			_steamMP.SetLobbyData(e.LobbyId, "MaxCraftPartCount", "0");
			_steamMP.SetLobbyData(e.LobbyId, "ReportCount", "0");
			_steamMP.SetLobbyData(e.LobbyId, "PasswordProtected", (!string.IsNullOrEmpty(_serverPasswordHash)).ToString());
			this.LobbyCreated?.Invoke(this, EventArgs.Empty);
		}

		private void OnJoinLobby(object sender, JoinLobbyResultEventArgs e)
		{
			if (e.Result != JoinLobbyResultType.Ok)
			{
				ClearCurrentLobbyData();
				Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, "Failed to join the Steam multiplayer lobby.");
				this.LobbyJoined?.Invoke(this, new SteamLobbyJoinedEventArgs(e.LobbyId, 0uL, _joinLobbyRequestAutoLoadScene, success: false));
				return;
			}
			LobbyId = e.LobbyId;
			LobbyOwnerId = _steamMP.GetLobbyOwner(e.LobbyId);
			_serverPasswordHash = (string.IsNullOrEmpty(_serverPasswordHash) ? null : Hash.SHA512(_serverPasswordHash, e.LobbyId.ToString()));
			this.LobbyJoined?.Invoke(this, new SteamLobbyJoinedEventArgs(LobbyId, LobbyOwnerId, _joinLobbyRequestAutoLoadScene, success: true));
			foreach (LobbyMemberInfo lobbyMember in _steamMP.GetLobbyMembers(e.LobbyId))
			{
				if (lobbyMember.UserId != LocalUserId)
				{
					_steamMP.SetPlayedWith(lobbyMember.UserId);
				}
			}
		}

		private void OnJoinLobbyRequested(object sender, JoinLobbyRequestedEventArgs e)
		{
			JoinLobby(e.LobbyId, autoLoadScene: true, null);
		}

		private void OnLobbyDataUpdate(object sender, LobbyDataUpdateEventArgs e)
		{
			if (!e.Success)
			{
				Debug.LogError("A Steam lobby data update failed. ");
				return;
			}
			if (LobbyId != e.LobbyId)
			{
				Debug.LogError($"Received a Steam lobby data update for a lobby the user is not currently in. CurrentLobbyId={LobbyId}, UpdateLobbyId={e.LobbyId}");
				return;
			}
			ulong lobbyOwner = _steamMP.GetLobbyOwner(e.LobbyId);
			if (lobbyOwner != LobbyOwnerId)
			{
				LobbyOwnerId = lobbyOwner;
				this.LobbyOwnerChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		private void OnLobbyListRequest(object sender, RequestLobbyListResultEventArgs e)
		{
			List<LobbyData> list = new List<LobbyData>(e.LobbyIds.Count);
			if (!e.Success)
			{
				return;
			}
			foreach (ulong lobbyId in e.LobbyIds)
			{
				try
				{
					string lobbyData = _steamMP.GetLobbyData(lobbyId, "ServerName");
					string lobbyData2 = _steamMP.GetLobbyData(lobbyId, "LobbyOwner");
					string lobbyData3 = _steamMP.GetLobbyData(lobbyId, "PingLocation");
					string lobbyData4 = _steamMP.GetLobbyData(lobbyId, "MaxCraftPartCount");
					string lobbyData5 = _steamMP.GetLobbyData(lobbyId, "ReportCount");
					string lobbyData6 = _steamMP.GetLobbyData(lobbyId, "PasswordProtected");
					int.TryParse(lobbyData4, out var result);
					int.TryParse(lobbyData5, out var result2);
					ulong.TryParse(lobbyData2, out var result3);
					bool.TryParse(lobbyData6, out var result4);
					int lobbyMemberLimit = _steamMP.GetLobbyMemberLimit(lobbyId);
					int numLobbyMembers = _steamMP.GetNumLobbyMembers(lobbyId);
					int latency = _steamMP.EstimatePingTimeFromLocalHost(lobbyData3);
					LobbyData item = new LobbyData(lobbyId, result3, lobbyData, latency, numLobbyMembers, lobbyMemberLimit, result, result2, result4);
					list.Add(item);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError($"Failed to retrieve data for Steam lobby {lobbyId}.");
				}
			}
			try
			{
				this.LobbyListReceived?.Invoke(this, new LobbyListEventArgs(list, e.Success));
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
		}

		private void OnLobbyMemberDataUpdate(object sender, LobbyMemberDataUpdateEventArgs e)
		{
		}

		private void OnNetworkingMessagesSessionRequest(object sender, NetworkingMessagesSessionRequestEventArgs e)
		{
			_steamMP.AcceptSessionWithUser(e.SteamId);
		}

		private void OnServerReportReceived(ulong reportingUserId)
		{
			if (IsInLobby && IsLobbyOwner && _usersReportingCurrentLobby.Add(reportingUserId))
			{
				int result;
				int num = (int.TryParse(_steamMP.GetLobbyData(LobbyId, "ReportCount"), out result) ? result : 0);
				int num2 = num;
				int num3 = ((!IsServerReportedByAdmin(reportingUserId)) ? 1 : 100);
				_steamMP.SetLobbyData(LobbyId, "ReportCount", (num2 + num3).ToString());
			}
		}

		private void ProcessSteamNetworkingMessage(SteamNetworkingMessage message)
		{
			NetworkManager networkManager = Game.Instance.NetworkGameManager?.NetworkManager;
			if (networkManager == null)
			{
				Debug.LogError("Cannot process Steam networking message when the network manager is not available.");
				return;
			}
			using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = ReaderPool.Retrieve(message.Data, networkManager).AsDisposable();
			SteamNetworkingMessageType steamNetworkingMessageType = pooledReaderDisposableWrapper.Reader.ReadEnum<SteamNetworkingMessageType>();
			switch (steamNetworkingMessageType)
			{
			case SteamNetworkingMessageType.TestMessage:
			{
				string arg = pooledReaderDisposableWrapper.Reader.ReadStringAllocated();
				Debug.Log($"Received Steam Networking test message from {message.SenderSteamId}: {arg}");
				break;
			}
			case SteamNetworkingMessageType.ReportServer:
				OnServerReportReceived(message.SenderSteamId);
				break;
			default:
				Debug.LogError($"Received unknown Steam networking message type '{steamNetworkingMessageType}' from {message.SenderSteamId}");
				break;
			}
		}
	}
}
