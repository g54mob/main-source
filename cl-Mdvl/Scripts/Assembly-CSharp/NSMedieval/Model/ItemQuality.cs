using System;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class ItemQuality : ProductQualityBase
	{
		[SerializeField]
		private float decompositionCoefficientMultiplier;

		[SerializeField]
		private string[] onEquipEffectors;

		[SerializeField]
		private float agentFlammability = 1f;

		[SerializeField]
		private float agentFireDamageMultiplier = 1f;

		public float DecompositionCoefficientMultiplier => decompositionCoefficientMultiplier;

		public float AgentFlammability => agentFlammability;

		public float AgentFireDamageMultiplier => agentFireDamageMultiplier;

		public string[] OnEquipEffectors => onEquipEffectors;

		public override string GetID()
		{
			return string.Empty;
		}
	}
}
