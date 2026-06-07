using UnityEngine;

public class SettingsUIScale : MonoBehaviour
{
	public TFUISlider target;

	private void OnEnable()
	{
		if (SettingsManager.Instance != null)
		{
			target.SetValue(1f - SettingsManager.Instance.UiReferenceResolutionFactor);
		}
	}

	private void Start()
	{
		target.onChange.AddListener(OnChange);
	}

	private void OnChange()
	{
		SettingsManager.Instance.SetUIReferenceResolutionScaleFactor(1f - target.value);
	}
}
