using UnityEngine;

public class SettingsFullscreen : MonoBehaviour
{
	public Checkbox checkbox;

	public void OnApply()
	{
		SettingsManager.Instance.SetFullscreen(checkbox.state);
	}

	private void OnEnable()
	{
		if ((bool)SettingsManager.Instance)
		{
			checkbox.SetState(SettingsManager.Instance.Fullscreen);
		}
	}
}
