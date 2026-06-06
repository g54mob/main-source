using System;
using System.Collections;
using Sirenix.OdinInspector;

public static class ModifierTypeExtensions
{
	public static IEnumerable GroupedModifierTypes()
	{
		ValueDropdownList<ModifierType> valueDropdownList = new ValueDropdownList<ModifierType>();
		Array values = Enum.GetValues(typeof(ModifierType));
		for (int i = 0; i < values.Length; i++)
		{
			ModifierType modifierType = (ModifierType)values.GetValue(i);
			valueDropdownList.Add(new ValueDropdownItem<ModifierType>(modifierType.Categorize(), modifierType));
		}
		return valueDropdownList;
	}

	private static string Categorize(this ModifierType type)
	{
		if (type < ModifierType.DataModifier)
		{
			if (type >= ModifierType.BugsGenerationRate)
			{
				if (type < (ModifierType)700)
				{
					if (type < ModifierType.Hype)
					{
						return $"Bugs/{type}";
					}
					return $"Hype/{type}";
				}
				if (type < ModifierType.FansModifier)
				{
					return $"Uptime/{type}";
				}
				return $"Fans/{type}";
			}
			if (type >= ModifierType.Load)
			{
				if (type < ModifierType.Ping)
				{
					return $"Load/{type}";
				}
				return $"Ping/{type}";
			}
			if (type >= ModifierType.PlayersGrowthRate)
			{
				if (type < ModifierType.PricePerCopy)
				{
					return $"Players/{type}";
				}
				return $"Money/{type}";
			}
			if (type > ModifierType.None)
			{
				return $"Misc/{type}";
			}
			if (type == ModifierType.None)
			{
				return $"{type}";
			}
		}
		else
		{
			if (type < ModifierType.DevelopmentTime)
			{
				if (type < ModifierType.OperationConcurrentAmount)
				{
					if (type < ModifierType.UpgradeGeneralCost)
					{
						return $"Data/{type}";
					}
					return $"Upgrades/{type}";
				}
				if (type < ModifierType.DatacenterCost)
				{
					return $"Operations/{type}";
				}
				return $"Datacenters/{type}";
			}
			if (type < ModifierType.AuctionCut)
			{
				if (type < ModifierType.DebuggerHexCount)
				{
					return $"Development/{type}";
				}
				return $"Debugger/{type}";
			}
			if (type < (ModifierType)7000)
			{
				return $"Auction/{type}";
			}
		}
		return $"Unknown/{type}";
	}
}
