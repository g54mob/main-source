using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Managers.Selection;
using NSMedieval.Types;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class DoorTutorialStep : TutorialStep
	{
		private Vec3Int doorPosition = new Vec3Int(101, 5, 94);

		private BaseBuildingInstance lastWallDestroyed;

		public DoorTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_open_build_base"),
				new TutorialStepTask("tut_select_build_door"),
				new TutorialStepTask("tut_place_door"),
				new TutorialStepTask("tut_wait_to_build")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent += OnShowConstructionCategory;
			MonoSingleton<UIController>.Instance.ConstructionPanel.ClosePanelEvent += base.OnConstructionPanelClose;
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent += OnChangeBuildingToPlace;
			MonoSingleton<UIShowManager>.Instance.ShowConstruction();
			MonoSingleton<UIController>.Instance.ConstructionPanel.SetCategoriesInteractable(new HashSet<BuildingCategoryUI> { BuildingCategoryUI.Base }, interactable: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.GetCategoryTransform(BuildingCategoryUI.Base));
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructBase(allow: true);
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<SelectionManager>.Instance.DeselectTool();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.Hide();
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructBase(allow: false);
			MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
		}

		public override void Tick()
		{
			base.Tick();
			if (Tasks[2].IsComplete)
			{
				CheckAllBuildingsFinished();
			}
		}

		private void OnShowConstructionCategory(BuildingCategoryUI category)
		{
			if (category == BuildingCategoryUI.Base)
			{
				CompleteTask(0);
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetCategoriesInteractable(new HashSet<string> { "wood_door" }, interactable: true);
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.GetSubcategoryTransform("wood_door"));
				});
			}
		}

		private void OnChangeBuildingToPlace()
		{
			CompleteTask(1);
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent -= OnShowConstructionCategory;
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetSubCategoriesInteractable(new HashSet<string> { "wood_door" }, interactable: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowVolumeMarker(new Vec3Int(doorPosition.x, 18, doorPosition.z));
			MonoSingleton<ScreenPointerManager>.Instance.AddTarget(GridUtils.GetWorldPosition(doorPosition), Vector3.up, hideIfTargetOnScreen: true);
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent -= OnChangeBuildingToPlace;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlaced;
			base.BuildingsManagerMain.BeforeBuildingDestroyedEvent += OnBeforeBuildingDestroyed;
		}

		private void OnBeforeBuildingDestroyed(BaseBuildingInstance baseBuildingInstance)
		{
			if (baseBuildingInstance.BuildingType == BuildingType.Wall)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DoorTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Wall about to be destroyed at ");
					messageBuilder.AppendFormatted(baseBuildingInstance.Positions.FirstOrDefault());
				}
				Log.Debug(messageBuilder);
				lastWallDestroyed = baseBuildingInstance;
			}
		}

		private void OnBlueprintPlaced(BaseBuildingInstance buildingInstance)
		{
			if (buildingInstance.BlueprintId != "wood_door")
			{
				return;
			}
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(15, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DoorTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Door placed at ");
				messageBuilder.AppendFormatted(buildingInstance.Positions.FirstOrDefault());
			}
			Log.Trace(messageBuilder);
			foreach (Vec3Int position2 in buildingInstance.Positions)
			{
				Vec3Int position = position2;
				if (position != doorPosition)
				{
					messageBuilder = new FVLogTraceInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DoorTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(position.ToString());
						messageBuilder.AppendLiteral(" Outside Allowed");
					}
					Log.Trace(messageBuilder);
					ShowOptimizedBlackBarMessage("tutorial_wrong_construction_position");
					MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
					{
						buildingInstance.Map.BuildingsManagerMain.DestroyBuilding(buildingInstance);
						if (lastWallDestroyed != null)
						{
							MonoSingleton<BuildingPlacementManager>.Instance.SpawnBlueprint(lastWallDestroyed.Blueprint, position);
							MonoSingleton<BuildingPlacementManager>.Instance.InitializeBuilding("wood_door");
							lastWallDestroyed = null;
						}
					});
					return;
				}
				messageBuilder = new FVLogTraceInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DoorTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(position.ToString());
					messageBuilder.AppendLiteral(" Inside Allowed");
				}
				Log.Trace(messageBuilder);
			}
			LockAllBuildingTypes();
			ForceUnpauseAndAllowTimeControls();
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				DeselectAllDelayed();
				LockAllBuildingTypes();
				MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
				MonoSingleton<ScreenPointerManager>.Instance.TryRemoveTarget(GridUtils.GetWorldPosition(doorPosition));
				CompleteTask(2);
			});
		}

		private void CheckAllBuildingsFinished()
		{
			float num = 0f;
			float num2 = 0f;
			foreach (Dictionary<BaseBuildingInstance, BaseBuildingViewComponent> value in base.BuildingsManagerMain.TypeInstanceView.Values)
			{
				foreach (BaseBuildingInstance key in value.Keys)
				{
					if (key != null)
					{
						num += 1f;
						if (key.ConstructionPhase == ConstructionPhase.Finished)
						{
							num2 += 1f;
						}
					}
				}
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(33, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DoorTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Complete ");
				messageBuilder.AppendFormatted(num2);
				messageBuilder.AppendLiteral(" of ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(" building instances ");
				messageBuilder.AppendFormatted(num2 / num, "P1");
			}
			Log.Trace(messageBuilder);
			UpdateTaskCompletion(3, num2 / num);
		}
	}
}
