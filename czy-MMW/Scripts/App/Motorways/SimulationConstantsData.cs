using FixMath;
using NaughtyAttributes;
using UnityEngine;

namespace Motorways
{
	[CreateAssetMenu(menuName = "Motorways/SimulationConstants")]
	public class SimulationConstantsData : ScriptableObject
	{
		private const string TrainConstants = "Train Constants";

		[FoldoutGroup("Train Constants")]
		public Fix64 trainSpeed = (Fix64)2.6f;

		[FoldoutGroup("Train Constants")]
		public Fix64 trainAcceleration = (Fix64)1.1f;

		[FoldoutGroup("Train Constants")]
		public Fix64 trainDeceleration = (Fix64)2.2f;

		[FoldoutGroup("Train Constants")]
		public Fix64 trainMinimumSpeedDuringDeceleration = (Fix64)0.1f;

		[FoldoutGroup("Train Constants")]
		public Fix64 trainStoppingDistanceFromBuffer = (Fix64)0.5f;

		[FoldoutGroup("Train Constants")]
		[Tooltip("The distance from a crossing a train has to be before the lights go/cars will stop")]
		public Fix64 trainCrossingSignalDistance = (Fix64)5f;

		[FoldoutGroup("Train Constants")]
		public int maxDemandFromTrain = 6;

		[FoldoutGroup("Train Constants")]
		public int minDemandFromTrain = 1;

		[FoldoutGroup("Train Constants")]
		public Fix64 demandPerHouse = (Fix64)0.5f;

		[Tooltip("The max rate of acceleration for vehicles on a crossing")]
		[FoldoutGroup("Train Constants")]
		public Fix64 maxAccelerationOnCrossings = (Fix64)0.3f;

		[Tooltip("The relative speed vehicles want to be at when arriving at a crossing")]
		[FoldoutGroup("Train Constants")]
		public Fix64 targetSpeedTowardsCrossings = (Fix64)0.5f;

		[Tooltip("How smoothly it decelerates towards targetSpeedTowardsCrossings")]
		[FoldoutGroup("Train Constants")]
		public Fix64 decelerationExponentTowardsCrossings = Fix64.One;

		[Tooltip("How far away from the crossing the traffic slows down, measured in vehicle lengths")]
		[FoldoutGroup("Train Constants")]
		public Fix64 crossingSlowDistance = (Fix64)3f;

		[Tooltip("How far away from the edge of a crossing tile the traffic stops, measured in vehicle lengths")]
		[FoldoutGroup("Train Constants")]
		public Fix64 crossingStopDistance = (Fix64)2f;

		[Tooltip("How long cars will wait at a crossing after a train has passed")]
		[FoldoutGroup("Train Constants")]
		public Fix64 crossingWaitTime = (Fix64)0.5f;

		[FoldoutGroup("Train Constants")]
		public Fix64 trainStationWaitTime = (Fix64)1.1f;

		[FoldoutGroup("Train Constants")]
		public Fix64 trainCenterToWheelDistance = (Fix64)0.95f;

		[FoldoutGroup("Train Constants")]
		public Fix64 trainCarriageSeparationDistance = (Fix64)1.1f;

		private const string BoatConstants = "Boat Constants";

		[FoldoutGroup("Boat Constants")]
		public Fix64 boatSpeed = (Fix64)2.6f;

		[FoldoutGroup("Boat Constants")]
		public Fix64 boatAcceleration = (Fix64)1.1f;

		[FoldoutGroup("Boat Constants")]
		public Fix64 boatUndockingAcceleration = (Fix64)0.5f;

		[FoldoutGroup("Boat Constants")]
		public Fix64 boatDeceleration = (Fix64)2.2f;

		[FoldoutGroup("Boat Constants")]
		public Fix64 boatMinimumSpeedDuringDeceleration = (Fix64)0.1f;

		[FoldoutGroup("Boat Constants")]
		public Fix64 boatStoppingDistanceFromBuffer = (Fix64)0.5f;

		[FoldoutGroup("Boat Constants")]
		public Fix64 boatCenterToPivotDistance = (Fix64)1f;

		[FoldoutGroup("Boat Constants")]
		public Fix64 boatCenterToBowDistance = (Fix64)0.95f;

