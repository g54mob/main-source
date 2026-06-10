using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using I2.Loc;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Model.SecondMap;
using NSMedieval.Production;
using NSMedieval.Repository;
using NSMedieval.RoomDetection;
using NSMedieval.Scripts.Pooler;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools.Debug;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water.DebugUI;
using NSMedieval.Weather;
using NSMedieval.WorldMap;
using Repository.Map;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils;

namespace NSMedieval.DevConsole
{
	public class DeveloperPanelView : DeveloperView
	{
		[SerializeField]
		private GameObject contentParent;

		[SerializeField]
		private GameObject buttonPrefab;

		[SerializeField]
		private GameObject submenuButtonPrefab;

		[SerializeField]
		private GameObject toggleButtonPrefab;

		[SerializeField]
		private GameObject dropdownPrefab;

		[SerializeField]
		private GameObject subgroupPrefab;

		[SerializeField]
		private GameObject spacerPrefab;

		[SerializeField]
		private InputField searchInputField;

		[SerializeField]
		private DeveloperActionButton refreshSearchButton;

		private List<GameObject> menuItems = new List<GameObject>();

		private List<GameObject> subgroups = new List<GameObject>();

		private List<KeyValuePair<string, DeveloperActionButton>> buttons = new List<KeyValuePair<string, DeveloperActionButton>>();

		private List<KeyValuePair<string, DeveloperToggle>> toggles = new List<KeyValuePair<string, DeveloperToggle>>();

		private Action backAction;

		private NSMedieval.Model.Raid customRaid;

		private int gender;

		public override void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
		}

		public override void SetupPanel(DeveloperPanelCategory category)
		{
			if (category == DeveloperPanelCategory.Actions)
			{
				Reset();
			}
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanelEvent += Reset;
		}

		public override void Reset()
		{
			buttons.Clear();
			toggles.Clear();
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanelEvent -= Reset;
			FlushMenuItems(delegate
			{
				SetupActionsPanel(delegate
				{
					ReparentMenuItems();
				});
			});
			BackButtonAction(null);
		}

		private void OnEnable()
		{
			InitDebugSingletons();
			if (MonoSingleton<DeveloperToolsView>.Instance.RefreshPanel)
			{
				MonoSingleton<DeveloperToolsView>.Instance.RefreshPanel = false;
				Reset();
			}
		}

		private void InitDebugSingletons()
		{
			if (!MonoSingleton<RegionDebugger>.IsInstantiated())
			{
				MonoSingleton<RegionDebugger>.DevForceInstantiate();
			}
			if (!MonoSingleton<DevVoxelInfoController>.IsInstantiated())
			{
				MonoSingleton<DevVoxelInfoController>.DevForceInstantiate();
			}
			if (!MonoSingleton<MapNodeDebugManager>.IsInstantiated())
			{
				MonoSingleton<MapNodeDebugManager>.DevForceInstantiate();
			}
			if (!MonoSingleton<MapPathDebugManager>.IsInstantiated())
			{
				MonoSingleton<MapPathDebugManager>.DevForceInstantiate();
			}
		}

