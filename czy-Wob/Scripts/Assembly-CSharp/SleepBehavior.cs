using System.Collections.Generic;
using UnityEngine;

public class SleepBehavior : MonoBehaviour
{
	public delegate void SleepFinishedCallback();

	private SleepFinishedCallback currentCallback;

	private float knockoverTorque = 125f;

	private float knockoverTorqueTime = 0.75f;

	private float currentKnockoverTime;

	private int sleepParticlesKey;

	private Dictionary<GameObject, int> strengthModKeys = new Dictionary<GameObject, int>();

	private List<Rigidbody> rbCache = new List<Rigidbody>();

	private float currentBodyTime;

	private AnimationCurveWrapper bodyCurveY;

	private float currentLegTime;

	private AnimationCurveWrapper legCurveZ;

	private float legKickChance = 1f;

	private float specificLegKickChance = 0.25f;

	private float randomKickJitter = 10f;

	private bool isKicking;

	private List<GameObject> kickingLegs = new List<GameObject>();

	private float sleepStartVelocity = 0.5f;

	private float secondsBeforeSleepCancel = 6f;

	private float totalSeconds;

	private bool reachedMinSleepVel;

	private float sleepNoiseChance = 0.002f;

	private TimeSpan sleepStartTimespan;

	private bool isSleeping;

	private bool isCyclicSleeping;

	private DogNoises noisesRef;

	private FaceController faceRef;

	private LegController controllerRef;

	private DogParticleController particleRef;

	private GlobalClock globalClockRef;

