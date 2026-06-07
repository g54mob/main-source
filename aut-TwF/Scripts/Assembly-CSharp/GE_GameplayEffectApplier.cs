using UnityEngine;

public class GE_GameplayEffectApplier : GameplayEffect
{
	private GE_GameplayEffectApplierData gameplayEffectApplierData;

	private TowerCombatComponent towerCombatComponent;

	private bool hasOverTimeAutoAttack;

	private float lastApplyTime;

	private Enemy lastApplyEnemy;

	protected override void OnInitEffect()
	{
		gameplayEffectApplierData = base.EffectData as GE_GameplayEffectApplierData;
		hasOverTimeAutoAttack = base.Owner.GetComponent<AbilityManager>().GetAutoAttackAbility() is AutoAttack_overTime;
		towerCombatComponent = base.Owner.GetComponent<TowerCombatComponent>();
		towerCombatComponent.onDamageEnemy += OnDamageEnemy;
	}

	protected override void OnEndEffect()
	{
		towerCombatComponent.onDamageEnemy -= OnDamageEnemy;
	}

	private void OnDamageEnemy(Enemy enemy, Tower tower, FDamageData data, Vector3 damagePosition, bool isMainDamage, object auxData, FDamageReport damageReport)
	{
		if ((bool)enemy && isMainDamage && (!hasOverTimeAutoAttack || gameplayEffectApplierData.MinIntervalPerEnemy == 0f || lastApplyEnemy != enemy || Time.time - lastApplyTime > gameplayEffectApplierData.MinIntervalPerEnemy))
		{
			enemy.GetComponent<GameplayEffectsComponent>().ApplyEffect(gameplayEffectApplierData.GEData, gameplayEffectApplierData.StacksToApply * base.CurrentStacks);
			lastApplyEnemy = enemy;
			lastApplyTime = Time.time;
		}
	}
}
