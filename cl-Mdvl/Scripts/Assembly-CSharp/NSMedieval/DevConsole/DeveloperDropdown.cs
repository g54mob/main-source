using System;
using System.Linq;
using NSMedieval.UI;
using TMPro;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class DeveloperDropdown : MonoBehaviour
	{
		private TooltipViewNew tooltip;

		private string[] options;

		private Action onChangedCallback;

		public void SetupChoices(string[] options, Action onChangedCallback)
		{
			this.options = options;
			this.onChangedCallback = onChangedCallback;
			TMP_Dropdown componentInChildren = GetComponentInChildren<TMP_Dropdown>();
			componentInChildren.ClearOptions();
			componentInChildren.AddOptions(this.options.ToList());
		}

		public string GetSelectedOption()
		{
			TMP_Dropdown componentInChildren = GetComponentInChildren<TMP_Dropdown>();
			return options[componentInChildren.value];
		}

		public int GetSelectedOptionValue()
		{
			return GetComponentInChildren<TMP_Dropdown>().value;
		}

		public void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
		}
	}
}
