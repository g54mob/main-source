using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevConsole;
using Tyd;
using UnityEngine;

public static class Localization
{
	public class Translation : IWorkshopItem
	{
		private Dictionary<string, string[]> _locs;

		private Dictionary<string, string[]> _secondaryLocs;

		public string[] FemaleNames;

		public string[] MaleNames;

		public string[] LastNames;

		public string[] FemaleLastNames;

		public Translation SecondaryTranslation;

		public uint GetWordCount()
		{
			uint num = 0u;
			foreach (KeyValuePair<string, string[]> loc in _locs)
			{
				for (int i = 0; i < loc.Value.Length; i++)
				{
					string input = loc.Value[i];
					num += (uint)(input.CountLetter(' ') + input.CountLetter('\n') + 1);
				}
			}
			return num;
		}

		public uint GetLineCount()
		{
			uint num = 0u;
			foreach (KeyValuePair<string, string[]> loc in _locs)
			{
				for (int i = 0; i < loc.Value.Length; i++)
				{
					string input = loc.Value[i];
					num += (uint)(input.CountLetter('\n') + 1);
				}
			}
			return num;
		}

		public override bool LoadLocalization()
		{
			return false;
		}

		public Dictionary<string, string[]> GetAllValues()
		{
			return _locs;
		}

		public bool NoModsHasValue(string input)
		{
			return _locs.ContainsKey(input.Strip(' '));
		}

		public void ReplaceValue(string input, string[] output)
		{
			string key = input.Strip(' ');
			if (_locs.ContainsKey(key))
			{
				_locs[key] = output;
			}
			else if (_secondaryLocs.ContainsKey(key))
			{
				_secondaryLocs[key] = output;
			}
		}

		public bool TryGetValue(string input, out string[] output)
		{
			string key = input.Strip(' ');
			if (!_locs.TryGetValue(key, out output))
			{
				return _secondaryLocs.TryGetValue(key, out output);
			}
			return true;
		}

		public override bool CheckCanUpload()
		{
			return !base.ItemTitle.Equals("English");
		}

		private string CheckKey(string key)
		{
			return key.Strip(' ');
		}

		private void AddNodes(XMLParser.XMLNode node, Dictionary<string, string[]> locs, string fileName, string parentName = null)
		{
			string text = node.TryGetAttribute("Name", node.TryGetAttribute("id"));
			string text2 = text;
			if (text != null)
			{
				text = CheckKey(text);
				text2 = text;
				if (parentName != null)
				{
					text = parentName + text;
				}
				if (!node.Name.ToLower().Equals("item"))
				{
					text = node.Name.ToUpper() + text;
				}
				string value;
				if (node.Attributes.TryGetValue("NamePlural", out value))
				{
					value = CheckKey(value);
					string[] array = ParsePlural(node.Value);
					AddPair(locs, text, fileName, array[0]);
					AddPair(locs, value, fileName, array[1]);
					AddPair(locs, text + "Singular", fileName, array[2]);
					AddPair(locs, text + "Plural", fileName, array[3]);
				}
				else if (node.Children != null && node.Children.Count > 0)
				{
					AddPair(locs, text, fileName, node.Children.SelectNotNull((XMLParser.XMLNode x) => x.Value).ToArray());
				}
				else
				{
					AddPair(locs, text, fileName, node.Value);
				}
			}
			if (node.Children != null && node.Children.Count > 0)
			{
				for (int num = 0; num < node.Children.Count; num++)
				{
					AddNodes(node.Children[num], locs, fileName, text2 ?? parentName);
				}
			}
		}

		private void AddPair(Dictionary<string, string[]> locs, string name, string fileName, params string[] values)
		{
			locs[name] = values;
		}

		public void AddNewNodes(TydDocument doc, string file)
		{
			for (int i = 0; i < doc.Nodes.Count; i++)
			{
				AddNodes(doc.Nodes[i], _locs, file);
			}
		}

