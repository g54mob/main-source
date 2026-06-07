using LightTower;
using UnityEngine;

public class EnemyAbility_spawnEnemies : EnemyAbility
{
	[SerializeField]
	private LTSpawner[] spawnerPrefabs;

	private EnemyMovement enemyMovement;

	protected override void Awake()
	{
		base.Awake();
		enemyMovement = abilityManager.gameObject.GetComponent<EnemyMovement>();
	}

	protected override void DoAbilityEffect(FActiveAbilityInputData inputData)
	{
		if (enemyMovement.CurrentPathTile?.NextPathTiles != null && enemyMovement.CurrentPathTile.NextPathTiles.Count > 0)
		{
			LTSpawner[] array = spawnerPrefabs;
			for (int i = 0; i < array.Length; i++)
			{
				LTSpawner lTSpawner = Object.Instantiate(array[i], base.transform.position, base.transform.rotation);
				lTSpawner.StartPathTile = abilityManager.gameObject.GetComponent<EnemyMovement>().CurrentPathTile.NextPathTiles[0];
				LTFunctionLibrary.GetSpawnersManager().RegisterExternalSpawner(lTSpawner);
				lTSpawner.StartSpawner();
			}
		}
	}
}
