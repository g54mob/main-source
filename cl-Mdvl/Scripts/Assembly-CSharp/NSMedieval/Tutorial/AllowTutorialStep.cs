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
	public class AllowTutorialStep : TutorialStep
	{
		private readonly HashSet<string> startResourceIds = new HashSet<string>();

		private int startResourceCount;

		private readonly Dictionary<ResourcePileInstance, ResourcePileView> startResourcePiles = new Dictionary<ResourcePileInstance, ResourcePileView>();

		private StockpileInstance stockpileInstance;

		private Vec3Int Start => new Vec3Int(100, 15, 99);

		private Vec3Int End => new Vec3Int(99, 15, 97);

		public AllowTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_select_allow"),
				new TutorialStepTask("tut_drag_allow"),
				new TutorialStepTask("tut_wait_for_haul")
			};
		}

		public override void BeginStep()
		{
			MonoSingleton<TutorialManager>.Instance.HandleOrdersPanel(allow: true);
			MonoSingleton<TutorialManager>.Instance.HandleSelection(canSelect: false);
			MonoSingleton<UIController>.Instance.OrdersPanelView.Show();
			base.BeginStep();
			foreach (KeyValuePair<ResourcePileInstance, ResourcePileView> allPile in MonoSingleton<ResourcePileManager>.Instance.AllPiles)
			{
				if (!StashedResourceIds.Contains(allPile.Key.BlueprintId))
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(7, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\AllowTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Pile ");
						messageBuilder.AppendFormatted(allPile.Key.BlueprintId);
						messageBuilder.AppendLiteral(": ");
						messageBuilder.AppendFormatted(allPile.Key.GetStorage().Resources.FirstOrDefault().Amount);
					}
					Log.Trace(messageBuilder);
					startResourcePiles.Add(allPile.Key, allPile.Value);
					startResourceIds.Add(allPile.Key.BlueprintId);
					allPile.Key.ForbidChangeEvent += OnForbidChanged;
				}
			}
			startResourceCount = startResourcePiles.Count;
			stockpileInstance = MonoSingleton<StockpileManager>.Instance.Stockpiles.FirstOrDefault();
			if (stockpileInstance == null)
			{
				Log.Error("Couldn't find stockpile instance on the map", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\AllowTutorialStep.cs");
				return;
			}
			stockpileInstance.OnPileAddedToGridEvent += OnPileAddedToStockpile;
			MonoSingleton<UIShowManager>.Instance.ShowOrders();
			MonoSingleton<UIController>.Instance.OrdersPanelView.SetCategoriesInteractable(new HashSet<OrderType> { OrderType.Allow }, interactable: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.OrdersPanelView.GetCategoryTransform(OrderType.Allow));
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowAllowOrder(allow: true);
			MonoSingleton<SelectionManager>.Instance.AssignOrderEvent += OnOrderAssigned;
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<TutorialManager>.Instance.HandleSelection(canSelect: true);
			MonoSingleton<UIController>.Instance.OrdersPanelView.SetCategoriesInteractable(new HashSet<OrderType>(), interactable: true);
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowAllowOrder(allow: false);
			stockpileInstance.OnPileAddedToGridEvent -= OnPileAddedToStockpile;
			MonoSingleton<SelectionManager>.Instance.AssignOrderEvent -= OnOrderAssigned;
		}

		private void OnOrderAssigned(OrderType orderType, AreaType areaType)
		{
			if (orderType == OrderType.Allow)
			{
				MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
				ShowMarkersAndPointers(Start, End, Vector3.up, hideIfTargetOnscreen: true);
				CompleteTask(0);
				MonoSingleton<SelectionManager>.Instance.AssignOrderEvent -= OnOrderAssigned;
			}
		}

		private void OnForbidChanged(IForbidable forbidable)
		{
			float num = 0f;
			foreach (ResourcePileInstance key in startResourcePiles.Keys)
			{
				if (!key.IsForbidden)
				{
					num += 1f;
				}
			}
			float num2 = num / (float)startResourcePiles.Count;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(14, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\AllowTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("OnSetAllowed ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral("/");
				messageBuilder.AppendFormatted(startResourcePiles.Count);
			}
			Log.Trace(messageBuilder);
			UpdateTaskCompletion(1, num2);
			if (num2 >= 1f)
			{
				OnAllowTaskComplete();
				HideMarkersAndPointers(Start, End);
				MonoSingleton<UIController>.Instance.OrdersPanelView.SetCategoriesInteractable(new HashSet<OrderType>(), interactable: true);
			}
		}

		private void OnAllowTaskComplete()
		{
			foreach (ResourcePileInstance key in startResourcePiles.Keys)
			{
				if (key != null)
				{
					key.ForbidChangeEvent -= OnForbidChanged;
				}
			}
			startResourcePiles.Clear();
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
					if (startResourceIds.Contains(resource.BlueprintId))
					{
						startResourceIds.Remove(resource.BlueprintId);
					}
				}
			}
			float num = (float)(startResourceCount - startResourceIds.Count) / (float)startResourceCount;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(17, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\AllowTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Completed ");
				messageBuilder.AppendFormatted(startResourceCount);
				messageBuilder.AppendLiteral("-");
				messageBuilder.AppendFormatted(startResourceIds.Count);
				messageBuilder.AppendLiteral(" / ");
				messageBuilder.AppendFormatted(startResourceCount);
				messageBuilder.AppendLiteral(" = ");
				messageBuilder.AppendFormatted(num);
			}
			Log.Info(messageBuilder);
			UpdateTaskCompletion(2, num);
			if (num >= 1f)
			{
				stockpileInstance.OnPileAddedToGridEvent -= OnPileAddedToStockpile;
			}
		}
	}
}
