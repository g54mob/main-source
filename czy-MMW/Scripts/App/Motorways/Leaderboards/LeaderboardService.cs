using System.Collections.Generic;
using Factory;
using JetBrains.Annotations;
using UnityEngine;

namespace Motorways.Leaderboards
{
	public class LeaderboardService
	{
		private delegate void LeaderboardEntryRequestDelegate(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted);

		private class CachedLeaderboardRequest
		{
			private readonly float _timestamp;

			public bool HasExpired => Time.realtimeSinceStartup - _timestamp > 90f;

			public List<LeaderboardEntry> Entries { get; }

			public long TotalEntryCount { get; }

			public CachedLeaderboardRequest(List<LeaderboardEntry> entries, long totalEntryCount)
			{
				Entries = entries;
				TotalEntryCount = totalEntryCount;
				_timestamp = Time.realtimeSinceStartup;
			}
		}

		private class CachedHistogramRequest
		{
			private readonly float _timestamp;

			public bool HasExpired => Time.realtimeSinceStartup - _timestamp > 90f;

			public List<int> Buckets { get; }

			public int BucketSize { get; }

			public CachedHistogramRequest(List<int> buckets, int bucketSize)
			{
				Buckets = buckets;
				BucketSize = bucketSize;
				_timestamp = Time.realtimeSinceStartup;
			}
		}

		private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("LeaderboardService");

		private const float RequestCacheLifetime = 90f;

		public const int NoLeaderboardEntries = 0;

		[Dependency]
		private ILeaderboardBackend _leaderboardBackend;

		[Dependency]
		private IHistogramBackend _histogramBackend;

		[Dependency]
		private ActivePlayer _player;

		private readonly Dictionary<LeaderboardId, CachedLeaderboardRequest> _localLeaderboardEntryCache = new Dictionary<LeaderboardId, CachedLeaderboardRequest>();

		private readonly Dictionary<LeaderboardId, CachedLeaderboardRequest> _topLeaderboardEntryCache = new Dictionary<LeaderboardId, CachedLeaderboardRequest>();

		private readonly Dictionary<LeaderboardId, CachedLeaderboardRequest> _playerCenteredLeaderboardEntryCache = new Dictionary<LeaderboardId, CachedLeaderboardRequest>();

		private readonly Dictionary<LeaderboardId, CachedLeaderboardRequest> _topFriendFilteredLeaderboardEntryCache = new Dictionary<LeaderboardId, CachedLeaderboardRequest>();

		private readonly Dictionary<LeaderboardId, CachedHistogramRequest> _histogramCache = new Dictionary<LeaderboardId, CachedHistogramRequest>();

		private const int NumBits_ScoreState = 2;

		private const int NumBits_Timestamp = 16;

		private const int NumBits_Unused = 14;

		private const int ScoreStateMask = 3;

		private const int TimestampMask = 262140;

		private const int UnusedMask = -262144;

		public bool CanSubmitScoresOffline => _leaderboardBackend.CanSubmitScoresOffline;

		public bool CanAuthenticate => _leaderboardBackend.CanAuthenticate;

		public void ClearLeaderboardEntryCache(LeaderboardId leaderboardId)
		{
			Log.Info("Clearing cache for {0}.", leaderboardId);
			_localLeaderboardEntryCache.Remove(leaderboardId);
			_topLeaderboardEntryCache.Remove(leaderboardId);
			_playerCenteredLeaderboardEntryCache.Remove(leaderboardId);
			_topFriendFilteredLeaderboardEntryCache.Remove(leaderboardId);
			_histogramCache.Remove(leaderboardId);
		}

		public AsyncRequestHandle RequestLocalEntry(LeaderboardId leaderboardId, [NotNull] LocalEntryRequestCompleted localEntryRequestCompleted)
		{
			Log.Info($"RequestLocalEntry for {leaderboardId}");
			if (_localLeaderboardEntryCache.TryGetValue(leaderboardId, out var value) && !value.HasExpired && value.Entries.Count > 0)
			{
				Log.Info($"Found entries for {leaderboardId} in cache");
				localEntryRequestCompleted(value.Entries[0], value.TotalEntryCount, null);
				return AsyncRequestHandle.CompletedRequestHandle;
			}
			AsyncRequestHandle localRequestHandle = new AsyncRequestHandle();
			_leaderboardBackend.RequestLocalEntry(leaderboardId, delegate(LeaderboardEntry entry, long count, LeaderboardError error)
			{
				if (error == null)
				{
					if (entry != null && leaderboardId is DailyLeaderboardId dailyLeaderboardId && entry.Timestamp != dailyLeaderboardId.Timestamp)
					{
						entry = null;
					}
					_localLeaderboardEntryCache.Remove(leaderboardId);
					_localLeaderboardEntryCache.Add(leaderboardId, new CachedLeaderboardRequest(new List<LeaderboardEntry> { entry }, count));
				}
				if (localRequestHandle.IsActive)
				{
					localEntryRequestCompleted(entry, count, error);
				}
			});
			return localRequestHandle;
		}

