using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HSVPicker
{
	public class ColorPresets : MonoBehaviour
	{
		public ColorPicker picker;

		public GameObject[] presets;

		public Image createPresetImage;

		private ColorPresetList _colors;

		private void Awake()
		{
			picker.onValueChanged.AddListener(ColorChanged);
		}

		private void Start()
		{
			GenerateDefaultPresetColours();
		}

		private void OnEnable()
		{
			if (picker.Setup.RegenerateOnOpen)
			{
				GenerateDefaultPresetColours();
			}
		}

		public void SetColorPresets(List<Color> colors)
		{
			_colors?.UpdateList(colors);
		}

		private void GenerateDefaultPresetColours()
		{
			_colors = (string.IsNullOrEmpty(picker.Setup.PresetColorsId) ? new ColorPresetList() : ColorPresetManager.Get(picker.Setup.PresetColorsId));
			if (_colors.Colors.Count < picker.Setup.DefaultPresetColors.Count)
			{
				_colors.UpdateList(picker.Setup.DefaultPresetColors);
			}
			_colors.OnColorsUpdated += OnColorsUpdate;
			OnColorsUpdate(_colors.Colors);
		}

		private void OnColorsUpdate(List<Color> colors)
		{
			for (int i = 0; i < presets.Length; i++)
			{
				if (colors.Count <= i)
				{
					presets[i].SetActive(value: false);
					continue;
				}
				presets[i].SetActive(value: true);
				presets[i].GetComponent<Image>().color = colors[i];
			}
			createPresetImage.gameObject.SetActive(colors.Count < presets.Length && picker.Setup.UserCanAddPresets);
		}

		public void CreatePresetButton()
		{
			_colors.AddColor(picker.CurrentColor);
		}

		public void PresetSelect(Image sender)
		{
			picker.AssignColor(sender.color);
		}

		private void ColorChanged(Color color)
		{
			createPresetImage.color = color;
		}

		private void OnDestroy()
		{
			picker.onValueChanged.RemoveListener(ColorChanged);
			_colors.OnColorsUpdated -= OnColorsUpdate;
		}
	}
}
