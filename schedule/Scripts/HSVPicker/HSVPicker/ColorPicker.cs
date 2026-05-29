using UnityEngine;

namespace HSVPicker
{
	[DefaultExecutionOrder(0)]
	public class ColorPicker : MonoBehaviour
	{
		private float _hue;

		private float _saturation;

		private float _brightness;

		[SerializeField]
		private Color _color;

		[Header("Setup")]
		public ColorPickerSetup Setup;

		[Header("Event")]
		public ColorChangedEvent onValueChanged;

		public HSVChangedEvent onHSVChanged;

		public Color CurrentColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float H
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float S
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float V
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float R
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float G
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float B
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private float A
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void Regenerate()
		{
		}

		private void RGBChanged()
		{
		}

		private void HSVChanged()
		{
		}

		private void SendChangedEvent()
		{
		}

		public void AssignColor(ColorValues type, float value)
		{
		}

		public void AssignColor(Color color)
		{
		}

		public float GetValue(ColorValues type)
		{
			return 0f;
		}

		public void ToggleColorSliders()
		{
		}

		private void UpdateColorToggleText()
		{
		}

		private void HandleHeaderSetting(ColorPickerSetup.ColorHeaderShowing setupShowHeader)
		{
		}
	}
}
