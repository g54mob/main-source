using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class SecondaryQuest08 : SecondaryQuest
	{
		private MaxVigilanceGoal _vigilanceGoal;

		[SerializeField]
		private int _targetVigilanceValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _vigilanceEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetVigilance;

		[SerializeField]
		[VariablePopup(false)]
		private string _vigilance;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private DaysUnderVigilanceGoal _daysGoal;

		[SerializeField]
		private int _targetDaysValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _daysEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetDays;

		[SerializeField]
		[VariablePopup(false)]
		private string _days;

		[SerializeField]
		private LocalizedString _bark02;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_vigilance);
			ResetVariableTo0(_days);
		}

		protected override void StopObservingObjectives()
		{
			_vigilanceGoal?.CleanStopObserving();
			_daysGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetVigilance, _targetVigilanceValue);
			DialogueLua.SetVariable(_targetDays, _targetDaysValue);
			_vigilanceGoal = new MaxVigilanceGoal(this, _vigilanceEntry, _vigilance, _targetVigilance);
			_vigilanceGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			}, delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
			_daysGoal = new DaysUnderVigilanceGoal(this, _daysEntry, _days, _targetDays, _targetVigilance);
			_daysGoal?.StartObserving(delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
		}
	}
}
