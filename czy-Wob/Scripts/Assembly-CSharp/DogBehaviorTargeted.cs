using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DogBehaviorTargeted : DogBehaviorBase
{
	private DogBehaviorTargetedEnum targetedEnum;

	private List<string> targetProperties = new List<string>();

	private bool requireTargetInMouth;

	private bool updatedFace;

	protected override void UpdateBehavior()
	{
		base.UpdateBehavior();
		if (isRunningBehavior && requireTargetInMouth)
		{
			if (mouthRef == null)
			{
				mouthRef = associatedDog.GetComponent<MouthController>();
			}
			GameObject targetObject = associatedAI.GetTargetObject();
			if (targetObject == null || mouthRef.GetCarriedObject() != targetObject)
			{
				associatedAI.ForceInterruptBehavior();
			}
		}
	}

	public override float GetNeedAdvertisement(Need need, GameObject potentialTarget)
	{
		if (!advertise)
		{
			return 0f;
		}
		return base.GetNeedAdvertisement(need);
	}

	public override DogBehaviorTargetedEnum GetTargetedEnum()
	{
		return targetedEnum;
	}

	protected override void AssignEnum()
	{
		base.AssignEnum();
		targetedEnum = (DogBehaviorTargetedEnum)Enum.Parse(typeof(DogBehaviorTargetedEnum), base.gameObject.name);
	}

	public override void StartBehavior()
	{
		base.StartBehavior();
		updatedFace = false;
		requireTargetInMouth = false;
		DoggyBrain component = associatedDog.GetComponent<DoggyBrain>();
		GameObject target = GetTarget();
		if (!(target == null))
		{
			if (component.GetFeelingTowardsTarget(target) == Opinion.LIKE && feelingTowardsTarget == FeelingTowardsTarget.POSITIVE)
			{
				component.SetTailStatesOverride(TailController.TailState.WAGGING);
			}
			else if (component.GetFeelingTowardsTarget(target) == Opinion.DISLIKE && feelingTowardsTarget == FeelingTowardsTarget.NEGATIVE)
			{
				updatedFace = true;
				component.SetTailStatesOverride(TailController.TailState.TUCKED);
				associatedDog.GetComponent<FaceController>().RequestFace(Face.ANGRY);
			}
		}
	}

	public override void FinishBehavior(bool naturalFinish = true, GameObject objectCause = null)
	{
		base.FinishBehavior(naturalFinish, objectCause);
		GameObject target = GetTarget();
		DoggyBrain component = associatedDog.GetComponent<DoggyBrain>();
		component.ClearTailStatesOverride();
		if (updatedFace)
		{
			associatedDog.GetComponent<FaceController>().RequestFace(Face.DEFAULT);
		}
		if (naturalFinish && target != null)
		{
			InteractableBase component2 = target.transform.root.GetComponent<InteractableBase>();
			if (component2 != null)
			{
				component2.OnObjectInteractedWithByDog(associatedDog, feelingTowardsTarget);
			}
			Opinion opinion = component.GetFeelingTowardsTarget(target);
			if (opinion == Opinion.LIKE && feelingTowardsTarget == FeelingTowardsTarget.POSITIVE)
			{
				associatedDog.GetComponent<DogParticleController>().RequestHappyUpdateParticles();
			}
			else if (opinion == Opinion.DISLIKE && feelingTowardsTarget == FeelingTowardsTarget.NEGATIVE)
			{
				associatedDog.GetComponent<DogParticleController>().RequestAngryUpdateParticles();
			}
		}
		associatedAI.ClearTargetObject();
		targetProperties.Clear();
	}

	public override bool TargetConditionsMet(GameObject potentialTarget)
	{
		if (targetConditions.Count > 0 && potentialTarget == null)
		{
			return false;
		}
		for (int i = 0; i < targetConditions.Count; i++)
		{
			if (!targetConditions[i].ConditionMet(associatedDog, potentialTarget))
			{
				return false;
			}
		}
		return true;
	}

	protected override bool NeedsCancel()
	{
		if (associatedAI.GetTargetObject() == null)
		{
			return true;
		}
		return false;
	}

	protected override void RunAction(DogAction action)
	{
		if (runningAction)
		{
			Debug.LogError("RunningAction already set to true when a new action is set to be run.");
		}
		runningAction = true;
		switch (action)
		{
		case DogAction.WALK_TO_INTERACTION_POINT:
			TargetPointHelper.TargetGivenPoint(associatedDog, associatedAI.GetTargetObject().GetComponent<InteractableBase>().GetInteractionPointTransform(), base.ActionFinishedCallback, ReservableObjectType.NONE, useLooseFacingOffset: false, useSuperLooseFacingOffset: false, usePointDirectly: true);
			break;
		case DogAction.WALK_TO_TARGET:
			TargetPointHelper.TargetGivenPoint(associatedDog, associatedAI.GetTargetObject().transform, base.ActionFinishedCallback);
			break;
		case DogAction.WALK_TO_TARGET_CLOSE_GROUND:
			TargetPointHelper.TargetGivenPoint(associatedDog, associatedAI.GetTargetObject().transform, base.ActionFinishedCallback, ReservableObjectType.NONE, useLooseFacingOffset: false, useSuperLooseFacingOffset: false, usePointDirectly: false, getClose: true, isGroundPosition: true);
			break;
		case DogAction.FACE_TARGET:
			TargetPointHelper.TargetGivenPoint(associatedDog, associatedAI.GetTargetObject().transform, base.ActionFinishedCallback, ReservableObjectType.NONE, useLooseFacingOffset: true);
			break;
		case DogAction.FACE_TARGET_FAR:
			TargetPointHelper.TargetGivenPoint(associatedDog, associatedAI.GetTargetObject().transform, base.ActionFinishedCallback, ReservableObjectType.NONE, useLooseFacingOffset: false, useSuperLooseFacingOffset: true);
			break;
		case DogAction.EAT:
			associatedDog.GetComponent<EatBehavior>().RequestEat(associatedAI.GetTargetObject());
			ActionFinishedCallback();
			break;
		case DogAction.LEVITATE_TARGET:
			associatedDog.GetComponent<LevitateBehavior>().RequestLevitate(associatedAI.GetTargetObject(), base.ActionFinishedCallback);
			break;
		case DogAction.GHOST_EAT:
			associatedDog.GetComponent<GhostEatBehavior>().RequestEat(associatedAI.GetTargetObject(), base.ActionFinishedCallback);
			break;
		case DogAction.THROW_TARGET:
			associatedDog.GetComponent<ThrowObjectBehavior>().RequestThrow(associatedAI.GetTargetObject(), base.ActionFinishedCallback);
			break;
		case DogAction.SHAKE_TARGET:
			associatedDog.GetComponent<ShakeObjectBehavior>().RequestShake(associatedAI.GetTargetObject(), base.ActionFinishedCallback);
			break;
		case DogAction.GRAB_TARGET:
			associatedDog.GetComponent<MouthController>().GrabObject(associatedAI.GetTargetObject(), hold: true, base.ActionFinishedCallback);
			break;
		case DogAction.BITE_TARGET:
			associatedDog.GetComponent<MouthController>().GrabObject(associatedAI.GetTargetObject(), hold: false, base.ActionFinishedCallback);
			break;
		case DogAction.DROP_TARGET:
			associatedDog.GetComponent<MouthController>().DropObject();
			ActionFinishedCallback();
			break;
		case DogAction.FINALIZE_DEN_CONSTRUCTION:
			associatedDog.GetComponent<DogDenController>().FinalizeDenConstruction(associatedAI.GetTargetObject(), base.ActionFinishedCallback);
			break;
		case DogAction.TARGET_HELD_REQUIREMENT:
			requireTargetInMouth = true;
			ActionFinishedCallback();
			break;
		case DogAction.RELEASE_TARGET_HELD_REQUIREMENT:
			requireTargetInMouth = false;
			ActionFinishedCallback();
			break;
		case DogAction.GROWL:
		{
			associatedDog.GetComponent<DogNoises>().RequestGrowl();
			DogAI component = associatedAI.GetTargetObject().transform.root.GetComponent<DogAI>();
			if (component != null)
			{
				component.OnGrowledAtByDog(associatedDog);
			}
			ActionFinishedCallback();
			break;
		}
		case DogAction.COMPLAIN:
		{
			associatedDog.GetComponent<DogNoises>().RequestComplain();
			DogAI component = associatedAI.GetTargetObject().transform.root.GetComponent<DogAI>();
			if (component != null)
			{
				component.OnComplainedAtByDog(associatedDog);
			}
			ActionFinishedCallback();
			break;
		}
		case DogAction.BURY_HELD_OBJECT:
		{
			GameObject carriedObject = mouthRef.GetCarriedObject();
			mouthRef.DropObject();
			associatedAI.GetTargetObject().GetComponent<Hole>().BuryObject(carriedObject);
			ActionFinishedCallback();
			break;
		}
		case DogAction.DIG_UP_HOLE:
			associatedAI.GetTargetObject().GetComponent<Hole>().DigUp();
			ActionFinishedCallback();
			break;
		case DogAction.WATCH_TV:
			associatedAI.GetComponent<WatchTVBehavior>().RequestWatch(associatedAI.GetTargetObject().GetComponent<InteractableTV>(), base.ActionFinishedCallback);
			break;
		default:
			base.RunAction(action);
			break;
		}
	}

	protected override void FinalizeAction(DogAction action, bool naturalFinish)
	{
		switch (action)
		{
		case DogAction.WALK_TO_INTERACTION_POINT:
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			break;
		case DogAction.WALK_TO_TARGET:
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			break;
		case DogAction.WALK_TO_TARGET_CLOSE_GROUND:
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			break;
		case DogAction.FACE_TARGET:
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			break;
		case DogAction.FACE_TARGET_FAR:
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			break;
		case DogAction.EAT:
			associatedDog.GetComponent<EatBehavior>().RequestStopEating(naturalEnd: true);
			break;
		case DogAction.LEVITATE_TARGET:
			associatedDog.GetComponent<LevitateBehavior>().RequestStopLevitating();
			break;
		case DogAction.GHOST_EAT:
			associatedDog.GetComponent<GhostEatBehavior>().RequestStopEating(naturalEnd: true);
			break;
		case DogAction.THROW_TARGET:
			associatedDog.GetComponent<ThrowObjectBehavior>().RequestStopThrowing();
			break;
		case DogAction.SHAKE_TARGET:
			associatedDog.GetComponent<ShakeObjectBehavior>().RequestStopShaking();
			break;
		case DogAction.WATCH_TV:
			associatedDog.GetComponent<WatchTVBehavior>().RequestStop();
			break;
		default:
			base.FinalizeAction(action, naturalFinish);
			break;
		}
	}

	public override bool IsTargeted()
	{
		return true;
	}

	public override GameObject GetTarget()
	{
		return associatedAI.GetTargetObject();
	}

	protected virtual GameObject GetTarget(GameObject obj)
	{
		if (obj.tag == Tags.DOG)
		{
			return obj.GetComponent<LegController>().bodyFront;
		}
		Rigidbody componentInChildren = obj.GetComponentInChildren<Rigidbody>();
		if (componentInChildren != null)
		{
			return componentInChildren.gameObject;
		}
		return obj;
	}

	protected virtual bool CheckDistanceToTarget(float maxDist, float minDist = -1f)
	{
		GameObject obj = positionRefObj;
		float num = Vector3.Distance(b: associatedAI.GetTargetObject().transform.position, a: obj.transform.position);
		if (num < maxDist && num > minDist)
		{
			return true;
		}
		return false;
	}

	protected virtual bool CheckFacing()
	{
		return true;
	}

	public override List<string> GetAllProperties()
	{
		List<string> allProperties = base.GetAllProperties();
		allProperties.AddRange(targetProperties);
		return allProperties;
	}
}
