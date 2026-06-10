using System;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class WeaponQuality : ItemQuality
	{
		[SerializeField]
		private float damageMultiplier;

		[SerializeField]
		private float precisionFalloffMultiplier;

		[SerializeField]
		private float precisionMultiplier;

		[SerializeField]
		private float attackSpeedMultiplier;

		[SerializeField]
		private float rangeMultiplier;

		[SerializeField]
		private float ignoresArmorMultiplier;

		[SerializeField]
		private float armorDamageMultiplier;

		[SerializeField]
		private float buildingDamageMultiplier;

		[SerializeField]
		private float hpLossPerUseMultiplier;

		[SerializeField]
		private float hpLossFlammableProjectileModifierMultiplier;

		public float DamageMultiplier => damageMultiplier;

		public float PrecisionFalloffMultiplier => precisionFalloffMultiplier;

		public float PrecisionMultiplier => precisionMultiplier;

		public float AttackSpeedMultiplier => attackSpeedMultiplier;

		public float RangeMultiplier => rangeMultiplier;

		public float IgnoresArmorMultiplier => ignoresArmorMultiplier;

		public float ArmorDamageMultiplier => armorDamageMultiplier;

		public float BuildingDamageMultiplier => buildingDamageMultiplier;

		public float HpLossPerUseMultiplier => hpLossPerUseMultiplier;

		public float HpLossFlammableProjectileModifierMultiplier => hpLossFlammableProjectileModifierMultiplier;
	}
}
