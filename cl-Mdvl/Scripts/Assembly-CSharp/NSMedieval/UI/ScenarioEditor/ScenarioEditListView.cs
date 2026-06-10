using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NSMedieval.UI.ScenarioEditor
{
	public class ScenarioEditListView : ScenarioEditEntryView
	{
		[SerializeField]
		private DropdownLayoutItemView listDropdown;

		[SerializeField]
		private DropdownLayoutItemView options1Dropdown;

		[SerializeField]
		private DropdownLayoutItemView options2Dropdown;

		private string listValue = string.Empty;

		private string options1Value = string.Empty;

		private string options2Value = string.Empty;

		public event Action<string, ScenarioEditEntryView> ValueChanged;

		public void SetDefaults(string label, List<string> listValues)
		{
			SetDefaults(label);
			listDropdown.SetData(listValues, delegate(string s)
			{
				listValue = s;
				OnDropdownValueChange();
			});
			listValue = listValues.FirstOrDefault();
			options1Dropdown.gameObject.SetActive(options1Value.Equals(string.Empty));
			options2Dropdown.gameObject.SetActive(options2Value.Equals(string.Empty));
		}

		public void SetDefaults(string label, List<string> listValues, string options1Label, List<string> options1Values)
		{
			SetDefaults(label, listValues);
			options1Dropdown.SetData(options1Label, options1Values, delegate(string s)
			{
				options1Value = s;
				OnDropdownValueChange();
			});
			options1Value = options1Values.FirstOrDefault();
		}

		public void SetDefaults(string label, List<string> listValues, string options1Label, List<string> options1Values, string options2Label, List<string> options2Values)
		{
			SetDefaults(label, listValues, options1Label, options1Values);
			options2Dropdown.SetData(options2Label, options2Values, delegate(string s)
			{
				options2Value = s;
				OnDropdownValueChange();
			});
			options2Value = options2Values.FirstOrDefault();
		}

		public void SetValue(int listValue, int options1Value = -1, int options2Value = -1)
		{
			listDropdown.SetValue(listValue);
			options1Dropdown.SetValue(options1Value);
			options2Dropdown.SetValue(options2Value);
		}

		private void OnDropdownValueChange()
		{
			string value = listValue;
			if (!options1Value.Equals(string.Empty))
			{
				value = options1Value + "_" + listValue;
			}
			if (!options2Value.Equals(string.Empty))
			{
				value = options1Value + "_" + options2Value + "_" + listValue;
			}
			Notify(value);
		}

		private void Notify(string value)
		{
			this.ValueChanged?.Invoke(value, this);
		}
	}
}
