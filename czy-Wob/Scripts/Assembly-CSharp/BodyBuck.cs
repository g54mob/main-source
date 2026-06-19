using System.Collections.Generic;
using UnityEngine;

public class BodyBuck : MonoBehaviour
{
	public delegate void BuckFinishedCallback();

	public float buckMultiplier = 3f;

	private float customMultiplier = 1f;

	private bool isBucking;

	private AnimationCurveWrapper buckCurveBackZ;

	private AnimationCurveWrapper buckCurveFrontZ;

	private bool backHitTop;

	private bool frontHitTop;

	private bool backHitBot;

	private bool frontHitBot;

	private float curveTime;

	private float maxCurveTime;

	private float additionalWaitTime;

	private float additionalOffset = 0.01f;

	private float bottomBuckMultiplier = 1f;

	private float collisionTimeCurrentTop;

	private float collisionTimeRequiredTop = 0.1f;

	private float collisionTimeCurrentBot;

	private float collisionTimeRequiredBot = 0.2f;

	private float buckDampTimer = 0.5f;

	private float noCollisionCount;

	private float noCollisionDampMultiplier = 0.75f;

	private GameObject bodyBack;

	private GameObject bodyFront;

	private List<GameObject> backIgnoreList = new List<GameObject>();

	private List<GameObject> frontIgnoreList = new List<GameObject>();

	private bool bucksLocked;

	private bool continuousBucks;

	private bool checkedBuckLastFrame;

	private DoggyBrain brainRef;

	private LegController controllerRef;

	private void Awake()
	{
		brainRef = base.gameObject.GetComponent<DoggyBrain>();
		controllerRef = base.gameObject.GetComponent<LegController>();
		bodyBack = controllerRef.bodyBack;
		bodyFront = controllerRef.bodyFront;
		PopulateIgnoreLists();
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.AddKey(0f, 0f);
		animationCurve.AddKey(0.25f, 650f);
		animationCurve.AddKey(0.5f, -1600f);
		animationCurve.AddKey(0.75f, 0f);
		animationCurve.AddKey(1.25f, 0f);
		AnimationCurve animationCurve2 = new AnimationCurve();
		animationCurve2.AddKey(0f, 0f);
		animationCurve2.AddKey(0.5f, -500f);
		animationCurve2.AddKey(0.75f, 800f);
		animationCurve2.AddKey(1f, -500f);
		buckCurveFrontZ = new AnimationCurveWrapper(animationCurve);
		buckCurveBackZ = new AnimationCurveWrapper(animationCurve2);
		maxCurveTime = Mathf.Max(buckCurveFrontZ.GetTotalTime(), buckCurveBackZ.GetTotalTime());
	}

