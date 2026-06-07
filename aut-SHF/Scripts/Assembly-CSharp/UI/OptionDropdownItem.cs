using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
	public class OptionDropdownItem : OptionItemBase
	{
		[SerializeField]
		private TMP_Dropdown dropdown;

		[SerializeField]
		private TMP_Text itemName;

		private Color textColor;

		private void Awake()
		{
		}

		public override int GetValue()
		{
			return 0;
		}

		public override void SetValue(int value)
		{
		}

		public void OnChangeValue(int value)
		{
		}

		public void ClearOptions()
		{
		}

		public void AddOptions(List<string> options)
		{
		}

		public void RefreshShownValue()
		{
		}

		public override void DisableItem(bool disable)
		{
		}
	}
}
