using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest55 : Quest
	{
		private DaysWithoutRoomTypeGoal _noVampireRoomGoal;

		[SerializeField]
		private NavigationArea _navigationArea;

		[SerializeField]
		[QuestEntryPopup]
		private int _noVampireRoomEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _daysTarget;

		[SerializeField]
		private int _daysTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _days;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private SpeciesLureGoal _lureVampiresGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _lureVampiresEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _lureVampiresTarget;

		[SerializeField]
		private int _lureVampiresTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _lureVampires;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		private SpeciesLureGoal _lureHumansGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _lureHumansEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _lureHumansTarget;

		[SerializeField]
		private int _lureHumansTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _lureHumans;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		[SerializeField]
		private LocalizedString _bark03;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_days, _lureVampires, _lureHumans);
		}

		protected override void StopObservingObjectives()
		{
			_noVampireRoomGoal?.CleanStopObserving();
			_lureVampiresGoal?.CleanStopObserving();
			_lureHumansGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_daysTarget, _daysTargetValue);
			DialogueLua.SetVariable(_lureVampiresTarget, _lureVampiresTargetValue);
			DialogueLua.SetVariable(_lureHumansTarget, _lureHumansTargetValue);
			_noVampireRoomGoal = new DaysWithoutRoomTypeGoal(this, _noVampireRoomEntry, _days, _daysTarget, _navigationArea);
			_noVampireRoomGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
			_lureVampiresGoal = new SpeciesLureGoal(this, _lureVampiresEntry, _lureVampires, _lureVampiresTarget, ESpecies.Vampire);
			_lureVampiresGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
			_lureHumansGoal = new SpeciesLureGoal(this, _lureHumansEntry, _lureHumans, _lureHumansTarget, ESpecies.Human);
			_lureHumansGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback03);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark03);
			});
		}
	}
}
