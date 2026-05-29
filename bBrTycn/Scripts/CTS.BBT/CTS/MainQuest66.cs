using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest66 : Quest
	{
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

		private RoomTypeGoal _vampireRoomsGoal;

		[Header("Vampire Room Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _vampireRoomsEntry;

		[SerializeField]
		private NavigationArea _vampireNavArea;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireRoomsTarget;

		[SerializeField]
		private int _vampireRoomsTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireRooms;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _vampireRoomsFeedback;

		[SerializeField]
		private LocalizedString _vampireRoomsBark;

		private NoLoanGoal _noLoanGoal;

		[Header("No Loan Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _noLoanEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _noLoanFeedback;

		private TurnoverGoal _turnoverGoal;

		[Header("Turnover Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _turnoverEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _turnoverTarget;

		[SerializeField]
		private int _turnoverTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _turnover;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _turnoverFeedback;

		[SerializeField]
		private LocalizedString _turnoverBark;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_vampireReviews, _vampireRooms, _turnover);
		}

		protected override void StopObservingObjectives()
		{
			_vampireReviewsGoal?.CleanStopObserving();
			_vampireRoomsGoal?.CleanStopObserving();
			_noLoanGoal?.CleanStopObserving();
			_turnoverGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_vampireReviewsTarget, _vampireReviewsTargetValue);
			_vampireReviewsGoal = new PositiveReviewsSpeciesGoal(this, _vampireReviewsEntry, _vampireReviews, _vampireReviewsTarget, ESpecies.Vampire);
			_vampireReviewsGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_vampireReviewsFeedback);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_vampireReviewsBark);
			});
			DialogueLua.SetVariable(_vampireRoomsTarget, _vampireRoomsTargetValue);
			_vampireRoomsGoal = new RoomTypeGoal(this, _vampireRoomsEntry, _vampireRooms, _vampireRoomsTarget, _vampireNavArea);
			_vampireRoomsGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_vampireRoomsFeedback);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_vampireRoomsBark);
			});
			_noLoanGoal = new NoLoanGoal(this, _noLoanEntry);
			_noLoanGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_noLoanFeedback);
			});
			DialogueLua.SetVariable(_turnoverTarget, _turnoverTargetValue);
			_turnoverGoal = new TurnoverGoal(this, _turnoverEntry, _turnover, _turnoverTarget);
			_turnoverGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_turnoverFeedback);
			}, delegate
			{
				Barks.BarkAnyWorker(_turnoverBark);
			});
		}
	}
}
