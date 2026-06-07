using System;
using TMPro;
using UnityEngine;

namespace PajamaLlama.UI.Formatting
{
	[Serializable]
	public struct IntFormatter
	{
		[SerializeField]
		private SignStyle _signStyle;

		[SerializeField]
		private ColorRange[] _colorRanges;

		public void Format(TextMeshProUGUI tmpText, int value, bool setActive = true)
		{
			switch (_signStyle)
			{
			case SignStyle.NegativeOnly:
				tmpText.text = value.ToString();
				break;
			case SignStyle.NegativeAndPositive:
				tmpText.text = ((value < 0) ? value.ToString() : $"+{value}");
				break;
			case SignStyle.NegativeAndPositiveZeroExcluded:
				tmpText.text = ((value <= 0) ? value.ToString() : $"+{value}");
				break;
			case SignStyle.None:
				tmpText.text = Mathf.Abs(value).ToString();
				break;
			}
			if (setActive)
			{
				tmpText.gameObject.SetActive(value: true);
			}
			if (_colorRanges.IsNullOrEmpty())
			{
				return;
			}
			ColorRange[] colorRanges = _colorRanges;
			for (int i = 0; i < colorRanges.Length; i++)
			{
				ColorRange colorRange = colorRanges[i];
				if (colorRange.IsInRange(value))
				{
					tmpText.color = colorRange.Color;
				}
			}
		}

		public void Format(TextMeshProUGUI tmpText, float value, bool setActive = true)
		{
			Format(tmpText, Mathf.RoundToInt(value), setActive);
		}
	}
}
