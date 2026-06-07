using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.InfoHandles
{
	public class WedgeInfoHandle : MonoBehaviour
	{
		[SerializeField]
		private Image colorIndicator;

		[SerializeField]
		private TextMeshProUGUI label;

		[SerializeField]
		private FloatValueTextHandle value;

		public void InitWedgeInfo(WedgeInfo info, string suffix, int precision)
		{
			if (info.color == Color.clear)
			{
				colorIndicator.gameObject.SetActive(value: false);
			}
			else
			{
				colorIndicator.color = info.color;
			}
			label.text = info.label;
			value.suffix = suffix;
			value.precision = precision;
		}

		public void UpdateValue(float val)
		{
			value.UpdateValue(val);
		}
	}
}
