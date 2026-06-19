using Pug.Conversion;
using Unity.Mathematics;

public class ScarabBossConverter : SingleAuthoringComponentConverter<ScarabBossAuthoring>
{
	protected override void Convert(ScarabBossAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		EnsureHasComponent<ScarabBossCD>();
		EnsureHasComponent<ScarabBossHasAppearedCD>();
		EnsureHasComponent<ScarabBossBuriedStateCD>();
		AddComponentData(new ScarabBossAppearStateCD
		{
			appearDuration = authoring.appearDuration
		});
		int num = authoring.chargeDamage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
		{
			num = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.chargeDamageMultiplier);
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
		AddComponentData(new ScarabBossChargeStateCD
		{
			buryDuration = authoring.buryDuration,
			unearthDuration = authoring.unearthDuration,
			minCooldown = authoring.minChargeCooldown,
			maxCooldown = authoring.maxChargeCooldown,
			damage = num
		});
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: false);
		EnsureHasBuffer<TargetMortarPositionBuffer>();
	}
}
