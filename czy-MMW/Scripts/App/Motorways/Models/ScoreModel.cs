using System;
using Factory;
using FixMath;
using Server;

namespace Motorways.Models
{
	public class ScoreModel : Model<EmptyModelFrame, ScoreModel.IObserver>
	{
		public interface IObserver
		{
			void OnEfficiencyScoreIncreased(Fix64 addedScore);
		}

		[Dependency]
		private SimulationConstantsData _constants;

		[Dependency]
		private City _city;

		[Dependency]
		private UpgradeDatabaseModel _upgrades;

		[Dependency]
		private ActivePlayer _player;

		[Dependency]
		private IAchievementHandler _achievementHandler;

		[Serialize(true, null)]
		public int Score { get; private set; }

		[Serialize(true, null)]
		public Fix64 EfficiencyScore { get; private set; } = Fix64.Zero;

		[Serialize(true, null)]
		public int CurrentEfficiencyMilestone { get; private set; }

		public void AddScore()
		{
			Score++;
		}

		public void AddEfficiencyScoreFromTripLength(Fix64 vehiclePathLength)
		{
			if (!_upgrades.HasPendingUpgrades)
			{
				Fix64 efficiencyScoreForVehiclePathLength = _constants.GetEfficiencyScoreForVehiclePathLength(vehiclePathLength);
				EfficiencyScore = Fix64.Min(efficiencyScoreForVehiclePathLength + EfficiencyScore, _city.Definition.GetEfficiencyMilestone(CurrentEfficiencyMilestone, _constants.MilestoneIncreaseAfterPrecalculatedIntervals));
				ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.OnEfficiencyScoreIncreased(efficiencyScoreForVehiclePathLength);
				}
			}
		}

		public bool HasAchievedCurrentMilestone()
		{
			return EfficiencyScore >= _city.Definition.GetEfficiencyMilestone(CurrentEfficiencyMilestone, _constants.MilestoneIncreaseAfterPrecalculatedIntervals);
		}

		public void ProgressToNextMilestone()
		{
			CurrentEfficiencyMilestone++;
			EfficiencyScore = Fix64.Zero;
			if (_city.Rules.RecordsGameStatistics() && _city.Rules.ScoringMode == ScoringMode.EfficiencyMilestones)
			{
				_player.AchievementStatistics.OnEndlessMilestoneAchieved(_achievementHandler);
				_player.CheckLifetimeAchievements();
			}
		}

		public void DeductEfficiencyScore(Fix64 deltaTime)
		{
			Fix64 milestoneProgress = EfficiencyScore / _city.Definition.GetEfficiencyMilestone(CurrentEfficiencyMilestone, _constants.MilestoneIncreaseAfterPrecalculatedIntervals);
			Fix64 percentageOfMilestoneToLoseFromProgress = _constants.GetPercentageOfMilestoneToLoseFromProgress(milestoneProgress);
			EfficiencyScore = Fix64.Max(EfficiencyScore - _city.Definition.GetEfficiencyMilestone(CurrentEfficiencyMilestone, _constants.MilestoneIncreaseAfterPrecalculatedIntervals) * percentageOfMilestoneToLoseFromProgress * deltaTime, Fix64.Zero);
		}

		public void OnContinuedInEndless()
		{
			CurrentEfficiencyMilestone = Math.Max(_upgrades.TotalClaimedPackages, CurrentEfficiencyMilestone);
		}

		public void ResetForEndless()
		{
			EfficiencyScore = Fix64.Zero;
			CurrentEfficiencyMilestone = Math.Min(_upgrades.TotalGrantedUpgradesCount, CurrentEfficiencyMilestone);
		}

		public override void Reset()
		{
			base.Reset();
			Score = 0;
			EfficiencyScore = Fix64.Zero;
			CurrentEfficiencyMilestone = 0;
		}

		public ScoreModel()
			: base(1)
		{
		}
	}
}