		private void SetupActionsPanel(Action callback)
		{
			VisualDebugManager instance = MonoSingleton<VisualDebugManager>.Instance;
			AddSubgroup("dev_buildings");
			AddToggle("dev_autoconstruct_" + CommandArgument("autoconstruct"), "autoconstruct", "dev_tooltip_autoconstruct").onClick.AddListener(Autoconstruct);
			AddToggle("dev_unlock_all_variants_" + CommandArgument("unlockAllVariants"), "dev_tooltip_unlock_all_variants").onClick.AddListener(UnlockAllVariants);
			AddToggle("dev_spawn_materials_with_building_" + CommandArgument("spawnMaterialsWithBuilding"), "dev_tooltip_spawn_materials_with_building").onClick.AddListener(SpawnMaterialsWithBuilding);
			AddToggle("dev_craftable_buildings_enabled_" + CommandArgument("craftableBuildingsEnabled"), "dev_tooltip_craftable_buildings_enabled").onClick.AddListener(CraftableBuildingsEnabled);
			AddButton("dev_switchFactionOwnership", "switchFactionOwnership", "dev_tooltip_switchFactionOwnership").onClick.AddListener(SwitchFactionOwnership);
			AddButton("dev_convertAllBuildingsToEnemyOwned", "convertAllBuildingsToEnemyOwned", "dev_tooltip_convertAllBuildingsToEnemyOwned").onClick.AddListener(ConvertAllBuildingsToEnemyOwned);
			AddToggle("dev_allowEdgePlacement_" + CommandArgument("toggleAllowEdgePlacement"), "toggleAllowEdgePlacement", "dev_tooltip_allowEdgePlacement").onClick.AddListener(AllowEdgePlacement);
			AddToggle("dev_unlock_all_room_types", "unlockRoomType", "dev_tooltip_unlock_all_room_types", startingValue: false, (from rt in Repository<RoomTypeRepository, RoomType>.Instance.GetAllItems()
				where rt.Locked
				select rt.GetID()).Any()).onClick.AddListener(UnlockAllRoomTypes);
			AddSubgroup("dev_research");
			AddToggle("dev_activateAllResearch_" + CommandArgument("activateAllResearch"), "activateAllResearch", "dev_tooltip_activate_all_research", CommandArgument("activateAllResearch") == "on").onClick.AddListener(ActivateAllResearch);
			AddSubgroup("dev_production");
			AddToggle("dev_production_speed_normal", "productionSpeed", "dev_tooltip_production_speed_max", MonoSingleton<ProductionManager>.Instance.GlobalSpeedMultiplier > 1f).onClick.AddListener(delegate
			{
				ToggleProductionSpeed();
			});
			AddSubgroup("dev_camera");
			AddToggle("dev_marketing_mode", "marketingMode", "dev_tooltip_marketing_mode", CommandArgument("marketingMode") == "on").onClick.AddListener(MarketingMode);
			AddToggle("dev_toggle_tooltips_" + CommandArgument("toggleTooltips"), "toggleTooltips", "dev_tooltip_toggle_tooltips", CommandArgument("toggleTooltips") == "on").onClick.AddListener(ToggleTooltips);
			AddToggle("dev_toggle_ui_" + CommandArgument("toggleUI"), "toggleUi", "dev_tooltip_toggle_ui", !(CommandArgument("toggleUI") == "on")).onClick.AddListener(ToggleUI);
			AddSubgroup("dev_piles");
			AddButton("dev_spawn_resource", "spawnResource", "dev_tooltip_spawn_resource", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupResourcePanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_spawn_resource_ctg", "spawnResourceCtg", "dev_tooltip_spawn_resource_ctg", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupResourceCtgPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_spawn_item", "spawnItem", "dev_tooltip_spawn_item", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupItemsPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_destroy_pile", "destroyPile", "dev_tooltip_destroy_pile").onClick.AddListener(DestroyResourcePile);
			AddButton("dev_kill_all_piles", "killPiles", "dev_tooltip_kill_piles").onClick.AddListener(KillAllPiles);
			AddButton("dev_recount_piles", "recountPiles", "dev_tooltip_recount_piles").onClick.AddListener(RecountPiles);
			AddButton("dev_recount_haul_piles", "recountPiles", "dev_tooltip_recount_haul_piles").onClick.AddListener(RecountHaulPiles);
			AddButton("dev_set_freshness_100", "setFreshness", "dev_tooltip_set_freshness_100").onClick.AddListener(delegate
			{
				SetFreshness(100f);
			});
			AddButton("dev_set_freshness_1", "setFreshness", "dev_tooltip_set_freshness_1").onClick.AddListener(delegate
			{
				SetFreshness(1f);
			});
			AddButton("dev_set_freshness_0", "setFreshness", "dev_tooltip_set_freshness_0").onClick.AddListener(delegate
			{
				SetFreshness(0f);
			});
			AddButton("dev_fill_storage", "fillStorage", "dev_tooltip_fill_storage").onClick.AddListener(delegate
			{
				FillStorage();
			});
			AddSubgroup("dev_workers");
			AddButton("dev_spawn_worker_1", "spawnWorker", "dev_tooltip_spawn_worker_1").onClick.AddListener(delegate
			{
				SpawnWorker(1);
			});
			AddButton("dev_spawn_worker_10", "spawnWorker", "dev_tooltip_spawn_worker_10").onClick.AddListener(delegate
			{
				SpawnWorker(10);
			});
			AddButton("dev_remove_worker", "removeWorker", "dev_tooltip_remove_worker").onClick.AddListener(delegate
			{
				RemoveWorker();
			});
			AddButton("dev_wound_worker", "woundWorker", "dev_tooltip_wound_worker").onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					WoundWorker(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_toggle_invurnelability", "toggleInvulnerability", "dev_tooltip_toggle_invurnelability").onClick.AddListener(delegate
			{
				ToggleInvurnelability();
			});
			AddToggle("dev_toggle_invurnelability_" + CommandArgument("toggleInvulnerability"), "toggleInvulnerability", "dev_tooltip_toggle_Invulnerability_all", CommandArgument("toggleInvulnerability") == "on").onClick.AddListener(ToggleAllSettlerInvurnelability);
			AddButton("dev_ladder_falldown", "ladder_falldown", "dev_tooltip_ladder_falldown").onClick.AddListener(delegate
			{
				LadderFalldown();
			});
			AddButton("dev_kill_all_workers_but_one", "killAllWorkersButOne", "dev_tooltip_kill_all_workers_but_one").onClick.AddListener(KillAllWorkersButOne);
			AddButton("dev_reset_workers", "resetWorkers", "dev_tooltip_reset_workers").onClick.AddListener(delegate
			{
				ResetWorkers();
			});
			AddButton("dev_set_mood_plus_10", "moodPlus", "dev_tooltip_mood_plus").onClick.AddListener(delegate
			{
				SetWorkerMood(10);
			});
			AddButton("dev_set_mood_minus_10", "moodMinus", "dev_tooltip_mood_minus").onClick.AddListener(delegate
			{
				SetWorkerMood(-10);
			});
			AddButton("dev_add_xp_to_skill", "addSkill", "dev_tooltip_add_xp_to_skill", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupSkillsPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddSubgroup("dev_health");
			AddButton("dev_set_health_100", "setHealth", "dev_tooltip_set_health_100").onClick.AddListener(delegate
			{
				SetHealth(100f);
			});
			AddButton("dev_set_health_1", "setHealth", "dev_tooltip_set_health_1").onClick.AddListener(delegate
			{
				SetHealth(1f);
			});
			AddButton("dev_set_health_0", "setHealth", "dev_tooltip_set_health_0").onClick.AddListener(delegate
			{
				SetHealth(0f);
			});
			AddSubgroup("dev_hunger");
			AddButton("dev_set_worker_hunger_100", "setHunger", "dev_tooltip_set_hunger_100").onClick.AddListener(delegate
			{
				SetWorkerHunger(100f);
			});
			AddButton("dev_set_worker_hunger_50", "setHunger", "dev_tooltip_set_hunger_50").onClick.AddListener(delegate
			{
				SetWorkerHunger(50f);
			});
			AddButton("dev_set_worker_hunger_1", "setHunger", "dev_tooltip_set_hunger_1").onClick.AddListener(delegate
			{
				SetWorkerHunger(1f);
			});
			AddButton("dev_set_worker_hunger_minus_100", "setHunger", "dev_tooltip_set_hunger_-100").onClick.AddListener(delegate
			{
				SetWorkerHunger(-99f);
			});
			AddSubgroup("dev_worker_stats");
			AddButton("dev_set_worker_stats", "setWorkerStat", "dev_tooltip_set_worker_stats", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupWorkerStatPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddSubgroup("dev_sleep");
			AddButton("dev_set_worker_sleep_100", "setSleep", "dev_tooltip_set_worker_sleep_100").onClick.AddListener(delegate
			{
				SetWorkerSleep(100f);
			});
			AddButton("dev_set_worker_sleep_50", "setSleep", "dev_tooltip_set_worker_sleep_50").onClick.AddListener(delegate
			{
				SetWorkerSleep(50f);
			});
			AddButton("dev_set_worker_sleep_1", "setSleep", "dev_tooltip_set_worker_sleep_1").onClick.AddListener(delegate
			{
				SetWorkerSleep(1f);
			});
			AddButton("dev_faint_worker", "faint", "dev_tooltip_faint_worker").onClick.AddListener(delegate
			{
				FaintWorker(5f);
			});
			AddButton("dev_unfaint_worker", "unfaint", "dev_tooltip_unfaint_worker").onClick.AddListener(delegate
			{
				FaintWorker(99f);
			});
			AddSubgroup("dev_menu_combat");
			AddButton("dev_mark_animals_for_attack", "huntAllAnimals", "dev_tooltip_hunt_animals").onClick.AddListener(delegate
			{
				HuntAllAnimals();
			});
			AddButton("dev_mark_workers_for_attack", "huntAllWorkers", "dev_tooltip_hunt_workers").onClick.AddListener(delegate
			{
				StartWorkerBattleRoyale();
			});
			AddToggle("dev_toggle_combat_damage_popup", "toggleCombatDamagePopup", "dev_tooltip_toggle_combat_damage_popup", DeveloperVariables.ShowCombatNumbers).onClick.AddListener(ToggleCombatDamagePopup);
			AddButton("dev_spawn_enemy", string.Empty, "dev_tooltip_spawn_enemy", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupEnemiesPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_kill_all_enemies", "killEnemies", "dev_tooltip_kill_enemies").onClick.AddListener(delegate
			{
				KillAllEnemies();
			});
			AddButton("dev_spawn_trebuchet", string.Empty, "dev_tooltip_spawn_trebuchet", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupTrebuchetsPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_make_npc_leave", string.Empty, "dev_tooltip_make_npc_leave").onClick.AddListener(delegate
			{
				ActivateMakeNPCLeave();
			});
			AddButton("dev_spawn_blank_npc", string.Empty, "dev_tooltip_spawn_blank_npc", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupNPCsPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_set_npc_behaviour", string.Empty, "dev_tooltip_set_npc_behaviour", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupNPCBehaviourPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_set_npc_faction", string.Empty, "dev_tooltip_set_npc_faction", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupNPCFactionPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_commander_ai", string.Empty, "dev_tooltip_commander_ai", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupCommanderAIPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_deal_damage", "dealDamage", "dev_tooltip_deal_damage").onClick.AddListener(delegate
			{
				DealDamage();
			});
			AddSubgroup("dev_events");
			AddButton("dev_spawn_event", string.Empty, "dev_tooltip_spawn_event", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupEventsPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_schedule_event_group", string.Empty, "dev_tooltip_schedule_event_group", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupEventGroupsPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_event_interaction_chance_always", "setInteractionEventChance", "dev_tooltip_set_interaction_event_chance_always").onClick.AddListener(delegate
			{
				SetInteractionEventChance(1f);
			});
			AddButton("dev_event_interaction_chance_default", "setInteractionEventChance", "dev_tooltip_set_interaction_event_chance_default").onClick.AddListener(delegate
			{
				SetInteractionEventChance(0f);
			});
			AddSubgroup("dev_map");
			AddButton("dev_relocate_animal_idle_points", string.Empty, "dev_tooltip_relocate_animal_idle_points").onClick.AddListener(delegate
			{
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				foreach (KeyValuePair<Animal, List<IdlePointManager.AnimalIdlePoint>> item in VillageManager.ActiveVillage.Map.IdlePointManager.IdlePointsByAnimal)
				{
					foreach (IdlePointManager.AnimalIdlePoint item2 in item.Value)
					{
						VillageManager.ActiveVillage.Map.IdlePointManager.RelocateAnimalIdlePoint(item2);
					}
				}
				stopwatch.Stop();
				UnityEngine.Debug.Log($"Relocated all animal idle points in {stopwatch.Elapsed.TotalMilliseconds:F2} ms.");
			});
			AddButton("dev_weather_time", string.Empty, "dev_tooltip_weather_date_time").onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					DateTimeDebug(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_refresh_stability_water", string.Empty, "dev_tooltip_refresh_stability_water", isSubMenuButton: true).onClick.AddListener(delegate
			{
				VillageMap map = VillageManager.ActiveVillage.Map;
				int num = map.GridSpaceData.Length;
				for (int i = 0; i < num; i++)
				{
					MapNode mapNode = map.GridSpaceData[i];
					if (mapNode != null && mapNode.IsWater)
					{
						map.StabilityManager.GroundRemoved(mapNode.Position.x, mapNode.Position.y, mapNode.Position.z);
					}
				}
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			});
			AddSubgroup("dev_world_map");
			AddButton("dev_spawn_map_marker", string.Empty, "dev_spawn_world_marker_tooltip", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupSpawnMapMarkerPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_ambush_caravan", string.Empty, "dev_ambush_caravan_tooltip").onClick.AddListener(delegate
			{
				CaravanInstance caravanInstance = GlobalSaveController.CurrentVillageData.WorldMapData.Caravans.Where((CaravanInstance caravan) => caravan.CaravanState == CaravanState.Travelling).PickRandom();
				if (caravanInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(96, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DeveloperPanelView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("No valid caravan found to force ambush. There needs to be at least 1 caravan that is in state '");
						messageBuilder.AppendFormatted(CaravanState.Travelling);
						messageBuilder.AppendLiteral("'");
					}
					Log.Error(messageBuilder);
				}
				else
				{
					caravanInstance.StartAmbush();
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				}
			});
			AddSubgroup("dev_voxel");
			AddToggle("dev_voxel_info", "voxelInfo", "dev_tooltip_voxel_info", CommandArgument("voxelInfo") == "on").onClick.AddListener(VoxelInfo);
			AddToggle("dev_water_debug", "", "dev_tooltip_toggle_water_debug_ui", WaterDebugUI.IsDebugUIEnabled).onClick.AddListener(ToggleWaterDebugUI);
			AddButton("dev_damage_voxel", "damageVoxel", "dev_tooltip_damage_voxel").onClick.AddListener(delegate
			{
				DamageVoxel();
			});
			AddToggle("dev_weather_view", "toggleWeatherView", "dev_tooltip_weather_view", CommandArgument("toggleWeatherView") == "on").onClick.AddListener(WeatherDebugView);
			AddToggle("dev_instant_dig_" + CommandArgument("toggleinstantdig"), "toggleinstantdig", "dev_tooltip_instant_dig", CommandArgument("toggleinstantdig") == "on").onClick.AddListener(InstantDig);
			AddButton("dev_mining_speed_10", string.Empty, "dev_tooltip_10_mining_speed").onClick.AddListener(delegate
			{
				foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
				{
					if (worker != null)
					{
						worker.Stats?.AddAttributeModifier(new CustomAttributeAdderModifierInstance(AttributeType.MineSpeed, 10f, "_dbg"));
						worker.Stats?.AddAttributeModifier(new CustomAttributeAdderModifierInstance(AttributeType.MineFail, 0f, "_dbg"));
					}
				}
			});
			AddButton("dev_mining_speed_reset", string.Empty, "dev_tooltip_revert_mining_speed").onClick.AddListener(delegate
			{
				foreach (HumanoidInstance worker2 in GlobalSaveController.CurrentVillageData.Workers)
				{
					worker2?.Stats?.RemoveAttributeModifier(ModifierType.CustomAttributeAdder, "_dbg");
				}
			});
			AddSubgroup("dev_plants");
			AddButton("dev_spawn_plant", "spawnPlant", "dev_tooltip_spawn_plant", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupPlantPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_spawn_mature_plant", "spawnMaturePlant", "dev_tooltip_spawn_mature_plant", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupMaturePlantPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_kill_all_plants", "killPlants", "dev_tooltip_kill_plants").onClick.AddListener(delegate
			{
				KillPlants();
			});
			AddButton("dev_plant_next_phase", "plantNextPhase", "dev_tooltip_plant_next_phase").onClick.AddListener(delegate
			{
				PlantNextPhase();
			});
			AddToggle("dev_instant_cut_" + CommandArgument("instantCut"), "forcePlantCrops", "dev_tooltip_instant_cut").onClick.AddListener(InstantCut);
			AddSubgroup("dev_crops");
			AddButton("dev_crop_next_phase", "cropNextPhase", "dev_tooltip_crop_next_phase").onClick.AddListener(delegate
			{
				CropNextPhase();
			});
			AddToggle("dev_force_crop_harvest_phase_" + CommandArgument("forceCropHarvestPhase"), "forceCropHarvestPhase", "dev_tooltip_force_crop_harvest_phase").onClick.AddListener(ForceCropHarvestPhase);
			AddToggle("dev_force_plant_crops_" + CommandArgument("forcePlantCrops"), "forcePlantCrops", "dev_tooltip_force_plant_crops").onClick.AddListener(ForcePlantCrops);
			AddSubgroup("dev_fuel");
			AddButton("dev_set_low_fuel", "setLowFuel", "dev_tooltip_set_low_fuel").onClick.AddListener(delegate
			{
				SetLowFuel();
			});
			AddSubgroup("dev_thunder");
			AddButton("dev_thunder", "thunder", "dev_tooltip_thunder").onClick.AddListener(delegate
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("thunder");
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			});
			AddSubgroup("dev_regions");
			AddToggle("dev_toggle_regions", "toggleVisualRegions", "dev_tooltip_toggle_regions", instance.EnabledType.HasFlag(VisualDebugType.MapRegions)).onClick.AddListener(ToggleRegions);
			AddToggle("dev_toggle_air_nodes", "toggleVisualNodes", "dev_tooltip_air_grid_nodes", instance.EnabledType.HasFlag(VisualDebugType.GridNode)).onClick.AddListener(ToggleGridNodesAir);
			AddToggle("dev_toggle_ground_nodes", "toggleVisualAirNodes", "dev_tooltip_ground_grid_nodes", instance.EnabledType.HasFlag(VisualDebugType.GridNode)).onClick.AddListener(ToggleGridNodesGround);
			AddToggle("dev_toggle_pathing_lines", "toggleVisualPathingLines", "dev_tooltip_pathing_lines", instance.EnabledType.HasFlag(VisualDebugType.Pathfinding)).onClick.AddListener(TogglePathingLines);
			AddSubgroup("dev_pathfinding");
			AddButton("dev_refresh_nodes", "", "dev_tooltip_refresh_nodes").onClick.AddListener(RefreshAllNodes);
			AddButton("dev_update_node_visualizer", "", "dev_tooltip_node_visualizer").onClick.AddListener(ToggleDebugNodeUpdatesVisualizer);
			AddSubgroup("dev_warning_messages");
			AddButton("dev_create_warning", "", "dev_tooltip_create_warning_messages").onClick.AddListener(delegate
			{
				TestWarningMessages();
			});
			AddButton("dev_update_warning", "", "dev_tooltip_test_update_warnings").onClick.AddListener(delegate
			{
				UpdateWarningMessage();
			});
			AddButton("dev_remove_warning", "", "dev_tooltip_test_remove_warnings").onClick.AddListener(delegate
			{
				RemoveAllWarningMessages();
			});
			AddSubgroup("dev_visual_debug");
			AddToggle("dev_toggle_all_debug", "toggleVisualDebugElements", "dev_tooltip_toggle_all_visual_debug", VisualDebugManager.IsEnabled).onClick.AddListener(ToggleVisalDebuggingSystem);
			AddToggle("dev_toggle_recheability_debug", "toggleVisualReachability", "dev_tooltip_toggle_reachability", instance.EnabledType.HasFlag(VisualDebugType.Reachability)).onClick.AddListener(ToggleVisualDebugReachablePoints);
			AddToggle("dev_toggle_proximity_debug", "toggleVisualProximity", "dev_tooltip_toggle_visual_proximity", instance.EnabledType.HasFlag(VisualDebugType.Proximity)).onClick.AddListener(ToggleVisualDebugProximity);
			AddToggle("dev_toggle_relocate_debug", "toggleVisualRelPiles", "dev_tooltip_toggle_relocate_piles", instance.EnabledType.HasFlag(VisualDebugType.RelocatePileGoal)).onClick.AddListener(ToggleDebugRelocatePiles);
			AddSubgroup("dev_effects");
			AddButton("dev_spawn_particle_system", string.Empty, "dev_tooltip_spawn_particle_system", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupSpawnParticlesPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddSubgroup("dev_trading");
			AddButton("dev_spawn_trader", "spawnTrader", "dev_tooltip_spawn_trader").onClick.AddListener(delegate
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnTrader", new string[3] { "trader_1", "0", "0" });
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			});
			AddButton("dev_spawn_trader_with_bodyguards", "spawnTraderWithBodyguards", "dev_tooltip_spawn_trader_bodyguards").onClick.AddListener(delegate
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnTrader", new string[3] { "trader_1", "0", "3" });
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			});
			AddButton("dev_faction_set_friendliness", string.Empty, "dev_tooltip_faction_set_friendliness", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupFactionsFriendlinessPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_spawn_bard_visitor", "spawnBardVisitor").onClick.AddListener(delegate
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnBardVisitor", new string[2] { "bard_visitor_1", "0" });
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			});
			AddSubgroup("dev_animals");
			AddButton("dev_spawn_animal", "spawnAnimal", "dev_tooltip_spawn_animal", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupAnimalsPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_kill_all_animals", "killAnimals", "dev_tooltip_kill_all_animals").onClick.AddListener(delegate
			{
				KillAllAnimals();
			});
			AddButton("dev_mark_for_roping", "markForRoping", "dev_tooltip_mark_for_roping").onClick.AddListener(delegate
			{
				MarkForRoping();
			});
			AddButton("dev_domestic", "setDomesticAnimal", "dev_tooltip_set_domestic").onClick.AddListener(SetAsDomestic);
			AddButton("dev_pet", "setPetAnimal", "dev_tooltip_set_pet").onClick.AddListener(SetAsPet);
			AddButton("dev_wild", "setWildAnimal", "dev_tooltip_set_wild").onClick.AddListener(SetAsWild);
			AddButton("dev_wild_aggressive", "setWildAggressiveAnimal", "dev_tooltip_set_wild_aggro").onClick.AddListener(SetAsWildAggressive);
			AddButton("dev_pregnant", "setPregnantAnimal", "dev_tooltip_set_pregnant_animal").onClick.AddListener(SetPregnantAnimal);
			AddButton("dev_birth", "giveBirth", "dev_tooltip_give_birth_animal").onClick.AddListener(GiveBirth);
			AddButton("dev_animal_prod_finish", "finishAnimalProduction", "dev_tooltip_finish_animal_production").onClick.AddListener(FinishAnimalProduction);
			AddButton("dev_reset_animal_timers", "resetTamingAndTraining", "dev_tooltip_reset_taming_and_training").onClick.AddListener(ResetAnimalTamingAndTrainingCounters);
			AddSubgroup("dev_fish");
			AddButton("dev_spawn_fish", "spawnFish", "dev_tooltip_spawn_fish", isSubMenuButton: true).onClick.AddListener(delegate
			{
				FlushMenuItems(delegate
				{
					SetupFishPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			AddButton("dev_try_fish_spawn", "tryFishSpawn", "dev_tooltip_try_fish_spawn").onClick.AddListener(TryFishSpawn);
			AddButton("dev_kill_all_fish", "killAllFish", "dev_tooltip_kill_all_fish").onClick.AddListener(delegate
			{
				KillAllFish();
			});
			AddSubgroup("dev_traps");
			AddButton("dev_trigger_trap", "triggerTrap", "dev_tooltip_trigger_traps").onClick.AddListener(TriggerTrap);
			AddButton("dev_reset_trap", "resetTrap", "dev_tooltip_reset_traps").onClick.AddListener(ResetTrap);
			AddSubgroup("dev_general_actions");
			AddButton("dev_force_exception", "forceException", "dev_tooltip_force_exception").onClick.AddListener(ForceException);
			AddToggle("dev_toggle_player_voxel_info", "togglePlayerVoxelInfo", "dev_tooltip_toggle_player_voxel_info", PlayerVoxelInfo.ShowInfo).onClick.AddListener(TogglePlayerVoxelInfo);
			AddSubgroup("dev_second_map");
			AddToggle("dev_second_map_timer_" + CommandArgument("commandDisableSecondMapTimer"), "commandDisableSecondMapTimer", "dev_tooltip_second_map_timer", CommandArgument("commandDisableSecondMapTimer") == "on").onClick.AddListener(SecondMapTimer);
			callback();
		}

		public void DestroyAllBuildings()
		{
			_ = VillageManager.ActiveVillage.Map;
			foreach (SelectableObject item in MonoSingleton<SelectableObjectManager>.Instance.SelectableObjects.ToList())
			{
				if (item.IsBuilding && item.GetAsWorldObject() is BaseBuildingInstance baseBuildingInstance)
				{
					baseBuildingInstance.DestroyBuildingStabilityZero();
				}
			}
		}

		private void ActivateMakeNPCLeave()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("makeNPCLeave");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void RefreshAllNodes()
		{
			VillageManager.ActiveVillage.Map.RefreshAllNodes();
			MapNode[] gridSpaceData = VillageManager.ActiveVillage.Map.GridSpaceData;
			foreach (MapNode node in gridSpaceData)
			{
				VillageManager.ActiveVillage.Map.RegionManager.MapNodeStateChanged(node);
			}
			foreach (uint key in VillageManager.ActiveVillage.Map.RegionAreaManager.Areas.Keys)
			{
				VillageManager.ActiveVillage.Map.RegionAreaManager.QueueForRecalculation(key);
			}
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void ToggleDebugNodeUpdatesVisualizer()
		{
			MonoSingleton<DebugNodeUpdatesVisualizer>.Instance.enabled = !MonoSingleton<DebugNodeUpdatesVisualizer>.Instance.isActiveAndEnabled;
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void TestWarningMessages()
		{
			for (int i = 0; i < 10; i++)
			{
				WarningMessageCategory warningMessageCategory = EnumValues.WarningMessageCategories.PickRandom();
				if (warningMessageCategory != WarningMessageCategory.None)
				{
					WarningMessageData message = new WarningMessageData(warningMessageCategory, $"{i}. {warningMessageCategory} test msg", $"{i}. Tooltip test of type {warningMessageCategory}", "Idle");
					MonoSingleton<WarningMessageController>.Instance.ShowMessage(message);
				}
			}
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void UpdateWarningMessage()
		{
			foreach (WarningMessageData item in MonoSingleton<WarningMessageManager>.Instance.GetMessagesShowing())
			{
				item.UpdateData(item.Text + " updated", item.Tooltip + " updated");
				MonoSingleton<WarningMessageController>.Instance.ShowMessage(item);
			}
		}

		private void RemoveAllWarningMessages()
		{
			List<WarningMessageData> messagesShowing = MonoSingleton<WarningMessageManager>.Instance.GetMessagesShowing();
			foreach (WarningMessageData item in messagesShowing)
			{
				MonoSingleton<WarningMessageController>.Instance.HideMessage(item);
			}
			messagesShowing.Clear();
		}

		private void SetupAnimalsPanel(Action callback)
		{
			AddSubgroup("dev_wild_animals");
			foreach (Animal item in Repository<AnimalBaseRepository, Animal>.Instance.GetAllItems())
			{
				AddButton(AnimalUtils.GetLocalizedName(item), string.Empty, "dev_tooltip_animal").GetComponent<SoundButton>().onClick.AddListener(delegate
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnAnimal", new string[5]
					{
						item.GetID(),
						"1",
						$"{UnityEngine.Random.Range(0, 2)}",
						"-1",
						$"{UnityEngine.Random.Range(0f, 0.95f)}"
					});
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				});
			}
			AddSubgroup("dev_domestic_animals");
			foreach (Animal item2 in Repository<AnimalBaseRepository, Animal>.Instance.GetAllItems())
			{
				if (item2.CanBeTamed)
				{
					AddButton(AnimalUtils.GetLocalizedName(item2), string.Empty, "dev_tooltip_animal_domestic").GetComponent<SoundButton>().onClick.AddListener(delegate
					{
						MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnDomesticAnimal", new string[5]
						{
							item2.GetID(),
							"1",
							$"{UnityEngine.Random.Range(0, 2)}",
							"-1",
							$"{UnityEngine.Random.Range(0f, 0.95f)}"
						});
						MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
					});
				}
			}
			AddSubgroup("dev_pet_animals");
			foreach (Animal item3 in Repository<AnimalBaseRepository, Animal>.Instance.GetAllItems())
			{
				if (item3.CanBeTrained)
				{
					AddButton("animal_name_" + item3.GetID(), string.Empty, "dev_tooltip_animal_pet").GetComponent<SoundButton>().onClick.AddListener(delegate
					{
						MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnPetAnimal", new string[5]
						{
							item3.GetID(),
							"1",
							$"{UnityEngine.Random.Range(0, 2)}",
							"-1",
							$"{UnityEngine.Random.Range(0f, 0.95f)}"
						});
						MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
					});
				}
			}
			BackButtonAction(Reset);
			callback();
		}

		private void SetupWorkerStatPanel(Action callback)
		{
			AddSubgroup("dev_stat_0");
			GenerateStatButtons(0);
			AddSubgroup("dev_stat_25");
			GenerateStatButtons(25);
			AddSubgroup("dev_stat_50");
			GenerateStatButtons(50);
			AddSubgroup("dev_stat_75");
			GenerateStatButtons(75);
			AddSubgroup("dev_stat_100");
			GenerateStatButtons(100);
			BackButtonAction(Reset);
			callback();
			void GenerateStatButtons(int statAmount)
			{
				StatType[] array = (StatType[])Enum.GetValues(typeof(StatType));
				for (int i = 0; i < array.Length; i++)
				{
					StatType statType = array[i];
					if (statType != StatType.None)
					{
						AddButton("menu_" + statType, string.Empty, "dev_tooltip_stat_set").GetComponent<SoundButton>().onClick.AddListener(delegate
						{
							MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setWorkerStat", new string[2]
							{
								statType.ToString(),
								statAmount.ToString()
							});
							MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
						});
					}
				}
			}
		}

		private void SetupResourcePanel(Action callback)
		{
			int numberToSpawn = 0;
			DeveloperToggle maxToggle = AddToggle("general_maxLevel", "", null, startingValue: true, interactible: true, ignoreBySearch: true);
			DeveloperToggle oneToggle = AddToggle("1", "", null, startingValue: false, interactible: true, ignoreBySearch: true);
			DeveloperToggle randomToggle = AddToggle("menu_randomise", "", null, startingValue: false, interactible: true, ignoreBySearch: true);
			maxToggle.onClick.AddListener(delegate
			{
				numberToSpawn = 0;
				UntoggleAllOtherNumbers(new List<DeveloperToggle> { oneToggle, randomToggle });
			});
			oneToggle.onClick.AddListener(delegate
			{
				numberToSpawn = 1;
				UntoggleAllOtherNumbers(new List<DeveloperToggle> { maxToggle, randomToggle });
			});
			randomToggle.onClick.AddListener(delegate
			{
				numberToSpawn = -1;
				UntoggleAllOtherNumbers(new List<DeveloperToggle> { maxToggle, oneToggle });
			});
			AddSpacer();
			AddSubgroup("dev_select_resource");
			_ = VillageManager.ActiveVillage.Map;
			foreach (Resource item in from res in Repository<ResourceRepository, Resource>.Instance.GetAllItems()
				orderby ResourceUtils.GetLocalizedResourceName(res.GetID())
				select res)
			{
				if ((item.HasQuality && !item.IsBuildingStructure) || MonoSingleton<GlobalSaveController>.Instance.IsBuildingLocked(item.BuildingBlueprintID))
				{
					continue;
				}
				string localizedResourceName = ResourceUtils.GetLocalizedResourceName(item.GetID());
				AddButton(localizedResourceName, string.Empty, "dev_tooltip_resource").GetComponent<SoundButton>().onClick.AddListener(delegate
				{
					if (numberToSpawn != -1 && numberToSpawn != 1)
					{
						numberToSpawn = item.StackingLimit;
					}
					else if (numberToSpawn == -1)
					{
						numberToSpawn = UnityEngine.Random.Range(1, item.StackingLimit);
					}
					MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnResource", new string[2]
					{
						item.GetID(),
						numberToSpawn.ToString()
					});
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				});
			}
			BackButtonAction(Reset);
			callback();
		}

		private void UntoggleAllOtherNumbers(IEnumerable<DeveloperToggle> toggles)
		{
			foreach (DeveloperToggle toggle in toggles)
			{
				toggle.ToggleImage(value: false);
			}
		}

		private void SetupResourceCtgPanel(Action callback)
		{
			AddSubgroup("dev_select_resourceCtg");
			ResourceCategory[] allResourceCategories = EnumValues.AllResourceCategories;
			for (int i = 0; i < allResourceCategories.Length; i++)
			{
				ResourceCategory category = allResourceCategories[i];
				if (category != ResourceCategory.None)
				{
					string text = "resource_category_name_" + category;
					if (category.ToString() == "CtgAll")
					{
						AddSpacer();
					}
					AddButton(text, string.Empty, "dev_tooltip_resourceCtg").GetComponent<SoundButton>().onClick.AddListener(delegate
					{
						MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnResourceCtg", new string[1] { category.ToString() });
						MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
					});
				}
			}
			BackButtonAction(Reset);
			callback();
		}

		private void SetupPlantPanel(Action callback)
		{
			AddSubgroup("dev_select_plant");
			foreach (PlantMapResource item in Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetAllItems())
			{
				string text = "resource_holder_name_" + item.GetID();
				AddButton(text, string.Empty, "dev_tooltip_plant").GetComponent<SoundButton>().onClick.AddListener(delegate
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnPlant", new string[1] { item.GetID() });
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				});
			}
			BackButtonAction(Reset);
			callback();
		}

