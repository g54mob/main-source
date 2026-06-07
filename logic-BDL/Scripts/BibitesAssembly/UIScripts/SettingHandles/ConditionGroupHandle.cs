using System;
using System.Collections.Generic;
using System.Linq;
using SettingsScripts;
using SimulationScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts.SettingHandles
{
	public class ConditionGroupHandle : MonoBehaviour
	{
		public ConditionGroup conditionGroup;

		public Button toggleLogicButton;

		public TextMeshProUGUI logicText;

		public Transform conditionHolder;

		public GameObject simConditionPrefab;

		public GameObject addGroupSection;

		private readonly List<SimConditionHandle> subConditions = new List<SimConditionHandle>();

		private readonly List<ConditionGroupHandle> subGroups = new List<ConditionGroupHandle>();

		[NonSerialized]
		public UnityEvent<ConditionGroupHandle> onConditionGroupRemoved = new UnityEvent<ConditionGroupHandle>();

		[NonSerialized]
		public UnityEvent onAnySubConditionsChanged = new UnityEvent();

		[NonSerialized]
		public int depth;

		private bool hasInit;

		public List<SimConditionHandle> allSubConditions => subConditions.Union(subGroups.SelectMany((ConditionGroupHandle g) => g.allSubConditions)).ToList();

		public void Initialize(ConditionGroup settings, int newDepth = 0)
		{
			conditionGroup = settings;
			depth = newDepth;
			foreach (ISimCondition subCondition in conditionGroup.subConditions)
			{
				if (subCondition is ConditionGroup toAdd)
				{
					AddConditionGroup(toAdd);
				}
				else if (subCondition is SimCondition toAdd2)
				{
					AddSimCondition(toAdd2);
				}
			}
			toggleLogicButton.onClick.AddListener(ToggleLogic);
			conditionGroup.logic.Subscribe(UpdateLogicText);
			UpdateLogicText(conditionGroup.logic.val);
			hasInit = true;
			if (depth == 0)
			{
				CheckSubConditionsRemovability();
			}
			addGroupSection.SetActive(depth < 2);
		}

		private void SubSimConditionRemoved(SimConditionHandle removed)
		{
			conditionGroup.subConditions.Remove(removed.simCondition);
			subConditions.Remove(removed);
			OnAnySubConditionsChanged();
			CheckToRemove();
		}

		private void SubConditionGroupRemoved(ConditionGroupHandle removed)
		{
			conditionGroup.subConditions.Remove(removed.conditionGroup);
			subGroups.Remove(removed);
			OnAnySubConditionsChanged();
			CheckToRemove();
		}

		private void CheckToRemove()
		{
			if (conditionGroup.subConditions.Count <= 0)
			{
				onConditionGroupRemoved.Invoke(this);
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		private void CheckSubConditionsRemovability()
		{
			List<SimConditionHandle> list = allSubConditions;
			bool removable = list.Count > 1;
			list.ForEach(delegate(SimConditionHandle s)
			{
				s.SetRemovable(removable);
			});
		}

		public void AddCondition(bool addSimCondition)
		{
			if (addSimCondition)
			{
				SimCondition simCondition = new SimCondition(SimMetric.Time, "", Comparator.GreaterThanOrEqual, SimMetric.Constant, "3600");
				this.conditionGroup.subConditions.Add(simCondition);
				AddSimCondition(simCondition);
			}
			else if (depth <= 1)
			{
				ConditionGroup conditionGroup = ConditionGroup.NewSubGroup(SimMetric.Time, "", Comparator.GreaterThanOrEqual, SimMetric.Constant, "3600");
				this.conditionGroup.subConditions.Add(conditionGroup);
				AddConditionGroup(conditionGroup);
			}
		}

		public void AddSimCondition(SimCondition toAdd)
		{
			SimConditionHandle component = UnityEngine.Object.Instantiate(simConditionPrefab, conditionHolder).GetComponent<SimConditionHandle>();
			component.Initialize(toAdd);
			subConditions.Add(component);
			component.simConditionRemoved.AddListener(SubSimConditionRemoved);
			OnAnySubConditionsChanged();
		}

		public void AddConditionGroup(ConditionGroup toAdd)
		{
			ConditionGroupHandle component = UnityEngine.Object.Instantiate(UIPrefabsHolder.Instance.ConditionGroupPrefab, conditionHolder).GetComponent<ConditionGroupHandle>();
			subGroups.Add(component);
			component.Initialize(toAdd, depth + 1);
			component.onConditionGroupRemoved.AddListener(SubConditionGroupRemoved);
			component.onAnySubConditionsChanged.AddListener(OnAnySubConditionsChanged);
			OnAnySubConditionsChanged();
		}

		public void OnAnySubConditionsChanged()
		{
			if (depth != 0)
			{
				onAnySubConditionsChanged.Invoke();
			}
			else
			{
				CheckSubConditionsRemovability();
			}
		}

		public void ToggleLogic()
		{
			conditionGroup.logic.SetValue((conditionGroup.logic.val == ConditionGroupLogic.And) ? ConditionGroupLogic.Or : ConditionGroupLogic.And);
		}

		public void UpdateLogicText(ConditionGroupLogic logic)
		{
			logicText.text = logic.ToString().ToUpper();
		}

		private void OnDestroy()
		{
			if (hasInit)
			{
				conditionGroup.logic.UnSubscribe(UpdateLogicText);
			}
		}
	}
}
