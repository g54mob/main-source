using System;
using System.Text;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration
{
	[HelpURL("https://kb.heathenengineering.com/assets/steamworks/leaderboard-object")]
	[CreateAssetMenu(menuName = "Steamworks/Leaderboard Object")]
	public class LeaderboardObject : ScriptableObject
	{
		public bool createIfMissing;

		public ELeaderboardSortMethod sortMethod = ELeaderboardSortMethod.k_ELeaderboardSortMethodAscending;

		public ELeaderboardDisplayType displayType = ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNumeric;

		[HideInInspector]
		public string apiName;

		[HideInInspector]
		public int maxDetailEntries;

		[NonSerialized]
		[HideInInspector]
		public LeaderboardData data;

		public UnityLeaderboardRankUpdateEvent UserEntryUpdated = new UnityLeaderboardRankUpdateEvent();

		public string DisplayName => data.DisplayName;

		public bool Valid => data.Valid;

		public int EntryCount => data.EntryCount;

		public void GetUserEntry(Action<LeaderboardEntry, bool> callback)
		{
			data.GetUserEntry(maxDetailEntries, callback);
		}

		public void GetEntries(ELeaderboardDataRequest request, int start, int end, Action<LeaderboardEntry[], bool> callback)
		{
			data.GetEntries(request, start, end, maxDetailEntries, callback);
		}

		public void GetEntries(UserData[] users, Action<LeaderboardEntry[], bool> callback)
		{
			data.GetEntries(users, maxDetailEntries, callback);
		}

		public void GetAllEntries(int maxDetailEntries, Action<LeaderboardEntry[], bool> callback)
		{
			data.GetAllEntries(maxDetailEntries, callback);
		}

		public void Register()
		{
			if (createIfMissing)
			{
				LeaderboardData.GetOrCreate(apiName, displayType, sortMethod, delegate(LeaderboardData result, bool error)
				{
					if (error)
					{
						Debug.LogError("Failed to create or find leaderboard " + apiName);
					}
					data = result;
				});
				return;
			}
			LeaderboardData.Get(apiName, delegate(LeaderboardData result, bool error)
			{
				if (error)
				{
					Debug.LogError("Failed to find leaderboard " + apiName);
				}
				data = result;
			});
		}

		public void UploadScore(int score, ELeaderboardUploadScoreMethod method, Action<LeaderboardScoreUploaded, bool> callback = null)
		{
			if (data.Valid)
			{
				data.UploadScore(score, method, callback);
				return;
			}
			if (createIfMissing)
			{
				LeaderboardData.GetOrCreate(apiName, displayType, sortMethod, delegate(LeaderboardData result, bool error)
				{
					data = result;
					if (error)
					{
						Debug.LogError("Failed to create or find leaderboard " + apiName);
					}
					else
					{
						data.UploadScore(score, method, callback);
					}
				});
				return;
			}
			LeaderboardData.Get(apiName, delegate(LeaderboardData result, bool error)
			{
				data = result;
				if (error)
				{
					Debug.LogError("Failed to find leaderboard " + apiName);
				}
				else
				{
					data.UploadScore(score, method, callback);
				}
			});
		}

		public void UploadScore(int score, int[] scoreDetails, ELeaderboardUploadScoreMethod method, Action<LeaderboardScoreUploaded, bool> callback = null)
		{
			if (data.Valid)
			{
				data.UploadScore(score, scoreDetails, method, callback);
				return;
			}
			if (createIfMissing)
			{
				LeaderboardData.GetOrCreate(apiName, displayType, sortMethod, delegate(LeaderboardData result, bool error)
				{
					data = result;
					if (error)
					{
						Debug.LogError("Failed to create or find leaderboard " + apiName);
					}
					else
					{
						data.UploadScore(score, scoreDetails, method, callback);
					}
				});
				return;
			}
			LeaderboardData.Get(apiName, delegate(LeaderboardData result, bool error)
			{
				data = result;
				if (error)
				{
					Debug.LogError("Failed to find leaderboard " + apiName);
				}
				else
				{
					data.UploadScore(score, scoreDetails, method, callback);
				}
			});
		}

		public void AttachUGC(string fileName, object jsonObject, Encoding encoding, Action<LeaderboardUGCSet, bool> callback = null)
		{
			if (data.Valid)
			{
				data.AttachUGC(fileName, jsonObject, encoding, callback);
				return;
			}
			if (createIfMissing)
			{
				LeaderboardData.GetOrCreate(apiName, displayType, sortMethod, delegate(LeaderboardData result, bool error)
				{
					data = result;
					if (error)
					{
						Debug.LogError("Failed to create or find leaderboard " + apiName);
					}
					else
					{
						data.AttachUGC(fileName, jsonObject, encoding, callback);
					}
				});
				return;
			}
			LeaderboardData.Get(apiName, delegate(LeaderboardData result, bool error)
			{
				data = result;
				if (error)
				{
					Debug.LogError("Failed to find leaderboard " + apiName);
				}
				else
				{
					data.AttachUGC(fileName, jsonObject, encoding, callback);
				}
			});
		}

		public void ForceUploadScore(string score)
		{
			if (data.Valid)
			{
				data.ForceUploadScore(score);
				return;
			}
			if (createIfMissing)
			{
				LeaderboardData.GetOrCreate(apiName, displayType, sortMethod, delegate(LeaderboardData result, bool error)
				{
					data = result;
					if (error)
					{
						Debug.LogError("Failed to create or find leaderboard " + apiName);
					}
					else
					{
						data.ForceUploadScore(score);
					}
				});
				return;
			}
			LeaderboardData.Get(apiName, delegate(LeaderboardData result, bool error)
			{
				data = result;
				if (error)
				{
					Debug.LogError("Failed to find leaderboard " + apiName);
				}
				else
				{
					data.ForceUploadScore(score);
				}
			});
		}

		public void ForceUploadScore(int score)
		{
			if (data.Valid)
			{
				data.ForceUploadScore(score);
				return;
			}
			if (createIfMissing)
			{
				LeaderboardData.GetOrCreate(apiName, displayType, sortMethod, delegate(LeaderboardData result, bool error)
				{
					data = result;
					if (error)
					{
						Debug.LogError("Failed to create or find leaderboard " + apiName);
					}
					else
					{
						data.ForceUploadScore(score);
					}
				});
				return;
			}
			LeaderboardData.Get(apiName, delegate(LeaderboardData result, bool error)
			{
				data = result;
				if (error)
				{
					Debug.LogError("Failed to find leaderboard " + apiName);
				}
				else
				{
					data.ForceUploadScore(score);
				}
			});
		}

		public void KeepBestUploadScore(string score)
		{
			if (data.Valid)
			{
				data.KeepBestUploadScore(score);
				return;
			}
			if (createIfMissing)
			{
				LeaderboardData.GetOrCreate(apiName, displayType, sortMethod, delegate(LeaderboardData result, bool error)
				{
					data = result;
					if (error)
					{
						Debug.LogError("Failed to create or find leaderboard " + apiName);
					}
					else
					{
						data.KeepBestUploadScore(score);
					}
				});
				return;
			}
			LeaderboardData.Get(apiName, delegate(LeaderboardData result, bool error)
			{
				data = result;
				if (error)
				{
					Debug.LogError("Failed to find leaderboard " + apiName);
				}
				else
				{
					data.KeepBestUploadScore(score);
				}
			});
		}

		public void KeepBestUploadScore(int score)
		{
			if (data.Valid)
			{
				data.KeepBestUploadScore(score);
				return;
			}
			if (createIfMissing)
			{
				LeaderboardData.GetOrCreate(apiName, displayType, sortMethod, delegate(LeaderboardData result, bool error)
				{
					data = result;
					if (error)
					{
						Debug.LogError("Failed to create or find leaderboard " + apiName);
					}
					else
					{
						data.KeepBestUploadScore(score);
					}
				});
				return;
			}
			LeaderboardData.Get(apiName, delegate(LeaderboardData result, bool error)
			{
				data = result;
				if (error)
				{
					Debug.LogError("Failed to find leaderboard " + apiName);
				}
				else
				{
					data.KeepBestUploadScore(score);
				}
			});
		}
	}
}