		private void SetupMaturePlantPanel(Action callback)
		{
			AddSubgroup("dev_select_plant");
			foreach (PlantMapResource item in Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetAllItems())
			{
				string text = "resource_holder_name_" + item.GetID();
				AddButton(text, string.Empty, "dev_tooltip_plant").GetComponent<SoundButton>().onClick.AddListener(delegate
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnMaturePlant", new string[1] { item.GetID() });
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				});
			}
			BackButtonAction(Reset);
			callback();
		}

		private void SetupFishPanel(Action callback)
		{
			AddSubgroup("dev_select_fish");
			foreach (FishMapResource item in Repository<FishMapResourceRepository, FishMapResource>.Instance.GetAllItems())
			{
				string localizedResourceName = ResourceUtils.GetLocalizedResourceName(item.GetID());
				AddButton(localizedResourceName, string.Empty, "dev_tooltip_fish").GetComponent<SoundButton>().onClick.AddListener(delegate
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnFish", new string[1] { item.GetID() });
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				});
			}
			BackButtonAction(Reset);
			callback();
		}

		private void TryFishSpawn()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("tryFishSpawn");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void SetupItemsPanel(Action callback)
		{
			AddSubgroup("dev_select_item");
			foreach (string group in Repository<ResourceRepository, Resource>.Instance.GetItemGroups())
			{
				string text = "equipment_name_" + group;
				AddButton(text, string.Empty, "dev_tooltip_spawn_item", isSubMenuButton: true).GetComponent<SoundButton>().onClick.AddListener(delegate
				{
					FlushMenuItems(delegate
					{
						SetupGroupItemsPanel(group, delegate
						{
							ReparentMenuItems();
						});
					});
				});
			}
			AddSpacer();
			AddButton("dev_random_item", string.Empty, "dev_tooltip_random_item").GetComponent<SoundButton>().onClick.AddListener(delegate
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnRandomResources", new string[1] { "10" });
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			});
			BackButtonAction(Reset);
			callback();
		}

		private void SetupGroupItemsPanel(string group, Action callback)
		{
			AddSubgroup("dev_select_item_quality");
			foreach (Resource item in from x in Repository<ResourceRepository, Resource>.Instance.GetAllItems()
				where x.GroupIdentifier == @group
				select x)
			{
				if (item.HasQuality)
				{
					string localizedResourceName = ResourceUtils.GetLocalizedResourceName(item.GetID());
					AddButton(localizedResourceName, string.Empty, "dev_tooltip_spawn_item_quality").GetComponent<SoundButton>().onClick.AddListener(delegate
					{
						MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnResource", new string[2]
						{
							item.GetID(),
							item.StackingLimit.ToString()
						});
						MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
					});
				}
			}
			BackButtonAction(delegate
			{
				FlushMenuItems(delegate
				{
					SetupItemsPanel(delegate
					{
						ReparentMenuItems();
					});
				});
			});
			callback();
		}

		private void SetupSkillsPanel(Action callback)
		{
			BackButtonAction(Reset);
			AddSubgroup("dev_select_dropdown");
			DeveloperDropdown xpToAddDropdown = AddDropdown("XP to add: ", new string[10] { "1000", "2000", "4000", "5000", "10000", "-1000", "-2000", "-4000", "-5000", "-10000" }, null);
			AddSubgroup("dev_select_skill");
			string[] names = Enum.GetNames(typeof(SkillType));
			foreach (string skill in names)
			{
				AddButton("skill_name_" + skill, string.Empty, "dev_tooltip_skill").onClick.AddListener(delegate
				{
					string[] arguments = new string[2]
					{
						skill,
						xpToAddDropdown.GetSelectedOption()
					};
					MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("addExperience", arguments);
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				});
			}
			AddSpacer();
			callback();
		}

		private void SetupSpawnParticlesPanel(Action callback)
		{
			BackButtonAction(Reset);
			AddSubgroup("dev_particle_system");
			if (MonoSingleton<ParticleSystemPool>.IsInstantiated())
			{
				foreach (string particleId in MonoSingleton<ParticleSystemPool>.Instance.GetIds())
				{
					AddButton("dev_particle_" + particleId, string.Empty, particleId ?? "").onClick.AddListener(delegate
					{
						MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnParticleSystem", new string[1] { particleId });
						MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
					});
				}
			}
			AddSpacer();
			callback();
		}

		private void SetupFactionsFriendlinessPanel(Action callback)
		{
			BackButtonAction(Reset);
			FactionInstance selectedFaction = null;
			if (MonoSingleton<GlobalSaveController>.IsInstantiated() && GlobalSaveController.CurrentVillageData.WorldMapData != null)
			{
				AddSubgroup("dev_faction_friendliness");
				foreach (FactionInstance factionInstance in GlobalSaveController.CurrentVillageData.WorldMapData.FactionInstances)
				{
					string text = factionInstance.BlueprintId + "_name";
					AddButton(text, string.Empty, "dev_tooltip_faction").onClick.AddListener(delegate
					{
						selectedFaction = factionInstance;
					});
				}
				AddSpacer();
				AddSubgroup("dev_faction_modify_friendliness");
				AddButton("dev_friendliness_plus", string.Empty, "dev_tooltip_friendliness_plus").onClick.AddListener(delegate
				{
					selectedFaction?.AddFriendliness(10f);
					if (selectedFaction != null)
					{
						bool isEnabled;
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(50, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DeveloperPanelView.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Increased friendliness of ");
							messageBuilder.AppendFormatted(selectedFaction.BlueprintId);
							messageBuilder.AppendLiteral(". Current friendliness: ");
							messageBuilder.AppendFormatted(selectedFaction.PlayerFriendliness);
						}
						Log.Debug(messageBuilder);
					}
				});
				AddButton("dev_friendliness_minus", string.Empty, "dev_tooltip_friendliness_minus").onClick.AddListener(delegate
				{
					selectedFaction?.AddFriendliness(-10f);
					if (selectedFaction != null)
					{
						bool isEnabled;
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(50, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DeveloperPanelView.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Decreased friendliness of ");
							messageBuilder.AppendFormatted(selectedFaction.BlueprintId);
							messageBuilder.AppendLiteral(". Current friendliness: ");
							messageBuilder.AppendFormatted(selectedFaction.PlayerFriendliness);
						}
						Log.Debug(messageBuilder);
					}
				});
			}
			AddSpacer();
			callback();
		}

		private void SetupTrebuchetsPanel(Action callback)
		{
			BackButtonAction(Reset);
			AddSubgroup("dev_trebuchet_spawn");
			foreach (Trebuchet trebuchetType in Repository<TrebuchetRepository, Trebuchet>.Instance.GetAllItems())
			{
				string text = trebuchetType.GetID().Replace("_", " ").ToCamelCase();
				AddButton(text, string.Empty, "dev_tooltip_spawn_trebuchet").onClick.AddListener(delegate
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnTrebuchet", new string[1] { trebuchetType.GetID() });
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				});
			}
			AddSpacer();
			AddButton("dev_set_health_0", string.Empty, "dev_tooltip_set_health_0").onClick.AddListener(delegate
			{
				SetHealth(0f);
			});
			callback();
		}

		private void SetupEnemiesPanel(Action callback)
		{
			_SetupNPCsPanel(callback, "EnemyBehaviour");
		}

		private void SetupNPCsPanel(Action callback)
		{
			_SetupNPCsPanel(callback);
		}

		private void _SetupNPCsPanel(Action callback, string startingBehaviourName = null)
		{
			if (startingBehaviourName == null)
			{
				startingBehaviourName = "BlankBehaviour";
			}
			BackButtonAction(Reset);
			AddSubgroup("dev_enemy_spawn");
			foreach (NPC npcType in Repository<NPCRepository, NPC>.Instance.GetAllItems())
			{
				string text = LocKeyUtils.GetName(npcType.LocKeys);
				AddButton(text ?? "", string.Empty, "dev_tooltip_enemy").onClick.AddListener(delegate
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnNPC", new string[3]
					{
						npcType.GetID(),
						$"{gender}",
						startingBehaviourName
					});
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				});
			}
			AddSpacer();
			AddButton("dev_gender_" + ((gender == 0) ? "male" : "female"), string.Empty, "dev_tooltip_gender").onClick.AddListener(delegate
			{
				gender = 1 - gender;
				EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperActionButton>().SetupButton("Gender: " + ((gender == 0) ? "Male" : "Female"), string.Empty);
			});
			AddSpacer();
			AddButton("dev_kill_all_enemies", string.Empty, "dev_tooltip_kill_enemies").onClick.AddListener(KillAllEnemies);
			AddButton("dev_set_health_0", string.Empty, "dev_tooltip_set_health_0").onClick.AddListener(delegate
			{
				SetHealth(0f);
			});
			callback();
		}

		private void SetupCommanderAIPanel(Action callback)
		{
			BackButtonAction(Reset);
			AddButton("dev_create_commander_from_all", string.Empty, "dev_tooltip_create_commander_from_all").onClick.AddListener(delegate
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("createCommanderGroupFromAll");
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			});
			AddButton("dev_enable_manual_commander_input", string.Empty, "dev_tooltip_enable_manual_commander_input").onClick.AddListener(delegate
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("enableManualCommanderInput");
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			});
			AddButton("dev_enable_manual_construct_commander_input", string.Empty, "dev_tooltip_enable_manual_construct_commander_input").onClick.AddListener(delegate
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("enableManualConstructCommanderInput");
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			});
			AddButton("dev_enable_manual_dig_commander_input", string.Empty, "dev_tooltip_enable_manual_dig_commander_input").onClick.AddListener(delegate
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("enableManualDigCommanderInput");
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			});
			callback();
		}

		private void SetupNPCBehaviourPanel(Action callback)
		{
			BackButtonAction(Reset);
			AddSubgroup("dev_npc_behaviour_select");
			string[] array = new string[6] { "BlankBehaviour", "EnemyBehaviour", "TraderBehaviour", "TraderBodyguardBehaviour", "PrisonerBehaviour", "WorkerBehaviour" };
			foreach (string behaviourName in array)
			{
				AddButton(behaviourName ?? "", string.Empty, "dev_behaviour_name_tooltip").onClick.AddListener(delegate
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setNPCBehaviour", new string[1] { behaviourName });
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				});
			}
			AddSpacer();
			callback();
		}

		private void SetupNPCFactionPanel(Action callback)
		{
			BackButtonAction(Reset);
			AddSubgroup("dev_npc_faction_select");
			foreach (FactionInstance faction in GlobalSaveController.CurrentVillageData.WorldMapData.FactionInstances)
			{
				AddButton(faction.BlueprintId + "_name", string.Empty, "dev_faction_name_tooltip").onClick.AddListener(delegate
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setNPCFaction", new string[1] { faction.BlueprintId });
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				});
			}
			AddSpacer();
			callback();
		}

		private void SetupEventGroupsPanel(Action callback)
		{
			BackButtonAction(Reset);
			AddSubgroup("dev_select_event_group");
			foreach (EventGroupInstance group in MonoSingleton<EventScheduler>.Instance.EventGroups)
			{
				string text = "dev_event_group_" + group.Blueprint.GetID().Replace("_", "").ToCamelCase();
				if (!(text == "dev_event_group_None"))
				{
					AddButton(text, string.Empty, "dev_tooltip_event_group").onClick.AddListener(delegate
					{
						MonoSingleton<EventScheduler>.Instance.ScheduleEventGroup(group, GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal + UnityEngine.Random.Range(5, 25));
						MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
					});
				}
			}
			AddSpacer();
			AddButton("dev_kill_all_enemies", string.Empty, "dev_tooltip_kill_enemies").onClick.AddListener(KillAllEnemies);
			AddButton("dev_set_health_0", string.Empty, "dev_tooltip_set_health_0").onClick.AddListener(delegate
			{
				SetHealth(0f);
			});
			callback();
		}

		private void SetupSpawnMapMarkerPanel(Action callback)
		{
			BackButtonAction(Reset);
			foreach (SecondMapType type in Enum.GetValues(typeof(SecondMapType)))
			{
				if (type != SecondMapType.LootStash && type != SecondMapType.Attack)
				{
					continue;
				}
				AddSubgroup(type.ToString());
				foreach (SecondMapSaveInfo info in Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.GetSaves(type))
				{
					string text = info.GetID() + "_" + info.BiomeType.Replace("map_type_", "");
					AddButton(text, string.Empty, string.Empty).onClick.AddListener(delegate
					{
						using PooledList<string> mapIds = ListPool<string>.GetJanitor(info.GetID());
						switch (type)
						{
						case SecondMapType.LootStash:
							MapPlaceGenerator.MaybeSpawnLootStash(1f, null, null, null, mapIds);
							break;
						case SecondMapType.Attack:
							MapPlaceGenerator.MaybeSpawnBanditCamp(1f, null, null, null, mapIds);
							break;
						}
						MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
					});
				}
				AddSpacer();
			}
			callback();
		}

		private void SetupEventsPanel(Action callback)
		{
			BackButtonAction(Reset);
			AddSubgroup("dev_event_spawn");
			AddSubgroup("game_event_type_season_start");
			foreach (GameEvent gameEvent in Repository<GameEventSettingsRepository, GameEvent>.Instance.GetAllItems())
			{
				string eventName = gameEvent.GetID().Replace("game_event_", "dev_event_");
				if (eventName == "dev_event_crop_blight")
				{
					AddSubgroup("Weather");
				}
				if (eventName == "dev_event_influence_20")
				{
					AddSubgroup("game_event_type_influence");
				}
				if (eventName == "dev_event_new_worker")
				{
					AddSubgroup("dev_event_new_worker");
				}
				if (eventName == "dev_event_raid_new")
				{
					AddSubgroup("life_event_type_Combat");
				}
				if (eventName == "dev_event_general_goods_trader_small")
				{
					AddSubgroup("general_trader");
				}
				if (eventName == "game_boar_event")
				{
					AddSubgroup("ctrl_Animals");
				}
				if (eventName == "dev_event_beggar")
				{
					AddSubgroup("game_event_type_visitor");
				}
				if (eventName == "dev_event_ambush" || eventName == "dev_event_attack_camp")
				{
					continue;
				}
				AddButton(eventName, string.Empty, gameEvent.GetID()).onClick.AddListener(delegate
				{
					if (eventName == "dev_event_all_dead_second_map" && !GlobalSaveController.CurrentVillageData.IsSecondMap)
					{
						Log.Error("You are currently not on secondary map.", "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DeveloperPanelView.cs");
					}
					else
					{
						if (eventName == "dev_event_raid_infamy")
						{
							GameEvent byID = Repository<GameEventSettingsRepository, GameEvent>.Instance.GetByID("game_event_raid_infamy");
							if (!FactionUtil.GetFactionsByFriendliness(byID.Friendliness, byID.ExcludeFactions, mustHaveVillages: true).Any())
							{
								bool isEnabled;
								FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(123, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DeveloperPanelView.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("There are currently no available ");
									messageBuilder.AppendFormatted(byID.Friendliness.First());
									messageBuilder.AppendLiteral(" factions that are not excluded. You probably need to activate the infamy grand objective.");
								}
								Log.Error(messageBuilder);
								return;
							}
						}
						MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
						MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
						{
							MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.StartEvent(gameEvent.GetID());
						});
					}
				});
			}
			AddSpacer();
			AddButton("dev_kill_all_enemies", string.Empty, "dev_tooltip_kill_enemies").onClick.AddListener(KillAllEnemies);
			AddButton("dev_set_health_0", string.Empty, "dev_tooltip_set_health_0").onClick.AddListener(delegate
			{
				SetHealth(0f);
			});
			callback();
		}

		private void SetupRaidersDetailsPanel(Action callback, int count)
		{
		}

		private void ToggleStructurePresetsPanel()
		{
		}

		private void ForceException()
		{
			throw new DivideByZeroException();
		}

		private void ToggleUI()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("toggleUI");
			if (!(EventSystem.current == null) && !(EventSystem.current.currentSelectedGameObject == null))
			{
				EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_toggle_ui_" + CommandArgument("toggleUI"), "dev_tooltip_toggle_ui");
			}
		}

		private void ToggleTooltips()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("toggleTooltips");
			if (!(EventSystem.current == null) && !(EventSystem.current.currentSelectedGameObject == null))
			{
				EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_toggle_tooltips_" + CommandArgument("toggleTooltips"), "dev_tooltip_toggle_tooltips");
			}
		}

		private void RecountPiles()
		{
			MonoSingleton<ResourcePileTracker>.Instance.ScheduleRecountPiles();
		}

		private void RecountHaulPiles()
		{
			MonoSingleton<ResourcePileHaulingManager>.Instance.TriggerLazyReProcessAll();
		}

		private void MarketingMode()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("marketingMode");
		}

		private void ForcePlantCrops()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("forcePlantCrops");
			if (!(EventSystem.current == null) && !(EventSystem.current.currentSelectedGameObject == null))
			{
				EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_force_plant_crops_" + CommandArgument("forcePlantCrops"), "dev_tooltip_force_plant_crops");
			}
		}

		private void ForceCropHarvestPhase()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("forceCropHarvestPhase");
			if (!(EventSystem.current == null) && !(EventSystem.current.currentSelectedGameObject == null))
			{
				EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_force_crop_harvest_phase_" + CommandArgument("forceCropHarvestPhase"), "dev_tooltip_force_crop_harvest_phase");
			}
		}

		private void InstantCut()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("instantCut");
			if (!(EventSystem.current == null) && !(EventSystem.current.currentSelectedGameObject == null))
			{
				EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_instant_cut_" + CommandArgument("instantCut"), "dev_tooltip_instant_cut");
			}
		}

		private void ConstructWithoutResources()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("constructWithoutResources");
		}

		private void ToggleAltCamera()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("toggleAltCamera");
			if (!(EventSystem.current == null) && !(EventSystem.current.currentSelectedGameObject == null))
			{
				EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_toggle_altCamera_" + CommandArgument("toggleAltCamera"), "dev_tooltip_toggle_alt_camera");
			}
		}

		private void DestroyResourcePile()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("destroyPile");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void KillAllPiles()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("killPiles");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void KillAllWorkersButOne()
		{
			List<HumanoidInstance> list = WorkerManager.WorkersEverywhere.ToList();
			if (list.Count <= 1)
			{
				return;
			}
			list.RemoveAt(0);
			foreach (HumanoidInstance item in list)
			{
				item.GetStat(StatType.Health).SetCurrent(0f);
			}
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void ToggleVisalDebuggingSystem()
		{
			if (VisualDebugManager.IsEnabled)
			{
				MonoSingleton<VisualDebugManager>.Instance.SetEnabled(value: false);
			}
			else
			{
				MonoSingleton<VisualDebugManager>.Instance.SetEnabled(value: true);
			}
		}

		private void ToggleVisualDebugProximity()
		{
			if (MonoSingleton<VisualDebugManager>.Instance.EnabledType.HasFlag(VisualDebugType.Proximity))
			{
				MonoSingleton<VisualDebugManager>.Instance.DisableType(VisualDebugType.Proximity);
			}
			else
			{
				MonoSingleton<VisualDebugManager>.Instance.EnableType(VisualDebugType.Proximity);
			}
		}

		private void ToggleRegions()
		{
			if (MonoSingleton<VisualDebugManager>.Instance.EnabledType.HasFlag(VisualDebugType.MapRegions))
			{
				MonoSingleton<VisualDebugManager>.Instance.DisableType(VisualDebugType.MapRegions);
				return;
			}
			MonoSingleton<VisualDebugManager>.Instance.EnableType(VisualDebugType.MapRegions);
			MonoSingleton<RegionDebugger>.Instance.GenerateDebugElements();
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void ToggleGridNodesAir()
		{
			if (MonoSingleton<VisualDebugManager>.Instance.EnabledType.HasFlag(VisualDebugType.GridNode))
			{
				MonoSingleton<VisualDebugManager>.Instance.DisableType(VisualDebugType.GridNode);
				MonoSingleton<MapNodeDebugManager>.Instance.Hide();
			}
			else
			{
				MonoSingleton<VisualDebugManager>.Instance.EnableType(VisualDebugType.GridNode);
				MonoSingleton<MapNodeDebugManager>.Instance.Show(showAirNodes: true);
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			}
		}

		private void ToggleGridNodesGround()
		{
			if (MonoSingleton<VisualDebugManager>.Instance.EnabledType.HasFlag(VisualDebugType.GridNode))
			{
				MonoSingleton<VisualDebugManager>.Instance.DisableType(VisualDebugType.GridNode);
				MonoSingleton<MapNodeDebugManager>.Instance.Hide();
			}
			else
			{
				MonoSingleton<VisualDebugManager>.Instance.EnableType(VisualDebugType.GridNode);
				MonoSingleton<MapNodeDebugManager>.Instance.Show(showAirNodes: false);
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			}
		}

		private void TogglePathingLines()
		{
			if (MonoSingleton<VisualDebugManager>.Instance.EnabledType.HasFlag(VisualDebugType.Pathfinding))
			{
				MonoSingleton<MapPathDebugManager>.Instance.Hide();
				return;
			}
			MonoSingleton<MapPathDebugManager>.Instance.Show();
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void ToggleDebugRelocatePiles()
		{
			if (MonoSingleton<VisualDebugManager>.Instance.EnabledType.HasFlag(VisualDebugType.RelocatePileGoal))
			{
				MonoSingleton<VisualDebugManager>.Instance.DisableType(VisualDebugType.RelocatePileGoal);
			}
			else
			{
				MonoSingleton<VisualDebugManager>.Instance.EnableType(VisualDebugType.RelocatePileGoal);
			}
		}

		private void ToggleVisualDebugReachablePoints()
		{
			if (MonoSingleton<VisualDebugManager>.Instance.EnabledType.HasFlag(VisualDebugType.Reachability))
			{
				MonoSingleton<VisualDebugManager>.Instance.DisableType(VisualDebugType.Reachability);
			}
			else
			{
				MonoSingleton<VisualDebugManager>.Instance.EnableType(VisualDebugType.Reachability);
			}
		}

		private void HuntAllAnimals()
		{
			List<AnimalInstance> list = new List<AnimalInstance>();
			list.AddRange(GlobalSaveController.CurrentVillageData.Animals);
			foreach (AnimalInstance item in list)
			{
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Hunt, item);
			}
		}

		private void ToggleCombatDamagePopup()
		{
			DeveloperVariables.ShowCombatNumbers = !DeveloperVariables.ShowCombatNumbers;
		}

		private void ToggleProductionSpeed()
		{
			if (MonoSingleton<ProductionManager>.Instance.GlobalSpeedMultiplier > 1f)
			{
				EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_production_speed_normal", "dev_tooltip_production_speed_max");
				SetProductionSpeedMultiplier(1f);
			}
			else
			{
				EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_production_speed_max", "dev_tooltip_production_speed_normal");
				SetProductionSpeedMultiplier(50f);
			}
		}

		private void SetProductionSpeedMultiplier(float value)
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("productionSpeed", value);
		}

		private void AutoprodWorkers()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("autoprodWorkers");
			EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperActionButton>().SetupButton("dev_autoprod_worker_" + CommandArgument("autoprodWorkers"), CommandDescription("autoprodWorkers"));
		}

		private void AutoprodResources()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("autoprodResources");
			EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperActionButton>().SetupButton("dev_autoprod_resources_" + CommandArgument("autoprodResources"), CommandDescription("autoprodResources"));
		}

		private void Autoconstruct()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("autoconstruct");
			if (!(EventSystem.current == null) && !(EventSystem.current.currentSelectedGameObject == null))
			{
				EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_autoconstruct_" + CommandArgument("autoconstruct"), "dev_tooltip_autoconstruct");
			}
		}

		private void UnlockAllVariants()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("unlockAllVariants");
			if (!(EventSystem.current == null) && !(EventSystem.current.currentSelectedGameObject == null))
			{
				EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_unlock_all_variants_" + CommandArgument("unlockAllVariants"), "dev_tooltip_unlock_all_variants");
			}
		}

		private void SpawnMaterialsWithBuilding()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnMaterialsWithBuilding");
			if (!(EventSystem.current == null) && !(EventSystem.current.currentSelectedGameObject == null))
			{
				EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_spawn_materials_with_building_" + CommandArgument("spawnMaterialsWithBuilding"), "dev_tooltip_spawn_materials_with_building");
			}
		}

		private void CraftableBuildingsEnabled()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("craftableBuildingsEnabled");
			if (!(EventSystem.current == null) && !(EventSystem.current.currentSelectedGameObject == null))
			{
				EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_craftable_buildings_enabled_" + CommandArgument("craftableBuildingsEnabled"), "dev_tooltip_craftable_buildings_enabled");
			}
		}

		private void AllowEdgePlacement()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("toggleAllowEdgePlacement");
			EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_allowEdgePlacement_" + CommandArgument("toggleAllowEdgePlacement"), "dev_tooltip_allowEdgePlacement");
		}

		private void UnlockAllRoomTypes()
		{
			foreach (string item in from rt in Repository<RoomTypeRepository, RoomType>.Instance.GetAllItems()
				where rt.Locked
				select rt.GetID())
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("unlockRoomType", new string[1] { item });
			}
			EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().interactable = false;
		}

		private void SwitchFactionOwnership()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("switchFactionOwnership");
		}

		private void ConvertAllBuildingsToEnemyOwned()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("convertAllBuildingsToEnemyOwned");
		}

		private void ActivateAllResearch()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("activateAllResearch");
			EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_activateAllResearch_" + CommandArgument("activateAllResearch"), "dev_tooltip_activate_all_research");
		}

		private void SetInteractionEventChance(float chance)
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setInteractionEventChance", chance);
		}

		private void WorkerConstructionSpeedMax()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("constructionSpeedMax");
		}

		private void WorkerMiningSpeedMax()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("miningSpeedMax");
		}

		private void SetWorkerSleep(float value)
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setSleep", value);
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void FaintWorker(float value)
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setConsciousness", value);
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void SetWorkerHunger(float value)
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setHunger", value);
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void ToggleInvurnelability()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("toggleInvulnerability", 0f);
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void ToggleAllSettlerInvurnelability()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("toggleInvulnerability", float.MaxValue);
			EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_toggle_invurnelability_" + CommandArgument("toggleInvulnerability"), "dev_tooltip_toggle_invurnelability_all");
		}

		private void SetHealth(float value)
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setHealth", value);
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void SetFreshness(float value)
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setFreshness", value);
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void FillStorage()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("fillStorage");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void RemoveWorker()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("removeWorker");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void WoundWorker(Action callback)
		{
			BackButtonAction(Reset);
			AddSubgroup("dev_inflict_wound");
			foreach (StatEffectorWound woundType in Repository<WoundsRepository, StatEffectorWound>.Instance.GetAllItems())
			{
				if (woundType.LocKeys != null)
				{
					string text = LocKeyUtils.GetName(woundType.LocKeys);
					AddButton(text ?? "", string.Empty, "dev_tooltip_inflict_wound").onClick.AddListener(delegate
					{
						MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("woundWorker", new string[1] { woundType.GetID() });
						MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
					});
				}
			}
			AddSpacer();
			callback();
		}

		private void VoxelInfo()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("voxelInfo");
			if (CommandArgument("voxelInfo") == "on")
			{
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			}
		}

		private void ToggleWaterDebugUI()
		{
			WaterDebugUI.ToggleActive();
			if (WaterDebugUI.IsDebugUIEnabled)
			{
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			}
		}

		private void DamageVoxel()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("damageVoxel");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void WeatherDebugView()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("toggleWeatherView");
			if (CommandArgument("toggleWeatherView") == "on")
			{
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			}
		}

		private void DateTimeDebug(Action callback)
		{
			AddSubgroup("Seasons");
			foreach (SeasonDebugConfig config in Repository<SeasonDebugConfigRepository, SeasonDebugConfig>.Instance.GetAllItems())
			{
				AddButton("Set " + config.GetID(), "setSeason", "dev_tooltip_set_season").GetComponent<SoundButton>().onClick.AddListener(delegate
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setSeason", new string[2]
					{
						config.Index.ToString(),
						config.DaysInPercent.ToString("0.00")
					});
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				});
			}
			AddSubgroup("Day Time");
			foreach (DayTimeDebugConfig config2 in Repository<DayTimeDebugConfigRepository, DayTimeDebugConfig>.Instance.GetAllItems())
			{
				AddButton("Set " + config2.GetID(), "setTimeInDay", "dev_tooltip_set_time_of_day").GetComponent<SoundButton>().onClick.AddListener(delegate
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setTimeInDay", new string[1] { config2.Percent.ToString("0.00") });
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				});
			}
			AddSubgroup("Weather");
			foreach (WeatherEvent eventType in Repository<WeatherEventRepository, WeatherEvent>.Instance.GetAllItems())
			{
				AddButton("Set " + eventType.GetID(), "setWeatherEvent", "dev_tooltip_set_weather_event").GetComponent<SoundButton>().onClick.AddListener(delegate
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setWeatherEvent", new string[1] { eventType.GetID() });
					MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
				});
			}
			BackButtonAction(Reset);
			callback();
		}

		private void InstantDig()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("toggleinstantdig");
			if (CommandArgument("toggleinstantdig") == "on")
			{
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			}
		}

		private void KillAllEnemies()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("killEnemies");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void TogglePlayerVoxelInfo()
		{
			PlayerVoxelInfo.ShowInfo = !PlayerVoxelInfo.ShowInfo;
			OutlinePostProcess.Instance.ShowHoverFill = !OutlinePostProcess.Instance.ShowHoverFill;
			if (PlayerVoxelInfo.ShowInfo)
			{
				MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
			}
		}

		private void SecondMapTimer()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("commandDisableSecondMapTimer");
			EventSystem.current.currentSelectedGameObject.GetComponent<DeveloperToggle>().SetupButton("dev_second_map_timer_" + CommandArgument("commandDisableSecondMapTimer"), "dev_tooltip_second_map_timer");
		}

		private void KillPlants()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("killPlants");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void PlantNextPhase()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("plantNextPhase");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void CropNextPhase()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("cropNextPhase");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void SetLowFuel()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setLowFuel");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void SpawnTrebuchet()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnTrebuchet");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void KillAllAnimals()
		{
			foreach (AnimalInstance item in new List<AnimalInstance>(GlobalSaveController.CurrentVillageData.Animals))
			{
				item.Stats?.GetStat(StatType.Health)?.SetCurrent(0f);
			}
		}

		private void KillAllFish()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("killAllFish");
		}

		private void DealDamage()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("dealDamage", 15f);
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void LadderFalldown()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("ladderFalldown");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void ResetWorkers()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("resetWorkers");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void SetWorkerMood(int value)
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("changeWorkerMood", value);
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void StartWorkerBattleRoyale()
		{
		}

		private void SpawnWorker(int amount)
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("spawnWorker", new string[1] { amount.ToString() });
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void MarkForRoping()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("markForRoping");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void SetAsDomestic()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setDomesticAnimal");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void SetAsPet()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setPetAnimal");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void SetAsWild()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setWildAnimal");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void SetAsWildAggressive()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setWildAggressiveAnimal");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void SetPregnantAnimal()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("setPregnantAnimal");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void GiveBirth()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("giveBirth");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void FinishAnimalProduction()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("finishAnimalProduction");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void ResetAnimalTamingAndTrainingCounters()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("resetTamingAndTraining");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void TriggerTrap()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("triggerTrap");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void ResetTrap()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("resetTrap");
			MonoSingleton<DeveloperToolsView>.Instance.CloseDevToolsPanel();
		}

		private void Start()
		{
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
			refreshSearchButton.onClick.AddListener(RefreshSearch);
		}

		private void OnDestroy()
		{
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
				refreshSearchButton.onClick.RemoveAllListeners();
			}
		}

		private void OnTick(float deltaTime)
		{
			if (base.gameObject.activeInHierarchy)
			{
				if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && searchInputField.text != string.Empty)
				{
					SearchButtons(searchInputField.text.ToLower());
					searchInputField.Select();
					searchInputField.ActivateInputField();
				}
				else if (Input.GetKeyDown(KeyCode.Escape) && searchInputField.text != string.Empty)
				{
					RefreshSearch();
				}
			}
		}

		private void RefreshSearch()
		{
			ClearSearchInputField();
			foreach (KeyValuePair<string, DeveloperActionButton> button in buttons)
			{
				button.Value.SetActive(active: true);
			}
			foreach (KeyValuePair<string, DeveloperToggle> toggle in toggles)
			{
				toggle.Value.SetActive(active: true);
			}
		}

		private void ClearSearchInputField()
		{
			searchInputField.Select();
			searchInputField.ActivateInputField();
			searchInputField.text = string.Empty;
		}

		private void SearchButtons(string keyword)
		{
			foreach (KeyValuePair<string, DeveloperActionButton> button in buttons)
			{
				button.Value.SetActive(button.Key.Contains(keyword));
			}
			foreach (KeyValuePair<string, DeveloperToggle> toggle in toggles)
			{
				toggle.Value.SetActive(toggle.Key.Contains(keyword));
			}
		}

		private DeveloperToggle AddToggle(string name, string consoleCommand, string tooltip = null, bool startingValue = false, bool interactible = true, bool ignoreBySearch = false)
		{
			if (consoleCommand != string.Empty && tooltip == null)
			{
				tooltip = CommandDescription(consoleCommand);
			}
			GameObject gameObject = DevPool.Spawn(toggleButtonPrefab);
			if (gameObject.GetComponent<DeveloperToggle>() == null)
			{
				gameObject.AddComponent<DeveloperToggle>();
			}
			DeveloperToggle component = gameObject.GetComponent<DeveloperToggle>();
			component.SetupButton(name, tooltip);
			component.ToggleImage(startingValue);
			string text = component.GetComponentInChildren<TextMeshProUGUI>().text;
			menuItems.Add(component.gameObject);
			if (!ignoreBySearch)
			{
				toggles.Add(new KeyValuePair<string, DeveloperToggle>(text.ToLower(), component));
			}
			component.onClick.AddListener(delegate
			{
				MonoSingleton<BugReporterManager>.Instance.IsDevConsoleOpened = true;
			});
			component.interactable = interactible;
			return component;
		}

		private DeveloperActionButton AddButton(string name, string consoleCommand, string tooltip = null, bool isSubMenuButton = false)
		{
			if (consoleCommand != string.Empty && tooltip == null)
			{
				tooltip = CommandDescription(consoleCommand);
			}
			GameObject gameObject = DevPool.Spawn(isSubMenuButton ? submenuButtonPrefab : buttonPrefab);
			if (gameObject.GetComponent<DeveloperActionButton>() == null)
			{
				gameObject.AddComponent<DeveloperActionButton>();
			}
			DeveloperActionButton component = gameObject.GetComponent<DeveloperActionButton>();
			component.SetupButton(name, tooltip);
			string text = component.GetComponentInChildren<TextMeshProUGUI>().text;
			menuItems.Add(component.gameObject);
			buttons.Add(new KeyValuePair<string, DeveloperActionButton>(text.ToLower(), component));
			component.onClick.AddListener(delegate
			{
				MonoSingleton<BugReporterManager>.Instance.IsDevConsoleOpened = true;
			});
			return component;
		}

		private DeveloperDropdown AddDropdown(string name, string[] options, Action onChangedCallback)
		{
			AddSubgroup(name);
			DeveloperDropdown component = DevPool.Spawn(dropdownPrefab).GetComponent<DeveloperDropdown>();
			component.SetupChoices(options, onChangedCallback);
			menuItems.Add(component.gameObject);
			return component;
		}

		private void FlushMenuItems(Action callback)
		{
			foreach (GameObject menuItem in menuItems)
			{
				if (menuItem != null)
				{
					if ((bool)menuItem.GetComponent<DeveloperActionButton>())
					{
						menuItem.GetComponent<DeveloperActionButton>().ResetButton();
					}
					if ((bool)menuItem.GetComponent<DeveloperToggle>())
					{
						menuItem.GetComponent<DeveloperToggle>().ResetButton();
					}
					menuItem.transform.SetParent(base.transform);
					DevPool.DeSpawn(menuItem);
				}
			}
			menuItems.Clear();
			buttons.Clear();
			toggles.Clear();
			ClearSearchInputField();
			callback();
		}

		private GameObject AddSubgroup(string title)
		{
			GameObject gameObject = DevPool.Spawn(subgroupPrefab);
			menuItems.Add(gameObject);
			gameObject.GetComponentInChildren<Localize>().SetTerm(title);
			return gameObject;
		}

		private void AddSpacer()
		{
			menuItems.Add(DevPool.Spawn(spacerPrefab));
		}

		private void BackButtonAction(Action callback)
		{
			MonoSingleton<DeveloperToolsView>.Instance.SetBackButton(callback);
		}

		private void ReparentMenuItems()
		{
			menuItems.RemoveAll((GameObject item) => item == null);
			foreach (GameObject menuItem in menuItems)
			{
				menuItem.transform.SetParent(contentParent.transform, worldPositionStays: false);
			}
		}

		private string CommandDescription(string consoleCommand)
		{
			if (MonoSingleton<DeveloperConsoleController>.Instance.GetCommand(consoleCommand) != null)
			{
				return MonoSingleton<DeveloperConsoleController>.Instance.GetCommand(consoleCommand).Description;
			}
			return consoleCommand;
		}

		private string CommandArgument(string consoleCommand)
		{
			if (MonoSingleton<DeveloperConsoleController>.Instance.GetCommand(consoleCommand) != null)
			{
				return MonoSingleton<DeveloperConsoleController>.Instance.GetCommand(consoleCommand).Argument;
			}
			return consoleCommand;
		}
	}
}
