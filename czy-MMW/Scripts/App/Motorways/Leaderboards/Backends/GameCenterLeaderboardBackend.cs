using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Factory;
using Helpers.GameCenter;

namespace Motorways.Leaderboards.Backends
{
	public class GameCenterLeaderboardBackend : ILeaderboardBackend
	{
		private interface IEntryRequest
		{
			LeaderboardId LeaderboardId { get; }
		}

		private struct LocalEntryRequest : IEntryRequest
		{
			public LocalEntryRequestCompleted entryRequestCompleted;

			public LeaderboardId LeaderboardId { get; }

			public LocalEntryRequest(LeaderboardId leaderboardId, LocalEntryRequestCompleted entryRequestCompleted)
			{
				LeaderboardId = leaderboardId;
				this.entryRequestCompleted = entryRequestCompleted;
			}
		}

		private struct TopEntryRequest : IEntryRequest
		{
			public int entryCount;

			public EntryRequestCompleted entryRequestCompleted;

			public LeaderboardId LeaderboardId { get; }

			public TopEntryRequest(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
			{
				LeaderboardId = leaderboardId;
				this.entryCount = entryCount;
				this.entryRequestCompleted = entryRequestCompleted;
			}
		}

		private struct PlayerCenteredEntryRequest : IEntryRequest
		{
			public int entryCount;

			public EntryRequestCompleted entryRequestCompleted;

			public LeaderboardId LeaderboardId { get; }

			public PlayerCenteredEntryRequest(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
			{
				LeaderboardId = leaderboardId;
				this.entryCount = entryCount;
				this.entryRequestCompleted = entryRequestCompleted;
			}
		}

		private struct FriendEntryRequest : IEntryRequest
		{
			public int entryCount;

			public EntryRequestCompleted entryRequestCompleted;

			public LeaderboardId LeaderboardId { get; }

			public FriendEntryRequest(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
			{
				LeaderboardId = leaderboardId;
				this.entryCount = entryCount;
				this.entryRequestCompleted = entryRequestCompleted;
			}
		}

		private static readonly LeaderboardError UnknownError = new LeaderboardError(LeaderboardErrorCode.Unknown, StringId.LeaderboardError_Generic);

		private static readonly LeaderboardError NotAuthenticatedError = new LeaderboardError(LeaderboardErrorCode.NotAuthenticated, StringId.LeaderboardError_NotAuthenticatedGameCenter);

		private static readonly LeaderboardError RecurringLeaderboardUnsupportedError = new LeaderboardError(LeaderboardErrorCode.RecurringLeaderboardUnsupported, StringId.LeaderboardError_RecurringLeaderboardUnsupported);

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("GameCenterBackend");

		[Dependency]
		private IGameCenterAuthentication _gameCenterAuthentication;

		[Dependency]
		private TickRegistry _tickRegistry;

		private Queue<IEntryRequest> _entryRequests = new Queue<IEntryRequest>();

		private IEntryRequest entryRequestInProgress;

		public bool CanSubmitScoresOffline => true;

		public bool CanAuthenticate => false;

		public void RequestLocalEntry(LeaderboardId leaderboardId, LocalEntryRequestCompleted localEntryRequestCompleted)
		{
			if (!_gameCenterAuthentication.IsAuthenticated)
			{
				Log.Error($"Local entry request fail - Not authenticated with GameCenter - Leaderboard: {leaderboardId}");
				localEntryRequestCompleted(null, 0L, NotAuthenticatedError);
				return;
			}
			if (leaderboardId.IsRecurringLeaderboard && !GameCenterShared.GCSupportsRecurringLeaderboards())
			{
				Log.Error($"Local entry request fail - Recurring Leaderboards are not supported - Leaderboard: {leaderboardId}");
				localEntryRequestCompleted(null, 0L, RecurringLeaderboardUnsupportedError);
				return;
			}
			_entryRequests.Enqueue(new LocalEntryRequest(leaderboardId, localEntryRequestCompleted));
			if (_entryRequests.Count == 1)
			{
				_tickRegistry.AppTicking += Tick;
			}
		}

		public void SubmitScore(LeaderboardId leaderboardId, int score, LeaderboardScoreState scoreState, SubmitScoreRequestCompleted submitScoreRequestCompleted)
		{
			if (!_gameCenterAuthentication.IsAuthenticated)
			{
				Log.Error($"Submit score fail - Not authenticated with GameCenter - Leaderboard: {leaderboardId}, Score: {score}, ScoreState: {scoreState}");
				submitScoreRequestCompleted(submittedSuccessfully: false);
				return;
			}
			string backendLeaderboardId = GetBackendLeaderboardId(leaderboardId);
			int scoreContext = LeaderboardService.EncodeScoreContext(leaderboardId, scoreState);
			bool submittedSuccessfully = GameCenterShared.GCSetLeaderboardScore(backendLeaderboardId, score, scoreContext);
			submitScoreRequestCompleted(submittedSuccessfully);
		}

