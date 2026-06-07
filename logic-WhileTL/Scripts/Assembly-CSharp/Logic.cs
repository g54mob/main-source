using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using App.Data;
using Aux;
using DeepTraffic;
using Localization;
using Newtonsoft.Json;
using ReinforcementLearning.Environment;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Logic : ActiveComponent
{
	public struct OldSaveHeader
	{
		public string m;

		public int v;
	}

	public struct SaveHeader
	{
		public string m;

		public int v;

		public DateTime date;
	}

	public class BoolConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(((bool)value) ? 1 : 0);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return string.Equals(reader.Value.ToString(), "1");
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(bool);
		}
	}

	public class FloatConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue((float)value);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			float result = 0f;
			float.TryParse(reader.Value.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out result);
			return result;
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(float);
		}
	}

	public class IntConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue((int)value);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			int result = 0;
			int.TryParse(reader.Value.ToString(), out result);
			return result;
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(int);
		}
	}

	public enum KeyColor
	{
		RED = 0,
		GREEN = 1,
		BLUE = 2,
		WHITE = 3,
		BASICACTIVE = 4,
		MEMORYACTIVE = 5,
		BASICDEACTIVE = 6,
		MEMORYDEACTIVE = 7,
		NORMAL = 8,
		BIGERROR = 9,
		LOWERROR = 10,
		TIME = 11,
		ERRORTEXT = 12,
		TIMETEXT = 13,
		ACCURACY = 14,
		OCCUPANCY = 15,
		MONEY = 16,
		MONEYTEXT = 17,
		SERVERSTEXT = 18,
		SERVERS = 19,
		BAD = 20,
		GOOD = 21,
		WARNING = 22,
		GREY = 23,
		GRAYUNDERBLOCK = 24,
		NEWS = 25,
		BLACK = 26,
		SETTINGSGREY = 27,
		DARKGREEN = 28,
		DARKGREY = 29,
		GRAYTEXT = 30,
		LAYER = 31,
		DISCORDSH = 32,
		PRIMARYFONT = 33,
		MAX_COLORS = 34
	}

	public static UnityEvent staticDataLoadedEvent = new UnityEvent();

	public static bool staticDataLoaded = false;

	public static CreateProject _createProject;

	private static JsonSerializerSettings settings = null;

	private static AchivementBlockInstancer smallAchivementPrefab;

	public static AchivementPopupController achivementPopupController;

	private static Dictionary<string, Font> fonts = new Dictionary<string, Font>();

	private static GameObject urlCopied = null;

	private static List<Color> colors = null;

	public static Dictionary<int, BaseQuest> baseQuests = new Dictionary<int, BaseQuest>();

	private static List<string[]> replaceOldHashes = new List<string[]>
	{
		new string[2] { "flower2", "-765800137" },
		new string[2] { "flower1", "-765800138" },
		new string[2] { "WH", "2769" },
		new string[2] { "hair2", "99040400" },
		new string[2] { "BACKPROPAGANDA", "1261554650" },
		new string[2] { "smartphone2", "328518541" },
		new string[2] { "blackPlayer", "325639104" },
		new string[2] { "flower3", "-765800136" },
		new string[2] { "flower4", "-765800135" },
		new string[2] { "room2", "108698295" },
		new string[2] { "room3", "108698296" },
		new string[2] { "chair2", "-1361640947" },
		new string[2] { "mouse2", "-1068279763" },
		new string[2] { "DOOM", "2104233" },
		new string[2] { "hair3", "99040401" },
		new string[2] { "hair4", "99040402" },
		new string[2] { "smartphone3", "328518542" },
		new string[2] { "bluePlayer", "-128021541" },
		new string[2] { "chair3", "-1361640946" },
		new string[2] { "mouse3", "-1068279762" },
		new string[2] { "greenPlayer", "1965017028" },
		new string[2] { "'RANDOMFOREST'", "-1992963424" },
		new string[2] { "'ISOFOREST'", "-997962558" },
		new string[2] { "'SGRADIENT'", "1177412739" },
		new string[2] { ":0", ":-1519515031" },
		new string[2] { ":0", ":-1519515030" },
		new string[2] { ":0", ":-1519515029" },
		new string[2] { ":0", ":-1519515028" },
		new string[2] { ":0", ":-1519515027" },
		new string[2] { ":0", ":-1519515026" },
		new string[2] { "SANDBOX0", "-1519515031" },
		new string[2] { "SANDBOX1", "-1519515030" },
		new string[2] { "SANDBOX2", "-1519515029" },
		new string[2] { "SANDBOX3", "-1519515028" },
		new string[2] { "SANDBOX4", "-1519515027" },
		new string[2] { "SANDBOX5", "-1519515026" },
		new string[2] { "80894", "RAM" }
	};

	private static List<string[]> replaceOldUpgradesHashes = new List<string[]>
	{
		new string[2] { "80894", "RAM" },
		new string[2] { "-596015761", "TIMBREL" },
		new string[2] { "-1852497085", "SERVER" },
		new string[2] { "-1592834737", "SERVER2" },
		new string[2] { "-1871803575", "ROUTER" },
		new string[2] { "-1296619357", "TIMBREL2" },
		new string[2] { "2103631369", "ROUTER2" },
		new string[2] { "-1592834735", "SERVER4" },
		new string[2] { "2103631370", "ROUTER3" },
		new string[2] { "-1296619356", "TIMBREL3" },
		new string[2] { "2103631371", "ROUTER4" }
	};

	private static List<string[]> replaceQuestHashes = new List<string[]>
	{
		new string[2] { "R/B DIVIDE", "1428293428" },
		new string[2] { "G/B DIVIDE", "-705025313" },
		new string[2] { "WITHOUT BLUE", "504771794" },
		new string[2] { "ONLY RED", "-1287050755" },
		new string[2] { "ONLY RED FAST", "-1700377441" },
		new string[2] { "DSTREE_SCHEME", "486434167" },
		new string[2] { "ONLY RED FAST1", "-1172093070" },
		new string[2] { "ONLY TRIANGLE", "611755004" },
		new string[2] { "ONLY TRIANGLE1", "1784535989" },
		new string[2] { "ONLY RED FAST2", "-1172093069" },
		new string[2] { "FIRST PERCEPTRON", "65966590" },
		new string[2] { "FIRST PERCEPTRON1", "2044964339" },
		new string[2] { "FIRST PERCEPTRON-2", "-1030615005" },
		new string[2] { "FIRST PERCEPTRON3", "2044964341" },
		new string[2] { "FIRST PERCEPTRON2", "2044964340" },
		new string[2] { "FIRST PERCEPTRON21", "-1030614851" },
		new string[2] { "R/R PARALLEL", "158335986" },
		new string[2] { "ALL/G DIVIDE", "-892383424" },
		new string[2] { "R/R PARALLEL1", "613448319" },
		new string[2] { "R/R PARALLEL2", "613448320" },
		new string[2] { "R/R/R/R PARALLEL", "-326476308" },
		new string[2] { "R/R/R/R PARALLEL1", "-1530830907" },
		new string[2] { "R/R/R/R PARALLEL2", "-1530830906" },
		new string[2] { "R/R/R/R PARALLEL3", "-1530830905" },
		new string[2] { "ONLY R PARALLEL", "-518768887" },
		new string[2] { "ONLY R PARALLEL1", "1098033736" },
		new string[2] { "ONLY R PARALLEL2", "1098033737" },
		new string[2] { "ONLY R/R PARALLEL", "-1410559002" },
		new string[2] { "ONLY R/R PARALLEL1", "-777656053" },
		new string[2] { "ONLY R/R PARALLEL2", "-777656052" },
		new string[2] { "ONLY R/R PARALLEL3", "-777656051" },
		new string[2] { "WB/WG DIVIDE", "562303365" },
		new string[2] { "R/G/B SORT", "1884858017" },
		new string[2] { "R/G/B QUICK SORT", "1179120340" },
		new string[2] { "R/G/B SORT1", "-1698943568" },
		new string[2] { "R/G/B SORT2", "-1698943567" },
		new string[2] { "R/G/B SORT3", "-1698943566" },
		new string[2] { "R/G DIVIDE 50%", "-2144673575" },
		new string[2] { "R/G DIVIDE 50%1", "-2060371336" },
		new string[2] { "R/G DIVIDE 50%2", "-2060371335" },
		new string[2] { "R/G DIVIDE 50%3", "-2060371334" },
		new string[2] { "R/G DIVIDE 50%4", "-2060371333" },
		new string[2] { "R/G DIVIDE 50%5", "-2060371332" },
		new string[2] { "R/G DIVIDE 75%", "-2144671498" },
		new string[2] { "R/G DIVIDE 75%1", "-2060306949" },
		new string[2] { "R/G DIVIDE 75%2", "-2060306948" },
		new string[2] { "R/G DIVIDE 75%3", "-2060306947" },
		new string[2] { "R/G DIVIDE 75%4", "-2060306946" },
		new string[2] { "SHAPE%", "-1850238780" },
		new string[2] { "ANYSORTER", "1109949335" },
		new string[2] { "ONLY BLUE 80%", "-1378256549" },
		new string[2] { "ONLY BLUE 80%1", "223719990" },
		new string[2] { "ONLY RED CIRCLE", "-2053691309" },
		new string[2] { "PRETRAINED GENETIC", "1612217789" },
		new string[2] { "GENETIC DIVIDE", "471963968" },
		new string[2] { "GENETIC DIVIDE1", "1745981169" },
		new string[2] { "GENETIC DIVIDE2", "1745981170" },
		new string[2] { "GENETIC DIVIDE3", "1745981171" },
		new string[2] { "GENETIC DIVIDE4", "1745981172" },
		new string[2] { "GENETIC DIVIDE5", "1745981173" },
		new string[2] { "GENETIC DIVIDE6", "1745981174" },
		new string[2] { "GENETIC DIVIDE 2", "-1709159086" },
		new string[2] { "C/T DIVIDE", "1386843665" },
		new string[2] { "RC 75%", "-1884493160" },
		new string[2] { "ONLY SQUARE", "-1315707887" },
		new string[2] { "C/T DIVIDE1", "42480704" },
		new string[2] { "C/T DIVIDE2", "42480705" },
		new string[2] { "ONLY SQUARE 60%", "1040240668" },
		new string[2] { "ONLY SQUARE 60%1", "-2112277611" },
		new string[2] { "ONLY SQUARE 60%2", "-2112277610" },
		new string[2] { "ONLY SQUARE 60%3", "-2112277609" },
		new string[2] { "C/S/T SORT", "491805554" },
		new string[2] { "C/S/T SORT1", "-1933896961" },
		new string[2] { "C/S/T SORT2", "-1933896960" },
		new string[2] { "C/S/T SORT3", "-1933896959" },
		new string[2] { "C/S/T SORT4", "-1933896958" },
		new string[2] { "RC/BT DIVIDE", "-1396525655" },
		new string[2] { "C/S/T QUICK SORT", "798951141" },
		new string[2] { "C/S/T MACHINE SORT", "-971741237" },
		new string[2] { "R/G/B MACHINE SORT", "-701361158" },
		new string[2] { "R/G/B MACHINE SORT1", "-267359369" },
		new string[2] { "R/G/B MACHINE SORT2", "-267359368" },
		new string[2] { "R/G/B MACHINE SORT3", "-267359367" },
		new string[2] { "R/G/B MACHINE SORT4", "-267359366" },
		new string[2] { "R/G/B MACHINE SORT5", "-267359365" },
		new string[2] { "R/G/B MACHINE SORT6", "-267359364" },
		new string[2] { "ACC R MACHINE", "-371600038" },
		new string[2] { "ACC R MACHINE1", "1365300759" },
		new string[2] { "ACC R MACHINE2", "1365300760" },
		new string[2] { "ACC R MACHINE3", "1365300761" },
		new string[2] { "ACC R MACHINE4", "1365300762" },
		new string[2] { "MACHINE SORT", "-168030729" },
		new string[2] { "FAST GREEN MACHINE", "816964390" },
		new string[2] { "MACHINE SORT1", "-913985254" },
		new string[2] { "MACHINE SORT2", "-913985253" },
		new string[2] { "MACHINE SORT3", "-913985252" },
		new string[2] { "MACHINE SORT4", "-913985251" },
		new string[2] { "COPY TEXT", "-31332616" },
		new string[2] { "COPY TEXT1", "-971311047" },
		new string[2] { "COPY TEXT2", "-971311046" },
		new string[2] { "FAST TEXT COPY1", "-862373651" },
		new string[2] { "FAST TEXT COPY", "-1690386492" },
		new string[2] { "RNNCOLOR", "-315251471" },
		new string[2] { "RNNCOLOR1", "-1182860960" },
		new string[2] { "RNNCOLOR2", "-1182860959" },
		new string[2] { "RNNCOLOR3", "-1182860958" },
		new string[2] { "RNNMULTI", "-305837369" },
		new string[2] { "ARMASTARTUP", "-1072679624" },
		new string[2] { "PERCEPTRONSTARTUP", "-745535441" },
		new string[2] { "ATARI", "62596389" },
		new string[2] { "TRAFFICFINDER", "-774537149" },
		new string[2] { "EXTRABIGACC", "-357386383" },
		new string[2] { "EVOLVER", "-649341323" },
		new string[2] { "AMAZON", "1934031364" },
		new string[2] { "INSURER", "-1619368744" },
		new string[2] { "ELITECLUB", "1983195561" },
		new string[2] { "COURSES", "1675931544" },
		new string[2] { "HEALTH", "2127033948" },
		new string[2] { "ITEMS", "69988256" },
		new string[2] { "SOMEBODYS", "-2089677187" },
		new string[2] { "NON_ML_CAR", "-11880730" },
		new string[2] { "GENETIC_CAR0", "1274276418" },
		new string[2] { "GENETIC_CAR1", "1274276419" },
		new string[2] { "GENETIC_CAR2", "1274276420" },
		new string[2] { "GENETIC_CAR3", "1274276421" },
		new string[2] { "DQN_CAR0", "-551758054" },
		new string[2] { "DQN_CAR1", "-551758053" },
		new string[2] { "PARALLEL", "1954029063" },
		new string[2] { "DSTREE", "2026017965" },
		new string[2] { "DSSHAPE", "-1619177390" },
		new string[2] { "REMOVE", "-1881281404" },
		new string[2] { "IFCOLOR", "-1863362490" },
		new string[2] { "IFSHAPE", "-1848805244" },
		new string[2] { "RANDOMFOREST", "-1992963424" },
		new string[2] { "ISOFOREST", "-997962558" },
		new string[2] { "PERCEPTRONCOLOR", "-1611219563" },
		new string[2] { "PERCEPTRONSHAPE", "-1596662317" },
		new string[2] { "RNNCELL", "2068030964" },
		new string[2] { "GRADIENT", "872277808" },
		new string[2] { "SGRADIENT", "1177412739" },
		new string[2] { "LSTM", "2346560" },
		new string[2] { "ARMA", "2017669" },
		new string[2] { "GENCOPYBLOCKCOLOR", "-661160101" },
		new string[2] { "MULTIPLY", "1436456484" },
		new string[2] { "CONV", "2074420" },
		new string[2] { "ROSENBLATT", "2039716984" },
		new string[2] { "ISOBJECT", "1349425385" },
		new string[2] { "ISCAR", "69956170" },
		new string[2] { "EXPERT_LEARN", "-688139313" },
		new string[2] { "FORUM_START_WORK", "1163610860" },
		new string[2] { "DSTREE_LEARN", "-544909294" },
		new string[2] { "ROSENBLATT_LEARN", "2110135197" },
		new string[2] { "ACCURACY_LEARN", "1481900894" },
		new string[2] { "GENETIC_LEARN", "856278942" },
		new string[2] { "PERCEPTRON_LEARN", "-1904542445" },
		new string[2] { "RNN_LEARN", "-384237257" },
		new string[2] { "STARTC", "-1839154111" },
		new string[2] { "ANTIQC", "1935504628" },
		new string[2] { "BASICC", "1952097781" },
		new string[2] { "GENETICC", "-1701901782" },
		new string[2] { "NEURALC", "-1732738460" },
		new string[2] { "DEEPLC", "2012640099" },
		new string[2] { "FINISHC", "-135032304" }
	};

	private static float sliderMultSpeed = -3f;

	private static Navigation customNav = default(Navigation);

	public static Dropdown openedDropdown = null;

	public static GameObject openedCanvas = null;

	public static GameObject currentBlocker = null;

	private static Thread saveThread = null;

	private static bool restartSave = false;

	private static bool saveCompleted = false;

	private static int saveFailed;

	private static int nintendoCommitCounter = 1;

	private static int nintendoCommitFreq = 4;

	public static bool ForceNoCloud = false;

	public static List<Text> bestFitsUpdte = new List<Text>();

	private static Dictionary<string, App.Data.Data> hashedDatas = new Dictionary<string, App.Data.Data>();

	private static Dictionary<string, int> colorKeyToColorId = new Dictionary<string, int>();

	private static Dictionary<int, string> immediatelyRunQuestPairs = null;

	private static Dictionary<string, Sprite> loadedSprites = new Dictionary<string, Sprite>();

	public static Dictionary<string, GameObject> loadedPrefabs = new Dictionary<string, GameObject>();

	public static Color goodColor = Color.white;

	public static Color badColor = Color.white;

	public static Dictionary<int, Color> percColors = new Dictionary<int, Color>();

	private static List<ConstructionBlock> trainableBlocks = null;

	public static Dictionary<int, ElementColor> cashedColors = null;

	private static DeepTrafficQuestController deepTrafficQuestController = null;

	public static List<Color> Colors
	{
		get
		{
			if (colors != null)
			{
				return colors;
			}
			colors = new List<Color>();
			for (int i = 1; i <= 3; i++)
			{
				colors.Add(GetColor("MEDALCOLOR" + i));
			}
			return colors;
		}
	}

	public static Color[] ColorsArray => Colors.ToArray();

	public static DeepTrafficQuestController DeepTrafficQuestController
	{
		get
		{
			if (!(deepTrafficQuestController == null))
			{
				_ = deepTrafficQuestController.gameObject.activeInHierarchy;
			}
			return deepTrafficQuestController;
		}
	}

	public static Construction Construction { get; private set; }

	public static GoogleController GoogleController { get; private set; }

	public static Controller Controller { get; private set; }

	public static TreeController TreeController { get; private set; }

	public static ComicsController ComicsController { get; set; }

	public static JsonSerializerSettings GetGlobalSettings()
	{
		if (settings == null)
		{
			settings = new JsonSerializerSettings();
			settings.TypeNameHandling = TypeNameHandling.Auto;
			settings.NullValueHandling = NullValueHandling.Ignore;
			settings.DefaultValueHandling = DefaultValueHandling.Include;
			settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			settings.Converters = new List<JsonConverter>
			{
				new BoolConverter(),
				new FloatConverter(),
				new IntConverter()
			};
		}
		return settings;
	}

	private void Awake()
	{
		smallAchivementPrefab = Resources.Load<AchivementBlockInstancer>("Prefabs/SmallAchivementBlock");
		achivementPopupController = UnityEngine.Object.FindObjectOfType<AchivementPopupController>();
	}

	public static RectTransform InstantiateSmallAchivement(string name)
	{
		AchivementBlockInstancer achivementBlockInstancer = UnityEngine.Object.Instantiate(smallAchivementPrefab);
		achivementBlockInstancer.Init(name, hidden: false, big: false);
		return achivementBlockInstancer.GetComponent<RectTransform>();
	}

	public static string GetRandomTextKeyNameForQuest(int id)
	{
		return ActiveComponent._staticData.Quests[id].Texts;
	}

	public static LevelData GetLevelData()
	{
		_ = ActiveComponent.Model.P.Servers;
		return ActiveComponent._staticData.Levels.FirstItem();
	}

	public static Font GetFont(string fontName)
	{
		if (fonts.ContainsKey(fontName))
		{
			return fonts[fontName];
		}
		Font font = Resources.Load(fontName) as Font;
		fonts.Add(fontName, font);
		Shader.WarmupAllShaders();
		return font;
	}

	public static bool StartupUnlocked(Startup st)
	{
		return UnlockGroup.IsUnlocked(st.ReqUnlockGroups);
	}

	public static bool StartupBlocked(Startup st)
	{
		return UnlockGroup.IsUnlocked(st.ReqBlockGroups);
	}

	public static Startup GetRandomStartup(string keyName)
	{
		List<Startup> list = new List<Startup>();
		int hashCode = keyName.GetHashCode();
		foreach (Startup startup in ActiveComponent._staticData.Startups)
		{
			if (startup.KeyName.GetHashCode() == hashCode)
			{
				for (int i = 0; i < startup.ChanceScore; i++)
				{
					list.Add(startup);
					list.LastItem().dayMail = ActiveComponent.Model.P.Days + ActiveComponent.Model.P.Weeks * 7;
				}
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public static bool WasMoneyLetter(string KeyName)
	{
		return ActiveComponent.Model.P.wasMoneyLetters.FindIndex((string s) => s == KeyName) >= 0;
	}

	public static bool LinuxTestPass()
	{
		string text = ActiveComponent._staticData.Settings.CheckLinuxValue1.ToString();
		if (text != "1.00")
		{
			return false;
		}
		if (text != "-0.05")
		{
			return false;
		}
		return true;
	}

	public static bool MoneyLetterUnlocked(MoneyLetter ml)
	{
		return UnlockGroup.IsUnlocked(ml.ReqUnlockGroups);
	}

	public static bool MoneyLetterBlocked(MoneyLetter ml)
	{
		return UnlockGroup.IsUnlocked(ml.ReqBlockGroups);
	}

	public static bool CheckConditions(QuestCondition cnd, Construction construction)
	{
		return cnd?.Check(construction) ?? false;
	}

	public static bool CheckConditions(QuestCondition cnd, SchemeBlock sch)
	{
		return cnd?.Check(sch) ?? false;
	}

	public static MoneyLetter GetRandomMoneyLetter()
	{
		List<MoneyLetter> list = new List<MoneyLetter>();
		foreach (MoneyLetter moneyLetter in ActiveComponent._staticData.MoneyLetters)
		{
			if (!WasMoneyLetter(moneyLetter.KeyName) && MoneyLetterUnlocked(moneyLetter) && !MoneyLetterBlocked(moneyLetter))
			{
				for (int i = 0; i < moneyLetter.ChanceScore; i++)
				{
					list.Add(moneyLetter);
					list.LastItem().used = 0;
					list.LastItem().dayMail = ActiveComponent.Model.P.Days + ActiveComponent.Model.P.Weeks * 7;
					list.LastItem().wasRead = 0;
				}
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public static List<UnlockGroup> ParseReqGroups(string group)
	{
		List<UnlockGroup> list = new List<UnlockGroup>();
		string[] array = group.Split(';');
		foreach (string text in array)
		{
			if (text != "")
			{
				string[] array2 = text.Split(',');
				UnlockGroup unlockGroup = new UnlockGroup();
				if (!int.TryParse(array2[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out unlockGroup.numUnlock))
				{
					unlockGroup.numUnlock = 0;
				}
				for (int j = 1; j < array2.Length; j++)
				{
					unlockGroup.questsKeyNames.Add(array2[j]);
					unlockGroup.questsHashes.Add(array2[j].GetHashCode());
				}
				list.Add(unlockGroup);
			}
		}
		return list;
	}

	public static bool IsBaseBlock(string KeyName)
	{
		return ActiveComponent._staticData.ConstructionBlocks.FindIndex((ConstructionBlock s) => s.KeyName == KeyName) >= 0;
	}

	public static void OpenUrl(string url)
	{
		Application.OpenURL(url);
	}

	public static int GetCouUnreadTasks()
	{
		int num = 0;
		foreach (string item in ActiveComponent.Model.P.taskQueue)
		{
			if (QuestLine.IsLoadedInMemory(item) && !QuestLine.GetQuest(item).IsTaskOpened())
			{
				num++;
			}
		}
		return num;
	}

	public static bool IsStartupInProgress(string name)
	{
		return ActiveComponent.Model.P.Startups.FindIndex((StartupScheme s) => s.baseStartup.KeyName == name) >= 0;
	}

	public static int GetUnreadLettersNum()
	{
		return GetCouUnreadMoneyLetters() + GetCouUnreadStartups() + GetCouUnreadTasks();
	}

	public static int GetCouUnreadStartups()
	{
		int num = 0;
		foreach (StartupScheme startup in ActiveComponent.Model.P.Startups)
		{
			if (startup.released == 1)
			{
				num++;
			}
		}
		return ActiveComponent.Model.P.startupQueue.Count - ActiveComponent.Model.P.removedStartups.Count - num;
	}

	public static int GetCouUnreadMoneyLetters()
	{
		int num = 0;
		foreach (MoneyLetter moneyLetter in ActiveComponent.Model.P.moneyLetters)
		{
			if (moneyLetter.used == 0)
			{
				num++;
			}
		}
		return num;
	}

	public static int ServersToMoney(int serv)
	{
		return serv *= ActiveComponent._staticData.Settings.ServerCost;
	}

	public static bool HasAlgoBlock(string KeyName)
	{
		return ActiveComponent.Model.P.extraUnlockedAlgos.Contains(KeyName);
	}

	public static bool HasUpgrade(string KeyName)
	{
		return ActiveComponent.Model.P.unlockedUpgrades.FindIndex((UpgradeStats s) => s.KeyName == KeyName) >= 0;
	}

	public static bool HasHat(string KeyName)
	{
		return ActiveComponent.Model.P.unlockedCatHats.FindIndex((CatVR s) => s.KeyName == KeyName) >= 0;
	}

	public static string GetPrefabPath(string keyName, bool bigBlock = false)
	{
		if (bigBlock)
		{
			return "Prefabs/" + keyName + "_MOBILE";
		}
		return "Prefabs/" + keyName;
	}

	public static void UnlockAllAchievements()
	{
		foreach (AchivementData achivementData in ActiveComponent._staticData.AchivementDatas)
		{
			if (!achivementData.KeyName.Contains("PS"))
			{
				Steam.UnlockAchievement(achivementData.KeyName);
			}
		}
	}

	public static bool CheckPromoCode(string code)
	{
		if (code == null)
		{
			return false;
		}
		string lcode = code.ToLower();
		PromoCode p = ActiveComponent._staticData.PromoCodes.Find((PromoCode i) => i.KeyName.ToLower() == lcode);
		if (p != null)
		{
			Steam.UnlockAchievement("ACHIEVEMENT_16");
			if (ActiveComponent.Model.globalSaves.unlockedPromoCats.FindIndex((string j) => j.ToLower() == p.ItemUnlock.ToLower()) < 0 && ActiveComponent._staticData.PromoCats.FindIndex((CatVR j) => j.KeyName.ToLower() == p.ItemUnlock.ToLower()) >= 0)
			{
				ActiveComponent.Model.globalSaves.unlockedPromoCats.Add(p.ItemUnlock.ToLower());
				UpdateGlobalSaves();
				return true;
			}
			if (ActiveComponent.Model.globalSaves.unlockedMainThemes.FindIndex((string j) => j.ToLower() == p.ItemUnlock.ToLower()) < 0 && ActiveComponent._staticData.Themes.FindIndex((BaseItem j) => j.KeyName.ToLower() == p.ItemUnlock.ToLower()) >= 0)
			{
				ActiveComponent.Model.globalSaves.unlockedMainThemes.Add(p.ItemUnlock.ToLower());
				ActiveComponent.Model.globalSaves.activeTheme = p.ItemUnlock.ToLower();
				UpdateGlobalSaves();
				return true;
			}
			return true;
		}
		return false;
	}

	public static void CheckPSPlatinum()
	{
		if (GetModel().globalSaves.gainedAchivements.Contains("ACHIEVEMENT_PS"))
		{
			return;
		}
		bool flag = true;
		foreach (AchivementData achivementData in ActiveComponent._staticData.AchivementDatas)
		{
			if (achivementData.PSId > 0 && !ActiveComponent.Model.globalSaves.gainedAchivements.Contains(achivementData.KeyName))
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			GetModel().globalSaves.gainedAchivements.Add("ACHIEVEMENT_PS");
		}
	}

	public static void CheckEpochAchivments()
	{
		int num = 4;
		foreach (Epoch epoch in ActiveComponent._staticData.Epochs)
		{
			if (ActiveComponent.Model.globalSaves.passedTasks.ContainsKey(epoch.End) && ActiveComponent.Model.globalSaves.passedTasks[epoch.End] > 0)
			{
				Steam.UnlockAchievement("ACHIEVEMENT_" + num);
			}
			num++;
		}
	}

	public static bool WasPromoCode(string code)
	{
		if (code == null)
		{
			return false;
		}
		string lcode = code.ToLower();
		PromoCode p = ActiveComponent._staticData.PromoCodes.Find((PromoCode i) => i.KeyName.ToLower() == lcode);
		if (p == null)
		{
			return false;
		}
		if (ActiveComponent._staticData.PromoCats.FindIndex((CatVR i) => i.KeyName.ToLower() == p.ItemUnlock.ToLower()) >= 0)
		{
			return ActiveComponent.Model.globalSaves.unlockedPromoCats.Contains(p.ItemUnlock.ToLower());
		}
		if (ActiveComponent._staticData.Themes.FindIndex((BaseItem i) => i.KeyName.ToLower() == p.ItemUnlock.ToLower() && i.isPromo) >= 0)
		{
			return ActiveComponent.Model.globalSaves.unlockedMainThemes.Contains(p.ItemUnlock.ToLower());
		}
		return false;
	}

	public static bool IsLose()
	{
		if (ActiveComponent.Model.P.Money < 0)
		{
			return true;
		}
		return false;
	}

	public static bool IsWin()
	{
		int numCompleted = QuestLine.GetNumCompleted();
		int num = 0;
		QuestLine.GetSumScore();
		bool flag = true;
		foreach (ConstructionQuest quest in ActiveComponent._staticData.Quests)
		{
			if (quest.Locked == 0 && quest.IsTask == 1 && quest.VisibleToPlayer)
			{
				num++;
				if (!QuestLine.IsLoadedInMemory(quest.KeyName) || QuestLine.GetQuest(quest.KeyName).GetScore() < 3)
				{
					flag = false;
				}
			}
		}
		foreach (CarQuest carQuest in ActiveComponent._staticData.CarQuests)
		{
			if (carQuest.Locked == 0 && carQuest.VisibleToPlayer)
			{
				num++;
				if (!QuestLine.IsLoadedInMemory(carQuest.KeyName) || QuestLine.GetQuest(carQuest.KeyName).GetScore() < 3)
				{
					flag = false;
				}
			}
		}
		foreach (ForumQuest forumQuest in ActiveComponent._staticData.ForumQuests)
		{
			if (forumQuest.Locked == 0 && forumQuest.VisibleToPlayer)
			{
				num++;
			}
		}
		foreach (Comics comicse in ActiveComponent._staticData.Comicses)
		{
			if (comicse.Locked == 0 && comicse.VisibleToPlayer)
			{
				num++;
			}
		}
		if (num <= numCompleted)
		{
			Steam.UnlockAchievement("ACHIEVEMENT_10");
		}
		if (flag)
		{
			Steam.UnlockAchievement("ACHIEVEMENT_11");
		}
		if (ActiveComponent.Model.P.wasWin == 1)
		{
			return false;
		}
		foreach (EndGame item in ActiveComponent._staticData.EndGame)
		{
			if (UnlockGroup.IsUnlocked(item.ReqUnlockGroups))
			{
				Steam.UnlockAchievement("ACHIEVEMENT_9");
				if (-ActiveComponent.Model.globalSaves.unlockedPromoCats.Count - 1 + ActiveComponent.Model.P.unlockedCatHats.Count + ActiveComponent.Model.P.unlockedUpgrades.Count + ActiveComponent.Model.P.extraUnlockedAlgos.Count + ActiveComponent.Model.P.boughtShopItem.Count == 0)
				{
					Steam.UnlockAchievement("ACHIEVEMENT_19");
				}
				ActiveComponent.Model.globalSaves.showOutro = true;
				return true;
			}
		}
		return false;
	}

	public static int GetUpgradesCouWithTag(string Tag)
	{
		return GetUpgradesCouWithTag(Tag.GetHashCode());
	}

	public static int GetUpgradesCouWithTag(int hash)
	{
		int num = 0;
		foreach (UpgradeStats pCUpgrade in ActiveComponent._staticData.PCUpgrades)
		{
			if (hash == pCUpgrade.Tag.GetHashCode())
			{
				num++;
			}
		}
		return num;
	}

	public static Sticker GetStickerByHash(int hash)
	{
		return GetSmthByHash(hash, ActiveComponent._staticData.Stickers);
	}

	public static ConstructionBlock GetConstrBlockByKeyHash(int hash)
	{
		return GetSmthByHash(hash, ActiveComponent._staticData.ConstructionBlocks);
	}

	public static Epoch GetEpochByHash(int hash)
	{
		return GetSmthByHash(hash, ActiveComponent._staticData.Epochs);
	}

	public static Epoch GetEpochByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.Epochs);
	}

	public static AchivementData GetAchivementDataByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.AchivementDatas);
	}

	public static ForumMessageData GetForumMessageDataByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.ForumMessagesData);
	}

	public static CarSliderParamsBounds GetCarSliderParamsBoundsByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.carSliderParamsBounds);
	}

	public static ForumQuest GetForumQuestByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.ForumQuests);
	}

	public static Startup GetStartupByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.Startups);
	}

	private static T GetSmthByKeyName<T>(string keyName, List<T> list) where T : BaseKeyData
	{
		return GetSmthByHash(keyName.GetHashCode(), list);
	}

	public static SpriteHolder GetZIPSpriteByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.Sprites);
	}

	private static T GetSmthByHash<T>(int hash, List<T> list) where T : BaseKeyData
	{
		return list.Find((T y) => y.KeyName.GetHashCode() == hash);
	}

	public static List<App.Data.Data> GetListDatas(ConstructionQuest cq)
	{
		return new List<App.Data.Data>
		{
			GetDataByKeyName(cq.Data0),
			GetDataByKeyName(cq.Data1),
			GetDataByKeyName(cq.Data2),
			GetDataByKeyName(cq.Data3),
			GetDataByKeyName(cq.Data4)
		};
	}

	public static Chain CreateChain(Transform paretntTransform)
	{
		Chain chain = CreateChain();
		chain.transform.SetParent(paretntTransform);
		return chain;
	}

	public static Chain CreateChain()
	{
		return ActiveComponent.Model.GetChainObjectFromPool(ActiveComponent.Model.chainPrefab, Vector3.zero, Quaternion.identity, null);
	}

	public static List<List<bool>> HasElemInDatasInQuest(ConstructionQuest cq)
	{
		List<List<bool>> list = new List<List<bool>>();
		List<List<int>> list2 = SumCouInDatasInQuest(cq);
		list.Clear();
		for (int i = 0; i < 3; i++)
		{
			list.Add(new List<bool>());
			for (int j = 0; j < 3; j++)
			{
				list[i].Add(item: false);
			}
		}
		for (int k = 0; k < 3; k++)
		{
			for (int l = 0; l < 3; l++)
			{
				list[k][l] = list2[k][l] > 0;
			}
		}
		return list;
	}

	public static List<List<int>> GetCouMatrixInData(App.Data.Data d, ConstructionQuest cq)
	{
		List<List<int>> list = new List<List<int>>();
		list.Clear();
		for (int i = 0; i < 3; i++)
		{
			list.Add(new List<int>());
			for (int j = 0; j < 3; j++)
			{
				list[i].Add(0);
			}
		}
		if (d != null)
		{
			if (cq.OnlyColor == 1)
			{
				list[0][1] += d.RC + d.RS + d.RT;
				list[1][1] += d.GC + d.GS + d.GT;
				list[2][1] += d.BC + d.BS + d.BT;
			}
			else if (cq.OnlyShape == 1)
			{
				list[1][0] += d.RC + d.GC + d.BC;
				list[1][1] += d.RS + d.GS + d.BS;
				list[1][2] += d.RT + d.GT + d.BT;
			}
			else
			{
				list[0][0] += d.RC;
				list[1][0] += d.GC;
				list[2][0] += d.BC;
				list[0][1] += d.RS;
				list[1][1] += d.GS;
				list[2][1] += d.BS;
				list[0][2] += d.RT;
				list[1][2] += d.GT;
				list[2][2] += d.BT;
			}
		}
		return list;
	}

	public static List<List<int>> SumCouInDatasInQuest(ConstructionQuest cq)
	{
		List<List<int>> list = new List<List<int>>();
		List<App.Data.Data> list2 = new List<App.Data.Data>();
		list2.Add(GetDataByKeyName(cq.Data0));
		list2.Add(GetDataByKeyName(cq.Data1));
		list2.Add(GetDataByKeyName(cq.Data2));
		list2.Add(GetDataByKeyName(cq.Data3));
		list2.Add(GetDataByKeyName(cq.Data4));
		list.Clear();
		for (int i = 0; i < 3; i++)
		{
			list.Add(new List<int>());
			for (int j = 0; j < 3; j++)
			{
				list[i].Add(0);
			}
		}
		foreach (App.Data.Data item in list2)
		{
			if (item != null)
			{
				if (cq.OnlyColor == 1)
				{
					list[0][1] += item.RC + item.RS + item.RT;
					list[1][1] += item.GC + item.GS + item.GT;
					list[2][1] += item.BC + item.BS + item.BT;
				}
				if (cq.OnlyShape == 1)
				{
					list[1][0] += item.RC + item.GC + item.BC;
					list[1][1] += item.RS + item.GS + item.BS;
					list[1][2] += item.RT + item.GT + item.BT;
				}
				if (cq.OnlyColor == 0 && cq.OnlyShape == 0)
				{
					list[0][0] += item.RC;
					list[1][0] += item.GC;
					list[2][0] += item.BC;
					list[0][1] += item.RS;
					list[1][1] += item.GS;
					list[2][1] += item.BS;
					list[0][2] += item.RT;
					list[1][2] += item.GT;
					list[2][2] += item.BT;
				}
			}
		}
		return list;
	}

	public static List<CarObjectTreeHierarchy> GetCarObjectTreeHierarchy()
	{
		return ActiveComponent._staticData.carObjectTreeHierarchy;
	}

	public static CarObjectTreeHierarchy GetCarObjectTreeHierarchyByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.carObjectTreeHierarchy);
	}

	public static CarQuest GetCarQuestByKeyName(string keyName)
	{
		return GetBaseQuestByKeyName(keyName).As<CarQuest>();
	}

	public static Comics GetComicsByKeyName(string keyName)
	{
		return GetBaseQuestByKeyName(keyName).As<Comics>();
	}

	public static DeepTrafficEnvPresets GetCarEnvByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.CarEnv);
	}

	public static AgentPresets GetCarAgentByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.CarAgents);
	}

	public static LidarData GetLidarDataByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.LidarData);
	}

	public static LidarData GetBestLidarData()
	{
		if (ActiveComponent._staticData.LidarData.Count == 0)
		{
			return null;
		}
		for (int num = ActiveComponent._staticData.LidarData.Count - 1; num >= 0; num--)
		{
			if (UnlockGroup.IsUnlocked(ParseReqGroups(ActiveComponent._staticData.LidarData[num].ReqUnlock)))
			{
				return ActiveComponent._staticData.LidarData[num];
			}
		}
		return null;
	}

	public static AgentUnlockedParams GetCarEnabledParamsByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.CarEnabledParams);
	}

	public static DeepTrafficControllerPresets GetCarControllerByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.CarController);
	}

	public static DeepTrafficControllerUnlockedParams GetCarControllerEnabledParamByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.CarControllerEnabledParams);
	}

	public static CarCondition GetCarConditionByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.CarConditions);
	}

	public static CarAttentionBackground GetCarAttentionBackgroundByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.CarAttentionBackground);
	}

	public static CarConstraint GetCarConstraintByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.CarConstraints);
	}

	public static CarMedalCondition GetCarMedalConditionByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.CarMedalConditions);
	}

	public static CarDatas GetCarDatasByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.carDatas);
	}

	public static Checkpoint GetCheckPointByKeyname(string keyName)
	{
		int hash = keyName.GetHashCode();
		return ActiveComponent._staticData.Checkpoints.Find((Checkpoint s) => s.KeyName.GetHashCode() == hash);
	}

	public static void UpdateCurGlobalScore(QuestLine.Quest q)
	{
		string key = q.GetName();
		if (!ActiveComponent.Model.globalSaves.passedTasks.ContainsKey(key))
		{
			ActiveComponent.Model.globalSaves.passedTasks[key] = q.GetScore();
		}
		else
		{
			ActiveComponent.Model.globalSaves.passedTasks[key] = Mathf.Max(ActiveComponent.Model.globalSaves.passedTasks[key], q.GetScore());
		}
	}

	public static void AddMoney(int money)
	{
		ActiveComponent.Model.P.Money += money;
	}

	public static BaseQuest GetBaseQuestByKeyName(string keyName)
	{
		return GetBaseQuestByKeyHash(keyName.GetHashCode());
	}

	public static BaseQuest GetBaseQuestByKeyHash(int hash)
	{
		if (baseQuests.ContainsKey(hash))
		{
			return baseQuests[hash];
		}
		ConstructionQuest smthByHash = GetSmthByHash(hash, ActiveComponent._staticData.Quests);
		if (smthByHash != null)
		{
			baseQuests.Add(hash, smthByHash);
			return smthByHash;
		}
		CarQuest smthByHash2 = GetSmthByHash(hash, ActiveComponent._staticData.CarQuests);
		if (smthByHash2 != null)
		{
			baseQuests.Add(hash, smthByHash2);
			return smthByHash2;
		}
		Comics smthByHash3 = GetSmthByHash(hash, ActiveComponent._staticData.Comicses);
		if (smthByHash3 != null)
		{
			baseQuests.Add(hash, smthByHash3);
			return smthByHash3;
		}
		ForumQuest smthByHash4 = GetSmthByHash(hash, ActiveComponent._staticData.ForumQuests);
		baseQuests.Add(hash, smthByHash4);
		return smthByHash4;
	}

	public static void InitSession(PreviewData pr)
	{
		ActiveComponent.Model.P.lastGainStartup = 0;
		ActiveComponent.Model.P.curLetter = null;
		ActiveComponent.Model.P.rememberedSpeed = 1f;
		ActiveComponent.Model.P.Days = 0;
		ActiveComponent.Model.P.curCat = 0;
		ActiveComponent.Model.P.showCustom = 0;
		ActiveComponent.Model.P.passedFirstQuest = 0;
		ActiveComponent.Model.P.Money = GetCheckPointByKeyname(pr.startCheckpointKeyName).StartMoney;
		ActiveComponent.Model.P.infotutorial = pr.startCheckpointKeyName != ActiveComponent._staticData.Checkpoints[0].KeyName;
		try
		{
			ActiveComponent.Model.P.daysStartTask.Add(DateTime.Now.ToString());
		}
		catch
		{
			ActiveComponent.Model.P.daysStartTask.Add(DateTime.UtcNow.ToString());
		}
		ActiveComponent.Model.P.watchedShop = new Dictionary<string, int>();
		ActiveComponent.Model.P.watchedShop.Add(ActiveComponent._staticData.CatCost[0].KeyName, 1);
		ActiveComponent.Model.P.taskQueue.Clear();
		ActiveComponent.Model.P.startupConstructionTutorial = 0;
		ActiveComponent.Model.P.daysTutorial = 0;
		ActiveComponent.Model.P.wasMoneyLetters.Clear();
		ActiveComponent.Model.P.upgradeStats = new UpgradeStats();
		ActiveComponent.Model.P.Servers = 0L;
		if (ActiveComponent.Model.curPreview.startCheckpointKeyName != ActiveComponent._staticData.Checkpoints[0].KeyName)
		{
			ActiveComponent.Model.P.showCustom = 1;
			ActiveComponent.Model.P.passedFirstQuest = 1;
			ActiveComponent.Model.P.startupTutorial = 1;
			ActiveComponent.Model.P.treeBtnTutorial = true;
		}
		List<string> unlockTasksList = GetCheckPointByKeyname(pr.startCheckpointKeyName).UnlockTasksList;
		if (unlockTasksList.Count > 0)
		{
			foreach (string item in unlockTasksList)
			{
				string key = item;
				BaseQuest baseQuestByKeyName = GetBaseQuestByKeyName(item);
				QuestLine.Quest quest = QuestLine.UpdateOrAddQuest(baseQuestByKeyName);
				if (baseQuestByKeyName.Is<BaseGameQuest>())
				{
					ActiveComponent.Model.P.taskQueue.Add(item);
				}
				int value = 0;
				if (ActiveComponent.Model.globalSaves.passedTasks.TryGetValue(key, out value))
				{
					quest.SetOpened(state: true);
					quest.SetScore(value);
					quest.SetGainedReward(1);
				}
				else
				{
					quest.SetScore(0);
					quest.SetQuest(baseQuestByKeyName);
				}
			}
			if (pr.startCheckpointKeyName != ActiveComponent._staticData.Checkpoints[0].KeyName)
			{
				ActiveComponent.Model.P.firstNonForumQuestTutorial = 1;
				ActiveComponent.Model.P.firstTreeTutorialCompleted = true;
			}
			if (unlockTasksList.Contains(ActiveComponent._staticData.Settings.ShowServersTrigger))
			{
				ActiveComponent.Model.P.serversTutorial = 1;
			}
			if (unlockTasksList.Contains(ActiveComponent._staticData.Settings.ErrorTutorial))
			{
				ActiveComponent.Model.P.errorTutorial = 1;
			}
			if (unlockTasksList.Contains(ActiveComponent._staticData.Settings.SpeedTutorial))
			{
				ActiveComponent.Model.P.speedTutorial = 1;
			}
			if (unlockTasksList.Contains(ActiveComponent._staticData.Settings.TimeTutorial))
			{
				ActiveComponent.Model.P.timeTutorial = 1;
			}
			if (unlockTasksList.Contains(ActiveComponent._staticData.Settings.OccAndAccTutorial))
			{
				ActiveComponent.Model.P.occAndAccTutorial = 1;
			}
			if (unlockTasksList.Contains(ActiveComponent._staticData.Settings.MaintainAccTutorial))
			{
				ActiveComponent.Model.P.maintainAccLevelTutorial = 1;
			}
			if (unlockTasksList.Contains(ActiveComponent._staticData.Settings.CopyTutorial))
			{
				ActiveComponent.Model.P.copyTutorial = 1;
			}
			if (unlockTasksList.Contains(ActiveComponent._staticData.Settings.MemoryRNNTutorial))
			{
				ActiveComponent.Model.P.memoryRNNTutorial = 1;
			}
			if (unlockTasksList.Contains(ActiveComponent._staticData.Settings.ShowCatHubTrigger))
			{
				ActiveComponent.Model.P.catHubTutorial = 1;
			}
		}
		ActiveComponent.Model.P.playerUnit = new Unit("PLAYER", UnityEngine.Random.Range(ActiveComponent._staticData.Settings.MinPlayerScore, ActiveComponent._staticData.Settings.MaxPlayerScore));
		QuestLine.UpdateComicsesScore();
		ActiveComponent.Model.P.sandboxSchemes = new Dictionary<string, SandboxScheme>();
		string empty = string.Empty;
		for (int i = 0; i < ActiveComponent._staticData.Settings.MaxSandbox; i++)
		{
			empty = "SANDBOX" + i;
			ActiveComponent.Model.P.sandboxSchemes.Add(empty, new SandboxScheme());
			ActiveComponent.Model.P.sandboxSchemes[empty].InitEmpty();
		}
		ActiveComponent.Model.P.watchBlockTutorials = new Dictionary<string, int>();
		foreach (ConstructionBlock constructionBlock in ActiveComponent._staticData.ConstructionBlocks)
		{
			int value2 = Convert.ToInt32(UnlockGroup.IsUnlocked(constructionBlock.ReqUnlockGroups) && constructionBlock.Extra == 0);
			ActiveComponent.Model.P.watchBlockTutorials.Add(constructionBlock.KeyName, value2);
		}
		ActiveComponent.Model.P.activeInterierItem = new Dictionary<string, int>();
		foreach (InteriorItem shopItem in ActiveComponent._staticData.ShopItems)
		{
			ActiveComponent.Model.P.activeInterierItem.Add(shopItem.KeyName, 0);
		}
		foreach (UpgradeStats pCUpgrade in ActiveComponent._staticData.PCUpgrades)
		{
			ActiveComponent.Model.P.activeInterierItem.Add(pCUpgrade.KeyName, 0);
		}
		Checkpoint checkPointByKeyname = GetCheckPointByKeyname(pr.startCheckpointKeyName);
		QuestLine.UpdateOrAddQuest(GetBaseQuestByKeyName(checkPointByKeyname.ScrollToTask));
		QuestLine.SetCurrentQuest(checkPointByKeyname.ScrollToTask);
		QuestLine.Quest quest2 = QuestLine.GetQuest(checkPointByKeyname.ScrollToTask);
		if (quest2.Is<BaseGameQuest>())
		{
			ActiveComponent.Model.P.ShowFastMailTask = quest2;
			ActiveComponent.Model.OpenTaskInbox = quest2;
			ActiveComponent.Model.P.taskQueue.Add(checkPointByKeyname.ScrollToTask);
		}
	}

	public static void AddDay()
	{
		ActiveComponent.Model.P.Days++;
	}

	public static int GetCurSandboxes()
	{
		int a = 0;
		if (ActiveComponent.Model.curPreview.IsQuestDone(ActiveComponent._staticData.Settings.SandBoxTrigger))
		{
			a = ActiveComponent._staticData.Settings.SandboxDefaultsNum + ActiveComponent.Model.P.upgradeStats.MemoryBonus;
		}
		return Mathf.Min(a, ActiveComponent._staticData.Settings.MaxSandbox);
	}

	public static string TransformSandboxnameToShowName(string keyName)
	{
		string text = keyName.Replace("SANDBOX", "");
		return TextResources.GetString("DLL") + text;
	}

	public static ConstructionQuest GetCurrentTableQuest()
	{
		QuestLine.Quest quest = QuestLine.GetCurrentQuest();
		if (ActiveComponent.Model.construction.constrState == ConstructionState.Forum)
		{
			quest = QuestLine.GetQuest(quest.GetForumQuest().QuestKeyName);
		}
		if (!quest.Is<ConstructionQuest>())
		{
			return null;
		}
		return quest.GetTableQuest();
	}

	public static string GetShowNameById(string keyName)
	{
		SchemeBlock schemeBlockByKeyName = GetSchemeBlockByKeyName(keyName);
		if (schemeBlockByKeyName == null)
		{
			if (ActiveComponent.Model.P.sandboxSchemes.ContainsKey(keyName))
			{
				return TransformSandboxnameToShowName(keyName);
			}
			QuestLine.Quest quest = QuestLine.GetCurrentQuest();
			if (ActiveComponent.Model.construction.constrState == ConstructionState.Forum)
			{
				quest = QuestLine.GetQuest(quest.GetForumQuest().QuestKeyName);
			}
			return TextResources.GetString(quest.GetName() + " BLOCK");
		}
		string showName = schemeBlockByKeyName.GetShowName();
		if (showName.Length > 0)
		{
			return showName;
		}
		if (ActiveComponent.Model.P.sandboxSchemes.ContainsKey(schemeBlockByKeyName.KeyName))
		{
			return TransformSandboxnameToShowName(schemeBlockByKeyName.KeyName);
		}
		return TextResources.GetString(schemeBlockByKeyName.KeyName + " BLOCK");
	}

	public static int GetMaxChainCapacityForGraph()
	{
		return (int)(GetChainTime() / (GetWorkTimeByKeyName("PARALLEL") * 2f));
	}

	public static int GetMaxAcc(ConstructionQuest q)
	{
		int num = -1;
		App.Data.Result resultByKeyName = GetResultByKeyName(q.Res0);
		if (resultByKeyName != null)
		{
			num = Mathf.Max(num, resultByKeyName.Accuracy);
		}
		resultByKeyName = GetResultByKeyName(q.Res0);
		if (resultByKeyName != null)
		{
			num = Mathf.Max(num, resultByKeyName.Accuracy);
		}
		resultByKeyName = GetResultByKeyName(q.Res1);
		if (resultByKeyName != null)
		{
			num = Mathf.Max(num, resultByKeyName.Accuracy);
		}
		resultByKeyName = GetResultByKeyName(q.Res2);
		if (resultByKeyName != null)
		{
			num = Mathf.Max(num, resultByKeyName.Accuracy);
		}
		resultByKeyName = GetResultByKeyName(q.Res3);
		if (resultByKeyName != null)
		{
			num = Mathf.Max(num, resultByKeyName.Accuracy);
		}
		resultByKeyName = GetResultByKeyName(q.Res4);
		if (resultByKeyName != null)
		{
			num = Mathf.Max(num, resultByKeyName.Accuracy);
		}
		return num;
	}

	public static User GetAudienceByKeyName(string KeyName)
	{
		return ActiveComponent._staticData.Users.Find((User s) => s.KeyName == KeyName);
	}

	public static CatVR GetPromocatByKeyName(string KeyName)
	{
		return ActiveComponent._staticData.PromoCats.Find((CatVR s) => s.KeyName.ToLower() == KeyName.ToLower());
	}

	public static ConstructionQuest GetOldQuestById(int id)
	{
		return ActiveComponent._staticData.Quests.Find((ConstructionQuest s) => s.OldId == id);
	}

	public static UpgradeStats GetPCUpgradeBykeyName(string name)
	{
		int hash = name.GetHashCode();
		return ActiveComponent._staticData.PCUpgrades.Find((UpgradeStats s) => s.KeyName.GetHashCode() == hash);
	}

	public static CatVR GetCatVRBykeyName(string name)
	{
		int hash = name.GetHashCode();
		CatVR catVR = ActiveComponent._staticData.CatCost.Find((CatVR s) => s.KeyName.GetHashCode() == hash);
		if (catVR != null)
		{
			return catVR;
		}
		return ActiveComponent._staticData.CatCost.Find((CatVR s) => s.KeyName.GetHashCode() == hash);
	}

	public static int GetMaxElementsOnLine()
	{
		return ActiveComponent._staticData.Settings.MaxElementsOnChain;
	}

	public static string GetSaveNameTemplate(bool playerPostfix = true)
	{
		if (!playerPostfix)
		{
			return "WTL_saves_game_id";
		}
		return "WTL_saves_game_idPLAYER";
	}

	public static string GetSaveNameFromID(int playerID)
	{
		return GetSaveNameTemplate() + playerID;
	}

	public static int GetCurrentAppVersion()
	{
		return Helper.VersionStringToInt(ActiveComponent.Model.P.version);
	}

	public static string GetCurLangSufix()
	{
		switch (ActiveComponent.Model.globalSaves.lang)
		{
		case 0:
			return "_en";
		case 1:
			return "_ru";
		case 2:
			return "_ch";
		case 3:
			return "_ch";
		default:
			Debug.LogError("Not implemented");
			return "_en";
		}
	}

	public static int GetMinAccInCosntrQuest(ConstructionQuest cq)
	{
		int num = 100;
		if (cq == null)
		{
			return num;
		}
		foreach (string item in new List<string> { cq.Res0, cq.Res1, cq.Res2, cq.Res3, cq.Res4 })
		{
			App.Data.Result resultByKeyName = GetResultByKeyName(item);
			if (resultByKeyName != null)
			{
				num = Mathf.Min(resultByKeyName.Accuracy, num);
			}
		}
		return num;
	}

	public static void UpdateHashDictionaryToNextUnityVersion(Dictionary<int, int> dict, Func<int, string> GetName)
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, int> item in dict)
		{
			list.Add(item.Key);
		}
		foreach (int item2 in list)
		{
			int num = dict[item2];
			dict.Add(GetName(num).GetHashCode(), num);
			dict.Remove(item2);
		}
	}

	public static void LoadOrCreatePData(string KEY = "WTL_saves")
	{
		int num = 0;
		string text = LoadSaveGame(KEY);
		if (text.Length > 0)
		{
			try
			{
				string[] array = text.Split(Convert.ToChar(3));
				if (array.Length > 1)
				{
					try
					{
						SaveHeader saveHeader = DeserializeObject<SaveHeader>(array[0]);
						num = saveHeader.v;
						Debug.LogError("Loaded save game from: " + saveHeader.date);
					}
					catch (Exception ex)
					{
						Debug.LogError(ex.Message);
						num = DeserializeObject<OldSaveHeader>(array[0]).v;
					}
					try
					{
						ActiveComponent.Model.P = DeserializeObject<PersistentData>(array[1]);
					}
					catch
					{
					}
					if (num < 101066)
					{
						string text2 = SerializeObject(ActiveComponent.Model.P.boughtShopItem);
						foreach (string[] replaceOldHash in replaceOldHashes)
						{
							text2 = text2.Replace(replaceOldHash[1], replaceOldHash[0]);
						}
						ActiveComponent.Model.P.boughtShopItem = DeserializeObject<Dictionary<string, int>>(text2);
						text2 = SerializeObject(ActiveComponent.Model.P.activeInterierItem);
						foreach (string[] replaceOldHash2 in replaceOldHashes)
						{
							text2 = text2.Replace(replaceOldHash2[1], replaceOldHash2[0]);
						}
						foreach (string[] replaceOldUpgradesHash in replaceOldUpgradesHashes)
						{
							text2 = text2.Replace(replaceOldUpgradesHash[0], replaceOldUpgradesHash[1]);
						}
						ActiveComponent.Model.P.activeInterierItem = DeserializeObject<Dictionary<string, int>>(text2);
						text2 = SerializeObject(ActiveComponent.Model.P.sandboxSchemes);
						foreach (string[] replaceOldHash3 in replaceOldHashes)
						{
							text2 = text2.Replace(replaceOldHash3[1], replaceOldHash3[0]);
						}
						ActiveComponent.Model.P.sandboxSchemes = DeserializeObject<Dictionary<string, SandboxScheme>>(text2);
						text2 = SerializeObject(ActiveComponent.Model.P.extraUnlockedAlgos);
						foreach (string[] replaceOldHash4 in replaceOldHashes)
						{
							text2 = text2.Replace(replaceOldHash4[1], replaceOldHash4[0]);
						}
						text2 = text2.Replace("'", "");
						ActiveComponent.Model.P.extraUnlockedAlgos = DeserializeObject<List<string>>(text2);
						string text3 = SerializeObject(ActiveComponent.Model.P.watchBlockTutorials);
						foreach (string[] replaceQuestHash in replaceQuestHashes)
						{
							text3 = text3.Replace(replaceQuestHash[1], replaceQuestHash[0]);
						}
						text3 = text3.Replace("'", "");
						ActiveComponent.Model.P.watchBlockTutorials = DeserializeObject<Dictionary<string, int>>(text3);
						ActiveComponent.Model.P.startupsStatsString = new Dictionary<string, StartupStat>();
						foreach (KeyValuePair<int, StartupStat> startupsStat in ActiveComponent.Model.P.startupsStats)
						{
							foreach (string[] replaceQuestHash2 in replaceQuestHashes)
							{
								if (Convert.ToInt32(replaceQuestHash2[1]) == startupsStat.Key)
								{
									ActiveComponent.Model.P.startupsStatsString.Add(replaceQuestHash2[0], Clone<StartupStat>(startupsStat.Value));
								}
							}
						}
					}
					foreach (StartupScheme startup in ActiveComponent.Model.P.Startups)
					{
						if (startup.lastFailed.Count > 7)
						{
							startup.lastFailed = startup.lastFailed.GetRange(startup.lastFailed.Count - 7, 7);
						}
					}
					QuestLine.Deserialize(array[2]);
				}
			}
			catch (Exception ex2)
			{
				Debug.LogError(ex2.Message);
				PersistentData persistentData = new PersistentData();
				persistentData.upgradeStats = new UpgradeStats();
				persistentData.unlockedCatHats.Add(ActiveComponent._staticData.CatCost[0]);
				persistentData.ShowFastMailTask = null;
				ActiveComponent.Model.P = persistentData;
				ActiveComponent.Model.P.version = Program.GetVersionString();
				InitSession(ActiveComponent.Model.curPreview);
				Debug.Log("JSON serialize failed! Reason: " + ex2.Message);
				return;
			}
		}
		else
		{
			PersistentData persistentData2 = new PersistentData();
			persistentData2.upgradeStats = new UpgradeStats();
			persistentData2.unlockedCatHats.Add(ActiveComponent._staticData.CatCost[0]);
			persistentData2.ShowFastMailTask = null;
			persistentData2.version = Program.GetVersionString();
			ActiveComponent.Model.P = persistentData2;
			InitSession(ActiveComponent.Model.curPreview);
			Comics comics = ActiveComponent._staticData.Comicses[0];
			QuestLine.UpdateOrAddQuest(comics);
			ActiveComponent.Model.curPreview.MakeQuestAvailable(comics.KeyName);
			num = Helper.VersionStringToInt(ActiveComponent.Model.P.version);
		}
		ActiveComponent.Model.P.unlockedCatHats.RemoveAll((CatVR o) => o == null);
		ApplyPromoCats();
		if (num < 3042)
		{
			ActiveComponent.Model.P.ShowFastMailTask = QuestLine.GetCurrentQuest();
			foreach (CarQuest carQuest in ActiveComponent._staticData.CarQuests)
			{
				QuestLine.Quest quest = QuestLine.GetQuest(carQuest.KeyName);
				if (quest != null)
				{
					quest.quest = Clone<CarQuest>(carQuest);
					quest.cathub = new Cathub();
				}
			}
		}
		foreach (Comics comicse in ActiveComponent._staticData.Comicses)
		{
			QuestLine.Quest quest2 = QuestLine.GetQuest(comicse.KeyName);
			if (UnlockGroup.IsUnlocked(comicse.ReqUnlockGroups) || (quest2 != null && quest2.IsTaskOpened()))
			{
				QuestLine.UpdateOrAddQuest(comicse);
			}
		}
		foreach (ForumQuest forumQuest in ActiveComponent._staticData.ForumQuests)
		{
			QuestLine.Quest quest3 = QuestLine.GetQuest(forumQuest.KeyName);
			if (UnlockGroup.IsUnlocked(forumQuest.ReqUnlockGroups) || (quest3 != null && quest3.IsTaskOpened()))
			{
				QuestLine.UpdateOrAddQuest(forumQuest);
			}
		}
		foreach (ConstructionQuest quest6 in ActiveComponent._staticData.Quests)
		{
			QuestLine.Quest quest4 = QuestLine.GetQuest(quest6.KeyName);
			if (UnlockGroup.IsUnlocked(quest6.ReqUnlockGroups) || (quest4 != null && quest4.IsTaskOpened()))
			{
				QuestLine.UpdateOrAddQuest(quest6);
			}
		}
		foreach (CarQuest carQuest2 in ActiveComponent._staticData.CarQuests)
		{
			QuestLine.Quest quest5 = QuestLine.GetQuest(carQuest2.KeyName);
			if (UnlockGroup.IsUnlocked(carQuest2.ReqUnlockGroups) || (quest5 != null && quest5.IsTaskOpened()))
			{
				QuestLine.UpdateOrAddQuest(carQuest2);
			}
		}
		foreach (string item in QuestLine.GetListCompleted())
		{
			ActiveComponent.Model.curPreview.MakeQuestAvailable(item);
			ActiveComponent.Model.curPreview.MakeQuestDone(item);
		}
		if (ActiveComponent.Model.P.ShowFastMailTask != null && !QuestLine.IsLoadedInMemory(ActiveComponent.Model.P.ShowFastMailTask.GetName()))
		{
			ActiveComponent.Model.P.ShowFastMailTask = null;
		}
		if (num < 4054)
		{
			ActiveComponent.Model.P.startupsStatsString = new Dictionary<string, StartupStat>();
			foreach (string usedStartup in ActiveComponent.Model.P.usedStartups)
			{
				Startup startupByKeyName = GetStartupByKeyName(usedStartup);
				ActiveComponent.Model.P.startupsStatsString.Add(usedStartup, new StartupStat(startupByKeyName.SharesCou * startupByKeyName.ShareCost));
			}
		}
		if (num < 4057)
		{
			foreach (Startup item2 in ActiveComponent.Model.P.startupQueue)
			{
				Startup startupByKeyName2 = GetStartupByKeyName(item2.KeyName);
				if (item2 != null)
				{
					item2.Texts = startupByKeyName2.Texts;
				}
				else if (item2.Texts == "")
				{
					item2.Texts = item2.KeyName;
				}
			}
			foreach (StartupScheme startup2 in ActiveComponent.Model.P.Startups)
			{
				Startup startupByKeyName3 = GetStartupByKeyName(startup2.baseStartup.KeyName);
				if (startup2 != null)
				{
					startup2.baseStartup.Texts = startupByKeyName3.Texts;
				}
				else if (startup2.baseStartup.Texts == "")
				{
					startup2.baseStartup.Texts = startup2.baseStartup.KeyName;
				}
			}
		}
		if (num < 4059)
		{
			ActiveComponent.Model.P.startupTutorial = 1;
		}
		foreach (ConstructionBlock constructionBlock in ActiveComponent._staticData.ConstructionBlocks)
		{
			ActiveComponent.Model.P.watchBlockTutorials.TryAdd(constructionBlock.KeyName, 0);
		}
		foreach (CarQuest carQuest3 in ActiveComponent._staticData.CarQuests)
		{
			QuestLine.GetQuest(carQuest3.KeyName);
		}
		SendAnalytics("SESSION_START", new Dictionary<string, object>(), addDynamicGroup: true);
	}

	public static Controller GetController()
	{
		return ActiveComponent._controller;
	}

	public static SoundSystem GetSound()
	{
		return ActiveComponent.Sound;
	}

	public static Model GetModel()
	{
		return ActiveComponent.Model;
	}

	public static Program GetProgram()
	{
		return ActiveComponent.Program;
	}

	public static DateEvent GetCurDateEvent()
	{
		foreach (DateEvent dateEvent in ActiveComponent._staticData.DateEvents)
		{
			if (dateEvent.IsValid())
			{
				return dateEvent;
			}
		}
		return null;
	}

	public static string GetDefaultTag()
	{
		DateEvent curDateEvent = GetCurDateEvent();
		if (curDateEvent == null)
		{
			return "DEFAULT";
		}
		return curDateEvent.KeyName;
	}

	public static bool UpdateCursorCanvasStatus(ref bool prevOpenedDropdownState, ref bool closing, Dropdown dropdown, int normalChildCount = 3)
	{
		bool flag = dropdown.transform.childCount != normalChildCount;
		if (!prevOpenedDropdownState && flag)
		{
			customNav.mode = Navigation.Mode.None;
			dropdown.navigation = customNav;
			prevOpenedDropdownState = flag;
			GameObject gameObject = (openedCanvas = dropdown.gameObject.transform.GetChild(dropdown.transform.childCount - 1).gameObject);
			Transform root = dropdown.transform.root;
			Transform child = dropdown.transform.root.GetChild(root.transform.childCount - 1);
			child.GetComponent<Button>().navigation = customNav;
			currentBlocker = child.gameObject;
			openedDropdown = dropdown;
			ActiveComponent.Program.cursor.SetCanvas(gameObject);
			Toggle[] componentsInChildren = gameObject.GetComponentsInChildren<Toggle>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].navigation = customNav;
			}
			return false;
		}
		if (prevOpenedDropdownState && !flag)
		{
			prevOpenedDropdownState = flag;
			openedDropdown = null;
			openedCanvas = null;
			ActiveComponent.Program.cursor.SetCanvas(null);
			closing = true;
			return true;
		}
		return false;
	}

	public static Vector3 GetMousePosition()
	{
		Vector3 result = Vector3.zero;
		if (ActiveComponent.Program.cursor.Visible())
		{
			result = Program.mainCam.WorldToScreenPoint(ActiveComponent.Program.cursor.transform.position);
		}
		else
		{
			result.Set(Input.mousePosition.x, Input.mousePosition.y, 0f);
		}
		return result;
	}

	public static Vector3 ModifySliderMoveDelta(Vector3 defaultDelta)
	{
		return defaultDelta * sliderMultSpeed;
	}

	public static Vector3 GetCursorInWorld()
	{
		Vector3 zero = Vector3.zero;
		if (ActiveComponent.Program.cursor.Visible())
		{
			return ActiveComponent.Program.cursor.transform.position;
		}
		return InputSystem.GetCursorInWorld();
	}

	public static Vector3 GetMouseInWorld()
	{
		Vector3 zero = Vector3.zero;
		if (ActiveComponent.Program.cursor.Visible())
		{
			return ActiveComponent.Program.cursor.transform.position;
		}
		return InputSystem.GetMouseInWorld();
	}

	public static StaticData GetStaticData()
	{
		return ActiveComponent._staticData;
	}

	public static void ApplyPromoCats()
	{
		foreach (string i in ActiveComponent.Model.globalSaves.unlockedPromoCats)
		{
			if (ActiveComponent.Model.P.unlockedCatHats.FindIndex((CatVR s) => s.KeyName.ToLower() == i.ToLower()) < 0)
			{
				ActiveComponent.Model.P.unlockedCatHats.Add(GetPromocatByKeyName(i.ToLower()));
				ActiveComponent.Model.P.curCat = ActiveComponent.Model.P.unlockedCatHats.Count - 1;
			}
		}
	}

	public static string RoundFloatTostr(float f)
	{
		return (int)(f * 10f) / 10 + "." + (int)(f * 10f) % 10;
	}

	public static void TryJson()
	{
		JsonConvert.DeserializeObject<QuestLine.Quest>(JsonConvert.SerializeObject(null, Formatting.None, GetGlobalSettings()), GetGlobalSettings());
	}

	public static void SendAnalytics(string key, Dictionary<string, object> dict, bool addDynamicGroup = false)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (addDynamicGroup)
		{
			dictionary.Add("levels_complete_count", QuestLine.GetNumCompleted());
			dictionary.Add("active_startups_count", ActiveComponent.Model.P.Startups.Count);
			dictionary.Add("total_startups_count", ActiveComponent.Model.P.removedStartups.Count + ActiveComponent.Model.P.Startups.Count);
			dictionary.Add("cohort_day", ActiveComponent.Model.globalSaves.cohort_day);
			dictionary.Add("checkpoint", ActiveComponent.Model.curPreview.startCheckpointKeyName);
			dictionary.Add("source", "steam");
		}
		GetProgram().amp.Event(key, dict, dictionary);
		if (addDynamicGroup)
		{
			dictionary.Add("version", Program.GetShortVersion());
		}
		foreach (string key2 in dictionary.Keys)
		{
			dict.Add(key2, dictionary[key2]);
		}
	}

	public static bool LoadOrCreateGlobalSaves(string KEY = "WTL_saves_global")
	{
		GlobalSaves globalSaves = null;
		string text = LoadSaveGame(KEY);
		if (text != null && text.Length > 0)
		{
			Helper.VersionStringToInt(Program.GetVersionString());
			try
			{
				globalSaves = JsonConvert.DeserializeObject<GlobalSaves>(text, GetGlobalSettings());
				foreach (PreviewData item in globalSaves.Preview)
				{
					if (item.qinfo.Count == 0)
					{
						item.date.Set();
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.Message);
			}
		}
		bool result = false;
		if (globalSaves == null)
		{
			globalSaves = new GlobalSaves();
			globalSaves.newGames = 0;
			globalSaves.musicVolume = 1f;
			globalSaves.soundVolume = 1f;
			globalSaves.vibration = 3;
			globalSaves.passedTasks = new Dictionary<string, int>();
			try
			{
				globalSaves.cohort_day = DateTime.Now.DayOfYear;
				globalSaves.cohort_month = DateTime.Now.Month;
			}
			catch
			{
				globalSaves.cohort_day = DateTime.UtcNow.DayOfYear;
				globalSaves.cohort_month = DateTime.UtcNow.Month;
			}
			globalSaves.cohort_week = GetWeekNumber();
			globalSaves.user_id_ab = SecondsSinceEpoch();
			globalSaves.version = Program.GetVersionString();
			result = true;
		}
		if (globalSaves.user_id_ab <= -1)
		{
			globalSaves.user_id_ab = SecondsSinceEpoch();
		}
		if (globalSaves.passedTasksCou == null)
		{
			globalSaves.passedTasksCou = new Dictionary<string, int>();
			foreach (ConstructionQuest quest in ActiveComponent._staticData.Quests)
			{
				globalSaves.passedTasksCou.Add(quest.KeyName, 0);
			}
			foreach (CarQuest carQuest in ActiveComponent._staticData.CarQuests)
			{
				globalSaves.passedTasksCou.Add(carQuest.KeyName, 0);
			}
		}
		ActiveComponent.Model.globalSaves = globalSaves;
		UpdateGlobalSaves();
		return result;
	}

	public static int SecondsSinceEpoch()
	{
		DateTime value = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
		DateTime dateTime = DateTime.UtcNow;
		try
		{
			dateTime = DateTime.Now;
		}
		catch
		{
		}
		return Convert.ToInt32(dateTime.Subtract(value).TotalSeconds);
	}

	public static int GetWeekNumber()
	{
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		int num = 0;
		try
		{
			return invariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		}
		catch
		{
			return invariantCulture.Calendar.GetWeekOfYear(DateTime.UtcNow, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		}
	}

	public static Encoding GetSaveEncoding()
	{
		return Encoding.UTF8;
	}

	public static byte[] ReadSaveFromFile(string pathFile)
	{
		FileStream fileStream = File.Open(pathFile, FileMode.Open);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		return array;
	}

	public static string SerializeObject(object obj)
	{
		return JsonConvert.SerializeObject(obj, Formatting.None, GetGlobalSettings());
	}

	public static T DeserializeObject<T>(string json)
	{
		return JsonConvert.DeserializeObject<T>(json, GetGlobalSettings());
	}

	private void OnApplicationQuit()
	{
		if (saveThread != null && saveThread.IsAlive)
		{
			saveThread.Join();
		}
	}

	public static int GetPreviewIdWithSaveKey(string saveKey)
	{
		int num = 0;
		foreach (PreviewData item in ActiveComponent.Model.globalSaves.Preview)
		{
			if (item.saveName == saveKey)
			{
				return num;
			}
			num++;
		}
		return num;
	}

	public static bool IsSteamRunning()
	{
		return Steam.IsInitialized();
	}

	public static bool IsSteamDeckRunning()
	{
		if (!Steam.IsInitialized())
		{
			return false;
		}
		return SteamUtils.IsSteamRunningOnSteamDeck();
	}

	public static void UpdateGameSaves(int autoSaved = 1)
	{
		nintendoCommitCounter++;
		ActiveComponent.Model.curPreview.autoSaved = autoSaved;
		ActiveComponent.Model.P.Startups.ForEach(delegate(StartupScheme i)
		{
			i.ClearToSave();
		});
		ActiveComponent.Model.P.unityVersion = Application.unityVersion;
		if (autoSaved == 1)
		{
			ActiveComponent.Model.curPreview.info = TextResources.GetString("AUTOSAVE");
			ActiveComponent.Model.globalSaves.Preview.ForEach(delegate(PreviewData i)
			{
				i.isLastRun = 0;
			});
			ActiveComponent.Model.curPreview.date.Set();
			ActiveComponent.Model.curPreview.money = ActiveComponent.Model.P.Money;
			ActiveComponent.Model.curPreview.startupsNumber = ActiveComponent.Model.P.Startups.Count;
			ActiveComponent.Model.curPreview.version = Program.GetVersionString();
			ActiveComponent.Model.curPreview.isLastRun = 1;
			ActiveComponent.Model.curPreview.buggleScore = QuestLine.GetSumScore();
			if (saveThread == null || !saveThread.IsAlive)
			{
				saveThread = new Thread(UpdateGameSaves_);
				restartSave = false;
				saveCompleted = false;
				saveFailed = 0;
				saveThread.Start();
			}
			else if (saveCompleted)
			{
				saveThread.Join();
				saveThread = new Thread(UpdateGameSaves_);
				restartSave = false;
				saveCompleted = false;
				saveFailed = 0;
				saveThread.Start();
			}
			else
			{
				restartSave = true;
				saveCompleted = false;
				saveFailed = 0;
			}
		}
		else
		{
			if (saveThread != null && saveThread.IsAlive)
			{
				saveThread.Join();
			}
			restartSave = false;
			saveCompleted = false;
			UpdateGameSaves_();
		}
	}

	private static void UpdateGameSaves_()
	{
		string text = GetSaveNameTemplate(playerPostfix: false) + ActiveComponent.Model.curPreview.saveName;
		ActiveComponent.Model.P.version = Program.GetVersionString();
		SaveHeader saveHeader = default(SaveHeader);
		saveHeader.m = "WTL!";
		saveHeader.v = Program.GetVersionInt();
		try
		{
			saveHeader.date = DateTime.Now;
		}
		catch
		{
			saveHeader.date = DateTime.UtcNow;
		}
		string empty = string.Empty;
		try
		{
			if (restartSave)
			{
				restartSave = false;
				UpdateGameSaves_();
				return;
			}
			empty = SerializeObject(saveHeader);
			empty += Convert.ToChar(3);
			if (restartSave)
			{
				restartSave = false;
				UpdateGameSaves_();
				return;
			}
			empty += SerializeObject(ActiveComponent.Model.P);
			empty += Convert.ToChar(3);
			if (restartSave)
			{
				restartSave = false;
				UpdateGameSaves_();
				return;
			}
			empty += QuestLine.Serialize();
		}
		catch (Exception ex)
		{
			if (restartSave)
			{
				restartSave = false;
				UpdateGameSaves_();
				return;
			}
			Debug.Log("JSON serialize failed! Reason: " + ex.Message);
			if (saveThread != null && saveThread.IsAlive)
			{
				saveFailed++;
				if (saveFailed < 3)
				{
					UpdateGameSaves_();
				}
			}
			return;
		}
		if (restartSave)
		{
			restartSave = false;
			UpdateGameSaves_();
			return;
		}
		WriteSaveGame(text, empty);
		if (restartSave)
		{
			restartSave = false;
			UpdateGameSaves_();
			return;
		}
		UpdateGlobalSaves();
		if (restartSave)
		{
			restartSave = false;
			UpdateGameSaves_();
		}
		else
		{
			saveCompleted = true;
		}
	}

	public static Cheat GetCheatByKeyName(string keyName)
	{
		return GetSmthByKeyName(keyName, ActiveComponent._staticData.Cheats);
	}

	public static bool IsCheatActivated(string keyName)
	{
		Cheat cheatByKeyName = GetCheatByKeyName(keyName);
		if (cheatByKeyName != null)
		{
			return ActiveComponent.Model.activatedCheats.Contains(cheatByKeyName.showName.ToUpper());
		}
		return false;
	}

	public static void SavePData(PersistentData p, string KEY = "WTL_saves", int autoSaved = 1)
	{
		string json = JsonConvert.SerializeObject(p, Formatting.None, GetGlobalSettings());
		WriteSaveGame(KEY, json);
		UpdateGlobalSaves();
	}

	public static PersistentData DeepCloneSaveByKeyName(string KeyName)
	{
		return JsonConvert.DeserializeObject<PersistentData>(JsonConvert.SerializeObject(ActiveComponent.Model.P, Formatting.None, GetGlobalSettings()), GetGlobalSettings());
	}

	public static PreviewData DeepClonePreviewData(PreviewData pr)
	{
		return JsonConvert.DeserializeObject<PreviewData>(JsonConvert.SerializeObject(pr, Formatting.None, GetGlobalSettings()), GetGlobalSettings());
	}

	public static void SortCredits()
	{
		for (int i = 0; i < ActiveComponent.Model.P.credits.Count; i++)
		{
			for (int j = 1; j < ActiveComponent.Model.P.credits.Count; j++)
			{
				if (ActiveComponent.Model.P.credits[j - 1].DaysBack > ActiveComponent.Model.P.credits[j].DaysBack)
				{
					Credit value = ActiveComponent.Model.P.credits[j - 1];
					ActiveComponent.Model.P.credits[j - 1] = ActiveComponent.Model.P.credits[j];
					ActiveComponent.Model.P.credits[j] = value;
				}
			}
		}
	}

	public static void AddTextToBestFitQueue(Text text)
	{
		bestFitsUpdte.Add(text);
	}

	private void FixedUpdate()
	{
		if (bestFitsUpdte.Count <= 0)
		{
			return;
		}
		foreach (Text item in bestFitsUpdte)
		{
			item.resizeTextForBestFit = true;
		}
		bestFitsUpdte.Clear();
	}

	public static void UpdateGlobalSaves(string KEY = "WTL_saves_global")
	{
		string json = SerializeObject(ActiveComponent.Model.globalSaves);
		WriteSaveGame(KEY, json);
	}

	public static byte[] GetNativeSaveData(string text, Encoding encoding)
	{
		byte[] array = LZF.Compress(encoding.GetBytes(text.ToCharArray()));
		byte[] array2 = MD5.Create().ComputeHash(array);
		byte[] array3 = new byte[array.Length + array2.Length];
		Buffer.BlockCopy(array2, 0, array3, 0, array2.Length);
		Buffer.BlockCopy(array, 0, array3, array2.Length, array.Length);
		return array3;
	}

	private static byte[] GetByteSaveData(byte[] bytes, bool compressed = false)
	{
		byte[] array = new byte[16];
		int num = bytes.Length - array.Length;
		byte[] array2 = new byte[num];
		Buffer.BlockCopy(bytes, 0, array, 0, array.Length);
		Buffer.BlockCopy(bytes, array.Length, array2, 0, num);
		byte[] second = MD5.Create().ComputeHash(array2);
		if (!array.SequenceEqual(second))
		{
			return null;
		}
		if (!compressed)
		{
			return LZF.Decompress(array2);
		}
		return array2;
	}

	public static string GetTextSaveData(byte[] bytes, Encoding encoding)
	{
		byte[] byteSaveData = GetByteSaveData(bytes);
		if (byteSaveData == null)
		{
			return string.Empty;
		}
		return encoding.GetString(byteSaveData);
	}

	public static string GetSaveGameFilePath(string saveName)
	{
		return Program.GetSaveGamePath() + saveName;
	}

	public static bool DeleteSave(string name = "WTL_saves")
	{
		string saveGameFilePath = GetSaveGameFilePath(name);
		if (File.Exists(saveGameFilePath))
		{
			File.Delete(saveGameFilePath);
			return true;
		}
		return false;
	}

	public static FileInfo[] GetLocalSaveGames()
	{
		return new DirectoryInfo(Program.GetSaveGamePath())?.GetFiles();
	}

	public static int DeleteAllSaves()
	{
		int num = 0;
		FileInfo[] localSaveGames = GetLocalSaveGames();
		foreach (FileInfo fileInfo in localSaveGames)
		{
			if (!fileInfo.Name.Contains("WTL_saves_global"))
			{
				fileInfo.Delete();
				num++;
			}
		}
		return num;
	}

	public static bool DoesSaveExist(string name = "WTL_saves")
	{
		if (Steam.LoadFromCloud(name, GetSaveEncoding()).Length > 0)
		{
			return true;
		}
		return DoesSaveFileExist(name);
	}

	public static bool DoesSaveFileExist(string name)
	{
		return File.Exists(GetSaveGameFilePath(name));
	}

	public static void WriteSaveGame(string name, string json)
	{
		string saveGameFilePath = GetSaveGameFilePath(name);
		byte[] nativeSaveData = GetNativeSaveData(json, GetSaveEncoding());
		File.WriteAllBytes(saveGameFilePath, nativeSaveData);
		if (!ForceNoCloud)
		{
			Steam.SaveToCloud(name, json, GetSaveEncoding());
		}
	}

	public static string LoadSaveGame(string name, bool skipCloud = false)
	{
		string empty = string.Empty;
		if (!ForceNoCloud && !skipCloud)
		{
			empty = Steam.LoadFromCloud(name, GetSaveEncoding());
			if (empty.Length > 0)
			{
				return empty;
			}
		}
		if (DoesSaveFileExist(name))
		{
			string saveGameFilePath = GetSaveGameFilePath(name);
			try
			{
				string textSaveData = GetTextSaveData(File.ReadAllBytes(saveGameFilePath), GetSaveEncoding());
				if (textSaveData.Length != 0)
				{
					return textSaveData;
				}
				Debug.LogError("Save game corrupted: " + saveGameFilePath);
				MessageBox.Warning("SAVEGAMEPROBLEM", "SAVEGAMECORRUPTED");
			}
			catch (Exception ex)
			{
				Debug.LogError("Failed reading save: " + saveGameFilePath + ". Reason: " + ex.ToString());
				MessageBox.Warning("SAVEGAMEPROBLEM");
			}
		}
		empty = PlayerPrefs.GetString(name);
		if (empty.Length > 0)
		{
			WriteSaveGame(name, empty);
			return empty;
		}
		return string.Empty;
	}

	public static string LoadLocalSaveGame(string name)
	{
		return LoadSaveGame(name, skipCloud: true);
	}

	public static string LoadCloudSaveGame(string name)
	{
		return LoadSaveGame(name);
	}

	public static int SyncLocalSavesWithCloud()
	{
		int num = 0;
		FileInfo[] localSaveGames = GetLocalSaveGames();
		foreach (FileInfo fileInfo in localSaveGames)
		{
			byte[] byteSaveData = GetByteSaveData(ReadSaveFromFile(fileInfo.FullName), compressed: true);
			if (Steam.SaveToCloud(fileInfo.Name, byteSaveData))
			{
				num++;
				Steam.Print(num + ".) save uploaded: " + fileInfo.FullName);
			}
		}
		return num;
	}

	public static int GetNumSaves()
	{
		return Math.Max(Steam.GetNumSavesInCloud(), GetLocalSaveGames().Length);
	}

	public static void StartupResult(int id)
	{
	}

	public static void DeleteStartup(int id)
	{
		ActiveComponent.Model.P.startupsPrevVers.RemoveAt(id);
	}

	public static App.Data.Data GetDataByKeyName(string kn)
	{
		if (hashedDatas.ContainsKey(kn))
		{
			return hashedDatas[kn];
		}
		App.Data.Data data = ActiveComponent._staticData.Datas.Find((App.Data.Data o) => o.KeyName == kn);
		hashedDatas.Add(kn, data);
		return data;
	}

	public static bool isBuyBlockUnwatched(string KeyName)
	{
		if (ActiveComponent.Model.P.watchedShop.ContainsKey(KeyName))
		{
			return ActiveComponent.Model.P.watchedShop[KeyName] == 0;
		}
		return true;
	}

	public static int GetUnwatchedBlocks()
	{
		int num = 0;
		foreach (ConstructionBlock constructionBlock in ActiveComponent._staticData.ConstructionBlocks)
		{
			if (constructionBlock.CanBuy && UnlockGroup.IsUnlocked(constructionBlock.ReqUnlockGroups) && isBuyBlockUnwatched(constructionBlock.KeyName))
			{
				num++;
			}
		}
		return num;
	}

	public static int GetUnwatchedOthers()
	{
		int num = 0;
		foreach (InteriorItem shopItem in ActiveComponent._staticData.ShopItems)
		{
			if (UnlockGroup.IsUnlocked(shopItem.ReqUnlockGroups) && shopItem.CanBuy && isBuyBlockUnwatched(shopItem.KeyName))
			{
				num++;
			}
		}
		return num;
	}

	public static string GetPromoText(string code)
	{
		if (TextResources.IsKeyExists(code + "PROMO"))
		{
			return ColorTransform("GOOD", TextResources.GetString(code + "PROMO"));
		}
		PromoCode promo = ActiveComponent._staticData.PromoCodes.Find((PromoCode i) => i.KeyName.ToUpper() == code.ToUpper());
		if (ActiveComponent._staticData.PromoCats.FindIndex((CatVR i) => i.KeyName.ToUpper() == promo.ItemUnlock.ToUpper()) >= 0)
		{
			return ColorTransform("GOOD", TextResources.GetString("DEFAULT_PROMO_TEXT"));
		}
		if (ActiveComponent._staticData.Themes.FindIndex((BaseItem i) => i.KeyName.ToUpper() == promo.ItemUnlock.ToUpper() && i.isPromo) >= 0)
		{
			return ColorTransform("GOOD", TextResources.GetString("DEFAULT_PROMO_TEXT_THEME"));
		}
		return ColorTransform("GOOD", TextResources.GetString("DEFAULT_PROMO_TEXT"));
	}

	public static int GetUnwatchedHats()
	{
		int num = 0;
		foreach (CatVR item in ActiveComponent._staticData.CatCost)
		{
			if (item.KeyName != "DEFAULTCAT" && UnlockGroup.IsUnlocked(item.ReqUnlockGroups) && item.VisibleToPlayer && isBuyBlockUnwatched(item.KeyName))
			{
				num++;
			}
		}
		foreach (CatVR promoCat in ActiveComponent._staticData.PromoCats)
		{
			if (UnlockGroup.IsUnlocked(promoCat.ReqUnlockGroups) && promoCat.VisibleToPlayer && isBuyBlockUnwatched(promoCat.KeyName))
			{
				num++;
			}
		}
		return num;
	}

	public static int GetUnwatchedHardware()
	{
		int num = 0;
		foreach (UpgradeStats pCUpgrade in ActiveComponent._staticData.PCUpgrades)
		{
			if (UnlockGroup.IsUnlocked(pCUpgrade.ReqUnlockGroups) && isBuyBlockUnwatched(pCUpgrade.KeyName) && pCUpgrade.CanBuy && isBuyBlockUnwatched(pCUpgrade.KeyName))
			{
				num++;
			}
		}
		return num;
	}

	public static int GetUnwatchedShop()
	{
		return GetUnwatchedBlocks() + GetUnwatchedHardware() + GetUnwatchedHats() + GetUnwatchedOthers();
	}

	public static App.Data.Result GetResultByKeyName(string kn)
	{
		return ActiveComponent._staticData.Results.Find((App.Data.Result i) => i.KeyName == kn);
	}

	public static int GetTaskNumByKeyName(string KeyName)
	{
		int num = ActiveComponent._staticData.Quests.FindIndex((ConstructionQuest i) => i.KeyName == KeyName);
		if (num >= 0)
		{
			return num;
		}
		return 0;
	}

	public static ConstructionQuest GetTaskByKeyName(string KeyName)
	{
		return GetBaseQuestByKeyName(KeyName).As<ConstructionQuest>();
	}

	public static T GetStaticDataQuest<T>(QuestLine.Quest quest, string name) where T : BaseQuest
	{
		BaseQuest baseQuest = null;
		BaseQuest quest2 = quest.quest;
		if (quest2.Is<T>())
		{
			baseQuest = GetTaskByKeyName(name);
		}
		else if (quest2.Is<T>())
		{
			baseQuest = GetCarQuestByKeyName(name);
		}
		else if (quest2.Is<T>())
		{
			baseQuest = GetComicsByKeyName(name);
		}
		if (baseQuest == null)
		{
			return null;
		}
		return baseQuest.As<T>();
	}

	public static string DataQuest(ConstructionQuest cq, int id)
	{
		return id switch
		{
			0 => cq.Data0, 
			1 => cq.Data1, 
			2 => cq.Data2, 
			3 => cq.Data3, 
			4 => cq.Data4, 
			_ => "", 
		};
	}

	public static bool CreditUnlocked(Credit cr)
	{
		if (cr.MinDepth < ActiveComponent.Model.P.credits.Count || cr.MaxDepth > ActiveComponent.Model.P.credits.Count)
		{
			return false;
		}
		return UnlockGroup.IsUnlocked(cr.ReqUnlockGroups);
	}

	public static Credit GetRandomCredit()
	{
		List<Credit> list = new List<Credit>();
		foreach (Credit credit in ActiveComponent._staticData.Credits)
		{
			if (CreditUnlocked(credit))
			{
				list.Add(credit);
			}
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		return null;
	}

	public static string ResultQuest(ConstructionQuest cq, int id)
	{
		return id switch
		{
			0 => cq.Res0, 
			1 => cq.Res1, 
			2 => cq.Res2, 
			3 => cq.Res3, 
			4 => cq.Res4, 
			_ => "", 
		};
	}

	public static float GetChainTime()
	{
		return ActiveComponent._staticData.Settings.TimeOnLine / (1f + ActiveComponent.Model.P.upgradeStats.ChainSpeedBonus);
	}

	public static int GetColorIdByKeyName(string kn)
	{
		if (colorKeyToColorId.ContainsKey(kn))
		{
			return colorKeyToColorId[kn];
		}
		int num = ActiveComponent._staticData.Colors.FindIndex((ElementColor i) => i.KeyName == kn);
		colorKeyToColorId.Add(kn, num);
		return num;
	}

	public static string WordToString(List<char> word, int prefixLen = -1)
	{
		string text = "";
		int num = 0;
		foreach (char item in word)
		{
			text += item;
			if (prefixLen != -1)
			{
				if (num == prefixLen)
				{
					break;
				}
				num++;
			}
		}
		return text;
	}

	public static int GetSchemeUsersDayCapacity(SchemeBlock scheme)
	{
		if (scheme == null)
		{
			return 0;
		}
		scheme.Marking();
		int blockCou = GetBlockCou(scheme);
		int socketsCou = scheme.GetSocketsCou();
		int num = blockCou + socketsCou * GetCurSocketDepth();
		socketsCou = scheme.GetMaxElementsOnLines();
		return num + scheme.GetMaxElementsOnLines();
	}

	public static int GetScoreFromCurConstructuion()
	{
		QuestLine.Quest quest = QuestLine.GetCurrentQuest();
		if (ActiveComponent.Model.construction.constrState == ConstructionState.Forum)
		{
			quest = QuestLine.GetQuest(quest.GetForumQuest().QuestKeyName);
		}
		if (CheckConditions((QuestCondition)quest.GetCondition(quest.GetCurCondition()), ActiveComponent.Model.construction))
		{
			return quest.GetCurCondition() + 1;
		}
		return 0;
	}

	public static int GetSchemeUsersDayCapacity(Construction constr)
	{
		return GetSchemeUsersDayCapacity(CreateSchemeFromCurrentState(constr));
	}

	public static int GetBlockCou(SchemeBlock scheme)
	{
		return scheme.GetBlocksCou(startup: true, 1);
	}

	public static SchemeBlock CreateSchemeFromCurrentState(Construction constr)
	{
		constr.InitSocketsNums();
		SchemeBlock schemeBlock = new SchemeBlock();
		schemeBlock.InitOnLoad(schemeBlock);
		schemeBlock.Init(constr);
		return schemeBlock;
	}

	public static int GetBlockCou(Construction constr)
	{
		return GetBlockCou(CreateSchemeFromCurrentState(constr));
	}

	public static Sprite GetSpriteByKeyName(string keyName)
	{
		if (ActiveComponent.Model.sprites.ContainsKey(keyName))
		{
			return ActiveComponent.Model.sprites[keyName];
		}
		Sprite sprite = LoadSprite(keyName);
		ActiveComponent.Model.sprites.Add(keyName, sprite);
		return sprite;
	}

	public static string GetNextImmediatelyQuest(string curQuestEnd)
	{
		if (immediatelyRunQuestPairs == null)
		{
			immediatelyRunQuestPairs = new Dictionary<int, string>();
			string[] array = ActiveComponent._staticData.Settings.ImmediatelyRunQuestPairs.Split(';');
			foreach (string text in array)
			{
				if (text != "")
				{
					string[] array2 = text.Split(',');
					immediatelyRunQuestPairs.Add(array2[0].GetHashCode(), array2[1]);
				}
			}
		}
		int hashCode = curQuestEnd.GetHashCode();
		if (immediatelyRunQuestPairs.ContainsKey(hashCode))
		{
			return immediatelyRunQuestPairs[hashCode];
		}
		return null;
	}

	public static Sprite LoadSprite(string Path)
	{
		if (!loadedSprites.ContainsKey(Path))
		{
			loadedSprites.Add(Path, Resources.Load<Sprite>("Art/" + Path));
		}
		return loadedSprites[Path];
	}

	public static string MinMaxEqualValueStringForCondition(float min, float max, string val, string keyColor)
	{
		if (min >= max || min < 0f || max < 0f)
		{
			return ColorTransform(keyColor, min + val);
		}
		return ColorTransform(keyColor, min.ToString()) + " - " + ColorTransform(keyColor, max + val);
	}

	public static QuestCondition GetConditionByKeyName(string KeyName)
	{
		return ActiveComponent._staticData.Conditions.Find((QuestCondition i) => i.KeyName == KeyName);
	}

	public static int GetShapeIdByKeyName(string kn)
	{
		return ActiveComponent._staticData.Shapes.FindIndex((ElementShape i) => i.KeyName == kn);
	}

	public static float GetCurServersCostInsecond()
	{
		return (float)ActiveComponent._staticData.Settings.ServerCost * (1f - ActiveComponent.Model.P.upgradeStats.ServersCostBonus);
	}

	public static GameObject LoadPrefab(string keyName, bool block = true)
	{
		if (!loadedPrefabs.ContainsKey(keyName))
		{
			GameObject gameObject = Resources.Load(GetPrefabPath(keyName, block)) as GameObject;
			if (gameObject != null)
			{
				gameObject.name = keyName;
			}
			else
			{
				gameObject = Resources.Load("Prefabs/" + keyName) as GameObject;
			}
			loadedPrefabs.Add(keyName, gameObject);
			return gameObject;
		}
		return loadedPrefabs[keyName];
	}

	public static Color GetPercColor(float perc)
	{
		if (goodColor == Color.white)
		{
			badColor = GetColor(0);
			goodColor = GetColor(1);
		}
		int key = Mathf.RoundToInt(perc * 100f);
		if (percColors.ContainsKey(key))
		{
			return percColors[key];
		}
		Color color = new Color(goodColor.r * (1f - perc) + badColor.r * perc, goodColor.g * (1f - perc) + badColor.g * perc, goodColor.b * (1f - perc) + badColor.b * perc);
		percColors.Add(key, color);
		return color;
	}

	public static void CreateReloadObject()
	{
		GameObject obj = UnityEngine.Object.Instantiate(Resources.Load("Prefabs/ReloadingObject") as GameObject);
		UnityEngine.Object.DontDestroyOnLoad(obj);
		obj.name = "ReloadingObject";
	}

	public static float GetWorkTimeByKeyName(string KeyName, int socket = 0)
	{
		if (ActiveComponent._staticData.ConstructionBlocksFast.ContainsKey(KeyName.GetHashCode()))
		{
			return (float)Math.Round(ActiveComponent._staticData.ConstructionBlocksFast[KeyName.GetHashCode()].WorkTime / (1f + ActiveComponent.Model.P.upgradeStats.BlocksSpeedBonus), 3);
		}
		SchemeBlock schemeBlockByKeyName = GetSchemeBlockByKeyName(KeyName);
		if (schemeBlockByKeyName != null)
		{
			return (float)Math.Round(schemeBlockByKeyName.GetInputSpeed(socket) / (1f + ActiveComponent.Model.P.upgradeStats.BlocksSpeedBonus), 3);
		}
		return 0.01f;
	}

	public static float GetValueByKeyName(string KeyName)
	{
		return ActiveComponent._staticData.ConstructionBlocks.Find((ConstructionBlock i) => i.KeyName == KeyName)?.Value ?? 0f;
	}

	public static SchemeBlock GetSchemeBlockByHash(int hash)
	{
		QuestLine.Quest quest = QuestLine.GetQuest(hash);
		if (quest != null)
		{
			return quest.GetCustomCathubSchemeBlock();
		}
		foreach (string key in ActiveComponent.Model.P.sandboxSchemes.Keys)
		{
			if (key.GetHashCode() == hash)
			{
				return ActiveComponent.Model.P.sandboxSchemes[key].GetUseAsCustomScheme();
			}
		}
		return null;
	}

	public static T Clone<T>(object obj)
	{
		return DeserializeObject<T>(SerializeObject(obj));
	}

	public static SchemeBlock GetSchemeBlockByKeyName(string name)
	{
		return GetSchemeBlockByHash(name.GetHashCode());
	}

	public static SchemeBlock GetSchemeCustomBlockByKeyName(string name)
	{
		return GetSchemeBlockByHash(name.GetHashCode());
	}

	public static SchemeBlock GetSchemeCustomBlockByHash(int hash)
	{
		return QuestLine.GetQuest(hash).GetCustomCathubSchemeBlock();
	}

	public static int GetServersCouInBlock(string kn)
	{
		return GetConstrBlockByKeyHash(kn.GetHashCode())?.ServersCost ?? GetSchemeBlockByKeyName(kn)?.GetServersCost() ?? 0;
	}

	public static float ParseMath(string s, float firstParam, float secondParam = 0f)
	{
		if (s == null)
		{
			return 0f;
		}
		s = s.ToLower();
		s = Regex.Replace(s, "\\s+", "");
		float result = 0f;
		if (float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
		{
			return result;
		}
		switch (s)
		{
		case "pi":
			return MathF.PI;
		case "e":
			return MathF.E;
		case "x":
			return firstParam;
		case "c":
			return secondParam;
		default:
		{
			string text = s.Substring(0, 3);
			string s2 = "";
			switch (text)
			{
			case "sin":
				return Mathf.Sin(ParseMath(s.Substring(4, s.Length - 1 - 4), firstParam, secondParam));
			case "cos":
				return Mathf.Cos(ParseMath(s.Substring(4, s.Length - 1 - 4), firstParam, secondParam));
			case "tan":
				return Mathf.Tan(ParseMath(s.Substring(4, s.Length - 1 - 4), firstParam, secondParam));
			case "abs":
				return Mathf.Abs(ParseMath(s.Substring(4, s.Length - 1 - 4), firstParam, secondParam));
			default:
			{
				int num = 0;
				string text2 = "";
				int num2 = 0;
				for (num2 = 4; num2 < s.Length; num2++)
				{
					if (s[num2] == '(')
					{
						num++;
					}
					if (s[num2] == ')')
					{
						num--;
					}
					if (num == 0 && s[num2] == ',')
					{
						s2 = s.Substring(4, num2 - 4);
						break;
					}
				}
				num = 0;
				bool flag = false;
				for (int i = num2 + 1; i < s.Length; i++)
				{
					if (s[i] == '(')
					{
						flag = true;
						num++;
					}
					if (s[i] == ')')
					{
						num--;
					}
					if (num == 0 && flag)
					{
						text2 = s.Substring(num2 + 1, i - num2);
						break;
					}
				}
				if (text2 == "")
				{
					text2 = s.Substring(num2 + 1, s.Length - 1 - num2 - 1);
				}
				return text switch
				{
					"add" => ParseMath(s2, firstParam, secondParam) + ParseMath(text2, firstParam, secondParam), 
					"mdd" => ParseMath(s2, firstParam, secondParam) - ParseMath(text2, firstParam, secondParam), 
					"del" => ParseMath(s2, firstParam, secondParam) / ParseMath(text2, firstParam, secondParam), 
					"mul" => ParseMath(s2, firstParam, secondParam) * ParseMath(text2, firstParam, secondParam), 
					"pow" => Mathf.Pow(ParseMath(s2, firstParam, secondParam), ParseMath(text2, firstParam, secondParam)), 
					"log" => Mathf.Log(ParseMath(s2, firstParam, secondParam), ParseMath(text2, firstParam, secondParam)), 
					"max" => Mathf.Max(ParseMath(s2, firstParam, secondParam), ParseMath(text2, firstParam, secondParam)), 
					"min" => Mathf.Max(ParseMath(s2, firstParam, secondParam), ParseMath(text2, firstParam, secondParam)), 
					_ => 0f, 
				};
			}
			}
		}
		}
	}

	public static bool StartupWasUserd(string keyName)
	{
		foreach (string usedStartup in ActiveComponent.Model.P.usedStartups)
		{
			if (usedStartup == keyName)
			{
				return true;
			}
		}
		return false;
	}

	public static int GetCustomBlockCouInSheme(string keyName)
	{
		return GetSchemeBlockByKeyName(keyName)?.GetCustomBlocksCou() ?? 0;
	}

	public static float GetTimeInBlock(string kn)
	{
		if (IsBaseBlock(kn))
		{
			return GetWorkTimeByKeyName(kn);
		}
		return 0f;
	}

	public static int GetBlocksCouInSheme(string keyName)
	{
		return GetSchemeBlockByKeyName(keyName)?.GetFullBlocksCou() ?? 0;
	}

	public static int GetRemoveCouInSheme(string keyName)
	{
		return GetSchemeBlockByKeyName(keyName)?.GetRemoveCou() ?? 0;
	}

	public static Color GetColor(KeyColor k)
	{
		if (ActiveComponent._staticData == null)
		{
			return Color.white;
		}
		if (ActiveComponent.Model != null && (k == KeyColor.GREEN || k == KeyColor.MONEY) && ActiveComponent.Model.globalSaves.IsSet(SaveFlags.ColorBlind))
		{
			return GetColor(KeyColor.WARNING);
		}
		return ActiveComponent._staticData.Colors[(int)k].AsNormalizedFloat();
	}

	public static Color GetColor(int id)
	{
		if (id == 1 && ActiveComponent.Model.globalSaves.IsSet(SaveFlags.ColorBlind))
		{
			return GetColor(KeyColor.WARNING);
		}
		if (id >= ActiveComponent._staticData.Colors.Count)
		{
			return Color.white;
		}
		return ActiveComponent._staticData.Colors[id].AsNormalizedFloat();
	}

	public static bool TaskContainsSelflearningBlocks(string legal)
	{
		if (trainableBlocks == null)
		{
			trainableBlocks = new List<ConstructionBlock>();
			foreach (ConstructionBlock constructionBlock in ActiveComponent._staticData.ConstructionBlocks)
			{
				if (constructionBlock.Trainable == 1)
				{
					trainableBlocks.Add(constructionBlock);
				}
			}
		}
		return trainableBlocks.FindIndex((ConstructionBlock i) => legal.Contains(i.KeyName)) >= 0;
	}

	public static ElementColor GetStaticColor(string keyName)
	{
		int hashCode = keyName.GetHashCode();
		if (cashedColors == null)
		{
			cashedColors = new Dictionary<int, ElementColor>();
			foreach (ElementColor color in ActiveComponent._staticData.Colors)
			{
				cashedColors.Add(color.KeyName.GetHashCode(), Clone<ElementColor>(color));
			}
		}
		if (!cashedColors.ContainsKey(hashCode))
		{
			return null;
		}
		return cashedColors[hashCode];
	}

	public static string GetHexColor(string keyName)
	{
		if (ActiveComponent._staticData == null)
		{
			return "#ffffff";
		}
		if (keyName == "MONEY" && ActiveComponent.Model.globalSaves.IsSet(SaveFlags.ColorBlind))
		{
			ElementColor staticColor = GetStaticColor("WARNING");
			if (staticColor != null)
			{
				return staticColor.hex;
			}
		}
		ElementColor staticColor2 = GetStaticColor(keyName);
		if (staticColor2 == null)
		{
			return "#ffffff";
		}
		return staticColor2.hex;
	}

	public static string ColorTransform(string keyName, string text)
	{
		return "<color=" + GetHexColor(keyName) + ">" + text + "</color>";
	}

	public static bool StartupWasDeleted(string KeyName)
	{
		return ActiveComponent.Model.P.removedStartups.FindIndex((string i) => i == KeyName) >= 0;
	}

	public static Color? GetColorIfExists(string keyName)
	{
		if (ActiveComponent._staticData == null)
		{
			return null;
		}
		if (ActiveComponent.Model != null && (keyName == "GREEN" || keyName == "MONEY") && ActiveComponent.Model.globalSaves.IsSet(SaveFlags.ColorBlind))
		{
			return GetColor(KeyColor.WARNING);
		}
		return GetStaticColor(keyName)?.AsNormalizedFloat();
	}

	public static Color GetColor(string keyName)
	{
		if (ActiveComponent._staticData == null)
		{
			return Color.white;
		}
		if (ActiveComponent.Model != null && (keyName == "GREEN" || keyName == "MONEY") && ActiveComponent.Model.globalSaves.IsSet(SaveFlags.ColorBlind))
		{
			return GetColor(KeyColor.WARNING);
		}
		return GetStaticColor(keyName)?.AsNormalizedFloat() ?? Color.white;
	}

	public static Color GetColor(string keyName, float alpha)
	{
		Color color = GetColor(keyName);
		color.a = alpha;
		return color;
	}

	public static Color GetColor(string keyName, int alpha)
	{
		return GetColor(keyName, (float)alpha / 255f);
	}

	public static int GetDay()
	{
		return ActiveComponent.Model.P.Days + 7 * ActiveComponent.Model.P.Weeks;
	}

	public static Server GetServerByKeyName(string KeyName)
	{
		return ActiveComponent._staticData.Servers.Find((Server i) => i.KeyName == KeyName);
	}

	public static int GetCurSocketDepth()
	{
		return ActiveComponent._staticData.Settings.SocketDepth + ActiveComponent.Model.P.upgradeStats.SocketDepthBonus;
	}

	public static void SaveCurCathub()
	{
		Cathub cathub = null;
		if (ActiveComponent.Model.construction.schemeStack.GetCount() != 0)
		{
			Construction.SchemeStack.Entry entry = ActiveComponent.Model.construction.schemeStack.Top();
			cathub = ((entry.state != ConstructionState.SandBox) ? QuestLine.GetQuest(entry.GetBaseQuest().KeyName).GetCatHub() : ActiveComponent.Model.P.sandboxSchemes[entry.keyName].GetCatHub());
			SaveCurCathub(cathub);
		}
	}

	public static void SaveCurCathub(Cathub cathub)
	{
		if (ActiveComponent.Model.Scheme != null)
		{
			int currentScheme = cathub.GetCurrentScheme();
			CathubScheme scheme = cathub.GetScheme(currentScheme);
			ActiveComponent.Model.Scheme.ClearToSave();
			scheme.json = SerializeObject(ActiveComponent.Model.Scheme);
			cathub.SetScheme(currentScheme, scheme);
		}
	}

	public static void AddPack(string sku)
	{
	}

	public static SchemeBlock GetCustomSchemeByKeyName(string name)
	{
		return GetSchemeCustomBlockByKeyName(name);
	}

	public static void ReInitAllControllers()
	{
		Construction = (Construction)ReInitController<Construction>();
		GoogleController = (GoogleController)ReInitController<GoogleController>();
		Controller = (Controller)ReInitController<Controller>();
		TreeController = (TreeController)ReInitController<TreeController>();
		ComicsController = (ComicsController)ReInitController<ComicsController>();
		deepTrafficQuestController = (DeepTrafficQuestController)ReInitController<DeepTrafficQuestController>();
	}

	public static UnityEngine.Object ReInitController<T>()
	{
		UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(T));
		if (array.Length == 0)
		{
			return null;
		}
		return array[0];
	}
}
