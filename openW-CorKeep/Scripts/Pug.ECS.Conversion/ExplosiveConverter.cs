using Pug.Conversion;
using Unity.Mathematics;

public class ExplosiveConverter : SingleAuthoringComponentConverter<ExplosiveAuthoring>
{
	protected override void Convert(ExplosiveAuthoring authoring)
	{
		EnemyAuthoring component;
		bool flag = TryGetActiveComponent<EnemyAuthoring>(authoring, out component);
		int num = authoring.damage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component2))
		{
			ProjectileAuthoring component3;
			bool flag2 = TryGetActiveComponent<ProjectileAuthoring>(authoring, out component3);
			num = ExplosiveAuthoring.LevelToExplosionDamage(component2.level, authoring.damageMultiplier);
			authoring.miningDamage = ExplosiveAuthoring.LevelToMiningDamage(component2.level, authoring.miningDamageMultiplier, flag || flag2);
		}
		if (flag)
		{
			num = (int)math.round((float)num * 2f);
			if (base.UseHardModeSettings)
			{
				num = (int)math.round((float)num * 2f);
			}
			else if (base.UseCasualModeSettings)
			{
				num = (int)math.round((float)num * 0.5f);
			}
		}
		AddComponentData(new IsExplosiveCD
		{
			damage = num,
			tileDamage = authoring.miningDamage,
			explosionID = authoring.explosionID,
			explosionVariation = authoring.explosionVariation,
			ignoreExploding = authoring.ignoreExploding,
			explosionInheritsFaction = authoring.explosionInheritsFaction,
			bombInheritsFaction = authoring.bombInheritsFaction,
			useSmallNapalmVariant = authoring.useSmallNapalmVariant,
			explosionPushback = authoring.explosionPushback
		});
		EnsureHasComponent<HasExplodedCD>(componentIsEnabled: false);
		EnsureHasComponent<OwnerReferenceCD>();
	}
}
