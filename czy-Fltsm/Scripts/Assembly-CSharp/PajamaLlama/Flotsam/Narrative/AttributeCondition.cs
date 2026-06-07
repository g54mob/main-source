using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class AttributeCondition : IScenarioTriggerableCondition
	{
		[SerializeField]
		private DrifterAttributes.AttributeType _attributeType;

		[SerializeField]
		private int _requiredExpertise;

		public bool IsMet()
		{
			foreach (Agent agent in Community.PlayerCommunity.Agents)
			{
				if (agent.Attributes.TryReturnAttribute(_attributeType, out var attribute) && _requiredExpertise <= attribute.Expertise)
				{
					return true;
				}
			}
			return false;
		}
	}
}
