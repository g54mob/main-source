using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class ForageTutorialStep : TutorialStep
	{
		private const string RedcurrantName = "redcurrant";

		private const int StockpiledTotalAmount = 90;

		private const int RedcurrantTotalAmount = 9;

		private StockpileInstance stockpileInstance;

		private readonly HashSet<PlantMapResourceInstance> plantMapResourceInstances = new HashSet<PlantMapResourceInstance>();

		private Vec3Int Start => new Vec3Int(96, 15, 109);

		private Vec3Int End => new Vec3Int(100, 15, 112);

		public ForageTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_select_harvest"),
				new TutorialStepTask("tut_drag_select_redcurrant", new object[1] { 9 }),
				new TutorialStepTask("tut_stockpile_redcurrant", new object[1] { 90 })
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<TutorialManager>.Instance.HandleSelection(canSelect: false);
			stockpileInstance = MonoSingleton<StockpileManager>.Instance.Stockpiles.FirstOrDefault();
			if (stockpileInstance == null)
			{
				Log.Error("Couldn't find stockpile instance on the map", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ForageTutorialStep.cs");
				return;
			}
			MonoSingleton<UIController>.Instance.OrdersPanelView.SetCategoriesInteractable(new HashSet<OrderType> { OrderType.Harvesting }, interactable: true);
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowHarvestOrder(allow: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.OrdersPanelView.GetCategoryTransform(OrderType.Harvesting));
			MonoSingleton<SelectionManager>.Instance.AssignOrderEvent += OnOrderAssigned;
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<TutorialManager>.Instance.HandleSelection(canSelect: true);
			MonoSingleton<UIController>.Instance.OrdersPanelView.SetCategoriesInteractable(new HashSet<OrderType>(), interactable: true);
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowHarvestOrder(allow: false);
		}

		public override void Tick()
		{
			base.Tick();
			OrderMarkCheck();
			StockpileCheck();
		}

		private void OnOrderAssigned(OrderType orderType, AreaType areaType)
		{
			if (orderType == OrderType.Harvesting)
			{
				MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
				ShowMarkersAndPointers(Start, End, Vector3.up, hideIfTargetOnscreen: true);
				CompleteTask(0);
				MonoSingleton<SelectionManager>.Instance.AssignOrderEvent -= OnOrderAssigned;
			}
		}

		private void OrderMarkCheck()
		{
			if (Tasks[1].IsComplete)
			{
				return;
			}
			foreach (KeyValuePair<PlantMapResourceInstance, PlantMapResourceView> item in MonoSingleton<PlantResourceManager>.Instance.InstanceView)
			{
				if (item.Key.CurrentOrder != OrderType.Harvesting)
				{
					continue;
				}
				bool isEnabled;
				if (!IsInsideAllowedArea(item.Value.GetAsWorldObject().GridDataPosition, Start, End))
				{
					item.Key.SetCurrentOrder(OrderType.None);
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(12, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ForageTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(item.Key);
						messageBuilder.AppendLiteral(" not allowed");
					}
					Log.Trace(messageBuilder);
					return;
				}
				if (!(item.Key.BlueprintId != "shrub_redcurrant") && plantMapResourceInstances.Add(item.Key))
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(19, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ForageTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Checking for ");
						messageBuilder.AppendFormatted(item.Key.BlueprintId);
						messageBuilder.AppendLiteral(" (");
						messageBuilder.AppendFormatted(plantMapResourceInstances.Count);
						messageBuilder.AppendLiteral(") ");
						messageBuilder.AppendFormatted(item.Key.CurrentOrder);
						messageBuilder.AppendLiteral(" ");
						messageBuilder.AppendFormatted(item.Key.HarvestPhase);
						messageBuilder.AppendLiteral(" ");
						messageBuilder.AppendFormatted(item.Key.Positions.FirstOrDefault());
					}
					Log.Trace(messageBuilder);
				}
			}
			float percentComplete = (float)plantMapResourceInstances.Count / 9f;
			UpdateTaskCompletion(1, percentComplete);
			if (Tasks[1].IsComplete)
			{
				Log.Debug("Mark Step Complete", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ForageTutorialStep.cs");
				DeselectAllDelayed();
				HideMarkersAndPointers(Start, End);
				MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowHarvestOrder(allow: false);
				MonoSingleton<UIController>.Instance.OrdersPanelView.SetCategoriesInteractable(new HashSet<OrderType>(), interactable: true);
			}
		}

		private void StockpileCheck()
		{
			if (stockpileInstance == null || Tasks[2].IsComplete)
			{
				return;
			}
			int num = 0;
			bool isEnabled;
			foreach (StockpileSpaceData value in stockpileInstance.Grid.Values)
			{
				if (value.Pile == null)
				{
					continue;
				}
				foreach (ResourceInstance resource in value.Pile.GetStorage().Resources)
				{
					if (!(resource.BlueprintId != "redcurrant"))
					{
						FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(19, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ForageTutorialStep.cs");
						if (isEnabled)
						{
							messageBuilder.AppendFormatted(resource.BlueprintId);
							messageBuilder.AppendLiteral(" - Amount: ");
							messageBuilder.AppendFormatted(resource.Amount);
							messageBuilder.AppendLiteral(" Count: ");
							messageBuilder.AppendFormatted(resource.Count.Amount);
						}
						Log.Trace(messageBuilder);
						num += resource.Amount;
					}
				}
			}
			float num2 = (float)num / 90f;
			UpdateTaskCompletion(2, num2);
			if (num2 >= 1f)
			{
				FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ForageTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Task Complete: ");
					messageBuilder2.AppendFormatted(num2);
				}
				Log.Debug(messageBuilder2);
			}
		}
	}
}
