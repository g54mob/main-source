using UnityEngine;

public class SettingsAntiAliasing : MonoBehaviour
{
	public EnumSelector selector;

	private void Start()
	{
		selector.onChange.AddListener(OnChange);
	}

	private void OnEnable()
	{
		selector.options.Clear();
		selector.options.AddRange(new string[4] { "Disabled", "2x", "4x", "8x" });
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