		[FoldoutGroup("Boat Constants")]
		public Fix64 boatTerminalWaitTime = (Fix64)1.1f;

		[FoldoutGroup("Boat Constants")]
		public Fix64 boatDockingSpeedThreshold = Fix64.One;

		[FoldoutGroup("Boat Constants")]
		public Fix64 boatUndockingSpeedThreshold = (Fix64)2f;

		[FoldoutGroup("Boat Constants")]
		public Vector2 boatUndockingMidpointOffset = new Vector2(0.5f, 0f);

		private const string VehicleConstants = "Vehicles";

		[FoldoutGroup("Vehicles")]
		public Fix64 maxAcceleration = (Fix64)0.6f;

		[FoldoutGroup("Vehicles")]
		public Fix64 controlledIntersectionAcceleration = (Fix64)0.6f;

		[FoldoutGroup("Vehicles")]
		public Fix64 roundaboutAcceleration = (Fix64)1f;

		[Tooltip("How smooth acceleration is.")]
		[FoldoutGroup("Vehicles")]
		public Fix64 accelerationExponent = (Fix64)4L;

		[FoldoutGroup("Vehicles")]
		public Fix64 maxDeceleration = (Fix64)1.5f;

		[Tooltip("How smooth deceleration is.")]
		[FoldoutGroup("Vehicles")]
		public Fix64 decelerationExponent = (Fix64)4L;

		[Tooltip("Speed cars will try hit when driving towards intersections.")]
		[FoldoutGroup("Vehicles")]
		public Fix64 targetSpeedTowardsIntersections = Fix64.One;

		[FoldoutGroup("Vehicles")]
		[Tooltip("How smoothly it decelerates towards targetSpeedTowardsIntersections")]
		public Fix64 decelerationExponentTowardsIntersections = Fix64.One;

		[FoldoutGroup("Vehicles")]
		public Fix64 speedMultiplier = Fix64.One;

		[FoldoutGroup("Vehicles")]
		[Tooltip("How long to wait before just going")]
		public Fix64 MaximumTimeToWaitAtIntersection = (Fix64)45L;

		[FoldoutGroup("Vehicles")]
		[Tooltip("How many roads do we count as an intersection to slow down for?")]
		public int NumberOfRoadsAtIntersectionToSlowDownFor = 3;

		[FoldoutGroup("Vehicles")]
		[Tooltip("Do we include houses connected to roads as intersections?")]
		public bool IgnoreHousesForIntersectionSlowDown;

		[FoldoutGroup("Vehicles")]
		[Tooltip("Do we include destinations connected to roads as intersections?")]
		public bool IgnoreDestinationsForIntersectionSlowDown;

		[FoldoutGroup("Vehicles")]
		[Tooltip("How much of a straight lane into a roundabout do we count as not part of the roundabout?")]
		public Fix64 PercentageOfStraightLanesIntoRoundaboutsToCountOutside = Fix64Consts.OneHalf;

		[Tooltip("Do we want to enable special behaviour for straight lines?")]
		[FoldoutGroup("Vehicles")]
		public bool TreatStraightRoundaboutEntrancesAsNotRoundabouts;

		[FoldoutGroup("Vehicles")]
		[Tooltip("How far to look ahead for average speed and intersections to slow at.")]
		public Fix64 LookaheadDistance = (Fix64)5L;

		[FoldoutGroup("Vehicles")]
		public bool useAverageLaneSpeedRatherThanMin = true;

		[FoldoutGroup("Vehicles")]
		public bool useAverageLaneSpeedRatherThanMinOnMotorways;

		[FoldoutGroup("Vehicles")]
		[Tooltip("How slow all vehicles in a cycle must be travelling before they're pushed forward to break the cycle.")]
		public Fix64 minSpeedBeforePushingCycle = Fix64.One / (Fix64)10L;

		private const string LaneConstants = "Lanes";

		[FoldoutGroup("Lanes")]
		[Tooltip("Base lane speed.")]
		public Fix64 defaultLaneSpeed = Fix64.One;

		[Tooltip("How slow do cars go on a hairpin turn?")]
		[FoldoutGroup("Lanes")]
		public Fix64 sharpTurnSpeedMultiplier = (Fix64)(1.0 / 3.0);

