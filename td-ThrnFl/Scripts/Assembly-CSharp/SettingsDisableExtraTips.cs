using UnityEngine;

public class SettingsDisableExtraTips : MonoBehaviour
{
	public Checkbox checkbox;

	public void OnApply()
	{
		SettingsManager.Instance.SetDisableExtraTips(checkbox.state);
	}

	private void OnEnable()
	{
		if ((bool)SettingsManager.Instance)
		{
			checkbox.SetState(SettingsManager.Instance.DisableExtraTips);
		}
	}
}
