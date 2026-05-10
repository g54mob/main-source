using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest40 : Quest
	{
		private RoomTypeGoal _roomGoal;

		[SerializeField]
		private NavigationArea _navArea;

		[SerializeField]
		[QuestEntryPopup]
		private int _roomEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _roomTarget;

		[SerializeField]
		private int _roomTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _room;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private SellDrinksGoal _sellGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _sellEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _sellTarget;

		[SerializeField]
		private int _sellTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _sell;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_room, _sell);
		}

		protected override void StopObservingObjectives()
		{
			_roomGoal?.CleanStopObserving();
			_sellGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_roomTarget, _roomTargetValue);
			DialogueLua.SetVariable(_sellTarget, _sellTargetValue);
			_roomGoal = new RoomTypeGoal(this, _roomEntry, _room, _roomTarget, _navArea);
			_roomGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyVampireCustomer(_bark01);
			});
			_sellGoal = new SellDrinksGoal(this, _sellEntry, _sell, _sellTarget);
			_sellGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			});
		}
	}
}
