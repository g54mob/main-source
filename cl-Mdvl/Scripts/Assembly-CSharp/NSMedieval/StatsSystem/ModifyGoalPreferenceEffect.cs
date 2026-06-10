using System.Collections.Generic;
using FoxyVoxel.Logging;

namespace NSMedieval.StatsSystem
{
	public class ModifyGoalPreferenceEffect : EffectorBase
	{
		private string goalPreferenceId;

		private int valueModifier;

		public ModifyGoalPreferenceEffect(StatEffector parent)
			: base(EffectorType.ModifyGoalPreference, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			goalPreferenceId = data["GoalPreferenceId"];
			if (string.IsNullOrEmpty(goalPreferenceId))
			{
				Log.Error("GoalPreferenceId is not string or not set. Check json", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\ModifyGoalPreferenceEffect.cs");
			}
			if (!int.TryParse(data["Priority"], out var result))
			{
				Log.Error("Priority was no parsed as int. Check json", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\ModifyGoalPreferenceEffect.cs");
			}
			valueModifier = result;
		}

		public override void Start(StatsInstance instance)
		{
			instance.ModifyGoalPreference(goalPreferenceId, valueModifier);
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
		}

		public override void End(StatsInstance instance)
		{
			if (!instance.HasDisposed)
			{
				instance.ModifyGoalPreference(goalPreferenceId, -valueModifier);
			}
		}
	}
}
