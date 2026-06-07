using System.Collections;
using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest61 : Quest
	{
		private PositiveReviewsSpeciesGoal _humanReviewsGoal;

		[Header("Human Reviews Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _humanReviewsEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _humanReviewsTarget;

		[SerializeField]
		private int _humanReviewsTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _humanReviews;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _humanReviewsFeedback;

		[SerializeField]
		private LocalizedString _humanReviewsBark;

		private PositiveReviewsSpeciesGoal _vampireReviewsGoal;

		[Header("Vampire Reviews Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _vampireReviewsEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireReviewsTarget;

		[SerializeField]
		private int _vampireReviewsTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireReviews;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _vampireReviewsFeedback;

		[SerializeField]
		private LocalizedString _vampireReviewsBark;

		private SubStockMissionGoal _earlGreyGoal;

		[Header("Earl Grey Delivery Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _earlGreyEntry;

		[SerializeField]
		private StockMissionData _stockMissionData;

		[SerializeField]
		private StockItemSO _earlGreySO;

		[SerializeField]
		[VariablePopup(false)]
		private string _earlGreyTarget;

		[SerializeField]
		[VariablePopup(false)]
		private string _earlGrey;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _earlGreyFeedback;

		[SerializeField]
		private LocalizedString _earlGreyBark;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_humanReviews, _vampireReviews, _earlGrey);
		}

		protected override IEnumerator QuestIntroduction()
		{
			CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.SetMission(_stockMissionData);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			_humanReviewsGoal?.CleanStopObserving();
			_vampireReviewsGoal?.CleanStopObserving();
			_earlGreyGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_humanReviewsTarget, _humanReviewsTargetValue);
			DialogueLua.SetVariable(_vampireReviewsTarget, _vampireReviewsTargetValue);
			MissionBasket mainMissionBasket = CTSSingleton<StoreBaskets>.Instance.MainMissionBasket;
			DialogueLua.SetVariable(_earlGreyTarget, mainMissionBasket.CurrentMissionStatus[_earlGreySO].RequiredCount);
			_humanReviewsGoal = new PositiveReviewsSpeciesGoal(this, _humanReviewsEntry, _humanReviews, _humanReviewsTarget, ESpecies.Human);
			_humanReviewsGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_humanReviewsFeedback);
			}, delegate
			{
				Barks.BarkAnyHumanCustomer(_humanReviewsBark);
			});
			_vampireReviewsGoal = new PositiveReviewsSpeciesGoal(this, _vampireReviewsEntry, _vampireReviews, _vampireReviewsTarget, ESpecies.Vampire);
			_vampireReviewsGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_vampireReviewsFeedback);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_vampireReviewsBark);
			});
			_earlGreyGoal = new SubStockMissionGoal(this, _earlGreyEntry, _earlGrey, _earlGreyTarget, mainMissionBasket, _earlGreySO);
			_earlGreyGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_earlGreyFeedback);
			}, delegate
			{
				Barks.BarkAnyWorker(_earlGreyBark);
			});
		}
	}
}
