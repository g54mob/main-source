using System.Collections.Generic;
using UnityEngine;

public class Cannonball : Projectile
{
	[SerializeField]
	private float splitChance;

	public bool splitBall;

	private int bonusHitDamage;

	private int extraDamagePerHit;

	public HashSet<Collider> targetsHit = new HashSet<Collider>();

	protected override void Start()
	{
		if (!splitBall && launchSound != Sound.None)
		{
			SFXManager.instance.PlaySound(launchSound, base.transform.position);
		}
	}

	public void SetSplitChance(float chance)
	{
		splitChance = chance;
	}

	public void SetRange(float range)
	{
		maximumLifeTime = range / speed;
	}

	public void SetSpecialDamage(int extraDmg)
	{
		extraDamagePerHit = extraDmg;
	}

	protected override void FixedUpdate()
	{
		maximumLifeTime -= Time.fixedDeltaTime;
		if (maximumLifeTime < 0f)
		{
			if (detachOnDestruction != null)
			{
				detachOnDestruction.transform.parent = null;
			}
			if (extraFX != null)
			{
				extraFX.OnDetach();
			}
			Object.Destroy(base.gameObject);
		}
		CheckForHits();
		MoveProjectile();
		if (homing)
		{
			AlterCourse();
		}
	}

	protected override void CheckForHits()
	{
		Vector3 position = base.transform.position;
		position.y = 0.25f;
		RaycastHit[] array = Physics.SphereCastAll(position, 0.125f, base.transform.forward, speed * Time.fixedDeltaTime + 0.25f, layermask, QueryTriggerInteraction.Collide);
		if (array.Length != 0)
		{
			RaycastHit[] array2 = array;
			foreach (RaycastHit hit in array2)
			{
				OnHit(hit);
			}
		}
	}

	protected override void OnHit(RaycastHit hit)
	{
		if (!targetsHit.Contains(hit.collider))
		{
			targetsHit.Add(hit.collider);
			IDamageable component = hit.transform.GetComponent<IDamageable>();
			if (component != null)
			{
				DealDamage(component);
				damage += extraDamagePerHit;
			}
			homing = false;
			if (Random.Range(0f, 1f) < splitChance && maximumLifeTime >= 1f)
			{
				GameObject obj = Object.Instantiate(base.gameObject, base.transform.position, base.transform.rotation);
				damage = Mathf.FloorToInt((float)damage * 0.75f);
				damage = Mathf.Max(damage, 1);
				obj.GetComponent<Projectile>().SetStats(shotBy, null, speed, damage, healthDamage, armorDamage, shieldDamage, slowPercent, bleedPercent, burnPercent, poisonPercent, critChance, stunChance);
				Cannonball component2 = obj.GetComponent<Cannonball>();
				splitChance *= 0.5f;
				component2.splitBall = true;
				component2.SetSplitChance(splitChance);
				component2.SetRange(maximumLifeTime * speed);
				component2.SetSpecialDamage(extraDamagePerHit);
				component2.RandomizeTrajectory();
				component2.homing = false;
				component2.targetsHit = targetsHit;
				base.transform.localScale *= 0.75f;
				component2.transform.localScale *= 0.75f;
			}
			RandomizeTrajectory();
		}
	}

	public void RandomizeTrajectory()
	{
		Vector3 vector = base.transform.forward * 10f + base.transform.position + new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));
		vector.y = 0.5f;
		Quaternion rotation = Quaternion.LookRotation(0.25f * Vector3.up + vector - base.transform.position, Vector3.up);
		base.transform.rotation = rotation;
	}
}
