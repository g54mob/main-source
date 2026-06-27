using System;
using System.Collections.Generic;
using Restory.Data.Locations;
using Restory.Data.Tables.Parameters;
using UnityEngine;

namespace Restory.Data.GameConfigs
{
	[CreateAssetMenu(menuName = "Restory/Infrastructure/Create GameConfig", fileName = "GameConfig", order = 0)]
	public class GameConfig : ScriptableObject, IGameParametersEntity
	{
		[Serializable]
		public class PresetActivationRuleset
		{
			public GameMode Mode;

			public ActivationPlatform Platforms;
		}

		[Serializable]
		public struct ActivationPlatform
		{
			public bool Editor;

			public bool ReleaseBuild;

			public bool DeveloperBuild;

			public bool GetSupportedStatus()
			{
				bool flag = false;
				if (Application.isEditor)
				{
					return Editor;
				}
				if (Debug.isDebugBuild)
				{
					return DeveloperBuild;
				}
				return ReleaseBuild;
			}
		}

		[SerializeField]
		private VersionType versionType;

		[SerializeField]
		private string minimalSupportedSaveFileVersion;

		[SerializeField]
		private SystemLanguage[] supportedLocalizations = new SystemLanguage[1] { SystemLanguage.English };

		[SerializeField]
		private PresetActivationRuleset[] presetActivationRulesets;

		[SerializeField]
		private ActivationPlatform analyticsSupportedPlatforms;

		[SerializeField]
		private ActivationPlatform saveSystemSupportedPlatforms;

		[SerializeField]
		private ActivationPlatform cheatConsoleSupportedPlatforms;

		[SerializeField]
		private ActivationPlatform unityUserReportSupportedPlatforms;

		[SerializeField]
		private ActivationPlatform logConsoleSupportedPlatforms;

		[SerializeField]
		private ActivationPlatform deviceSelectionPanelSupportedPlatforms;

		[SerializeField]
		private ActivationPlatform randomNpcVisitsSupportedPlatforms;

		[Space]
		[SerializeField]
		private int tweenersCapacity = 500;

		[SerializeField]
		private int sequencesCapacity = 312;

		[NonSerialized]
		private VersionType replacedVersionType;

		[NonSerialized]
		private bool wasVersionTypeReplaced;

		public VersionType VersionType
		{
			get
			{
				if (!wasVersionTypeReplaced)
				{
					return versionType;
				}
				return replacedVersionType;
			}
		}

		public string MinimalSupportedSaveFileVersion => minimalSupportedSaveFileVersion;

		public IReadOnlyCollection<SystemLanguage> SupportedLocalizations => supportedLocalizations;

		public IReadOnlyCollection<PresetActivationRuleset> PresetActivationRulesets => presetActivationRulesets;

		public ActivationPlatform AnalyticsSupportedPlatforms => analyticsSupportedPlatforms;

		public ActivationPlatform SaveSystemSupportedPlatforms => saveSystemSupportedPlatforms;

		public ActivationPlatform CheatConsoleSupportedPlatforms => cheatConsoleSupportedPlatforms;

		public ActivationPlatform UnityUserReportPlatforms => unityUserReportSupportedPlatforms;

		public ActivationPlatform LogConsoleSupportedPlatforms => logConsoleSupportedPlatforms;

		public ActivationPlatform DeviceSelectionPanelSupportedPlatforms => deviceSelectionPanelSupportedPlatforms;

		public ActivationPlatform RandomNpcVisitsSupportedPlatforms => randomNpcVisitsSupportedPlatforms;

		public int TweenersCapacity => tweenersCapacity;

		public int SequencesCapacity => sequencesCapacity;

		public void ReplaceVersionType(VersionType versionType)
		{
			replacedVersionType = versionType;
			wasVersionTypeReplaced = true;
		}
	}
}
