using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerLeaderboardBoast : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerLeaderboardBoastDefinition _definition;

		public AdvisorTriggerLeaderboardBoast(AdvisorTriggerLeaderboardBoastDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (Level.IsSandbox())
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (!PlatformFeatureSupport.IsFeatureSupported(_definition.FeatureRequired))
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (Level.TimelineManager.TotalGameMonthsPassed < _definition.NumMonthsUntilShow)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (OnlineManager.GetFriendCount() <= 0)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			foreach (KeyValuePair<OnlinePlayerID, OnlineMetadata> item in Level.Metagame.OnlineMetadataManager.GetMetadataCache())
			{
				if (!(item.Key == OnlineManager.GetLocalPlayerID()) && Level.Metagame.CareerStatsManager.GetFriendScore(CareerStatsManager.Type.LevelHospitalValue, item.Key, out var _))
				{
					return _definition.Priority;
				}
			}
			return Advisor.PriorityLevel.DontShow;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return result;
			}
			Dictionary<OnlinePlayerID, OnlineMetadata> metadataCache = Level.Metagame.OnlineMetadataManager.GetMetadataCache();
			if (metadataCache.Count - 1 <= 0)
			{
				result.Message = ScriptLocalization.Advisor.CheckLeaderboards_CS;
				result.Duration = _definition.MessageLifetime;
				return result;
			}
			List<CareerStatsManager.Type> leaderboardPlaylistYearEnd = Level.Config.GetLeaderboardConfig().LeaderboardPlaylistYearEnd;
			CareerStatsManager.Type type = leaderboardPlaylistYearEnd[(int)RandomUtils.GlobalRandomInstance.NextDouble(0.0, leaderboardPlaylistYearEnd.Count)];
			int localPlayerStat = Level.Metagame.CareerStatsManager.GetLocalPlayerStat(type);
			List<OnlinePlayerID> list = new List<OnlinePlayerID>();
			OnlinePlayerID onlinePlayerID = OnlineManager.GetLocalPlayerID();
			int num = localPlayerStat;
			foreach (KeyValuePair<OnlinePlayerID, OnlineMetadata> item in metadataCache)
			{
				if (Level.Metagame.CareerStatsManager.GetFriendScore(type, item.Key, out var score) && score > 0)
				{
					if (score > num)
					{
						num = score;
						onlinePlayerID = item.Key;
					}
					list.Add(item.Key);
				}
			}
			if (list.Count <= 0)
			{
				result.Message = ScriptLocalization.Advisor.CheckLeaderboards_CS;
				result.Duration = _definition.MessageLifetime;
				return result;
			}
			if (!_definition.StatStrings.TryGetValue(type, out var _))
			{
				result.Message = ScriptLocalization.Advisor.CheckLeaderboards_CS;
				result.Duration = _definition.MessageLifetime;
				return result;
			}
			int index = (int)RandomUtils.GlobalRandomInstance.NextDouble(0.0, list.Count);
			OnlinePlayerID onlinePlayerID2 = list[index];
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(onlinePlayerID2);
			string arg = ((playerInfo != null) ? playerInfo.DisplayName : string.Empty);
			if (!Level.Metagame.CareerStatsManager.GetFriendScore(type, onlinePlayerID2, out var score2))
			{
				result.Message = ScriptLocalization.Advisor.CheckLeaderboards_CS;
				result.Duration = _definition.MessageLifetime;
				return result;
			}
			bool flag = score2 < localPlayerStat;
			bool flag2 = score2 > localPlayerStat;
			string arg2;
			string arg3;
			switch (type)
			{
			case CareerStatsManager.Type.LevelCureRate:
			case CareerStatsManager.Type.LevelStaffMorale:
			case CareerStatsManager.Type.LevelReputation:
				arg2 = StringUtils.FormatPercentageValue((float)score2 / 100f);
				arg3 = StringUtils.FormatPercentageValue((float)localPlayerStat / 100f);
				break;
			case CareerStatsManager.Type.LevelHospitalValue:
			case CareerStatsManager.Type.LevelBalance:
			case CareerStatsManager.Type.LevelYearlyIncome:
				arg2 = StringUtils.FormatCurrency(score2);
				arg3 = StringUtils.FormatCurrency(localPlayerStat);
				break;
			case CareerStatsManager.Type.LevelPrestige:
			case CareerStatsManager.Type.LevelStaffCount:
			case CareerStatsManager.Type.LevelCuresPerYear:
				arg2 = StringUtils.FormatInteger(score2);
				arg3 = StringUtils.FormatInteger(localPlayerStat);
				break;
			default:
				result.Message = ScriptLocalization.Advisor.CheckLeaderboards_CS;
				result.Duration = _definition.MessageLifetime;
				return result;
			}
			arg = $"<style=\"AdvisorHighlight\">{arg}</style>";
			arg2 = $"<style=\"AdvisorHighlight\">{arg2}</style>";
			arg3 = $"<style=\"AdvisorHighlight\">{arg3}</style>";
			string text = $"<style=\"AdvisorHighlight\">{_definition.StatStrings[type].Translation}</style>";
			if (onlinePlayerID == OnlineManager.GetLocalPlayerID())
			{
				result.Message = string.Format(_definition.PlayerTopScoreMessage.Translation, text, arg3);
				result.Duration = _definition.MessageLifetime;
				return result;
			}
			if (onlinePlayerID == onlinePlayerID2)
			{
				result.Message = string.Format(_definition.FriendTopScoreMessage.Translation, arg, text, arg2, arg3);
				result.Duration = _definition.MessageLifetime;
				return result;
			}
			if (flag)
			{
				result.Message = string.Format(_definition.FriendLowerMessageLocalised.Translation, arg, text, arg2, arg3);
				result.Duration = _definition.MessageLifetime;
				return result;
			}
			if (flag2)
			{
				result.Message = string.Format(_definition.FriendHigherMessageLocalised.Translation, arg, text, arg2, arg3);
				result.Duration = _definition.MessageLifetime;
				return result;
			}
			result.Message = ScriptLocalization.Advisor.CheckLeaderboards_CS;
			result.Duration = _definition.MessageLifetime;
			return result;
		}
	}
}
