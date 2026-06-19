using System.Collections.Generic;
using UnityEngine;

public class SitBehavior : MonoBehaviour
{
	public delegate void SitFinishedCallback();

	private SitFinishedCallback currentCallback;

	private Vector3 sitRestoreMod = new Vector3(1f, 1f, 0f);

	private Vector3 targetBackLegRot = new Vector3(0f, 0f, 320f);

	private Vector3 targetBodyBackRot = new Vector3(0f, 0f, 45f);

	private Vector3 targetBodyFrontRot = new Vector3(0f, 0f, 320f);

	private Vector3 motionMultiplier = new Vector3(1f, 1f, 1f);

	private float waitTime = 0.25f;

	private float legRotTime = 0.5f;

	private float legRotTime2 = 0.1f;

	private float bodyRotTime = 0.5f;

	private Rigidbody bodyBackRB;

	private Rigidbody bodyFrontRB;

	private Vector3 bodyBackForce = new Vector3(1000f, 0f, 0f);

	private Vector3 bodyFrontForce = new Vector3(500f, 0f, 0f);

	private List<GameObject> frontLegs = new List<GameObject>();

	private bool bounce;

	private float bounceChance = 0.2f;

	private float bounceForce = 100f;

	private bool kick;

	private float kickChance = 0.5f;

	private float kickChancePerFrame = 0.0015f;

	private float kickTorque = -350f;

	private float kickingTimerLow = 0.1f;

	private float kickingTimerHigh = 0.3f;

	private List<float> kickingLegsTimers = new List<float>();

	private List<GameObject> kickingLegs = new List<GameObject>();

	private bool isSitting;

	private DogAI aiRef;

	private DoggyBrain brainRef;

	private FaceController faceRef;

	private LegController controllerRef;

	private WalkController walkControllerRef;

	private void Awake()
	{
		aiRef = base.gameObject.GetComponent<DogAI>();
		brainRef = base.gameObject.GetComponent<DoggyBrain>();
		faceRef = base.gameObject.GetComponent<FaceController>();
		controllerRef = base.gameObject.GetComponent<LegController>();
		walkControllerRef = base.gameObject.GetComponent<WalkController>();
		bodyBackRB = controllerRef.bodyBack.GetComponent<Rigidbody>();
		bodyFrontRB = controllerRef.bodyFront.GetComponent<Rigidbody>();
		frontLegs.AddRange(controllerRef.GetLegsForBodySegment(bodyFrontRB.gameObject));
	}

	private void FixedUpdate()
	{
		if (isSitting)
		{
			PushBackward();
			LookAlive();
		}
	}

	private void Update()
	{
		if (isSitting && !aiRef.IsValidRotationForSit())
		{
			aiRef.ForceInterruptBehavior();
		}
	}

	public bool IsSitting()
	{
		return isSitting;
	}

	public void RequestSit(SitFinishedCallback callback = null)
	{
		if (isSitting)
		{
			Debug.LogError("Attempting to sit but we're already doing so.");
			return;
		}
		currentCallback = callback;
		Sit();
	}

	public void RequestStandUp()
	{
		if (isSitting)
		{
			FinishSit();
		}
	}

