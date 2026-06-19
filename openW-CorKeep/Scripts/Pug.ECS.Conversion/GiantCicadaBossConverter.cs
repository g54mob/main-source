using Pug.Conversion;
using Unity.Mathematics;

public class GiantCicadaBossConverter : SingleAuthoringComponentConverter<GiantCicadaBossAuthoring>
{
	protected override void Convert(GiantCicadaBossAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		EnsureHasComponent<DistanceToPlayerCD>();
		EnsureHasBuffer<TargetMortarPositionBuffer>();
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: false);
		EnsureHasComponent<IsInCombatCD>();
		EnsureHasComponent<GiantCicadaBossHasAppearedCD>();
		int num = authoring.armSlamDamage;
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
		EnsureHasComponent<GiantCicadaBossCD>();
		AddComponentData(new GiantCicadaBossAppearStateCD
		{
			appearDuration = authoring.spawnDuration
		});
		AddComponentData(new GiantCicadaSlamArmsStateCD
		{
			armSlamDamage = num,
			minCooldown = authoring.armSlamCooldown,
			armSlamAnticipation = authoring.armSlamAnticipation,
			armSlamAnimationDuration = authoring.armSlamAnimationDuration
		});
		SetProperty("EnemyStagesState/transitionDuration", authoring.stageTransitionDuration);
		AddComponentData(new EnemyStagesStateCD
		{
			maxStages = authoring.amountOfStages,
			currentStage = authoring.amountOfStages - 1,
			lowestMultiplier = authoring.lowestStageMultiplier
		});
		AddComponentData(new CoreBossSpawnVoidStateCD
		{
			isDisabled = true,
			minCooldown = authoring.voidSpawn.minCooldown,
			maxCooldown = authoring.voidSpawn.maxCooldown,
			duration = authoring.voidSpawn.duration,
			durationUntilSpawn = authoring.voidSpawn.durationUntilSpawn,
			durationAfterSpawn = authoring.voidSpawn.durationAfterSpawn,
			voidZoneType = VoidZoneType.AttackAreas
		});
		EnsureHasBuffer<CoreBossVoidImmuneZoneBuffer>();
		EnsureHasBuffer<AttackedNearbyEntitiesBufferCD>();
	}
}
