using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollOverBehavior : MonoBehaviour
{
	public delegate void RollFinishedCallback();

	private float knockoverTorque = 125f;

	private float knockoverTorqueTime = 0.75f;

	private float flipOverTorque = 1250f;

	private float flipOverTime = 3f;

	private Coroutine currentRollOverRoutine;

	private Dictionary<GameObject, int> strengthModKeys = new Dictionary<GameObject, int>();

	private Rigidbody bodyFrontRB;

	private Rigidbody bodyBackRB;

	private DogAI aiRef;

	private DogState stateRef;

	private LegController controllerRef;

	private void Awake()
	{
		aiRef = GetComponent<DogAI>();
		stateRef = GetComponent<DogState>();
		controllerRef = GetComponent<LegController>();
		bodyBackRB = controllerRef.bodyBack.GetComponent<Rigidbody>();
		bodyFrontRB = controllerRef.bodyFront.GetComponent<Rigidbody>();
	}

	public void RequestRollOver(RollFinishedCallback callback = null)
	{
		if (currentRollOverRoutine != null)
		{
			Debug.LogError("Attempting to roll over but we're already doing that.");
		}
		else
		{
			currentRollOverRoutine = StartCoroutine(RollOverRoutine(callback));
		}
	}

	public void RequestStandUp()
	{
		StandUp();
		if (currentRollOverRoutine != null)
		{
			StopCoroutine(currentRollOverRoutine);
			currentRollOverRoutine = null;
		}
	}

	private IEnumerator RollOverRoutine(RollFinishedCallback callback)
	{
		bool rollRight = true;
		float zMult = 3f;
		float barkChanceOnFailure = 0.25f;
		if (stateRef.RightSideBlocked(zMult))
		{
			rollRight = false;
			if (stateRef.LeftSideBlocked(zMult))
			{
				if (Random.value < barkChanceOnFailure)
				{
					GetComponent<DogNoises>().RequestBark();
				}
				aiRef.ForceInterruptBehavior();
				yield break;
			}
		}
		WaitForFixedUpdate fixedWait = new WaitForFixedUpdate();
		float currentTime = 0f;
		_ = bodyFrontRB.rotation.eulerAngles;
		controllerRef.FreezeMotion();
		controllerRef.LockStabilitySteps();
		foreach (GameObject allLeg in controllerRef.GetAllLegs())
		{
			strengthModKeys[allLeg] = allLeg.GetComponent<Limb>().RequestSleep();
		}
		GetComponent<BodyBuck>().LockBucks();
		while (currentTime <= knockoverTorqueTime)
		{
			currentTime += Time.fixedDeltaTime;
			Vector3 torque = new Vector3(knockoverTorque, 0f, 0f);
			if (!rollRight)
			{
				torque *= -1f;
			}
			bodyBackRB.AddRelativeTorque(torque);
			bodyFrontRB.AddRelativeTorque(torque);
			yield return fixedWait;
		}
		foreach (GameObject allLeg2 in controllerRef.GetAllLegs())
		{
			allLeg2.GetComponent<RotationRestore>().SetTargetRotMod(new Vector3(180f, 0f, 0f));
		}
		float targetRotationWindow = 0.95f;
		currentTime = 0f;
		bool hasReachedTargetRotation = false;
		while (currentTime <= flipOverTime && !hasReachedTargetRotation)
		{
			currentTime += Time.fixedDeltaTime;
			Vector3 torque2 = new Vector3(flipOverTorque, 0f, 0f);
			if (!rollRight)
			{
				torque2 *= -1f;
			}
			bodyBackRB.AddRelativeTorque(torque2);
			bodyFrontRB.AddRelativeTorque(torque2);
			yield return fixedWait;
			if (!hasReachedTargetRotation && Vector3.Dot(bodyFrontRB.transform.up, Vector3.down) >= targetRotationWindow)
			{
				hasReachedTargetRotation = true;
			}
		}
		if (!hasReachedTargetRotation && Random.value < barkChanceOnFailure)
		{
			GetComponent<DogNoises>().RequestBark();
		}
		StandUp();
		callback?.Invoke();
		currentRollOverRoutine = null;
	}

	private void StandUp()
	{
		controllerRef.UnfreezeMotion();
		controllerRef.UnlockStabilitySteps();
		foreach (GameObject allLeg in controllerRef.GetAllLegs())
		{
			allLeg.GetComponent<RotationRestore>().ClearTargetRotMod();
			if (strengthModKeys.ContainsKey(allLeg))
			{
				allLeg.GetComponent<Limb>().RequestWakeUp(strengthModKeys[allLeg]);
			}
		}
		strengthModKeys.Clear();
		GetComponent<BodyBuck>().UnlockBucks();
	}
}
