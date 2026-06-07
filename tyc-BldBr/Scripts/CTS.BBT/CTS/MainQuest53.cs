using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest53 : Quest
	{
		private DanceTrapCaptureGoal _danceTrapCaptureGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _danceTrapCaptureEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _danceTrapCaptureTarget;

		[SerializeField]
		private int _danceTrapCaptureTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _danceTrapCapture;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private LockInCellSimultaneousGoal _lockInCellSimultaneousGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _lockInCellSimultaneousEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _lockInCellSimultaneousTarget;

		[SerializeField]
		private int _lockInCellSimultaneousTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _lockInCellSimultaneous;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_danceTrapCapture, _lockInCellSimultaneous);
		}

		protected override void StopObservingObjectives()
		{
			_danceTrapCaptureGoal?.CleanStopObserving();
			_lockInCellSimultaneousGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_danceTrapCaptureTarget, _danceTrapCaptureTargetValue);
			DialogueLua.SetVariable(_lockInCellSimultaneousTarget, _lockInCellSimultaneousTargetValue);
			_danceTrapCaptureGoal = new DanceTrapCaptureGoal(this, _danceTrapCaptureEntry, _danceTrapCapture, _danceTrapCaptureTarget);
			_danceTrapCaptureGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
			_lockInCellSimultaneousGoal = new LockInCellSimultaneousGoal(this, _lockInCellSimultaneousEntry, _lockInCellSimultaneous, _lockInCellSimultaneousTarget);
			_lockInCellSimultaneousGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
		}
	}
}
