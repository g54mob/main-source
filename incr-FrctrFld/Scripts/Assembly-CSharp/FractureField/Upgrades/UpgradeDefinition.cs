using System;
using System.Collections.Generic;
using FractureField.Prestige;
using FractureField.Shared.Enums;

namespace FractureField.Upgrades
{
	[Serializable]
	public class UpgradeDefinition
	{
		public string Id { get; set; }

		public string Category { get; set; }

		public string PrettyId { get; set; }

		public string Name { get; set; }

		public Func<Upgrade, string> GetDescription { get; set; }

		public Func<Upgrade, CurrencyType> GetCostCurrency { get; set; }

		public Dictionary<string, string> Metadata { get; set; }

		public PrestigeLayerType PrestigeLayerType { get; set; }

		public Func<bool> GetIsLockedInDemo { get; set; }

		public Func<bool> GetIsHidden { get; set; }

		public float BaseCost { get; set; }

		public float GrowthRate { get; set; }

		public float CostTaper { get; set; }

		public Func<Upgrade, string> GetFormattedNextIncrease { get; set; }

		public Func<Upgrade, int, float> GetEffect { get; set; }

		public Func<Upgrade, int, float> GetCost { get; set; }

		public Func<float, string> GetFormattedEffect { get; set; }

		private int MaxLevel { get; set; }

		public Func<Upgrade, int> GetMaxLevel { get; set; }

		public UpgradeDefinition()
		{
		}

		public UpgradeDefinition(string id, string category, string prettyId, string name, Func<Upgrade, string> getDescription, Func<Upgrade, CurrencyType> getCostCurrency, Func<Upgrade, string> getFormattedNextIncrease, Func<Upgrade, int, float> getEffect, float baseCost = 0f, Func<Upgrade, int, float> getCost = null, Func<float, string> getFormattedEffect = null, float growthRate = 1.25f, float costTaper = 0.9f, int maxLevel = 2147483647, Func<Upgrade, int> getMaxLevel = null, Dictionary<string, string> metadata = null, PrestigeLayerType prestigeLayerType = PrestigeLayerType.None, Func<bool> getIsLockedInDemo = null, Func<bool> getIsHidden = null)
		{
		}
	}
}
