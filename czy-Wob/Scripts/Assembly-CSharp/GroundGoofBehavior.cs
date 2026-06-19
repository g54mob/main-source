using System.Collections.Generic;
using UnityEngine;

public class GroundGoofBehavior : MonoBehaviour
{
	public delegate void GoofFinishedCallback();

	private bool isGoofing;

	private float currentTimer;

	private float randomGoofChance = 0.5f;

	private float randomGoofCheckTimer = 0.75f;

	private float currentGoofMultiplier = 1f;

	private float maxGoofMultiplier = 2f;

	private float goofMultiplierIncrement = 0.25f;

	private float bodyTorqueMultiplier = 5f;

	private AnimationCurveWrapper legCurveZ;

	private float currentGoofTimer;

	private List<GameObject> allLegs = new List<GameObject>();

	private List<GameObject> frontLegs = new List<GameObject>();

	private bool fullGoof;

	private float fullGoofChance = 0.5f;

	private BodyBuck buckRef;

	private LegController controllerRef;

	private void Awake()
	{
		controllerRef = base.gameObject.GetComponent<LegController>();
		allLegs = controllerRef.GetAllLegs();
		frontLegs = controllerRef.GetLegsForBodySegment(controllerRef.bodyFront);
		CreateCurves();
	}

	private void Update()
	{
		if (isGoofing)
		{
			CheckRandomGoof();
		}
	}

	private void FixedUpdate()
	{
		if (isGoofing)
		{
			CheckCurrentGoof();
		}
	}

	public void RequestGoof(GoofFinishedCallback callback = null)
	{
		if (!isGoofing)
		{
			if (buckRef == null)
			{
				buckRef = base.gameObject.GetComponent<BodyBuck>();
			}
			StartTheGoof();
			callback?.Invoke();
		}
	}

	public void RequestGoofEnd()
	{
		if (isGoofing)
		{
			StopTheGoof();
		}
	}

	private void CreateCurves()
	{
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.AddKey(0f, 0f);
		animationCurve.AddKey(0.5f, 200f);
		animationCurve.AddKey(0.75f, -300f);
		animationCurve.AddKey(1f, 0f);
		legCurveZ = new AnimationCurveWrapper(animationCurve);
	}

	private void CheckRandomGoof()
	{
		currentTimer += Time.deltaTime;
		if (currentTimer >= randomGoofCheckTimer)
		{
			currentTimer = 0f;
			if (Random.value <= randomGoofChance)
			{
				StartGoofCurve();
			}
		}
	}

	private void CheckCurrentGoof()
	{
		if (currentGoofTimer < legCurveZ.GetTotalTime())
		{
			FollowCurve();
		}
	}

	private void StartTheGoof()
	{
		isGoofing = true;
		currentTimer = 0f;
		StartGoofCurve();
		controllerRef.FreezeMotion();
	}

	private void StopTheGoof()
	{
		isGoofing = false;
		controllerRef.UnfreezeMotion();
	}

	private void StartGoofCurve()
	{
		if (controllerRef.AnyLegGrounded())
		{
			buckRef.RequestBuck();
			return;
		}
		fullGoof = Random.value <= fullGoofChance;
		if (currentGoofTimer > 0f && currentGoofTimer < legCurveZ.GetTotalTime())
		{
			currentGoofMultiplier += goofMultiplierIncrement;
			if (currentGoofMultiplier > maxGoofMultiplier)
			{
				currentGoofMultiplier = maxGoofMultiplier;
			}
		}
		else
		{
			currentGoofMultiplier = 1f;
		}
		currentGoofTimer = 0f;
	}

	private void FollowCurve()
	{
		Vector3 vector = CurveUtil.EvaluateAverageCurveWrapperTime(legCurveZ, currentGoofTimer, currentGoofTimer - Time.fixedDeltaTime) * base.transform.forward;
		if (fullGoof)
		{
			for (int i = 0; i < allLegs.Count; i++)
			{
				controllerRef.TorqueLeg(allLegs[i], vector * currentGoofMultiplier);
			}
		}
		else
		{
			for (int j = 0; j < frontLegs.Count; j++)
			{
				controllerRef.TorqueLeg(frontLegs[j], vector * currentGoofMultiplier);
			}
		}
		if (vector.magnitude > 0f)
		{
			vector *= -1f;
		}
		controllerRef.TorqueBody(controllerRef.bodyFront, vector * bodyTorqueMultiplier, applyLimbCompensation: true, modifyLegStrength: true, useTorqueDamping: true, rawTorque: true);
		currentGoofTimer += Time.fixedDeltaTime;
	}
}
