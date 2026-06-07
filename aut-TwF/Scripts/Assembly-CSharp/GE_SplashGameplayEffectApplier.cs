using UnityEngine;

public class GE_SplashGameplayEffectApplier : GE_Splash
{
	private GE_SplashGameplayEffectApplierData splashGameplayEffectApplierData;

	private TowerCombatComponent towerCombatComponent;

	protected override void OnInitEffect()
	{
		base.OnInitEffect();
		splashGameplayEffectApplierData = base.EffectData as GE_SplashGameplayEffectApplierData;
	}

	protected override void OnSplash(Enemy enemy, FDamageData data, Vector3 damagePosition)
	{
		base.OnSplash(enemy, data, damagePosition);
		enemy.GetComponent<GameplayEffectsComponent>().ApplyEffect(splashGameplayEffectApplierData.GEData, splashGameplayEffectApplierData.StacksToApply);
	}
}
