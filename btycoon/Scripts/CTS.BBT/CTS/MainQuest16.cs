using System.Collections;
using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest16 : Level02Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _bloodQualityEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _currentBloodQualityVariable;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetBloodQualityVariable;

		[SerializeField]
		private int _targetBloodQualityVariableValue;

		[SerializeField]
		private StockItemSO _blood;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		[QuestEntryPopup]
		private int _cellQualityEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _currentCellQualityVariable;

		[SerializeField]
		[QuestEntryPopup]
		private int _machineQualityEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _currentMachineQualityVariable;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetQualityVariable;

		[SerializeField]
		private int _targetQualityVariableValue;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		[QuestEntryPopup]
		private int _deliveryTabEntry;

		[SerializeField]
		private StringKey _stockMissionTab;

		[SerializeField]
		private LocalizedString _bark03;

		[SerializeField]
		[QuestEntryPopup]
		private int _bloodBagEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetBloodBagDeliveryVariable;

		[SerializeField]
		private StockMissionData _stockMissionData;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_currentBloodQualityVariable);
			ResetVariableTo0(_currentCellQualityVariable);
			ResetVariableTo0(_currentMachineQualityVariable);
		}

		protected override IEnumerator QuestIntroduction()
		{
			DialogueManager.StopAllConversations();
			base.QuestChain.MissionBasket.SetMission(_stockMissionData);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			UI_StockPopulator.PanelOpened -= OnStockUIShown;
			Stocks.BarStock.UnregisterToStockChange(_blood, OnBloodStockChange);
			MissionBasket.MissionEnded -= OnMissionEnded;
			MachineBase.BloodQualityChanged -= OnMachineQualityChanged;
			MachineBase.BloodQualityChanged -= OnCellQualityChanged;
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetBloodQualityVariable, _targetBloodQualityVariableValue);
			DialogueLua.SetVariable(_targetQualityVariable, _targetQualityVariableValue);
			DialogueLua.SetVariable(_targetBloodBagDeliveryVariable, base.QuestChain.MissionBasket.CurrentMissionStatus[_blood].RequiredCount);
			Stocks.BarStock.RegisterToStockChange(_blood, OnBloodStockChange);
			OnBloodStockChange(default(StockInventory<StockStack, StockItemSO>.StockItemChangedData));
			MachineBase.BloodQualityChanged += OnMachineQualityChanged;
			MachineBase.BloodQualityChanged += OnCellQualityChanged;
			UI_StockPopulator.PanelOpened += OnStockUIShown;
			OnBloodStockChange(default(StockInventory<StockStack, StockItemSO>.StockItemChangedData));
			MissionBasket.MissionEnded += OnMissionEnded;
			HighlightButton.Highlight(BBTUI.Instance.ButtonID_Stocks);
			HighlightButton.Highlight(BBTUI.Instance.ButtonID_StocksMissionBasket);
		}

		private void OnMachineQualityChanged(MachineBase machine, int quality)
		{
			if (!(machine is Cell) && SetQuestEntryVariable(_machineQualityEntry, _currentMachineQualityVariable, quality, _targetQualityVariable))
			{
				MachineBase.BloodQualityChanged -= OnMachineQualityChanged;
				QuestEntrySuccess(_machineQualityEntry);
			}
		}

		private void OnCellQualityChanged(MachineBase machine, int quality)
		{
			if (machine is Cell && SetQuestEntryVariable(_cellQualityEntry, _currentCellQualityVariable, quality, _targetQualityVariable))
			{
				MachineBase.BloodQualityChanged -= OnCellQualityChanged;
				QuestEntrySuccess(_cellQualityEntry);
			}
		}

		private void OnMissionEnded(MissionBasket basket, MissionBasket.MissionResult result)
		{
			if (!(basket != base.QuestChain.MissionBasket) && result.Result == MissionBasket.EMissionResult.Full)
			{
				MissionBasket.MissionEnded -= OnMissionEnded;
				QuestEntrySuccess(_bloodBagEntry);
			}
		}

		private void OnStockUIShown(StringKey key)
		{
			if (key.IsValid() && key == _stockMissionTab)
			{
				UI_StockPopulator.PanelOpened -= OnStockUIShown;
				QuestEntrySuccess(_deliveryTabEntry);
			}
		}

		private void OnBloodStockChange(StockInventory<StockStack, StockItemSO>.StockItemChangedData data)
		{
			if (Stocks.BarStock.TryPeekFirst(_blood.StockType, _blood, out var peekedStack) && SetQuestEntryVariable(_bloodQualityEntry, _currentBloodQualityVariable, peekedStack.Quality, _targetBloodQualityVariable))
			{
				Stocks.BarStock.UnregisterToStockChange(_blood, OnBloodStockChange);
				QuestEntrySuccess(_bloodQualityEntry);
			}
		}
	}
}
