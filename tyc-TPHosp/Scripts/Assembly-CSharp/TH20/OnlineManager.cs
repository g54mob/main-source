#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using MessagePack;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public static class OnlineManager
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public int MaxCollaborativeProjects = 3;

			public TextAsset CollaborativeProjectNames;

			public Sprite DefaultAvatarSprite;

			public Sprite DefaultAvatarSpritePrime;

			public Sprite DefaultOrganisationSprite;
		}

		public enum PlayerType
		{
			Local = 0,
			Friend = 1,
			NonFriend = 2
		}

		[Union(0, typeof(OnlineChallengeData))]
		public interface IOnlineSerializable
		{
			void PrepareForUpload();

			void RestoreAfterDownload();
		}

		private static IOnlineManager _instance;

		private static App _app;

		private static Dictionary<OnlinePlayerID, OnlinePlayerInfo> _playerInfos = new Dictionary<OnlinePlayerID, OnlinePlayerInfo>();

		private static List<OnlinePlayerID> _friendIDs = new List<OnlinePlayerID>();

		private static List<OnlinePlayerID> _nonFriendIDs = new List<OnlinePlayerID>();

		private static List<OnlinePlayerID> _blockedUserIDs = new List<OnlinePlayerID>();

		private static List<OnlinePlayerID> _mutedUserIDs = new List<OnlinePlayerID>();

		public static Action<OnlinePlayerID> OnPersonaChanged;

		public static BiDictionary<int, object> AssetIDs;

		public static Sprite DefaultAvatarSprite;

		public static Sprite DefaultOrganisationSprite;

		public static bool MultiplayerBlocked = false;

		public static bool OnlineChatBlocked = false;

		public static MonoBehaviour BehaviourToRunCoroutinesOn { get; private set; }

		public static bool APIDisabled => false;

		public static DataFileCache DataFiles => _instance.DataFiles;

		public static void Initialise(Config config, MonoBehaviour behaviourToRunCoroutinesOn, BiDictionary<int, object> assetIDs, App app)
		{
			BehaviourToRunCoroutinesOn = behaviourToRunCoroutinesOn;
			AssetIDs = assetIDs;
			_app = app;
			if (_instance == null)
			{
				_instance = new SteamManager();
				_instance.Initialise();
			}
			_instance.Config = config;
			_instance.InitDataFileCache();
			_instance.SetAssetIDs(assetIDs);
			DefaultAvatarSprite = config.DefaultAvatarSprite;
			DefaultOrganisationSprite = config.DefaultOrganisationSprite;
		}

		public static void Destroy()
		{
			if (_instance == null)
			{
				Logging.Warning("Attempting to destroy the OnlineManager after it has already been destroyed");
				return;
			}
			_instance.Destroy();
			ConsoleCommandsDatabase.UnRegisterCommand("ForceConnection");
			ConsoleCommandsDatabase.UnRegisterCommand("ForceAPIDisabled");
		}

		public static bool IsInitialized()
		{
			if (_instance != null)
			{
				return _instance.IsInitialized();
			}
			return false;
		}

		public static IEnumerator RequestPlayerInfo(List<OnlinePlayerID> ids)
		{
			yield return _instance.RequestPlayerInfo(ids);
		}

		public static bool IsLoggedOn()
		{
			if (_instance != null)
			{
				return _instance.IsLoggedOn();
			}
			return false;
		}

		public static bool RequiresLogOn()
		{
			if (_instance != null && _instance.MustBeLoggedOn())
			{
				return !_instance.IsLoggedOn();
			}
			return false;
		}

		public static void StartLogOn()
		{
			if (_instance != null)
			{
				_instance.StartLogOn();
			}
		}

		public static bool IsInitializedAndLoggedOn()
		{
			if (IsInitialized())
			{
				return IsLoggedOn();
			}
			return false;
		}

		public static bool IsConnected()
		{
			return _instance.IsConnected();
		}

		public static void Update()
		{
		}

		public static Sprite GetAvatar(OnlinePlayerID playerID)
		{
			return _instance.GetAvatar(playerID);
		}

		public static void ShowUserProfile(OnlinePlayerID playerID)
		{
			_instance.ShowUserProfile(playerID);
		}

		public static uint GetServerTime()
		{
			return _instance.GetServerTime();
		}

		public static void PrintDataFiles()
		{
			if (_instance == null)
			{
				UnityEngine.Debug.LogError("No online manager found");
			}
			else if (_instance.DataFiles == null)
			{
				UnityEngine.Debug.LogError("No DataFilesCache found");
			}
			else
			{
				_instance.DataFiles.PrintFiles();
			}
		}

		public static OnlinePlayerID GetLocalPlayerID()
		{
			return _instance.GetLocalPlayerID();
		}

		public static OnlinePlayerInfo GetLocalPlayerInfo()
		{
			return GetPlayerInfo(GetLocalPlayerID());
		}

		public static void RefreshMutedPlayers(ulong[] playerIDs)
		{
			_mutedUserIDs.Clear();
			for (int i = 0; i < playerIDs.Length; i++)
			{
				_mutedUserIDs.Add(new OnlinePlayerID(playerIDs[i]));
			}
		}

		public static void RefreshBlockedPlayers(ulong[] playerIDs)
		{
			_blockedUserIDs.Clear();
			for (int i = 0; i < playerIDs.Length; i++)
			{
				_blockedUserIDs.Add(new OnlinePlayerID(playerIDs[i]));
			}
		}

		public static bool ShouldHideMessageFromUser(OnlinePlayerID playerID)
		{
			if (playerID == GetLocalPlayerID())
			{
				return false;
			}
			if (OnlineChatBlocked)
			{
				return true;
			}
			if (!IsUserMuted(playerID))
			{
				return IsUserBlocked(playerID);
			}
			return true;
		}

		public static bool IsUserMuted(OnlinePlayerID playerID)
		{
			for (int i = 0; i < _mutedUserIDs.Count; i++)
			{
				if (playerID == _mutedUserIDs[i])
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsUserBlocked(OnlinePlayerID playerID)
		{
			return _blockedUserIDs.Contains(playerID);
		}

		public static bool IsUserBlockingInvites(OnlinePlayerID playerID)
		{
			if (MultiplayerBlocked)
			{
				return true;
			}
			OnlinePlayerInfo playerInfo = GetPlayerInfo(playerID);
			if (playerInfo == null)
			{
				return true;
			}
			if (!playerInfo.InvitesBlocked)
			{
				return IsUserBlocked(playerID);
			}
			return true;
		}

		public static OnlinePlayerInfo StorePlayerInfoAndID(OnlinePlayerID playerID, PlayerType playerType)
		{
			if (!_playerInfos.ContainsKey(playerID))
			{
				_playerInfos.Add(playerID, new OnlinePlayerInfo(playerID, playerType == PlayerType.Local));
			}
			SetPlayerTypeForPlayer(playerID, playerType);
			return _playerInfos[playerID];
		}

		public static void SetPlayerTypeForPlayer(OnlinePlayerID playerID, PlayerType playerType)
		{
			switch (playerType)
			{
			case PlayerType.Friend:
				_friendIDs.AddUnique(playerID);
				_nonFriendIDs.Remove(playerID);
				break;
			case PlayerType.NonFriend:
				_nonFriendIDs.AddUnique(playerID);
				_friendIDs.Remove(playerID);
				break;
			}
		}

		public static void ClearOnlineFriendData(bool clearLocalPlayerInfo = false)
		{
			if (clearLocalPlayerInfo)
			{
				_playerInfos.Clear();
			}
			else
			{
				_playerInfos.RemoveAll((KeyValuePair<OnlinePlayerID, OnlinePlayerInfo> info) => info.Key != _instance.GetLocalPlayerID());
			}
			_friendIDs.Clear();
			_nonFriendIDs.Clear();
			_mutedUserIDs.Clear();
			_blockedUserIDs.Clear();
		}

		public static void ClearAllOnlineData()
		{
			ClearOnlineFriendData(clearLocalPlayerInfo: true);
			DataFiles.ClearFiles();
		}

		public static OnlinePlayerInfo GetPlayerInfo(OnlinePlayerID playerID)
		{
			_playerInfos.TryGetValue(playerID, out var value);
			return value;
		}

		public static bool GetPlayerInfoExists(OnlinePlayerID playerID)
		{
			return _playerInfos.ContainsKey(playerID);
		}

		public static bool RemovePlayerInfo(OnlinePlayerID playerID)
		{
			if (_friendIDs.Contains(playerID))
			{
				_friendIDs.Remove(playerID);
			}
			else if (_nonFriendIDs.Contains(playerID))
			{
				_nonFriendIDs.Remove(playerID);
			}
			return _playerInfos.Remove(playerID);
		}

		public static void ClearPlayerInfos()
		{
			_playerInfos.Clear();
		}

		public static void RemovePlayerInfosIf(Func<OnlinePlayerInfo, bool> shouldRemoveCheck)
		{
			List<OnlinePlayerID> list = new List<OnlinePlayerID>();
			foreach (KeyValuePair<OnlinePlayerID, OnlinePlayerInfo> playerInfo in _playerInfos)
			{
				if (shouldRemoveCheck(playerInfo.Value))
				{
					list.Add(playerInfo.Key);
				}
			}
			foreach (OnlinePlayerID item in list)
			{
				RemovePlayerInfo(item);
			}
		}

		public static int GetFriendCount()
		{
			return _friendIDs.Count;
		}

		public static int GetKnownPlayersCount()
		{
			return _playerInfos.Count;
		}

		public static List<OnlinePlayerID> GetKnownPlayerIDs()
		{
			return _playerInfos.Keys.ToList();
		}

		public static List<OnlinePlayerID> GetFriendPlayerIDs()
		{
			return _friendIDs;
		}

		public static List<OnlinePlayerID> GetNonFriendPlayerIDs()
		{
			return _nonFriendIDs;
		}

		public static void RegisterOnServerConnectionChanged(Action<bool> callback)
		{
			IOnlineManager instance = _instance;
			instance.OnServerConnectionChanged = (Action<bool>)Delegate.Combine(instance.OnServerConnectionChanged, callback);
		}

		public static void UnregisterOnServerConnectionChanged(Action<bool> callback)
		{
			IOnlineManager instance = _instance;
			instance.OnServerConnectionChanged = (Action<bool>)Delegate.Remove(instance.OnServerConnectionChanged, callback);
		}

		public static void UpdateRichPresenceLevelData(in RichPresenceLevelData data)
		{
			_instance.UpdateRichPresenceLevelData(in data);
		}

		public static void SetGameMode(GameMode gameMode)
		{
			_instance.SetGameMode(gameMode);
		}

		public static void UpdateRichPresenceDisplayValue(GameMode gameMode)
		{
			_instance.UpdateRichPresenceDisplayValue();
		}

		public static void ClearRichPresenceLevelData()
		{
			_instance.ClearRichPresenceLevelData();
		}

		public static void OnApplicationFocus(bool focus)
		{
			_instance.OnApplicationFocus(focus);
		}
	}
}
