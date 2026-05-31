using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest47 : Quest
	{
		[SerializeField]
		private BBTKillHunterGoal _hunterGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private ProcessHumansGoal _processHumansGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _processHumansEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetProcessHumans;

		[SerializeField]
		private int _targetProcessHumansValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _processHumans;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		private NoLoanGoal _noLoanGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _noLoanEntry;

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
			ResetVariableTo0(_processHumans, _turnover);
		}

		protected override void StopObservingObjectives()
		{
			_processHumansGoal?.CleanStopObserving();
			_noLoanGoal?.CleanStopObserving();
			_turnoverGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetProcessHumans, _targetProcessHumansValue);
			DialogueLua.SetVariable(_targetTurnover, _targetTurnoverValue);
			_hunterGoal.StartObserving(this, delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark01);
			});
			_processHumansGoal = new ProcessHumansGoal(this, _processHumansEntry, _processHumans, _targetProcessHumans);
			_processHumansGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark02);
			});
			_noLoanGoal = new NoLoanGoal(this, _noLoanEntry);
			_noLoanGoal?.StartObserving(delegate
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
