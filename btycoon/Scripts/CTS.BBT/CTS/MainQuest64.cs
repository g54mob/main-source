using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest64 : Quest
	{
		private DaysUnderVigilanceGoal _daysUnderVigilanceGoal;

		[Header("Vigilance Over Time Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _daysUnderVigilanceEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _maxVigilance;

		[SerializeField]
		private int _maxVigilanceValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _daysUnderVigilanceTarget;

		[SerializeField]
		private int _daysUnderVigilanceValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _daysUnderVigilance;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _daysUnderVigilanceFeedback;

		[SerializeField]
		private LocalizedString _daysUnderVigilanceBark;

		private DaysWithoutWholesaler _wholesalerGoal;

		[Header("No Store Over Time Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _wholesalerEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _wholesalerTarget;

		[SerializeField]
		private int _wholesalerTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _wholesaler;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _wholesalerFeedback;

		[SerializeField]
		private LocalizedString _wholesalerBark;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_daysUnderVigilance, _wholesaler);
		}

		protected override void StopObservingObjectives()
		{
			_daysUnderVigilanceGoal?.CleanStopObserving();
			_wholesalerGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_maxVigilance, _maxVigilanceValue);
			DialogueLua.SetVariable(_daysUnderVigilanceTarget, _daysUnderVigilanceValue);
			DialogueLua.SetVariable(_wholesalerTarget, _wholesalerTargetValue);
			_daysUnderVigilanceGoal = new DaysUnderVigilanceGoal(this, _daysUnderVigilanceEntry, _daysUnderVigilance, _daysUnderVigilanceTarget, _maxVigilance);
			_daysUnderVigilanceGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_daysUnderVigilanceFeedback);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_daysUnderVigilanceBark);
			});
			_wholesalerGoal = new DaysWithoutWholesaler(this, _wholesalerEntry, _wholesaler, _wholesalerTarget);
			_wholesalerGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_wholesalerFeedback);
			}, delegate
			{
				Barks.BarkAnyWorker(_wholesalerBark);
			});
		}
	}
}
