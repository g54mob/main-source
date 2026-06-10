using System;
using System.Collections.Generic;
using System.Linq;
using Controller;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Testing.Autoplay;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public abstract class TutorialStep
	{
		protected const int YDefaultWorldPosition = 15;

		protected const int YDefaultGroundPosition = 5;

		protected const string WoodDoor = "wood_door";

		protected const string WoodWall = "wood_wall_element";

		protected const string WoodFloor = "wood_floor";

		protected const string HayRoofWhole = "hay_roof_whole";

		protected const string WoodBeam = "wood_beam";

		protected const string WoodLadder = "wood_ladder";

		protected const string WoodMerlon = "wood_merlon";

		protected const string CampFireBlueprintName = "camp_fire";

		protected const float DefaultLayer = 8f;

		private static readonly Vector3 DefaultCameraPosition = new Vector3(104.6f, 15.6f, 97.6f);

		private const float DefaultCameraHeight = 61.5f;

		private const float DefaultCameraRotation = -245.2f;

		private const float DefaultCameraTilt = 35.6f;

		protected readonly IntRange BasePositionRangeX = new IntRange(102, 106);

		protected readonly IntRange BasePositionRangeZ = new IntRange(92, 96);

		protected readonly IntRange StockpilePositionRangeX = new IntRange(92, 96);

		protected readonly IntRange StockpilePositionRangeZ = new IntRange(92, 96);

		protected readonly HashSet<string> StashedResourceIds = new HashSet<string> { "good_wood_short_bow", "good_wood_light_crossbow", "good_wood_spear" };

		private readonly string name;

		private readonly string info;

		public bool IsComplete;

		public bool IsActive;

		public List<TutorialStepTask> Tasks;

		public List<KeyInputEvent> AllowedKeyInputs { get; protected set; }

		public List<KeyInputEvent> BlockedKeyInputs { get; protected set; }

		protected VillageMap ActiveVillageMap => VillageManager.ActiveVillage.Map;

		protected BuildingsManagerMain BuildingsManagerMain => ActiveVillageMap.BuildingsManagerMain;

		protected Vec3Int InsideAreaStart => new Vec3Int(BasePositionRangeX.Min, 15, BasePositionRangeZ.Min);

		protected Vec3Int InsideAreaEnd => new Vec3Int(BasePositionRangeX.Max, 15, BasePositionRangeZ.Max);

		public event Action StepCompleteEvent;

		protected static void CameraJumpToDefault(bool immediate = false)
		{
			if (immediate)
			{
				MonoSingleton<RtsCamera>.Instance.SetCameraDirect(DefaultCameraPosition, 61.5f, -245.2f, 35.6f);
			}
			else
			{
				MonoSingleton<RtsCamera>.Instance.SetCameraJump(DefaultCameraPosition, 61.5f, -245.2f, 35.6f);
			}
		}

		protected TutorialStep(string name, string info)
		{
			this.name = name;
			this.info = info;
			AllowedKeyInputs = new List<KeyInputEvent>();
			BlockedKeyInputs = new List<KeyInputEvent>();
		}

		public virtual void BeginStep()
		{
			DeselectAll();
			if (Tasks.Count > 0)
			{
				Tasks[0].SetActive(active: true);
			}
			MonoSingleton<SelectableObjectController>.Instance.DeselectAllEvent += OnDeselectAll;
		}

		protected virtual void CompleteStep()
		{
			IsComplete = true;
			DeselectAllDelayed();
			MonoSingleton<SelectableObjectController>.Instance.DeselectAllEvent -= OnDeselectAll;
			this.StepCompleteEvent?.Invoke();
		}

		protected void ShowOptimizedBlackBarMessage(string messageKey, object[] args = null)
		{
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, messageKey, delegate
			{
				if (args != null)
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(string.Format(messageKey.ToLocalized(), args));
				}
				else
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(messageKey.ToLocalized());
				}
			}, 0.1f);
		}

		public virtual void Tick()
		{
			if (!IsComplete && Tasks.Count((TutorialStepTask task) => task.IsComplete) == Tasks.Count)
			{
				CompleteStep();
			}
		}

		public string GetName()
		{
			return MonoSingleton<LocalizationController>.Instance.GetText(name) ?? "";
		}

		public string GetStepCounter()
		{
			int num = MonoSingleton<TutorialStepManager>.Instance.CurrentIndex + 1;
			int num2 = MonoSingleton<TutorialStepManager>.Instance.TotalSteps - 1;
			if (num <= num2)
			{
				return string.Format("{0} {1}/{2}", "general_step".ToLocalized(), num, MonoSingleton<TutorialStepManager>.Instance.TotalSteps - 1);
			}
			return string.Empty;
		}

		public string GetInfo()
		{
			return MonoSingleton<LocalizationController>.Instance.GetText(info);
		}

		private void OnDeselectAll()
		{
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
		}

		protected void UpdateTaskCompletion(int index, float percentComplete)
		{
			if (percentComplete >= 1f)
			{
				CompleteTask(index);
			}
			else
			{
				Tasks[index].UpdateCompletion(percentComplete);
			}
		}

		protected void CompleteTask(int index)
		{
			Tasks[index].UpdateCompletion(1f);
			if (Tasks.Count >= index + 2)
			{
				Tasks[index + 1].SetActive(active: true);
			}
		}

		protected void LockAllBuildingTypes()
		{
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.Hide();
			MonoSingleton<UIController>.Instance.ConstructionPanel.SetCategoriesInteractable(new HashSet<BuildingCategoryUI>(), interactable: true);
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetCategoriesInteractable(new HashSet<string>(), interactable: true);
		}

		protected void DeselectAllDelayed()
		{
			Log.Trace("DeselectAll in next frame", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialStep.cs");
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(DeselectAll);
		}

		protected void DeselectAll()
		{
			if (!LoadingController.IsLeavingMainScene)
			{
				MonoSingleton<SelectionManager>.Instance.DeselectTool();
				MonoSingleton<SelectableObjectManager>.Instance.DeselectAll();
				MonoSingleton<BuildingPlacementManager>.Instance.CancelSelection(resetCancelPlacement: true);
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.Hide();
			}
		}

		protected void BuildItems(List<BuildingItem> buildItems, bool autoConstruct = false)
		{
			MonoSingleton<BuildingPlacementManager>.Instance.Autoconstruct = autoConstruct;
			foreach (BuildingItem buildItem in buildItems)
			{
				MonoSingleton<BuildingPlacementManager>.Instance.SpawnBlueprint(buildItem.Blueprint, buildItem.Position, buildItem.Angle);
			}
			MonoSingleton<BuildingPlacementManager>.Instance.Autoconstruct = false;
		}

		protected bool IsInsideAllowedArea(Vec3Int position, Vec3Int areaStart, Vec3Int areaEnd)
		{
			for (int i = areaStart.x; i <= areaEnd.x; i++)
			{
				for (int j = areaStart.z; j <= areaEnd.z; j++)
				{
					if (position.x == i && position.z == j)
					{
						return true;
					}
				}
			}
			return false;
		}

		protected void HandleInvalidBlueprintPlacement(BaseBuildingInstance buildingInstance)
		{
			ShowOptimizedBlackBarMessage("tutorial_wrong_construction_position");
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				buildingInstance.Map.BuildingsManagerMain.DestroyBuilding(buildingInstance);
			});
		}

		protected void ShowMarkersAndPointers(Vec3Int start, Vec3Int end, Vector3 offset, bool hideIfTargetOnscreen = false)
		{
			MonoSingleton<TutorialViewManager>.Instance.ShowMarker(start, end);
			ShowScreenPointerTarget(start, end, offset, hideIfTargetOnscreen);
		}

		protected void ShowScreenPointerTarget(Vec3Int start, Vec3Int end, Vector3 offset, bool hideIfTargetOnscreen = false)
		{
			MonoSingleton<ScreenPointerManager>.Instance.AddTarget(GetWorldPositionCenter(start, end), offset, hideIfTargetOnscreen);
		}

		protected void HideMarkersAndPointers(Vec3Int start, Vec3Int end)
		{
			MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
			HideScreenPointerTarget(start, end);
		}

		protected void HideScreenPointerTarget(Vec3Int start, Vec3Int end)
		{
			MonoSingleton<ScreenPointerManager>.Instance.TryRemoveTarget(GetWorldPositionCenter(start, end));
		}

		private static Vector3 GetWorldPositionCenter(Vec3Int start, Vec3Int end)
		{
			Vec3Int vec3Int = new Vec3Int((start.x + end.x) / 2, start.y / World.MapBlockHeight, (start.z + end.z) / 2);
			Vector3 worldPosition = GridUtils.GetWorldPosition(vec3Int);
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(3, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(start);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(end);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(worldPosition);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(vec3Int);
			}
			Log.Debug(messageBuilder);
			return worldPosition;
		}

		protected void Pause()
		{
			MonoSingleton<GameplayPauseManager>.Instance.Register(MonoSingleton<GameSpeedManager>.Instance);
			ShowOptimizedBlackBarMessage("tutorial_game_paused");
		}

		protected void ForcePause()
		{
			MonoSingleton<GameplayPauseManager>.Instance.ForcePause();
			MonoSingleton<UIShowManager>.Instance.HideTimeControls();
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowTimeControls(allow: false);
			ShowOptimizedBlackBarMessage("tutorial_game_paused");
		}

		protected void ForceUnpauseAndAllowTimeControls()
		{
			ForceUnpause();
			MonoSingleton<UIShowManager>.Instance.ShowTimeControls();
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowTimeControls(allow: true);
		}

		protected void ForceUnpause()
		{
			MonoSingleton<GameplayPauseManager>.Instance.ForceUnpause();
			ShowOptimizedBlackBarMessage("tutorial_game_unpaused");
		}

		protected void OnConstructionPanelClose()
		{
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
		}
	}
}
