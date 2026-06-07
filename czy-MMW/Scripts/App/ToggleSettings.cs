using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

public class ToggleSettings
{
	public class BuildFlagToggleSetting
	{
		public enum BuildFlagState
		{
			IsSet = 0,
			IsNotSet = 1
		}

		public enum BuildFlagAction
		{
			CompileOut = 0,
			HideInOptions = 1,
			ShowInOptions = 2,
			DefaultToEnabled = 3,
			DefaultToDisabled = 4
		}

		public string BuildFlag;

		public BuildFlagState FlagState;

		public BuildFlagAction BuildAction;

		public static BuildFlagToggleSetting LoadFromRootJson(JSON.Dictionary rootDictionary, string configurationNameForLogging)
		{
			BuildFlagToggleSetting buildFlagToggleSetting = new BuildFlagToggleSetting();
			if (rootDictionary.ContainsKey("BuildFlag"))
			{
				buildFlagToggleSetting.BuildFlag = rootDictionary.GetString("BuildFlag");
			}
			if (rootDictionary.ContainsKey("FlagState"))
			{
				string text = rootDictionary.GetString("FlagState");
				if (!Diagnostics.Verify(Enum.TryParse<BuildFlagState>(text, out buildFlagToggleSetting.FlagState), "Failed to parse use case {0} for configuration {1}.", text, configurationNameForLogging))
				{
					return null;
				}
			}
			if (rootDictionary.ContainsKey("BuildAction"))
			{
				string text2 = rootDictionary.GetString("BuildAction");
				if (!Diagnostics.Verify(Enum.TryParse<BuildFlagAction>(text2, out buildFlagToggleSetting.BuildAction), "Failed to parse build action {0} for configuration {1}.", text2, configurationNameForLogging))
				{
					return null;
				}
			}
			return buildFlagToggleSetting;
		}

		public Dictionary<string, object> GenerateJsonDictionaryForSetting()
		{
			return new Dictionary<string, object>
			{
				{
					"BuildFlag",
					BuildFlag.ToString()
				},
				{
					"FlagState",
					FlagState.ToString()
				},
				{
					"BuildAction",
					BuildAction.ToString()
				}
			};
		}

		public BuildFlagToggleSetting Duplicate()
		{
			return new BuildFlagToggleSetting
			{
				BuildFlag = BuildFlag,
				FlagState = FlagState,
				BuildAction = BuildAction
			};
		}
	}

	public Feature feature;

	public FeatureToggleState featureToggleState;

	public List<BuildFlagToggleSetting> buildFlagToggleSettings = new List<BuildFlagToggleSetting>();

	private const string FeatureToggleKey = "FeatureToggles";

	private const string FeatureNameKey = "Feature";

	private const string ToggleStateKey = "ToggleState";

	private const string BuildFlagsKey = "BuildFlags";

	public bool CanBeRemoved()
	{
		if (featureToggleState == FeatureToggleState.NoOverride)
		{
			return buildFlagToggleSettings.Count == 0;
		}
		return false;
	}

	public ToggleSettings Duplicate()
	{
		ToggleSettings toggleSettings = new ToggleSettings();
		toggleSettings.feature = feature;
		toggleSettings.featureToggleState = featureToggleState;
		toggleSettings.buildFlagToggleSettings = new List<BuildFlagToggleSetting>(buildFlagToggleSettings.Count);
		foreach (BuildFlagToggleSetting buildFlagToggleSetting in buildFlagToggleSettings)
		{
			toggleSettings.buildFlagToggleSettings.Add(buildFlagToggleSetting.Duplicate());
		}
		return toggleSettings;
	}

	[NotNull]
	public static ToggleSettings InitializeNewSettings(Feature forFeature, FeatureToggleState newToggleState)
	{
		return new ToggleSettings
		{
			feature = forFeature,
			featureToggleState = newToggleState
		};
	}

