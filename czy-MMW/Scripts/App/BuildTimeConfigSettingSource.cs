using System;
using System.Collections.Generic;

public class BuildTimeConfigSettingSource : IFeatureToggleSettingSource
{
	private readonly Dictionary<Feature, ToggleSettings> _toggleSettings;

	private const string DefaultConfigResourceName = "DefaultConfig";

	public static readonly List<string> BuildSystemFeatureConfigs = new List<string>();

	public FeatureToggleSettingSourcePriority SourcePriority => FeatureToggleSettingSourcePriority.BuildTimeSource;

	public event Action<Feature, FeatureToggleState> FeatureToggleStateChanged
	{
		add
		{
		}
		remove
		{
		}
	}

	public BuildTimeConfigSettingSource(IEnvironment environment)
	{
		_toggleSettings = ToggleSettings.LoadSettingsFromFeatureConfigResource("DefaultConfig", "default environment configuration asset");
		LoadToggleSettingsFromFiles(environment.FeatureConfigs);
		LoadToggleSettingsFromFiles(BuildSystemFeatureConfigs);
	}

	private void LoadToggleSettingsFromFiles(List<string> featureConfigFilenames)
	{
		if (featureConfigFilenames == null || featureConfigFilenames.Count <= 0)
		{
			return;
		}
		foreach (string featureConfigFilename in featureConfigFilenames)
		{
			Dictionary<Feature, ToggleSettings> dictionary = ToggleSettings.LoadSettingsFromFeatureConfigResource(featureConfigFilename, "environment '" + featureConfigFilename + "' configuration asset");
			foreach (Feature key in dictionary.Keys)
			{
				_toggleSettings[key] = dictionary[key];
			}
		}
	}

	public FeatureToggleState GetFeatureToggleState(Feature forFeature)
	{
		if (_toggleSettings.TryGetValue(forFeature, out var value))
		{
			return value.featureToggleState;
		}
		return FeatureToggleState.NoOverride;
	}
}
