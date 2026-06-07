using System;
using SettingScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts.SettingHandles.References
{
	public class SettingDropdownReference : MonoBehaviour
	{
		[SerializeField]
		public TextMeshProUGUI settingName;

		[SerializeField]
		public TextMeshProUGUI helperText;

		[SerializeField]
		public SettingHelper helperButton;

		public Button resetButton;

		[SerializeField]
		public TMP_Dropdown dropdown;

		[NonSerialized]
		public UnityAction<int, bool> onItemHovered;

		public void ItemHovered(int i, bool val)
		{
			onItemHovered?.Invoke(i - 1, val);
		}
	}
}
