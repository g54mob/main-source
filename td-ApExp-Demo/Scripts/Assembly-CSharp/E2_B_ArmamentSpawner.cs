using System.Collections.Generic;
using UnityEngine;

public class E2_B_ArmamentSpawner : E2_B_Armament
{
	private List<EnemyBase> spawns;

	[SerializeField]
	public ExplodeSprite hatchTop;

	[SerializeField]
	public ExplodeSprite hatchBottom;

	private E2_B_BossAController bossA => boss as E2_B_BossAController;

	private new void Awake()
	{
		base.Awake();
		spawns = new List<EnemyBase>();
	}

	private void Update()
	{
	}

	public override void Aim()
	{
	}

	public override void PlaySpawnAnim()
	{
		base.Anim.SetTrigger("Spawn");
	}

	public void Spawn()
	{
		InstantiateDrone();
	}

	public GameObject InstantiateDrone()
	{
		GameObject obj = Object.Instantiate(spawnPrefab, base.transform.position, base.transform.parent.rotation, null);
		E2_B_HealDrone component = obj.GetComponent<E2_B_HealDrone>();
		component.HealthComponent.SetMaxHealth(bossA.DroneHealth);
		component.healAmount = bossA.HealAmount;
		component.healTime = bossA.HealInterval;
		component.IsEnemy = boss.IsEnemy;
		E2_B_BossBController e2_B_BossBController = bossA.GetOtherBossController() as E2_B_BossBController;
		component.SetTargetTf(e2_B_BossBController.GetHealingDronePosition());
		component.SetTarget(e2_B_BossBController);
		EnemyManager.Instance.RegisterEnemy(component);
		spawns.Add(component);
		return obj;
	}

	public override void OnBossFactionChanged()
	{
		foreach (EnemyBase spawn in spawns)
		{
			if ((object)spawn != null)
			{
				spawn.IsEnemy = boss.IsEnemy;
			}
		}
	}
}
