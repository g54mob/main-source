using Pug.Conversion;
using Unity.Mathematics;

public class SlimeBossJumpStateConverter : SingleAuthoringComponentConverter<SlimeBossJumpStateAuthoring>
{
	protected override void Convert(SlimeBossJumpStateAuthoring authoring)
	{
		int num = authoring.damage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
		{
			num = (int)((float)MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.damageMultiplier) * 1.55f);
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
		AddComponentData(new SlimeBossJumpStateCD
		{
			anticipationTime = authoring.anticipationTime,
			enragedAnticipationTime = authoring.enragedAnticipationTime,
			maxAirTime = authoring.maxAirTime,
			enragedMaxAirTime = authoring.enragedMaxAirTime,
			landTime = authoring.landTime,
			damage = num,
			jumpMoveSpeed = authoring.jumpMoveSpeed,
			enragedJumpMoveSpeed = authoring.enragedJumpMoveSpeed,
			slimeTileset = authoring.slimeTileset
		});
		EnsureHasComponent<IsInCombatCD>();
	}
}
