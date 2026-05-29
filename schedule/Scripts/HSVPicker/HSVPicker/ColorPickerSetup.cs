using System;
using TMPro;
using UnityEngine;

namespace HSVPicker
{
	[Serializable]
	public class ColorPickerSetup
	{
		public enum ColorHeaderShowing
		{
			Hide = 0,
			ShowColor = 1,
			ShowColorCode = 2,
			ShowAll = 3
		}

		[Serializable]
		public class UiElements
		{
			public RectTransform[] Elements;

			public void Toggle(bool active)
			{
			}
		}

		public bool ShowRgb;

		public bool ShowHsv;

		public bool ShowAlpha;

		public bool ShowColorBox;

		public bool ShowColorSliderToggle;

		[Tooltip("Re-initialise the colour picker settings every time the picker is made active.")]
		public bool RegenerateOnOpen;

		[Tooltip("Enable the user to add presets, up to the maximum preset limit.")]
		public bool UserCanAddPresets;

		public ColorHeaderShowing ShowHeader;

		public UiElements RgbSliders;

		public UiElements HsvSliders;

		public UiElements ColorToggleElement;

		public UiElements AlphaSlidiers;

		public UiElements ColorHeader;

		public UiElements ColorCode;

		public UiElements ColorPreview;

		public UiElements ColorBox;

		public TMP_Text SliderToggleButtonText;

		public string PresetColorsId;

		public Color[] DefaultPresetColors;
	}
}
