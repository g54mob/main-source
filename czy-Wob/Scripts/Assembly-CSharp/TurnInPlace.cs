using System.Collections.Generic;
using UnityEngine;

public class TurnInPlace : MonoBehaviour
{
	public delegate void TurnFinishedCallback();

	private TurnFinishedCallback currentCallback;

	private bool isTurning;

	private float turnTargetAngle;

	private Transform targetToFace;

	private float facingDeadzone = 5f;

	private int turnMax = 5;

	private int currentTurnCount;

	private int numRequiredGroundedLegs = 2;

	private GameObject turnstyle;

	private ConfigurableJoint turnstyleJoint;

	private float targetTurnstyleY;

	private float turnstyleSpeed = 90f;

	private List<FixedJoint> turnstyleJoints = new List<FixedJoint>();

	private List<SmartMotion> currentMotions = new List<SmartMotion>();

	private float plantWaitTime = 3f;

	private float currentWaitTime;

	private bool backLegsPlanted;

	private bool waitingForPlants;

	private List<Limb> plantedLegs = new List<Limb>();

	private List<GameObject> bouncingLegs = new List<GameObject>();

	private GameObject bodyBack;

	private GameObject bodyFront;

	private GameObject plantedBodySegment;

	private GameObject bouncingBodySegment;

	private float plantedTurnRatio = 3f;

	private bool beingDestroyed;

	private float turnLockCurrent;

	private float turnLockTeleportTimer = 0.25f;

	private DogAI aiRef;

	private BodyBuck buckRef;

	private DogState stateRef;

	private LegController controllerRef;

	private NodeAssociationController nodeRef;

	private ObjectGrabber grabberRef;

	private void Awake()
	{
		aiRef = GetComponent<DogAI>();
		stateRef = GetComponent<DogState>();
		controllerRef = GetComponent<LegController>();
		nodeRef = GetComponent<NodeAssociationController>();
		grabberRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		bodyFront = controllerRef.bodyFront;
		bodyBack = controllerRef.bodyBack;
	}

	public void SetBuckRef(BodyBuck buck)
	{
		buckRef = buck;
	}

	private void FixedUpdate()
	{
		if (IsDoingPlantedTurn() && nodeRef.IsInPipe())
		{
			StopTurn();
		}
		if (turnstyle != null)
		{
			RotateTurnstyle();
		}
		if (turnLockCurrent > 0f)
		{
			turnLockCurrent -= Time.fixedDeltaTime;
		}
	}

	public bool IsDoingPlantedTurn()
	{
		return turnstyle != null;
	}

	public bool IsTurning()
	{
		return isTurning;
	}

	private void OnDestroy()
	{
		beingDestroyed = true;
		if (turnstyle != null)
		{
			CleanupPlantedTurn(forceDone: true);
		}
	}

	public void LockPlantedTurnsFromTeleport()
	{
		turnLockCurrent = turnLockTeleportTimer;
	}

	public void RequestPlantedTurn(float angle)
	{
		if (turnstyle != null)
		{
			StopTurn();
		}
		if (nodeRef.IsInPipe() || !controllerRef.AnyLegGrounded() || turnLockCurrent > 0f)
		{
			LargeTurn();
			return;
		}
		backLegsPlanted = false;
		if ((angle > 0f && stateRef.RightSideBlocked()) || (angle < 0f && stateRef.LeftSideBlocked()))
		{
			if ((angle > 0f && stateRef.LeftSideBlocked()) || (angle < 0f && stateRef.RightSideBlocked()))
			{
				StopTurn();
				buckRef.RequestBuck();
				return;
			}
			backLegsPlanted = true;
		}
		int legCountForBodySegment = controllerRef.GetLegCountForBodySegment(bodyFront);
		if (backLegsPlanted || legCountForBodySegment == 0)
		{
			plantedBodySegment = bodyBack;
			bouncingBodySegment = bodyFront;
		}
		else
		{
			plantedBodySegment = bodyFront;
			bouncingBodySegment = bodyBack;
		}
		plantedLegs.Clear();
		bouncingLegs = controllerRef.GetLegsForBodySegment(bouncingBodySegment);
		List<GameObject> legsForBodySegment = controllerRef.GetLegsForBodySegment(plantedBodySegment);
		for (int i = 0; i < legsForBodySegment.Count; i++)
		{
			plantedLegs.Add(legsForBodySegment[i].GetComponent<Limb>());
		}
		currentWaitTime = 0f;
		waitingForPlants = false;
		for (int j = 0; j < plantedLegs.Count; j++)
		{
			Limb component = plantedLegs[j].GetComponent<Limb>();
			component.PlantLeg();
			if (!component.IsLegPlanted())
			{
				waitingForPlants = true;
			}
		}
		targetTurnstyleY = angle;
		turnstyle = new GameObject("Turnstyle");
		if (plantedLegs.Count == 0)
		{
			CleanupPlantedTurn(forceDone: true);
		}
		else if (!waitingForPlants)
		{
			StrapFeetToPlank();
		}
	}

