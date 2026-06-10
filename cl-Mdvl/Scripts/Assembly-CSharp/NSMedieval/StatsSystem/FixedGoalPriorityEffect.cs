using System.Collections.Generic;
using System.Globalization;
using FoxyVoxel.Logging;

namespace NSMedieval.StatsSystem
{
	public class FixedGoalPriorityEffect : EffectorBase
	{
		private string goalId;

		private float priority;

		public FixedGoalPriorityEffect(StatEffector parent)
			: base(EffectorType.FixedGoalPriority, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			goalId = data["GoalName"];
			priority = float.Parse(data["Priority"], CultureInfo.InvariantCulture);
			if (goalId == null)
			{
				Log.Error("FixedGoalPriorityEffect invalid goalId!", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\FixedGoalPriorityEffect.cs");
			}
		}

		public override void Start(StatsInstance instance)
		{
			instance.AddGoalFixedPriority(goalId, priority);
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
		}

		public override void End(StatsInstance instance)
		{
			if (!instance.HasDisposed)
			{
				instance.RemoveGoalFixedPriority(goalId);
			}
		}
	}
}
