using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[Serializable]
public class NewAIGoal : IComparable<NewAIGoal>
{
	public enum DoorActionCheckResult
	{
		success = 0,
		noHandle = 1,
		beingUsed = 2,
		duplicate = 3
	}

	public enum DoorSide
	{
		mySide = 0,
		forceCurrentSide = 1,
		forceCurrentOtherSide = 2
	}

	public string name;

	[NonSerialized]
	[Header("Parents")]
	public NewAIController aiController;

	public AIGoalPreset preset;

	[Header("Goal Variables")]
	public float basePriority;

	private float traitMultiplier;

	[Tooltip("Is this goal currently active?")]
	public bool isActive;

	[Tooltip("The time this should happen at (ideally)")]
	public float triggerTime;

	[Tooltip("The time this was last set to active")]
	public float activeTimestamp;

	[NonSerialized]
	public float duration;

	public float debugWorkStartHour;

	public float debugWorkEndHour;

	private NewGameLocation lastEstimatedTravelTime;

	[NonSerialized]
	public float travelTime;

	[Tooltip("The amount of time this has been active")]
	public int jobID;

	[NonSerialized]
	[Tooltip("How important is this action compared to others")]
	[Header("Priority")]
	public float timingWeight;

	[NonSerialized]
	public float nourishmentWeight;

	[NonSerialized]
	public float hydrationWeight;

	[NonSerialized]
	public float altertnessWeight;

	[NonSerialized]
	public float tirednessWeight;

	[NonSerialized]
	public float energyWeight;

	[NonSerialized]
	public float excitementWeight;

	[NonSerialized]
	public float choresWeight;

	[NonSerialized]
	public float hygeieneWeight;

	[NonSerialized]
	public float bladderWeight;

	[NonSerialized]
	public float heatWeight;

	[NonSerialized]
	public float drunkWeight;

	[NonSerialized]
	public float breathWeight;

	[NonSerialized]
	public float poisonedWeight;

	[NonSerialized]
	public float blindedWeight;

	[Space(7f)]
	[ReadOnly]
	public float priority;

	[Header("Actions")]
	public List<NewAIAction> actions;

	public float nextPotterAction;

	private int doorCheckCycle;

	private bool workCleanUpStarted;

	public List<Interactable> chosenInteractablesThisGoal;

	[Header("Location")]
	public NewGameLocation gameLocation;

	public NewRoom roomLocation;

	public NewNode passedNode;

	[NonSerialized]
	public Interactable passedInteractable;

	public NewGameLocation passedGameLocation;

	public int passedVar;

	[NonSerialized]
	public GroupsController.SocialGroup passedGroup;

	public int searchProgress;

	public List<NewNode> searchedNodes;

	[NonSerialized]
	public MurderController.Murder murderRef;

	public float lastCheckedForWorkingDay;

	public float lastCheckedForGroupDay;

	private bool startGameWorkCheck;

	private bool startGameGroupCheck;

	private NewRoom arrivedRoom;

	public NewAIGoal(NewAIController newController, AIGoalPreset newPreset, float newTrigerTime, float newDuration, NewNode newPassedNode = null, Interactable newPassedInteractable = null, NewGameLocation newPassedGameLocation = null, GroupsController.SocialGroup newPassedGroup = null, MurderController.Murder newMurderRef = null, float newTraitMultiplier = 1f, int newPassedVar = -2)
	{
	}

	public void UpdateNextWorkingTimes()
	{
	}

	public void UpdateNextGroupTimes()
	{
	}

	public void UpdatePriority(bool ignoreDelayTime = false)
	{
	}

	public void OnActivate()
	{
	}

	public void RefreshActions(bool refresh = false)
	{
	}

	public void OnDeactivate(float delayReactivationTime)
	{
	}

	public void AITick()
	{
	}

	public void InsertActionsCheck()
	{
	}

	public void CancelIrreleventActions()
	{
	}

	public void ResetBehaviourCheck(InteractablePreset.ObjectResetCondition currentCondition)
	{
	}

	public void PutDownItem(Interactable inventoryItem, NewGameLocation location)
	{
	}

	public void PickUpItem(Interactable inventoryItem)
	{
	}

	public void RoomLightingCheck(NewRoom room, RoomConfiguration.AILightingBehaviour.LightingPreference pref)
	{
	}

	public bool IsLastOccupantOfRoom(NewRoom room, bool trueIfAsleep = false)
	{
		return false;
	}

	public bool IsLastOccupantOfGameLocation(NewGameLocation gl, bool trueIfAsleep = false)
	{
		return false;
	}

	public void PotterCheck()
	{
	}

	private void SetNextPotterTime()
	{
	}

	public bool TryInsertInteractableAction(Interactable with, AIActionPreset newPreset, int priority, NewNode forcedNode = null, bool duplicateActionCheck = true)
	{
		return false;
	}

	public bool TryInsertDoorAction(NewDoor door, AIActionPreset preset, DoorSide doorSide, int priority, out DoorActionCheckResult result, NewNode forcedNode = null, bool immediateTick = false, NewAIAction createdFor = null)
	{
		result = default(DoorActionCheckResult);
		return false;
	}

	private void TurnMainLightOn(NewRoom where)
	{
	}

	private void TurnMainLightOff(NewRoom where)
	{
	}

	private void TurnSecondaryLightOn(NewRoom where)
	{
	}

	private void TurnSecondaryLightsOff(NewRoom where)
	{
	}

	private void DeactivateInteractable(Interactable thisInteractable)
	{
	}

	public bool InsertUnlockAction(NewDoor door, bool lockBehind)
	{
		return false;
	}

	public bool InsertLockAction(NewDoor door)
	{
		return false;
	}

	public void InsertPlayerHidingPlaceRemoval()
	{
	}

	public void OnCompletedAction(NewAIAction completed)
	{
	}

	public void Complete()
	{
	}

	public void Remove()
	{
	}

	public float GetTimeActive()
	{
		return 0f;
	}

	public StateSaveData.CurrentGoalStateSave GetGoalStateSave()
	{
		return null;
	}

	public int CompareTo(NewAIGoal otherObject)
	{
		return 0;
	}

	public AIActionPreset GetFirstAction(NewGameLocation loc)
	{
		return null;
	}

	public float GetActionChance(AIGoalPreset.GoalActionSetup actionSetup, NewGameLocation loc)
	{
		return 0f;
	}
}
