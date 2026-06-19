using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkController : MonoBehaviour
{
	public delegate void TargetReachedCallback();

	private TargetReachedCallback currentCallback;

	public bool debugNoWalk;

	public bool turningEnabled = true;

	public bool debugvis;

	private RaycastHit[] results = new RaycastHit[100];

	private Transform facingTarget;

	private bool applyFacingTorque = true;

	private float targetAngle;

	private float targetDistance = 1.5f;

	private float offsetTargetDistance = 1f;

	private float tallDogAdjustedTargetDistance = 5f;

	private float looseTargetDistance = 3f;

	private float superLooseTargetDistance = 50f;

	private float closeTargetDistance = 0.1f;

	private bool requireClose;

	private bool useLooseTargetDistance;

	private bool useSuperLooseTargetDistance;

	private bool finalTargetIsGroundPosition;

	private bool directlyTargetFinalTransform;

	private bool useLooseTargetDistanceForFinalObject;

	private bool useSuperLooseTargetDistanceForFinalObject;

	private float currentAngleDiff;

	private float walkDrag;

	private float facingTorque = 400f;

	private float facingDeadzone = 25f;

	private float timeBeforeTurnRequest = 0.25f;

	private float incorrectFacingTime;

	private int lastFacingCheckFrame = -1;

	private bool lastFacingCheckValue;

	private GameObject lastFacingObject;

	public bool groundedWalkReqs;

	private List<LegGroup> walkingGroups = new List<LegGroup>();

	private List<BodyGroup> walkingGroupsBody = new List<BodyGroup>();

	private int currentPathNode;

	private GameObject finalPathTarget;

	private ulong? finalRoomUID;

	private ReservableObjectType finalReservableType;

	private Vector3 finalPathPos;

	private TargetReachedCallback finalPathCallback;

	private Vector3 verticalPathNodeOffset = new Vector3(0f, 0.2f, 0f);

	private List<PathPosition> path = new List<PathPosition>();

	private Coroutine currentReplanRoutine;

	private Vector3 lastNewPos = Vector3.zero;

	private float stuckDist = 0.25f;

	private float timeNearCurrentPos;

	private float stuckTime = 10f;

	private float objectDropTime = 2f;

	private float gruntChance = 0.001f;

	private bool trainingMode;

	private List<GameObject> faceCheckList = new List<GameObject>();

	private List<GameObject> facingObjectsToDestroyOnFinish = new List<GameObject>();

	private List<GameObject> targetObjectsToDestroyOnFinish = new List<GameObject>();

	private DogAI aiRef;

	private BodyBuck buckRef;

	private DogState stateRef;

	private DoggyBrain brainRef;

	private TurnInPlace turnRef;

	private DogNoises dogNoisesRef;

	private FaceController faceRef;

	private BoundingBoxComponent bbc;

	private MouthController mouthRef;

	private LegController legControllerRef;

	private DogDenController denControllerRef;

	private NodeAssociationController nodeRef;

	private void Awake()
	{
		aiRef = GetComponent<DogAI>();
		buckRef = GetComponent<BodyBuck>();
		stateRef = GetComponent<DogState>();
		brainRef = GetComponent<DoggyBrain>();
		turnRef = GetComponent<TurnInPlace>();
		dogNoisesRef = GetComponent<DogNoises>();
		faceRef = GetComponent<FaceController>();
		bbc = GetComponent<BoundingBoxComponent>();
		mouthRef = GetComponent<MouthController>();
		legControllerRef = GetComponent<LegController>();
		denControllerRef = GetComponent<DogDenController>();
		nodeRef = GetComponent<NodeAssociationController>();
	}

	private void OnDrawGizmos()
	{
		if (!debugvis || path.Count == 0)
		{
			return;
		}
		Gizmos.color = Color.grey;
		for (int i = 0; i < path.Count; i++)
		{
			if (i == currentPathNode)
			{
				Gizmos.color = Color.blue;
			}
			else
			{
				Gizmos.color = Color.grey;
			}
			Gizmos.DrawSphere(path[i].position, 0.25f);
			if (i > 0)
			{
				Gizmos.DrawLine(path[i].position, path[i - 1].position);
			}
		}
		Gizmos.DrawLine(path[path.Count - 1].position, finalPathPos);
	}

	public void SetTrainingMode()
	{
		trainingMode = true;
	}

	public void UpdateWalk(bool debugWalk = false)
	{
		if (trainingMode || debugWalk)
		{
			WalkWithTurn();
			return;
		}
		for (int i = 0; i < path.Count; i++)
		{
			if (path[i].denUID.HasValue)
			{
				if (!(ObjectRegistration.GetRegistrationScript().GetPlaceableObjectForUID(path[i].denUID.Value) == null))
				{
					break;
				}
				OnWalkEnded();
				aiRef.ForceInterruptBehavior();
				return;
			}
		}
		if (finalPathTarget != null)
		{
			UpdateFinalPathPosition();
		}
		Vector3 pos = finalPathPos;
		if (finalTargetIsGroundPosition)
		{
			pos += verticalPathNodeOffset;
		}
		if (path.Count == 0 && currentReplanRoutine == null && (finalPathTarget == null || !CleanCastToPosition(pos, finalPathTarget)))
		{
			OnWalkEnded();
			aiRef.ForceInterruptBehavior();
			return;
		}
		WalkWithTurn();
		if (!nodeRef.IsInPipe())
		{
			CheckCallback();
			CheckPathReverse();
		}
	}

	public void OnObjectInFrontOfFace(GameObject obj)
	{
		obj = obj.transform.root.gameObject;
		if (!obj.CompareTag(Tags.DOG) && finalPathTarget != null && obj.tag != "Untagged")
		{
			DogBehaviorBase currentBehavior = aiRef.GetCurrentBehavior();
			_ = currentBehavior.retargetingStrategy;
			if (finalPathTarget.CompareTag(obj.tag))
			{
				finalPathTarget = obj;
				aiRef.SetTargetObject(obj);
				FinishPathPrematurely();
			}
			else if (currentBehavior.retargetingStrategy == RetargetStrategy.SAME_TAG_OR_NEW_TAGS && currentBehavior.additionalRetargetingTags.Contains(Tags.GetTagsEnumFromTag(obj.tag)))
			{
				finalPathTarget = obj;
				aiRef.SetTargetObject(obj);
				FinishPathPrematurely();
			}
		}
	}

	public void ReportReservationObject(ReservableObject obj)
	{
		aiRef.SetTargetReservableObject(obj);
		FinishPathPrematurely();
	}

	public bool IsInPositionForTarget(GameObject targetObj)
	{
		if (mouthRef.GetCarriedObject() == targetObj.transform.root.gameObject)
		{
			return true;
		}
		bool flag = IsFacingObject(targetObj) && IsCloseToObject(targetObj);
		if (flag)
		{
			return true;
		}
		if (!IsFollowingPath() || path.Count <= 1)
		{
			return flag;
		}
		if (currentPathNode < path.Count - 1 && !path[currentPathNode].denUID.HasValue)
		{
			return CleanCastToPosition(path[currentPathNode + 1].position + verticalPathNodeOffset);
		}
		return flag;
	}

	private bool IsFollowingPath()
	{
		if (path.Count <= 0 || currentPathNode > path.Count - 1)
		{
			return false;
		}
		return true;
	}

	private void CheckPathReverse()
	{
		if (path.Count == 0)
		{
			return;
		}
		Vector3 pos = finalPathPos;
		if (finalTargetIsGroundPosition)
		{
			pos += verticalPathNodeOffset;
		}
		if (currentReplanRoutine == null && !path[path.Count - 1].denUID.HasValue && !CleanCastToPosition(pos, finalPathTarget, path[path.Count - 1].position + verticalPathNodeOffset))
		{
			ReplanPath();
		}
		else if (!IsFollowingPath())
		{
			if (CleanCastToPosition(pos, finalPathTarget))
			{
				return;
			}
			if (currentPathNode <= 1)
			{
				OnWalkEnded();
				aiRef.ForceInterruptBehavior();
				return;
			}
			if (currentPathNode < path.Count && !path[currentPathNode].denUID.HasValue)
			{
				Vector3 value = path[currentPathNode].position + verticalPathNodeOffset;
				if (!CleanCastToPosition(pos, finalPathTarget, value))
				{
					OnWalkEnded();
					aiRef.ForceInterruptBehavior();
				}
			}
			while (currentPathNode >= path.Count)
			{
				currentPathNode--;
			}
			SetFacingPoint(path[currentPathNode].position, PathNodeReachedCallback);
		}
		else if (!CleanCastToPosition(facingTarget.position + verticalPathNodeOffset, facingTarget.gameObject))
		{
			if (currentPathNode == 0)
			{
				OnWalkEnded();
				aiRef.ForceInterruptBehavior();
			}
			else
			{
				currentPathNode--;
				SetFacingPoint(path[currentPathNode].position, PathNodeReachedCallback);
			}
		}
	}

	private void CheckIsStuck()
	{
		Vector3 position = legControllerRef.bodyFront.transform.position;
		if (Vector3.Distance(position, lastNewPos) > stuckDist * base.transform.root.localScale.x)
		{
			timeNearCurrentPos = 0f;
			lastNewPos = position;
			return;
		}
		if (timeNearCurrentPos >= objectDropTime && mouthRef.IsCarryingObject() && aiRef.GetTargetObject() != mouthRef.GetCarriedObject())
		{
			mouthRef.DropObject();
		}
		if (timeNearCurrentPos >= stuckTime)
		{
			brainRef.OnStuck();
			if (buckRef == null)
			{
				buckRef = GetComponent<BodyBuck>();
			}
			if (!buckRef.IsBucking())
			{
				buckRef.RequestBuck();
			}
		}
		timeNearCurrentPos += Time.deltaTime;
	}

	private void OnWalkEnded()
	{
		lastFacingObject = null;
		if (IsFollowingPath())
		{
			currentCallback = finalPathCallback;
		}
		ClearPath();
		CallCallback();
		for (int i = 0; i < walkingGroups.Count; i++)
		{
			walkingGroups[i].Reset();
		}
		for (int j = 0; j < walkingGroupsBody.Count; j++)
		{
			walkingGroupsBody[j].Reset();
		}
	}

	private void CallCallback()
	{
		if (currentCallback != null)
		{
			TargetReachedCallback targetReachedCallback = currentCallback;
			currentCallback = null;
			targetReachedCallback();
		}
	}

	private void CheckCallback()
	{
		if (currentCallback == null)
		{
			return;
		}
		if (facingTarget == null)
		{
			CallCallback();
		}
		else if (IsInPositionForTarget(facingTarget.gameObject))
		{
			if (finalPathTarget == null)
			{
				CallCallback();
				return;
			}
			if (path == null)
			{
				Debug.LogError("path is null");
			}
			if (facingTarget.root == finalPathTarget.transform.root && currentPathNode < path.Count)
			{
				currentPathNode++;
			}
			CallCallback();
		}
		else if (finalRoomUID.HasValue)
		{
			ulong? roomUID = bbc.GetRoomUID(requireInRoom: true);
			if (roomUID.HasValue && roomUID == finalRoomUID)
			{
				FinishPathPrematurely();
			}
		}
		else
		{
			if (finalPathTarget == null)
			{
				return;
			}
			if (finalTargetIsGroundPosition && IsCloseToObject(finalPathTarget.transform.root.gameObject, ignoreY: true))
			{
				FinishPathPrematurely();
				return;
			}
			if (stateRef.GetObjectInFrontOfFace() == finalPathTarget.transform.root.gameObject)
			{
				InteractableBase component = finalPathTarget.transform.root.gameObject.GetComponent<InteractableBase>();
				if (component == null || !component.HasCustomInteractionPoint())
				{
					FinishPathPrematurely();
					return;
				}
			}
			if (facingTarget.root == finalPathTarget.transform.root)
			{
				return;
			}
			Vector3 pos = finalPathPos;
			if (finalTargetIsGroundPosition)
			{
				pos += verticalPathNodeOffset;
			}
			if (currentPathNode < path.Count && CleanCastToPosition(pos, finalPathTarget))
			{
				currentPathNode = path.Count;
				CallCallback();
			}
			else if (IsFacingObject(finalPathTarget) && IsCloseToObject(finalPathTarget))
			{
				InteractableBase component2 = finalPathTarget.transform.root.gameObject.GetComponent<InteractableBase>();
				if (component2 == null || !component2.HasCustomInteractionPoint())
				{
					FinishPathPrematurely();
				}
			}
		}
	}

	public void FinishPathPrematurely()
	{
		currentPathNode = path.Count;
		if (finalPathCallback != null)
		{
			currentCallback = finalPathCallback;
		}
		CallCallback();
	}

	public void ResetLimbsAngularDrag()
	{
		for (int i = 0; i < walkingGroups.Count; i++)
		{
			walkingGroups[i].ResetLimbsAngularDrag();
		}
	}

	private void WalkWithTurn()
	{
		if (debugNoWalk)
		{
			ResetLimbsAngularDrag();
			legControllerRef.RestoreRotation(legControllerRef.GetDefaultRestoreMod());
			legControllerRef.Stabilize();
			return;
		}
		bool flag = true;
		if (facingTarget != null)
		{
			UpdateTargetAngle();
			flag = IsFacingObject(facingTarget.gameObject);
		}
		if (!turningEnabled)
		{
			flag = true;
		}
		bool flag2 = aiRef.IsValidRotation();
		if (!flag)
		{
			if (flag2)
			{
				if (incorrectFacingTime >= timeBeforeTurnRequest && !turnRef.IsTurning())
				{
					turnRef.RequestTurn(facingTarget);
				}
				else if (turnRef.IsTurning() && !turnRef.IsDoingPlantedTurn() && turnRef.ShouldBeDoingPlantedTurn(facingTarget))
				{
					turnRef.RequestStop(forceDone: true);
					turnRef.RequestTurn(facingTarget);
				}
				if (!turnRef.IsDoingPlantedTurn())
				{
					legControllerRef.TorqueBodyTowardsPoint(legControllerRef.bodyBack, facingTarget.position);
					legControllerRef.TorqueBodyTowardsPoint(legControllerRef.bodyFront, facingTarget.position);
				}
			}
			incorrectFacingTime += Time.deltaTime;
		}
		else
		{
			incorrectFacingTime = 0f;
		}
		if (!flag2 && turnRef.IsTurning())
		{
			turnRef.RequestStop(forceDone: true);
		}
		if (legControllerRef.AnyLegGrounded())
		{
			legControllerRef.StabilizeBody(legControllerRef.bodyBack, 35f, 500f);
			legControllerRef.StabilizeBody(legControllerRef.bodyFront, 35f, 500f);
		}
		if (!flag2 || turnRef.IsDoingPlantedTurn())
		{
			ResetLimbsAngularDrag();
			legControllerRef.RestoreRotation(legControllerRef.GetDefaultRestoreMod());
			legControllerRef.Stabilize();
			if (Random.value < gruntChance)
			{
				dogNoisesRef.RequestGrunt();
			}
			CheckIsStuck();
			return;
		}
		CheckIsStuck();
		for (int i = 0; i < walkingGroups.Count; i++)
		{
			legControllerRef.MoveLegGroup(walkingGroups[i]);
		}
		for (int j = 0; j < walkingGroupsBody.Count; j++)
		{
			legControllerRef.MoveBodyGroup(walkingGroupsBody[j]);
		}
		legControllerRef.RestoreRotation(legControllerRef.walkRestoreMod);
	}

	private void AddTargetObjectToDestroyIfNeeded(GameObject obj)
	{
		if (!targetObjectsToDestroyOnFinish.Contains(obj))
		{
			targetObjectsToDestroyOnFinish.Add(obj);
		}
	}

	private void AddFacingObjectToDestroyIfNeeded(GameObject obj)
	{
		DestroyFacingObjects();
		if (!facingObjectsToDestroyOnFinish.Contains(obj))
		{
			facingObjectsToDestroyOnFinish.Add(obj);
		}
	}

	public bool SetPathingTarget(GameObject targetObj, TargetReachedCallback callback = null, bool useLooseOffset = false, ulong? targetRoomUID = null, ReservableObjectType targetReservableType = ReservableObjectType.NONE, bool useSuperLooseFacingOffset = false, bool destroyTargetAfter = false, bool isGroundPosition = false, bool usePointDirectly = false, bool getClose = false)
	{
		if (targetObj == null)
		{
			return false;
		}
		if (destroyTargetAfter)
		{
			AddTargetObjectToDestroyIfNeeded(targetObj);
		}
		if (nodeRef.IsInPipe())
		{
			finalPathTarget = targetObj;
			finalRoomUID = targetRoomUID;
			finalPathCallback = callback;
			finalReservableType = targetReservableType;
			ReplanPath();
			return true;
		}
		path = nodeRef.GetPathToTarget(targetObj, usePointDirectly);
		if (path.Count == 0)
		{
			if (aiRef.CanRaycastToObject(targetObj))
			{
				SetFacingTarget(targetObj.transform, callback);
				return true;
			}
			if (aiRef.GetCurrentBehavior() != null)
			{
				aiRef.ForceInterruptBehavior();
			}
			callback();
			return false;
		}
		requireClose = getClose;
		finalTargetIsGroundPosition = isGroundPosition;
		directlyTargetFinalTransform = usePointDirectly;
		useLooseTargetDistanceForFinalObject = useLooseOffset;
		useSuperLooseTargetDistanceForFinalObject = useSuperLooseFacingOffset;
		finalPathTarget = targetObj;
		finalRoomUID = targetRoomUID;
		finalReservableType = targetReservableType;
		finalPathCallback = callback;
		UpdateFinalPathPosition();
		if (path.Count > 1)
		{
			currentPathNode = 1;
		}
		else
		{
			currentPathNode = 0;
		}
		if (currentPathNode >= path.Count)
		{
			if (aiRef.GetCurrentBehavior() != null)
			{
				aiRef.ForceInterruptBehavior();
			}
			callback();
			return false;
		}
		SetFacingPoint(path[currentPathNode].position, PathNodeReachedCallback);
		return true;
	}

	private void UpdateFinalPathPosition()
	{
		if (directlyTargetFinalTransform)
		{
			finalPathPos = finalPathTarget.transform.position;
			return;
		}
		DogAI.TransformAndPos bestTransformAndPosForTarget = aiRef.GetBestTransformAndPosForTarget(finalPathTarget);
		if (bestTransformAndPosForTarget.transform == null)
		{
			Vector3 position = finalPathTarget.transform.position;
			InteractableBase component = finalPathTarget.GetComponent<InteractableBase>();
			ObjectUtil.GetStageHitpoint(finalPathPos = ((!(component != null)) ? ObjectUtil.GetObjCenter(finalPathTarget) : component.GetInteractionPoint()), ref finalPathPos);
		}
		else
		{
			finalPathPos = bestTransformAndPosForTarget.closestPosition;
		}
	}

	private void ReplanPath()
	{
		if (currentReplanRoutine != null)
		{
			StopCoroutine(currentReplanRoutine);
		}
		currentReplanRoutine = StartCoroutine(ReplanRoutine());
	}

	private IEnumerator ReplanRoutine()
	{
		while (nodeRef.IsInPipe())
		{
			yield return new WaitForSeconds(0.25f);
		}
		TargetReachedCallback callback = finalPathCallback;
		currentCallback = null;
		finalPathCallback = null;
		SetPathingTarget(finalPathTarget, callback, useLooseTargetDistanceForFinalObject, finalRoomUID, finalReservableType, useSuperLooseTargetDistanceForFinalObject, destroyTargetAfter: false, finalTargetIsGroundPosition, directlyTargetFinalTransform, requireClose);
		currentReplanRoutine = null;
	}

	private void ClearPath()
	{
		if (currentReplanRoutine != null)
		{
			StopCoroutine(currentReplanRoutine);
			currentReplanRoutine = null;
		}
		path.Clear();
		finalRoomUID = null;
		finalPathTarget = null;
		finalPathCallback = null;
		finalPathPos = Vector3.zero;
		finalReservableType = ReservableObjectType.NONE;
		DestroyTargetOjbects();
		DestroyFacingObjects();
	}

	private void DestroyTargetOjbects()
	{
		for (int num = targetObjectsToDestroyOnFinish.Count - 1; num >= 0; num--)
		{
			if (targetObjectsToDestroyOnFinish[num] != null)
			{
				Object.Destroy(targetObjectsToDestroyOnFinish[num]);
			}
		}
		targetObjectsToDestroyOnFinish.Clear();
	}

	private void DestroyFacingObjects()
	{
		for (int num = facingObjectsToDestroyOnFinish.Count - 1; num >= 0; num--)
		{
			if (facingObjectsToDestroyOnFinish[num] != null)
			{
				Object.Destroy(facingObjectsToDestroyOnFinish[num]);
			}
		}
		facingObjectsToDestroyOnFinish.Clear();
		faceRef.StopFocus();
	}

	private void PathNodeReachedCallback()
	{
		if (currentPathNode < path.Count && path[currentPathNode].denUID.HasValue)
		{
			if (path[currentPathNode].exteriorNode)
			{
				GameObject placeableObjectForUID = ObjectRegistration.GetRegistrationScript().GetPlaceableObjectForUID(path[currentPathNode].denUID.Value);
				if (placeableObjectForUID == null)
				{
					aiRef.ForceInterruptBehavior();
					return;
				}
				denControllerRef.EnterDen(placeableObjectForUID);
			}
			else
			{
				denControllerRef.ExitDen();
			}
		}
		currentPathNode++;
		if (currentPathNode >= path.Count)
		{
			if (finalPathTarget != null)
			{
				UpdateFinalPathPosition();
				SetFacingTarget(finalPathTarget.transform, finalPathCallback);
			}
			else
			{
				aiRef.ForceInterruptBehavior();
			}
		}
		else
		{
			SetFacingPoint(path[currentPathNode].position, PathNodeReachedCallback);
		}
	}

	public void SetFacingPoint(Vector3 newFacingPos, TargetReachedCallback callback = null, bool useLooseOffset = false, bool useSuperLooseFacingOffset = false)
	{
		currentCallback = null;
		GameObject gameObject = new GameObject("TempFacingTarget (FacingPoint) " + base.gameObject.name);
		gameObject.transform.position = newFacingPos;
		SetFacingTarget(gameObject.transform, callback, useLooseOffset, useSuperLooseFacingOffset, destroyTargetAfter: true);
	}

	public void SetFacingTarget(Transform newFacingObj, TargetReachedCallback callback = null, bool useLooseOffset = false, bool useSuperLooseFacingOffset = false, bool destroyTargetAfter = false)
	{
		if (finalPathTarget != null && newFacingObj == finalPathTarget.transform)
		{
			useLooseTargetDistance = useLooseTargetDistanceForFinalObject;
			useSuperLooseTargetDistance = useSuperLooseTargetDistanceForFinalObject;
		}
		else
		{
			useLooseTargetDistance = useLooseOffset;
			useSuperLooseTargetDistance = useSuperLooseFacingOffset;
		}
		if (destroyTargetAfter)
		{
			AddFacingObjectToDestroyIfNeeded(newFacingObj.gameObject);
		}
		facingTarget = aiRef.GetBestPosTransformForTarget(newFacingObj.gameObject);
		if (facingTarget == null)
		{
			Rigidbody rigidbody = newFacingObj.GetComponent<Rigidbody>();
			if (rigidbody == null)
			{
				rigidbody = newFacingObj.GetComponentInChildren<Rigidbody>();
			}
			if (rigidbody == null)
			{
				facingTarget = newFacingObj;
			}
			else
			{
				facingTarget = rigidbody.transform;
			}
		}
		faceRef.FocusOnTarget(facingTarget);
		if (callback != null)
		{
			if (currentCallback != null)
			{
				Debug.LogError("Double-setting callback.");
				CallCallback();
			}
			currentCallback = callback;
		}
	}

	public void RemoveFacingTarget()
	{
		useLooseTargetDistance = false;
		useLooseTargetDistanceForFinalObject = false;
		faceRef.StopFocus();
		turnRef.RequestStop(forceDone: true);
		facingTarget = null;
		OnWalkEnded();
	}

	public void IgnoreFacing()
	{
		applyFacingTorque = false;
	}

	public void RestoreFacing()
	{
		applyFacingTorque = true;
	}

	public void UpdateFacing()
	{
		if (facingTarget == null || !applyFacingTorque)
		{
			return;
		}
		float y = legControllerRef.internalFacingObj.transform.rotation.eulerAngles.y;
		float angleDiff = AngleUtil.GetAngleDiff(targetAngle, y);
		if (!(Mathf.Abs(angleDiff) <= facingDeadzone))
		{
			float num = facingTorque;
			if (angleDiff > 0f)
			{
				num *= -1f;
			}
			legControllerRef.TorqueBody(legControllerRef.bodyBack, new Vector3(0f, num, 0f), applyLimbCompensation: true, modifyLegStrength: false);
			legControllerRef.TorqueBody(legControllerRef.bodyFront, new Vector3(0f, num, 0f), applyLimbCompensation: true, modifyLegStrength: false);
		}
	}

	public bool IsFacingObject(GameObject obj)
	{
		if (Time.frameCount == lastFacingCheckFrame && obj == lastFacingObject)
		{
			return lastFacingCheckValue;
		}
		if (finalTargetIsGroundPosition && obj == finalPathTarget && CleanCastToPosition(finalPathPos + verticalPathNodeOffset, finalPathTarget) && IsCloseToObject(finalPathTarget, ignoreY: false, groundPosCheck: true))
		{
			return true;
		}
		float yFacingAngle = AngleUtil.GetYFacingAngle(aiRef.GetBestPosForTarget(obj), legControllerRef.internalFacingObj.transform);
		float y = legControllerRef.internalFacingObj.transform.eulerAngles.y;
		currentAngleDiff = Mathf.Abs(AngleUtil.GetAngleDiff(yFacingAngle, y));
		lastFacingCheckValue = false;
		if (currentAngleDiff <= facingDeadzone)
		{
			lastFacingCheckValue = true;
		}
		lastFacingObject = obj;
		lastFacingCheckFrame = Time.frameCount;
		return lastFacingCheckValue;
	}

	public bool IsCloseToObject(GameObject obj, bool ignoreY = false, bool groundPosCheck = false)
	{
		Vector3 vector = aiRef.GetBestPosForTarget(obj);
		Vector3 position = faceRef.GetDogHeadForIndex(0).mouthTransform.position;
		bool flag = false;
		if (ignoreY || currentPathNode < path.Count - 1 || finalRoomUID.HasValue || finalTargetIsGroundPosition || groundPosCheck)
		{
			flag = true;
			vector = new Vector3(vector.x, position.y, vector.z);
		}
		float num = targetDistance;
		if (useLooseTargetDistance)
		{
			num = looseTargetDistance;
		}
		if (useSuperLooseTargetDistance)
		{
			num = superLooseTargetDistance;
		}
		if (requireClose)
		{
			num = closeTargetDistance;
		}
		if (obj.GetComponent<Collider>() == null)
		{
			return Vector3.Distance(vector, position) <= num;
		}
		if (!flag && !useLooseTargetDistance && !useSuperLooseTargetDistance && !requireClose && position.y > vector.y && Vector3.Distance(new Vector3(vector.x, position.y, vector.z), position) <= offsetTargetDistance)
		{
			num = tallDogAdjustedTargetDistance;
		}
		int hitNum = RaycastUtil.GoodRaycastAllNonAlloc(position, vector - position, num, results);
		faceCheckList.Clear();
		faceCheckList.Add(base.gameObject);
		GameObject carriedObject = mouthRef.GetCarriedObject();
		if (carriedObject != null)
		{
			faceCheckList.Add(carriedObject);
		}
		RaycastHit closestHitIgnoringObjects = RaycastUtil.GetClosestHitIgnoringObjects(hitNum, position, results, faceCheckList);
		if (closestHitIgnoringObjects.transform == null || closestHitIgnoringObjects.transform.root != obj.transform.root)
		{
			return false;
		}
		return Vector3.Distance(closestHitIgnoringObjects.point, position) <= num;
	}

	private bool CleanCastToPosition(Vector3 pos, GameObject optionalObj = null, Vector3? customRefPos = null)
	{
		Vector3 hitPoint = legControllerRef.internalFacingObj.transform.position;
		if (customRefPos.HasValue)
		{
			hitPoint = customRefPos.Value;
		}
		else
		{
			ObjectUtil.GetStageHitpoint(hitPoint, ref hitPoint);
			hitPoint += verticalPathNodeOffset;
		}
		if (Vector3.Distance(hitPoint, pos) == 0f)
		{
			return true;
		}
		int num = RaycastUtil.NavmeshPipeCastAllNonAlloc(hitPoint, pos - hitPoint, Vector3.Distance(hitPoint, pos), results);
		if (debugvis)
		{
			Debug.DrawLine(hitPoint, pos, Color.black, 0.2f);
		}
		for (int i = 0; i < num; i++)
		{
			if ((!(optionalObj != null) || ((directlyTargetFinalTransform || !(results[i].transform.root == optionalObj.transform.root)) && (!directlyTargetFinalTransform || !(results[i].transform == optionalObj.transform)))) && !(results[i].transform.root == base.gameObject.transform.root))
			{
				return false;
			}
		}
		return true;
	}

	public LegGroup GetLegGroupForLeg(GameObject leg)
	{
		for (int i = 0; i < walkingGroups.Count; i++)
		{
			if (walkingGroups[i].legs.Contains(leg))
			{
				return walkingGroups[i];
			}
		}
		return null;
	}

	public void UpdateWalkingCurves(List<AnimationCurve> torqueList, AnimationCurve fZ, AnimationCurve bZ, float jiggleMultiplier)
	{
		float multiplier = 0.5f;
		walkingGroups.Clear();
		walkingGroupsBody.Clear();
		for (int i = 0; i < legControllerRef.walkForwardGroups.Count; i++)
		{
			LegGroup legGroup = new LegGroup();
			legGroup.legs = new List<GameObject>();
			legGroup.legs.AddRange(legControllerRef.walkForwardGroups[i].legs);
			legGroup.groundedRequirements.AddRange(legControllerRef.walkForwardGroups[i].groundedRequirements);
			legGroup.loopMovement = true;
			legGroup.keyController = KeyBindings.WALK_KEY;
			if (groundedWalkReqs)
			{
				List<GameObject> list = new List<GameObject>();
				for (int j = 0; j < legControllerRef.walkForwardGroups[i].legs.Count; j++)
				{
					list.Add(legControllerRef.GetFootForLeg(legControllerRef.walkForwardGroups[i].legs[j]));
				}
				legGroup.groundedRequirements = list;
				legGroup.groundedRequirementsMode = GroundedMode.OnZDirSwitch;
			}
			legGroup.torqueX = new AnimationCurveWrapper(CreateCurve(torqueList[0], legControllerRef.walkForwardGroups[i].multiplier.x, jiggleMultiplier, legControllerRef.walkForwardGroups[i].jiggleTorque));
			legGroup.torqueY = new AnimationCurveWrapper(CreateCurve(torqueList[1], legControllerRef.walkForwardGroups[i].multiplier.y, jiggleMultiplier, legControllerRef.walkForwardGroups[i].jiggleTorque));
			legGroup.torqueZ = new AnimationCurveWrapper(CreateCurve(torqueList[2], legControllerRef.walkForwardGroups[i].multiplier.z, jiggleMultiplier, legControllerRef.walkForwardGroups[i].jiggleTorque));
			legGroup.length = legControllerRef.walkForwardLoopTime;
			legGroup.initialOffset = legControllerRef.walkForwardGroups[i].offset;
			legGroup.inMotionAngularDrag = walkDrag;
			legGroup.Initialize();
			walkingGroups.Add(legGroup);
		}
		BodyGroup bodyGroup = new BodyGroup();
		bodyGroup.legs = new List<GameObject>();
		bodyGroup.legs.Add(legControllerRef.bodyFront);
		bodyGroup.loopMovement = true;
		bodyGroup.keyController = KeyBindings.WALK_KEY;
		bodyGroup.torqueZ = new AnimationCurveWrapper(CreateCurve(fZ, multiplier));
		bodyGroup.length = legControllerRef.walkForwardLoopTime;
		bodyGroup.Initialize();
		walkingGroupsBody.Add(bodyGroup);
		BodyGroup bodyGroup2 = new BodyGroup();
		bodyGroup2.legs = new List<GameObject>();
		bodyGroup2.legs.Add(legControllerRef.bodyBack);
		bodyGroup2.loopMovement = true;
		bodyGroup2.keyController = KeyBindings.WALK_KEY;
		bodyGroup2.torqueZ = new AnimationCurveWrapper(CreateCurve(bZ, multiplier));
		bodyGroup2.length = legControllerRef.walkForwardLoopTime;
		bodyGroup2.initialOffset = 0.5f;
		bodyGroup2.Initialize();
		walkingGroupsBody.Add(bodyGroup2);
	}

	private void UpdateTargetAngle()
	{
		targetAngle = AngleUtil.GetYFacingAngle(aiRef.GetBestPosForTarget(facingTarget.gameObject), legControllerRef.internalFacingObj.transform);
	}

	private AnimationCurve CreateCurve(AnimationCurve refCurve, float multiplier = 1f, float jiggleMultiplier = 1f, bool jiggleTorque = false)
	{
		AnimationCurve animationCurve = new AnimationCurve();
		for (int i = 0; i < refCurve.length; i++)
		{
			Keyframe keyframe = refCurve.keys[i];
			float time = WrapTime(keyframe.time, legControllerRef.walkForwardLoopTime);
			float num = keyframe.value * multiplier;
			if (jiggleTorque)
			{
				num *= jiggleMultiplier;
			}
			animationCurve.AddKey(time, num);
		}
		return animationCurve;
	}

	private float WrapTime(float time, float max)
	{
		while (time > max)
		{
			time -= max;
		}
		return time;
	}
}