		public void RequestTopEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
		{
			if (!_gameCenterAuthentication.IsAuthenticated)
			{
				entryRequestCompleted(null, 0L, NotAuthenticatedError);
				return;
			}
			if (leaderboardId.IsRecurringLeaderboard && !GameCenterShared.GCSupportsRecurringLeaderboards())
			{
				entryRequestCompleted(null, 0L, RecurringLeaderboardUnsupportedError);
				return;
			}
			_entryRequests.Enqueue(new TopEntryRequest(leaderboardId, entryCount, entryRequestCompleted));
			if (_entryRequests.Count == 1)
			{
				_tickRegistry.AppTicking += Tick;
			}
		}

		public void RequestPlayerCenteredEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
		{
			if (!_gameCenterAuthentication.IsAuthenticated)
			{
				entryRequestCompleted(null, 0L, NotAuthenticatedError);
				return;
			}
			if (leaderboardId.IsRecurringLeaderboard && !GameCenterShared.GCSupportsRecurringLeaderboards())
			{
				entryRequestCompleted(null, 0L, RecurringLeaderboardUnsupportedError);
				return;
			}
			_entryRequests.Enqueue(new PlayerCenteredEntryRequest(leaderboardId, entryCount, entryRequestCompleted));
			if (_entryRequests.Count == 1)
			{
				_tickRegistry.AppTicking += Tick;
			}
		}

		public void RequestTopFriendFilteredEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
		{
			if (!_gameCenterAuthentication.IsAuthenticated)
			{
				entryRequestCompleted(null, 0L, NotAuthenticatedError);
				return;
			}
			if (leaderboardId.IsRecurringLeaderboard && !GameCenterShared.GCSupportsRecurringLeaderboards())
			{
				entryRequestCompleted(null, 0L, RecurringLeaderboardUnsupportedError);
				return;
			}
			_entryRequests.Enqueue(new FriendEntryRequest(leaderboardId, entryCount, entryRequestCompleted));
			if (_entryRequests.Count == 1)
			{
				_tickRegistry.AppTicking += Tick;
			}
		}

		public void PresentError(LeaderboardError error)
		{
		}

		private bool HaveRequestsToProcess()
		{
			if (entryRequestInProgress == null)
			{
				return _entryRequests.Count > 0;
			}
			return true;
		}

		private void Tick(float deltaTime)
		{
			if (!HaveRequestsToProcess())
			{
				_tickRegistry.AppTicking -= Tick;
			}
			else
			{
				ProcessEntryRequests();
			}
		}

		private void ProcessEntryRequests()
		{
			if (entryRequestInProgress == null)
			{
				if (_entryRequests.Count <= 0)
				{
					return;
				}
				IEntryRequest entryRequest = (entryRequestInProgress = _entryRequests.Dequeue());
				string backendLeaderboardId = GetBackendLeaderboardId(entryRequest.LeaderboardId);
				if (!(entryRequest is LocalEntryRequest))
				{
					if (!(entryRequest is TopEntryRequest))
					{
						if (!(entryRequest is FriendEntryRequest))
						{
							if (entryRequest is PlayerCenteredEntryRequest)
							{
								GameCenterShared.GCRequestPlayerCenteredLeaderboardEntries(backendLeaderboardId);
							}
						}
						else
						{
							GameCenterShared.GCRequestFriendLeaderboardEntries(backendLeaderboardId);
						}
					}
					else
					{
						GameCenterShared.GCRequestTopLeaderboardEntries(backendLeaderboardId);
					}
				}
				else
				{
					GameCenterShared.GCRequestLocalLeaderboardEntry(backendLeaderboardId);
				}
			}
			else
			{
				if (!GameCenterShared.GCIsLeaderboardRequestFinished())
				{
					return;
				}
				List<LeaderboardEntry> topEntries;
				LeaderboardError results = GetResults(out topEntries);
				Log.Info("Request finished! Leaderboard: {0}, RequestType: {1}, Received entry count: {2}, Error: {3}", entryRequestInProgress.LeaderboardId, entryRequestInProgress.GetType().FullName, topEntries.Count, results);
				IEntryRequest entryRequest2 = entryRequestInProgress;
				if (!(entryRequest2 is LocalEntryRequest localEntryRequest))
				{
					if (!(entryRequest2 is TopEntryRequest topEntryRequest))
					{
						if (!(entryRequest2 is PlayerCenteredEntryRequest playerCenteredEntryRequest))
						{
							if (entryRequest2 is FriendEntryRequest friendEntryRequest)
							{
								friendEntryRequest.entryRequestCompleted?.Invoke(topEntries, GameCenterShared.GCGetTotalLeaderboardEntryCount(), results);
							}
						}
						else
						{
							playerCenteredEntryRequest.entryRequestCompleted?.Invoke(topEntries, GameCenterShared.GCGetTotalLeaderboardEntryCount(), results);
						}
					}
					else
					{
						topEntryRequest.entryRequestCompleted?.Invoke(topEntries, GameCenterShared.GCGetTotalLeaderboardEntryCount(), results);
					}
				}
				else
				{
					LeaderboardEntry localEntry = ((topEntries.Count <= 0) ? null : topEntries[0]);
					localEntryRequest.entryRequestCompleted?.Invoke(localEntry, GameCenterShared.GCGetTotalLeaderboardEntryCount(), results);
				}
				entryRequestInProgress = null;
			}
		}