		public void SubmitScore(LeaderboardId leaderboardId, int score, LeaderboardScoreState scoreState)
		{
			if (scoreState == LeaderboardScoreState.NotSubmitted)
			{
				Diagnostics.FailAssert("Score state should never be set to NotSubmitted.");
				return;
			}
			if (!CanSubmitScoresOffline)
			{
				_player.MotorwaysExtendedUserProfile.LogUnsubmittedScore(leaderboardId, score, scoreState);
			}
			if (leaderboardId is DailyLeaderboardId)
			{
				SubmitScoreWithDailyChallengeValidation(leaderboardId, score, scoreState);
			}
			else
			{
				SubmitScoreWithoutValidation(leaderboardId, score, scoreState);
			}
		}

		private void SubmitScoreWithDailyChallengeValidation(LeaderboardId leaderboardId, int score, LeaderboardScoreState scoreState)
		{
			Log.Info($"Making sure score is not locked before submitting: Leaderboard: {leaderboardId}, Score: {score}, ScoreState: {scoreState}");
			RequestLocalEntry(leaderboardId, delegate(LeaderboardEntry localEntry, long totalLeaderboardEntryCount, LeaderboardError error)
			{
				if (error != null)
				{
					Log.Info($"Not submitting score. Cannot verify that score state is not locked: Leaderboard: {leaderboardId}, Score: {score}, ScoreState: {scoreState}");
				}
				else
				{
					bool isScoreLocked = false;
					int currentScore = -1;
					if (localEntry != null)
					{
						isScoreLocked = localEntry.ScoreState == LeaderboardScoreState.Locked;
						currentScore = localEntry.Score;
					}
					if (MotorwaysScoreValidation.ShouldRecordScore(isScoreLocked, currentScore, score))
					{
						SubmitScoreWithoutValidation(leaderboardId, score, scoreState);
					}
					else
					{
						_player.MotorwaysExtendedUserProfile.MarkScoreAsSubmitted(leaderboardId);
					}
				}
			});
		}

		private void SubmitScoreWithoutValidation(LeaderboardId leaderboardId, int score, LeaderboardScoreState scoreState)
		{
			Log.Info("Submitting score of {0} to {1} with state {2}.", score, leaderboardId, scoreState);
			ClearLeaderboardEntryCache(leaderboardId);
			_leaderboardBackend.SubmitScore(leaderboardId, score, scoreState, GetSubmitRequestAction(leaderboardId, score));
		}

		private SubmitScoreRequestCompleted GetSubmitRequestAction(LeaderboardId id, int score)
		{
			return delegate
			{
				_leaderboardBackend.RequestLocalEntry(id, delegate(LeaderboardEntry entry, long count, LeaderboardError error)
				{
					if (error == null && entry != null && entry.Score >= score)
					{
						_player.MotorwaysExtendedUserProfile.MarkScoreAsSubmitted(id);
					}
				});
			};
		}

		public AsyncRequestHandle RequestTopEntries(LeaderboardId leaderboardId, int entryCount, [NotNull] EntryRequestCompleted entryRequestCompleted)
		{
			Log.Info("RequestTopEntries for {0}.", leaderboardId);
			LeaderboardEntryRequestDelegate requestDelegate = _leaderboardBackend.RequestTopEntries;
			Dictionary<LeaderboardId, CachedLeaderboardRequest> topLeaderboardEntryCache = _topLeaderboardEntryCache;
			return RequestEntries(leaderboardId, entryCount, entryRequestCompleted, requestDelegate, topLeaderboardEntryCache);
		}

