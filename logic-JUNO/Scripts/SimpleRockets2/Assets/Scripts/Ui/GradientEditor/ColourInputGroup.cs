using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.GradientEditor
{
	public class ColourInputGroup : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		private Color _colour;

		private Image _image;

		private bool _allowHDR;

		[SerializeField]
		private TMP_InputField _inputField;

		[SerializeField]
		private TMP_InputField _intensityField;

		public bool AllowHDR
		{
			get
			{
				return _allowHDR;
			}
			set
			{
				_allowHDR = value;
				_intensityField.gameObject.SetActive(value);
			}
		}

		public Color Colour
		{
			get
			{
				return _colour;
			}
			set
			{
				value.a = 1f;
				_colour = value;
				_image.color = value;
				if (AllowHDR)
				{
					var (color, num) = HDRToColorPair(value);
					_inputField.SetTextWithoutNotify(ColorUtility.ToHtmlStringRGB(color));
					_intensityField.SetTextWithoutNotify(num.ToString("0.##"));
				}
				else
				{
					_inputField.SetTextWithoutNotify(ColorUtility.ToHtmlStringRGB(value));
				}
			}
		}

		public event Action<Color> OnValueChanged;

		public void OnPointerClick(PointerEventData eventData)
		{
			Game.Instance.UserInterface.CreateColorPicker(allowTransparency: false, Colour, Callback, Callback, AllowHDR);
			void Callback(Color c)
			{
				Colour = c;
				this.OnValueChanged?.Invoke(Colour);
			}
		}

		private static Color ColorPairToHDR(Color color, float intensity)
		{
			float num = Mathf.Pow(2f, intensity);
			color.r *= num;
			color.g *= num;
			color.b *= num;
			return color;
		}

		private static (Color color, float intensity) HDRToColorPair(Color color)
		{
			float maxColorComponent = color.maxColorComponent;
			(Color, float) result = default((Color, float));
			if (maxColorComponent > 1f)
			{
				result.Item2 = Mathf.Log(maxColorComponent, 2f);
				color.r /= maxColorComponent;
				color.g /= maxColorComponent;
				color.b /= maxColorComponent;
			}
			result.Item1 = color;
			return result;
		}

		private void UpdateColor(string s)
		{
			string text = _inputField.text;
			if (!text.StartsWith("#"))
			{
				text = "#" + text;
			}
			Color color2;
			if (AllowHDR)
			{
				if (float.TryParse(_intensityField.text, out var result) && ColorUtility.TryParseHtmlString(text, out var color))
				{
					color = ColorPairToHDR(color, result);
					color.a = 1f;
					_colour = color;
					_image.color = color;
					this.OnValueChanged?.Invoke(color);
				}
			}
			else if (ColorUtility.TryParseHtmlString(text, out color2))
			{
				color2.a = 1f;
				_colour = color2;
				_image.color = color2;
				this.OnValueChanged?.Invoke(color2);
			}
		}

		private void Awake()
		{
			_image = GetComponent<Image>();
			_inputField.onValueChanged.AddListener(UpdateColor);
			_intensityField.onValueChanged.AddListener(UpdateColor);
		}
	}
}