	private void Sit()
	{
		isSitting = true;
		List<SmartMotion> list = new List<SmartMotion>();
		SmartMotion smartMotion = controllerRef.bodyBack.AddComponent<SmartMotion>();
		smartMotion.SetController(controllerRef);
		smartMotion.setIsMovingLimb(limbVal: false);
		smartMotion.AddKeyframe(bodyRotTime, targetBodyBackRot);
		smartMotion.AddKeyframe(bodyRotTime, targetBodyBackRot);
		smartMotion.AddKeyframe(bodyRotTime, targetBodyBackRot);
		list.Add(smartMotion);
		SmartMotion smartMotion2 = controllerRef.bodyFront.AddComponent<SmartMotion>();
		smartMotion2.SetController(controllerRef);
		smartMotion2.setIsMovingLimb(limbVal: false);
		smartMotion2.AddKeyframe(bodyRotTime, targetBodyFrontRot);
		smartMotion2.AddKeyframe(bodyRotTime, targetBodyFrontRot);
		smartMotion2.AddKeyframe(bodyRotTime, targetBodyFrontRot);
		smartMotion2.AddKeyframe(bodyRotTime, targetBodyFrontRot);
		smartMotion2.AddKeyframe(bodyRotTime, targetBodyFrontRot);
		smartMotion2.AddKeyframe(bodyRotTime, targetBodyFrontRot);
		list.Add(smartMotion2);
		List<GameObject> legsForBodySegment = controllerRef.GetLegsForBodySegment(controllerRef.bodyBack);
		for (int i = 0; i < legsForBodySegment.Count; i++)
		{
			SmartMotion smartMotion3 = legsForBodySegment[i].AddComponent<SmartMotion>();
			smartMotion3.SetController(controllerRef);
			smartMotion3.setIsMovingLimb(limbVal: true);
			smartMotion3.AddKeyframe(waitTime, Vector3.zero, considerX: false, considerY: false, considerZ: false);
			smartMotion3.AddKeyframe(legRotTime, targetBackLegRot / (i + 1));
			smartMotion3.AddKeyframe(legRotTime2, targetBackLegRot / (i + 1));
			smartMotion3.AddKeyframe(legRotTime, targetBackLegRot / (i + 1));
			smartMotion3.AddKeyframe(legRotTime2, targetBackLegRot / (i + 1));
			smartMotion3.AddKeyframe(legRotTime, targetBackLegRot / (i + 1));
			smartMotion3.AddKeyframe(legRotTime2, targetBackLegRot / (i + 1));
			list.Add(smartMotion3);
		}
		for (int j = 0; j < list.Count; j++)
		{
			list[j].StartMotion(motionMultiplier);
		}
		StartSit();
	}

	private void StartSit()
	{
		isSitting = true;
		walkControllerRef.IgnoreFacing();
		controllerRef.SetZStepsLocked(val: true);
		GetComponent<BodyBuck>().LockBucks();
		controllerRef.SetRestoreMod(sitRestoreMod);
		controllerRef.LoosenAbs(LooseAbsLock.SITTING);
		List<GameObject> allLegs = controllerRef.GetAllLegs();
		for (int i = 0; i < allLegs.Count; i++)
		{
			allLegs[i].GetComponent<Stabilizer>().PauseFootTorque();
		}
		if (currentCallback != null)
		{
			currentCallback();
			currentCallback = null;
		}
		if (Random.value <= bounceChance)
		{
			bounce = true;
		}
		if (Random.value <= kickChance)
		{
			kick = true;
		}
	}

	private void FinishSit()
	{
		List<GameObject> allLegs = controllerRef.GetAllLegs();
		for (int i = 0; i < allLegs.Count; i++)
		{
			allLegs[i].GetComponent<Stabilizer>().UnpauseFootTorque();
		}
		kick = false;
		bounce = false;
		kickingLegs.Clear();
		kickingLegsTimers.Clear();
		isSitting = false;
		faceRef.StopFocus();
		controllerRef.ClearRestoreMod();
		walkControllerRef.RestoreFacing();
		controllerRef.SetZStepsLocked(val: false);
		GetComponent<BodyBuck>().UnlockBucks();
		controllerRef.TightenAbs(LooseAbsLock.SITTING);
	}

	private void PushBackward()
	{
		bodyBackRB.AddRelativeForce(bodyBackForce);
		bodyFrontRB.AddRelativeForce(bodyFrontForce);
	}

	private void LookAlive()
	{
		if (brainRef.IsSleeping())
		{
			return;
		}
		if (bounce)
		{
			bodyFrontRB.AddRelativeTorque(Random.Range(0f - bounceForce, bounceForce), Random.Range(0f - bounceForce, bounceForce), Random.Range(0f - bounceForce, bounceForce));
		}
		if (!kick)
		{
			return;
		}
		for (int i = 0; i < frontLegs.Count; i++)
		{
			if (!(Random.value > kickChancePerFrame) && !kickingLegs.Contains(frontLegs[i]))
			{
				kickingLegs.Add(frontLegs[i]);
				kickingLegsTimers.Add(Random.Range(kickingTimerLow, kickingTimerHigh));
			}
		}
		for (int num = kickingLegs.Count - 1; num >= 0; num--)
		{
			controllerRef.TorqueLeg(kickingLegs[num], kickTorque * kickingLegs[num].transform.forward, applyLimbCompensation: true, modifyLegStrength: true, restoreTension: true, rawTorque: true);
			kickingLegsTimers[num] -= Time.fixedDeltaTime;
			if (kickingLegsTimers[num] <= 0f)
			{
				kickingLegs.RemoveAt(num);
				kickingLegsTimers.RemoveAt(num);
			}
		}
	}
}