		[FoldoutGroup("Lanes")]
		[Tooltip("How slow do cars go on a right hand turn?")]
		public Fix64 rightAngleTurnSpeedMultiplier = (Fix64)(2.0 / 3.0);

		[FoldoutGroup("Lanes")]
		[Tooltip("How slow do cars go when heading towards an intersection?")]
		public Fix64 intersectionSpeedMultiplier = Fix64Consts.OneHalf;

		[Tooltip("How fast do cars go when heading towards a roundabout?")]
		[FoldoutGroup("Lanes")]
		public Fix64 roundaboutSpeedMultiplier = Fix64Consts.Two;

		[FoldoutGroup("Lanes")]
		public Fix64 maxSpeedOnMotorways = (Fix64)3L;

		private const string TrafficLightConstants = "Traffic Lights";

		[FoldoutGroup("Traffic Lights")]
		[Tooltip("The minimum delay before traffic lights changing (seconds).")]
		public Fix64 changeDelay = (Fix64)10L;

		[FoldoutGroup("Traffic Lights")]
		[Tooltip("The delay before changing traffic lights if in overtime (seconds).")]
		public Fix64 overtimeChangeDelay = (Fix64)5L;

		[FoldoutGroup("Traffic Lights")]
		[Tooltip("The duration of amber lights (seconds).")]
		public Fix64 amberDelay = (Fix64)2L;

		[FoldoutGroup("Traffic Lights")]
		[Tooltip("If there are fewer than this many cars nearby, don't swap just yet.")]
		public int minimumNearbyCarsBeforeSwapping = 2;

		[FoldoutGroup("Traffic Lights")]
		public Fix64 distanceToCountForNearbyCars = (Fix64)2L;

		[FoldoutGroup("Traffic Lights")]
		public Fix64 MaximumIdleTimeAtTrafficLightBeforeMaxWeight = (Fix64)30L;

		[FoldoutGroup("Traffic Lights")]
		public Fix64 IdleTimeAtTrafficLightWeightMultiplier = Fix64.One;

		[FoldoutGroup("Traffic Lights")]
		public Fix64 IdleTimeAtTrafficLightWeightMultiplierOnMothballedLane = Fix64Consts.Two;

		[FoldoutGroup("Traffic Lights")]
		[Tooltip("If cars can turn right on red, we weigh them less when deciding what green lanes to swap to.This ensures we don't uncessarily swap")]
		public Fix64 CanTurnRightWeightModifier = Fix64.One;

		[FoldoutGroup("Traffic Lights")]
		[Tooltip("If a car is in a carpark, how much extra priority do we give it?")]
		public Fix64 CarparkPriorityModifier = Fix64Consts.Two;

		[FoldoutGroup("Traffic Lights")]
		[Tooltip("If this car is blocked by the same intersection that has the traffic light, how much do we drop the resulting weight by?")]
		public Fix64 BlockedCarWeightModifier = (Fix64)0.1f;

		[FoldoutGroup("Traffic Lights")]
		public bool americanRedLightRules;

		[FoldoutGroup("Traffic Lights")]
		public bool greenLightsIgnoreCollisions;

		private const string BuildingSpawningConstants = "Building Spawning";

		[FoldoutGroup("Building Spawning")]
		public Fix64 FailedHouseSpawnCooldown = (Fix64)2L;

		[FoldoutGroup("Building Spawning")]
		public Fix64 FailedDestinationRetryDelay = (Fix64)20L;

		[FoldoutGroup("Building Spawning")]
		[Tooltip("Max Failed Building Spawns Before Ignoring Tile Weights")]
		[MinValue(0)]
		public int MaxFailedBuildingSpawnsBeforeIgnoringWeights = 5;

		[FoldoutGroup("Building Spawning")]
		[Tooltip("Max Failed Double Carpark Spawns Before Converting To a Single Carpark")]
		[MinValue(0)]
		public int MaxFailedDoubleCarparkSpawnsBeforeConvertingToSingle = 10;

		[FoldoutGroup("Building Spawning")]
		[Tooltip("How many times a destination has to fail before converting to a destination upgrade instead.")]
		[MinValue(0)]
		public int MaxFailedDestinationSpawnsBeforeConvertingToUpgrade = 15;

		[FoldoutGroup("Building Spawning")]
		public Fix64 MinimumTimeBetweenDestinationSpawns = (Fix64)10L;