	[NotNull]
	public static Dictionary<Feature, ToggleSettings> LoadSettingsFromFeatureConfigResource(string featureConfigResourceName, string configurationNameForLogging, bool errorOnFeatureNotFound = false)
	{
		string text = string.Format("{0}{1}{2}", "FeatureToggleConfigs", Path.DirectorySeparatorChar, featureConfigResourceName);
		TextAsset textAsset = Resources.Load(text, typeof(TextAsset)) as TextAsset;
		if (textAsset == null)
		{
			text = string.Format("{0}{1}BuildTimeConfigs{2}{3}", "FeatureToggleConfigs", Path.DirectorySeparatorChar, Path.DirectorySeparatorChar, featureConfigResourceName);
			textAsset = Resources.Load(text, typeof(TextAsset)) as TextAsset;
		}
		if (Diagnostics.Verify(textAsset != null, "Can't find the {0} in the resources folder!  Attempted path {1}.", configurationNameForLogging, text))
		{
			return LoadSettingsFromJsonString(textAsset.text, configurationNameForLogging, errorOnFeatureNotFound);
		}
		return new Dictionary<Feature, ToggleSettings>();
	}

	[NotNull]
	private static Dictionary<Feature, ToggleSettings> LoadSettingsFromJsonString(string toggleSettingsJson, string configurationNameForLogging, bool errorOnFeatureNotFound = false)
	{
		Dictionary<Feature, ToggleSettings> dictionary = new Dictionary<Feature, ToggleSettings>();
		JSON.Dictionary dictionary2 = JSON.LoadFromString(toggleSettingsJson) as JSON.Dictionary;
		if (!Diagnostics.Verify(dictionary2 != null, "Failed to parse JSON from the {0}.", configurationNameForLogging))
		{
			return dictionary;
		}
		JSON.Array array = dictionary2.GetArray("FeatureToggles");
		if (Diagnostics.Verify(array != null, "Couldn't find the feature toggle collection!"))
		{
			for (int i = 0; i < array.Count; i++)
			{
				JSON.Dictionary dictionary3 = array.GetDictionary(i);
				if (!Diagnostics.Verify(dictionary3 != null, "Couldn't parse a dictionary out of index {0} in the feature toggle collection.", i))
				{
					continue;
				}
				string text = dictionary3.GetString("Feature");
				Feature result = Feature.NotSelected;
				int num;
				int condition;
				if (!string.IsNullOrEmpty(text))
				{
					num = (Enum.TryParse<Feature>(text, out result) ? 1 : 0);
					if (num != 0)
					{
						condition = 1;
						goto IL_009e;
					}
				}
				else
				{
					num = 0;
				}
				condition = ((!errorOnFeatureNotFound) ? 1 : 0);
				goto IL_009e;
				IL_009e:
				Diagnostics.Verify((byte)condition != 0, "Failed to parse feature name from string {0}!", text);
				if (num == 0)
				{
					continue;
				}
				string text2 = dictionary3.GetString("ToggleState");
				FeatureToggleState result2 = FeatureToggleState.NoOverride;
				Diagnostics.Verify(!string.IsNullOrEmpty(text2) && Enum.TryParse<FeatureToggleState>(text2, out result2), "Failed to parse feature toggle state for feature {0} with value {1}!", text, text2);
				ToggleSettings toggleSettings = InitializeNewSettings(result, result2);
				if (dictionary3.ContainsKey("BuildFlags"))
				{
					JSON.Array array2 = dictionary3.GetArray("BuildFlags");
					for (int j = 0; j < array2.Count; j++)
					{
						BuildFlagToggleSetting buildFlagToggleSetting = BuildFlagToggleSetting.LoadFromRootJson(array2.GetDictionary(j), configurationNameForLogging);
						if (buildFlagToggleSetting != null)
						{
							toggleSettings.buildFlagToggleSettings.Add(buildFlagToggleSetting);
						}
					}
				}
				dictionary.Add(toggleSettings.feature, toggleSettings);
			}
		}
		return dictionary;
	}
}
