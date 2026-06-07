using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class OptionToggleItem : OptionItemBase
	{
		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private TMP_Text itemName;

		private Color textColor;

		private int intValue => 0;

		private void Awake()
		{
		}

		public override int GetValue()
		{
			return 0;
		}

		public bool GetBoolValue()
		{
			return false;
		}

		public override void SetValue(int value)
		{
		}

		public void SetBoolValue(bool value)
		{
		}

		public void OnChangeValue(bool isOn)
		{
		}

		public override void DisableItem(bool disable)
		{
		}
	}
}
