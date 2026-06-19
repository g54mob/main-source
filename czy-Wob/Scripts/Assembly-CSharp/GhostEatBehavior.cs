using System.Collections.Generic;
using UnityEngine;

public class GhostEatBehavior : MonoBehaviour
{
	public delegate void EatFinishedCallback();

	private EatFinishedCallback currentCallback;

	private GameObject currentlyEatenObject;

	private float customEatenObjectWeight = 0.1f;

	private float customEatenObjectDrag = 0.75f;

	private List<EatenObjectInfo> eatenInfo = new List<EatenObjectInfo>();

	private ConfigurableJoint eatenObjectJoint;

	private AnimationCurveWrapper eatCurveX;

	private AnimationCurveWrapper eatCurveZ;

	private float curveTime;

	private float previousCurveTime;

	private float biteTimeOffset = 0.25f;

	private float scaleBuffer = 0.1f;

	private bool isEating;

	private float currentFoodTimer;

	private float targetFoodTimer;

	private float foodTimerLow = 120f;

	private float foodTimerHigh = 360f;

	private float ectoplasmTransformationTimer = 60f;

	private GameObject foodObj;

	private DogAI aiRef;

	private DogGutController gutRef;

	private LegController controllerRef;

	private MouthController mouthControllerRef;

	private DogHome homeRef;

	private void Awake()
	{
		aiRef = GetComponent<DogAI>();
		gutRef = GetComponent<DogGutController>();
		controllerRef = GetComponent<LegController>();
		mouthControllerRef = GetComponent<MouthController>();
		homeRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME, nullAllowed: true);
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

	public GameObject GetCurrentlyEatenObject()
	{
		return currentlyEatenObject;
	}

	private void FixedUpdate()
	{
		if (isEating)
		{
			ProcessEat();
		}
	}

	private void OnDestroy()
	{
		if (currentlyEatenObject != null)
		{
			DropEatenObject();
		}
	}

	private void Update()
	{
		if (!isEating && currentFoodTimer < targetFoodTimer)
		{
			bool flag = false;
			if (currentFoodTimer >= ectoplasmTransformationTimer)
			{
				flag = true;
			}
			currentFoodTimer += Time.deltaTime;
			if (!flag && currentFoodTimer >= ectoplasmTransformationTimer && currentlyEatenObject != null && currentlyEatenObject.CompareTag(Tags.FOOD))
			{
				SpawnEctoplasm();
			}
			if (currentFoodTimer >= targetFoodTimer)
			{
				DropEatenObject();
			}
		}
	}

	public void RequestEat(GameObject food, EatFinishedCallback callback = null)
	{
		if (!isEating)
		{
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

	private void ProcessEat()
	{
		GameObject carriedObject = mouthControllerRef.GetCarriedObject();
		if (carriedObject == null || carriedObject.transform.root.gameObject != foodObj.transform.root.gameObject)
		{
			RequestStopEating();
			return;
		}
		Vector3 torque = new Vector3(CurveUtil.EvaluateAverageCurveWrapperTime(eatCurveX, curveTime, previousCurveTime), 0f, CurveUtil.EvaluateAverageCurveWrapperTime(eatCurveZ, curveTime, previousCurveTime));
		controllerRef.TorqueBody(controllerRef.bodyFront, torque);
		previousCurveTime = curveTime;
		float fixedDeltaTime = Time.fixedDeltaTime;
		float num = curveTime + biteTimeOffset;
		if ((float)(int)num / eatCurveX.GetTotalTime() != (float)(int)(num + fixedDeltaTime) / eatCurveX.GetTotalTime())
		{
			if (!isEating)
			{
				RequestStopEating();
			}
			else
			{
				FinalizeEat();
			}
		}
		else
		{
			curveTime += fixedDeltaTime;
		}
	}

	private void Eat(GameObject food)
	{
		if (currentlyEatenObject == food)
		{
			Debug.LogError(string.Concat("Attempting to eat an object (", food, ") that we already have inside of us."));
			return;
		}
		if (currentlyEatenObject != null)
		{
			DropEatenObject();
		}
		curveTime = 0f;
		previousCurveTime = 0f;
		foodObj = food;
		if (foodObj == null)
		{
			StopEating();
			return;
		}
		controllerRef.PlantLegs();
		isEating = true;
	}

	private void SetColliderStatus(bool status)
	{
		Collider[] componentsInChildren = currentlyEatenObject.GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = status;
		}
	}

	public SerializableGameObject GetSaveableEatenObject(GameObject obj)
	{
		if (obj != currentlyEatenObject)
		{
			Debug.LogError(string.Concat("Attempting to save an eaten object (", obj, ") that it doesn't look like we actually ate. Our actual eaten object is: ", currentlyEatenObject));
			return null;
		}
		if (eatenInfo.Count == 0)
		{
			return new SerializableGameObject(obj);
		}
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < eatenInfo.Count; i++)
		{
			list.Add(eatenInfo[i].eatenObjectScaledTransform.localScale);
			eatenInfo[i].eatenObjectScaledTransform.localScale = eatenInfo[i].previousEatenObjectScale;
		}
		SerializableGameObject result = new SerializableGameObject(obj);
		for (int j = 0; j < eatenInfo.Count; j++)
		{
			eatenInfo[j].eatenObjectScaledTransform.localScale = list[j];
		}
		return result;
	}

