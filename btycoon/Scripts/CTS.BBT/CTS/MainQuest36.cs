using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest36 : Quest
	{
		private PrestigeLevelGoal _prestigeGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _prestigeEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _prestigeTarget;

		[SerializeField]
		private int _prestigeTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _prestige;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private RoomTypeGoal _roomsGoal;

		[SerializeField]
		private NavigationArea _navArea;

		[SerializeField]
		[QuestEntryPopup]
		private int _roomsEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _roomsTarget;

		[SerializeField]
		private int _roomsTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _rooms;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		private HypnoticTrapCaptureGoal _captureGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _captureEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _captureTarget;

		[SerializeField]
		private int _captureTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _capture;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		[SerializeField]
		private LocalizedString _bark03;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_prestige, _rooms, _capture);
		}

		protected override void StopObservingObjectives()
		{
			_prestigeGoal?.CleanStopObserving();
			_roomsGoal?.CleanStopObserving();
			_captureGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_prestigeTarget, _prestigeTargetValue);
			DialogueLua.SetVariable(_roomsTarget, _roomsTargetValue);
			DialogueLua.SetVariable(_captureTarget, _captureTargetValue);
			_prestigeGoal = new PrestigeLevelGoal(this, _prestigeEntry, _prestige, _prestigeTarget);
			_prestigeGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
			_roomsGoal = new RoomTypeGoal(this, _roomsEntry, _rooms, _roomsTarget, _navArea);
			_roomsGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
			_captureGoal = new HypnoticTrapCaptureGoal(this, _captureEntry, _capture, _captureTarget);
			_captureGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback03);
			}, delegate
			{
				Barks.BarkAnyHumanCustomer(_bark03);
			});
		}
	}
}
