using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings/Sound Settings", fileName = "SoundSettings")]
public class SoundSettings : ScriptableObject
{
	public SliderSettingItem masterVol;

	public SliderSettingItem musicVol;

	public SliderSettingItem sFXVol;

	public SliderSettingItem proxChatVol;

	public static event Action<SoundSettings> SettingsChanged;

	private void NotifyChanged()
	{
		SoundSettings.SettingsChanged?.Invoke(this);
	}

	public void TriggerSettingsChanged()
	{
		NotifyChanged();
	}
}
