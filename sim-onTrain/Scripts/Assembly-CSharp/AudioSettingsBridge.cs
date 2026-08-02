using Michsky.UI.Heat;
using UnityEngine;

public class AudioSettingsBridge : MonoBehaviour
{
	[Header("Refs")]
	[SerializeField]
	private SettingsData settings;

	[SerializeField]
	private UIManagerAudio uiAudio;

	[Header("Sliders (Heat)")]
	[SerializeField]
	private SliderManager masterSlider;

	[SerializeField]
	private SliderManager musicSlider;

	[SerializeField]
	private SliderManager sfxSlider;

	[SerializeField]
	private SliderManager uiSlider;

	[SerializeField]
	private SliderManager ambienceSlider;

	[Header("Voice Chat Sliders (Heat)")]
	[SerializeField]
	private SliderManager voiceInputSlider;

	[SerializeField]
	private SliderManager voiceOutputSlider;

	[Header("Voice Chat Switches (Heat)")]
	[SerializeField]
	private SwitchManager voiceChatEnabledSwitch;

	[SerializeField]
	private SwitchManager pushToTalkSwitch;

	private bool synced;

	private void Start()
	{
		if ((bool)masterSlider)
		{
			masterSlider.mainSlider.onValueChanged.AddListener(OnMasterChanged);
		}
		if ((bool)musicSlider)
		{
			musicSlider.mainSlider.onValueChanged.AddListener(OnMusicChanged);
		}
		if ((bool)sfxSlider)
		{
			sfxSlider.mainSlider.onValueChanged.AddListener(OnSFXChanged);
		}
		if ((bool)uiSlider)
		{
			uiSlider.mainSlider.onValueChanged.AddListener(OnUIChanged);
		}
		if ((bool)ambienceSlider)
		{
			ambienceSlider.mainSlider.onValueChanged.AddListener(OnAmbienceChanged);
		}
		if ((bool)voiceInputSlider)
		{
			voiceInputSlider.mainSlider.onValueChanged.AddListener(OnVoiceInputChanged);
		}
		if ((bool)voiceOutputSlider)
		{
			voiceOutputSlider.mainSlider.onValueChanged.AddListener(OnVoiceOutputChanged);
		}
		if ((bool)voiceChatEnabledSwitch)
		{
			voiceChatEnabledSwitch.onValueChanged.AddListener(OnVoiceChatEnabledChanged);
		}
		if ((bool)pushToTalkSwitch)
		{
			pushToTalkSwitch.onValueChanged.AddListener(OnPushToTalkChanged);
		}
	}

	public void SyncSliders()
	{
		SyncSlider(masterSlider, settings.masterVolume);
		SyncSlider(musicSlider, settings.musicVolume);
		SyncSlider(sfxSlider, settings.sfxVolume);
		SyncSlider(uiSlider, settings.uiVolume);
		SyncSlider(ambienceSlider, settings.ambienceVolume);
		SyncSlider(voiceInputSlider, settings.voiceInputVolume);
		SyncSlider(voiceOutputSlider, settings.voiceOutputVolume);
		SyncSwitch(voiceChatEnabledSwitch, settings.voiceChatEnabled);
		SyncSwitch(pushToTalkSwitch, settings.voicePushToTalk);
		synced = true;
	}

	private static void SyncSwitch(SwitchManager sw, bool isOn)
	{
		if (!(sw == null))
		{
			sw.isOn = isOn;
			sw.UpdateUI();
		}
	}

	private static void SyncSlider(SliderManager sm, float value)
	{
		if (!(sm == null) && !(sm.mainSlider == null))
		{
			sm.mainSlider.value = value;
			sm.UpdateUI();
		}
	}

	private void OnDestroy()
	{
		if ((bool)masterSlider)
		{
			masterSlider.mainSlider.onValueChanged.RemoveListener(OnMasterChanged);
		}
		if ((bool)musicSlider)
		{
			musicSlider.mainSlider.onValueChanged.RemoveListener(OnMusicChanged);
		}
		if ((bool)sfxSlider)
		{
			sfxSlider.mainSlider.onValueChanged.RemoveListener(OnSFXChanged);
		}
		if ((bool)uiSlider)
		{
			uiSlider.mainSlider.onValueChanged.RemoveListener(OnUIChanged);
		}
		if ((bool)ambienceSlider)
		{
			ambienceSlider.mainSlider.onValueChanged.RemoveListener(OnAmbienceChanged);
		}
		if ((bool)voiceInputSlider)
		{
			voiceInputSlider.mainSlider.onValueChanged.RemoveListener(OnVoiceInputChanged);
		}
		if ((bool)voiceOutputSlider)
		{
			voiceOutputSlider.mainSlider.onValueChanged.RemoveListener(OnVoiceOutputChanged);
		}
		if ((bool)voiceChatEnabledSwitch)
		{
			voiceChatEnabledSwitch.onValueChanged.RemoveListener(OnVoiceChatEnabledChanged);
		}
		if ((bool)pushToTalkSwitch)
		{
			pushToTalkSwitch.onValueChanged.RemoveListener(OnPushToTalkChanged);
		}
	}

	private void OnMasterChanged(float v)
	{
		if (synced)
		{
			v = SafeLinear(v);
			if (SettingsManager.Instance != null)
			{
				SettingsManager.Instance.SetMasterVolume(v);
			}
		}
	}

	private void OnMusicChanged(float v)
	{
		if (synced)
		{
			v = SafeLinear(v);
			if (SettingsManager.Instance != null)
			{
				SettingsManager.Instance.SetMusicVolume(v);
			}
		}
	}

	private void OnSFXChanged(float v)
	{
		if (synced)
		{
			v = SafeLinear(v);
			if (SettingsManager.Instance != null)
			{
				SettingsManager.Instance.SetSFXVolume(v);
			}
		}
	}

	private void OnUIChanged(float v)
	{
		if (synced)
		{
			v = SafeLinear(v);
			if (SettingsManager.Instance != null)
			{
				SettingsManager.Instance.SetUIVolume(v);
			}
		}
	}

	private void OnAmbienceChanged(float v)
	{
		if (synced)
		{
			v = SafeLinear(v);
			if (SettingsManager.Instance != null)
			{
				SettingsManager.Instance.SetAmbienceVolume(v);
			}
		}
	}

	private void OnVoiceInputChanged(float v)
	{
		if (synced && SettingsManager.Instance != null)
		{
			SettingsManager.Instance.SetVoiceInputVolume(Mathf.Clamp01(v));
		}
	}

	private void OnVoiceOutputChanged(float v)
	{
		if (synced && SettingsManager.Instance != null)
		{
			SettingsManager.Instance.SetVoiceOutputVolume(Mathf.Clamp01(v));
		}
	}

	private void OnVoiceChatEnabledChanged(bool on)
	{
		if (synced && SettingsManager.Instance != null)
		{
			SettingsManager.Instance.SetVoiceChatEnabled(on);
		}
	}

	private void OnPushToTalkChanged(bool on)
	{
		if (synced && SettingsManager.Instance != null)
		{
			SettingsManager.Instance.SetVoicePushToTalk(on);
		}
	}

	private static float SafeLinear(float v)
	{
		return Mathf.Clamp(v, 0.0001f, 1f);
	}
}
