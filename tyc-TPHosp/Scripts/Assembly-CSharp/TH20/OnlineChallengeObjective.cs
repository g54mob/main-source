#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class OnlineChallengeObjective : LevelObjective
	{
		public class PlayerInfo
		{
			public OnlinePlayerID OnlinePlayerID;

			public string PlayerName;

			public bool IsLocalPlayer;

			public Sprite RivalIcon;

			public OnlineChallengeDefinition.RivalScoreData AIScoreData;

			public Color PlayerColor = Color.grey;

			public ChallengeData ChallengeData;

			public OnlineScreenshotData ScreenshotData;

			public bool IsAI => AIScoreData != null;

			public PlayerInfo(OnlinePlayerID onlinePlayerID, MetagameSaveHeader saveHeader = null)
			{
				OnlinePlayerID = onlinePlayerID;
				OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(OnlinePlayerID);
				IsLocalPlayer = onlinePlayerID == OnlineManager.GetLocalPlayerID();
				if (playerInfo != null)
				{
					PlayerName = playerInfo.DisplayName;
				}
				else if (IsLocalPlayer && saveHeader != null)
				{
					PlayerName = saveHeader.OrganisationName;
				}
				else
				{
					PlayerName = ScriptLocalization.Misc.Unknown_CS;
				}
			}

			public PlayerInfo(uint id, string name, bool isLocalPlayer)
			{
				OnlinePlayerID = id;
				PlayerName = name;
				IsLocalPlayer = isLocalPlayer;
				RivalIcon = null;
				AIScoreData = null;
			}

			public PlayerInfo(RivalFoundationDefinition rivalFoundationDefinition, OnlineChallengeDefinition.RivalScoreData scoreData)
			{
				OnlinePlayerID = rivalFoundationDefinition.DummySteamID;
				PlayerName = rivalFoundationDefinition.FoundationName.Translation;
				IsLocalPlayer = false;
				RivalIcon = rivalFoundationDefinition.Icon;
				AIScoreData = scoreData;
			}

			public void RestoreFromSave()
			{
				if (RivalIcon == null)
				{
					OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(OnlinePlayerID);
					if (playerInfo != null)
					{
						PlayerName = playerInfo.DisplayName;
					}
				}
			}
		}

		private struct PositionDataItem
		{
			public OnlinePlayerID OnlinePlayerID;

			public float Score;
		}

		private readonly Level _level;

		[NonSerialized]
		private OnlineChallengeState _state;

		public bool IsOfflineChallenge;

		public string ObjectiveUniqueID;

		public string ObjectiveScreenshotUniqueID;

		public OnlinePlayerID LocalPlayerID;

		public OnlineChallengeData LocalPlayerObjectiveData;

		public OnlineScreenshotData LocalPlayerScreenshotData;

		public Dictionary<OnlinePlayerID, PlayerInfo> PlayerInfoDictionary = new Dictionary<OnlinePlayerID, PlayerInfo>();

		[NonSerialized]
		public Dictionary<OnlinePlayerID, OnlineChallengeData> FriendDataCache;

		public uint TimestampLastSeen;

		public bool ObjectiveFinishedThisSession;

		[NonSerialized]
		private List<PositionDataItem> _positions;

		[NonSerialized]
		private string[] _positionStrings;

		public static int MaxChallengePlayers => 5;

		public static int MaxChallengeRivals => MaxChallengePlayers - 1;

		public new OnlineChallengeDefinition Definition { get; private set; }

		public List<OnlinePlayerID> PlayerList => PlayerInfoDictionary.Keys.ToList();

		public OnlineChallengeObjective(Level level, string uniqueReference, OnlineChallengeDefinition definition)
			: base(level, uniqueReference, definition, isVisible: true, isDiscovered: false, isReplayable: true, startImmediately: false)
		{
			_level = level;
			Definition = definition;
			FriendDataCache = new Dictionary<OnlinePlayerID, OnlineChallengeData>();
			ObjectiveUniqueID = ((Definition.LeaderboardName != null) ? Definition.LeaderboardName : string.Empty);
			ObjectiveScreenshotUniqueID = ObjectiveUniqueID + "Screenshot";
			InitialisePositionStrings();
			_positions = new List<PositionDataItem>();
			ChangeState<InitialiseState>();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			InitialisePositionStrings();
			_positions = new List<PositionDataItem>();
			FriendDataCache = new Dictionary<OnlinePlayerID, OnlineChallengeData>();
			if (OnlineManager.IsInitializedAndLoggedOn() && (base.State == ObjectiveState.Active || base.State == ObjectiveState.Finished) && LocalPlayerID != OnlineManager.GetLocalPlayerID())
			{
				Abandon();
			}
			else
			{
				ChangeState<InitialiseState>();
			}
		}

		public void OnConnectionEstablished()
		{
			if (_state != null)
			{
				_state.ConnectionEstablished();
			}
		}

		public override void Destroy()
		{
			if (_state != null)
			{
				_state.Exit();
				_state = null;
			}
			base.Destroy();
		}

		public void StartStateMachine()
		{
			switch (base.State)
			{
			case ObjectiveState.Undiscovered:
				ChangeState<UndiscoveredState>();
				break;
			case ObjectiveState.Unstarted:
				ChangeState<UnstartedState>();
				break;
			case ObjectiveState.Active:
				ChangeState<ActiveState>();
				break;
			case ObjectiveState.Finished:
				ChangeState<FinishedState>();
				break;
			}
		}

		private void InitialisePositionStrings()
		{
			if (_positionStrings == null)
			{
				_positionStrings = new string[8] { "Online/OrdinalNumber_First_CS", "Online/OrdinalNumber_Second_CS", "Online/OrdinalNumber_Third_CS", "Online/OrdinalNumber_Fourth_CS", "Online/OrdinalNumber_Fifth_CS", "Online/OrdinalNumber_Sixth_CS", "Online/OrdinalNumber_Seventh_CS", "Online/OrdinalNumber_Eigth_CS" };
			}
		}

		public override void Update(float timeDelta, float unscaledTimeDelta)
		{
			if (_state != null)
			{
				_state.Update(unscaledTimeDelta);
			}
			base.Update(timeDelta, unscaledTimeDelta);
		}

		public void Reset()
		{
			if (!IsReplayable)
			{
				return;
			}
			foreach (ObjectiveSubGoal subGoal in SubGoals)
			{
				subGoal.Destroy();
			}
			SubGoals = null;
			DaysElapsed = 0;
			CurrentHiScore = 0;
			CreateSubGoals();
			PlayerInfoDictionary.Clear();
			base.State = ObjectiveState.Unstarted;
			ChangeState<UnstartedState>();
		}

		protected override void OnDiscover()
		{
			base.OnDiscover();
			if (!(_state is InitialiseState))
			{
				ChangeState<UnstartedState>();
			}
		}

		protected override void OnStart()
		{
			if (PlayerInfoDictionary.Count > MaxChallengeRivals)
			{
				Logging.Error(LogChannels.Online, "Trying to start challenge, but we have too many rivals in the list! ({0}, but we should have {1} or less)", PlayerInfoDictionary.Count, MaxChallengeRivals);
				Abandon();
				return;
			}
			IsOfflineChallenge = !OnlineManager.IsInitializedAndLoggedOn();
			LocalPlayerID = OnlineManager.GetLocalPlayerID();
			OnlineChallengeData onlineChallengeData = new OnlineChallengeData(LocalPlayerID, _level.TimelineManager.CurrentGameDate.AsTotalDays(), Definition.TimeLength);
			LocalPlayerScreenshotData = new OnlineScreenshotData();
			MetagameSaveHeader metagameSaveHeaderForSlot = _level.App.SaveSystem.GetMetagameSaveHeaderForSlot(_level.App.SaveSystem.MostRecentMetagameSaveSlotIndex);
			PlayerInfo playerInfo = new PlayerInfo(LocalPlayerID, metagameSaveHeaderForSlot);
			playerInfo.ChallengeData = onlineChallengeData;
			playerInfo.ScreenshotData = LocalPlayerScreenshotData;
			PlayerInfoDictionary.Add(LocalPlayerID, playerInfo);
			LocalPlayerObjectiveData = onlineChallengeData;
			int num = 0;
			foreach (KeyValuePair<OnlinePlayerID, PlayerInfo> item in PlayerInfoDictionary)
			{
				PlayerInfo value = item.Value;
				value.PlayerColor = GameAlgorithms.Config.OnlineChallengeColors[num];
				if (value.IsLocalPlayer)
				{
					num++;
					continue;
				}
				OnlineChallengeData value2;
				if (value.IsAI)
				{
					value.ChallengeData = Definition.GenerateChallengeData(value.AIScoreData);
				}
				else if (FriendDataCache.TryGetValue(value.OnlinePlayerID, out value2))
				{
					value.ChallengeData = value2;
				}
				num++;
			}
			LocalPlayerObjectiveData.PlayersList.AddRange(PlayerList);
			ChangeState<ActiveState>();
			base.OnStart();
		}

		protected override void OnFinish(CompletionType completionType)
		{
			base.OnFinish(completionType);
			base.Level.Metagame.ObjectiveEvents.OnObjectiveCompleted.InvokeSafe(this, completionType);
			ObjectiveFinishedThisSession = true;
			ChangeState<FinishedState>();
			string text = $"<style=\"AdvisorHighlight\">{StringUtils.FormatNumber((int)GetLocalPlayerScore())}</style>";
			string text2 = $"<style=\"AdvisorHighlight\">{LocalizationManager.GetTranslation(GetLocalPlayerPositionString(), FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters: true)}</style>";
			string text3 = $"<style=\"Rewards\">{Definition.GetRewardsString(this, GetRewards(completionType))}</style>";
			string message = string.Format(ScriptLocalization.Online.CompleteAdvisorMessage_CS, Definition.NameLocalised.Translation, text, text2, text3);
			base.Level.Advisor.PushMessage(new AdvisorMessageDefinition
			{
				Duration = 12f,
				Icon = null,
				Message = message,
				UserCanDismiss = true
			}, interrupt: true, Advisor.PriorityLevel.Medium);
			base.Level.Metagame.OnlineMetadataManager.Upload(immediately: true);
			PlatformStatsAndAchievements.TriggerAchievement(AchievementId.MultiplayerChallenge);
		}

		protected override void OnSubGoalUpdated(ObjectiveSubGoal subGoal)
		{
			base.OnSubGoalUpdated(subGoal);
			if (subGoal.GetOwnerObjective().Definition == Definition && _state != null)
			{
				_state.OnSubGoalUpdated(subGoal);
			}
		}

		protected override void OnTimelineUpdated(int day, int month, int year)
		{
			base.OnTimelineUpdated(day, month, year);
			if (_state != null)
			{
				_state.OnTimelineUpdated(DaysElapsed);
			}
		}

		public OnlineScreenshotData.Screenshot TakeScreenshot(int width, int height, string caption, int quality)
		{
			RenderToTexture rtt = new RenderToTexture(Camera.main, width, height);
			OnlineScreenshotData.Screenshot result = LocalPlayerScreenshotData.AddScreenshotData(rtt, caption, DaysElapsed, quality);
			_level.ObjectiveEvents.OnLocalPlayerScreenshotUpdated.InvokeSafe(this, LocalPlayerScreenshotData);
			return result;
		}

		public void ResetLocalPlayerScreenshotData()
		{
			PlayerInfo playerInfo = GetPlayerInfo(LocalPlayerID);
			if (playerInfo != null)
			{
				LocalPlayerScreenshotData = new OnlineScreenshotData();
				playerInfo.ScreenshotData = LocalPlayerScreenshotData;
				_level.ObjectiveEvents.OnLocalPlayerScreenshotUpdated.InvokeSafe(this, LocalPlayerScreenshotData);
			}
		}

		public PlayerInfo GetPlayerInfo(OnlinePlayerID onlinePlayerID)
		{
			PlayerInfoDictionary.TryGetValue(onlinePlayerID, out var value);
			return value;
		}

		public Color GetPlayerColor(OnlinePlayerID onlinePlayerID)
		{
			return GetPlayerInfo(onlinePlayerID)?.PlayerColor ?? Color.black;
		}

		public void SetData(OnlinePlayerID onlinePlayerID, OnlineChallengeData data)
		{
			if (onlinePlayerID == LocalPlayerID || !onlinePlayerID.IsValid())
			{
				return;
			}
			PlayerInfo playerInfo = GetPlayerInfo(onlinePlayerID);
			if (playerInfo != null)
			{
				playerInfo.ChallengeData = data;
				_level.ObjectiveEvents.OnFriendDataUpdated.InvokeSafe(this, onlinePlayerID, data);
				if (data.LastUpdateTime > TimestampLastSeen)
				{
					_level.ObjectiveEvents.OnNewOnlineDataReceived.InvokeSafe(this, onlinePlayerID);
				}
			}
		}

		public ChallengeData GetData(OnlinePlayerID onlinePlayerID)
		{
			if (onlinePlayerID == LocalPlayerID)
			{
				return LocalPlayerObjectiveData;
			}
			return GetPlayerInfo(onlinePlayerID)?.ChallengeData;
		}

		public void SetScreenshotData(OnlinePlayerID onlinePlayerID, OnlineScreenshotData data)
		{
			if (!(onlinePlayerID == LocalPlayerID) && onlinePlayerID.IsValid())
			{
				PlayerInfo playerInfo = GetPlayerInfo(onlinePlayerID);
				if (playerInfo != null)
				{
					playerInfo.ScreenshotData = data;
					_level.ObjectiveEvents.OnFriendScreenshotUpdated.InvokeSafe(this, onlinePlayerID, data);
				}
			}
		}

		public OnlineScreenshotData GetScreenshotData(OnlinePlayerID onlinePlayerID)
		{
			if (onlinePlayerID == LocalPlayerID)
			{
				return LocalPlayerScreenshotData;
			}
			return GetPlayerInfo(onlinePlayerID)?.ScreenshotData;
		}

		private void ChangeState<T>() where T : OnlineChallengeState, new()
		{
			if (_state != null)
			{
				_state.Exit();
				_state = null;
			}
			_state = new T
			{
				Owner = this,
				Level = _level
			};
			_state.Enter();
		}

		public void LogNotificationView()
		{
			TimestampLastSeen = OnlineManager.GetServerTime();
			base.Level.ObjectiveEvents.OnOnlineChallengeNotificationsViewed.InvokeSafe(this);
		}

		public BaseOnlineDataFile GetDownloadFileInfo(OnlinePlayerID onlinePlayerID)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return null;
			}
			return OnlineManager.DataFiles.GetFriendDataFile(OnlineFileClass.OnlineChallenge, ObjectiveUniqueID, onlinePlayerID);
		}

		public int GetNumUnseenNotifications()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return 0;
			}
			if (FriendDataCache == null)
			{
				return 0;
			}
			int num = 0;
			foreach (KeyValuePair<OnlinePlayerID, OnlineChallengeData> item in FriendDataCache)
			{
				OnlineChallengeData value = item.Value;
				if (value != null && !(value.PlayerID == OnlineManager.GetLocalPlayerID()) && !OnlineManager.IsUserBlocked(value.PlayerID) && TimestampLastSeen < value.LastUpdateTime)
				{
					num++;
				}
			}
			return num;
		}

		public float GetLocalPlayerScore()
		{
			return LocalPlayerObjectiveData.GetScore(DaysElapsed);
		}

		public string GetLocalPlayerPositionString()
		{
			_positions.Clear();
			foreach (KeyValuePair<OnlinePlayerID, PlayerInfo> item in PlayerInfoDictionary)
			{
				ChallengeData data = GetData(item.Key);
				if (data != null)
				{
					_positions.Add(new PositionDataItem
					{
						OnlinePlayerID = item.Key,
						Score = data.GetScore(DaysElapsed)
					});
				}
				else
				{
					_positions.Add(new PositionDataItem
					{
						OnlinePlayerID = item.Key,
						Score = 0f
					});
				}
			}
			_positions.Sort((PositionDataItem p1, PositionDataItem p2) => p2.Score.CompareTo(p1.Score));
			for (int num = 0; num < _positions.Count; num++)
			{
				if (num >= _positionStrings.Length)
				{
					return string.Empty;
				}
				if (_positions[num].OnlinePlayerID == OnlineManager.GetLocalPlayerID())
				{
					return _positionStrings[num];
				}
			}
			return string.Empty;
		}

		public static string GetUniqueBrokenChallengeName(LevelConfig levelConfig, ObjectiveDefinition definition)
		{
			return StringUtils.RemoveAllSpaces($"<!-MissingTranslation[{levelConfig.DisplayNameLocalised.Term}]-!>_<!-MissingTranslation[{definition.NameLocalised.Term}]-!>");
		}

		public override bool ShowGUIOnDiscover()
		{
			return false;
		}

		public override void OnMouseSelect()
		{
			GeneralNotificationMenu generalNotificationMenu = _level.HUD.FindMenu<GeneralNotificationMenu>();
			if (generalNotificationMenu != null)
			{
				generalNotificationMenu.ToggleMode(GeneralNotificationMenu.Category.Online);
			}
		}
	}
}