		private void AddNodes(TydNode node, Dictionary<string, string[]> locs, string fileName, string parentName = null)
		{
			TydString tydString;
			TydList tydList;
			if ((tydString = node as TydString) != null)
			{
				AddPair(locs, (parentName == null) ? tydString.Name : (parentName + tydString.Name), fileName, tydString.Value);
			}
			else if ((tydList = node as TydList) != null)
			{
				AddPair(locs, (parentName == null) ? tydList.Name : (parentName + tydList.Name), fileName, (from x in tydList.Nodes.OfType<TydString>()
					select x.Value).ToArray());
			}
			else
			{
				TydTable tydTable;
				if ((tydTable = node as TydTable) == null)
				{
					return;
				}
				string text = parentName ?? "";
				if (tydTable.Name != null && !tydTable.Name.Equals("Item"))
				{
					text = tydTable.Name.ToUpper() + text;
				}
				string text2 = null;
				TydNode child = tydTable.GetChild("Name");
				if (child != null && child is TydString)
				{
					text2 = tydTable.GetChildValue("Name");
					TydString child2 = tydTable.GetChild<TydString>("Plural");
					if (child2 != null)
					{
						string text3 = child2.Value.Strip(' ');
						string[] array = ParsePlural(tydTable.GetChildValue("Value"));
						if (array == null)
						{
							return;
						}
						AddPair(locs, text2, fileName, array[0]);
						if (!text3.Equals(text2))
						{
							AddPair(locs, text3, fileName, array[1]);
						}
						AddPair(locs, text2 + "Singular", fileName, array[2]);
						AddPair(locs, text2 + "Plural", fileName, array[3]);
					}
					else
					{
						TydNode child3 = tydTable.GetChild("Value", true);
						TydString tydString2;
						if ((tydString2 = child3 as TydString) != null)
						{
							AddPair(locs, text + text2, fileName, tydString2.Value);
						}
						else
						{
							AddPair(locs, text + text2, fileName, (from x in ((TydList)child3).Nodes.OfType<TydString>()
								select x.Value).ToArray());
						}
					}
				}
				else
				{
					bool flag = true;
					foreach (TydString item in tydTable.Nodes.OfType<TydString>())
					{
						string name = item.Name;
						if (flag)
						{
							text2 = name;
							flag = false;
						}
						AddPair(locs, text + item.Name, fileName, item.Value);
					}
					foreach (TydList item2 in from x in tydTable.Nodes.OfType<TydList>()
						where x.Nodes.TrueForAll((TydNode z) => z is TydString)
						select x)
					{
						string name2 = item2.Name;
						if (flag)
						{
							text2 = name2;
							flag = false;
						}
						AddPair(locs, text + item2.Name, fileName, (from x in item2.Nodes.OfType<TydString>()
							select x.Value).ToArray());
					}
					foreach (TydTable item3 in tydTable.Nodes.OfType<TydTable>())
					{
						AddNodes(item3, locs, fileName, text);
					}
				}
				foreach (TydList item4 in tydTable.Nodes.OfType<TydList>())
				{
					if ("Name".Equals(node.Name) || "Plural".Equals(node.Name) || "Value".Equals(node.Name))
					{
						continue;
					}
					for (int num = 0; num < item4.Nodes.Count; num++)
					{
						TydNode tydNode = item4.Nodes[num];
						if (tydNode is TydTable)
						{
							string text4 = text2 ?? parentName;
							TydString tydString3;
							if (num > 0 && text4 != null && (tydString3 = item4.Nodes[num - 1] as TydString) != null)
							{
								text4 = tydString3.Value.ToUpper() + text4;
							}
							AddNodes(tydNode, locs, fileName, text4);
						}
					}
				}
			}
		}

		private string[] ParsePlural(string node)
		{
			int num = node.IndexOf("[");
			int num2 = node.IndexOf("]");
			if (num < 0 || num2 < 0)
			{
				DevConsole.Console.LogError("Incorrectly formatted plural key: " + node);
				return null;
			}
			string[] array = node.Substring(num + 1, num2 - num - 1).Split('|');
			if (array.Length == 0)
			{
				DevConsole.Console.LogError("Incorrectly formatted plural key: " + node);
				return null;
			}
			string text = node.Substring(0, num);
			string text2 = node.Substring(num2 + 1);
			string text3 = array[0];
			string text4 = ((array.Length > 1) ? array[1] : text3);
			return new string[4]
			{
				text3,
				text4,
				text + text3.ToLower() + text2,
				text + text4.ToLower() + text2
			};
		}

