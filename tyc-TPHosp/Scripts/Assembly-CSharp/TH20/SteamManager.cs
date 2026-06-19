#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Steamworks;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class SteamManager : MustCallDestroy, IOnlineManager
	{
		public static int[] DataVersions = new int[4] { 9, 7, 7, 4 };

		private bool _initialized;

		private bool _loggedOn;

		public static Dictionary<CSteamID, Sprite> SteamAvatarTextures = new Dictionary<CSteamID, Sprite>();

		private Callback<PersonaStateChange_t> _personaStateChange;

		private Callback<SteamServersConnected_t> _steamServerConnected;

		private Callback<SteamServersDisconnected_t> _steamServerDisconnected;

		private Callback<AvatarImageLoaded_t> _avatarImageLoaded;

		private SteamRichPresence _richPresence;

		private DataFileCache _dataFileCache;

		public Action<bool> OnServerConnectionChanged { get; set; }

		public SteamRichPresence RichPresence => _richPresence;

		public DataFileCache DataFiles => _dataFileCache;

		public OnlineManager.Config Config { get; set; }

		public void Initialise()
		{
			_initialized = OSManager.IsInitialised();
			_loggedOn = _initialized && SteamUser.BLoggedOn();
			if (!_loggedOn)
			{
				return;
			}
			_personaStateChange = Callback<PersonaStateChange_t>.Create(OnPersonaStateChange);
			_steamServerConnected = Callback<SteamServersConnected_t>.Create(OnSteamServersConnected);
			_steamServerDisconnected = Callback<SteamServersDisconnected_t>.Create(OnSteamServersDisconnected);
			_avatarImageLoaded = Callback<AvatarImageLoaded_t>.Create(OnAvatarImageLoaded);
			OnlineManager.StorePlayerInfoAndID(GetLocalPlayerID(), OnlineManager.PlayerType.Local);
			int friendCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
			for (int i = 0; i < friendCount; i++)
			{
				CSteamID friendByIndex = SteamFriends.GetFriendByIndex(i, EFriendFlags.k_EFriendFlagImmediate);
				if (CSteamID.Nil != friendByIndex)
				{
					AddNewFriend(friendByIndex, OnlineManager.PlayerType.Friend);
				}
			}
			_richPresence = new SteamRichPresence();
			_dataFileCache = new DataFileCache();
			ConsoleCommandsDatabase.RegisterCommand("OnlineReadAllRemoteFiles", "Gather and log all remote files", "OnlineReadAllRemoteFiles", Debug_OnlineReadAllRemoteFiles);
			ConsoleCommandsDatabase.RegisterCommand("OnlineClearAllRemoteFiles", "Permanently delete all remote files from Steam", "OnlineClearAllRemoteFiles", Debug_OnlineClearAllRemoteFiles);
		}

		public void InitDataFileCache()
		{
			if (_loggedOn)
			{
				if (_dataFileCache == null)
				{
					Logging.Error(LogChannels.Online, "Data file cache is null when we're logged into Steam, something has gone wrong here!");
				}
				else
				{
					_dataFileCache.StartUploadCoroutine();
				}
			}
		}

		public void SetAssetIDs(BiDictionary<int, object> AssetIDs)
		{
			SteamHelpers.AssetIDs = AssetIDs;
		}

		private void OnPersonaStateChange(PersonaStateChange_t personaStateChange)
		{
			CSteamID cSteamID = new CSteamID(personaStateChange.m_ulSteamID);
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(cSteamID);
			if (playerInfo != null)
			{
				OnPersonaChanged(playerInfo, personaStateChange);
			}
			else if ((personaStateChange.m_nChangeFlags & EPersonaChange.k_EPersonaChangeRelationshipChanged) != 0)
			{
				OnlineManager.RemovePlayerInfo(cSteamID);
				bool? flag = OnlineManager.GetFriendPlayerIDs()?.Contains(cSteamID);
				OnlineManager.PlayerType playerType = ((flag.HasValue && flag.Value) ? OnlineManager.PlayerType.Friend : OnlineManager.PlayerType.NonFriend);
				OnlineManager.StorePlayerInfoAndID(cSteamID, playerType);
			}
			OnlineManager.RemovePlayerInfosIf(ShouldRemovePlayerOnPersonaChange);
			OnlineManager.OnPersonaChanged.InvokeSafe(cSteamID);
		}

		public bool OnPersonaChanged(OnlinePlayerInfo playerInfo, PersonaStateChange_t personaStateChange)
		{
			if (playerInfo.PlayerID != personaStateChange.m_ulSteamID)
			{
				return false;
			}
			bool result = false;
			if ((personaStateChange.m_nChangeFlags & EPersonaChange.k_EPersonaChangeName) != 0)
			{
				playerInfo.DisplayName = SteamFriends.GetFriendPersonaName(playerInfo.PlayerID);
				playerInfo.OnlineName = playerInfo.DisplayName;
				result = true;
			}
			if ((personaStateChange.m_nChangeFlags & EPersonaChange.k_EPersonaChangeAvatar) != 0)
			{
				playerInfo.DisplayIcon = GetAvatar(playerInfo.PlayerID);
				result = true;
			}
			if ((personaStateChange.m_nChangeFlags & EPersonaChange.k_EPersonaChangeRelationshipChanged) != 0)
			{
				playerInfo.FriendRelationship = (int)SteamFriends.GetFriendRelationship(playerInfo.PlayerID);
				result = true;
			}
			return result;
		}

		private bool ShouldRemovePlayerOnPersonaChange(OnlinePlayerInfo playerInfo)
		{
			return (byte)(1u & ((playerInfo.FriendRelationship == 3) ? 1u : 0u) & (playerInfo.IsLocalPlayer ? 1u : 0u)) != 0;
		}

		public override void Destroy()
		{
			if (_initialized)
			{
				if (_richPresence != null)
				{
					_richPresence.Destroy();
				}
				if (_dataFileCache != null)
				{
					_dataFileCache.Destroy();
				}
				if (_personaStateChange != null)
				{
					_personaStateChange.Unregister();
				}
				if (_steamServerConnected != null)
				{
					_steamServerConnected.Unregister();
				}
				if (_steamServerDisconnected != null)
				{
					_steamServerDisconnected.Unregister();
				}
				ConsoleCommandsDatabase.UnRegisterCommand("OnlineReadAllRemoteFiles");
				ConsoleCommandsDatabase.UnRegisterCommand("OnlineClearAllRemoteFiles");
			}
			base.Destroy();
		}

		public void Update()
		{
		}

		public void AddNewFriend(CSteamID steamID, OnlineManager.PlayerType playerType = OnlineManager.PlayerType.NonFriend)
		{
			if (OnlineManager.GetPlayerInfoExists(steamID))
			{
				return;
			}
			SteamFriends.RequestUserInformation(steamID, bRequireNameOnly: false);
			OnlineManager.StorePlayerInfoAndID(steamID, playerType);
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(steamID);
			if (playerInfo.PlayerID == (OnlinePlayerID)SteamUser.GetSteamID())
			{
				playerInfo.PlayingGameID = OSManager.AppID;
				playerInfo.IsLocalPlayer = true;
				playerInfo.DisplayName = SteamFriends.GetFriendPersonaName(playerInfo.PlayerID);
				playerInfo.OnlineName = playerInfo.DisplayName;
				playerInfo.DisplayIcon = GetAvatar(playerInfo.PlayerID);
				playerInfo.FriendRelationship = 0;
				return;
			}
			if (SteamFriends.GetFriendGamePlayed(playerInfo.PlayerID, out var pFriendGameInfo))
			{
				playerInfo.PlayingGameID = pFriendGameInfo.m_gameID;
			}
			playerInfo.IsLocalPlayer = false;
			playerInfo.DisplayName = SteamFriends.GetFriendPersonaName(playerInfo.PlayerID);
			playerInfo.DisplayIcon = GetAvatar((CSteamID)playerInfo.PlayerID);
			playerInfo.FriendRelationship = (int)SteamFriends.GetFriendRelationship(playerInfo.PlayerID);
			playerInfo.OnlineName = playerInfo.DisplayName;
		}

		public IEnumerator RequestPlayerInfo(List<OnlinePlayerID> playerIDs)
		{
			for (int i = 0; i < playerIDs.Count; i++)
			{
				AddNewFriend(playerIDs[i]);
			}
			yield break;
		}

		public static bool IsConnectedToSteamServices()
		{
			return OnlineManager.IsInitializedAndLoggedOn();
		}

		public OnlinePlayerID GetLocalPlayerID()
		{
			return SteamUser.GetSteamID();
		}

		public static Sprite GetAvatar(CSteamID steamID)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return OnlineManager.DefaultAvatarSprite;
			}
			if (CSteamID.Nil == steamID)
			{
				return null;
			}
			if (SteamAvatarTextures.TryGetValue(steamID, out var value))
			{
				return value;
			}
			return LoadAvatarSpriteForSteamID(steamID);
		}

		private static Sprite LoadAvatarSpriteForSteamID(CSteamID steamID)
		{
			int largeFriendAvatar = SteamFriends.GetLargeFriendAvatar(steamID);
			if (SteamUtils.GetImageSize(largeFriendAvatar, out var pnWidth, out var pnHeight) && pnWidth != 0 && pnHeight != 0)
			{
				byte[] array = new byte[pnWidth * pnHeight * 4];
				if (SteamUtils.GetImageRGBA(largeFriendAvatar, array, (int)(pnWidth * pnHeight * 4)))
				{
					Texture2D texture2D = new Texture2D((int)pnWidth, (int)pnHeight, TextureFormat.RGBA32, mipChain: false);
					array.FlipVertically((int)(pnWidth * 4), (int)pnHeight);
					texture2D.LoadRawTextureData(array);
					texture2D.Apply();
					Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
					SteamAvatarTextures[steamID] = sprite;
					return sprite;
				}
			}
			return OnlineManager.DefaultAvatarSprite;
		}

		public void ShowUserProfile(OnlinePlayerID targetPlayerID)
		{
		}

		public static uint GetServerRealTime()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return 0u;
			}
			return SteamUtils.GetServerRealTime();
		}

		private void OnSteamServersConnected(SteamServersConnected_t result)
		{
			OnServerConnectionChanged.InvokeSafe(param: true);
		}

		private void OnSteamServersDisconnected(SteamServersDisconnected_t result)
		{
			OnServerConnectionChanged.InvokeSafe(param: false);
		}

		private void OnAvatarImageLoaded(AvatarImageLoaded_t result)
		{
			LoadAvatarSpriteForSteamID(result.m_steamID);
			OnlineManager.OnPersonaChanged.InvokeSafe(result.m_steamID);
		}

		private ConsoleCommandResult Debug_OnlineReadAllRemoteFiles(string[] args)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return ConsoleCommandResult.Failed("FAILED - Steam is not initialised!");
			}
			int fileCount = SteamRemoteStorage.GetFileCount();
			for (int i = 0; i < fileCount; i++)
			{
				int pnFileSizeInBytes;
				string fileNameAndSize = SteamRemoteStorage.GetFileNameAndSize(i, out pnFileSizeInBytes);
				byte[] array = new byte[pnFileSizeInBytes];
				SteamRemoteStorage.FileRead(fileNameAndSize, array, pnFileSizeInBytes);
				Logging.Info(LogChannels.Online, "File {0}({1}) - {2}", fileNameAndSize, pnFileSizeInBytes, Encoding.ASCII.GetString(array));
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_OnlineClearAllRemoteFiles(string[] args)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return ConsoleCommandResult.Failed("FAILED - Steam is not initialised!");
			}
			int fileCount = SteamRemoteStorage.GetFileCount();
			for (int i = 0; i < fileCount; i++)
			{
				SteamRemoteStorage.FileDelete(SteamRemoteStorage.GetFileNameAndSize(i, out var _));
			}
			return ConsoleCommandResult.Succeeded();
		}

		bool IOnlineManager.IsInitialized()
		{
			return _initialized;
		}

		bool IOnlineManager.IsLoggedOn()
		{
			return _loggedOn;
		}

		public Sprite GetAvatar(OnlinePlayerID onlinePlayerID)
		{
			return GetAvatar((CSteamID)onlinePlayerID);
		}

		public uint GetServerTime()
		{
			return GetServerRealTime();
		}

		public bool IsConnected()
		{
			return IsConnectedToSteamServices();
		}

		public bool MustBeLoggedOn()
		{
			return false;
		}

		public void StartLogOn()
		{
			Logging.Error("Calling StartLogOn for Steam but Steam should always be logged on before the app starts so this function does nothing");
		}

		public void UpdateRichPresenceLevelData(in RichPresenceLevelData data)
		{
			_richPresence.UploadRichPresenceData(in data);
		}

		public void ClearRichPresenceLevelData()
		{
			_richPresence.ClearPlayerRichPresence();
		}

		public void SetGameMode(GameMode gameMode)
		{
		}

		public void UpdateRichPresenceDisplayValue()
		{
		}

		public void OnApplicationFocus(bool focus)
		{
		}

		void IOnlineManager.UpdateRichPresenceLevelData(in RichPresenceLevelData data)
		{
			UpdateRichPresenceLevelData(in data);
		}
	}
}
