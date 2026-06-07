using UnityEngine;

public class SettingsDisableTooltips : MonoBehaviour
{
	public Checkbox checkbox;

	public void OnApply()
	{
		SettingsManager.Instance.SetDisableTooltips(checkbox.state);
	}

	private void OnEnable()
	{
		if ((bool)SettingsManager.Instance)
		{
			checkbox.SetState(SettingsManager.Instance.DisableTooltips);
		}
	}
}
