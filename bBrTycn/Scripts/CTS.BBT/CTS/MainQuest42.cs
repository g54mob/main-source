using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest42 : Quest
	{
		private BarValueGoal _barValueGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _barValueEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetBarValue;

		[SerializeField]
		private int _targetBarValueValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _barValue;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private PositiveReviewsGoal _positiveReviewsGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _positiveReviewsEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetPositiveReviews;

		[SerializeField]
		private int _targetPositiveReviewsValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _positiveReviews;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		private DaysUnderVigilanceGoal _daysUnderVigilanceGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _daysEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _maxVigilance;

		[SerializeField]
		private float _maxVigilanceValue;

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
		private string _feedback03;

		[SerializeField]
		private LocalizedString _bark03;

		private TurnoverGoal _turnoverGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _turnoverEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetTurnover;

		[SerializeField]
		private int _targetTurnoverValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _turnover;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback04;

		[SerializeField]
		private LocalizedString _bark04;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_barValue, _positiveReviews, _days, _turnover);
		}

		protected override void StopObservingObjectives()
		{
			_barValueGoal?.CleanStopObserving();
			_positiveReviewsGoal?.CleanStopObserving();
			_daysUnderVigilanceGoal?.CleanStopObserving();
			_turnoverGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetBarValue, _targetBarValueValue);
			DialogueLua.SetVariable(_targetPositiveReviews, _targetPositiveReviewsValue);
			DialogueLua.SetVariable(_maxVigilance, _maxVigilanceValue);
			DialogueLua.SetVariable(_targetDays, _targetDaysValue);
			DialogueLua.SetVariable(_targetTurnover, _targetTurnoverValue);
			_barValueGoal = new BarValueGoal(this, _barValueEntry, _barValue, _targetBarValue);
			_barValueGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark01);
			});
			_positiveReviewsGoal = new PositiveReviewsGoal(this, _positiveReviewsEntry, _positiveReviews, _targetPositiveReviews);
			_positiveReviewsGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark02);
			});
			_daysUnderVigilanceGoal = new DaysUnderVigilanceGoal(this, _daysEntry, _days, _targetDays, _maxVigilance);
			_daysUnderVigilanceGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback03);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark03);
			});
			_turnoverGoal = new TurnoverGoal(this, _turnoverEntry, _turnover, _targetTurnover);
			_turnoverGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback04);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark04);
			});
		}
	}
}
