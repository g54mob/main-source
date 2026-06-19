using System.Collections.Generic;
using UnityEngine;

public class DeathKnellBehavior : MonoBehaviour
{
	private bool isKnelling;

	private float knockoverTorque = 125f;

	private float knockoverTorqueTime = 0.75f;

	private float currentTime;

	private float witnessTime = 3f;

	private bool hasRegisteredWitnesses;

	private bool startedNoise;

	private Dictionary<GameObject, int> strengthModKeys = new Dictionary<GameObject, int>();

	private LegController controllerRef;

	private MouthController mouthControllerRef;

	private DogRegistration dogRegRef;

	private void Awake()
	{
		controllerRef = GetComponent<LegController>();
		mouthControllerRef = GetComponent<MouthController>();
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	private void FixedUpdate()
	{
		if (isKnelling)
		{
			currentTime += Time.fixedDeltaTime;
			if (currentTime < knockoverTorqueTime)
			{
				Knockover();
			}
			else if (!startedNoise)
			{
				startedNoise = true;
				GetComponent<HowlBehavior>().RequestHowl();
			}
			if (!hasRegisteredWitnesses && currentTime > witnessTime)
			{
				RegisterWitnesses();
			}
		}
	}

	public void RequestDeathKnell()
	{
		if (isKnelling)
		{
			Debug.LogError("Attempting to let out a death knell but we're already doing so.");
		}
		else
		{
			StartDeathKnell();
		}
	}

	public void RequestStopDeathKnell(bool natural)
	{
		if (isKnelling)
		{
			StopDeathKnell(natural);
		}
	}

	private void StartDeathKnell()
	{
		mouthControllerRef.DropObject();
		controllerRef.FreezeMotion();
		controllerRef.LockStabilitySteps();
		foreach (GameObject allLeg in controllerRef.GetAllLegs())
		{
			strengthModKeys[allLeg] = allLeg.GetComponent<Limb>().RequestSleep();
		}
		GetComponent<BodyBuck>().LockBucks();
		GetComponent<DogAI>().LockDistractions();
		GetComponent<DoggyBrain>().LockEmotionParticles();
		GetComponent<WalkController>().RemoveFacingTarget();
		isKnelling = true;
		hasRegisteredWitnesses = false;
	}

	private void StopDeathKnell(bool natural)
	{
		isKnelling = false;
		if (natural && GameSettings.IsDogDeathEnabled())
		{
			return;
		}
		controllerRef.UnfreezeMotion();
		controllerRef.UnlockStabilitySteps();
		foreach (GameObject allLeg in controllerRef.GetAllLegs())
		{
			allLeg.GetComponent<Limb>().RequestWakeUp(strengthModKeys[allLeg]);
		}
		strengthModKeys.Clear();
		GetComponent<BodyBuck>().UnlockBucks();
		GetComponent<DogAI>().UnlockDistractions();
		GetComponent<DoggyBrain>().UnlockEmotionParticles();
	}

	private void Knockover()
	{
		Vector3 finalTorque = new Vector3(knockoverTorque, 0f, 0f);
		controllerRef.AddCalculatedTorque(controllerRef.bodyBack.GetComponent<Rigidbody>(), finalTorque);
		controllerRef.AddCalculatedTorque(controllerRef.bodyFront.GetComponent<Rigidbody>(), finalTorque);
	}

	private void RegisterWitnesses()
	{
		hasRegisteredWitnesses = true;
		ulong iDFromDog = dogRegRef.GetIDFromDog(base.gameObject);
		DoggyBrain component = GetComponent<DoggyBrain>();
		List<GameObject> allDogs = dogRegRef.GetAllDogs();
		for (int i = 0; i < allDogs.Count; i++)
		{
			if (dogRegRef.GetIDFromDog(allDogs[i]) != iDFromDog)
			{
				DogAI component2 = allDogs[i].GetComponent<DogAI>();
				DistractionWitnessDeath newDistraction = new DistractionWitnessDeath(component2, 10f, component);
				component2.TryAddNewDistraction(newDistraction, useTimeSinceLastDistraction: false);
			}
		}
	}
}
