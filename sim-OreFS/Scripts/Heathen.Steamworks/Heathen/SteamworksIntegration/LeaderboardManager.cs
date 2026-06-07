using System;
using System.Collections.Generic;
using System.Linq;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace Heathen.SteamworksIntegration
{
	public class LeaderboardManager : MonoBehaviour
	{
		public enum ManagedEvents
		{
			QueryError = 0,
			QueryCompleted = 1,
			UploadError = 2,
			UserEntryUpdated = 3
		}

		[Serializable]
		public class UserEntryEvent : UnityEvent<LeaderboardEntry>
		{
		}

		[Serializable]
		public class EntryResultsEvent : UnityEvent<LeaderboardEntry[]>
		{
		}

		[SerializeField]
		private List<ManagedEvents> m_Delegates;

		public LeaderboardObject leaderboard;

		private LeaderboardEntry _lastKnownUserEntry;

		public UserEntryEvent evtUserEntryUpdated = new UserEntryEvent();

		public EntryResultsEvent evtQueryCompleted = new EntryResultsEvent();

		public UnityEvent evtQueryError = new UnityEvent();

		public UnityEvent evtUploadError = new UnityEvent();

		public LeaderboardEntry LastKnownUserEntry
		{
			get
			{
				return _lastKnownUserEntry;
			}
			private set
			{
				_lastKnownUserEntry = value;
				evtUserEntryUpdated.Invoke(value);
			}
		}

		public void RefreshUserEntry()
		{
			leaderboard.GetUserEntry(delegate(LeaderboardEntry r, bool e)
			{
				if (!e)
				{
					LastKnownUserEntry = r;
				}
				else
				{
					evtQueryError.Invoke();
				}
			});
		}

		public void GetTopEntries(int count)
		{
			leaderboard.GetEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, 0, count, delegate(LeaderboardEntry[] r, bool e)
			{
				if (!e)
				{
					LeaderboardEntry leaderboardEntry = r.FirstOrDefault((LeaderboardEntry p) => p.entry.m_steamIDUser == SteamUser.GetSteamID());
					if (leaderboardEntry != null)
					{
						LastKnownUserEntry = leaderboardEntry;
					}
					evtQueryCompleted.Invoke(r);
				}
				else
				{
					evtQueryError?.Invoke();
				}
			});
		}

		public void GetNearbyEntries(int beforeUser, int afterUser)
		{
			leaderboard.GetEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobalAroundUser, -beforeUser, afterUser, delegate(LeaderboardEntry[] r, bool e)
			{
				if (!e)
				{
					LeaderboardEntry leaderboardEntry = r.FirstOrDefault((LeaderboardEntry p) => p.entry.m_steamIDUser == SteamUser.GetSteamID());
					if (leaderboardEntry != null)
					{
						LastKnownUserEntry = leaderboardEntry;
					}
					evtQueryCompleted.Invoke(r);
				}
				else
				{
					evtQueryError?.Invoke();
				}
			});
		}

		public void GetNearbyEntries(int aroundUser)
		{
			GetNearbyEntries(aroundUser, aroundUser);
		}

		public void GetAllFriendsEntries()
		{
			leaderboard.GetEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestFriends, 0, 0, delegate(LeaderboardEntry[] r, bool e)
			{
				if (!e)
				{
					LeaderboardEntry leaderboardEntry = r.FirstOrDefault((LeaderboardEntry p) => p.entry.m_steamIDUser == SteamUser.GetSteamID());
					if (leaderboardEntry != null)
					{
						LastKnownUserEntry = leaderboardEntry;
					}
					evtQueryCompleted.Invoke(r);
				}
				else
				{
					evtQueryError?.Invoke();
				}
			});
		}

		public void GetUserEntries(IEnumerable<UserData> users)
		{
			leaderboard.GetEntries(users.ToArray(), delegate(LeaderboardEntry[] r, bool e)
			{
				if (!e)
				{
					LeaderboardEntry leaderboardEntry = r.FirstOrDefault((LeaderboardEntry p) => p.entry.m_steamIDUser == SteamUser.GetSteamID());
					if (leaderboardEntry != null)
					{
						LastKnownUserEntry = leaderboardEntry;
					}
					evtQueryCompleted.Invoke(r);
				}
				else
				{
					evtQueryError?.Invoke();
				}
			});
		}

		public void UploadScore(int score)
		{
			leaderboard.UploadScore(score, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest, delegate(LeaderboardScoreUploaded r, bool e)
			{
				if (!e)
				{
					RefreshUserEntry();
				}
				else
				{
					evtUploadError.Invoke();
				}
			});
		}

		public void UploadScore(int score, int[] details)
		{
			leaderboard.UploadScore(score, details, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest, delegate(LeaderboardScoreUploaded r, bool e)
			{
				if (!e)
				{
					RefreshUserEntry();
				}
				else
				{
					evtUploadError.Invoke();
				}
			});
		}

		public void ForceScore(int score)
		{
			leaderboard.UploadScore(score, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, delegate(LeaderboardScoreUploaded r, bool e)
			{
				if (!e)
				{
					RefreshUserEntry();
				}
				else
				{
					evtUploadError.Invoke();
				}
			});
		}

		public void ForceScore(int score, int[] details)
		{
			leaderboard.UploadScore(score, details, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, delegate(LeaderboardScoreUploaded r, bool e)
			{
				if (!e)
				{
					RefreshUserEntry();
				}
				else
				{
					evtUploadError.Invoke();
				}
			});
		}
	}
}