	private void PopulateIgnoreLists()
	{
		backIgnoreList.Add(bodyFront);
		frontIgnoreList.Add(bodyBack);
		List<LegStructure> allLegStructures = controllerRef.GetAllLegStructures();
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			AddChildrenToList(ref frontIgnoreList, allLegStructures[i].leg.transform.parent);
			AddChildrenToList(ref backIgnoreList, allLegStructures[i].leg.transform.parent);
		}
		GameObject tail = GetComponent<DogLooks>().tail;
		AddChildrenToList(ref frontIgnoreList, tail.transform);
		AddChildrenToList(ref backIgnoreList, tail.transform);
		AddChildrenToList(ref frontIgnoreList, bodyFront.transform);
	}

	private void AddChildrenToList(ref List<GameObject> listRef, Transform parent)
	{
		for (int i = 0; i < parent.childCount; i++)
		{
			listRef.Add(parent.GetChild(i).gameObject);
			AddChildrenToList(ref listRef, parent.GetChild(i));
		}
	}

	private void Update()
	{
		CheckBuckUpdate();
		ProcessBuckUpdate();
	}

	private void FixedUpdate()
	{
		ProcessBuckFixedUpdate();
	}

	public void LockBucks()
	{
		bucksLocked = true;
	}

	public void UnlockBucks()
	{
		bucksLocked = false;
	}

	public void RequestContinuousBucking()
	{
		continuousBucks = true;
	}

	public void StopContinuousBucking()
	{
		continuousBucks = false;
	}

	private void ProcessBuckUpdate()
	{
		if (isBucking && !continuousBucks)
		{
			CheckDamp();
		}
	}

	private void CheckBuckUpdate()
	{
		if (isBucking || bucksLocked)
		{
			return;
		}
		if (checkedBuckLastFrame)
		{
			checkedBuckLastFrame = false;
			if (frontHitTop || backHitTop)
			{
				collisionTimeCurrentTop += Time.deltaTime;
			}
			if (frontHitBot || backHitBot)
			{
				collisionTimeCurrentBot += Time.deltaTime;
			}
			return;
		}
		checkedBuckLastFrame = true;
		if (continuousBucks)
		{
			RequestBuck();
			return;
		}
		backHitTop = false;
		frontHitTop = false;
		backHitBot = false;
		frontHitBot = false;
		float x = base.transform.root.localScale.x;
		bool collisionIsStageLayer = false;
		if (ObjectStatusUtil.CheckTopCollision(bodyFront, ref frontIgnoreList, ref collisionIsStageLayer, additionalOffset, x, checkPhysicsPlants: false, checkStage: false, !brainRef.IsGhost()) && controllerRef.AnyLegsForSegmentGrounded(bodyFront))
		{
			frontHitTop = true;
		}
		else if (ObjectStatusUtil.CheckTopCollision(bodyBack, ref backIgnoreList, ref collisionIsStageLayer, additionalOffset, x, checkPhysicsPlants: false, checkStage: false, !brainRef.IsGhost()) && controllerRef.AnyLegsForSegmentGrounded(bodyBack))
		{
			backHitTop = true;
		}
		else if (ObjectStatusUtil.CheckBotCollision(bodyFront, ref frontIgnoreList, ref collisionIsStageLayer, additionalOffset, x, checkPhysicsPlants: false, checkStage: false, !brainRef.IsGhost()))
		{
			frontHitBot = true;
		}
		else if (ObjectStatusUtil.CheckBotCollision(bodyBack, ref backIgnoreList, ref collisionIsStageLayer, additionalOffset, x, checkPhysicsPlants: false, checkStage: false, !brainRef.IsGhost()))
		{
			backHitBot = true;
		}
		if (frontHitTop || backHitTop)
		{
			collisionTimeCurrentTop += Time.deltaTime;
			if (collisionTimeCurrentTop >= collisionTimeRequiredTop)
			{
				RequestBuck(null, fromCollision: true, collisionIsStageLayer);
			}
			return;
		}
		collisionTimeCurrentTop = 0f;
		if (frontHitBot || backHitBot)
		{
			collisionTimeCurrentBot += Time.deltaTime;
			if (collisionTimeCurrentBot >= collisionTimeRequiredBot)
			{
				RequestBuck(null, fromCollision: true, collisionIsStageLayer);
			}
		}
		else
		{
			collisionTimeCurrentBot = 0f;
		}
	}

	public void RequestBuckStop()
	{
		FinishBuck();
	}

	public bool IsBucking()
	{
		return isBucking;
	}

	public void RequestBuck(BuckFinishedCallback callback = null, bool fromCollision = false, bool collisionIsStageLayer = false, float additionalMultiplier = 1f)
	{
		if (isBucking)
		{
			callback?.Invoke();
			return;
		}
		customMultiplier = additionalMultiplier;
		curveTime = 0f;
		isBucking = true;
		noCollisionCount = 0f;
		if (fromCollision && !collisionIsStageLayer)
		{
			brainRef.OnBellyBackCollisionStart();
		}
		callback?.Invoke();
	}

	private void ProcessBuckFixedUpdate()
	{
		if (isBucking)
		{
			if (curveTime < maxCurveTime)
			{
				AddTorque();
			}
			curveTime += Time.fixedDeltaTime;
			if (curveTime >= maxCurveTime + additionalWaitTime)
			{
				FinishBuck();
			}
		}
	}

	private void CheckDamp()
	{
		float x = base.transform.root.localScale.x;
		bool flag = false;
		bool collisionIsStageLayer = false;
		if (ObjectStatusUtil.CheckTopCollision(bodyFront, ref frontIgnoreList, ref collisionIsStageLayer, additionalOffset, x, checkPhysicsPlants: false, checkStage: false, !brainRef.IsGhost()) && controllerRef.AnyLegsForSegmentGrounded(bodyFront))
		{
			flag = true;
		}
		else if (ObjectStatusUtil.CheckTopCollision(bodyBack, ref backIgnoreList, ref collisionIsStageLayer, additionalOffset, x, checkPhysicsPlants: false, checkStage: false, !brainRef.IsGhost()) && controllerRef.AnyLegsForSegmentGrounded(bodyBack))
		{
			flag = true;
		}
		else if (ObjectStatusUtil.CheckBotCollision(bodyFront, ref frontIgnoreList, ref collisionIsStageLayer, additionalOffset, x, checkPhysicsPlants: false, checkStage: false, !brainRef.IsGhost()))
		{
			flag = true;
		}
		else if (ObjectStatusUtil.CheckBotCollision(bodyBack, ref backIgnoreList, ref collisionIsStageLayer, additionalOffset, x, checkPhysicsPlants: false, checkStage: false, !brainRef.IsGhost()))
		{
			flag = true;
		}
		if (!flag)
		{
			noCollisionCount += Time.fixedDeltaTime;
		}
		else
		{
			noCollisionCount = 0f;
		}
	}

	private void AddTorque()
	{
		Vector3 vector;
		Vector3 vector2;
		if (frontHitTop)
		{
			vector = new Vector3(0f, 0f, CurveUtil.EvaluateAverageCurveWrapperTime(buckCurveBackZ, curveTime, curveTime - Time.fixedDeltaTime));
			vector2 = new Vector3(0f, 0f, CurveUtil.EvaluateAverageCurveWrapperTime(buckCurveFrontZ, curveTime, curveTime - Time.fixedDeltaTime));
		}
		else if (backHitTop)
		{
			vector2 = new Vector3(0f, 0f, CurveUtil.EvaluateAverageCurveWrapperTime(buckCurveBackZ, curveTime, curveTime - Time.fixedDeltaTime));
			vector = new Vector3(0f, 0f, CurveUtil.EvaluateAverageCurveWrapperTime(buckCurveFrontZ, curveTime, curveTime - Time.fixedDeltaTime));
		}
		else if (frontHitBot)
		{
			vector = new Vector3(0f, 0f, CurveUtil.EvaluateAverageCurveWrapperTime(buckCurveBackZ, curveTime, curveTime - Time.fixedDeltaTime)) * bottomBuckMultiplier;
			vector2 = new Vector3(0f, 0f, CurveUtil.EvaluateAverageCurveWrapperTime(buckCurveFrontZ, curveTime, curveTime - Time.fixedDeltaTime)) * bottomBuckMultiplier;
		}
		else
		{
			vector2 = new Vector3(0f, 0f, CurveUtil.EvaluateAverageCurveWrapperTime(buckCurveBackZ, curveTime, curveTime - Time.fixedDeltaTime)) * bottomBuckMultiplier;
			vector = new Vector3(0f, 0f, CurveUtil.EvaluateAverageCurveWrapperTime(buckCurveFrontZ, curveTime, curveTime - Time.fixedDeltaTime)) * bottomBuckMultiplier;
		}
		if (noCollisionCount >= buckDampTimer)
		{
			vector *= noCollisionDampMultiplier;
			vector2 *= noCollisionDampMultiplier;
		}
		float x = base.transform.localScale.x;
		controllerRef.TorqueBody(bodyBack, vector * buckMultiplier * customMultiplier * x, applyLimbCompensation: true, modifyLegStrength: true, useTorqueDamping: false);
		controllerRef.TorqueBody(bodyFront, vector2 * buckMultiplier * customMultiplier * x, applyLimbCompensation: true, modifyLegStrength: true, useTorqueDamping: false);
	}

	private void FinishBuck()
	{
		isBucking = false;
	}
}
