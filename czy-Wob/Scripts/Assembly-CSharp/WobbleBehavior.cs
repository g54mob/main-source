using System.Collections.Generic;
using UnityEngine;

public class WobbleBehavior : MonoBehaviour
{
	public delegate void WobbleFinishedCallback();

	private WobbleFinishedCallback currentCallback;

	private GameObject bodyBack;

	private GameObject bodyFront;

	private AnimationCurveWrapper buckCurveBackZ;

	private AnimationCurveWrapper buckCurveFrontZ;

	private List<GameObject> allLegs = new List<GameObject>();

	private bool isWobbling;

	private float wobbleAnimationTimerX;

	private float wobbleAnimationTimerZ;

	private float wobbleMultiplier = 4000f;

	private bool ruckusWobble;

	private LegController controllerRef;

	private void Awake()
	{
		controllerRef = base.gameObject.GetComponent<LegController>();
		bodyBack = controllerRef.bodyBack;
		bodyFront = controllerRef.bodyFront;
		allLegs.AddRange(controllerRef.GetAllLegs());
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.postWrapMode = WrapMode.Loop;
		animationCurve.AddKey(0f, 0f);
		animationCurve.AddKey(0.25f, 650f);
		animationCurve.AddKey(0.5f, -1600f);
		animationCurve.AddKey(0.75f, 0f);
		animationCurve.AddKey(1.25f, 0f);
		AnimationCurve animationCurve2 = new AnimationCurve();
		animationCurve2.postWrapMode = WrapMode.Loop;
		animationCurve2.AddKey(0f, 0f);
		animationCurve2.AddKey(0.5f, -500f);
		animationCurve2.AddKey(0.75f, 800f);
		animationCurve2.AddKey(1f, -500f);
		buckCurveFrontZ = new AnimationCurveWrapper(animationCurve);
		buckCurveBackZ = new AnimationCurveWrapper(animationCurve2);
	}

	private void FixedUpdate()
	{
		if (isWobbling)
		{
			UpdateWobble();
		}
	}

	private void UpdateWobble()
	{
		for (int i = 0; i < allLegs.Count; i++)
		{
			allLegs[i].GetComponent<Limb>().PlantLeg();
		}
		wobbleAnimationTimerX += Time.fixedDeltaTime * 4f;
		wobbleAnimationTimerZ += Time.fixedDeltaTime * 16f;
		float x = Mathf.Sin(wobbleAnimationTimerX) / 10f;
		float num = Mathf.Sin(wobbleAnimationTimerZ);
		if (ruckusWobble)
		{
			x = 0f;
		}
		else
		{
			num /= 10f;
		}
		wobbleAnimationTimerX += Time.fixedDeltaTime;
		Vector3 vector = new Vector3(x, 0f, 0f);
		Vector3 vector2 = new Vector3(x, 0f, num);
		float x2 = base.transform.localScale.x;
		controllerRef.TorqueBody(bodyBack, vector * x2 * wobbleMultiplier, applyLimbCompensation: true, modifyLegStrength: true, useTorqueDamping: false);
		controllerRef.TorqueBody(bodyFront, vector2 * x2 * wobbleMultiplier, applyLimbCompensation: true, modifyLegStrength: true, useTorqueDamping: false);
	}

	public bool IsWobbling()
	{
		return isWobbling;
	}

	public void RequestWobble(bool ruckus = false, WobbleFinishedCallback callback = null)
	{
		if (isWobbling)
		{
			Debug.LogError("Attempting to wobble but we're already doing so.");
			return;
		}
		ruckusWobble = ruckus;
		if (allLegs.Count == 0)
		{
			GetComponent<DogAI>().ForceInterruptBehavior();
			return;
		}
		currentCallback = callback;
		StartWobble();
	}

	public void RequestWobbleStop()
	{
		if (isWobbling)
		{
			FinishWobble();
		}
	}

	private void StartWobble()
	{
		isWobbling = true;
		wobbleAnimationTimerX = 0f;
		wobbleAnimationTimerZ = 0f;
		GetComponent<BodyBuck>().LockBucks();
		List<GameObject> list = controllerRef.GetAllLegs();
		for (int i = 0; i < list.Count; i++)
		{
			list[i].GetComponent<Limb>().PlantLeg();
		}
		if (currentCallback != null)
		{
			currentCallback();
			currentCallback = null;
		}
	}

	private void FinishWobble()
	{
		for (int i = 0; i < allLegs.Count; i++)
		{
			allLegs[i].GetComponent<Limb>().UnplantLeg();
		}
		isWobbling = false;
		GetComponent<BodyBuck>().UnlockBucks();
	}
}