	public void DropEatenObject()
	{
		if (currentlyEatenObject == null)
		{
			return;
		}
		ObjectConnectionsManager.OnConsumedObjectDroppedByGhost(base.gameObject, currentlyEatenObject);
		for (int i = 0; i < eatenInfo.Count; i++)
		{
			if (eatenInfo[i].eatenObjectScaledTransform != null)
			{
				Rigidbody component = eatenInfo[i].eatenObjectScaledTransform.GetComponent<Rigidbody>();
				component.mass = eatenInfo[i].previousEatenObjectWeight;
				component.drag = eatenInfo[i].previousDrag;
				component.angularDrag = eatenInfo[i].previousAngularDrag;
				if (eatenInfo.Count == 1)
				{
					eatenInfo[i].eatenObjectScaledTransform.localScale = eatenInfo[i].previousEatenObjectScale;
				}
			}
		}
		eatenInfo.Clear();
		SetColliderStatus(status: true);
		if (eatenObjectJoint != null)
		{
			Object.Destroy(eatenObjectJoint);
			eatenObjectJoint = null;
		}
		Transform obj = controllerRef.butt.transform;
		BoundingBoxComponent component2 = currentlyEatenObject.GetComponent<BoundingBoxComponent>();
		component2.ForceUpdateBoundingBox();
		Vector3 boxCenter = component2.GetBoxCenter();
		Vector3 vector = obj.transform.position - boxCenter;
		ObjectConnectionsManager.OnObjectTeleported(currentlyEatenObject, vector);
		currentlyEatenObject.transform.position += vector;
		currentlyEatenObject = null;
	}

	private void FinalizeEat()
	{
		if (currentlyEatenObject != null)
		{
			DropEatenObject();
		}
		PlaceObjectInsideGhost(foodObj);
		currentFoodTimer = 0f;
		targetFoodTimer = Random.Range(foodTimerLow, foodTimerHigh);
		RequestStopEating();
	}

	private void PlaceObjectInsideGhost(GameObject newFood)
	{
		currentlyEatenObject = newFood;
		BoundingBoxComponent component = currentlyEatenObject.GetComponent<BoundingBoxComponent>();
		component.ForceUpdateBoundingBox();
		SetColliderStatus(status: false);
		float num = component.GetMaxBound() * 2f + scaleBuffer;
		Vector3 lossyScale = controllerRef.bodyFront.transform.lossyScale;
		float num2 = lossyScale.x * 2f;
		if (lossyScale.y < num2)
		{
			num2 = lossyScale.y;
		}
		if (lossyScale.z < num2)
		{
			num2 = lossyScale.z;
		}
		eatenInfo.Clear();
		if (num > num2)
		{
			float num3 = num2 / num;
			List<Rigidbody> list = new List<Rigidbody>();
			list.AddRange(currentlyEatenObject.GetComponentsInChildren<Rigidbody>());
			for (int i = 0; i < list.Count; i++)
			{
				EatenObjectInfo item = new EatenObjectInfo
				{
					eatenObjectScaledTransform = list[i].transform,
					previousEatenObjectWeight = list[i].mass,
					previousDrag = list[i].drag,
					previousAngularDrag = list[i].angularDrag
				};
				list[i].mass = customEatenObjectWeight;
				list[i].drag = customEatenObjectDrag;
				list[i].angularDrag = customEatenObjectDrag;
				list[i].velocity = Vector3.zero;
				list[i].angularVelocity = Vector3.zero;
				item.previousEatenObjectScale = item.eatenObjectScaledTransform.localScale;
				if (list.Count == 1)
				{
					item.eatenObjectScaledTransform.localScale *= num3;
				}
				eatenInfo.Add(item);
			}
		}
		component.ForceUpdateBoundingBox();
		Vector3 boxCenter = component.GetBoxCenter();
		Vector3 vector = controllerRef.bodyFront.transform.position + (controllerRef.bodyBack.transform.position - controllerRef.bodyFront.transform.position) / 2f;
		Vector3 vector2 = vector - boxCenter;
		ObjectConnectionsManager.OnObjectTeleported(currentlyEatenObject, vector2);
		currentlyEatenObject.transform.position += vector2;
		ObjectConnectionsManager.OnObjectConsumedByGhost(base.gameObject, currentlyEatenObject);
		CreateEatenObjectJoint(vector);
	}

