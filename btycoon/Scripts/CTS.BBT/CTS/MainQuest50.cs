using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class MainQuest50 : Quest
	{
		private SpeciesServiceGoal _vampireGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _vampireEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireTarget;

		[SerializeField]
		private int _vampireTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampire;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_vampire);
		}

		protected override void StopObservingObjectives()
		{
			_vampireGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_vampireTarget, _vampireTargetValue);
			_vampireGoal = new SpeciesServiceGoal(this, _vampireEntry, _vampire, _vampireTarget, ESpecies.Vampire);
			_vampireGoal?.StartObserving();
		}
	}
}
