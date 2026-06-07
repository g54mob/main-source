using Factory;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways
{
	public class CreativeGameRules : GameRules
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

		public override ScoringMode ScoringMode => ScoringMode.None;

		public override bool CanDestinationsOvercrowd => false;

		public override bool CanUpgradeDestinationsAfterFailedSpawns => true;

		public override bool FailedSpawnsIgnoreStoppedExpansionTime => true;

		public override bool ShouldGameStartFullyExpanded => true;

		public override bool HasUnlimitedUpgrades => true;

		public override bool BuildingsIgnoreOtherBuildings => true;

		public override bool NoDestinationDeadzoneForHouses => true;

		public override bool AllowPlacingBuildingsOnUnzoneableTiles => true;

		public override bool AllowSpawningAtMapEdges => true;

		public override bool AllowBlockingSpawns => true;

		public override bool AllowSpawnsOnRoundaboutDeadzone => true;

		public override bool AllowConnectingDriveways => true;

		public override bool ShouldHideStaticUpgrades => true;

		public override bool ShowColourWidget => true;

		public override bool AllowSecondDestinationStartUpgraded => true;

		public override bool ShouldSavePeriodically => true;

		public override bool AllowDemandRelocation => false;

		public override bool ShowUpgradeCounters => false;

		public override bool ShouldBuildingsBulldozeTrees => true;

		public override bool HasDisabledAutomaticSpawn()
		{
			return true;
		}

		public override int GetExpectedUpgradePackageCount(Fix64 upgradeScheduleTime)
		{
			return 0;
		}

		public override int GetMaximumDemandForDestination(DestinationModel destinationModel)
		{
			return destinationModel.MaximumDemandBeforeTimerStarts;
		}

		public override Fix64 GetDemandMultiplierForDestination(DestinationModel model)
		{
			return base.GetDemandMultiplierForDestination(model) * _constants.CreativeDemandMultiplier;
		}

		public override bool SupportsLeaderboards()
		{
			return false;
		}

		public override bool RecordsGameStatistics()
		{
			return false;
		}

		public override float GetCameraPanRange()
		{
			return 50f;
		}

		public override bool ShowDisconnectedBuildingsUI()
		{
			return false;
		}
	}
}
