using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest46 : Quest
	{
		[SerializeField]
		private BBTKillInvestigatorGoal _investigatorsGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		private BBTSubSpeciesServiceGoal _ironJawsGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		private CustomerParameters _ironJaws;

		[SerializeField]
		private BBTDaysUnderVigilanceGoal _daysUnderVigilanceGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

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

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_turnover);
		}

		protected override void StopObservingObjectives()
		{
			_turnoverGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetTurnover, _targetTurnoverValue);
			_investigatorsGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark01);
			});
			_ironJawsGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnySpecificTypeCustomer(_ironJaws, _bark02);
			});
			_daysUnderVigilanceGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback03);
			});
			_turnoverGoal = new TurnoverGoal(this, _turnoverEntry, _turnover, _targetTurnover);
			_turnoverGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback04);
			});
		}
	}
}
