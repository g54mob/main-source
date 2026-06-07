using Factory;
using FixMath;
using Motorways.Models;
using Motorways.Processes;
using Server;

namespace Motorways
{
	public class EndlessGameRules : GameRules
	{
		[Dependency]
		private ScoreModel _scoreModel;

		[Dependency]
		private ClockModel _clock;

		[Dependency]
		private UpgradeDatabaseModel _upgrades;

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private CityPlanModel _cityPlanModel;

		public override ScoringMode ScoringMode => ScoringMode.EfficiencyMilestones;

		public override Fix64 SpawnRampMultiplier => _constants.EndlessSpawnRampMultiplier;

		public override int AdditionalHousesPerGroup => _constants.AdditionalHousesPerGroup;

		public override bool CanExpansionTimeContinue
		{
			get
			{
				if (FeatureToggle.IsFeatureEnabled(Feature.EndlessWithWeeklyMilestones))
				{
					return base.CanExpansionTimeContinue;
				}
				if (_clock.ExpansionTime >= (Fix64)(_scoreModel.CurrentEfficiencyMilestone + 1) * _constants.ExpansionTimePerMilestone + _constants.BonusExpansionTime)
				{
					return false;
				}
				if (_upgrades.HasPendingUpgrades)
				{
					return false;
				}
				ModelListEnumerator<DestinationModel> enumerator = _simulation.GetModels<DestinationModel>().GetEnumerator();
				while (enumerator.MoveNext())
				{
					DestinationModel current = enumerator.Current;
					if (current.totalServicedPins == 0 && current.IsSupplySufficient && _cityPlanModel.groupHouseCounts[current.GroupIndex] >= _constants.AdditionalHousesPerGroup)
					{
						return false;
					}
				}
				return true;
			}
		}

		public override bool UsesPerCityHouseGraph => true;

		public override GenerateDemandProcess.DemandGenerationStyle GetDemandGenerationStyle => GenerateDemandProcess.DemandGenerationStyle.PermanentBalanced;

		public override int UpgradeWeekMetric => _upgrades.TotalClaimedPackages + 1;

		public override bool CanDestinationsOvercrowd => false;

		public override bool CanUpgradeDestinationsAfterFailedSpawns => true;

		public override bool FailedSpawnsIgnoreStoppedExpansionTime => true;

		public override int GetExpectedUpgradePackageCount(Fix64 upgradeScheduleTime)
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.EndlessWithWeeklyMilestones))
			{
				return base.GetExpectedUpgradePackageCount(upgradeScheduleTime);
			}
			return _scoreModel.CurrentEfficiencyMilestone;
		}

		public override int GetMaximumDemandForDestination(DestinationModel destinationModel)
		{
			return destinationModel.MaximumDemandBeforeTimerStarts;
		}

		public override Fix64 GetDemandMultiplierForDestination(DestinationModel model)
		{
			return base.GetDemandMultiplierForDestination(model) * _constants.EndlessDemandMultiplier;
		}

		public override bool SupportsLeaderboards()
		{
			return false;
		}
	}
}
