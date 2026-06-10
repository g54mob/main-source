using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[Serializable]
public class NewAIAction
{
	public string name;

	[NonSerialized]
	[Header("Action Variables")]
	public NewAIGoal goal;

	public AIActionPreset preset;

	[Tooltip("Is this action currently active?")]
	public bool isActive;

	public bool completed;

	public bool repeat;

	[NonSerialized]
	public bool checkedForInsertions;

	public bool insertedAction;

	[ReadOnly]
	public int insertedActionPriority;

	[NonSerialized]
	public NewAIAction createdFor;

	[Header("Location")]
	public NewNode node;

	[NonSerialized]
	public Interactable interactable;

	[NonSerialized]
	public Interactable.UsagePoint usagePoint;

	[Tooltip("Is the citizen at the correct location?")]
	public bool isAtLocation;

	public PathFinder.PathData path;

	[NonSerialized]
	public Interactable passedInteractable;

	public NewRoom passedRoom;

	public NewNode forcedNode;

	[NonSerialized]
	public GroupsController.SocialGroup passedGroup;

	[NonSerialized]
	public bool forceRun;

	public float estimatedArrival;

	public float arrivedAtDestination;

	private bool actionCheckRecursion;

	private NewGameLocation.ObjectPlacement bestPlacement;

	public List<InteractablePreset> passedAcquireItems;

	public NewWall vantagePoint;

	[NonSerialized]
	[Header("Audio")]
	public AudioController.LoopingSoundInfo audioLoop;

	[NonSerialized]
	[Header("Progress")]
	public float lastRecordedTickWhileAtDesitnation;

	public float timeThisWillTake;

	public float progress;

	[NonSerialized]
	public float dontUpdateGoalPriorityForExtraTime;

	public float createdAt;

	[Header("Debug")]
	[Space(7f)]
	public InteractableController debugPassedInteractable;

	public NewRoom debugPassedRoom;

	public bool debugForcedNode;

	public Vector3 debugForcedNodeWorldPos;

	public List<Interactable> debugPickupInteractable;

	[Space(7f)]
	public InteractableController debugInteractableController;

	public Vector3 debugInteractionUsagePosition;

	public NewAIAction(NewAIGoal newGoal, AIActionPreset newPreset, bool newInsertedAction = false, NewRoom newPassedRoom = null, Interactable newPassedInteractable = null, NewNode newForcedNode = null, GroupsController.SocialGroup newPassedGroup = null, List<InteractablePreset> newPassedAcquireItems = null, bool newForceRun = false, int newInsertedActionPriority = 3, NewAIAction newCreatedFor = null)
	{
	}

	public void OnActivate()
	{
	}

	public bool DestinationCheck(bool overflowLoop = false)
	{
		return false;
	}

	private bool IsCloseEnoughForAttack()
	{
		return false;
	}

	public void MovementDestinationCheck(NewNode resetNode)
	{
	}

	public void SetUsagePoint(Interactable.UsagePoint newUsagePoint, Interactable.UsePointSlot newSlot)
	{
	}

	public bool InteractableUsePointCheck()
	{
		return false;
	}

	public void OnUsePointBusy()
	{
	}

	public void UpdateCombatPose()
	{
	}

	public void SetupPath(bool scanForNextNodeFurniture = true)
	{
	}

	public bool UsingFurnitureCheck()
	{
		return false;
	}

	public void OnDeactivate(bool executeDeactivateAnimation = true)
	{
	}

	public void CancelNextAIInteraction()
	{
	}

	public void Complete()
	{
	}

	private void ExecuteAdditionalActions(ref List<AIActionPreset.AutomaticAction> actionPresets)
	{
	}

	public void ExecuteEndSwitchChanges()
	{
	}

	public void DropItemAtEnd()
	{
	}

	public void Remove(float delayReactivationTime = 0f)
	{
	}

	public void TriggerArrivalSound()
	{
	}

	public void EndSoundLoop()
	{
	}

	public void AITick()
	{
	}

	public bool InteractableStateCheck(AIActionPreset.CheckActionAgainstState stateCheck)
	{
		return false;
	}

	public void LOSCheck()
	{
	}

	private bool IsPersuitTargetCatchable()
	{
		return false;
	}

	public void SetAtDestination(bool val, bool forceUpdate = false)
	{
	}

	public void OnInvalidMovement(int attemptNumber)
	{
	}

	public bool AllowImmediateCompletion()
	{
		return false;
	}

	public bool AllowImmediateTeleportation()
	{
		return false;
	}

	public void ImmediateComplete()
	{
	}

	public Interactable InteractablePicker(ref List<Interactable> opt, Vector3 currentWorldPosition, bool useSocialRules, out NewNode useNode, out Interactable.UsagePoint usePoint, GroupsController.SocialGroup meetingGroup = null, bool useDistance = false, bool useDistanceIfInSameAddress = true, List<Interactable> ignore = null)
	{
		useNode = null;
		usePoint = null;
		return null;
	}
}
