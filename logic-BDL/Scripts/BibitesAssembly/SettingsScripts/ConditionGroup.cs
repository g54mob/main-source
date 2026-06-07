using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using SimulationScripts;

namespace SettingsScripts
{
	public class ConditionGroup : ISimCondition, ISaveable
	{
		public bool isRoot = true;

		public List<ISimCondition> subConditions = new List<ISimCondition>();

		public readonly ChoiceSetting<ConditionGroupLogic> logic = new ChoiceSetting<ConditionGroupLogic>
		{
			Name = "Logic",
			HelperText = "How the sub-conditions are stacked.",
			DefaultValue = ConditionGroupLogic.And,
			val = ConditionGroupLogic.And,
			choices = logicChoices
		};

		public static SettingChoices<ConditionGroupLogic> logicChoices = new SettingChoices<ConditionGroupLogic>
		{
			choices = new List<SettingChoice<ConditionGroupLogic>>
			{
				new SettingChoice<ConditionGroupLogic>(ConditionGroupLogic.And, "AND", "Applies AND logic to the group"),
				new SettingChoice<ConditionGroupLogic>(ConditionGroupLogic.Or, "OR", "Applies OR logic to the group")
			}
		};

		public SimCondition first => GetAllSimConditions().First();

		public int GetConditionCounts()
		{
			int n = 0;
			subConditions.ForEach(delegate(ISimCondition condition)
			{
				int num = n;
				int num2;
				if (!(condition is ConditionGroup conditionGroup))
				{
					if (!(condition is SimCondition))
					{
						throw new ArgumentOutOfRangeException("condition", condition, null);
					}
					num2 = 1;
				}
				else
				{
					num2 = conditionGroup.GetConditionCounts();
				}
				n = num + num2;
			});
			return n;
		}

		public bool EvaluateIsMet()
		{
			bool flag = false;
			bool flag2 = false;
			foreach (ISimCondition subCondition in subConditions)
			{
				if (!flag2)
				{
					flag = subCondition.EvaluateIsMet();
					flag2 = true;
				}
				else
				{
					flag = logic.val switch
					{
						ConditionGroupLogic.And => flag && subCondition.EvaluateIsMet(), 
						ConditionGroupLogic.Or => flag || subCondition.EvaluateIsMet(), 
						_ => subCondition.EvaluateIsMet(), 
					};
				}
			}
			return flag;
		}

		public ConditionGroup()
		{
		}

		public static ConditionGroup NewSubGroup()
		{
			return new ConditionGroup
			{
				isRoot = false
			};
		}

		public static ConditionGroup NewSubGroup(SimMetric metric1, string arg1, Comparator comparator, SimMetric metric2, string arg2)
		{
			return new ConditionGroup(metric1, arg1, comparator, metric2, arg2)
			{
				isRoot = false
			};
		}

		public ConditionGroup(SimMetric metric1, string arg1, Comparator comparator, SimMetric metric2, string arg2)
		{
			subConditions.Add(new SimCondition(metric1, arg1, comparator, metric2, arg2));
		}

		public List<SimCondition> GetAllSimConditions()
		{
			List<SimCondition> list = new List<SimCondition>();
			foreach (ISimCondition subCondition in subConditions)
			{
				if (subCondition is SimCondition item)
				{
					list.Add(item);
				}
				else if (subCondition is ConditionGroup conditionGroup)
				{
					list.AddRange(conditionGroup.GetAllSimConditions());
				}
			}
			return list;
		}

		public void SimplifyGroup()
		{
			List<ConditionGroup> list = new List<ConditionGroup>();
			foreach (ISimCondition item in subConditions.ToList())
			{
				if (!(item is ConditionGroup conditionGroup))
				{
					continue;
				}
				conditionGroup.SimplifyGroup();
				if (conditionGroup.subConditions.Count > 1 && conditionGroup.logic.val != logic.val)
				{
					continue;
				}
				foreach (ISimCondition subCondition in conditionGroup.subConditions)
				{
					subConditions.Add(subCondition);
				}
				list.Add(conditionGroup);
			}
			list.ForEach(delegate(ConditionGroup g)
			{
				subConditions.Remove(g);
			});
		}

		public JObject SaveState()
		{
			if (isRoot)
			{
				SimplifyGroup();
			}
			JObject jObject = new JObject { ["logic"] = logic.val.ToString() };
			JArray jArray = new JArray();
			foreach (ISimCondition subCondition in subConditions)
			{
				jArray.Add(subCondition.SaveState());
			}
			jObject["subs"] = jArray;
			return jObject;
		}

		public void LoadState(JObject state)
		{
			logic.SetValue(state["logic"].ToObject<ConditionGroupLogic>());
			foreach (JToken item in (JArray)state["subs"])
			{
				if (item["logic"] != null)
				{
					ConditionGroup conditionGroup = NewSubGroup();
					conditionGroup.LoadState((JObject)item);
					subConditions.Add(conditionGroup);
				}
				else
				{
					SimCondition simCondition = new SimCondition();
					simCondition.LoadState((JObject)item);
					subConditions.Add(simCondition);
				}
			}
			if (isRoot)
			{
				SimplifyGroup();
			}
		}
	}
}
