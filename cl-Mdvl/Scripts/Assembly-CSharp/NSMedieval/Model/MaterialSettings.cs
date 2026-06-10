using System;
using NSEipix.Base;
using NSMedieval.Construction;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class MaterialSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private float hitpointsMultiplier;

		[SerializeField]
		private float weightMultiplier;

		[SerializeField]
		private float damageMultiplier;

		[SerializeField]
		private float attackSpeedMultiplier;

		[SerializeField]
		private float armorRatingMultiplier;

		[SerializeField]
		private float wealthPointsMultiplier;

		[SerializeField]
		private ItemMaterialCategory itemMaterialCategory;

		[SerializeField]
		private string dismantledProductsOverride;

		[SerializeField]
		private string iconColorValue;

		[SerializeField]
		private SetShaderParam[] shaderParameters;

		[SerializeField]
		private string[] onEquipEffectors;

		[SerializeField]
		private string[] hitEffectorGroupIDs;

		[SerializeField]
		private string[] criticalHitEffectorGroupIDs;

		[SerializeField]
		private float beautyInputAdd;

		[SerializeField]
		private float beautyInputEquippedAdd;

		[SerializeField]
		private float beautyInputOnShelfAdd;

		[SerializeField]
		private float beautyInputInsideAdd;

		[SerializeField]
		private float agentFlammability = 1f;

		[SerializeField]
		private float agentFireDamageMultiplier = 1f;

		[SerializeField]
		private float hpLossPerUseMultiplier;

		[SerializeField]
		private float hpLossFlammableProjectileModifierMultiplier;

		public LocKeys[] LocKeys => locKeys;

		public float HitpointsMultiplier => hitpointsMultiplier;

		public float WeightMultiplier => weightMultiplier;

		public float DamageMultiplier => damageMultiplier;

		public float AttackSpeedMultiplier => attackSpeedMultiplier;

		public float ArmorRatingMultiplier => armorRatingMultiplier;

		public float WealthPointsMultiplier => wealthPointsMultiplier;

		public ItemMaterialCategory ItemMaterialCategory => itemMaterialCategory;

		public string DismantledProductsOverride => dismantledProductsOverride;

		public SetShaderParam[] ShaderParameters => shaderParameters;

		public string IconColorValue => iconColorValue;

		public string[] OnEquipEffectors => onEquipEffectors;

		public string[] HitEffectorGroupIDs => hitEffectorGroupIDs;

		public string[] CriticalHitEffectorGroupIDs => criticalHitEffectorGroupIDs;

		public float BeautyInputAdd => beautyInputAdd;

		public float BeautyInputOnShelfAdd => beautyInputOnShelfAdd;

		public float BeautyInputEquippedAdd => beautyInputEquippedAdd;

		public float BeautyInputInsideAdd => beautyInputInsideAdd;

		public float AgentFlammability => agentFlammability;

		public float AgentFireDamageMultiplier => agentFireDamageMultiplier;

		public float HpLossPerUseMultiplier => hpLossPerUseMultiplier;

		public float HpLossFlammableProjectileModifierMultiplier => hpLossFlammableProjectileModifierMultiplier;

		public override string GetID()
		{
			return id;
		}
	}
}