		public AsyncRequestHandle RequestPlayerCenteredEntries(LeaderboardId leaderboardId, int entryCount, [NotNull] EntryRequestCompleted entryRequestCompleted)
		{
			Log.Info("RequestPlayerCenteredEntries for {0}.", leaderboardId);
			LeaderboardEntryRequestDelegate requestDelegate = _leaderboardBackend.RequestPlayerCenteredEntries;
			Dictionary<LeaderboardId, CachedLeaderboardRequest> playerCenteredLeaderboardEntryCache = _playerCenteredLeaderboardEntryCache;
			return RequestEntries(leaderboardId, entryCount, entryRequestCompleted, requestDelegate, playerCenteredLeaderboardEntryCache);
		}

		public AsyncRequestHandle RequestTopFriendFilteredEntries(LeaderboardId leaderboardId, int entryCount, [NotNull] EntryRequestCompleted entryRequestCompleted)
		{
			Log.Info("RequestTopFriendFilteredEntries for {0}.", leaderboardId);
			LeaderboardEntryRequestDelegate requestDelegate = _leaderboardBackend.RequestTopFriendFilteredEntries;
			Dictionary<LeaderboardId, CachedLeaderboardRequest> topFriendFilteredLeaderboardEntryCache = _topFriendFilteredLeaderboardEntryCache;
			return RequestEntries(leaderboardId, entryCount, entryRequestCompleted, requestDelegate, topFriendFilteredLeaderboardEntryCache);
		}

		public AsyncRequestHandle RequestHistogram(LeaderboardId leaderboardId, [NotNull] HistogramRequestCompleted histogramRequestCompleted)
		{
			Log.Info("RequestHistogram for {0}.", leaderboardId);
			if (_histogramCache.TryGetValue(leaderboardId, out var value) && !value.HasExpired)
			{
				Log.Info("Found histogram for {0} in cache.", leaderboardId);
				histogramRequestCompleted(value.Buckets, value.BucketSize, null);
				return AsyncRequestHandle.CompletedRequestHandle;
			}
			AsyncRequestHandle requestHandle = new AsyncRequestHandle();
			_histogramBackend.RequestHistogram(leaderboardId, delegate(List<int> buckets, int size, LeaderboardError error)
			{
				if (error == null)
				{
					_histogramCache.Remove(leaderboardId);
					_histogramCache.Add(leaderboardId, new CachedHistogramRequest(buckets, size));
				}
				if (requestHandle.IsActive)
				{
					histogramRequestCompleted(buckets, size, error);
				}
			});
			return requestHandle;
		}

		public void PresentError([NotNull] LeaderboardError error)
		{
			_leaderboardBackend.PresentError(error);
		}

		public bool IsLeaderboardTypeSupported(LeaderboardType type)
		{
			return _leaderboardBackend.IsLeaderboardTypeSupported(type);
		}

		public bool Authenticate(AuthenticationCompleted authenticationCompleted)
		{
			return _leaderboardBackend.Authenticate(authenticationCompleted);
		}

		private void LogInvalidLocalEntries(LeaderboardId leaderboardId, List<LeaderboardEntry> entries, LeaderboardEntry localEntry)
		{
			if (localEntry == null)
			{
				Log.Info($"No local entry - Leaderboard: {leaderboardId}");
				return;
			}
			if (localEntry.Rank == 0L)
			{
				Log.Info($"Unranked local entry: {localEntry} - Leaderboard: {leaderboardId}");
				return;
			}
			foreach (LeaderboardEntry entry in entries)
			{
				if (entry.Type != LeaderboardEntryType.Local)
				{
					if (localEntry.Rank < entry.Rank && localEntry.Score < entry.Score)
					{
						Log.Error($"Invalid local entry detected: Local entry is ranked higher than this entry, but the local entry's score is lower than this entry.\nLocalEntry: {localEntry}\nOtherEntry: {entry}\nLeaderboard: {leaderboardId}");
						break;
					}
					if (localEntry.Rank > entry.Rank && localEntry.Score > entry.Score)
					{
						Log.Error($"Invalid local entry detected: Local entry is ranked lower than this entry, but local entry's score is higher than this entry.\nLocalEntry: {localEntry}\nOtherEntry: {entry}\nLeaderboard: {leaderboardId}");
						break;
					}
				}
			}
		}

