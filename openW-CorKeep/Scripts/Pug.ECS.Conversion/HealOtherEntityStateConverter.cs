using Pug.Conversion;
using Unity.Mathematics;

public class HealOtherEntityStateConverter : SingleAuthoringComponentConverter<HealOtherEntityStateAuthoring>
{
	protected override void Convert(HealOtherEntityStateAuthoring authoring)
	{
		int num = authoring.healPerSecond;
		AreaLevelAuthoring component;
		if (authoring.healPercentageOfHp)
		{
			num = (int)math.round(1f * authoring.healMultiplier);
		}
		else if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out component))
		{
			num = HealOtherEntityStateAuthoring.LevelToHealing(component.level, authoring.healMultiplier);
		}
		if (TryGetActiveComponent<EnemyAuthoring>(authoring, out var _) && !authoring.donCalculateHealingFromLevel)
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
		AddComponentData(new HealOtherEntityStateCD
		{
			maxReachDistance = authoring.maxReachDistance,
			anticipationDuration = authoring.anticipationDuration,
			healDuration = authoring.healDuration,
			healPerSecond = num,
			minCooldown = authoring.minCooldown,
			maxCooldown = authoring.maxCooldown,
			skipVisibilityCheck = authoring.skipVisibilityCheck,
			keepHealingUntilTakingDamageXTimes = authoring.keepHealingUntilTakingDamageXTimes,
			healPercentageOfHp = authoring.healPercentageOfHp
		});
		EnsureHasBuffer<EntitiesHealedBuffer>();
	}
}
