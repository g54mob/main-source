using UnityEngine;

public class ThrowObjectBehavior : MonoBehaviour
{
	public delegate void ThrowCallback();

	private float currentBodyTime;

	private AnimationCurveWrapper bodyCurveY;

	private AnimationCurveWrapper bodyCurveX;

	private float customBreakFloat = 1000f;

	private float releaseTime = 0.6f;

	private float minLeverageRatio = 0.5f;

	private float initialHoldTime = 0.5f;

	private float waitTimerCurrent;

	private bool throwFlip;

	private GameObject thrownObjectRef;

	private bool hasInterruptedDog;

	private ThrowCallback currentCallback;

	private MouthController mouthRef;

	private LegController controllerRef;

	private bool isThrowing;

	private void Awake()
	{
		mouthRef = base.gameObject.GetComponent<MouthController>();
		controllerRef = base.gameObject.GetComponent<LegController>();
		CreateCurves();
	}

	private void FixedUpdate()
	{
		if (isThrowing)
		{
			FollowCurve();
		}
	}

	private void CreateCurves()
	{
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.AddKey(0f, 0f);
		animationCurve.AddKey(0.2f, -0f);
		animationCurve.AddKey(0.25f, -10000f);
		animationCurve.AddKey(0.55f, 0f);
		animationCurve.AddKey(releaseTime, 0f);
		animationCurve.AddKey(1.5f, 0f);
		animationCurve.postWrapMode = WrapMode.Once;
		bodyCurveY = new AnimationCurveWrapper(animationCurve);
		AnimationCurve animationCurve2 = new AnimationCurve();
		animationCurve2.AddKey(0f, 0f);
		animationCurve2.AddKey(0.2f, 0f);
		animationCurve2.AddKey(0.25f, -2000f);
		animationCurve2.AddKey(0.55f, 0f);
		animationCurve.AddKey(1.5f, 0f);
		animationCurve2.postWrapMode = WrapMode.Once;
		bodyCurveX = new AnimationCurveWrapper(animationCurve2);
	}

	private void FollowCurve()
	{
		if (thrownObjectRef == null)
		{
			StopThrowing();
			return;
		}
		if (waitTimerCurrent < initialHoldTime)
		{
			waitTimerCurrent += Time.fixedDeltaTime;
			return;
		}
		Vector3 vector = new Vector3(CurveUtil.EvaluateAverageCurveWrapperTime(bodyCurveX, currentBodyTime, currentBodyTime - Time.fixedDeltaTime), CurveUtil.EvaluateAverageCurveWrapperTime(bodyCurveY, currentBodyTime, currentBodyTime - Time.fixedDeltaTime), 0f);
		if (throwFlip)
		{
			vector *= -1f;
		}
		if (!mouthRef.IsCarryingObject())
		{
			vector = Vector3.zero;
		}
		int numPlantedLegs = controllerRef.GetNumPlantedLegs();
		float num = Mathf.Max(numPlantedLegs / controllerRef.GetLegCount(), minLeverageRatio);
		if (numPlantedLegs == 0)
		{
			num = 0f;
		}
		controllerRef.TorqueBody(controllerRef.bodyFront, vector * num);
		controllerRef.TorqueBody(controllerRef.bodyBack, -vector * num);
		currentBodyTime += Time.fixedDeltaTime;
		if (currentBodyTime >= bodyCurveY.GetTotalTime())
		{
			StopThrowing();
		}
		else
		{
			if (!(currentBodyTime >= releaseTime))
			{
				return;
			}
			if (mouthRef.IsCarryingObject())
			{
				InteractableBase component = mouthRef.GetCarriedObject().transform.root.GetComponent<InteractableBase>();
				if (component != null)
				{
					component.OnObjectThrownByDog(base.gameObject);
				}
				mouthRef.DropObject();
				DogBehaviorBase currentBehavior = base.gameObject.GetComponent<DogAI>().GetCurrentBehavior();
				if (currentBehavior != null)
				{
					currentBehavior.AwardBehaviorDefinedLoot();
				}
				controllerRef.TightenAbs(LooseAbsLock.THROWING_OBJECT);
			}
			controllerRef.PlantLegs(customBreakFloat, customBreakFloat);
			if (thrownObjectRef.transform.root.CompareTag(Tags.DOG) && !hasInterruptedDog)
			{
				DogBehaviorBase currentBehavior2 = thrownObjectRef.transform.root.GetComponent<DogAI>().GetCurrentBehavior();
				if (currentBehavior2 != null)
				{
					hasInterruptedDog = true;
					currentBehavior2.HandleInterruption(base.gameObject, surpriseParticles: false);
				}
			}
		}
	}

	public void RequestThrow(GameObject target, ThrowCallback callback)
	{
		if (isThrowing)
		{
			callback();
			Debug.LogError("Attempting to throw an object but we're already doing that.");
			return;
		}
		currentBodyTime = 0f;
		waitTimerCurrent = 0f;
		hasInterruptedDog = false;
		currentCallback = callback;
		StartThrowing(target);
	}

	public void RequestStopThrowing()
	{
		if (isThrowing)
		{
			StopThrowing();
		}
	}

	private void StartThrowing(GameObject target)
	{
		isThrowing = true;
		mouthRef.GrabObject(target);
		controllerRef.PlantLegs(customBreakFloat, customBreakFloat);
		controllerRef.LoosenAbs(LooseAbsLock.THROWING_OBJECT);
		thrownObjectRef = target;
		throwFlip = Random.value >= 0.5f;
	}

	private void StopThrowing()
	{
		isThrowing = false;
		controllerRef.UnplantLegs();
		controllerRef.TightenAbs(LooseAbsLock.THROWING_OBJECT);
		mouthRef.DropObject();
		thrownObjectRef = null;
		currentCallback();
		currentCallback = null;
	}
}
