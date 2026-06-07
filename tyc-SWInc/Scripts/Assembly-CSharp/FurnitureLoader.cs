using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using DevConsole;
using Tyd;
using UnityEngine;

public static class FurnitureLoader
{
	private class NodeWrapper
	{
		public XMLParser.XMLNode XMLNode;

		public TydNode TYDNode;

		public string Name
		{
			get
			{
				if (XMLNode == null)
				{
					return TYDNode.Name;
				}
				return XMLNode.Name;
			}
		}

		public string Value
		{
			get
			{
				if (XMLNode == null)
				{
					TydString tydString;
					if ((tydString = TYDNode as TydString) == null)
					{
						return null;
					}
					return tydString.Value;
				}
				return XMLNode.Value;
			}
		}

		public bool IsNull
		{
			get
			{
				if (XMLNode != null)
				{
					if (string.IsNullOrEmpty(XMLNode.Value))
					{
						return XMLNode.Children.Count == 0;
					}
					return false;
				}
				TydString tydString = TYDNode as TydString;
				if (tydString != null)
				{
					return string.IsNullOrEmpty(tydString.Value);
				}
				return false;
			}
		}

		public IEnumerable<NodeWrapper> Children
		{
			get
			{
				if (XMLNode != null)
				{
					for (int i = 0; i < XMLNode.Children.Count; i++)
					{
						yield return new NodeWrapper(XMLNode.Children[i]);
					}
					yield break;
				}
				TydCollection tydCollection;
				TydCollection n = (tydCollection = TYDNode as TydCollection);
				if (tydCollection != null && n.Nodes != null)
				{
					for (int i = 0; i < n.Nodes.Count; i++)
					{
						yield return new NodeWrapper(n.Nodes[i]);
					}
				}
			}
		}

		public IEnumerable<NodeWrapper> ChildrenCollections
		{
			get
			{
				if (XMLNode != null)
				{
					for (int i = 0; i < XMLNode.Children.Count; i++)
					{
						yield return new NodeWrapper(XMLNode.Children[i]);
					}
				}
				else
				{
					TydCollection tydCollection;
					if ((tydCollection = TYDNode as TydCollection) == null)
					{
						yield break;
					}
					foreach (TydCollection item in tydCollection.Nodes.OfType<TydCollection>())
					{
						yield return new NodeWrapper(item);
					}
				}
			}
		}

		public NodeWrapper(XMLParser.XMLNode xmlNode)
		{
			XMLNode = xmlNode;
		}

		public NodeWrapper(TydNode tydNode)
		{
			TYDNode = tydNode;
		}

		public NodeWrapper(string value)
		{
			XMLNode = new XMLParser.XMLNode(null, value);
		}

		public string TryGetAttribute(string key, string tydNode = null, string defValue = null)
		{
			if (XMLNode == null)
			{
				return GetNodeValue(tydNode ?? key, defValue);
			}
			return XMLNode.TryGetAttribute(key, defValue);
		}

		public string GetAttribute(string key)
		{
			if (XMLNode != null)
			{
				return XMLNode.GetAttribute(key);
			}
			return GetNodeValueForced(key);
		}

		public string GetNodeValue(string name, string def = null)
		{
			if (XMLNode == null)
			{
				return ((TydCollection)TYDNode).GetChildValue(name, false, def);
			}
			return XMLNode.GetNodeValue(name, def);
		}

		public string GetNodeValueForced(string name)
		{
			if (XMLNode == null)
			{
				return ((TydCollection)TYDNode).GetChildValue(name);
			}
			return XMLNode.GetNode(name).Value;
		}

		public T GetNodeValue<T>(string subName, T def)
		{
			if (XMLNode != null)
			{
				XMLParser.XMLNode node = XMLNode.GetNode(subName, false);
				if (node != null)
				{
					return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(node.Value);
				}
				return def;
			}
			return ((TydCollection)TYDNode).GetChildValue(subName, false, def);
		}

