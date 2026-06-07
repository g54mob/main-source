using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using SimulationScripts;
using UnityEngine;
using UnityEngine.Events;

namespace SettingsScripts
{
	public class SimCondition : ISimCondition, ISaveable
	{
		public SimulationMetric leftValue = new SimulationMetric();

		public SimulationMetric rightValue = new SimulationMetric();

		public UnityEvent onEvaluate = new UnityEvent();

		public readonly ChoiceSetting<Comparator> comparator = new ChoiceSetting<Comparator>
		{
			Name = "Comparison Operator",
			HelperText = "The comparison type",
			DefaultValue = Comparator.GreaterThan,
			val = Comparator.GreaterThan,
			choices = comparatorChoices
		};

		public static SettingChoices<Comparator> comparatorChoices = new SettingChoices<Comparator>
		{
			choices = new List<SettingChoice<Comparator>>
			{
				new SettingChoice<Comparator>(Comparator.LessThan, "<", "Met when left value is smaller than right value"),
				new SettingChoice<Comparator>(Comparator.GreaterThan, ">", "Met when left value is bigger than right value"),
				new SettingChoice<Comparator>(Comparator.LessThanOrEqual, "≤", "Met when left value is smaller or equal than right value"),
				new SettingChoice<Comparator>(Comparator.GreaterThanOrEqual, "≥", "Met when left value is bigger or equal than right value")
			}
		};

		public bool lastIsMet => Compare(leftValue.lastVal, rightValue.lastVal);

		public bool CheckParadigm(SimMetric metric1, SimMetric metric2)
		{
			if (metric1 == leftValue.metric.val || metric1 == rightValue.metric.val)
			{
				if (metric2 != leftValue.metric.val)
				{
					return metric2 == rightValue.metric.val;
				}
				return true;
			}
			return false;
		}

		public bool EvaluateIsMet()
		{
			bool result = Compare(leftValue.Evaluate(), rightValue.Evaluate());
			onEvaluate.Invoke();
			return result;
		}

		private bool Compare(float left, float right)
		{
			return comparator.val switch
			{
				Comparator.LessThan => left < right, 
				Comparator.GreaterThan => left > right, 
				Comparator.Equal => Mathf.Approximately(left, right), 
				Comparator.NotEqual => !Mathf.Approximately(left, right), 
				Comparator.GreaterThanOrEqual => left >= right, 
				Comparator.LessThanOrEqual => left <= right, 
				_ => throw new ArgumentException("Invalid comparison operator"), 
			};
		}

		public SimCondition()
		{
			leftValue.metric.choices = SimulationMetric.metricChoicesWithoutConstant;
		}

		public SimCondition(SimMetric metric1, string arg1, Comparator comparator, SimMetric metric2, string arg2)
		{
			leftValue.metric.choices = SimulationMetric.metricChoicesWithoutConstant;
			leftValue.metric.SetValue(metric1);
			leftValue.argument.SetValue(arg1);
			this.comparator.SetValue(comparator);
			rightValue.metric.SetValue(metric2);
			rightValue.argument.SetValue(arg2);
		}

		public JObject SaveState()
		{
			return new JObject
			{
				["metric1"] = leftValue.metric.val.ToString(),
				["arg1"] = leftValue.argument.val,
				["comp"] = comparator.val.ToString(),
				["metric2"] = rightValue.metric.val.ToString(),
				["arg2"] = rightValue.argument.val
			};
		}

		public void LoadState(JObject state)
		{
			comparator.SetValue(state["comp"].ToObject<Comparator>());
			leftValue.metric.SetValue(state["metric1"].ToObject<SimMetric>());
			leftValue.argument.SetValue(state["arg1"].ToString());
			rightValue.metric.SetValue(state["metric2"].ToObject<SimMetric>());
			rightValue.argument.SetValue(state["arg2"].ToString());
		}
	}
}
