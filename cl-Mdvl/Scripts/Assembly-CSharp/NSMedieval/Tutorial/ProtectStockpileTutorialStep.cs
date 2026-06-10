using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Types;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class ProtectStockpileTutorialStep : TutorialStep
	{
		private const int TotalFloorsCount = 25;

		private const int TotalWallsCount = 4;

		private const int TotalRoofsFinishedCount = 49;

		private const int TotalRoofBlueprintsCount = 7;

		private int wallBlueprints;

		private int beamBlueprints;

		private int floorBlueprints;

		private int roofBlueprints;

		private readonly HashSet<Vec3Int> wallPositions = new HashSet<Vec3Int>
		{
			new Vec3Int(97, 5, 97),
			new Vec3Int(97, 5, 91),
			new Vec3Int(91, 5, 97),
			new Vec3Int(91, 5, 91)
		};

		private readonly HashSet<Vec3Int> beamPositions = new HashSet<Vec3Int>
		{
			new Vec3Int(97, 5, 92),
			new Vec3Int(92, 5, 91),
			new Vec3Int(91, 5, 92),
			new Vec3Int(92, 5, 97)
		};

		private readonly Vec3Int[] beamMarkerPositions = new Vec3Int[8]
		{
			new Vec3Int(97, 5, 91),
			new Vec3Int(91, 5, 91),
			new Vec3Int(97, 5, 97),
			new Vec3Int(91, 5, 97),
			new Vec3Int(97, 5, 97),
			new Vec3Int(97, 5, 91),
			new Vec3Int(91, 5, 97),
			new Vec3Int(91, 5, 91)
		};

		private readonly IntRange roofPositionRangeX;

		private readonly IntRange roofPositionRangeZ;

		private Vec3Int RoofsStart => new Vec3Int(roofPositionRangeX.Min, 18, roofPositionRangeZ.Min);

		private Vec3Int RoofsEnd => new Vec3Int(roofPositionRangeX.Max, 18, roofPositionRangeZ.Max);

		private Vec3Int FloorsStart => new Vec3Int(StockpilePositionRangeX.Min, 15, StockpilePositionRangeZ.Min);

		private Vec3Int FloorsEnd => new Vec3Int(StockpilePositionRangeX.Max, 15, StockpilePositionRangeZ.Max);

		public ProtectStockpileTutorialStep(string name, string info)
			: base(name, info)
		{
			roofPositionRangeX = new IntRange(StockpilePositionRangeX.Min - 1, StockpilePositionRangeX.Max + 1);
			roofPositionRangeZ = new IntRange(StockpilePositionRangeZ.Min - 1, StockpilePositionRangeZ.Max + 1);
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_build_floors", new object[1] { 25 }),
				new TutorialStepTask("tut_build_walls", new object[1] { 4 }),
				new TutorialStepTask("tut_build_beams", new object[1] { 4 }),
				new TutorialStepTask("tut_build_roofs")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent += OnShowConstructionCategory;
			MonoSingleton<UIController>.Instance.ConstructionPanel.ClosePanelEvent += base.OnConstructionPanelClose;
			MonoSingleton<UIShowManager>.Instance.ShowConstruction();
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructBase(allow: true);
			MonoSingleton<UIController>.Instance.ConstructionPanel.SetCategoriesInteractable(new HashSet<BuildingCategoryUI> { BuildingCategoryUI.Base }, interactable: true);
			StartBuildFloorsTask();
		}

		protected override void CompleteStep()
		{
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructBase(allow: false);
			MonoSingleton<UIController>.Instance.ConstructionPanel.SetCategoriesInteractable(new HashSet<BuildingCategoryUI>(), interactable: true);
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent -= OnShowConstructionCategory;
			base.CompleteStep();
		}

		public override void Tick()
		{
			base.Tick();
			if (!Tasks[0].IsComplete)
			{
				CheckBuiltFloors();
			}
			else if (!Tasks[1].IsComplete)
			{
				CheckBuiltWalls();
			}
			else if (!Tasks[2].IsComplete)
			{
				CheckBuiltBeams();
			}
			else if (!Tasks[3].IsComplete)
			{
				CheckBuiltRoofs();
			}
		}

		private void OnShowConstructionCategory(BuildingCategoryUI obj)
		{
			if (!Tasks[0].IsComplete)
			{
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetCategoriesInteractable(new HashSet<string> { "wood_floor" }, interactable: true);
			}
			else if (!Tasks[1].IsComplete)
			{
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetCategoriesInteractable(new HashSet<string> { "wood_wall_element" }, interactable: true);
			}
			else if (!Tasks[2].IsComplete)
			{
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetCategoriesInteractable(new HashSet<string> { "wood_beam" }, interactable: true);
			}
			else if (!Tasks[3].IsComplete)
			{
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetCategoriesInteractable(new HashSet<string> { "hay_roof_whole" }, interactable: true);
			}
		}

		private void ShowScreenPointer(bool show)
		{
			if (show)
			{
				ShowScreenPointerTarget(RoofsStart, RoofsEnd, Vector3.zero, hideIfTargetOnscreen: true);
			}
			else
			{
				HideScreenPointerTarget(RoofsStart, RoofsEnd);
			}
		}

		private void StartBuildFloorsTask()
		{
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlacedFloors;
			ShowMarkersAndPointers(FloorsStart, FloorsEnd, Vector3.up, hideIfTargetOnscreen: true);
		}

		private void OnBlueprintPlacedFloors(BaseBuildingInstance buildingInstance)
		{
			bool isEnabled;
			if (buildingInstance.BlueprintId != "wood_floor")
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(52, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProtectStockpileTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("OnBlueprintPlaced called with invalid blueprint id: ");
					messageBuilder.AppendFormatted(buildingInstance.BlueprintId);
				}
				Log.Error(messageBuilder);
				return;
			}
			Vec3Int position = buildingInstance.Positions.FirstOrDefault();
			if (!IsInsideAllowedAreaFloors(position))
			{
				HandleInvalidBlueprintPlacement(buildingInstance);
				return;
			}
			floorBlueprints++;
			FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProtectStockpileTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Floor Blueprints: ");
				messageBuilder2.AppendFormatted(floorBlueprints);
				messageBuilder2.AppendLiteral(" / ");
				messageBuilder2.AppendFormatted(25);
			}
			Log.Debug(messageBuilder2);
			if (floorBlueprints == 25)
			{
				HideMarkersAndPointers(FloorsStart, FloorsEnd);
				DeselectAllDelayed();
			}
		}

		protected bool IsInsideAllowedAreaFloors(Vec3Int position)
		{
			for (int i = StockpilePositionRangeX.Min; i <= StockpilePositionRangeZ.Max; i++)
			{
				for (int j = StockpilePositionRangeZ.Min; j <= StockpilePositionRangeZ.Max; j++)
				{
					if (position.x == i && position.z == j)
					{
						return true;
					}
				}
			}
			return false;
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
				if (item.Value != null && IsInsideAllowedAreaFloors(item.Key))
				{
					num += 1f;
				}
			}
			float percentComplete = num / 25f;
			UpdateTaskCompletion(0, percentComplete);
			if (Tasks[0].IsComplete)
			{
				OnFloorsTaskEnd();
			}
		}

		private void OnFloorsTaskEnd()
		{
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnBlueprintPlacedFloors;
			DeselectAllDelayed();
			StartBuildWallsTask();
		}

		private void StartBuildWallsTask()
		{
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlacedWalls;
			foreach (Vec3Int wallPosition in wallPositions)
			{
				MonoSingleton<TutorialViewManager>.Instance.ShowMarker(new Vec3Int(wallPosition.x, 15, wallPosition.z), hidePrevious: false);
			}
			ShowScreenPointer(show: true);
		}

		private void OnBlueprintPlacedWalls(BaseBuildingInstance buildingInstance)
		{
			if (buildingInstance.BlueprintId != "wood_wall_element")
			{
				return;
			}
			Vec3Int vec3Int = buildingInstance.Positions.FirstOrDefault();
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProtectStockpileTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Wall placed at ");
				messageBuilder.AppendFormatted(vec3Int);
			}
			Log.Trace(messageBuilder);
			if (!wallPositions.Contains(vec3Int))
			{
				HandleInvalidBlueprintPlacement(buildingInstance);
				return;
			}
			MonoSingleton<TutorialViewManager>.Instance.HideMarker(vec3Int);
			ShowScreenPointer(show: false);
			wallBlueprints++;
			FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProtectStockpileTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Wall Blueprints: ");
				messageBuilder2.AppendFormatted(wallBlueprints);
				messageBuilder2.AppendLiteral(" / ");
				messageBuilder2.AppendFormatted(4);
			}
			Log.Debug(messageBuilder2);
			if (wallBlueprints == 4)
			{
				MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
				DeselectAllDelayed();
			}
		}

		private void CheckBuiltWalls()
		{
			Dictionary<Vec3Int, BaseBuildingInstance> dictionary = base.BuildingsManagerMain.TypePositionInstanceDictionary[BuildingType.Wall];
			if (dictionary == null || dictionary.Keys.Count == 0)
			{
				return;
			}
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(0, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProtectStockpileTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(dictionary.Count);
			}
			Log.Debug(messageBuilder);
			float num = 0f;
			foreach (KeyValuePair<Vec3Int, BaseBuildingInstance> item in dictionary)
			{
				if (item.Value == null)
				{
					Log.Error("Null value in dictionary", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProtectStockpileTutorialStep.cs");
				}
				else if (wallPositions.Contains(item.Key))
				{
					num += 1f;
				}
			}
			messageBuilder = new FVLogDebugInterpolationHandler(12, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProtectStockpileTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Build walls ");
				messageBuilder.AppendFormatted(num);
			}
			Log.Debug(messageBuilder);
			UpdateTaskCompletion(1, num / 4f);
			if (Tasks[1].IsComplete)
			{
				OnWallsTaskEnd();
			}
		}

		private void OnWallsTaskEnd()
		{
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnBlueprintPlacedWalls;
			MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
			DeselectAllDelayed();
			StartBuildBeamsTask();
		}

		private void StartBuildBeamsTask()
		{
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlacedBeams;
			for (int i = 0; i <= beamMarkerPositions.Length - 2; i += 2)
			{
				MonoSingleton<TutorialViewManager>.Instance.ShowBeamMarker(beamMarkerPositions[i], beamMarkerPositions[i + 1]);
			}
			ShowScreenPointer(show: true);
		}

		private void OnBlueprintPlacedBeams(BaseBuildingInstance buildingInstance)
		{
			if (buildingInstance.BlueprintId != "wood_beam")
			{
				return;
			}
			Vec3Int vec3Int = buildingInstance.Positions.FirstOrDefault();
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProtectStockpileTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Beam placed at ");
				messageBuilder.AppendFormatted(vec3Int);
			}
			Log.Trace(messageBuilder);
			if (!beamPositions.Contains(vec3Int))
			{
				HandleInvalidBlueprintPlacement(buildingInstance);
				return;
			}
			MonoSingleton<TutorialViewManager>.Instance.HideBeamMarker(buildingInstance.Positions);
			beamBlueprints++;
			FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProtectStockpileTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Beam Blueprints: ");
				messageBuilder2.AppendFormatted(beamBlueprints);
				messageBuilder2.AppendLiteral(" / ");
				messageBuilder2.AppendFormatted(4);
			}
			Log.Debug(messageBuilder2);
			if (beamBlueprints == 4)
			{
				MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
				ShowScreenPointer(show: false);
				DeselectAllDelayed();
			}
		}

		private void CheckBuiltBeams()
		{
			Dictionary<Vec3Int, BaseBuildingInstance> dictionary = base.BuildingsManagerMain.TypePositionInstanceDictionary[BuildingType.Beam];
			if (dictionary == null || dictionary.Keys.Count == 0)
			{
				return;
			}
			float num = 0f;
			foreach (KeyValuePair<Vec3Int, BaseBuildingInstance> item in dictionary)
			{
				if (item.Value != null && beamPositions.Contains(item.Key))
				{
					num += 1f;
				}
			}
			UpdateTaskCompletion(2, num / 4f);
			if (Tasks[2].IsComplete)
			{
				OnBeamsTaskEnd();
			}
		}

		private void OnBeamsTaskEnd()
		{
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnBlueprintPlacedBeams;
			DeselectAllDelayed();
			StartBuildRoofsTask();
		}

		private void StartBuildRoofsTask()
		{
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlacedRoofs;
			ShowMarkersAndPointers(RoofsStart, RoofsEnd, Vector3.up, hideIfTargetOnscreen: true);
		}

		private void OnBlueprintPlacedRoofs(BaseBuildingInstance buildingInstance)
		{
			bool isEnabled;
			if (buildingInstance.BlueprintId != "hay_roof_whole")
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(52, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProtectStockpileTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("OnBlueprintPlaced called with invalid blueprint id: ");
					messageBuilder.AppendFormatted(buildingInstance.BlueprintId);
				}
				Log.Error(messageBuilder);
				return;
			}
			Vec3Int position = buildingInstance.Positions.FirstOrDefault();
			if (!IsInsideAllowedAreaRoofs(position))
			{
				HandleInvalidBlueprintPlacement(buildingInstance);
				return;
			}
			int num = roofPositionRangeX.Max - roofPositionRangeX.Min + 1;
			if (buildingInstance.Positions.Count != num)
			{
				ShowOptimizedBlackBarMessage(string.Format(MonoSingleton<LocalizationController>.Instance.GetText("tutorial_wrong_roof_size"), num));
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					buildingInstance.Map.BuildingsManagerMain.DestroyBuilding(buildingInstance);
				});
				return;
			}
			roofBlueprints++;
			FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(12, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProtectStockpileTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Roof bp: ");
				messageBuilder2.AppendFormatted(roofBlueprints);
				messageBuilder2.AppendLiteral(" / ");
				messageBuilder2.AppendFormatted(7);
			}
			Log.Trace(messageBuilder2);
			if (roofBlueprints == 7)
			{
				HideMarkersAndPointers(RoofsStart, RoofsEnd);
				DeselectAllDelayed();
			}
		}

		private bool IsInsideAllowedAreaRoofs(Vec3Int position)
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
				if (item.Value != null && IsInsideAllowedAreaRoofs(item.Key))
				{
					num += 1f;
				}
			}
			float num2 = num / 49f;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(12, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProtectStockpileTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Finished: ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(": ");
				messageBuilder.AppendFormatted(num2, "P1");
			}
			Log.Trace(messageBuilder);
			UpdateTaskCompletion(3, num2);
			if (Tasks[3].IsComplete)
			{
				OnRoofsTaskEnd();
			}
		}

		private void OnRoofsTaskEnd()
		{
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnBlueprintPlacedRoofs;
			DeselectAllDelayed();
		}
	}
}
