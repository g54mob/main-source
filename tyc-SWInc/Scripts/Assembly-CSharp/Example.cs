using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Achievements;
using AltSerialize;
using DevConsole;
using SINetworking;
using StatementParser;
using Steamworks;
using TinyJson;
using Tyd;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.EventSystems;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;

public class Example : MonoBehaviour
{
	public class ParserWorld : LineParse.ScriptWorld
	{
		private HashSet<Type> _restrictedTypes = new HashSet<Type>
		{
			typeof(AchievementController),
			typeof(NetworkManager),
			typeof(SteamWorkshop),
			typeof(SteamManager),
			typeof(SteamAPI),
			typeof(SteamMatchmaking),
			typeof(SteamFriends),
			typeof(SteamGameServer),
			typeof(SteamInventory),
			typeof(SteamNetworking),
			typeof(SteamClient),
			typeof(SteamNetworkingMessages),
			typeof(SteamNetworkingSockets),
			typeof(SteamUser),
			typeof(SteamUGC)
		};

		private Assembly[] _assemblies = AppDomain.CurrentDomain.GetAssemblies();

		public NetworkManager NetworkManager
		{
			get
			{
				return NetworkManager.Instance;
			}
		}

		public GameSettings GameSettings
		{
			get
			{
				return GameSettings.Instance;
			}
		}

		public SelectorController SelectorController
		{
			get
			{
				return SelectorController.Instance;
			}
		}

		public HashSet<Selectable> Selected
		{
			get
			{
				return SelectorController.Instance.Selected;
			}
		}

		public HUD HUD
		{
			get
			{
				return HUD.Instance;
			}
		}

		public WindowManager WindowManager
		{
			get
			{
				return WindowManager.Instance;
			}
		}

		public MarketSimulation MarketSimulation
		{
			get
			{
				return MarketSimulation.Active;
			}
		}

		public HashSet<WorkItem> WorkItems
		{
			get
			{
				return GameSettings.MyCompany.WorkItems;
			}
		}

		public IEnumerable<Furniture> Furniture
		{
			get
			{
				return ObjectDatabase.Instance.GetAllFurnitureComponents();
			}
		}

		public SoftwareProduct LastProduct
		{
			get
			{
				return ProductDetailWindow.LastShownProduct;
			}
		}

		public Company LastCompany
		{
			get
			{
				return CompanyDetailWindow.LastShownCompany;
			}
		}

		public global::DevConsole.Console Console
		{
			get
			{
				return global::DevConsole.Console.Singleton;
			}
		}

		public SDateTime Now
		{
			get
			{
				return SDateTime.Now();
			}
		}

		public string CopyToClipboard(object o)
		{
			bool wasArray = false;
			return GUIUtility.systemCopyBuffer = LogOutput(o, ref wasArray, false, false);
		}

		public override bool IsRestricted(Type type)
		{
			return _restrictedTypes.Contains(type);
		}

		public override bool IsProtected()
		{
			return true;
		}

		public void ForceTrade(SoftwareProduct p)
		{
			new IPDeal(p).Accept(GameSettings.MyCompany);
		}

		public void ReWriteTyd(string path, bool forceQutoes = false, bool noInlineTables = false)
		{
			File.WriteAllText(path, TydToText.Write(TydFile.FromFile(path).DocumentNode, true, 0, 0, forceQutoes, noInlineTables));
		}

		public void ReWriteTydPretty(string path, bool forceQutoes = false, bool noInlineTables = false)
		{
			File.WriteAllText(path, TydToText.Write(TydFile.FromFile(path).DocumentNode, true, 0, 0, forceQutoes, noInlineTables, true));
		}

		public object GetOrDefault(IDictionary dict, object key, object defVal)
		{
			if (!dict.Contains(key))
			{
				return defVal;
			}
			return dict[key];
		}

		public SDateTime CreateDate(int year, int month = 0, int day = 0, int hour = 0, int minute = 0)
		{
			return new SDateTime(minute, hour, day, month, year - 1900);
		}

		public void DoSelect(Selectable target)
		{
			SelectorController.Instance.SetSelection(target);
		}

		public void DoSelect(IEnumerable target)
		{
			SelectorController.Instance.SetSelection(target.OfType<Selectable>());
		}

		public void AddManufactureDeal()
		{
			SimulatedCompany.ProductPrototype random = MarketSimulation.Active.Companies.Values.SelectMany((SimulatedCompany x) => x.Releases.Where((SimulatedCompany.ProductPrototype z) => z.Category.Hardware)).GetRandom();
			if (random != null)
			{
				PrintDeal deal = new PrintDeal(random.DevCompany, random, 0f, random.HardwarePrice * MarketSimulation.HardwareCopyPriceFactor, 100000u);
				HUD.Instance.dealWindow.InsertDeal(deal);
			}
		}

		public Color GetColor(string c)
		{
			if (!c.StartsWith("#"))
			{
				c = "#" + c;
			}
			Color color;
			if (!ColorUtility.TryParseHtmlString(c, out color))
			{
				return Color.white;
			}
			return color;
		}

		public Color GetRandomColor(float sat, float val)
		{
			return Color.HSVToRGB(UnityEngine.Random.value, sat, val);
		}

