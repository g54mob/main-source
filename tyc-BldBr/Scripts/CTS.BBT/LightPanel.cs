using System.Linq;
using TMPro;
using UnityEngine;

public class LightPanel : MonoBehaviour
{
	[SerializeField]
	private TMP_Dropdown _intensityDropdown;

	[SerializeField]
	private LightDataSO _lightData;

	[SerializeField]
	private Transform _colorButtonContainer;

	[SerializeField]
	private LightColorButton _lightColorButtonPrefab;

	[SerializeField]
	private Light _currentLightSelected;

	private void Start()
	{
		for (int i = 0; i < _lightData.Colors.Length; i++)
		{
			LightColorButton lightColorButton = Object.Instantiate(_lightColorButtonPrefab, _colorButtonContainer);
			lightColorButton.SetColor(_lightData.Colors[i]);
			lightColorButton.OnColorSelected += OnColorSelected;
		}
		_intensityDropdown.ClearOptions();
		_intensityDropdown.AddOptions(_lightData.RangeIntensityCouples.Select((RangeIntensityCouple x) => x.Name).ToList());
		_intensityDropdown.onValueChanged.AddListener(OnIntensitySelected);
		OnColorSelected(Color.white);
		OnIntensitySelected(0);
	}

	private void OnDestroy()
	{
		_intensityDropdown.onValueChanged.RemoveListener(OnIntensitySelected);
	}

	private void OnColorSelected(Color color)
	{
		if (!(_currentLightSelected == null))
		{
			_currentLightSelected.color = color;
		}
	}

	private void OnIntensitySelected(int index)
	{
		if (!(_currentLightSelected == null))
		{
			_currentLightSelected.intensity = _lightData.RangeIntensityCouples[index].Intensity;
			_currentLightSelected.range = _lightData.RangeIntensityCouples[index].Range;
		}
	}

	private void Update()
	{
	}
}
