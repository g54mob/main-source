using System.Collections;
using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class SecondaryQuest06 : SecondaryQuest
	{
		[SerializeField]
		private StockMissionData _stockMissionData;

		[SerializeField]
		private StockItemSO _bloodSO;

		private SubStockMissionGoal _missionGoal;

		[SerializeField]
		private int _targetBloodDeliveriesValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _bloodDeliveriesEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetBloodDeliveries;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodDeliveries;

		[SerializeField]
		private LocalizedString _bark01;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_bloodDeliveries);
		}

		protected override IEnumerator QuestIntroduction()
		{
			SetMissionBasket(_stockMissionData);
			DialogueLua.SetVariable(_targetBloodDeliveries, CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket.CurrentMissionStatus[_bloodSO].RequiredCount);
			return base.QuestIntroduction();
		}

		protected override void StopObservingObjectives()
		{
			_missionGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetBloodDeliveries, _targetBloodDeliveriesValue);
			_missionGoal = new SubStockMissionGoal(this, _bloodDeliveriesEntry, _bloodDeliveries, _targetBloodDeliveries, CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket, _bloodSO);
			_missionGoal?.StartObserving(delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
		}
	}
}
