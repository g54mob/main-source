using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChokeOnFoodBehavior : MonoBehaviour
{
	public delegate void ChokeFinishedCallback();

	private bool isChoking;

	private float currentBodyTime;

	private AnimationCurveWrapper bodyCurveZ;

	private Coroutine currentChokeRoutine;

	private LiquidInfo barfInfo;

	private float purgeModifier = 0.25f;

	private DogGutController dogGutRef;

	private LegController controllerRef;

	private FaceController faceController;

	private DogParticleController particleRef;

	private MouthController mouthControllerRef;

	private DogHome homeRef;

	private void Awake()
	{
		dogGutRef = GetComponent<DogGutController>();
		controllerRef = GetComponent<LegController>();
		faceController = GetComponent<FaceController>();
		particleRef = GetComponent<DogParticleController>();
		mouthControllerRef = GetComponent<MouthController>();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		homeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		LiquidController globalComponent = registrationScript.GetGlobalComponent<LiquidController>(GlobalObject.LIQUID_CONTROLLER, nullAllowed: true);
		if (globalComponent != null)
		{
			barfInfo = globalComponent.GetLiquidForType(LiquidType.BARF);
		}
		CreateCurves();
	}

	private void FixedUpdate()
	{
		if (isChoking)
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

	public void RequestChoke(ChokeFinishedCallback callback = null)
	{
		if (isChoking)
		{
			Debug.LogError("Attempting to choke but we're already choking.");
		}
		else
		{
			currentChokeRoutine = StartCoroutine(ChokeRoutine(callback));
		}
	}

	private IEnumerator ChokeRoutine(ChokeFinishedCallback callback)
	{
		faceController.RequestFace(Face.WINCE, 4.25f);
		yield return new WaitForSeconds(0.75f);
		int mouthIndex = mouthControllerRef.GetActiveMouthIndex();
		StartChoking();
		yield return new WaitForSeconds(1.5f);
		CreateBarfPuddle(mouthIndex);
		CreateHockedUpFood(mouthIndex);
		GetComponent<DogAI>().GetCurrentBehavior().AwardBehaviorDefinedLoot();
		GetComponent<DogGutController>().GetDogGut().Purge(purgeModifier);
		callback?.Invoke();
		currentChokeRoutine = null;
	}

	public void RequestStopChoking()
	{
		if (isChoking)
		{
			StopChoking();
		}
	}

	private void StartChoking()
	{
		int activeMouthIndex = mouthControllerRef.GetActiveMouthIndex();
		mouthControllerRef.DropObject();
		currentBodyTime = 0f;
		isChoking = true;
		particleRef.RequestChokingParticlesStart(activeMouthIndex);
		List<GameObject> allLegs = controllerRef.GetAllLegs();
		for (int i = 0; i < allLegs.Count; i++)
		{
			allLegs[i].GetComponent<Limb>().PlantLeg();
		}
	}

	private void CreateBarfPuddle(int mouthIndex)
	{
		GameObject obj = new GameObject("Barf Puddle Creator");
		obj.transform.position = faceController.GetDogHeadForIndex(mouthIndex).mouthTransform.position;
		Liquid liquid = obj.AddComponent<Liquid>();
		liquid.ApplyLiquid(barfInfo);
		liquid.CreatePuddle(smallPuddle: true);
		Object.Destroy(obj);
	}

	private void CreateHockedUpFood(int mouthIndex)
	{
		GameObject gameObject = homeRef.TrySpawnItem(dogGutRef.hockedUpFoodObject, faceController.GetDogHeadForIndex(mouthIndex).mouthTransform.position, null, moveToGoodLocation: false);
		if (gameObject != null)
		{
			gameObject.AddComponent<Liquid>().ApplyLiquid(barfInfo, force: true);
		}
	}

	private void StopChoking()
	{
		isChoking = false;
		if (currentChokeRoutine != null)
		{
			StopCoroutine(currentChokeRoutine);
			currentChokeRoutine = null;
		}
		List<GameObject> allLegs = controllerRef.GetAllLegs();
		for (int i = 0; i < allLegs.Count; i++)
		{
			allLegs[i].GetComponent<Limb>().UnplantLeg();
		}
	}
}
