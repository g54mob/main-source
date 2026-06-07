using System;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingsScripts;

namespace SettingScripts
{
	public class ChallengeParameters : ISaveable
	{
		public BibiteSettings championSettings = new BibiteSettings();

		public ConditionGroup exitCondition = new ConditionGroup(SimMetric.Time, "", Comparator.GreaterThanOrEqual, SimMetric.Constant, "3600");

		public SimulationMetric scoringMetric = new SimulationMetric(SimMetric.TagCount, "Champion");

		public BoolSetting highScoreIsBetter = new BoolSetting
		{
			Name = "High is better",
			HelperText = "If enabled, means that a higher value of the scoring metric is a better Score",
			DefaultValue = true,
			val = true
		};

		public ConditionGroup oneStarCondition = new ConditionGroup(SimMetric.TagCount, "Champion", Comparator.GreaterThanOrEqual, SimMetric.Constant, "50");

		public ConditionGroup twoStarCondition = new ConditionGroup(SimMetric.TagCount, "Champion", Comparator.GreaterThanOrEqual, SimMetric.Constant, "100");

		public ConditionGroup threeStarCondition = new ConditionGroup(SimMetric.TagCount, "Champion", Comparator.GreaterThanOrEqual, SimMetric.Constant, "200");

		[NonSerialized]
		public string star1Desc;

		[NonSerialized]
		public string star2Desc;

		[NonSerialized]
		public string star3Desc;

		[NonSerialized]
		public string challengeName;

		[NonSerialized]
		public string challengeDesc;

		public JObject SaveState()
		{
			JObject jObject = new JObject();
			jObject["exit"] = exitCondition.SaveState();
			jObject["scoringMetric"] = scoringMetric.metric.val.ToString();
			if (scoringMetric.metric.val.MetricHasArgument())
			{
				jObject["scoringArg"] = scoringMetric.argument.val;
			}
			jObject["scoringHigh"] = highScoreIsBetter.val;
			jObject["star1"] = oneStarCondition.SaveState();
			jObject["star2"] = twoStarCondition.SaveState();
			jObject["star3"] = threeStarCondition.SaveState();
			jObject["champion"] = championSettings.SaveForChampion();
			return jObject;
		}

		public void LoadState(JObject state)
		{
			exitCondition = new ConditionGroup();
			oneStarCondition = new ConditionGroup();
			twoStarCondition = new ConditionGroup();
			threeStarCondition = new ConditionGroup();
			exitCondition.LoadState((JObject)state["exit"]);
			oneStarCondition.LoadState((JObject)state["star1"]);
			twoStarCondition.LoadState((JObject)state["star2"]);
			threeStarCondition.LoadState((JObject)state["star3"]);
			if (state["scoringMetric"] != null)
			{
				scoringMetric.metric.SetValue(state["scoringMetric"].ToObject<SimMetric>());
			}
			if (state["scoringArg"] != null)
			{
				scoringMetric.argument.SetValue(state["scoringArg"].ToString());
			}
			if (state["scoringHigh"] != null)
			{
				highScoreIsBetter.SetValue(state["scoringHigh"].ToObject<bool>());
			}
			if (state["champion"] != null)
			{
				championSettings.LoadForChampion((JObject)state["champion"]);
			}
		}
	}
}
