using Motorways.UI;
using TMPro;
using UnityEngine;

public class DebugToggleButton : MonoBehaviour
{
	public TextMeshProUGUI text;

	public TouchToggle touchToggle;

	public GameObject toggleFill;

	public GameObject indicator;

	public string debugOptionName;

	public Feature featureToToggle;

	public DebugOptionsPage debugOptionsPage;

	private static readonly int FeatureToggleStateCount = typeof(FeatureToggleState).GetEnumNames().Length;

	private FeatureToggleState _currentState;

	public void Initialize(string newDebugOptionName, Feature newFeature, DebugOptionsPage newDebugOptionsPage, ToggleButtonGroup group)
	{
		debugOptionName = newDebugOptionName;
		text.text = debugOptionName;
		featureToToggle = newFeature;
		debugOptionsPage = newDebugOptionsPage;
		group?.RegisterToggle(touchToggle);
		_currentState = OptionsMenuSettingSource.GetOptionsMenuFeatureState(featureToToggle);
		UpdateButtonState();
	}

	public void UpdateButtonState()
	{
		bool value = FeatureToggle.IsDynamicFeatureEnabled(featureToToggle);
		touchToggle.Set(value, sendCallback: false);
		toggleFill.SetActive(touchToggle.IsOn);
		indicator.SetActive(_currentState != FeatureToggleState.NoOverride);
	}

	public void OnClick()
	{
		_currentState = (FeatureToggleState)((int)(_currentState + 1) % FeatureToggleStateCount);
		debugOptionsPage.SetDebugOptionEnabled(debugOptionName.Replace(" ", ""), _currentState);
		UpdateButtonState();
	}
}
