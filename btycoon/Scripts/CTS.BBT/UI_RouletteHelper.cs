using CTS.ScriptableSettings;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_RouletteHelper : MonoBehaviour
{
	[Foldout("Dev")]
	[SerializeField]
	private TMP_Text _rouletteNameDisplay;

	[Foldout("Dev")]
	[SerializeField]
	private TMP_Text _currentPreset;

	[Foldout("Dev")]
	[SerializeField]
	private IntSetting _settingData;

	[Foldout("Dev")]
	[SerializeField]
	private Image _rightArrow;

	[Foldout("Dev")]
	[SerializeField]
	private Image _leftArrow;

	[BoxGroup("Right Arrow")]
	[SerializeField]
	private Color _rightArrowColor;

	[BoxGroup("Right Arrow")]
	[ShowAssetPreview(64, 64)]
	[SerializeField]
	private Sprite _rightArrowSprite;

	[BoxGroup("Left Arrow")]
	[SerializeField]
	private Color _leftArrowColor;

	[BoxGroup("Left Arrow")]
	[ShowAssetPreview(64, 64)]
	[SerializeField]
	private Sprite _leftArrowSprite;

	[BoxGroup("Roulette Values")]
	[SerializeField]
	private string _rouletteName;

	private int _currentPresetIndex;

	private void Start()
	{
		_settingData.ValueChanged += OnSettingChanged;
		OnSettingChanged(_settingData.GetValue());
	}

	private void OnSettingChanged(int obj)
	{
		_currentPreset.text = _settingData.GetCurrentValueName();
	}

	private void OnDestroy()
	{
		_settingData.ValueChanged -= OnSettingChanged;
	}

	public void IncrementIndex()
	{
		_currentPresetIndex++;
		_settingData.SetValue(_currentPresetIndex);
		_currentPresetIndex = _settingData.GetValue();
	}

	public void DecrementIndex()
	{
		_currentPresetIndex--;
		_settingData.SetValue(_currentPresetIndex);
		_currentPresetIndex = _settingData.GetValue();
	}
}
