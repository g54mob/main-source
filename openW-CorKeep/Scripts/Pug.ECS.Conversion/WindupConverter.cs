using Pug.Conversion;

public class WindupConverter : SingleAuthoringComponentConverter<SecondaryUseAuthoring>
{
	protected override void Convert(SecondaryUseAuthoring authoring)
	{
		AddComponentData(new SecondaryUseCD
		{
			mechanic = authoring.mechanic,
			windupTiers = authoring.windupTiers,
			cancelAttackIfNotAtWindupTier = authoring.cancelAttackIfNotAtWindupTier,
			windupAreaSizeMultiplier = authoring.windupAreaSizeMultiplier,
			extraDamageMultiplier = authoring.extraDamageMultiplier,
			projectileSpeedMultiplier = authoring.projectileSpeedMultiplier,
			windupTime = authoring.windupTime,
			knockback = authoring.knockback,
			weaponEffectType = authoring.weaponEffectType,
			useTerm = authoring.useTerm,
			minionToSpawn = authoring.minionToSpawn,
			manaCostMultiplier = authoring.manaCostMultiplier
		});
	}
}
