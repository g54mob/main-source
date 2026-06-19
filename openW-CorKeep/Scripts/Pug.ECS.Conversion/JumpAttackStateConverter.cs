using Pug.Conversion;
using Unity.Mathematics;

public class JumpAttackStateConverter : SingleAuthoringComponentConverter<JumpAttackStateAuthoring>
{
	protected override void Convert(JumpAttackStateAuthoring authoring)
	{
		int num = authoring.jumpDamage;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
		{
			num = MeleeAttackStateAuthoring.LevelToDamage(component.level, authoring.jumpDamageMultiplier);
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
		EnsureHasComponent<AttackCooldownTimerCD>();
		EnsureHasComponent<IsInCombatCD>();
		AddComponentData(new JumpAttackStateCD
		{
			jumpDamage = num
		});
		SetProperty("JumpAttack/anticipationTime", authoring.anticipationTime);
		SetProperty("JumpAttack/airTime", authoring.airTime);
		SetProperty("JumpAttack/jumpMoveSpeed", authoring.jumpMoveSpeed);
		if (authoring.canOnlyAttackEnemiesAndPlayer)
		{
			SetProperty("JumpAttack/canOnlyAttackEnemiesAndPlayer");
		}
		SetProperty("JumpAttack/minCooldown", authoring.minCooldown);
		SetProperty("JumpAttack/maxCooldown", authoring.maxCooldown);
		SetProperty("JumpAttack/distanceToAttackSq", authoring.distanceToAttack);
	}
}