		[FoldoutGroup("Building Spawning")]
		public Fix64 DelayBetweenSameGroupHouseSpawns = (Fix64)10L;

		[FoldoutGroup("Building Spawning")]
		[SerializeField]
		private AnimationCurve _houseDistanceToContributionCurve = new AnimationCurve();

		[FoldoutGroup("Building Spawning")]
		[SerializeField]
		private Fix64 _houseContributionMultiplier = Fix64.One;

		[SerializeField]
		[FoldoutGroup("Building Spawning")]
		private AnimationCurve GroupDestinationCountToHouseValueMultiplier = new AnimationCurve();

		private const string SuburbConstants = "Suburb Spawning";

		[FoldoutGroup("Suburb Spawning")]
		public Fix64 MinimumSuburbCountScale = (Fix64)0.7f;

		[FoldoutGroup("Suburb Spawning")]
		public Fix64 MinimumSuburbCountExponent = (Fix64)1.2f;

		[FoldoutGroup("Suburb Spawning")]
		public Fix64 MaximumSuburbCountScale = (Fix64)0.4f;

		[FoldoutGroup("Suburb Spawning")]
		public Fix64 MaximumSuburbCountExponent = (Fix64)1.4f;

		[MinValue(0)]
		[FoldoutGroup("Suburb Spawning")]
		public int MinimumSpawnAttemptsForSuburbMultiplier = 5;

		[FoldoutGroup("Suburb Spawning")]
		[MinValue(0)]
		public int MaximumSpawnAttemptsForSuburbMultiplier = 10;

		[FoldoutGroup("Suburb Spawning")]
		public Fix64 MaximumDelayedBuildingSuburbCountMultiplier = (Fix64)4L;

		private const string BigPinConstants = "Big Pins";

		[FoldoutGroup("Big Pins")]
		public Fix64 MaxOvercrowdTime = (Fix64)90L;

		[FoldoutGroup("Big Pins")]
		[Tooltip("The chunk of time at the end of the overcrowd timer that is not displayed.")]
		public Fix64 GracePeriodTime = (Fix64)2L;

		[FoldoutGroup("Big Pins")]
		public Fix64 OvercrowdTimerAcceleration = (Fix64)0.02;

		[FoldoutGroup("Big Pins")]
		public Fix64 OvercrowdTimerCarArrivalDeceleration = (Fix64)0.5;

		[FoldoutGroup("Big Pins")]
		public Fix64 OvercrowdTimerReturnSpeed = Fix64Consts.Two;

		[FoldoutGroup("Big Pins")]
		[SerializeField]
		private AnimationCurve OvercrowdTimerSpeedMultiplierByDemand = AnimationCurve.Linear(0f, 1f, 0f, 1f);

		[FoldoutGroup("Big Pins")]
		[SerializeField]
		private AnimationCurve CarArrivalPinReductionMultiplierOverTime = AnimationCurve.Linear(0f, 1f, 0f, 1f);

		[FoldoutGroup("Big Pins")]
		[Tooltip("The percentage to reduce the overcrowding timer at the instant a vehicle picks up a pin. Note this is actually a percentage and goes from 0 to 100.")]
		public Fix64 PercentageToReduceTimerOnCarArrival = (Fix64)10L;

		[FoldoutGroup("Big Pins")]
		[Tooltip("The minimum amount to reduce the timer, in virtualized seconds, when a vehicle picks up a pin.")]
		public Fix64 MinimumAmountToReduceTimerOnCarArrival = (Fix64)0L;

		[FoldoutGroup("Big Pins")]
		[Tooltip("The maximum amount to reduce the timer, in virtualized seconds, when a vehicle picks up a pin.")]
		public Fix64 MaximumAmountToReduceTimerOnCarArrival = (Fix64)3L;

		[FoldoutGroup("Big Pins")]
		public Fix64 MinimumOvercrowdTimerSpeed = (Fix64)0L;

		[FoldoutGroup("Big Pins")]
		public Fix64 MaximumOvercrowdTimerSpeed = (Fix64)1L;

		private const string DemandConstants = "Demand";

		[FoldoutGroup("Demand")]
		public Fix64 DemandMultiplierForBuildings = (Fix64)0.8;

		[FoldoutGroup("Demand")]
		public Fix64 DemandMultiplierForUpgradedBuildings = (Fix64)1.6;

