using System;
using System.Collections.Generic;
using Assets.HSVPicker;
using UnityEngine;
using UnityEngine.UI;

public class ColorPresets : MonoBehaviour
{
	public ColorPicker picker;

	public GameObject[] presets;

	public Image createPresetImage;

	private ColorPresetList _colors;

	public event Action OnColorPresetChanged;

	private void Awake()
	{
		picker.onValueChanged.AddListener(ColorChanged);
		for (int i = 0; i < presets.Length; i++)
		{
			Image presetImage = presets[i].GetComponent<Image>();
			presets[i].GetComponent<Toggle>().onValueChanged.AddListener(delegate(bool isOn)
			{
				if (isOn)
				{
					PresetSelect(presetImage);
				}
			});
		}
	}

	private void Start()
	{
		_colors = ColorPresetManager.Get(picker.Setup.PresetColorsId);
		if (_colors.Colors.Count < picker.Setup.DefaultPresetColors.Length)
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
		createPresetImage.gameObject.SetActive(colors.Count < presets.Length);
	}

	public void CreatePresetButton()
	{
		_colors.AddColor(picker.CurrentColor);
	}

	public void PresetSelect(Image sender)
	{
		picker?.OnValueDiscretChanged(picker.CurrentColor, sender.color);
		picker.CurrentColor = sender.color;
	}

	public void PresetColorChanged()
	{
		for (int i = 0; i < presets.Length; i++)
		{
			if (presets[i].GetComponent<Toggle>().isOn)
			{
				presets[i].GetComponent<Image>().color = picker.CurrentColor;
				break;
			}
		}
		this.OnColorPresetChanged?.Invoke();
	}

	public void SetColorPresets(Color[] colors)
	{
		int num = ((presets.Length > colors.Length) ? colors.Length : presets.Length);
		for (int i = 0; i < num; i++)
		{
			presets[i].GetComponent<Image>().color = colors[i];
		}
		picker.Setup.DefaultPresetColors = colors;
	}

	public Color[] GetColorPresets()
	{
		Color[] array = new Color[presets.Length];
		for (int i = 0; i < presets.Length; i++)
		{
			array[i] = presets[i].GetComponent<Image>().color;
		}
		return array;
	}

	private void ColorChanged(Color color)
	{
		createPresetImage.color = color;
	}
}
