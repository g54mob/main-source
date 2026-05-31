using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest05 : Level01Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _selectID;

		[SerializeField]
		[QuestEntryPopup]
		private int _autonomyID;

		[SerializeField]
		[QuestEntryPopup]
		private int _cleaningID;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		private CustomerSpawn _customerSpawn;

		[SerializeField]
		private MoveTarget _moveTarget;

		[SerializeField]
		private UIGifsListSO _autonomyVideos;

		[InjectScope(EGetScope.Singleton)]
		[Inject(false)]
		private WorkerPriorityPanel _priorityPanel;

		protected override void QuestSetup()
		{
			base.QuestChain.ToggleWorkersGlobalAutonomy(value: true);
		}

		protected override void StartObservingObjectives()
		{
			CTSSingleton<UIHelpingGifs>.Instance.ChooseHelpList(_autonomyVideos);
			if (base.QuestChain.FirstWorker.ChoreAssigner.TryGetPrioritySelfActive(ChoreCategory.Cleaning, out var selfEnabled) && selfEnabled)
			{
				QuestEntrySuccess(_cleaningID);
			}
			else
			{
				WorkerChoreAssigner.OnPriorityStatusChanged += OnPriorityStatusChanged;
			}
			if (base.QuestChain.FirstWorker.ChoreAssigner.ObjectLock.IsUnlocked())
			{
				QuestEntrySuccess(_autonomyID);
			}
			else
			{
				WorkerChoreAssigner.OnAutonomyActive += OnAutonomyActive;
			}
			Worker.OnSelect += Worker_OnSelect;
			if (WorldSelector.IsObjectSelected(base.QuestChain.FirstWorker.Selection.SelectableObject))
			{
				Worker_OnSelect(base.QuestChain.FirstWorker);
			}
			if (IsEntryStateActive(_autonomyID))
			{
				_priorityPanel.HighlightAutonomy(isActive: true);
			}
			else if (IsEntryStateActive(_cleaningID))
			{
				_priorityPanel.HighlightCategory(ChoreCategory.Cleaning);
			}
		}

		private void OnPriorityStatusChanged(Worker worker, ChoreCategory priority, bool active)
		{
			if (priority == ChoreCategory.Cleaning && active)
			{
				QuestEntrySuccess(_selectID);
				if (IsEntryStateActive(_cleaningID))
				{
					_priorityPanel.StopHighlightCategory(ChoreCategory.Cleaning);
					QuestEntrySuccess(_cleaningID);
				}
			}
		}

		private void Worker_OnSelect(Worker worker)
		{
			Worker.OnSelect -= Worker_OnSelect;
			if (QuestLog.GetQuestEntryState(_questName, _selectID) != QuestState.Success)
			{
				QuestEntrySuccess(_selectID);
			}
		}

		private void OnAutonomyActive(Worker worker, bool active)
		{
			if (active && IsEntryStateActive(_autonomyID))
			{
				_priorityPanel.HighlightAutonomy(isActive: false);
				if (IsEntryStateActive(_cleaningID))
				{
					_priorityPanel.HighlightCategory(ChoreCategory.Cleaning);
				}
				QuestEntrySuccess(_autonomyID);
				BarkFirstWorker(_bark01.GetLocalizedString());
			}
		}

		protected override void StopObservingObjectives()
		{
			Worker.OnSelect -= Worker_OnSelect;
			WorkerChoreAssigner.OnAutonomyActive -= OnAutonomyActive;
			WorkerChoreAssigner.OnPriorityStatusChanged -= OnPriorityStatusChanged;
		}

		protected override void OnQuestSuccess()
		{
			base.OnQuestSuccess();
			base.QuestChain.PreviousInhabitant = _customerSpawn.Spawn();
			base.PreviousInhabitant.Tags.AddTag(EAgentTag.CannotLeave);
			base.PreviousInhabitant.ActionPlayer.ForceAction(new AgentActionEnterBar(), EActionPriority.Forced);
			base.PreviousInhabitant.ActionPlayer.AddAction(new AgentActionBark(_bark02.GetLocalizedString(), 5f));
			_priorityPanel.HighlightAutonomy(isActive: false);
			_priorityPanel.StopHighlightCategory(ChoreCategory.Cleaning);
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			base.QuestChain.ToggleWorkersGlobalAutonomy(value: true);
			base.QuestChain.FirstWorker.ChoreAssigner.SetActive(value: true);
			base.QuestChain.FirstWorker.ChoreAssigner.TogglePriority(ChoreCategory.Cleaning, value: true);
		}

		public override void SuccessConfirmation()
		{
			base.QuestChain.ToggleWorkersGlobalAutonomy(value: true);
		}
	}
}
