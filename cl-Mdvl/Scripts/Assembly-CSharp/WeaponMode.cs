using System;
using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Types;
using UnityEngine;

[Serializable]
public class WeaponMode
{
	[SerializeField]
	private WeaponType weaponType;

	[SerializeField]
	private float damage;

	[SerializeField]
	private float range;

	[SerializeField]
	private float ignoresArmor;

	[SerializeField]
	private float armorDamage;

	[SerializeField]
	private float buildingDamage;

	[SerializeField]
	private float precision;

	[SerializeField]
	private float precisionFalloff;

	[SerializeField]
	private float attackSpeed;

	[SerializeField]
	private Vector3 projectileOffset;

	[SerializeField]
	private float ladderDamageMod = 1f;

	[SerializeField]
	private float ladderCritMod = 1f;

	[SerializeField]
	private float ladderSpeedMod = 1f;

	[SerializeField]
	private float waterDamageMod = 1f;

	[SerializeField]
	private float waterCritMod = 1f;

	[SerializeField]
	private float waterSpeedMod = 1f;

	[SerializeField]
	private float waterPrecisionPenalty;

	[SerializeField]
	private bool canFireFlammableProjectiles;

	[SerializeField]
	private string[] hitEffectorGroupIDs;

	[SerializeField]
	private string[] criticalHitEffectorGroupIDs;

	[SerializeField]
	private float projectileArcHeight;

	[SerializeField]
	private float projectileSpeed;

	[SerializeField]
	private string projectilePrefabAddress;

	[SerializeField]
	private string projectileHitCreatureParticles;

	[SerializeField]
	private string projectileHitBuildingParticles;

	[SerializeField]
	private string projectileMissParticles;

	[SerializeField]
	private string projectileBreakParticles;

	[SerializeField]
	private float hpLossPerUse;

	[SerializeField]
	private bool loseHpOnMiss;

	[SerializeField]
	private float hpLossFlammableProjectileModifier = 1f;

	[SerializeField]
	private string weaponSound;

	[NonSerialized]
	private WeaponTypeSettings weaponTypeSettingsCache;

	[NonSerialized]
	private HitEffector[] onHitEffectors;

	[NonSerialized]
	private HitEffector[] onCriticalHitEffectors;

	public float Damage => damage;

	public float Range => range;

	public WeaponType WeaponType => weaponType;

	public float IgnoresArmor => ignoresArmor;

	public float ArmorDamage => armorDamage;

	public float BuildingDamage => buildingDamage;

	public float Precision => precision;

	public float PrecisionFalloff => precisionFalloff;

	public float AttackSpeed => attackSpeed;

	public float LadderDamageMod => ladderDamageMod;

	public float LadderCritMod => ladderCritMod;

	public float LadderSpeedMod => ladderSpeedMod;

	public float WaterDamageMod => waterDamageMod;

	public float WaterCritMod => waterCritMod;

	public float WaterSpeedMod => waterSpeedMod;

	public float WaterPrecisionPenalty => waterPrecisionPenalty;

	public Vector3 ProjectileOffset => projectileOffset;

	public string[] HitEffectorGroupIDs => hitEffectorGroupIDs;

	public string[] CriticalHitEffectorGroupIDs => criticalHitEffectorGroupIDs;

	public bool CanFireFlammableProjectiles => canFireFlammableProjectiles;

	public string ProjectilePrefabAddress => projectilePrefabAddress;

	public float ProjectileArcHeight => projectileArcHeight;

	public float ProjectileSpeed => projectileSpeed;

	public string ProjectileHitCreatureParticles => projectileHitCreatureParticles;

	public string ProjectileHitBuildingParticles => projectileHitBuildingParticles;

	public string ProjectileMissParticles => projectileMissParticles;

	public string ProjectileBreakParticles => projectileBreakParticles;

	public float HpLossPerUse => hpLossPerUse;

	public bool LoseHpOnMiss => loseHpOnMiss;

	public float HpLossFlammableProjectileModifier => hpLossFlammableProjectileModifier;

	public HitEffector[] OnHitEffectors
	{
		get
		{
			if (onHitEffectors == null && hitEffectorGroupIDs != null)
			{
				List<HitEffector> list = new List<HitEffector>();
				string[] array = hitEffectorGroupIDs;
				foreach (string id in array)
				{
					list.AddRange(Repository<HitEffectorGroupRepository, HitEffectorGroup>.Instance.GetByID(id).HitEffectors);
				}
				onHitEffectors = list.ToArray();
			}
			return onHitEffectors;
		}
	}

	public HitEffector[] OnCriticalHitEffectors
	{
		get
		{
			if (onCriticalHitEffectors == null && criticalHitEffectorGroupIDs != null)
			{
				List<HitEffector> list = new List<HitEffector>();
				string[] array = criticalHitEffectorGroupIDs;
				foreach (string id in array)
				{
					list.AddRange(Repository<HitEffectorGroupRepository, HitEffectorGroup>.Instance.GetByID(id).HitEffectors);
				}
				onCriticalHitEffectors = list.ToArray();
			}
			return onCriticalHitEffectors;
		}
	}

	public WeaponTypeSettings WeaponTypeSettings
	{
		get
		{
			if (weaponTypeSettingsCache == null)
			{
				weaponTypeSettingsCache = Repository<WeaponTypeSettingsRepository, WeaponTypeSettings>.Instance.GetByID(weaponType);
			}
			return weaponTypeSettingsCache;
		}
	}

	public string WeaponSound => weaponSound;

	public WeaponMode GenerateQualityClone(float damage, float precisionFalloff, float precision, float attackSpeed, float range, float ignoresArmor, float armorDamage, float buildingDamage, string[] hitEffectorGroupIDs, string[] criticalHitEffectorGroupIDs, float hpLossPerUse, float hpLossFlammableProjectileModifier)
	{
		return new WeaponMode
		{
			weaponType = weaponType,
			projectileOffset = projectileOffset,
			canFireFlammableProjectiles = canFireFlammableProjectiles,
			ladderCritMod = ladderCritMod,
			ladderDamageMod = ladderDamageMod,
			ladderSpeedMod = ladderSpeedMod,
			waterCritMod = waterCritMod,
			waterDamageMod = waterDamageMod,
			waterPrecisionPenalty = waterPrecisionPenalty,
			waterSpeedMod = waterSpeedMod,
			projectilePrefabAddress = projectilePrefabAddress,
			projectileArcHeight = projectileArcHeight,
			projectileSpeed = projectileSpeed,
			projectileHitCreatureParticles = projectileHitCreatureParticles,
			projectileHitBuildingParticles = projectileHitBuildingParticles,
			projectileMissParticles = projectileMissParticles,
			projectileBreakParticles = projectileBreakParticles,
			loseHpOnMiss = loseHpOnMiss,
			weaponSound = weaponSound,
			damage = damage,
			range = range,
			attackSpeed = attackSpeed,
			precision = precision,
			precisionFalloff = precisionFalloff,
			armorDamage = armorDamage,
			ignoresArmor = ignoresArmor,
			buildingDamage = buildingDamage,
			criticalHitEffectorGroupIDs = criticalHitEffectorGroupIDs,
			hitEffectorGroupIDs = hitEffectorGroupIDs,
			hpLossPerUse = hpLossPerUse,
			hpLossFlammableProjectileModifier = hpLossFlammableProjectileModifier
		};
	}

	public override string ToString()
	{
		return string.Format("{0}: {1}, {2}: {3}, AttackType: {4}", "weaponType", weaponType, "range", range, WeaponTypeSettings.AttackType);
	}
}
