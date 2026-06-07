using System;
using SettingScripts;
using SettingsScripts;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts.SettingHandles
{
	public class SimConditionHandle : MonoBehaviour
	{
		public SimCondition simCondition;

		public SimulationMetricHandle metric1Handle;

		public SimulationMetricHandle metric2Handle;

		public ChoiceSettingDropdown<ChoiceSetting<Comparator>, Comparator> comparatorDropdown;

		public SettingDropdownReference comparatorDropdownRef;

		[NonSerialized]
		public UnityEvent<SimConditionHandle> simConditionRemoved = new UnityEvent<SimConditionHandle>();

		public Button removeButton;

		private bool isRemovable;

		public void Initialize(SimCondition condition, bool removable = false)
		{
			simCondition = condition;
			metric1Handle.Initialize(simCondition.leftValue);
			metric2Handle.Initialize(simCondition.rightValue);
			comparatorDropdown = new ChoiceSettingDropdown<ChoiceSetting<Comparator>, Comparator>(simCondition.comparator, comparatorDropdownRef);
			SetRemovable(removable);
		}

		public void SetRemovable(bool removable)
		{
			isRemovable = removable;
			removeButton.gameObject.SetActive(isRemovable);
		}

		public void Remove()
		{
			simConditionRemoved.Invoke(this);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
