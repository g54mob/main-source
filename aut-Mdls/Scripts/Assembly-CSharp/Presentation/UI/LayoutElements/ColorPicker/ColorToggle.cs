using System;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.LayoutElements.ColorPicker
{
	public class ColorToggle : MonoBehaviour
	{
		[SerializeField]
		private GameObject _activeContent;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private Image _colorBg;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		private Color _color;

		private bool _isSelected;

		public Action<ColorToggle, Color> OnColorChanged = delegate
		{
		};

		private bool _isDisabled;

		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				_isSelected = value;
				if (_activeContent != null)
				{
					_activeContent.SetActive(_isSelected);
				}
			}
		}

		private void Awake()
		{
			IsSelected = true;
			_button.onClick.AddListener(HandleButtonPressed);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(HandleButtonPressed);
		}

		private void HandleButtonPressed()
		{
			ButtonPressed();
		}

		public void ButtonPressed()
		{
			IsSelected = !IsSelected;
			OnColorChanged(this, _color);
		}

		public void SetColor(Color color)
		{
			_color = color;
			_colorBg.color = _color;
		}

		public void SetDisabled(bool value)
		{
			_isDisabled = value;
			_button.interactable = !value;
			if (_canvasGroup != null)
			{
				_canvasGroup.alpha = (value ? 0.3f : 0.8f);
			}
		}
	}
}
