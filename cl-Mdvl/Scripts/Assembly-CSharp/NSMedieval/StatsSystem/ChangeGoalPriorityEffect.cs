using System.Collections.Generic;
using System.Globalization;
using FoxyVoxel.Logging;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	public class ChangeGoalPriorityEffect : EffectorBase
	{
		private string goalId;

		private float priority;

		public ChangeGoalPriorityEffect(StatEffector parent)
			: base(EffectorType.ChangeGoalPriority, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			goalId = data["GoalName"];
			priority = float.Parse(data["Priority"], CultureInfo.InvariantCulture);
			if (goalId == null || Mathf.Approximately(priority, 0f))
			{
				Log.Error("ChangeGoalPriorityEffect invalid parameters!", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\ChangeGoalPriorityEffect.cs");
			}
		}

		public override void Start(StatsInstance instance)
		{
			instance.AddGoalPriorityModifier(goalId, priority);
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
		}

		public override void End(StatsInstance instance)
		{
			if (!instance.HasDisposed)
			{
				instance.AddGoalPriorityModifier(goalId, 0f - priority);
			}
		}
	}
}
