using System;
using System.Collections.Generic;
using Factory;
using FixMath;
using Motorways.Models;
using Server;
using Unity.Profiling;
using UnityEngine;

namespace Motorways
{
	public class MotorwaysAchievementDefinition : AchievementDefinition
	{
		[Flags]
		public enum AchievementGameMode
		{
			Normal = 1,
			Endless = 2,
			Expert = 4,
			Creative = 8,
			Everything = 0xF
		}

		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("MotorwaysAchievementDefinition");

		private static readonly ProfilerMarker Profiler_UpgradeLengthMotorway = new ProfilerMarker(ProfilerCategory.Scripts, "MotorwaysAchievementDefinition.UpgradeLength(Motorway)");

		private static readonly ProfilerMarker Profiler_UpgradeLengthPassage = new ProfilerMarker(ProfilerCategory.Scripts, "MotorwaysAchievementDefinition.UpgradeLength(Passage)");

		public int IntValue { get; private set; }

		public string CityName { get; private set; }

		public int ChallengeIndex { get; private set; } = -1;

		public AchievementType Type { get; private set; }

		public AchievementScale Scale { get; private set; }

		public AchievementGameMode RequiredGameMode { get; private set; } = AchievementGameMode.Everything;

		public UpgradeType UpgradeType { get; private set; }

		public StringId Description { get; protected set; }

		public bool DoesGameModeMatch(GameMode otherMode)
		{
			return otherMode switch
			{
				GameMode.Normal => RequiredGameMode.HasFlag(AchievementGameMode.Normal), 
				GameMode.Endless => RequiredGameMode.HasFlag(AchievementGameMode.Endless), 
				GameMode.Expert => RequiredGameMode.HasFlag(AchievementGameMode.Expert), 
				GameMode.Creative => RequiredGameMode.HasFlag(AchievementGameMode.Creative), 
				_ => false, 
			};
		}

		public bool IsRetroactivelySatisfied(ActivePlayer player)
		{
			switch (Scale)
			{
			case AchievementScale.City:
				if (Type == AchievementType.Score)
				{
					return IsCityScoreAchievementCompleted(player, ChallengeIndex);
				}
				return false;
			case AchievementScale.Game:
				return false;
			case AchievementScale.Lifetime:
				return IsLifetimeAchievementSatisfied(player);
			default:
				return false;
			}
		}

		private IEnumerable<GameMode> GetSupportedGameModes()
		{
			if (DoesGameModeMatch(GameMode.Normal))
			{
				yield return GameMode.Normal;
			}
			if (DoesGameModeMatch(GameMode.Endless))
			{
				yield return GameMode.Endless;
			}
			if (DoesGameModeMatch(GameMode.Expert))
			{
				yield return GameMode.Expert;
			}
			if (DoesGameModeMatch(GameMode.Creative))
			{
				yield return GameMode.Creative;
			}
		}

		private bool IsCityScoreAchievementCompleted(ActivePlayer player, int challengeIndex)
		{
			if (!Diagnostics.Verify(Scale == AchievementScale.City && Type == AchievementType.Score, "IsCityScoreAchievementCompleted called with achievement of scale {0} and type {1}. Only valid for scale City and type Score", Scale, Type))
			{
				return false;
			}
			int num = 0;
			foreach (GameMode supportedGameMode in GetSupportedGameModes())
			{
				if (challengeIndex == -1 || challengeIndex == -2)
				{
					if (challengeIndex == -1)
					{
						MotorwaysCityStatistics cityStatisticsForCity = player.GetCityStatisticsForCity(CityName, supportedGameMode);
						if (cityStatisticsForCity != null)
						{
							num = Mathf.Max(cityStatisticsForCity.MaxTrips, num);
						}
					}
					foreach (CityChallengeStatistics cityChallengeScore2 in player.GetCityChallengeScores(CityName, supportedGameMode))
					{
						if (cityChallengeScore2 != null)
						{
							num = Mathf.Max(cityChallengeScore2.BestScore, num);
						}
					}
				}
				else
				{
					CityChallengeStatistics cityChallengeScore = player.GetCityChallengeScore(CityName, supportedGameMode, challengeIndex);
					if (cityChallengeScore != null)
					{
						num = Mathf.Max(cityChallengeScore.BestScore, num);
					}
				}
			}
			return num >= IntValue;
		}

		public bool IsGameAchievementSatisfied(MotorwaysGame game)
		{
			if (!Diagnostics.Verify(Scale == AchievementScale.City || Scale == AchievementScale.Game, "Can't check if the achievement is satisfied when of scale {0}", Scale))
			{
				return false;
			}
			if (!DoesGameModeMatch(game.StartedWithGameMode))
			{
				return false;
			}
			if (Diagnostics.Verify(Scale == AchievementScale.Game || (Scale == AchievementScale.City && CityName == game.MapDefinition.cityName)))
			{
				switch (Type)
				{
				case AchievementType.Score:
					return game.Simulation.GetModel<ScoreModel>().Score >= IntValue;
				case AchievementType.UpgradesUsed:
					return CheckGameUpgradesUsedAchievement(game);
				case AchievementType.UpgradeLength:
					return CheckUpgradeLengthAchievement(game);
				case AchievementType.ClearBigPin:
				{
					ModelListEnumerator<DestinationModel> enumerator = game.Simulation.GetModels<DestinationModel>().GetEnumerator();
					while (enumerator.MoveNext())
					{
						DestinationModel current = enumerator.Current;
						if (current.CurrentFrame.OvercrowdingTime > Fix64.Zero && current.NextFrame.OvercrowdingTime <= Fix64.Zero && !current.IsOvercrowding)
						{
							return true;
						}
					}
					return false;
				}
				case AchievementType.UseAllUpgrades:
					return CheckUsedAllUpgradesAchievement(game);
				case AchievementType.EndlessMilestones:
					return game.Simulation.GetModel<ScoreModel>().CurrentEfficiencyMilestone >= IntValue;
				}
			}
			Diagnostics.FailAssert("We failed to find a game/city condition that meets achievement: {0} ({1}, {2}, {3}, {4})", base.Id, Scale, Type, IntValue, UpgradeType);
			return false;
		}

