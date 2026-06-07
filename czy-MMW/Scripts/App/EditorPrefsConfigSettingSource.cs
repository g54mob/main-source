using System;
using System.Collections.Generic;

public class EditorPrefsConfigSettingSource : IFeatureToggleSettingSource
{
	private static readonly Dictionary<Feature, string> FeatureToggleIdCache = new Dictionary<Feature, string>();

	private static EditorPrefsConfigSettingSource Instance;

	public FeatureToggleSettingSourcePriority SourcePriority => FeatureToggleSettingSourcePriority.EditorPrefsSource;

	public event Action<Feature, FeatureToggleState> FeatureToggleStateChanged;

	public EditorPrefsConfigSettingSource()
	{
		Instance = this;
	}

	public FeatureToggleState GetFeatureToggleState(Feature forFeature)
	{
		return GetEditorPrefsFeatureState(forFeature);
	}

	public static void SetEditorPrefsFeatureState(Feature forFeature, FeatureToggleState newState)
	{
		Instance?.FeatureToggleStateChanged?.Invoke(forFeature, newState);
	}

	public static FeatureToggleState GetEditorPrefsFeatureState(Feature feature)
	{
		return FeatureToggleState.NoOverride;
	}

	private static string GetEditorPrefsKeyForFeature(Feature feature)
	{
		if (FeatureToggleIdCache.TryGetValue(feature, out var value))
		{
			return value;
		}
		string text = $"UnityEditorFeatureToggle-{feature}";
		FeatureToggleIdCache.Add(feature, text);
		return text;
	}
}
