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
	public class ProductionTutorialStep : TutorialStep
	{
		private SelectionPanelView selectionPanelView;

		private const int TargetProductionCycleCount = 3;

		private const string ProductionBlueprintName = "meal";

		private float producedCount;

		private BaseBuildingViewComponent campfireView;

		private BaseBuildingInstance campfireInstance;

		public ProductionTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_production_select_campfire"),
				new TutorialStepTask("tut_production_select_meal"),
				new TutorialStepTask("tut_production_set_amount", new object[1] { 3 }),
				new TutorialStepTask("tut_wait_to_produce_meals", new object[1] { 3 })
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<TutorialManager>.Instance.HandleSelection(canSelect: true);
			selectionPanelView = MonoSingleton<UIController>.Instance.SelectionPanel.PanelView;
			foreach (KeyValuePair<BaseBuildingInstance, BaseBuildingViewComponent> item in base.BuildingsManagerMain.TypeInstanceView[BuildingType.ProductionBuilding])
			{
				if (!(item.Key.BlueprintId != "camp_fire"))
				{
					campfireInstance = item.Key;
					campfireView = item.Value;
					break;
				}
			}
			MonoSingleton<ScreenPointerManager>.Instance.AddTarget(campfireView.transform.position, new Vector3(0f, 2f, 0f));
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelectedEvent;
			MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent += OnDeselectEvent;
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			selectionPanelView = null;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelectedEvent;
			MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent -= OnDeselectEvent;
		}

		private void OnDeselectEvent(SelectableObject selectableObject)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(12, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProductionTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Deselected: ");
				messageBuilder.AppendFormatted(selectableObject);
			}
			Log.Debug(messageBuilder);
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
		}

		private void OnSelectedEvent(SelectableObject selectable)
		{
			if (selectable is BaseBuildingViewComponent baseBuildingViewComponent && !(baseBuildingViewComponent.BaseBuildingInstance.BlueprintId != "camp_fire"))
			{
				if (!Tasks[0].IsComplete)
				{
					CompleteTask(0);
					MonoSingleton<ScreenPointerManager>.Instance.TryRemoveTarget(campfireView.transform.position);
				}
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(OnProductionPanelOpen);
			}
		}

		private void OnProductionPanelOpen()
		{
			SelectionExtraProduction productionExtraWindow = selectionPanelView.ProductionExtraWindow;
			foreach (IconWithBackgroundButton productionButton in productionExtraWindow.ProductionButtons)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(12, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProductionTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("iconButton: ");
					messageBuilder.AppendFormatted(productionButton.Name);
				}
				Log.Debug(messageBuilder);
				if (productionButton.Name == "meal")
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
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProductionTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("New production: ");
				messageBuilder.AppendFormatted(productionInstance.BlueprintId);
				messageBuilder.AppendLiteral(" added");
			}
			Log.Trace(messageBuilder);
			if (productionInstance.BlueprintId != "meal")
			{
				return;
			}
			CompleteTask(1);
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelectedEvent;
			MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent -= OnDeselectEvent;
			productionSystemInstance.OnNewProductionEvent -= OnNewProductionEvent;
			productionInstance.SetProductTargetCount(0);
			using (List<ProductionLayoutItemView>.Enumerator enumerator = selectionPanelView.ProductionExtraWindow.ProductionQueue.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					ProductionLayoutItemView current = enumerator.Current;
					FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(26, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProductionTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("productionLayoutItemView: ");
						messageBuilder2.AppendFormatted(current.ModeDropdown);
					}
					Log.Debug(messageBuilder2);
					current.ModeDropdown.interactable = false;
				}
			}
			ForcePause();
			productionInstance.OnTargetCountChange += OnCountChange;
			productionInstance.OnLastStepCompleted += OnProductionComplete;
		}

		private void OnCountChange(ProductionInstance productionInstance, int targetCount)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(27, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProductionTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Production count changed: ");
				messageBuilder.AppendFormatted(productionInstance.BlueprintId);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(targetCount);
			}
			Log.Trace(messageBuilder);
			if (targetCount >= 3)
			{
				CompleteTask(2);
				productionInstance.OnTargetCountChange -= OnCountChange;
				ForceUnpauseAndAllowTimeControls();
			}
		}

		private void OnProductionComplete(ProductionInstance productionInstance, ProductionStepInstance productionStepInstance)
		{
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(22, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProductionTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(productionInstance.BlueprintId);
				messageBuilder.AppendLiteral(" production completed.");
			}
			Log.Debug(messageBuilder);
			if (!(productionInstance.BlueprintId != "meal"))
			{
				producedCount += 1f;
				messageBuilder = new FVLogDebugInterpolationHandler(10, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ProductionTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(producedCount);
					messageBuilder.AppendLiteral(" produced.");
				}
				Log.Debug(messageBuilder);
				UpdateTaskCompletion(3, producedCount / 3f);
				if (Tasks[3].IsComplete)
				{
					CompleteTask(3);
					productionInstance.OnLastStepCompleted -= OnProductionComplete;
				}
			}
		}
	}
}