		private static LeaderboardError GetResults(out List<LeaderboardEntry> topEntries)
		{
			topEntries = new List<LeaderboardEntry>();
			int num = GameCenterShared.GCGetDownloadedLeaderboardEntryCount();
			if (num < 0)
			{
				return UnknownError;
			}
			for (int i = 0; i < num; i++)
			{
				LeaderboardEntry leaderboardEntryAtIndex = GetLeaderboardEntryAtIndex(i);
				if (leaderboardEntryAtIndex != null)
				{
					topEntries.Add(leaderboardEntryAtIndex);
				}
			}
			return null;
		}

		private static LeaderboardEntry GetLeaderboardEntryAtIndex(int entryIndex)
		{
			IntPtr id = IntPtr.Zero;
			IntPtr name = IntPtr.Zero;
			int context = 0;
			int score = 0;
			long rank = 0L;
			bool isLocal = false;
			bool isFriend = false;
			if (!GameCenterShared.GCGetRetrievedLeaderboardEntry(entryIndex, ref id, ref name, ref score, ref rank, ref context, ref isLocal, ref isFriend))
			{
				return null;
			}
			string id2 = Marshal.PtrToStringAuto(id);
			string text = Marshal.PtrToStringAuto(name);
			string text2 = "";
			foreach (int num in text)
			{
				if (num != 8236 && num != 8234 && num != 8235 && num != 8206 && num != 8207)
				{
					text2 += (char)num;
				}
			}
			text = text2;
			LeaderboardEntryType type = LeaderboardEntryType.Global;
			if (isLocal)
			{
				type = LeaderboardEntryType.Local;
			}
			else if (isFriend)
			{
				type = LeaderboardEntryType.Friend;
			}
			LeaderboardService.DecodeScoreContext(context, out var timeStamp, out var scoreState);
			Log.Info("Entry retrieved from backend - Name: {0}, Rank: {1}, Score: {2}, Context: {3}, Timestamp: {4}, Score State: {5}", text, rank, score, context, timeStamp, scoreState);
			return new LeaderboardEntry(id2, text, type, score, rank, timeStamp, scoreState);
		}

		public bool IsLeaderboardTypeSupported(LeaderboardType type)
		{
			return true;
		}

		public bool Authenticate(AuthenticationCompleted authenticationCompleted)
		{
			return false;
		}

		private string GetBackendLeaderboardId(LeaderboardId leaderboardId)
		{
			if (!(leaderboardId is CityLeaderboardId cityLeaderboardId))
			{
				if (!(leaderboardId is DailyLeaderboardId dailyLeaderboardId))
				{
					if (leaderboardId is WeeklyLeaderboardId weeklyLeaderboardId)
					{
						char c = ((weeklyLeaderboardId.Week == ChallengeSystem.LeaderboardWeek.WeekA) ? 'a' : 'b');
						return $"grp.week_{c}";
					}
					Diagnostics.FailAssert("Invalid ILeaderboard derived type: {0}", leaderboardId);
					return null;
				}
				return "grp." + dailyLeaderboardId.Day.ToString().ToLower();
			}
			if (cityLeaderboardId.Mode == CityGameMode.CityChallenge)
			{
				return $"grp.{cityLeaderboardId.City.ToString().ToLower()}_{cityLeaderboardId.Mode.ToString().ToLower()}_challenge{cityLeaderboardId.CityChallengeIndex}";
			}
			CityLeaderboardId cityLeaderboardId2 = cityLeaderboardId;
			return "grp." + cityLeaderboardId2.City.ToString().ToLower() + "_" + cityLeaderboardId2.Mode.ToString().ToLower();
		}
	}
}
