using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehavior : MonoBehaviour
{
	public delegate void FlyFinishedCallback();

	private FlyFinishedCallback currentCallback;

	private float flyTimeLow = 5f;

	private float flyTimeHigh = 20f;

	private bool isFlying;

	private Coroutine flyRoutine;

	private float periodicForwardChance = 0.5f;

	private float constantForwardChance = 0.1f;

	private List<WingController> leftWingRefs = new List<WingController>();

	private List<WingController> rightWingRefs = new List<WingController>();

	private float flapUpTime = 0.25f;

	private float flapUpTimeFast = 0.1f;

	private float flutterUpTimeFast = 0.075f;

	private float flapUpTimeStandard = 0.2f;

	private float flapUpTimeSlow = 0.45f;

	private float flapUpTimeVariance = 0.025f;

	private float flapStandardChance = 0.65f;

	private float flapFastChance = 0.8f;

	private float flutterStandardChance = 0.35f;

	private float flutterFastChance = 0.8f;

	private float flapWait;

	private BodyBuck buckRef;

	private GravboostDog gravBoostRef;

	private void Awake()
	{
		buckRef = GetComponent<BodyBuck>();
	}

	public void GenerateNextFlapUpTime(bool flutter = false)
	{
		float num = flapFastChance;
		float num2 = flapStandardChance;
		if (flutter)
		{
			num = flutterFastChance;
			num2 = flutterStandardChance;
		}
		if (Random.value <= num2)
		{
			flapUpTime = Random.Range(flapUpTimeStandard - flapUpTimeVariance, flapUpTimeVariance + flapUpTimeVariance);
		}
		else if (Random.value <= num)
		{
			float num3 = flapUpTimeFast;
			if (flutter)
			{
				num3 = flutterUpTimeFast;
			}
			flapUpTime = Random.Range(num3 - flapUpTimeVariance, num3 + flapUpTimeVariance);
		}
		else
		{
			flapUpTime = Random.Range(flapUpTimeSlow - flapUpTimeVariance, flapUpTimeSlow + flapUpTimeVariance);
		}
		if (flutter && Random.value > 0.925f)
		{
			flapWait = Random.Range(10f, 20f);
		}
		else
		{
			flapWait = 0f;
		}
	}

	public float GetFlapUpTime()
	{
		return flapUpTime;
	}

	public float GetFlapWaitTime()
	{
		return flapWait;
	}

	private void Start()
	{
		gravBoostRef = GetComponent<GravboostDog>();
		DogLooks component = GetComponent<DogLooks>();
		if (component.leftWing != null)
		{
			leftWingRefs.AddRange(component.leftWing.GetComponentsInChildren<WingController>());
			for (int i = 0; i < leftWingRefs.Count; i++)
			{
				leftWingRefs[i].SetFlyRef(this);
			}
		}
		if (component.rightWing != null)
		{
			rightWingRefs.AddRange(component.rightWing.GetComponentsInChildren<WingController>());
			for (int j = 0; j < rightWingRefs.Count; j++)
			{
				rightWingRefs[j].SetFlyRef(this);
			}
		}
	}

	public bool IsFlying()
	{
		return isFlying;
	}

	public void RequestFly(FlyFinishedCallback callback = null)
	{
		if (isFlying || flyRoutine != null)
		{
			Debug.LogError("Attempting to fly but we're already doing so.");
			return;
		}
		isFlying = true;
		currentCallback = callback;
		flyRoutine = StartCoroutine(FlyRoutine());
	}

	public void RequestStopFlying()
	{
		if (isFlying)
		{
			FinishFly();
		}
	}

	private IEnumerator FlyRoutine()
	{
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		GetComponent<BoundingBoxComponent>();
		BoundingBoxComponent bbc = GetComponent<BoundingBoxComponent>();
		isFlying = true;
		buckRef.LockBucks();
		bool left = false;
		bool right = false;
		bool flyForwardConstant = false;
		bool flyForwardPeriodic = false;
		if (Random.value < periodicForwardChance)
		{
			if (Random.value < constantForwardChance)
			{
				flyForwardConstant = true;
			}
			else
			{
				flyForwardPeriodic = true;
			}
			if (Random.value < 0.25f)
			{
				if (Random.value < 0.5f)
				{
					left = true;
				}
				else
				{
					right = true;
				}
			}
		}
		for (int i = 0; i < leftWingRefs.Count; i++)
		{
			leftWingRefs[i].SetWingState(WingController.WingState.FLAP, force: false, flyForwardConstant, flyForwardPeriodic, right, left);
		}
		for (int j = 0; j < rightWingRefs.Count; j++)
		{
			rightWingRefs[j].SetWingState(WingController.WingState.FLAP, force: false, flyForwardConstant, flyForwardPeriodic, right, left);
		}
		float timer = 0f;
		for (float flyTime = Random.Range(flyTimeLow, flyTimeHigh); timer < flyTime; timer += Time.deltaTime)
		{
			if (!(bbc != null))
			{
				break;
			}
			yield return frameWait;
		}
		currentCallback?.Invoke();
		currentCallback = null;
		flyRoutine = null;
		FinishFly();
	}

	private void FinishFly()
	{
		isFlying = false;
		currentCallback = null;
		buckRef.UnlockBucks();
		gravBoostRef.ClearCustomMultiplier();
		for (int i = 0; i < leftWingRefs.Count; i++)
		{
			leftWingRefs[i].SetWingState(WingController.WingState.TUCKED);
		}
		for (int j = 0; j < rightWingRefs.Count; j++)
		{
			rightWingRefs[j].SetWingState(WingController.WingState.TUCKED);
		}
		if (flyRoutine != null)
		{
			StopCoroutine(flyRoutine);
			flyRoutine = null;
		}
	}
}
