using System;
using System.Collections;
using UnityEngine;

public class RocketMotor : RocketAttachment
{
	[Serializable]
	public struct MotorRecipe
	{
		public MotorCraftingController.MotorCraftingMethod motorCraftingMethod;

		public GameObject[] ingredients;

		public int[] requiredGrams;
	}

	public MotorRecipe[] motorRecipe;

	public Food.Ingredient[] ingredients;

	public float trustPow;

	public float launchDuration = 1.5f;

	public AnimationCurve powerCurve;

	public RocketType type;

	public ParticleSystem ps;

	public Material liquidMaterial;

	public Color liquidColor;

	public MeshRenderer tube;

	public Material[] tubeMats;

	public SkinnedMeshRenderer currentPro;

	public SkinnedMeshRenderer[] propellents;

	private bool isInit;

	private void Awake()
	{
		OnAwake();
	}

	private void Start()
	{
		OnStart();
		if (!(rocket != null))
		{
			return;
		}
		rocket.rocketMotor = base.gameObject;
		if (type == RocketType.Gunpowder)
		{
			if (GameManager.S.rocketPerkList[2] && !isInit)
			{
				trustPow *= 1.2f;
				launchDuration *= 1.2f;
			}
			isInit = true;
		}
		else if (type == RocketType.Water)
		{
			ParticleSystem.MainModule main = rocket.ps.main;
			main.startColor = liquidColor;
			StartCoroutine(DelayedUpdateLiquidMaterial());
		}
		rocket.trustPow = trustPow;
		rocket.launchDuration = launchDuration;
		rocket.myCurve = powerCurve;
		StartCoroutine(DelayedUpdatePowerCurve());
	}

	public void InitCustomMotor(string name, float newMass, float newThrustpow, float newDuration, AnimationCurve newCurve, int proIndex, int tubeIndex, Material proMat)
	{
		partName = name;
		if (!(rocket != null))
		{
			return;
		}
		rocketRb.mass -= mass;
		mass = newMass;
		rocketRb.mass += mass;
		trustPow = newThrustpow;
		launchDuration = newDuration;
		if (GameManager.S.rocketPerkList[2])
		{
			trustPow *= 1.2f;
			launchDuration *= 1.2f;
		}
		rocket.trustPow = trustPow;
		rocket.launchDuration = launchDuration;
		powerCurve = newCurve;
		rocket.myCurve = powerCurve;
		StartCoroutine(DelayedUpdatePowerCurve());
		for (int i = 0; i < propellents.Length; i++)
		{
			if (proIndex == i)
			{
				propellents[i].gameObject.SetActive(value: true);
				currentPro = propellents[i];
			}
			else
			{
				propellents[i].gameObject.SetActive(value: false);
			}
		}
		tube.material = tubeMats[tubeIndex];
		currentPro.material = proMat;
		mainImage = null;
	}

	private IEnumerator DelayedUpdateLiquidMaterial()
	{
		yield return null;
		rocket.body.liquid.material = liquidMaterial;
	}

	private IEnumerator DelayedUpdatePowerCurve()
	{
		yield return null;
		if (rocket.body != null)
		{
			rocket.body.PowerCurveUpdate();
		}
	}

	private void Update()
	{
	}
}
