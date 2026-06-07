using System;
using System.Collections.Generic;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	public class GameServerBrowserManager : MonoBehaviour
	{
		[Serializable]
		public class ResultsEvent : UnityEvent<ResultData>
		{
		}

		[Serializable]
		public class ResultData
		{
			public GameServerSearchType type;

			public List<GameServerBrowserEntery> entries;

			public bool hasIOFailure;

			public ResultData(GameServerSearchType type, List<GameServerBrowserEntery> entries, bool IOFailure)
			{
				this.type = type;
				this.entries = entries;
				hasIOFailure = IOFailure;
			}
		}

		private class Search
		{
			public HServerListRequest hRequest;

			public Action<List<GameServerBrowserEntery>, bool> callback;

			public Action clear;

			public ISteamMatchmakingServerListResponse m_ServerListResponse;

			public Search()
			{
				m_ServerListResponse = new ISteamMatchmakingServerListResponse(OnServerResponded, OnServerFailedToRespond, OnRefreshComplete);
			}

			private void OnServerResponded(HServerListRequest hRequest, int iServer)
			{
				HServerListRequest hServerListRequest = hRequest;
				Debug.Log("OnServerResponded: " + hServerListRequest.ToString() + " - " + iServer);
			}

			private void OnServerFailedToRespond(HServerListRequest hRequest, int iServer)
			{
				HServerListRequest hServerListRequest = hRequest;
				Debug.Log("OnServerFailedToRespond: " + hServerListRequest.ToString() + " - " + iServer);
				if (callback != null)
				{
					callback(null, arg2: true);
				}
			}

			private void OnRefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response)
			{
				HServerListRequest hServerListRequest = hRequest;
				Debug.Log("OnRefreshComplete: " + hServerListRequest.ToString() + " - " + response);
				List<GameServerBrowserEntery> list = new List<GameServerBrowserEntery>();
				int serverCount = SteamMatchmakingServers.GetServerCount(hRequest);
				for (int i = 0; i < serverCount; i++)
				{
					gameserveritem_t serverDetails = SteamMatchmakingServers.GetServerDetails(hRequest, i);
					if (serverDetails.m_steamID.m_SteamID != 0L && serverDetails.m_nAppID == App.Id)
					{
						GameServerBrowserEntery item = new GameServerBrowserEntery(serverDetails);
						list.Add(item);
					}
				}
				if (hRequest != HServerListRequest.Invalid)
				{
					SteamMatchmakingServers.ReleaseRequest(hRequest);
				}
				if (callback != null)
				{
					callback(list, arg2: false);
				}
				clear();
			}
		}

		private class PingQuery
		{
			public HServerQuery hQuery;

			public ISteamMatchmakingPingResponse m_PingResponse;

			public GameServerBrowserEntery target;

			public Action<GameServerBrowserEntery, bool> callback;

			public Action clear;

			public PingQuery()
			{
				m_PingResponse = new ISteamMatchmakingPingResponse(OnServerRespondedPing, OnServerFailedToRespondPing);
			}

			private void OnServerFailedToRespondPing()
			{
				if (hQuery != HServerQuery.Invalid)
				{
					SteamMatchmakingServers.CancelServerQuery(hQuery);
				}
				callback?.Invoke(target, arg2: true);
				clear?.Invoke();
			}

			private void OnServerRespondedPing(gameserveritem_t server)
			{
				if (hQuery != HServerQuery.Invalid)
				{
					SteamMatchmakingServers.CancelServerQuery(hQuery);
				}
				if (target != null)
				{
					target.Update(server);
					target.evtDataUpdated.Invoke();
					callback?.Invoke(target, arg2: false);
				}
				else
				{
					callback?.Invoke(new GameServerBrowserEntery(server), arg2: false);
				}
				clear?.Invoke();
			}
		}

		private class PlayerQuery
		{
			public HServerQuery hQuery;

			public ISteamMatchmakingPlayersResponse m_PlayersResponse;

			public GameServerBrowserEntery target;

			public Action<GameServerBrowserEntery, bool> callback;

			public Action clear;

			public PlayerQuery()
			{
				m_PlayersResponse = new ISteamMatchmakingPlayersResponse(OnAddPlayerToList, OnPlayersFailedToRespond, OnPlayersRefreshComplete);
			}

			private void OnPlayersRefreshComplete()
			{
				if (hQuery != HServerQuery.Invalid)
				{
					SteamMatchmakingServers.CancelServerQuery(hQuery);
				}
				target.evtDataUpdated.Invoke();
				callback?.Invoke(target, arg2: false);
				clear?.Invoke();
			}

			private void OnPlayersFailedToRespond()
			{
				if (hQuery != HServerQuery.Invalid)
				{
					SteamMatchmakingServers.CancelServerQuery(hQuery);
				}
				callback?.Invoke(target, arg2: true);
				clear?.Invoke();
			}

			private void OnAddPlayerToList(string pchName, int nScore, float flTimePlayed)
			{
				target.players.Add(new ServerPlayerEntry
				{
					name = pchName,
					score = nScore,
					timePlayed = new TimeSpan(0, 0, 0, (int)flTimePlayed, 0)
				});
			}
		}

		private class RulesQuery
		{
			public HServerQuery hQuery;

			public ISteamMatchmakingRulesResponse m_RulesResponse;

			public GameServerBrowserEntery target;

			public Action<GameServerBrowserEntery, bool> callback;

			public Action clear;

			public RulesQuery()
			{
				m_RulesResponse = new ISteamMatchmakingRulesResponse(OnAddRuleToList, OnRulesFailedToRespond, OnRulesRefreshComplete);
			}

			private void OnAddRuleToList(string pchRule, string pchValue)
			{
				target.rules.Add(new StringKeyValuePair
				{
					key = pchRule,
					value = pchValue
				});
			}

			private void OnRulesRefreshComplete()
			{
				if (hQuery != HServerQuery.Invalid)
				{
					SteamMatchmakingServers.CancelServerQuery(hQuery);
				}
				target.evtDataUpdated.Invoke();
				if (callback != null)
				{
					callback(target, arg2: false);
				}
				if (clear != null)
				{
					clear();
				}
			}

			private void OnRulesFailedToRespond()
			{
				if (hQuery != HServerQuery.Invalid)
				{
					SteamMatchmakingServers.CancelServerQuery(hQuery);
				}
				callback?.Invoke(target, arg2: true);
				clear?.Invoke();
			}
		}

		public class Filter : Dictionary<string, string>
		{
			public MatchMakingKeyValuePair_t[] Array
			{
				get
				{
					MatchMakingKeyValuePair_t[] array = new MatchMakingKeyValuePair_t[base.Count];
					int num = 0;
					using Enumerator enumerator = GetEnumerator();
					while (enumerator.MoveNext())
					{
						KeyValuePair<string, string> current = enumerator.Current;
						array[num] = new MatchMakingKeyValuePair_t
						{
							m_szKey = current.Key,
							m_szValue = current.Value
						};
						num++;
					}
					return array;
				}
			}
		}

		private readonly List<Search> searchList = new List<Search>();

		private readonly List<PingQuery> pingList = new List<PingQuery>();

		private readonly List<PlayerQuery> playerList = new List<PlayerQuery>();

		private readonly List<RulesQuery> ruleList = new List<RulesQuery>();

		public ResultsEvent evtSearchCompleted = new ResultsEvent();

		public void GetAllFavorites()
		{
			GetServerList(App.Client.Id, GameServerSearchType.Favorites);
		}

		public void GetAllFriends()
		{
			GetServerList(App.Client.Id, GameServerSearchType.Friends);
		}

		public void GetAllHistory()
		{
			GetServerList(App.Client.Id, GameServerSearchType.History);
		}

		public void GetAllInternet()
		{
			GetServerList(App.Client.Id, GameServerSearchType.Internet);
		}

		public void GetAllLAN()
		{
			GetServerList(App.Client.Id, GameServerSearchType.LAN);
		}

		public void GetAllSpectator()
		{
			GetServerList(App.Client.Id, GameServerSearchType.Spectator);
		}

		public void GetFavorites(Filter filter)
		{
			GetServerList(App.Client.Id, GameServerSearchType.Favorites, null, filter);
		}

		public void GetFriends(Filter filter)
		{
			GetServerList(App.Client.Id, GameServerSearchType.Friends, null, filter);
		}

		public void GetHistory(Filter filter)
		{
			GetServerList(App.Client.Id, GameServerSearchType.History, null, filter);
		}

		public void GetInternet(Filter filter)
		{
			GetServerList(App.Client.Id, GameServerSearchType.Internet, null, filter);
		}

		public void GetLAN(Filter filter)
		{
			GetServerList(App.Client.Id, GameServerSearchType.LAN, null, filter);
		}

		public void GetSpectator(Filter filter)
		{
			GetServerList(App.Client.Id, GameServerSearchType.Spectator, null, filter);
		}

		public void GetServerList(GameServerSearchType type, Action<List<GameServerBrowserEntery>, bool> callback = null, Filter filter = null)
		{
			GetServerList(App.Client.Id, type, callback, filter);
		}

		public void GetServerList(AppId_t appId, GameServerSearchType type, Action<List<GameServerBrowserEntery>, bool> callback = null, Filter filter = null)
		{
			Search nSearch = new Search();
			nSearch.clear = delegate
			{
				searchList.Remove(nSearch);
			};
			MatchMakingKeyValuePair_t[] filters = new MatchMakingKeyValuePair_t[0];
			if (filter != null)
			{
				filters = filter.Array;
			}
			switch (type)
			{
			case GameServerSearchType.Favorites:
				nSearch.callback = delegate(List<GameServerBrowserEntery> r, bool e)
				{
					callback?.Invoke(r, e);
					evtSearchCompleted.Invoke(new ResultData(GameServerSearchType.Favorites, r, e));
				};
				Matchmaking.Client.RequestFavoritesServerList(appId, filters, nSearch.m_ServerListResponse);
				break;
			case GameServerSearchType.Friends:
				nSearch.callback = delegate(List<GameServerBrowserEntery> r, bool e)
				{
					callback?.Invoke(r, e);
					evtSearchCompleted.Invoke(new ResultData(GameServerSearchType.Friends, r, e));
				};
				Matchmaking.Client.RequestFriendsServerList(appId, filters, nSearch.m_ServerListResponse);
				break;
			case GameServerSearchType.History:
				nSearch.callback = delegate(List<GameServerBrowserEntery> r, bool e)
				{
					callback?.Invoke(r, e);
					evtSearchCompleted.Invoke(new ResultData(GameServerSearchType.History, r, e));
				};
				Matchmaking.Client.RequestHistoryServerList(appId, filters, nSearch.m_ServerListResponse);
				break;
			case GameServerSearchType.Internet:
				nSearch.callback = delegate(List<GameServerBrowserEntery> r, bool e)
				{
					callback?.Invoke(r, e);
					evtSearchCompleted.Invoke(new ResultData(GameServerSearchType.Internet, r, e));
				};
				Matchmaking.Client.RequestInternetServerList(appId, filters, nSearch.m_ServerListResponse);
				break;
			case GameServerSearchType.LAN:
				nSearch.callback = delegate(List<GameServerBrowserEntery> r, bool e)
				{
					callback?.Invoke(r, e);
					evtSearchCompleted.Invoke(new ResultData(GameServerSearchType.LAN, r, e));
				};
				Matchmaking.Client.RequestLANServerList(appId, nSearch.m_ServerListResponse);
				break;
			case GameServerSearchType.Spectator:
				nSearch.callback = delegate(List<GameServerBrowserEntery> r, bool e)
				{
					callback?.Invoke(r, e);
					evtSearchCompleted.Invoke(new ResultData(GameServerSearchType.Spectator, r, e));
				};
				Matchmaking.Client.RequestSpectatorServerList(appId, filters, nSearch.m_ServerListResponse);
				break;
			}
			searchList.Add(nSearch);
		}

		public void PingServer(string ipAddress, ushort port, Action<GameServerBrowserEntery, bool> callback)
		{
			PingServer(Utilities.IPStringToUint(ipAddress), port, callback);
		}

		public void PingServer(uint ipAddress, ushort port, Action<GameServerBrowserEntery, bool> callback)
		{
			PingQuery nQuery = new PingQuery();
			nQuery.callback = callback;
			nQuery.hQuery = Matchmaking.Client.PingServer(ipAddress, port, nQuery.m_PingResponse);
			nQuery.clear = delegate
			{
				pingList.Remove(nQuery);
			};
			pingList.Add(nQuery);
		}

		public void PingServer(servernetadr_t address, Action<GameServerBrowserEntery, bool> callback)
		{
			PingServer(address.GetIP(), address.GetQueryPort(), callback);
		}

		public void PingServer(GameServerBrowserEntery entry, Action<GameServerBrowserEntery, bool> callback)
		{
			PingQuery nQuery = new PingQuery();
			nQuery.callback = callback;
			nQuery.target = entry;
			nQuery.hQuery = Matchmaking.Client.PingServer(entry.m_NetAdr.GetIP(), entry.m_NetAdr.GetQueryPort(), nQuery.m_PingResponse);
			nQuery.clear = delegate
			{
				pingList.Remove(nQuery);
			};
			pingList.Add(nQuery);
		}

		public void PlayerDetails(GameServerBrowserEntery entry, Action<GameServerBrowserEntery, bool> callback)
		{
			PlayerQuery nQuery = new PlayerQuery();
			nQuery.callback = callback;
			entry.players.Clear();
			nQuery.target = entry;
			nQuery.hQuery = Matchmaking.Client.PlayerDetails(entry.m_NetAdr.GetIP(), entry.m_NetAdr.GetQueryPort(), nQuery.m_PlayersResponse);
			nQuery.clear = delegate
			{
				playerList.Remove(nQuery);
			};
			playerList.Add(nQuery);
		}

		public void ServerRules(GameServerBrowserEntery entry, Action<GameServerBrowserEntery, bool> callback)
		{
			RulesQuery nQuery = new RulesQuery();
			nQuery.callback = callback;
			entry.rules.Clear();
			nQuery.target = entry;
			nQuery.hQuery = Matchmaking.Client.ServerRules(entry.m_NetAdr.GetIP(), entry.m_NetAdr.GetQueryPort(), nQuery.m_RulesResponse);
			nQuery.clear = delegate
			{
				ruleList.Remove(nQuery);
			};
			ruleList.Add(nQuery);
		}

		private void OnDestroy()
		{
			if (searchList != null)
			{
				foreach (Search search in searchList)
				{
					try
					{
						if (search.hRequest != HServerListRequest.Invalid)
						{
							SteamMatchmakingServers.ReleaseRequest(search.hRequest);
						}
					}
					catch
					{
					}
				}
			}
			if (pingList != null)
			{
				foreach (PingQuery ping in pingList)
				{
					try
					{
						if (ping.hQuery != HServerQuery.Invalid)
						{
							SteamMatchmakingServers.CancelServerQuery(ping.hQuery);
						}
					}
					catch
					{
					}
				}
			}
			if (playerList != null)
			{
				foreach (PlayerQuery player in playerList)
				{
					try
					{
						if (player.hQuery != HServerQuery.Invalid)
						{
							SteamMatchmakingServers.CancelServerQuery(player.hQuery);
						}
					}
					catch
					{
					}
				}
			}
			if (ruleList == null)
			{
				return;
			}
			foreach (RulesQuery rule in ruleList)
			{
				try
				{
					if (rule.hQuery != HServerQuery.Invalid)
					{
						SteamMatchmakingServers.CancelServerQuery(rule.hQuery);
					}
				}
				catch
				{
				}
			}
		}
	}
}
