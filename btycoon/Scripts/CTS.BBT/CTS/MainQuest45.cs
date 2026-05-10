using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest45 : Quest
	{
		private DaysUnderVigilanceGoal _daysUnderVigilanceGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _daysEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _maxVigilance;

		[SerializeField]
		private int _maxVigilanceValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetDays;

		[SerializeField]
		private int _targetDaysValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _days;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		private BBTPositiveReviewsSpeciesGoal _humanReviewsGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		private BBTPositiveReviewsSpeciesGoal _vampireReviewsGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		[SerializeField]
		private BBTDaysWithoutRoomTypeGoal _roomTypeGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback04;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_days);
		}

		protected override void StopObservingObjectives()
		{
			_daysUnderVigilanceGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_maxVigilance, _maxVigilanceValue);
			DialogueLua.SetVariable(_targetDays, _targetDaysValue);
			_daysUnderVigilanceGoal = new DaysUnderVigilanceGoal(this, _daysEntry, _days, _targetDays, _maxVigilance);
			_daysUnderVigilanceGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark01);
			});
			_humanReviewsGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark02);
			});
			_vampireReviewsGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback03);
			});
			_roomTypeGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback04);
			});
		}
	}
}
