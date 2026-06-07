using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using DevConsole;
using SINetworking;
using StatementParser;
using Tyd;
using UnityEngine;

public static class GameData
{
	public enum EnvironmentType
	{
		Rural = 0,
		Town = 1,
		City = 2
	}

	public enum ClimateType
	{
		Cold = 0,
		Temperate = 1,
		Warm = 2
	}

	public static string[] ObsoleteDifficultySettings;

	private static string[] FemaleNames;

	private static string[] MaleNames;

	private static string[] LastNames;

	private static string[] FemaleLastNames;

	private static Dictionary<string, SoftwareType> SoftwareTypes;

	private static Dictionary<string, CompanyType> CompanyTypes;

	private static Dictionary<string, RandomNameGenerator> NameGens;

	public static Dictionary<string, Currency> CurrencyRates;

	public static List<ModPackage> ModPackages;

	public static List<RewardTask> Tasks;

	private static Currency cachedCurrency;

	private static bool hasCachedCurrency;

	private static string cachedCurrencyName;

	public static SaveGame LoadFile;

	public static SDateTime CompanyDate;

	public static byte[] CompanyData;

	public static bool LoadBackup;

	public static string CompanyName;

	public static bool LoadBuildingOnLoad;

	public static bool LoadCompanyOnLoad;

	public static bool EditMode;

	public static bool CampaignMode;

	public static string BobName;

	public static bool MultiplayerMode;

	public static bool DoCampaignInit;

	public static bool RestartCompany;

	public static List<MarketEvent> RestartEvents;

	public static HashSet<string> RestartCompletedMissions;

	public static HashSet<string> RestartActiveMissions;

	public static uint RestartCompanyID;

	public static PersonalityGraph RestartCompanyPersonalities;

	public static string[][] RestartCompanySpecs;

	public static double RestartCompanyFunds;

	public static byte[] RestartCompanyFounder;

	public static string LobbyName;

	public static string LobbyPassword;

	public static bool NetworkAllowCodeMods;

	public static bool NetworkAllowFurnitureMods;

	public static float? ForcedIPO;

	public static float RoundLimit;

	public static NetworkLobby.RoundLimitType RoundType;

	public static bool PlotAdjacency;

	public static double StartingMoney;

	public static Dictionary<string, SentenceGenerator> SentenceGen;

	public static Dictionary<string, MoodEffect> MoodEffects;

	private static PersonalityGraph Personalities;

	public static int ActiveYear;

	public static Actor[] Founders;

	public static bool IntroDone;

	public static bool RuralBigPlots;

	public static DifficultyValues.DifficultySetting SelectedDifficulty;

	public static int DaysPerMonth;

	public static int LoanAmount;

	public static int LoadYear;

	public static byte[] CompanyLogo;

	public static byte[] NetworkSaveData;

	public static NetworkMeta NetworkData;

	public static InitialNetworkSettings NetworkSettings;

	public static SDateTime? HostDate;

	public static EnvironmentType Environment;

	public static ClimateType Climate;

	public static List<BlueprintGroup> Blueprints;

	public static Dictionary<string, CustomActor> SavedStyles;

	public static Dictionary<string, Dictionary<string, BehaviorNode>> AITrees;

	public static System.Random RND;

	public static SoftwareType DigitalDistributionPlatform;

	public static string RandomString;

	public static TydDocument TeamSetups;

	public static TydDocument ProjectManagementSetups;

	public static List<string> LocalLogos;

	public static Dictionary<string, Material> UserImages;

	public static float DefaultBillboardEffect;

	private static RandomWordGenerator2 _wordGenerator;

	public static Dictionary<string, DLCObject> InstalledDLC;

	private static FileSystemWatcher _newImageWatcher;

	public static bool UserImagesDirty;

	private static bool _isInit;

	public const float DefaultMaxSpec = 0.5f;

	public static Dictionary<string, float> TaskTime;

	private static float[,] CachedEffectiveness;

	private static int[] OptimalEmployees;

	public static bool LoadAnyOnLoad
	{
		get
		{
			if (!LoadBuildingOnLoad)
			{
				return LoadCompanyOnLoad;
			}
			return true;
		}
		set
		{
			LoadBuildingOnLoad = (LoadCompanyOnLoad = value);
		}
	}

	public static string UserImagePath
	{
		get
		{
			return Path.Combine(Utilities.GetRoot(), "Images");
		}
	}

	public static float RNDValue
	{
		get
		{
			return (float)RND.NextDouble();
		}
	}

	public static event EventHandler OnNewImages;

	public static string GenerateWord(System.Random rng)
	{
		rng = new System.Random(rng.Next());
		string text;
		do
		{
			text = _wordGenerator.GenerateWord(rng);
		}
		while (ProfanityFilter.ProfanityStatic.Contains(text));
		return text.Substring(0, 1) + text.Substring(1).ToLower();
	}

	public static void InitRND()
	{
		RND = new System.Random(RandomString.GetHashCode());
	}

	public static void ResetLobbyData()
	{
		MultiplayerMode = false;
		LobbyName = null;
		LobbyPassword = null;
		NetworkAllowCodeMods = false;
		NetworkAllowFurnitureMods = false;
		NetworkSettings = null;
	}

	public static int RNDRange(int min, int max)
	{
		return RND.Next(min, max);
	}

	public static float RNDRange(float min, float max)
	{
		return min + (float)RND.NextDouble() * (max - min);
	}

	public static IEnumerator Initialize()
	{
		if (_isInit)
		{
			yield break;
		}
		_isInit = true;
		yield return "Loading static data";
		string modDir = Path.Combine(Utilities.GetRoot(), "Mods");
		if (!Directory.Exists(modDir))
		{
			Directory.CreateDirectory(modDir);
		}
		float t = Time.realtimeSinceStartup;
		LoadNames(modDir);
		LoadStaticData();
		LoadAI();
		if (File.Exists("Teams.tyd"))
		{
			try
			{
				TeamSetups = TydFile.FromFile("Teams.tyd").DocumentNode;
			}
			catch (Exception)
			{
				TeamSetups = null;
			}
		}
		if (File.Exists("ProjectManagement.tyd"))
		{
			try
			{
				ProjectManagementSetups = TydFile.FromFile("ProjectManagement.tyd").DocumentNode;
			}
			catch (Exception)
			{
				ProjectManagementSetups = null;
			}
		}
		LoadCurrencies(modDir);
		LoadStyles();
		cachedCurrency = CurrencyRates["Standard"];
		CacheEffectivenessStats();
		_wordGenerator = new RandomWordGenerator2(LoadTextAsset("RandomWord2"));
		if (Application.isPlaying)
		{
			float tt = Time.realtimeSinceStartup;
			yield return "Loading data mods";
			LoadMods(modDir);
			Debug.Log("Data mod load time: " + (Time.realtimeSinceStartup - tt).SecondsToTime());
			yield return "Loading blueprints";
			tt = Time.realtimeSinceStartup;
			LoadPrefabs();
			Debug.Log("Blueprint load time: " + (Time.realtimeSinceStartup - tt).SecondsToTime());
		}
		string imgPath = UserImagePath;
		Material material = new Material(ObjectDatabase.Instance.UserImageMaterial);
		material.mainTexture = ObjectDatabase.Instance.DefaultUserImage;
		UserImages["defaultuserimage"] = material;
		if (Directory.Exists(imgPath))
		{
			_newImageWatcher = new FileSystemWatcher(imgPath);
			float tt = Time.realtimeSinceStartup;
			yield return "Loading user images";
			LoadUserImages(imgPath);
			Debug.Log("User image load time: " + (Time.realtimeSinceStartup - tt).SecondsToTime());
		}
		else
		{
			try
			{
				Directory.CreateDirectory(imgPath);
				_newImageWatcher = new FileSystemWatcher(imgPath);
			}
			catch (Exception ex3)
			{
				Debug.Log("Failed creating user image path:\n" + ex3.ToString());
			}
		}
		if (_newImageWatcher != null)
		{
			_newImageWatcher.EnableRaisingEvents = true;
			_newImageWatcher.NotifyFilter = NotifyFilters.FileName;
			_newImageWatcher.Changed += delegate
			{
				UserImagesDirty = true;
			};
			_newImageWatcher.Created += delegate
			{
				UserImagesDirty = true;
			};
		}
		Debug.Log("Data load time: " + (Time.realtimeSinceStartup - t).SecondsToTime());
		try
		{
			string path = Path.Combine(Utilities.GetRoot(), "Logos.txt");
			if (File.Exists(path))
			{
				LocalLogos = new List<string>(File.ReadAllLines(path));
			}
		}
		catch (Exception ex4)
		{
			Debug.Log(ex4.ToString());
		}
	}

