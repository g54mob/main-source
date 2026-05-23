using System.Collections.Generic;
using UnityEngine;

public class SettingsResolution : MonoBehaviour
{
	public EnumSelector selector;

	private Dictionary<int, Resolution> availableResolutions = new Dictionary<int, Resolution>();

	private void Start()
	{
		selector.onChange.AddListener(ApplyResolution);
	}

	private void OnEnable()
	{
		selector.options.Clear();
		availableResolutions.Clear();
		int index = 0;
		for (int i = 0; i < Screen.resolutions.Length; i++)
		{
			Resolution resolution = Screen.resolutions[i];
			availableResolutions.Add(i, resolution);
			string item = resolution.width + " x " + resolution.height + " @ " + resolution.refreshRateRatio.value.ToString("F0") + "Hz";
			selector.options.Add(item);
			if (resolution.CompareResolutions(SettingsManager.Instance.CurrentResolution))
			{
				index = i;
			}
		}
		selector.SetIndex(index);
	}

	private void ApplyResolution()
	{
		if (availableResolutions.TryGetValue(selector.Index, out var value) && !value.CompareResolutions(SettingsManager.Instance.CurrentResolution))
		{
			SettingsManager.Instance.SetResolution(value);
		}
	}
}
