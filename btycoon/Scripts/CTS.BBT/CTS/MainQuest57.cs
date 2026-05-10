using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest57 : Quest
	{
		private DaysUnderVigilanceGoal _daysUnderVigilanceGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _daysUnderVigilanceEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _maxVigilance;

		[SerializeField]
		private int _maxVigilanceValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _daysUnderVigilanceTarget;

		[SerializeField]
		private int _daysUnderVigilanceValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _daysUnderVigilance;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private RoomTypeGoal _vampireRoomGoal;

		[SerializeField]
		private NavigationArea _navigationArea;

		[SerializeField]
		[QuestEntryPopup]
		private int _vampireRoomEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireRoomTarget;

		[SerializeField]
		private int _vampireRoomTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireRoom;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		private SpeciesServiceGoal _vampireServiceGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _vampireServiceEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireServiceTarget;

		[SerializeField]
		private int _vampireServiceTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _vampireService;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		[SerializeField]
		private LocalizedString _bark03;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_daysUnderVigilance, _vampireRoom, _vampireService);
		}

		protected override void StopObservingObjectives()
		{
			_daysUnderVigilanceGoal?.CleanStopObserving();
			_vampireRoomGoal?.CleanStopObserving();
			_vampireServiceGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_maxVigilance, _maxVigilanceValue);
			DialogueLua.SetVariable(_daysUnderVigilanceTarget, _daysUnderVigilanceValue);
			DialogueLua.SetVariable(_vampireRoomTarget, _vampireRoomTargetValue);
			DialogueLua.SetVariable(_vampireServiceTarget, _vampireServiceTargetValue);
			_daysUnderVigilanceGoal = new DaysUnderVigilanceGoal(this, _daysUnderVigilanceEntry, _daysUnderVigilance, _daysUnderVigilanceTarget, _maxVigilance);
			_daysUnderVigilanceGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
			_vampireRoomGoal = new RoomTypeGoal(this, _vampireRoomEntry, _vampireRoom, _vampireRoomTarget, _navigationArea);
			_vampireRoomGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
			_vampireServiceGoal = new SpeciesServiceGoal(this, _vampireServiceEntry, _vampireService, _vampireServiceTarget, ESpecies.Vampire);
			_vampireServiceGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback03);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark03);
			});
		}
	}
}
