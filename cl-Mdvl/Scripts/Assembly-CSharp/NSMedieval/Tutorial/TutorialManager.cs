using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class TutorialManager : MonoSingleton<TutorialManager>
	{
		[SerializeField]
		private TutorialDebugStart tutorialDebugStart;

		private const string StartSave = "Start.sav";

		private readonly List<TutorialStep> tutorialSteps = new List<TutorialStep>();

		private readonly HashSet<int> noStatsUpdateWorkers = new HashSet<int>();

		private List<string> steps = new List<string>();

		public static bool IsTutorialActive
		{
			get
			{
				if (MonoSingleton<TutorialManager>.IsInstantiated())
				{
					return MonoSingleton<TutorialManager>.Instance.IsTutorialInProgress;
				}
				return false;
			}
		}

		public bool IsTutorialInProgress { get; private set; }

		public bool PreventWorldTimeTick { get; set; }

		public bool CanSelect { get; private set; }

		public bool AllowCreatureCommands { get; private set; }

		public bool AllowAdditionalMenu { get; private set; }

		public bool AllowOrdersPanel { get; private set; }

		public List<TutorialStep> TutorialSteps => tutorialSteps;

		public bool BlockStatUpdate(IStatsOwner statsOwner)
		{
			if (!(statsOwner is HumanoidInstance humanoidInstance))
			{
				return false;
			}
			if (humanoidInstance.WorkerBehaviour == null)
			{
				return false;
			}
			if (noStatsUpdateWorkers.Add(humanoidInstance.UniqueId))
			{
				return false;
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(26, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Blocked Stats Update for: ");
				messageBuilder.AppendFormatted(humanoidInstance);
			}
			Log.Debug(messageBuilder);
			return true;
		}

		public void HandleSelection(bool canSelect)
		{
			CanSelect = canSelect;
		}

		public void HandleCreatureCommands(bool allow)
		{
			AllowCreatureCommands = allow;
		}

		public void HandleAdditionalMenu(bool allow)
		{
			AllowAdditionalMenu = allow;
		}

		public void HandleOrdersPanel(bool allow)
		{
			AllowOrdersPanel = allow;
		}

		public void LoadTutorial()
		{
			IsTutorialInProgress = true;
			HandleSelection(canSelect: true);
			HandleOrdersPanel(allow: true);
			InitSteps();
			LoadMainSceneDelayed();
		}

		private void LoadMainSceneDelayed()
		{
			MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: true);
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.3f).Then(Load);
		}

		private void Load()
		{
			if (!MonoSingleton<GlobalSaveController>.Instance.LoadTutorialVillageData("Start.sav"))
			{
				IsTutorialInProgress = false;
				MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: false);
				Log.Error("Couldn't load Start.sav", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialManager.cs");
			}
			else
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(MonoSingleton<AddressableSceneLoadingManager>.Instance.LoadMainScene);
			}
		}

		private void InitSteps()
		{
			tutorialSteps.Add(new StartTutorialStep("tut_start_title", "tut_start_info"));
			tutorialSteps.Add(new CameraTutorialStep("tut_camera_title", "tut_camera_info"));
			tutorialSteps.Add(new TimeControlsTutorialStep("tut_time_controls_title", "tut_time_controls_info"));
			tutorialSteps.Add(new StockpileTutorialStep("tut_stockpile_title", "tut_stockpile_info"));
			tutorialSteps.Add(new AllowTutorialStep("tut_allow_name", "tut_allow_info"));
			tutorialSteps.Add(new WallsTutorialStep("tut_walls_name", "tut_walls_info"));
			tutorialSteps.Add(new DoorTutorialStep("tut_door_name", "tut_door_info"));
			tutorialSteps.Add(new FloorsTutorialStep("tut_floor_name", "tut_floor_info"));
			tutorialSteps.Add(new RoofsTutorialStep("tut_roof_name", "tut_roof_info"));
			tutorialSteps.Add(new PlaceBedsTutorialStep("tut_beds_name", "tut_beds_info"));
			tutorialSteps.Add(new ForageTutorialStep("tut_forage_name", "tut_forage_info"));
			tutorialSteps.Add(new CampFireTutorialStep("tut_campfire_name", "tut_campfire_info"));
			tutorialSteps.Add(new ProductionTutorialStep("tut_production_name", "tut_production_info"));
			tutorialSteps.Add(new ResearchTableTutorialStep("tut_research_table_name", "tut_research_table_info"));
			tutorialSteps.Add(new JobsTutorialStep("tut_jobs_name", "tut_jobs_info"));
			tutorialSteps.Add(new ProduceBooksTutorialStep("tut_produce_books_name", "tut_produce_books_info"));
			tutorialSteps.Add(new ResearchTutorialStep("tut_research_name", "tut_research_info"));
			tutorialSteps.Add(new ProtectStockpileTutorialStep("tut_protect_stockpile_name", "tut_protect_stockpile_info"));
			tutorialSteps.Add(new LayersTutorialStep("tut_layers_name", "tut_layers_info"));
			tutorialSteps.Add(new DiggingTutorialStep("tut_digging_name", "tut_digging_info"));
			tutorialSteps.Add(new LaddersTutorialStep("tut_ladders_name", "tut_ladders_info"));
			tutorialSteps.Add(new EquipTutorialStep("tut_equip_name", "tut_equip_info"));
			tutorialSteps.Add(new DefenseStructuresTutorialStep("tut_defense_name", "tut_defense_info"));
			tutorialSteps.Add(new DraftingTutorialStep("tut_drafting_name", "tut_drafting_info"));
			tutorialSteps.Add(new RaidTutorialStep("tut_raid_name", "tut_raid_info"));
			tutorialSteps.Add(new FinalTutorialStep("tut_final_name", "tut_final_info"));
		}

		protected override void Awake()
		{
			base.Awake();
			IsTutorialInProgress = false;
		}

		private void Start()
		{
			MonoSingleton<LoadingController>.Instance.HomeSceneLoadedEvent += OnHomeSceneLoaded;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("this.tutorialDebugStart == null: ");
				messageBuilder.AppendFormatted(tutorialDebugStart == null);
			}
			Log.Trace(messageBuilder);
			if (tutorialDebugStart == null)
			{
				Log.Warning("TutorialDebugStart reference is null.", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialManager.cs");
				tutorialDebugStart = Object.FindObjectOfType<TutorialDebugStart>();
			}
			if (tutorialDebugStart == null)
			{
				Log.Error("TutorialDebugStart component not found in scene. Debug menu unavailable.", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialManager.cs");
			}
		}

		private void OnHomeSceneLoaded()
		{
			IsTutorialInProgress = false;
			tutorialSteps.Clear();
		}
	}
}