		public bool IsLifetimeAchievementSatisfied(ActivePlayer player)
		{
			if (!Diagnostics.Verify(Scale == AchievementScale.Lifetime, "Can't check non-lifetime achievements using this method!"))
			{
				return false;
			}
			switch (Type)
			{
			case AchievementType.Score:
				return player.AchievementStatistics.TotalPointsScored >= IntValue;
			case AchievementType.Tutorial:
				return player.IsAnyTutorialCompleted;
			case AchievementType.TreesBulldozed:
				return player.AchievementStatistics.TreesBulldozed >= IntValue;
			case AchievementType.DailyChallenge:
				return player.AchievementStatistics.DailyChallengesPlayed >= IntValue;
			case AchievementType.WeeklyChallenge:
				return player.AchievementStatistics.WeeklyChallengesPlayed >= IntValue;
			case AchievementType.UpgradesUsed:
				return player.AchievementStatistics.GetTotalUpgradesUsed(UpgradeType) >= IntValue;
			case AchievementType.DeletedUpgrades:
				return player.AchievementStatistics.GetTotalUpgradesDeleted(UpgradeType) >= IntValue;
			case AchievementType.EndlessMilestones:
				return player.AchievementStatistics.TotalEndlessMilestonesAchieved >= IntValue;
			default:
				Diagnostics.FailAssert("We failed to find a lifetime condition that meets achievement: {0} ({1}, {2}, {3})", base.Id, Scale, Type, IntValue);
				return false;
			}
		}

		public override bool InitFromAchievementData(AchievementData achievementData, IScope scope)
		{
			if (base.InitFromAchievementData(achievementData, scope) && achievementData is MotorwaysAchievementData motorwaysAchievementData)
			{
				IntValue = motorwaysAchievementData.intValue;
				CityName = motorwaysAchievementData.cityName;
				ChallengeIndex = motorwaysAchievementData.challengeIndex;
				Type = motorwaysAchievementData.type;
				Scale = motorwaysAchievementData.scale;
				UpgradeType = motorwaysAchievementData.upgradeType;
				RequiredGameMode = motorwaysAchievementData.gameMode;
				base.Id = motorwaysAchievementData.name;
				if (Enum.TryParse<StringId>(motorwaysAchievementData.DescriptionId, out var result))
				{
					Description = result;
				}
				else
				{
					Description = StringId.None;
				}
				return true;
			}
			return false;
		}

		private bool CheckUsedAllUpgradesAchievement(MotorwaysGame game)
		{
			UpgradeDatabaseModel model = game.Simulation.GetModel<UpgradeDatabaseModel>();
			for (int i = 0; i < 9; i++)
			{
				UpgradeType upgradeType = (UpgradeType)i;
				if (upgradeType != UpgradeType.House && upgradeType != UpgradeType.Destination && upgradeType != UpgradeType.DoubleDestination && model.GetUsedUpgradeCount(upgradeType) == 0)
				{
					return false;
				}
			}
			MotorwayModel model2 = game.Simulation.GetModel<MotorwayModel>();
			return MotorwayIsValid(model2);
		}

		private bool MotorwayIsValid(MotorwayModel motorway)
		{
			if (motorway != null && motorway.EndCoordinates != motorway.StartCoordinates)
			{
				return motorway.State == RoadState.Active;
			}
			return false;
		}

		private bool CheckGameUpgradesUsedAchievement(MotorwaysGame game)
		{
			if (UpgradeType != UpgradeType.Motorway)
			{
				return game.Simulation.GetModel<UpgradeDatabaseModel>().GetUsedUpgradeCount(UpgradeType) >= IntValue;
			}
			int num = 0;
			ModelListEnumerator<MotorwayModel> enumerator = game.Simulation.GetModels<MotorwayModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				MotorwayModel current = enumerator.Current;
				if (MotorwayIsValid(current))
				{
					num++;
				}
			}
			return num >= IntValue;
		}

		private bool CheckUpgradeLengthAchievement(MotorwaysGame game)
		{
			if (!Diagnostics.Verify(UpgradeType == UpgradeType.Bridge || UpgradeType == UpgradeType.Tunnel || UpgradeType == UpgradeType.Motorway, "Can't use the UpgradeLength achievement stat with upgrade type {0} ({1})", UpgradeType, base.Id))
			{
				return false;
			}
			if (UpgradeType == UpgradeType.Motorway)
			{
				ModelListEnumerator<MotorwayModel> enumerator = game.Simulation.GetModels<MotorwayModel>().GetEnumerator();
				while (enumerator.MoveNext())
				{
					MotorwayModel current = enumerator.Current;
					if (Mathf.CeilToInt(Vector2Int.Distance(current.StartTile.Coordinates, current.EndTile.Coordinates)) >= IntValue)
					{
						return true;
					}
				}
				return false;
			}
			ModelListEnumerator<PassageModel> enumerator2 = game.Simulation.GetModels<PassageModel>().GetEnumerator();
			while (enumerator2.MoveNext())
			{
				Passage passage = enumerator2.Current.Passage;
				if (passage.UpgradeType == UpgradeType && passage.IsComplete && passage.Length >= IntValue)
				{
					return true;
				}
			}
			return false;
		}
	}
}
