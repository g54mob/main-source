using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts
{
	public class DropdownItem : MonoBehaviour
	{
		public Toggle toggle;

		public TextMeshProUGUI label;

		public TooltipTrigger tooltip;

		public bool isOn
		{
			get
			{
				return toggle.isOn;
			}
			set
			{
				toggle.isOn = value;
			}
		}

		public void InitItem(DropdownItemData info, UnityAction<int> onChange = null)
		{
			base.gameObject.SetActive(value: true);
			label.text = info.title;
			tooltip.UpdateText(info.title, info.tooltip);
			isOn = info.defaultState;
			if (onChange != null)
			{
				toggle.onValueChanged.AddListener(delegate
				{
					onChange(base.transform.GetSiblingIndex() - 1);
				});
			}
		}
	}
}
