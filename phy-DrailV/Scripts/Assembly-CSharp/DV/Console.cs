using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AwesomeTechnologies.VegetationSystem;
using CommandTerminal;
using DV.Audio;
using DV.CabControls;
using DV.Common;
using DV.Damage;
using DV.InventorySystem;
using DV.JObjectExtstensions;
using DV.Localization;
using DV.Logic.Job;
using DV.OriginShift;
using DV.PointSet;
using DV.ServicePenalty;
using DV.ServicePenalty.UI;
using DV.Simulation.Brake;
using DV.Simulation.Cars;
using DV.Simulation.Controllers;
using DV.Telemetry;
using DV.Teleporters;
using DV.TerrainSystem;
using DV.ThingTypes;
using DV.Tutorial;
using DV.Tutorial.QT;
using DV.Utils;
using DV.VFX;
using DV.WeatherSystem;
using I2.Loc;
using LocoSim.Implementations;
using LocoSim.Resources;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Scripting;
using VRTK;

namespace DV
{
	public class Console
	{
		private enum FieldType
		{
			Bool = 0,
			Float = 1,
			Int = 2,
			Vector3 = 3
		}

		private static string CONSOLE_PREFAB_NAME = "[console]";

		private static DevGUI devGUI;

		private static float backupShadowDistance = 1200f;

		private static int backupCascades = 4;

		private static float backupCascades2 = 0.084f;

		private static Vector3 backupCascades4 = new Vector3(0.028f, 0.092f, 0.347f);

		private const string TAA_PARAM_JITTER_SPREAD = "jitterSpread";

		private const string TAA_PARAM_STATIONARY_BLENDING = "stationaryBlending";

		private const string TAA_PARAM_MOTION_BLENDING = "motionBlending";

		private const string TAA_PARAM_SHARPNESS = "sharpness";

		private static readonly string[] TAA_AvailableParams = new string[4] { "jitterSpread", "stationaryBlending", "motionBlending", "sharpness" };

		private static List<GameObject> killedVolumetrics = new List<GameObject>();

		private static CouplingHoseDebugGUI hosesGUI;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void Init()
		{
			Debug.Log("Initializing console");
			GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load(CONSOLE_PREFAB_NAME) as GameObject);
			gameObject.name = CONSOLE_PREFAB_NAME;
			gameObject.transform.SetSiblingIndex(0);
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void RegisterDevCommandsOnStart()
		{
			if (Application.isPlaying && DevUtil.IsDevMachine())
			{
				UnityEngine.Object.FindObjectOfType<Terminal>().StartCoroutine(RegisterDevCommandsDelayed());
			}
		}

		private static IEnumerator RegisterDevCommandsDelayed()
		{
			yield return WaitFor.EndOfFrame;
			if (Terminal.Shell == null)
			{
				Debug.LogError("Enabling dev commands failed, Terminal.Shell is null");
			}
			else if (DevUtil.IsDevMachine())
			{
				Debug.Log("Enabling dev commands");
				RegisterDevCommands();
			}
		}

		private static void RegisterDevCommands()
		{
			Register("Dev.Timescale", Dev_Timescale, 0, 1);
			Register("Dev.LocoSimulationTimeMultiplier", Dev_LocoSimulationTimeMultiplier, 1, 1);
			Register("Dev.ToggleDevGUI", Dev_ToggleDevGUI, 0, 0);
			Register("Dev.PlayerSpeed", Dev_PlayerSpeed, 2, 2);
			Register("Dev.EnableCommsRadioCheatMode", Dev_EnableCommsRadioCheatMode, 0, 1);
			Register("Dev.SpawnMoney", Dev_SpawnMoney, 1, 1);
			Register("Dev.GiveMoney", Dev_GiveMoney, 1, 1);
			Register("Dev.SetMoney", Dev_SetMoney, 1, 1);
			Register("Dev.SpawnItem", Dev_SpawnItem, 0, 2, "Spawn an item given a prefab name. Args: [prefab name] [count]");
			Register("Dev.ClearDebts", Dev_ClearDebts, 0, 0);
			Register("Dev.CabLightToggle", Dev_CabLightToggle, 0, 0);
			Register("Dev.CabLightIntensity", Dev_CabLightIntensity, 1, 1);
			Register("Dev.PrintDebtsActivationTime", Dev_PrintDebtsActivationTime, 0, 0);
			Register("Dev.LocoClampResource", Dev_LocoClampResource, 2, 2, "Clamp single resource to specified upper limit");
			Register("Dev.LocoDepleteResources", Dev_LocoDepleteResources, 0, 1, "Calling without args depletes all resources, otherwise write resource you wish to deplete (FUEL, OIL, SAND ...)");
			Register("Dev.LocoRefillResources", Dev_LocoRefillResources, 0, 1, "Calling without args refills all resources, otherwise write resource you wish to refill (FUEL, OIL, SAND ...)");
			Register("Dev.LocoDamageParts", Dev_LocoDamageParts, 0, 1, "Calling without args damages all parts, otherwise write part you wish to damage (body, wheels, electrical, mechanical)");
			Register("Dev.LocoRepairParts", Dev_LocoRepairParts, 0, 1, "Calling without args repairs all parts, otherwise write part you wish to repair (body, wheels, electrical, mechanical)");
			Register("Dev.LocoStartEngine", Dev_LocoStartEngine, 0, 0, "Sets your engine into ready to drive state");
			Register("Dev.MarkPlayer", Dev_MarkPlayer, 0, 1, "Remembers player's position and orientation in a 0-9 slot. Default is 0.");
			Register("Dev.RecallPlayer", Dev_RecallPlayer, 0, 1, "Loads a previously stored mark (position and orientation of the player) from a 0-9 slot. Changes in-game time and weather, might mess things up with that. Default is 0.");
			Register("Dev.JobCompleteNextTask", Dev_JobCompleteNextTask, 0, 1, "Completes next task of a job. Args: jobId, format example SM-SL-90");
			Register("Dev.RefreshJobsAtTheStation", Dev_RefreshJobsAtTheStation, 0, 0, "Use only when in the station to refresh existing jobs");
			Register("Dev.TeleportTrainToTrack", Dev_TeleportTrainToTrack, 1, 1, "Teleports a train to desired station track. Args: trackId, format example SM-A1S");
			Register("Dev.ListCarsInfo", Dev_ListCarsInfo, 0, 1, "Lists car info (Legend: U unique, D derailed, J job, C cargo, P position). Args(optional):  L - locos only, C - regular cars only, U - unique only, carId (L-001), default ALL");
			Register("Dev.CarDamageAndResourcesInfo", Dev_CarDamageAndResourcesInfo, 0, 1, "Shows damage and resources info of a car. Args(optional): carId, format example L-001, default PlayerCar");
			Register("Dev.TeleportToCar", Dev_TeleportToCar, 1, 1, "Teleports player to the car with provided ID. Args: carID, format example L-001");
			Register("Dev.TeleportToStation", Dev_TeleportToStation, 1, 1, "Teleports player to station with provided ID Args: stationID, format example SM");
			Register("Dev.SetFarLoaderRange", Dev_SetFarLoaderRange, 2, 2, "Set far streamer loading area. Args: [loading size] [unloading size]");
			Register("Dev.SetNearLoaderRange", Dev_SetNearLoaderRange, 2, 2, "Set near streamer loading area. Args:  [loading size] [unloading size]");
			Register("Dev.ForwardRenderingToggle", Dev_ForwardRenderingToggle, 0, 1, "Toggle forward rendering on/off. Args: [none] - logs current forward rendering state; [on] - 0 is off and 1 is on");
			Register("Dev.AdvanceTime", Dev_AdvanceTime, 1, 1, "Advance time by number of seconds");
			Register("Dev.SpawnBed", Dev_SpawnBed, 0, 0, "Spawn a bed, for testing of sleeping time advance mechanic");
			Register("Dev.OffsetLastWakeTime", Dev_OffsetLastWakeTime, 1, 1, "Shift the last bed wake time by number of hours");
			Register("Dev.QT.StartLoco", Dev_StartLocoQT, 0, 0);
			Register("Dev.QT.StartCoupling", Dev_StartCouplingQT, 0, 0);
			Register("Dev.QT.StartRerailing", Dev_StartRerailingQT, 0, 0);
			Register("Dev.QT.StartDebt", Dev_StartDebtPayingQT, 0, 1);
			Register("Dev.QT.StartManual", Dev_StartManualQT, 0, 1);
			Register("Dev.QT.StartQT", Dev_StartQTQT, 0, 1);
			Register("Dev.QT.StartHandcar", Dev_StartHandcarQT, 0, 1);
			Register("Dev.QT.StartClear", Dev_StartClearQT, 0, 1);
			Register("Dev.QT.Abort", Dev_AbortQT, 0, 0);
			Register("Dev.InputSemantic", Dev_InputSemantic, 0, 1, "Display a list of available semantics with no args, or resolves a given semantic using currently active input configuration.");
			Register("Dev.FeatureFlags", Dev_CheckFeatureFlags, 0, 0, "List all of game feature flags and their state");
			Register("Dev.Allow", Dev_FeatureFlagAllow, 1, 1, "Allow a feature flag. Args: [feature flag name]");
			Register("Dev.Deny", Dev_FeatureFlagDeny, 1, 1, "Deny a feature flag. Args: [feature flag name]");
			Register("Dev.ShadowTrace", Dev_ShadowTrace, 0, 1);
			Register("Dev.WorldAO", Dev_WorldAO, 0, 1);
			Register("Dev.TerrainGridShadows", Dev_TerrainGridShadows, 1, 1);
			Register("Dev.OriginShiftRange", Dev_OriginShiftRange, 0, 1, "Gets or sets the distance from origin after which an origin shift will occur.");
			Register("Dev.OriginShiftNow", Dev_OriginShiftNow, 0, 0, "Temporarily shortens the world shifting range so it would occur immediately, then restores it.");
			Register("Dev.ModifyLicenses", Dev_ModifyLicenses, 0, 2, "Modifies your licenses. Args: [license name ('all' for all licenses, 'list' to list all licenses)] [grant/revoke (true/false)]");
			Register("Dev.Explode", Dev_ExplodeTrain, 0, 1, "Explodes the train you're standing on, or the one with the given ID.");
			Register("Dev.EnvSoundStats", Dev_EnvSoundStats, 0, 1, "Toggles statistics about environment sounds.");
			Register("Dev.RebuildLightData", Dev_RebuildLightData, 0, 0, "Rebuilds and reuploads all GPU light glow/flare data.");
			Register("Dev.UnlockGarage", UnlockGarage, 0, 1, "Unlock one or all garages. Run with no args to list all garages. Provide a garage ID to unlock it specifically.");
		}

		private static void Register(string name, Action<CommandArg[]> proc, int minArgs = 0, int maxArgs = -1, string help = "", string hint = null)
		{
			CommandInfo command = Terminal.Shell.AddCommand(name, proc, minArgs, maxArgs, help, hint);
			Terminal.Autocomplete.Register(command);
		}

		private static void Dev_Timescale(CommandArg[] args)
		{
			if (args.Length == 0)
			{
				Terminal.Log("Current value: " + Time.timeScale);
			}
			else if (!Terminal.IssuedError)
			{
				Time.timeScale = args[0].Float;
			}
		}

		private static void Dev_EnableCommsRadioCheatMode(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				bool flag = args.Length == 0 || args[0].Int > 0;
				Globals.G.GameParams.CommsRadioCheatMode = flag;
				Terminal.Log("Comms radio cheat mode " + (flag ? "enabled" : "disabled"));
			}
		}

