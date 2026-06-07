using UnityEngine;

public class GE_StacksConsumerDamage : GE_StacksConsumer
{
	private GE_StacksConsumerDamageData stacksConsumerDamageData;

	private new TowerCombatComponent towerCombatComponent;

	protected override void OnInitEffect()
	{
		base.OnInitEffect();
		towerCombatComponent = base.Owner.GetComponent<TowerCombatComponent>();
		stacksConsumerDamageData = base.EffectData as GE_StacksConsumerDamageData;
	}

	protected override void OnHit(Enemy enemy, FDamageData data, Vector3 damagePosition, int stacks)
	{
		if (stacks <= 0)
		{
			return;
		}
		data.damage = stacks * stacksConsumerDamageData.DamagePerStack;
		data.healthMultiplier = stacksConsumerDamageData.HealthMultiplier;
		data.armorMultiplier = stacksConsumerDamageData.ArmorMultiplier;
		data.shieldMultiplier = stacksConsumerDamageData.ShieldMultiplier;
		towerCombatComponent.DoDamageToEnemy(enemy, data, enemy.transform.position, isMainDamage: false);
		if (stacksConsumerDamageData.SplashRadius > 0f)
		{
			Collider[] array = Physics.OverlapSphere(damagePosition, stacksConsumerDamageData.SplashRadius, LayerMask.GetMask("Enemy"));
			foreach (Collider collider in array)
			{
				if (collider.gameObject.tag == "Enemy" && collider.TryGetComponent<Enemy>(out var component) && (stacksConsumerDamageData.AffectsTarget || component != enemy) && towerCombatComponent.CanTargetEnemy(component))
				{
					towerCombatComponent.DoDamageToEnemy(component, data, enemy.transform.position, isMainDamage: false);
				}
			}
		}
		if ((bool)stacksConsumerDamageData.VfxPrefab)
		{
			Object.Instantiate(stacksConsumerDamageData.VfxPrefab, damagePosition, Quaternion.identity, null);
		}
		AudioSystem.Instance.PlaySound3D(stacksConsumerDamageData.Sound, damagePosition, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f);
		if (stacksConsumerDamageData.Debug)
		{
			GameObject gameObject = Object.Instantiate(stacksConsumerDamageData.DebugObject, damagePosition + Vector3.up * 0.2f, Quaternion.identity);
			gameObject.transform.localScale = new Vector3(1f, 0f, 1f) * stacksConsumerDamageData.SplashRadius * 2f;
			Object.Destroy(gameObject, 0.5f);
		}
	}
}
