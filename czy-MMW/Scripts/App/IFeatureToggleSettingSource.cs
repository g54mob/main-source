using System;

public interface IFeatureToggleSettingSource
{
	FeatureToggleSettingSourcePriority SourcePriority { get; }

	event Action<Feature, FeatureToggleState> FeatureToggleStateChanged;

	FeatureToggleState GetFeatureToggleState(Feature forFeature);
}
