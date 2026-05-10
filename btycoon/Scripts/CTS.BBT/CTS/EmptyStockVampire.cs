using System;
using System.Collections;
using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class EmptyStockVampire : CircumstantialQuest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _fridgeEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _bloodDrinkEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodDrinkVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodReceivedVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodDrinkMaxVariableName;

		[SerializeField]
		private int _bloodDrinkMaxVariableNameValue;

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
			ResetVariableTo0(_bloodDrinkVariableName);
		}

		public override void StopObservingStartConditions()
		{
			Stocks.BarStock.StockChanged -= OnStockChanged;
		}

		public override void StartObservingStartConditions()
		{
			DialogueLua.SetVariable(_bloodDrinkMaxVariableName, _bloodDrinkMaxVariableNameValue);
			Stocks.BarStock.StockChanged += OnStockChanged;
		}

		private void OnStockChanged(StockInventory<StockStack, StockItemSO>.StockChangedData obj)
		{
			if (!(obj.StockType != Stocks.VampireStockType) && obj.Operation == EOperation.Removed && obj.StockCapacity.CurrentCapacity <= 0)
			{
				Stocks.BarStock.StockChanged -= OnStockChanged;
				StartQuest();
			}
		}

		protected override IEnumerator QuestIntroduction()
		{
			DialogueLua.SetVariable(_bloodDrinkVariableName, 0);
			yield break;
		}

		protected override void StartObservingObjectives()
		{
			Furniture.FurnitureBought += OnFurnitureBought;
			Furniture.FurnitureSold += OnFurnitureSold;
			BuyBasket.BasketBought += OnGroceryBought;
			StockBought(GetDeliveries().GetStockTypeAmountInCurrentDeliveries(Stocks.VampireStockType));
			Deliveries.DeliveryCompleted += OnDeliveryArrived;
			if (CTSSingleton<LevelParameters>.Instance.Furnitures.DoesAnyExist(StationStock.IsFridge))
			{
				QuestEntrySuccess(_fridgeEntry);
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
			if (delivery.DeliveryAmounts.TryGetValue(Stocks.VampireStockType, out var value) && IncrementQuestEntryVariable(_orderArrivedEntry, _bloodReceivedVariableName, value, _bloodDrinkMaxVariableName))
			{
				Deliveries.DeliveryCompleted -= OnDeliveryArrived;
				QuestEntrySuccess(_orderArrivedEntry);
			}
		}

		private void OnGroceryBought(ShopBasket.BasketValidation basketValidation)
		{
			int num = 0;
			ReadOnlySpan<StockStack>.Enumerator enumerator = basketValidation.GetEnumerator();
			while (enumerator.MoveNext())
			{
				StockStack current = enumerator.Current;
				if (current.ItemData.StockType == Stocks.VampireStockType)
				{
					num += current.StackCount;
				}
			}
			StockBought(num);
		}

		private void StockBought(int amount)
		{
			if (IncrementQuestEntryVariable(_bloodDrinkEntry, _bloodDrinkVariableName, amount, _bloodDrinkMaxVariableName))
			{
				BuyBasket.BasketBought -= OnGroceryBought;
				QuestEntrySuccess(_bloodDrinkEntry);
			}
		}

		private void OnFurnitureSold(Furniture furniture)
		{
			if (CTSSingleton<LevelParameters>.InstanceExists() && QuestLog.GetQuestEntryState(_questName, _fridgeEntry) == QuestState.Success && !CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable(StationStock.IsFridge))
			{
				QuestEntryCancelSuccess(_fridgeEntry);
			}
		}

		private void OnFurnitureBought(Furniture furniture)
		{
			if (QuestLog.GetQuestEntryState(_questName, _fridgeEntry) == QuestState.Active && furniture.Parameters.Tags.HasFlag(EFurnitureTags.Fridge))
			{
				QuestEntrySuccess(_fridgeEntry);
			}
		}
	}
}
