using Factory;
using FixMath;
using Motorways.Models;
using Motorways.Processes;
using Motorways.Views;
using UnityEngine;

namespace Motorways
{
	public class GameRules
	{
		[Dependency]
		protected SimulationConstantsData _constants;

		[Dependency]
		private ActivePlayer _player;

		[Dependency]
		private ClockModel _clock;

		public const int GetAllAvailableUpgradeOptions = 9;

		public virtual ScoringMode ScoringMode => ScoringMode.Trips;

		public int MinimumMotorwayLength => 2;

		public virtual GenerateDemandProcess.DemandGenerationStyle GetDemandGenerationStyle => GenerateDemandProcess.DemandGenerationStyle.Timer;

		public virtual bool CanBuildingsDemolishUnusedRoads => false;

		public virtual bool DoRoadsAnimation => true;

		public virtual Fix64 SpawnRampMultiplier => Fix64.One;

		public virtual bool CanExpansionTimeContinue => true;

		public virtual int AdditionalHousesPerGroup => 0;

		public virtual bool UsesPerCityHouseGraph => false;

		public virtual bool RoadsBecomePermanentOverTime => false;

		public virtual int UpgradeWeekMetric => _clock.ExpansionWeek;

		public virtual bool CanDestinationsOvercrowd => true;

		public virtual bool CanUpgradeDestinationsAfterFailedSpawns => false;

		public virtual bool FailedSpawnsIgnoreStoppedExpansionTime => false;

		public virtual bool ShouldGameStartFullyExpanded => false;

		public virtual bool HasUnlimitedUpgrades => false;

		public virtual bool BuildingsIgnoreOtherBuildings => false;

		public virtual bool NoDestinationDeadzoneForHouses => false;

		public virtual bool AllowPlacingBuildingsOnUnzoneableTiles => false;

		public virtual bool AllowSpawningAtMapEdges => false;

		public virtual bool AllowBlockingSpawns => false;

		public virtual bool AllowSpawnsOnRoundaboutDeadzone => false;

		public virtual bool AllowConnectingDriveways => false;

		public virtual bool ShouldHideStaticUpgrades => false;

		public virtual bool ShowColourWidget => false;

		public virtual bool AllowSecondDestinationStartUpgraded => false;

		public virtual bool ShouldSavePeriodically => true;

		public virtual bool AllowDemandRelocation => true;

		public virtual bool ShowUpgradeCounters => true;

		public virtual bool ShouldBuildingsBulldozeTrees => false;

		public static int GetMotorwayLength(Vector2Int startCoordinates, Vector2Int endCoordinates)
		{
			int a = Mathf.Abs(endCoordinates.x - startCoordinates.x);
			int b = Mathf.Abs(endCoordinates.y - startCoordinates.y);
			return Mathf.Max(a, b);
		}

		public virtual bool ShouldShowNewUpgradeIconDescriptionForType(UpgradeType type)
		{
			if (_player.HasSeenNewContent(GameUpgradeScreen.GetContentIdStringForSelectedUpgradeType(type)))
			{
				return false;
			}
			return true;
		}

		public virtual StringId GetNoConcreteErrorMessage(DeviceInputType type)
		{
			return StringId.None;
		}

		public virtual StringId GetUpgradeScreenDescriptionUpgrades(int optionCount = 2)
		{
			if (optionCount == 1)
			{
				return StringId.Tutorial_SecondUpgrade;
			}
			return StringId.WeekTagline_ChooseUpgrade;
		}

		public virtual StringId GetGameOverLineOne()
		{
			return StringId.GameOver_LineOne;
		}

		public virtual StringId GetGameOverLineTwo()
		{
			return StringId.GameOver_LineTwo;
		}

		public virtual int GetExpectedUpgradePackageCount(Fix64 upgradeScheduleTime)
		{
			return ClockModel.SecondsToWeeks(upgradeScheduleTime);
		}

		public virtual int GetMaximumDemandForDestination(DestinationModel destinationModel)
		{
			return destinationModel.MaximumDemandBeforeTimerStarts + GetMaximumOverflowPinsForDestination(destinationModel);
		}

		public int GetMaximumOverflowPinsForDestination(DestinationModel model)
		{
			if (!model.IsUpgraded)
			{
				return 4;
			}
			return 6;
		}

		public virtual Fix64 GetDemandMultiplierForDestination(DestinationModel model)
		{
			if (model.IsBoatTerminal)
			{
				if (!model.IsUpgraded)
				{
					return _constants.DemandMultiplierForBoatTerminals;
				}
				return _constants.DemandMultiplierForUpgradedBoatTerminals;
			}
			if (!model.IsUpgraded)
			{
				return _constants.DemandMultiplierForBuildings;
			}
			return _constants.DemandMultiplierForUpgradedBuildings;
		}

		public virtual Fix64 GetClockSpeedMultiplier()
		{
			return Fix64.One;
		}

		public virtual Fix64 GetOvercrowdingSpeedMultiplier(Fix64 currentTimerProgress)
		{
			return Fix64.One;
		}

		public virtual int GetNumberOfUpgradeOptionsPerWeek()
		{
			return 2;
		}

		public virtual bool CanInteract()
		{
			return true;
		}

		public virtual float GetCameraPanRange()
		{
			return 8f;
		}

		public virtual bool ShowsUI()
		{
			return true;
		}

		public virtual bool UseCamera()
		{
			return ShowsUI();
		}

		public virtual bool DoesIgnorePlayableArea()
		{
			return false;
		}

		public virtual bool UIStartVisible()
		{
			return true;
		}

		public virtual bool SupportsLeaderboards()
		{
			return true;
		}

		public virtual bool RecordsGameStatistics()
		{
			return true;
		}

		public virtual bool CanSave()
		{
			return true;
		}

		public virtual bool HasDisabledAutomaticSpawn()
		{
			return false;
		}

		public virtual bool HasSpawnScheduleVariation()
		{
			return true;
		}

		public virtual bool ShowDisconnectedBuildingsUI()
		{
			return true;
		}

		public virtual bool ShouldUseUpgradeScreenOffsets()
		{
			return false;
		}

		public virtual bool ShowCannotConnectToCarparkErrorNotification()
		{
			return true;
		}

		public virtual bool ShowNoConcreteErrorNotification()
		{
			return true;
		}

		public virtual bool SupportsChallenges()
		{
			return true;
		}
	}
}
