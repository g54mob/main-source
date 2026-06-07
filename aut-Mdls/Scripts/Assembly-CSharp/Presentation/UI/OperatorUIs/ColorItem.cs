using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs
{
	public class ColorItem : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private TextMeshProUGUI _textMeshProUGUI;

		[SerializeField]
		private Image _colorImage;

		private Color _color;

		public Action<Color> ColorPicked;

		private void Start()
		{
			_button.onClick.AddListener(ButtonPressed);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(ButtonPressed);
		}

		private void ButtonPressed()
		{
			ColorPicked(_color);
		}

		public void SetColor(Color color, string colorName)
		{
			_color = color;
			_colorImage.color = color;
			_textMeshProUGUI.SetText(colorName);
		}
	}
}
