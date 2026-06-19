using System.Collections.Generic;
using UnityEngine;

public class EatBehavior : MonoBehaviour
{
	public delegate void EatFinishedCallback();

	private EatFinishedCallback currentCallback;

	private LegController controllerRef;

	private AnimationCurveWrapper eatCurveX;

	private AnimationCurveWrapper eatCurveZ;

	private float curveTime;

	private float previousCurveTime;

	private float biteTimeOffset = 0.25f;

	private bool isEating;

	private float gruntChance = 0.025f;

	private FoodPersonalityType foodPersonality;

	private float timingUpdateJiggle = 0.5f;

	private float foodAverseTimingMod = 0.66f;

	private float foodObsessedTimingMod = 2f;

	private DogAI aiRef;

	private GameObject foodObj;

	private Eatable foodEatable;

	private DoggyBrain brainRef;

	private DogNoises dogNoisesRef;

	private MouthController mouthControllerRef;

	private DogPoopController poopControllerRef;

	private DogGutController dogGutControllerRef;

	private void Awake()
	{
		aiRef = GetComponent<DogAI>();
		brainRef = GetComponent<DoggyBrain>();
		dogNoisesRef = GetComponent<DogNoises>();
		controllerRef = GetComponent<LegController>();
		mouthControllerRef = GetComponent<MouthController>();
		poopControllerRef = GetComponent<DogPoopController>();
		dogGutControllerRef = GetComponent<DogGutController>();
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.AddKey(0f, 0f);
		animationCurve.AddKey(0.5f, 0f);
		AnimationCurve animationCurve2 = new AnimationCurve();
		animationCurve2.AddKey(0f, 0f);
		animationCurve2.AddKey(0.25f, -1000f);
		animationCurve2.AddKey(0.5f, 0f);
		animationCurve.postWrapMode = WrapMode.Loop;
		animationCurve2.postWrapMode = WrapMode.Loop;
		eatCurveX = new AnimationCurveWrapper(animationCurve);
		eatCurveZ = new AnimationCurveWrapper(animationCurve2);
	}

	private void FixedUpdate()
	{
		if (isEating)
		{
			EatAnimation();
		}
	}

	public void RequestEat(GameObject food, EatFinishedCallback callback = null)
	{
		if (!isEating)
		{
			foodPersonality = brainRef.GetPersonality().GetFoodPersonality();
			currentCallback = callback;
			Eat(food);
		}
	}

	public void RequestStopEating(bool naturalEnd = false)
	{
		if (isEating)
		{
			StopEating();
			if (!naturalEnd)
			{
				base.gameObject.GetComponent<DogAI>().ForceInterruptBehavior();
			}
		}
	}

	private void EatAnimation()
	{
		if (!foodEatable.CanBite())
		{
			RequestStopEating();
			return;
		}
		GameObject carriedObject = mouthControllerRef.GetCarriedObject();
		if (carriedObject == null || carriedObject.transform.root.gameObject != foodObj.transform.root.gameObject)
		{
			RequestStopEating();
			return;
		}
		Vector3 torque = new Vector3(CurveUtil.EvaluateAverageCurveWrapperTime(eatCurveX, curveTime, previousCurveTime), 0f, CurveUtil.EvaluateAverageCurveWrapperTime(eatCurveZ, curveTime, previousCurveTime));
		controllerRef.TorqueBody(controllerRef.bodyFront, torque);
		previousCurveTime = curveTime;
		float num;
		if (foodPersonality != FoodPersonalityType.FOOD_OBSESSED)
		{
			num = ((foodPersonality != FoodPersonalityType.FOOD_AVERSE) ? Time.fixedDeltaTime : (Time.fixedDeltaTime * foodAverseTimingMod));
		}
		else
		{
			num = Time.fixedDeltaTime * foodObsessedTimingMod;
			if (Random.value <= gruntChance)
			{
				dogNoisesRef.RequestGrunt();
			}
		}
		num += Random.Range((0f - timingUpdateJiggle) * num, timingUpdateJiggle * num);
		float num2 = curveTime + biteTimeOffset;
		if ((float)(int)num2 / eatCurveX.GetTotalTime() != (float)(int)(num2 + num) / eatCurveX.GetTotalTime())
		{
			TakeBite(mouthControllerRef.GetActiveMouthIndex());
		}
		curveTime += num;
	}

	private void TakeBite(int activeMouthIndex)
	{
		foodEatable.RequestBite(base.gameObject, activeMouthIndex);
		if (foodEatable == null || !isEating)
		{
			return;
		}
		if (foodEatable.isPoop)
		{
			DogFeatController.ReportPoopFeatProgress(GetComponent<ObjectID>().GetUID(), 1);
		}
		DogBehaviorBase currentBehavior = aiRef.GetCurrentBehavior();
		if (currentBehavior != null)
		{
			currentBehavior.AwardBehaviorDefinedLoot();
			currentBehavior.AwardBehaviorDefinedAndValuedLoot(foodEatable.hungerGivenPerBite);
			float num = foodEatable.gutFloraTypes.Count;
			float num2 = foodEatable.boostedGutFloraTypes.Count;
			bool isBoosted = false;
			List<GutFloraResource> objects = foodEatable.gutFloraTypes;
			if (foodEatable.gutFloraTypes.Count == 0)
			{
				isBoosted = true;
				objects = foodEatable.boostedGutFloraTypes;
			}
			else if (foodEatable.boostedGutFloraTypes.Count != 0)
			{
				float num3 = num2 + num;
				if (Random.value <= num2 / num3)
				{
					isBoosted = true;
					objects = foodEatable.boostedGutFloraTypes;
				}
			}
			dogGutControllerRef.GetDogGut().SpawnNewGutFlora(ListUtil.GetRandomElement(objects), null, null, null, foodEatable, isBoosted);
		}
		poopControllerRef.OnBiteTaken();
		mouthControllerRef.TryTeething();
	}

	private void Eat(GameObject food)
	{
		curveTime = 0f;
		previousCurveTime = 0f;
		foodObj = food;
		if (foodObj == null)
		{
			StopEating();
			return;
		}
		foodEatable = foodObj.GetComponent<Eatable>();
		if (foodEatable == null)
		{
			StopEating();
			return;
		}
		foodEatable.AssignDog(base.gameObject);
		controllerRef.PlantLegs();
		isEating = true;
	}

	private void StopEating()
	{
		if (foodEatable != null)
		{
			foodEatable.ReleaseDog(base.gameObject);
		}
		if (currentCallback != null)
		{
			currentCallback();
			currentCallback = null;
		}
		foodObj = null;
		foodEatable = null;
		aiRef.ClearTargetObject();
		controllerRef.UnplantLegs();
		GetComponent<MouthController>().DropObject();
		isEating = false;
	}
}