	private void PlantedTurnMotion(bool backLegsPlanted)
	{
		float z = 60f;
		if (backLegsPlanted)
		{
			z = 125f;
		}
		for (int i = 0; i < bouncingLegs.Count; i++)
		{
			SmartMotion smartMotion = bouncingLegs[i].AddComponent<SmartMotion>();
			smartMotion.setIsMovingLimb(limbVal: true);
			smartMotion.SetController(controllerRef);
			smartMotion.AddKeyframe(0.25f, new Vector3(0f, 0f, z));
			smartMotion.AddKeyframe(1f, new Vector3(0f, 0f, 0f), considerX: false, considerY: false, considerZ: false);
			if (i == 0)
			{
				smartMotion.StartMotion(PlantedTurnDone, Vector3.one);
			}
			else
			{
				smartMotion.StartMotion(EmptyDone, Vector3.one);
			}
			currentMotions.Add(smartMotion);
		}
		if (backLegsPlanted)
		{
			SmartMotion smartMotion2 = bodyFront.AddComponent<SmartMotion>();
			smartMotion2.setIsMovingLimb(limbVal: false);
			smartMotion2.SetController(controllerRef);
			smartMotion2.AddKeyframe(0.1f, new Vector3(0f, 0f, -90f));
			smartMotion2.AddKeyframe(1.5f, new Vector3(0f, 0f, -90f));
			smartMotion2.AddKeyframe(2f, new Vector3(0f, 0f, 0f));
			Vector3 one = Vector3.one;
			smartMotion2.StartMotion(EmptyDone, one);
			currentMotions.Add(smartMotion2);
		}
	}

	private void EmptyDone()
	{
	}

	private void PlantedTurnDone()
	{
		PlantedTurnDone(forceDone: false);
	}

	private void PlantedTurnDone(bool forceDone)
	{
		CleanupPlantedTurn(forceDone);
	}

	private void CleanupPlantedTurn(bool forceDone = false)
	{
		if (turnstyle == null)
		{
			return;
		}
		for (int i = 0; i < turnstyleJoints.Count; i++)
		{
			if (turnstyleJoints[i] != null)
			{
				Object.Destroy(turnstyleJoints[i]);
				turnstyleJoints[i] = null;
			}
		}
		turnstyleJoints.Clear();
		for (int j = 0; j < plantedLegs.Count; j++)
		{
			plantedLegs[j].UnplantLeg();
		}
		plantedLegs.Clear();
		Object.Destroy(turnstyle);
		turnstyle = null;
		StopMotions();
		if (!forceDone)
		{
			StartTurn();
		}
		else
		{
			StopTurn(forceDone);
		}
	}

	private void CheckPlants()
	{
		if (!waitingForPlants)
		{
			return;
		}
		currentWaitTime += Time.deltaTime;
		for (int i = 0; i < plantedLegs.Count; i++)
		{
			if (!plantedLegs[i].IsLegPlanted())
			{
				if (currentWaitTime >= plantWaitTime)
				{
					RequestStop(forceDone: false);
				}
				return;
			}
		}
		waitingForPlants = false;
		StrapFeetToPlank();
	}

