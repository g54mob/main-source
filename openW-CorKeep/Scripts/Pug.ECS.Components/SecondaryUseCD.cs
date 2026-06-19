using Unity.Entities;

public struct SecondaryUseCD : IComponentData, IQueryTypeParameter
{
	public SecondaryUseMechanic mechanic;

	public int windupTiers;

	public int cancelAttackIfNotAtWindupTier;

	public float windupAreaSizeMultiplier;

	public float extraDamageMultiplier;

	public float projectileSpeedMultiplier;

	public float windupTime;

	public bool knockback;

	public float manaCostMultiplier;

	public WeaponEffectType weaponEffectType;

	public SecondaryUseTerm useTerm;

	public ObjectID minionToSpawn;

	public bool hasSecondaryUse => mechanic != SecondaryUseMechanic.None;

	public bool summonsMinion
	{
		get
		{
			if (mechanic == SecondaryUseMechanic.SpawnMinion)
			{
				return minionToSpawn != ObjectID.None;
			}
			return false;
		}
	}

	public bool hasWindup => mechanic == SecondaryUseMechanic.WindUp;
}
