using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest23 : Quest
	{
		[SerializeField]
		[ConversationPopup(false, false)]
		private string _dialogue01;

		[SerializeField]
		private RewardData _reward01;

		[SerializeField]
		[QuestEntryPopup]
		private int _barEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		private ExtendBarGoal _extendBarGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _vampireEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireTargetVariableName;

		[SerializeField]
		private LocalizedString _bark01;

		private SpeciesServiceGoal _speciesServiceGoal;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_vampireVariableName);
		}

		protected override IEnumerator QuestIntroduction()
		{
			return DialogueHelper.DialogueCoroutine(_dialogue01, _reward01);
		}

		protected override void StopObservingObjectives()
		{
			_extendBarGoal?.CleanStopObserving();
			_speciesServiceGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			_extendBarGoal = new ExtendBarGoal(this, _barEntry);
			_speciesServiceGoal = new SpeciesServiceGoal(this, _vampireEntry, _vampireVariableName, _vampireTargetVariableName, ESpecies.Vampire);
			_extendBarGoal?.StartObserving(OnExtendBarGoalAchieved);
			_speciesServiceGoal?.StartObserving(OnSpeciesServiceGoalAchieved);
		}

		private void OnExtendBarGoalAchieved()
		{
			_extendBarGoal.Achieved -= OnExtendBarGoalAchieved;
			DialogueHelper.StartConversation(_feedback01);
		}

		private void OnSpeciesServiceGoalAchieved()
		{
			_speciesServiceGoal.Achieved -= OnSpeciesServiceGoalAchieved;
			Barks.BarkAnyWorker(_bark01);
		}
	}
}
