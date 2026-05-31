using System;
using PixelCrushers.DialogueSystem;

namespace CTS
{
	public abstract class BBTBaseGoal
	{
		[QuestEntryPopup]
		public int Entry;

		protected Quest Quest;

		public void AddGoalToQuest(Quest quest)
		{
			if (!(quest == null) && !quest.Goals.Contains(this))
			{
				quest.Goals.Add(this);
			}
		}

		public void RemoveGoalFromQuest(Quest quest)
		{
			if (!(quest == null))
			{
				quest.Goals.Remove(this);
			}
		}

		public virtual void ResetVariable()
		{
		}

		public virtual void SetupTarget()
		{
		}

		public void SetupGoal(Quest quest)
		{
			Quest = quest;
			InstantiateGoal();
			AddGoalToQuest(quest);
			SetupTarget();
		}

		public void SetupGoal(Quest quest, params Action[] actionsAchieved)
		{
			SetupGoal(quest);
			AddActionToPlayOnAchievement(actionsAchieved);
		}

		protected abstract void InstantiateGoal();

		public abstract void StopObserving();

		public abstract void StartObserving(Quest quest, params Action[] actionsAchieved);

		public abstract void AddActionToPlayOnAchievement(params Action[] actionsAchieved);
	}
}
