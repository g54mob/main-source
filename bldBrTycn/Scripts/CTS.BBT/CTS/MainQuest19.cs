using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class MainQuest19 : Level02Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _prestigeEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _currentPrestigeVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetPrestigeVariableName;

		[SerializeField]
		private int _targetPrestigeVariableNameValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _moneyEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _currentMoneyVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetMoneyVariableName;

		[SerializeField]
		private int _targetMoneyVariableNameValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _bloodBagsEntry;

		[SerializeField]
		private StockItemSO _blood;

		[SerializeField]
		[VariablePopup(false)]
		private string _currentBloodBagsVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetBloodBagsVariableName;

		[SerializeField]
		private int _targetBloodBagsVariableNameValue;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_currentBloodBagsVariableName);
			ResetVariableTo0(_currentMoneyVariableName);
			ResetVariableTo0(_currentPrestigeVariableName);
		}

		protected override void StopObservingObjectives()
		{
			Prestige.PrestigeLevelChanged -= OnPrestigeLevelChanged;
			MoneyHandler.MoneyAmountChanged -= OnMoneyAmountChanged;
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetPrestigeVariableName, _targetPrestigeVariableNameValue);
			DialogueLua.SetVariable(_targetMoneyVariableName, _targetMoneyVariableNameValue);
			DialogueLua.SetVariable(_targetBloodBagsVariableName, _targetBloodBagsVariableNameValue);
			Prestige.PrestigeLevelChanged += OnPrestigeLevelChanged;
			OnPrestigeLevelChanged(MonoSingleton<Prestige>.Instance.CurrentPrestigeLevel);
			MoneyHandler.MoneyAmountChanged += OnMoneyAmountChanged;
			OnMoneyAmountChanged(MonoSingleton<MoneyHandler>.Instance.CurrentMoney);
			Stocks.BarStock.RegisterToStockChange(_blood, OnBloodStockChange);
			OnBloodStockChange(default(StockInventory<StockStack, StockItemSO>.StockItemChangedData));
		}

		private void OnBloodStockChange(StockInventory<StockStack, StockItemSO>.StockItemChangedData data)
		{
			if (Stocks.BarStock.TryPeekFirst(_blood.StockType, _blood, out var peekedStack) && SetQuestEntryVariable(_bloodBagsEntry, _currentBloodBagsVariableName, peekedStack.StackCount, _targetBloodBagsVariableName))
			{
				Stocks.BarStock.UnregisterToStockChange(_blood, OnBloodStockChange);
				QuestEntrySuccess(_bloodBagsEntry);
			}
		}

		private void OnMoneyAmountChanged(int amount)
		{
			if (SetQuestEntryVariable(_moneyEntry, _currentMoneyVariableName, amount, _targetMoneyVariableName))
			{
				MoneyHandler.MoneyAmountChanged -= OnMoneyAmountChanged;
				QuestEntrySuccess(_moneyEntry);
			}
		}

		private void OnPrestigeLevelChanged(PrestigeLevelData data)
		{
			if (SetQuestEntryVariable(_prestigeEntry, _currentPrestigeVariableName, data.Level, _targetPrestigeVariableName))
			{
				Prestige.PrestigeLevelChanged -= OnPrestigeLevelChanged;
				QuestEntrySuccess(_prestigeEntry);
			}
		}
	}
}
