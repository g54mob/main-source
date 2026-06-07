using UnityEngine;

public class SettingsShadowResolution : MonoBehaviour
{
	public EnumSelector selector;

	private void Start()
	{
		selector.onChange.AddListener(OnChange);
	}

	private void OnEnable()
	{
		selector.options.Clear();
		selector.options.AddRange(new string[5] { "256", "512", "1024", "2048", "4096" });
		if ((bool)SettingsManager.Instance)
		{
			selector.SetIndex(SettingsManager.AALevelToInt(SettingsManager.Instance.AntiAliasing));
		}
	}

	private void OnChange()
	{
		SettingsManager.Instance.SetAntiAliasing(SettingsManager.IntToAALevel(selector.Index));
	}
}
