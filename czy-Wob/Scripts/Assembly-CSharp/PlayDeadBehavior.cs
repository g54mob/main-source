using System.Collections.Generic;
using UnityEngine;

public class PlayDeadBehavior : MonoBehaviour
{
	private bool isPlayingDead;

	private float knockoverTorque = 175f;

	private float knockoverTorqueTime = 0.75f;

	private float currentTime;

	private Dictionary<GameObject, int> strengthModKeys = new Dictionary<GameObject, int>();

	private FaceController faceRef;

	private LegController controllerRef;

	private DogParticleController particleRef;

	private void Awake()
	{
		faceRef = GetComponent<FaceController>();
		controllerRef = GetComponent<LegController>();
		particleRef = GetComponent<DogParticleController>();
	}

	private void FixedUpdate()
	{
		if (isPlayingDead)
		{
			currentTime += Time.fixedDeltaTime;
			if (currentTime < knockoverTorqueTime)
			{
				Knockover();
			}
		}
	}

	public void RequestPlayDead()
	{
		if (isPlayingDead)
		{
			Debug.LogError("Attempting to play dead but we're already doing so.");
		}
		else
		{
			StartPlayingDead();
		}
	}

	public void RequestStopPlayingDead()
	{
		if (isPlayingDead)
		{
			StopPlayingDead();
		}
	}

	private void StartPlayingDead()
	{
		faceRef.RequestFace(Face.DEAD);
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
		isPlayingDead = true;
	}

	private void StopPlayingDead()
	{
		isPlayingDead = false;
		faceRef.RequestFace(Face.DEFAULT);
		particleRef.RequestSurpriseParticlesStart(lockAI: true, immediate: true);
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
}
