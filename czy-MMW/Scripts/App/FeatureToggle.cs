using System;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public static class FeatureToggle
{
	public const string GroupPrefix = "Group_";

	public const string FeatureToggleMenuItemDirectory = "Tools/Feature Toggles/";

	private static readonly List<IFeatureToggleSettingSource> ToggleSettingSources;

	private static readonly List<Feature> DynamicFeatures;

	private static readonly List<bool> FeatureStateCache;

	private static readonly ProfilerMarker Profiler_IsDynamicFeatureEnabled;

	static FeatureToggle()
	{
		ToggleSettingSources = new List<IFeatureToggleSettingSource>();
		Profiler_IsDynamicFeatureEnabled = new ProfilerMarker("FeatureToggle.IsDynamicFeatureEnabled");
		DynamicFeatures = new List<Feature>();
		string[] names = Enum.GetNames(typeof(Feature));
		Array values = Enum.GetValues(typeof(Feature));
		int num = names.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			if (!names[i].StartsWith("Group_"))
			{
				int num3 = (int)values.GetValue(i);
				num2 = Mathf.Max(num3, num2);
				DynamicFeatures.Add((Feature)num3);
			}
		}
		FeatureStateCache = new List<bool>(num2);
		while (FeatureStateCache.Count <= num2)
		{
			FeatureStateCache.Add(item: false);
		}
	}

	public static void AddSource(IFeatureToggleSettingSource newSource)
	{
		int i;
		for (i = 0; i < ToggleSettingSources.Count; i++)
		{
			if (ToggleSettingSources[i].SourcePriority == newSource.SourcePriority)
			{
				ToggleSettingSources[i].FeatureToggleStateChanged -= OnFeatureToggleStateChanged;
				ToggleSettingSources.RemoveAt(i);
				break;
			}
			if (ToggleSettingSources[i].SourcePriority > newSource.SourcePriority)
			{
				break;
			}
		}
		ToggleSettingSources.Insert(i, newSource);
		UpdateAllFeatureStates();
		newSource.FeatureToggleStateChanged += OnFeatureToggleStateChanged;
	}

	public static void RemoveAllSources()
	{
		foreach (IFeatureToggleSettingSource toggleSettingSource in ToggleSettingSources)
		{
			toggleSettingSource.FeatureToggleStateChanged -= OnFeatureToggleStateChanged;
		}
		ToggleSettingSources.Clear();
		UpdateAllFeatureStates();
	}

	public static bool IsFeatureEnabled(Feature featureToCheck)
	{
		return FeatureStateCache[(int)featureToCheck];
	}

	public static bool IsFeatureDisabled(Feature featureToCheck)
	{
		return !FeatureStateCache[(int)featureToCheck];
	}

	public static bool IsDynamicFeatureEnabled(Feature featureToCheck)
	{
		foreach (IFeatureToggleSettingSource toggleSettingSource in ToggleSettingSources)
		{
			switch (toggleSettingSource.GetFeatureToggleState(featureToCheck))
			{
			case FeatureToggleState.Enabled:
				return true;
			case FeatureToggleState.Disabled:
				return false;
			}
		}
		return false;
	}

	private static void OnFeatureToggleStateChanged(Feature feature, FeatureToggleState state)
	{
		FeatureStateCache[(int)feature] = IsDynamicFeatureEnabled(feature);
	}

	private static void UpdateAllFeatureStates()
	{
		foreach (Feature dynamicFeature in DynamicFeatures)
		{
			FeatureStateCache[(int)dynamicFeature] = IsDynamicFeatureEnabled(dynamicFeature);
		}
	}
}
