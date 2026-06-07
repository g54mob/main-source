using UnityEngine;

public class GE_SplashDamage : GE_Splash
{
	private GE_SplashDamageData splashDamageData;

	private TowerCombatComponent towerCC;

	protected override void OnInitEffect()
	{
		base.OnInitEffect();
		towerCC = base.Owner.GetComponent<TowerCombatComponent>();
		splashDamageData = base.EffectData as GE_SplashDamageData;
	}

	protected override void OnSplash(Enemy enemy, FDamageData data, Vector3 damagePosition)
	{
		base.OnSplash(enemy, data, damagePosition);
		data.damage *= splashDamageData.DamageMultipler;
		towerCC.DoDamageToEnemy(enemy, data, enemy.transform.position, isMainDamage: false);
	}
}
