using SettingScripts;
using TMPro;
using UIScripts.SettingHandles;
using UIScripts.SettingHandles.References;
using UnityEngine;

namespace UIScripts
{
	public class ChallengeParametersHandle : MonoBehaviour
	{
		public static ChallengeParametersHandle instance;

		private ChallengeParameters settings;

		[SerializeField]
		private BibiteSettingsHandle championSettingsHandle;

		[SerializeField]
		private ConditionGroupHandle exitConditionHanddle;

		[SerializeField]
		private SimulationMetricHandle scoringMetricHanddle;

		[SerializeField]
		private SettingToggleReference highIsBetterToggleRef;

		private SettingToggle highIsBetterToggle;

		[SerializeField]
		private ConditionGroupHandle star1ConditionHanddle;

		[SerializeField]
		private ConditionGroupHandle star2ConditionHanddle;

		[SerializeField]
		private ConditionGroupHandle star3ConditionHanddle;

		[SerializeField]
		private TMP_InputField star1Description;

		[SerializeField]
		private TMP_InputField star2Description;

		[SerializeField]
		private TMP_InputField star3Description;

		public string star1Desc => star1Description.text;

		public string star2Desc => star1Description.text;

		public string star3Desc => star1Description.text;

		public void InitializeItem(ChallengeParameters challengeParameters)
		{
			if (instance != null)
			{
				Object.Destroy(instance);
			}
			instance = this;
			settings = challengeParameters;
			settings.championSettings.tagging.SetValue(Tagging.CustomTagging);
			settings.championSettings.customTag.SetValue("Champion");
			settings.championSettings.spawnType.SetValue(SpawnType.OneTime);
			championSettingsHandle.InitializeForChampion(settings.championSettings);
			exitConditionHanddle.Initialize(settings.exitCondition);
			scoringMetricHanddle.Initialize(settings.scoringMetric);
			highIsBetterToggle = new SettingToggle(settings.highScoreIsBetter, highIsBetterToggleRef);
			star1ConditionHanddle.Initialize(settings.oneStarCondition);
			star2ConditionHanddle.Initialize(settings.twoStarCondition);
			star3ConditionHanddle.Initialize(settings.threeStarCondition);
			star1Description.text = settings.star1Desc;
			star2Description.text = settings.star2Desc;
			star3Description.text = settings.star3Desc;
			star1Description.onValueChanged.AddListener(UpdateStar1Desc);
			star2Description.onValueChanged.AddListener(UpdateStar2Desc);
			star3Description.onValueChanged.AddListener(UpdateStar3Desc);
		}

		public void UpdateStar1Desc(string val)
		{
			settings.star1Desc = val;
		}

		public void UpdateStar2Desc(string val)
		{
			settings.star2Desc = val;
		}

		public void UpdateStar3Desc(string val)
		{
			settings.star3Desc = val;
		}
	}
}