		public void LoadSecondary(string folder)
		{
			string[] files = Directory.GetFiles(folder, "*.tyd");
			foreach (string text in files)
			{
				if (Path.GetFileNameWithoutExtension(text).ToLower().Equals("meta"))
				{
					continue;
				}
				try
				{
					TydFile tydFile = TydFile.FromContent(Utilities.ReadOnlyReadAllText(text), text);
					for (int j = 0; j < tydFile.DocumentNode.Nodes.Count; j++)
					{
						AddNodes(tydFile.DocumentNode.Nodes[j], _secondaryLocs, Path.GetFileName(text));
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Error in file " + Path.GetFileName(text) + ":\n" + ex.ToString());
				}
			}
		}

		public Translation(string folder)
		{
			InitMod(folder, 0f);
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			_locs = new Dictionary<string, string[]>();
			_secondaryLocs = new Dictionary<string, string[]>();
			bool flag = false;
			string[] files = Directory.GetFiles(folder, "*.tyd");
			foreach (string text in files)
			{
				if (Path.GetFileNameWithoutExtension(text).ToLower().Equals("meta"))
				{
					continue;
				}
				try
				{
					TydFile tydFile = TydFile.FromContent(Utilities.ReadOnlyReadAllText(text), text);
					for (int j = 0; j < tydFile.DocumentNode.Nodes.Count; j++)
					{
						AddNodes(tydFile.DocumentNode.Nodes[j], _locs, Path.GetFileName(text));
					}
					flag = true;
				}
				catch (Exception ex)
				{
					throw new Exception("Error in file " + Path.GetFileName(text) + ":\n" + ex.ToString());
				}
			}
			if (!flag)
			{
				DevConsole.Console.LogWarning("Localization: " + base.ItemTitle + " is in XML format and some translations may not work! You should use the CONVERT_LOCALIZATION_TYD command to convert your files to TYD");
				files = Directory.GetFiles(folder, "*.xml");
				foreach (string text2 in files)
				{
					try
					{
						XMLParser.XMLNode node = XMLParser.ParseXML(Utilities.ReadOnlyReadAllText(text2));
						AddNodes(node, _locs, Path.GetFileName(text2));
					}
					catch (Exception ex2)
					{
						throw new Exception("Error in file " + Path.GetFileName(text2) + ":\n" + ex2.ToString());
					}
				}
			}
			foreach (DLCObject value in GameData.InstalledDLC.Values)
			{
				TydDocument translation = value.GetTranslation(base.ItemTitle);
				if (translation != null)
				{
					for (int k = 0; k < translation.Nodes.Count; k++)
					{
						AddNodes(translation.Nodes[k], _locs, value.DLCName);
					}
				}
			}
			if (File.Exists(Path.Combine(folder, "femalefirstnames.txt")))
			{
				FemaleNames = File.ReadAllLines(Path.Combine(folder, "femalefirstnames.txt"));
			}
			if (File.Exists(Path.Combine(folder, "malefirstnames.txt")))
			{
				MaleNames = File.ReadAllLines(Path.Combine(folder, "malefirstnames.txt"));
			}
			if (File.Exists(Path.Combine(folder, "lastnames.txt")))
			{
				LastNames = File.ReadAllLines(Path.Combine(folder, "lastnames.txt"));
			}
			if (File.Exists(Path.Combine(folder, "femalelastnames.txt")))
			{
				FemaleLastNames = File.ReadAllLines(Path.Combine(folder, "femalelastnames.txt"));
			}
			LoadTime += Time.realtimeSinceStartup - realtimeSinceStartup;
		}

		public override string GetWorkshopType()
		{
			return "Localization";
		}

		public override string[] GetValidExts()
		{
			return new string[4] { "xml", "txt", "png", "tyd" };
		}

		public override string[] ExtraTags()
		{
			return new string[0];
		}

		public override string ToString()
		{
			return base.ItemTitle;
		}

		public override string GetActualString()
		{
			return base.ItemTitle;
		}

		public override void SteamNameUpdated()
		{
			if (base.ItemTitle.Equals(OriginalTranslation))
			{
				SetTranslation(base.ItemTitle);
			}
		}

		public float GetTranslatedPercent()
		{
			Translation translation = Translations.FirstOrDefault((Translation x) => x.ItemTitle.Equals("English"));
			if (translation != null)
			{
				int num = 0;
				foreach (string key in translation._locs.Keys)
				{
					if (_locs.ContainsKey(key))
					{
						num++;
					}
				}
				return (float)num / (float)translation._locs.Count;
			}
			return 1f;
		}

		public override string GetExtraInfo()
		{
			return "Translated".Loc(GetTranslatedPercent().ToPercent());
		}

		public override int GetCount()
		{
			return _locs.Count;
		}
	}

	private static List<Translation> Translations;

	public static string OriginalTranslation;

	public static Translation CurrentTranslation;

	public static Translation English;

	public static string LocalizationFolder
	{
		get
		{
			return Path.Combine(Utilities.GetRoot(), "Localization");
		}
	}

