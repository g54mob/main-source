using System;

namespace CTS
{
	[Serializable]
	public abstract class BBTSimpleGoal<GoalType> : BBTBaseGoal where GoalType : QuestGoal
	{
		public GoalType Goal;

		public override void StopObserving()
		{
			Goal?.CleanStopObserving();
		}

		public override void StartObserving(Quest quest, params Action[] actionsAchieved)
		{
			if (Goal == null)
			{
				SetupGoal(quest);
			}
			Goal?.StartObserving(actionsAchieved);
		}

		protected override void InstantiateGoal()
		{
			Goal = (GoalType)Activator.CreateInstance(typeof(GoalType), Quest, Entry);
		}

		public override void AddActionToPlayOnAchievement(params Action[] actionsAchieved)
		{
			Goal.AddActionToPlayOnAchievement(actionsAchieved);
		}
	}
}
