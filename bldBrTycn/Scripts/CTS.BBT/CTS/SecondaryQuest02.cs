using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class SecondaryQuest02 : SecondaryQuest
	{
		[SerializeField]
		private NavigationArea _navigationArea;

		private PlaceSpecificFurnitureInSpecificRoomTypeGoal<Cell> _cellsGoal;

		[SerializeField]
		private int _targetcellsValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _cellsEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetcells;

		[SerializeField]
		[VariablePopup(false)]
		private string _cells;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private LockInCellGoal _captureGoal;

		[SerializeField]
		private int _targetcaptureValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _captureEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetcapture;

		[SerializeField]
		[VariablePopup(false)]
		private string _capture;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		protected override void StopObservingObjectives()
		{
			_cellsGoal?.CleanStopObserving();
			_captureGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetcells, _targetcellsValue);
			DialogueLua.SetVariable(_targetcapture, _targetcaptureValue);
			_cellsGoal = new PlaceSpecificFurnitureInSpecificRoomTypeGoal<Cell>(this, _cellsEntry, _cells, _targetcells, _navigationArea);
			_captureGoal = new LockInCellGoal(this, _captureEntry, _capture, _targetcapture, _navigationArea);
			_cellsGoal?.StartObserving(OnCellsAchieved);
			_captureGoal?.StartObserving(OnCaptureAchieved);
		}

		private void OnCellsAchieved()
		{
			DialogueHelper.StartConversation(_feedback01);
			Barks.BarkAnyVampireCustomer(_bark01);
		}

		private void OnCaptureAchieved()
		{
			DialogueHelper.StartConversation(_feedback02);
			Barks.BarkAnyVampireCustomer(_bark02);
		}
	}
}