	public static Translation GetLanguage(string name, Translation def = null)
	{
		return Translations.FirstOrDefault((Translation x) => x.ItemTitle.Equals(name), def);
	}

	public static IEnumerable<Translation> GetLanguages()
	{
		for (int i = 0; i < Translations.Count; i++)
		{
			yield return Translations[i];
		}
	}

	public static void SetTranslation(string name)
	{
		SetTranslation(GetLanguage(name, English ?? Translations.FirstOrDefault()));
	}

	public static void SetTranslation(Translation tr)
	{
		CurrentTranslation = tr;
		if (LanguageWindow.Instance != null)
		{
			LanguageWindow.Instance.RefreshMainMenu();
		}
	}

	static Localization()
	{
		Translations = new List<Translation>();
		OriginalTranslation = null;
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		string localizationFolder = LocalizationFolder;
		if (!Directory.Exists(localizationFolder))
		{
			Directory.CreateDirectory(localizationFolder);
		}
		CopyDefault();
		LoadLanguages();
		SetTranslation("English");
		Debug.Log("Localization load time: " + (Time.realtimeSinceStartup - realtimeSinceStartup).SecondsToTime());
		if (LoadDebugger.Instance != null)
		{
			LoadDebugger.AddInfo("Finished loading languages");
		}
		foreach (Furniture allFurnitureComponent in ObjectDatabase.Instance.GetAllFurnitureComponents())
		{
			CheckFurnResub(allFurnitureComponent);
		}
	}

	public static void CopyDefault()
	{
		string localizationFolder = LocalizationFolder;
		foreach (string item in new string[1] { "English" }.OrderBy((string x) => x))
		{
			string text = Path.Combine(localizationFolder, item);
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			TextAsset[] array = Resources.LoadAll<TextAsset>("Localization/" + item);
			foreach (TextAsset textAsset in array)
			{
				try
				{
					File.WriteAllText(Path.Combine(text, textAsset.name + ".tyd"), textAsset.text);
				}
				catch (Exception)
				{
				}
			}
		}
	}

	public static void AddLanguage(Translation l)
	{
		for (int i = 0; i < Translations.Count; i++)
		{
			Translation translation = Translations[i];
			if (translation.SameRoot(l.RootInvariant, true))
			{
				if (translation == CurrentTranslation)
				{
					CurrentTranslation = l;
				}
				Translations.RemoveAt(i);
				ModWindow.RemoveMod(translation);
				i--;
			}
		}
		if (English == null && l.ItemTitle.Equals("English"))
		{
			English = l;
		}
		Translations.Add(l);
	}

	public static void LoadLanguages()
	{
		string[] directories = Directory.GetDirectories(LocalizationFolder);
		foreach (string text in directories)
		{
			try
			{
				AddLanguage(new Translation(text));
			}
			catch (Exception ex)
			{
				LoadDebugger.AddError("Failed loading language: " + Path.GetFileName(text));
				new FailMod("Localization", text, ex.ToString());
				Debug.LogError("Localization failed loading language: " + Path.GetFileName(text) + ". With error:\n" + ex.ToString());
			}
		}
	}

	public static IWorkshopItem LoadSteamLanguage(string path, string name)
	{
		try
		{
			Translation translation = new Translation(path);
			AddLanguage(translation);
			if (translation.ItemTitle.Equals(OriginalTranslation))
			{
				SetTranslation(translation);
			}
			return translation;
		}
		catch (Exception ex)
		{
			string text = "Error loading localization " + name + ":\n" + ex.ToString();
			Debug.Log(text);
			DevConsole.Console.LogError(text);
			return new FailMod("Localization", path, ex.ToString());
		}
	}

	public static void CheckFurnResub(Furniture f)
	{
		if (f.ButtonDescription != null && f.ButtonDescription.StartsWith("[") && f.ButtonDescription.EndsWith("]"))
		{
			string text = f.ButtonDescription.Substring(1, f.ButtonDescription.Length - 2);
			ReSubFurn("FURNITURE" + f.name, "FURNITURE" + text);
		}
	}

	private static void ReSubFurn(string name, string replace)
	{
		foreach (Translation translation in Translations)
		{
			string[] output;
			string[] output2;
			if (translation.TryGetValue(replace, out output) && output.Length > 1 && translation.TryGetValue(name, out output2))
			{
				if (output2.Length < 2)
				{
					output2 = new string[2]
					{
						output2[0],
						null
					};
					translation.ReplaceValue(name, output2);
				}
				output2[1] = output[1];
			}
		}
	}

