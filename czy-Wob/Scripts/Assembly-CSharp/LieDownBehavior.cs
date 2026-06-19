using System.Collections.Generic;
using UnityEngine;

public class LieDownBehavior : MonoBehaviour
{
	public delegate void SleepFinishedCallback();

	private SleepFinishedCallback currentCallback;

	private float knockoverTorque = 125f;

	private float knockoverTorqueTime = 0.75f;

	private float currentKnockoverTime;

	private Dictionary<GameObject, int> strengthModKeys = new Dictionary<GameObject, int>();

	private List<Rigidbody> rbCache = new List<Rigidbody>();

	private float currentBodyTime;

	private AnimationCurveWrapper bodyCurveY;

	private LegController controllerRef;

	private bool isLyingDown;

	private void Awake()
	{
		controllerRef = base.gameObject.GetComponent<LegController>();
		Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody item in componentsInChildren)
		{
			rbCache.Add(item);
		}
		CreateCurves();
	}

	private void FixedUpdate()
	{
		if (isLyingDown)
		{
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

	private void CreateCurves()
	{
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.AddKey(0f, 0f);
		animationCurve.AddKey(5f, 150f);
		animationCurve.AddKey(10f, 0f);
		animationCurve.AddKey(14f, 0f);
		bodyCurveY = new AnimationCurveWrapper(animationCurve);
		bodyCurveY.SetPostWrapMode(WrapMode.Loop);
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
	}

	public void RequestLieDown(SleepFinishedCallback callback = null)
	{
		if (isLyingDown)
		{
			Debug.LogError("Attempting to lie down but we're already doing so.");
			return;
		}
		LieDown();
		currentCallback = callback;
	}

	public void RequestStandUp()
	{
		if (isLyingDown)
		{
			StandUp();
		}
	}

	private void LieDown()
	{
		currentBodyTime = 0f;
		isLyingDown = true;
		currentKnockoverTime = 0f;
		controllerRef.FreezeMotion();
		controllerRef.LockStabilitySteps();
		foreach (GameObject allLeg in controllerRef.GetAllLegs())
		{
			strengthModKeys[allLeg] = allLeg.GetComponent<Limb>().RequestSleep();
		}
		GetComponent<BodyBuck>().LockBucks();
	}

	private void StandUp()
	{
		isLyingDown = false;
		controllerRef.UnfreezeMotion();
		controllerRef.UnlockStabilitySteps();
		foreach (GameObject allLeg in controllerRef.GetAllLegs())
		{
			allLeg.GetComponent<Limb>().RequestWakeUp(strengthModKeys[allLeg]);
		}
		strengthModKeys.Clear();
		GetComponent<BodyBuck>().UnlockBucks();
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