	private void Awake()
	{
		noisesRef = GetComponent<DogNoises>();
		faceRef = GetComponent<FaceController>();
		controllerRef = GetComponent<LegController>();
		particleRef = GetComponent<DogParticleController>();
		globalClockRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GlobalClock>(GlobalObject.GLOBAL_CLOCK);
		Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody item in componentsInChildren)
		{
			rbCache.Add(item);
		}
		CreateCurves();
	}

	private void Update()
	{
		if (reachedMinSleepVel && isSleeping && !noisesRef.IsAnyVocalizationPlaying() && Random.value <= sleepNoiseChance)
		{
			noisesRef.RequestSnore();
		}
	}

	private void FixedUpdate()
	{
		if (isSleeping)
		{
			if (!isCyclicSleeping)
			{
				UpdateVelocityChecks();
			}
			if (currentKnockoverTime < knockoverTorqueTime)
			{
				Knockover();
			}
			else
			{
				FollowCurve();
			}
		}
	}

	public bool IsSleeping()
	{
		return isSleeping;
	}

	public bool IsCyclicSleeping()
	{
		return isCyclicSleeping;
	}

	private void UpdateVelocityChecks()
	{
		bool flag = true;
		for (int i = 0; i < rbCache.Count; i++)
		{
			float magnitude = rbCache[i].velocity.magnitude;
			if (!reachedMinSleepVel && magnitude > sleepStartVelocity)
			{
				flag = false;
			}
		}
		if (!reachedMinSleepVel && flag)
		{
			reachedMinSleepVel = true;
		}
		if (!reachedMinSleepVel)
		{
			totalSeconds += Time.fixedDeltaTime;
			if (totalSeconds >= secondsBeforeSleepCancel)
			{
				reachedMinSleepVel = true;
			}
		}
	}

	private void CreateCurves()
	{
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.AddKey(0f, 0f);
		animationCurve.AddKey(5f, 150f);
		animationCurve.AddKey(10f, 0f);
		animationCurve.AddKey(14f, 0f);
		bodyCurveY = new AnimationCurveWrapper(animationCurve);
		bodyCurveY.SetPostWrapMode(WrapMode.Loop);
		AnimationCurve animationCurve2 = new AnimationCurve();
		animationCurve2.AddKey(0f, 0f);
		animationCurve2.AddKey(0.5f, 50f);
		animationCurve2.AddKey(0.75f, -25f);
		animationCurve2.AddKey(1f, 0f);
		animationCurve2.AddKey(1.75f, 0f);
		legCurveZ = new AnimationCurveWrapper(animationCurve2);
	}

	private void FollowCurve()
	{
		Vector3 vector = CurveUtil.EvaluateAverageCurveWrapperTime(bodyCurveY, currentBodyTime, currentBodyTime - Time.fixedDeltaTime) * base.transform.up;
		if (controllerRef.bodyFront.transform.localEulerAngles.x > 180f)
		{
			vector *= -1f;
		}
		controllerRef.TorqueBody(controllerRef.bodyFront, vector, applyLimbCompensation: true, modifyLegStrength: true, useTorqueDamping: true, rawTorque: true);
		controllerRef.TorqueBody(controllerRef.bodyBack, -vector, applyLimbCompensation: true, modifyLegStrength: true, useTorqueDamping: true, rawTorque: true);
		currentBodyTime += Time.fixedDeltaTime;
		CheckKicks();
	}

	private void CheckKicks()
	{
		if (!isKicking)
		{
			if (!((float)Random.Range(0, 1500) <= legKickChance))
			{
				return;
			}
			isKicking = true;
			currentLegTime = 0f;
			kickingLegs.Clear();
			List<GameObject> allLegs = controllerRef.GetAllLegs();
			for (int i = 0; i < allLegs.Count; i++)
			{
				if ((float)Random.Range(0, 1) < specificLegKickChance)
				{
					kickingLegs.Add(allLegs[i]);
				}
			}
		}
		else
		{
			float num = currentLegTime;
			for (int j = 0; j < kickingLegs.Count; j++)
			{
				num = currentLegTime - (float)j / (float)controllerRef.GetLegCount();
				float num2 = CurveUtil.EvaluateAverageCurveWrapperTime(legCurveZ, num, num - Time.fixedDeltaTime);
				controllerRef.TorqueLeg(kickingLegs[j], num2 * Mathf.Min(Random.Range(0f, randomKickJitter) - 5f, 0f) * base.transform.forward, applyLimbCompensation: true, modifyLegStrength: true, restoreTension: true, rawTorque: true);
			}
			currentLegTime += Time.fixedDeltaTime;
			if (currentLegTime >= legCurveZ.GetTotalTime())
			{
				isKicking = false;
			}
		}
	}

	public void RequestCyclicSleep()
	{
		if (!isCyclicSleeping)
		{
			Sleep();
			isCyclicSleeping = true;
			reachedMinSleepVel = true;
		}
	}

	public void RequestSleep(SleepFinishedCallback callback = null)
	{
		if (isSleeping)
		{
			Debug.LogError("Attempting to sleep but we're already sleeping.");
			return;
		}
		Sleep();
		currentCallback = callback;
	}

	public void RequestWakeUp()
	{
		if (isSleeping && !isCyclicSleeping)
		{
			WakeUp();
		}
	}

	public void RequestCyclicWakeUp()
	{
		if (isCyclicSleeping)
		{
			WakeUp();
		}
	}

	private void Sleep()
	{
		sleepStartTimespan = globalClockRef.GetCurrentTimespan();
		currentLegTime = 0f;
		currentBodyTime = 0f;
		totalSeconds = 0f;
		reachedMinSleepVel = false;
		isSleeping = true;
		currentKnockoverTime = 0f;
		controllerRef.FreezeMotion();
		controllerRef.LockStabilitySteps();
		foreach (GameObject allLeg in controllerRef.GetAllLegs())
		{
			strengthModKeys[allLeg] = allLeg.GetComponent<Limb>().RequestSleep();
		}
		sleepParticlesKey = particleRef.RequestSleepParticlesStart();
		GetComponent<BodyBuck>().LockBucks();
		GetComponent<DogAI>().LockDistractions();
		GetComponent<DoggyBrain>().LockEmotionParticles();
		GetComponent<FaceController>().RemoveNeckTension();
		GetComponent<WalkController>().RemoveFacingTarget();
		faceRef.RequestFace(Face.SLEEP);
	}

	private void WakeUp()
	{
		if (noisesRef.IsAnyVocalizationPlaying())
		{
			noisesRef.StopCurrentVocalization();
			noisesRef.RequestGrunt();
		}
		int minutesUpdate = Mathf.RoundToInt((globalClockRef.GetCurrentTimespan() - sleepStartTimespan).GetTotalMinutes());
		DogFeatController.ReportSleepFeatProgress(GetComponent<ObjectID>().GetUID(), minutesUpdate);
		isSleeping = false;
		isCyclicSleeping = false;
		controllerRef.UnfreezeMotion();
		controllerRef.UnlockStabilitySteps();
		foreach (GameObject allLeg in controllerRef.GetAllLegs())
		{
			allLeg.GetComponent<Limb>().RequestWakeUp(strengthModKeys[allLeg]);
		}
		strengthModKeys.Clear();
		particleRef.RequestParticlesEnd(sleepParticlesKey);
		GetComponent<BodyBuck>().UnlockBucks();
		GetComponent<DogAI>().UnlockDistractions();
		GetComponent<FaceController>().RestoreNeckTension();
		GetComponent<DoggyBrain>().UnlockEmotionParticles();
		faceRef.RequestFace(Face.DEFAULT);
	}

	private void Knockover()
	{
		currentKnockoverTime += Time.fixedDeltaTime;
		Vector3 finalTorque = new Vector3(knockoverTorque, 0f, 0f);
		controllerRef.AddCalculatedTorque(controllerRef.bodyBack.GetComponent<Rigidbody>(), finalTorque);
		controllerRef.AddCalculatedTorque(controllerRef.bodyFront.GetComponent<Rigidbody>(), finalTorque);
		if (currentCallback != null && currentKnockoverTime >= knockoverTorqueTime)
		{
			currentCallback();
			currentCallback = null;
		}
	}
}
