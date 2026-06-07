using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class AreaEffectModule_damage : AreaEffectModule
{
	[SerializeField]
	private float damage;

	[SerializeField]
	private EDamageMultiplier healthDamageMultiplier = EDamageMultiplier.Normal;

	[SerializeField]
	private EDamageMultiplier armorDamageMultiplier = EDamageMultiplier.Normal;

	[SerializeField]
	private EDamageMultiplier shieldDamageMultiplier = EDamageMultiplier.Normal;

	public override string DisplayName => LocalizationSettings.StringDatabase.GetLocalizedString("GameplayEffects", "GE_areaEffectModule_damage_name", null, FallbackBehavior.UseProjectSettings);

	public override string Description
	{
		get
		{
			AreaEffect component = GetComponent<AreaEffect>();
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{ "damage", damage },
				{ "tick-time", component.TickTime },
				{ "duration", component.Duration },
				{
					"enemy-type",
					component.GetAffectedEnemyTypesString()
				}
			};
			return new LocalizedString("GameplayEffects", "GE_areaEffectModule_damage_description").GetLocalizedString(dictionary);
		}
	}

	public override void DoModuleEffect(IEnumerable<Enemy> enemies)
	{
		foreach (Enemy enemy in enemies)
		{
			FDamageData damageData = new FDamageData(damage, healthDamageMultiplier, armorDamageMultiplier, shieldDamageMultiplier);
			if ((bool)areaEffect.OwnerTower)
			{
				areaEffect.OwnerTower.CombatComponent.DoDamageToEnemy(enemy, damageData, enemy.transform.position, isMainDamage: false);
			}
			else
			{
				enemy.CombatComponent.DoDamage(base.gameObject, damageData, reportDamage: true);
			}
		}
	}
}
