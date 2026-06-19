using Pug.Conversion;
using Unity.Mathematics;

public class BeamAttackStateConverter : SingleAuthoringComponentConverter<BeamAttackStateAuthoring>
{
	protected override void Convert(BeamAttackStateAuthoring authoring)
	{
		int num = authoring.damage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
		{
			num = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.damageMultiplier);
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
		AddComponentData(new BeamAttackStateCD
		{
			damage = num,
			anticipationDuration = authoring.anticipationDuration,
			attackDuration = authoring.attackDuration,
			endDuration = authoring.endDuration,
			spawnAtDistanceInfront = authoring.spawnAtDistanceInfront,
			timeBetweenDamageTicks = authoring.timeBetweenDamageTicks,
			minCooldown = authoring.minCooldown,
			maxCooldown = authoring.maxCooldown,
			beamWidth = authoring.beamWidth,
			beamReachDistance = authoring.beamReachDistance,
			amountOfBeams = authoring.amountOfBeams,
			angleBetweenBeams = authoring.angleBetweenBeams
		});
	}
}
