using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_StyleInflenceValue : MonoBehaviour
	{
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private Image _fillImage;

		[SerializeField]
		private TMP_Text _valueText;

		public BarStyleParameters Theme { get; private set; }

		public void SetTheme(BarStyleParameters themeStruct)
		{
			_icon.sprite = themeStruct.Icon;
			Theme = themeStruct;
			_fillImage.color = themeStruct.StyleColor;
		}

		public void SetValue(float value)
		{
			_fillImage.fillAmount = value;
			_valueText.text = Mathf.RoundToInt(value * 100f) + "%";
		}
	}
}