		private static void Dev_LocoSimulationTimeMultiplier(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				float simTimeMultiplier = args[0].Float;
				SimController[] array = UnityEngine.Object.FindObjectsOfType<SimController>();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].simTimeMultiplier = simTimeMultiplier;
				}
			}
		}

		private static void Dev_ToggleDevGUI(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				if (devGUI == null)
				{
					devGUI = SingletonBehaviour<DevGUI>.Instance;
				}
				else
				{
					devGUI.gameObject.SetActive(!devGUI.gameObject.activeSelf);
				}
			}
		}

		private static void Dev_PlayerSpeed(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			CustomFirstPersonController customFirstPersonController = UnityEngine.Object.FindObjectOfType<CustomFirstPersonController>();
			if (!customFirstPersonController)
			{
				Terminal.Log("CustomFirstPersonController not found in scene, doing nothing");
				return;
			}
			float baseWalkSpeed = args[0].Float;
			float baseRunSpeed = args[1].Float;
			if (!Terminal.IssuedError)
			{
				customFirstPersonController.baseWalkSpeed = baseWalkSpeed;
				customFirstPersonController.baseRunSpeed = baseRunSpeed;
			}
		}

		private static void Dev_SpawnMoney(CommandArg[] args)
		{
			if (!Terminal.IssuedError && !(PlayerManager.PlayerTransform == null))
			{
				int num = args[0].Int;
				if (num < 0)
				{
					num = 100;
				}
				Transform playerTransform = PlayerManager.PlayerTransform;
				((GameObject)UnityEngine.Object.Instantiate(Resources.Load("Banknotes", typeof(GameObject)), playerTransform.position + playerTransform.forward * 1f, playerTransform.rotation, WorldMover.OriginShiftParent)).GetComponent<Banknotes>().Amount = num;
			}
		}

		private static void Dev_GiveMoney(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				double playerMoney = SingletonBehaviour<Inventory>.Instance.PlayerMoney;
				SingletonBehaviour<Inventory>.Instance.AddMoney(args[0].Int);
				Terminal.Log($"You now have {SingletonBehaviour<Inventory>.Instance.PlayerMoney} (previous value was {playerMoney})");
			}
		}

		private static void Dev_SetMoney(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				double playerMoney = SingletonBehaviour<Inventory>.Instance.PlayerMoney;
				SingletonBehaviour<Inventory>.Instance.SetMoney(args[0].Int);
				Terminal.Log($"You now have {SingletonBehaviour<Inventory>.Instance.PlayerMoney} (previous value was {playerMoney})");
			}
		}

		private static void Dev_SpawnItem(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			if (args.Length == 0)
			{
				List<InventoryItemSpec> items = Globals.G.Items.items;
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("\nItem Prefabs:");
				foreach (InventoryItemSpec item in items)
				{
					stringBuilder.AppendLine("- " + item.ItemPrefabName);
				}
				Debug.Log(stringBuilder);
				return;
			}
			string requested = args[0].String.ToLower();
			List<InventoryItemSpec> specs = Globals.G.Items.items.Where((InventoryItemSpec s) => s.ItemPrefabName.ToLower().Contains(requested)).ToList();
			if (specs.Count == 0)
			{
				Terminal.Log("No items not found! Run without args to list all available items.");
				return;
			}
			if (specs.Count > 1)
			{
				Terminal.Log($"Found {specs.Count} items, run again with more specific string.");
				{
					foreach (InventoryItemSpec item2 in specs)
					{
						Terminal.Log("- " + item2.ItemPrefabName);
					}
					return;
				}
			}
			SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(SpawnItems());
			IEnumerator SpawnItems()
			{
				int count = ((args.Length <= 1) ? 1 : args[1].Int);
				InventoryItemSpec spec = specs[0];
				Terminal.Log($"Spawning {count}x {spec.LocalizedName}");
				Transform t = PlayerManager.ActiveCamera.transform;
				for (int i = 0; i < count; i++)
				{
					InventoryItemSpec inventoryItemSpec = UnityEngine.Object.Instantiate(spec, t.position + t.forward * 0.5f, t.rotation);
					inventoryItemSpec.BelongsToPlayer = true;
					ItemBase component = inventoryItemSpec.GetComponent<ItemBase>();
					SingletonBehaviour<StorageController>.Instance.AddItemToWorldStorage(component);
					yield return WaitFor.Seconds(0.1f);
				}
			}
		}

		private static void Dev_ClearDebts(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				SingletonBehaviour<CareerManagerDebtController>.Instance.ClearRestOfThePayableDebts();
			}
		}

		private static void Dev_CabLightToggle(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				Transform transform = (PlayerManager.Car ? PlayerManager.Car.transform.Find("[cab light]") : null);
				if ((bool)transform)
				{
					transform.gameObject.SetActive(!transform.gameObject.activeSelf);
				}
				else
				{
					Terminal.Log("No '[cab light]' found");
				}
			}
		}

		private static void Dev_CabLightIntensity(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				Transform transform = (PlayerManager.Car ? PlayerManager.Car.transform.Find("[cab light]") : null);
				if ((bool)transform)
				{
					transform.GetComponent<Light>().intensity = args[0].Float;
				}
				else
				{
					Terminal.Log("No '[cab light]' found");
				}
			}
		}

		private static void Dev_PrintDebtsActivationTime(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				SingletonBehaviour<CareerManagerDebtController>.Instance.PrintDebtsActivationTime();
			}
		}

		private static void Dev_LocoClampResource(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			if (PlayerManager.Car == null)
			{
				Terminal.Log("Not in a loco, can't clamp");
				return;
			}
			ResourceContainerController resourceContainerController = PlayerManager.Car.SimController?.resourceContainerController;
			if (resourceContainerController == null)
			{
				Terminal.Log("Can't access resourcesController, can't clamp");
				return;
			}
			if (args.Length < 2)
			{
				Terminal.Log("Usage: Dev.LocoClampResource <resourceContainerName> <maxFactor>");
				return;
			}
			string value = args[0].String;
			float maxFactor = args[1].Float;
			if (Enum.TryParse<ResourceContainerType>(value, ignoreCase: true, out var result))
			{
				resourceContainerController.ClampResourceContainer(result, maxFactor);
				return;
			}
			string[] names = Enum.GetNames(typeof(ResourceContainerType));
			string text = "Invalid resource container name, valid names are:\n";
			string[] array = names;
			foreach (string text2 in array)
			{
				text = text + text2 + "\n";
			}
			Terminal.Log(text);
		}

		private static void Dev_LocoDepleteResources(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				LocoDepleteRefillResources(args, deplete: true);
			}
		}

		private static void Dev_LocoRefillResources(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				LocoDepleteRefillResources(args, deplete: false);
			}
		}

		private static void LocoDepleteRefillResources(CommandArg[] args, bool deplete)
		{
			if (PlayerManager.Car == null)
			{
				Terminal.Log("Not in a loco, can't " + (deplete ? "deplete" : "refill"));
				return;
			}
			ResourceContainerController resourceContainerController = PlayerManager.Car.SimController?.resourceContainerController;
			if (resourceContainerController == null)
			{
				Terminal.Log("Can't access resourcesController, can't" + (deplete ? "deplete" : "refill"));
				return;
			}
			if (args.Length == 0)
			{
				if (deplete)
				{
					resourceContainerController.DepleteAllResourceContainers();
				}
				else
				{
					resourceContainerController.RefillAllResourceContainers();
				}
				return;
			}
			if (Enum.TryParse<ResourceContainerType>(args[0].String, ignoreCase: true, out var result))
			{
				if (deplete)
				{
					resourceContainerController.DepleteResourceContainer(result);
				}
				else
				{
					resourceContainerController.RefillResourceContainer(result);
				}
				return;
			}
			string[] names = Enum.GetNames(typeof(ResourceContainerType));
			string text = "Invalid resource container name, valid names are:\n";
			string[] array = names;
			foreach (string text2 in array)
			{
				text = text + text2 + "\n";
			}
			Terminal.Log(text);
		}

		private static void Dev_LocoDamageParts(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				LocoDamageRepairParts(args, damage: true);
			}
		}

		private static void Dev_LocoRepairParts(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				LocoDamageRepairParts(args, damage: false);
			}
		}

		private static void LocoDamageRepairParts(CommandArg[] args, bool damage)
		{
			if (PlayerManager.Car == null)
			{
				Terminal.Log("Not in a loco, can't " + (damage ? "damage" : "repair"));
				return;
			}
			DamageController component = PlayerManager.Car.GetComponent<DamageController>();
			if (component == null)
			{
				Terminal.Log("Can't access dmgCtrl, can't" + (damage ? "damage" : "repair"));
				return;
			}
			if (args.Length == 0)
			{
				if (damage)
				{
					component.DamageFullyAll();
				}
				else
				{
					component.RepairAll();
				}
				return;
			}
			switch (args[0].String.ToLower())
			{
			case "body":
				if (damage)
				{
					component.bodyDamage.DamageCar(component.bodyDamage.currentHealth, useSensitivityModifier: false);
				}
				else
				{
					component.bodyDamage.RepairCar(component.bodyDamage.maxHealth - component.bodyDamage.currentHealth);
				}
				break;
			case "wheels":
				if (component.wheels != null)
				{
					if (damage)
					{
						component.wheels.ApplyDamage(component.wheels.CurrentHitPoints);
					}
					else
					{
						component.wheels.RepairDamage(component.wheels.fullHitPoints - component.wheels.CurrentHitPoints);
					}
				}
				break;
			case "electrical":
				if (component.electricalPT != null)
				{
					if (damage)
					{
						component.electricalPT.ApplyDamage(component.electricalPT.CurrentHitPoints);
					}
					else
					{
						component.electricalPT.RepairDamage(component.electricalPT.fullHitPoints - component.electricalPT.CurrentHitPoints);
					}
				}
				break;
			case "mechanical":
				if (component.mechanicalPT != null)
				{
					if (damage)
					{
						component.mechanicalPT.ApplyDamage(component.mechanicalPT.CurrentHitPoints);
					}
					else
					{
						component.mechanicalPT.RepairDamage(component.mechanicalPT.fullHitPoints - component.mechanicalPT.CurrentHitPoints);
					}
				}
				break;
			default:
				Terminal.Log("Invalid damage part, valid parts are: body, wheels, electrical, mechanical");
				break;
			}
		}

		private static void Dev_LocoStartEngine(CommandArg[] args)
		{
			TrainCar car = PlayerManager.Car;
			if (!(car == null))
			{
				StartupHelper.Startup(car);
			}
		}

		private static void Dev_MarkPlayer(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			int num = 0;
			if (args.Length != 0)
			{
				num = args[0].Int;
				if (num < 0 || num > 9)
				{
					Terminal.Log("Invalid mark/recall slot");
					return;
				}
			}
			JObject jObject = new JObject();
			Vector3 value = PlayerManager.PlayerTransform.AbsolutePosition();
			jObject.SetVector3("Player_position", value);
			jObject.SetVector3("Player_rotation", PlayerManager.PlayerTransform.rotation.eulerAngles);
			jObject.SetJObject("Time_and_date", SingletonBehaviour<WeatherDriver>.Instance.GetSaveData(packOverrides: true));
			File.WriteAllText(Path.Combine(Application.persistentDataPath, "DBG_Mark_" + num + ".json"), jObject.ToString());
			Terminal.Log($"Mark #{num} saved.");
		}

		private static void Dev_RecallPlayer(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			int num = 0;
			if (args.Length != 0)
			{
				num = args[0].Int;
				if (num < 0 || num > 9)
				{
					Terminal.Log("Invalid mark/recall slot");
					return;
				}
			}
			string path = Path.Combine(Application.persistentDataPath, "DBG_Mark_" + num + ".json");
			if (!File.Exists(path))
			{
				Terminal.Log($"Slot {num} wasn't found. Did you save anything in it?");
				return;
			}
			try
			{
				JObject jObject = JObject.Parse(File.ReadAllText(path));
				Vector3 position = jObject.GetVector3("Player_position").Value + WorldMover.currentMove;
				Vector3 value = jObject.GetVector3("Player_rotation").Value;
				JObject data = jObject["Time_and_date"] as JObject;
				PlayerManager.TeleportPlayer(position, Quaternion.Euler(value), null, useRotation: true);
				SingletonBehaviour<WeatherDriver>.Instance.LoadSaveData(data, useOverrides: true);
				Terminal.Log($"Mark #{num} recalled.");
			}
			catch (Exception ex)
			{
				Terminal.Log($"Couldn't load from slot {num} because: {ex.Message}");
				Debug.LogException(ex);
			}
		}

		private static void Dev_TeleportTrainToTrack(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			string trackId = args[0].String.ToLower();
			RailTrack railTrack = StationController.allStations.SelectMany((StationController s) => s.AllStationTracks).FirstOrDefault((RailTrack t) => t.LogicTrack().ID.FullDisplayID.ToLower() == trackId);
			if (railTrack == null)
			{
				Debug.LogError("Couldn't find railtrack with id " + trackId);
				return;
			}
			List<TrainCar> list = ((PlayerManager.Car != null) ? new List<TrainCar>(PlayerManager.Car.trainset.cars) : null);
			if (list == null)
			{
				Debug.LogError("Player is currently not on any train");
			}
			else
			{
				SingletonBehaviour<CoroutineManager>.Instance.Run(MoveCarsCoro(list, railTrack));
			}
		}

		private static void Dev_TeleportToStation(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			string text = args[0].String.ToUpper();
			StationController stationByYardID = StationController.GetStationByYardID(text);
			if (stationByYardID == null)
			{
				string[] value = StationController.allStations.Select((StationController s) => s.stationInfo.YardID).ToArray();
				Debug.LogError("Station with id " + text + " doesn't exist. Available stations: " + string.Join(",", value));
				return;
			}
			StationFastTravelDestination componentInChildren = stationByYardID.GetComponentInChildren<StationFastTravelDestination>(includeInactive: true);
			if (componentInChildren == null)
			{
				Debug.LogError("Station with id " + text + " doesn't have teleporter");
			}
			else
			{
				componentInChildren.TeleportPlayer();
			}
		}

		private static void Dev_TeleportToCar(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				string carId = args[0].String.ToUpper();
				TrainCar trainCar = SingletonBehaviour<CarSpawner>.Instance.AllCars.FirstOrDefault((TrainCar c) => c.ID == carId);
				if (trainCar == null)
				{
					Debug.LogError("Car with id " + carId + " doesn't exist");
				}
				else
				{
					PlayerManager.TeleportPlayerToCar(trainCar);
				}
			}
		}

		private static void Dev_ListCarsInfo(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			TrainCar[] array;
			if (args.Length != 0)
			{
				string carId = args[0].String.ToUpper();
				TrainCar trainCar = SingletonBehaviour<CarSpawner>.Instance.AllCars.FirstOrDefault((TrainCar c) => c.ID == carId);
				if (trainCar != null)
				{
					array = new TrainCar[1] { trainCar };
				}
				else
				{
					switch (args[0].String.ToUpper())
					{
					case "L":
						array = SingletonBehaviour<CarSpawner>.Instance.AllLocos.ToArray();
						break;
					case "C":
						array = SingletonBehaviour<CarSpawner>.Instance.AllCars.Except(SingletonBehaviour<CarSpawner>.Instance.AllLocos).ToArray();
						break;
					case "U":
						array = SingletonBehaviour<CarSpawner>.Instance.AllCars.Where((TrainCar c) => c.uniqueCar).ToArray();
						break;
					default:
						Debug.LogError("Bad argument, use L - locos only, C - regular cars only, U - unique only, carId or no args - all. Defaulting to all");
						array = SingletonBehaviour<CarSpawner>.Instance.AllCars.ToArray();
						break;
					}
				}
			}
			else
			{
				array = SingletonBehaviour<CarSpawner>.Instance.AllCars.ToArray();
			}
			LevelInfo levelInfo = SingletonBehaviour<LevelInfo>.Instance;
			Array.Sort(array, delegate(TrainCar car1, TrainCar car2)
			{
				if (levelInfo != null)
				{
					int num2 = string.Compare(levelInfo.Get8x8PositionCoords(car1.transform.AbsolutePosition()), levelInfo.Get8x8PositionCoords(car2.transform.AbsolutePosition()), StringComparison.Ordinal);
					if (num2 != 0)
					{
						return num2;
					}
				}
				int num3 = CarTypes.IsAnyLocoSlugTender(car2.carLivery).CompareTo(CarTypes.IsAnyLocoSlugTender(car1.carLivery));
				return (num3 != 0) ? num3 : string.Compare(car1.carLivery.id, car2.carLivery.id, StringComparison.Ordinal);
			});
			StringBuilder stringBuilder = new StringBuilder();
			TrainCar[] array2 = array;
			foreach (TrainCar trainCar2 in array2)
			{
				stringBuilder.Append("[" + ((levelInfo != null) ? levelInfo.Get8x8PositionCoords(trainCar2.transform.AbsolutePosition()) : trainCar2.transform.AbsolutePosition().ToString()) + "] ");
				stringBuilder.Append(trainCar2.carLivery.id.PadRight(20) + " | " + (trainCar2.uniqueCar ? "U" : " ") + " " + (trainCar2.derailed ? "D" : " ") + " " + trainCar2.ID.PadRight(6) + " ");
				stringBuilder.Append("| STATIONARY: " + (trainCar2.isStationary ? "Y" : "N") + " ");
				stringBuilder.Append("| SLEEP ALLOWED: " + (trainCar2.isEligibleForSleep ? "Y" : "N") + " ");
				stringBuilder.Append("| RB ASLEEP: " + (trainCar2.rb.IsSleeping() ? "Y" : "N") + " ");
				stringBuilder.Append("| KINEMATIC: " + (trainCar2.rb.isKinematic ? "Y" : "N") + " ");
				Job jobOfCar = SingletonBehaviour<JobsManager>.Instance.GetJobOfCar(trainCar2.logicCar);
				string text = ((jobOfCar != null) ? jobOfCar.ID : "");
				stringBuilder.Append("| J: " + text.PadRight(9) + " ");
				stringBuilder.Append("| C: " + trainCar2.LoadedCargo.ToString().PadRight(20) + " ");
				stringBuilder.Append("| GUID: " + trainCar2.CarGUID + " ");
				stringBuilder.Append($"| P{trainCar2.transform.AbsolutePosition()} ");
				stringBuilder.AppendLine();
			}
			Debug.Log(stringBuilder.ToString());
		}

		private static void Dev_CarDamageAndResourcesInfo(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			TrainCar trainCar;
			if (args.Length != 0)
			{
				string carId = args[0].String.ToUpper();
				trainCar = SingletonBehaviour<CarSpawner>.Instance.AllCars.FirstOrDefault((TrainCar c) => c.ID == carId);
				if (trainCar == null)
				{
					Debug.LogError("Car with id " + carId + " doesn't exist");
					return;
				}
			}
			else
			{
				trainCar = PlayerManager.Car;
				if (trainCar == null)
				{
					Debug.LogError("Player not in any car");
					return;
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			DamageController component = trainCar.GetComponent<DamageController>();
			stringBuilder.AppendLine(trainCar.carLivery.id + " [" + trainCar.ID + "]");
			stringBuilder.AppendLine($"Body: {trainCar.CarDamage.EffectiveHealthPercentage * 100f}% ");
			if (trainCar.LoadedCargo != CargoType.None)
			{
				stringBuilder.AppendLine($"Cargo: {trainCar.CargoDamage.EffectiveHealthPercentage100Notation}%");
			}
			if (component != null)
			{
				if (component.wheels != null)
				{
					stringBuilder.AppendLine($"Wheels: {component.wheels.HealthPercentage100Notation}%");
				}
				if (component.mechanicalPT != null)
				{
					stringBuilder.AppendLine($"MechanicalPT: {component.mechanicalPT.HealthPercentage100Notation}%");
				}
				if (component.electricalPT != null)
				{
					stringBuilder.AppendLine($"ElectricalPT: {component.electricalPT.HealthPercentage100Notation}%");
				}
			}
			stringBuilder.AppendLine();
			ResourceContainerController resourceContainerController = trainCar.SimController?.resourceContainerController;
			if (resourceContainerController != null)
			{
				foreach (ResourceContainer resourceContainer in resourceContainerController.resourceContainers)
				{
					stringBuilder.AppendLine($"{resourceContainer.resourceType.ToString()}: {resourceContainer.normalizedReadOutPort.Value * 100f}% ");
				}
			}
			Debug.Log(stringBuilder.ToString());
		}

		private static void Dev_JobCompleteNextTask(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			string jobId;
			if (args.Length != 0)
			{
				jobId = args[0].String.ToLowerInvariant();
			}
			else
			{
				GameObject equippedItemAtSlot = SingletonBehaviour<Inventory>.Instance.GetEquippedItemAtSlot(0);
				if (!equippedItemAtSlot || !equippedItemAtSlot.TryGetComponent<JobBooklet>(out var component))
				{
					Debug.LogError("You must be holding a job booklet if you don't provide a jobId as an argument");
					return;
				}
				jobId = component.job.ID.ToLowerInvariant();
			}
			Job job = SingletonBehaviour<JobsManager>.Instance.currentJobs.FirstOrDefault((Job j) => j.ID.ToLowerInvariant() == jobId);
			if (job != null)
			{
				CompleteNextJobTask(job);
			}
			else
			{
				Debug.LogError("Couldn't find job with id " + jobId);
			}
		}

		private static void CompleteNextJobTask(Job job)
		{
			if (job.State != JobState.InProgress)
			{
				Debug.LogError("Job " + job.ID + " is not in progress!");
				return;
			}
			List<Task> tasks = job.tasks;
			if (tasks.All((Task t) => t.state == TaskState.Done))
			{
				Debug.Log("Tasks for job " + job.ID + " are completed, go validate the job");
			}
			else
			{
				CompleteNextTask(tasks);
			}
			void CompleteNextTask(List<Task> list)
			{
				for (int i = 0; i < list.Count; i++)
				{
					Task task = list[i];
					if (task.state != TaskState.Done)
					{
						switch (task.InstanceTaskType)
						{
						case TaskType.Transport:
							SingletonBehaviour<CoroutineManager>.Instance.Run(TransportTaskCoro(task));
							return;
						case TaskType.Warehouse:
							SingletonBehaviour<CoroutineManager>.Instance.Run(WarehouseTaskCoro(task));
							return;
						case TaskType.Sequential:
						case TaskType.Parallel:
							CompleteNextTask(task.GetTaskData().nestedTasks);
							return;
						}
					}
				}
			}
		}

		private static void Dev_RefreshJobsAtTheStation(CommandArg[] obj)
		{
			Transform playerTransform = PlayerManager.PlayerTransform;
			if (!(playerTransform != null))
			{
				return;
			}
			List<StationController> allStations = StationController.allStations;
			if (allStations.Count == 0)
			{
				return;
			}
			StationController stationController = allStations[0];
			float num = (playerTransform.transform.position - stationController.transform.position).sqrMagnitude;
			for (int i = 1; i < allStations.Count; i++)
			{
				StationController stationController2 = allStations[i];
				float sqrMagnitude = (playerTransform.transform.position - stationController2.transform.position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					stationController = stationController2;
				}
			}
			stationController.RegenerateJobs();
		}

		private static IEnumerator WarehouseTaskCoro(Task task)
		{
			TaskData taskData = task.GetTaskData();
			WarehouseMachineController warehouseCtrl = WarehouseMachineController.allControllers.FirstOrDefault((WarehouseMachineController wmc) => wmc.warehouseMachine.WarehouseTrack == taskData.destinationTrack && taskData.cargoTypePerCar.All((CargoType c) => wmc.warehouseMachine.IsCargoSupported(c)));
			if (warehouseCtrl == null)
			{
				Debug.LogError($"Couldn't find warehouse machine on track {taskData.destinationTrack.ID}, that supports required cargo");
				yield break;
			}
			warehouseCtrl.ActivateExternally();
			while (warehouseCtrl.LoadOrUnloadOngoing)
			{
				yield return null;
			}
			Debug.Log((task.state == TaskState.Done) ? ("Task " + taskData.type.ToString() + " is completed!") : ("Task " + taskData.type.ToString() + " wasn't completed!"));
		}

		private static IEnumerator TransportTaskCoro(Task task)
		{
			TaskData taskData = task.GetTaskData();
			List<TrainCar> taskTrainCars = taskData.cars.Select((Car car) => SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar[car]).ToList();
			RailTrack destinationRailTrack = taskData.destinationTrack.RailTrack();
			yield return SingletonBehaviour<CoroutineManager>.Instance.Run(MoveCarsCoro(taskTrainCars, destinationRailTrack));
			TrainCar trainCar = taskTrainCars[0];
			if (task.IsLastTask && !trainCar.brakeSystem.brakeset.anyHandbrakeApplied)
			{
				trainCar.brakeSystem.SetHandbrakePosition(1f);
			}
			yield return WaitFor.Seconds(2f);
			Debug.Log((task.state == TaskState.Done) ? ("Task " + taskData.type.ToString() + " is completed!") : ("Task " + taskData.type.ToString() + " wasn't completed!"));
		}

		private static IEnumerator MoveCarsCoro(List<TrainCar> trainCarsToMove, RailTrack destinationRailTrack)
		{
			List<TrainCar> carsAlreadyOnTrack = (from car in destinationRailTrack.LogicTrack().GetCarsFullyOnTrack()
				select SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar[car]).ToList();
			EquiPointSet.Point[] points = destinationRailTrack.GetKinkedPointSet().points;
			if (carsAlreadyOnTrack.Count > 0)
			{
				Vector3 startPoint = (Vector3)points[1].position + WorldMover.currentMove;
				yield return SingletonBehaviour<CoroutineManager>.Instance.Run(TrainCarTeleporter.TeleportTrainset(carsAlreadyOnTrack, startPoint));
				if (carsAlreadyOnTrack.Any((TrainCar c) => c.Bogies.Any((Bogie b) => b.track != destinationRailTrack)))
				{
					yield return SingletonBehaviour<CoroutineManager>.Instance.Run(TrainCarTeleporter.TeleportTrainset(carsAlreadyOnTrack, startPoint));
					if (carsAlreadyOnTrack.Any((TrainCar c) => c.Bogies.Any((Bogie b) => b.track != destinationRailTrack)))
					{
						Debug.LogError($"Couldn't shift cars from destination railtrack {destinationRailTrack.LogicTrack().ID}");
					}
				}
			}
			Vector3 target = (Vector3)points[points.Length / 2].position + WorldMover.currentMove;
			yield return SingletonBehaviour<CoroutineManager>.Instance.Run(TrainCarTeleporter.TeleportTrainset(trainCarsToMove, target));
			string arg = string.Join("\n", trainCarsToMove.Select((TrainCar tc) => tc.ID));
			if (trainCarsToMove.Any((TrainCar c) => c.Bogies.Any((Bogie b) => b.track != destinationRailTrack)))
			{
				Debug.LogError($"Cars: \n{arg}\nmoved to nearby track, there was no space on {destinationRailTrack.LogicTrack().ID}");
			}
			else
			{
				Debug.Log($"Cars: \n{arg}\nsuccessfully moved to destination track {destinationRailTrack.LogicTrack().ID}");
			}
		}

		private static void Dev_SetNearLoaderRange(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				int load = args[0].Int;
				int unload = args[1].Int;
				SetStreamerLoading("near", load, unload);
			}
		}

		private static void Dev_SetFarLoaderRange(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				int load = args[0].Int;
				int unload = args[1].Int;
				SetStreamerLoading("far", load, unload);
			}
		}

		private static void SetStreamerLoading(string name, int load, int unload)
		{
			Streamer streamer = (from s in UnityEngine.Object.FindObjectsOfType<Streamer>()
				where s.name.Contains(name)
				select s).FirstOrDefault();
			if (!streamer)
			{
				Debug.LogError("Streamer " + name + " is missing!");
				return;
			}
			streamer.loadingRange = new Vector3(load, 0f, load);
			streamer.deloadingRange = new Vector3(unload, 0f, unload);
		}

		private static void Dev_ForwardRenderingToggle(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			bool isForwardRendering = SingletonBehaviour<GraphicsOptions>.Instance.IsForwardRendering;
			if (args.Length == 0)
			{
				Terminal.Log($"Forward rendering is: {isForwardRendering}");
				return;
			}
			bool flag;
			switch (args[0].Int)
			{
			case 0:
				flag = false;
				break;
			case 1:
				flag = true;
				break;
			default:
				Terminal.Log("Invalid argument, valid forward rendering arguments are: 0 or 1");
				return;
			}
			if (flag == isForwardRendering)
			{
				Terminal.Log($"Current forward rendering is already {flag}");
				return;
			}
			SingletonBehaviour<GraphicsOptions>.Instance.SetForwardRendering(flag);
			Terminal.Log($"Forward rendering set to {SingletonBehaviour<GraphicsOptions>.Instance.IsForwardRendering}");
		}

		private static void Dev_AdvanceTime(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				DateTime dateTime = SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime;
				TimeAdvance.AdvanceTime(args[0].Float, force: true);
				DateTime dateTime2 = SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime;
				Terminal.Log($"Time advanced from {dateTime} to {dateTime2}");
			}
		}

		private static void Dev_SpawnBed(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				GameObject original = Resources.Load("Bed_debug") as GameObject;
				original = UnityEngine.Object.Instantiate(original);
				if ((bool)PlayerManager.Car)
				{
					original.transform.SetParent(PlayerManager.Car.interior);
				}
				else
				{
					original.transform.SetParent(WorldMover.OriginShiftParent);
				}
				Vector3 position = Camera.main.transform.position;
				position.y -= 1f;
				Vector3 forward = Camera.main.transform.forward;
				forward.y = 0f;
				original.transform.position = position + forward * 1.2f;
				original.transform.localScale = Vector3.one * 0.5f;
			}
		}

		private static void Dev_OffsetLastWakeTime(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				DateTime lastWakeTime = SingletonBehaviour<BedSleepingController>.Instance.lastWakeTime;
				DateTime dateTime = SingletonBehaviour<BedSleepingController>.Instance.lastWakeTime.AddHours(args[0].Float);
				SingletonBehaviour<BedSleepingController>.Instance.lastWakeTime = dateTime;
				Terminal.Log($"Last wake time changed from {lastWakeTime} to {dateTime}");
			}
		}

		private static void Dev_StartLocoQT(CommandArg[] args)
		{
			if (!SceneSwitcher.IsInGameWorld)
			{
				Terminal.Log("Tutorials only work during gameplay!");
			}
			else if (QuickTutorialHost.IsTutorialRunning)
			{
				Terminal.Log("Tutorial already running!");
			}
			else
			{
				QuickTutorialHost.StartTutorial(QuickTutorialFactory.PrepareFor(PlayerManager.Car));
			}
		}

		private static void Dev_StartCouplingQT(CommandArg[] args)
		{
			if (!SceneSwitcher.IsInGameWorld)
			{
				Terminal.Log("Tutorials only work during gameplay!");
			}
			else if (QuickTutorialHost.IsTutorialRunning)
			{
				Terminal.Log("Tutorial already running!");
			}
			else
			{
				QuickTutorialHost.StartTutorial(QuickTutorialFactory.CouplingTutorial(PlayerManager.ActiveCamera.transform, announceCompletion: true, doRangeChecks: true));
			}
		}

		private static void Dev_StartRerailingQT(CommandArg[] args)
		{
			if (!SceneSwitcher.IsInGameWorld)
			{
				Terminal.Log("Tutorials only work during gameplay!");
			}
			else if (QuickTutorialHost.IsTutorialRunning)
			{
				Terminal.Log("Tutorial already running!");
			}
			else
			{
				QuickTutorialHost.StartTutorial(QuickTutorialFactory.RerailingTutorial(PlayerManager.ActiveCamera.transform, doRangeChecks: true, onlyClosestRail: false));
			}
		}

		private static void Dev_StartDebtPayingQT(CommandArg[] args)
		{
			if (!SceneSwitcher.IsInGameWorld)
			{
				Terminal.Log("Tutorials only work during gameplay!");
				return;
			}
			if (QuickTutorialHost.IsTutorialRunning)
			{
				Terminal.Log("Tutorial already running!");
				return;
			}
			Vector3 reference = (PlayerManager.ActiveCamera ? PlayerManager.ActiveCamera.transform.position : Vector3.zero);
			CareerManagerInputHandler[] array = UnityEngine.Object.FindObjectsOfType<CareerManagerInputHandler>();
			if (array.Length == 0)
			{
				Terminal.Log("No Career Managers found around, can't start.");
				return;
			}
			string text = "";
			if (args.Length != 0)
			{
				text = args[0].ToString();
			}
			else
			{
				if (!PlayerManager.Car)
				{
					Terminal.Log("Player isn't in a train car, nor was an ID provided as argument, can't start.");
					return;
				}
				text = PlayerManager.Car.ID;
			}
			Array.Sort(array, (CareerManagerInputHandler a, CareerManagerInputHandler b) => (a.transform.position - reference).sqrMagnitude.CompareTo((b.transform.position - reference).sqrMagnitude));
			QuickTutorialHost.StartTutorial(QuickTutorialFactory.CareerDebtPayingTutorial(array[0].gameObject, text));
		}

		private static void Dev_StartManualQT(CommandArg[] args)
		{
			if (!SceneSwitcher.IsInGameWorld)
			{
				Terminal.Log("Tutorials only work during gameplay!");
			}
			else if (QuickTutorialHost.IsTutorialRunning)
			{
				Terminal.Log("Tutorial already running!");
			}
			else
			{
				QuickTutorialHost.StartTutorial(QuickTutorialFactory.ManualTutorial());
			}
		}

		private static void Dev_StartQTQT(CommandArg[] args)
		{
			if (!SceneSwitcher.IsInGameWorld)
			{
				Terminal.Log("Tutorials only work during gameplay!");
			}
			else if (QuickTutorialHost.IsTutorialRunning)
			{
				Terminal.Log("Tutorial already running!");
			}
			else
			{
				QuickTutorialHost.StartTutorial(QuickTutorialFactory.QTsTutorial());
			}
		}

		private static void Dev_StartHandcarQT(CommandArg[] args)
		{
			if (!SceneSwitcher.IsInGameWorld)
			{
				Terminal.Log("Tutorials only work during gameplay!");
			}
			else if (QuickTutorialHost.IsTutorialRunning)
			{
				Terminal.Log("Tutorial already running!");
			}
			else
			{
				QuickTutorialHost.StartTutorial(QuickTutorialFactory.HandcarSpawnTutorial(PlayerManager.PlayerTransform.transform, onlyClosestRail: true));
			}
		}

		private static void Dev_StartClearQT(CommandArg[] args)
		{
			if (!SceneSwitcher.IsInGameWorld)
			{
				Terminal.Log("Tutorials only work during gameplay!");
			}
			else if (QuickTutorialHost.IsTutorialRunning)
			{
				Terminal.Log("Tutorial already running!");
			}
			else
			{
				QuickTutorialHost.StartTutorial(QuickTutorialFactory.HandcarClearTutorial(PlayerManager.LastLoco));
			}
		}

		private static void Dev_AbortQT(CommandArg[] args)
		{
			if (!SceneSwitcher.IsInGameWorld)
			{
				Terminal.Log("Tutorials only work during gameplay!");
			}
			else
			{
				QuickTutorialHost.AbortTutorial();
			}
		}

		private static void Dev_InputSemantic(CommandArg[] args)
		{
			if (args.Length == 0)
			{
				TutorialInputPromptsBridge.Semantics[] array = (TutorialInputPromptsBridge.Semantics[])Enum.GetValues(typeof(TutorialInputPromptsBridge.Semantics));
				for (int i = 0; i < array.Length; i++)
				{
					TutorialInputPromptsBridge.Semantics semantic = array[i];
					string text;
					try
					{
						text = TutorialInputPromptsBridge.GetLocalizedForSemantic(semantic);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						text = "!EXCEPTION!";
					}
					Terminal.Log(semantic.ToString() + ": " + text);
				}
			}
			else
			{
				Terminal.Log(TutorialInputPromptsBridge.GetLocalizedForSemantic(args[0].String));
			}
		}

		private static void Dev_CheckFeatureFlags(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				GameFeatureFlags.Flag[] allFlags = GameFeatureFlags.AllFlags;
				foreach (GameFeatureFlags.Flag flag in allFlags)
				{
					Terminal.Log(string.Format("{0}: {1}", flag, GameFeatureFlags.IsAllowed(flag) ? "Allowed" : "DENIED"));
				}
			}
		}

		private static void Dev_FeatureFlagAllow(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				if (Enum.TryParse<GameFeatureFlags.Flag>(args[0].String, ignoreCase: true, out var result))
				{
					GameFeatureFlags.Allow(result);
					Terminal.Log($"{result} is now allowed");
				}
				else
				{
					Terminal.Log("Invalid flag name, valid names are: " + string.Join(", ", Enum.GetNames(typeof(GameFeatureFlags.Flag))));
				}
			}
		}

		private static void Dev_FeatureFlagDeny(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				if (Enum.TryParse<GameFeatureFlags.Flag>(args[0].String, ignoreCase: true, out var result))
				{
					GameFeatureFlags.Deny(result);
					Terminal.Log($"{result} is now denied");
				}
				else
				{
					Terminal.Log("Invalid flag name, valid names are: " + string.Join(", ", Enum.GetNames(typeof(GameFeatureFlags.Flag))));
				}
			}
		}

		private static void Dev_ShadowTrace(CommandArg[] args)
		{
			ShadowTracer instance = SingletonBehaviour<ShadowTracer>.Instance;
			if (instance == null)
			{
				Terminal.Log("No ShadowTracer component found in scene! Nothing to do.");
			}
			else if (args.Length == 0)
			{
				Terminal.Log(instance.ShadowTracing.ToString());
			}
			else if (!instance.ShadowTracing && args[0].Int > 0)
			{
				backupShadowDistance = QualitySettings.shadowDistance;
				backupCascades2 = QualitySettings.shadowCascade2Split;
				backupCascades4 = QualitySettings.shadowCascade4Split;
				backupCascades = QualitySettings.shadowCascades;
				QualitySettings.shadowDistance = 400f;
				QualitySettings.shadowCascades = 2;
				QualitySettings.shadowCascade2Split = 0.084f;
				instance.ShadowTracing = true;
				instance.RenderAsync();
				Terminal.Log(instance.ShadowTracing.ToString());
			}
			else if (instance.ShadowTracing && args[0].Int == 0)
			{
				QualitySettings.shadowDistance = backupShadowDistance;
				QualitySettings.shadowCascades = backupCascades;
				QualitySettings.shadowCascade2Split = backupCascades2;
				QualitySettings.shadowCascade4Split = backupCascades4;
				instance.ShadowTracing = false;
				Terminal.Log(instance.ShadowTracing.ToString());
			}
		}

		private static void Dev_WorldAO(CommandArg[] args)
		{
			ShadowTracer instance = SingletonBehaviour<ShadowTracer>.Instance;
			if (instance == null)
			{
				Terminal.Log("No ShadowTracer component found in scene! Nothing to do.");
				return;
			}
			if (args.Length == 0)
			{
				Terminal.Log(instance.AORenderer.ToString());
				return;
			}
			if (instance.AORenderer != args[0].Int > 0)
			{
				instance.AORenderer = args[0].Int > 0;
			}
			Terminal.Log(instance.AORenderer.ToString());
		}

		private static void Dev_TerrainGridShadows(CommandArg[] args)
		{
			TerrainGrid terrainGrid = UnityEngine.Object.FindObjectOfType<TerrainGrid>();
			if (terrainGrid == null)
			{
				Terminal.Log("No TerrainGrid component found in scene! Nothing to do.");
			}
			else if (args[0].Int > 0 || args[0].Bool)
			{
				terrainGrid.EnableShadows();
				Terminal.Log("Terrain shadows enabled");
			}
			else
			{
				terrainGrid.DisableShadows();
				Terminal.Log("Terrain shadows disabled");
			}
		}

		private static void Dev_OriginShiftRange(CommandArg[] args)
		{
			if ((bool)SingletonBehaviour<WorldMover>.Instance)
			{
				if (args.Length != 0)
				{
					SingletonBehaviour<WorldMover>.Instance.moveRange = Mathf.Max(1f, args[0].Float);
				}
				Terminal.Log(SingletonBehaviour<WorldMover>.Instance.moveRange.ToString());
			}
			else
			{
				Terminal.Log("There's no world mover in this scene.");
			}
		}

		private static void Dev_OriginShiftNow(CommandArg[] args)
		{
			if (!SingletonBehaviour<WorldMover>.Instance)
			{
				Terminal.Log("There's no world mover in this scene.");
			}
			else
			{
				SingletonBehaviour<CoroutineManager>.Instance.Run(DebugWorldMove());
			}
		}

		private static IEnumerator DebugWorldMove()
		{
			Terminal.Log("Setting short range to initiate move...");
			float rangeBackup = SingletonBehaviour<WorldMover>.Instance.moveRange;
			Vector3 previousShift = WorldMover.currentMove;
			SingletonBehaviour<WorldMover>.Instance.moveRange = 1f;
			while (WorldMover.currentMove == previousShift)
			{
				yield return null;
			}
			Terminal.Log("World moved, restoring range.");
			SingletonBehaviour<WorldMover>.Instance.moveRange = rangeBackup;
		}

		private static void Dev_ModifyLicenses(CommandArg[] args)
		{
			LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
			List<GeneralLicenseType_v2> generalLicenses = Globals.G.Types.generalLicenses;
			List<JobLicenseType_v2> jobLicenses = Globals.G.Types.jobLicenses;
			string text = ((args.Length != 0) ? args[0].String : null);
			if (text == "list")
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendLine("\nGeneral Licenses:");
				generalLicenses.ForEach(delegate(GeneralLicenseType_v2 l)
				{
					sb.AppendLine("- " + l.id);
				});
				sb.AppendLine("\nJob Licenses:");
				jobLicenses.ForEach(delegate(JobLicenseType_v2 l)
				{
					sb.AppendLine("- " + l.id);
				});
				Debug.Log(sb);
				return;
			}
			if (args.Length == 0 || text == "all")
			{
				bool flag = args.Length < 2 || (args.Length >= 2 && args[1].Bool);
				foreach (GeneralLicenseType_v2 item in generalLicenses)
				{
					if (flag && !instance.IsGeneralLicenseAcquired(item))
					{
						instance.AcquireGeneralLicense(item);
					}
					else if (!flag && instance.IsGeneralLicenseAcquired(item))
					{
						instance.RemoveGeneralLicense(item);
					}
				}
				foreach (JobLicenseType_v2 item2 in jobLicenses)
				{
					if (flag && !instance.IsJobLicenseAcquired(item2))
					{
						instance.AcquireJobLicense(item2);
					}
					else if (!flag && instance.IsJobLicenseAcquired(item2))
					{
						instance.RemoveJobLicense(new JobLicenseType_v2[1] { item2 });
					}
				}
				Debug.Log(string.Format("{0} all {1} licenses", flag ? "Granted" : "Revoked", generalLicenses.Count + jobLicenses.Count));
				return;
			}
			GeneralLicenseType_v2 generalLicense;
			bool flag2 = Globals.G.Types.TryGetGeneralLicense(text, out generalLicense);
			JobLicenseType_v2 jobLicense;
			bool flag3 = Globals.G.Types.TryGetJobLicense(text, out jobLicense);
			if (!flag2 && !flag3)
			{
				Debug.LogError("Unknown license '" + text + "'");
				return;
			}
			bool flag4 = ((args.Length > 1) ? args[1].Bool : ((flag2 && !instance.IsGeneralLicenseAcquired(generalLicense)) || (flag3 && !instance.IsJobLicenseAcquired(jobLicense))));
			if (flag2)
			{
				if (flag4)
				{
					instance.AcquireGeneralLicense(generalLicense);
				}
				else
				{
					instance.RemoveGeneralLicense(generalLicense);
				}
			}
			else if (flag4)
			{
				instance.AcquireJobLicense(jobLicense);
			}
			else
			{
				instance.RemoveJobLicense(new JobLicenseType_v2[1] { jobLicense });
			}
			Debug.Log((flag4 ? "Granted" : "Revoked") + " " + (flag2 ? "general" : "job") + " license " + text);
		}

		private static void Dev_ExplodeTrain(CommandArg[] args)
		{
			TrainCar trainCar = ((args.Length != 0) ? SingletonBehaviour<CarSpawner>.Instance.AllCars.Find((TrainCar c) => c.ID == args[0].String) : PlayerManager.Car);
			if (trainCar == null)
			{
				Debug.LogError("You must be in a train or provide a train ID to explode!");
				return;
			}
			if ((bool)trainCar.SimController && trainCar.SimController.simFlow.TryGetPort(trainCar.GetComponentInChildren<ExplosionActivationOnSignal>()?.explosionSignalPortId, out var port, canBeNullOrEmpty: true))
			{
				port.Value = 1f;
			}
			trainCar.GetComponentInChildren<ResourceExplosionBase>()?.ExplodeResource();
			trainCar.interior.GetComponentInChildren<CargoReactionBase>()?.ExplodeCargo();
		}

		private static void Dev_EnvSoundStats(CommandArg[] args)
		{
			if (SingletonBehaviour<EnvironmentSoundSystem>.Instance == null)
			{
				Terminal.Log("There's no EnvironmentSoundSystem in this scene, are you in the menus?");
				return;
			}
			if (args.Length != 0)
			{
				SingletonBehaviour<EnvironmentSoundSystem>.Instance.showStats = args[0].Int > 0;
			}
			Terminal.Log(SingletonBehaviour<EnvironmentSoundSystem>.Instance.showStats ? "1" : "0");
		}

		private static void Dev_RebuildLightData(CommandArg[] args)
		{
			SpriteLightsSystem instance = SingletonBehaviour<SpriteLightsSystem>.Instance;
			if (instance != null)
			{
				instance.RebuildAllData();
				Terminal.Log("Initiated light data rebuild");
			}
			else
			{
				Terminal.Log("There's no SpriteLightsSystem in this scene, are you in the menus?");
			}
		}

		private static void UnlockGarage(CommandArg[] args)
		{
			LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
			if (args.Length == 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("All Garages:");
				stringBuilder.AppendLine("- all");
				foreach (GarageType_v2 garage2 in Globals.G.Types.garages)
				{
					if (!garage2.id.ToLowerInvariant().Contains("relic"))
					{
						stringBuilder.Append("- ");
						stringBuilder.Append(garage2.id);
						stringBuilder.Append(" (Unlocked: ");
						stringBuilder.Append(instance.IsGarageUnlocked(garage2));
						stringBuilder.AppendLine(")");
					}
				}
				Debug.Log(stringBuilder);
				return;
			}
			string text = args[0].String;
			GarageType_v2 garage;
			if (text == "all")
			{
				foreach (GarageType_v2 garage3 in Globals.G.Types.garages)
				{
					if (!garage3.id.ToLowerInvariant().Contains("relic") && !instance.IsGarageUnlocked(garage3))
					{
						instance.UnlockGarage(garage3);
					}
				}
				Debug.Log("Unlocked all garages");
			}
			else if (!Globals.G.Types.TryGetGarage(text, out garage))
			{
				Debug.LogError("No garage found with id '" + text + "'");
			}
			else if (garage.id.ToLowerInvariant().Contains("relic"))
			{
				Debug.LogError("Relics are not supported by this command!");
			}
			else
			{
				instance.UnlockGarage(garage);
				Debug.Log("Unlocked " + garage.id);
			}
		}

		private static void Graphics_Handle(string fieldName, CommandArg[] args, FieldType fieldType)
		{
			PropertyInfo property = typeof(QualitySettings).GetProperty(fieldName);
			if (args.Length == 0)
			{
				Terminal.Log("Current value: " + property.GetValue(null));
			}
			else if (!Terminal.IssuedError)
			{
				switch (fieldType)
				{
				case FieldType.Bool:
					property.SetValue(null, args[0].Int > 0);
					break;
				case FieldType.Float:
					property.SetValue(null, args[0].Float);
					break;
				case FieldType.Int:
					property.SetValue(null, args[0].Int);
					break;
				case FieldType.Vector3:
					property.SetValue(null, new Vector3(args[0].Float, args[1].Float, args[2].Float));
					break;
				default:
					Terminal.Log(TerminalLogType.Error, "Unknown field type " + fieldType);
					break;
				}
				Terminal.Log("Value is now: " + property.GetValue(null));
			}
		}

		[RegisterCommand("Graphics.AnisitropicFiltering", Help = "Disable/enable/force anisotropic texture filtering (0, 1, 2)")]
		private static void Graphics_AnisotropicFiltering(CommandArg[] args)
		{
			Graphics_Handle("anisotropicFiltering", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.Antialiasing", Help = "Antialiasing level (0, 2, 4, 8)")]
		private static void Graphics_Antialiasing(CommandArg[] args)
		{
			Graphics_Handle("antiAliasing", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.AsyncUpload.BufferSize", Help = "See Unity docs for QualitySettings.AsyncUploadBufferSize (2-512)")]
		private static void Graphics_AsyncUploadBufferSize(CommandArg[] args)
		{
			Graphics_Handle("asyncUploadBufferSize", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.AsyncUpload.TimeSlice", Help = "See Unity docs for QualitySettings.AsyncUploadTimeSlice (1-33)")]
		private static void Graphics_AsyncUploadTimeSlice(CommandArg[] args)
		{
			Graphics_Handle("asyncUploadTimeSlice", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.LodBias", Help = "LOD distance multiplier (float)")]
		private static void Graphics_LodBias(CommandArg[] args)
		{
			Graphics_Handle("lodBias", args, FieldType.Float);
		}

		[RegisterCommand("Graphics.MasterTextureLimit", Help = "Texture MipMap limit, each value cuts texture quality into half (int)")]
		private static void Graphics_MasterTextureLimit(CommandArg[] args)
		{
			Graphics_Handle("masterTextureLimit", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.MaxQueuedFrames", Help = "Maximum number of frames queued up by graphics driver (int)")]
		private static void Graphics_MaxQueuedFrames(CommandArg[] args)
		{
			Graphics_Handle("maxQueuedFrames", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.ParticleRaycastBudget", Help = "Limits number of collision tests per frame for particles (int)")]
		private static void Graphics_ParticleRaycastBudget(CommandArg[] args)
		{
			Graphics_Handle("particleRaycastBudget", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.PixelLightCount", Help = "The maximum number of pixel lights that should affect any object (int)")]
		private static void Graphics_PixelLightCount(CommandArg[] args)
		{
			Graphics_Handle("pixelLightCount", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.RealtimeReflectionProbes", Help = "Enable/disable realtime reflection probes (bool)")]
		private static void Graphics_RealtimeReflectionProbes(CommandArg[] args)
		{
			Graphics_Handle("realtimeReflectionProbes", args, FieldType.Bool);
		}

		[RegisterCommand("Graphics.Shadow.Cascades", Help = "Number of shadow cascades for directional lights (1, 2, 4)")]
		private static void Graphics_ShadowCascades(CommandArg[] args)
		{
			Graphics_Handle("shadowCascades", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.Shadow.Distance", Help = "Shadow drawing distance (float)")]
		private static void Graphics_ShadowDistance(CommandArg[] args)
		{
			Graphics_Handle("shadowDistance", args, FieldType.Float);
		}

		[RegisterCommand("Graphics.Shadow.Projection", Help = "Directional light close/stable shadow projection (0, 1)")]
		private static void Graphics_ShadowProjection(CommandArg[] args)
		{
			Graphics_Handle("shadowProjection", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.Shadow.Resolution", Help = "Shadow resolution (0-3)")]
		private static void Graphics_ShadowResolution(CommandArg[] args)
		{
			Graphics_Handle("shadowResolution", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.Shadow.Mode", Help = "Off / Hard only / Hard & Soft shadows (0, 1, 2)")]
		private static void Graphics_ShadowMode(CommandArg[] args)
		{
			Graphics_Handle("shadows", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.Shadow.NGSS", Help = "Set NGSS (screen-space shadows) state: 0 - disabled, 1 - low quality, 2 - high quality", MinArgCount = 1, MaxArgCount = 1)]
		private static void Graphics_NGSS(CommandArg[] args)
		{
			if (args[0].Int == 0)
			{
				SingletonBehaviour<GraphicsOptions>.Instance.SetScreenSpaceShadowsState(state: false, highQuality: false);
				Terminal.Log("Screen-space shadows disabled");
			}
			else if (args[0].Int == 1)
			{
				SingletonBehaviour<GraphicsOptions>.Instance.SetScreenSpaceShadowsState(state: true, highQuality: false);
				Terminal.Log("Screen-space shadows enabled, low quality");
			}
			else if (args[0].Int == 2)
			{
				SingletonBehaviour<GraphicsOptions>.Instance.SetScreenSpaceShadowsState(state: true, highQuality: true);
				Terminal.Log("Screen-space shadows enabled, high quality");
			}
			else
			{
				Terminal.Log("Invalid argument, use 0, 1 or 2");
			}
		}

		[RegisterCommand("Graphics.StreamingMipmaps.Active", Help = "Enable/disable texture mipmap streaming (see also StreamingMipmapsAddAllCameras) (bool)")]
		private static void Graphics_StreamingMipmapsActive(CommandArg[] args)
		{
			Graphics_Handle("streamingMipmapsActive", args, FieldType.Bool);
		}

		[RegisterCommand("Graphics.StreamingMipmaps.AddAllCameras", Help = "Enable/disable texture mipmap streaming on all enabled cameras (bool)")]
		private static void Graphics_StreamingMipmapsAddAllCameras(CommandArg[] args)
		{
			Graphics_Handle("streamingMipmapsAddAllCameras", args, FieldType.Bool);
		}

		[RegisterCommand("Graphics.StreamingMipmaps.MaxFileIORequests", Help = "Limits number of file IO requests for texture streaming (int)")]
		private static void Graphics_StreamingMipmapsMaxFileIORequests(CommandArg[] args)
		{
			Graphics_Handle("streamingMipmapsMaxFileIORequests", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.StreamingMipmaps.MaxLevelReduction", Help = "Maximum number of mipmap levels to discard for each texture (int)")]
		private static void Graphics_StreamingMipmapsMaxLevelReduction(CommandArg[] args)
		{
			Graphics_Handle("streamingMipmapsMaxLevelReduction", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.StreamingMipmaps.MemoryBudget", Help = "Total amount of memory to be used by streaming and non-streaming textures (float)")]
		private static void Graphics_StreamingMipmapsMemoryBudget(CommandArg[] args)
		{
			Graphics_Handle("streamingMipmapsMemoryBudget", args, FieldType.Float);
		}

		[RegisterCommand("Graphics.StreamingMipmaps.RenderersPerFrame", Help = "Limits number of renderers per frame used for calculation of mipmap levels (int)")]
		private static void Graphics_StreamingMipmapsRenderersPerFrame(CommandArg[] args)
		{
			Graphics_Handle("streamingMipmapsRenderersPerFrame", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.VSyncCount", Help = "Number of VSyncs that should pass between each frame (0-4)")]
		private static void Graphics_VSyncCount(CommandArg[] args)
		{
			Graphics_Handle("vSyncCount", args, FieldType.Int);
		}

		[RegisterCommand("Graphics.ShadowCascade2Split", Help = "Split value for cascaded shadows in 2-cascades case (float 0-1)")]
		private static void Graphics_ShadowCascade2Split(CommandArg[] args)
		{
			Graphics_Handle("shadowCascade2Split", args, FieldType.Float);
		}

		[RegisterCommand("Graphics.ShadowCascade4Split", Help = "Split values for cascaded shadows in 4-cascades case (3 floats)")]
		private static void Graphics_ShadowCascade4Split(CommandArg[] args)
		{
			Graphics_Handle("shadowCascade4Split", args, FieldType.Vector3);
		}

		[RegisterCommand("Graphics.ShadowCascadeInfo", Help = "Print out current shadow cascades count and world-space split distance")]
		private static void Graphics_ShadowCascadeInfo(CommandArg[] args)
		{
			if (QualitySettings.shadowCascades == 0)
			{
				Terminal.Log("No cascades enabled");
			}
			else if (QualitySettings.shadowCascades == 2)
			{
				float num = QualitySettings.shadowCascade2Split * QualitySettings.shadowDistance;
				Terminal.Log("Using 2 cascades:");
				Terminal.Log("#1: " + 0f + " -> " + num);
				Terminal.Log("#2: " + num + " -> " + QualitySettings.shadowDistance);
			}
			else if (QualitySettings.shadowCascades == 4)
			{
				Vector3 shadowCascade4Split = QualitySettings.shadowCascade4Split;
				float num2 = shadowCascade4Split.x * QualitySettings.shadowDistance;
				float num3 = shadowCascade4Split.y * QualitySettings.shadowDistance;
				float num4 = shadowCascade4Split.z * QualitySettings.shadowDistance;
				Terminal.Log("Using 4 cascades:");
				Terminal.Log("#1: " + 0f + " -> " + num2);
				Terminal.Log("#2: " + num2 + " -> " + num3);
				Terminal.Log("#3: " + num3 + " -> " + num4);
				Terminal.Log("#4: " + num4 + " -> " + QualitySettings.shadowDistance);
			}
			else
			{
				Terminal.Log("Cascade count is " + QualitySettings.shadowCascades + " and this should never happen.");
			}
		}

		[RegisterCommand("Graphics.TerrainShadows", Help = "Enable/disable terrain shadows", MinArgCount = 0, MaxArgCount = 1)]
		private static void Graphics_ToggleTerrainShadows(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			Terrain[] array = UnityEngine.Object.FindObjectsOfType<Terrain>();
			if (array.Length == 0)
			{
				Terminal.Log("No terrains found");
				return;
			}
			ShadowCastingMode shadowCastingMode = array[0].shadowCastingMode;
			if (args.Length == 0)
			{
				Terminal.Log("Current value: " + shadowCastingMode);
				return;
			}
			Terrain[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].shadowCastingMode = ((shadowCastingMode != ShadowCastingMode.On) ? ShadowCastingMode.On : ShadowCastingMode.Off);
			}
		}

		[RegisterCommand("Graphics.TerrainsRendering", Help = "Enable/disable rendering terrains", MinArgCount = 0, MaxArgCount = 1)]
		private static void Graphics_TerrainsRendering(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			Terrain[] array = UnityEngine.Object.FindObjectsOfType<Terrain>();
			if (array.Length == 0)
			{
				Terminal.Log("No terrains found");
				return;
			}
			bool drawHeightmap = array[0].drawHeightmap;
			if (args.Length == 0)
			{
				Terminal.Log("Current value: " + drawHeightmap);
				return;
			}
			Terrain[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].drawHeightmap = !drawHeightmap;
			}
		}

		[RegisterCommand("Graphics.DeferredAA", Help = "Set deferred anti-aliasing mode (0, 1, 2, 3)")]
		private static void Graphics_DeferredAA(CommandArg[] args)
		{
			if (args.Length == 0)
			{
				int num = GamePreferences.Get<int>(Preferences.AntiAliasingDeferredLevelsIndex);
				Terminal.Log(string.Concat("Current mode: ", num, " (", (GraphicsOptions.AntiAliasingDeferred)num, ")"));
			}
			else
			{
				int num2 = Mathf.Clamp(args[0].Int, 0, 3);
				GamePreferences.Set(Preferences.AntiAliasingDeferredLevelsIndex, num2);
				Terminal.Log(string.Concat("Mode set to: ", num2, " (", (GraphicsOptions.AntiAliasingDeferred)num2, ")"));
			}
		}

		[RegisterCommand("Graphics.SoftTAA", Help = "Set TAA to be softer-looking, can help with screenshots")]
		private static void Graphics_SoftTAA(CommandArg[] args)
		{
			Camera main = Camera.main;
			if (main == null)
			{
				Terminal.Log("No main camera, nothing to do");
				return;
			}
			PostProcessLayer component = main.GetComponent<PostProcessLayer>();
			if (component == null)
			{
				Terminal.Log("No PostProcessLayer on current main camera, nothing to do");
			}
			else if (args.Length == 0)
			{
				Terminal.Log("Current mode: " + ((component.temporalAntialiasing.sharpness > 0f) ? "0 (sharp)" : "1 (soft)"));
			}
			else if (Mathf.Clamp(args[0].Int, 0, 1) == 0)
			{
				Terminal.Log("Mode set to: 0 (sharp)");
				component.temporalAntialiasing.jitterSpread = 0.5f;
				component.temporalAntialiasing.stationaryBlending = 0.85f;
				component.temporalAntialiasing.motionBlending = 0.8f;
				component.temporalAntialiasing.sharpness = 0.3f;
			}
			else
			{
				Terminal.Log("Mode set to: 1 (soft)");
				component.temporalAntialiasing.jitterSpread = 1f;
				component.temporalAntialiasing.stationaryBlending = 0.85f;
				component.temporalAntialiasing.motionBlending = 0.8f;
				component.temporalAntialiasing.sharpness = 0f;
			}
		}

		private static float TAA_GetValue(TemporalAntialiasing taa, string name)
		{
			return (float)typeof(TemporalAntialiasing).GetField(name).GetValue(taa);
		}

		private static void TAA_SetValue(TemporalAntialiasing taa, string name, float value)
		{
			typeof(TemporalAntialiasing).GetField(name).SetValue(taa, value);
		}

		[RegisterCommand("Graphics.TweakTAA", Help = "Set TAA parameters, run without arg to get a list, run without value to get current state, or with multiple values in a row to set all at once")]
		private static void Graphics_TweakTAA(CommandArg[] args)
		{
			Camera main = Camera.main;
			if (main == null)
			{
				Terminal.Log("No main camera, nothing to do");
				return;
			}
			PostProcessLayer component = main.GetComponent<PostProcessLayer>();
			if (component == null)
			{
				Terminal.Log("No PostProcessLayer on current main camera, nothing to do");
			}
			else if (args.Length == 0)
			{
				string[] tAA_AvailableParams = TAA_AvailableParams;
				foreach (string text in tAA_AvailableParams)
				{
					Terminal.Log(text + " = " + TAA_GetValue(component.temporalAntialiasing, text));
				}
			}
			else if (args.Length == 1 || args.Length == 2)
			{
				string text2 = args[0].String.ToLower();
				string text3 = "";
				for (int j = 0; j < TAA_AvailableParams.Length; j++)
				{
					if (TAA_AvailableParams[j].ToLower() == text2)
					{
						text3 = TAA_AvailableParams[j];
						break;
					}
				}
				if (string.IsNullOrEmpty(text3))
				{
					Terminal.Log("Unknown TAA parameter '" + args[1].String + "', available: " + string.Join(", ", TAA_AvailableParams));
				}
				else if (args.Length == 2)
				{
					TAA_SetValue(component.temporalAntialiasing, text3, args[1].Float);
					Terminal.Log(text3 + " is now " + TAA_GetValue(component.temporalAntialiasing, text3));
				}
				else
				{
					Terminal.Log(text3 + " = " + TAA_GetValue(component.temporalAntialiasing, text3));
				}
			}
			else if (args.Length == TAA_AvailableParams.Length)
			{
				for (int k = 0; k < TAA_AvailableParams.Length; k++)
				{
					TAA_SetValue(component.temporalAntialiasing, TAA_AvailableParams[k], args[k].Float);
					Terminal.Log(TAA_AvailableParams[k] + " is now " + TAA_GetValue(component.temporalAntialiasing, TAA_AvailableParams[k]));
				}
			}
			else
			{
				Terminal.Log("Invalid number of parameters. Valid variants are:\n0 - print out current state of parameters\n1 - [parameter name] - check single parameter\n2 - [parameter name] [value] - set single parameter value\n" + TAA_AvailableParams.Length + " - [value1] [value2] ... - set all the parameter values at once");
			}
		}

		[RegisterCommand("Graphics.ExposureCompensation", Help = "View or set current exposure compensation value from the global postprocessing object", MaxArgCount = 1, MinArgCount = 0)]
		private static void Graphics_ExposureCompensation(CommandArg[] args)
		{
			if (!SingletonBehaviour<GraphicsOptions>.Instance.GlobalPostProcessVolume.IsSome(out var value))
			{
				Terminal.Log("There is no global postprocessing object in this scene, are you in gameplay?");
				return;
			}
			AutoExposure setting = value.profile.GetSetting<AutoExposure>();
			if (setting == null)
			{
				Terminal.Log("Couldn't find AutoExposure in this postprocessing volume, can't proceed.");
				return;
			}
			if (args.Length == 0)
			{
				Terminal.Log("Current compensation value = " + setting.keyValue.value);
				return;
			}
			setting.keyValue.Override(args[0].Float);
			Terminal.Log("Compensation set to " + setting.keyValue.value);
		}

		[RegisterCommand("Graphics.KillVolumetrics", Help = "Disable all volumetric props")]
		private static void Graphics_KillVolumetrics(CommandArg[] args)
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag("SkipLightBake");
			killedVolumetrics.Clear();
			GameObject[] array2 = array;
			foreach (GameObject gameObject in array2)
			{
				if (gameObject.name == "VolumetricGlow")
				{
					killedVolumetrics.Add(gameObject);
					gameObject.SetActive(value: false);
				}
			}
			Terminal.Log("Disabled " + killedVolumetrics.Count + " object(s)");
		}

		[RegisterCommand("Graphics.RestoreVolumetrics", Help = "Restore  all volumetric props")]
		private static void Graphics_RestoreVolumetrics(CommandArg[] args)
		{
			int num = 0;
			foreach (GameObject killedVolumetric in killedVolumetrics)
			{
				if (killedVolumetric != null)
				{
					num++;
					killedVolumetric.SetActive(value: true);
				}
			}
			killedVolumetrics.Clear();
			Terminal.Log("Enabled " + num + " object(s)");
		}

		[RegisterCommand("Graphics.LightsRange", Help = "Set lights range")]
		private static void Graphics_LightsRange(CommandArg[] args)
		{
			if (args.Length == 1)
			{
				GeneratedLightsController[] array = UnityEngine.Object.FindObjectsOfType<GeneratedLightsController>();
				GeneratedLightsController[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].SetRange(args[0].Float);
				}
				Terminal.Log("Range for " + array.Length + " controller(s) set to " + args[0].Float);
			}
			else
			{
				Terminal.Log("Invalid argument count");
			}
		}

		[RegisterCommand("Graphics.LightingQuality", Help = "Set lighting quality (0, 1, 2)")]
		private static void Graphics_LightingQuality(CommandArg[] args)
		{
			if (args.Length == 0)
			{
				GraphicsOptions.LightingQuality lightingQualityLevel = SingletonBehaviour<GraphicsOptions>.Instance.LightingQualityLevel;
				Terminal.Log(string.Concat("Current lighting quality level: ", lightingQualityLevel, " (", (int)lightingQualityLevel, ")"));
			}
			else if (args.Length == 1)
			{
				int num = -1;
				if (args[0].String == "0" || args[0].String.ToLower() == GraphicsOptions.LightingQuality.LOW.ToString().ToLower())
				{
					num = 0;
				}
				else if (args[0].Int == 1 || args[0].String.ToLower() == GraphicsOptions.LightingQuality.MEDIUM.ToString().ToLower())
				{
					num = 1;
				}
				else if (args[0].Int == 2 || args[0].String.ToLower() == GraphicsOptions.LightingQuality.HIGH.ToString().ToLower())
				{
					num = 2;
				}
				if (num >= 0)
				{
					GamePreferences.Set(Preferences.LightingQualityIndex, num);
					GraphicsOptions.LightingQuality lightingQualityLevel2 = SingletonBehaviour<GraphicsOptions>.Instance.LightingQualityLevel;
					Terminal.Log(string.Concat("Current lighting quality level: ", lightingQualityLevel2, " (", (int)lightingQualityLevel2, ")"));
				}
				else
				{
					Terminal.Log("Invalid lighting quality level: " + args[0].String);
				}
			}
			else
			{
				Terminal.Log("Too many arguments, use none to get current state, or use one to set state");
			}
		}

		[RegisterCommand("Texture.allowThreadedTextureCreation", Help = "Allow Unity internals to perform Texture creation on any thread (rather than the dedicated render thread).", MinArgCount = 0, MaxArgCount = 1)]
		private static void Texture_allowThreadedTextureCreation(CommandArg[] args)
		{
			if (args.Length == 1)
			{
				Texture.allowThreadedTextureCreation = args[0].Bool;
			}
			else
			{
				Terminal.Log($"Texture.allowThreadedTextureCreation = {Texture.allowThreadedTextureCreation}");
			}
		}

		[RegisterCommand("Texture.currentTextureMemory", Help = "The amount of memory that all Textures in the scene use.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Texture_currentTextureMemory(CommandArg[] args)
		{
			Terminal.Log($"Texture.currentTextureMemory = {Texture.currentTextureMemory}");
		}

		[RegisterCommand("Texture.desiredTextureMemory", Help = "The total size of the Textures, in bytes, that Unity loads if there were no other constraints. Before Unity loads any Textures, it applies the memory budget which reduces the loaded Texture resolution if the Texture sizes exceed its value. The `desiredTextureMemory` value takes into account the mipmap levels that Unity has requested or that you have set manually.For example, if Unity does not load a Texture at full resolution because it is far away or its requested mipmap level is greater than 0, Unity reduces the `desiredTextureMemory` value to match the total memory needed.The `desiredTextureMemory` value can be greater than the `targetTextureMemory` value.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Texture_desiredTextureMemory(CommandArg[] args)
		{
			Terminal.Log($"Texture.desiredTextureMemory = {Texture.desiredTextureMemory}");
		}

		[RegisterCommand("Texture.GenerateAllMips", Help = "Can be used with Texture constructors that take a mip count to indicate that all mips should be generated. The value of this field is -1.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Texture_GenerateAllMips(CommandArg[] args)
		{
			Terminal.Log($"Texture.GenerateAllMips = {Texture.GenerateAllMips}");
		}

		[RegisterCommand("Texture.nonStreamingTextureCount", Help = "The number of non-streaming Textures in the scene. This includes instances of Texture2D and CubeMap Textures. This does not include any other Texture types, or 2D and CubeMap Textures that Unity creates internally.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Texture_nonStreamingTextureCount(CommandArg[] args)
		{
			Terminal.Log($"Texture.nonStreamingTextureCount = {Texture.nonStreamingTextureCount}");
		}

		[RegisterCommand("Texture.nonStreamingTextureMemory", Help = "The amount of memory Unity allocates for non-streaming Textures in the scene. This only includes instances of Texture2D and CubeMap Textures. This does not include any other Texture types, or 2D and CubeMap Textures that Unity creates internally.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Texture_nonStreamingTextureMemory(CommandArg[] args)
		{
			Terminal.Log($"Texture.nonStreamingTextureMemory = {Texture.nonStreamingTextureMemory}");
		}

		[RegisterCommand("Texture.streamingMipmapUploadCount", Help = "How many times has a Texture been uploaded due to Texture mipmap streaming.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Texture_streamingMipmapUploadCount(CommandArg[] args)
		{
			Terminal.Log($"Texture.streamingMipmapUploadCount = {Texture.streamingMipmapUploadCount}");
		}

		[RegisterCommand("Texture.streamingRendererCount", Help = "Number of renderers registered with the Texture streaming system.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Texture_streamingRendererCount(CommandArg[] args)
		{
			Terminal.Log($"Texture.streamingRendererCount = {Texture.streamingRendererCount}");
		}

		[RegisterCommand("Texture.streamingTextureCount", Help = "Number of streaming Textures.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Texture_streamingTextureCount(CommandArg[] args)
		{
			Terminal.Log($"Texture.streamingTextureCount = {Texture.streamingTextureCount}");
		}

		[RegisterCommand("Texture.streamingTextureDiscardUnusedMips", Help = "Forces the streaming Texture system to discard all unused mipmaps instead of caching them until the Texture memory budget is exceeded. This is useful when you profile or write tests to keep a predictable set of Textures in memory.", MinArgCount = 0, MaxArgCount = 1)]
		private static void Texture_streamingTextureDiscardUnusedMips(CommandArg[] args)
		{
			if (args.Length == 1)
			{
				Texture.streamingTextureDiscardUnusedMips = args[0].Bool;
			}
			else
			{
				Terminal.Log($"Texture.streamingTextureDiscardUnusedMips = {Texture.streamingTextureDiscardUnusedMips}");
			}
		}

		[RegisterCommand("Texture.streamingTextureForceLoadAll", Help = "Force streaming Textures to load all mipmap levels.", MinArgCount = 0, MaxArgCount = 1)]
		private static void Texture_streamingTextureForceLoadAll(CommandArg[] args)
		{
			if (args.Length == 1)
			{
				Texture.streamingTextureForceLoadAll = args[0].Bool;
			}
			else
			{
				Terminal.Log($"Texture.streamingTextureForceLoadAll = {Texture.streamingTextureForceLoadAll}");
			}
		}

		[RegisterCommand("Texture.streamingTextureLoadingCount", Help = "Number of streaming Textures with mipmaps currently loading.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Texture_streamingTextureLoadingCount(CommandArg[] args)
		{
			Terminal.Log($"Texture.streamingTextureLoadingCount = {Texture.streamingTextureLoadingCount}");
		}

		[RegisterCommand("Texture.streamingTexturePendingLoadCount", Help = "Number of streaming Textures with outstanding mipmaps to be loaded.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Texture_streamingTexturePendingLoadCount(CommandArg[] args)
		{
			Terminal.Log($"Texture.streamingTexturePendingLoadCount = {Texture.streamingTexturePendingLoadCount}");
		}

		[RegisterCommand("Texture.targetTextureMemory", Help = "The total amount of Texture memory that Unity allocates to the Textures in the scene after it applies the memory budget and finishes loading Textures. `targetTextureMemory`also takes mipmap streaming settings into account. This value only includes instances of Texture2D and CubeMap Textures. It does not include any other Texture types, or 2D and CubeMap Textures that Unity creates internally.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Texture_targetTextureMemory(CommandArg[] args)
		{
			Terminal.Log($"Texture.targetTextureMemory = {Texture.targetTextureMemory}");
		}

		[RegisterCommand("Texture.totalTextureMemory", Help = "The total amount of Texture memory that Unity would use if it loads all Textures at mipmap level 0.This is a theoretical value that does not take into account any input from the streaming system or any other input, for example when you set the`Texture2D.requestedMipmapLevel` manually.To see a Texture memory value that takes inputs into account, use `desiredTextureMemory`.`totalTextureMemory` only includes instances of Texture2D and CubeMap Textures. It does not include any other Texture types, or 2D and CubeMap Textures that Unity creates internally.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Texture_totalTextureMemory(CommandArg[] args)
		{
			Terminal.Log($"Texture.totalTextureMemory = {Texture.totalTextureMemory}");
		}

		[RegisterCommand("Graphics.TerrainLightingQuality", Help = "Set terrain lighting  quality (0, 1, 2)")]
		private static void Graphics_TerrainLightingQuality(CommandArg[] args)
		{
			if (SingletonBehaviour<ShadowTracer>.Instance == null)
			{
				Terminal.Log("No ShadowTracer component in current scene, nothing to do.");
			}
			else if (args.Length == 0)
			{
				GraphicsOptions.TerrainLightingQuality terrainLightingQualityLevel = SingletonBehaviour<GraphicsOptions>.Instance.TerrainLightingQualityLevel;
				Terminal.Log(string.Concat("Current terrain lighting quality level: ", terrainLightingQualityLevel, " (", (int)terrainLightingQualityLevel, ")"));
			}
			else if (args.Length == 1)
			{
				int num = -1;
				if (args[0].String == "0" || args[0].String.ToLower() == GraphicsOptions.TerrainLightingQuality.LOW.ToString().ToLower())
				{
					num = 0;
				}
				else if (args[0].Int == 1 || args[0].String.ToLower() == GraphicsOptions.TerrainLightingQuality.MEDIUM.ToString().ToLower())
				{
					num = 1;
				}
				else if (args[0].Int == 2 || args[0].String.ToLower() == GraphicsOptions.TerrainLightingQuality.HIGH.ToString().ToLower())
				{
					num = 2;
				}
				if (num >= 0)
				{
					GamePreferences.Set(Preferences.TerrainLightingQualityIndex, num);
					GraphicsOptions.TerrainLightingQuality terrainLightingQualityLevel2 = SingletonBehaviour<GraphicsOptions>.Instance.TerrainLightingQualityLevel;
					Terminal.Log(string.Concat("Current terrain lighting quality level: ", terrainLightingQualityLevel2, " (", (int)terrainLightingQualityLevel2, ")"));
				}
				else
				{
					Terminal.Log("Invalid terrain lighting quality level: " + args[0].String);
				}
			}
			else
			{
				Terminal.Log("Too many arguments, use none to get current state, or use one to set state");
			}
		}

		[RegisterCommand("Graphics.DeferredDecals", Help = "Enable or disable deferred decals renderer (0, 1)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Graphics_DeferredDecals(CommandArg[] args)
		{
			if (args.Length == 0)
			{
				Terminal.Log("Current value: " + (SingletonBehaviour<DeferredDecalRenderer>.Instance.enabled ? "enabled" : "disabled"));
				return;
			}
			SingletonBehaviour<DeferredDecalRenderer>.Instance.enabled = args[0].Int > 0;
			Terminal.Log("DeferredDecalRenderer is now " + (SingletonBehaviour<DeferredDecalRenderer>.Instance.enabled ? "enabled" : "disabled"));
		}

		[RegisterCommand("Debug.ToggleCouplingHoseDebugGUI", Help = "Enable/disable coupling hoses debug stats", MinArgCount = 0, MaxArgCount = 0)]
		public static void Debug_ToggleCouplingHoseDebugGUI(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				if (hosesGUI == null)
				{
					hosesGUI = SingletonBehaviour<CouplingHoseDebugGUI>.Instance;
				}
				else
				{
					hosesGUI.gameObject.SetActive(!hosesGUI.gameObject.activeSelf);
				}
			}
		}

		[RegisterCommand(null, Name = "Lang.Dirs", Help = "Prints all dirs specified in LocalizationLoader.LocalizationDirs", MinArgCount = 0, MaxArgCount = 0)]
		public static void Lang_Dirs(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			foreach (string localizationDir in LocalizationLoader.LocalizationDirs)
			{
				Terminal.Log(localizationDir);
			}
		}

		[RegisterCommand(null, Name = "Lang.Fetch", Help = "Downloads localization CSVs from all URLs defined in 'sources.json' files,which are looked for in dirs specified in LocalizationLoader.LocalizationDirs\nThe format of JSON content is { 'filename.csv': 'https://url/to.csv', 'another.csv': 'https://...' }", MinArgCount = 0, MaxArgCount = 0)]
		public static void Lang_Fetch(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				Terminal.Log("\nRun Lang.Reload after this command finishes to apply changes\n");
				LocalizationCSVFetcher.DownloadLocalizationCSVs();
			}
		}

		[RegisterCommand("Lang.Reload", Help = "Reloads localization .csv files and loads current scene again", MinArgCount = 0, MaxArgCount = 0)]
		private static void Lang_Reload(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				SceneSwitcher.ReloadCurrentScene(reloadLocalization: true);
			}
		}

		[RegisterCommand("Lang.Set", Help = "Change localization to given language name. If a second argument is passed (any value) it will also do Lang.Reload", MinArgCount = 0, MaxArgCount = 2)]
		private static void Lang_Set(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			if (args.Length == 0)
			{
				Terminal.Log("Current language: " + LocalizationManager.CurrentLanguage);
				return;
			}
			LocalizationManager.CurrentLanguage = args[0].String;
			if (args.Length > 1)
			{
				SceneSwitcher.ReloadCurrentScene(reloadLocalization: true);
			}
		}

		[RegisterCommand("Lang.RunTestScene", Help = "Runs the localization test scene", MinArgCount = 0, MaxArgCount = 0)]
		private static void Lang_RunTestScene(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				SceneSwitcher.SwitchToScene(DVScenes.LocalizationTest);
			}
		}

		[RegisterCommand("Debug.RestartScene", Help = "Restarts the current scene", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_RestartScene(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				SceneSwitcher.ReloadCurrentScene();
			}
		}

		[RegisterCommand("Debug.ReturnToMainMenu", Help = "Loads the main menu scene", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_ReturnToMainMenu(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				SceneSwitcher.SwitchToScene(DVScenes.MainMenu);
			}
		}

		[RegisterCommand("Physics.Toggle", Help = "Enable/disable physics", MinArgCount = 0, MaxArgCount = 0)]
		private static void Physics_Toggle(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				Physics.autoSimulation = !Physics.autoSimulation;
				Terminal.Log("Physics is now " + (Physics.autoSimulation ? "enabled" : "disabled"));
			}
		}

		[RegisterCommand("Debug.NumCars", Help = "Prints number of train cars in the world", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_NumCars(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				Terminal.Log(string.Concat(UnityEngine.Object.FindObjectsOfType<TrainCar>().Length));
			}
		}

		[RegisterCommand("Debug.ToggleTrackIndicators", Help = "Enable/disable track ID indicators above station tracks", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_ToggleTrackIndicators(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			RailTrack[] array = UnityEngine.Object.FindObjectsOfType<RailTrack>();
			for (int i = 0; i < array.Length; i++)
			{
				Transform transform = array[i].transform.Find("[track id]");
				if (transform != null)
				{
					if (!flag2)
					{
						flag = !transform.gameObject.activeInHierarchy;
						flag2 = true;
					}
					transform.gameObject.SetActive(flag);
				}
			}
			if (flag2)
			{
				Terminal.Log("Indicators above station tracks are now " + (flag ? "enabled" : "disabled"));
			}
			else
			{
				Terminal.Log("Couldn't find any tracks with indicators");
			}
		}

		[RegisterCommand("Debug.MaxJobsPerStation", Help = "Sets maximum number of procedural jobs created in stations", MinArgCount = 1, MaxArgCount = 1)]
		private static void Debug_MaxJobsPerStation(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			int num = args[0].Int;
			if (num >= 0)
			{
				StationController[] array = UnityEngine.Object.FindObjectsOfType<StationController>();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].proceduralJobsRuleset.jobsCapacity = num;
				}
			}
		}

		[RegisterCommand("Debug.DestroyBuggedObjects", Help = "Destroys objects that have NaN position, should fix short tele-grab", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_DestroyBuggedObjects(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			Transform[] array = UnityEngine.Object.FindObjectsOfType<Transform>();
			foreach (Transform transform in array)
			{
				if (float.IsNaN(transform.position.x) || float.IsNaN(transform.position.y) || float.IsNaN(transform.position.z))
				{
					Debug.Log("Destroying '" + transform.name + "'");
					UnityEngine.Object.Destroy(transform.gameObject);
				}
			}
		}

		[RegisterCommand("Debug.SleepAllItems", Help = "Force all items/props physics to sleep", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_SleepAllItems(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			ItemBase[] array = UnityEngine.Object.FindObjectsOfType<ItemBase>();
			foreach (ItemBase itemBase in array)
			{
				Rigidbody component = itemBase.GetComponent<Rigidbody>();
				if (!component)
				{
					Debug.Log("Object '" + itemBase.name + "' doesn't have rigidbody, skipping", itemBase);
				}
				else
				{
					component.Sleep();
				}
			}
		}

		[RegisterCommand("Debug.DestroyAllItems", Help = "Destroys all props/items (can be game-breaking)", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_DestroyAllItems(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				ItemBase[] array = UnityEngine.Object.FindObjectsOfType<ItemBase>();
				for (int i = 0; i < array.Length; i++)
				{
					UnityEngine.Object.Destroy(array[i].gameObject);
				}
			}
		}

		[RegisterCommand("Debug.DeleteCarsAndJobsSaveData", Help = "Deletes all existing cars, jobs and clears cars/jobs savegame data", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_DeleteCarsAndJobsSaveData(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				SingletonBehaviour<JobsManager>.Instance.AbandonAllJobs();
				SingletonBehaviour<JobSaveManager>.Instance.DeleteAllNonActiveJobChains();
				CarsSaveManager.DeleteAllExistingCars();
				SingletonBehaviour<SaveGameManager>.Instance.data.RemoveData(SaveGameKeys.Cars);
				SingletonBehaviour<SaveGameManager>.Instance.data.RemoveData("Unique_cars");
				SingletonBehaviour<SaveGameManager>.Instance.data.RemoveData(SaveGameKeys.Jobs);
			}
		}

		[RegisterCommand("Debug.TeleportToPoint", Help = "Teleports the player to a specific x,z coordinate on the map (value range 0-16384)", MinArgCount = 2, MaxArgCount = 2)]
		private static void Debug_TeleportToPoint(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			if (VRManager.IsVREnabled())
			{
				Terminal.Log("TeleportToPoint is a Non-VR specific command. Aborting.");
				return;
			}
			if (!SingletonBehaviour<LevelInfo>.Instance)
			{
				Terminal.Log(TerminalLogType.Error, "Couldn't find level size. Aborting.");
				return;
			}
			Vector3 worldSize = SingletonBehaviour<LevelInfo>.Instance.worldSize;
			float x = Mathf.Clamp(args[0].Float, 0f, worldSize.x) / worldSize.x;
			float z = Mathf.Clamp(args[1].Float, 0f, worldSize.z) / worldSize.z;
			if (!Terminal.IssuedError)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Run(WorldTeleportTool.TeleportToNormalizedCoordinatesNonVR(x, z));
			}
		}

		[RegisterCommand("Debug.TeleportToPointNormalized", Help = "Teleports the player to a specific normalized x and normalized z coordinate on the map (value range 0-1)", MinArgCount = 2, MaxArgCount = 2)]
		private static void Debug_TeleportToPointNormalized(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			if (VRManager.IsVREnabled())
			{
				Terminal.Log("TeleportToPoint is a Non-VR specific command. Aborting.");
				return;
			}
			float x = Mathf.Clamp01(args[0].Float);
			float z = Mathf.Clamp01(args[1].Float);
			if (!Terminal.IssuedError)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Run(WorldTeleportTool.TeleportToNormalizedCoordinatesNonVR(x, z));
			}
		}

		[RegisterCommand("Debug.PrintPlayerPosition", Help = "Prints player's current coordinates in the world", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_PrintPlayerPosition(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			if (!PlayerManager.PlayerTransform)
			{
				Terminal.Log("Couldn't find player");
				return;
			}
			Vector3 vector = PlayerManager.PlayerTransform.AbsolutePosition();
			Terminal.Log($"Player position: x: {vector.x}, y: {vector.y}, z: {vector.z}");
			if (!SingletonBehaviour<LevelInfo>.Instance)
			{
				Terminal.Log(TerminalLogType.Warning, "Couldn't find level size, can't calculate normalized position.");
				return;
			}
			Vector3 worldSize = SingletonBehaviour<LevelInfo>.Instance.worldSize;
			Vector3 vector2 = new Vector3(vector.x / worldSize.x, 0f, vector.z / worldSize.z);
			Terminal.Log($"Player normalized position: x: {vector2.x}, z: {vector2.z}");
		}

		[RegisterCommand("Debug.TrainOptimizationStatus", Help = "Shows number of sleeping / awaken cars", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_TrainOptimizationStatus(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			TrainCar[] array = UnityEngine.Object.FindObjectsOfType<TrainCar>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].rb.IsSleeping())
				{
					num++;
				}
				else
				{
					num2++;
				}
			}
			Terminal.Log($"Sleeping cars: {num} | Awaken cars: {num2}");
		}

		[RegisterCommand("Debug.PrintLicenses", Help = "Prints all acquired licenses at this moment", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_PrintLicenses(CommandArg[] args)
		{
			Terminal.Log("General licenses: " + string.Join(", ", from l in SingletonBehaviour<LicenseManager>.Instance.GetGeneralAcquiredLicenses()
				select l.id));
			Terminal.Log("Job licenses: " + string.Join(", ", from l in SingletonBehaviour<LicenseManager>.Instance.GetAcquiredJobLicenses()
				select l.id));
			Terminal.Log("Garages licenses: " + string.Join(", ", from g in SingletonBehaviour<LicenseManager>.Instance.GetUnlockedGarages()
				select g.id));
		}

		[RegisterCommand("Debug.SetSunYRotation", Help = "Sets sun Y rotation (0 - 360)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Debug_SetSunYRotation(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			Light light = UnityEngine.Object.FindObjectsOfType<Light>().FirstOrDefault((Light light2) => light2.type == LightType.Directional && light2.name == "Directional Light");
			if ((bool)light)
			{
				if (args.Length == 0)
				{
					Terminal.Log($"Sun Y rotation: {light.transform.rotation.eulerAngles.y}");
					return;
				}
				Vector3 eulerAngles = light.transform.rotation.eulerAngles;
				eulerAngles.y = args[0].Float;
				light.transform.rotation = Quaternion.Euler(eulerAngles);
			}
			else
			{
				Terminal.Log(TerminalLogType.Error, "Can't find the sun!");
			}
		}

		[RegisterCommand("Debug.SetSunXRotation", Help = "Sets sun X rotation (0 - 360)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Debug_SetSunXRotation(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			Light light = UnityEngine.Object.FindObjectsOfType<Light>().FirstOrDefault((Light light2) => light2.type == LightType.Directional && light2.name == "Directional Light");
			if ((bool)light)
			{
				if (args.Length == 0)
				{
					Terminal.Log($"Sun X rotation: {light.transform.rotation.eulerAngles.x}");
					return;
				}
				Vector3 eulerAngles = light.transform.rotation.eulerAngles;
				eulerAngles.x = args[0].Float;
				light.transform.rotation = Quaternion.Euler(eulerAngles);
			}
			else
			{
				Terminal.Log(TerminalLogType.Error, "Can't find the sun!");
			}
		}

		[RegisterCommand("Debug.LoadingAlertsToggle", Help = "Toggles loading area and car spawning alerts ", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_LoadingAlertsToggle(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				InfoMessageSystem infoMessageSystem = UnityEngine.Object.FindObjectOfType<InfoMessageSystem>();
				if (infoMessageSystem != null)
				{
					infoMessageSystem.EnableLoadingAreaAndCarSpawningInfo(!infoMessageSystem.LoadingAlerts);
					Terminal.Log("Loading alerts " + (infoMessageSystem.LoadingAlerts ? "enabled" : "disabled") + "!");
				}
				else
				{
					Terminal.Log(TerminalLogType.Error, "No InfoMessageSystem found, ignoring request!");
				}
			}
		}

		[RegisterCommand("Debug.AutoSavingEnabled", Help = "Toggles auto-save", MinArgCount = 0, MaxArgCount = 1)]
		private static void Debug_AutoSavingEnabled(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				if (!SingletonBehaviour<SaveGameManager>.Instance)
				{
					Terminal.Log(TerminalLogType.Warning, "SaveGameManager is not present");
				}
				else if (args.Length == 0)
				{
					Terminal.Log("Auto-saving is " + (SingletonBehaviour<SaveGameManager>.Instance.disableAutosave ? "disabled" : "enabled"));
					Terminal.Log("Saving in general is " + (SingletonBehaviour<SaveGameManager>.Instance.SaveAllowed() ? "allowed" : "disallowed"));
				}
				else
				{
					SingletonBehaviour<SaveGameManager>.Instance.disableAutosave = args[0].Int <= 0;
					Terminal.Log("Auto-saving is now " + (SingletonBehaviour<SaveGameManager>.Instance.disableAutosave ? "disabled" : "enabled"));
				}
			}
		}

		[RegisterCommand("Debug.AutoSaveNow", Help = "Forces a auto-save", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_AutoSaveNow(CommandArg[] args)
		{
			_DoSave(SaveType.Auto);
		}

		[RegisterCommand("Debug.QuickSaveNow", Help = "Forces a quick-save", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_QuickSaveNow(CommandArg[] args)
		{
			_DoSave(SaveType.Quick);
		}

		[RegisterCommand("Debug.ManualSaveNow", Help = "Forces a manual save", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_ManualSaveNow(CommandArg[] args)
		{
			_DoSave(SaveType.Manual);
		}

		private static void _DoSave(SaveType saveType)
		{
			if (!Terminal.IssuedError)
			{
				if (!SingletonBehaviour<SaveGameManager>.Instance)
				{
					Terminal.Log(TerminalLogType.Warning, "SaveGameManager is not present");
				}
				else if (SingletonBehaviour<SaveGameManager>.Instance.Save(saveType) == null)
				{
					Terminal.Log(TerminalLogType.Warning, "Saving failed");
					Terminal.Log("Auto-saving is " + (SingletonBehaviour<SaveGameManager>.Instance.disableAutosave ? "disabled" : "enabled"));
					Terminal.Log("Saving in general is " + (SingletonBehaviour<SaveGameManager>.Instance.SaveAllowed() ? "allowed" : "disallowed"));
				}
			}
		}

		[RegisterCommand("Debug.ErrorPingToggle", Help = "Toggles playing of error sound", MinArgCount = 0, MaxArgCount = 1)]
		private static void Debug_ErrorPingToggle(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				bool flag = (ErrorSoundLogHandler.SoundEnabled = ((args.Length == 0) ? (!ErrorSoundLogHandler.SoundEnabled) : (args[0].Int > 0)));
				Terminal.Log("Error pings are now " + (flag ? "enabled" : "disabled"));
			}
		}

		[RegisterCommand("Debug.NumberOfCarsPerCarType", Help = "Lists number of cars per each car type", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_NumberOfCarsPerCarType(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			Dictionary<TrainCarType, int> dictionary = new Dictionary<TrainCarType, int>();
			foreach (TrainCar allCar in SingletonBehaviour<CarSpawner>.Instance.AllCars)
			{
				if (dictionary.ContainsKey(allCar.carType))
				{
					dictionary[allCar.carType] = dictionary[allCar.carType] + 1;
				}
				else
				{
					dictionary[allCar.carType] = 1;
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			TrainCarType[] array = Enum.GetValues(typeof(TrainCarType)).Cast<TrainCarType>().Skip(1)
				.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				TrainCarType key = array[i];
				int value = 0;
				dictionary.TryGetValue(key, out value);
				stringBuilder.AppendLine($"{key.ToString()}: {value}");
			}
			Debug.Log(stringBuilder.ToString());
		}

		[RegisterCommand("Debug.UnloadUnusedAssetsToggle", Help = "Toggles freeing up memory when loading new area (frees up more RAM, but causes stutter)", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_UnloadUnusedAssetsToggle(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				Streamer.unloadUnusedAssetsEnabled = !Streamer.unloadUnusedAssetsEnabled;
				Terminal.Log("Automatic unloading is now " + (Streamer.unloadUnusedAssetsEnabled ? "enabled" : "disabled"));
			}
		}

		[RegisterCommand("Debug.ForceUnloadUnusedAssets", Help = "Calls Resources.UnloadUnusedAssets() method.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_ForceUnloadUnusedAssets(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				Debug.Log("Calling Resources.UnloadUnusedAssets() via console command.");
				Resources.UnloadUnusedAssets();
			}
		}

		[RegisterCommand("Debug.GCCollect", Help = "Calls GC.Collect() method.", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_GCCollect(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				Debug.Log("Calling GC.Collect() via console command.");
				GC.Collect();
			}
		}

		[RegisterCommand("Debug.GCCollectIncremental", Help = "Calls GarbageCollector.CollectIncremental() method with desired duration (in ms).", MinArgCount = 1, MaxArgCount = 1)]
		private static void Debug_GCCollectIncremental(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				ulong num = (ulong)(args[0].Float * 1000000f);
				Debug.Log($"Calling GarbageCollector.CollectIncremental({num}) via console command.");
				GarbageCollector.CollectIncremental(num);
			}
		}

		[RegisterCommand("Debug.Telemetry", Help = "Record in-game train car telemetry that will be saved to disk when derailing, for later analysis.", MinArgCount = 0, MaxArgCount = 1)]
		private static void Debug_EnableTelemetry(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				if (args.Length != 0)
				{
					bool flag = args[0].Bool;
					Debug.Log(string.Format("Setting {0} to ({1}) via console command.", "TelemetryEnabled", flag));
					GamePreferences.Set(Preferences.TelemetryEnabled, flag);
				}
				else
				{
					Debug.Log("TelemetryEnabled is currently " + (SingletonBehaviour<TelemetryCentral>.Instance.enabled ? "ENABLED" : "DISABLED") + " (use true/false argument to change state)");
				}
			}
		}

		[RegisterCommand("Debug.SaveTelemetry", Help = "Save current telemetry data, with an optional string prefix for easier identification. Look for new files in app data folder afterwards.", MinArgCount = 0, MaxArgCount = 1)]
		private static void Debug_SaveTelemetry(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				if (!SingletonBehaviour<TelemetryCentral>.Instance.enabled)
				{
					Debug.LogWarning("Telemetry is NOT currently enabled, results might be empty if you haven't done some recording previously in this session.");
				}
				string prefix = ((args.Length != 0) ? (args[0].String + "_") : "");
				SingletonBehaviour<TelemetryCentral>.Instance.SaveAll(prefix);
				Debug.Log($"Saving telemetry for {SingletonBehaviour<TelemetryCentral>.Instance.RecorderCount} tracked objects...");
				SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(Telemetry_SavingTracker());
			}
		}

		private static IEnumerator Telemetry_SavingTracker()
		{
			while (TelemetrySavingTracker.AnyPendingSaves)
			{
				yield return null;
			}
			Debug.Log("Telemetry saving done.");
		}

		[RegisterCommand("Debug.InventoryEventDebug", Help = "Enables logging of inventory event debug", MinArgCount = 0, MaxArgCount = 0)]
		private static void Debug_InventoryEventDebug(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			if (SingletonBehaviour<Inventory>.Instance == null)
			{
				Terminal.Log("Inventory not found, doing nothing");
				return;
			}
			GameObject gameObject = SingletonBehaviour<Inventory>.Instance.gameObject;
			InventoryEventDebugLogger component = gameObject.GetComponent<InventoryEventDebugLogger>();
			if (component != null)
			{
				component.enabled = !component.enabled;
			}
			else
			{
				gameObject.AddComponent<InventoryEventDebugLogger>();
			}
		}

		[RegisterCommand("Debug.SetBrakeConst", MinArgCount = 2, MaxArgCount = 2)]
		private static void Debug_SetBrakeConst(CommandArg[] args)
		{
			BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
			string text = args[0].String;
			float num = args[1].Float;
			FieldInfo field = typeof(BrakeSystemConsts).GetField(text + "_EQ_SPEED_MULTIPLIER", bindingAttr);
			if (field == null)
			{
				field = typeof(BrakeSystemConsts).GetField(text, bindingAttr);
			}
			if (field == null)
			{
				Terminal.Log("no such brake const found");
				return;
			}
			object value = field.GetValue(null);
			field.SetValue(null, num);
			Terminal.Log($"Set {text} {value}->{num}");
		}

		[RegisterCommand("Debug.ToggleRunInBackgroundWhilePaused", MinArgCount = 0, MaxArgCount = 1)]
		private static void Debug_ToggleRunInBackgroundWhilePaused(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				SingletonBehaviour<GraphicsOptions>.Instance.RunInBackgroundWhilePaused = ((args.Length != 0) ? args[0].Bool : (!SingletonBehaviour<GraphicsOptions>.Instance.RunInBackgroundWhilePaused));
				Terminal.Log((SingletonBehaviour<GraphicsOptions>.Instance.RunInBackgroundWhilePaused ? "Enabled" : "Disabled") + " running in background while paused.");
			}
		}

		private static bool OculusCheck()
		{
			if (Terminal.IssuedError)
			{
				return false;
			}
			if (!VRManager.IsVREnabled())
			{
				Terminal.Log("This is a VR-only command");
				return false;
			}
			if (!VRTK_SDKManager.GetLoadedSDKSetup().name.ToLower().Contains("oculus"))
			{
				Terminal.Log("This command is specific to Oculus SDK, which is not currently in use");
				return false;
			}
			return true;
		}

		[RegisterCommand("Oculus.RenderScale", Help = "View/set Oculus SDK render scale min & max values (float [, float])", MinArgCount = 0, MaxArgCount = 2)]
		private static void Oculus_RenderScale(CommandArg[] args)
		{
			if (OculusCheck())
			{
				if (args.Length == 0)
				{
					Terminal.Log($"Current values: {OVRManager.instance.minRenderScale}, {OVRManager.instance.maxRenderScale}");
				}
				else if (args.Length == 1)
				{
					float maxRenderScale = Mathf.Clamp(args[0].Float, 0.5f, 4f);
					OVRManager.instance.minRenderScale = (OVRManager.instance.maxRenderScale = maxRenderScale);
					Terminal.Log($"Set both minimum & maximum to: {OVRManager.instance.minRenderScale}");
				}
				else if (args.Length == 2)
				{
					float num = Mathf.Clamp(args[0].Float, 0.5f, 4f);
					float maxRenderScale2 = Mathf.Clamp(args[1].Float, num, 4f);
					OVRManager.instance.minRenderScale = num;
					OVRManager.instance.maxRenderScale = maxRenderScale2;
					Terminal.Log($"Set to: {OVRManager.instance.minRenderScale}, {OVRManager.instance.maxRenderScale}");
				}
				else
				{
					Terminal.Log("Command requires 1 or 2 float values");
				}
			}
		}

		[RegisterCommand("Player.MoveToLastGoodPosition", Help = "Moves player to where it was last in contact with the terrain", MinArgCount = 0, MaxArgCount = 0)]
		private static void Player_MoveToLastGoodPosition(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				FallThroughTerrainFix fallThroughTerrainFix = UnityEngine.Object.FindObjectOfType<FallThroughTerrainFix>();
				if (!fallThroughTerrainFix)
				{
					Terminal.Log(TerminalLogType.Error, "Couldn't find last good position.");
				}
				else
				{
					fallThroughTerrainFix.MoveToLastGoodPosition();
				}
			}
		}

		[RegisterCommand("Player.FOV", Help = "Sets camera field of view. Default is 50, valid range is 30-120.", MinArgCount = 1, MaxArgCount = 1)]
		private static void Player_FOV(CommandArg[] args)
		{
			if (Terminal.IssuedError)
			{
				return;
			}
			if (VRManager.IsVREnabled())
			{
				Terminal.Log("Field of view option is unavailable in VR.");
				return;
			}
			float value = args[0].Float;
			if (!Terminal.IssuedError)
			{
				if (PlayerManager.PlayerCamera.GetComponent<CameraZoom>() == null)
				{
					Terminal.Log("CameraZoom not found. Field of view change skipped.");
				}
				else
				{
					GamePreferences.Set(Preferences.FieldOfView, value);
				}
			}
		}

		[RegisterCommand("ScreenshotTaker.Enable", Help = "Enable screenshot taker tool", MinArgCount = 0, MaxArgCount = 0)]
		private static void ScreenshotTaker_Enable(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				ScreenshotTaker instance = SingletonBehaviour<ScreenshotTaker>.Instance;
				Terminal.Log($"Press {instance.captureKey} to take screenshots - current Supersize value is {instance.superSize}");
			}
		}

		[RegisterCommand("ScreenshotTaker.Supersize", Help = "Resolution multiplier", MinArgCount = 0, MaxArgCount = 1)]
		private static void ScreenshotTaker_Supersize(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				ScreenshotTaker instance = SingletonBehaviour<ScreenshotTaker>.Instance;
				if (args.Length == 0)
				{
					Terminal.Log($"Current value: {instance.superSize}");
				}
				else
				{
					instance.superSize = args[0].Int;
				}
			}
		}

		private static VegetationSystemPro FindVS()
		{
			VegetationSystemPro vegetationSystemPro = UnityEngine.Object.FindObjectOfType<VegetationSystemPro>();
			if (vegetationSystemPro == null)
			{
				Terminal.Log("Vegetation not present in the scene");
			}
			return vegetationSystemPro;
		}

		private static void Vegetation_Handle(string fieldName, CommandArg[] args, FieldType fieldType)
		{
			VegetationSystemPro vegetationSystemPro = FindVS();
			if (!vegetationSystemPro)
			{
				return;
			}
			FieldInfo field = typeof(VegetationSettings).GetField(fieldName);
			if (args.Length == 0)
			{
				Terminal.Log("Current value: " + field.GetValue(vegetationSystemPro.VegetationSettings));
			}
			else if (!Terminal.IssuedError)
			{
				switch (fieldType)
				{
				case FieldType.Bool:
					field.SetValue(vegetationSystemPro.VegetationSettings, args[0].Int > 0);
					break;
				case FieldType.Float:
					field.SetValue(vegetationSystemPro.VegetationSettings, args[0].Float);
					break;
				default:
					Terminal.Log(TerminalLogType.Error, "Unknown field type " + fieldType);
					break;
				}
				Terminal.Log("Value is now: " + field.GetValue(vegetationSystemPro.VegetationSettings));
			}
		}

		[RegisterCommand("Veg.Toggle", Help = "Enables/disables vegetation (re-enabling might not work yet)")]
		private static void Vegetation_Toggle(CommandArg[] args)
		{
			VegetationSystemPro vegetationSystemPro = FindVS();
			if ((bool)vegetationSystemPro)
			{
				vegetationSystemPro.enabled = !vegetationSystemPro.enabled;
				Terminal.Log("Vegetation " + (vegetationSystemPro.enabled ? "enabled" : "disabled"));
			}
		}

		[RegisterCommand("Veg.LodFactor", Help = "LOD factor (0-5)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_LodFactor(CommandArg[] args)
		{
			Vegetation_Handle("LODDistanceFactor", args, FieldType.Float);
		}

		[RegisterCommand("Veg.Distance.Grass", Help = "Grass & small plant distance (0-800)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Distance_Grass(CommandArg[] args)
		{
			Vegetation_Handle("PlantDistance", args, FieldType.Float);
		}

		[RegisterCommand("Veg.Distance.Tree", Help = "Additional tree distance (0-3000)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Distance_Tree(CommandArg[] args)
		{
			Vegetation_Handle("AdditionalTreeMeshDistance", args, FieldType.Float);
		}

		[RegisterCommand("Veg.Distance.Billboard", Help = "Additional billboard distance (0-20000)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Distance_Billboard(CommandArg[] args)
		{
			Vegetation_Handle("AdditionalBillboardDistance", args, FieldType.Float);
		}

		[RegisterCommand("Veg.Density.Grass", Help = "Grass density (0-2)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Density_Grass(CommandArg[] args)
		{
			Vegetation_Handle("GrassDensity", args, FieldType.Float);
		}

		[RegisterCommand("Veg.Density.Plant", Help = "Small plant density (0-2)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Density_Plant(CommandArg[] args)
		{
			Vegetation_Handle("PlantDensity", args, FieldType.Float);
		}

		[RegisterCommand("Veg.Density.Tree", Help = "Tree density (0-2)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Density_Tree(CommandArg[] args)
		{
			Vegetation_Handle("TreeDensity", args, FieldType.Float);
		}

		[RegisterCommand("Veg.Density.Object", Help = "Object density (0-2)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Density_Object(CommandArg[] args)
		{
			Vegetation_Handle("ObjectDensity", args, FieldType.Float);
		}

		[RegisterCommand("Veg.Density.LargeObject", Help = "Large object density (0-2)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Density_LargeObject(CommandArg[] args)
		{
			Vegetation_Handle("LargeObjectDensity", args, FieldType.Float);
		}

		[RegisterCommand("Veg.Shadows.Grass", Help = "Grass shadows (bool)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Shadows_Grass(CommandArg[] args)
		{
			Vegetation_Handle("GrassShadows", args, FieldType.Bool);
		}

		[RegisterCommand("Veg.Shadows.Plant", Help = "Small plant shadows (bool)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Shadows_Plant(CommandArg[] args)
		{
			Vegetation_Handle("PlantShadows", args, FieldType.Bool);
		}

		[RegisterCommand("Veg.Shadows.Tree", Help = "Tree shadows (bool)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Shadows_Tree(CommandArg[] args)
		{
			Vegetation_Handle("TreeShadows", args, FieldType.Bool);
		}

		[RegisterCommand("Veg.Shadows.Object", Help = "Object shadows (bool)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Shadows_Object(CommandArg[] args)
		{
			Vegetation_Handle("ObjectShadows", args, FieldType.Bool);
		}

		[RegisterCommand("Veg.Shadows.LargeObject", Help = "Large object shadows (bool)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Shadows_LargeObject(CommandArg[] args)
		{
			Vegetation_Handle("LargeObjectShadows", args, FieldType.Bool);
		}

		[RegisterCommand("Veg.Shadows.Billboard", Help = "Billboard shadows (bool)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Shadows_Billboard(CommandArg[] args)
		{
			Vegetation_Handle("BillboardShadows", args, FieldType.Bool);
		}

		[RegisterCommand("Veg.Debug.WaitFrames", Help = "Number of frames to wait between (un)loading terrain tiles (int)", MinArgCount = 0, MaxArgCount = 1)]
		private static void Vegetation_Debug_WaitFrames(CommandArg[] args)
		{
			TerrainGrid terrainGrid = UnityEngine.Object.FindObjectOfType<TerrainGrid>();
			if (terrainGrid == null)
			{
				Terminal.Log(TerminalLogType.Warning, "TerrainGrid component not found");
				return;
			}
			if (args.Length == 0)
			{
				Terminal.Log("Current value: " + terrainGrid.vegetationReloadWaitFrames);
				return;
			}
			int value = args[0].Int;
			if (!Terminal.IssuedError)
			{
				terrainGrid.vegetationReloadWaitFrames = Mathf.Clamp(value, 0, 1000);
			}
		}

		[RegisterCommand("Veg.Debug.RefreshVegetation", Help = "Refreshes Vegetation", MaxArgCount = 0, MinArgCount = 0)]
		private static void Vegetation_Debug_RefreshVegetation(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				VegetationSystemPro vegetationSystemPro = FindVS();
				if ((bool)vegetationSystemPro)
				{
					vegetationSystemPro.ClearCache();
					vegetationSystemPro.RefreshTerrainHeightmap();
				}
			}
		}

		[RegisterCommand("Veg.Debug.RefreshVegetationLocal", Help = "Refreshes vegetation cells within a given range around the player. Uses range of 20m if no argument is passed", MaxArgCount = 1, MinArgCount = 0)]
		private static void Vegetation_Debug_RefreshVegetationLocal(CommandArg[] args)
		{
			if (!Terminal.IssuedError)
			{
				VegetationSystemPro vegetationSystemPro = FindVS();
				if ((bool)vegetationSystemPro)
				{
					float num = ((args.Length == 0) ? 20f : args[0].Float);
					Vector3 center = PlayerManager.PlayerTransform.AbsolutePosition();
					Bounds bounds = new Bounds(center, new Vector3(num, num, num));
					vegetationSystemPro.ClearCache(bounds);
					vegetationSystemPro.RefreshTerrainHeightmap();
				}
			}
		}
	}
}
