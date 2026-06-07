using System.Collections;
using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class SecondaryQuest04 : SecondaryQuest
	{
		[SerializeField]
		private StockMissionData _stockMissionData;

		[SerializeField]
		private StockItemSO _bloodSO;

		private BloodQualityGoal _bloodQualityGoal;

		[SerializeField]
		private int _targetbloodQualityValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _bloodQualityEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetbloodQuality;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodQuality;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

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
		private LocalizedString _bark02;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_bloodQuality);
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
			_bloodQualityGoal?.CleanStopObserving();
			_missionGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetbloodQuality, _targetbloodQualityValue);
			DialogueLua.SetVariable(_targetBloodDeliveries, _targetBloodDeliveriesValue);
			_bloodQualityGoal = new BloodQualityGoal(this, _bloodQualityEntry, _bloodQuality, _targetbloodQuality, _bloodSO);
			_bloodQualityGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
			_missionGoal = new SubStockMissionGoal(this, _bloodDeliveriesEntry, _bloodDeliveries, _targetBloodDeliveries, CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket, _bloodSO);
			_missionGoal?.StartObserving(delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
		}
	}
}
