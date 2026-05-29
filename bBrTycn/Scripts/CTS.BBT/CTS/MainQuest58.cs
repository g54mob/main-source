using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest58 : Quest
	{
		private SellDrinksGoal _sellDrinksGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _sellDrinksEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _sellDrinksTarget;

		[SerializeField]
		private int _sellDrinksTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _sellDrinks;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private MachineCaptureGoal _captureMachineGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _captureMachineEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _captureMachineTarget;

		[SerializeField]
		private int _captureMachineTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _captureMachine;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		private ProcessHumansGoal _processGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _processEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _processTarget;

		[SerializeField]
		private int _processTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _process;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		[SerializeField]
		private LocalizedString _bark03;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_sellDrinks, _captureMachine, _process);
		}

		protected override void StopObservingObjectives()
		{
			_sellDrinksGoal?.CleanStopObserving();
			_captureMachineGoal?.CleanStopObserving();
			_processGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_sellDrinksTarget, _sellDrinksTargetValue);
			DialogueLua.SetVariable(_captureMachineTarget, _captureMachineTargetValue);
			DialogueLua.SetVariable(_processTarget, _processTargetValue);
			_sellDrinksGoal = new SellDrinksGoal(this, _sellDrinksEntry, _sellDrinks, _sellDrinksTarget);
			_sellDrinksGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
			_captureMachineGoal = new MachineCaptureGoal(this, _captureMachineEntry, _captureMachine, _captureMachineTarget);
			_captureMachineGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
			_processGoal = new ProcessHumansGoal(this, _processEntry, _process, _processTarget);
			_processGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback03);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark03);
			});
		}
	}
}
