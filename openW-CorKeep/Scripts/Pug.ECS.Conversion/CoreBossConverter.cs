using Pug.Conversion;
using Unity.Mathematics;

public class CoreBossConverter : SingleAuthoringComponentConverter<CoreBossAuthoring>
{
	protected override void Convert(CoreBossAuthoring authoring)
	{
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: true);
		EnsureHasBuffer<CoreBossOrbsBuffer>();
		EnsureHasComponent<StateInfoCD>();
		EnsureHasBuffer<TargetMortarPositionBuffer>();
		EnsureHasComponent<DistanceToPlayerCD>();
		AddComponentData(new PhaseTransitionStateCD
		{
			phase1TransitionDuration = authoring.phase1TransitionDuration,
			phase1HealthThreshold = authoring.phase1HealthThreshold,
			invulnerableDuration = authoring.invulnerableDuration
		});
		AddComponentData(new CoreBossSpawnBeamsStateCD
		{
			isDisabled = authoring.beamSpawn.disabled,
			durationUntilBeamSpawn = authoring.beamSpawn.durationUntilSpawn,
			durationAfterBeamSpawn = authoring.beamSpawn.durationAfterSpawn,
			minCooldown = authoring.beamSpawn.minCooldown,
			maxCooldown = authoring.beamSpawn.maxCooldown
		});
		AddComponentData(new CoreBossSpawnVoidStateCD
		{
			isDisabled = authoring.voidSpawn.disabled,
			minCooldown = authoring.voidSpawn.minCooldown,
			maxCooldown = authoring.voidSpawn.maxCooldown,
			duration = authoring.voidSpawn.duration,
			durationUntilSpawn = authoring.voidSpawn.durationUntilSpawn,
			durationAfterSpawn = authoring.voidSpawn.durationAfterSpawn
		});
		EnsureHasBuffer<CoreBossVoidImmuneZoneBuffer>();
		EnsureHasBuffer<AttackedNearbyEntitiesBufferCD>();
		EnsureHasBuffer<CoreBossBeamMovementInstructionBuffer>();
		EnsureHasBuffer<BeamQueueBuffer>();
		int num = authoring.whirlwindProjectileDamage;
		int num2 = authoring.homingTriangleProjectileDamage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
		{
			num = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.whirlwindProjectileDamageMultiplier);
			num2 = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.homingTriangleProjectileDamageMultiplier);
		}
		if (TryGetActiveComponent<EnemyAuthoring>(authoring, out var _))
		{
			if (base.UseHardModeSettings)
			{
				num = (int)math.round((float)num * 2f);
				num2 = (int)math.round((float)num2 * 2f);
			}
			else if (base.UseCasualModeSettings)
			{
				num = (int)math.round((float)num * 0.5f);
				num2 = (int)math.round((float)num2 * 0.5f);
			}
		}
		AddComponentData(new CoreBossCD
		{
			orbCount = authoring.orbCount,
			orbRotationSpeed = authoring.orbRotationSpeed,
			orbMinDistance = authoring.orbMinDistance,
			orbMaxDistance = authoring.orbMaxDistance,
			whirlwindProjectileDamage = num,
			homingTriangleProjectileDamage = num2,
			hasObtainedSouls = true
		});
	}
}
