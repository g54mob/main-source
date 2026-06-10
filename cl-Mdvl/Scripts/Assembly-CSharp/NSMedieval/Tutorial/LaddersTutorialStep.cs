using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Views.Resources;

namespace NSMedieval.Tutorial
{
	public class LaddersTutorialStep : TutorialStep
	{
		private readonly List<string> stashedResourcePiles = new List<string>();

		private int startResourcesCount;

		private StockpileInstance stockpileInstance;

		private readonly HashSet<Vec3Int> ladderPositions = new HashSet<Vec3Int>
		{
			new Vec3Int(89, 4, 102),
			new Vec3Int(89, 3, 102)
		};

		private int blueprintsPlaced;

		public LaddersTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_build_wooden_ladders", new object[1] { ladderPositions.Count }),
				new TutorialStepTask("tut_wait_for_haul_stash")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			bool isEnabled;
			foreach (KeyValuePair<ResourcePileInstance, ResourcePileView> allPile in MonoSingleton<ResourcePileManager>.Instance.AllPiles)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(7, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\LaddersTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Pile ");
					messageBuilder.AppendFormatted(allPile.Key.BlueprintId);
					messageBuilder.AppendLiteral(": ");
					messageBuilder.AppendFormatted(allPile.Key.GetStorage().Resources.FirstOrDefault().Amount);
				}
				Log.Trace(messageBuilder);
				if (StashedResourceIds.Contains(allPile.Key.BlueprintId))
				{
					stashedResourcePiles.Add(allPile.Key.BlueprintId);
				}
			}
			startResourcesCount = stashedResourcePiles.Count;
			stockpileInstance = MonoSingleton<StockpileManager>.Instance.Stockpiles.FirstOrDefault();
			if (stockpileInstance == null)
			{
				Log.Error("Couldn't find stockpile instance on the map", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\LaddersTutorialStep.cs");
				return;
			}
			MonoSingleton<UIController>.Instance.ConstructionPanel.SetCategoriesInteractable(new HashSet<BuildingCategoryUI> { BuildingCategoryUI.Base }, interactable: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.GetCategoryTransform(BuildingCategoryUI.Base));
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructBase(allow: true);
			foreach (Vec3Int ladderPosition in ladderPositions)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\LaddersTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Placing ladder preview to: ");
					messageBuilder.AppendFormatted(ladderPosition);
				}
				Log.Trace(messageBuilder);
				MonoSingleton<TutorialViewManager>.Instance.ShowLadderMarker(ladderPosition);
			}
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent += OnShowConstructionCategory;
			MonoSingleton<UIController>.Instance.ConstructionPanel.ClosePanelEvent += base.OnConstructionPanelClose;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlaced;
			stockpileInstance.OnPileAddedToGridEvent += OnPileAddedToStockpile;
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			LockAllBuildingTypes();
			stockpileInstance.OnPileAddedToGridEvent -= OnPileAddedToStockpile;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnBlueprintPlaced;
			MonoSingleton<UIController>.Instance.ConstructionPanel.ClosePanelEvent -= base.OnConstructionPanelClose;
		}

		public override void Tick()
		{
			base.Tick();
			CheckBuiltLadders();
		}

		private void OnShowConstructionCategory(BuildingCategoryUI category)
		{
			if (category == BuildingCategoryUI.Base)
			{
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetCategoriesInteractable(new HashSet<string> { "wood_ladder" }, interactable: true);
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.GetSubcategoryTransform("wood_ladder"));
				});
				MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent += OnChangeBuildingToPlace;
			}
		}

		private void OnChangeBuildingToPlace()
		{
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent -= OnShowConstructionCategory;
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetSubCategoriesInteractable(new HashSet<string> { "wood_ladder" }, interactable: true);
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent -= OnChangeBuildingToPlace;
		}

		private void OnBlueprintPlaced(BaseBuildingInstance buildingInstance)
		{
			bool isEnabled;
			if (buildingInstance.BlueprintId != "wood_ladder")
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(52, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\LaddersTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("OnBlueprintPlaced called with invalid blueprint id: ");
					messageBuilder.AppendFormatted(buildingInstance.BlueprintId);
				}
				Log.Error(messageBuilder);
				return;
			}
			Vec3Int vec3Int = buildingInstance.Positions.FirstOrDefault();
			FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(12, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\LaddersTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Blueprint ");
				messageBuilder2.AppendFormatted(buildingInstance.BlueprintId);
				messageBuilder2.AppendLiteral(": ");
				messageBuilder2.AppendFormatted(vec3Int);
			}
			Log.Trace(messageBuilder2);
			if (ladderPositions.Contains(vec3Int))
			{
				messageBuilder2 = new FVLogTraceInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\LaddersTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(vec3Int.ToString());
					messageBuilder2.AppendLiteral(" Inside Allowed");
				}
				Log.Trace(messageBuilder2);
				MonoSingleton<TutorialViewManager>.Instance.HideLadderMarker(vec3Int);
				MonoSingleton<ScreenPointerManager>.Instance.TryRemoveTarget(GridUtils.GetWorldPosition(ladderPositions.FirstOrDefault()));
				blueprintsPlaced++;
				if (blueprintsPlaced >= ladderPositions.Count)
				{
					MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnBlueprintPlaced;
					MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.1f).Then(delegate
					{
						MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
						MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.Hide();
						MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructBase(allow: false);
						LockAllBuildingTypes();
						DeselectAll();
					});
				}
			}
			else
			{
				messageBuilder2 = new FVLogTraceInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\LaddersTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(vec3Int.ToString());
					messageBuilder2.AppendLiteral(" Outside Allowed");
				}
				Log.Trace(messageBuilder2);
				ShowOptimizedBlackBarMessage("tutorial_wrong_construction_position");
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					buildingInstance.Map.BuildingsManagerMain.DestroyBuilding(buildingInstance);
				});
			}
		}

		private void CheckBuiltLadders()
		{
			if (Tasks[0].IsComplete)
			{
				return;
			}
			Dictionary<Vec3Int, BaseBuildingInstance> dictionary = base.BuildingsManagerMain.TypePositionInstanceDictionary[BuildingType.Ladder];
			if (dictionary == null || dictionary.Keys.Count == 0)
			{
				return;
			}
			float num = 0f;
			foreach (KeyValuePair<Vec3Int, BaseBuildingInstance> item in dictionary)
			{
				if (item.Value != null && ladderPositions.Contains(item.Key) && item.Value.ConstructionPhase.Equals(ConstructionPhase.Finished))
				{
					num += 1f;
				}
			}
			float percentComplete = num / (float)ladderPositions.Count;
			UpdateTaskCompletion(0, percentComplete);
			if (Tasks[0].IsComplete)
			{
				LockAllBuildingTypes();
				MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructBase(allow: false);
				DeselectAll();
			}
		}

		private void OnPileAddedToStockpile()
		{
			foreach (StockpileSpaceData value in stockpileInstance.Grid.Values)
			{
				if (value.Pile == null)
				{
					continue;
				}
				foreach (ResourceInstance resource in value.Pile.GetStorage().Resources)
				{
					if (StashedResourceIds.Contains(resource.BlueprintId))
					{
						stashedResourcePiles.Remove(resource.BlueprintId);
					}
				}
			}
			float num = (float)(StashedResourceIds.Count - stashedResourcePiles.Count) / (float)StashedResourceIds.Count;
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\LaddersTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Completed Sum(");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(")");
			}
			Log.Debug(messageBuilder);
			UpdateTaskCompletion(1, num);
			if (num >= 1f)
			{
				stockpileInstance.OnPileAddedToGridEvent -= OnPileAddedToStockpile;
			}
		}
	}
}
