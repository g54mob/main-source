using Pug.Conversion;
using Unity.Mathematics;

public class ExplodeOnImpactConverter : SingleAuthoringComponentConverter<ExplodeOnImpactAuthoring>
{
	protected override void Convert(ExplodeOnImpactAuthoring authoring)
	{
		int num = authoring.explodeDamage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
		{
			num = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.explodeDamageMultiplier);
		}
		if (TryGetActiveComponent<EnemyAuthoring>(authoring, out var _))
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
		AddComponentData(new ExplodeOnImpactWithEntityCD
		{
			distanceToExplode = authoring.distanceToExplode,
			explodeRadius = authoring.explodeRadius,
			explodeDamage = num,
			spawnTilesOnExplode = authoring.spawnTilesOnExplode,
			tileTypeToSpawn = authoring.tileTypeToSpawn,
			tilesetToSpawn = authoring.tilesetToSpawn
		});
	}
}
