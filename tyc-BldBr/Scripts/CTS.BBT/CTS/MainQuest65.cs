using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest65 : Quest
	{
		private ReaperKillGoal _reaperKillsGoal;

		[Header("Reaper Kills Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _reaperKillsEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _reaperKillsTarget;

		[SerializeField]
		private int _reaperKillsTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _reaperKills;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _reaperKillsFeedback;

		[SerializeField]
		private LocalizedString _reaperKillsBark;

		private ReaperMarkGoal _reaperMarksGoal;

		[Header("Reaper Marks Goal")]
		[SerializeField]
		[QuestEntryPopup]
		private int _reaperMarksEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _reaperMarksTarget;

		[SerializeField]
		private int _reaperMarksTargetValue;

		[SerializeField]
		[VariablePopup(false)]
		private string _reaperMarks;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _reaperMarksFeedback;

		[SerializeField]
		private LocalizedString _reaperMarksBark;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_reaperKills, _reaperMarks);
		}

		protected override void StopObservingObjectives()
		{
			_reaperKillsGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_reaperKillsTarget, _reaperKillsTargetValue);
			DialogueLua.SetVariable(_reaperMarksTarget, _reaperMarksTargetValue);
			_reaperKillsGoal = new ReaperKillGoal(this, _reaperKillsEntry, _reaperKills, _reaperKillsTarget);
			_reaperKillsGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_reaperKillsFeedback);
			});
			_reaperMarksGoal = new ReaperMarkGoal(this, _reaperMarksEntry, _reaperMarks, _reaperMarksTarget);
			_reaperMarksGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_reaperMarksFeedback);
			});
		}
	}
}
