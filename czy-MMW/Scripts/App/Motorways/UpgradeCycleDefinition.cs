using System;
using UnityEngine;

namespace Motorways
{
	[Serializable]
	public struct UpgradeCycleDefinition
	{
		[Tooltip("The packages the player starts with on this map, including concrete")]
		public UpgradePackageDefinition[] startingPackages;

		[Tooltip("The potential packages that can be presented each week")]
		public WeeklyUpgradeDefinition[] weeklyChoicePackages;
	}
}
