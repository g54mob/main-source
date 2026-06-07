using System;
using System.Collections.Generic;
using Dissonance;
using TMPro;
using UnityEngine;

public class DissonanceInputModeDropdown : MonoBehaviour
{
	private enum UiMode
	{
		OpenMic = 0,
		VoiceActivation = 1,
		PushToTalkCustom = 2
	}

	[Header("References")]
	[SerializeField]
	private TMP_Dropdown dropdown;

	[SerializeField]
	private DissonanceComms comms;

	[SerializeField]
	private VoiceProximityBroadcastTrigger broadcast;

	[Header("Custom PTT (optional)")]
	[SerializeField]
	private bool enableCustomPttHold = true;

	[SerializeField]
	private KeyCode customPttKey = KeyCode.V;

	private const string PrefKey = "vc.inputmode";

	private UiMode _currentMode = UiMode.VoiceActivation;

	public MicAudioCanvas micScript;

	private void Awake()
	{
		if (!dropdown)
		{
			dropdown = GetComponent<TMP_Dropdown>();
		}
		if (!comms)
		{
			comms = UnityEngine.Object.FindObjectOfType<DissonanceComms>(includeInactive: true);
		}
		broadcast = comms.gameObject.GetComponent<VoiceProximityBroadcastTrigger>();
		if (!dropdown || !broadcast)
		{
			Debug.LogError("[DissonanceInputModeDropdown] Missing TMP_Dropdown or VoiceBroadcastTrigger.");
			base.enabled = false;
			return;
		}
		int value = PlayerPrefs.GetInt("vc.inputmode", 1);
		value = (int)(_currentMode = (UiMode)Mathf.Clamp(value, 0, 2));
		dropdown.SetValueWithoutNotify(value);
		dropdown.onValueChanged.AddListener(OnDropdownChanged);
		UpdateAllLanguageChanges();
	}

	public void UpdateAllLanguageChanges()
	{
		if ((bool)dropdown)
		{
			dropdown.ClearOptions();
			dropdown.AddOptions(new List<string>
			{
				JSONAccess.Instance.GetMiscText("UI Text 4", "Open Mic"),
				JSONAccess.Instance.GetMiscText("UI Text 4", "Automatic"),
				JSONAccess.Instance.GetMiscText("UI Text 4", "Push To Talk")
			});
			dropdown.RefreshShownValue();
		}
	}

	private void Start()
	{
		micScript = MicAudioCanvas.Instance;
		ApplyMode(_currentMode, save: false);
	}

	private void OnDestroy()
	{
		if (dropdown != null)
		{
			dropdown.onValueChanged.RemoveListener(OnDropdownChanged);
		}
	}

	private void OnDropdownChanged(int index)
	{
		_currentMode = (UiMode)Mathf.Clamp(index, 0, 2);
		ApplyMode(_currentMode, save: true);
	}

	private void ApplyMode(UiMode mode, bool save)
	{
		switch (mode)
		{
		case UiMode.OpenMic:
			micScript.activationMode = 0;
			broadcast.Mode = CommActivationMode.Open;
			broadcast.IsMuted = false;
			break;
		case UiMode.VoiceActivation:
			micScript.activationMode = 1;
			broadcast.Mode = CommActivationMode.VoiceActivation;
			broadcast.IsMuted = false;
			break;
		case UiMode.PushToTalkCustom:
			micScript.activationMode = 2;
			broadcast.Mode = CommActivationMode.Open;
			broadcast.IsMuted = true;
			break;
		}
		if (save)
		{
			PlayerPrefs.SetInt("vc.inputmode", (int)mode);
			PlayerPrefs.Save();
		}
		micScript.openMic.SetActive(value: false);
		micScript.activationMic.SetActive(value: false);
		micScript.pttMic.SetActive(value: false);
	}

	private void Update()
	{
		if (_currentMode == UiMode.PushToTalkCustom && enableCustomPttHold)
		{
			if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind11"))))
			{
				micScript.pttMic.SetActive(value: true);
				broadcast.IsMuted = false;
			}
			else
			{
				micScript.pttMic.SetActive(value: false);
				broadcast.IsMuted = true;
			}
		}
	}

	public KeyCode ConvertStringToKeyCode(string keyName)
	{
		return keyName.ToLower() switch
		{
			"left ctrl" => KeyCode.LeftControl, 
			"LeftControl" => KeyCode.LeftControl, 
			"right ctrl" => KeyCode.RightControl, 
			"left shift" => KeyCode.LeftShift, 
			"LeftShift" => KeyCode.LeftShift, 
			"right shift" => KeyCode.RightShift, 
			"shift" => KeyCode.LeftShift, 
			"ctrl" => KeyCode.LeftControl, 
			_ => (KeyCode)Enum.Parse(typeof(KeyCode), keyName, ignoreCase: true), 
		};
	}
}
