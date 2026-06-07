using UnityEngine;
using UnityEngine.Events;

namespace UIScripts
{
	public class RealDropdown : MyDropdown
	{
		private int selected;

		public UnityEvent<int> onValueChanged = new UnityEvent<int>();

		public int value
		{
			get
			{
				return selected;
			}
			set
			{
				OnChange(value);
			}
		}

		public override void OnChange(int index)
		{
			selected = Mathf.Clamp(index, 0, items.Count);
			for (int i = 0; i < items.Count; i++)
			{
				if (i != selected)
				{
					items[i].toggle.SetIsOnWithoutNotify(value: false);
				}
			}
			items[selected].toggle.SetIsOnWithoutNotify(value: true);
			label.text = items[selected].label.text;
			template.SetActive(value: false);
			onValueChanged.Invoke(selected);
		}
	}
}
