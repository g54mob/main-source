using System;
using UnityEngine;

namespace Property
{
	[Serializable]
	public struct FurnitureRequirement
	{
		[Tooltip("Type of furniture required")]
		public FurnitureType furnitureType;

		[Tooltip("Minimum quantity required")]
		public int minCount;

		[Tooltip("Does this furniture have special placement rules?")]
		public bool hasPlacementRules;

		[Tooltip("Description of placement rules for UI")]
		public string placementRuleDescription;
	}
}
