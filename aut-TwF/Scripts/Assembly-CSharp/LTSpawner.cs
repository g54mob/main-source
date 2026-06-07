using System;
using LightTower;
using UnityEngine;

public class LTSpawner : Spawner, ISavable
{
	[Header("LT Spawner")]
	[SerializeField]
	private PathTile startPathTile;

	private int enemyEssencePerEnemy;

	[Savable("deadSpawnedObjects", true, false)]
	private int deadSpawnedObjects;

	public PathTile StartPathTile
	{
		get
		{
			return startPathTile;
		}
		set
		{
			startPathTile = value;
			this.onStartPathTileChanged?.Invoke();
		}
	}

	public event Action<LTSpawner> onAllSpanwdObjectsDead;

	public event Action onStartPathTileChanged;

	public override GameObject SpawnObject()
	{
		GameObject obj = base.SpawnObject();
		obj.transform.SetParent(null);
		float num = base.Config.CalculateEnemyEssencePerEnemy();
		enemyEssencePerEnemy = (int)num + ((UnityEngine.Random.value <= num - (float)(int)num) ? 1 : 0);
		obj.GetComponent<Enemy>().EnemyEssenceDropped = enemyEssencePerEnemy;
		return obj;
	}

	protected override GameObject SpawnObjectWithSpawnTransform(SpawnerPosition.SpawnTransform spawnTransform)
	{
		GameObject obj = base.SpawnObjectWithSpawnTransform(spawnTransform);
		obj.GetComponent<Enemy>().EnemyMovement.CurrentPathTile = (spawnTransform as SpawnerPosition_PathTile.LTSpawnTransform).pathTile;
		return obj;
	}

	protected override void ResetSpawner()
	{
		base.ResetSpawner();
		deadSpawnedObjects = 0;
	}

	public bool AreAllSpawnedObjectsDead()
	{
		if (HasEndedSpawning())
		{
			return deadSpawnedObjects >= spawnedObjectsAmount;
		}
		return false;
	}

	private void OnSpawnedObjectDies(CombatComponent combatComponent)
	{
		combatComponent.onDie -= OnSpawnedObjectDies;
		deadSpawnedObjects++;
		if (AreAllSpawnedObjectsDead())
		{
			this.onAllSpanwdObjectsDead?.Invoke(this);
		}
	}
}
