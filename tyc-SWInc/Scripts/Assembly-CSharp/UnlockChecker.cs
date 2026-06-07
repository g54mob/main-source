using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnlockChecker : MonoBehaviour
{
	public enum UnlockType
	{
		Software = 0,
		Category = 1,
		Feature = 2,
		Addon = 3,
		Furniture = 4
	}

	[Serializable]
	public struct UnlockItem
	{
		public UnlockType Type;

		public string Name;

		public UnlockItem(UnlockType type, string name)
		{
			Type = type;
			Name = name;
		}

		public string GetName()
		{
			switch (Type)
			{
			case UnlockType.Software:
				return MarketSimulation.Active.SoftwareTypes[Name].GetActualString();
			case UnlockType.Category:
			{
				string[] array3 = Name.Split('\n');
				return MarketSimulation.Active.SoftwareTypes[array3[0]].Categories[array3[1]].GetActualString();
			}
			case UnlockType.Feature:
			{
				string[] array2 = Name.Split('\n');
				string actualString = MarketSimulation.Active.SoftwareTypes[array2[0]].Categories[array2[1]].GetActualString();
				if (array2.Length == 3)
				{
					return actualString + " -> " + Localization.GetFeature(array2[0], array2[2])[0];
				}
				string actualString2 = MarketSimulation.Active.SoftwareTypes[array2[0]].AddOns[array2[2]].GetActualString();
				AddOnFeature addOnFeature = MarketSimulation.Active.SoftwareTypes[array2[0]].AddOns[array2[2]].Features[array2[3]];
				return actualString + " -> " + actualString2 + " -> " + Localization.GetFeature(addOnFeature.Software, addOnFeature.Name)[0];
			}
			case UnlockType.Addon:
			{
				string[] array = Name.Split('\n');
				return MarketSimulation.Active.SoftwareTypes[array[0]].Categories[array[1]].GetActualString() + " -> " + MarketSimulation.Active.SoftwareTypes[array[0]].AddOns[array[2]].GetActualString();
			}
			case UnlockType.Furniture:
				return Localization.GetFurniture(Name, Name, null)[0];
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public void OnClick()
		{
			switch (Type)
			{
			case UnlockType.Software:
			{
				SoftwareType softwareType = MarketSimulation.Active.SoftwareTypes[Name];
				HUD.Instance.docWindow.ShowWith(Name, softwareType.Categories.First((KeyValuePair<string, SoftwareCategory> x) => x.Value.IsUnlocked(SDateTime.Now().Year)).Key);
				break;
			}
			case UnlockType.Category:
			case UnlockType.Feature:
			case UnlockType.Addon:
			{
				string[] array = Name.Split('\n');
				HUD.Instance.docWindow.ShowWith(array[0], array[1]);
				break;
			}
			case UnlockType.Furniture:
				HUD.Instance.BuildMode = true;
				HUD.Instance.SetBuildType(1);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	public Dictionary<UnlockType, HashSet<string>> Unlocks = new Dictionary<UnlockType, HashSet<string>>();

	private List<UnlockItem> _cachedResult = new List<UnlockItem>();

	public bool WasUnlocked(UnlockType type, string name)
	{
		HashSet<string> value;
		if (Unlocks.TryGetValue(type, out value))
		{
			return value.Contains(name);
		}
		return false;
	}

	public void Serialize(WriteDictionary dict)
	{
		dict["UnlockChecker"] = Unlocks;
	}

	public void Deserialize(WriteDictionary dict)
	{
		if (!dict.Contains("UnlockChecker"))
		{
			UpdateMe(true);
		}
		else
		{
			Unlocks = dict.Get("UnlockChecker", Unlocks);
		}
	}

	public List<UnlockItem> UpdateMe(bool force)
	{
		_cachedResult.Clear();
		SDateTime time = SDateTime.Now();
		int year = time.Year;
		foreach (SoftwareType value in MarketSimulation.Active.SoftwareTypes.Values)
		{
			if (value.OneClient)
			{
				continue;
			}
			bool flag = false;
			if (!value.IsUnlocked(year))
			{
				continue;
			}
			if (!WasUnlocked(UnlockType.Software, value.Name))
			{
				flag = true;
				Unlocks.Append(UnlockType.Software, value.Name);
				_cachedResult.Add(new UnlockItem(UnlockType.Software, value.Name));
			}
			foreach (SoftwareCategory value2 in value.Categories.Values)
			{
				if (!value2.IsUnlocked(year))
				{
					continue;
				}
				string text = value.Name + "\n" + value2.Name;
				bool flag2 = flag;
				UnlockType unlockType = UnlockType.Category;
				string element = text;
				if (value.Categories.Count == 1)
				{
					unlockType = UnlockType.Software;
					element = value.Name;
				}
				if (!WasUnlocked(unlockType, element))
				{
					Unlocks.Append(unlockType, element);
					if (!flag2)
					{
						_cachedResult.Add(new UnlockItem(unlockType, element));
					}
					flag2 = true;
				}
				foreach (SoftwareAddOn value3 in value.AddOns.Values)
				{
					if (!value3.Categories.Contains(value2.Name))
					{
						continue;
					}
					string text2 = text + "\n" + value3.Name;
					if (!value3.IsUnlocked(year))
					{
						continue;
					}
					bool flag3 = flag2;
					if (!WasUnlocked(UnlockType.Addon, text2))
					{
						Unlocks.Append(UnlockType.Addon, text2);
						if (!flag3)
						{
							_cachedResult.Add(new UnlockItem(UnlockType.Addon, text2));
						}
						flag3 = true;
					}
					foreach (AddOnFeature value4 in value3.Features.Values)
					{
						string element2 = text2 + "\n" + value4.Name;
						if (!WasUnlocked(UnlockType.Feature, element2) && value4.IsUnlocked(MarketSimulation.Active.GetLatestTech(value4.Spec, time, value2, GameSettings.Instance.MyCompany), value2))
						{
							Unlocks.Append(UnlockType.Feature, element2);
							if (!flag3)
							{
								_cachedResult.Add(new UnlockItem(UnlockType.Feature, element2));
							}
						}
					}
				}
				foreach (FeatureBase value5 in value.Features.Values)
				{
					string element3 = text + "\n" + value5.Name;
					if (!WasUnlocked(UnlockType.Feature, element3) && value5.IsUnlocked(MarketSimulation.Active.GetLatestTech(value5.Spec, time, value2, GameSettings.Instance.MyCompany), value2))
					{
						Unlocks.Append(UnlockType.Feature, element3);
						if (!flag2)
						{
							_cachedResult.Add(new UnlockItem(UnlockType.Feature, element3));
						}
					}
				}
			}
		}
		if (force || (time.Month == 0 && time.Day == 0))
		{
			foreach (Furniture allFurnitureComponent in ObjectDatabase.Instance.GetAllFurnitureComponents())
			{
				if (allFurnitureComponent.Queryable() && !allFurnitureComponent.IsConstructionFurniture() && string.IsNullOrEmpty(allFurnitureComponent.Unlockable) && !allFurnitureComponent.Type.Equals("Award") && string.IsNullOrEmpty(allFurnitureComponent.MetalMarket) && !WasUnlocked(UnlockType.Furniture, allFurnitureComponent.name) && allFurnitureComponent.IsPurchasable() && allFurnitureComponent.IsUnlocked())
				{
					Unlocks.Append(UnlockType.Furniture, allFurnitureComponent.name);
					_cachedResult.Add(new UnlockItem(UnlockType.Furniture, allFurnitureComponent.name));
				}
			}
		}
		return _cachedResult;
	}
}
