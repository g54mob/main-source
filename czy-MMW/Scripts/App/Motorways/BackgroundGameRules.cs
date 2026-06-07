using FixMath;
using Motorways.Models;

namespace Motorways
{
	public class BackgroundGameRules : GameRules
	{
		public override bool DoRoadsAnimation => false;

		public override bool ShouldSavePeriodically => false;

		public override int GetMaximumDemandForDestination(DestinationModel destinationModel)
		{
			return 5;
		}

		public override int GetNumberOfUpgradeOptionsPerWeek()
		{
			return 0;
		}

		public override bool CanInteract()
		{
			return false;
		}

		public override bool ShowsUI()
		{
			return false;
		}

		public override bool DoesIgnorePlayableArea()
		{
			return true;
		}

		public override int GetExpectedUpgradePackageCount(Fix64 upgradeScheduleTime)
		{
			return 0;
		}

		public override bool SupportsLeaderboards()
		{
			return false;
		}

		public override bool RecordsGameStatistics()
		{
			return false;
		}

		public override bool HasSpawnScheduleVariation()
		{
			return false;
		}

		public override bool ShowDisconnectedBuildingsUI()
		{
			return false;
		}

		public override bool CanSave()
		{
			return false;
		}

		public override bool SupportsChallenges()
		{
			return false;
		}
	}
}
