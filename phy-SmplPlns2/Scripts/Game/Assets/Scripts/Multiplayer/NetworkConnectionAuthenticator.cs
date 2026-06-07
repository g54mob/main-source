using System;
using System.Linq;
using Assets.Scripts.Multiplayer.Lobbies;
using Assets.Scripts.Scenes;
using FishNet.Authenticating;
using FishNet.Broadcast;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Transporting;
using FishNet.Transporting.Multipass;
using FishySteamworks;
using Jundroo.SocialPlatforms;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class NetworkConnectionAuthenticator : Authenticator
	{
		public enum ConnectionFailedType
		{
			Unknown = 0,
			VersionMismatch = 1,
			Kicked = 2,
			Banned = 3,
			InvalidPassword = 4
		}

		[Serializable]
		public struct ClientConnectionData : IBroadcast
		{
			public string PasswordHash { get; set; }

			public ulong SteamId { get; set; }

			public string UserName { get; set; }

			public SerializableVersion Version { get; set; }
		}

		[Serializable]
		public struct ConnectionResponseData : IBroadcast
		{
			public ConnectionFailedType ConnectionFailedType { get; set; }

			public bool ConnectionSuccessful { get; set; }

			public SerializableVersion ServerVersion { get; set; }
		}

		[Serializable]
		public struct SerializableVersion
		{
			public int Build;

			public int Major;

			public int Minor;

			public int Revision;

			public static explicit operator SerializableVersion(Version version)
			{
				return new SerializableVersion
				{
					Major = version.Major,
					Minor = version.Minor,
					Build = version.Build,
					Revision = version.Revision
				};
			}

			public static explicit operator Version(SerializableVersion version)
			{
				return new Version(version.Major, version.Minor, version.Build, version.Revision);
			}
		}

		public override event Action<NetworkConnection, bool> OnAuthenticationResult;

		public override void InitializeOnce(NetworkManager networkManager)
		{
			base.InitializeOnce(networkManager);
			base.NetworkManager.ServerManager.RegisterBroadcast<ClientConnectionData>(OnClientConnectionDataReceived, requireAuthentication: false);
			base.NetworkManager.ClientManager.RegisterBroadcast<ConnectionResponseData>(OnServerConnectionResponseReceived);
			base.NetworkManager.ClientManager.OnClientConnectionState += OnClientConnectionStateChanged;
			base.NetworkManager.ClientManager.OnAuthenticated += OnClientAuthenticated;
		}

		private ClientConnectionData CreateClientConnectionData()
		{
			SteamLobbyManager steamLobbyManager = Game.Instance.NetworkGameManager.SteamLobbyManager;
			return new ClientConnectionData
			{
				UserName = GetLocalUserName(),
				SteamId = (steamLobbyManager?.LocalUserId ?? 0),
				Version = (SerializableVersion)Game.Version,
				PasswordHash = steamLobbyManager?.ServerPasswordHash
			};
		}

		private string GetLocalUserName()
		{
			string text = SocialExt.LocalUser?.userName;
			if (string.IsNullOrWhiteSpace(text))
			{
				text = Game.Instance.Settings.App.UserName;
				if (string.IsNullOrWhiteSpace(text))
				{
					text = string.Empty;
				}
			}
			return text;
		}

		private void OnClientAuthenticated()
		{
			if (base.NetworkManager.ServerManager.Started)
			{
				base.NetworkManager.ClientManager.Connection.CustomData = CreateClientConnectionData();
			}
		}

		private void OnClientConnectionDataReceived(NetworkConnection connection, ClientConnectionData data, Channel channel)
		{
			if (connection.IsAuthenticated)
			{
				Debug.LogError("A connection authentication attempt was received from a client that was already authenticated.");
				connection.Disconnect(immediately: true);
				return;
			}
			bool flag = base.NetworkManager.TransportManager.Transport is global::FishySteamworks.FishySteamworks;
			if (!flag && base.NetworkManager.TransportManager.Transport is Multipass multipass)
			{
				flag = multipass.GetTransport(connection.TransportIndex) is global::FishySteamworks.FishySteamworks;
			}
			if (!flag)
			{
				Debug.LogWarning("Connecting via non-steam transport, SteamID authentication not avaialable");
			}
			else
			{
				if (!ulong.TryParse(connection.GetAddress(), out var result))
				{
					Debug.LogError("A connection authentication attempt was rejected becuase the connection address was not valid");
					connection.Disconnect(immediately: true);
					return;
				}
				if (result != data.SteamId)
				{
					Debug.LogError($"A connection attempted to authenticate as SteamID {data.SteamId} but the underlying connection was to SteamID {result}. Liar liar?");
					connection.Disconnect(immediately: true);
					data.SteamId = result;
					return;
				}
				data.SteamId = result;
			}
			bool flag2 = true;
			Version version = (Version)data.Version;
			if (version.Major != Game.Version.Major || version.Minor != Game.Version.Minor || version.Build != Game.Version.Build)
			{
				Debug.LogError($"A connection authentication attempt was received from a client with a different game version. Server version: {Game.Version}, Client Version: {version}.");
				SendServerConnectionResponse(connection, ConnectionFailedType.VersionMismatch);
				flag2 = false;
			}
			else if (SteamLobbyManager.KickedUsers.Contains(data.SteamId))
			{
				Debug.LogError($"A connection authentication attempt was received from a client that has been kicked from this server. Steam ID: {data.SteamId}, UserName: {data.UserName}.");
				SendServerConnectionResponse(connection, ConnectionFailedType.Kicked);
				flag2 = false;
			}
			else if (SteamLobbyManager.BannedUsers.Any(((ulong SteamUserId, string SteamUserName) x) => x.SteamUserId == data.SteamId))
			{
				Debug.LogError($"A connection authentication attempt was received from a client that has been banned from this server. Steam ID: {data.SteamId}, UserName: {data.UserName}.");
				SendServerConnectionResponse(connection, ConnectionFailedType.Banned);
				flag2 = false;
			}
			else
			{
				SteamLobbyManager steamLobbyManager = Game.Instance.NetworkGameManager.SteamLobbyManager;
				if (steamLobbyManager != null && !string.IsNullOrEmpty(steamLobbyManager.ServerPasswordHash) && steamLobbyManager.ServerPasswordHash != data.PasswordHash)
				{
					Debug.LogError($"A connection authentication attempt was received from a client with an invalid server password. Steam ID: {data.SteamId}, UserName: {data.UserName}.");
					SendServerConnectionResponse(connection, ConnectionFailedType.InvalidPassword);
					flag2 = false;
				}
			}
			if (flag2)
			{
				connection.CustomData = data;
				SendServerConnectionResponse(connection, null);
			}
			OnAuthenticationResult(connection, flag2);
		}

		private void OnClientConnectionStateChanged(ClientConnectionStateArgs args)
		{
			if (args.ConnectionState == LocalConnectionState.Started && !base.NetworkManager.ServerManager.Started)
			{
				base.NetworkManager.ClientManager.Broadcast(CreateClientConnectionData());
			}
		}

		private void OnServerConnectionResponseReceived(ConnectionResponseData data, Channel channel)
		{
			if (data.ConnectionSuccessful)
			{
				Debug.Log("The connection authentication attempt with the server was successful");
				return;
			}
			SceneManager sceneManager = Game.Instance.SceneManager;
			Action<string> action = delegate(string message)
			{
				if (sceneManager.SceneTransitionInProgress)
				{
					sceneManager.QueuePostSceneLoadAction(delegate
					{
						Game.Instance.UserInterface.CreateMessageDialog(message, "Connection Failed");
					});
				}
				else
				{
					Game.Instance.UserInterface.CreateMessageDialog(message, "Connection Failed");
				}
			};
			if (data.ConnectionFailedType == ConnectionFailedType.VersionMismatch)
			{
				Version version = (Version)data.ServerVersion;
				Version version2 = Game.Version;
				Debug.LogError($"The connection authentication attempt with the server failed due to a version mismatch. Server version: {version}, Client version: {Game.Version}.");
				action("Unable to connect to the game server. The server is running " + ((version > version2) ? "a newer" : "an older") + " version of the game. " + System.Environment.NewLine + $"Server Version: {version}" + System.Environment.NewLine + $"Your Version: {version2}");
			}
			else if (data.ConnectionFailedType == ConnectionFailedType.Kicked)
			{
				Debug.LogError("The connection authentication attempt with the server failed because the user has recently been kicked from this server.");
				action("You have been kicked from this server and cannot reconnect.");
			}
			else if (data.ConnectionFailedType == ConnectionFailedType.Banned)
			{
				Debug.LogError("The connection authentication attempt with the server failed because the user has been banned from this server.");
				action("You have been banned from this server and may not connect.");
			}
			else if (data.ConnectionFailedType == ConnectionFailedType.InvalidPassword)
			{
				Debug.LogError("The connection authentication attempt with the server failed because the server password was invalid.");
				action("The server password you entered is incorrect.");
			}
			else
			{
				Debug.LogError("The connection authentication attempt with the server failed due to an unknown reason.");
				action("Failed to connect to game server");
			}
		}

		private void SendServerConnectionResponse(NetworkConnection connection, ConnectionFailedType? failureType)
		{
			ConnectionResponseData message = new ConnectionResponseData
			{
				ConnectionSuccessful = !failureType.HasValue,
				ConnectionFailedType = failureType.GetValueOrDefault(),
				ServerVersion = (SerializableVersion)Game.Version
			};
			base.NetworkManager.ServerManager.Broadcast(connection, message, requireAuthenticated: false);
		}
	}
}
