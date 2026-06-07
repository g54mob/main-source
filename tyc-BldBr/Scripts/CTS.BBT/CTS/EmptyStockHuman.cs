using System;
using System.Collections;
using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class EmptyStockHuman : CircumstantialQuest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _shelveEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _humanDrinkEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _humanDrinkVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _humanDrinkReceivedVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _humanDrinkMaxVariableName;

		[SerializeField]
		private int _humanDrinkMaxVariableNameValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _orderArrivedEntry;

		private Deliveries _deliveries;

		private Deliveries GetDeliveries()
		{
			if (!_deliveries)
			{
				_deliveries = ComponentGetter.GetComponentSingleSingleton(typeof(Deliveries)) as Deliveries;
			}
			return _deliveries;
		}

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_humanDrinkVariableName);
		}

		public override void StopObservingStartConditions()
		{
			Stocks.BarStock.StockChanged -= OnStockChanged;
		}

		public override void StartObservingStartConditions()
		{
			DialogueLua.SetVariable(_humanDrinkMaxVariableName, _humanDrinkMaxVariableNameValue);
			Stocks.BarStock.StockChanged += OnStockChanged;
		}

		private void OnStockChanged(StockInventory<StockStack, StockItemSO>.StockChangedData obj)
		{
			if (!(obj.StockType != Stocks.HumanStockType) && obj.Operation == EOperation.Removed && obj.StockCapacity.CurrentCapacity <= 0)
			{
				Stocks.BarStock.StockChanged -= OnStockChanged;
				StartQuest();
			}
		}

		protected override IEnumerator QuestIntroduction()
		{
			DialogueLua.SetVariable(_humanDrinkVariableName, 0);
			yield break;
		}

		protected override void StartObservingObjectives()
		{
			Furniture.FurnitureBought += OnFurnitureBought;
			Furniture.FurnitureSold += OnFurnitureSold;
			BuyBasket.BasketBought += OnGroceryBought;
			StockBought(GetDeliveries().GetStockTypeAmountInCurrentDeliveries(Stocks.HumanStockType));
			Deliveries.DeliveryCompleted += OnDeliveryArrived;
			if (CTSSingleton<LevelParameters>.Instance.Furnitures.DoesAnyExist(StationStock.IsShelf))
			{
				QuestEntrySuccess(_shelveEntry);
			}
		}

		protected override void StopObservingObjectives()
		{
			Furniture.FurnitureBought -= OnFurnitureBought;
			Furniture.FurnitureSold -= OnFurnitureSold;
			BuyBasket.BasketBought -= OnGroceryBought;
			Deliveries.DeliveryCompleted -= OnDeliveryArrived;
		}

		private void OnDeliveryArrived(Delivery delivery)
		{
			if (delivery.DeliveryAmounts.TryGetValue(Stocks.HumanStockType, out var value) && IncrementQuestEntryVariable(_orderArrivedEntry, _humanDrinkReceivedVariableName, value, _humanDrinkMaxVariableName))
			{
				Deliveries.DeliveryCompleted -= OnDeliveryArrived;
				QuestEntrySuccess(_orderArrivedEntry);
			}
		}

		private void OnGroceryBought(ShopBasket.BasketValidation basketValidation)
		{
			int num = 0;
			ReadOnlySpan<StockStack> span = basketValidation.StockValidated.Span;
			for (int i = 0; i < span.Length; i++)
			{
				StockStack stockStack = span[i];
				if (stockStack.ItemData.StockType == Stocks.HumanStockType)
				{
					num += stockStack.StackCount;
				}
			}
			StockBought(num);
		}

		private void StockBought(int amount)
		{
			if (IncrementQuestEntryVariable(_humanDrinkEntry, _humanDrinkVariableName, amount, _humanDrinkMaxVariableName))
			{
				BuyBasket.BasketBought -= OnGroceryBought;
				QuestEntrySuccess(_humanDrinkEntry);
			}
		}

		private void OnFurnitureSold(Furniture furniture)
		{
			if (CTSSingleton<LevelParameters>.InstanceExists() && QuestLog.GetQuestEntryState(_questName, _shelveEntry) == QuestState.Success && !CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable(StationStock.IsShelf))
			{
				QuestEntryCancelSuccess(_shelveEntry);
			}
		}

		private void OnFurnitureBought(Furniture furniture)
		{
			if (QuestLog.GetQuestEntryState(_questName, _shelveEntry) == QuestState.Active && furniture.Parameters.Tags.HasFlag(EFurnitureTags.Shelve))
			{
				QuestEntrySuccess(_shelveEntry);
			}
		}
	}
}
