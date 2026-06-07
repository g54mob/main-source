using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest38 : Quest
	{
		private PositiveReviewsSpeciesGoal _humanReviewsGoal;

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
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private PositiveReviewsSpeciesGoal _vampireReviewsGoal;

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
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		private BBTHaveSpecificFurnitureInteractorGoal<Television> _tvGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		[SerializeField]
		private LocalizedString _bark03;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_humanReviews, _vampireReviews);
		}

		protected override void StopObservingObjectives()
		{
			_humanReviewsGoal?.CleanStopObserving();
			_vampireReviewsGoal?.CleanStopObserving();
			_tvGoal.StopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_humanReviewsTarget, _humanReviewsTargetValue);
			DialogueLua.SetVariable(_vampireReviewsTarget, _vampireReviewsTargetValue);
			_humanReviewsGoal = new PositiveReviewsSpeciesGoal(this, _humanReviewsEntry, _humanReviews, _humanReviewsTarget, ESpecies.Human);
			_humanReviewsGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyHumanCustomer(_bark01);
			});
			_vampireReviewsGoal = new PositiveReviewsSpeciesGoal(this, _vampireReviewsEntry, _vampireReviews, _vampireReviewsTarget, ESpecies.Vampire);
			_vampireReviewsGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
			_tvGoal.StartObserving(this, delegate
			{
				OnTVGoalAchieved();
			});
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			UnlockingManager.AddUnlockKey(EUnlockKey.RockDinnerBarPackage);
		}

		private void OnTVGoalAchieved()
		{
			DialogueHelper.StartFeedback(_feedback03);
			Barks.BarkAnyVampireCustomer(_bark03);
		}
	}
}
