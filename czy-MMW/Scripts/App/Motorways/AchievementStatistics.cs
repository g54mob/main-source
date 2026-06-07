using System;
using Motorways.Models;

namespace Motorways
{
	public class AchievementStatistics : JsonSerializable
	{
		private const string TotalEndlessMilestonesAchievedKey = "TotalEndlessMilestonesAchieved";

		[JsonSerializable("DCPlayed", JsonSerializableAttribute.MergeStrategy.Max)]
		public int DailyChallengesPlayed { get; private set; }

		[JsonSerializable("WCPlayed", JsonSerializableAttribute.MergeStrategy.Max)]
		public int WeeklyChallengesPlayed { get; private set; }

		[JsonSerializable("TreesBulldozed", JsonSerializableAttribute.MergeStrategy.Max)]
		public int TreesBulldozed { get; private set; }

		[JsonSerializable("TotalScore", JsonSerializableAttribute.MergeStrategy.Max)]
		public int TotalPointsScored { get; private set; }

		[JsonSerializable("TotalConcrete", JsonSerializableAttribute.MergeStrategy.Max)]
		public int TotalConcreteUsed { get; private set; }

		[JsonSerializable("TotalBridges", JsonSerializableAttribute.MergeStrategy.Max)]
		public int TotalBridgesUsed { get; private set; }

		[JsonSerializable("TotalTunnels", JsonSerializableAttribute.MergeStrategy.Max)]
		public int TotalTunnelsUsed { get; private set; }

		[JsonSerializable("TotalMotorways", JsonSerializableAttribute.MergeStrategy.Max)]
		public int TotalMotorwaysUsed { get; private set; }

		[JsonSerializable("TotalTrafficLights", JsonSerializableAttribute.MergeStrategy.Max)]
		public int TotalTrafficLightsUsed { get; private set; }

		[JsonSerializable("TotalRoundabouts", JsonSerializableAttribute.MergeStrategy.Max)]
		public int TotalRoundaboutsUsed { get; private set; }

		[JsonSerializable("TotalConcreteDeleted", JsonSerializableAttribute.MergeStrategy.Max)]
		public int TotalConcreteDeleted { get; private set; }

		[JsonSerializable("TotalEndlessMilestonesAchieved", JsonSerializableAttribute.MergeStrategy.Max)]
		public int TotalEndlessMilestonesAchieved { get; private set; }

		public event Action DataChanged;

		public void ConfirmDataChanged()
		{
			this.DataChanged?.Invoke();
		}

		private static string GetJsonSerializableNameOfProperty(string propertyName)
		{
			return JsonSerializable.GetJsonSerializableName(typeof(AchievementStatistics).GetProperty(propertyName));
		}

		public void OnTreeBulldozed(IAchievementHandler achievementHandler)
		{
			TreesBulldozed++;
			ConfirmDataChanged();
			achievementHandler.IncrementStatistic(GetJsonSerializableNameOfProperty("TreesBulldozed"), 1);
		}

		public void OnEndlessMilestoneAchieved(IAchievementHandler achievementHandler)
		{
			TotalEndlessMilestonesAchieved++;
			ConfirmDataChanged();
			achievementHandler.IncrementStatistic(GetJsonSerializableNameOfProperty("TotalEndlessMilestonesAchieved"), 1);
		}

		public int GetTotalUpgradesUsed(UpgradeType type)
		{
			switch (type)
			{
			case UpgradeType.Bridge:
				return TotalBridgesUsed;
			case UpgradeType.Concrete:
				return TotalConcreteUsed;
			case UpgradeType.Motorway:
				return TotalMotorwaysUsed;
			case UpgradeType.TrafficLight:
				return TotalTrafficLightsUsed;
			case UpgradeType.Roundabout:
				return TotalRoundaboutsUsed;
			case UpgradeType.Tunnel:
				return TotalTunnelsUsed;
			default:
				Diagnostics.FailAssert("Unknown upgrade type {0}.", type);
				return 0;
			}
		}

