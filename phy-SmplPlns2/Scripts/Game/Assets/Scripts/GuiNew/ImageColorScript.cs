using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GuiNew
{
	public class ImageColorScript : MonoBehaviour
	{
		[SerializeField]
		private Color _blinkingColor;

		[SerializeField]
		private float _blinkPeriod = 2f;

		[SerializeField]
		private Color _defaultColor;

		[SerializeField]
		private Image _image;

		private bool _isBlinking;

		private bool _isSelected;

		[SerializeField]
		private Color _selectedColor;

		public Color BlinkColor
		{
			get
			{
				return _blinkingColor;
			}
			set
			{
				if (_blinkingColor != value)
				{
					_blinkingColor = value;
					UpdateColor();
				}
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

		public Color DefaultColor
		{
			get
			{
				return _defaultColor;
			}
			set
			{
				if (_defaultColor != value)
				{
					_defaultColor = value;
					UpdateColor();
				}
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
					UpdateColor();
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
					UpdateColor();
				}
			}
		}

		public Color SelectedColor
		{
			get
			{
				return _selectedColor;
			}
			set
			{
				if (_selectedColor != value)
				{
					_selectedColor = value;
					UpdateColor();
				}
			}
		}

		protected virtual void Awake()
		{
			if (_image == null)
			{
				_image = GetComponent<Image>();
				if (_image == null)
				{
					Debug.LogError("Unable to find the image component for the image color script. GameObject: " + base.name, this);
					base.enabled = false;
					return;
				}
			}
			UpdateColor();
		}

		protected virtual void Update()
		{
			if (_isBlinking)
			{
				UpdateColor();
			}
		}

		private void UpdateBlinkColor(Color color)
		{
			float num = _blinkPeriod * 0.5f;
			float num2 = Time.realtimeSinceStartup % _blinkPeriod / num;
			if (num2 > 1f)
			{
				num2 = 2f - num2;
			}
			num2 *= num2;
			color = Color.Lerp(color, _blinkingColor, num2);
			_image.color = color;
		}

		private void UpdateColor()
		{
			if (IsBlinking)
			{
				UpdateBlinkColor(_isSelected ? _selectedColor : _defaultColor);
			}
			else
			{
				_image.color = (_isSelected ? _selectedColor : _defaultColor);
			}
		}
	}
}
