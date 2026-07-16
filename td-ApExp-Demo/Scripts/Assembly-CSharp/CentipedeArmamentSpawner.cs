using System.Collections.Generic;
using UnityEngine;

public class CentipedeArmamentSpawner : CentipedeArmament
{
	[SerializeField]
	private Transform spawnPointTf;

	private float spawnTimer;

	private float spawnDelay = 0.59f;

	private bool isReadyToSpawn;

	private List<EnemyBase> spawns;

	private new void Awake()
	{
		base.Awake();
		spawns = new List<EnemyBase>();
	}

	private void Update()
	{
		spawnTimer -= Time.deltaTime;
		if (isReadyToSpawn && spawnTimer <= 0f)
		{
			EnemyBase component = Object.Instantiate(spawnPrefab, spawnPointTf.position, base.transform.parent.rotation).GetComponent<EnemyBase>();
			EnemyManager.Instance.RegisterEnemy(component);
			spawns.Add(component);
			component.IsEnemy = enemyCentipede.IsEnemy;
			isReadyToSpawn = false;
		}
	}

	public override void Aim()
	{
	}

	public override void Fire()
	{
		base.Anim.Play("Launch", 0, 0f);
		isReadyToSpawn = true;
		spawnTimer = spawnDelay;
	}

	public override void OnSegmentFactionChanged()
	{
		foreach (EnemyBase spawn in spawns)
		{
			spawn.IsEnemy = enemyCentipede.IsEnemy;
		}
	}
}
