using UnityEngine;

public class RoutineControls : MonoBehaviour
{
	private static RoutineControls _instance;

	[Tooltip("Based on 3 meals a day + snack, the hunger rate should be ~+0.125 an hour")]
	[Header("Stat Multipliers")]
	public float hungerRate;

	[Tooltip("...Raise it slightly for thirst")]
	public float thirstRate;

	[Tooltip("Alertness- similar to meals")]
	public float tirednessRate;

	[Tooltip("Energy- a 17 hour day depleats energy completely")]
	public float energyRate;

	[Tooltip("Boredem rate")]
	public float boredemRate;

	[Tooltip("Chores rate - 48 hours")]
	public float choresRate;

	[Tooltip("Hygiene rate - 24 hours")]
	public float hygeieneRate;

	[Tooltip("Bladder rate - 4 hours")]
	public float bladderRate;

	[Tooltip("Drunk rate - 2 hours")]
	public float drunkRate;

	[Tooltip("Breath rate - 5 mins")]
	public float breathRate;

	[Tooltip("Idle sound rate - 1 hour")]
	public float idleSoundRate;

	[Tooltip("Poison remove rate - 1 hours")]
	public float poisonRate;

	[Tooltip("Blinded remove rate - 5 mins")]
	public float blindedRate;

	[Header("Routine")]
	[Tooltip("Citizen decisions on whether to go out to get certain things like food depend on 1) how much time they've spent somewhere, this many hours = 100% decision to go somewhere else")]
	public float commericalDecisionMPTimeSpent;

	[Tooltip("How likely a citizen will choose to go out to get certain things (eg. Food) when the player is in the same building.")]
	[Range(0f, 1f)]
	public float commericalDecisionMPlayerSameBuilding;

	[Tooltip("How likely a citizen will choose to go out to get certain things (eg. Food) when the player is in the same gamelocation.")]
	[Range(0f, 1f)]
	public float commericalDecisionMPlayerSameLocation;

	[Range(0f, 2f)]
	[Tooltip("How likely a citizen will choose to go out to get certain things (eg. Food) when the player is not in the above.")]
	public float commericalDecisionMPlayerElsewhere;

	[Header("Action Reference")]
	public AIGoalPreset workGoal;

	public AIGoalPreset answerDoorGoal;

	public AIGoalPreset awakenGoal;

	public AIGoalPreset sleepGoal;

	public AIGoalPreset patrolGoal;

	public AIGoalPreset fleeGoal;

	public AIGoalPreset investigateGoal;

	public AIGoalPreset postJob;

	public AIGoalPreset enforcerResponse;

	public AIGoalPreset enforcerGuardDuty;

	public AIGoalPreset makeSpecificCall;

	public AIGoalPreset layLow;

	public AIGoalPreset kidnapperCollectRansom;

	public AIGoalPreset kidnapperFreeVictim;

	public AIActionPreset searchArea;

	public AIActionPreset searchAreaEnforcer;

	public AIActionPreset hangUp;

	public AIActionPreset raiseAlarm;

	public AIActionPreset sleep;

	public AIActionPreset audioFocus;

	public AIActionPreset mainLightOn;

	public AIActionPreset mainLightOff;

	public AIActionPreset secondaryLightOn;

	public AIActionPreset secondaryLightOff;

	public AIActionPreset lockDoor;

	public AIActionPreset unlockDoor;

	public AIActionPreset openDoor;

	public AIActionPreset closeDoor;

	public AIActionPreset knockOnDoor;

	public AIActionPreset openLocker;

	public AIActionPreset closeLocker;

	public AIActionPreset hide;

	public AIActionPreset pullPlayerFromHiding;

	public AIActionPreset answerTelephone;

	public AIActionPreset makeCall;

	public AIActionPreset takeMoney;

	public AIActionPreset pickupFromFloor;

	public AIActionPreset putBack;

	public AIActionPreset turnOnMusic;

	public AIActionPreset disposal;

	public AIActionPreset bargeDoor;

	public AIActionPreset standAgainstWall;

	public AIActionPreset standGuard;

	public AIActionPreset putUpPoliceTape;

	public AIActionPreset putUpStreetCrimeScene;

	public AIActionPreset getHandIn;

	public AIActionPreset AIPutDownItem;

	public AIActionPreset AIPickUpItem;

	public AIActionPreset purchaseItem;

	public AIActionPreset takeConsumable;

	public AIActionPreset sit;

	public AIActionPreset lookBehindSpooked;

	public AIActionPreset mugging;

	public AIActionPreset fameAndFortune;

	public AIActionPreset loiterConfront;

	public AIActionPreset takeFirstPersonItem;

	public AIActionPreset cleanUp;

	public AIGoalPreset findDeadBody;

	public AIGoalPreset smellDeadBody;

	public AIGoalPreset mourn;

	public AIGoalPreset stealItem;

	public AIGoalPreset exitBuilding;

	public AIGoalPreset missionMeetUpSpecific;

	public AIGoalPreset giveSelfUp;

	public AIGoalPreset meetFood;

	public GroupPreset meetUpFoodMission;

	public AIGoalPreset toGoGoal;

	public AIGoalPreset toGoWalkGoal;

	public BuildingPreset cityHall;

	[Tooltip("How many sales records are kept")]
	[Header("Sales records")]
	public int salesRecordsThreshold;

	public static RoutineControls Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