	public static string[] GetFurniture(string name, string defaultName, string desc)
	{
		if (CurrentTranslation == null)
		{
			return new string[2] { defaultName, desc };
		}
		string[] output;
		if (CurrentTranslation.TryGetValue("FURNITURE" + name, out output))
		{
			return output;
		}
		return new string[2] { defaultName, desc };
	}

	public static string GetTutorial(string id)
	{
		if (CurrentTranslation == null)
		{
			return "[Localization not loaded]";
		}
		id = "TUTORIAL" + id;
		string[] output;
		if (!CurrentTranslation.TryGetValue(id, out output))
		{
			return Fallback(id);
		}
		return output[0];
	}

	private static string Fallback(string id)
	{
		string[] output;
		if (Options.LocalizationFallback && English != null && English.TryGetValue(id, out output))
		{
			return output[0];
		}
		return "[NoLoc]" + id;
	}

	public static string[] GetSoftware(SoftwareType sw)
	{
		if (CurrentTranslation == null)
		{
			return new string[2] { sw.Name, sw.Description };
		}
		string[] output;
		if (CurrentTranslation.TryGetValue("SOFTWARE" + sw.Name, out output))
		{
			return output;
		}
		return new string[2] { sw.Name, sw.Description };
	}

	public static string[] GetSoftwareCat(SoftwareType sw, string cat)
	{
		SoftwareCategory orNull = sw.Categories.GetOrNull(cat);
		string text = ((orNull == null) ? null : orNull.Description);
		if (CurrentTranslation == null)
		{
			return new string[2] { cat, text };
		}
		string[] output;
		if ("Default".Equals(cat))
		{
			if (CurrentTranslation.TryGetValue("SoftwareCategoryDefault", out output))
			{
				return output;
			}
			return new string[2] { cat, text };
		}
		if (CurrentTranslation.TryGetValue("CATEGORY" + sw.Name + cat, out output))
		{
			return output;
		}
		return new string[2] { cat, text };
	}

	public static string GetSoftwareComponent(SoftwareType sw, string component)
	{
		if (CurrentTranslation == null)
		{
			return component;
		}
		string[] output;
		if (CurrentTranslation.TryGetValue("COMPONENT" + sw.Name + component, out output))
		{
			return output[0];
		}
		return component;
	}

	public static FormatColorString LocSW(this string sw)
	{
		if (CurrentTranslation == null)
		{
			return sw;
		}
		string[] output;
		if (CurrentTranslation.TryGetValue("SOFTWARE" + sw, out output))
		{
			return output[0];
		}
		return sw;
	}

	public static FormatColorString LocSWC(this string cat, string sw)
	{
		if (CurrentTranslation == null)
		{
			return cat;
		}
		string[] output;
		if ("Default".Equals(cat))
		{
			if (CurrentTranslation.TryGetValue("SoftwareCategoryDefault", out output))
			{
				return output[0];
			}
			return cat;
		}
		if (CurrentTranslation.TryGetValue("CATEGORY" + sw + cat, out output))
		{
			return output[0];
		}
		return cat;
	}

	public static FormatColorString LocSWFull(this string type, string category)
	{
		if (category == null || category.Equals("Default"))
		{
			return type.LocSW();
		}
		return category.LocSWC(type) + " " + type.LocSW();
	}

	public static FormatColorString SWFeat(this string feat, string swType)
	{
		return GetFeature(swType, feat)[0];
	}

	public static string[] GetFeature(SoftwareType sw, string feature)
	{
		if (CurrentTranslation == null)
		{
			FeatureBase value;
			if (sw.Features.TryGetValue(feature, out value))
			{
				return new string[2] { value.Name, value.Description };
			}
			return new string[2] { feature, "" };
		}
		string[] output;
		if (CurrentTranslation.TryGetValue("FEATURE" + sw.Name + feature, out output))
		{
			return output;
		}
		FeatureBase value2;
		if (sw.Features.TryGetValue(feature, out value2))
		{
			return new string[2] { value2.Name, value2.Description };
		}
		return new string[2] { feature, "" };
	}

	private static bool TryGetFeature(string sw, string feature, out FeatureBase f)
	{
		SoftwareType value;
		if (MarketSimulation.Active.SoftwareTypes.TryGetValue(sw, out value))
		{
			return value.Features.TryGetValue(feature, out f);
		}
		f = null;
		return false;
	}

