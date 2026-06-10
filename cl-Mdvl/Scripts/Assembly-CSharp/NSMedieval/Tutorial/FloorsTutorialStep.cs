using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Types;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class FloorsTutorialStep : TutorialStep
	{
		private const int TotalFloorsCount = 25;

		private Vec3Int Start => new Vec3Int(BasePositionRangeX.Min, 15, BasePositionRangeZ.Min);

		private Vec3Int End => new Vec3Int(BasePositionRangeX.Max, 15, BasePositionRangeZ.Max);

		public FloorsTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_open_build_base"),
				new TutorialStepTask("tut_select_build_floor"),
				new TutorialStepTask("tut_drag_place_floors"),
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
			DeselectAllDelayed();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.Hide();
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructBase(allow: false);
			MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnBlueprintPlaced;
		}

		public override void Tick()
		{
			base.Tick();
			CheckBuiltFloors();
		}

		private void OnShowConstructionCategory(BuildingCategoryUI category)
		{
			if (category == BuildingCategoryUI.Base)
			{
				CompleteTask(0);
				MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetCategoriesInteractable(new HashSet<string> { "wood_floor" }, interactable: true);
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.GetSubcategoryTransform("wood_floor"));
				});
			}
		}

		private void OnChangeBuildingToPlace()
		{
			CompleteTask(1);
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent -= OnShowConstructionCategory;
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetSubCategoriesInteractable(new HashSet<string> { "wood_floor" }, interactable: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowMarker(Start, End);
			ShowMarkersAndPointers(Start, End, Vector3.up, hideIfTargetOnscreen: true);
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent -= OnChangeBuildingToPlace;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlaced;
		}

		private void OnBlueprintPlaced(BaseBuildingInstance buildingInstance)
		{
			bool isEnabled;
			if (buildingInstance.BlueprintId != "wood_floor")
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(52, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\FloorsTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("OnBlueprintPlaced called with invalid blueprint id: ");
					messageBuilder.AppendFormatted(buildingInstance.BlueprintId);
				}
				Log.Error(messageBuilder);
				return;
			}
			Vec3Int position = buildingInstance.Positions.FirstOrDefault();
			FVLogTraceInterpolationHandler messageBuilder2;
			if (IsInsideAllowedFloorsArea(position))
			{
				messageBuilder2 = new FVLogTraceInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\FloorsTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(position.ToString());
					messageBuilder2.AppendLiteral(" Inside Allowed");
				}
				Log.Trace(messageBuilder2);
				CheckPlacedBlueprints();
				return;
			}
			messageBuilder2 = new FVLogTraceInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\FloorsTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendFormatted(position.ToString());
				messageBuilder2.AppendLiteral(" Outside Allowed");
			}
			Log.Trace(messageBuilder2);
			ShowOptimizedBlackBarMessage("tutorial_wrong_construction_position");
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				buildingInstance.Map.BuildingsManagerMain.DestroyBuilding(buildingInstance);
			});
		}

		private void CheckPlacedBlueprints()
		{
			Dictionary<Vec3Int, BaseBuildingInstance> dictionary = base.BuildingsManagerMain.TypePositionInstanceDictionary[BuildingType.Floor];
			if (dictionary == null || dictionary.Keys.Count == 0)
			{
				return;
			}
			float num = 0f;
			foreach (KeyValuePair<Vec3Int, BaseBuildingInstance> item in dictionary)
			{
				if (item.Value != null && IsInsideAllowedFloorsArea(item.Key))
				{
					num += 1f;
				}
			}
			float num2 = num / 25f;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(14, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\FloorsTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Blueprints: ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(": ");
				messageBuilder.AppendFormatted(num2, "P1");
			}
			Log.Trace(messageBuilder);
			UpdateTaskCompletion(2, num2);
			if (num2 >= 1f)
			{
				DeselectAllDelayed();
				LockAllBuildingTypes();
				HideMarkersAndPointers(Start, End);
			}
		}

		private void CheckBuiltFloors()
		{
			Dictionary<Vec3Int, BaseBuildingInstance> dictionary = base.BuildingsManagerMain.TypePositionInstanceDictionary[BuildingType.Floor];
			if (dictionary == null || dictionary.Keys.Count == 0)
			{
				return;
			}
			float num = 0f;
			foreach (KeyValuePair<Vec3Int, BaseBuildingInstance> item in dictionary)
			{
				if (item.Value != null && IsInsideAllowedFloorsArea(item.Key) && item.Value.ConstructionPhase.Equals(ConstructionPhase.Finished))
				{
					num += 1f;
				}
			}
			float num2 = num / 25f;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(12, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\FloorsTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Finished: ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(": ");
				messageBuilder.AppendFormatted(num2, "P1");
			}
			Log.Trace(messageBuilder);
			UpdateTaskCompletion(3, num2);
			if (num2 >= 1f)
			{
				Log.Debug("Step Finished", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\FloorsTutorialStep.cs");
			}
		}

		private bool IsInsideAllowedFloorsArea(Vec3Int position)
		{
			if (position.y != 5)
			{
				return false;
			}
			for (int i = BasePositionRangeX.Min; i <= BasePositionRangeX.Max; i++)
			{
				for (int j = BasePositionRangeZ.Min; j <= BasePositionRangeZ.Max; j++)
				{
					if (position.x == i && position.z == j)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
