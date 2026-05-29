using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest26 : Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _punchingBallEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		private BuySpecificFurnitureInteractorGoal<PunchingBall> _punchingBallGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _captureEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _captureVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _captureTargetVariableName;

		[SerializeField]
		private int _captureTargetVariableNameValue;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark01;

		private PunchingBallCaptureGoal _punchingBallCaptureGoal;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_captureVariableName);
		}

		protected override void StopObservingObjectives()
		{
			_punchingBallGoal?.CleanStopObserving();
			_punchingBallCaptureGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_captureTargetVariableName, _captureTargetVariableNameValue);
			_punchingBallGoal = new BuySpecificFurnitureInteractorGoal<PunchingBall>(this, _punchingBallEntry);
			_punchingBallCaptureGoal = new PunchingBallCaptureGoal(this, _captureEntry, _captureVariableName, _captureTargetVariableName);
			_punchingBallGoal.StartObserving(OnPunchingBallGoalAchieved);
			_punchingBallCaptureGoal.StartObserving(OnCaptureGoalAchieved);
		}

		private void OnPunchingBallGoalAchieved()
		{
			_punchingBallGoal.Achieved -= OnPunchingBallGoalAchieved;
			DialogueHelper.StartConversation(_feedback01);
		}

		private void OnCaptureGoalAchieved()
		{
			_punchingBallCaptureGoal.Achieved -= OnCaptureGoalAchieved;
			DialogueHelper.StartConversation(_feedback02);
		}
	}
}