	private void StrapFeetToPlank()
	{
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < plantedLegs.Count; i++)
		{
			list.Add(controllerRef.GetFootForLeg(plantedLegs[i].gameObject));
		}
		turnstyle.transform.position = ObjectUtil.GetCentroid(list);
		Rigidbody rigidbody = turnstyle.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		turnstyleJoint = turnstyle.AddComponent<ConfigurableJoint>();
		turnstyleJoint.xMotion = ConfigurableJointMotion.Locked;
		turnstyleJoint.yMotion = ConfigurableJointMotion.Locked;
		turnstyleJoint.zMotion = ConfigurableJointMotion.Locked;
		turnstyleJoint.angularXMotion = ConfigurableJointMotion.Locked;
		turnstyleJoint.angularZMotion = ConfigurableJointMotion.Locked;
		JointDrive angularYZDrive = turnstyleJoint.angularYZDrive;
		angularYZDrive.positionSpring = 10000f;
		turnstyleJoint.angularYZDrive = angularYZDrive;
		for (int j = 0; j < list.Count; j++)
		{
			FixedJoint fixedJoint = list[j].AddComponent<FixedJoint>();
			fixedJoint.connectedBody = rigidbody;
			fixedJoint.breakForce = 50000f;
			fixedJoint.breakTorque = 50000f;
			turnstyleJoints.Add(fixedJoint);
		}
		PlantedTurnMotion(backLegsPlanted);
	}

	private void RotateTurnstyle()
	{
		CheckPlants();
		if (waitingForPlants)
		{
			return;
		}
		bool flag = true;
		for (int i = 0; i < turnstyleJoints.Count; i++)
		{
			if (turnstyleJoints[i] != null)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			CleanupPlantedTurn();
			StartTurn();
			return;
		}
		Vector3 eulerAngles = turnstyleJoint.targetRotation.eulerAngles;
		if (targetTurnstyleY > 0f)
		{
			if (!(eulerAngles.y >= targetTurnstyleY))
			{
				float y = Mathf.Min(eulerAngles.y + Time.deltaTime * turnstyleSpeed, targetTurnstyleY);
				turnstyleJoint.targetRotation = Quaternion.Euler(0f, y, 0f);
			}
			return;
		}
		float num;
		for (num = eulerAngles.y; num > 0f; num -= 360f)
		{
		}
		if (!(num <= targetTurnstyleY))
		{
			float y = Mathf.Max(num - Time.deltaTime * turnstyleSpeed, targetTurnstyleY);
			turnstyleJoint.targetRotation = Quaternion.Euler(0f, y, 0f);
		}
	}

	public void RequestTurn(Transform targetToFace, TurnFinishedCallback callback = null)
	{
		if (!isTurning)
		{
			this.targetToFace = targetToFace;
			float yFacingAngle = AngleUtil.GetYFacingAngle(aiRef.GetBestPosForTarget(targetToFace.gameObject), bodyFront.transform);
			RequestTurn(yFacingAngle, callback);
		}
	}

	public void RequestTurn(float targetAngle, TurnFinishedCallback callback = null)
	{
		if (!isTurning)
		{
			currentTurnCount = 0;
			turnTargetAngle = targetAngle;
			currentCallback = callback;
			StartTurn();
		}
	}

	public void RequestStop(bool forceDone)
	{
		StopTurn(forceDone);
	}

	public bool ShouldBeDoingPlantedTurn(Transform facingTarget)
	{
		if (facingTarget == null)
		{
			return false;
		}
		Vector3 bestPosForTarget = aiRef.GetBestPosForTarget(facingTarget.gameObject);
		float yFacingAngle = AngleUtil.GetYFacingAngle(bestPosForTarget, bodyFront.transform);
		Vector3 eulerAngles = bodyFront.transform.eulerAngles;
		float num = Vector3.Distance(bestPosForTarget, controllerRef.mouth.transform.position);
		return Mathf.Abs(AngleUtil.GetAngleDiff(yFacingAngle, eulerAngles.y)) / num > plantedTurnRatio * 1.25f;
	}

	private void StartTurn()
	{
		StopMotions();
		if (currentTurnCount > turnMax || beingDestroyed)
		{
			StopTurn();
			return;
		}
		if (grabberRef.GetGrabbedObject() == base.gameObject)
		{
			StopTurn();
			return;
		}
		Vector3 vector = Vector3.zero;
		if (targetToFace != null)
		{
			vector = aiRef.GetBestPosForTarget(targetToFace.gameObject);
			turnTargetAngle = AngleUtil.GetYFacingAngle(vector, bodyFront.transform);
		}
		Vector3 eulerAngles = bodyFront.transform.eulerAngles;
		float num = Mathf.Abs(AngleUtil.GetAngleDiff(turnTargetAngle, eulerAngles.y));
		float num2 = Vector3.Distance(vector, controllerRef.mouth.transform.position);
		float num3 = num / num2;
		if (num <= facingDeadzone)
		{
			StopTurn();
		}
		else if (num3 > plantedTurnRatio)
		{
			RequestPlantedTurn(0f - AngleUtil.AngleSubtract(turnTargetAngle, eulerAngles.y));
		}
		else
		{
			LargeTurn();
		}
		isTurning = true;
		currentTurnCount++;
	}

	private void LargeTurn()
	{
		controllerRef.ClearRestoreMod();
		controllerRef.SetRestoreMod(new Vector3(1f, 0f, 1f));
		SmartMotion smartMotion = bodyFront.AddComponent<SmartMotion>();
		SmartMotion smartMotion2 = bodyBack.AddComponent<SmartMotion>();
		smartMotion2.SetController(controllerRef);
		smartMotion.SetController(controllerRef);
		smartMotion2.setIsMovingLimb(limbVal: false);
		smartMotion.setIsMovingLimb(limbVal: false);
		Vector3 eulerAngles = bodyFront.transform.eulerAngles;
		smartMotion.AddKeyframe(1f, new Vector3(eulerAngles.x, turnTargetAngle, eulerAngles.z), considerX: true, considerY: true, considerZ: true, numRequiredGroundedLegs);
		smartMotion.AddKeyframe(1f, new Vector3(eulerAngles.x, turnTargetAngle, eulerAngles.z), considerX: true, considerY: true, considerZ: true, numRequiredGroundedLegs);
		smartMotion.AddKeyframe(0.5f, new Vector3(eulerAngles.x, turnTargetAngle, eulerAngles.z), considerX: true, considerY: true, considerZ: true, numRequiredGroundedLegs);
		Vector3 eulerAngles2 = bodyBack.transform.eulerAngles;
		smartMotion2.AddKeyframe(0.5f, new Vector3(eulerAngles2.x, turnTargetAngle, eulerAngles2.z), considerX: true, considerY: true, considerZ: true, numRequiredGroundedLegs);
		smartMotion2.AddKeyframe(1.5f, new Vector3(eulerAngles2.x, turnTargetAngle, eulerAngles2.z), considerX: true, considerY: true, considerZ: true, numRequiredGroundedLegs);
		smartMotion2.AddKeyframe(0.5f, new Vector3(eulerAngles2.x, turnTargetAngle, eulerAngles2.z), considerX: true, considerY: true, considerZ: true, numRequiredGroundedLegs);
		Vector3 one = Vector3.one;
		smartMotion2.StartMotion(one);
		smartMotion.StartMotion(StartTurn, one);
		currentMotions.Add(smartMotion2);
		currentMotions.Add(smartMotion);
	}

	private void StopMotions()
	{
		for (int i = 0; i < currentMotions.Count; i++)
		{
			currentMotions[i].StopMotion();
		}
		currentMotions.Clear();
		PlantedTurnDone(forceDone: true);
	}

	private void StopTurn(bool forceDone = false)
	{
		isTurning = false;
		controllerRef.ClearRestoreMod();
		targetToFace = null;
		waitingForPlants = false;
		if (turnstyle != null)
		{
			CleanupPlantedTurn(forceDone);
		}
		if (currentCallback != null)
		{
			currentCallback();
			currentCallback = null;
		}
	}
}
