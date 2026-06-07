using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest30 : Quest
	{
		private PrestigeLevelGoal _prestigeLevelGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _prestigeEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		[VariablePopup(false)]
		private string _prestigeVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _prestigeTargetVariableName;

		[SerializeField]
		private int _prestigeTargetVariableNameValue;

		[SerializeField]
		private LocalizedString _bark01;

		private MaxVigilanceGoal _vigilanceGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _vigilanceEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetVigilance;

		[SerializeField]
		private int _targetVigilanceValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _vigilance;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_prestigeVariableName);
		}

		protected override void StopObservingObjectives()
		{
			_prestigeLevelGoal?.CleanStopObserving();
			_vigilanceGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_prestigeTargetVariableName, _prestigeTargetVariableNameValue);
			DialogueLua.SetVariable(_targetVigilance, _targetVigilanceValue);
			_prestigeLevelGoal = new PrestigeLevelGoal(this, _prestigeEntry, _prestigeVariableName, _prestigeTargetVariableName);
			_prestigeLevelGoal.StartObserving(OnPrestigeGoalAchieved);
			_vigilanceGoal = new MaxVigilanceGoal(this, _vigilanceEntry, _vigilance, _targetVigilance);
			_vigilanceGoal?.StartObserving();
		}

		private void OnPrestigeGoalAchieved()
		{
			_prestigeLevelGoal.Achieved -= OnPrestigeGoalAchieved;
			Barks.BarkAnyVampireCustomer(_bark01);
			DialogueHelper.StartConversation(_feedback01);
		}
	}
}