		[FoldoutGroup("Demand")]
		public Fix64 AverageCarsPerDay = (Fix64)1.55;

		[FoldoutGroup("Demand")]
		public Fix64 DelayBeforeFirstPinOfDestination = (Fix64)4L;

		[FoldoutGroup("Demand")]
		public Fix64 DemandMultiplierForBoatTerminals = Fix64.One;

		[FoldoutGroup("Demand")]
		public Fix64 DemandMultiplierForUpgradedBoatTerminals = (Fix64)2L;

		private const string EndlessConstants = "Endless";

		[SerializeField]
		[FoldoutGroup("Endless")]
		private AnimationCurve PathDistanceToEfficiencyScore = AnimationCurve.Linear(0f, 0f, 100f, 100f);

		[FoldoutGroup("Endless")]
		public Fix64 EndlessDemandMultiplier = (Fix64)0.5;

		[FoldoutGroup("Endless")]
		public int MilestoneIncreaseAfterPrecalculatedIntervals = 50;

		[FoldoutGroup("Endless")]
		public Fix64 PercentageOfMilestoneToLose = (Fix64)0.1f;

		[FoldoutGroup("Endless")]
		[SerializeField]
		private AnimationCurve PercentageOfMilestoneToLoseMultiplier = AnimationCurve.Linear(0f, 0.5f, 1f, 1f);

		[FoldoutGroup("Endless")]
		public Fix64 EndlessSpawnRampMultiplier = Fix64.One;

		[FoldoutGroup("Endless")]
		public Fix64 ExpansionTimePerMilestone = (Fix64)140L;

		[Tooltip("How much extra expansion time to we grant in Endless mode?")]
		[FoldoutGroup("Endless")]
		public Fix64 BonusExpansionTime = (Fix64)140L;

		[FoldoutGroup("Endless")]
		public int AdditionalHousesPerGroup = 1;

		[FoldoutGroup("Endless")]
		public Fix64 TimeAtHouseBeforeCarIsAvailable = (Fix64)5L;

		private const string ExpertConstants = "Expert";

		[FoldoutGroup("Expert")]
		public Fix64 DurationTillRoadPermanence = (Fix64)40L;

		[FoldoutGroup("Expert")]
		public Fix64 PercentageOfPermanenceTimerWhereRoadsCannotBeDemolished = (Fix64)0.25;

		[FoldoutGroup("Expert")]
		public int MaxUpgradeChoicesAwardedInExpertMode = 8;

		[FoldoutGroup("Expert")]
		public Fix64 DryingRoadSpeedMultiplier = (Fix64)0.8f;

		private const string CreativeConstants = "Creative";

		[FoldoutGroup("Creative")]
		public Fix64 CreativeDemandMultiplier = (Fix64)1.5;

		public Fix64 EvaluateHouseContributionFromDistance(Fix64 distance)
		{
			return (Fix64)_houseDistanceToContributionCurve.Evaluate((float)distance) * _houseContributionMultiplier;
		}

		public Fix64 EvaluateDestinationCountHouseValueMultiplier(int numberOfDestinationsInGroupIndex)
		{
			return (Fix64)GroupDestinationCountToHouseValueMultiplier.Evaluate(numberOfDestinationsInGroupIndex);
		}

		public Fix64 GetOvercrowdTimerSpeedMultiplierForExtraDemand(Fix64 currentDemandMultiplier)
		{
			return (Fix64)OvercrowdTimerSpeedMultiplierByDemand.Evaluate((float)currentDemandMultiplier);
		}

		public Fix64 GetCarArrivalPinReductionMultiplierOverTime(Fix64 gameTime)
		{
			return (Fix64)CarArrivalPinReductionMultiplierOverTime.Evaluate((float)gameTime);
		}

		public Fix64 GetEfficiencyScoreForVehiclePathLength(Fix64 length)
		{
			return (Fix64)PathDistanceToEfficiencyScore.Evaluate((float)length);
		}

		public Fix64 GetPercentageOfMilestoneToLoseFromProgress(Fix64 milestoneProgress)
		{
			return (Fix64)PercentageOfMilestoneToLoseMultiplier.Evaluate((float)milestoneProgress) * PercentageOfMilestoneToLose;
		}
	}
}
