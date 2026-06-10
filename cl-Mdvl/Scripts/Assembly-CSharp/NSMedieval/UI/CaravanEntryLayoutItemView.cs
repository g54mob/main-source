using System;
using System.Collections.Generic;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using Unity.Mathematics;
using UnityEngine;

namespace NSMedieval.UI
{
	public class CaravanEntryLayoutItemView : TradingBaseLayoutItemView
	{
		[SerializeField]
		private BasicLayoutItemView amount;

		[SerializeField]
		private BasicLayoutItemView price;

		[SerializeField]
		private TradingInputLayoutItemView amountInput;

		[NonSerialized]
		private int resourceAmount;

		[NonSerialized]
		private bool amountChangeSubscribed;

		[NonSerialized]
		private bool isFiltered;

		[NonSerialized]
		private Dictionary<StatType, float> statValues = new Dictionary<StatType, float>();

		public TradingInputLayoutItemView AmountInput => amountInput;

		public bool IsFiltered => isFiltered;

		public int Amount => resourceAmount;

		public ResourceInstance CreateResourceInstance()
		{
			ResourceInstance resourceInstance = new ResourceInstance(base.Resource, resourceAmount);
			foreach (KeyValuePair<StatType, float> statValue in statValues)
			{
				resourceInstance.Stats.GetStat(statValue.Key).SetCurrent(statValue.Value);
			}
			return resourceInstance;
		}

		public int GetTradeValue()
		{
			return amountInput.TradeValue;
		}

		private void SubscribeToAmountChange()
		{
			if (!amountChangeSubscribed)
			{
				amountChangeSubscribed = true;
				amountInput.PreAmountChangedEvent += OnAmountChanged;
			}
		}

		private void OnAmountChanged(int newValue)
		{
			resourceAmount = newValue;
		}

		public void SetData(ResourceInstance resourceInstance)
		{
			statValues.Clear();
			foreach (KeyValuePair<StatType, StatInstance> stat in resourceInstance.Stats.Stats)
			{
				statValues.Add(stat.Key, stat.Value.Current);
			}
			SubscribeToAmountChange();
			resourceAmount = resourceInstance.Amount;
			Initialize(resourceInstance.Blueprint);
			if (base.IsEquipment || base.IsBuilding)
			{
				SetHealth(resourceInstance.GetStat(StatType.Health).GetNormalizedPercentage());
			}
			else
			{
				SetHealth(0f);
			}
			int max = resourceInstance.Amount;
			amount.SetText(max.ToString());
			float wealthPoints = resourceInstance.Blueprint.WealthPoints;
			price.SetText($"{TradeEntryLayoutItemView.ValueSprite} {wealthPoints:N2}");
			amountInput.SetMinMax(0, max);
			amountInput.SetTradeValue(0);
			itemName.SetDataText(GetItemName(), GetItemTooltip());
		}

		public void AddResourceAmount(int toAdd)
		{
			resourceAmount = math.max(0, resourceAmount + toAdd);
		}

		public void SubResourceAmount(int toSub)
		{
			resourceAmount = math.max(0, resourceAmount - toSub);
		}

		public void SetFiltered(bool isFiltered)
		{
			base.gameObject.SetActive(!isFiltered);
			this.isFiltered = isFiltered;
		}
	}
}
