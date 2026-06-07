using System.Collections;
using UnityEngine;

public class RocketBody : RocketAttachment
{
	public Com com;

	public RocketType type;

	public BodySize size;

	public Vector3 nozzlePos;

	public Transform headPos;

	public Transform motorPos;

	public Transform camPos;

	public float powTimeBonus;

	public MeshRenderer liquid;

	public MaterialPropertyBlock mpb;

	public Material[] possibleColors;

	public CustomCrafitng customCrafting;

	protected override float liftMultiplier => 0f;

	protected override float dragMultiplier => 0.5f;

	protected override float momentMultiplier => 1f;

	private void Awake()
	{
		OnAwake();
	}

	private void Start()
	{
		OnStart();
		mpb = new MaterialPropertyBlock();
		partType = 1;
		com = Com.Middle;
		if (rocket != null)
		{
			rocket.body = this;
			rocket.rocketBody = base.gameObject;
			rocket.bounsLaunchDuration = powTimeBonus;
			PowerCurveUpdate();
			if (headPos != null)
			{
				rocket.rocketHeadPos.position = headPos.position;
				rocket.rocketHeadPos.rotation = headPos.rotation;
				rocket.rocketHeadPos.localScale = headPos.localScale;
			}
			if (motorPos != null)
			{
				rocket.motorPos.position = motorPos.position;
				rocket.motorPos.rotation = motorPos.rotation;
				rocket.motorPos.localScale = motorPos.localScale;
			}
			if (camPos != null)
			{
				rocket.camPos.position = camPos.position;
				rocket.camPos.rotation = camPos.rotation;
			}
		}
		if (rocket.ps != null && type == RocketType.Gunpowder)
		{
			rocket.tr = rocket.ps.GetComponentInChildren<TrailRenderer>();
			rocket.tr.emitting = false;
		}
	}

	public void SpendLiquid(float value)
	{
		if (type == RocketType.Water)
		{
			liquid.GetPropertyBlock(mpb);
			float value2 = Mathf.Lerp(0.45f, 0.75f, value);
			mpb.SetFloat("_FillAmount", value2);
			liquid.SetPropertyBlock(mpb);
		}
	}

	public void PowerCurveUpdate()
	{
		StartCoroutine(DelayedPowerCurveUpdate());
	}

	private IEnumerator DelayedPowerCurveUpdate()
	{
		yield return null;
		if (type == RocketType.Water)
		{
			rocket.StretchCurveOverall(rocket.bounsLaunchDuration + rocket.launchDuration - 1f);
		}
		else
		{
			rocket.StretchCurveOverall(rocket.bounsLaunchDuration + rocket.launchDuration - 1.5f);
		}
	}

	public override void AddForces()
	{
		Quaternion identity = Quaternion.identity;
		force = AerodynamicsForce(identity, rocketRb, base.transform, airDensity, area, length, GameManager.S.windManager.wind);
		if (bounsArea > 0f)
		{
			rocketRb.AddForceAtPosition(force.Force * 0.6f, base.transform.position);
			rocketRb.AddForceAtPosition(force.Force * 0.4f, rocket.head.transform.position);
		}
		else
		{
			rocketRb.AddForceAtPosition(force.Force, base.transform.position);
		}
		rocketRb.AddTorque(force.Torque);
		Debug.DrawRay(base.transform.position, force.Force.normalized * 3f, Color.cyan);
	}
}
