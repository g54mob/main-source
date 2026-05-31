using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class SecondaryQuest07 : SecondaryQuest
	{
		[SerializeField]
		private NavigationArea _navigationArea;

		private NoRoomTypeGoal _noRoomGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _noRoomEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private DaysWithoutRoomTypeGoal _daysNoRoomGoal;

		[SerializeField]
		private int _targetDaysNoRoomValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _daysNoRoomEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetDaysNoRoom;

		[SerializeField]
		[VariablePopup(false)]
		private string _daysNoRoom;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_daysNoRoom);
		}

		protected override void StopObservingObjectives()
		{
			_noRoomGoal?.CleanStopObserving();
			_daysNoRoomGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetDaysNoRoom, _targetDaysNoRoomValue);
			_noRoomGoal = new NoRoomTypeGoal(this, _noRoomEntry, _navigationArea);
			_noRoomGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
			_daysNoRoomGoal = new DaysWithoutRoomTypeGoal(this, _daysNoRoomEntry, _daysNoRoom, _targetDaysNoRoom, _navigationArea);
			_daysNoRoomGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
		}
	}
}
