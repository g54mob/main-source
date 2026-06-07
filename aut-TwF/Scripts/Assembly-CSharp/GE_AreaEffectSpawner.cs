using UnityEngine;

public class GE_AreaEffectSpawner : GameplayEffect
{
	private GE_AreaEffectSpawnerData areaEffectSpawnerData;

	private TowerCombatComponent towerCombatComponent;

	protected override void OnInitEffect()
	{
		areaEffectSpawnerData = base.EffectData as GE_AreaEffectSpawnerData;
		towerCombatComponent = base.Owner.GetComponent<TowerCombatComponent>();
		towerCombatComponent.onDamageEnemy += OnDamageEnemy;
	}

	protected override void OnEndEffect()
	{
		towerCombatComponent.onDamageEnemy -= OnDamageEnemy;
	}

	private void OnDamageEnemy(Enemy enemy, Tower tower, FDamageData data, Vector3 damagePosition, bool isMainDamage, object auxData, FDamageReport damageReport)
	{
		if (isMainDamage)
		{
			Vector3 position = Vector3.zero;
			switch (areaEffectSpawnerData.SpawnMode)
			{
			case GE_AreaEffectSpawnerData.ESpawnMode.EnemyPosition:
				position = ((!(enemy != null)) ? damagePosition : enemy.transform.position);
				break;
			case GE_AreaEffectSpawnerData.ESpawnMode.ProjectilePosition:
				position = damagePosition;
				break;
			}
			position.y = 0f;
			Object.Instantiate(areaEffectSpawnerData.AreaEffectPrefab, position, Quaternion.identity).OwnerTower = tower;
		}
	}
}
