using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Types;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class RoofsTutorialStep : TutorialStep
	{
		private const int RoofGridLenght = 7;

		private const int TotalRoofsCount = 49;

		private readonly IntRange roofPositionRangeX;

		private readonly IntRange roofPositionRangeZ;

		private Vec3Int Start => new Vec3Int(roofPositionRangeX.Min, 18, roofPositionRangeZ.Min);

		private Vec3Int End => new Vec3Int(roofPositionRangeX.Max, 18, roofPositionRangeZ.Max);

		public RoofsTutorialStep(string name, string info)
			: base(name, info)
		{
			roofPositionRangeX = new IntRange(BasePositionRangeX.Min - 1, BasePositionRangeX.Max + 1);
			roofPositionRangeZ = new IntRange(BasePositionRangeZ.Min - 1, BasePositionRangeZ.Max + 1);
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_open_build_base"),
				new TutorialStepTask("tut_select_build_roof"),
				new TutorialStepTask("tut_drag_place_roofs"),
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
			CheckBuiltRoofs();
		}

		private void OnShowConstructionCategory(BuildingCategoryUI category)
		{
			if (category == BuildingCategoryUI.Base)
			{
				CompleteTask(0);
				MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetCategoriesInteractable(new HashSet<string> { "hay_roof_whole" }, interactable: true);
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.GetSubcategoryTransform("hay_roof_whole"));
				});
			}
		}

		private void OnChangeBuildingToPlace()
		{
			CompleteTask(1);
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent -= OnShowConstructionCategory;
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetSubCategoriesInteractable(new HashSet<string> { "hay_roof_whole" }, interactable: true);
			ShowMarkersAndPointers(Start, End, Vector3.up, hideIfTargetOnscreen: true);
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent -= OnChangeBuildingToPlace;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlaced;
		}

		private void OnBlueprintPlaced(BaseBuildingInstance buildingInstance)
		{
			if (buildingInstance.BlueprintId != "hay_roof_whole")
			{
				Log.Error("OnBlueprintPlaced called with invalid blueprint id", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\RoofsTutorialStep.cs");
				return;
			}
			foreach (Vec3Int position in buildingInstance.Positions)
			{
				if (!IsInsideAllowedArea(position))
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\RoofsTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(position);
						messageBuilder.AppendLiteral(" Outside Allowed");
					}
					Log.Trace(messageBuilder);
					ShowOptimizedBlackBarMessage("tutorial_wrong_construction_position");
					MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
					{
						buildingInstance.Map.BuildingsManagerMain.DestroyBuilding(buildingInstance);
					});
					return;
				}
				int num = roofPositionRangeX.Max - roofPositionRangeX.Min + 1;
				if (buildingInstance.Positions.Count != num)
				{
					ShowOptimizedBlackBarMessage("tutorial_wrong_roof_size", new object[1] { 7 });
					MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
					{
						buildingInstance.Map.BuildingsManagerMain.DestroyBuilding(buildingInstance);
					});
					return;
				}
			}
			Log.Trace("Inside Allowed", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\RoofsTutorialStep.cs");
			CheckPlacedBlueprints();
		}

		private void CheckPlacedBlueprints()
		{
			Dictionary<Vec3Int, BaseBuildingInstance> dictionary = base.BuildingsManagerMain.TypePositionInstanceDictionary[BuildingType.Roof];
			if (dictionary == null || dictionary.Keys.Count == 0)
			{
				return;
			}
			float num = 0f;
			foreach (KeyValuePair<Vec3Int, BaseBuildingInstance> item in dictionary)
			{
				if (item.Value != null && IsInsideAllowedArea(item.Key))
				{
					num += 1f;
				}
			}
			float num2 = num / 49f;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(14, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\RoofsTutorialStep.cs");
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

		private void CheckBuiltRoofs()
		{
			Dictionary<Vec3Int, BaseBuildingInstance> dictionary = base.BuildingsManagerMain.TypePositionInstanceDictionary[BuildingType.Roof];
			if (dictionary == null || dictionary.Keys.Count == 0)
			{
				return;
			}
			float num = 0f;
			foreach (KeyValuePair<Vec3Int, BaseBuildingInstance> item in dictionary)
			{
				if (item.Value != null && IsInsideAllowedArea(item.Key) && item.Value.ConstructionPhase.Equals(ConstructionPhase.Finished))
				{
					num += 1f;
				}
			}
			float num2 = num / 49f;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(12, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\RoofsTutorialStep.cs");
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
				Log.Debug("Step Finished", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\RoofsTutorialStep.cs");
			}
		}

		private bool IsInsideAllowedArea(Vec3Int position)
		{
			for (int i = roofPositionRangeX.Min; i <= roofPositionRangeX.Max; i++)
			{
				for (int j = roofPositionRangeZ.Min; j <= roofPositionRangeZ.Max; j++)
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
