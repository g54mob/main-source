using System.Collections.Generic;
using FoxyVoxel.Logging;

namespace NSMedieval.StatsSystem
{
	public class ForceGoalEnableStateEffect : EffectorBase
	{
		private string goalId;

		private bool goalState;

		public ForceGoalEnableStateEffect(StatEffector parent)
			: base(EffectorType.ForceGoalEnableState, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			goalId = data["GoalName"];
			goalState = bool.Parse(data["GoalState"]);
			if (goalId == null)
			{
				Log.Error("ForceGoalEnableStateEffect invalid parameters!", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\ForceGoalEnableStateEffect.cs");
			}
		}

		public override void Start(StatsInstance instance)
		{
			instance.AddForceGoalEnableStateModifier(goalId, goalState);
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
		}

		public override void End(StatsInstance instance)
		{
			if (!instance.HasDisposed)
			{
				instance.ClearForceGoalEnableStateModifier(goalId);
			}
		}
	}
}
