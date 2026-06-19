using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarfBehavior : MonoBehaviour
{
	public delegate void BarfFinishedCallback();

	private bool isBarfing;

	private float currentBodyTime;

	private AnimationCurveWrapper bodyCurveZ;

	private Coroutine currentBarfRoutine;

	private LiquidInfo barfInfo;

	private string dogBarfSound = "dog_barf";

	private DoggyBrain brainRef;

	private LegController controllerRef;

	private FaceController faceController;

	private DogParticleController particleRef;

	private MouthController mouthControllerRef;

	private void Awake()
	{
		brainRef = GetComponent<DoggyBrain>();
		controllerRef = GetComponent<LegController>();
		faceController = GetComponent<FaceController>();
		particleRef = GetComponent<DogParticleController>();
		mouthControllerRef = GetComponent<MouthController>();
		LiquidController globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<LiquidController>(GlobalObject.LIQUID_CONTROLLER, nullAllowed: true);
		if (globalComponent != null)
		{
			barfInfo = globalComponent.GetLiquidForType(LiquidType.BARF);
		}
		CreateCurves();
	}

	private void FixedUpdate()
	{
		if (isBarfing)
		{
			FollowCurve();
		}
	}

	private void CreateCurves()
	{
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.AddKey(0f, 0f);
		animationCurve.AddKey(0.25f, 500f);
		animationCurve.AddKey(0.5f, 500f);
		animationCurve.AddKey(1f, 0f);
		animationCurve.postWrapMode = WrapMode.Loop;
		bodyCurveZ = new AnimationCurveWrapper(animationCurve);
	}

	private void FollowCurve()
	{
		Vector3 torque = new Vector3(0f, 0f, CurveUtil.EvaluateAverageCurveWrapperTime(bodyCurveZ, currentBodyTime, currentBodyTime - Time.fixedDeltaTime));
		controllerRef.TorqueBody(controllerRef.bodyFront, torque);
		currentBodyTime += Time.fixedDeltaTime;
	}

	public void RequestBarf(BarfFinishedCallback callback = null)
	{
		if (isBarfing)
		{
			Debug.LogError("Attempting to barf but we're already barfing.");
		}
		else
		{
			currentBarfRoutine = StartCoroutine(BarfRoutine(callback));
		}
	}

	private IEnumerator BarfRoutine(BarfFinishedCallback callback)
	{
		faceController.RequestFace(Face.WINCE, 4.25f);
		yield return new WaitForSeconds(0.75f);
		StartBarfing();
		brainRef.OnBarf();
		AudioController.Play(dogBarfSound, faceController.GetDogHeadForIndex(0).mouthTransform.position);
		callback?.Invoke();
		yield return new WaitForSeconds(0.5f);
		CreateBarfPuddle();
		GetComponent<DogAI>().GetCurrentBehavior().AwardBehaviorDefinedLoot();
		GetComponent<DogGutController>().GetDogGut().Purge();
		currentBarfRoutine = null;
	}

	public void RequestStopBarfing()
	{
		if (isBarfing)
		{
			StopBarfing();
		}
	}

	private void StartBarfing()
	{
		int activeMouthIndex = mouthControllerRef.GetActiveMouthIndex();
		mouthControllerRef.DropObject();
		currentBodyTime = 0f;
		isBarfing = true;
		particleRef.RequestBarfParticlesStart(activeMouthIndex);
		List<GameObject> allLegs = controllerRef.GetAllLegs();
		for (int i = 0; i < allLegs.Count; i++)
		{
			allLegs[i].GetComponent<Limb>().PlantLeg();
		}
	}

	private void CreateBarfPuddle()
	{
		GameObject obj = new GameObject("Barf Puddle Creator");
		obj.transform.position = faceController.GetDogHeadForIndex(0).mouthTransform.position;
		Liquid liquid = obj.AddComponent<Liquid>();
		liquid.ApplyLiquid(barfInfo);
		liquid.CreatePuddle();
		Object.Destroy(obj);
		GoalsController.ReportGoalEvent(GoalCondition.BARF);
	}

	private void StopBarfing()
	{
		isBarfing = false;
		if (currentBarfRoutine != null)
		{
			StopCoroutine(currentBarfRoutine);
			currentBarfRoutine = null;
		}
		List<GameObject> allLegs = controllerRef.GetAllLegs();
		for (int i = 0; i < allLegs.Count; i++)
		{
			allLegs[i].GetComponent<Limb>().UnplantLeg();
		}
	}
}
