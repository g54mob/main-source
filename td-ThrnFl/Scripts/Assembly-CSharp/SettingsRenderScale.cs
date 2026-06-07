using UnityEngine;

public class SettingsRenderScale : MonoBehaviour
{
	public TFUISlider target;

	private void OnEnable()
	{
		if (SettingsManager.Instance != null)
		{
			target.SetValue(SettingsManager.Instance.Renderscale);
		}
	}

	private void Start()
	{
		target.onChange.AddListener(OnChange);
	}

	private void OnChange()
	{
		SettingsManager.Instance.SetRenderscale(target.value);
	}
}
