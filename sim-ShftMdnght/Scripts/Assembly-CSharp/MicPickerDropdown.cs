using System.Collections.Generic;
using Dissonance;
using TMPro;
using UnityEngine;

public class MicPickerDropdown : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private TMP_Dropdown dropdown;

	[SerializeField]
	private DissonanceComms comms;

	[Header("Options")]
	[Tooltip("Show a 'System Default' option which lets Unity pick the OS default device.")]
	[SerializeField]
	private bool includeSystemDefault = true;

	private readonly List<string> _devices = new List<string>();

	private const string PrefKey = "voice.input.device";

	private void Awake()
	{
		if (dropdown == null)
		{
			dropdown = GetComponent<TMP_Dropdown>();
		}
		if (comms == null)
		{
			comms = Object.FindObjectOfType<DissonanceComms>(includeInactive: true);
		}
		if (dropdown == null || comms == null)
		{
			Debug.LogError("[MicPickerDropdown] Missing Dropdown or DissonanceComms reference.");
			base.enabled = false;
			return;
		}
		AudioSettings.OnAudioConfigurationChanged += OnAudioConfigChanged;
		BuildList();
		dropdown.onValueChanged.AddListener(OnDropdownChanged);
		UpdateAllLanguageChanges();
	}

	public void UpdateAllLanguageChanges()
	{
		if (dropdown.options.Count > 0)
		{
			dropdown.options[0].text = JSONAccess.Instance.GetMiscText("UI Text 4", "System Default");
			dropdown.RefreshShownValue();
		}
	}

	private void Start()
	{
		ApplySavedSelectionIfAny();
		UpdateAllLanguageChanges();
	}

	private void OnDestroy()
	{
		dropdown.onValueChanged.RemoveListener(OnDropdownChanged);
		AudioSettings.OnAudioConfigurationChanged -= OnAudioConfigChanged;
	}

	private void OnAudioConfigChanged(bool deviceWasChanged)
	{
		BuildList();
	}

	private void BuildList()
	{
		dropdown.ClearOptions();
		_devices.Clear();
		if (includeSystemDefault)
		{
			_devices.Add(string.Empty);
		}
		string[] devices = Microphone.devices;
		if (devices != null && devices.Length != 0)
		{
			_devices.AddRange(devices);
		}
		List<string> list = new List<string>();
		foreach (string device in _devices)
		{
			list.Add(string.IsNullOrEmpty(device) ? "System Default" : device);
		}
		if (list.Count == 0)
		{
			list.Add("No microphones found");
			dropdown.AddOptions(list);
			dropdown.interactable = false;
			return;
		}
		dropdown.interactable = true;
		dropdown.AddOptions(list);
		string text = PlayerPrefs.GetString("voice.input.device", string.Empty);
		string item = ((!string.IsNullOrEmpty(text)) ? text : (comms.MicrophoneName ?? string.Empty));
		int num = _devices.IndexOf(item);
		if (num < 0)
		{
			num = 0;
		}
		dropdown.SetValueWithoutNotify(num);
		ApplySelection(num, save: false);
	}

	private void OnDropdownChanged(int index)
	{
		ApplySelection(index, save: true);
	}

	private void ApplySelection(int index, bool save)
	{
		if (index >= 0 && index < _devices.Count)
		{
			string text = _devices[index];
			comms.MicrophoneName = text;
			if (save)
			{
				PlayerPrefs.SetString("voice.input.device", text ?? string.Empty);
				PlayerPrefs.Save();
			}
			Debug.Log("[MicPickerDropdown] Selected mic: " + (string.IsNullOrEmpty(text) ? "System Default" : text));
		}
	}

	private void ApplySavedSelectionIfAny()
	{
		if (_devices.Count != 0)
		{
			string item = PlayerPrefs.GetString("voice.input.device", string.Empty);
			int num = _devices.IndexOf(item);
			if (num < 0)
			{
				num = 0;
			}
			if (dropdown.value != num)
			{
				dropdown.SetValueWithoutNotify(num);
			}
			ApplySelection(num, save: false);
		}
	}
}
