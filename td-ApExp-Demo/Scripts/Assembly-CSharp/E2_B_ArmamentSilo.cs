using System.Collections.Generic;
using UnityEngine;

public class E2_B_ArmamentSilo : E2_B_Armament
{
	[SerializeField]
	private Transform missileSpawn;

	private List<EnemyBase> missiles;

	private Unit TargetUnit;

	private float damage;

	private new void Awake()
	{
		base.Awake();
		missiles = new List<EnemyBase>();
	}

	public override void Fire(float damage)
	{
		this.damage = damage;
		base.Anim.SetTrigger("Launch");
	}

	public void SpawnRocket()
	{
		GameObject obj = Object.Instantiate(spawnPrefab, missileSpawn.position, missileSpawn.rotation);
		EnemyBase component = obj.GetComponent<EnemyBase>();
		component.IsEnemy = boss.IsEnemy;
		DozerMissile component2 = obj.GetComponent<DozerMissile>();
		component2.TargetUnit = TargetUnit;
		component2.damage = damage;
		missiles.Add(component);
	}

	public void SetTarget(Unit t)
	{
		TargetUnit = t;
	}

	public override void OnBossFactionChanged()
	{
		base.OnBossFactionChanged();
		foreach (EnemyBase missile in missiles)
		{
			missile.IsEnemy = boss.IsEnemy;
		}
	}

	public void OnMissileDeath(EnemyBase deadMissile)
	{
		missiles.Remove(deadMissile);
	}
}
