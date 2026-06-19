using Pug.Conversion;
using Unity.Mathematics;

public class MeleeAttackStateConverter : SingleAuthoringComponentConverter<MeleeAttackStateAuthoring>
{
	protected override void Convert(MeleeAttackStateAuthoring authoring)
	{
		int num = authoring.meleeDamage;
		EnemyAuthoring component;
		bool flag = TryGetActiveComponent<EnemyAuthoring>(authoring, out component);
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component2))
		{
			num = MeleeAttackStateAuthoring.LevelToDamage(component2.level, authoring.meleeDamageMultiplier);
			authoring.tileDamage = MeleeAttackStateAuthoring.LevelToTileDamage(component2.level, authoring.tileDamageMultiplier, flag);
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
		AddComponentData(new MeleeAttackStateCD
		{
			meleeDamage = num
		});
		EnsureHasComponent<AttackCooldownTimerCD>();
		EnsureHasComponent<IsInCombatCD>();
		SetProperty("MeleeAttack/anticipationDuration", authoring.anticipationDuration);
		SetProperty("MeleeAttack/hitDuration", authoring.hitDuration);
		SetProperty("MeleeAttack/durationBeforeDamageDeal", authoring.durationBeforeDamageDeal);
		SetProperty("MeleeAttack/minCooldown", authoring.minCooldown);
		SetProperty("MeleeAttack/maxCooldown", authoring.maxCooldown);
		SetProperty("MeleeAttack/minDistanceToAttemptHit", authoring.minDistanceToAttemptHit);
		SetProperty("MeleeAttack/hitDistanceInfront", authoring.hitDistanceInfront);
		SetProperty("MeleeAttack/hitOffset", authoring.hitOffset);
		if (authoring.hitInDiscreteDirections)
		{
			SetProperty("MeleeAttack/hitInDiscreteDirections");
		}
		if (authoring.hitTiles)
		{
			SetProperty("MeleeAttack/hitTiles");
		}
		SetProperty("MeleeAttack/tileDamage", authoring.tileDamage);
		SetProperty("MeleeAttack/hitRadius", authoring.hitRadius);
		SetProperty("MeleeAttack/hitBoxHalfWidth", authoring.hitBoxHalfWidth);
		SetProperty("MeleeAttack/hitBoxHalfLength", authoring.hitBoxHalfLength);
		SetProperty("MeleeAttack/pushForce", authoring.pushForce);
		SetProperty("MeleeAttack/moveForceForward", authoring.moveForceForward);
		if (authoring.alwaysMoveAtFullForceForward)
		{
			SetProperty("MeleeAttack/alwaysMoveAtFullForceForward");
		}
		if (authoring.lockOrientationDuringHit)
		{
			SetProperty("MeleeAttack/lockOrientationDuringHit");
		}
		if (authoring.lockOrientationDuringAnticipation)
		{
			SetProperty("MeleeAttack/lockOrientationDuringAnticipation");
		}
		SetProperty("MeleeAttack/objectToSpawnOnHitTiles", authoring.objectToSpawnOnHitTiles);
		if (authoring.canHitLowTriggers)
		{
			SetProperty("MeleeAttack/canHitLowTriggers");
		}
		if (authoring.bypassMaxDamagePerHit)
		{
			SetProperty("MeleeAttack/bypassMaxDamagePerHit");
		}
		if (authoring.skipVisibilityCheck)
		{
			SetProperty("MeleeAttack/skipVisibilityCheck");
		}
		SetProperty("MeleeAttack/amountOfHits", authoring.amountOfHits);
		SetProperty("MeleeAttack/attackPlayerTimeout", authoring.attackPlayerTimeout);
		if (authoring.canOnlyAttackEnemiesAndPlayer)
		{
			SetProperty("MeleeAttack/canOnlyAttackEnemiesAndPlayer");
		}
	}
}
