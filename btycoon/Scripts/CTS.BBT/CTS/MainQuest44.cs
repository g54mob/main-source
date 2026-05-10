using CTS.BBT;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest44 : Quest
	{
		private StockAmountQualityGoal _stockAmountQualityGoal;

		[SerializeField]
		private StockItemSO _blood;

		[SerializeField]
		[QuestEntryPopup]
		private int _stockAmountQualityEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetQuality;

		[SerializeField]
		private int _targetQualityValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetStockAmount;

		[SerializeField]
		private int _targetStockAmountValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _stockAmount;

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

		[SerializeField]
		private BBTSubSpeciesServiceGoal _speciesServiceGoal;

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
		private LocalizedString _bark03;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_stockAmount, _positiveReviews, _turnover);
		}

		protected override void StopObservingObjectives()
		{
			_stockAmountQualityGoal?.CleanStopObserving();
			_positiveReviewsGoal?.CleanStopObserving();
			_turnoverGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetQuality, _targetQualityValue);
			DialogueLua.SetVariable(_targetStockAmount, _targetStockAmountValue);
			DialogueLua.SetVariable(_targetPositiveReviews, _targetPositiveReviewsValue);
			DialogueLua.SetVariable(_targetTurnover, _targetTurnoverValue);
			_stockAmountQualityGoal = new StockAmountQualityGoal(this, _stockAmountQualityEntry, _stockAmount, _targetStockAmount, _targetQuality, _blood);
			_stockAmountQualityGoal?.StartObserving(delegate
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
			_speciesServiceGoal.StartObserving(this);
			_turnoverGoal = new TurnoverGoal(this, _turnoverEntry, _turnover, _targetTurnover);
			_turnoverGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback04);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark03);
			});
		}
	}
}