		private AsyncRequestHandle RequestEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted, LeaderboardEntryRequestDelegate requestDelegate, Dictionary<LeaderboardId, CachedLeaderboardRequest> cache)
		{
			if (cache.TryGetValue(leaderboardId, out var value) && !value.HasExpired)
			{
				Log.Info("Found entries for {0} in cache.", leaderboardId);
				entryRequestCompleted(value.Entries, value.TotalEntryCount, null);
				return AsyncRequestHandle.CompletedRequestHandle;
			}
			Log.Info("No cached entries found for {0}.", leaderboardId);
			AsyncRequestHandle requestHandle = new AsyncRequestHandle();
			requestDelegate(leaderboardId, entryCount, delegate(List<LeaderboardEntry> entries, long totalLeaderboardEntryCount, LeaderboardError error)
			{
				if (error != null)
				{
					if (requestHandle.IsActive)
					{
						entryRequestCompleted(entries, totalLeaderboardEntryCount, error);
					}
				}
				else if (!Diagnostics.Verify(entries != null, "Invalid state. Having no error implies we have valid entries, even if it's an empty list."))
				{
					if (requestHandle.IsActive)
					{
						entryRequestCompleted(entries, totalLeaderboardEntryCount, error);
					}
				}
				else
				{
					bool flag = false;
					int num = 0;
					for (int i = 0; i < entries.Count; i++)
					{
						if (entries[i].Type == LeaderboardEntryType.Local)
						{
							flag = true;
							num = i;
							break;
						}
					}
					if (flag && leaderboardId is RecurringLeaderboardId recurringLeaderboardId)
					{
						LeaderboardEntry leaderboardEntry = entries[num];
						if (leaderboardEntry.Timestamp != recurringLeaderboardId.Timestamp && recurringLeaderboardId.IsLeaderboardOpen())
						{
							Log.Info($"Local entry timestamp {leaderboardEntry.Timestamp} does not match expected timestamp {recurringLeaderboardId.Timestamp}. Ignoring local entry.");
							flag = false;
							entries.RemoveAt(num);
							num = 0;
						}
					}
					string arg = (flag ? "present" : "not present");
					Log.Info($"Request received for {leaderboardId}, local entry is {arg}");
					if (flag)
					{
						LeaderboardEntry leaderboardEntry2 = entries[num];
						if (num > entryCount)
						{
							if (entries.Count > entryCount)
							{
								entries.RemoveRange(entryCount, entries.Count - entryCount);
							}
							entries.Add(leaderboardEntry2);
						}
						LogInvalidLocalEntries(leaderboardId, entries, leaderboardEntry2);
						cache.Remove(leaderboardId);
						cache.Add(leaderboardId, new CachedLeaderboardRequest(entries, totalLeaderboardEntryCount));
						if (requestHandle.IsActive)
						{
							entryRequestCompleted(entries, totalLeaderboardEntryCount, error);
						}
					}
					else
					{
						RequestLocalEntry(leaderboardId, delegate(LeaderboardEntry localEntry, long localCount, LeaderboardError localRequestError)
						{
							if (localRequestError == null)
							{
								if (entries.Count > entryCount)
								{
									entries.RemoveRange(entryCount, entries.Count - entryCount);
								}
								if (localEntry == null)
								{
									localEntry = new LeaderboardEntry(string.Empty, string.Empty, LeaderboardEntryType.Local, 0, 0L, 0, LeaderboardScoreState.NotSubmitted);
								}
								entries.Add(localEntry);
								LogInvalidLocalEntries(leaderboardId, entries, localEntry);
								cache.Remove(leaderboardId);
								cache.Add(leaderboardId, new CachedLeaderboardRequest(entries, totalLeaderboardEntryCount));
							}
							else
							{
								Log.Warn("Failed to obtain local entry from {0} with error {1}.", leaderboardId, localRequestError);
							}
							if (requestHandle.IsActive)
							{
								entryRequestCompleted(entries, totalLeaderboardEntryCount, error);
							}
						});
					}
				}
			});
			return requestHandle;
		}

		public static int EncodeScoreContext(LeaderboardId leaderboardId, LeaderboardScoreState scoreState)
		{
			int num = 0;
			if (leaderboardId is RecurringLeaderboardId recurringLeaderboardId)
			{
				num = recurringLeaderboardId.Timestamp;
			}
			int num2 = num / 86400 << 2;
			return (int)scoreState | num2;
		}

		public static void DecodeScoreContext(int context, out int timeStamp, out LeaderboardScoreState scoreState)
		{
			timeStamp = (context >> 2) * 86400;
			scoreState = (LeaderboardScoreState)(context & 3);
		}
	}
}
