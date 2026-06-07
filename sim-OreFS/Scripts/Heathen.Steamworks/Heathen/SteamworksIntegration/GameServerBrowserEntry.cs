using System;
using System.Collections.Generic;
using Heathen.SteamworksIntegration.API;
using Steamworks;
using UnityEngine.Events;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public class GameServerBrowserEntry : gameserveritem_t
	{
		public List<StringKeyValuePair> rules;

		public List<ServerPlayerEntry> players;

		public UnityEvent evtDataUpdated = new UnityEvent();

		public string IpAddress => Utilities.IPUintToString(m_NetAdr.GetIP());

		public ushort QueryPort => m_NetAdr.GetQueryPort();

		public ushort ConnectionPort => m_NetAdr.GetConnectionPort();

		public CSteamID SteamId => m_steamID;

		public AppId_t AppId => new AppId_t(m_nAppID);

		public bool UsesPassword => m_bPassword;

		public bool IsSecured => m_bSecure;

		public int PlayerCount => m_nPlayers;

		public int BotPlayerCount => m_nBotPlayers;

		public int MaxPlayerCount => m_nMaxPlayers;

		public int Ping => m_nPing;

		public int Version => m_nServerVersion;

		public DateTime LastPlayed => new DateTime(1970, 1, 1).AddSeconds(m_ulTimeLastPlayed);

		public string Description
		{
			get
			{
				return GetGameDescription();
			}
			set
			{
				SetGameDescription(value);
			}
		}

		public string Tags
		{
			get
			{
				return GetGameTags();
			}
			set
			{
				SetGameTags(value);
			}
		}

		public string Name
		{
			get
			{
				return GetServerName();
			}
			set
			{
				SetServerName(value);
			}
		}

		public string Map
		{
			get
			{
				return GetMap();
			}
			set
			{
				SetMap(value);
			}
		}

		public string Directory
		{
			get
			{
				return GetGameDir();
			}
			set
			{
				SetGameDir(value);
			}
		}

		public GameServerBrowserEntry(gameserveritem_t item)
		{
			evtDataUpdated = new UnityEvent();
			m_bDoNotRefresh = item.m_bDoNotRefresh;
			m_bHadSuccessfulResponse = item.m_bHadSuccessfulResponse;
			m_bPassword = item.m_bPassword;
			m_bSecure = item.m_bSecure;
			m_nAppID = item.m_nAppID;
			m_nBotPlayers = item.m_nBotPlayers;
			m_NetAdr = item.m_NetAdr;
			m_nMaxPlayers = item.m_nMaxPlayers;
			m_nPing = item.m_nPing;
			m_nPlayers = item.m_nPlayers;
			m_nServerVersion = item.m_nServerVersion;
			m_steamID = item.m_steamID;
			m_ulTimeLastPlayed = item.m_ulTimeLastPlayed;
			SetGameDescription(item.GetGameDescription());
			SetGameDir(item.GetGameDir());
			SetGameTags(item.GetGameTags());
			SetMap(item.GetMap());
			SetServerName(item.GetServerName());
			players = new List<ServerPlayerEntry>();
			rules = new List<StringKeyValuePair>();
		}

		public void Update(gameserveritem_t item)
		{
			m_bDoNotRefresh = item.m_bDoNotRefresh;
			m_bHadSuccessfulResponse = item.m_bHadSuccessfulResponse;
			m_bPassword = item.m_bPassword;
			m_bSecure = item.m_bSecure;
			m_nAppID = item.m_nAppID;
			m_nBotPlayers = item.m_nBotPlayers;
			m_NetAdr = item.m_NetAdr;
			m_nMaxPlayers = item.m_nMaxPlayers;
			m_nPing = item.m_nPing;
			m_nPlayers = item.m_nPlayers;
			m_nServerVersion = item.m_nServerVersion;
			m_steamID = item.m_steamID;
			m_ulTimeLastPlayed = item.m_ulTimeLastPlayed;
			SetGameDescription(item.GetGameDescription());
			SetGameDir(item.GetGameDir());
			SetGameTags(item.GetGameTags());
			SetMap(item.GetMap());
			SetServerName(item.GetServerName());
			evtDataUpdated.Invoke();
		}
	}
}
