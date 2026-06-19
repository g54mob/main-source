using Pug.Conversion;
using Unity.Mathematics;

public class LarvaBossConverter : SingleAuthoringComponentConverter<BossLarvaAuthoring>
{
	protected override void Convert(BossLarvaAuthoring authoring)
	{
		EnsureHasBuffer<LarvaTargetPointsBuffer>();
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
		AddComponentData(new BossLarvaCD
		{
			damage = num,
			segmentPrefabSmall = GetPrefabDependency(authoring.segmentPrefabSmall),
			segmentPrefabMedium = GetPrefabDependency(authoring.segmentPrefabMedium),
			segmentPrefabLarge = GetPrefabDependency(authoring.segmentPrefabLarge),
			roamDistance = authoring.roamDistance,
			roamDeviation = authoring.roamDeviation
		});
	}
}
