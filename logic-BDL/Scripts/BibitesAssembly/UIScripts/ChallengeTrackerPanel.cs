using ManagementScripts;
using SettingScripts;
using SimulationScripts;
using TMPro;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
	public class ChallengeTrackerPanel : UIPanel
	{
		private ChallengeParameters challenge;

		[SerializeField]
		private TextMeshProUGUI challengeLabel;

		[SerializeField]
		private TextMeshProUGUI challengeDesc;

		[SerializeField]
		private SimConditionText exitDesc;

		[SerializeField]
		private FloatValueTextHandle score;

		[SerializeField]
		private TextMeshProUGUI betterText;

		[SerializeField]
		private TextMeshProUGUI star1Desc;

		[SerializeField]
		private TextMeshProUGUI star2Desc;

		[SerializeField]
		private TextMeshProUGUI star3Desc;

		[SerializeField]
		private Image oneStarStar;

		[SerializeField]
		private Image twoStarStar;

		[SerializeField]
		private Image threeStarStar;

		public override void InitPanel()
		{
			base.InitPanel();
			challenge = ScenarioSettings.Instance.challengeParameters;
			challengeDesc.text = challenge.challengeDesc;
			exitDesc.Initialize(challenge.exitCondition.first);
			star1Desc.text = challenge.star1Desc;
			star2Desc.text = challenge.star2Desc;
			star3Desc.text = challenge.star3Desc;
			oneStarStar.color = ChallengesProgress.lockedStarColor;
			twoStarStar.color = ChallengesProgress.lockedStarColor;
			threeStarStar.color = ChallengesProgress.lockedStarColor;
			betterText.text = "(" + (challenge.highScoreIsBetter.val ? "High" : "Low") + " is better)";
			ChallengeManager.Instance.onChallengeChecked.AddListener(OnChallengeChecked);
			OnChallengeChecked();
		}

		protected override void UpdatePanel()
		{
			base.UpdatePanel();
			score.UpdateValue(challenge.scoringMetric.Evaluate());
		}

		public void OnChallengeChecked()
		{
			int starAttained = ChallengeManager.Instance.info.starAttained;
			oneStarStar.color = ((starAttained > 0) ? ChallengesProgress.unlockedStarColor : ChallengesProgress.lockedStarColor);
			twoStarStar.color = ((starAttained > 1) ? ChallengesProgress.unlockedStarColor : ChallengesProgress.lockedStarColor);
			threeStarStar.color = ((starAttained > 2) ? ChallengesProgress.unlockedStarColor : ChallengesProgress.lockedStarColor);
		}

		public void RetryClicked()
		{
			PopupManager.DisplayWarningWithCancel(null, "Retry Challenge", "You will lose all progress on this challenge. \n\nAre you sure?", "YES", RetryChallenge);
		}

		public void RetryChallenge()
		{
			GameManager.StartGame();
		}
	}
}
