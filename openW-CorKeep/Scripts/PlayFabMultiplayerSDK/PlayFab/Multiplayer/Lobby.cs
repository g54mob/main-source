using System;
using System.Collections.Generic;
using System.Linq;
using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class Lobby
	{
		private static Dictionary<IntPtr, Lobby> lobbyCache = new Dictionary<IntPtr, Lobby>();

		public string Id
		{
			get
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetLobbyId(Handle, out var id));
				return id;
			}
		}

		public object Context
		{
			get
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetCustomContext(Handle, out var customContext));
				if (customContext != null)
				{
					return customContext;
				}
				return null;
			}
			set
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbySetCustomContext(Handle, value));
			}
		}

		public uint MaxMemberCount
		{
			get
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetMaxMemberCount(Handle, out var maxMemberCount));
				return maxMemberCount;
			}
		}

		public LobbyOwnerMigrationPolicy OwnerMigrationPolicy
		{
			get
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetOwnerMigrationPolicy(Handle, out var ownerMigrationPolicy));
				return (LobbyOwnerMigrationPolicy)ownerMigrationPolicy;
			}
		}

		public LobbyAccessPolicy AccessPolicy
		{
			get
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetAccessPolicy(Handle, out var accessPolicy));
				return (LobbyAccessPolicy)accessPolicy;
			}
		}

		public LobbyMembershipLock MembershipLock
		{
			get
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetMembershipLock(Handle, out var lockState));
				return (LobbyMembershipLock)lockState;
			}
		}

		public string ConnectionString
		{
			get
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetConnectionString(Handle, out var connectionString));
				return connectionString;
			}
		}

		internal PFLobbyHandle Handle { get; set; }

		internal Lobby(PFLobbyHandle lobbyHandle)
		{
			Handle = lobbyHandle;
		}

		public bool TryGetOwner(out PFEntityKey owner)
		{
			if (PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetOwner(Handle, out var entityKey)) && entityKey != null)
			{
				PFEntityKey pFEntityKey = new PFEntityKey(entityKey);
				owner = pFEntityKey;
				return true;
			}
			owner = null;
			return false;
		}

		public IList<PFEntityKey> GetMembers()
		{
			List<PFEntityKey> list = new List<PFEntityKey>();
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetMembers(Handle, out var users));
			PlayFab.Multiplayer.InteropWrapper.PFEntityKey[] array = users;
			for (int i = 0; i < array.Length; i++)
			{
				PFEntityKey item = new PFEntityKey(array[i]);
				list.Add(item);
			}
			return list;
		}

		public void Leave(PlayFabAuthenticationContext localUser)
		{
			Leave(new PFEntityKey(localUser));
		}

		public void Leave(PFEntityKey localUser)
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyLeave(Handle, localUser.EntityKey, null));
		}

		public void LeaveAllLocalUsers()
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyLeave(Handle, null, null));
		}

		public IDictionary<string, string> GetSearchProperties()
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetSearchPropertyKeys(Handle, out var keys));
			string[] values = new string[keys.Length];
			int num = 0;
			string[] array = keys;
			foreach (string key in array)
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetSearchProperty(Handle, key, out var value));
				values[num++] = value;
			}
			return Enumerable.Range(0, keys.Length).ToDictionary((int num2) => keys[num2], (int num2) => values[num2]);
		}

		public IDictionary<string, string> GetLobbyProperties()
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetLobbyPropertyKeys(Handle, out var keys));
			string[] values = new string[keys.Length];
			int num = 0;
			string[] array = keys;
			foreach (string key in array)
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetLobbyProperty(Handle, key, out var value));
				values[num++] = value;
			}
			return Enumerable.Range(0, keys.Length).ToDictionary((int num2) => keys[num2], (int num2) => values[num2]);
		}

		public IDictionary<string, string> GetMemberProperties(PFEntityKey member)
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetMemberPropertyKeys(Handle, member.EntityKey, out var keys));
			string[] values = new string[keys.Length];
			int num = 0;
			string[] array = keys;
			foreach (string key in array)
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetMemberProperty(Handle, member.EntityKey, key, out var value));
				values[num++] = value;
			}
			return Enumerable.Range(0, keys.Length).ToDictionary((int num2) => keys[num2], (int num2) => values[num2]);
		}

		public LobbyMemberConnectionStatus GetMemberConnectionStatus(PFEntityKey member)
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetMemberConnectionStatus(Handle, member.EntityKey, out var memberConnectionStatus));
			return (LobbyMemberConnectionStatus)memberConnectionStatus;
		}

		public bool TryGetServer(out PFEntityKey server)
		{
			if (PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetServer(Handle, out var server2)) && server2 != null)
			{
				server = new PFEntityKey(server2);
				return true;
			}
			server = null;
			return false;
		}

		public IDictionary<string, string> GetServerProperties()
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetServerPropertyKeys(Handle, out var keys));
			string[] values = new string[keys.Length];
			int num = 0;
			string[] array = keys;
			foreach (string key in array)
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetServerProperty(Handle, key, out var value));
				values[num++] = value;
			}
			return Enumerable.Range(0, keys.Length).ToDictionary((int num2) => keys[num2], (int num2) => values[num2]);
		}

		public LobbyServerConnectionStatus GetServerConnectionStatus()
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyGetServerConnectionStatus(Handle, out var memberConnectionStatus));
			return (LobbyServerConnectionStatus)memberConnectionStatus;
		}

		public void PostUpdate(PlayFabAuthenticationContext localUser, LobbyDataUpdate lobbyUpdate, IDictionary<string, string> memberProperties)
		{
			PlayFabMultiplayer.SetEntityToken(localUser);
			PostUpdate(new PFEntityKey(localUser), lobbyUpdate, memberProperties);
		}

		public void PostUpdate(PFEntityKey localUser, LobbyDataUpdate lobbyUpdate, IDictionary<string, string> memberProperties)
		{
			PFLobbyMemberDataUpdate memberUpdate = new PFLobbyMemberDataUpdate(memberProperties);
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyPostUpdate(Handle, localUser.EntityKey, lobbyUpdate.Update, memberUpdate, null));
		}

		public void PostUpdate(PlayFabAuthenticationContext localUser, LobbyDataUpdate lobbyUpdate)
		{
			PlayFabMultiplayer.SetEntityToken(localUser);
			PostUpdate(new PFEntityKey(localUser), lobbyUpdate);
		}

		public void PostUpdate(PFEntityKey localUser, LobbyDataUpdate lobbyUpdate)
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyPostUpdate(Handle, localUser.EntityKey, lobbyUpdate.Update, null, null));
		}

		public void PostUpdate(PlayFabAuthenticationContext localUser, IDictionary<string, string> memberProperties)
		{
			PlayFabMultiplayer.SetEntityToken(localUser);
			PostUpdate(new PFEntityKey(localUser), memberProperties);
		}

		public void PostUpdate(PFEntityKey localUser, IDictionary<string, string> memberProperties)
		{
			PFLobbyMemberDataUpdate memberUpdate = new PFLobbyMemberDataUpdate(memberProperties);
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyPostUpdate(Handle, localUser.EntityKey, null, memberUpdate, null));
		}

		public void SendInvite(PlayFabAuthenticationContext sender, PFEntityKey invitee)
		{
			PlayFabMultiplayer.SetEntityToken(sender);
			SendInvite(new PFEntityKey(sender), invitee);
		}

		public void SendInvite(PFEntityKey sender, PFEntityKey invitee)
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbySendInvite(Handle, sender.EntityKey, invitee.EntityKey, null));
		}

		public void AddMember(PlayFabAuthenticationContext localUser, IDictionary<string, string> memberProperties)
		{
			PlayFabMultiplayer.SetEntityToken(localUser);
			AddMember(new PFEntityKey(localUser), memberProperties);
		}

		public void AddMember(PFEntityKey localUser, IDictionary<string, string> memberProperties)
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyAddMember(Handle, localUser.EntityKey, memberProperties, null));
		}

		public void ForceRemoveMember(PFEntityKey targetMember, bool preventRejoin)
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFLobbyForceRemoveMember(Handle, targetMember.EntityKey, preventRejoin, null));
		}

		public void ServerPostUpdate(LobbyDataUpdate lobbyUpdate)
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayerServer.PFLobbyServerPostUpdate(Handle, lobbyUpdate.Update, null));
		}

		public void ServerDeleteLobby()
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayerServer.PFLobbyServerDeleteLobby(Handle, null));
		}

		public void PostUpdateAsServer(LobbyServerDataUpdate lobbyServerUpdate)
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayerServer.PFLobbyServerPostUpdateAsServer(Handle, lobbyServerUpdate.Update, null));
		}

		public void LeaveAsServer()
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayerServer.PFLobbyServerLeaveAsServer(Handle, null));
		}

		internal static Lobby GetLobbyUsingCache(PFLobbyHandle handle)
		{
			if (lobbyCache.TryGetValue(handle.InteropHandleIntPtr, out var value))
			{
				return value;
			}
			value = new Lobby(handle);
			lobbyCache[handle.InteropHandleIntPtr] = value;
			return value;
		}

		internal static void ClearLobbyFromCache(PFLobbyHandle handle)
		{
			if (lobbyCache.ContainsKey(handle.InteropHandleIntPtr))
			{
				lobbyCache.Remove(handle.InteropHandleIntPtr);
			}
		}
	}
}
