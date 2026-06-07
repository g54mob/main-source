using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class SecondaryQuest01 : SecondaryQuest
	{
		private KillInvestigatorGoal _investogatorKillGoal;

		[SerializeField]
		private int _targetInvestigatorKillsValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _investigatorKillsEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetInvestigatorKills;

		[SerializeField]
		[VariablePopup(false)]
		private string _investigatorKills;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private DaysUnderVigilanceGoal _daysWithMaxVigilanceGoal;

		[SerializeField]
		private float _maxVigilanceValue;

		[SerializeField]
		private int _targetDaysValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _vigilanceDaysEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _maxVigilance;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetDays;

		[SerializeField]
		[VariablePopup(false)]
		private string _days;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		protected override void OnResetQuest()
		{
			base.OnResetQuest();
			ResetVariableTo0(_investigatorKills);
			ResetVariableTo0(_days);
		}

		protected override void StopObservingObjectives()
		{
			_investogatorKillGoal?.CleanStopObserving();
			_daysWithMaxVigilanceGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetInvestigatorKills, _targetInvestigatorKillsValue);
			DialogueLua.SetVariable(_maxVigilance, _maxVigilanceValue);
			DialogueLua.SetVariable(_targetDays, _targetDaysValue);
			_investogatorKillGoal = new KillInvestigatorGoal(this, _investigatorKillsEntry, _investigatorKills, _targetInvestigatorKills);
			_daysWithMaxVigilanceGoal = new DaysUnderVigilanceGoal(this, _vigilanceDaysEntry, _days, _targetDays, _maxVigilance);
			_investogatorKillGoal?.StartObserving(OnInvestigatorKillsAchieved);
			_daysWithMaxVigilanceGoal?.StartObserving(OnDaysWithMaxVigilanceAchieved);
		}

		private void OnInvestigatorKillsAchieved()
		{
			DialogueHelper.StartConversation(_feedback01);
			Barks.BarkAnyWorker(_bark01);
		}

		private void OnDaysWithMaxVigilanceAchieved()
		{
			DialogueHelper.StartConversation(_feedback02);
			Barks.BarkAnyWorker(_bark02);
		}
	}
}
