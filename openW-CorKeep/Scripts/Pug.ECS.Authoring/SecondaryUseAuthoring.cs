using NaughtyAttributes;
using UnityEngine;

[DisallowMultipleComponent]
public class SecondaryUseAuthoring : MonoBehaviour
{
	public SecondaryUseMechanic mechanic;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.WindUp)]
	public int windupTiers = 1;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.WindUp)]
	public int cancelAttackIfNotAtWindupTier;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.WindUp)]
	public float windupAreaSizeMultiplier = 1f;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.WindUp)]
	public float extraDamageMultiplier = 1f;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.WindUp)]
	public float projectileSpeedMultiplier = 1f;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.WindUp)]
	public float windupTime = 0.7f;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.WindUp)]
	public float windupTimeMultiplier = 1f;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.WindUp)]
	public float manaCostMultiplier = 2f;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.WindUp)]
	public int windupExplosionSequenceStart;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.WindUp)]
	public int windupExplosionSequenceIncrement;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.WindUp)]
	public bool knockback;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.WindUp)]
	public WeaponEffectType weaponEffectType;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.WindUp)]
	public SecondaryUseTerm useTerm;

	[AllowNesting]
	[ShowIf("mechanic", SecondaryUseMechanic.SpawnMinion)]
	public ObjectID minionToSpawn;

	private void OnValidate()
	{
		if (windupTiers > 1 && GetComponent<RangeWeaponAuthoring>() != null)
		{
			windupTime = (float)windupTiers * 0.7f * windupTimeMultiplier;
		}
	}
}
