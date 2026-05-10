using System;
using PixelCrushers.DialogueSystem;

namespace CTS
{
	public abstract class QuestGoal
	{
		private Quest _quest;

		public int EntryID { get; private set; }

		protected string QuestName => _quest.QuestName;

		public virtual bool IsGoalSucceedeed => QuestLog.GetQuestEntryState(QuestName, EntryID) == QuestState.Success;

		public event Action Updated;

		public static event Action<Quest, int> QuestGoalUpdated;

		public event Action Achieved;

		public static event Action<Quest, int> QuestGoalAchieved;

		public event Action AchievementCanceled;

		public static event Action<Quest, int> QuestGoalAchievementCanceled;

		public event Action Failed;

		public static event Action<Quest, int> QuestGoalFailed;

		public QuestGoal(Quest quest, int entryID)
		{
			_quest = quest;
			EntryID = entryID;
		}

		~QuestGoal()
		{
			CleanStopObserving();
		}

		public abstract void StopObserving();

		public abstract void StartObserving();

		public void CleanStopObserving()
		{
			this.Achieved = null;
			StopObserving();
		}

		public void AddActionToPlayOnAchievement(Action actionAchieved)
		{
			if (actionAchieved != null)
			{
				Achieved += actionAchieved;
			}
		}

		public void AddActionToPlayOnAchievement(params Action[] actionsAchieved)
		{
			foreach (Action actionAchieved in actionsAchieved)
			{
				AddActionToPlayOnAchievement(actionAchieved);
			}
		}

		public void StartObserving(Action actionAchieved)
		{
			AddActionToPlayOnAchievement(actionAchieved);
			StartObserving();
		}

		public void StartObserving(params Action[] actionsAchieved)
		{
			foreach (Action actionAchieved in actionsAchieved)
			{
				AddActionToPlayOnAchievement(actionAchieved);
			}
			StartObserving();
		}

		protected void WarnGoalUpdate()
		{
			this.Updated?.Invoke();
			QuestGoal.QuestGoalUpdated?.Invoke(_quest, EntryID);
			_quest.WarnEntryUpdate(EntryID);
		}

		protected void SetGoalState(bool success)
		{
			if (success)
			{
				AchieveGoal();
			}
			else
			{
				CancelGoalAchievment();
			}
		}

		protected void AchieveGoal()
		{
			if (QuestLog.GetQuestEntryState(QuestName, EntryID) != QuestState.Success)
			{
				QuestLog.SetQuestEntryState(QuestName, EntryID, QuestState.Success);
				WarnGoalUpdate();
				this.Achieved?.Invoke();
				QuestGoal.QuestGoalAchieved?.Invoke(_quest, EntryID);
				_quest.SuccessCheck();
			}
		}

		protected void CancelGoalAchievment()
		{
			if (QuestLog.GetQuestEntryState(QuestName, EntryID) != QuestState.Active)
			{
				QuestLog.SetQuestEntryState(QuestName, EntryID, QuestState.Active);
				WarnGoalUpdate();
				this.AchievementCanceled?.Invoke();
				QuestGoal.QuestGoalAchievementCanceled?.Invoke(_quest, EntryID);
			}
		}

		protected void GoalFailure()
		{
			if (QuestLog.GetQuestEntryState(QuestName, EntryID) != QuestState.Failure)
			{
				QuestLog.SetQuestEntryState(QuestName, EntryID, QuestState.Failure);
				WarnGoalUpdate();
				this.Failed?.Invoke();
				QuestGoal.QuestGoalFailed?.Invoke(_quest, EntryID);
			}
		}
	}
}
