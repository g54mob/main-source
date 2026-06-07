using UnityEngine;

public class GE_LifeBasedDamage : GameplayEffect
{
	private GE_LifeBasedDamageData lifeBasedDamageData;

	private TowerCombatComponent towerCombatComponent;

	protected override void OnInitEffect()
	{
		base.OnInitEffect();
		lifeBasedDamageData = base.EffectData as GE_LifeBasedDamageData;
		towerCombatComponent = base.Owner.GetComponent<TowerCombatComponent>();
		towerCombatComponent.onPreDamageEnemy += OnPreDamageEnemy;
	}

	protected override void OnEndEffect()
	{
		towerCombatComponent.onPreDamageEnemy -= OnPreDamageEnemy;
	}

	private bool CheckTreshold(Enemy enemy)
	{
		if (!enemy)
		{
			return false;
		}
		float num = enemy.CombatComponent.Life / enemy.CombatComponent.MaxLife;
		return lifeBasedDamageData.TresholdMode switch
		{
			GE_LifeBasedDamageData.EMode.LessThan => num <= lifeBasedDamageData.EnemyLifePercentageTreshold, 
			GE_LifeBasedDamageData.EMode.MoreThan => num >= lifeBasedDamageData.EnemyLifePercentageTreshold, 
			_ => true, 
		};
	}

	private void OnPreDamageEnemy(Enemy enemy, Tower tower, FDamageData data, Vector3 vector, bool isMainDamage, object customData)
	{
		if (CheckTreshold(enemy))
		{
			data.damage *= lifeBasedDamageData.DamageMultipler;
		}
	}
}
