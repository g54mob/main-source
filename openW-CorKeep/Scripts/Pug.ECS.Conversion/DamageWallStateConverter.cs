using Pug.Conversion;
using Unity.Mathematics;

public class DamageWallStateConverter : SingleAuthoringComponentConverter<DamageObjectStateAuthoring>
{
	protected override void Convert(DamageObjectStateAuthoring authoring)
	{
		EnemyAuthoring component;
		bool flag = TryGetActiveComponent<EnemyAuthoring>(authoring, out component);
		int value = authoring.damage;
		int num = authoring.meleeDamage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component2))
		{
			value = DamageObjectStateAuthoring.LevelToTileDamage(component2.level, authoring.damageMultiplier, flag);
			num = MeleeAttackStateAuthoring.LevelToDamage(component2.level, authoring.meleeDamageMultiplier);
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
		EnsureHasComponent<DetectCollisionCD>();
		SetProperty("DamageObjectState/damage", value);
		SetProperty("DamageObjectState/meleeDamage", num);
		SetProperty("DamageObjectState/maxAllowedDamagesWithoutGoal", authoring.maxAllowedDamagesWithoutGoal);
		SetProperty("DamageObjectState/hitDuration", authoring.hitDuration);
		SetProperty("DamageObjectState/anticipationDuration", authoring.anticipationTime);
		SetProperty("DamageObjectState/hitRadius", authoring.hitRadius);
		SetProperty("DamageObjectState/hitDistanceInfront", authoring.hitDistanceInfront);
		if (authoring.bypassCantAttackBehaviourWhileChasing)
		{
			SetProperty("DamageObjectState/bypassCantAttackBehaviourWhileChasing");
		}
		AddComponentData(default(DamageObjectStateCD));
	}
}
