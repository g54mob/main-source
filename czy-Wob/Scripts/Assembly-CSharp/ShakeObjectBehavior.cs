using UnityEngine;

public class ShakeObjectBehavior : MonoBehaviour
{
	public delegate void ThrowCallback();

	private float currentBodyTime;

	private AnimationCurveWrapper bodyCurveY;

	private float customBreakFloat = 5000f;

	private float minLeverageRatio = 0.5f;

	private float initialHoldTime = 0.5f;

	private float waitTimerCurrent;

	private float endTime = 0.6f;

	private int cyclesLow = 3;

	private int cyclesHigh = 5;

	private int cyclesChosen = 1;

	private float randomTimingOffset;

	private float randomTimingOffsetLow = -0.02f;

	private float randomTimingOffsetHigh = 0.02f;

	private Vector3 cycleAngleLeft = new Vector3(0f, 0f, 90f);

	private Vector3 cycleAngleRight = new Vector3(0f, 0f, -90f);

	private int headAngleSwitchCount;

	private GameObject shakenObjectRef;

	private bool hasInterruptedDog;

	private ThrowCallback currentCallback;

	private MouthController mouthRef;

	private LegController controllerRef;

	private FaceController faceControllerRef;

	private bool isShaking;

	private void Awake()
	{
		mouthRef = base.gameObject.GetComponent<MouthController>();
		controllerRef = base.gameObject.GetComponent<LegController>();
		faceControllerRef = base.gameObject.GetComponent<FaceController>();
		CreateCurves();
	}

	private void FixedUpdate()
	{
		if (isShaking)
		{
			FollowCurve();
		}
	}

	private void CreateCurves()
	{
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.AddKey(0f, 0f);
		animationCurve.AddKey(0.25f, -10000f);
		animationCurve.AddKey(0.5f, 10000f);
		animationCurve.AddKey(endTime, 0f);
		animationCurve.postWrapMode = WrapMode.Loop;
		bodyCurveY = new AnimationCurveWrapper(animationCurve);
	}

	private void FollowCurve()
	{
		if (shakenObjectRef == null)
		{
			StopShaking();
			return;
		}
		if (waitTimerCurrent < initialHoldTime)
		{
			waitTimerCurrent += Time.fixedDeltaTime;
			return;
		}
		if (!mouthRef.IsCarryingObject())
		{
			StopShaking();
			return;
		}
		Vector3 vector = new Vector3(0f, CurveUtil.EvaluateAverageCurveWrapperTime(bodyCurveY, currentBodyTime, currentBodyTime - Time.fixedDeltaTime), 0f);
		int numPlantedLegs = controllerRef.GetNumPlantedLegs();
		float num = 0.5f;
		float num2 = controllerRef.GetLegCount();
		if (num2 > 0f)
		{
			num = Mathf.Max((float)numPlantedLegs / num2, minLeverageRatio);
		}
		controllerRef.TorqueBody(controllerRef.bodyFront, vector * num);
		float totalTime = bodyCurveY.GetTotalTime();
		if (currentBodyTime + randomTimingOffset >= totalTime * (float)headAngleSwitchCount)
		{
			if (headAngleSwitchCount == 1)
			{
				faceControllerRef.RequestFace(Face.ANGRY, -1f, suppressEmote: true);
			}
			randomTimingOffset = Random.Range(randomTimingOffsetLow, randomTimingOffsetHigh);
			headAngleSwitchCount++;
			if (headAngleSwitchCount > 1)
			{
				Vector3 overrideFaceRot = ((headAngleSwitchCount % 2 == 0) ? cycleAngleLeft : cycleAngleRight);
				faceControllerRef.SetOverrideFaceRot(overrideFaceRot);
			}
		}
		currentBodyTime += Time.fixedDeltaTime;
		if (!(currentBodyTime >= bodyCurveY.GetTotalTime() * (float)cyclesChosen))
		{
			return;
		}
		DogBehaviorBase currentBehavior = base.gameObject.GetComponent<DogAI>().GetCurrentBehavior();
		if (currentBehavior != null)
		{
			currentBehavior.AwardBehaviorDefinedLoot();
		}
		if (shakenObjectRef.transform.root.CompareTag(Tags.DOG) && !hasInterruptedDog)
		{
			DogBehaviorBase currentBehavior2 = shakenObjectRef.transform.root.GetComponent<DogAI>().GetCurrentBehavior();
			if (currentBehavior2 != null)
			{
				hasInterruptedDog = true;
				currentBehavior2.HandleInterruption(base.gameObject, surpriseParticles: false);
			}
		}
		StopShaking();
	}

	public void RequestShake(GameObject target, ThrowCallback callback)
	{
		if (isShaking)
		{
			callback();
			Debug.LogError("Attempting to shake an object but we're already doing that.");
			return;
		}
		currentBodyTime = 0f;
		waitTimerCurrent = 0f;
		hasInterruptedDog = false;
		currentCallback = callback;
		cyclesChosen = Random.Range(cyclesLow, cyclesHigh);
		StartShaking(target);
	}

	public void RequestStopShaking()
	{
		if (isShaking)
		{
			StopShaking();
		}
	}

	private void StartShaking(GameObject target)
	{
		isShaking = true;
		randomTimingOffset = 0f;
		mouthRef.GrabObject(target);
		faceControllerRef.MaximizeNeckTension();
		controllerRef.PlantLegs(customBreakFloat, customBreakFloat);
		shakenObjectRef = target;
		headAngleSwitchCount = 0;
	}

	private void StopShaking()
	{
		isShaking = false;
		controllerRef.UnplantLegs();
		faceControllerRef.RestoreNeckTension();
		faceControllerRef.ClearOverrideFaceRot();
		faceControllerRef.RequestFace(Face.DEFAULT);
		shakenObjectRef = null;
		currentCallback();
		currentCallback = null;
	}
}
