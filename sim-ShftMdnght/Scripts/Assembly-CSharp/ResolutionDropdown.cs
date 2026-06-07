using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResolutionDropdown : MonoBehaviour
{
	[Header("UI")]
	[SerializeField]
	private TMP_Dropdown dropdown;

	[Header("Behaviour")]
	[SerializeField]
	private bool preferLastSavedOverCurrent = true;

	private const string PrefKey = "video_resolution_index";

	private readonly List<Resolution> _uniqueResolutions = new List<Resolution>();

	private readonly List<string> _options = new List<string>();

	private void Awake()
	{
		if (!dropdown)
		{
			dropdown = GetComponent<TMP_Dropdown>();
		}
	}

	private void Start()
	{
		BuildUniqueResolutionList();
		int startupIndex = GetStartupIndex();
		SetDropdownWithoutNotify(startupIndex);
		if (preferLastSavedOverCurrent && PlayerPrefs.HasKey("video_resolution_index"))
		{
			ApplyResolution(startupIndex);
		}
		dropdown.onValueChanged.AddListener(OnChanged);
	}

	private void OnDestroy()
	{
		dropdown.onValueChanged.RemoveListener(OnChanged);
	}

	private void BuildUniqueResolutionList()
	{
		dropdown.ClearOptions();
		_uniqueResolutions.Clear();
		_options.Clear();
		HashSet<(int, int)> hashSet = new HashSet<(int, int)>();
		Resolution[] resolutions = Screen.resolutions;
		for (int i = 0; i < resolutions.Length; i++)
		{
			Resolution item = resolutions[i];
			(int, int) item2 = (item.width, item.height);
			if (!hashSet.Contains(item2))
			{
				hashSet.Add(item2);
				_uniqueResolutions.Add(item);
				_options.Add($"{item.width} x {item.height}");
			}
		}
		dropdown.AddOptions(_options);
	}

	private int GetStartupIndex()
	{
		if (preferLastSavedOverCurrent && PlayerPrefs.HasKey("video_resolution_index"))
		{
			return Mathf.Clamp(PlayerPrefs.GetInt("video_resolution_index"), 0, _uniqueResolutions.Count - 1);
		}
		return FindMatchIndex(Screen.width, Screen.height);
	}

	private int FindMatchIndex(int width, int height)
	{
		for (int i = 0; i < _uniqueResolutions.Count; i++)
		{
			if (_uniqueResolutions[i].width == width && _uniqueResolutions[i].height == height)
			{
				return i;
			}
		}
		return 0;
	}

	private void OnChanged(int index)
	{
		ApplyResolution(index);
		PlayerPrefs.SetInt("video_resolution_index", index);
		PlayerPrefs.Save();
	}

	private void ApplyResolution(int index)
	{
		index = Mathf.Clamp(index, 0, _uniqueResolutions.Count - 1);
		Resolution resolution = _uniqueResolutions[index];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
	}

	private void SetDropdownWithoutNotify(int index)
	{
		dropdown.SetValueWithoutNotify(index);
		dropdown.RefreshShownValue();
	}
}
