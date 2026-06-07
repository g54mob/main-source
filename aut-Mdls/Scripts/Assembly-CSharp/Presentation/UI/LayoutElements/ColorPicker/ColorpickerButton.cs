using System;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.LayoutElements.ColorPicker
{
	public class ColorpickerButton : MonoBehaviour
	{
		[SerializeField]
		private GameObject _activeContent;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private Image _colorBg;

		private Color _color;

		private bool _isSelected;

		public Action<ColorpickerButton, Color> OnColorChanged = delegate
		{
		};

		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				_isSelected = value;
				_activeContent.SetActive(_isSelected);
			}
		}

		private void Awake()
		{
			_button.onClick.AddListener(ButtonPressed);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(ButtonPressed);
		}

		private void ButtonPressed()
		{
			if (!_isSelected)
			{
				OnColorChanged(this, _color);
				IsSelected = true;
			}
		}

		public void SetColor(Color color)
		{
			_color = color;
			_colorBg.color = _color;
		}
	}
}
