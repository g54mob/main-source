using UnityEngine;

public class SettingsAudioVolume : MonoBehaviour
{
	public TFUISlider target;

	public SettingsManager.MixerChannel channel;

	private void OnEnable()
	{
		if (SettingsManager.Instance != null)
		{
			target.SetValue(SettingsManager.Instance.GetAudioVolume(channel));
		}
	}

	private void Start()
	{
		target.onChange.AddListener(OnChange);
	}

	private void OnChange()
	{
		SettingsManager.Instance.SetAudioValue(target.value, channel);
	}
}
