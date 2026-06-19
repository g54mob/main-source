using Pug.Conversion;
using Unity.Mathematics;

public class HydraBossConverter : SingleAuthoringComponentConverter<HydraBossAuthoring>
{
	protected override void Convert(HydraBossAuthoring authoring)
	{
		EnsureHasComponent<HydraBossVulnerableEntityCD>();
		EnsureHasComponent<MainHydraRefCD>();
		EnsureHasComponent<MainHydraCD>();
		EnsureHasBuffer<HydrasBuffer>();
		EnsureHasBuffer<HydraCombatAppearPositionsBuffer>();
		if (authoring.hydraType == HydraBossType.Nature)
		{
			EnsureHasComponent<HydraBossNatureCD>();
		}
		else if (authoring.hydraType == HydraBossType.Sea)
		{
			EnsureHasComponent<HydraBossSeaCD>();
		}
		else if (authoring.hydraType == HydraBossType.Desert)
		{
			EnsureHasComponent<HydraBossDesertCD>();
		}
		else if (authoring.hydraType == HydraBossType.Void)
		{
			EnsureHasComponent<HydraBossVoidCD>();
		}
		int num = authoring.buriedAppearDamage;
		int num2 = authoring.beamDamage;
		int num3 = authoring.stalactiteMortarDamage;
		int num4 = authoring.shockwaveDamage;
		int num5 = authoring.iceShardMortarDamage;
		int num6 = authoring.lavaMortarDamage;
		int num7 = authoring.nilipedeMortarDamage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
		{
			num = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.buriedAppearDamageMultiplier);
			num2 = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.beamDamageMultiplier);
			num3 = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.stalactiteMortarDamageMultiplier);
			num4 = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.shockwaveDamageMultiplier);
			num5 = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.iceShardMortarDamageMultiplier);
			num6 = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.lavaMortarDamageMultiplier);
			num7 = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.nilipedeMortarDamageMultiplier);
		}
		if (TryGetActiveComponent<EnemyAuthoring>(authoring, out var _))
		{
			if (base.UseHardModeSettings)
			{
				num = (int)math.round((float)num * 2f);
				num2 = (int)math.round((float)num2 * 2f);
				num3 = (int)math.round((float)num3 * 2f);
				num4 = (int)math.round((float)num4 * 2f);
				num5 = (int)math.round((float)num5 * 2f);
				num6 = (int)math.round((float)num6 * 2f);
				num7 = (int)math.round((float)num7 * 2f);
			}
			else if (base.UseCasualModeSettings)
			{
				num = (int)math.round((float)num * 0.5f);
				num2 = (int)math.round((float)num2 * 0.5f);
				num3 = (int)math.round((float)num3 * 0.5f);
				num4 = (int)math.round((float)num4 * 0.5f);
				num5 = (int)math.round((float)num5 * 0.5f);
				num6 = (int)math.round((float)num6 * 0.5f);
				num7 = (int)math.round((float)num7 * 0.5f);
			}
		}
		EnsureHasComponent<BaitableCD>();
		AddComponentData(new HydraBossCD
		{
			hydraType = authoring.hydraType,
			internalState = -1,
			vulnerableEntityPrefab = GetPrefabDependency(authoring.vulnerableEntityPrefab),
			beamDamage = num2,
			stalactiteMortarDamage = num3,
			shockwaveDamage = num4,
			iceShardMortarDamage = num5,
			lavaMortarDamage = num6,
			nilipedeMortarDamage = num7
		});
		AddComponentData(new HydraBossBuriedCombatStateCD
		{
			buryDuration = authoring.buryDuration,
			unearthDuration = authoring.unearthDuration,
			minCooldown = authoring.buriedMinCooldown,
			maxCooldown = authoring.buriedMaxCooldown,
			buriedAppearDamage = num
		});
		AddComponentData(new HydraBossBuriedRoamingStateCD
		{
			buryDuration = authoring.buryDuration,
			unearthDuration = authoring.unearthDuration,
			damage = num
		});
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: true);
		EnsureHasComponent<IsInCombatCD>();
		EnsureHasBuffer<TargetMortarPositionBuffer>();
	}
}