	public static string[] GetFeature(string sw, string feature)
	{
		string[] output;
		if (CurrentTranslation != null && CurrentTranslation.TryGetValue("FEATURE" + sw + feature, out output))
		{
			return output;
		}
		FeatureBase f;
		if (TryGetFeature(sw, feature, out f))
		{
			return new string[2] { f.Name, f.Description };
		}
		return new string[1] { feature };
	}

	public static string[] GetFeature(FeatureBase f)
	{
		if (CurrentTranslation == null)
		{
			return new string[2] { f.Name, f.Description };
		}
		string[] output;
		if (CurrentTranslation.TryGetValue("FEATURE" + f.Software + f.Name, out output))
		{
			return output;
		}
		return new string[2] { f.Name, f.Description };
	}

	public static string Loc(this string input, params object[] args)
	{
		return Utilities.RobustStringFormat(input.Loc(), false, false, args);
	}

	public static string LocNoColor(this string input)
	{
		return Utilities.RobustStringFormat(input.Loc(), false, false);
	}

	public static string LocColor(this string input, params object[] args)
	{
		return Utilities.RobustStringFormat(input.Loc(), true, false, args);
	}

	public static string LocColorAll(this string input, params object[] args)
	{
		return Utilities.RobustStringFormat(input.Loc(), true, true, args);
	}

	public static string[] LocAll(this string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return null;
		}
		if (CurrentTranslation == null)
		{
			return null;
		}
		string[] output;
		if (CurrentTranslation.TryGetValue(input, out output))
		{
			return output;
		}
		Translation language = GetLanguage("English", Translations.FirstOrDefault());
		if (language != null && language.TryGetValue(input, out output))
		{
			return output;
		}
		return null;
	}

	public static string Loc(this string input)
	{
		if (string.IsNullOrEmpty(input) || input.Length == 1)
		{
			return input;
		}
		if (CurrentTranslation == null)
		{
			return "[Localization not loaded]";
		}
		string[] output;
		if (CurrentTranslation.TryGetValue(input, out output))
		{
			return output[0];
		}
		Translation language = GetLanguage("English", Translations.FirstOrDefault());
		if (language != null && language.TryGetValue(input, out output))
		{
			return output[0];
		}
		return Fallback(input);
	}

	public static string LocTry(this string input)
	{
		if (string.IsNullOrEmpty(input) || input.Length == 1)
		{
			return input;
		}
		if (CurrentTranslation == null)
		{
			return input;
		}
		string[] output;
		if (CurrentTranslation.TryGetValue(input, out output))
		{
			return output[0];
		}
		return input;
	}

	public static bool LocTry(this string input, out string res)
	{
		res = null;
		if (string.IsNullOrEmpty(input) || input.Length == 1)
		{
			return false;
		}
		if (CurrentTranslation == null)
		{
			return false;
		}
		string[] output;
		if (CurrentTranslation.TryGetValue(input, out output))
		{
			res = output[0];
			return true;
		}
		return false;
	}

	public static string LocDef(this string input, string defaultLoc)
	{
		if (string.IsNullOrEmpty(input) || input.Length == 1)
		{
			return defaultLoc;
		}
		if (CurrentTranslation == null)
		{
			return defaultLoc;
		}
		string[] output;
		if (CurrentTranslation.TryGetValue(input, out output))
		{
			return output[0];
		}
		Translation language = GetLanguage("English", Translations.FirstOrDefault());
		if (language != null && language.TryGetValue(input, out output))
		{
			return output[0];
		}
		return defaultLoc;
	}

	public static string LocPlural(this string input, int number)
	{
		if (number == 1)
		{
			return Utilities.RobustStringFormat((input + "Singular").Loc(), false, false, number);
		}
		return Utilities.RobustStringFormat((input + "Plural").Loc(), false, false, number);
	}

	public static string LocPlural(this string input, double number)
	{
		if (Math.Abs(number - 1.0) < 1E-06)
		{
			return Utilities.RobustStringFormat((input + "Singular").Loc(), false, false, number);
		}
		return Utilities.RobustStringFormat((input + "Plural").Loc(), false, false, number);
	}

	public static string LocPlural(this string input, uint number, bool dot = false)
	{
		string text = (dot ? number.ToString("N0") : number.ToString());
		if (number == 1)
		{
			return Utilities.RobustStringFormat((input + "Singular").Loc(), false, false, text);
		}
		return Utilities.RobustStringFormat((input + "Plural").Loc(), false, false, text);
	}
}