	public static void LoadUserImages(string imgPath)
	{
		UserImagesDirty = false;
		if (Directory.Exists(imgPath))
		{
			string[] files = Directory.GetFiles(imgPath, "*.png");
			for (int i = 0; i < files.Length; i++)
			{
				LoadUserImage(files[i]);
			}
			files = Directory.GetFiles(imgPath, "*.jpg");
			for (int i = 0; i < files.Length; i++)
			{
				LoadUserImage(files[i]);
			}
			files = Directory.GetFiles(imgPath, "*.jpeg");
			for (int i = 0; i < files.Length; i++)
			{
				LoadUserImage(files[i]);
			}
		}
		EventHandler onNewImages = GameData.OnNewImages;
		if (onNewImages != null)
		{
			onNewImages(null, null);
		}
	}

	private static void LoadUserImage(string filePath)
	{
		string text = "";
		try
		{
			text = XxHash64.ComputeHashHex(filePath, 0uL);
		}
		catch (Exception)
		{
		}
		string key = Path.GetFileName(filePath).ToLower();
		Material value;
		if (!UserImages.TryGetValue(key, out value) || !(value.name != "") || !value.name.Equals(text))
		{
			Texture2D texture2D = new Texture2D(1, 1);
			texture2D.wrapMode = TextureWrapMode.Clamp;
			try
			{
				texture2D.LoadImage(File.ReadAllBytes(filePath));
			}
			catch (Exception ex2)
			{
				Debug.Log("Failed loading user image " + Path.GetFileName(filePath) + "\n" + ex2.ToString());
				UnityEngine.Object.Destroy(texture2D);
				return;
			}
			if (value != null)
			{
				value.name = text;
				UnityEngine.Object.Destroy(value.mainTexture);
				value.mainTexture = texture2D;
			}
			else
			{
				value = new Material(ObjectDatabase.Instance.UserImageMaterial);
				value.name = text;
				value.mainTexture = texture2D;
				UserImages[key] = value;
			}
		}
	}

	public static void SaveLogo(string logo)
	{
		logo = ReloadSDFTree(ReloadSDFTree(ReloadSDFTree(logo)));
		if (!LocalLogos.Contains(logo))
		{
			LocalLogos.Add(logo);
			try
			{
				File.WriteAllLines(Path.Combine(Utilities.GetRoot(), "Logos.txt"), LocalLogos);
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
			}
		}
	}

	private static string ReloadSDFTree(string input)
	{
		return SDFCreator.GetTreeString(SDFCreator.SerializeTree(SDFCreator.LoadSDFTree(SDFCreator.GetTreeFromString(input))));
	}

	public static void DeleteLogo(string logo)
	{
		if (LocalLogos.Remove(logo))
		{
			try
			{
				File.WriteAllLines(Path.Combine(Utilities.GetRoot(), "Logos.txt"), LocalLogos);
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
			}
		}
	}

	public static CampaignMission LoadMission(string ID)
	{
		TydDocument documentNode = TydFile.FromContent(LoadFullTextAsset("Campaign/" + ID), ID).DocumentNode;
		return new CampaignMission(ID, documentNode);
	}

	public static void InitializeNow()
	{
		IEnumerator enumerator = Initialize();
		while (enumerator.MoveNext())
		{
		}
	}

	static GameData()
	{
		ObsoleteDifficultySettings = new string[4] { "Easy", "Medium", "Hard", "Impossible" };
		SoftwareTypes = new Dictionary<string, SoftwareType>();
		CompanyTypes = new Dictionary<string, CompanyType>();
		NameGens = new Dictionary<string, RandomNameGenerator>();
		CurrencyRates = new Dictionary<string, Currency> { 
		{
			"Standard",
			new Currency("Standard", "$", "", 1f)
		} };
		ModPackages = new List<ModPackage>();
		Tasks = new List<RewardTask>();
		hasCachedCurrency = false;
		LoadBackup = false;
		CompanyName = "MyCompany";
		LoadBuildingOnLoad = false;
		LoadCompanyOnLoad = false;
		EditMode = false;
		CampaignMode = false;
		BobName = null;
		MultiplayerMode = false;
		DoCampaignInit = false;
		RestartCompany = false;
		RestartEvents = null;
		RestartCompletedMissions = null;
		RestartActiveMissions = null;
		NetworkAllowCodeMods = false;
		NetworkAllowFurnitureMods = false;
		ForcedIPO = null;
		RoundLimit = float.PositiveInfinity;
		RoundType = NetworkLobby.RoundLimitType.DisablePause;
		PlotAdjacency = false;
		StartingMoney = 0.0;
		SentenceGen = new Dictionary<string, SentenceGenerator>();
		ActiveYear = 80;
		IntroDone = false;
		RuralBigPlots = true;
		SelectedDifficulty = DifficultyValues.DefaultSettings;
		DaysPerMonth = 1;
		LoanAmount = 0;
		LoadYear = 0;
		Environment = EnvironmentType.Town;
		Climate = ClimateType.Temperate;
		Blueprints = new List<BlueprintGroup>();
		SavedStyles = new Dictionary<string, CustomActor>();
		AITrees = new Dictionary<string, Dictionary<string, BehaviorNode>>();
		RND = new System.Random();
		RandomString = "None";
		LocalLogos = new List<string>();
		UserImages = new Dictionary<string, Material>();
		DefaultBillboardEffect = 3f;
		InstalledDLC = new Dictionary<string, DLCObject>();
		UserImagesDirty = false;
		_isInit = false;
		TaskTime = new Dictionary<string, float>();
		CachedEffectiveness = new float[512, 64];
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		if (System.Environment.GetCommandLineArgs().None((string x) => x.ToLower().Equals("-disablethreadboost")))
		{
			int workerThreads;
			int completionPortThreads;
			ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
			int workerThreads2;
			int completionPortThreads2;
			ThreadPool.GetMaxThreads(out workerThreads2, out completionPortThreads2);
			ThreadPool.SetMinThreads(Mathf.Min(300, workerThreads2), completionPortThreads);
		}
		else
		{
			Debug.Log("Disabled thread boost hack");
		}
		Debug.Log("Software Inc. " + Versioning.NetworkVersionString);
	}

	private static IEnumerable<string> GetDLCSearchPaths()
	{
		yield return Path.GetFullPath("/");
		yield return Path.GetFullPath("DLC");
		yield return Utilities.GetRoot();
		yield return Path.Combine(Utilities.GetRoot(), "DLC");
	}

	private static IEnumerator LoadDLC()
	{
		yield return "Checking for DLC";
		HashSet<string> loaded = new HashSet<string>();
		foreach (string dLCSearchPath in GetDLCSearchPaths())
		{
			if (!loaded.Add(dLCSearchPath) || !Directory.Exists(dLCSearchPath))
			{
				continue;
			}
			string[] files = Directory.GetFiles(dLCSearchPath, "*.dlc");
			foreach (string text in files)
			{
				AssetBundle assetBundle = AssetBundle.LoadFromFile(text);
				if (!(assetBundle != null))
				{
					continue;
				}
				TextAsset textAsset = assetBundle.LoadAsset<TextAsset>("meta.txt");
				if (!(textAsset != null))
				{
					continue;
				}
				TydFile tydFile = TydFile.FromContent(textAsset.text, text);
				string childValue = tydFile.DocumentNode.GetChildValue("Name");
				if (!Options.IsDLCDisabled(childValue) && !InstalledDLC.ContainsKey(childValue))
				{
					TextAsset textAsset2 = assetBundle.LoadAsset<TextAsset>("main.bytes");
					if (textAsset2 != null)
					{
						Assembly assembly;
						try
						{
							assembly = Assembly.Load(textAsset2.bytes);
						}
						catch (Exception ex)
						{
							Debug.LogError("Found DLC: " + Path.GetFileName(text) + " but failed to load assembly:\n" + ex.ToString());
							continue;
						}
						Type type = assembly.GetTypes().FirstOrDefault((Type x) => x.IsSubclassOf(typeof(DLCObject)));
						if (type != null)
						{
							DLCObject dLCObject = Activator.CreateInstance(type) as DLCObject;
							dLCObject.Initialize(assetBundle, tydFile.DocumentNode);
							InstalledDLC[childValue] = dLCObject;
							LoadDLCData(dLCObject);
							yield return "Found " + Path.GetFileName(text);
						}
						else
						{
							yield return "Found " + Path.GetFileName(text) + ", but missing meta class";
						}
					}
					else
					{
						yield return "Found " + Path.GetFileName(text) + ", but missing assembly";
					}
				}
				else
				{
					yield return "Found " + Path.GetFileName(text) + ", but missing meta data";
				}
			}
		}
	}