	private void CreateEatenObjectJoint(Vector3 bellyCenter)
	{
		if (eatenObjectJoint != null)
		{
			Debug.LogError("EatenObjectJoint already exists: " + eatenObjectJoint);
			Object.Destroy(eatenObjectJoint);
			eatenObjectJoint = null;
		}
		Rigidbody componentInChildren = currentlyEatenObject.GetComponentInChildren<Rigidbody>();
		Rigidbody component = controllerRef.bodyFront.GetComponent<Rigidbody>();
		eatenObjectJoint = componentInChildren.gameObject.AddComponent<ConfigurableJoint>();
		eatenObjectJoint.configuredInWorldSpace = true;
		eatenObjectJoint.connectedBody = component;
		eatenObjectJoint.anchor = componentInChildren.transform.InverseTransformPoint(bellyCenter);
		eatenObjectJoint.xMotion = ConfigurableJointMotion.Locked;
		eatenObjectJoint.yMotion = ConfigurableJointMotion.Locked;
		eatenObjectJoint.zMotion = ConfigurableJointMotion.Locked;
		SoftJointLimitSpring linearLimitSpring = new SoftJointLimitSpring
		{
			spring = 0f
		};
		SoftJointLimit linearLimit = new SoftJointLimit
		{
			limit = 0.1f,
			bounciness = 0f
		};
		eatenObjectJoint.linearLimit = linearLimit;
		eatenObjectJoint.linearLimitSpring = linearLimitSpring;
		SoftJointLimit lowAngularXLimit = default(SoftJointLimit);
		SoftJointLimit highAngularXLimit = default(SoftJointLimit);
		SoftJointLimit softJointLimit = default(SoftJointLimit);
		float num = 0.1f;
		float bounciness = 0f;
		lowAngularXLimit.limit = 0f - num;
		lowAngularXLimit.bounciness = bounciness;
		highAngularXLimit.limit = num;
		highAngularXLimit.bounciness = bounciness;
		softJointLimit.limit = num;
		softJointLimit.bounciness = bounciness;
		eatenObjectJoint.lowAngularXLimit = lowAngularXLimit;
		eatenObjectJoint.highAngularXLimit = highAngularXLimit;
		eatenObjectJoint.angularYLimit = softJointLimit;
		eatenObjectJoint.angularZLimit = softJointLimit;
		eatenObjectJoint.enablePreprocessing = false;
		eatenObjectJoint.projectionMode = JointProjectionMode.PositionAndRotation;
		eatenObjectJoint.projectionAngle = 1f;
		eatenObjectJoint.projectionDistance = 0.1f;
	}

	private void StopEating()
	{
		isEating = false;
		currentCallback?.Invoke();
		currentCallback = null;
		foodObj = null;
		aiRef.ClearTargetObject();
		controllerRef.UnplantLegs();
		GetComponent<MouthController>().DropObject();
	}

	private void SpawnEctoplasm()
	{
		if (!(homeRef == null))
		{
			Vector3 anchor = eatenObjectJoint.anchor;
			GameObject gameObject = homeRef.TrySpawnItem(gutRef.ectoplasmObject, anchor, null, moveToGoodLocation: false);
			if (gameObject == null)
			{
				Debug.LogError("Failed to create ectoplasm.");
				return;
			}
			GameObject obj = currentlyEatenObject;
			DropEatenObject();
			Object.Destroy(obj);
			PlaceObjectInsideGhost(gameObject);
			GoalsController.ReportGoalEvent(GoalCondition.ECTOPLASM);
		}
	}
}
