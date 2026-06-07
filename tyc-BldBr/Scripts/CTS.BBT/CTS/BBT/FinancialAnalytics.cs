using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.BBT.Handlers.Charges;
using GameAnalyticsSDK;
using UnityEngine;

namespace CTS.BBT
{
	public class FinancialAnalytics : MonoBehaviour
	{
		[SerializeField]
		private string _groceriesRessourceItemType = "Groceries";

		[SerializeField]
		private string _furnituresRessourceItemType = "Furnitures";

		[SerializeField]
		private string _vampiresRessourceItemType = "Vampires";

		[SerializeField]
		private string _humansRessourceItemType = "Humans";

		[SerializeField]
		private string _drinksRessourceItemType = "Drinks";

		[SerializeField]
		private string _rewardsRessourceItemType = "Rewards";

		[SerializeField]
		private string _chargesRessourceItemType = "Charges";

		[SerializeField]
		private string _loansRessourceItemType = "Bank";

		private Dictionary<(string, string), float> _sinks = new Dictionary<(string, string), float>();

		private Dictionary<(string, string), float> _sources = new Dictionary<(string, string), float>();

		private void OnEnable()
		{
			Furniture.FurnitureBought += OnFurnitureBought;
			Furniture.FurnitureSold += OnFurnitureSold;
			QuestRewards.RewardEarned += OnRewardEarned;
			ChargesHandlers.ChargePayed += OnChargePayed;
			BuyBasket.BasketBought += OnGroceryBought;
			CustomerOrder.DrinkPayed += OnDrinkPayed;
			FinancialLoaningManager.OnTakeOutALoan += OnLoanGot;
		}

		private void OnDisable()
		{
			Furniture.FurnitureBought -= OnFurnitureBought;
			Furniture.FurnitureSold -= OnFurnitureSold;
			QuestRewards.RewardEarned -= OnRewardEarned;
			ChargesHandlers.ChargePayed -= OnChargePayed;
			BuyBasket.BasketBought -= OnGroceryBought;
			CustomerOrder.DrinkPayed -= OnDrinkPayed;
			FinancialLoaningManager.OnTakeOutALoan -= OnLoanGot;
			SendData();
		}

		private void OnLoanGot(int amount)
		{
			AddTransaction(_sources, _loansRessourceItemType, "Loan", amount);
		}

		private void OnDrinkPayed(DrinkSO drink, int price)
		{
			AddTransaction(_sources, _drinksRessourceItemType, drink.Name, price);
		}

		private void OnGroceryBought(ShopBasket.BasketValidation basketValidation)
		{
			ReadOnlySpan<StockStack> span = basketValidation.StockValidated.Span;
			for (int i = 0; i < span.Length; i++)
			{
				StockStack stockStack = span[i];
				AddTransaction(_sinks, _groceriesRessourceItemType, stockStack.ItemData.Name, stockStack.ItemData.PurchasePrice * stockStack.StackCount);
			}
		}

		private void OnChargePayed(ChargeTypes type, int chargeAmount)
		{
			string id = "Charge";
			switch (type)
			{
			case ChargeTypes.Salaries:
				id = "Salaries";
				break;
			case ChargeTypes.Energy:
				id = "Energy";
				break;
			case ChargeTypes.Insurance:
				id = "Insurance";
				break;
			case ChargeTypes.Loans:
				id = "Interests";
				AddTransaction(_sinks, _loansRessourceItemType, id, chargeAmount);
				return;
			case ChargeTypes.Exceptional:
				id = "Exceptional";
				break;
			}
			AddTransaction(_sinks, _chargesRessourceItemType, id, chargeAmount);
		}

		private void OnRewardEarned(int rewardAmount)
		{
			if (rewardAmount != 0)
			{
				AddTransaction((rewardAmount > 0) ? _sources : _sinks, _rewardsRessourceItemType, "Quest", Mathf.Abs(rewardAmount));
			}
		}

		private void OnFurnitureSold(Furniture furniture)
		{
			int resellPrice = furniture.GetResellPrice();
			if (resellPrice != 0)
			{
				AddTransaction(_sources, _furnituresRessourceItemType, furniture.Parameters.Name, resellPrice);
			}
		}

		private void OnFurnitureBought(Furniture furniture)
		{
			AddTransaction(_sinks, _furnituresRessourceItemType, furniture.Parameters.Name, furniture.Parameters.PurchasePrice);
		}

		private void AddTransaction(Dictionary<(string, string), float> collection, string type, string id, float value)
		{
			if (collection.ContainsKey((type, id)))
			{
				collection[(type, id)] += value;
			}
			else
			{
				collection.Add((type, id), value);
			}
		}

		private void SendData()
		{
			foreach (KeyValuePair<(string, string), float> sink in _sinks)
			{
				GameAnalytics.NewResourceEvent(GAResourceFlowType.Sink, "Dollar", sink.Value, sink.Key.Item1, sink.Key.Item2);
			}
			foreach (KeyValuePair<(string, string), float> source in _sources)
			{
				GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Dollar", source.Value, source.Key.Item1, source.Key.Item2);
			}
		}
	}
}
