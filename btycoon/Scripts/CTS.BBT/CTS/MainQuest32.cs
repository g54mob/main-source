using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class MainQuest32 : Quest
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float _targetStyleUnitInterval = 0.5f;

		[SerializeField]
		[QuestEntryPopup]
		private int _vladEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _vladVariableName;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		private bool _vladFeedbackPlayed;

		private StyleGoal _vladGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _yumekoEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _yumekoVariableName;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		private bool _yumekoFeedbackPlayed;

		private StyleGoal _yumekoGoal;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetVariableName;

		[SerializeField]
		[QuestEntryPopup]
		private int _vampireEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireTargetVariableName;

		private SpeciesServiceGoal _speciesServiceGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _dialogue01;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _dialogue02;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _dialogue03;

		private string _winnerDialogue;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_vladVariableName);
			ResetVariableTo0(_yumekoVariableName);
			ResetVariableTo0(_vampireVariableName);
		}

		protected override void StopObservingObjectives()
		{
			_vladGoal?.CleanStopObserving();
			_yumekoGoal?.CleanStopObserving();
			_speciesServiceGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			_vladGoal = new StyleGoal(this, _vladEntry, _vladVariableName, _targetVariableName, _targetStyleUnitInterval, EBarStyle.Basic, EBarStyle.Vampire);
			_yumekoGoal = new StyleGoal(this, _yumekoEntry, _yumekoVariableName, _targetVariableName, _targetStyleUnitInterval, EBarStyle.Kawaii, EBarStyle.Cyberpunk);
			_speciesServiceGoal = new SpeciesServiceGoal(this, _vampireEntry, _vampireVariableName, _vampireTargetVariableName, ESpecies.Vampire);
			_vladGoal?.StartObserving(OnVladGoalAchieved);
			_yumekoGoal?.StartObserving(OnYumekoGoalAchieved);
			_speciesServiceGoal?.StartObserving(CheckWinner);
		}

		private void OnVladGoalAchieved()
		{
			if (!_vladFeedbackPlayed)
			{
				DialogueHelper.StartConversation(_feedback01);
				_vladFeedbackPlayed = true;
			}
			_winnerDialogue = _dialogue01;
			CheckWinner();
		}

		private void OnYumekoGoalAchieved()
		{
			if (!_yumekoFeedbackPlayed)
			{
				DialogueHelper.StartConversation(_feedback03);
				_yumekoFeedbackPlayed = true;
			}
			_winnerDialogue = _dialogue03;
			CheckWinner();
		}

		private void CheckWinner()
		{
			if (_speciesServiceGoal.IsGoalSucceedeed && (_vladGoal.IsGoalSucceedeed || _yumekoGoal.IsGoalSucceedeed))
			{
				StartSuccess();
			}
		}

		public override IEnumerator QuestPostSuccessCoroutine()
		{
			yield return DialogueHelper.DialogueCoroutine(_winnerDialogue);
		}
	}
}
