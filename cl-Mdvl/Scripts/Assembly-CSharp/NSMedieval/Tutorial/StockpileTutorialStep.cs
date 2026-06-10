using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Stockpiles;
using NSMedieval.Types;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class StockpileTutorialStep : TutorialStep, IObserver
	{
		private const string DefaultStockpile = "default_stockpile";

		private const int BaseSideSize = 4;

		private Vec3Int Start => new Vec3Int(StockpilePositionRangeX.Min, 15, StockpilePositionRangeZ.Min);

		private Vec3Int End => new Vec3Int(StockpilePositionRangeX.Max, 15, StockpilePositionRangeZ.Max);

		public StockpileTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_open_build_zone"),
				new TutorialStepTask("tut_select_stockpile"),
				new TutorialStepTask("tut_drag_place_building")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent += OnShowConstructionCategory;
			MonoSingleton<UIController>.Instance.ConstructionPanel.ClosePanelEvent += base.OnConstructionPanelClose;
			MonoSingleton<UIController>.Instance.Attach(this);
			ForceUnpauseAndAllowTimeControls();
			MonoSingleton<GameSpeedManager>.Instance.SetSpeedNormal();
			MonoSingleton<UIShowManager>.Instance.ShowConstruction();
			MonoSingleton<UIController>.Instance.ConstructionPanel.SetCategoriesInteractable(new HashSet<BuildingCategoryUI> { BuildingCategoryUI.Zone }, interactable: true);
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructZone(allow: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.GetCategoryTransform(BuildingCategoryUI.Zone));
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<SelectionManager>.Instance.DeselectTool();
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructZone(allow: false);
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.Hide();
		}

		private void OnShowConstructionCategory(BuildingCategoryUI category)
		{
			if (category == BuildingCategoryUI.Zone)
			{
				CompleteTask(0);
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.GetSubcategoryTransform("default_stockpile"));
				});
			}
		}

		private void OnModifyZoneButtonClicked()
		{
			CompleteTask(1);
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent -= OnShowConstructionCategory;
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetSubCategoriesInteractable(new HashSet<string> { "default_stockpile" }, interactable: true);
			ShowMarkersAndPointers(Start, End, Vector3.up, hideIfTargetOnscreen: true);
			MonoSingleton<UIController>.Instance.Detach(this);
			MonoSingleton<StockpileController>.Instance.StockpilePlacedEvent += OnStockpilePlaced;
		}

		private void OnStockpilePlaced(StockpileInstance stockpileInstance)
		{
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(3, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\StockpileTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(stockpileInstance.Start);
				messageBuilder.AppendLiteral(" - ");
				messageBuilder.AppendFormatted(stockpileInstance.End);
			}
			Log.Debug(messageBuilder);
			int num = Mathf.Abs(stockpileInstance.Start.x - stockpileInstance.End.x);
			int num2 = Mathf.Abs(stockpileInstance.Start.z - stockpileInstance.End.z);
			if (num != 4 || num2 != 4)
			{
				messageBuilder = new FVLogDebugInterpolationHandler(8, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\StockpileTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(num);
					messageBuilder.AppendLiteral(" or ");
					messageBuilder.AppendFormatted(num2);
					messageBuilder.AppendLiteral(" != ");
					messageBuilder.AppendFormatted(4);
				}
				Log.Debug(messageBuilder);
				ShowOptimizedBlackBarMessage("tutorial_wrong_construction_size");
				stockpileInstance.Dispose();
			}
			else if (!stockpileInstance.ContainsGridPosition(Start.ToGridY()) || !stockpileInstance.ContainsGridPosition(End.ToGridY()))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(20, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\StockpileTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(Start);
					messageBuilder.AppendLiteral(" or ");
					messageBuilder.AppendFormatted(End);
					messageBuilder.AppendLiteral(" not part of ");
					messageBuilder.AppendFormatted(stockpileInstance.Start);
					messageBuilder.AppendLiteral(" - ");
					messageBuilder.AppendFormatted(stockpileInstance.End);
				}
				Log.Debug(messageBuilder);
				ShowOptimizedBlackBarMessage("tutorial_wrong_construction_position");
				stockpileInstance.Dispose();
			}
			else
			{
				MonoSingleton<StockpileController>.Instance.StockpilePlacedEvent -= OnStockpilePlaced;
				CompleteTask(2);
				HideMarkersAndPointers(Start, End);
				DeselectAllDelayed();
				LockAllBuildingTypes();
				MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetSubCategoriesInteractable(new HashSet<string>(), interactable: false);
			}
		}
	}
}
