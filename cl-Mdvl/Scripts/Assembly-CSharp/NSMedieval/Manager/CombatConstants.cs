using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Manager
{
	public static class CombatConstants
	{
		public static float BaseRange;

		public static Vector3 HeadHeightOffset;

		public const float ShootTraversePenaltyIgnoreRange = 2f;

		public const int MaximumAttackersPerTarget = 8;

		public const float LosPenaltyIgnoreBuildingsBelowDistance = 3f;

		public const float InCombatNoDamageDuration = 8f;

		public const float InCombatInflictDamageDuration = 3f;

		public const float InCombatStateRange = 5f;

		public const float CreatureOnNodeDistance = 0.65f;

		public const float AttackRangeNodeTolerantion = 0.3f;

		public const int BuildingAttackPositionSearchCountLimit = 8;

		public const float WorkerAiMeleeAutoEngageRange = 7f;

		public const int WorkerAiMeleeAutoEngageTargetCheckLimit = 3;

		public const float InitialChargeTargetDistanceDivider = 2f;

		public const float RangedAttackerAboveDamageBonus = 1.3f;

		public const float RangedAttackerBelowDamageBonus = 0.8f;

		public const float RangedAttackerAboveHitChanceBonus = 1.3f;

		public const float RangedAttackerBelowHitChanceBonus = 0.9f;

		public const float FollowRange = 5f;

		public const float CombatMoveToPositionActionTimeout = 2f;

		public const float LadderAdditionalRange = 0.7f;

		public const float DiagonalLadderMaxAttackHeight = 1.3f;

		public static readonly WeaponType[] TwoHandWeapons = new WeaponType[9]
		{
			WeaponType.TwoHandBow,
			WeaponType.TwoHandCrossbow,
			WeaponType.TwoHandMace,
			WeaponType.TwoHandStaff,
			WeaponType.TwoHandSpear,
			WeaponType.TwoHandAxe,
			WeaponType.TwoHandSword,
			WeaponType.TwoHandRam,
			WeaponType.TwoHandSling
		};

		public const float TwoHandedWeaponOnLaddersDmg = 0.4f;

		public const float OneHandedWeaponOnLaddersDmg = 0.8f;

		public const float UnarmedLadderDmg = 1f;

		public const float TwoHandedWeaponOnLaddersSpeed = 1.4f;

		public const float OneHandedWeaponOnLaddersSpeed = 1.2f;

		public const float UnarmedOnLaddersSpeed = 1.2f;

		public const float FlammableProjectileAttackSpeedMod = 1.15f;

		public const float FlammableProjectileAccuracyPenalty = 0.2f;

		public const int MaxCreaturesOnNode = 3;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			BaseRange = 1.5f;
			HeadHeightOffset = new Vector3(0f, 2.1f, 0f);
		}
	}
}
