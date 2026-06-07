using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DevConsole;
using Tyd;
using UnityEngine;

[Serializable]
public class ModPackage : IWorkshopItem
{
	public readonly Dictionary<string, SoftwareType> SoftwareTypes;

	public readonly Dictionary<string, SoftwareTypeOverride> SoftwareTypeOverrides;

	public readonly Dictionary<string, CompanyType> CompanyTypes;

	public readonly Dictionary<string, RandomNameGenerator> NameGenerators;

	public HardwareDesign[] HardwareDesigns;

	public readonly string[] DeleteCompanyTypes;

	public readonly PersonalityGraph Personalities;

	private bool _enabled;

	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			_enabled = value;
		}
	}

	public ModPackage(string root, Dictionary<string, SoftwareType> s, Dictionary<string, SoftwareTypeOverride> so, Dictionary<string, CompanyType> c, Dictionary<string, RandomNameGenerator> n, PersonalityGraph p, string[] dct, List<HardwareDesign> designs, float loadTime)
	{
		InitMod(root, loadTime);
		SoftwareTypes = s;
		string itemTitle = base.ItemTitle;
		foreach (KeyValuePair<string, SoftwareType> softwareType in SoftwareTypes)
		{
			softwareType.Value.ModName = itemTitle;
		}
		SoftwareTypeOverrides = so;
		foreach (KeyValuePair<string, SoftwareTypeOverride> softwareTypeOverride in SoftwareTypeOverrides)
		{
			softwareTypeOverride.Value.ModName = itemTitle;
		}
		CompanyTypes = c;
		NameGenerators = n;
		Personalities = p;
		DeleteCompanyTypes = dct;
		if (designs != null)
		{
			HardwareDesigns = designs.ToArray();
			for (int i = 0; i < HardwareDesigns.Length; i++)
			{
				HardwareDesigns[i].Parent = this;
			}
		}
		else
		{
			HardwareDesigns = new HardwareDesign[0];
		}
	}

	public static ModPackage Load(string root)
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		Dictionary<string, SoftwareType> dictionary = new Dictionary<string, SoftwareType>();
		Dictionary<string, SoftwareTypeOverride> dictionary2 = new Dictionary<string, SoftwareTypeOverride>();
		Dictionary<string, CompanyType> dictionary3 = new Dictionary<string, CompanyType>();
		Dictionary<string, RandomNameGenerator> dictionary4 = new Dictionary<string, RandomNameGenerator>();
		PersonalityGraph personalityGraph = null;
		if (Directory.Exists(root + "/NameGenerators"))
		{
			string[] files = Directory.GetFiles(root + "/NameGenerators", "*.txt", SearchOption.AllDirectories);
			foreach (string path in files)
			{
				try
				{
					RandomNameGenerator randomNameGenerator = RandomNameGenerator.Load(File.ReadAllLines(path));
					randomNameGenerator.ErrorCheck();
					dictionary4.Add(Path.GetFileNameWithoutExtension(path), randomNameGenerator);
				}
				catch (Exception ex)
				{
					throw new Exception("Error loading name generator: " + Path.GetFileName(path) + " with error:\n" + ex.Message);
				}
			}
		}
		string path2 = Path.Combine(root, "SoftwareTypes");
		if (Directory.Exists(path2))
		{
			List<TydFile> list = null;
			try
			{
				list = TydFile.ReadAndResolvePath(path2, SearchOption.AllDirectories, "meta");
			}
			catch (Exception ex2)
			{
				throw new Exception("Error loading software files:\n" + ex2.Message);
			}
			if (list != null)
			{
				for (int j = 0; j < list.Count; j++)
				{
					TydFile tydFile = list[j];
					foreach (TydCollection item in tydFile.DocumentNode.Nodes.OfType<TydCollection>())
					{
						if (item.AttributeAbstract)
						{
							continue;
						}
						try
						{
							if (item.GetChild("Override") != null)
							{
								SoftwareTypeOverride softwareTypeOverride = new SoftwareTypeOverride(item, root);
								dictionary2[softwareTypeOverride.Name] = softwareTypeOverride;
							}
							else
							{
								SoftwareType softwareType = new SoftwareType(item, Path.GetFileName(root), root);
								dictionary[softwareType.Name] = softwareType;
							}
						}
						catch (Exception ex3)
						{
							throw new Exception("Error loading software type: " + tydFile.FileName + " with error:\n" + ex3.Message);
						}
					}
				}
			}
		}
		string[] array = new string[0];
		if (Directory.Exists(root + "/CompanyTypes"))
		{
			string[] files2 = Directory.GetFiles(root + "/CompanyTypes", "*.tyd", SearchOption.AllDirectories);
			string text = Path.Combine(Path.Combine(root, "CompanyTypes"), "delete.txt");
			if (File.Exists(text))
			{
				array = Utilities.ReadAllText(text).SplitByNewLines();
			}
			string[] files = files2;
			foreach (string text2 in files)
			{
				if (!Path.GetFileNameWithoutExtension(text2).ToLower().Equals("meta"))
				{
					try
					{
						CompanyType companyType = new CompanyType(TydFromText.ParseOne(Utilities.ReadAllText(text2)) as TydCollection);
						dictionary3[companyType.Name] = companyType;
					}
					catch (Exception ex4)
					{
						throw new Exception("Error loading company type: " + Path.GetFileName(text2) + " with error:\n" + ex4.Message);
					}
				}
			}
		}
		if (File.Exists(root + "/Personalities.tyd"))
		{
			try
			{
				personalityGraph = new PersonalityGraph(TydFromText.ParseOne(Utilities.ReadAllText(root + "/Personalities.tyd")) as TydCollection);
			}
			catch (Exception ex5)
			{
				DevConsole.Console.LogError("Error loading personalities in mod " + Path.GetFileName(root) + " with error:\n" + ex5.Message);
			}
		}
		if (dictionary4.Count == 0 && dictionary.Count == 0 && dictionary2.Count == 0 && dictionary3.Count == 0 && (personalityGraph == null || personalityGraph.PersonalityTraits.Count == 0) && array.Length == 0)
		{
			throw new Exception("Mod is empty or not supported in this version of Software Inc.");
		}
		List<HardwareDesign> list2 = null;
		if (Directory.Exists(root + "/HardwareDesign"))
		{
			string[] files = Directory.GetFiles(root + "/HardwareDesign", "*.tyd", SearchOption.AllDirectories);
			foreach (string text3 in files)
			{
				TydTable tydTable = TydFromText.ParseOne(Utilities.ReadAllText(text3)) as TydTable;
				if (tydTable == null)
				{
					continue;
				}
				try
				{
					string childValue = tydTable.GetChildValue("ID");
					HardwareDesign value;
					if (!ObjectDatabase.Instance.HardwareDesigns.TryGetValue(childValue, out value) || !value.BuiltIn)
					{
						HardwareDesign hardwareDesign = HardwareDesign.LoadDesign(tydTable, text3);
						ObjectDatabase.Instance.HardwareDesigns[childValue] = hardwareDesign;
						if (list2 == null)
						{
							list2 = new List<HardwareDesign>();
						}
						list2.Add(hardwareDesign);
					}
					else
					{
						DevConsole.Console.LogError("Error loading hardware design: " + Path.GetFileName(text3) + ", can't override built-in hardware designs!");
					}
				}
				catch (Exception ex6)
				{
					DevConsole.Console.LogError("Error loading hardware design: " + Path.GetFileName(text3) + " with error:\n" + ex6.Message);
				}
			}
		}
		ModPackage modPackage = new ModPackage(root, dictionary, dictionary2, dictionary3, dictionary4, personalityGraph, array, list2, Time.realtimeSinceStartup - realtimeSinceStartup);
		SoftwareType[] array2 = new SoftwareType[0];
		CompanyType[] array3 = new CompanyType[0];
		try
		{
			array2 = GameData.AllSoftwareTypes(new ModPackage[1] { modPackage }).ToArray();
			array3 = GameData.AllCompanyTypes(modPackage).ToArray();
		}
		catch (Exception ex7)
		{
			throw new Exception("Error applying mod with error:\n" + ex7.Message);
		}
		string text4 = GameData.CheckForErrors(array2);
		if (text4 != null)
		{
			throw new Exception("Error applying mod with error:\n" + text4);
		}
		text4 = OtherErrors(array2, array3, GameData.GetRandomNameGenerators(dictionary4));
		if (text4 != null)
		{
			throw new Exception("Error applying mod with error:\n" + text4);
		}
		return modPackage;
	}

	public static string OtherErrors(SoftwareType[] types, CompanyType[] cTypes, Dictionary<string, RandomNameGenerator> generators)
	{
		foreach (SoftwareType softwareType in types)
		{
			if (softwareType.OneClient && (softwareType.Categories.Count > 1 || !softwareType.Categories.ContainsKey("Default")))
			{
				return softwareType.Name + " is a contract software type and cannot have categories defined";
			}
			foreach (SoftwareCategory value2 in softwareType.Categories.Values)
			{
				string nameGenName = value2.GetNameGenName();
				if (nameGenName == null)
				{
					return "Name generator not defined for category " + value2.Name + " in software " + softwareType.Name;
				}
				if (!generators.ContainsKey(nameGenName))
				{
					return "Name generator " + value2.GetNameGenName() + " for category " + value2.Name + " in software " + softwareType.Name + " does not exist";
				}
			}
			foreach (SoftwareAddOn value3 in softwareType.AddOns.Values)
			{
				string nameGenName2 = value3.GetNameGenName();
				if (nameGenName2 == null)
				{
					return "Name generator not defined for category " + value3.Name + " in software " + softwareType.Name;
				}
				if (!generators.ContainsKey(nameGenName2))
				{
					return "Name generator " + value3.GetNameGenName() + " for category " + value3.Name + " in software " + softwareType.Name + " does not exist";
				}
			}
		}
		foreach (CompanyType comp in cTypes)
		{
			List<string> list = comp.Types.Keys.Select((KeyValuePair<string, string> x) => x.Key).ToList();
			if (list.Count != list.Distinct().Count())
			{
				return "Company type " + comp.Name + " has same software type defined twice";
			}
			foreach (KeyValuePair<KeyValuePair<string, string>, float> type in comp.Types)
			{
				KeyValuePair<KeyValuePair<string, string>, float> item1 = type;
				SoftwareType softwareType2 = types.FirstOrDefault((SoftwareType x) => x.Name.Equals(item1.Key.Key));
				if (softwareType2 == null)
				{
					return string.Concat("Software ", type.Key, " in company type ", comp.Name, " does not exist");
				}
				if (type.Key.Value != null && !softwareType2.Categories.ContainsKey(type.Key.Value))
				{
					return "Category " + type.Key.Value + " for software " + type.Key.Key + " in company type " + comp.Name + " does not exist";
				}
			}
			if (comp.Addons != null)
			{
				foreach (KeyValuePair<KeyValuePair<string, string>, float> addon in comp.Addons)
				{
					KeyValuePair<KeyValuePair<string, string>, float> item2 = addon;
					SoftwareType softwareType3 = types.FirstOrDefault((SoftwareType x) => x.Name.Equals(item2.Key.Key));
					if (softwareType3 == null)
					{
						return string.Concat("Software ", addon.Key, " in company type ", comp.Name, " does not exist");
					}
					SoftwareAddOn value;
					if (softwareType3.AddOns.TryGetValue(addon.Key.Value, out value))
					{
						if (!value.Hardware)
						{
							return "Addon " + addon.Key.Value + " for software " + addon.Key.Key + " in company type " + comp.Name + " is not available for external development";
						}
						continue;
					}
					return "Addon " + addon.Key.Value + " for software " + addon.Key.Key + " in company type " + comp.Name + " does not exist";
				}
			}
			if (comp.ForceType != null)
			{
				SoftwareType softwareType4 = types.FirstOrDefault((SoftwareType x) => x.Name.Equals(comp.ForceType));
				if (softwareType4 == null)
				{
					return "Forced release software " + comp.ForceType + " in company type " + comp.Name + " does not exist";
				}
				if (comp.ForceCat != null && !softwareType4.Categories.ContainsKey(comp.ForceCat))
				{
					return "Forced software release category " + comp.ForceCat + " for software " + comp.ForceType + " in company type " + comp.Name + " does not exist";
				}
			}
			if (comp.NameGen != null && !generators.ContainsKey(comp.NameGen))
			{
				return "Name generator " + comp.NameGen + " for company type " + comp.Name + " does not exist";
			}
		}
		return null;
	}

	public override string ToString()
	{
		return base.ItemTitle;
	}

	public override string GetWorkshopType()
	{
		return "Data mod";
	}

	public override string[] GetValidExts()
	{
		return new string[7] { "txt", "xml", "png", "tyd", "gltf", "glb", "obj" };
	}

	public override string[] ExtraTags()
	{
		List<string> list = new List<string>();
		if ((SoftwareTypes != null && SoftwareTypes.Count > 0) || (SoftwareTypeOverrides != null && SoftwareTypeOverrides.Count > 0))
		{
			list.Add("Software types");
		}
		if (Personalities != null && Personalities.PersonalityTraits.Count > 0)
		{
			list.Add("Personalities");
		}
		if (CompanyTypes != null && CompanyTypes.Count > 0)
		{
			list.Add("AI companies");
		}
		return list.ToArray();
	}

	public override string GetActualString()
	{
		return base.ItemTitle;
	}

	public override bool GenerateLocalization()
	{
		string text = Path.Combine(base.Root, "Localization");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string text2 = Path.Combine(text, "English");
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		GameData.ExportSoftwareToLocalization(SoftwareTypes.Values, HardwareDesigns, Path.Combine(text2, "Software.tyd"), false);
		return true;
	}

	public void Unload()
	{
		if (HardwareDesigns == null)
		{
			return;
		}
		for (int i = 0; i < HardwareDesigns.Length; i++)
		{
			HardwareDesign hardwareDesign = HardwareDesigns[i];
			hardwareDesign.CleanUp(true, true, true, true);
			HardwareDesign value;
			if (ObjectDatabase.Instance.HardwareDesigns.TryGetValue(hardwareDesign.ID, out value) && value == hardwareDesign)
			{
				ObjectDatabase.Instance.HardwareDesigns.Remove(hardwareDesign.ID);
			}
		}
	}

	public override string GetExtraInfo()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = ((SoftwareTypes != null) ? SoftwareTypes.Count : 0);
		num += ((SoftwareTypeOverrides != null) ? SoftwareTypeOverrides.Count : 0);
		if (num > 0)
		{
			stringBuilder.AppendLine("SoftwareType".LocPlural(num));
		}
		if (CompanyTypes != null && CompanyTypes.Count > 0)
		{
			stringBuilder.AppendLine("AICompany".LocPlural(CompanyTypes.Count));
		}
		if (Personalities != null && Personalities.PersonalityTraits.Count > 0)
		{
			stringBuilder.AppendLine("Personality".LocPlural(Personalities.PersonalityTraits.Count));
		}
		return stringBuilder.ToString();
	}

	public override int GetCount()
	{
		return SoftwareTypeOverrides.Count + SoftwareTypes.Count;
	}
}
