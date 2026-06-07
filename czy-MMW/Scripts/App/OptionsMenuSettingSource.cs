using System;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuSettingSource : IFeatureToggleSettingSource
{
	private readonly Dictionary<Feature, ToggleSettings> _toggleSettings = new Dictionary<Feature, ToggleSettings>();

	private static readonly Dictionary<Feature, string> FeatureToggleIdCache = new Dictionary<Feature, string>();

	private static OptionsMenuSettingSource Instance = null;

	public FeatureToggleSettingSourcePriority SourcePriority => FeatureToggleSettingSourcePriority.InGameOptionsSource;

	public event Action<Feature, FeatureToggleState> FeatureToggleStateChanged;

	public OptionsMenuSettingSource()
	{
		Instance = this;
		bool flag = false;
		foreach (Feature value in Enum.GetValues(typeof(Feature)))
		{
			if (value == Feature.Group_Hidden)
			{
				flag = true;
			}
			else if (flag && value.ToString().StartsWith("Group_", StringComparison.Ordinal))
			{
				flag = false;
			}
			else if (!flag)
			{
				_toggleSettings.Add(value, GetPlayerPrefsFeatureToggleSettings(value));
			}
		}
	}

	public static FeatureToggleState GetOptionsMenuFeatureState(Feature forFeature)
	{
		if (Instance != null)
		{
			return Instance.GetFeatureToggleState(forFeature);
		}
		return FeatureToggleState.NoOverride;
	}

	public static void SetOptionsMenuFeatureState(Feature forFeature, FeatureToggleState newState)
	{
		Instance?.SetFeatureToggleState(forFeature, newState);
	}

	public FeatureToggleState GetFeatureToggleState(Feature forFeature)
	{
		if (_toggleSettings.TryGetValue(forFeature, out var value))
		{
			return value.featureToggleState;
		}
		return FeatureToggleState.NoOverride;
	}

	private void SetFeatureToggleState(Feature forFeature, FeatureToggleState newState)
	{
		if (_toggleSettings.TryGetValue(forFeature, out var value))
		{
			value.featureToggleState = newState;
		}
		else
		{
			if (newState == FeatureToggleState.NoOverride)
			{
				return;
			}
			value = ToggleSettings.InitializeNewSettings(forFeature, newState);
			_toggleSettings.Add(forFeature, value);
		}
		PlayerPrefs.SetInt(GetPlayerPrefsKeyForFeature(forFeature), (int)value.featureToggleState);
		this.FeatureToggleStateChanged?.Invoke(forFeature, value.featureToggleState);
	}

	private static string GetPlayerPrefsKeyForFeature(Feature feature)
	{
		if (FeatureToggleIdCache.TryGetValue(feature, out var value))
		{
			return value;
		}
		string text = $"PlayerPrefsFeatureToggle-{feature}";
		FeatureToggleIdCache.Add(feature, text);
		return text;
	}

	private static ToggleSettings GetPlayerPrefsFeatureToggleSettings(Feature feature)
	{
		FeatureToggleState newToggleState = (FeatureToggleState)PlayerPrefs.GetInt(GetPlayerPrefsKeyForFeature(feature), 0);
		return ToggleSettings.InitializeNewSettings(feature, newToggleState);
	}
}