		public string ToBinary(int val, uint max = 32u)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < max; i++)
			{
				stringBuilder.Insert(0, ((val & 1) != 0) ? "1" : "0");
				val >>= 1;
			}
			return stringBuilder.ToString();
		}

		public string ToBinary(uint val, uint max = 32u)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < max; i++)
			{
				stringBuilder.Insert(0, ((val & 1) != 0) ? "1" : "0");
				val >>= 1;
			}
			return stringBuilder.ToString();
		}

		public string CountCategory(IEnumerable<object> l)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (IGrouping<object, object> item in from x in l
				group x by x into x
				orderby x.Count() descending
				select x)
			{
				stringBuilder.AppendLine(string.Concat(item.Key, ": ", item.Count()));
			}
			return stringBuilder.ToString();
		}

		public override Type GetTypeFromName(string name)
		{
			switch (name)
			{
			case "TydToText":
				return typeof(TydToText);
			case "TydFile":
				return typeof(TydFile);
			case "File":
				return typeof(File);
			case "Application":
				return typeof(Application);
			case "AltSerializer":
				return typeof(AltSerializer);
			case "Type":
				return typeof(Type);
			case "LineParse":
				return typeof(LineParse);
			case "Rect":
				return typeof(Rect);
			case "Vector2":
				return typeof(Vector2);
			case "Vector3":
				return typeof(Vector3);
			case "Vector4":
				return typeof(Vector4);
			case "Color":
				return typeof(Color);
			case "Color32":
				return typeof(Color32);
			default:
			{
				for (int i = 0; i < _assemblies.Length; i++)
				{
					Type type = _assemblies[i].GetType(name, false);
					if (type != null)
					{
						return type;
					}
				}
				return null;
			}
			}
		}
	}

	public static ParserWorld ParserInstance = new ParserWorld();

	public static bool NetworkDetails = false;

	public global::DevConsole.Console DevConsole;

	public static bool EnableNavMesh = false;

	public static bool NavMeshPortal = false;

	public static bool UseNavWeight = false;

	public static bool EnableDirtTree = false;

	public static bool EnableNearness = false;

	public static bool CachedPaths = false;

	public static bool PreferredPoint = false;

	public static bool EnableBSP = false;

	private static string[] _bools = new string[2] { "True", "False" };

	private static HashSet<Type> _validScopeTypes = null;

	private static Dictionary<Type, string> TypeRedirection = new Dictionary<Type, string>
	{
		{
			typeof(int),
			"int"
		},
		{
			typeof(string),
			"string"
		},
		{
			typeof(float),
			"float"
		},
		{
			typeof(bool),
			"bool"
		},
		{
			typeof(uint),
			"uint"
		},
		{
			typeof(byte),
			"byte"
		},
		{
			typeof(void),
			"void"
		}
	};

	public static Vector2 StCamPos;

	public static Quaternion StCamDir;

	public static int StCamFloor;

	public static float StCamZoom;

	private static StringBuilder _compFix = new StringBuilder();

	private static IEnumerable<string> GetEmployeeRoles(string[] unused)
	{
		for (int i = 0; i < 5; i++)
		{
			Employee.EmployeeRole employeeRole = (Employee.EmployeeRole)i;
			yield return employeeRole.ToString();
		}
	}

	private static IEnumerable<string> GetEmployeeSpec(string[] param, int i)
	{
		Employee.EmployeeRole result;
		if (Enum.TryParse<Employee.EmployeeRole>(param[i], true, out result))
		{
			return GameSettings.Instance.GetAllSpecializations(result);
		}
		return null;
	}

	private static IEnumerable<string> GetSoftwareTypes(string[] unused, bool withContract)
	{
		if (!withContract)
		{
			return from x in MarketSimulation.Active.SoftwareTypes
				where !x.Value.OneClient
				select x.Key;
		}
		return MarketSimulation.Active.SoftwareTypes.Keys;
	}

	private static IEnumerable<string> GetBoolean(string[] unused)
	{
		return _bools;
	}

	private static IEnumerable<string> GetSoftwareCategories(string[] param, int i)
	{
		SoftwareType value;
		if (MarketSimulation.Active.SoftwareTypes.TryGetValue(param[i], out value))
		{
			return value.Categories.Keys;
		}
		return null;
	}

	private void Start()
	{
		global::DevConsole.Console.AddCommand(new Command("TAKE_ALL_LAND", TakeAllLand, "Claims the entire plot")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command("WRITE_ERROR", WriteErrors, "Show all errors that has occured during this save"));
		global::DevConsole.Console.AddCommand(new Command<bool>("TOGGLE_LIGHTS", ToggleLights, "Toggles whether lamps should always be on", GetBoolean));
		global::DevConsole.Console.AddCommand(new Command("UNLOCK_FURNITURE", UnlockFurniture, "Unlocks all furniture")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command("SPAWN_GUEST", SpawnGuest, "Spawns a guest, that appears in the game for a receptionist")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<int>("SPAWN_BURGLAR", SpawnRobber, "Spawns a burglar")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command("SPAWN_POLICE", SpawnPolice, "Spawns a police officer for each burglar present")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<int, string>("SPAWN_EMPLOYEES", HireEmployees, "Spawns the specified employees in the specified role", null, GetEmployeeRoles)
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<bool>("TOGGLE_SKYSCRAPERS", ToggleScraperTransparency, "Toggle whether skyscrapers should become see-through", GetBoolean));
		global::DevConsole.Console.AddCommand(new Command("MAX_EMPLOYEE_STATS", MaxEmployee, "Maxes the stats of all selected employees")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<float>("SET_EMPLOYEE_STATS", SetEmployeeStats, "Sets the selected employees stats to the specified value between 0-1")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<string, string, int>("SET_EMPLOYEE_STAT", SetEmployeeStat, "Sets a specified spec in a specified role of the selected employees to a specified value between 0-3", GetEmployeeRoles, (string[] x) => GetEmployeeSpec(x, 0))
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<string>("ADD_EMPLOYEE_EXP", AddExp, "Add 1 experience point to selected employees in specified role", GetEmployeeRoles)
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command("RESET_MOOD", ResetMoods, "Reset thoughts and mood affectors of selected employees")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<int>("SPAWN_CAR", SpawnDebugCar, "Spawns the specified amount of cars, which park somewhere for a couple of minutes and drives off"));
		global::DevConsole.Console.AddCommand(new Command("UNLOCK_ALL_REWARDS", UnlockAllRewards, "Unlocks all rewards in the game"));
		global::DevConsole.Console.AddCommand(new Command<float>("ADD_MONEY", delegate(float x)
		{
			AddMoney(x, false, false);
		}, "Adds the specified amount of money"));
		global::DevConsole.Console.AddCommand(new Command<float, string>("SEND_MONEY", SendMoney, "Sends the specified amount of money in multiplayer", null, (string[] x) => NetworkManager.Instance.Players.Select((NetworkPlayer z) => z.Name)));
		global::DevConsole.Console.AddCommand(new Command<string, string, int>("ADD_FANS", AddReputation, "Adds the specified amount of fans to the specified software category", (string[] x) => GetSoftwareTypes(x, false), (string[] x) => GetSoftwareCategories(x, 0))
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<float>("SET_BUSINESS_REP", SetBusinessRep, "Sets business reputation to the specified level in percent")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command("APPROVE_SDF", ApproveSDF)
		{
			Hide = true
		});
		global::DevConsole.Console.AddCommand(new Command("CLEAR_DIRT", ClearDirt, "Clears dirt in all rooms")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command("RESET_ARRIVAL", ResetArrival, "Resets the arrival time of all selected employee that are not present"));
		global::DevConsole.Console.AddCommand(new Command<int>("SKIP_DAYS", SkipDay, "Skips the specified amount of days. This might freeze the game for a while")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<int>("SKIP_HOURS", SkipHour, "Skips the specified amount of hours")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<int>("SKIP_TO", SkipTo, "Skips to the specified hour between 0 and 23")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command("INSTA_DEVELOP_DESIGN", InstaRelease, "Instantly releases software in design document window if modded")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<int>("AGE_EMPLOYEES", AgeEmployees, "Ages all selected employees the specified amount of months")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<bool>("TOGGLE_INFINITE_SUBSIDIARIES", delegate(bool x)
		{
			Cheats.InfiniteSubs = x;
		}, "Toggle whether to remove limit on subsidiaries", GetBoolean)
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<string>("GENERATE_LOCALIZATION", GenerateLocs, "Generates localization files for the specified mod.", (string[] z) => from x in ModWindow.Mods.Values.SelectMany((EventList<object> x) => x).OfType<IWorkshopItem>()
			select x.ItemTitle));
		global::DevConsole.Console.AddCommand(new Command<string>("RELOAD_MOD", ReloadMod, "Reloads the specified mod, but not for the currently running game.", (string[] x) => GameData.ModPackages.Select((ModPackage z) => z.ItemTitle)));
		global::DevConsole.Console.AddCommand(new Command<string>("CHECK_SPEC_REP", CheckSpecs, "Checks whether all specializations are represented in software types using the specified mod", (string[] x) => GameData.ModPackages.Select((ModPackage z) => z.ItemTitle)));
		global::DevConsole.Console.AddCommand(new Command<string, string, string>("CHECK_ADDON_MARKET", CheckAddonBalance, "Checks whether all markets are fulfilled by an add-on in a software type. Input Mod name, software name and add-on name", (string[] x) => GameData.ModPackages.Select((ModPackage z) => z.ItemTitle)));
		global::DevConsole.Console.AddCommand(new Command<string, string, string>("TEST_DEV_MOD", TestSoftware, "Checks whether software is balanced properly. Input Mod name, software name and category name", (string[] x) => GameData.ModPackages.Select((ModPackage z) => z.ItemTitle)));
		global::DevConsole.Console.AddCommand(new Command<string>("RELOAD_DLL_MOD", delegate(string x)
		{
			ModController.Instance.ReloadMod(x, true, false);
		}, "Reload a dll mod. Game may become unstable", (string[] x) => ModController.Instance.Mods.Select((ModController.DLLMod z) => z.ItemTitle))
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<string>("RECOMPILE_DLL_MOD", delegate(string x)
		{
			ModController.Instance.ReloadMod(x, true, true);
		}, "re-compile a dll mod. Game may become unstable", (string[] x) => ModController.Instance.Mods.Select((ModController.DLLMod z) => z.ItemTitle))
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<string>("UNLOAD_DLL_MOD", delegate(string x)
		{
			ModController.Instance.UnloadMod(x, false, true);
		}, "Unload a dll mod. Game may become unstable", (string[] x) => ModController.Instance.Mods.Select((ModController.DLLMod z) => z.ItemTitle))
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command("RELOAD_FURNITURE", FurnitureLoader.ReLoadFurniture, "Reloads all modded furniture with immediate effect")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<string>("RELOAD_FURNITURE_MOD", FurnitureLoader.ReLoadSpecificFurniture, "Reloads specified modded furniture with immediate effect", (string[] x) => FurnitureLoader.LoadedFurniture.Select((FurnitureMod z) => z.ItemTitle))
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command("RELOAD_MATERIALS", delegate
		{
			RoomMaterialController.Instance.InitializeTextures(true);
		}, "Reloads all room materials, only including materials loaded at game launch"));
		global::DevConsole.Console.AddCommand(new Command("REFRESH_SAVES", SaveGameManager.RefreshSaves));
		global::DevConsole.Console.AddCommand(new Command<bool>("FURNITURE_DEBUG", delegate(bool x)
		{
			ActiveFurnDebug.Activate(x);
		}, "Toggle whether to show the build(red->cyan) and nav(green->pink) boundary, interaction points(blue) and snap points(yellow) of the selected furniture", GetBoolean));
		global::DevConsole.Console.AddCommand(new Command<string>("FURNITURE_THUMBNAIL", FurnitureThumbnail, "Generates a thumbnail for the specified furniture. Only works in the main menu"));
		global::DevConsole.Console.AddCommand(new Command<string>("EXPORT_FURNITURE_BOUNDS", FurnitureBounds, "Exports boundary information to the TyD of the specified furniture."));
		global::DevConsole.Console.AddCommand(new Command<string>("EXPORT_FURNITURE_POINTS", ExportFurniturePoints, "Exports snap and interaction point data to the TyD of the specified furniture."));
		global::DevConsole.Console.AddCommand(new Command<float>("FLYCAM_DRAW_DISTANCE", FlycamDistance, "The draw distance multiplier to use in first person mode. Between 1 and 10."));
		global::DevConsole.Console.AddCommand(new Command("ACTIVATE_WAYPOINT_EDITOR", WayPoints, "Activates a waypoint animation system for first person mode. Press Backspace to add a waypoint and Enter to play."));
		global::DevConsole.Console.AddCommand(new Command<bool>("TOGGLE_CEILING", ToggleCeiling, "Toggles the generation of ceiling meshes for first person mode. Might need a reload and has a performance impact.", GetBoolean));
		global::DevConsole.Console.AddCommand(new Command("UI_UNDER_MOUSE", UIUnderMouse, "Lists all UI elements currently under the mouse cursor"));
		global::DevConsole.Console.AddCommand(new Command<string>("UI_CHILDREN", UIChildren, "Get a list of all UI elements contained in a UI element"));
		global::DevConsole.Console.AddCommand(new Command<string>("UI_COMPONENTS", UIComponents, "Get a list of all components attached to a UI element"));
		global::DevConsole.Console.AddCommand(new Command("SHOW_INSPECTOR", ShowInspector, "Open an inspector to show all active objects in the scene"));
		global::DevConsole.Console.AddCommand(new Command("SHOW_ICONS", ShowIcons, "Open an inspector to show all icons in the game"));
		global::DevConsole.Console.AddCommand(new Command("RELOAD_TUTORIALS", ReloadTutorials, "Reloads all tutorials"));
		global::DevConsole.Console.AddCommand(new Command("SKIP_TRACK", UISoundFX.ForceSkipTrack, "Force skip music track playing, if any"));
		global::DevConsole.Console.AddCommand(new Command("START_FIRE", delegate
		{
			SelectorController.Instance.Selected.OfType<Room>().ForEachEnum(delegate(Room x)
			{
				x.StartFire();
			});
		}, "Starts fire in selected rooms"));
		global::DevConsole.Console.AddCommand(new Command<string, int>("CAPTURE_SCREEN", CaptureScreen, "Saves screenshot to a Capture folder with the specified file name (excluding .png, auto indexed) and with the specified scaling"));
		global::DevConsole.Console.AddCommand(new Command<string>("LIST_SCOPE_MEMBERS", ListScopeVariables, "List all members of a script scope"));
		global::DevConsole.Console.AddCommand(new Command<string, string>("COMPARE_LOCALIZATION", CompareLocs, "Compare the first translation UI file to the second. The second should almost always be English", (string[] z) => from x in Localization.GetLanguages()
			select x.ItemTitle, (string[] z) => from x in Localization.GetLanguages()
			select x.ItemTitle));
		global::DevConsole.Console.AddCommand(new Command<string>("CONVERT_LOCALIZATION_TYD", ConvertLocXML, "Convert all XML files to TyD files for the specified localization", (string[] z) => from x in Localization.GetLanguages()
			select x.ItemTitle));
		global::DevConsole.Console.AddCommand(new Command("RELOAD_LOCALIZATION", ReloadLocalizations, "Reloads all localizations, but doesn't update UI"));
		global::DevConsole.Console.AddCommand(new Command("STORE_CAM_STATE", StoreCameraState, "Saves current camera position"));
		global::DevConsole.Console.AddCommand(new Command("RESTORE_CAM_STATE", RestoreCameraState, "Loads last saved camera position"));
		global::DevConsole.Console.AddCommand(new Command<string>("SET_STYLE", SetStyle, "Sets style in customization menu", (string[] x) => ActorGenerator.Instance.Tags));
		global::DevConsole.Console.AddCommand(new Command("GET_GENERATION_STRING", PrintRNDString, "Output the string used to generate the map"));
		global::DevConsole.Console.AddCommand(new Command("CHECK_RESOURCES", CheckResources, "Checks the number of currently allocated graphics resources"));
		global::DevConsole.Console.AddCommand(new Command("CLEAN_RESOURCES", CleanResources, "Cleans up unusued resources"));
		global::DevConsole.Console.AddCommand(new Command<string>("FIND_BOXES", FindBoxesFor, "Find all conveyors and assemblers containing components related to the specified printing job"));
		global::DevConsole.Console.AddCommand(new Command("EXPORT_CSV", ExportCSV, "Export the content of a list under the mouse cursor as CSV to the clipboard"));
		global::DevConsole.Console.AddCommand(new Command<bool>("NETWORK_DETAILS", delegate(bool x)
		{
			NetworkDetails = x;
		})
		{
			Hide = true
		});
		global::DevConsole.Console.AddCommand(new Command<byte>("NETWORK_CHECK", NetworkDiagnostics)
		{
			Hide = true
		});
		global::DevConsole.Console.AddCommand(new Command("COMMAND_ARGS", delegate
		{
			global::DevConsole.Console.Log(Options.CommandLines);
		}, "Outputs what parameters the game was launched with"));
		global::DevConsole.Console.AddCommand(new Command("FIX_COMPONENT_COUNT", delegate
		{
			FixComponentCounts(true);
		}, "Recounts all hardware components on map in case a print job is stalled"));
		global::DevConsole.Console.AddCommand(new Command("FORCE_CRASH", delegate
		{
			Utils.ForceCrash(ForcedCrashCategory.AccessViolation);
		})
		{
			Hide = true,
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<string>("EXECUTE", ParseCommand, "Executes one line of code")
		{
			AvailableOnline = false
		});
		global::DevConsole.Console.AddCommand(new Command<string>("EXECUTE_CLIP", ParseCommandToClip, "Executes one line of code and writes result to clipboard")
		{
			AvailableOnline = false
		});
	}

	private void ShowIcons()
	{
		new GameObject("Icon browser").AddComponent<GUIIconBrowser>();
	}

	private void CleanResources()
	{
		StartCoroutine(ResourceCleanup(true));
	}

	public static IEnumerator ResourceCleanup(bool console)
	{
		long m = Profiler.GetTotalAllocatedMemoryLong();
		float t = Time.timeSinceLevelLoad;
		yield return Resources.UnloadUnusedAssets();
		long totalAllocatedMemoryLong = Profiler.GetTotalAllocatedMemoryLong();
		string text = ((m <= totalAllocatedMemoryLong) ? ("-" + ((uint)(totalAllocatedMemoryLong - m)).ByteSize()) : ((uint)(m - totalAllocatedMemoryLong)).ByteSize());
		if (console)
		{
			global::DevConsole.Console.Log("Unloaded resources in " + (Time.timeSinceLevelLoad - t).SecondsToTime() + " with a change of " + text);
		}
		else
		{
			Debug.Log("Unloaded resources in " + (Time.timeSinceLevelLoad - t).SecondsToTime() + " with a change of " + text);
		}
	}

	private void CheckResources()
	{
		Material[] array = Resources.FindObjectsOfTypeAll<Material>();
		global::DevConsole.Console.Log("RT: " + Resources.FindObjectsOfTypeAll<RenderTexture>().Length + "\nTex: " + Resources.FindObjectsOfTypeAll<Texture>().Length + "\nMat: " + array.Length + "\nLast mat: " + array[0].name);
	}

	private void ShowInspector()
	{
		if (WindowManager.Instance != null)
		{
			InspectorWindow inspectorWindow = UnityEngine.Object.Instantiate(WindowManager.Instance.InspectorWindowPrefab);
			inspectorWindow.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
			inspectorWindow.Window.Show(true);
		}
	}

	private void ProbeNavWeight()
	{
		Vector2 mouseProj = HUD.Instance.GetMouseProj();
		Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(GameSettings.Instance.ActiveFloor, mouseProj);
		if (roomFromPoint != null)
		{
			TriangleNode triangle = roomFromPoint.GetTriangle(mouseProj);
			if (triangle != null)
			{
				global::DevConsole.Console.Log(string.Join(", ", triangle.Weight.Values));
			}
		}
	}

	private void TestColumnOpSize()
	{
		Debug.Log("order size bytes: " + Convert.ToBase64String(GameReader.Compress(Serializer.Serialize(GameSettings.Instance.ColumnOrder))).Length);
	}

	private void ResetArrival()
	{
		if (!(SelectorController.Instance != null))
		{
			return;
		}
		SDateTime sDateTime = SDateTime.Now();
		foreach (Actor item in SelectorController.Instance.Selected.OfType<Actor>())
		{
			if (item.AItype == AI.AIType.Employee && !item.isActiveAndEnabled)
			{
				item.StayHome = 0;
				SDateTime time = new SDateTime((float)item.SpawnTime - item.MeetingDiff, sDateTime.Day + 1, sDateTime.Month, sDateTime.Year);
				GameSettings.Instance.sActorManager.AddToAwaiting(item, time, true);
			}
		}
	}

	private void ClearGrass()
	{
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = GameSettings.Instance.GrassTrot;
		GL.Clear(true, true, Color.black);
		RenderTexture.active = active;
	}

	private void ResetActorBlend()
	{
		if (ActorCustomization.Instance != null)
		{
			ActorCustomization.Instance.ResetSliders();
		}
	}

	private void CompareSDF()
	{
		string[] array = GUIUtility.systemCopyBuffer.Split('|');
		StringBuilder stringBuilder = new StringBuilder();
		SDFCreator.LoadSDFTree(SDFCreator.GetTreeFromString(array[0])).Compare(SDFCreator.LoadSDFTree(SDFCreator.GetTreeFromString(array[1])), stringBuilder);
		Debug.Log(stringBuilder.ToString());
	}

	private static void TestNetworkRoom()
	{
		BuildingPrefab buildingPrefab = BuildingPrefab.SaveRooms(GameSettings.Instance.sRoomManager.Rooms.ToArray(), GameSettings.Instance.sRoomManager.Roofs.ToArray(), false);
		using (MemoryStream memoryStream = new MemoryStream())
		{
			buildingPrefab.WriteData(memoryStream);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			buildingPrefab = BuildingPrefab.ReadData(memoryStream);
		}
		new PlayerMap(0, buildingPrefab);
	}

	private void NetworkDiagnostics(byte x)
	{
		if (NetworkManager.IsConnected)
		{
			NetworkPlayer player = NetworkManager.GetPlayer(x);
			if (player != null)
			{
				NetworkMessaging.SendDiagnostics(NetworkMessaging.DiagnosticSheet.Company, null, NetworkMessaging.MessageTarget.Specifically, player.ID);
			}
		}
	}

	private static void PrintStyle()
	{
		Room room = SelectorController.Instance.Selected.FirstOrDefaultOf<Room>();
		if (room != null)
		{
			Debug.Log(string.Format("{0} = {1}, {2} = {3}, {4} = {5}, {6}", room.FloorMat, (SVector3)room.FloorColor, room.InsideMat, (SVector3)room.InsideColor, room.OutsideMat, (SVector3)room.OutsideColor, room.FenceStyle));
			return;
		}
		Roof roof = SelectorController.Instance.Selected.FirstOrDefaultOf<Roof>();
		if (roof != null)
		{
			Debug.Log(string.Format("{0} = {1}, {2} = {3}", roof.RoofMaterial, (SVector3)roof.RoofColor, roof.GableMaterial, (SVector3)roof.GableColor));
			return;
		}
		PathObject pathObject = SelectorController.Instance.Selected.FirstOrDefaultOf<PathObject>();
		if (pathObject != null)
		{
			Debug.Log(string.Format("{0} = {1}", pathObject.Material, (SVector3)pathObject.MatColor));
			return;
		}
		Furniture furniture = SelectorController.Instance.Selected.FirstOrDefaultOf<Furniture>();
		if (furniture != null)
		{
			Debug.Log(string.Format("{0}, {1}, {2}, atlas = {3}", furniture.ColorPrimaryEnabled ? ColorUtility.ToHtmlStringRGB(furniture.ColorPrimary) : "N/A", furniture.ColorSecondaryEnabled ? ColorUtility.ToHtmlStringRGB(furniture.ColorSecondary) : "N/A", furniture.ColorTertiaryEnabled ? ColorUtility.ToHtmlStringRGB(furniture.ColorTertiary) : "N/A", (furniture.AtlasObject != null) ? furniture.AtlasIndex.ToString() : "N/A"));
		}
	}

	private static void CreateMod()
	{
		ModPackage item = new ModPackage("SaveGameMod", MarketSimulation.Active.SoftwareTypes, new Dictionary<string, SoftwareTypeOverride>(), MarketSimulation.Active.CompanyTypes, MarketSimulation.Active.RNG, GameSettings.Instance.Personalities, new string[0], null, 0f);
		GameData.ModPackages.Add(item);
	}

	private static void PrintRNDString()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			global::DevConsole.Console.Log(GameSettings.Instance.RNDString);
		}
	}

	private static void CheckTutorialArrows()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (KeyValuePair<string, TutorialMessage[]> tutorial in TutorialSystem.Tutorials)
		{
			TutorialMessage[] value = tutorial.Value;
			foreach (TutorialMessage tutorialMessage in value)
			{
				foreach (TutorialMessage.TutorialPoint point in tutorialMessage.Points)
				{
					if (!point.ThreeD && !string.IsNullOrEmpty(point.ElementAnchor) && WindowManager.FindElementPath(point.ElementAnchor) == null)
					{
						string text = "Failed finding: " + point.ElementAnchor + " for " + tutorial.Key + "-" + tutorialMessage.Message;
						global::DevConsole.Console.LogError(text);
						stringBuilder.AppendLine(text);
					}
				}
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private static void LangsInLocalizor(string result, string error)
	{
		if (error != null)
		{
			return;
		}
		global::DevConsole.Console.Log("Possible languages:");
		foreach (KeyValuePair<string, string> item in result.FromJson<Dictionary<string, string>>())
		{
			global::DevConsole.Console.Log(item.Key);
		}
	}

	private static void SubLoadFromLocalizor(string result, string error)
	{
		if (error == null)
		{
			List<Dictionary<string, object>> list = result.FromJson<List<Dictionary<string, object>>>();
			if (list.Count > 0)
			{
				Dictionary<string, object> dictionary = list[0];
				object value = null;
				TydDocument tydDocument = null;
				if (!dictionary.TryGetValue("languageName", out value))
				{
					return;
				}
				string text = value.ToString();
				object value2;
				if (!dictionary.TryGetValue("translations", out value2))
				{
					return;
				}
				Dictionary<string, object> dictionary2 = value2 as Dictionary<string, object>;
				if (dictionary2 == null)
				{
					return;
				}
				Dictionary<string, TydList> lists = new Dictionary<string, TydList>();
				tydDocument = new TydDocument();
				foreach (KeyValuePair<string, object> item in dictionary2)
				{
					ParseNode(item.Key, item.Value.ToString(), tydDocument, lists);
				}
				if (!Directory.Exists("Localization/" + text))
				{
					Directory.CreateDirectory("Localization/" + text);
				}
				File.WriteAllText("Localization/" + text + "/translations.tyd", TydToText.Write(tydDocument, true, 0, 0, true, false, false, true));
				File.WriteAllText("Localization/" + text + "/meta.tyd", "Name \"" + text + "\"\nAuthor \"Localizor.com\"\nDescription \"Downloaded from Localizor.com\"");
				global::DevConsole.Console.Log("Successfully downloaded " + text);
				try
				{
					Localization.Translation translation = new Localization.Translation("Localization/" + text);
					Localization.AddLanguage(translation);
					global::DevConsole.Console.Log(translation.GetTranslatedPercent().ToPercent() + " translated");
					if (LanguageWindow.Instance != null)
					{
						LanguageWindow.Instance.Refresh();
					}
					return;
				}
				catch (Exception ex)
				{
					Debug.LogError("Localization failed loading language with error:\n" + ex.ToString());
					return;
				}
			}
			global::DevConsole.Console.Log("Failed loading translation");
			URLDownloader.Launch("https://www.localizor.com/api/public/63/languages", LangsInLocalizor);
		}
		else
		{
			global::DevConsole.Console.Log("Failed downloading translation:\n" + error);
		}
	}

	private static void LoadFromLocalizor(string langName)
	{
		if (string.IsNullOrWhiteSpace(langName))
		{
			global::DevConsole.Console.Log("Please specify language, e.g. \"de\"");
			return;
		}
		URLDownloader.Launch("https://www.localizor.com/api/public/63/translations?language=" + langName, SubLoadFromLocalizor);
		global::DevConsole.Console.Log("Downloading translation");
	}

	private static void ParseNode(string keys, string value, TydDocument doc, Dictionary<string, TydList> lists)
	{
		string[] array = keys.Split('|');
		if (array.Length > 1)
		{
			if (array[0].Equals("Plural"))
			{
				TydTable node = new TydTable("Item", new TydString("Name", array[1]), new TydString("Plural", array[2]), new TydString("Value", value));
				doc.AddChild(node);
				return;
			}
			int num = array[1].ConvertToInt(array[0]);
			TydList orAdd = lists.GetOrAdd(array[0], delegate(string x)
			{
				if (TydToText.ShouldWriteWithQuotes(x))
				{
					TydList tydList = new TydList("Value");
					TydTable tydTable = new TydTable("Item", new TydString("Name", x));
					tydTable.AddChild(tydList);
					doc.AddChild(tydTable);
					return tydList;
				}
				TydList tydList2 = new TydList(x);
				doc.AddChild(tydList2);
				return tydList2;
			});
			for (int num2 = orAdd.Count; num2 <= num; num2++)
			{
				orAdd.AddChild(new TydString(null, ""));
			}
			((TydString)orAdd.Nodes[num]).Value = value;
		}
		else if (TydToText.ShouldWriteWithQuotes(array[0]))
		{
			doc.AddChild(new TydTable("Item", new TydString("Name", array[0]), new TydString("Value", value)));
		}
		else
		{
			doc.AddChild(new TydString(array[0], value));
		}
	}

	private static void ConvertLocalizor(string locName)
	{
		Localization.Translation language = Localization.GetLanguage(locName);
		if (language == null)
		{
			return;
		}
		string root = language.Root;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		string[] files = Directory.GetFiles(root, "*.csv");
		foreach (string text in files)
		{
			string s = File.ReadAllText(text);
			TydDocument doc = new TydDocument();
			Dictionary<string, TydList> dict = new Dictionary<string, TydList>();
			int pos = 0;
			while (MatchLoc(s, ref pos, stringBuilder, stringBuilder2))
			{
				string[] array = stringBuilder.ToString().Split('|');
				string text2 = stringBuilder2.ToString();
				if (array.Length > 1)
				{
					if (array[0].Equals("Plural"))
					{
						TydTable node = new TydTable("Item", new TydString("Name", array[1]), new TydString("Plural", array[2]), new TydString("Value", text2));
						doc.AddChild(node);
						continue;
					}
					int num = array[1].ConvertToInt(array[0]);
					TydList orAdd = dict.GetOrAdd(array[0], delegate(string x)
					{
						if (TydToText.ShouldWriteWithQuotes(x))
						{
							TydList tydList = new TydList("Value");
							TydTable tydTable = new TydTable("Item", new TydString("Name", x));
							tydTable.AddChild(tydList);
							doc.AddChild(tydTable);
							return tydList;
						}
						TydList tydList2 = new TydList(x);
						doc.AddChild(tydList2);
						return tydList2;
					});
					for (int num2 = orAdd.Count; num2 <= num; num2++)
					{
						orAdd.AddChild(new TydString(null, ""));
					}
					((TydString)orAdd.Nodes[num]).Value = text2;
				}
				else if (TydToText.ShouldWriteWithQuotes(array[0]))
				{
					doc.AddChild(new TydTable("Item", new TydString("Name", array[0]), new TydString("Value", text2)));
				}
				else
				{
					doc.AddChild(new TydString(array[0], text2));
				}
			}
			File.WriteAllText(text.ToLower().Replace(".csv", ".tyd"), TydToText.Write(doc, true, 0, 0, true, false, false, true));
		}
	}

	private static bool MatchLoc(string s, ref int pos, StringBuilder key, StringBuilder value)
	{
		key.Clear();
		value.Clear();
		int num = 0;
		while (num != 4 && pos < s.Length)
		{
			char c = s[pos];
			switch (num)
			{
			case 0:
				if (c == '"')
				{
					num = 1;
				}
				break;
			case 1:
				if (SubMatchLoc(s, ref pos, key))
				{
					num = 2;
				}
				break;
			case 2:
				if (c == '"')
				{
					num = 3;
				}
				break;
			case 3:
				if (SubMatchLoc(s, ref pos, value))
				{
					num = 4;
				}
				break;
			}
			pos++;
		}
		return num == 4;
	}

	private static bool SubMatchLoc(string s, ref int pos, StringBuilder sb)
	{
		char c = s[pos];
		if (s[pos] == '\\' && pos + 1 < s.Length && s[pos + 1] == '"')
		{
			sb.Append('"');
			pos++;
			return false;
		}
		if (c == '"')
		{
			if (pos + 1 < s.Length && s[pos + 1] == '"')
			{
				sb.Append('"');
				pos++;
				return false;
			}
			return true;
		}
		sb.Append(c);
		return false;
	}

	private static void ReloadLocalizations()
	{
		Localization.LoadLanguages();
	}

	private static void SpawnBoxes()
	{
		foreach (Furniture item in SelectorController.Instance.Selected.OfType<Furniture>())
		{
			if (item.HasConveyor && item.Conveyor.CurrentBoxes[0] == null)
			{
				GameSettings.Instance.BoxController.CreateBox(null, item.Conveyor, 0);
			}
		}
	}

	private static void SideWalkTest()
	{
		RoadManager instance = RoadManager.Instance;
		for (int i = 0; i < RoadManager.Floors; i++)
		{
			MeshCombiner meshCombiner = new MeshCombiner("Sidewalk", true, false);
			for (int j = 0; j < instance.GridSize; j++)
			{
				for (int k = 0; k < instance.GridSize; k++)
				{
					RoadSegment segment = instance.GetSegment(j, k, i);
					if (segment != null)
					{
						segment.GenerateSidewalk(meshCombiner);
					}
				}
			}
			GameObject obj = new GameObject("Sidewalk");
			obj.AddComponent<MeshFilter>().sharedMesh = meshCombiner.CreateMesh();
			obj.AddComponent<MeshRenderer>().sharedMaterial = TimeOfDay.Instance.SideWalkMat;
		}
	}

	private static void InstaMarket(string sw)
	{
		SoftwareProduct productFromName = MarketSimulation.Active.GetProductFromName(sw);
		if (productFromName != null)
		{
			productFromName.AddToMarketing(MarketSimulation.Active.GetMaxAwareness(productFromName) - productFromName.GetRealAwareness());
		}
		else
		{
			global::DevConsole.Console.LogError("Product does not exist");
		}
	}

	private static void MarketPercent(string sw, float pc)
	{
		SoftwareProduct productFromName = MarketSimulation.Active.GetProductFromName(sw);
		if (productFromName != null)
		{
			productFromName.AddToMarketing(MarketSimulation.Active.GetMaxAwareness(productFromName) * pc - productFromName.GetRealAwareness());
		}
		else
		{
			global::DevConsole.Console.LogError("Product does not exist");
		}
	}

	private void UIChildren(string arg)
	{
		RectTransform rectTransform = WindowManager.FindElementPath(arg);
		if (rectTransform != null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine();
			ListUIChildren(rectTransform.transform, stringBuilder, 0, 3);
			global::DevConsole.Console.Log(stringBuilder.ToString());
		}
		else
		{
			global::DevConsole.Console.Log("Element does not exist");
		}
	}

	private bool ListUIChildren(Transform p, StringBuilder sb, int offset, int max)
	{
		for (int i = 0; i < offset; i++)
		{
			sb.Append("  ");
		}
		sb.Append('/');
		if (max == 0)
		{
			sb.AppendLine("...");
			return false;
		}
		sb.AppendLine(p.name);
		for (int j = 0; j < p.childCount && ListUIChildren(p.GetChild(j), sb, offset + 1, max - 1); j++)
		{
		}
		return true;
	}

	private void GenerateLocs(string mod)
	{
		IWorkshopItem workshopItem = ModWindow.Mods.Values.SelectMany((EventList<object> x) => x).OfType<IWorkshopItem>().FirstOrDefault((IWorkshopItem x) => x.ItemTitle.Equals(mod));
		if (workshopItem != null)
		{
			if (workshopItem.GenerateLocalization())
			{
				global::DevConsole.Console.Log("Localization files generated");
			}
			else
			{
				global::DevConsole.Console.Log("This mod type can't auto generate localization files");
			}
		}
		else
		{
			global::DevConsole.Console.Log("Couldn't find mod");
		}
	}

	private void SpawnPolice()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.SpawnPolice(false);
		}
	}

	private void SetStyle(string style)
	{
		if (ActorCustomization.Instance != null)
		{
			ActorGenerator.Instance.ApplySavedStyle(ActorGenerator.Instance.GenerateStyle(ActorCustomization.Instance.Female, style, 20f), ActorCustomization.Instance);
			ActorCustomization.Instance.InitHead();
		}
	}

	private void CompareLocs(string l1, string l2)
	{
		Localization.Translation language = Localization.GetLanguage(l1);
		Localization.Translation language2 = Localization.GetLanguage(l2);
		if (language != null)
		{
			if (language2 != null)
			{
				Dictionary<string, string[]> allValues = language.GetAllValues();
				Dictionary<string, string[]> allValues2 = language2.GetAllValues();
				HashSet<string> hashSet = allValues.Keys.ToHashSet();
				hashSet.AddRange(allValues2.Keys);
				{
					foreach (string item in hashSet)
					{
						bool flag = allValues.ContainsKey(item);
						bool flag2 = allValues2.ContainsKey(item);
						if (flag && !flag2)
						{
							global::DevConsole.Console.Log(string.Format("\"{0}\" not found", item), Color.red);
						}
						else if (!flag && flag2)
						{
							global::DevConsole.Console.Log(string.Format("\"{0}\" has been added", item), Color.green);
						}
					}
					return;
				}
			}
			global::DevConsole.Console.LogError(l2 + " not found!");
		}
		else
		{
			global::DevConsole.Console.LogError(l1 + " not found!");
		}
	}

	private void ParseCommand(string command)
	{
		object output = LineParse.Execute(LineParse.Parse(command), ParserInstance);
		bool wasArray = false;
		global::DevConsole.Console.Log(LogOutput(output, ref wasArray, true, true));
	}

	private void ParseCommandToClip(string command)
	{
		object output = LineParse.Execute(LineParse.Parse(command), ParserInstance);
		bool wasArray = false;
		GUIUtility.systemCopyBuffer = LogOutput(output, ref wasArray, true, true);
	}

	private void EvaluateCommand(string command)
	{
	}

	public static string LogOutput(object output, ref bool wasArray, bool colored, bool indexed)
	{
		if (output == null)
		{
			return "null";
		}
		if (output is string)
		{
			return output.ToString();
		}
		object obj;
		if ((obj = output) is Color)
		{
			Color color = (Color)obj;
			return (colored ? "■".FontColor(color) : "#") + ColorUtility.ToHtmlStringRGBA(color);
		}
		if ((obj = output) is Color32)
		{
			Color32 color2 = (Color32)obj;
			return (colored ? "■".FontColor(color2) : "#") + ColorUtility.ToHtmlStringRGBA(color2);
		}
		IDictionary dictionary;
		if ((dictionary = output as IDictionary) != null)
		{
			bool wasArray2 = false;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DictionaryEntry item in dictionary)
			{
				stringBuilder.AppendLine(string.Format("\"{0}\" = {1}", LogOutput(item.Key, ref wasArray2, colored, indexed), LogOutput(item.Value, ref wasArray2, colored, indexed)));
			}
			wasArray = true;
			return stringBuilder.ToString();
		}
		IEnumerable source;
		if ((source = output as IEnumerable) != null)
		{
			wasArray = true;
			bool subArr = false;
			string[] value = (indexed ? source.Cast<object>().Select((object x, int i) => i + ": " + LogOutput(x, ref subArr, colored, indexed)).ToArray() : (from object x in source
				select LogOutput(x, ref subArr, colored, indexed)).ToArray());
			if (subArr)
			{
				return string.Join("\n", value);
			}
			return "[ " + string.Join("; ", value) + " ]";
		}
		return output.ToString();
	}

	private void ParseCommandOut(string command)
	{
		global::DevConsole.Console.Log(LineParse.WriteTree(LineParse.Parse(command)));
	}

	private void InstaRelease()
	{
		if (HUD.Instance != null && HUD.Instance.docWindow.Window.Shown)
		{
			HUD.Instance.docWindow.DevelopClick(true);
		}
	}

	public static void HireEmployees(int n, string role)
	{
		Employee.EmployeeRole role2 = (Employee.EmployeeRole)Enum.Parse(typeof(Employee.EmployeeRole), role, true);
		Employee[] array = HUD.Instance.hireWindow.HireWin.GenerateEmployees(n, Employee.WageBracket.High, role2, false, null, null, null, Employee.Trait.None, Employee.Trait.None);
		for (int i = 0; i < array.Length; i++)
		{
			GameSettings.Instance.SpawnActor(array[i]);
		}
	}

	public static HashSet<Type> GetValidScopeTypes()
	{
		if (_validScopeTypes == null)
		{
			_validScopeTypes = new HashSet<Type>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				try
				{
					Type[] types = assembly.GetTypes();
					foreach (Type type in types)
					{
						object[] customAttributes = type.GetCustomAttributes(typeof(AllowScopeListAttribute), true);
						if (customAttributes.Length != 0 && ((AllowScopeListAttribute)customAttributes[0]).Allow)
						{
							_validScopeTypes.Add(type);
						}
					}
				}
				catch (Exception ex)
				{
					Debug.LogError("Failed loading types for " + assembly.FullName + ":\n" + ex.ToString());
				}
			}
		}
		return _validScopeTypes;
	}

	public static Type GetScopeType(string input, out string err, out string fullErr)
	{
		err = null;
		fullErr = null;
		string[] split = input.Split('.');
		Type type = GetValidScopeTypes().FirstOrDefault((Type x) => x.Name.Equals(split[0]));
		if (type != null)
		{
			Type type2 = type;
			for (int num = 1; num < split.Length; num++)
			{
				string text = split[num];
				int num2 = text.IndexOf('(');
				int num3 = 0;
				if (num2 > -1)
				{
					num3 = text.Substring(num2 + 1).TrimEnd(')').ConvertToInt("Generic index");
					text = text.Remove(num2);
				}
				MemberInfo[] member = type2.GetMember(text, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
				if (member.Length == 0)
				{
					err = text;
					return null;
				}
				Type type3;
				if ((object)(type3 = member[0] as Type) != null && type3.IsEnum)
				{
					type2 = type3;
				}
				else
				{
					FieldInfo fieldInfo = member[0] as FieldInfo;
					if (fieldInfo != null)
					{
						type2 = fieldInfo.FieldType;
					}
					else
					{
						PropertyInfo propertyInfo = member[0] as PropertyInfo;
						if (propertyInfo != null)
						{
							type2 = propertyInfo.PropertyType;
						}
						else
						{
							MethodInfo methodInfo = member[0] as MethodInfo;
							if (methodInfo != null && num2 > -1)
							{
								ParameterInfo[] parameters = methodInfo.GetParameters();
								if (num3 >= 0 && num3 < parameters.Length)
								{
									type2 = parameters[num3].ParameterType;
								}
								else
								{
									bool flag = false;
									for (int num4 = 1; num4 < member.Length; num4++)
									{
										MethodInfo methodInfo2 = member[num4] as MethodInfo;
										if (methodInfo2 != null)
										{
											parameters = methodInfo2.GetParameters();
											if (num3 >= 0 && num3 < parameters.Length)
											{
												type2 = parameters[num3].ParameterType;
												flag = true;
												break;
											}
										}
									}
									if (!flag)
									{
										err = text;
										fullErr = "Argument out of range for function: " + text;
										return null;
									}
								}
							}
							else
							{
								if (!(methodInfo != null) || !(methodInfo.ReturnType != typeof(void)))
								{
									if (methodInfo != null)
									{
										fullErr = "Can't extract info from void function: " + text;
									}
									err = text;
									return null;
								}
								type2 = methodInfo.ReturnType;
							}
						}
					}
				}
				if (type2.IsGenericType && num2 > -1)
				{
					Type[] genericArguments = type2.GetGenericArguments();
					if (num3 < 0 || num3 >= genericArguments.Length)
					{
						fullErr = "Argument out of range for generic type: " + text;
						err = text;
						return null;
					}
					type2 = genericArguments[num3];
				}
				while (type2.IsArray)
				{
					type2 = type2.GetElementType();
				}
			}
			return type2;
		}
		return null;
	}

	private static void ListScopeVariables(string input)
	{
		string[] array = input.Split('.');
		HashSet<Type> validScopeTypes = GetValidScopeTypes();
		Color c = new Color(0.5f, 1f, 0.5f);
		Color c2 = new Color(0.5f, 0.5f, 1f);
		Color c3 = new Color(1f, 0.5f, 0.5f);
		string err = null;
		string fullErr;
		Type scopeType = GetScopeType(input, out err, out fullErr);
		if (scopeType == null)
		{
			if (fullErr != null)
			{
				global::DevConsole.Console.Log(fullErr);
			}
			else if (err == null)
			{
				StringBuilder stringBuilder = new StringBuilder("Scope: " + array[0] + " not found. Valid options are:\n");
				foreach (Type item in validScopeTypes)
				{
					stringBuilder.AppendLine(item.Name.FontColor(c2));
				}
				global::DevConsole.Console.Log(stringBuilder.ToString());
			}
			else
			{
				global::DevConsole.Console.Log("Member: " + err + " not found");
			}
			return;
		}
		StringBuilder stringBuilder2 = new StringBuilder("Listing content of type " + TypeToString(scopeType).FontColor(c2) + ":\n");
		if (scopeType.IsEnum)
		{
			string[] names = Enum.GetNames(scopeType);
			Array values = Enum.GetValues(scopeType);
			Type underlyingType = Enum.GetUnderlyingType(scopeType);
			bool flag = scopeType.GetCustomAttributes(typeof(FlagsAttribute), true).Length != 0;
			stringBuilder2.AppendLine("Enum of type: " + underlyingType.Name);
			for (int i = 0; i < names.Length; i++)
			{
				if (flag)
				{
					int num = (int)values.GetValue(i);
					if (num == 0 || !Mathf.IsPowerOfTwo(num))
					{
						continue;
					}
				}
				stringBuilder2.Append(" * ");
				stringBuilder2.Append(names[i]);
				stringBuilder2.Append(" = ");
				stringBuilder2.AppendLine(Convert.ChangeType(values.GetValue(i), underlyingType).ToString());
			}
		}
		else
		{
			MemberInfo[] members = scopeType.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
			Type limit = typeof(LineParse.ScriptWorld);
			List<Type> list = (from x in members.OfType<Type>()
				where x.IsEnum
				select x).ToList();
			List<MethodInfo> list2 = (from x in members.OfType<MethodInfo>()
				where !x.IsSpecialName && ValidMethod(x, limit)
				select x).ToList();
			List<FieldInfo> list3 = (from x in members.OfType<FieldInfo>()
				where !x.IsSpecialName
				select x).ToList();
			List<PropertyInfo> list4 = (from x in members.OfType<PropertyInfo>()
				where !x.IsSpecialName
				select x).ToList();
			if (list.Count > 0)
			{
				stringBuilder2.AppendLine("<b>Enums:</b>");
				foreach (Type item2 in list.OrderBy((Type x) => x.Name))
				{
					stringBuilder2.AppendLine(TypeToString(item2).FontColor(c2) + ";");
				}
			}
			if (list4.Count > 0)
			{
				stringBuilder2.AppendLine("<b>Properties:</b>");
				foreach (PropertyInfo item3 in from x in list4
					orderby !x.GetGetMethod().IsStatic, x.Name
					select x)
				{
					if (item3.GetGetMethod().IsStatic)
					{
						stringBuilder2.Append("Static ");
					}
					stringBuilder2.Append(TypeToString(item3.PropertyType).FontColor(c2));
					stringBuilder2.Append(" ");
					stringBuilder2.Append(item3.Name.FontColor(c));
					stringBuilder2.AppendLine(";");
				}
			}
			if (list3.Count > 0)
			{
				stringBuilder2.AppendLine("<b>Variables:</b>");
				foreach (FieldInfo item4 in from x in list3
					orderby !x.IsStatic, x.Name
					select x)
				{
					if (item4.IsStatic)
					{
						stringBuilder2.Append("Static ");
					}
					stringBuilder2.Append(TypeToString(item4.FieldType).FontColor(c2));
					stringBuilder2.Append(" ");
					stringBuilder2.Append(item4.Name.FontColor(c));
					stringBuilder2.AppendLine(";");
				}
			}
			if (list2.Count > 0)
			{
				stringBuilder2.AppendLine("<b>Functions:</b>");
				foreach (MethodInfo item5 in from x in list2
					orderby !x.IsStatic, x.Name
					select x)
				{
					if (item5.IsStatic)
					{
						stringBuilder2.Append("Static ");
					}
					stringBuilder2.Append(TypeToString(item5.ReturnType).FontColor(c2));
					stringBuilder2.Append(" ");
					stringBuilder2.Append(item5.Name.FontColor(c));
					stringBuilder2.Append("(");
					ParameterInfo[] parameters = item5.GetParameters();
					for (int num2 = 0; num2 < parameters.Length; num2++)
					{
						stringBuilder2.Append(TypeToString(parameters[num2].ParameterType).FontColor(c2));
						stringBuilder2.Append(" ");
						stringBuilder2.Append(parameters[num2].Name.FontColor(c));
						if (parameters[num2].IsOptional)
						{
							stringBuilder2.Append(" = ");
							stringBuilder2.Append((parameters[num2].DefaultValue ?? "null").ToString().FontColor(c3));
						}
						if (num2 < parameters.Length - 1)
						{
							stringBuilder2.Append(", ");
						}
					}
					stringBuilder2.AppendLine(");");
				}
			}
		}
		global::DevConsole.Console.Singleton.Clear();
		global::DevConsole.Console.Log(stringBuilder2.ToString(), "000000");
	}

	private static bool ValidMethod(MethodInfo info, Type limit)
	{
		return !info.GetBaseDefinition().DeclaringType.IsAssignableFrom(limit);
	}

	private static string TypeToString(Type t)
	{
		if (t.IsGenericType)
		{
			Type genericTypeDefinition = t.GetGenericTypeDefinition();
			if (genericTypeDefinition == typeof(Nullable<>))
			{
				return TypeToString(t.GetGenericArguments()[0]) + "?";
			}
			string text = genericTypeDefinition.Name;
			int num = text.IndexOf('`');
			if (num > -1)
			{
				text = text.Remove(num);
			}
			text += "<";
			Type[] genericArguments = t.GetGenericArguments();
			for (int i = 0; i < genericArguments.Length; i++)
			{
				text += TypeToString(genericArguments[i]);
				if (i < genericArguments.Length - 1)
				{
					text += ", ";
				}
			}
			return text + ">";
		}
		if (t.IsArray)
		{
			int arrayRank = t.GetArrayRank();
			if (arrayRank > 1)
			{
				string text2 = TypeToString(t.GetElementType()) + "[";
				for (int j = 1; j < arrayRank; j++)
				{
					text2 += ",";
				}
				return text2 + "]";
			}
			return TypeToString(t.GetElementType()) + "[]";
		}
		return TypeRedirection.GetOrDefault(t, t.Name);
	}

	private void ReloadTutorials()
	{
		ReloadLocalizations();
		TutorialSystem.Instance.LoadTutorials();
		if (TutorialSystem.Instance.CurrentTutorial != null)
		{
			TutorialSystem.Instance.CurrentTutorial = TutorialSystem.Tutorials[TutorialSystem.Instance.CurrentTutorialName];
			TutorialSystem.Instance.CurrentMessage--;
			TutorialSystem.Instance.AdvanceTutorial(false, false);
		}
	}

	public static void UIUnderMouse()
	{
		List<string> list = new List<string>();
		HashSet<Transform> hashSet = new HashSet<Transform>();
		if (EventSystem.current != null)
		{
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.pointerId = -1;
			pointerEventData.position = Input.mousePosition;
			List<RaycastResult> list2 = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, list2);
			foreach (RaycastResult item in list2)
			{
				Transform transform = item.gameObject.transform;
				if (!hashSet.Contains(transform))
				{
					string pathToObject = WindowManager.GetPathToObject(transform, hashSet);
					if (pathToObject != null)
					{
						list.Add(pathToObject);
					}
				}
			}
		}
		if (list.Count == 0)
		{
			global::DevConsole.Console.Log("No objects found");
			return;
		}
		list.Insert(0, "Found " + list.Count + " objects:");
		global::DevConsole.Console.Log(string.Join("\n", list.ToArray()));
	}

	public static void ExportCSV()
	{
		if (!(EventSystem.current != null))
		{
			return;
		}
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		pointerEventData.pointerId = -1;
		pointerEventData.position = Input.mousePosition;
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointerEventData, list);
		foreach (RaycastResult item in list)
		{
			GUIListView component = item.gameObject.GetComponent<GUIListView>();
			if (component != null)
			{
				component.ExportCSV();
				global::DevConsole.Console.Log("CSV copied to clipboard");
				break;
			}
		}
	}

	public static void UIComponents(string arg)
	{
		RectTransform rectTransform = WindowManager.FindElementPath(arg);
		if (rectTransform != null)
		{
			Component[] components = rectTransform.gameObject.GetComponents<Component>();
			List<string> list = new List<string> { "Found components:" };
			list.AddRange(components.Select((Component x) => x.GetType().Name));
			global::DevConsole.Console.Log(string.Join("\n", list.ToArray()));
		}
		else
		{
			global::DevConsole.Console.Log("Element does not exist");
		}
	}

	public static void ReloadMod(string args)
	{
		IWorkshopItem workshopItem = GameData.ModPackages.FirstOrDefault((ModPackage x) => x.ItemTitle.Equals(args));
		if (workshopItem == null)
		{
			workshopItem = ModWindow.Mods[typeof(FailMod)].FirstOrDefaultOf((FailMod x) => x.ItemTitle.Equals(args));
		}
		if (workshopItem == null)
		{
			string text = Path.Combine("Mods", args);
			if (Directory.Exists(text))
			{
				ModPackage item;
				try
				{
					item = ModPackage.Load(text);
				}
				catch (Exception ex)
				{
					global::DevConsole.Console.LogError("Failed loading mod with error:\n" + ex.Message);
					return;
				}
				GameData.ModPackages.Add(item);
				global::DevConsole.Console.Log("Mod reloaded, start a new game to use");
				return;
			}
		}
		if (workshopItem == null)
		{
			global::DevConsole.Console.LogError("Could not find mod, current mods:\n" + string.Join("\n", GameData.ModPackages.SelectInPlace((ModPackage x) => x.ItemTitle)));
			return;
		}
		ModPackage item2;
		try
		{
			item2 = ModPackage.Load(workshopItem.Root);
		}
		catch (Exception ex2)
		{
			global::DevConsole.Console.LogError("Failed loading mod with error:\n" + ex2.Message);
			return;
		}
		ModPackage modPackage;
		if ((modPackage = workshopItem as ModPackage) != null)
		{
			modPackage.Unload();
			GameData.ModPackages.Remove(modPackage);
		}
		ModWindow.RemoveMod(workshopItem);
		GameData.ModPackages.Add(item2);
		global::DevConsole.Console.Log("Mod reloaded, start a new game to use");
	}

	public static void ToggleCeiling(bool val)
	{
		Cheats.CeilingMeshes = val;
	}

	public static void StoreCameraState()
	{
		StCamFloor = GameSettings.Instance.ActiveFloor;
		StCamPos = CameraScript.Instance.transform.position.FlattenVector3();
		StCamDir = CameraScript.Instance.transform.rotation;
		StCamZoom = CameraScript.Instance.mainCam.transform.localPosition.z;
	}

	public static void RestoreCameraState()
	{
		CameraScript.Instance.transform.position = StCamPos.ToVector3((float)StCamFloor * 2f);
		GameSettings.Instance.ActiveFloor = StCamFloor;
		Furniture.UpdateEdgeDetection();
		GameSettings.Instance.sRoomManager.ChangeFloor();
		CameraScript.GotoPos(StCamPos);
		CameraScript.Instance.transform.rotation = StCamDir;
		CameraScript.Instance.mainCam.transform.localPosition = Vector3.forward * StCamZoom;
		CameraScript.Instance.RefreshZoom();
	}

	public static void FlycamDistance(float args)
	{
		CameraScript.FlyCamDistance = Mathf.Clamp(args, 1f, 10f);
	}

	public static void WayPoints()
	{
		if (WayPointEditorWindow.Instance != null)
		{
			WayPointEditorWindow.Instance.enabled = true;
			WayPointEditorWindow.Instance.Window.Show();
		}
	}

	public static void FurnitureThumbnail(string args)
	{
		if (FurnitureThumbnailMaker.Instance != null)
		{
			FurnitureThumbnailMaker.Instance.TakePicture(args);
		}
		else
		{
			global::DevConsole.Console.Log("Please execute this command in the main menu");
		}
	}

	public static void FurnitureBounds(string args)
	{
		FurnitureLoader.BakeBounds(ObjectDatabase.Instance.GetFurnitureComponent(args));
	}

	public static void AgeEmployees(int args)
	{
		if (SelectorController.Instance != null)
		{
			SelectorController.Instance.Selected.OfType<Actor>().ToList().ForEach(delegate(Actor x)
			{
				x.employee.BirthDate -= args;
				x.UpdateAgeLook();
			});
		}
	}

	private static void ApproveSDF()
	{
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			SDFDownloader sDFDownloader = FindObject<SDFDownloader>(rootGameObjects[i].transform);
			if (sDFDownloader != null && sDFDownloader.AuthMode)
			{
				sDFDownloader.transform.parent.parent.GetComponent<GUIWindow>().Show();
				sDFDownloader.ShowDefault();
				break;
			}
		}
	}

	private static T FindObject<T>(Transform cur) where T : MonoBehaviour
	{
		T component = cur.GetComponent<T>();
		if (component != null)
		{
			return component;
		}
		for (int i = 0; i < cur.childCount; i++)
		{
			component = FindObject<T>(cur.GetChild(i));
			if (component != null)
			{
				return component;
			}
		}
		return null;
	}

	public static void SkipDay(int days)
	{
		if (GameSettings.Instance.IsReferenceNull() || GameSettings.ForcePause)
		{
			return;
		}
		int hour = TimeOfDay.Instance.Hour;
		bool flag = false;
		for (int i = 0; i < days; i++)
		{
			if (TimeOfDay.Instance.WaitingOnNetwork())
			{
				break;
			}
			do
			{
				flag |= TimeOfDay.Instance.AddHour(!flag, 60f);
				if (TimeOfDay.Instance.WaitingOnNetwork())
				{
					float minuteDelta = 60f - TimeOfDay.Instance.Minute;
					TimeOfDay.Instance.SimulateMinutes(minuteDelta);
					TimeOfDay.Instance.SetupTimeSync();
					TimeOfDay.SyncPlayerTime();
					break;
				}
			}
			while (!GameSettings.ForcePause && TimeOfDay.Instance.Hour != hour && !flag);
			if (GameSettings.ForcePause || flag)
			{
				break;
			}
		}
		GameSettings.Instance.sActorManager.Others["Parent"].ForEachEnum(delegate(Actor x)
		{
			x.UpdateParentState();
		});
	}

	public static void SkipHour(int args)
	{
		if (GameSettings.Instance.IsReferenceNull() || GameSettings.ForcePause)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < args; i++)
		{
			flag |= TimeOfDay.Instance.AddHour(!flag, 60f);
			if (GameSettings.ForcePause || flag)
			{
				break;
			}
		}
		GameSettings.Instance.sActorManager.Others["Parent"].ForEachEnum(delegate(Actor x)
		{
			x.UpdateParentState();
		});
	}

	public static void SkipTo(int args)
	{
		args = Mathf.Clamp(args, 0, 23);
		if (!GameSettings.Instance.IsReferenceNull() && !GameSettings.ForcePause)
		{
			bool flag = false;
			do
			{
				flag |= TimeOfDay.Instance.AddHour(!flag, 60f);
			}
			while (!GameSettings.ForcePause && TimeOfDay.Instance.Hour != args && !flag);
			GameSettings.Instance.sActorManager.Others["Parent"].ForEachEnum(delegate(Actor x)
			{
				x.UpdateParentState();
			});
		}
	}

	public static void ClearDirt()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.sRoomManager.Rooms.ForEach(delegate(Room room)
			{
				room.ClearDirt();
			});
		}
	}

	public static void AddMoney(float args, bool valuated, bool taxed)
	{
		if (!GameSettings.Instance.IsReferenceNull() && (!NetworkManager.IsConnected || NetworkManager.IsHost))
		{
			GameSettings.Instance.MyCompany.MakeTransaction(args, Company.TransactionCategory.Sales, taxed, "Cheat", valuated);
			if (NetworkManager.IsConnected)
			{
				NetworkMessaging.SendPlayerMessage("MultiplayerMoneyCheat".Loc(NetworkManager.Self.Name, args.Currency()), true, 0u, NetworkMessaging.MessageTarget.Everyone, 0);
			}
		}
	}

	public static void SendMoney(float args, string target)
	{
		if (!GameSettings.Instance.IsReferenceNull() && (!NetworkManager.IsConnected || NetworkManager.IsHost))
		{
			NetworkPlayer networkPlayer = NetworkManager.Instance.Players.FirstOrDefault((NetworkPlayer x) => x.Name.Equals(target));
			Company company = ((networkPlayer != null) ? networkPlayer.GetPlayerCompany() : null);
			if (company != null)
			{
				company.MakeTransaction(args, Company.TransactionCategory.Sales, false, "Cheat");
				NetworkMessaging.SendPlayerMessage("MultiplayerMoneyCheat".Loc(target, args.Currency()), true, 0u, NetworkMessaging.MessageTarget.Everyone, 0);
			}
		}
	}

	public static void SetBusinessRep(float pct)
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			float num = pct - GameSettings.Instance.MyCompany.BusinessReputation;
			GameSettings.Instance.MyCompany.ChangeBusinessRep(num * 6f, "Cheat", 6f);
		}
	}

	public static void AddReputation(string soft, string cat, int fans)
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.MyCompany.AddFans(fans, MarketSimulation.Active.SoftwareTypes[soft].Categories[cat]);
		}
	}

	public static void SpawnDebugCar(int num)
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.StartCoroutine(SpawnCar(num));
		}
	}

	public static IEnumerator SpawnCar(int num)
	{
		for (int i = 0; i < num; i++)
		{
			bool rich = UnityEngine.Random.value > 0.9f;
			CarScript carScript = RoadManager.Instance.CreateCar(RoadManager.PickCar(rich));
			carScript.GetComponent<NormalCar>().Debug = true;
			carScript.Init();
			yield return new WaitForSeconds(0.25f);
		}
	}

	public static void ResetMoods()
	{
		if (SelectorController.Instance != null)
		{
			SelectorController.Instance.Selected.OfType<Actor>().ToList().ForEach(delegate(Actor x)
			{
				x.employee.Thoughts.Clear();
				x.employee.JobSatisfaction = 1f;
			});
		}
	}

	public static void ReloadMoods()
	{
		GameData.LoadMoodEffects();
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		for (int i = 0; i < GameSettings.Instance.sActorManager.Actors.Count; i++)
		{
			Actor actor = GameSettings.Instance.sActorManager.Actors[i];
			for (int j = 0; j < actor.employee.Thoughts.List.Count; j++)
			{
				actor.employee.Thoughts.List[j].ResetMood();
			}
		}
	}

	public static void MaxEmployee()
	{
		if (!(SelectorController.Instance != null))
		{
			return;
		}
		SelectorController.Instance.Selected.OfType<Actor>().ToList().ForEach(delegate(Actor x)
		{
			for (int i = 0; i < 5; i++)
			{
				Employee.EmployeeRole role = (Employee.EmployeeRole)i;
				x.employee.ChangeSkillDirect(role, 1f);
				string[] allSpecializations = GameSettings.Instance.GetAllSpecializations(role);
				int num = 0;
				for (int j = 0; j < allSpecializations.Length; j++)
				{
					if (x.employee.GetSpecialization(role, allSpecializations[j]) > 0)
					{
						x.employee.SetSpecialization(role, allSpecializations[j], 4);
						num += 4;
					}
				}
				if (num < GameSettings.GetMaxSpecPoints(role))
				{
					for (int k = 0; k < allSpecializations.Length; k++)
					{
						x.employee.SetSpecialization(role, allSpecializations[k], 4);
					}
				}
			}
		});
	}

	public static void SetEmployeeStats(float stat)
	{
		if (!(SelectorController.Instance != null))
		{
			return;
		}
		SelectorController.Instance.Selected.OfType<Actor>().ToList().ForEach(delegate(Actor x)
		{
			for (int i = 0; i < 5; i++)
			{
				Employee.EmployeeRole role = (Employee.EmployeeRole)i;
				x.employee.ChangeSkillDirect(role, stat);
			}
		});
	}

	public static void AddExp(string role)
	{
		if (SelectorController.Instance != null)
		{
			Employee.EmployeeRole r = (Employee.EmployeeRole)Enum.Parse(typeof(Employee.EmployeeRole), role);
			SelectorController.Instance.Selected.OfType<Actor>().ToList().ForEach(delegate(Actor x)
			{
				x.employee.AddSpecExperience(r, 1f);
			});
		}
	}

	public static void SetEmployeeStat(string role, string name, int stat)
	{
		if (SelectorController.Instance != null)
		{
			SelectorController.Instance.Selected.OfType<Actor>().ToList().ForEach(delegate(Actor x)
			{
				x.employee.SetSpecialization((Employee.EmployeeRole)Enum.Parse(typeof(Employee.EmployeeRole), role), name, stat);
			});
		}
	}

	public static void RndEmployeeStats()
	{
		if (!(SelectorController.Instance != null))
		{
			return;
		}
		SelectorController.Instance.Selected.OfType<Actor>().ToList().ForEach(delegate(Actor x)
		{
			for (int i = 0; i < 5; i++)
			{
				Employee.EmployeeRole role = (Employee.EmployeeRole)i;
				x.employee.ChangeSkillDirect(role, UnityEngine.Random.value);
				string[] unlockedSpecializations = GameSettings.Instance.GetUnlockedSpecializations(role);
				foreach (string spec in unlockedSpecializations)
				{
					x.employee.SetSpecialization(role, spec, UnityEngine.Random.Range(0, 5));
				}
			}
		});
	}

	public static void ToggleScraperTransparency(bool val)
	{
		SkraperGen.NeverTransparent = val;
	}

	public static void SpawnGuest()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			Actor actor = GameSettings.Instance.SpawnActor(UnityEngine.Random.value > 0.5f, true, true, "Business");
			actor.employee.Salary = 2500f;
			actor.AItype = AI.AIType.Guest;
			GameSettings.Instance.sActorManager.AddToAwaiting(actor, SDateTime.Now(), true);
		}
	}

	public static void SpawnRobber(int i)
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.SpawnBurglar(i);
		}
	}

	public static void ToggleLights(bool val)
	{
		Cheats.ForceLights = val;
	}

	public static void UnlockFurniture()
	{
		Cheats.UnlockFurn = !Cheats.UnlockFurn;
		if (HUD.Instance != null)
		{
			HUD.Instance.UpdateFurnitureButtons();
		}
	}

	public static void TakeAllLand()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			int count = GameSettings.Instance.Plots.Count;
			for (int i = 0; i < count; i++)
			{
				GameSettings.Instance.BuyPlot(GameSettings.Instance.Plots[0], true);
			}
		}
	}

	public static void CaptureScreen(string file, int scale)
	{
		if (scale < 1 || scale > 6)
		{
			global::DevConsole.Console.LogError("Scale not valid");
		}
		if (file.ToLower().EndsWith(".png"))
		{
			file = file.Substring(0, file.Length - 4);
		}
		file = Path.Combine("Capture", Utilities.CleanFileName(file));
		if (!Directory.Exists("Capture"))
		{
			Directory.CreateDirectory("Capture");
		}
		int i;
		for (i = 0; File.Exists(GetCaptureFile(file, i)); i++)
		{
		}
		RoomMaterialController.Instance.StartCoroutine(ScreenCap(GetCaptureFile(file, i), scale));
	}

	private static string GetCaptureFile(string fileName, int num)
	{
		return fileName + num.ToString("0000") + ".png";
	}

	public static IEnumerator ScreenCap(string file, int scale)
	{
		global::DevConsole.Console.Singleton.gameObject.SetActive(false);
		WindowManager.Instance.Canvas.gameObject.SetActive(false);
		int ssaa = Options.SSAA;
		Options.SSAA = 10;
		yield return new WaitForEndOfFrame();
		ScreenCapture.CaptureScreenshot(file, scale);
		yield return new WaitForEndOfFrame();
		Options.SSAA = ssaa;
		WindowManager.Instance.Canvas.gameObject.SetActive(true);
		global::DevConsole.Console.Singleton.gameObject.SetActive(true);
	}

	public static void WriteErrors()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (GameSettings.Instance.Errors.Count == 0)
		{
			global::DevConsole.Console.Log("No errors present");
			return;
		}
		foreach (string error in GameSettings.Instance.Errors)
		{
			global::DevConsole.Console.Log(error);
		}
	}

	private static void ConvertLocXML(string locName)
	{
		Localization.Translation language = Localization.GetLanguage(locName);
		if (language != null)
		{
			string text = language.FolderPath();
			string[] files = Directory.GetFiles(text, "*.xml");
			foreach (string path in files)
			{
				XMLParser.XMLNode node = XMLParser.ParseXML(File.ReadAllText(path));
				StringBuilder stringBuilder = new StringBuilder();
				ConvertXML(node, stringBuilder, 0, null, true);
				File.WriteAllText(Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".tyd"), stringBuilder.ToString());
			}
			Localization.AddLanguage(new Localization.Translation(text));
		}
		else
		{
			global::DevConsole.Console.LogError("Translation folder doesn't exist");
		}
	}

	private static void CheckSpecs(string mod)
	{
		ModPackage modPackage = null;
		if (!string.IsNullOrEmpty(mod))
		{
			modPackage = GameData.ModPackages.FirstOrDefault((ModPackage x) => x.ItemTitle.Equals(mod));
			if (modPackage == null)
			{
				global::DevConsole.Console.LogError("Couldn't find mod with that name, current mods:\n" + string.Join("\n", GameData.ModPackages.SelectInPlace((ModPackage x) => x.ItemTitle)));
				return;
			}
		}
		SoftwareType[] array = ((modPackage == null) ? GameData.AllSoftwareTypes() : GameData.AllSoftwareTypes(new ModPackage[1] { modPackage })).ToArray();
		Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>
		{
			{
				"Art",
				new HashSet<string>()
			},
			{
				"Code",
				new HashSet<string>()
			}
		};
		Dictionary<string, HashSet<KeyValuePair<string, int>>> dictionary2 = new Dictionary<string, HashSet<KeyValuePair<string, int>>>
		{
			{
				"Art",
				new HashSet<KeyValuePair<string, int>>()
			},
			{
				"Code",
				new HashSet<KeyValuePair<string, int>>()
			}
		};
		for (int num = 0; num < array.Length; num++)
		{
			foreach (FeatureBase allFeature in array[num].GetAllFeatures())
			{
				if (allFeature.CodeArtRatio > 0f)
				{
					dictionary["Code"].Add(allFeature.Spec);
					dictionary2["Code"].Add(new KeyValuePair<string, int>(allFeature.Spec, allFeature.Level));
				}
				if (allFeature.CodeArtRatio < 1f)
				{
					dictionary["Art"].Add(allFeature.Spec);
					dictionary2["Art"].Add(new KeyValuePair<string, int>(allFeature.Spec, allFeature.Level));
				}
			}
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HashSet<string>> item2 in dictionary)
		{
			foreach (string item3 in item2.Value)
			{
				for (int num2 = 1; num2 <= 3; num2++)
				{
					KeyValuePair<string, int> item = new KeyValuePair<string, int>(item3, num2);
					if (!dictionary2[item2.Key].Contains(item))
					{
						list.Add(string.Format("{0} {1} - Level {2}", item3, item2.Key, num2));
					}
				}
			}
		}
		if (list.Count > 0)
		{
			global::DevConsole.Console.LogWarning("None of the following specialization levels are represented in any software type:\n" + string.Join("\n", list.ToArray()));
		}
		else
		{
			global::DevConsole.Console.Log("All specialization levels are represented in software");
		}
	}

	private static void ConvertXML(XMLParser.XMLNode node, StringBuilder sb, int indent, TydCollection parent, bool root = false)
	{
		string text = node.TryGetAttribute("Name", node.TryGetAttribute("id"));
		if (text != null)
		{
			string text2 = node.Name.Replace("Message", "Tutorial");
			text = text.Strip(' ');
			bool flag = text2.Equals("Item");
			string text3 = node.TryGetAttribute("NamePlural");
			TydNode node2;
			if (node.Value != null || node.Children.Count == 1)
			{
				string val = node.Value ?? node.Children[0].Value;
				if (text3 == null && flag && !TydToText.ShouldWriteWithQuotes(text))
				{
					node2 = new TydString(text, val);
				}
				else
				{
					TydTable tydTable = new TydTable(text2);
					if (text3 == null && !TydToText.ShouldWriteWithQuotes(text))
					{
						tydTable.AddChild(new TydString(text, val));
					}
					else
					{
						tydTable.AddChild(new TydString("Name", text));
						if (text3 != null)
						{
							tydTable.AddChild(new TydString("Plural", text3.Strip(' ')));
						}
						tydTable.AddChild(new TydString("Value", val));
					}
					node2 = tydTable;
				}
			}
			else
			{
				string[] children = node.Children.Where((XMLParser.XMLNode x) => x.Children == null || x.Children.Count == 0).SelectNotNull((XMLParser.XMLNode x) => x.Value).ToArray();
				if (flag && !TydToText.ShouldWriteWithQuotes(text) && node.Children.TrueForAll((XMLParser.XMLNode x) => x.Children == null || x.Children.Count == 0))
				{
					node2 = new TydList(text, children);
				}
				else
				{
					TydTable tydTable2 = new TydTable(text2);
					if (!TydToText.ShouldWriteWithQuotes(text))
					{
						tydTable2.AddChild(new TydList(text, children));
					}
					else
					{
						tydTable2.AddChild(new TydString("Name", text));
						tydTable2.AddChild(new TydList("Value", children));
					}
					foreach (XMLParser.XMLNode item in node.Children.Where((XMLParser.XMLNode x) => x.Children != null && x.Children.Count > 0))
					{
						ConvertXML(item, sb, indent, tydTable2);
					}
					node2 = tydTable2;
				}
			}
			if (parent != null)
			{
				parent.AddChild(node2);
			}
			else
			{
				sb.AppendLine(TydToText.Write(node2, true, indent, 0, true));
			}
			return;
		}
		if (parent == null)
		{
			if (!root)
			{
				sb.AppendLine(TydToText.IndentString(indent) + "#" + node.Name);
			}
			int indent2 = (root ? indent : (indent + 1));
			{
				foreach (XMLParser.XMLNode child in node.Children)
				{
					ConvertXML(child, sb, indent2, null);
				}
				return;
			}
		}
		TydList tydList = new TydList(node.Name);
		foreach (XMLParser.XMLNode child2 in node.Children)
		{
			ConvertXML(child2, sb, indent, tydList);
		}
		parent.AddChild(tydList);
	}

	private static void MakeSequel(string name, float qual, uint follows, bool withTasks)
	{
		SoftwareProduct proto = MarketSimulation.Active.GetProductFromName(name);
		if (proto != null)
		{
			proto = proto.GetLatestSuccessor();
			SoftwareType type = proto.Type;
			SoftwareCategory category = proto.Category;
			FeatureBase[] features = proto.Features;
			Dictionary<string, SoftwareProduct> dictionary = DesignDocumentWindow.GenerateNeeds(type, category);
			List<SoftwareProduct> list = DesignDocumentWindow.GenerateOS(type, features);
			Dictionary<string, TechLevel> techs = SimulatedCompany.PickTechs(category, SDateTime.Now(), dictionary, null, GameSettings.Instance.MyCompany);
			double num = (double)GameSettings.Instance.simulation.GetIdealMarketPrice(category, proto.SubscriptionBased) * category.PerceivedValue(features, techs);
			double num2 = qual;
			SoftwareProduct softwareProduct = new SoftwareProduct(MarketSimulation.Active.GenerateProductSequalName(proto.Name), type, category, (list == null) ? Array.Empty<SoftwareProduct>() : list.ToArray(), num2, num2, num2, num2, new double[3] { num2, num2, num2 }, proto.CreativityScore, (float)num, proto.SubscriptionBased, proto.Submarkets.ToArray(), SDateTime.Now(), SDateTime.Now(), proto.StartBugss, proto.InHouse, GameSettings.Instance.MyCompany, proto, GameSettings.Instance.simulation.GetID(), 0.0, features.ToArray(), techs, proto.Server, follows, null, 0f, dictionary.Values.ToDictionary((SoftwareProduct x) => x, (SoftwareProduct x) => 0f));
			softwareProduct.SendNetwork();
			softwareProduct.PhysicalCopies = MarketSimulation.Population;
			GameSettings.Instance.MyCompany.Products.Add(softwareProduct);
			GameSettings.Instance.simulation.AddProduct(softwareProduct, false);
			if (withTasks)
			{
				SupportWork supportWork = new SupportWork(softwareProduct, -1);
				GameSettings.Instance.MyCompany.AddWorkItem(supportWork);
				SupportWork supportWork2 = GameSettings.Instance.MyCompany.WorkItems.OfType<SupportWork>().FirstOrDefault((SupportWork x) => x.TargetProduct == proto);
				if (supportWork2 != null)
				{
					if (supportWork2.CompanyWorker != null)
					{
						supportWork.CompanyWorker = supportWork2.CompanyWorker;
					}
					else
					{
						supportWork.AddDevTeams(supportWork2.DevTeams);
					}
				}
				else
				{
					GameSettings.Instance.ApplyDefaultTeams(supportWork, "Support");
				}
				MarketingPlan marketingPlan = GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>().FirstOrDefault((MarketingPlan x) => x.TargetProduct == proto);
				MarketingPlan marketingPlan2 = new MarketingPlan(0f, softwareProduct);
				GameSettings.Instance.MyCompany.AddWorkItem(marketingPlan2);
				if (marketingPlan != null)
				{
					if (marketingPlan.CompanyWorker != null)
					{
						marketingPlan2.CompanyWorker = marketingPlan.CompanyWorker;
					}
					else
					{
						marketingPlan2.AddDevTeams(marketingPlan.DevTeams);
					}
					marketingPlan.Kill();
				}
				else
				{
					GameSettings.Instance.ApplyDefaultTeams(marketingPlan2, "Market");
				}
			}
			SoftwareProduct.HandleNews(softwareProduct, false);
			softwareProduct.RunReleaseScripts();
		}
		else
		{
			global::DevConsole.Console.LogError("Product doesn't exist");
		}
	}

	public void TestSoftware(string mod, string softwareType, string category)
	{
		ModPackage modPackage = GameData.ModPackages.FirstOrDefault((ModPackage x) => x.ItemTitle.Equals(mod));
		if (modPackage == null)
		{
			global::DevConsole.Console.LogError("Mod not found, current mods:\n" + string.Join("\n", GameData.ModPackages.SelectInPlace((ModPackage x) => x.ItemTitle)));
			return;
		}
		SoftwareType softwareType2 = GameData.AllSoftwareTypes(new ModPackage[1] { modPackage }).FirstOrDefault((SoftwareType x) => x.Name.Equals(softwareType));
		if (softwareType2 == null)
		{
			global::DevConsole.Console.LogError("Software type not found");
			return;
		}
		SoftwareCategory orDefault = softwareType2.Categories.GetOrDefault(category);
		if (orDefault == null)
		{
			global::DevConsole.Console.LogError("Software type not found");
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		List<FeatureBase> list = new List<FeatureBase>();
		foreach (IGrouping<string, FeatureBase> item in from x in softwareType2.Features.Values
			group x by x.Spec)
		{
			SpecFeature specFeature = item.OfType<SpecFeature>().First();
			list.Add(specFeature);
			foreach (FeatureBase item2 in item)
			{
				if (item2 != specFeature)
				{
					list.Add(item2);
				}
			}
		}
		stringBuilder.AppendLine("Optimal development time: " + softwareType2.OptimalDevTime);
		stringBuilder.AppendLine("Max development time: " + list.SumSafe((FeatureBase x) => x.DevTime));
		Dictionary<FeatureBase, double[]> dictionary = new Dictionary<FeatureBase, double[]>();
		TechLevel techLevel = new TechLevel("Null", 0, 0f);
		techLevel.MarketOutdates[orDefault] = 0;
		techLevel.RefreshRelevancy(orDefault);
		double[] array = new double[3];
		foreach (FeatureBase item3 in list)
		{
			if (!(item3 is SpecFeature))
			{
				item3.GetSubAdd(orDefault, techLevel, array);
				dictionary[item3] = array.MultNewArray(1.0 / (double)item3.DevTime);
			}
		}
		List<SpecFeature> list2 = list.OfType<SpecFeature>().ToList();
		float devTime = techLevel.GetDevTime();
		int i;
		for (i = 0; i < 3; i++)
		{
			float num = 0f;
			array[i] = 0.0;
			foreach (SpecFeature item4 in list2)
			{
				item4.GetSubAdd(orDefault, techLevel, -1.0, array, true);
				num += item4.DevTime * devTime;
			}
			int num2 = 0;
			if (array[i] < 1.0)
			{
				foreach (KeyValuePair<FeatureBase, double[]> item5 in dictionary.OrderByDescending((KeyValuePair<FeatureBase, double[]> x) => x.Value[i]))
				{
					num2++;
					FeatureBase key = item5.Key;
					key.GetSubAdd(orDefault, techLevel, -1.0, array, true);
					num += key.DevTime * devTime;
					if (array[i] >= 1.0)
					{
						break;
					}
				}
			}
			if (array[i] >= 1.0)
			{
				stringBuilder.AppendLine(string.Format("Minimum development time for maxing {0}: {2} ({3} of optimal) with score: {1} and {4} sub features", softwareType2.SubMarkets[i], array[i].ToPercent(), num, (num / softwareType2.OptimalDevTime).ToPercent().FontColor(Color.Lerp(Color.green, Color.red, (num / softwareType2.OptimalDevTime - 1f) * 2f)), num2));
			}
			else
			{
				stringBuilder.AppendLine(string.Format("ONLY REACHED A SCORE OF {0} FOR {1}", array[i].ToPercent(), softwareType2.SubMarkets[i]).FontColor(Color.red));
			}
		}
		global::DevConsole.Console.Log(stringBuilder.ToString());
	}

	private static void StopFPS()
	{
		FPSStat component = CameraScript.Instance.mainCam.GetComponent<FPSStat>();
		if (component != null)
		{
			UnityEngine.Object.Destroy(component);
		}
	}

	private static void StartFPS()
	{
		if (CameraScript.Instance.mainCam.GetComponent<FPSStat>() == null)
		{
			CameraScript.Instance.mainCam.gameObject.AddComponent<FPSStat>();
		}
	}

	private static bool CheckProductCount(TransportBox[] boxes, ProductPrintOrder[] heli, StringBuilder sb)
	{
		Dictionary<IStockable, uint> stock = new Dictionary<IStockable, uint>();
		for (int i = 0; i < boxes.Length; i++)
		{
			AddStockUp(boxes[i].Order, stock);
		}
		for (int j = 0; j < heli.Length; j++)
		{
			AddStockUp(heli[j], stock);
		}
		foreach (ProductPallet productPallet in GameSettings.Instance.ProductPallets)
		{
			lock (productPallet)
			{
				for (int k = 0; k < productPallet.Orders.Length; k++)
				{
					AddStockUp(productPallet.Orders[k], stock);
				}
			}
		}
		lock (GameSettings.Instance.ProductPrinters)
		{
			foreach (ProductPrinter productPrinter in GameSettings.Instance.ProductPrinters)
			{
				if (productPrinter.Type == ProductPrinter.PrinterType.Product || productPrinter.IsFinalAssembly())
				{
					for (int l = 0; l < productPrinter.LocalOrders.Count; l++)
					{
						AddStockUp(productPrinter.LocalOrders[l], stock);
					}
				}
			}
		}
		foreach (Actor item in GameSettings.Instance.sActorManager.Staff)
		{
			if (item.AItype == AI.AIType.Courier && item.Order != null)
			{
				AddStockUp(item.Order, stock);
			}
		}
		return GameSettings.Instance.CheckStorage(stock, sb);
	}

	private static void AddStockUp(IProductOrder o, Dictionary<IStockable, uint> stock)
	{
		AddStockUp(o as ProductPrintOrder, stock);
	}

	private static void AddStockUp(ProductPrintOrder o, Dictionary<IStockable, uint> stock)
	{
		if (o != null)
		{
			for (int i = 0; i < o.Copies.Length; i++)
			{
				stock.AddUp(o.Stockables[i], o.Copies[i]);
			}
		}
	}

	public static void FixComponentCounts(bool print)
	{
		_compFix.Clear();
		TransportBox[] boxes = GameSettings.Instance.BoxController.GetBoxes().ToArray();
		bool flag = CheckProductCount(boxes, GameSettings.Instance.BoxController.GetHelicopterStorage().ToArray(), _compFix);
		lock (GameSettings.Instance.PrintOrders)
		{
			for (int i = 0; i < GameSettings.Instance.PrintOrders.Count; i++)
			{
				PrintJob printJob = GameSettings.Instance.PrintOrders[i];
				flag |= printJob.FixComponentCount(boxes, _compFix);
			}
		}
		if (print)
		{
			global::DevConsole.Console.Log(flag ? _compFix.ToString().TrimEnd() : "Found no inconsistencies");
		}
		else if (flag)
		{
			Debug.Log(_compFix.ToString().TrimEnd());
		}
		_compFix.Clear();
	}

	private static void ExportFurniturePoints(string name)
	{
		Furniture furniture = null;
		foreach (FurnitureMod item in FurnitureLoader.LoadedFurniture)
		{
			foreach (GameObject item2 in item.Furniture)
			{
				Furniture component = item2.GetComponent<Furniture>();
				if (component != null && component.name.Equals(name))
				{
					furniture = component;
					break;
				}
			}
			if (furniture != null)
			{
				break;
			}
		}
		if (furniture != null)
		{
			try
			{
				TydTable tydTable = TydFromText.ParseOne(File.ReadAllText(furniture.FileName)) as TydTable;
				TydList tydList = tydTable.AddChild(new TydList("InteractionPoints"));
				InteractionPoint[] interactionPoints = furniture.InteractionPoints;
				foreach (InteractionPoint interactionPoint in interactionPoints)
				{
					TydTable tydTable2 = tydList.AddChild(new TydTable(null));
					tydTable2.AddChild(new TydString("Name", interactionPoint.Action.ToString()));
					tydTable2.AddChild(interactionPoint.transform.localPosition.ToTyd("Position"));
					tydTable2.AddChild(interactionPoint.transform.localRotation.eulerAngles.ToTyd("Rotation"));
					if (interactionPoint.Animation != Actor.AnimationStates.Idle)
					{
						tydTable2.AddChild(new TydString("Animation", interactionPoint.Animation.ToString()));
					}
					if (interactionPoint.subAnimation != 0)
					{
						tydTable2.AddChild(new TydString("SubAnimation", interactionPoint.subAnimation.ToString()));
					}
					if (interactionPoint.MinimumNeeded != 1)
					{
						tydTable2.AddChild(new TydString("MinimumNeeded", interactionPoint.MinimumNeeded.ToString()));
					}
					if (!interactionPoint.NeedsReachCheck)
					{
						tydTable2.AddChild(new TydString("ReachCheck", interactionPoint.NeedsReachCheck.ToString()));
					}
					if (!interactionPoint.MainAction)
					{
						tydTable2.AddChild(new TydString("MainAction", interactionPoint.MainAction.ToString()));
					}
					if (!interactionPoint.ShowOnBuild)
					{
						tydTable2.AddChild(new TydString("ShowOnBuild", interactionPoint.ShowOnBuild.ToString()));
					}
					if (interactionPoint.Outside)
					{
						tydTable2.AddChild(new TydString("Outside", interactionPoint.Outside.ToString()));
					}
					if (interactionPoint.Child != null)
					{
						tydTable2.AddChild(new TydString("Child", interactionPoint.Child.Id.ToString()));
					}
				}
				TydList tydList2 = tydTable.AddChild(new TydList("SnapPoints"));
				SnapPoint[] snapPoints = furniture.SnapPoints;
				foreach (SnapPoint snapPoint in snapPoints)
				{
					TydTable tydTable3 = tydList2.AddChild(new TydTable(null));
					tydTable3.AddChild(new TydString("Name", snapPoint.Name));
					tydTable3.AddChild(snapPoint.transform.localPosition.ToTyd("Position"));
					tydTable3.AddChild(snapPoint.transform.localRotation.eulerAngles.ToTyd("Rotation"));
					if (!snapPoint.CheckValid)
					{
						tydTable3.AddChild(new TydString("CheckValid", snapPoint.CheckValid.ToString()));
					}
					if (snapPoint.InitLinks != null && snapPoint.InitLinks.Length != 0)
					{
						tydTable3.AddChild(new TydList("Links", snapPoint.InitLinks.SelectInPlace((SnapPoint x) => x.ToString())));
					}
					if (snapPoint.Blocking != null && snapPoint.Blocking.Length != 0)
					{
						tydTable3.AddChild(new TydList("Blocking", snapPoint.Blocking.SelectInPlace((SnapPoint x) => x.ToString())));
					}
				}
				File.WriteAllText(furniture.FileName, TydToText.Write(tydTable, true));
				global::DevConsole.Console.Log("Data written to file");
				return;
			}
			catch (Exception ex)
			{
				global::DevConsole.Console.LogError(ex.ToString());
				return;
			}
		}
		global::DevConsole.Console.LogError("Furniture not present in game");
	}

	public static void GotoHardwareEditor()
	{
		FrameTransition.StartTransition(true);
		ErrorLogging.FirstOfScene = true;
		ErrorLogging.SceneChanging = true;
		GameSettings.Instance = null;
		global::DevConsole.Console.SaveConsole();
		SceneManager.LoadScene("HardwareDesignEditor");
	}

	public static void GotoFurnitureEditor()
	{
		FrameTransition.StartTransition(true);
		ErrorLogging.FirstOfScene = true;
		ErrorLogging.SceneChanging = true;
		GameSettings.Instance = null;
		global::DevConsole.Console.SaveConsole();
		SceneManager.LoadScene("ThumbTool");
	}

	private static void ClearSubScore(double[] score)
	{
		for (int i = 0; i < 3; i++)
		{
			score[i] = 0.0;
		}
	}

	private static void PrintSubSubScore(double score, StringBuilder sb, float minValue, float sweetSpotMin, float sweetSpotMax)
	{
		if (score < (double)minValue)
		{
			sb.Append(score.ToPercent(false).FontColor(Color.red));
		}
		else if (score >= (double)sweetSpotMin && score <= (double)sweetSpotMax)
		{
			sb.Append(score.ToPercent(false).FontColor(Color.green));
		}
		else
		{
			sb.Append(score.ToPercent(false));
		}
	}

	private static void PrintSubScore(double[] score, StringBuilder sb, float minValue, float sweetSpotMin, float sweetSpotMax)
	{
		sb.Append("[ ");
		PrintSubSubScore(score[0], sb, minValue, sweetSpotMin, sweetSpotMax);
		sb.Append(", ");
		PrintSubSubScore(score[1], sb, minValue, sweetSpotMin, sweetSpotMax);
		sb.Append(", ");
		PrintSubSubScore(score[2], sb, minValue, sweetSpotMin, sweetSpotMax);
		sb.Append(" ]");
	}

	private static void CheckAddonBalance(string mod, string swS, string addonS)
	{
		ModPackage modPackage = GameData.ModPackages.FirstOrDefault((ModPackage x) => x.ItemTitle.Equals(mod));
		if (modPackage == null)
		{
			global::DevConsole.Console.LogError("Mod not found, loading default software");
		}
		SoftwareType sw = GameData.AllSoftwareTypes((modPackage == null) ? new ModPackage[0] : new ModPackage[1] { modPackage }).FirstOrDefault((SoftwareType x) => x.Name.Equals(swS));
		if (sw == null)
		{
			global::DevConsole.Console.LogError("Software type not found");
			return;
		}
		SoftwareAddOn orDefault = sw.AddOns.GetOrDefault(addonS);
		if (orDefault == null)
		{
			global::DevConsole.Console.LogError("Add-on not found");
		}
		else if (!GameSettings.Instance.IsReferenceNull())
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Score in: [ " + sw.SubMarkets[0] + ", " + sw.SubMarkets[1] + ", " + sw.SubMarkets[2] + " ]");
			double[] array = new double[3];
			double[] array2 = new double[3];
			double[] array3 = new double[3];
			foreach (SoftwareCategory item in orDefault.Categories.Select((string x) => sw.Categories[x]))
			{
				ClearSubScore(array);
				ClearSubScore(array2);
				if (orDefault.BaseFeature != null)
				{
					orDefault.BaseFeature.GetSubAdd(orDefault, item, null, 1.0, array3, 1u);
					array.AddArray(array3);
					array2.AddArray(array3);
				}
				foreach (AddOnFeature f in orDefault.Features.Values)
				{
					if (!f.IsCompatible(item.Name))
					{
						continue;
					}
					f.GetSubAdd(orDefault, item, null, 1.0, array3, f.MaxFactor);
					array2.AddArray(array3);
					if (!f.Unlock.HasValue && f.FeatureDependency == null)
					{
						SpecFeature specFeature = sw.Features.Values.OfType<SpecFeature>().FirstOrDefault((SpecFeature x) => x.Spec.Equals(f.Spec));
						if (specFeature != null && specFeature.Forced)
						{
							array.AddArray(array3);
						}
					}
				}
				stringBuilder.Append("Score for " + item.Name + " with no features unlocked: ");
				PrintSubScore(array, stringBuilder, 0.1f, 0.25f, 0.75f);
				stringBuilder.Append(" with all features unlocked: ");
				PrintSubScore(array2, stringBuilder, 1f, 1.5f, 2f);
				stringBuilder.AppendLine();
			}
			global::DevConsole.Console.Log(stringBuilder.ToString().TrimEnd());
		}
		else
		{
			global::DevConsole.Console.LogError("Please load a game up first");
		}
	}

	private static void NamesToChance(string inputFile, string outputFile)
	{
		if (File.Exists(inputFile))
		{
			Dictionary<char, Dictionary<char, int>> dictionary = new Dictionary<char, Dictionary<char, int>>();
			Dictionary<char, int> dict = new Dictionary<char, int>();
			HashSet<char> hashSet = new HashSet<char>();
			Dictionary<char, int> dictionary2 = new Dictionary<char, int>();
			string[] array = File.ReadAllLines(inputFile);
			foreach (string text in array)
			{
				for (int j = 0; j < text.Length; j++)
				{
					char c = text[j];
					hashSet.Add(c);
					if (j == 0)
					{
						dictionary2.AddUp(c);
					}
					if (j + 1 < text.Length)
					{
						char key = text[j + 1];
						Dictionary<char, int> value;
						if (!dictionary.TryGetValue(c, out value))
						{
							value = (dictionary[c] = new Dictionary<char, int>());
						}
						value.AddUp(key);
					}
					else
					{
						dict.AddUp(c);
					}
				}
			}
			TydDocument tydDocument = new TydDocument();
			int maxSt = dictionary2.SumSafe((KeyValuePair<char, int> x) => x.Value);
			tydDocument.AddChild(new TydList("Starting", dictionary2.UnZip((KeyValuePair<char, int> x) => x.Key.ToString(), (KeyValuePair<char, int> x) => ((float)x.Value / (float)maxSt).ToString()).ToArray()));
			foreach (char item in hashSet)
			{
				Dictionary<string, float> dictionary4 = new Dictionary<string, float>();
				Dictionary<char, int> orNull = dictionary.GetOrNull(item);
				int orDefault = dict.GetOrDefault(item, 0);
				int num = orDefault;
				if (orNull != null)
				{
					num += orNull.SumSafe((KeyValuePair<char, int> x) => x.Value);
					foreach (KeyValuePair<char, int> item2 in orNull)
					{
						dictionary4[item2.Key.ToString()] = (float)item2.Value / (float)num;
					}
				}
				if (orDefault > 0)
				{
					dictionary4[""] = (float)orDefault / (float)num;
				}
				TydTable tydTable = tydDocument.AddChild(new TydTable("Node"));
				tydTable.AddChild(new TydString("Value", item.ToString()));
				tydTable.AddChild(new TydList("Chances", dictionary4.UnZip((KeyValuePair<string, float> x) => x.Key, (KeyValuePair<string, float> x) => x.Value.ToString()).ToArray()));
			}
			File.WriteAllText(outputFile, TydToText.Write(tydDocument, true));
			global::DevConsole.Console.Log("Successfully written to: " + outputFile);
		}
		else
		{
			global::DevConsole.Console.LogError("Input file does not exist:" + inputFile);
		}
	}

	private static void FindBoxesFor(string name)
	{
		SelectorController.Instance.Highligt(false);
		SelectorController.Instance.Selected.Clear();
		foreach (Furniture item in GameSettings.Instance.sRoomManager.AllFurniture)
		{
			if (item.Conveyor != null)
			{
				for (int i = 0; i < item.Conveyor.CurrentBoxes.Length; i++)
				{
					TransportBox transportBox = item.Conveyor.CurrentBoxes[i];
					ManufactureOrder manufactureOrder;
					if (transportBox != null && (manufactureOrder = transportBox.Order as ManufactureOrder) != null && manufactureOrder.Target.GetIdentifyingName().Equals(name))
					{
						SelectorController.Instance.Selected.Add(item);
						break;
					}
				}
			}
			else
			{
				if (!(item.Printer != null) || item.Printer.Type != ProductPrinter.PrinterType.Assembly)
				{
					continue;
				}
				for (int j = 0; j < item.Printer.ManufactureQueue.Count; j++)
				{
					if (item.Printer.ManufactureQueue[j].Target.GetIdentifyingName().Equals(name))
					{
						SelectorController.Instance.Selected.Add(item);
						break;
					}
				}
			}
		}
		SelectorController.Instance.DoPostSelectChecks();
	}

	private static void GetFurnGrouping()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (IGrouping<ValueTuple<string, int>, Furniture> item in from x in ObjectDatabase.Instance.GetAllFurnitureComponents()
			group x by new ValueTuple<string, int>(x.Type, x.SelectionSubType))
		{
			stringBuilder.AppendLine(item.Key.ToString());
			foreach (Furniture item2 in item)
			{
				stringBuilder.AppendLine("\t" + item2.name);
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	public void UnlockAllRewards()
	{
		GameSettings.Instance.CompletedTasks.AddRange(GameData.Tasks.Select((RewardTask x) => x.Name));
		GameSettings.Instance.ClaimedRewards.AddRange(GameData.Tasks.Select((RewardTask x) => x.Name));
		HUD.Instance.RefreshBuildButtons();
		HUD.Instance.UpdateFurnitureButtons();
	}

	public static void CheckWordLength(string l)
	{
		Localization.Translation language = Localization.GetLanguage(l);
		if (language == null)
		{
			global::DevConsole.Console.LogError(l + " does not exist");
			return;
		}
		Dictionary<string, string[]> allValues = language.GetAllValues();
		StringBuilder stringBuilder = new StringBuilder();
		foreach (KeyValuePair<string, string[]> allValue in Localization.GetLanguage("English").GetAllValues())
		{
			string[] value;
			if (!allValues.TryGetValue(allValue.Key, out value))
			{
				continue;
			}
			int num = Mathf.Min(allValue.Value.Length, value.Length);
			for (int i = 0; i < num; i++)
			{
				int num2 = CountLetters(allValue.Value[i]);
				if (num2 < 40 && CountLetters(value[i]) > num2 + 6)
				{
					stringBuilder.AppendLine(allValue.Key + "\t" + NoNewLines(allValue.Value[i]) + "\t" + NoNewLines(value[i]));
				}
			}
		}
		GUIUtility.systemCopyBuffer = stringBuilder.ToString().TrimEnd();
		global::DevConsole.Console.Log("Copied to clipboard");
	}

	private static string NoNewLines(string i)
	{
		return i.Replace('\r', ' ').Replace('\n', ' ');
	}

	private static int CountLetters(string tr)
	{
		bool flag = false;
		int num = 0;
		for (int i = 0; i < tr.Length; i++)
		{
			if (flag)
			{
				if (tr[i] == '}')
				{
					flag = false;
				}
			}
			else if (tr[i] == '{')
			{
				flag = true;
			}
			else
			{
				num++;
			}
		}
		return num;
	}
}
