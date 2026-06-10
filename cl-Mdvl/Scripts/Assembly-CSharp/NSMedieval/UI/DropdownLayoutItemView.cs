using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;

namespace NSMedieval.UI
{
	public class DropdownLayoutItemView : LayoutGroupItemView
	{
		private readonly int dropdownIndex;

		private readonly int labelIndex = 1;

		public TMP_Dropdown Dropdown => base.GroupItems[dropdownIndex].GetComponent<TMP_Dropdown>();

		public void SetData(string labelText, List<string> optionValues, Action<string> callback)
		{
			base.GroupItems[labelIndex].GetComponent<TMP_Text>().SetText(labelText);
			SetData(optionValues, callback);
		}

		public void SetData(IEnumerable<string> optionValues, Action<int> callback)
		{
			AddOptions(optionValues);
			Dropdown.onValueChanged.AddListener(callback.Invoke);
		}

		public void SetData(List<string> optionValues, Action<string> callback)
		{
			AddOptions(optionValues);
			Dropdown.onValueChanged.AddListener(delegate(int value)
			{
				callback(optionValues[value]);
			});
		}

		public void SetValue(int value)
		{
			if (value >= 0 && value < Dropdown.options.Count)
			{
				Dropdown.value = value;
			}
		}

		public void SetValueWithoutNotify(int value)
		{
			if (value >= 0 && value < Dropdown.options.Count)
			{
				Dropdown.SetValueWithoutNotify(value);
			}
		}

		private void AddOptions(IEnumerable<string> optionValues)
		{
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			list.AddRange(optionValues.Select((string option) => new TMP_Dropdown.OptionData(option)));
			Dropdown.options = list;
		}
	}
}
