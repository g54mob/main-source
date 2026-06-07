using System;
using Gh.Tk.UI;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class BrightnessSlider3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		private TextMeshProI18n _title;

		private string _rawTitleText;

		private AmplifyColorBase _amplifyColor;

		[SerializeField]
		private Slider3DUIView _slider;

		[SerializeField]
		private Texture2D _darkTexture;

		[SerializeField]
		private Texture2D _lightTexture;

		[SerializeField]
		private Button3DUIView _resetButton;

		public static float BrightnessAdjustment
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private new void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void InvalidateBrightnessSetting()
		{
		}

		protected void OnValueChanged(object sender, EventArgs e)
		{
		}

		private void ApplyValue()
		{
		}

		private void SetBrightnessToPostProcessingEffect(float value)
		{
		}
	}
}
