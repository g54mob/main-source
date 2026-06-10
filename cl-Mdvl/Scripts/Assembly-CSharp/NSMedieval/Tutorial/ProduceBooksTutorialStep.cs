using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class ProduceBooksTutorialStep : TutorialStep
	{
		private SelectionPanelView selectionPanelView;

		private const int TargetProducedCount = 2;

		private float producedCount;

		private BaseBuildingViewComponent researchTableView;

		private const string ProductionBlueprintName = "basic_research_book";

		private const string BasicResearchTableName = "basic_research_table";

		public ProduceBooksTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_select_research_table"),
				new TutorialStepTask("tut_select_books"),
				new TutorialStepTask("tut_produce_forever"),
				new TutorialStepTask("tut_wait_to_produce_books", new object[1] { 2 })
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<TutorialManager>.Instance.HandleSelection(canSelect: true);
			MonoSingleton<UIController>.Instance.LeftPanelView.SetTopLeftButtonsInteractable(new HashSet<string>(), interactable: true);
			selectionPanelView = MonoSingleton<UIController>.Instance.SelectionPanel.PanelView;
			foreach (KeyValuePair<BaseBuildingInstance, BaseBuildingViewComponent> item in base.BuildingsManagerMain.TypeInstanceView[BuildingType.ProductionBuilding])
			{
				if (!(item.Key.BlueprintId != "basic_research_table"))
				{
					researchTableView = item.Value;
					break;
				}
			}
			MonoSingleton<ScreenPointerManager>.Instance.AddTarget(researchTableView.transform.position, new Vector3(1f, 2f, 0f));
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelectedEvent;
			MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent += OnDeselectEvent;
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			selectionPanelView = null;
			MonoSingleton<ScreenPointerManager>.Instance.TryRemoveTarget(researchTableView.transform.position);
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelectedEvent;
			MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent -= OnDeselectEvent;
		}

		private void OnDeselectEvent(SelectableObject arg1)
		{
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
		}

		private void OnSelectedEvent(SelectableObject selectable)
		{
			if (!Tasks[1].IsComplete && selectable is BaseBuildingViewComponent baseBuildingViewComponent && !(baseBuildingViewComponent.BaseBuildingInstance.BlueprintId != "basic_research_table"))
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(23, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProduceBooksTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Selected: ");
					messageBuilder.AppendFormatted(selectable);
					messageBuilder.AppendLiteral(", Building: ");
					messageBuilder.AppendFormatted(selectable.IsBuilding);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted(baseBuildingViewComponent.BaseBuildingInstance.BlueprintId);
				}
				Log.Debug(messageBuilder);
				if (!Tasks[0].IsComplete)
				{
					CompleteTask(0);
					MonoSingleton<ScreenPointerManager>.Instance.TryRemoveTarget(researchTableView.transform.position);
				}
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(OnProductionPanelOpen);
			}
		}

		private void OnProductionPanelOpen()
		{
			Log.Trace("OnProductionPanelOpen", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProduceBooksTutorialStep.cs");
			SelectionExtraProduction productionExtraWindow = selectionPanelView.ProductionExtraWindow;
			foreach (IconWithBackgroundButton productionButton in productionExtraWindow.ProductionButtons)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(12, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProduceBooksTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("iconButton: ");
					messageBuilder.AppendFormatted(productionButton.Name);
				}
				Log.Debug(messageBuilder);
				if (productionButton.Name == "basic_research_book")
				{
					productionButton.Button.interactable = true;
					MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(productionButton.gameObject.GetComponent<RectTransform>());
				}
				else
				{
					productionButton.Button.interactable = false;
				}
			}
			productionExtraWindow.SelectedComponentInstance.ProductionSystemInstance.OnNewProductionEvent += OnNewProductionEvent;
		}

		private void OnNewProductionEvent(ProductionSystemInstance productionSystemInstance, ProductionInstance productionInstance)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProduceBooksTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("OnNewProductionEvent: ");
				messageBuilder.AppendFormatted(productionInstance.BlueprintId);
			}
			Log.Trace(messageBuilder);
			if (productionInstance.BlueprintId != "basic_research_book")
			{
				return;
			}
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				CompleteTask(1);
				MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelectedEvent;
				MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent -= OnDeselectEvent;
				RectTransform target = null;
				bool isEnabled2;
				foreach (ProductionLayoutItemView item in selectionPanelView.ProductionExtraWindow.ProductionQueue)
				{
					item.ModeDropdown.interactable = true;
					FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(27, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProduceBooksTutorialStep.cs");
					if (isEnabled2)
					{
						messageBuilder2.AppendLiteral("productionLayoutItemView: ");
						messageBuilder2.AppendFormatted(item.Production.BlueprintId);
						messageBuilder2.AppendLiteral(" ");
						messageBuilder2.AppendFormatted(item.ModeDropdown.GetComponent<RectTransform>());
					}
					Log.Debug(messageBuilder2);
					if (!(item.Production.BlueprintId != "basic_research_book"))
					{
						target = item.ModeDropdown.GetComponent<RectTransform>();
						break;
					}
				}
				MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(target);
				productionSystemInstance.OnNewProductionEvent -= OnNewProductionEvent;
				FVLogTraceInterpolationHandler messageBuilder3 = new FVLogTraceInterpolationHandler(22, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProduceBooksTutorialStep.cs");
				if (isEnabled2)
				{
					messageBuilder3.AppendLiteral("New production: ");
					messageBuilder3.AppendFormatted(productionInstance.BlueprintId);
					messageBuilder3.AppendLiteral(" added");
				}
				Log.Trace(messageBuilder3);
				productionInstance.ProductionModeChangeEvent += OnProductionModeChange;
			});
		}

		private void OnProductionModeChange(ProductionInstance productionInstance, ProductionMode productionMode)
		{
			if (!(productionInstance.BlueprintId != "basic_research_book") && productionMode == ProductionMode.Forever)
			{
				CompleteTask(2);
				MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
				productionInstance.ProductionModeChangeEvent -= OnProductionModeChange;
				productionInstance.OnLastStepCompleted += OnProductionComplete;
			}
		}

		private void OnProductionComplete(ProductionInstance productionInstance, ProductionStepInstance productionStepInstance)
		{
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(22, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProduceBooksTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(productionInstance.BlueprintId);
				messageBuilder.AppendLiteral(" production completed.");
			}
			Log.Debug(messageBuilder);
			if (!(productionInstance.BlueprintId != "basic_research_book"))
			{
				producedCount += 1f;
				messageBuilder = new FVLogDebugInterpolationHandler(10, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProduceBooksTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(producedCount);
					messageBuilder.AppendLiteral(" produced.");
				}
				Log.Debug(messageBuilder);
				UpdateTaskCompletion(3, producedCount / 2f);
				if (!(producedCount < 2f))
				{
					CompleteTask(3);
					productionInstance.OnLastStepCompleted -= OnProductionComplete;
				}
			}
		}
	}
}
