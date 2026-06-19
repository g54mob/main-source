using System.Collections.Generic;
using UnityEngine;

public class BarkBehavior : MonoBehaviour
{
	private float currentBodyTime;

	private AnimationCurveWrapper bodyCurveZ;

	private List<GameObject> nearbyDogs = new List<GameObject>();

	private float wakeupChance = 0.01f;

	private bool isBarking;

	private bool rapidBarks;

	private float barkTimerCurrent;

	private float barkTimerMin;

	private float barkTimerMax = 1f;

	private float barkTimerMaxRapid = 0.2f;

	private DogNoises dogNoisesRef;

	private LegController controllerRef;

	private MouthController mouthControllerRef;

	private DogRegistration dogRegRef;

	private void Awake()
	{
		dogNoisesRef = GetComponent<DogNoises>();
		controllerRef = GetComponent<LegController>();
		mouthControllerRef = GetComponent<MouthController>();
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		CreateCurves();
	}

	private void FixedUpdate()
	{
		if (isBarking)
		{
			FollowCurve();
		}
	}

	private void Update()
	{
		CheckDogInterruption();
	}

	private void CheckDogInterruption()
	{
		for (int i = 0; i < nearbyDogs.Count; i++)
		{
			if (Random.value <= wakeupChance && !(nearbyDogs[i] == null))
			{
				DogBehaviorBase currentBehavior = nearbyDogs[i].GetComponent<DogAI>().GetCurrentBehavior();
				if (currentBehavior != null)
				{
					currentBehavior.HandleLoudNoise(base.gameObject);
				}
			}
		}
	}

	private void CreateCurves()
	{
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.AddKey(0f, 0f);
		animationCurve.AddKey(0.25f, -500f);
		animationCurve.AddKey(0.5f, 0f);
		animationCurve.postWrapMode = WrapMode.Loop;
		bodyCurveZ = new AnimationCurveWrapper(animationCurve);
	}

	private void FollowCurve()
	{
		Vector3 torque = new Vector3(0f, 0f, CurveUtil.EvaluateAverageCurveWrapperTime(bodyCurveZ, currentBodyTime, currentBodyTime - Time.fixedDeltaTime));
		controllerRef.TorqueBody(controllerRef.bodyFront, torque);
		currentBodyTime += Time.fixedDeltaTime;
		barkTimerCurrent -= Time.fixedDeltaTime;
		if (barkTimerCurrent <= 0f)
		{
			dogNoisesRef.RequestBark();
			float max = barkTimerMax;
			if (rapidBarks)
			{
				max = barkTimerMaxRapid;
			}
			barkTimerCurrent = Random.Range(barkTimerMin, max);
		}
	}

	public void RequestBark(bool rapid = false)
	{
		if (isBarking)
		{
			Debug.LogError("Attempting to bark but we're already barking.");
			return;
		}
		rapidBarks = rapid;
		StartBarking();
	}

	public void RequestStopBarking()
	{
		if (isBarking)
		{
			StopBarking();
		}
	}

	private void StartBarking()
	{
		barkTimerCurrent = 0f;
		mouthControllerRef.DropObject();
		currentBodyTime = 0f;
		isBarking = true;
		dogRegRef.GetNearbyDogList(base.gameObject, ref nearbyDogs);
		List<GameObject> legsForBodySegment = controllerRef.GetLegsForBodySegment(controllerRef.bodyBack);
		for (int i = 0; i < legsForBodySegment.Count; i++)
		{
			legsForBodySegment[i].GetComponent<Limb>().PlantLeg();
		}
	}

	private void StopBarking()
	{
		isBarking = false;
		nearbyDogs.Clear();
		List<GameObject> legsForBodySegment = controllerRef.GetLegsForBodySegment(controllerRef.bodyBack);
		for (int i = 0; i < legsForBodySegment.Count; i++)
		{
			legsForBodySegment[i].GetComponent<Limb>().UnplantLeg();
		}
	}
}
