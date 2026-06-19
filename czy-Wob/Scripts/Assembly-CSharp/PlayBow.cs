using System.Collections.Generic;
using UnityEngine;

public class PlayBow : MonoBehaviour
{
	public delegate void BowFinishedCallback();

	private BowFinishedCallback currentCallback;

	private bool isBowing;

	private Vector3 bowRestoreMod = new Vector3(0f, 0f, 0f);

	private float curveTime;

	private float maxCurveTime;

	private Vector3 targetLegRot = new Vector3(0f, 0f, 180f);

	private Vector3 targetLegRot2 = new Vector3(0f, 0f, 0f);

	private Vector3 targetBackLegRot = new Vector3(0f, 0f, 320f);

	private Vector3 targetBodyBackRot = new Vector3(0f, 0f, 45f);

	private Vector3 targetBodyFrontRot = new Vector3(0f, 0f, 320f);

	private Vector3 targetBodyFrontRot2 = new Vector3(0f, 0f, 25f);

	private Vector3 motionMultiplier = new Vector3(0.25f, 0f, 1f);

	private float waitTime = 0.25f;

	private float legRotTime = 0.5f;

	private float legRotTime2 = 0.1f;

	private float bodyRotTime = 0.5f;

	private float bodyRotTime2 = 0.5f;

	private LegController controllerRef;

	private WalkController walkControllerRef;

	private void Awake()
	{
		controllerRef = GetComponent<LegController>();
		walkControllerRef = GetComponent<WalkController>();
	}

	private void FixedUpdate()
	{
		if (isBowing)
		{
			curveTime += Time.fixedDeltaTime;
			if (curveTime >= maxCurveTime)
			{
				FinishBow();
			}
		}
	}

	public void RequestPlayBow(BowFinishedCallback callback = null)
	{
		if (isBowing)
		{
			return;
		}
		currentCallback = callback;
		isBowing = true;
		List<SmartMotion> list = new List<SmartMotion>();
		SmartMotion smartMotion = controllerRef.bodyBack.AddComponent<SmartMotion>();
		smartMotion.SetController(controllerRef);
		smartMotion.setIsMovingLimb(limbVal: false);
		smartMotion.AddKeyframe(bodyRotTime, targetBodyBackRot);
		list.Add(smartMotion);
		SmartMotion smartMotion2 = controllerRef.bodyFront.AddComponent<SmartMotion>();
		smartMotion2.SetController(controllerRef);
		smartMotion2.setIsMovingLimb(limbVal: false);
		smartMotion2.AddKeyframe(bodyRotTime, targetBodyFrontRot);
		smartMotion2.AddKeyframe(bodyRotTime, targetBodyFrontRot);
		smartMotion2.AddKeyframe(bodyRotTime2, targetBodyFrontRot2);
		list.Add(smartMotion2);
		float num = 0f;
		float num2 = 1f;
		List<GameObject> legsForBodySegment = controllerRef.GetLegsForBodySegment(controllerRef.bodyFront);
		for (int i = 0; i < legsForBodySegment.Count; i++)
		{
			SmartMotion smartMotion3 = legsForBodySegment[i].AddComponent<SmartMotion>();
			smartMotion3.SetController(controllerRef);
			smartMotion3.setIsMovingLimb(limbVal: true);
			smartMotion3.AddKeyframe(waitTime, Vector3.zero, considerX: false, considerY: false, considerZ: false);
			smartMotion3.AddKeyframe(legRotTime, targetLegRot / Mathf.Max(num, 1f));
			smartMotion3.AddKeyframe(legRotTime2, targetLegRot2 / Mathf.Max(num, 1f));
			list.Add(smartMotion3);
			if (i % 2 != 0 && num < num2)
			{
				num += 0.5f;
			}
		}
		List<GameObject> legsForBodySegment2 = controllerRef.GetLegsForBodySegment(controllerRef.bodyBack);
		for (int j = 0; j < legsForBodySegment2.Count; j++)
		{
			legsForBodySegment2[j].GetComponent<Limb>().PlantLeg();
			SmartMotion smartMotion4 = legsForBodySegment2[j].AddComponent<SmartMotion>();
			smartMotion4.SetController(controllerRef);
			smartMotion4.setIsMovingLimb(limbVal: true);
			smartMotion4.AddKeyframe(waitTime, Vector3.zero, considerX: false, considerY: false, considerZ: false);
			smartMotion4.AddKeyframe(legRotTime, targetBackLegRot / (j + 1));
			smartMotion4.AddKeyframe(legRotTime2, targetBackLegRot / (j + 1));
			list.Add(smartMotion4);
		}
		for (int k = 0; k < list.Count; k++)
		{
			list[k].StartMotion(motionMultiplier);
		}
		maxCurveTime = waitTime + legRotTime + legRotTime2;
		StartBow();
	}

	private void StartBow()
	{
		curveTime = 0f;
		isBowing = true;
		controllerRef.SetRestoreMod(bowRestoreMod);
		controllerRef.LockStabilitySteps();
		walkControllerRef.IgnoreFacing();
	}

	private void FinishBow()
	{
		List<GameObject> legsForBodySegment = controllerRef.GetLegsForBodySegment(controllerRef.bodyBack);
		for (int i = 0; i < legsForBodySegment.Count; i++)
		{
			legsForBodySegment[i].GetComponent<Limb>().UnplantLeg();
		}
		isBowing = false;
		controllerRef.ClearRestoreMod();
		controllerRef.UnlockStabilitySteps();
		walkControllerRef.RestoreFacing();
		if (currentCallback != null)
		{
			currentCallback();
			currentCallback = null;
		}
	}
}
