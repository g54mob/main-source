using System.Text.RegularExpressions;
using I2.Loc;
using Rewired;
using UnityEngine;

public class TextManager : MonoBehaviour, ILocalizationParamsManager
{
	private string _hungerLimit;

	private string _thirstLimit;

	public string HungerLimit
	{
		get
		{
			if (_hungerLimit == null)
			{
				_hungerLimit = AgentDescriptor.GetProperties().VitalProperties.HungerLimit.ToString();
			}
			return _hungerLimit;
		}
	}

	public string ThirstLimit
	{
		get
		{
			if (_thirstLimit == null)
			{
				_thirstLimit = AgentDescriptor.GetProperties().VitalProperties.ThirstLimit.ToString();
			}
			return _thirstLimit;
		}
	}

	private void Awake()
	{
		LocalizationManager.ParamManagers.Add(this);
	}

	private void OnDestroy()
	{
		LocalizationManager.ParamManagers.Remove(this);
	}

	string ILocalizationParamsManager.GetParameterValue(string param)
	{
		if (ActorDescriptor.TryGet<ActorDescriptor>(out var actorDescriptor, param))
		{
			return actorDescriptor.Name;
		}
		return param switch
		{
			"COMMUNITYNAME" => (Community.PlayerCommunity != null) ? Community.PlayerCommunity.Name : null, 
			"CURRENTDAY" => (GameManager.TimeManager != null) ? GameManager.TimeManager.Days.Count.ToString() : null, 
			"HUNGERDAYSLIMIT" => HungerLimit, 
			"THIRSTDAYSLIMIT" => ThirstLimit, 
			_ => null, 
		};
	}

	public static string ReplaceVariables(string text, Vitals vitals = null)
	{
		if (GameManager.WorldMapManager != null && GameManager.WorldMapManager.WorldMap != null)
		{
			text = Regex.Replace(text, "%BIOME_COST%", string.Format("<b>{0}</b>", GameplaySettings.ReturnNextBiomeEnergyCost().ToString("F0")), RegexOptions.IgnoreCase);
		}
		if (vitals == null)
		{
			return text;
		}
		if ((bool)vitals.Agent)
		{
			text = Regex.Replace(text, "%NAME%", $"<b>{vitals.Agent.Name}</b>", RegexOptions.IgnoreCase);
			text = Regex.Replace(text, "%FIRSTNAME%", $"<b>{vitals.Agent.Name}</b>", RegexOptions.IgnoreCase);
			text = Regex.Replace(text, "%LASTNAME%", $"<b>{vitals.Agent.Name}</b>", RegexOptions.IgnoreCase);
			text = Regex.Replace(text, "%NICKNAME%", $"<b>{vitals.Agent.Name}</b>", RegexOptions.IgnoreCase);
		}
		if (vitals.Agent.Community != null)
		{
			text = Regex.Replace(text, "%COMMUNITY%", vitals.Agent.Community.Name, RegexOptions.IgnoreCase);
		}
		return text;
	}

	public static string ReplaceVariables(string text, Bird bird = null)
	{
		if (bird == null)
		{
			return text;
		}
		text = Regex.Replace(text, "%NAME%", $"<b>{bird.Name}</b>", RegexOptions.IgnoreCase);
		text = Regex.Replace(text, "%FIRSTNAME%", $"<b>{bird.Name}</b>", RegexOptions.IgnoreCase);
		text = Regex.Replace(text, "%LASTNAME%", $"<b>{bird.Name}</b>", RegexOptions.IgnoreCase);
		text = Regex.Replace(text, "%NICKNAME%", $"<b>{bird.Name}</b>", RegexOptions.IgnoreCase);
		text = Regex.Replace(text, "%COMMUNITY%", bird.Community.Name, RegexOptions.IgnoreCase);
		return text;
	}

	public static string ReplaceVariables(string text, Buildable buildable = null)
	{
		if (buildable == null)
		{
			return text;
		}
		text = Regex.Replace(text, "%SALVAGERETURNS%", ReturnStringfromCountedItemProptertyList(buildable.Properties.RequiredResources), RegexOptions.IgnoreCase);
		text = Regex.Replace(text, "%HEALTHVITAL%", $"{buildable.Health:P2}", RegexOptions.IgnoreCase);
		text = Regex.Replace(text, "%HEALTHVITAL%", $"{buildable.Health:P2}", RegexOptions.IgnoreCase);
		text = ReplaceVariables(text, buildable.Properties);
		return text;
	}

	public static string ReplaceVariables(string text, Decoration decoration)
	{
		if (decoration == null)
		{
			return text;
		}
		text = Regex.Replace(text, "%SALVAGERETURNS%", ReturnStringfromCountedItemProptertyList(decoration.Properties.RequiredResources), RegexOptions.IgnoreCase);
		text = Regex.Replace(text, "%NAME%", $"<b>{decoration.Properties.Name}</b>", RegexOptions.IgnoreCase);
		return text;
	}

	public static string ReplaceVariables(string text, BuildableProperties buildableProperties)
	{
		text = Regex.Replace(text, "%NAME%", $"<b>{buildableProperties.Name}</b>", RegexOptions.IgnoreCase);
		text = Regex.Replace(text, "%RESEARCH%", buildableProperties.ResearchCost.ToString(), RegexOptions.IgnoreCase);
		if (text.Contains("%STORAGEAMOUNT%") || text.Contains("%storageamount%") || text.Contains("%WATERSTORAGEAMOUNT%") || text.Contains("%waterstorageamount%"))
		{
			Inventory component = buildableProperties.Prefab.GetComponent<Inventory>();
			text = Regex.Replace(text, "%STORAGEAMOUNT%", component.StorageCapacity.ToString(), RegexOptions.IgnoreCase);
			text = Regex.Replace(text, "%WATERSTORAGEAMOUNT%", component.LiquidCapacity.ToString(), RegexOptions.IgnoreCase);
		}
		return text;
	}

	public static string ReplaceVariables(string text, ProductionRecipeProperties recipeProperties)
	{
		text = Regex.Replace(text, "%RECIPE%", $"<b>{recipeProperties.LocalizedName}</b>", RegexOptions.IgnoreCase);
		return text;
	}

	public static string ReplaceVariables(string text, LandmarkBehaviour landmarkBehaviour)
	{
		text = Regex.Replace(text, "%LANDMARKNAME%", $"<b>{landmarkBehaviour.Name}</b>", RegexOptions.IgnoreCase);
		return text;
	}

	public static string ReturnStringfromCountedItemProptertyList(CountedItemProperty[] items)
	{
		if (items.Length == 0)
		{
			return "";
		}
		string text = "";
		for (int i = 0; i < items.Length; i++)
		{
			if (items[i].Amount != 0)
			{
				text += items[i].ReturnLocalizedString();
				if (i < items.Length - 1)
				{
					text += ",";
				}
			}
		}
		return text;
	}

	public static string ReplaceVariables(string text, ActionElementMap rewiredKey)
	{
		text = ((rewiredKey != null) ? Regex.Replace(text, "%HOTKEY%", $"[{rewiredKey.keyCode}]", RegexOptions.IgnoreCase) : Regex.Replace(text, "%HOTKEY%", "", RegexOptions.IgnoreCase));
		return text;
	}

	public static string ReplaceVariablesWithEmptyString(string text)
	{
		if (!string.IsNullOrEmpty(text))
		{
			text = Regex.Replace(text, "%HOTKEY%", string.Empty, RegexOptions.IgnoreCase);
		}
		return text;
	}
}
