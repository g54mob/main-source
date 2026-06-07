using UnityEngine;

public class SettingsVsync : MonoBehaviour
{
	public Checkbox checkbox;

	public void OnApply()
	{
		SettingsManager.Instance.SetVSync(checkbox.state);
	}

	private void OnEnable()
	{
		if ((bool)SettingsManager.Instance)
		{
			checkbox.SetState(SettingsManager.Instance.VSync);
		}
	}
}
