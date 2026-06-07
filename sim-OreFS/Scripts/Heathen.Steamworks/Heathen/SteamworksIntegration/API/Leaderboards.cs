using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration.API
{
	public static class Leaderboards
	{
		private struct AttachUGCRequest
		{
			public LeaderboardData leaderboard;

			public UGCHandle_t ugc;

			public Action<LeaderboardUGCSet, bool> callback;
		}

		private struct DownloadScoreRequest
		{
			public bool userRequest;

			public CSteamID[] users;

			public SteamLeaderboard_t leaderboard;

			public ELeaderboardDataRequest request;

			public int start;

			public int end;

			public int maxDetailsPerEntry;

			public Action<LeaderboardEntry[], bool> callback;
		}

		private struct UploadScoreRequest
		{
			public LeaderboardData leaderboard;

			public ELeaderboardUploadScoreMethod method;

			public int score;

			public int[] details;

			public Action<LeaderboardScoreUploaded, bool> callback;
		}

		private struct FindOrCreateRequest
		{
			public string apiName;

			public bool createIfMissing;

			public ELeaderboardDisplayType displayType;

			public ELeaderboardSortMethod sortMethod;

			public Action<LeaderboardData, bool> callback;
		}

		public static class Client
		{
			private static CallResult<LeaderboardUGCSet_t> m_LeaderboardUGCSet_t;

			private static CallResult<LeaderboardScoresDownloaded_t> m_LeaderboardScoresDownloaded_t;

			private static CallResult<LeaderboardFindResult_t> m_LeaderboardFindResult_t;

			private static CallResult<LeaderboardScoreUploaded_t> m_LeaderboardScoreUploaded_t;

			private static Queue<AttachUGCRequest> ugcQueue;

			private static Queue<DownloadScoreRequest> downloadQueue;

			private static Queue<UploadScoreRequest> uploadQueue;

			private static Queue<FindOrCreateRequest> findOrCreateQueue;

			public static float RequestTimeout { get; set; } = 30f;

			public static int PendingSetUgcRequests
			{
				get
				{
					if (ugcQueue != null)
					{
						return ugcQueue.Count;
					}
					return 0;
				}
			}

			public static int PendingDownloadScoreRequests
			{
				get
				{
					if (downloadQueue != null)
					{
						return downloadQueue.Count;
					}
					return 0;
				}
			}

			public static int PendingUploadScoreRequests
			{
				get
				{
					if (uploadQueue != null)
					{
						return uploadQueue.Count;
					}
					return 0;
				}
			}

			[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
			private static void Init()
			{
				m_LeaderboardUGCSet_t = null;
				m_LeaderboardScoresDownloaded_t = null;
				m_LeaderboardFindResult_t = null;
				m_LeaderboardScoreUploaded_t = null;
				ugcQueue = null;
				downloadQueue = null;
				uploadQueue = null;
				findOrCreateQueue = null;
				RequestTimeout = 30f;
			}

			private static void ExecuteUgcRequest()
			{
				BackgroundWorker bgWorker = new BackgroundWorker();
				bgWorker.DoWork += delegate
				{
					bool waiting = false;
					while (ugcQueue.Count > 0)
					{
						AttachUGCRequest request = ugcQueue.Peek();
						if (request.callback != null)
						{
							SteamAPICall_t hAPICall = SteamUserStats.AttachLeaderboardUGC(request.leaderboard, request.ugc);
							waiting = true;
							m_LeaderboardUGCSet_t.Set(hAPICall, delegate(LeaderboardUGCSet_t r, bool arg)
							{
								request.callback(r, arg);
								waiting = false;
							});
							while (waiting)
							{
								Thread.Sleep(100);
							}
						}
						ugcQueue.Dequeue();
					}
				};
				bgWorker.RunWorkerCompleted += delegate
				{
					bgWorker.Dispose();
				};
				bgWorker.RunWorkerAsync();
			}

			private static void ExecuteDownloadRequest()
			{
				BackgroundWorker bgWorker = new BackgroundWorker();
				bgWorker.DoWork += delegate
				{
					bool waiting = false;
					while (downloadQueue.Count > 0)
					{
						DownloadScoreRequest request = downloadQueue.Peek();
						if (request.callback != null)
						{
							if (request.userRequest)
							{
								SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntriesForUsers(request.leaderboard, request.users, request.users.Length);
								waiting = true;
								m_LeaderboardScoresDownloaded_t.Set(hAPICall, delegate(LeaderboardScoresDownloaded_t results, bool error)
								{
									request.callback(ProcessScoresDownloaded(results, error, request.maxDetailsPerEntry), error);
									waiting = false;
								});
								while (waiting)
								{
									Thread.Sleep(100);
								}
							}
							else
							{
								SteamAPICall_t hAPICall2 = SteamUserStats.DownloadLeaderboardEntries(request.leaderboard, request.request, request.start, request.end);
								waiting = true;
								m_LeaderboardScoresDownloaded_t.Set(hAPICall2, delegate(LeaderboardScoresDownloaded_t results, bool error)
								{
									request.callback(ProcessScoresDownloaded(results, error, request.maxDetailsPerEntry), error);
									waiting = false;
								});
								while (waiting)
								{
									Thread.Sleep(100);
								}
							}
						}
						downloadQueue.Dequeue();
					}
				};
				bgWorker.RunWorkerCompleted += delegate
				{
					bgWorker.Dispose();
				};
				bgWorker.RunWorkerAsync();
			}

			private static void ExecuteUploadRequest()
			{
				BackgroundWorker bgWorker = new BackgroundWorker();
				bgWorker.DoWork += delegate
				{
					bool waiting = false;
					while (uploadQueue.Count > 0)
					{
						UploadScoreRequest request = uploadQueue.Peek();
						SteamAPICall_t hAPICall = SteamUserStats.UploadLeaderboardScore(request.leaderboard, request.method, request.score, request.details, (request.details != null) ? request.details.Length : 0);
						waiting = true;
						m_LeaderboardScoreUploaded_t.Set(hAPICall, delegate(LeaderboardScoreUploaded_t r, bool flag)
						{
							request.callback?.Invoke(r, flag);
							if (SteamSettings.current != null && !flag && (r.m_bScoreChanged == 1 || r.m_nGlobalRankNew != r.m_nGlobalRankPrevious))
							{
								LeaderboardObject leaderboardObject = SteamSettings.Leaderboards.FirstOrDefault((LeaderboardObject p) => p != null && p.data.id == r.m_hSteamLeaderboard);
								if (leaderboardObject != null)
								{
									UserRankOrScoreUpdated(leaderboardObject);
								}
							}
							waiting = false;
						});
						while (waiting)
						{
							Thread.Sleep(100);
						}
						if (waiting)
						{
							request.callback?.Invoke(default(LeaderboardScoreUploaded), arg2: true);
							Debug.LogWarning("Leaderboard upload request exceeded the timeout of " + RequestTimeout + ", the callback will be called as a failure and next request serviced. The request may still come in at a later time.");
						}
						uploadQueue.Dequeue();
					}
				};
				bgWorker.RunWorkerCompleted += delegate
				{
					bgWorker.Dispose();
				};
				bgWorker.RunWorkerAsync();
			}

			private static void ExecuteFindOrCreateRequest()
			{
				BackgroundWorker bgWorker = new BackgroundWorker();
				bgWorker.DoWork += delegate
				{
					bool waiting = false;
					while (findOrCreateQueue.Count > 0)
					{
						FindOrCreateRequest request = findOrCreateQueue.Peek();
						if (request.callback != null)
						{
							if (request.createIfMissing)
							{
								SteamAPICall_t hAPICall = SteamUserStats.FindOrCreateLeaderboard(request.apiName, request.sortMethod, request.displayType);
								waiting = true;
								m_LeaderboardFindResult_t.Set(hAPICall, delegate(LeaderboardFindResult_t results, bool error)
								{
									request.callback?.Invoke(new LeaderboardData
									{
										apiName = request.apiName,
										id = results.m_hSteamLeaderboard
									}, error);
									waiting = false;
								});
								while (waiting)
								{
									Thread.Sleep(100);
								}
							}
							else
							{
								SteamAPICall_t hAPICall2 = SteamUserStats.FindLeaderboard(request.apiName);
								waiting = true;
								m_LeaderboardFindResult_t.Set(hAPICall2, delegate(LeaderboardFindResult_t results, bool error)
								{
									request.callback?.Invoke(new LeaderboardData
									{
										apiName = request.apiName,
										id = results.m_hSteamLeaderboard
									}, error);
									waiting = false;
								});
								while (waiting)
								{
									Thread.Sleep(100);
								}
							}
						}
						findOrCreateQueue.Dequeue();
					}
				};
				bgWorker.RunWorkerCompleted += delegate
				{
					bgWorker.Dispose();
				};
				bgWorker.RunWorkerAsync();
			}

			private static void UserRankOrScoreUpdated(LeaderboardObject leaderboard)
			{
				leaderboard.GetUserEntry(delegate(LeaderboardEntry r, bool e)
				{
					if (!e && r != null)
					{
						leaderboard.UserEntryUpdated?.Invoke(r);
					}
				});
			}

			public static void AttachUGC(LeaderboardData leaderboard, UGCHandle_t ugc, Action<LeaderboardUGCSet, bool> callback)
			{
				if (callback != null)
				{
					if (m_LeaderboardUGCSet_t == null)
					{
						m_LeaderboardUGCSet_t = CallResult<LeaderboardUGCSet_t>.Create();
					}
					if (ugcQueue == null)
					{
						ugcQueue = new Queue<AttachUGCRequest>();
					}
					AttachUGCRequest item = new AttachUGCRequest
					{
						leaderboard = leaderboard,
						ugc = ugc,
						callback = callback
					};
					ugcQueue.Enqueue(item);
					if (ugcQueue.Count == 1)
					{
						ExecuteUgcRequest();
					}
				}
			}

			public static void AttachUGC(LeaderboardData leaderboard, string fileName, byte[] data, Action<LeaderboardUGCSet, bool> callback)
			{
				if (callback == null)
				{
					return;
				}
				RemoteStorage.Client.FileWriteAsync(fileName, data, delegate(RemoteStorageFileWriteAsyncComplete_t writeResult, bool writeError)
				{
					if (!writeError)
					{
						RemoteStorage.Client.FileShare(fileName, delegate(RemoteStorageFileShareResult_t shareResult, bool shareError)
						{
							if (!shareError)
							{
								AttachUGC(leaderboard, shareResult.m_hFile, callback);
							}
							else
							{
								callback(new LeaderboardUGCSet_t
								{
									m_eResult = shareResult.m_eResult,
									m_hSteamLeaderboard = leaderboard
								}, arg2: true);
							}
						});
					}
					else
					{
						callback(new LeaderboardUGCSet_t
						{
							m_eResult = writeResult.m_eResult,
							m_hSteamLeaderboard = leaderboard
						}, arg2: true);
					}
				});
			}

			public static void AttachUGC(LeaderboardData leaderboard, string fileName, object jsonObject, Encoding encoding, Action<LeaderboardUGCSet, bool> callback)
			{
				if (callback == null)
				{
					return;
				}
				RemoteStorage.Client.FileWriteAsync(fileName, jsonObject, encoding, delegate(RemoteStorageFileWriteAsyncComplete_t writeResult, bool writeError)
				{
					if (!writeError)
					{
						RemoteStorage.Client.FileShare(fileName, delegate(RemoteStorageFileShareResult_t shareResult, bool shareError)
						{
							if (!shareError)
							{
								AttachUGC(leaderboard, shareResult.m_hFile, callback);
							}
							else
							{
								callback(new LeaderboardUGCSet_t
								{
									m_eResult = shareResult.m_eResult,
									m_hSteamLeaderboard = leaderboard
								}, arg2: true);
							}
						});
					}
					else
					{
						callback(new LeaderboardUGCSet_t
						{
							m_eResult = writeResult.m_eResult,
							m_hSteamLeaderboard = leaderboard
						}, arg2: true);
					}
				});
			}

			public static void AttachUGC(LeaderboardData leaderboard, string fileName, string content, Encoding encoding, Action<LeaderboardUGCSet, bool> callback)
			{
				if (callback == null)
				{
					return;
				}
				RemoteStorage.Client.FileWriteAsync(fileName, content, encoding, delegate(RemoteStorageFileWriteAsyncComplete_t writeResult, bool writeError)
				{
					if (!writeError)
					{
						RemoteStorage.Client.FileShare(fileName, delegate(RemoteStorageFileShareResult_t shareResult, bool shareError)
						{
							if (!shareError)
							{
								AttachUGC(leaderboard, shareResult.m_hFile, callback);
							}
							else
							{
								callback(new LeaderboardUGCSet_t
								{
									m_eResult = shareResult.m_eResult,
									m_hSteamLeaderboard = leaderboard
								}, arg2: true);
							}
						});
					}
					else
					{
						callback(new LeaderboardUGCSet_t
						{
							m_eResult = writeResult.m_eResult,
							m_hSteamLeaderboard = leaderboard
						}, arg2: true);
					}
				});
			}

			public static void DownloadEntries(LeaderboardData leaderboard, ELeaderboardDataRequest request, int start, int end, int maxDetailsPerEntry, Action<LeaderboardEntry[], bool> callback)
			{
				if (callback != null)
				{
					if (m_LeaderboardScoresDownloaded_t == null)
					{
						m_LeaderboardScoresDownloaded_t = CallResult<LeaderboardScoresDownloaded_t>.Create();
					}
					if (downloadQueue == null)
					{
						downloadQueue = new Queue<DownloadScoreRequest>();
					}
					DownloadScoreRequest item = new DownloadScoreRequest
					{
						userRequest = false,
						leaderboard = leaderboard,
						request = request,
						start = start,
						end = end,
						maxDetailsPerEntry = maxDetailsPerEntry,
						callback = callback
					};
					downloadQueue.Enqueue(item);
					if (downloadQueue.Count == 1)
					{
						ExecuteDownloadRequest();
					}
				}
			}

			public static void DownloadEntries(LeaderboardData leaderboard, CSteamID[] users, int maxDetailsPerEntry, Action<LeaderboardEntry[], bool> callback)
			{
				if (callback != null)
				{
					if (m_LeaderboardScoresDownloaded_t == null)
					{
						m_LeaderboardScoresDownloaded_t = CallResult<LeaderboardScoresDownloaded_t>.Create();
					}
					if (downloadQueue == null)
					{
						downloadQueue = new Queue<DownloadScoreRequest>();
					}
					DownloadScoreRequest item = new DownloadScoreRequest
					{
						userRequest = true,
						leaderboard = leaderboard,
						users = users,
						maxDetailsPerEntry = maxDetailsPerEntry,
						callback = callback
					};
					downloadQueue.Enqueue(item);
					if (downloadQueue.Count == 1)
					{
						ExecuteDownloadRequest();
					}
				}
			}

			public static void DownloadEntries(LeaderboardData leaderboard, UserData[] users, int maxDetailsPerEntry, Action<LeaderboardEntry[], bool> callback)
			{
				DownloadEntries(leaderboard, Array.ConvertAll(users, (UserData i) => i.id), maxDetailsPerEntry, callback);
			}

			public static void Find(string leaderboardName, Action<LeaderboardData, bool> callback)
			{
				if (callback != null)
				{
					if (m_LeaderboardFindResult_t == null)
					{
						m_LeaderboardFindResult_t = CallResult<LeaderboardFindResult_t>.Create();
					}
					if (findOrCreateQueue == null)
					{
						findOrCreateQueue = new Queue<FindOrCreateRequest>();
					}
					findOrCreateQueue.Enqueue(new FindOrCreateRequest
					{
						apiName = leaderboardName,
						callback = callback,
						createIfMissing = false
					});
					if (findOrCreateQueue.Count == 1)
					{
						ExecuteFindOrCreateRequest();
					}
				}
			}

			public static void FindOrCreate(string leaderboardName, ELeaderboardSortMethod sortingMethod, ELeaderboardDisplayType displayType, Action<LeaderboardData, bool> callback)
			{
				if (callback == null)
				{
					return;
				}
				if (m_LeaderboardFindResult_t == null)
				{
					m_LeaderboardFindResult_t = CallResult<LeaderboardFindResult_t>.Create();
				}
				if (sortingMethod == ELeaderboardSortMethod.k_ELeaderboardSortMethodNone)
				{
					Debug.LogError("You should never pass ELeaderboardSortMethod.k_ELeaderboardSortMethodNone for the sorting method as this is undefined behaviour.");
					callback?.Invoke(default(LeaderboardData), arg2: true);
					return;
				}
				if (displayType == ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNone)
				{
					Debug.LogError("You should never pass ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNone for the display type as this is undefined behaviour.");
					callback?.Invoke(default(LeaderboardData), arg2: true);
					return;
				}
				if (findOrCreateQueue == null)
				{
					findOrCreateQueue = new Queue<FindOrCreateRequest>();
				}
				findOrCreateQueue.Enqueue(new FindOrCreateRequest
				{
					apiName = leaderboardName,
					callback = callback,
					createIfMissing = true,
					sortMethod = sortingMethod,
					displayType = displayType
				});
				if (findOrCreateQueue.Count == 1)
				{
					ExecuteFindOrCreateRequest();
				}
			}

			public static ELeaderboardDisplayType GetDisplayType(LeaderboardData leaderboard)
			{
				return SteamUserStats.GetLeaderboardDisplayType(leaderboard);
			}

			public static int GetEntryCount(LeaderboardData leaderboard)
			{
				return SteamUserStats.GetLeaderboardEntryCount(leaderboard);
			}

			public static string GetName(LeaderboardData leaderboard)
			{
				return SteamUserStats.GetLeaderboardName(leaderboard);
			}

			public static ELeaderboardSortMethod GetSortMethod(LeaderboardData leaderboard)
			{
				return SteamUserStats.GetLeaderboardSortMethod(leaderboard);
			}

			public static void UploadScore(LeaderboardData leaderboard, ELeaderboardUploadScoreMethod method, int score, int[] details, Action<LeaderboardScoreUploaded, bool> callback = null)
			{
				if (m_LeaderboardScoreUploaded_t == null)
				{
					m_LeaderboardScoreUploaded_t = CallResult<LeaderboardScoreUploaded_t>.Create();
				}
				if (uploadQueue == null)
				{
					uploadQueue = new Queue<UploadScoreRequest>();
				}
				UploadScoreRequest item = new UploadScoreRequest
				{
					leaderboard = leaderboard,
					method = method,
					score = score,
					details = details,
					callback = callback
				};
				uploadQueue.Enqueue(item);
				if (uploadQueue.Count == 1)
				{
					ExecuteUploadRequest();
				}
			}

			private static LeaderboardEntry[] ProcessScoresDownloaded(LeaderboardScoresDownloaded_t param, bool bIOFailure, int maxDetailEntries)
			{
				if (!bIOFailure)
				{
					SteamUser.GetSteamID();
					LeaderboardEntry[] array = new LeaderboardEntry[param.m_cEntryCount];
					for (int i = 0; i < param.m_cEntryCount; i++)
					{
						int[] array2 = null;
						LeaderboardEntry_t pLeaderboardEntry;
						if (maxDetailEntries < 1)
						{
							SteamUserStats.GetDownloadedLeaderboardEntry(param.m_hSteamLeaderboardEntries, i, out pLeaderboardEntry, array2, maxDetailEntries);
						}
						else
						{
							array2 = new int[maxDetailEntries];
							SteamUserStats.GetDownloadedLeaderboardEntry(param.m_hSteamLeaderboardEntries, i, out pLeaderboardEntry, array2, maxDetailEntries);
						}
						LeaderboardEntry leaderboardEntry = new LeaderboardEntry();
						leaderboardEntry.entry = pLeaderboardEntry;
						leaderboardEntry.details = array2;
						array[i] = leaderboardEntry;
					}
					return array;
				}
				return new LeaderboardEntry[0];
			}
		}
	}
}
