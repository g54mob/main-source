using Pug.Conversion;
using Unity.Mathematics;

public class ExplodeStateConverter : SingleAuthoringComponentConverter<ExplodeStateAuthoring>
{
	protected override void Convert(ExplodeStateAuthoring authoring)
	{
		int num = authoring.damage;
		int tileDamage = authoring.tileDamage;
		EnemyAuthoring component;
		bool flag = TryGetActiveComponent<EnemyAuthoring>(authoring, out component);
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component2))
		{
			num = ExplodeStateAuthoring.LevelToExplosionDamage(component2.level, authoring.damageMultiplier);
			tileDamage = ExplodeStateAuthoring.LevelToMiningDamage(component2.level, authoring.tileDamageMultiplier, flag);
		}
		if (flag)
		{
			if (base.UseHardModeSettings)
			{
				num = (int)math.round((float)num * 2f);
			}
			else if (base.UseCasualModeSettings)
			{
				num = (int)math.round((float)num * 0.5f);
			}
		}
		EnsureHasComponent<StateInfoCD>();
		if (authoring.explodeOnInitialization)
		{
			AddComponentData(new ExplodeStateCD
			{
				distanceToExplode = authoring.distanceToExplode,
				anticipationDuration = authoring.explodeDuration,
				tileDamage = tileDamage,
				damage = num,
				explosionID = authoring.explosionID,
				explosionVariation = authoring.explosionVariation,
				minHealthRatioToExplode = authoring.minHealthRatioToExplode,
				explodeEvenIfKilledByPlayerAtTheSameTime = TryGetActiveComponent<TileAuthoring>(authoring, out var _),
				dropLootOnDestroy = authoring.dropLootOnDestroy
			});
		}
		if (authoring.explodeOnDeath)
		{
			AddComponentData(new IsExplosiveCD
			{
				damage = num,
				explosionID = authoring.explosionID,
				explosionVariation = authoring.explosionVariation,
				tileDamage = authoring.tileDamage
			});
			EnsureHasComponent<HasExplodedCD>(componentIsEnabled: false);
		}
	}
}