	private static void LoadDLCData(DLCObject o)
	{
		foreach (Localization.Translation language in Localization.GetLanguages())
		{
			TydDocument translation = o.GetTranslation(language.ItemTitle);
			if (translation != null)
			{
				language.AddNewNodes(translation, o.DLCName);
			}
		}
		foreach (SoftwareType item in o.EmbeddedSoftwareTypes())
		{
			SoftwareTypes[item.Name] = item;
		}
		foreach (CompanyType item2 in o.EmbeddedCompanyTypes())
		{
			CompanyTypes[item2.Name] = item2;
		}
		foreach (var item3 in o.EmbeddedNameGenerators())
		{
			NameGens[item3.Item1] = item3.Item2;
		}
	}

	private static void LoadAI()
	{
		Type typeFromHandle = typeof(AI);
		foreach (KeyValuePair<string, string> item in LoadAllTextAssetsWithNameNoSplit("AI"))
		{
			TydFile tydFile = TydFile.FromContent(item.Value, null);
			AITrees[item.Key] = BehaviorNode.LoadTree(tydFile.DocumentNode, item.Key, typeFromHandle);
		}
	}

	private static void LoadStyles()
	{
		try
		{
			string path = Path.Combine(Utilities.GetRoot(), "Characters");
			if (!Directory.Exists(path))
			{
				return;
			}
			string[] files = Directory.GetFiles(path, "*.xml");
			foreach (string text in files)
			{
				try
				{
					XMLParser.XMLNode root = XMLParser.ParseXML(File.ReadAllText(text));
					SavedStyles[Path.GetFileNameWithoutExtension(text)] = new CustomActor(root);
				}
				catch (Exception ex)
				{
					Debug.Log("Failed loading character: " + text + ":\n" + ex.ToString());
				}
			}
		}
		catch (Exception ex2)
		{
			Debug.Log(ex2.ToString());
		}
	}

