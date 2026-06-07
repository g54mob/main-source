using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GuiNew
{
	public class ButtonColorScript : MonoBehaviour
	{
		[SerializeField]
		[Header("Blinking Colors")]
		private ColorBlock _blinkingColors;

		[SerializeField]
		private float _blinkPeriod = 2f;

		private Button _button;

		[SerializeField]
		[Header("Default Colors")]
		private ColorBlock _defaultColors;

		private bool _isBlinking;

		private bool _isSelected;

		[SerializeField]
		[Header("Selected Colors")]
		private ColorBlock _selectedColors;

		public Color BlinkColor
		{
			get
			{
				return _blinkingColors.normalColor;
			}
			set
			{
				if (_blinkingColors.normalColor != value)
				{
					Color.RGBToHSV(value, out var H, out var S, out var V);
					_blinkingColors.normalColor = value;
					_blinkingColors.selectedColor = value;
					if (V >= 50f)
					{
						_blinkingColors.highlightedColor = Color.HSVToRGB(H, S, V - 20f);
						_blinkingColors.pressedColor = Color.HSVToRGB(H, S, V - 30f);
						_blinkingColors.disabledColor = Color.HSVToRGB(H, S, V - 40f);
					}
					else
					{
						_blinkingColors.highlightedColor = Color.HSVToRGB(H, S, V + 20f);
						_blinkingColors.pressedColor = Color.HSVToRGB(H, S, V + 30f);
						_blinkingColors.disabledColor = Color.HSVToRGB(H, S, V + 50f);
					}
					UpdateColors();
				}
			}
		}

		public ColorBlock BlinkColors
		{
			get
			{
				return _blinkingColors;
			}
			set
			{
				_blinkingColors = value;
				UpdateColors();
			}
		}

		public float BlinkPeriod
		{
			get
			{
				return _blinkPeriod;
			}
			set
			{
				_blinkPeriod = value;
			}
		}

		public ColorBlock DefaultColors
		{
			get
			{
				return _defaultColors;
			}
			set
			{
				_defaultColors = value;
				UpdateColors();
			}
		}

		public bool IsBlinking
		{
			get
			{
				return _isBlinking;
			}
			set
			{
				if (_isBlinking != value)
				{
					_isBlinking = value;
					UpdateColors();
				}
			}
		}

		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				if (_isSelected != value)
				{
					_isSelected = value;
					UpdateColors();
				}
			}
		}

		public ColorBlock SelectedColors
		{
			get
			{
				return _selectedColors;
			}
			set
			{
				_selectedColors = value;
				UpdateColors();
			}
		}

		protected virtual void Awake()
		{
			_button = GetComponent<Button>();
			if (_button == null)
			{
				Debug.LogError("Unable to find the button component for the button color script. GameObject: " + base.name, this);
				base.enabled = false;
			}
			else
			{
				UpdateColors();
			}
		}

		protected virtual void Update()
		{
			if (_isBlinking)
			{
				UpdateColors();
			}
		}

		private void UpdateBlinkColors(ColorBlock colors)
		{
			float num = _blinkPeriod * 0.5f;
			float num2 = Time.realtimeSinceStartup % _blinkPeriod / num;
			if (num2 > 1f)
			{
				num2 = 2f - num2;
			}
			num2 *= num2;
			colors.normalColor = Color.LerpUnclamped(colors.normalColor, _blinkingColors.normalColor, num2);
			colors.highlightedColor = Color.LerpUnclamped(colors.highlightedColor, _blinkingColors.highlightedColor, num2);
			colors.pressedColor = Color.LerpUnclamped(colors.pressedColor, _blinkingColors.pressedColor, num2);
			colors.selectedColor = Color.LerpUnclamped(colors.selectedColor, _blinkingColors.selectedColor, num2);
			colors.disabledColor = Color.LerpUnclamped(colors.disabledColor, _blinkingColors.disabledColor, num2);
			_button.colors = colors;
		}

		private void UpdateColors()
		{
			if (IsBlinking)
			{
				UpdateBlinkColors(_isSelected ? _selectedColors : _defaultColors);
			}
			else
			{
				_button.colors = (_isSelected ? _selectedColors : _defaultColors);
			}
		}
	}
}
