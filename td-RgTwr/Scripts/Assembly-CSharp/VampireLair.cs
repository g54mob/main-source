using System;
using System.Collections;
using UnityEngine;

public class VampireLair : Tower
{
	[SerializeField]
	private GameObject[] bloodTrails;

	private float repairChance;

	protected override void AimTurret()
	{
	}

	public override void SetStats()
	{
		base.SetStats();
		repairChance = (float)TowerManager.instance.GetSpecial1(towerType) * 0.06f;
	}

	protected override void Fire()
	{
		if (consumesMana)
		{
			int manaCost = (int)((float)base.damage * manaConsumptionRate);
			if (!ResourceManager.instance.CheckMana(manaCost))
			{
				return;
			}
			ResourceManager.instance.SpendMana(manaCost);
		}
		Vector3 position = base.transform.position;
		position.y = 0f;
		Collider[] array = Physics.OverlapSphere(position, base.range, enemyLayerMask, QueryTriggerInteraction.Collide);
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetComponent<IDamageable>()?.TakeDamage(towerType, base.damage, base.healthDamage, base.armorDamage, base.shieldDamage, base.slowPercent, base.bleedPercent, base.burnPercent, base.poisonPercent, base.critChance, base.stunChance);
		}
		for (int j = 0; j < bloodTrails.Length; j++)
		{
			StartCoroutine(DrawBlood(bloodTrails[j]));
		}
	}

	private IEnumerator DrawBlood(GameObject trail)
	{
		float startValue = UnityEngine.Random.Range(-(float)Math.PI, (float)Math.PI);
		for (float i = 0f; i <= (float)Math.PI * 2f; i += Time.deltaTime)
		{
			trail.transform.position = new Vector3(base.transform.position.x + Mathf.Sin(startValue + i) * base.range * Mathf.Max(((float)Math.PI - i) / (float)Math.PI, 0f), 0.75f, base.transform.position.z + Mathf.Cos(startValue + i) * base.range * Mathf.Max(((float)Math.PI - i) / (float)Math.PI, 0f));
			yield return new WaitForEndOfFrame();
		}
	}

	public void Repair()
	{
		if (repairChance > 0f && UnityEngine.Random.Range(0f, 1f) < repairChance)
		{
			GameManager.instance.RepairTower(10);
		}
	}
}
