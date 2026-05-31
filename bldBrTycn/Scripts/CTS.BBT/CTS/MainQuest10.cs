using System;
using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest10 : Level01Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _vampireEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _fridgeEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _bloodEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodMaxVariableName;

		[SerializeField]
		private int _bloodMaxVariableNameValue;

		[SerializeField]
		private StockItemSO _bloodStockItemSO;

		[SerializeField]
		[QuestEntryPopup]
		private int _vampireServiceEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		private LocalizedString _bark03;

		[SerializeField]
		private LocalizedString _bark04;

		public bool DeliveryComplete { get; private set; }

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_bloodVariableName);
			DeliveryComplete = false;
		}

		protected override void QuestSetup()
		{
			base.QuestChain.SetScenerizedStock(scenerized: true);
			if (CustomerManager.VampireCount > 0)
			{
				QuestEntrySuccess(_vampireEntry);
			}
			if (CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable(StationStock.IsFridge))
			{
				QuestEntrySuccess(_fridgeEntry);
			}
		}

		protected override IEnumerator QuestIntroduction()
		{
			DialogueLua.SetVariable(_bloodVariableName, 0);
			HighlightButton.Highlight(BBTUI.Instance.ButtonID_FurnitureShop);
			MonoSingleton<FurnitureShopPopulator>.Instance.Highlight(EFurnitureTags.Fridge);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			CustomerManager.OnCustomerEnterBar -= OnCustomerEnterBar;
			WorkerChoreDrinkDelivery.DrinkDelivered -= OnDrinkDelivered;
			Furniture.FurnitureBought -= OnFurnitureBought;
			Furniture.FurnitureSold -= OnFurnitureSold;
			BuyBasket.BasketBought -= OnGroceryBought;
			Deliveries.DeliveryCompleted -= OnDeliveryCompleted;
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_bloodMaxVariableName, _bloodMaxVariableNameValue);
			CustomerManager.OnCustomerEnterBar += OnCustomerEnterBar;
			WorkerChoreDrinkDelivery.DrinkDelivered += OnDrinkDelivered;
			Furniture.FurnitureBought += OnFurnitureBought;
			Furniture.FurnitureSold += OnFurnitureSold;
			BuyBasket.BasketBought += OnGroceryBought;
			Deliveries.DeliveryCompleted += OnDeliveryCompleted;
		}

		protected override void OnResumeQuest()
		{
			if (DeliveryComplete)
			{
				Deliveries.DeliveryCompleted -= OnDeliveryCompleted;
				base.QuestChain.SwitchPrestigeDataToNormal();
			}
			if (QuestLog.GetQuestEntryState(_questName, _fridgeEntry) == QuestState.Success)
			{
				base.QuestChain.UnlockStore();
				if (QuestLog.GetQuestEntryState(_questName, _bloodEntry) != QuestState.Success)
				{
					HighlightButton.Highlight(BBTUI.Instance.ButtonID_Stocks);
				}
			}
		}

		private void OnDeliveryCompleted(Delivery delivery)
		{
			if (QuestLog.GetQuestEntryState(_questName, _bloodEntry) == QuestState.Success && Stocks.BarStock.GetStockedCount(_bloodStockItemSO.StockType) > 0)
			{
				DeliveryComplete = true;
				Deliveries.DeliveryCompleted -= OnDeliveryCompleted;
				base.QuestChain.SwitchPrestigeDataToNormal();
			}
		}

		private void OnGroceryBought(ShopBasket.BasketValidation basketValidation)
		{
			int num = 0;
			ReadOnlySpan<StockStack>.Enumerator enumerator = basketValidation.GetEnumerator();
			while (enumerator.MoveNext())
			{
				StockStack current = enumerator.Current;
				if (!(current.ItemData != _bloodStockItemSO))
				{
					num = current.StackCount;
					break;
				}
			}
			if (num > 0 && IncrementQuestEntryVariable(_bloodEntry, _bloodVariableName, num, _bloodMaxVariableName))
			{
				BuyBasket.BasketBought -= OnGroceryBought;
				QuestEntrySuccess(_bloodEntry);
				DialogueHelper.StartConversation(_feedback01);
				base.QuestChain.BarkFirstWorker(_bark03.GetLocalizedString(), 2f);
				base.QuestChain.SetHungerActive(active: true);
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
			if (QuestLog.GetQuestEntryState(_questName, _fridgeEntry) == QuestState.Active && furniture.Parameters.Tags.HasFlagNonAlloc(EFurnitureTags.Fridge))
			{
				MonoSingleton<FurnitureShopPopulator>.Instance.StopHighlight(EFurnitureTags.Fridge);
				QuestEntrySuccess(_fridgeEntry);
				base.QuestChain.BarkFirstWorker(_bark02.GetLocalizedString(), 2f);
				base.QuestChain.UnlockStore();
				HighlightButton.Highlight(BBTUI.Instance.ButtonID_Stocks);
				ContextualAction.UnlockAction<ContextualActionOpenUI>();
			}
		}

		private void OnDrinkDelivered(CustomerOrder order)
		{
			if (order.CustomerRef.IsVampire)
			{
				WorkerChoreDrinkDelivery.DrinkDelivered -= OnDrinkDelivered;
				QuestEntrySuccess(_vampireServiceEntry);
				Barks.BarkAgent(order.CustomerRef, _bark04.GetLocalizedString());
			}
		}

		private void OnCustomerEnterBar(Customer customer)
		{
			if (customer.IsVampire)
			{
				CustomerManager.OnCustomerEnterBar -= OnCustomerEnterBar;
				QuestEntrySuccess(_vampireEntry);
				Barks.BarkAgent(customer, _bark01.GetLocalizedString());
			}
		}

		protected override void OnQuestSuccess()
		{
			base.OnQuestSuccess();
			base.QuestChain.SwitchPrestigeDataToNormal();
			base.QuestChain.SetScenerizedStock(scenerized: false);
			MonoSingleton<FurnitureShopPopulator>.Instance.StopHighlight(EFurnitureTags.Fridge);
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			MonoSingleton<FurnitureShopPopulator>.Instance.StopHighlight(EFurnitureTags.Fridge);
			base.QuestChain.SwitchPrestigeDataToNormal();
			base.QuestChain.SetScenerizedStock(scenerized: false);
			base.QuestChain.StoreButtonLocker.Unlock();
			ContextualAction.UnlockAction<ContextualActionOpenUI>();
		}

		public override void SuccessConfirmation()
		{
			base.QuestChain.SwitchPrestigeDataToNormal();
			base.QuestChain.SetScenerizedStock(scenerized: false);
			base.QuestChain.StoreButtonLocker.Unlock();
		}
	}
}
