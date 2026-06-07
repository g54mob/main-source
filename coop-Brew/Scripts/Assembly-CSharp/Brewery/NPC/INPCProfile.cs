using UnityEngine;

namespace Brewery.NPC
{
	public interface INPCProfile
	{
		float MaxHealth { get; }

		float HealthRegenRate { get; }

		float HealthRegenDelay { get; }

		float MaxPoise { get; }

		float PoiseDamagePerHit { get; }

		float StaggerCooldown { get; }

		float PoiseRegenRate { get; }

		float PoiseRegenDelay { get; }

		float StaggerDuration { get; }

		bool EnableHitFlash { get; }

		float HitFlashIntensity { get; }

		float HitFlashFadeOutDuration { get; }

		Color HitFlashColor { get; }

		float HitFlashRadius { get; }

		float BrawlStartChanceAfterDrink { get; }

		float BrawlJoinChance { get; }

		float BrawlAggroRadius { get; }

		float BrawlTargetPlayerChance { get; }

		float BrawlCooldownSeconds { get; }

		float BrawlFleeHealthThreshold { get; }

		float BrawlWatchOnlyChance { get; }

		bool BrawlNonCombatant { get; }

		int BrawlMaxConcurrentTargets { get; }

		float AttackCooldownMin { get; }

		float AttackCooldownMax { get; }

		bool ResetCooldownOnHit { get; }

		int RevengeHitThreshold { get; }

		float PostStaggerCooldown { get; }

		float CombatAttackRange { get; }

		float CombatMaxDistance { get; }

		float CombatRetreatDistance { get; }

		float CombatApproachSpeed { get; }

		float CombatSelfDefenseApproachSpeed { get; }

		float CombatRetreatSpeed { get; }

		float CombatRetreatDuration { get; }

		float CombatRetreatChance { get; }

		float CombatIdleTimeout { get; }

		float CombatMaxDuration { get; }
	}
}