		public NodeWrapper[] GetDelimitedValue(params string[] delimiters)
		{
			if (XMLNode != null)
			{
				return XMLNode.Value.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).SelectInPlace((string x) => new NodeWrapper(x.Trim()));
			}
			TydCollection tydCollection;
			if ((tydCollection = TYDNode as TydCollection) != null)
			{
				return tydCollection.Nodes.SelectInPlace((TydNode x) => new NodeWrapper(x));
			}
			TydString tydString;
			if ((tydString = TYDNode as TydString) != null)
			{
				return tydString.Value.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).SelectInPlace((string x) => new NodeWrapper(x.Trim()));
			}
			return Array.Empty<NodeWrapper>();
		}

		public float[] GetDelimitedNodeFloat(string name, bool forced = true)
		{
			if (XMLNode != null)
			{
				XMLParser.XMLNode node = XMLNode.GetNode(name, forced);
				if (node != null)
				{
					return node.Value.Split(',').SelectInPlace((string x) => x.ConvertToFloat(name));
				}
				return Array.Empty<float>();
			}
			TydCollection child = ((TydCollection)TYDNode).GetChild<TydCollection>(name, forced);
			if (child == null)
			{
				return Array.Empty<float>();
			}
			return child.GetChildValues<float>().ToArray();
		}

		public float[] GetDelimitedFloat(string name)
		{
			if (XMLNode != null)
			{
				return XMLNode.Value.Split(',').SelectInPlace((string x) => x.ConvertToFloat(name));
			}
			TydCollection tydCollection;
			if ((tydCollection = TYDNode as TydCollection) != null)
			{
				return tydCollection.GetChildValues<float>().ToArray();
			}
			return Array.Empty<float>();
		}

		public bool Contains(string name)
		{
			if (XMLNode == null)
			{
				return ((TydCollection)TYDNode).Nodes.Any((TydNode x) => name.Equals(x.Name));
			}
			return XMLNode.Contains(name);
		}

		public NodeWrapper GetNode(string name, bool forced)
		{
			if (XMLNode != null)
			{
				XMLParser.XMLNode node = XMLNode.GetNode(name, forced);
				if (node == null)
				{
					return null;
				}
				return new NodeWrapper(node);
			}
			TydNode child = ((TydCollection)TYDNode).GetChild(name, forced);
			if (child == null)
			{
				return null;
			}
			return new NodeWrapper(child);
		}
	}

	public struct TransformAction
	{
		public Transform T;

		public string Parent;

		public Vector3 Position;

		public Vector3 Rotation;

		public TransformAction(Transform t, string parent, Vector3 position, Vector3 rotation)
		{
			T = t;
			Parent = parent;
			Position = position;
			Rotation = rotation;
		}
	}

	private static bool Initialized = false;

	public static List<FurnitureMod> LoadedFurniture = new List<FurnitureMod>();

	private static bool _hadErrors = false;

	private static List<Transform> _trCache = new List<Transform>();

	private static HashSet<Renderer> _forceShadow = new HashSet<Renderer>();

	private static List<TransformAction> _transformCache = new List<TransformAction>();

	private static Dictionary<Type, HashSet<string>> _redirectToFurniture = new Dictionary<Type, HashSet<string>> { 
	{
		typeof(Upgradable),
		new HashSet<string> { "TheScreen", "OnMat", "OffMat", "ChangeColorOffSecondary", "ChangeColorOffTertiary", "DisableObjs" }
	} };

	public static void ExportFurnLocalization(List<GameObject> furniture, string outputPath)
	{
		TydDocument tydDocument = new TydDocument();
		TydTable tydTable = tydDocument.AddChild(new TydTable("Furniture"));
		string[] array = new string[3];
		Localization.Translation language = Localization.GetLanguage("English");
		HashSet<string> hashSet = (File.Exists(outputPath) ? (from x in TydFile.FromFile(outputPath).DocumentNode.Nodes.OfType<TydString>()
			select x.Name).ToHashSet() : new HashSet<string>());
		HashSet<string> hashSet2 = new HashSet<string>();
		foreach (GameObject item in furniture)
		{
			Furniture component = item.GetComponent<Furniture>();
			if (component != null)
			{
				if (component.OnlyInEditor || !string.IsNullOrEmpty(component.LocalizeOverride))
				{
					continue;
				}
				string text = component.ButtonDescription ?? "";
				if (text.StartsWith("["))
				{
					text = "";
				}
				TydList tydList = tydTable.AddChild(new TydList(component.name.Strip(' '), component.GetDefaultName(), text));
				if (component.ColorSecondaryEnabled || component.ColorTertiaryEnabled)
				{
					int num = 0;
					array[0] = (array[1] = (array[2] = ""));
					if (!component.PrimaryColorName.Equals("Primary"))
					{
						array[0] = component.PrimaryColorName;
						num = 1;
					}
					if (!component.SecondaryColorName.Equals("Secondary"))
					{
						array[1] = component.SecondaryColorName;
						num = 2;
					}
					if (!component.TertiaryColorName.Equals("Tertiary"))
					{
						array[2] = component.TertiaryColorName;
						num = 3;
					}
					for (int num2 = 0; num2 < num; num2++)
					{
						tydList.AddChild(new TydString(null, array[num2]));
					}
				}
				if (component.Category != null)
				{
					if (component.Category.Length != 0 && "Construction".Equals(component.Category[0]))
					{
						string text2 = component.Type.Strip(' ');
						if (!string.IsNullOrWhiteSpace(text2) && hashSet2.Add(text2) && (hashSet.Contains(text2) || !language.NoModsHasValue(text2)))
						{
							tydDocument.AddChild(new TydString(text2, component.Type));
						}
					}
					else
					{
						for (int num3 = 0; num3 < component.Category.Length; num3++)
						{
							if (component.Category[num3] != null)
							{
								string text3 = component.Category[num3].Strip(' ');
								if (!string.IsNullOrWhiteSpace(text3) && hashSet2.Add(text3) && (hashSet.Contains(text3) || !language.NoModsHasValue(text3)))
								{
									tydDocument.AddChild(new TydString(text3, component.Category[num3]));
								}
							}
						}
					}
				}
				string text4 = component.FunctionCategory.Strip(' ');
				if (!string.IsNullOrWhiteSpace(text4) && hashSet2.Add(text4) && (hashSet.Contains(text4) || !language.NoModsHasValue(text4)))
				{
					tydDocument.AddChild(new TydString(text4, component.FunctionCategory));
				}
				continue;
			}
			RoomSegment component2 = item.GetComponent<RoomSegment>();
			if (component2 != null)
			{
				tydTable.AddChild(new TydList(component2.name.Strip(' '), string.IsNullOrEmpty(component2.LocalizedName) ? component2.name : component2.LocalizedName, component2.ButtonDescription));
				string text5 = component2.Type.Strip(' ');
				if (!string.IsNullOrWhiteSpace(text5) && hashSet2.Add(text5) && (hashSet.Contains(text5) || !language.NoModsHasValue(text5)))
				{
					tydDocument.AddChild(new TydString(text5, component2.Type));
				}
			}
		}
		File.WriteAllText(outputPath, TydToText.Write(tydDocument, true, 0, 0, true), Encoding.UTF8);
	}

	public static void Init()
	{
		if (!Initialized)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			IEnumerator enumerator = LoadFurniture(true);
			while (enumerator.MoveNext())
			{
			}
			Debug.Log("Modded furniture load time: " + (Time.realtimeSinceStartup - realtimeSinceStartup).SecondsToTime());
			if (_hadErrors && Options.ConsoleOnError && !DevConsole.Console.isOpen)
			{
				DevConsole.Console.Open();
			}
			Initialized = true;
		}
	}

	public static IEnumerator InitSteps()
	{
		if (!Initialized)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			float t = Time.realtimeSinceStartup;
			IEnumerator res = LoadFurniture(true);
			while (res.MoveNext())
			{
				yield return res.Current;
			}
			Debug.Log("Modded furniture load time: " + (Time.realtimeSinceStartup - t).SecondsToTime());
			if (_hadErrors && Options.ConsoleOnError && !DevConsole.Console.isOpen)
			{
				DevConsole.Console.Open();
			}
			Initialized = true;
		}
	}

	public static void ReLoadFurniture()
	{
		foreach (GameObject item in LoadedFurniture.SelectMany((FurnitureMod x) => x.Furniture))
		{
			ObjectDatabase.Instance.RemoveFurniture(item);
			Furniture component = item.GetComponent<Furniture>();
			if (component != null)
			{
				component.isTemporary = true;
			}
			UnityEngine.Object.Destroy(item);
			if (HUD.Instance != null)
			{
				HUD.Instance.RemoveFurnitureButton(item);
			}
		}
		foreach (GameObject item2 in LoadedFurniture.SelectMany((FurnitureMod x) => x.RoomSegments))
		{
			ObjectDatabase.Instance.RemoveSegment(item2);
			UnityEngine.Object.Destroy(item2);
			if (HUD.Instance != null)
			{
				HUD.Instance.RemoveFurnitureButton(item2);
			}
		}
		foreach (var rep in LoadedFurniture.SelectMany((FurnitureMod x) => x.Replacements))
		{
			ObjectDatabase.ReplacementGroup value;
			ObjectDatabase.ReplacementObject r;
			if (ObjectDatabase.Instance.ModdedReplacements.TryGetValue(rep.Item1, out value) && value.Replacements.TryGetFirst((ObjectDatabase.ReplacementObject x) => x.Name.Equals(rep.Item2), out r) && r.Keys.RemoveFirst((ObjectDatabase.ReplacementKey x) => x.Key.Equals(rep.Item3)) && r.Keys.Count == 0 && value.Replacements.RemoveFirst((ObjectDatabase.ReplacementObject x) => x.Name.Equals(rep.Item2)) && value.Replacements.Count == 0)
			{
				ObjectDatabase.Instance.ModdedReplacements.Remove(rep.Item1);
			}
		}
		LoadedFurniture.ForEach(ModWindow.RemoveMod);
		LoadedFurniture.ForEach(delegate(FurnitureMod x)
		{
			x.ClearGPU();
		});
		LoadedFurniture.Clear();
		IEnumerator enumerator3 = LoadFurniture(false);
		while (enumerator3.MoveNext())
		{
		}
		if (_hadErrors && Options.ConsoleOnError && !DevConsole.Console.isOpen)
		{
			DevConsole.Console.Open();
		}
		if (HUD.Instance != null && GameSettings.Instance.AllowModdedFurniture)
		{
			foreach (GameObject item3 in LoadedFurniture.SelectMany((FurnitureMod x) => x.Furniture))
			{
				HUD.Instance.AddFurnitureButton(item3);
			}
			foreach (GameObject item4 in LoadedFurniture.SelectMany((FurnitureMod x) => x.RoomSegments))
			{
				HUD.Instance.AddSegmentButton(item4.GetComponent<RoomSegment>());
			}
			HUD.Instance.UpdateFurnitureButtons();
		}
		SteamWorkshop.RecheckItems(LoadedFurniture.OfType<IWorkshopItem>());
	}

	public static void ReLoadSpecificFurniture(string furn)
	{
		FurnitureMod furnitureMod = LoadedFurniture.FirstOrDefault((FurnitureMod x) => x.ItemTitle.Equals(furn));
		if (furnitureMod != null)
		{
			ReLoadFurniture(furnitureMod);
			return;
		}
		string text = Path.Combine(Path.Combine(Utilities.GetRoot(), "Furniture"), furn);
		if (!Directory.Exists(text))
		{
			return;
		}
		bool errors = false;
		FurnitureMod furnitureMod2;
		if ((furnitureMod2 = LoadFurnitureMod(text, ref errors, null) as FurnitureMod) == null)
		{
			return;
		}
		if (HUD.Instance != null)
		{
			foreach (GameObject item in furnitureMod2.Furniture)
			{
				HUD.Instance.AddFurnitureButton(item);
			}
			foreach (GameObject roomSegment in furnitureMod2.RoomSegments)
			{
				HUD.Instance.AddSegmentButton(roomSegment.GetComponent<RoomSegment>());
			}
			HUD.Instance.UpdateFurnitureButtons();
		}
		SteamWorkshop.RecheckItems(new FurnitureMod[1] { furnitureMod2 });
	}

	public static void ReLoadFurniture(FurnitureMod mod)
	{
		foreach (GameObject item in mod.Furniture)
		{
			ObjectDatabase.Instance.RemoveFurniture(item);
			Furniture component = item.GetComponent<Furniture>();
			if (component != null)
			{
				component.isTemporary = true;
			}
			UnityEngine.Object.Destroy(item);
			if (HUD.Instance != null)
			{
				HUD.Instance.RemoveFurnitureButton(item);
			}
		}
		foreach (GameObject roomSegment in mod.RoomSegments)
		{
			ObjectDatabase.Instance.RemoveSegment(roomSegment);
			UnityEngine.Object.Destroy(roomSegment);
			if (HUD.Instance != null)
			{
				HUD.Instance.RemoveFurnitureButton(roomSegment);
			}
		}
		foreach (var rep in mod.Replacements)
		{
			ObjectDatabase.ReplacementGroup value;
			ObjectDatabase.ReplacementObject r;
			if (ObjectDatabase.Instance.ModdedReplacements.TryGetValue(rep.Item1, out value) && value.Replacements.TryGetFirst((ObjectDatabase.ReplacementObject x) => x.Name.Equals(rep.Item2), out r) && r.Keys.RemoveFirst((ObjectDatabase.ReplacementKey x) => x.Key.Equals(rep.Item3)) && r.Keys.Count == 0 && value.Replacements.RemoveFirst((ObjectDatabase.ReplacementObject x) => x.Name.Equals(rep.Item2)) && value.Replacements.Count == 0)
			{
				ObjectDatabase.Instance.ModdedReplacements.Remove(rep.Item1);
			}
		}
		ModWindow.RemoveMod(mod);
		mod.ClearGPU();
		LoadedFurniture.Remove(mod);
		bool errors = false;
		FurnitureMod furnitureMod;
		if ((furnitureMod = LoadFurnitureMod(mod.Root, ref errors, null) as FurnitureMod) == null)
		{
			return;
		}
		if (HUD.Instance != null)
		{
			foreach (GameObject item2 in furnitureMod.Furniture)
			{
				HUD.Instance.AddFurnitureButton(item2);
			}
			foreach (GameObject roomSegment2 in furnitureMod.RoomSegments)
			{
				HUD.Instance.AddSegmentButton(roomSegment2.GetComponent<RoomSegment>());
			}
			HUD.Instance.UpdateFurnitureButtons();
		}
		SteamWorkshop.RecheckItems(new FurnitureMod[1] { furnitureMod });
	}

	public static IWorkshopItem LoadFurnitureMod(string dir, ref bool errors, string name, bool logFail = false)
	{
		StringBuilder stringBuilder = new StringBuilder();
		Dictionary<string, Mesh> dictionary = new Dictionary<string, Mesh>();
		Dictionary<string, Texture2D> dictionary2 = new Dictionary<string, Texture2D>();
		List<Material> mats = new List<Material>();
		List<string> issues = new List<string>();
		try
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			bool usedAutobounds = false;
			List<GameObject> list = new List<GameObject>();
			List<GameObject> list2 = new List<GameObject>();
			List<ValueTuple<string, string, string>> list3 = new List<ValueTuple<string, string, string>>();
			Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
			string path = Path.Combine(dir, "materials.xml");
			bool flag = true;
			if (!File.Exists(path))
			{
				path = Path.Combine(dir, "materials.tyd");
				flag = false;
			}
			Dictionary<string, Material> dictionary3 = new Dictionary<string, Material>();
			if (File.Exists(path))
			{
				try
				{
					if (flag)
					{
						dictionary3 = LoadMaterials(new NodeWrapper(XMLParser.ParseXML(File.ReadAllText(path))), dictionary2, mats, dir, issues);
					}
					else
					{
						List<TydNode> list4 = TydFromText.Parse(File.ReadAllText(path));
						dictionary3 = ((list4.Count != 1 || !list4[0].Name.Equals("Materials")) ? LoadMaterials(new NodeWrapper(new TydDocument(list4)), dictionary2, mats, dir, issues) : LoadMaterials(new NodeWrapper(list4[0]), dictionary2, mats, dir, issues));
					}
				}
				catch (Exception ex)
				{
					DevConsole.Console.LogError("Failed loading materials for " + name + " with error:\n" + ex.ToString());
				}
			}
			string text = Path.Combine(dir, "replacements.tyd");
			List<Texture2D> textures = dictionary2.Values.ToList();
			if (File.Exists(text))
			{
				LoadReplacements(TydFile.FromFile(text).DocumentNode, dir, dictionary, dictionary3, textures, list3, issues);
			}
			Material[] modMats = ObjectDatabase.Instance.ModMats;
			foreach (Material material in modMats)
			{
				dictionary3[material.name] = material;
			}
			List<TydFile> list5 = null;
			try
			{
				list5 = TydFile.ReadAndResolvePath(dir, SearchOption.TopDirectoryOnly, "materials", "meta", "replacements");
			}
			catch (Exception ex2)
			{
				stringBuilder.AppendLine("\tFailed loading TyD");
				stringBuilder.AppendLine("\t" + ex2);
			}
			if (list5 != null)
			{
				for (int j = 0; j < list5.Count; j++)
				{
					TydFile tydFile = list5[j];
					foreach (TydCollection item in tydFile.DocumentNode.Nodes.OfType<TydCollection>())
					{
						if (item.AttributeAbstract)
						{
							continue;
						}
						string childValue = item.GetChildValue("Name", false);
						stringBuilder.Clear();
						stringBuilder.AppendLine("Loading furniture: " + name + "/" + tydFile.FileName + "/" + childValue);
						bool success;
						bool error;
						if (childValue != null)
						{
							NodeWrapper root = new NodeWrapper(item);
							WallSnap wallSnap = null;
							bool roomSeg;
							wallSnap = LoadModContent(childValue, dir, tydFile.FilePath, ref errors, out success, out error, ref usedAutobounds, out roomSeg, root, stringBuilder, issues, dictionary, sprites, dictionary3, textures);
							if (wallSnap != null)
							{
								if (roomSeg)
								{
									list2.Add(wallSnap.gameObject);
								}
								else
								{
									list.Add(wallSnap.gameObject);
									Localization.CheckFurnResub((Furniture)wallSnap);
								}
							}
						}
						else
						{
							stringBuilder.AppendLine("Missing Name!");
							success = false;
							error = true;
						}
						if (!success || error)
						{
							errors = true;
							if (!success)
							{
								DevConsole.Console.LogError(stringBuilder.ToString());
							}
							else
							{
								DevConsole.Console.LogWarning(stringBuilder.ToString());
							}
						}
					}
				}
			}
			string[] files = Directory.GetFiles(dir, "*.xml");
			foreach (string text2 in files)
			{
				if (Path.GetFileName(text2).ToLower().Equals("materials.xml"))
				{
					continue;
				}
				stringBuilder.Clear();
				stringBuilder.AppendLine("Loading furniture: " + name + "/" + Path.GetFileName(text2));
				bool flag2 = false;
				string text3 = "";
				NodeWrapper root2 = null;
				try
				{
					text3 = File.ReadAllText(text2);
				}
				catch (Exception ex3)
				{
					stringBuilder.AppendLine("\tFailed reading file");
					stringBuilder.AppendLine("\t" + ex3);
					flag2 = true;
				}
				if (!flag2)
				{
					try
					{
						root2 = new NodeWrapper(XMLParser.ParseXML(text3));
					}
					catch (Exception ex4)
					{
						stringBuilder.AppendLine("\tFailed parsing xml");
						stringBuilder.AppendLine("\t" + ex4);
						flag2 = true;
					}
				}
				WallSnap wallSnap2 = null;
				bool roomSeg2 = false;
				bool success2;
				bool error2;
				if (!flag2)
				{
					wallSnap2 = LoadModContent(Path.GetFileNameWithoutExtension(text2), dir, text2, ref errors, out success2, out error2, ref usedAutobounds, out roomSeg2, root2, stringBuilder, null, dictionary, sprites, dictionary3, textures);
				}
				else
				{
					success2 = false;
					error2 = false;
				}
				if (wallSnap2 != null)
				{
					if (roomSeg2)
					{
						list2.Add(wallSnap2.gameObject);
					}
					else
					{
						list.Add(wallSnap2.gameObject);
						Localization.CheckFurnResub((Furniture)wallSnap2);
					}
				}
				if (!success2 || error2)
				{
					errors = true;
					if (!success2)
					{
						DevConsole.Console.LogError(stringBuilder.ToString());
					}
					else
					{
						DevConsole.Console.LogWarning(stringBuilder.ToString());
					}
				}
			}
			if (list.Count > 0 || list2.Count > 0 || list3.Count > 0)
			{
				FurnitureMod furnitureMod = new FurnitureMod(dir, list, list2, dictionary.Values.ToList(), textures, mats, list3, issues, usedAutobounds, Time.realtimeSinceStartup - realtimeSinceStartup);
				LoadedFurniture.Add(furnitureMod);
				return furnitureMod;
			}
		}
		catch (Exception ex5)
		{
			foreach (KeyValuePair<string, Mesh> item2 in dictionary)
			{
				UnityEngine.Object.Destroy(item2.Value);
			}
			foreach (Texture2D value in dictionary2.Values)
			{
				UnityEngine.Object.Destroy(value);
			}
			string text4 = "Error loading furniture pack " + name + ":\n" + ex5.ToString();
			LoadDebugger.AddError("Failed loading furniture mod: " + name);
			Debug.Log(text4);
			DevConsole.Console.LogError(text4);
			return new FailMod("Furniture", dir, ex5.ToString());
		}
		foreach (KeyValuePair<string, Mesh> item3 in dictionary)
		{
			UnityEngine.Object.Destroy(item3.Value);
		}
		foreach (Texture2D value2 in dictionary2.Values)
		{
			UnityEngine.Object.Destroy(value2);
		}
		return new FailMod("Furniture", dir, stringBuilder.ToString());
	}

	private static void LoadReplacements(TydDocument doc, string rootFolder, Dictionary<string, Mesh> meshes, Dictionary<string, Material> mats, List<Texture2D> textures, List<ValueTuple<string, string, string>> result, List<string> issues)
	{
		foreach (TydTable item in doc.Nodes.OfType<TydTable>())
		{
			try
			{
				string name = item.Name;
				ObjectDatabase.ReplacementGroup group;
				if (!ObjectDatabase.Instance.GetReplacementGroup(name, out group) && !ObjectDatabase.Instance.ModdedReplacements.TryGetValue(name, out group))
				{
					group = new ObjectDatabase.ReplacementGroup
					{
						Name = name,
						Replacements = new List<ObjectDatabase.ReplacementObject>()
					};
					ObjectDatabase.Instance.ModdedReplacements[name] = group;
				}
				foreach (TydTable item2 in item.Nodes.OfType<TydTable>())
				{
					string name2 = item2.Name;
					Material value;
					if (!mats.TryGetValue(item2.GetChildValue("Material"), out value))
					{
						issues.Add("Missing material " + item2.GetChildValue("Material") + " for mesh replacement: " + name + " -> " + name2);
						continue;
					}
					bool flag = false;
					TydString child = item2.GetChild<TydString>("Thumbnail");
					if (child == null)
					{
						child = item2.GetChild<TydString>("ThumbnailRGB");
						flag = true;
						if (child == null)
						{
							issues.Add("Missing thumbnail for mesh replacement: " + name + " -> " + name2);
							continue;
						}
					}
					TydList child2 = item2.GetChild<TydList>("Meshes", true);
					List<ObjectDatabase.ReplacementKey> list = new List<ObjectDatabase.ReplacementKey>();
					foreach (TydTable item3 in child2.Nodes.OfType<TydTable>())
					{
						string childValue = item3.GetChildValue("Name");
						string childValue2 = item3.GetChildValue("Mesh");
						Mesh m;
						if (!LoadMeshReplacementMesh(childValue2, rootFolder, issues, meshes, out m))
						{
							issues.Add("Error loading mesh for mesh replacement: " + name + " -> " + name2 + " -> " + childValue);
							continue;
						}
						Mesh m2 = null;
						Mesh m3 = null;
						if (item3.GetChild<TydString>("LOD1") != null && !LoadMeshReplacementMesh(childValue2, rootFolder, issues, meshes, out m2))
						{
							issues.Add("Error loading LOD1 mesh for mesh replacement: " + name + " -> " + name2 + " -> " + childValue);
							if (item3.GetChild<TydString>("LOD2") != null && !LoadMeshReplacementMesh(childValue2, rootFolder, issues, meshes, out m3))
							{
								issues.Add("Error loading LOD2 mesh for mesh replacement: " + name + " -> " + name2 + " -> " + childValue);
							}
						}
						list.Add(new ObjectDatabase.ReplacementKey
						{
							Key = childValue,
							Mesh = m,
							LOD1 = m2,
							LOD2 = m3
						});
						result.Add(new ValueTuple<string, string, string>(name, name2, childValue));
					}
					if (list.Count != 0)
					{
						Sprite sprite = null;
						Texture2D texture2D = new Texture2D(0, 0, TextureFormat.ARGB32, false);
						texture2D.LoadImage(File.ReadAllBytes(Path.Combine(rootFolder, child.Value)));
						texture2D.ScaleDown(128, 128);
						if (Options.FurnTexCompression)
						{
							texture2D.Compress(true);
						}
						textures.Add(texture2D);
						texture2D.name = child.Value;
						if (!flag)
						{
							sprite = Sprite.Create(texture2D, new Rect(0f, 0f, 128f, 128f), Vector2.zero);
							sprite.name = child.Value;
							texture2D = null;
						}
						group.Replacements.Add(new ObjectDatabase.ReplacementObject
						{
							Name = name2,
							Material = value,
							Keys = list,
							AlbedoThumb = texture2D,
							Thumbnail = sprite
						});
					}
				}
			}
			catch (Exception ex)
			{
				issues.Add("Error loading mesh replacements: " + ex.Message);
			}
		}
	}

	private static bool LoadMeshReplacementMesh(string filename, string rootFolder, List<string> issues, Dictionary<string, Mesh> meshes, out Mesh m)
	{
		try
		{
			m = LoadMesh(filename, issues, rootFolder, meshes, true);
		}
		catch (Exception)
		{
			m = null;
			return false;
		}
		return true;
	}

	private static WallSnap LoadModContent(string name, string dir, string file, ref bool errors, out bool success, out bool error, ref bool usedAutobounds, out bool roomSeg, NodeWrapper root, StringBuilder sb, List<string> issues, Dictionary<string, Mesh> meshes, Dictionary<string, Sprite> sprites, Dictionary<string, Material> materials, List<Texture2D> textures)
	{
		GameObject gameObject = null;
		WallSnap wallSnap = null;
		roomSeg = false;
		try
		{
			gameObject = CreateFurnitureObject(name, root, dir, sb, out success, out error, out roomSeg, ref usedAutobounds, meshes, sprites, materials, textures, issues);
		}
		catch (Exception ex)
		{
			sb.AppendLine("\tFailed loading with error:");
			sb.AppendLine("\t" + ex.ToString());
			success = false;
			error = false;
		}
		if (success)
		{
			wallSnap = gameObject.GetComponent<WallSnap>();
			gameObject.SetActive(false);
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
			wallSnap.FileName = file;
			if (roomSeg)
			{
				ObjectDatabase.Instance.AddSegment(gameObject);
				RoomSegment.ClearStaticData();
			}
			else
			{
				ObjectDatabase.Instance.AddFurniture(gameObject);
				((Furniture)wallSnap).UpgradeTo = root.TryGetAttribute("UpgradeFrom") ?? root.TryGetAttribute("UpgradeTo");
			}
		}
		else if (gameObject != null)
		{
			gameObject.SetActive(false);
			Furniture component = gameObject.GetComponent<Furniture>();
			if (component != null)
			{
				component.isTemporary = true;
			}
			UnityEngine.Object.Destroy(gameObject);
		}
		return wallSnap;
	}

	public static void BakeBounds(Furniture furn)
	{
		if (furn == null)
		{
			DevConsole.Console.LogError("Furniture does not exist");
			return;
		}
		if (furn.FileName != null && File.Exists(furn.FileName))
		{
			try
			{
				if (Path.GetExtension(furn.FileName).ToLower().Equals(".xml"))
				{
					XMLParser.XMLNode xMLNode = XMLParser.ParseXML(File.ReadAllText(furn.FileName));
					xMLNode.Attributes.Remove("AutoBounds");
					XMLParser.XMLNode xMLNode2 = xMLNode.GetNode("Furniture", false);
					if (xMLNode2 == null)
					{
						xMLNode2 = new XMLParser.XMLNode("Furniture");
						xMLNode.Children.Add(xMLNode2);
					}
					xMLNode2.Children.RemoveAll((XMLParser.XMLNode x) => x.Name.Equals("BuildBoundary"));
					if (furn.BuildBoundary != null && furn.BuildBoundary.Length != 0)
					{
						xMLNode2.Children.Add(new XMLParser.XMLNode("BuildBoundary", string.Join("\n", furn.BuildBoundary.SelectInPlace((Vector2 x) => ((SVector3)x).Serialize(2)))));
					}
					else
					{
						xMLNode2.Children.Add(new XMLParser.XMLNode("BuildBoundary", ""));
					}
					xMLNode2.Children.RemoveAll((XMLParser.XMLNode x) => x.Name.Equals("NavBoundary"));
					if (furn.NavBoundary != null && furn.NavBoundary.Length != 0)
					{
						xMLNode2.Children.Add(new XMLParser.XMLNode("NavBoundary", string.Join("\n", furn.NavBoundary.SelectInPlace((Vector2 x) => ((SVector3)x).Serialize(2)))));
					}
					else
					{
						xMLNode2.Children.Add(new XMLParser.XMLNode("NavBoundary", ""));
					}
					xMLNode2.Children.RemoveAll((XMLParser.XMLNode x) => x.Name.Equals("MeshBoundary"));
					if (furn.MeshBoundary != null && furn.MeshBoundary.Length != 0)
					{
						xMLNode2.Children.Add(new XMLParser.XMLNode("MeshBoundary", string.Join("\n", furn.MeshBoundary.SelectInPlace((Vector2 x) => ((SVector3)x).Serialize(2)))));
					}
					else
					{
						xMLNode2.Children.Add(new XMLParser.XMLNode("MeshBoundary", ""));
					}
					xMLNode2.Children.RemoveAll((XMLParser.XMLNode x) => x.Name.Equals("WallWidth"));
					xMLNode2.Children.RemoveAll((XMLParser.XMLNode x) => x.Name.Equals("YOffset"));
					if (furn.WallFurn)
					{
						xMLNode2.Children.Add(new XMLParser.XMLNode("WallWidth", furn.WallWidth.ToString()));
						xMLNode2.Children.Add(new XMLParser.XMLNode("YOffset", furn.YOffset.ToString()));
					}
					xMLNode2.Children.RemoveAll((XMLParser.XMLNode x) => x.Name.Equals("Height1"));
					xMLNode2.Children.RemoveAll((XMLParser.XMLNode x) => x.Name.Equals("Height2"));
					xMLNode2.Children.Add(new XMLParser.XMLNode("Height1", furn.Height1.ToString()));
					xMLNode2.Children.Add(new XMLParser.XMLNode("Height2", furn.Height2.ToString()));
					xMLNode2.Children.RemoveAll((XMLParser.XMLNode x) => x.Name.Equals("OnXEdge"));
					xMLNode2.Children.RemoveAll((XMLParser.XMLNode x) => x.Name.Equals("OnYEdge"));
					xMLNode2.Children.Add(new XMLParser.XMLNode("OnXEdge", furn.OnXEdge.ToString()));
					xMLNode2.Children.Add(new XMLParser.XMLNode("OnYEdge", furn.OnYEdge.ToString()));
					BoxCollider component = furn.GetComponent<BoxCollider>();
					if (component != null)
					{
						xMLNode.Children.RemoveAll((XMLParser.XMLNode x) => x.Name.Equals("BoxCollider"));
						XMLParser.XMLNode xMLNode3 = new XMLParser.XMLNode("BoxCollider");
						xMLNode3.Children.Add(new XMLParser.XMLNode("center", ((SVector3)component.center).Serialize(3)));
						xMLNode3.Children.Add(new XMLParser.XMLNode("size", ((SVector3)component.size).Serialize(3)));
						xMLNode.Children.Add(xMLNode3);
					}
					File.WriteAllText(furn.FileName, XMLParser.ExportXML(xMLNode));
				}
				else
				{
					TydTable tydTable = TydFile.FromFile(furn.FileName).DocumentNode.Seek("Name", furn.name);
					if (tydTable == null)
					{
						throw new Exception("Couldn't find furniture named: " + furn.name + " in file " + furn.FileName);
					}
					tydTable.Nodes.RemoveAll((TydNode x) => x.Name.Equals("AutoBounds"));
					TydCollection tydCollection = tydTable.GetChild<TydCollection>("Furniture");
					if (tydCollection == null)
					{
						tydCollection = tydTable.AddChild(new TydTable("Furniture"));
					}
					TydList tydList = tydCollection.ReplaceChild(new TydList("BuildBoundary"));
					if (furn.BuildBoundary != null && furn.BuildBoundary.Length != 0)
					{
						tydList.AddChildren(furn.BuildBoundary.SelectInPlace((Vector2 x) => x.ToTyd()));
					}
					TydList tydList2 = tydCollection.ReplaceChild(new TydList("NavBoundary"));
					if (furn.NavBoundary != null && furn.NavBoundary.Length != 0)
					{
						tydList2.AddChildren(furn.NavBoundary.SelectInPlace((Vector2 x) => x.ToTyd()));
					}
					TydList tydList3 = tydCollection.ReplaceChild(new TydList("MeshBoundary"));
					if (furn.MeshBoundary != null && furn.MeshBoundary.Length != 0)
					{
						tydList3.AddChildren(furn.MeshBoundary.SelectInPlace((Vector2 x) => x.ToTyd()));
					}
					if (furn.WallFurn)
					{
						tydCollection.ReplaceChild(new TydString("WallWidth", furn.WallWidth.ToString()));
						tydCollection.ReplaceChild(new TydString("YOffset", furn.YOffset.ToString()));
					}
					tydCollection.ReplaceChild(new TydString("Height1", furn.Height1.ToString()));
					tydCollection.ReplaceChild(new TydString("Height2", furn.Height2.ToString()));
					tydCollection.ReplaceChild(new TydString("OnXEdge", furn.OnXEdge.ToString()));
					tydCollection.ReplaceChild(new TydString("OnYEdge", furn.OnYEdge.ToString()));
					BoxCollider component2 = furn.GetComponent<BoxCollider>();
					if (component2 != null)
					{
						tydTable.ReplaceChild(new TydTable("BoxCollider")).AddChildren<TydList>(component2.center.ToTyd("center"), component2.size.ToTyd("size"));
					}
					File.WriteAllText(furn.FileName, TydToText.Write(tydTable, true));
				}
				DevConsole.Console.Log(furn.FileName + " has been updated");
				return;
			}
			catch (Exception ex)
			{
				DevConsole.Console.LogError(ex.ToString());
				return;
			}
		}
		DevConsole.Console.LogError("Failed finding XML file");
	}

	private static IEnumerator LoadFurniture(bool logErrors)
	{
		_hadErrors = false;
		string path = Path.Combine(Utilities.GetRoot(), "Furniture");
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		else
		{
			string[] directories = Directory.GetDirectories(path);
			foreach (string dir in directories)
			{
				string fileName = ModController.GetMetaName(dir) ?? Path.GetFileName(dir);
				yield return fileName;
				LoadFurnitureMod(dir, ref _hadErrors, fileName, logErrors);
			}
		}
		InitializePCDowngrades();
	}

	private static void InitializePCDowngrades()
	{
		List<int> list = new List<int>();
		List<Furniture> list2 = new List<Furniture>();
		foreach (GameObject item in ObjectDatabase.Instance.GetAllFurniture())
		{
			Furniture component = item.GetComponent<Furniture>();
			if (!component.Type.Equals("Computer") && !component.ForcePCPricing)
			{
				continue;
			}
			list2.Add(component);
			if (component.IgnorePCRelease || component.ForcePCPricing)
			{
				continue;
			}
			bool flag = true;
			for (int i = 0; i < list.Count; i++)
			{
				int num = list[i];
				if (component.UnlockYear == num)
				{
					flag = false;
					break;
				}
				if (component.UnlockYear < num)
				{
					list.Insert(i, component.UnlockYear);
					flag = false;
					break;
				}
			}
			if (flag)
			{
				list.Add(component.UnlockYear);
			}
		}
		for (int j = 0; j < list2.Count; j++)
		{
			Furniture furniture = list2[j];
			furniture.StartDowngrade = int.MaxValue;
			int num2 = list.Count - 1;
			while (num2 >= 0 && list[num2] > furniture.UnlockYear)
			{
				furniture.StartDowngrade = list[num2];
				num2--;
			}
		}
	}

	private static string FindUniqueFurnitureName(string input)
	{
		int num = 1;
		string text = input;
		while (ObjectDatabase.Instance.GetFurniture(text) != null)
		{
			text = input + " " + num;
			num++;
		}
		return text;
	}

	private static bool TryLoadTexture(Material mat, NodeWrapper node, Dictionary<string, Texture2D> textures, string dir, string name, string slot, List<string> issues)
	{
		string nodeValue = node.GetNodeValue(name);
		if (nodeValue != null)
		{
			Texture2D value;
			if (!textures.TryGetValue(nodeValue, out value))
			{
				value = new Texture2D(0, 0);
				value.LoadImage(File.ReadAllBytes(Path.Combine(dir, nodeValue)));
				if (Options.FurnTexCompression)
				{
					value.Compress(true);
				}
				value.name = nodeValue;
				textures[nodeValue] = value;
				if ((!Mathf.IsPowerOfTwo(value.width) || !Mathf.IsPowerOfTwo(value.height)) && issues != null)
				{
					issues.Add(nodeValue + " is not power of two, which can decrease performance and cause issues. Your textures should be 8, 16, 32, 64, 128, 256, 512, 1024, 2048, etc pixels tall and wide");
				}
			}
			mat.SetTexture(slot, value);
			return true;
		}
		return false;
	}

	private static Dictionary<string, Material> LoadMaterials(NodeWrapper root, Dictionary<string, Texture2D> textures, List<Material> mats, string dir, List<string> issues)
	{
		Dictionary<string, Material> dictionary = new Dictionary<string, Material>();
		ObjectDatabase instance = ObjectDatabase.Instance;
		Material defaultValue = instance.FurnitureMaterialTypes["Unity"];
		foreach (NodeWrapper child in root.Children)
		{
			string text = child.GetNodeValue("Type", "Unity");
			if (child.TryGetAttribute("Standard") != null)
			{
				text = "Standard";
			}
			Material material = new Material(instance.FurnitureMaterialTypes.GetOrDefault(text, defaultValue));
			material.name = child.Name;
			if (child.Contains("Texture"))
			{
				string nodeValue = child.GetNodeValue("Texture");
				string path = Path.Combine(dir, nodeValue);
				if (File.Exists(path))
				{
					Texture2D value;
					if (!textures.TryGetValue(nodeValue, out value))
					{
						value = new Texture2D(0, 0);
						value.LoadImage(File.ReadAllBytes(path));
						if (Options.FurnTexCompression)
						{
							value.Compress(true);
						}
						value.name = nodeValue;
						textures[nodeValue] = value;
						if ((!Mathf.IsPowerOfTwo(value.width) || !Mathf.IsPowerOfTwo(value.height)) && issues != null)
						{
							issues.Add(nodeValue + " is not power of two, which can decrease performance and cause issues. Your textures should be 8, 16, 32, 64, 128, 256, 512, 1024, 2048, etc pixels tall and wide");
						}
					}
					material.mainTexture = value;
				}
				else if (issues != null)
				{
					issues.Add("Texture " + nodeValue + " for material " + child.Name + " could not be found");
				}
			}
			else
			{
				material.mainTexture = null;
			}
			if ("Standard".Equals(text))
			{
				if (TryLoadTexture(material, child, textures, dir, "NormalMap", "_LumpMap", issues))
				{
					material.EnableKeyword("_BUMPMAP");
					material.EnableKeyword("_REVERSEMETAL");
				}
				if (TryLoadTexture(material, child, textures, dir, "ExtraMap", "_ExtraTex", issues))
				{
					material.EnableKeyword("_EXTRAMAP");
				}
				if (child.GetNodeValue("Snow", "False").ConvertToBoolDef(false))
				{
					material.EnableKeyword("_SNOW");
				}
			}
			else if ("Unity".Equals(text))
			{
				material.SetTexture("_BumpMap", null);
				material.SetTexture("_OcclusionMap", null);
				material.SetFloat("_Metallic", 0f);
				material.SetFloat("_Glossiness", 0f);
				material.SetFloat("_BumpScale", 1f);
				material.SetColor("_EmissionColor", Color.black);
			}
			else if ("Atlas".Equals(text))
			{
				if (child.GetNodeValue("RGBMapping", "False").ConvertToBoolDef(false))
				{
					material.EnableKeyword("_RGBMAP");
				}
				if (TryLoadTexture(material, child, textures, dir, "NormalMap", "_BumpMap", issues))
				{
					material.EnableKeyword("_BUMPMAP");
				}
			}
			mats.Add(material);
			dictionary[child.Name] = material;
			foreach (NodeWrapper child2 in child.Children)
			{
				if (child2.Name.Equals("Textures"))
				{
					foreach (NodeWrapper child3 in child2.Children)
					{
						string path2 = Path.Combine(dir, child3.Value);
						if (File.Exists(path2))
						{
							Texture2D value2;
							if (!textures.TryGetValue(child3.Value, out value2))
							{
								value2 = new Texture2D(0, 0);
								value2.LoadImage(File.ReadAllBytes(path2));
								if (value2.width >= 4 && value2.height >= 4 && Options.FurnTexCompression)
								{
									value2.Compress(true);
								}
								value2.name = child3.Value;
								textures[child3.Value] = value2;
								if ((!Mathf.IsPowerOfTwo(value2.width) || !Mathf.IsPowerOfTwo(value2.height)) && issues != null)
								{
									issues.Add(child3.Value + " is not power of two, which can decrease performance and cause issues. Your textures should be 8, 16, 32, 64, 128, 256, 512, 1024, 2048, etc pixels tall and wide");
								}
							}
							material.SetTexture(child3.Name, value2);
						}
						else if (issues != null)
						{
							issues.Add("Texture " + child3.Value + " for material " + child.Name + " could not be found");
						}
					}
				}
				else if (child2.Name.Equals("Floats"))
				{
					foreach (NodeWrapper child4 in child2.Children)
					{
						material.SetFloat(child4.Name, (float)Convert.ToDouble(child4.Value));
					}
				}
				else if (child2.Name.Equals("Colors"))
				{
					foreach (NodeWrapper child5 in child2.Children)
					{
						material.SetColor(child5.Name, StringToColor(child5));
					}
				}
				else if (child2.Name.Equals("Keywords"))
				{
					foreach (NodeWrapper child6 in child2.Children)
					{
						if (child6.Value.ToLower() == "false")
						{
							material.DisableKeyword(child6.Name);
						}
						else
						{
							material.EnableKeyword(child6.Name);
						}
					}
				}
				else
				{
					if (!child2.Name.Equals("Vectors"))
					{
						continue;
					}
					foreach (NodeWrapper child7 in child2.Children)
					{
						material.SetVector(child7.Name, child7.GetDelimitedValue(",").SelectInPlace((NodeWrapper x) => x.Value.ConvertToFloatDef(0f)).ToVector4());
					}
				}
			}
		}
		return dictionary;
	}

	public static void StripFurnitureGameObject(GameObject go, bool keepHoldables)
	{
		Furniture component = go.GetComponent<Furniture>();
		component.LocalizedName = null;
		component.LocalizeOverride = null;
		component.ButtonDescription = null;
		component.LODGroups = null;
		component.Colorable.Clear();
		component.Deprecated = false;
		component.OnlyInEditor = false;
		BoxCollider[] components = go.GetComponents<BoxCollider>();
		for (int i = 1; i < components.Length; i++)
		{
			UnityEngine.Object.Destroy(components[i]);
		}
		Collider[] components2 = go.GetComponents<Collider>();
		Bounds? bounds = null;
		foreach (Collider collider in components2)
		{
			if (!(collider is BoxCollider))
			{
				if (bounds.HasValue)
				{
					bounds.Value.Encapsulate(collider.bounds);
				}
				else
				{
					bounds = collider.bounds;
				}
				UnityEngine.Object.Destroy(collider);
			}
		}
		if (components.Length == 0 && bounds.HasValue)
		{
			BoxCollider boxCollider = go.AddComponent<BoxCollider>();
			boxCollider.center = bounds.Value.center;
			boxCollider.size = bounds.Value.size;
		}
		Upgradable component2 = component.GetComponent<Upgradable>();
		Transform smokePos = ((component2 != null) ? component2.SmokePosition : null);
		Server component3 = component.GetComponent<Server>();
		Transform serverLabel = ((component3 != null) ? component3.TextObj.transform : null);
		CheckFurnitureTransform(component, component.transform, smokePos, serverLabel, false, keepHoldables);
		LampScript component4 = component.GetComponent<LampScript>();
		if (component4 != null)
		{
			component4.Lights = null;
		}
		if (!keepHoldables)
		{
			component.HoldablePoints = new Transform[0];
		}
		component.ColorableLights = new List<PipLight>();
		component.UpgradeTo = null;
		component.IsIconic = new string[0];
		component.AltStyles = new List<FurnitureStyle>();
		component.CustomHeight = false;
		component.AllowForMods = false;
		component.PrimaryColorName = "Primary";
		component.SecondaryColorName = "Secondary";
		component.TertiaryColorName = "Tertiary";
		component.InteractChangeMesh = null;
		component.InteractMesh = null;
		component.DefaultMesh = null;
		component.ReplacementMeshes = Array.Empty<ReplacementMesh>();
		component.ReplacementGroups = Array.Empty<string>();
		component.Replacements = Array.Empty<string>();
	}

	public static void StripSegmentGameObject(GameObject go)
	{
		RoomSegment component = go.GetComponent<RoomSegment>();
		component.Colorable.Clear();
		component.OnlyInEditor = false;
		component.LocalizedName = null;
		component.ButtonDescription = null;
		BoxCollider[] components = go.GetComponents<BoxCollider>();
		for (int i = 1; i < components.Length; i++)
		{
			UnityEngine.Object.Destroy(components[i]);
		}
		Collider[] components2 = go.GetComponents<Collider>();
		Bounds? bounds = null;
		foreach (Collider collider in components2)
		{
			if (!(collider is BoxCollider))
			{
				if (bounds.HasValue)
				{
					bounds.Value.Encapsulate(collider.bounds);
				}
				else
				{
					bounds = collider.bounds;
				}
				UnityEngine.Object.Destroy(collider);
			}
		}
		if (components.Length == 0 && bounds.HasValue)
		{
			BoxCollider boxCollider = go.AddComponent<BoxCollider>();
			boxCollider.center = bounds.Value.center;
			boxCollider.size = bounds.Value.size;
		}
		CheckSegmentTransform(component, component.transform, false);
		component.ColorableLights = new List<PipLight>();
		component.IsIconic = new string[0];
		component.AltStyles = new List<FurnitureStyle>();
		component.CustomHeight = false;
		component.AllowForMods = false;
		component.PrimaryColorName = "Primary";
		component.SecondaryColorName = "Secondary";
		component.TertiaryColorName = "Tertiary";
		component.ReplacementMeshes = Array.Empty<ReplacementMesh>();
		component.ReplacementGroups = Array.Empty<string>();
		component.Replacements = Array.Empty<string>();
		component.Hinges = Array.Empty<DoorScript>();
		component.InsideWallMeshes = Array.Empty<MeshFilter>();
		component.ScalableObjects = new List<GameObject>();
		component.ScalableObjectsEdgeToEdge = new List<GameObject>();
		component.MovableObjects = new List<GameObject>();
		component.Children = Array.Empty<Renderer>();
		component.GlassRend = Array.Empty<Renderer>();
		component.TagParent = null;
	}

	private static bool CheckFurnitureTransform(Furniture furn, Transform child, Transform smokePos, Transform serverLabel, bool parentGone, bool keepHoldables)
	{
		if (child.gameObject.tag.Equals("NoDestroy"))
		{
			if (parentGone)
			{
				child.transform.SetParent(furn.transform);
				return true;
			}
			return false;
		}
		bool flag = child.gameObject != furn.gameObject && (!keepHoldables || furn.HoldablePoints == null || !furn.HoldablePoints.Contains(child)) && child.GetComponent<SnapPoint>() == null && child.GetComponent<InteractionPoint>() == null && (furn.LookAtPoints == null || !furn.LookAtPoints.Contains(child)) && child != smokePos && child != serverLabel;
		for (int i = 0; i < child.childCount; i++)
		{
			if (CheckFurnitureTransform(furn, child.GetChild(i), smokePos, serverLabel, flag, keepHoldables))
			{
				i--;
			}
		}
		if (!flag && parentGone)
		{
			child.transform.SetParent(furn.transform);
			return true;
		}
		if (flag)
		{
			child.transform.SetParent(null);
			UnityEngine.Object.Destroy(child.gameObject);
			return true;
		}
		return false;
	}

	private static bool CheckSegmentTransform(RoomSegment segment, Transform child, bool parentGone)
	{
		if (child.gameObject.tag.Equals("NoDestroy"))
		{
			if (parentGone)
			{
				child.transform.SetParent(segment.transform);
				return true;
			}
			return false;
		}
		bool flag = child.gameObject != segment.gameObject && child.gameObject != segment.WallMask;
		DoorScript component;
		if (!flag && child.TryGetComponent<DoorScript>(out component))
		{
			UnityEngine.Object.Destroy(component);
		}
		for (int i = 0; i < child.childCount; i++)
		{
			if (CheckSegmentTransform(segment, child.GetChild(i), flag))
			{
				i--;
			}
		}
		if (!flag && parentGone)
		{
			child.transform.SetParent(segment.transform);
			return true;
		}
		if (flag)
		{
			child.transform.SetParent(null);
			UnityEngine.Object.Destroy(child.gameObject);
			return true;
		}
		return false;
	}

	private static void InitFurniture(Furniture furn)
	{
		if (furn.Colorable == null)
		{
			furn.Colorable = new List<Renderer>();
		}
		if (furn.ColorableLights == null)
		{
			furn.ColorableLights = new List<PipLight>();
		}
		if (furn.Type == null)
		{
			furn.Type = "None";
		}
		if (furn.AuraValues == null)
		{
			furn.AuraValues = Array.Empty<float>();
		}
		if (furn.ReplacementGroups == null)
		{
			furn.ReplacementGroups = Array.Empty<string>();
		}
		furn.MeshBoundary = null;
	}

	private static void InitSegment(RoomSegment seg)
	{
		if (seg.Colorable == null)
		{
			seg.Colorable = new List<Renderer>();
		}
		if (seg.ColorableLights == null)
		{
			seg.ColorableLights = new List<PipLight>();
		}
		if (seg.Children == null)
		{
			seg.Children = Array.Empty<Renderer>();
		}
		if (seg.ScalableObjects == null)
		{
			seg.ScalableObjects = new List<GameObject>();
		}
		if (seg.ScalableObjectsEdgeToEdge == null)
		{
			seg.ScalableObjectsEdgeToEdge = new List<GameObject>();
		}
		if (seg.MovableObjects == null)
		{
			seg.MovableObjects = new List<GameObject>();
		}
		if (seg.Hinges == null)
		{
			seg.Hinges = Array.Empty<DoorScript>();
		}
		if (seg.GlassRend == null)
		{
			seg.GlassRend = Array.Empty<Renderer>();
		}
		if (seg.Type == null)
		{
			seg.Type = "None";
		}
	}

	private static Transform CheckParent(NodeWrapper node, string context, GameObject furn, StringBuilder output, ref bool error)
	{
		string pRef = node.TryGetAttribute("Parent", "TransformParent");
		if (pRef != null)
		{
			Transform t = _transformCache.FirstOrDefault((TransformAction x) => x.T.name.Equals(pRef)).T;
			if (t != null)
			{
				return t;
			}
			_trCache.Clear();
			furn.GetComponentsInChildren(true, _trCache);
			t = _trCache.FirstOrDefault((Transform x) => x.name.Equals(pRef));
			if (t != null)
			{
				return t;
			}
			output.AppendLine("\tFailed finding parent object: " + pRef + " for object: " + context);
			error = true;
			return furn.transform;
		}
		return furn.transform;
	}

	private static Mesh LoadMesh(string fileName, List<string> issues, string rootFolder, Dictionary<string, Mesh> meshes, bool throwError)
	{
		Mesh value;
		if (!meshes.TryGetValue(fileName, out value))
		{
			List<Mesh> list = ObjImporter.ImportMeshes(File.ReadAllText(Path.Combine(rootFolder, fileName)));
			if (list.Count == 1)
			{
				value = list[0];
			}
			else
			{
				if (list.Count <= 1)
				{
					if (throwError)
					{
						throw new Exception("No mesh data");
					}
					return null;
				}
				value = new Mesh();
				value.CombineMeshes(list.SelectInPlace((Mesh x) => new CombineInstance
				{
					mesh = x,
					subMeshIndex = 0,
					transform = Matrix4x4.identity
				}));
				list.ForEach(delegate(Mesh x)
				{
					UnityEngine.Object.Destroy(x);
				});
				if (issues != null)
				{
					issues.Add(fileName + " contains several meshes, which will increase load times. You should merge everything into one mesh per file");
				}
			}
			if (value.vertexCount > 800 && issues != null)
			{
				issues.Add(fileName + " has a lot of vertices (" + value.vertexCount + "). Bake details into normal maps, remove invisible faces (like faces pointing towards the ground) and make sure you use LODs");
			}
			value.name = fileName;
			meshes[fileName] = value;
		}
		return value;
	}

	private static LODFurn CreateLODGroup(GameObject mesh, Furniture furn)
	{
		LODFurn lODFurn = mesh.AddComponent<LODFurn>();
		lODFurn.Init();
		if (furn.LODGroups == null)
		{
			furn.LODGroups = new List<LODFurn>();
		}
		furn.LODGroups.Add(lODFurn);
		return lODFurn;
	}

	public static WallSnap ReloadSingleFurniture(FurnitureMod mod, string file)
	{
		NodeWrapper nodeWrapper = new NodeWrapper(TydFile.FromFile(file).DocumentNode.Nodes.First());
		string nodeValue = nodeWrapper.GetNodeValue("Name");
		if (nodeValue != null)
		{
			bool errors = false;
			bool usedAutobounds = false;
			StringBuilder sb = new StringBuilder();
			Dictionary<string, Mesh> dictionary = new Dictionary<string, Mesh>();
			foreach (Mesh mesh in mod.Meshes)
			{
				dictionary[mesh.name] = mesh;
			}
			Dictionary<string, Material> dictionary2 = new Dictionary<string, Material>();
			foreach (Material material2 in mod.Materials)
			{
				dictionary2[material2.name] = material2;
			}
			Material[] modMats = ObjectDatabase.Instance.ModMats;
			foreach (Material material in modMats)
			{
				dictionary2[material.name] = material;
			}
			mod.Issues.Clear();
			bool success;
			bool error;
			bool roomSeg;
			WallSnap wallSnap = LoadModContent(nodeValue, mod.Root, file, ref errors, out success, out error, ref usedAutobounds, out roomSeg, nodeWrapper, sb, mod.Issues, dictionary, new Dictionary<string, Sprite>(), dictionary2, mod.Textures);
			mod.Meshes = dictionary.Values.ToList();
			if (wallSnap != null)
			{
				if (roomSeg)
				{
					mod.RoomSegments.Add(wallSnap.gameObject);
				}
				else
				{
					mod.Furniture.Add(wallSnap.gameObject);
				}
				return wallSnap;
			}
		}
		return null;
	}

	private static void CheckParent(NodeWrapper node, Transform t, Vector3 pos, Vector3 rot)
	{
		_transformCache.Add(new TransformAction(t, node.TryGetAttribute("Parent", "TransformParent"), pos, rot));
	}

	private static void FileError(string error, StringBuilder output, List<string> issues, string furnName)
	{
		output.AppendLine("\t" + error);
		if (issues != null)
		{
			issues.Add("Issue with " + furnName + ": " + error);
		}
	}

	public static List<List<SnapPoint>> ExtractGroups(Furniture f)
	{
		List<List<SnapPoint>> list = new List<List<SnapPoint>>();
		HashSet<SnapPoint> visited = new HashSet<SnapPoint>();
		for (int i = 0; i < f.SnapPoints.Length; i++)
		{
			SnapPoint snapPoint = f.SnapPoints[i];
			if (snapPoint.Blocking != null && snapPoint.Blocking.Length != 0)
			{
				List<SnapPoint> list2 = new List<SnapPoint>();
				list.Add(list2);
				SubExtractGroups(snapPoint, visited, list2);
			}
		}
		return list;
	}

	private static void SubExtractGroups(SnapPoint f, HashSet<SnapPoint> visited, List<SnapPoint> result)
	{
		if (visited.Add(f))
		{
			result.Add(f);
			for (int i = 0; i < f.Blocking.Length; i++)
			{
				SubExtractGroups(f.Blocking[i], visited, result);
			}
		}
	}

	private static GameObject CreateFurnitureObject(string furnName, NodeWrapper root, string rootFolder, StringBuilder output, out bool success, out bool error, out bool roomSeg, ref bool usedAutobounds, Dictionary<string, Mesh> meshes, Dictionary<string, Sprite> sprites, Dictionary<string, Material> materials, List<Texture2D> textures, List<string> issues)
	{
		roomSeg = false;
		if (root.Children.None((NodeWrapper x) => x.Name.Equals("Models")))
		{
			FileError("Furniture needs at least one mesh", output, issues, furnName);
			error = true;
			success = false;
			return null;
		}
		error = false;
		if (root.Name.Equals("RoomSegment"))
		{
			roomSeg = true;
		}
		string text = root.TryGetAttribute("Base");
		Furniture furn = null;
		GameObject gameObject;
		WallSnap wallSnap;
		if (text != null)
		{
			if (roomSeg)
			{
				RoomSegment segmentComponent = ObjectDatabase.Instance.GetSegmentComponent(text);
				if (segmentComponent != null && !segmentComponent.OnlyInEditor)
				{
					gameObject = UnityEngine.Object.Instantiate(segmentComponent.gameObject);
					StripSegmentGameObject(gameObject);
					RoomSegment component = gameObject.GetComponent<RoomSegment>();
					component.Fallback = text;
					wallSnap = component;
					wallSnap.BaseObject = segmentComponent;
				}
				else
				{
					FileError("Base segment does not exist: \"" + text + "\", using default values", output, issues, furnName);
					gameObject = new GameObject();
					wallSnap = gameObject.AddComponent<RoomSegment>();
					error = true;
				}
			}
			else
			{
				GameObject gameObject2 = ObjectDatabase.Instance.GetFurniture(text);
				if (gameObject2 == null)
				{
					gameObject2 = ObjectDatabase.Instance.GetFurnitureNoCase(text.ToLower());
					if (gameObject2 != null)
					{
						FileError("Base furniture does not exist: \"" + text + "\", using \"" + gameObject2.name + "\" instead", output, issues, furnName);
						error = true;
					}
				}
				if (gameObject2 != null)
				{
					Furniture component2 = gameObject2.GetComponent<Furniture>();
					if (component2 != null && component2.OnlyInEditor)
					{
						gameObject2 = null;
					}
				}
				if (gameObject2 != null)
				{
					gameObject = UnityEngine.Object.Instantiate(gameObject2);
					StripFurnitureGameObject(gameObject, false);
					wallSnap = (furn = gameObject.GetComponent<Furniture>());
					wallSnap.BaseObject = gameObject2.GetComponent<Furniture>();
				}
				else
				{
					FileError("Base furniture does not exist: \"" + text + "\", using default values", output, issues, furnName);
					gameObject = new GameObject();
					wallSnap = (furn = gameObject.AddComponent<Furniture>());
					error = true;
				}
			}
		}
		else
		{
			gameObject = new GameObject();
			wallSnap = ((!roomSeg) ? ((WallSnap)(furn = gameObject.AddComponent<Furniture>())) : ((WallSnap)gameObject.AddComponent<RoomSegment>()));
		}
		if (roomSeg)
		{
			InitSegment((RoomSegment)wallSnap);
		}
		else
		{
			InitFurniture((Furniture)wallSnap);
		}
		gameObject.name = FindUniqueFurnitureName(furnName);
		string attribute = root.GetAttribute("Thumbnail");
		Sprite value;
		if (!sprites.TryGetValue(attribute, out value))
		{
			Texture2D texture2D = new Texture2D(0, 0, TextureFormat.ARGB32, false);
			texture2D.LoadImage(File.ReadAllBytes(Path.Combine(rootFolder, attribute)));
			texture2D.ScaleDown(128, 128);
			if (Options.FurnTexCompression)
			{
				texture2D.Compress(true);
			}
			textures.Add(texture2D);
			texture2D.name = attribute;
			value = Sprite.Create(texture2D, new Rect(0f, 0f, 128f, 128f), Vector2.zero);
			value.name = attribute;
			sprites[attribute] = value;
		}
		wallSnap.Thumbnail = value;
		bool flag = root.TryGetAttribute("AutoBounds", null, "False").ConvertToBoolDef(false);
		_forceShadow.Clear();
		_transformCache.Clear();
		bool flag2 = false;
		List<ReplacementMesh> list = new List<ReplacementMesh>();
		List<Renderer> list2 = new List<Renderer>();
		List<DoorScript> list3 = new List<DoorScript>();
		List<Renderer> list4 = new List<Renderer>();
		foreach (NodeWrapper childrenCollection in root.ChildrenCollections)
		{
			if (childrenCollection.Name.Equals("Models"))
			{
				int num = 0;
				foreach (NodeWrapper child in childrenCollection.Children)
				{
					try
					{
						string nodeValueForced = child.GetNodeValueForced("File");
						Mesh sharedMesh = LoadMesh(nodeValueForced, issues, rootFolder, meshes, true);
						GameObject gameObject3 = new GameObject(child.GetNodeValue("ComponentName", "SubMesh"));
						MeshFilter meshFilter = gameObject3.AddComponent<MeshFilter>();
						meshFilter.sharedMesh = sharedMesh;
						MeshRenderer meshRenderer = gameObject3.AddComponent<MeshRenderer>();
						CheckParent(child, gameObject3.transform, child.GetDelimitedNodeFloat("Position").ToVector3(), child.GetDelimitedNodeFloat("Rotation").ToVector3());
						gameObject3.transform.localScale = child.GetDelimitedNodeFloat("Scale").ToVector3(1f);
						list2.AddRange(meshRenderer);
						if (!roomSeg)
						{
							LODFurn lODFurn = null;
							if (child.Contains("LOD1"))
							{
								Mesh mesh = LoadMesh(child.GetNodeValue("LOD1"), issues, rootFolder, meshes, false);
								if (mesh != null)
								{
									lODFurn = CreateLODGroup(gameObject3, (Furniture)wallSnap);
									lODFurn.LOD1 = (lODFurn.LOD2 = mesh);
								}
							}
							if (child.Contains("LOD2"))
							{
								Mesh mesh2 = LoadMesh(child.GetNodeValue("LOD2"), issues, rootFolder, meshes, false);
								if (mesh2 != null)
								{
									if (lODFurn == null)
									{
										lODFurn = CreateLODGroup(gameObject3, (Furniture)wallSnap);
									}
									lODFurn.LOD2 = mesh2;
								}
							}
							if (child.Contains("Replacement"))
							{
								ReplacementMesh replacementMesh = gameObject3.AddComponent<ReplacementMesh>();
								replacementMesh.ReplacementName = child.GetNodeValue("Replacement");
								replacementMesh.MF = meshFilter;
								replacementMesh.MR = meshRenderer;
								replacementMesh.LOD = lODFurn;
								replacementMesh.HasLOD = lODFurn != null;
								list.Add(replacementMesh);
							}
						}
						if (!child.GetNodeValue("Shadows", "True").ConvertToBoolDef(true))
						{
							gameObject3.layer = 13;
						}
						else if (child.Contains("Shadows"))
						{
							_forceShadow.Add(meshRenderer);
						}
						if (child.Contains("Material"))
						{
							string nodeValue = child.GetNodeValue("Material");
							Material value2;
							if (materials.TryGetValue(nodeValue, out value2))
							{
								meshRenderer.sharedMaterial = value2;
								if (value2.shader == ObjectDatabase.Instance.CombineFurnitureMaterial.shader || (value2.shader == ObjectDatabase.Instance.AtlasFurnitureMaterial.shader && value2.IsKeywordEnabled("_RGBMAP")))
								{
									gameObject3.tag = "Highlight";
									wallSnap.Colorable.Add(meshRenderer);
								}
								if ("Glass".Equals(nodeValue))
								{
									gameObject3.layer = 1;
									list4.Add(meshRenderer);
								}
							}
							else
							{
								FileError("Failed finding material " + nodeValue + " for mesh " + nodeValueForced, output, issues, furnName);
								meshRenderer.material = ObjectDatabase.Instance.CombineFurnitureMaterial;
								error = true;
							}
						}
						else
						{
							gameObject3.tag = "Highlight";
							meshRenderer.material = ObjectDatabase.Instance.CombineFurnitureMaterial;
							wallSnap.Colorable.Add(meshRenderer);
						}
						string nodeValue2 = child.GetNodeValue("Tag");
						if (nodeValue2 != null)
						{
							gameObject3.tag = nodeValue2;
						}
					}
					catch (Exception ex)
					{
						string nodeValue3 = child.GetNodeValue("File", "Undefined");
						FileError("Failed loading mesh " + nodeValue3 + " with error:\n\t" + ex.Message, output, issues, furnName);
						success = false;
						continue;
					}
					num++;
				}
				continue;
			}
			if (childrenCollection.Name.Equals("Transforms"))
			{
				foreach (NodeWrapper child2 in childrenCollection.Children)
				{
					GameObject gameObject4 = new GameObject(child2.GetNodeValueForced("Name"));
					CheckParent(child2, gameObject4.transform, child2.GetDelimitedNodeFloat("Position").ToVector3(), child2.GetDelimitedNodeFloat("Rotation").ToVector3());
					gameObject4.transform.localScale = child2.GetDelimitedNodeFloat("Scale", false).ToVector3(1f);
				}
				continue;
			}
			if (!roomSeg && childrenCollection.Name.Equals("InteractionPoints"))
			{
				try
				{
					for (int num2 = 0; num2 < furn.InteractionPoints.Length; num2++)
					{
						UnityEngine.Object.Destroy(furn.InteractionPoints[num2].gameObject);
					}
					List<InteractionPoint> list5 = new List<InteractionPoint>();
					List<NodeWrapper> list6 = childrenCollection.Children.ToList();
					int[] array = new int[list6.Count];
					int[][] array2 = new int[list6.Count][];
					int num3 = 0;
					Dictionary<int, List<InteractionPoint>> dictionary = null;
					foreach (NodeWrapper item2 in list6)
					{
						GameObject gameObject5 = new GameObject(item2.GetNodeValue("ComponentName", "InteractionPoint"));
						CheckParent(item2, gameObject5.transform, item2.GetDelimitedNodeFloat("Position").ToVector3(), item2.GetDelimitedNodeFloat("Rotation").ToVector3());
						InteractionPoint interactionPoint = gameObject5.AddComponent<InteractionPoint>();
						string nodeValueForced2 = item2.GetNodeValueForced("Name");
						try
						{
							interactionPoint.Action = nodeValueForced2.ToEnum<InteractionPoint.ActionType>();
						}
						catch (Exception)
						{
							throw new Exception("\tUnknown action(Name) " + nodeValueForced2);
						}
						interactionPoint.Animation = item2.GetNodeValue("Animation", Actor.AnimationStates.Idle);
						interactionPoint.subAnimation = item2.GetNodeValue("SubAnimation", 0);
						interactionPoint.MinimumNeeded = item2.GetNodeValue("MinimumNeeded", 1);
						interactionPoint.NeedsReachCheck = item2.GetNodeValue("ReachCheck", true);
						interactionPoint.MainAction = item2.GetNodeValue("MainAction", true);
						interactionPoint.ShowOnBuild = item2.GetNodeValue("ShowOnBuild", true);
						interactionPoint.Outside = item2.GetNodeValue("Outside", false);
						interactionPoint.AlwaysValid = item2.GetNodeValue("AlwaysValid", false);
						interactionPoint.Parent = furn;
						array[num3] = item2.GetNodeValue("Child", -1);
						int nodeValue4 = item2.GetNodeValue("Group", -1);
						if (nodeValue4 >= 0)
						{
							if (dictionary == null)
							{
								dictionary = new Dictionary<int, List<InteractionPoint>>();
							}
							dictionary.Append(nodeValue4, interactionPoint);
						}
						NodeWrapper node = item2.GetNode("BlockedBy", false);
						if (node != null)
						{
							array2[num3] = node.GetDelimitedValue(",").SelectInPlace((NodeWrapper x) => x.Value.ConvertToIntDef(0));
						}
						list5.Add(interactionPoint);
						num3++;
					}
					furn.InteractionPoints = list5.ToArray();
					for (int num4 = 0; num4 < furn.InteractionPoints.Length; num4++)
					{
						if (array[num4] > -1)
						{
							furn.InteractionPoints[num4].Child = furn.InteractionPoints[array[num4]];
						}
						if (array2[num4] != null)
						{
							furn.InteractionPoints[num4].BlockedBy = array2[num4].SelectInPlaceList((int x) => furn.InteractionPoints[x]);
						}
						furn.InteractionPoints[num4].Id = num4;
					}
					if (dictionary != null)
					{
						foreach (List<InteractionPoint> value5 in dictionary.Values)
						{
							for (int num5 = 0; num5 < value5.Count; num5++)
							{
								value5[num5].Child = value5[(num5 + 1) % value5.Count];
							}
						}
					}
					Array.Sort(furn.InteractionPoints, new InteractionPoint.ActionSorter());
				}
				catch (Exception ex3)
				{
					FileError("Failed loading interaction points with error:\n\t" + ex3.Message, output, issues, furnName);
					success = false;
				}
				continue;
			}
			if (!roomSeg && childrenCollection.Name.Equals("SnapPoints"))
			{
				try
				{
					for (int num6 = 0; num6 < furn.SnapPoints.Length; num6++)
					{
						UnityEngine.Object.Destroy(furn.SnapPoints[num6].gameObject);
					}
					List<SnapPoint> list7 = new List<SnapPoint>();
					List<NodeWrapper> list8 = childrenCollection.Children.ToList();
					int[][] array3 = new int[list8.Count][];
					int[][] array4 = new int[list8.Count][];
					Dictionary<int, List<SnapPoint>> dictionary2 = null;
					int num7 = 0;
					foreach (NodeWrapper item3 in list8)
					{
						GameObject gameObject6 = new GameObject(item3.GetNodeValue("ComponentName", "SnapPoint"));
						CheckParent(item3, gameObject6.transform, item3.GetDelimitedNodeFloat("Position").ToVector3(), item3.GetDelimitedNodeFloat("Rotation").ToVector3());
						SnapPoint snapPoint = gameObject6.AddComponent<SnapPoint>();
						snapPoint.Name = item3.GetNodeValueForced("Name");
						snapPoint.CheckValid = item3.GetNodeValue("CheckValid", true);
						snapPoint.Parent = furn;
						NodeWrapper node2 = item3.GetNode("Links", false);
						array3[num7] = ((node2 != null) ? node2.GetDelimitedValue(",").SelectInPlace((NodeWrapper x) => Convert.ToInt32(x.Value)) : Array.Empty<int>());
						int nodeValue5 = item3.GetNodeValue("Group", -1);
						if (nodeValue5 >= 0)
						{
							if (dictionary2 == null)
							{
								dictionary2 = new Dictionary<int, List<SnapPoint>>();
							}
							dictionary2.Append(nodeValue5, snapPoint);
						}
						else
						{
							node2 = item3.GetNode("Blocking", false);
							array4[num7] = ((node2 != null) ? node2.GetDelimitedValue(",").SelectInPlace((NodeWrapper x) => Convert.ToInt32(x.Value)) : Array.Empty<int>());
						}
						NodeWrapper node3 = item3.GetNode("Surface", false);
						if (node3 != null)
						{
							snapPoint.Surface = node3.Children.Select((NodeWrapper x) => x.GetDelimitedFloat("Surface").ToVector2()).ToArray();
						}
						list7.Add(snapPoint);
						num7++;
					}
					furn.SnapPoints = list7.ToArray();
					for (int num8 = 0; num8 < furn.SnapPoints.Length; num8++)
					{
						furn.SnapPoints[num8].InitLinks = array3[num8].SelectInPlace((int x) => furn.SnapPoints[x]);
						furn.SnapPoints[num8].Blocking = ((array4[num8] != null && array4[num8].Length != 0) ? array4[num8].SelectInPlace((int x) => furn.SnapPoints[x]) : null);
						furn.SnapPoints[num8].Id = num8;
					}
					if (dictionary2 == null)
					{
						continue;
					}
					foreach (List<SnapPoint> value6 in dictionary2.Values)
					{
						for (int num9 = 0; num9 < value6.Count; num9++)
						{
							value6[num9].Blocking = new SnapPoint[value6.Count - 1];
							int num10 = 0;
							for (int num11 = 0; num11 < value6.Count; num11++)
							{
								if (num11 != num9)
								{
									value6[num9].Blocking[num10] = value6[num11];
									num10++;
								}
							}
						}
					}
				}
				catch (Exception ex4)
				{
					FileError("Failed loading snap points with error:\n\t" + ex4.Message, output, issues, furnName);
					success = false;
				}
				continue;
			}
			string text2 = childrenCollection.TryGetAttribute("Namespace");
			string text3 = childrenCollection.TryGetAttribute("Assembly");
			string text4 = childrenCollection.Name;
			if (text2 == null && text3 == null && childrenCollection.Name.Equals("Light"))
			{
				text4 = "PipLight";
			}
			Type type = ((text2 == null && text3 == null) ? (Type.GetType(text4) ?? Type.GetType(text4 + ", Assembly-CSharp") ?? Type.GetType(text4 + ", Assembly-CSharp-firstpass") ?? Type.GetType("UnityEngine." + text4 + ", UnityEngine")) : ((text2 == null) ? Type.GetType(text4 + ", " + text3) : ((text3 != null) ? Type.GetType(text2 + text4 + ", " + text3) : Type.GetType(text2 + text4))));
			if (type != null)
			{
				if (childrenCollection.TryGetAttribute("Destroy", "RemoveComponent") != null)
				{
					UnityEngine.Component component3 = CheckParent(childrenCollection, childrenCollection.Name, gameObject, output, ref error).gameObject.GetComponent(type);
					if (component3 != null && component3 != wallSnap)
					{
						UnityEngine.Object.DestroyImmediate(component3);
					}
					continue;
				}
				GameObject gameObject7 = CheckParent(childrenCollection, childrenCollection.Name, gameObject, output, ref error).gameObject;
				UnityEngine.Component component4 = gameObject7.GetComponent(type);
				if (component4 == null)
				{
					component4 = gameObject7.AddComponent(type);
				}
				DoorScript item;
				if ((object)(item = component4 as DoorScript) != null)
				{
					list3.Add(item);
				}
				if (component4 != null)
				{
					HashSet<string> orNull = _redirectToFurniture.GetOrNull(type);
					foreach (NodeWrapper child3 in childrenCollection.Children)
					{
						if ("TransformParent".Equals(child3.Name) || "Namespace".Equals(child3.Name) || "Assembly".Equals(child3.Name))
						{
							continue;
						}
						string text5 = child3.Name;
						bool flag3 = "UseEffects".Equals(text5);
						Furniture furniture;
						RoomSegment roomSegment;
						Upgradable upgradable;
						if ((object)(furniture = component4 as Furniture) != null)
						{
							if ("RoleBuffs".Equals(text5))
							{
								text5 = "UseEffects";
							}
							else if ("LookAtPoints".Equals(text5))
							{
								if (furniture.LookAtPoints != null)
								{
									furniture.LookAtPoints.ForEachEnum(delegate(Transform x)
									{
										x.name = "IGNOREMEIMBEINGDESTROYED";
										UnityEngine.Object.Destroy(x.gameObject);
									});
								}
							}
							else if ("UpgradeFrom".Equals(text5))
							{
								text5 = "UpgradeTo";
								flag2 = true;
							}
							else if (flag2 && "UpgradeTo".Equals(text5))
							{
								continue;
							}
						}
						else if ((object)(roomSegment = component4 as RoomSegment) != null)
						{
							if ("WallMeshes".Equals(text5))
							{
								Mesh[] array5 = (Mesh[])ConvertValue(typeof(Mesh[]), child3, gameObject, issues, rootFolder, meshes, materials);
								if (array5 != null)
								{
									List<MeshFilter> list9 = new List<MeshFilter>();
									foreach (Mesh mesh3 in array5)
									{
										GameObject gameObject8 = new GameObject(mesh3.name);
										gameObject8.transform.SetParent(gameObject.transform);
										MeshFilter meshFilter2 = gameObject8.AddComponent<MeshFilter>();
										meshFilter2.sharedMesh = mesh3;
										list9.Add(meshFilter2);
									}
									roomSegment.InsideWallMeshes = list9.ToArray();
								}
								continue;
							}
						}
						else if ((object)(upgradable = component4 as Upgradable) != null && "SmokePosition".Equals(text5))
						{
							Transform smokePosition = upgradable.SmokePosition;
							if (smokePosition != null)
							{
								smokePosition.name = "IGNOREMEIMBEINGDESTROYED";
								UnityEngine.Object.Destroy(smokePosition.gameObject);
							}
						}
						Type type2 = type;
						UnityEngine.Component obj = component4;
						if (orNull != null && orNull.Contains(text5))
						{
							type2 = typeof(Furniture);
							obj = wallSnap;
						}
						FieldInfo field = GetField(type2, text5);
						if (field != null)
						{
							try
							{
								object value3 = (flag3 ? GetUseEffects(child3) : ConvertValue(field.FieldType, child3, gameObject, issues, rootFolder, meshes, materials));
								field.SetValue(obj, value3);
							}
							catch (Exception ex5)
							{
								FileError("Failed setting field " + child3.Name + ":\n\t" + ex5.Message, output, issues, furnName);
								error = true;
							}
							continue;
						}
						PropertyInfo property = type2.GetProperty(text5);
						if (property != null)
						{
							try
							{
								object value4 = ConvertValue(property.PropertyType, child3, gameObject, issues, rootFolder, meshes, materials);
								property.SetValue(obj, value4, null);
							}
							catch (Exception ex6)
							{
								FileError("Failed setting property " + child3.Name + ":\n\t" + ex6.Message, output, issues, furnName);
								error = true;
							}
						}
						else
						{
							FileError("Undefined variable " + child3.Name, output, issues, furnName);
							error = true;
						}
					}
				}
				else
				{
					FileError("Couldn't create type " + childrenCollection.Name, output, issues, furnName);
					error = true;
				}
			}
			else
			{
				FileError("Undefined type " + childrenCollection.Name, output, issues, furnName);
				error = true;
			}
		}
		RoomSegment roomSegment2;
		if (roomSeg && (object)(roomSegment2 = wallSnap as RoomSegment) != null)
		{
			roomSegment2.Children = list2.ToArray();
			roomSegment2.Hinges = list3.ToArray();
			for (int num13 = 0; num13 < list3.Count; num13++)
			{
				list3[num13].Owner = roomSegment2;
				list3[num13].IsSegment = true;
			}
			roomSegment2.HasGlass = list4.Count > 0;
			if (roomSegment2.HasGlass)
			{
				roomSegment2.GlassRend = list4.ToArray();
			}
		}
		for (int num14 = 0; num14 < _transformCache.Count; num14++)
		{
			TransformAction action = _transformCache[num14];
			Transform transform;
			if (action.Parent == null)
			{
				transform = wallSnap.transform;
			}
			else
			{
				transform = wallSnap.GetComponentsInChildren<Transform>().FirstOrDefault((Transform x) => x.name.Equals(action.Parent));
				if (transform == null)
				{
					transform = _transformCache.FirstOrDefault((TransformAction x) => x.T.name.Equals(action.Parent)).T;
					if (transform == null)
					{
						FileError("Failed finding parent object: " + action.Parent + " for object: " + action.T.name, output, issues, furnName);
						transform = wallSnap.transform;
						error = true;
					}
				}
			}
			action.T.SetParent(transform, true);
			action.T.localPosition = action.Position;
			action.T.localRotation = Quaternion.Euler(action.Rotation);
		}
		if (!roomSeg)
		{
			Vector2[] array6 = null;
			if (flag)
			{
				FileError("Autobounds should be baked and removed to avoid long loading times", output, issues, furnName);
				usedAutobounds = true;
				bool used;
				array6 = GenerateBounds(furn, false, out used);
			}
			if (!furn.WallFurn && furn.BuildBoundary != null && furn.BuildBoundary.Length != 0 && furn.MeshBoundary == null)
			{
				if (array6 == null)
				{
					array6 = furn.CalculateBoundary().ToArray();
				}
				furn.MeshBoundary = array6;
			}
			if (wallSnap.GetComponent<LampScript>() != null)
			{
				for (int num15 = 0; num15 < wallSnap.Colorable.Count; num15++)
				{
					if (!_forceShadow.Contains(wallSnap.Colorable[num15]))
					{
						wallSnap.Colorable[num15].gameObject.layer = 13;
					}
				}
			}
			furn.upg = furn.GetComponent<Upgradable>();
			furn.HasUpg = furn.upg != null;
			FixFurniture(furn, output, issues, ref error);
		}
		else
		{
			FixSegment((RoomSegment)wallSnap, output, issues, ref error);
		}
		if (list.Count > 0)
		{
			wallSnap.ReplacementMeshes = list.ToArray();
		}
		success = true;
		return gameObject;
	}

	private static FieldInfo GetField(Type t, string field)
	{
		FieldInfo field2 = t.GetField(field);
		if (field2 != null)
		{
			return field2;
		}
		field2 = t.GetField(field, BindingFlags.Instance | BindingFlags.NonPublic);
		if (field2 != null && field2.GetCustomAttribute<SerializeField>() != null)
		{
			return field2;
		}
		return null;
	}

	public static Mesh GenerateWallMesh(Vector2[] points, float startWidth)
	{
		Mesh mesh = new Mesh();
		if (!Utilities.Clockwise(points))
		{
			Array.Reverse((Array)points);
		}
		float num = startWidth / 2f;
		ValueTuple<Vector2[], int[]> valueTuple = SwincBooster.Tesselate(new List<Vector2>
		{
			new Vector2(0f - num, 0f),
			new Vector2(num, 0f),
			new Vector2(num, 2f),
			new Vector2(0f - num, 2f)
		}, new Vector2[1][] { points }, false);
		mesh.vertices = valueTuple.Item1.SelectInPlace((Vector2 x) => new Vector3(x.x, x.y, 0f));
		mesh.normals = valueTuple.Item1.SelectInPlace((Vector2 x) => Vector3.forward);
		mesh.triangles = valueTuple.Item2;
		mesh.RecalculateTangents();
		return mesh;
	}

	public static Vector2[] GenerateBounds(Furniture furn, bool force, out bool used)
	{
		used = false;
		List<Vector2> list = furn.CalculateBoundary();
		if (list.Count > 4)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list.Count <= 4)
				{
					break;
				}
				Vector2 vector = list[i];
				int index = (i + 1) % list.Count;
				Vector2 vector2 = list[index];
				if ((vector - vector2).magnitude < 0.05f)
				{
					list[index] = (vector + vector2) * 0.5f;
					list.RemoveAt(i);
					i--;
				}
			}
		}
		if (list.Count == 4)
		{
			Vector2 vector3 = new Vector2(list.Min((Vector2 x) => x.x), list.Min((Vector2 x) => x.y));
			Vector2 vector4 = new Vector2(list.Max((Vector2 x) => x.x), list.Max((Vector2 x) => x.y));
			Vector2 vector5 = new Vector2(vector3.x, vector4.y);
			Vector2 vector6 = new Vector2(vector4.x, vector3.y);
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			for (int num = 0; num < list.Count; num++)
			{
				Vector2 vector7 = list[num];
				if (!flag && (vector7 - vector3).magnitude < 0.05f)
				{
					flag = true;
					continue;
				}
				if (!flag2 && (vector7 - vector4).magnitude < 0.05f)
				{
					flag2 = true;
					continue;
				}
				if (!flag3 && (vector7 - vector5).magnitude < 0.05f)
				{
					flag3 = true;
					continue;
				}
				if (flag4 || !((vector7 - vector6).magnitude < 0.05f))
				{
					break;
				}
				flag4 = true;
			}
			if (flag && flag2 && flag3 && flag4)
			{
				list = new List<Vector2> { vector3, vector6, vector4, vector5 };
			}
		}
		Vector2[] array = list.ToArray();
		Vector3 vector8 = new Vector3(10f, 2f, 10f);
		Vector3 vector9 = new Vector3(-10f, 0f, -10f);
		Vector3 position = furn.transform.position;
		Quaternion rotation = furn.transform.rotation;
		Vector3 localScale = furn.transform.localScale;
		furn.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		furn.transform.localScale = Vector3.one;
		foreach (Vector3 item in furn.GetComponentsInChildren<MeshFilter>().SelectMany((MeshFilter x) => x.sharedMesh.vertices.Select((Vector3 y) => x.transform.localToWorldMatrix.MultiplyPoint(y))))
		{
			vector8 = Utilities.MinVector(vector8, item);
			vector9 = Utilities.MaxVector(vector9, item);
		}
		furn.transform.SetPositionAndRotation(position, rotation);
		furn.transform.localScale = localScale;
		if ("Carpet".Equals(furn.Type))
		{
			furn.Height1 = -0.1f;
			furn.Height2 = -0.05f;
		}
		else
		{
			furn.Height1 = Mathf.Clamp(vector8.y, -1f, 3f);
			furn.Height2 = Mathf.Clamp(vector9.y, -1f, 3f);
		}
		BoxCollider component = furn.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.center = (vector9 + vector8) * 0.5f;
			component.size = vector9 - vector8;
		}
		Furniture furniture;
		bool flag5 = (((object)(furniture = furn.BaseObject as Furniture) == null) ? (!furn.IsSnapping && !furn.WallFurn) : (furniture.BuildBoundary != null && furniture.BuildBoundary.Length != 0));
		furn.NavBoundary = Array.Empty<Vector2>();
		furn.BuildBoundary = Array.Empty<Vector2>();
		if (furn.WallFurn)
		{
			furn.YOffset = (furn.CustomHeight ? furn.WallHeight : 0f) + (furn.Height1 + furn.Height2) * 0.5f;
			furn.WallWidth = vector9.x - vector8.x;
		}
		float num2 = vector9.x - vector8.x;
		int num3 = Mathf.RoundToInt(num2);
		float num4 = vector9.z - vector8.z;
		int num5 = Mathf.RoundToInt(num4);
		furn.OnXEdge = (num2 < 0.1f && num4 > 0.5f) || (num3 != 0 && num3 % 2 == 0);
		furn.OnYEdge = (num4 < 0.1f && num2 > 0.5f) || (num5 != 0 && num5 % 2 == 0);
		if (force || (flag5 && Utilities.PolygonArea(array) > 0.05f))
		{
			used = true;
			if (!furn.IsSnapping && !furn.InFloor && !furn.WallFurn && furn.Height1 >= 0f && furn.Height1 < 0.2f)
			{
				furn.NavBoundary = EnsureMinBounds(array, 0.3f);
			}
			Rect bounds = ((IList<Vector2>)array).GetBounds();
			if (bounds.width < 0.1f)
			{
				furn.BuildBoundary = new Vector2[2]
				{
					new Vector2(bounds.center.x, bounds.yMax - 0.01f),
					new Vector2(bounds.center.x, bounds.yMin + 0.01f)
				};
			}
			else if (bounds.height < 0.1f)
			{
				furn.BuildBoundary = new Vector2[2]
				{
					new Vector2(bounds.xMax - 0.01f, bounds.center.y),
					new Vector2(bounds.xMin + 0.01f, bounds.center.y)
				};
			}
			else
			{
				furn.BuildBoundary = new Vector2[array.Length];
				for (int num6 = 0; num6 < array.Length; num6++)
				{
					Vector2 first = array[(num6 == 0) ? (array.Length - 1) : (num6 - 1)];
					Vector2 second = array[num6];
					Vector2 third = array[(num6 + 1) % array.Length];
					furn.BuildBoundary[num6] = Utilities.GetOffset(first, second, third, 0.01f);
				}
			}
		}
		return array;
	}

	private static void FixSegment(RoomSegment seg, StringBuilder sb, List<string> issues, ref bool error)
	{
		seg.HasMask = seg.WallMask != null;
		if (seg.DynamicWidth)
		{
			if (seg.HasMask && !seg.ScalableObjects.Contains(seg.WallMask))
			{
				seg.ScalableObjects.Add(seg.WallMask);
			}
			if (seg.ScalableObjectsEdgeToEdge.Count == 0 && seg.ScalableObjects.Count == 0)
			{
				for (int i = 0; i < seg.InsideWallMeshes.Length; i++)
				{
					if (!seg.ScalableObjectsEdgeToEdge.Contains(seg.InsideWallMeshes[i].gameObject))
					{
						seg.ScalableObjectsEdgeToEdge.Add(seg.InsideWallMeshes[i].gameObject);
					}
				}
			}
		}
		if (seg.WallMask != null)
		{
			Vector3 localScale = seg.WallMask.transform.localScale;
			seg.WallMask.transform.localScale = new Vector3(seg.WallWidth - 0.1f, localScale.y, localScale.z);
		}
	}

	private static void FixFurniture(Furniture furn, StringBuilder sb, List<string> issues, ref bool error)
	{
		furn.Comfort = Mathf.Clamp01(furn.Comfort);
		furn.ComputerPowerModifier = Mathf.Clamp(furn.ComputerPowerModifier, 0f, 10f);
		AudioSource[] componentsInChildren = furn.GetComponentsInChildren<AudioSource>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].outputAudioMixerGroup = AudioManager.InGameNormal;
		}
		if (furn.NavBoundary != null && furn.NavBoundary.Length > 2 && Utilities.Clockwise(furn.NavBoundary))
		{
			furn.NavBoundary = null;
			FileError("The navigation boundary needs to be counter clockwise!", sb, issues, furn.name);
			error = true;
		}
		if (furn.BuildBoundary != null && furn.BuildBoundary.Length > 2 && Utilities.Clockwise(furn.BuildBoundary))
		{
			furn.BuildBoundary = null;
			FileError("The build boundary needs to be counter clockwise!", sb, issues, furn.name);
			error = true;
		}
		if (furn.LookAtPoints != null && furn.LookAtPoints.Length != 0 && furn.LookAtPoints.Any((Transform x) => x == null))
		{
			furn.LookAtPoints = furn.LookAtPoints.Where((Transform x) => x != null).ToArray();
		}
		ObjectDatabase.SetWallCullingDistance(furn);
	}

	private static float[] GetUseEffects(NodeWrapper node)
	{
		float[] array = new float[7];
		for (int i = 0; i < array.Length; i++)
		{
			int num = i;
			Furniture.UseEffect useEffect = (Furniture.UseEffect)i;
			array[num] = node.GetNodeValue(useEffect.ToString(), "0").ConvertToFloatDef(0f);
		}
		return array;
	}

	private static Vector2[] EnsureMinBounds(Vector2[] bounds, float min)
	{
		Vector2[] array = new Vector2[bounds.Length];
		Rect bounds2 = ((IList<Vector2>)bounds).GetBounds();
		Vector2 vector = Vector2.zero;
		Vector2 b = Vector2.one;
		bool flag = false;
		if (bounds2.width < min || bounds2.height < min)
		{
			flag = true;
			vector = bounds2.center;
			b = new Vector2(Mathf.Max(bounds2.width, min) / bounds2.width, Mathf.Max(bounds2.height, min) / bounds2.height);
		}
		for (int i = 0; i < bounds.Length; i++)
		{
			array[i] = bounds[i];
			if (flag)
			{
				array[i] = Vector2.Scale(array[i] - vector, b) + vector;
			}
		}
		return array;
	}

	private static Transform FindTransform(GameObject o, string name)
	{
		Transform transform = _transformCache.FirstOrDefault((TransformAction x) => x.T.name.Equals(name)).T;
		if (transform == null)
		{
			transform = o.GetComponentsInChildren<Transform>(true).FirstOrDefault((Transform x) => x.name.Equals(name));
		}
		return transform;
	}

	private static object ConvertValue(Type type, NodeWrapper value, GameObject o, List<string> issues, string rootFolder, Dictionary<string, Mesh> meshes, Dictionary<string, Material> materials)
	{
		if (type.IsClass && value.IsNull)
		{
			return null;
		}
		if (type.IsSubclassOf(typeof(UnityEngine.Component)))
		{
			string value2 = value.Value;
			if (value2.ToLower().Equals("self"))
			{
				return o.GetComponent(type);
			}
			Transform transform = FindTransform(o, value2);
			if (transform != null)
			{
				return transform.GetComponent(type);
			}
			throw new Exception("Failed finding transform: " + value2);
		}
		if (type == typeof(GameObject))
		{
			string value3 = value.Value;
			if (value3.ToLower().Equals("self"))
			{
				return o;
			}
			Transform transform2 = FindTransform(o, value3);
			if (transform2 != null)
			{
				return transform2.gameObject;
			}
			throw new Exception("Failed finding transform: " + value3);
		}
		if (type == typeof(Material))
		{
			return materials[value.Value];
		}
		if (type == typeof(FurnitureStyle))
		{
			if (value.TYDNode is TydList)
			{
				Color[] array = value.TYDNode.GetNodeValues().Select(StringToColor).ToArray();
				return new FurnitureStyle((array.Length != 0) ? array[0] : Color.white, (array.Length > 1) ? array[1] : Color.white, (array.Length > 2) ? array[2] : Color.white, null, null);
			}
			NodeWrapper node = value.GetNode("Color1", false);
			Color obj = ((node != null) ? StringToColor(node) : Color.white);
			node = value.GetNode("Color2", false);
			Color color = ((node != null) ? StringToColor(node) : Color.white);
			node = value.GetNode("Color3", false);
			Color color2 = ((node != null) ? StringToColor(node) : Color.white);
			node = value.GetNode("Replacement1", false);
			string replacement = ((node != null) ? node.Value : null);
			node = value.GetNode("Replacement2", false);
			return new FurnitureStyle(replacement2: (node != null) ? node.Value : null, c1: obj, c2: color, c3: color2, replacement1: replacement);
		}
		if (type.IsArray)
		{
			if (value.Children.Any())
			{
				Type elementType = type.GetElementType();
				Array array2 = Array.CreateInstance(elementType, value.Children.Count());
				int num = 0;
				{
					foreach (NodeWrapper child in value.Children)
					{
						array2.SetValue(ConvertValue(elementType, child, o, issues, rootFolder, meshes, materials), num);
						num++;
					}
					return array2;
				}
			}
			NodeWrapper[] delimitedValue = value.GetDelimitedValue(Environment.NewLine, "\r\n", "\n");
			Type elementType2 = type.GetElementType();
			Array array3 = Array.CreateInstance(elementType2, delimitedValue.Length);
			for (int i = 0; i < delimitedValue.Length; i++)
			{
				array3.SetValue(ConvertValue(elementType2, delimitedValue[i], o, issues, rootFolder, meshes, materials), i);
			}
			return array3;
		}
		if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
		{
			if (value.Children.Any())
			{
				Type type2 = type.GetGenericArguments()[0];
				IList list = (IList)Activator.CreateInstance(type);
				{
					foreach (NodeWrapper child2 in value.Children)
					{
						list.Add(ConvertValue(type2, child2, o, issues, rootFolder, meshes, materials));
					}
					return list;
				}
			}
			NodeWrapper[] delimitedValue2 = value.GetDelimitedValue(Environment.NewLine, "\r\n", "\n");
			Type type3 = type.GetGenericArguments()[0];
			IList list2 = (IList)Activator.CreateInstance(type);
			for (int j = 0; j < delimitedValue2.Length; j++)
			{
				list2.Add(ConvertValue(type3, delimitedValue2[j], o, issues, rootFolder, meshes, materials));
			}
			return list2;
		}
		if (type == typeof(Color))
		{
			return StringToColor(value);
		}
		if (type == typeof(Vector3))
		{
			return value.GetDelimitedValue(",").SelectInPlace((NodeWrapper x) => x.Value.ConvertToFloatDef(0f)).ToVector3();
		}
		if (type == typeof(Vector2))
		{
			return value.GetDelimitedValue(",").SelectInPlace((NodeWrapper x) => x.Value.ConvertToFloatDef(0f)).ToVector2();
		}
		if (type == typeof(Quaternion))
		{
			return Quaternion.Euler(value.GetDelimitedValue(",").SelectInPlace((NodeWrapper x) => x.Value.ConvertToFloatDef(0f)).ToVector3());
		}
		if (type == typeof(Mesh))
		{
			if (value.Value != null)
			{
				return LoadMesh(value.Value, issues, rootFolder, meshes, false);
			}
			return null;
		}
		return TypeDescriptor.GetConverter(type).ConvertFrom(value.Value);
	}

	private static Color StringToColor(NodeWrapper value)
	{
		Color color;
		if (value.Value != null && ColorUtility.TryParseHtmlString("#" + value.Value.Replace("#", ""), out color))
		{
			return color;
		}
		Vector3 vector = value.GetDelimitedValue(",").SelectInPlace((NodeWrapper x) => x.Value.ConvertToFloatDef(0f)).ToVector3();
		return new Color(vector.x, vector.y, vector.z);
	}

	private static Color StringToColor(string value)
	{
		Color color;
		if (!ColorUtility.TryParseHtmlString("#" + value.Replace("#", ""), out color))
		{
			return Color.white;
		}
		return color;
	}
}
