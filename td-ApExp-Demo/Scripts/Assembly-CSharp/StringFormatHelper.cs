using UnityEngine;
using UnityEngine.Localization;

public static class StringFormatHelper
{
	private static readonly LocalizedString relicKey = new LocalizedString
	{
		TableReference = "LocalizationTable",
		TableEntryReference = "Relic"
	};

	private static readonly LocalizedString upgradeKey = new LocalizedString
	{
		TableReference = "LocalizationTable",
		TableEntryReference = " Upgrade"
	};

	private static readonly LocalizedString moduleKey = new LocalizedString
	{
		TableReference = "LocalizationTable",
		TableEntryReference = " Module"
	};

	public static string ConvertToCurrency(int input)
	{
		return $"{input} <sprite index=0>";
	}

	public static string GetEnhancementString(Enhancement en)
	{
		string result = "";
		if (!(en is EnhancementUpgrade enhancementUpgrade))
		{
			if (en is EnhancementModule)
			{
				result = moduleKey.GetLocalizedString() ?? "";
			}
		}
		else if (enhancementUpgrade.IsRelic)
		{
			result = relicKey.GetLocalizedString();
		}
		else if (enhancementUpgrade.StatsObjectsToUpgrade != null && enhancementUpgrade.StatsObjectsToUpgrade.Length != 0)
		{
			EnhancementModule enhancementModule = FindModuleByStats(enhancementUpgrade.StatsObjectsToUpgrade[0]);
			result = ((!(enhancementModule != null)) ? upgradeKey.GetLocalizedString() : (enhancementModule.NameKey.GetLocalizedString() + " " + upgradeKey.GetLocalizedString()));
		}
		else
		{
			result = upgradeKey.GetLocalizedString();
		}
		return result;
	}

	public static string GetRarityString(Enhancement en)
	{
		ColorUtility.ToHtmlStringRGB(UIManager.Instance.RarityColor(en.Rarity));
		string text = $"Rarity_{en.Rarity}";
		return new LocalizedString
		{
			TableReference = "LocalizationTable",
			TableEntryReference = text
		}.GetLocalizedString() ?? "";
	}

	public static string GetLocalizedModuleType(ModuleCombatTypes moduleType)
	{
		string text = $"ModuleType_{moduleType}";
		return new LocalizedString("LocalizationTable", text).GetLocalizedString();
	}

	private static EnhancementModule FindModuleByStats(Stats stats)
	{
		foreach (EnhancementModule module in UpgradeManager.Instance.Modules)
		{
			if ((object)module == null)
			{
				continue;
			}
			EnhancementModule enhancementModule = module;
			if (enhancementModule.ModulePrefab != null)
			{
				Module component = enhancementModule.ModulePrefab.GetComponent<Module>();
				if ((bool)component && component.StatsSO == stats)
				{
					return enhancementModule;
				}
			}
		}
		return null;
	}
}