		private void LogUsedUpgrade(UpgradeType type, int amount, IAchievementHandler achievementHandler)
		{
			string jsonSerializableNameOfProperty;
			switch (type)
			{
			case UpgradeType.Bridge:
				jsonSerializableNameOfProperty = GetJsonSerializableNameOfProperty("TotalBridgesUsed");
				TotalBridgesUsed += amount;
				break;
			case UpgradeType.Concrete:
				jsonSerializableNameOfProperty = GetJsonSerializableNameOfProperty("TotalConcreteUsed");
				TotalConcreteUsed += amount;
				break;
			case UpgradeType.Motorway:
				jsonSerializableNameOfProperty = GetJsonSerializableNameOfProperty("TotalMotorwaysUsed");
				TotalMotorwaysUsed += amount;
				break;
			case UpgradeType.TrafficLight:
				jsonSerializableNameOfProperty = GetJsonSerializableNameOfProperty("TotalTrafficLightsUsed");
				TotalTrafficLightsUsed += amount;
				break;
			case UpgradeType.Roundabout:
				jsonSerializableNameOfProperty = GetJsonSerializableNameOfProperty("TotalRoundaboutsUsed");
				TotalRoundaboutsUsed += amount;
				break;
			case UpgradeType.Tunnel:
				jsonSerializableNameOfProperty = GetJsonSerializableNameOfProperty("TotalTunnelsUsed");
				TotalTunnelsUsed += amount;
				break;
			default:
				Diagnostics.FailAssert("Unknown upgrade type {0}.", type);
				return;
			}
			achievementHandler.IncrementStatistic(jsonSerializableNameOfProperty, amount);
		}

		public void LogDeletedUpgrade(UpgradeType type, int amount, IAchievementHandler achievementHandler)
		{
			if (type == UpgradeType.Concrete)
			{
				string jsonSerializableNameOfProperty = GetJsonSerializableNameOfProperty("TotalConcreteDeleted");
				TotalConcreteDeleted += amount;
				achievementHandler.IncrementStatistic(jsonSerializableNameOfProperty, amount);
			}
			else
			{
				Diagnostics.FailAssert("Unsupported upgrade type {0}.", type);
			}
		}

		public int GetTotalUpgradesDeleted(UpgradeType type)
		{
			if (type == UpgradeType.Concrete)
			{
				return TotalConcreteDeleted;
			}
			Diagnostics.FailAssert("Unsupported upgrade type {0}.", type);
			return 0;
		}

		public void LogScoreStatistics(MotorwaysGameStatistics incrementalStats, IAchievementHandler achievementHandler)
		{
			TotalPointsScored += incrementalStats.NewTrips;
			int num = 0 | ((incrementalStats.NewTrips > 0) ? 1 : 0);
			achievementHandler.IncrementStatistic(GetJsonSerializableNameOfProperty("TotalPointsScored"), incrementalStats.NewTrips);
			if (num != 0)
			{
				ConfirmDataChanged();
			}
		}

		public void LogGameOverStatistics(MotorwaysGame game, IAchievementHandler achievementHandler)
		{
			if (Diagnostics.Verify(game.HasGameEnded, "Can't log game statistics if the game isn't over!"))
			{
				bool flag = false;
				switch (game.Simulation.GetModel<ActiveChallengesModel>().challengeType)
				{
				case MapChallenge.ChallengeType.Daily:
					DailyChallengesPlayed++;
					flag = true;
					achievementHandler.IncrementStatistic(GetJsonSerializableNameOfProperty("DailyChallengesPlayed"), 1);
					break;
				case MapChallenge.ChallengeType.Weekly:
					WeeklyChallengesPlayed++;
					flag = true;
					achievementHandler.IncrementStatistic(GetJsonSerializableNameOfProperty("WeeklyChallengesPlayed"), 1);
					break;
				}
				if (flag)
				{
					ConfirmDataChanged();
				}
			}
		}

		public void LogUpgradeStatistics(MotorwaysGame game, IAchievementHandler achievementHandler, AchievementStatistics statsAtStart = null)
		{
			bool flag = false;
			UpgradeDatabaseModel model = game.Simulation.GetModel<UpgradeDatabaseModel>();
			UpgradeType[] upgradeTypes = UpgradeDatabase.UpgradeTypes;
			foreach (UpgradeType upgradeType in upgradeTypes)
			{
				int totalUpgradeCount = model.GetTotalUpgradeCount(upgradeType);
				totalUpgradeCount -= model.GetAvailableUpgradeCount(upgradeType);
				if (statsAtStart != null)
				{
					totalUpgradeCount -= statsAtStart.GetTotalUpgradesUsed(upgradeType);
				}
				LogUsedUpgrade(upgradeType, totalUpgradeCount, achievementHandler);
				if (totalUpgradeCount > 0)
				{
					flag = true;
				}
			}
			if (flag)
			{
				ConfirmDataChanged();
			}
		}
	}
}
