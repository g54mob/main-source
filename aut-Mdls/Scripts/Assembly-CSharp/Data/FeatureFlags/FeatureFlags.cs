#define ENABLE_DEBUG_EXCEPTIONS
#define ENABLE_DEBUG_ERRORS
using System;
using System.IO;
using UnityEngine;
using Utils;

namespace Data.FeatureFlags
{
	[CreateAssetMenu(fileName = "FeatureFlags", menuName = "FeatureFlags/FeatureFlags", order = 0)]
	public class FeatureFlags : ScriptableObject
	{
		[SerializeField]
		private FeatureFlagsData _defaultFeatureFlagsData;

		[SerializeField]
		private FeatureFlagsData _demoFeatureFlagsData;

		[SerializeField]
		private FeatureFlagsData _playtestFeatureFlagsData;

		[SerializeField]
		private FeatureFlagsData _developFeatureFlagsData;

		[SerializeField]
		private FeatureFlagsData _trailerFeatureFlagsData;

		[SerializeField]
		private FeatureFlagsData _kioskFeatureFlagsData;

		private const string FeatureFlagsFileName = "FeatureFlags.json";

		private bool _hasBeenOverridden;

		private FeatureFlagsData _overriddenFeatureFlagsData;

		public FeatureFlagsData OverriddenFeatureFlagsData
		{
			get
			{
				return _overriddenFeatureFlagsData;
			}
			set
			{
				_overriddenFeatureFlagsData = value;
				_hasBeenOverridden = value != null;
			}
		}

		public FeatureFlagsData Current
		{
			get
			{
				if (_hasBeenOverridden)
				{
					return _overriddenFeatureFlagsData;
				}
				return _demoFeatureFlagsData;
			}
		}

		public FeatureFlagsData GetDefaultFeatureFlagsData()
		{
			return _defaultFeatureFlagsData;
		}

		private void OnEnable()
		{
			LoadFeatureFlags();
		}

		private void LoadFeatureFlags()
		{
			OverriddenFeatureFlagsData = null;
			string file = Path.Combine(Application.streamingAssetsPath, "FeatureFlags.json");
			string text;
			if (Current.DemoFeatures && !Current.IsDevelopment)
			{
				this.LogError("Not allowed to overwrite a non-development demo build's feature flag from .json !", "LoadFeatureFlags", 75);
			}
			else if (FileUtils.TryReadText(file, out text))
			{
				try
				{
					FeatureFlagsData featureFlagsData = UnityEngine.Object.Instantiate(Current);
					JsonUtility.FromJsonOverwrite(text, featureFlagsData);
					OverriddenFeatureFlagsData = featureFlagsData;
				}
				catch (Exception ex)
				{
					this.LogAssertion("Error reading feature flags: " + ex.Message, "LoadFeatureFlags", 92);
				}
			}
		}
	}
}
