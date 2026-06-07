using System.Collections;
using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest54 : Quest
	{
		[SerializeField]
		private StockMissionData _stockMissionData;

		private SubStockMissionGoal _bloodEarlGreyGoal;

		[SerializeField]
		private StockItemSO _bloodEarlGreySO;

		[SerializeField]
		[QuestEntryPopup]
		private int _bloodEarlGreyEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodEarlGreyTarget;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodEarlGrey;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private SubStockMissionGoal _bloodBagsGoal;

		[SerializeField]
		private StockItemSO _bloodBagSO;

		[SerializeField]
		[QuestEntryPopup]
		private int _bloodBagsEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodBagsTarget;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodBags;

		private SubStockMissionGoal _smokedBloodGoal;

		[SerializeField]
		private StockItemSO _smokedBloodSO;

		[SerializeField]
		[QuestEntryPopup]
		private int _smokedBloodEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _smokedBloodTarget;

		[SerializeField]
		[VariablePopup(false)]
		private string _smokedBlood;

		private SubStockMissionGoal _granitaGoal;

		[SerializeField]
		private StockItemSO _granitaSO;

		[SerializeField]
		[QuestEntryPopup]
		private int _granitaEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _granitaTarget;

		[SerializeField]
		[VariablePopup(false)]
		private string _granita;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_bloodEarlGrey, _bloodBags, _smokedBlood, _granita);
		}

		protected override IEnumerator QuestIntroduction()
		{
			CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.SetMission(_stockMissionData);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			_bloodEarlGreyGoal?.CleanStopObserving();
			_bloodBagsGoal?.CleanStopObserving();
			_smokedBloodGoal?.CleanStopObserving();
			_granitaGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			MissionBasket mainMissionBasket = CTSSingleton<StoreBaskets>.Instance.MainMissionBasket;
			DialogueLua.SetVariable(_bloodEarlGreyTarget, mainMissionBasket.CurrentMissionStatus[_bloodEarlGreySO].RequiredCount);
			DialogueLua.SetVariable(_bloodBagsTarget, mainMissionBasket.CurrentMissionStatus[_bloodBagSO].RequiredCount);
			DialogueLua.SetVariable(_smokedBloodTarget, mainMissionBasket.CurrentMissionStatus[_smokedBloodSO].RequiredCount);
			DialogueLua.SetVariable(_granitaTarget, mainMissionBasket.CurrentMissionStatus[_granitaSO].RequiredCount);
			_bloodEarlGreyGoal = new SubStockMissionGoal(this, _bloodEarlGreyEntry, _bloodEarlGrey, _bloodEarlGreyTarget, mainMissionBasket, _bloodEarlGreySO);
			_bloodEarlGreyGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
			_bloodBagsGoal = new SubStockMissionGoal(this, _bloodBagsEntry, _bloodBags, _bloodBagsTarget, mainMissionBasket, _bloodBagSO);
			_bloodBagsGoal?.StartObserving();
			_smokedBloodGoal = new SubStockMissionGoal(this, _smokedBloodEntry, _smokedBlood, _smokedBloodTarget, mainMissionBasket, _smokedBloodSO);
			_smokedBloodGoal?.StartObserving();
			_granitaGoal = new SubStockMissionGoal(this, _granitaEntry, _granita, _granitaTarget, mainMissionBasket, _granitaSO);
			_granitaGoal?.StartObserving();
		}
	}
}
