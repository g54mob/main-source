using UnityEngine;

public class GE_Splash : GameplayEffect
{
	private GE_SplashData splashData;

	private TowerCombatComponent towerCombatComponent;

	protected override void OnInitEffect()
	{
		splashData = base.EffectData as GE_SplashData;
		towerCombatComponent = base.Owner.GetComponent<TowerCombatComponent>();
		towerCombatComponent.onDamageEnemy += OnDamageEnemy;
	}

	protected override void OnEndEffect()
	{
		towerCombatComponent.onDamageEnemy -= OnDamageEnemy;
	}

	private void OnDamageEnemy(Enemy enemy, Tower tower, FDamageData data, Vector3 damagePosition, bool isMainDamage, object auxData, FDamageReport damageReport)
	{
		if (!isMainDamage)
		{
			return;
		}
		if (splashData.Debug)
		{
			Object.Destroy(Object.Instantiate(splashData.DebugObject, damagePosition + Vector3.up * 0.2f, Quaternion.identity), 0.5f);
		}
		Collider[] array = Physics.OverlapSphere(damagePosition, splashData.SplashRadius);
		foreach (Collider collider in array)
		{
			if (collider.gameObject.tag == "Enemy" && collider.TryGetComponent<Enemy>(out var component) && (splashData.AffectTarget || component != enemy) && IsEnemyValid(component))
			{
				OnSplash(component, data, damagePosition);
			}
		}
		if ((bool)splashData.SpalshVFX)
		{
			Object.Instantiate(splashData.SpalshVFX, Vector3.Scale(damagePosition, new Vector3(1f, 0f, 1f)), Quaternion.identity, null);
		}
	}

	protected bool IsEnemyValid(Enemy enemy)
	{
		if (splashData.CustomValidEnemies)
		{
			return (enemy.EnemyType & splashData.ValidEnemyTypes) > (Enemy.EEnemyType)0;
		}
		return towerCombatComponent.CanTargetEnemy(enemy);
	}

	protected virtual void OnSplash(Enemy enemy, FDamageData data, Vector3 damagePosition)
	{
	}
}
