using System;
using System.Xml.Linq;
using Jundroo.Juicy.Widgets.Extra;
using Jundroo.Juicy.Widgets.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets
{
	public class SliderWidget : Widget, ISelectableWidget, IScrollHandler, IEventSystemHandler
	{
		[SerializeField]
		private Image _backgroundImage;

		private RectTransform _handleRect;

		private bool _ignoreSliderValueChangedEvent;

		private float _lastSoundValue = -1f;

		private float _maxValue = 1f;

		private float _minValue;

		private int _numberOfSteps;

		[SerializeField]
		private Slider _slider;

		public ColorProperty BackgroundColor { get; private set; }

		public Image BackgroundImage => _backgroundImage;

		public ColorProperty FillColor { get; private set; }

		public Image FillImage { get; private set; }

		public ColorProperty HandleColor { get; private set; }

		public Image HandleImage { get; private set; }

		public Vector2 HandleScale
		{
			get
			{
				return _handleRect.localScale;
			}
			set
			{
				_handleRect.localScale = new Vector3(value.x, value.y, 1f);
			}
		}

		public override bool Interactable
		{
			get
			{
				return base.Interactable;
			}
			set
			{
				base.Interactable = value;
				Selectable.interactable = value;
			}
		}

		public float MaxValue
		{
			get
			{
				return _maxValue;
			}
			set
			{
				_maxValue = value;
				ConfigureRange();
			}
		}

		public float MinValue
		{
			get
			{
				return _minValue;
			}
			set
			{
				_minValue = value;
				ConfigureRange();
			}
		}

		public int NumberOfSteps
		{
			get
			{
				return _numberOfSteps;
			}
			set
			{
				try
				{
					_ignoreSliderValueChangedEvent = true;
					float value2 = Value;
					_numberOfSteps = value;
					ConfigureRange();
					Value = value2;
				}
				finally
				{
					_ignoreSliderValueChangedEvent = false;
				}
			}
		}

		public Selectable Selectable => Slider;

		public Slider Slider => _slider;

		public SoundData SoundValueChanged { get; set; }

		public float Value
		{
			get
			{
				if (Slider.wholeNumbers)
				{
					return Mathf.Lerp(MinValue, MaxValue, _slider.normalizedValue);
				}
				return _slider.value;
			}
			set
			{
				try
				{
					_ignoreSliderValueChangedEvent = true;
					if (Slider.wholeNumbers)
					{
						_slider.normalizedValue = Mathf.InverseLerp(MinValue, MaxValue, value);
					}
					else
					{
						_slider.value = value;
					}
				}
				finally
				{
					_ignoreSliderValueChangedEvent = false;
				}
				this.ValueSet?.Invoke(value);
			}
		}

		protected override AttributeSet AttributeSet => SliderAttributes.Set;

		public event Action<float> ValueChanged;

		public event Action<float> ValueSet;

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
			FillImage = _slider.fillRect.GetComponent<Image>();
			HandleImage = _slider.handleRect.GetComponent<Image>();
			_handleRect = HandleImage.rectTransform;
			BackgroundColor = new ColorProperty(BackgroundImage.color, delegate(Color x)
			{
				BackgroundImage.color = x;
			});
			FillColor = new ColorProperty(FillImage.color, delegate(Color x)
			{
				FillImage.color = x;
			});
			HandleColor = new ColorProperty(HandleImage.color, delegate(Color x)
			{
				HandleImage.color = x;
			});
			ConfigureRange();
			_slider.onValueChanged.AddListener(delegate(float x)
			{
				OnSliderValueChanged(x);
			});
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			_lastSoundValue = Value;
		}

		public void OnScroll(PointerEventData eventData)
		{
			ScrollRect componentInParent = GetComponentInParent<ScrollRect>();
			if (componentInParent != null)
			{
				componentInParent.OnScroll(eventData);
			}
		}

		private void ConfigureRange()
		{
			if (NumberOfSteps > 0)
			{
				Slider.wholeNumbers = true;
				SetRange(0f, NumberOfSteps - 1);
			}
			else
			{
				Slider.wholeNumbers = false;
				SetRange(_minValue, _maxValue);
			}
		}

		private void OnSliderValueChanged(float x)
		{
			if (!_ignoreSliderValueChangedEvent)
			{
				this.ValueChanged?.Invoke(Value);
				if (SoundValueChanged != null && _lastSoundValue != Value)
				{
					_lastSoundValue = Value;
					base.Context.PlaySound(SoundValueChanged);
				}
			}
		}

		private void SetRange(float min, float max)
		{
			try
			{
				_ignoreSliderValueChangedEvent = true;
				Slider.minValue = min;
				Slider.maxValue = max;
			}
			finally
			{
				_ignoreSliderValueChangedEvent = false;
			}
		}
	}
}
