using CTS.BBT;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest39 : Quest
	{
		private SubSpeciesServiceGoal _jawsGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _jawsEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _jawsTarget;

		[SerializeField]
		private int _jawsTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _jaws;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private PanicGoal _panicGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _panicEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _panicTarget;

		[SerializeField]
		private int _panicTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _panic;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		private ServeDrinkSpecificGoal _smokedGoal;

		[SerializeField]
		private DrinkSO _smokedSO;

		[SerializeField]
		[QuestEntryPopup]
		private int _smokedEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _smokedTarget;

		[SerializeField]
		private int _smokedTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _smoked;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_jaws, _panic, _smoked);
		}

		protected override void StopObservingObjectives()
		{
			_jawsGoal?.CleanStopObserving();
			_panicGoal?.CleanStopObserving();
			_smokedGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_jawsTarget, _jawsTargetValue);
			DialogueLua.SetVariable(_panicTarget, _panicTargetValue);
			DialogueLua.SetVariable(_smokedTarget, _smokedTargetValue);
			_jawsGoal = new SubSpeciesServiceGoal(this, _jawsEntry, _jaws, _jawsTarget, ESubSpecies.SewerDweller);
			_jawsGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark01);
			});
			_panicGoal = new PanicGoal(this, _panicEntry, _panic, _panicTarget);
			_panicGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark02);
			});
			_smokedGoal = new ServeDrinkSpecificGoal(this, _smokedEntry, _smoked, _smokedTarget, _smokedSO);
			_smokedGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback03);
			});
		}
	}
}