	public static void CreateStyle(string name, bool female, ActorBodyItem.BodyItemObject[] items, float[] skills, Dictionary<string, int>[] specs, string[] personality, Employee.Trait[] traits)
	{
		try
		{
			string text = Path.Combine(Utilities.GetRoot(), "Characters");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			CustomActor customActor = new CustomActor(female, items, personality, traits, skills, specs);
			File.WriteAllText(Path.Combine(text, name + ".xml"), XMLParser.ExportXML(customActor.Serialize()));
			SavedStyles[name] = customActor;
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString());
		}
	}

	public static void DeleteStyle(string name)
	{
		try
		{
			string path = Path.Combine(Path.Combine(Utilities.GetRoot(), "Characters"), name + ".xml");
			if (File.Exists(path))
			{
				File.Delete(path);
				SavedStyles.Remove(name);
			}
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString());
		}
	}

	public static IWorkshopItem LoadSteamPrefab(string path, string name)
	{
		try
		{
			BlueprintGroup blueprintGroup = BlueprintGroup.LoadBlueprintGroup(path);
			if (blueprintGroup != null)
			{
				Blueprints.Add(blueprintGroup);
				return blueprintGroup;
			}
			return new FailMod("Blueprint", path, name, "Empty");
		}
		catch (Exception ex)
		{
			string text = "Error loading blueprint " + name + ":\n" + ex.ToString();
			Debug.Log(text);
			DevConsole.Console.LogError(text);
			return new FailMod("Blueprint", path, name, ex.ToString());
		}
	}

	public static void LoadPrefabs()
	{
		try
		{
			string path = Path.Combine(Utilities.GetRoot(), "Blueprints");
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			string[] directories = Directory.GetDirectories(path);
			foreach (string path2 in directories)
			{
				try
				{
					BlueprintGroup blueprintGroup = BlueprintGroup.LoadBlueprintGroup(path2);
					if (blueprintGroup != null)
					{
						Blueprints.Add(blueprintGroup);
					}
					else
					{
						new FailMod("Blueprint", path2, "Empty");
					}
				}
				catch (Exception ex)
				{
					new FailMod("Blueprint", path2, ex.ToString());
					DevConsole.Console.LogError("Error loading blueprint " + Path.GetFileName(path2) + ":\n" + ex.ToString());
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	public static void LoadGame(SaveGame file, byte[] companyData, SDateTime companyDate, bool backup, bool company, bool building, bool editMode)
	{
		LoadFile = file;
		CompanyData = companyData;
		CompanyDate = companyDate;
		LoadBuildingOnLoad = building;
		LoadCompanyOnLoad = company;
		LoadBackup = backup;
		EditMode = editMode;
		if (GUILoading.Instance != null)
		{
			GUILoading.SetState(true);
		}
	}

	private static void AddNode(TydCollection parent, string name, string desc, string tableName = null)
	{
		string text = name.Strip(' ');
		TydNode tydNode = ((!string.IsNullOrEmpty(desc)) ? ((TydNode)new TydList(text, name, desc)) : ((TydNode)new TydString(text, name)));
		if (tableName != null)
		{
			parent = parent.AddChild(new TydTable(tableName));
		}
		if (TydToText.ShouldWriteWithQuotes(text))
		{
			parent.AddChild(new TydString("Name", text));
			tydNode.Name = "Value";
			parent.AddChild(tydNode);
		}
		else
		{
			parent.AddChild(tydNode);
		}
	}

	public static void ExportSoftwareToLocalization(IEnumerable<SoftwareType> types, IList<HardwareDesign> hwDesign, string outputPath, bool includeDefault)
	{
		bool flag = includeDefault;
		TydDocument tydDocument = new TydDocument();
		if (includeDefault)
		{
			tydDocument.AddChild(new TydList("SoftwareCategoryDefault", "Default", ""));
		}
		HashSet<string> hashSet = new HashSet<string>();
		foreach (SoftwareType type in types)
		{
			hashSet.Clear();
			flag = true;
			TydTable tydTable = tydDocument.AddChild(new TydTable("Software"));
			AddNode(tydTable, type.Name, type.Description);
			TydList parent = tydTable.AddChild(new TydList("Features"));
			foreach (FeatureBase value in type.Features.Values)
			{
				if (hashSet.Add(value.Name))
				{
					AddNode(parent, value.Name, value.Description, "Feature");
				}
			}
			TydList tydList = null;
			if (type.Categories.Count > 1 || !type.Categories.First().Key.Equals("Default"))
			{
				tydList = tydTable.AddChild(new TydList("Categories"));
				foreach (SoftwareCategory value2 in type.Categories.Values)
				{
					AddNode(tydList, value2.Name, value2.Description, "Category");
				}
			}
			if (type.AddOns.Count > 0)
			{
				if (tydList == null)
				{
					tydList = tydTable.AddChild(new TydList("Categories"));
				}
				foreach (SoftwareAddOn value3 in type.AddOns.Values)
				{
					AddNode(tydList, value3.Name, value3.Description, "Category");
					foreach (AddOnFeature value4 in value3.Features.Values)
					{
						if (hashSet.Add(value4.Name))
						{
							AddNode(parent, value4.Name, value4.Description, "Feature");
						}
					}
				}
			}
			HashSet<string> hashSet2 = null;
			foreach (SoftwareCategory value5 in type.Categories.Values)
			{
				if (value5.Hardware)
				{
					if (hashSet2 == null)
					{
						hashSet2 = new HashSet<string>();
					}
					for (int i = 0; i < value5.Manufacturing.Components.Length; i++)
					{
						hashSet2.Add(value5.Manufacturing.Components[i].Name);
					}
				}
			}
			foreach (SoftwareAddOn value6 in type.AddOns.Values)
			{
				if (value6.Hardware)
				{
					if (hashSet2 == null)
					{
						hashSet2 = new HashSet<string>();
					}
					for (int j = 0; j < value6.Manufacturing.Components.Length; j++)
					{
						hashSet2.Add(value6.Manufacturing.Components[j].Name);
					}
				}
			}
			if (hashSet2 == null)
			{
				continue;
			}
			TydList parent2 = tydTable.AddChild(new TydList("Components"));
			foreach (string item in hashSet2)
			{
				AddNode(parent2, item, null, "Component");
			}
		}
		if (hwDesign != null)
		{
			HashSet<string> keys = new HashSet<string>();
			TydTable parent3 = tydDocument.AddChild(new TydTable("Hardware"));
			foreach (HardwareDesign item2 in hwDesign)
			{
				AddHWLoc(item2.ID, item2.Name, keys, parent3);
				HardwareDesign.MeshObject[] objects = item2.Objects;
				foreach (HardwareDesign.MeshObject meshObject in objects)
				{
					bool inUse;
					if (NeedsLoc(item2, meshObject, out inUse))
					{
						AddHWLoc(meshObject.ID, meshObject.Name, keys, parent3);
					}
					if ((inUse || meshObject.ID.Equals(item2.BaseMesh)) && meshObject.MorphTargets != null)
					{
						HardwareDesign.MorphInfo[] morphTargets = meshObject.MorphTargets;
						foreach (HardwareDesign.MorphInfo morphInfo in morphTargets)
						{
							AddHWLoc(morphInfo.Label, morphInfo.Label, keys, parent3);
						}
					}
				}
			}
		}
		if (flag)
		{
			File.WriteAllText(outputPath, TydToText.Write(tydDocument, true, 0, 0, true), Encoding.UTF8);
		}
	}

	private static bool NeedsLoc(HardwareDesign design, HardwareDesign.MeshObject o, out bool inUse)
	{
		inUse = false;
		for (int i = 0; i < design.Attachments.Count; i++)
		{
			HardwareDesign.AttachmentPoint attachmentPoint = design.Attachments[i];
			bool flag = attachmentPoint.Attachments.Any((HardwareDesign.Attachment z) => z.Object.Equals(o.ID));
			inUse |= flag;
			if (flag && (attachmentPoint.CanBeEmpty || attachmentPoint.CanRemove))
			{
				return true;
			}
		}
		return false;
	}

	private static void AddHWLoc(string key, string value, HashSet<string> keys, TydTable parent)
	{
		string text = key.Strip(' ');
		if (keys.Add(text))
		{
			parent.AddChild(new TydString(text, value));
		}
	}

	public static Currency GetCurrency(string name)
	{
		if (hasCachedCurrency && name.Equals(cachedCurrencyName))
		{
			return cachedCurrency;
		}
		Currency value;
		if (CurrencyRates.TryGetValue(name, out value))
		{
			cachedCurrencyName = name;
			cachedCurrency = value;
			hasCachedCurrency = true;
			return value;
		}
		return cachedCurrency;
	}

	private static string[] GetCorrectNaming(string[] check, string[] fallback)
	{
		if (check == null || check.Length == 0)
		{
			return fallback;
		}
		return check;
	}

	public static string GenerateName(bool male)
	{
		string[] array = (male ? GetCorrectNaming(Localization.CurrentTranslation.MaleNames, MaleNames) : GetCorrectNaming(Localization.CurrentTranslation.FemaleNames, FemaleNames));
		string obj = array[Utilities.GaussRange(0f, 0, array.Length - 1, 0.4f)];
		array = GetCorrectNaming(GetCorrectNaming((!male) ? GetCorrectNaming(Localization.CurrentTranslation.FemaleLastNames, FemaleLastNames) : null, Localization.CurrentTranslation.LastNames), LastNames);
		return obj + " " + array[Utilities.GaussRange(0f, 0, array.Length - 1, 0.4f)];
	}

	public static IEnumerable<SoftwareType> AllSoftwareTypes(ModPackage[] mods = null)
	{
		InitializeNow();
		mods = mods ?? ModPackages.Where((ModPackage x) => x.Enabled).ToArray();
		Dictionary<string, SoftwareType> dictionary = SoftwareTypes.ToDictionary((KeyValuePair<string, SoftwareType> x) => x.Key, (KeyValuePair<string, SoftwareType> x) => x.Value);
		List<string> list = mods.SelectMany((ModPackage x) => from z in x.SoftwareTypeOverrides
			where z.Value.Delete
			select z.Key).Distinct().ToList();
		list.RemoveAll((string x) => "Operating System".Equals(x));
		foreach (string item in list)
		{
			dictionary.Remove(item);
		}
		ModPackage[] array = mods;
		for (int num = 0; num < array.Length; num++)
		{
			foreach (KeyValuePair<string, SoftwareType> softwareType in array[num].SoftwareTypes)
			{
				if (!list.Contains(softwareType.Key))
				{
					dictionary[softwareType.Key] = softwareType.Value;
				}
			}
		}
		Dictionary<string, SoftwareTypeOverride[]> dictionary2 = (from x in mods.SelectMany((ModPackage x) => x.SoftwareTypeOverrides.Values)
			group x by x.Name).ToDictionary((IGrouping<string, SoftwareTypeOverride> x) => x.Key, (IGrouping<string, SoftwareTypeOverride> x) => x.ToArray());
		foreach (KeyValuePair<string, SoftwareType> item2 in dictionary.ToList())
		{
			if (dictionary2.ContainsKey(item2.Key))
			{
				dictionary[item2.Key] = item2.Value.Clone(dictionary2[item2.Key]);
			}
			else
			{
				dictionary[item2.Key] = item2.Value.Clone();
			}
		}
		return dictionary.Values;
	}

	public static string[] FilterUnlockedSpecs(string[] specs, int year, IList<SoftwareType> types, SoftwareType OS)
	{
		List<string> list = new List<string>(specs.Length);
		foreach (string text in specs)
		{
			bool flag = OS.HasSpec(text);
			for (int j = 0; j < types.Count; j++)
			{
				SoftwareType softwareType = types[j];
				if ((flag && softwareType.OSSpecific) || !softwareType.IsUnlocked(year))
				{
					continue;
				}
				bool flag2 = false;
				foreach (FeatureBase allFeature in softwareType.GetAllFeatures())
				{
					if (allFeature.Spec.Equals(text) && allFeature.IsUnlocked(year))
					{
						list.Add(text);
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					break;
				}
			}
		}
		return list.ToArray();
	}

	public static int CountSpecialization(SoftwareType[] sw, Employee.EmployeeRole role)
	{
		switch (role)
		{
		case Employee.EmployeeRole.Programmer:
			return CountSpecialization(from x in sw.SelectMany((SoftwareType x) => x.GetAllFeatures())
				where x.CodeArtRatio > 0f
				select x);
		case Employee.EmployeeRole.Designer:
			return CountSpecialization(sw.SelectMany((SoftwareType x) => x.GetAllFeatures()));
		case Employee.EmployeeRole.Artist:
			return CountSpecialization(from x in sw.SelectMany((SoftwareType x) => x.GetAllFeatures())
				where x.CodeArtRatio < 1f
				select x);
		default:
			throw new ArgumentOutOfRangeException("role", role, null);
		}
	}

	public static int CountSpecialization(IEnumerable<FeatureBase> features)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (FeatureBase feature in features)
		{
			hashSet.Add(feature.Spec);
		}
		return hashSet.Count;
	}

	public static string[][] GetSpecialization(SoftwareType[] sw)
	{
		return new string[3][]
		{
			sw.SelectMany((SoftwareType x) => from z in x.GetAllFeatures()
				select z.Spec).Distinct().ToArray(),
			sw.SelectMany((SoftwareType x) => from z in x.GetAllFeatures()
				where z.CodeArtRatio > 0f
				select z.Spec).Distinct().ToArray(),
			sw.SelectMany((SoftwareType x) => from z in x.GetAllFeatures()
				where z.CodeArtRatio < 1f
				select z.Spec).Distinct().ToArray()
		};
	}

	public static string[][] GetUnlockedSpecializations(int year, bool all = false)
	{
		string[][] array = (all ? new string[5][] : new string[3][]);
		SoftwareType[] array2 = AllSoftwareTypes().ToArray();
		SoftwareType oS = array2.First((SoftwareType x) => x.Name.Equals("Operating System"));
		if (all)
		{
			array[0] = Employee.LeadSpecs;
			array[4] = Employee.ServiceSpecs;
		}
		string[][] specialization = GetSpecialization(array2);
		array[all ? 3 : 2] = FilterUnlockedSpecs(specialization[2], year, array2, oS);
		array[1] = FilterUnlockedSpecs(specialization[1], year, array2, oS);
		array[all ? 2 : 0] = FilterUnlockedSpecs(specialization[0], year, array2, oS);
		return array;
	}

	public static string[] GetUnlockedSpecializations(Employee.EmployeeRole role)
	{
		SoftwareType[] array = AllSoftwareTypes().ToArray();
		SoftwareType oS = array.First((SoftwareType x) => x.Name.Equals("Operating System"));
		string[][] specialization = GetSpecialization(array);
		int activeYear = ActiveYear;
		switch (role)
		{
		case Employee.EmployeeRole.Lead:
			return Employee.LeadSpecs;
		case Employee.EmployeeRole.Programmer:
			return FilterUnlockedSpecs(specialization[1], activeYear, array, oS);
		case Employee.EmployeeRole.Designer:
			return FilterUnlockedSpecs(specialization[0], activeYear, array, oS);
		case Employee.EmployeeRole.Artist:
			return FilterUnlockedSpecs(specialization[2], activeYear, array, oS);
		case Employee.EmployeeRole.Service:
			return Employee.ServiceSpecs;
		default:
			throw new ArgumentOutOfRangeException("role", role, null);
		}
	}

	public static int GetMaxSpecPoints(Employee.EmployeeRole role, bool forceFull = false, float maxAmount = 0.5f)
	{
		switch (role)
		{
		case Employee.EmployeeRole.Lead:
			if (forceFull)
			{
				return Employee.LeadSpecs.Length * 3;
			}
			return Employee.MaxLeadSpec;
		case Employee.EmployeeRole.Service:
			if (forceFull)
			{
				return Employee.ServiceSpecs.Length * 3;
			}
			return Employee.MaxServiceSpec;
		default:
		{
			int num = CountSpecialization(AllSoftwareTypes().ToArray(), role);
			if (forceFull)
			{
				return num * 3;
			}
			return MaxDevSpec(num, maxAmount);
		}
		}
	}

	public static int MaxDevSpec(int count, float maxAmount = 0.5f)
	{
		return Mathf.FloorToInt((float)(count * 3) * maxAmount);
	}

	public static IEnumerable<KeyValuePair<string, RandomNameGenerator>> AllNameGenerators(ModPackage[] mods = null)
	{
		mods = mods ?? ModPackages.Where((ModPackage mod) => mod.Enabled).ToArray();
		IEnumerable<KeyValuePair<string, RandomNameGenerator>> enumerable = NameGens.AsEnumerable();
		ModPackage[] array = mods;
		foreach (ModPackage modPackage in array)
		{
			enumerable = enumerable.Concat(modPackage.NameGenerators);
		}
		return enumerable;
	}

	public static RandomNameGenerator GetStaticNameGenerator(string name)
	{
		return NameGens[name];
	}

	public static Dictionary<string, RandomNameGenerator> MergeGenerators(IEnumerable<KeyValuePair<string, RandomNameGenerator>> generators)
	{
		Dictionary<string, RandomNameGenerator> dictionary = new Dictionary<string, RandomNameGenerator>();
		foreach (string key in generators.Select((KeyValuePair<string, RandomNameGenerator> x) => x.Key).Distinct())
		{
			RandomNameGenerator[] array = (from x in generators
				where x.Key.Equals(key)
				select x.Value).ToArray();
			RandomNameGenerator randomNameGenerator = array.FirstOrDefault((RandomNameGenerator x) => x.Replace);
			if (randomNameGenerator != null)
			{
				dictionary.Add(key, randomNameGenerator);
				continue;
			}
			RandomNameGenerator randomNameGenerator2 = array[0].Clone();
			for (int num = 1; num < array.Length; num++)
			{
				randomNameGenerator2.MergeWith(array[num]);
			}
			dictionary.Add(key, randomNameGenerator2);
		}
		return dictionary;
	}

	public static PersonalityGraph AllPersonalities()
	{
		List<ModPackage> list = ModPackages.Where((ModPackage x) => x.Enabled && x.Personalities != null).ToList();
		ModPackage modPackage = list.FirstOrDefault((ModPackage x) => x.Personalities.Replace && x.Personalities.PersonalityTraits.Count > 1);
		PersonalityGraph personalityGraph = ((modPackage == null) ? Personalities.Clone() : modPackage.Personalities.Clone());
		for (int num = 0; num < list.Count; num++)
		{
			ModPackage modPackage2 = list[num];
			if (modPackage2 != modPackage)
			{
				personalityGraph.MergeWith(modPackage2.Personalities);
			}
		}
		return personalityGraph;
	}

	public static PersonalityGraph VanillaPersonalities()
	{
		return Personalities.Clone();
	}

	public static IEnumerable<CompanyType> AllCompanyTypes()
	{
		return AllCompanyTypes(ModPackages.Where((ModPackage mod) => mod.Enabled).ToArray());
	}

	public static IEnumerable<CompanyType> AllCompanyTypes(params ModPackage[] mods)
	{
		Dictionary<string, CompanyType> dictionary = CompanyTypes.ToDictionary((KeyValuePair<string, CompanyType> x) => x.Key, (KeyValuePair<string, CompanyType> x) => x.Value);
		HashSet<string> hashSet = new HashSet<string>();
		foreach (ModPackage modPackage in mods)
		{
			foreach (KeyValuePair<string, CompanyType> companyType in modPackage.CompanyTypes)
			{
				dictionary[companyType.Key] = companyType.Value;
			}
			hashSet.AddRange(modPackage.DeleteCompanyTypes);
		}
		foreach (string item in hashSet)
		{
			dictionary.Remove(item);
		}
		return dictionary.Values;
	}

	public static IEnumerable<string> SoftwareTypeNames()
	{
		IEnumerable<string> enumerable = SoftwareTypes.Keys.AsEnumerable();
		foreach (ModPackage item in ModPackages.Where((ModPackage mod) => mod.Enabled))
		{
			enumerable = enumerable.Concat(item.SoftwareTypes.Keys);
		}
		return enumerable;
	}

	public static SoftwareType GetSoftwareType(string name)
	{
		SoftwareType value = null;
		foreach (ModPackage item in ModPackages.Where((ModPackage mod) => mod.Enabled))
		{
			if (item.SoftwareTypes.TryGetValue(name, out value))
			{
				return value;
			}
		}
		if (SoftwareTypes.TryGetValue(name, out value))
		{
			return value;
		}
		throw new UnityException("Failed locating software type: " + name);
	}

	public static CompanyType GetCompanyType(string name)
	{
		CompanyType value = null;
		foreach (ModPackage item in ModPackages.Where((ModPackage mod) => mod.Enabled))
		{
			if (item.CompanyTypes.TryGetValue(name, out value))
			{
				return value;
			}
		}
		if (CompanyTypes.TryGetValue(name, out value))
		{
			return value;
		}
		throw new UnityException("Failed locating company type: " + name);
	}

	public static RandomNameGenerator GetRandomNameGenerators(string name)
	{
		RandomNameGenerator value = null;
		foreach (ModPackage item in ModPackages.Where((ModPackage mod) => mod.Enabled))
		{
			if (item.NameGenerators.TryGetValue(name, out value))
			{
				return value;
			}
		}
		if (NameGens.TryGetValue(name, out value))
		{
			return value;
		}
		throw new UnityException("Failed locating random name generator: " + name);
	}

	public static Dictionary<string, RandomNameGenerator> GetRandomNameGenerators()
	{
		Dictionary<string, RandomNameGenerator> dictionary = new Dictionary<string, RandomNameGenerator>(NameGens);
		foreach (ModPackage item in ModPackages.Where((ModPackage mod) => mod.Enabled))
		{
			foreach (KeyValuePair<string, RandomNameGenerator> nameGenerator in item.NameGenerators)
			{
				dictionary[nameGenerator.Key] = nameGenerator.Value;
			}
		}
		return dictionary;
	}

	public static RandomNameGenerator GetStaticRandomNameGenerator(string name)
	{
		return NameGens[name];
	}

	public static Dictionary<string, RandomNameGenerator> GetRandomNameGenerators(Dictionary<string, RandomNameGenerator> include)
	{
		Dictionary<string, RandomNameGenerator> dictionary = new Dictionary<string, RandomNameGenerator>(NameGens);
		foreach (KeyValuePair<string, RandomNameGenerator> item in include)
		{
			dictionary[item.Key] = item.Value;
		}
		return dictionary;
	}

	private static void LoadNames(string modDir)
	{
		FemaleNames = LoadEmployeeNames(modDir, "femalefirstnames", "Jane");
		MaleNames = LoadEmployeeNames(modDir, "malefirstnames", "John");
		LastNames = LoadEmployeeNames(modDir, "lastnames", "Doe");
		FemaleLastNames = LoadEmployeeNames(modDir, "femalelastnames", null, true);
	}

	private static string[] LoadEmployeeNames(string modDir, string assetName, string defName, bool allowNull = false)
	{
		try
		{
			string path = Path.Combine(modDir, assetName + ".txt");
			if (!File.Exists(path))
			{
				if (allowNull)
				{
					return null;
				}
				string contents = LoadFullTextAsset(assetName);
				File.WriteAllText(path, contents);
			}
			string[] array = File.ReadAllLines(path);
			if (array.Length == 0)
			{
				if (allowNull)
				{
					return null;
				}
				array = new string[1] { defName };
			}
			return array;
		}
		catch (Exception)
		{
			if (allowNull)
			{
				return null;
			}
			return LoadTextAsset(assetName);
		}
	}

	public static void ReloadSoftware()
	{
		NameGens.Clear();
		SoftwareTypes.Clear();
		foreach (KeyValuePair<string, string[]> item in LoadAllTextAssetsWithName("NameGenerators"))
		{
			NameGens.Add(item.Key, RandomNameGenerator.Load(item.Value));
		}
		string[] array = LoadAllTextAssetsNoSplit("SoftwareTypes", "base");
		for (int i = 0; i < array.Length; i++)
		{
			SoftwareType softwareType = new SoftwareType(TydFromText.ParseOne(array[i]) as TydCollection, null, null);
			SoftwareTypes.Add(softwareType.Name, softwareType);
		}
	}

	private static void LoadStaticData()
	{
		Debug.Log("Loading Random Name Generators");
		foreach (KeyValuePair<string, string[]> item in LoadAllTextAssetsWithName("NameGenerators"))
		{
			NameGens.Add(item.Key, RandomNameGenerator.Load(item.Value));
		}
		Debug.Log("Loading Sentence Generators");
		foreach (KeyValuePair<string, string[]> item2 in LoadAllTextAssetsWithName("SentenceGenerator"))
		{
			SentenceGenerator value = new SentenceGenerator(item2.Key, item2.Value);
			SentenceGen[item2.Key] = value;
		}
		Debug.Log("Loading mood effects");
		LoadMoodEffects();
		Debug.Log("Loading Software Types");
		string[] array = LoadAllTextAssetsNoSplit("SoftwareTypes", "base");
		for (int i = 0; i < array.Length; i++)
		{
			SoftwareType softwareType = new SoftwareType(TydFromText.ParseOne(array[i]) as TydCollection, null, null);
			SoftwareTypes.Add(softwareType.Name, softwareType);
		}
		DigitalDistributionPlatform = new SoftwareType(TydFromText.ParseOne(LoadFullTextAsset("DistributionPlatform")) as TydCollection, null, null);
		DigitalDistributionPlatform.UpdateID(1u);
		Debug.Log("Loading Company Types");
		array = LoadAllTextAssetsNoSplit("CompanyTypes");
		for (int i = 0; i < array.Length; i++)
		{
			CompanyType companyType = new CompanyType(TydFromText.ParseOne(array[i]) as TydCollection);
			CompanyTypes.Add(companyType.Name, companyType);
		}
		Personalities = new PersonalityGraph(TydFromText.ParseOne(LoadFullTextAsset("Personalities")) as TydCollection);
		Debug.Log("Loading Reward Tasks");
		foreach (TydTable item3 in TydFromText.Parse(LoadFullTextAsset("Tasks")).OfType<TydTable>())
		{
			Tasks.Add(new RewardTask(item3));
		}
	}

	private static bool CheckComplete(string task, HashSet<string> completed, HashSet<string> altCompleted)
	{
		if (altCompleted == null || !altCompleted.Contains(task))
		{
			return completed.Contains(task);
		}
		return true;
	}

	public static string CheckTasks(HashSet<string> completed, HashSet<string> altCompleted, Dictionary<string, int> taskProgress, ref int offset, ref int subOffset)
	{
		string result = null;
		RewardTask rewardTask = Tasks[offset];
		if (!CheckComplete(rewardTask.Name, completed, altCompleted) && (rewardTask.DependsOn == null || CheckComplete(rewardTask.DependsOn, completed, altCompleted)))
		{
			RewardTask.Goal goal = rewardTask.Goals[subOffset];
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			object obj = LineParse.Execute(goal.Eval, ScriptSystem.TaskScope.Scope);
			realtimeSinceStartup = Time.realtimeSinceStartup - realtimeSinceStartup;
			float value;
			if (!TaskTime.TryGetValue(goal.IDName, out value) || value < realtimeSinceStartup)
			{
				TaskTime[goal.IDName] = realtimeSinceStartup;
			}
			if (goal.IsCountable)
			{
				int value2;
				try
				{
					value2 = Convert.ToInt32(obj);
				}
				catch (Exception)
				{
					value2 = ((Convert.ToDouble(obj) > 0.0) ? int.MaxValue : int.MinValue);
				}
				taskProgress[goal.IDName] = value2;
			}
			else if (goal.IsAmount)
			{
				float num = (float)Convert.ToDouble(obj);
				taskProgress[goal.IDName] = Mathf.FloorToInt(num * 1000f);
			}
			else
			{
				bool flag = (bool)obj;
				taskProgress[goal.IDName] = (flag ? 1 : 0);
			}
			if (subOffset == rewardTask.Goals.Length - 1)
			{
				subOffset = 0;
				offset = (offset + 1) % Tasks.Count;
				bool flag2 = true;
				for (int i = 0; i < rewardTask.Goals.Length; i++)
				{
					RewardTask.Goal goal2 = rewardTask.Goals[i];
					if (goal2.IsCountable)
					{
						if (taskProgress.GetOrDefault(goal2.IDName, 0) < goal2.ReachGoal)
						{
							flag2 = false;
							break;
						}
					}
					else if (goal2.IsAmount)
					{
						if ((float)taskProgress.GetOrDefault(goal2.IDName, 0) / 1000f < goal2.FloatGoal)
						{
							flag2 = false;
							break;
						}
					}
					else if (taskProgress.GetOrDefault(goal2.IDName, 0) < 1)
					{
						flag2 = false;
						break;
					}
				}
				if (flag2)
				{
					result = rewardTask.Name;
				}
			}
			else
			{
				subOffset++;
			}
		}
		else
		{
			subOffset = 0;
			offset = (offset + 1) % Tasks.Count;
		}
		return result;
	}

	public static void LoadMoodEffects()
	{
		MoodEffects = TydFile.FromContent(LoadFullTextAsset("MoodEffects"), "MoodEffects.tyd").DocumentNode.Nodes.SelectInPlace((TydNode x) => new MoodEffect(x as TydTable)).ToDictionary((MoodEffect x) => x.Thought, (MoodEffect x) => x);
	}

	public static IWorkshopItem LoadSteamMod(string path, string name)
	{
		try
		{
			ModPackage modPackage = ModPackage.Load(path);
			ModPackages.Add(modPackage);
			return modPackage;
		}
		catch (Exception ex)
		{
			string text = "Error loading mod " + name + ":\n" + ex.ToString();
			Debug.Log(text);
			DevConsole.Console.LogError(text);
			return new FailMod("Data mod", path, name, ex.ToString());
		}
	}

	private static void LoadMods(string modFolder)
	{
		string[] directories = Directory.GetDirectories(modFolder);
		foreach (string text in directories)
		{
			try
			{
				ModPackages.Add(ModPackage.Load(text));
			}
			catch (Exception ex)
			{
				new FailMod("Data mod", text, ex.ToString());
				LoadDebugger.AddError("Failed loading mod: " + Path.GetFileName(text));
				if (DevConsole.Console.Singleton != null)
				{
					DevConsole.Console.LogError("Error loading mod " + Path.GetFileName(text) + ":\n" + ex.Message);
				}
			}
		}
	}

	private static void LoadCurrencies(string modFolder)
	{
		XMLParser.XMLNode xMLNode = null;
		try
		{
			string path = Path.Combine(modFolder, "Currencies.xml");
			if (!File.Exists(path))
			{
				string contents = LoadFullTextAsset("Currencies");
				File.WriteAllText(path, contents);
			}
			xMLNode = XMLParser.ParseXML(File.ReadAllText(path));
		}
		catch (Exception ex)
		{
			try
			{
				xMLNode = XMLParser.ParseXML(LoadFullTextAsset("Currencies"));
				DevConsole.Console.LogError(ex.ToString());
				Debug.Log(ex.ToString());
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
		if (xMLNode == null)
		{
			return;
		}
		try
		{
			XMLParser.XMLNode[] nodes = xMLNode.GetNodes("Currency");
			foreach (XMLParser.XMLNode xMLNode2 in nodes)
			{
				XMLParser.XMLNode node = xMLNode2.GetNode("Name", false);
				if (node != null)
				{
					CurrencyRates[node.Value] = new Currency(xMLNode2);
				}
			}
		}
		catch (Exception ex2)
		{
			DevConsole.Console.LogError(ex2.ToString());
			Debug.Log(ex2.ToString());
		}
	}

	public static string[][] LoadAllTextAssets(string path)
	{
		return Resources.LoadAll<TextAsset>(path).SelectInPlace((TextAsset x) => x.text.SplitByNewLines());
	}

	public static string[] LoadAllTextAssetsNoSplit(string path, string exclude = "")
	{
		return Resources.LoadAll<TextAsset>(path).WhereSelect((TextAsset x) => !x.name.ToLower().Equals(exclude), (TextAsset x) => x.text).ToArray();
	}

	public static Dictionary<string, string> LoadAllTextAssetsWithNameNoSplit(string path)
	{
		return Resources.LoadAll<TextAsset>(path).ToDictionary((TextAsset x) => x.name, (TextAsset x) => x.text);
	}

	public static Dictionary<string, string[]> LoadAllTextAssetsWithName(string path, bool removeEmpty = true)
	{
		return Resources.LoadAll<TextAsset>(path).ToDictionary((TextAsset x) => x.name, (TextAsset x) => x.text.SplitByNewLines(removeEmpty ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None));
	}

	public static string LoadFullTextAsset(string assetName)
	{
		return (Resources.Load(assetName) as TextAsset).text;
	}

	public static string[] LoadTextAsset(string assetName)
	{
		return LoadFullTextAsset(assetName).SplitByNewLines();
	}

	private static string CheckManufacturing(IManufacturable m, string swName, Func<string, FeatureBase> getFeat, params string[] cats)
	{
		if (m.IsHardware())
		{
			bool flag = false;
			HardwareComponent[] components = m.GetManufacturing().Components;
			foreach (HardwareComponent hardwareComponent in components)
			{
				if (hardwareComponent.DependsOn != null)
				{
					FeatureBase f = getFeat(hardwareComponent.DependsOn);
					if (f == null)
					{
						return "Component: " + hardwareComponent.Name + " in hardware " + m.GetActualName() + " in software " + swName + " depends on a feature that doesn't exist";
					}
					if (cats.Any((string x) => !f.IsCompatible(x)))
					{
						return "Component: " + hardwareComponent.Name + " in hardware " + m.GetActualName() + " in software " + swName + " depends on a feature that has an incompatible category";
					}
				}
				else
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return "Hardware: " + m.GetActualName() + " in software " + swName + " needs at least one hardware component that doesn't have any dependencies";
			}
		}
		return null;
	}

	public static string CheckForErrors(IEnumerable<SoftwareType> types)
	{
		return CheckForErrors(types.ToArray());
	}

	public static string CheckForErrors(SoftwareType[] types)
	{
		try
		{
			SoftwareType softwareType = types.FirstOrDefault((SoftwareType x) => x.Name.Equals("Operating System"));
			if (softwareType == null)
			{
				return "Missing operating system software type";
			}
			foreach (SoftwareType softwareType2 in types)
			{
				if (softwareType2.OptimalDevTime <= 0f)
				{
					return softwareType2.Name + " has to have an optimal dev time above 0";
				}
				if (softwareType2.Features.None((KeyValuePair<string, FeatureBase> x) => x.Value.IsForced(null) && (!x.Value.Unlock.HasValue || x.Value.Unlock.Value == 0)))
				{
					return softwareType2.Name + " does not have any forced features. All software types should have at least one forced feature without an unlock date";
				}
				foreach (string oSLimit in softwareType2.GetOSLimits())
				{
					if (!softwareType.Categories.ContainsKey(oSLimit))
					{
						return softwareType2.Name + " has been limited to the operating system category: " + oSLimit + ", which does not exist";
					}
				}
			}
			Dictionary<string, SoftwareType> dictionary = types.ToDictionary((SoftwareType x) => x.Name, (SoftwareType x) => x);
			Dictionary<string, SpecFeature> dictionary2 = new Dictionary<string, SpecFeature>();
			HashSet<string> addonCats = new HashSet<string>();
			foreach (SoftwareType sw in dictionary.Values)
			{
				if (sw.OSSpecific)
				{
					foreach (string oSLimit2 in sw.GetOSLimits())
					{
						if (!softwareType.Categories.ContainsKey(oSLimit2))
						{
							return "Software " + sw.Name + " supports non-existent operating system category: " + oSLimit2;
						}
					}
				}
				foreach (SoftwareCategory value in sw.Categories.Values)
				{
					string text = CheckManufacturing(value, sw.Name, (string x) => sw.Features.GetOrNull(x), value.Name);
					if (text != null)
					{
						return text;
					}
					if (Mathf.Approximately(value.TimeScale, 0f))
					{
						return "Category: " + value.Name + " in software " + sw.Name + " has zero timescale";
					}
				}
				dictionary2.Clear();
				foreach (FeatureBase value2 in sw.Features.Values)
				{
					if (Mathf.Approximately(value2.DevTime, 0f))
					{
						return "Feature: " + value2.Name + " in software " + sw.Name + " has zero devtime";
					}
					if (value2.SoftwareCategories != null)
					{
						string text2 = (from x in value2.SoftwareCategories
							where !sw.Categories.ContainsKey(x.Key)
							select x.Key).FirstOrDefault();
						if (text2 != null)
						{
							return "Feature: " + value2.Name + " in software " + sw.Name + " depends on non-existent software category " + text2;
						}
					}
					SpecFeature specF = value2 as SpecFeature;
					if (specF != null)
					{
						if (dictionary2.ContainsKey(specF.Spec))
						{
							return "Main feature: " + value2.Name + " in software " + sw.Name + " is using a previously used specialization: " + value2.Spec;
						}
						dictionary2.Add(value2.Spec, specF);
					}
					if (specF == null)
					{
						continue;
					}
					if (sw.OSSpecific)
					{
						SpecFeature specFeature = softwareType.Features.Values.OfType<SpecFeature>().FirstOrDefault((SpecFeature x) => x.Spec.Equals(specF.Spec));
						if (specFeature == null)
						{
							return "Software " + sw.Name + " uses the " + value2.Spec + " spec, but it is never supported by any operating systems";
						}
						if (specFeature.SoftwareCategories != null)
						{
							foreach (string item in sw.HasOSLimits() ? sw.GetOSLimits() : softwareType.Categories.Keys.AsEnumerable())
							{
								if (!specFeature.SoftwareCategories.ContainsKey(item))
								{
									return "Software " + sw.Name + " uses the " + value2.Spec + " spec, but it is never supported by any " + item + " operating system";
								}
							}
						}
					}
					string[] dependencies = specF.Dependencies;
					foreach (string text3 in dependencies)
					{
						string text4 = sw.Name + " -> " + value2.Name;
						string text5 = "Found dependency from " + text4 + " to " + text3;
						if (text3.Equals(sw.Name))
						{
							return text5 + ", but a feature cannot depend on it's own software type";
						}
						if (text3.Equals("Operating System"))
						{
							return text5 + ", but a single feature cannot depend on an OS, the entire software type has to instead";
						}
						if (!dictionary.ContainsKey(text3))
						{
							return text5 + ", but " + text3 + " doesn't exist";
						}
					}
				}
				foreach (SubFeature item2 in sw.Features.Values.OfType<SubFeature>())
				{
					if (!dictionary2.ContainsKey(item2.Spec))
					{
						return sw.Name + " contains sub feature: " + item2.Name + ", but no parent feature with same specialization: " + item2.Spec;
					}
				}
				foreach (SoftwareAddOn addon in sw.AddOns.Values)
				{
					string text6 = CheckManufacturing(addon, sw.Name, (string x) => addon.Features.GetOrNull(x), addon.Categories);
					if (text6 != null)
					{
						return text6;
					}
					if (addon.BaseFeature != null && !dictionary2.ContainsKey(addon.BaseFeature.Spec))
					{
						return "Base feature in software addon " + sw.Name + ": " + addon.Name + " is using spec " + addon.BaseFeature.Spec + " not supported by parent SoftwareType";
					}
					addonCats.Clear();
					addonCats.AddRange(addon.Categories);
					foreach (AddOnFeature feature in addon.Features.Values)
					{
						if (!dictionary2.ContainsKey(feature.Spec))
						{
							return "Feature: " + feature.Name + " in software addon " + sw.Name + ": " + addon.Name + " is using spec " + feature.Spec + " not supported by parent SoftwareType";
						}
						if (feature.SoftwareCategories != null && feature.SoftwareCategories.Keys.Any((string x) => !addonCats.Contains(x)))
						{
							return "Feature: " + feature.Name + " in software addon " + sw.Name + ": " + addon.Name + " depends on category that is not supported by add on";
						}
						if (feature.FeatureDependency != null)
						{
							FeatureBase f;
							if (!sw.Features.TryGetValue(feature.FeatureDependency, out f))
							{
								return "Feature: " + feature.Name + " in software addon " + sw.Name + ": " + addon.Name + " depends on parent feature that doesn't exist";
							}
							if (addonCats.Any((string x) => feature.IsCompatible(x) && !f.IsCompatible(x)))
							{
								return "Feature: " + feature.Name + " in software addon " + sw.Name + ": " + addon.Name + " depends on parent feature that is not compatible with addon categories";
							}
						}
					}
					if (addon.BaseFeature == null && addon.Features.Values.All((AddOnFeature x) => x.FeatureDependency != null || (x.Unlock.HasValue && (!addon.Unlock.HasValue || x.Unlock.Value > addon.Unlock.Value))))
					{
						return "Addon: " + addon.Name + " in software:" + sw.Name + " can have 0 possible features available to select. It should have atleast 1 or a base feature defined";
					}
					if (!addon.Forced.HasValue)
					{
						continue;
					}
					if (addon.BaseFeature != null && (!dictionary2[addon.BaseFeature.Spec].Forced || dictionary2[addon.BaseFeature.Spec].Unlock.HasValue))
					{
						return "Addon: " + addon.Name + " in software:" + sw.Name + " is forced, but base feature relies on specialization that is not forced in software type";
					}
					if (addon.BaseFeature != null)
					{
						continue;
					}
					bool flag = false;
					foreach (AddOnFeature value3 in addon.Features.Values)
					{
						SpecFeature specFeature2 = dictionary2[value3.Spec];
						if (specFeature2.Forced && !specFeature2.Unlock.HasValue)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						return "Addon: " + addon.Name + " in software:" + sw.Name + " is forced, but all features rely on specializations that are not forced in software type";
					}
				}
			}
			return null;
		}
		catch (Exception ex)
		{
			return "Error checking for software type errors: " + ex.ToString();
		}
	}

	public static float GetProjectEffectiveness(int employees, int devTime)
	{
		if (employees == 0 || devTime == 0)
		{
			return 1f;
		}
		if (employees - 1 < CachedEffectiveness.GetLength(1) && devTime - 1 < CachedEffectiveness.GetLength(0))
		{
			return CachedEffectiveness[devTime - 1, employees - 1];
		}
		return CalculateProjectEffectiveness(employees, devTime);
	}

	public static float ProjectDevTime(int designEmployees, int devEmployees, float devTime, float artRatio)
	{
		float projectEffectiveness = GetProjectEffectiveness(designEmployees, Mathf.Max(1, Mathf.RoundToInt(devTime * SoftwareType.DesignRatio * artRatio)));
		float projectEffectiveness2 = GetProjectEffectiveness(devEmployees, Mathf.Max(1, Mathf.RoundToInt(devTime * (1f - SoftwareType.DesignRatio))));
		return devTime * SoftwareType.DesignRatio / (projectEffectiveness * (float)designEmployees) + devTime * (1f - SoftwareType.DesignRatio) / (projectEffectiveness2 * (float)devEmployees);
	}

	public static float ProjectDevTime(int designEmployees, int devEmployees, int actualDesignEmployees, int actualDevEmployees, float devTime, float artRatio)
	{
		float projectEffectiveness = GetProjectEffectiveness(designEmployees, Mathf.Max(1, Mathf.RoundToInt(devTime * SoftwareType.DesignRatio * artRatio)));
		float projectEffectiveness2 = GetProjectEffectiveness(devEmployees, Mathf.Max(1, Mathf.RoundToInt(devTime * (1f - SoftwareType.DesignRatio))));
		return devTime * SoftwareType.DesignRatio / (projectEffectiveness * (float)actualDesignEmployees) + devTime * (1f - SoftwareType.DesignRatio) / (projectEffectiveness2 * (float)actualDevEmployees);
	}

	public static float ProjectDevTimeGeneric(int workers, int devTime)
	{
		float projectEffectiveness = GetProjectEffectiveness(workers, devTime);
		return (float)devTime / (projectEffectiveness * (float)workers);
	}

	public static float ProjectDevTimeGeneric(int devTime)
	{
		int optimalEmployees = GetOptimalEmployees(devTime);
		float projectEffectiveness = GetProjectEffectiveness(optimalEmployees, devTime);
		return (float)devTime / (projectEffectiveness * (float)optimalEmployees);
	}

	public static int GetOptimalEmployees(int devTime)
	{
		if (devTime <= 0)
		{
			return 0;
		}
		if (devTime - 1 < OptimalEmployees.Length)
		{
			return OptimalEmployees[devTime - 1];
		}
		return CalculateOptimalEmployee(devTime);
	}

	public static float GetMaxDevTime(int employees)
	{
		return (float)employees * 4f;
	}

	private static void CacheEffectivenessStats()
	{
		OptimalEmployees = new int[CachedEffectiveness.GetLength(0)];
		for (int i = 0; i < CachedEffectiveness.GetLength(0); i++)
		{
			OptimalEmployees[i] = CalculateOptimalEmployee(i + 1);
			for (int j = 0; j < CachedEffectiveness.GetLength(1); j++)
			{
				CachedEffectiveness[i, j] = CalculateProjectEffectiveness(j + 1, i + 1);
			}
		}
	}

	private static int CalculateOptimalEmployee(int devTime)
	{
		return Mathf.RoundToInt((float)devTime / 4f + 1f);
	}

	private static float CalculateProjectEffectiveness(int employees, int devTime)
	{
		if (employees == 0)
		{
			return 0f;
		}
		float num = 1f;
		if (devTime >= 16)
		{
			int num2 = 2 + (devTime - 16) / 8;
			if (employees <= num2)
			{
				num = devTime.MapRange(16f, 32f, 1f, 0f, true);
				num *= num;
				num = Mathf.Lerp(0.05f * (float)num2, 1f, num);
			}
		}
		return num * (1f / (float)employees) * (1f + (1f - 1f / Mathf.Pow((float)employees / 20f + 0.95f, 100f / (float)devTime)) * Mathf.Pow(devTime, 0.15f));
	}
}
