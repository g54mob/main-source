using System.Collections;
using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class MainQuest60 : Quest
	{
		private LoanGoal _loanGoal;

		[Header("Loan Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _loanEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _loanFeedback;

		private SubStockMissionGoal _shakeBloodGoal;

		[Header("Shake Blood Delivery Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _shakeBloodEntry;

		[SerializeField]
		private StockMissionData _stockMissionData;

		[SerializeField]
		private StockItemSO _shakeBloodSO;

		[SerializeField]
		[VariablePopup(false)]
		private string _shakeBloodTarget;

		[SerializeField]
		[VariablePopup(false)]
		private string _shakeBlood;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _shakeBloodFeedback;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_shakeBlood);
		}

		protected override IEnumerator QuestIntroduction()
		{
			CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.SetMission(_stockMissionData);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			_loanGoal?.CleanStopObserving();
			_shakeBloodGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			MissionBasket mainMissionBasket = CTSSingleton<StoreBaskets>.Instance.MainMissionBasket;
			if (mainMissionBasket.CurrentMissionStatus.TryGetValue(_shakeBloodSO, out var value))
			{
				DialogueLua.SetVariable(_shakeBloodTarget, value.RequiredCount);
			}
			else
			{
				DialogueLua.SetVariable(_shakeBlood, 10);
				DialogueLua.SetVariable(_shakeBloodTarget, 10);
			}
			_loanGoal = new LoanGoal(this, _loanEntry);
			_loanGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_loanFeedback);
			});
			_shakeBloodGoal = new SubStockMissionGoal(this, _shakeBloodEntry, _shakeBlood, _shakeBloodTarget, mainMissionBasket, _shakeBloodSO);
			_shakeBloodGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_shakeBloodFeedback);
			});
		}
	}
}
