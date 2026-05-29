using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class SecondaryQuest03 : SecondaryQuest
	{
		[SerializeField]
		private CustomerParameters _gobblersSO;

		private SubSpeciesServiceGoal _gobblersGoal;

		[SerializeField]
		private int _targetgobblersValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _gobblersEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetgobblers;

		[SerializeField]
		[VariablePopup(false)]
		private string _gobblers;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_gobblers);
		}

		protected override void StopObservingObjectives()
		{
			_gobblersGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetgobblers, _targetgobblersValue);
			_gobblersGoal = new SubSpeciesServiceGoal(this, _gobblersEntry, _gobblers, _targetgobblers, ESubSpecies.Gobbler);
			_gobblersGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnySpecificTypeCustomer(_gobblersSO, _bark01);
			});
		}
	}
}
