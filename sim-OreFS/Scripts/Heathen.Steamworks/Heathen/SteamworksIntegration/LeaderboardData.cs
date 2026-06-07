using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using Heathen.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public struct LeaderboardData : IEquatable<SteamLeaderboard_t>, IEquatable<ulong>, IEquatable<string>
	{
		public struct GetAllRequest
		{
			public bool create;

			public string name;

			public ELeaderboardDisplayType type;

			public ELeaderboardSortMethod sort;
		}

		public string apiName;

		public SteamLeaderboard_t id;

		public readonly string DisplayName => SteamUserStats.GetLeaderboardName(id);

		public readonly bool Valid => id.m_SteamLeaderboard != 0;

		public readonly int EntryCount => Leaderboards.Client.GetEntryCount(id);

		public readonly void GetUserEntry(int maxDetailEntries, Action<LeaderboardEntry, bool> callback)
		{
			Leaderboards.Client.DownloadEntries(id, new CSteamID[1] { UserData.Me }, maxDetailEntries, delegate(LeaderboardEntry[] results, bool error)
			{
				if (error || results.Length == 0)
				{
					callback(null, error);
				}
				else
				{
					callback(results[0], error);
				}
			});
		}

		public readonly void GetTopEntries(int count, int maxDetailEntries, Action<LeaderboardEntry[], bool> callback)
		{
			GetEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, 0, count, maxDetailEntries, callback);
		}

		public readonly void GetEntries(ELeaderboardDataRequest request, int start, int end, int maxDetailEntries, Action<LeaderboardEntry[], bool> callback)
		{
			Leaderboards.Client.DownloadEntries(id, request, start, end, maxDetailEntries, callback);
		}

		public readonly void GetEntries(UserData[] users, int maxDetailEntries, Action<LeaderboardEntry[], bool> callback)
		{
			Leaderboards.Client.DownloadEntries(id, Array.ConvertAll(users, (UserData p) => p.id), maxDetailEntries, callback);
		}

		public readonly void GetAllEntries(int maxDetailEntries, Action<LeaderboardEntry[], bool> callback)
		{
			GetEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, 0, int.MaxValue, maxDetailEntries, callback);
		}

		public readonly void GetEntries(CSteamID[] users, int maxDetailEntries, Action<LeaderboardEntry[], bool> callback)
		{
			Leaderboards.Client.DownloadEntries(id, users, maxDetailEntries, callback);
		}

		public static void Get(string name, Action<LeaderboardData, bool> callback)
		{
			Leaderboards.Client.Find(name, callback);
		}

		public static LeaderboardData Get(ulong id)
		{
			return id;
		}

		public static LeaderboardData Get(SteamLeaderboard_t id)
		{
			return id;
		}

		public static void GetAll(LeaderboardObject[] boards, Action<EResult> callback)
		{
			if (boards == null || boards.Length == 0)
			{
				callback?.Invoke(EResult.k_EResultOK);
				return;
			}
			if (SteamSettings.current != null && SteamSettings.current.isDebugging)
			{
				Debug.Log($"Beginning GetAll for {boards.Length} boards.");
			}
			if (boards.Any((LeaderboardObject b) => b == null || string.IsNullOrEmpty(b.apiName)))
			{
				Debug.LogError("Errors have been found with the Leaderboard Objects provided. Please review your Leaderboard Objects and try again.");
				callback?.Invoke(EResult.k_EResultUnexpectedError);
				return;
			}
			try
			{
				GetAllRequest[] array = new GetAllRequest[boards.Length];
				for (int num = 0; num < boards.Length; num++)
				{
					array[num] = new GetAllRequest
					{
						create = boards[num].createIfMissing,
						name = boards[num].apiName,
						sort = boards[num].sortMethod,
						type = boards[num].displayType
					};
				}
				BackgroundWorker bgWorker = new BackgroundWorker();
				bgWorker.DoWork += BgWorker_DoWork;
				bgWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs arguments)
				{
					if (arguments.Cancelled)
					{
						callback?.Invoke(EResult.k_EResultCancelled);
					}
					else if (arguments.Error != null)
					{
						callback?.Invoke(EResult.k_EResultUnexpectedError);
					}
					else
					{
						LeaderboardData[] array2 = arguments.Result as LeaderboardData[];
						for (int i = 0; i < array2.Length; i++)
						{
							boards[i].data = array2[i];
						}
						callback?.Invoke(EResult.k_EResultOK);
					}
					bgWorker.Dispose();
				};
				bgWorker.RunWorkerAsync(array);
			}
			catch (Exception ex)
			{
				Debug.LogError("Get All Leaderboards experienced and unhandled exception: " + ex.ToString());
				callback?.Invoke(EResult.k_EResultUnexpectedError);
			}
		}

		public static void GetAll(GetAllRequest[] commands, Action<LeaderboardData[], EResult> callback)
		{
			if (commands == null || commands.Length == 0)
			{
				callback?.Invoke(null, EResult.k_EResultOK);
				return;
			}
			LeaderboardData[] boards = new LeaderboardData[commands.Length];
			try
			{
				BackgroundWorker bgWorker = new BackgroundWorker();
				bgWorker.DoWork += BgWorker_DoWork;
				bgWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs arguments)
				{
					if (arguments.Cancelled)
					{
						callback?.Invoke(null, EResult.k_EResultCancelled);
					}
					else if (arguments.Error != null)
					{
						callback?.Invoke(null, EResult.k_EResultUnexpectedError);
					}
					else
					{
						LeaderboardData[] array = arguments.Result as LeaderboardData[];
						for (int i = 0; i < array.Length; i++)
						{
							boards[i] = array[i];
						}
						callback?.Invoke(boards, EResult.k_EResultOK);
					}
					bgWorker.Dispose();
				};
				bgWorker.RunWorkerAsync(commands);
			}
			catch (Exception ex)
			{
				Debug.LogError("Get All Leaderboards experienced and unhandled exception: " + ex.ToString());
				callback?.Invoke(null, EResult.k_EResultUnexpectedError);
			}
		}

		private static void BgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			GetAllRequest[] array = e.Argument as GetAllRequest[];
			LeaderboardData[] results = new LeaderboardData[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					GetAllRequest getAllRequest = array[i];
					bool waiting = true;
					if (getAllRequest.create)
					{
						GetOrCreate(getAllRequest.name, getAllRequest.type, getAllRequest.sort, delegate(LeaderboardData result, bool error)
						{
							results[i] = result;
							waiting = false;
						});
					}
					else
					{
						Get(getAllRequest.name, delegate(LeaderboardData result, bool error)
						{
							results[i] = result;
							waiting = false;
						});
					}
					while (waiting)
					{
						Thread.Sleep(10);
					}
				}
				catch
				{
					results[i] = default(LeaderboardData);
				}
			}
			e.Result = results;
		}

		public static void GetOrCreate(string name, ELeaderboardDisplayType displayType, ELeaderboardSortMethod sortMethod, Action<LeaderboardData, bool> callback)
		{
			Leaderboards.Client.FindOrCreate(name, sortMethod, displayType, callback);
		}

		public readonly void UploadScore(int score, ELeaderboardUploadScoreMethod method, Action<LeaderboardScoreUploaded, bool> callback = null)
		{
			Leaderboards.Client.UploadScore(id, method, score, null, callback);
		}

		public readonly void UploadScore(int score, int[] scoreDetails, ELeaderboardUploadScoreMethod method, Action<LeaderboardScoreUploaded, bool> callback = null)
		{
			Leaderboards.Client.UploadScore(id, method, score, scoreDetails, callback);
		}

		public readonly void AttachUGC(string fileName, object jsonObject, Encoding encoding, Action<LeaderboardUGCSet, bool> callback = null)
		{
			Leaderboards.Client.AttachUGC(id, fileName, jsonObject, encoding, callback);
		}

		public readonly void AttachUGC(string fileName, object jsonObject, Action<LeaderboardUGCSet, bool> callback = null)
		{
			Leaderboards.Client.AttachUGC(id, fileName, jsonObject, Encoding.UTF8, callback);
		}

		public readonly void ForceUploadScore(string score)
		{
			if (int.TryParse(score, out var result))
			{
				UploadScore(result, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate);
			}
		}

		public readonly void ForceUploadScore(int score)
		{
			UploadScore(score, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate);
		}

		public readonly void ForceUploadScore(int score, int[] details)
		{
			UploadScore(score, details, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate);
		}

		public readonly void KeepBestUploadScore(string score)
		{
			if (int.TryParse(score, out var result))
			{
				UploadScore(result, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest);
			}
		}

		public readonly void KeepBestUploadScore(int score)
		{
			UploadScore(score, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest);
		}

		public readonly void KeepBestUploadScore(int score, int[] details)
		{
			UploadScore(score, details, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest);
		}

		public override readonly string ToString()
		{
			return apiName;
		}

		public override readonly int GetHashCode()
		{
			return id.GetHashCode() + apiName.GetHashCode();
		}

		public override readonly bool Equals(object obj)
		{
			if (obj.GetType() == typeof(SteamLeaderboard_t))
			{
				return Equals((SteamLeaderboard_t)obj);
			}
			if (obj.GetType() == typeof(string))
			{
				return Equals((string)obj);
			}
			if (obj.GetType() == typeof(ulong))
			{
				return Equals((ulong)obj);
			}
			return id.Equals(obj);
		}

		public readonly bool Equals(SteamLeaderboard_t other)
		{
			return id.Equals(other);
		}

		public readonly bool Equals(ulong other)
		{
			return id.m_SteamLeaderboard.Equals(other);
		}

		public readonly bool Equals(string other)
		{
			return apiName.Equals(other);
		}

		public static bool operator ==(LeaderboardData l, LeaderboardData r)
		{
			return l.id == r.id;
		}

		public static bool operator ==(LeaderboardData l, ulong r)
		{
			return l.id.m_SteamLeaderboard == r;
		}

		public static bool operator ==(LeaderboardData l, string r)
		{
			return l.apiName == r;
		}

		public static bool operator ==(LeaderboardData l, SteamLeaderboard_t r)
		{
			return l.id == r;
		}

		public static bool operator !=(LeaderboardData l, LeaderboardData r)
		{
			return l.id != r.id;
		}

		public static bool operator !=(LeaderboardData l, ulong r)
		{
			return l.id.m_SteamLeaderboard != r;
		}

		public static bool operator !=(LeaderboardData l, string r)
		{
			return l.apiName != r;
		}

		public static bool operator !=(LeaderboardData l, SteamLeaderboard_t r)
		{
			return l.id != r;
		}

		public static implicit operator ulong(LeaderboardData c)
		{
			return c.id.m_SteamLeaderboard;
		}

		public static implicit operator LeaderboardData(ulong id)
		{
			return new LeaderboardData
			{
				id = new SteamLeaderboard_t(id),
				apiName = Leaderboards.Client.GetName(new SteamLeaderboard_t(id))
			};
		}

		public static implicit operator SteamLeaderboard_t(LeaderboardData c)
		{
			return c.id;
		}

		public static implicit operator LeaderboardData(SteamLeaderboard_t id)
		{
			return new LeaderboardData
			{
				id = id
			};
		}

		public static implicit operator string(LeaderboardData c)
		{
			return c.apiName;
		}
	}
}
