using SettingScripts;
using SimulationScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	public class ChallengeEndPopup : MonoBehaviour
	{
		public GameObject winSection;

		public GameObject lostSection;

		public TextMeshProUGUI title;

		public TextMeshProUGUI challengeName;

		public TextMeshProUGUI scoreText;

		public GameObject tryToSection;

		public TextMeshProUGUI nextStarText;

		public Image star1;

		public Image star2;

		public Image star3;

		public GameObject highScoreSection;

		public GameObject lowScoreSection;

		public TextMeshProUGUI championName;

		public TextMeshProUGUI oldHighscore;

		public TextMeshProUGUI oldChampionName;

		public GameObject screenBlocker;

		private bool show;

		private void Awake()
		{
			if (!show)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		public void Show(ChallengeScoreInfo info)
		{
			show = true;
			base.gameObject.SetActive(value: true);
			screenBlocker.SetActive(value: true);
			bool flag = info.starAttained > 0;
			title.text = (flag ? "Congratulation!" : "Better luck next time...");
			winSection.SetActive(flag);
			lostSection.SetActive(!flag);
			star1.color = ((info.starAttained > 0) ? ChallengesProgress.unlockedStarColor : ChallengesProgress.lockedStarColor);
			star2.color = ((info.starAttained > 1) ? ChallengesProgress.unlockedStarColor : ChallengesProgress.lockedStarColor);
			star3.color = ((info.starAttained > 2) ? ChallengesProgress.unlockedStarColor : ChallengesProgress.lockedStarColor);
			if (!flag)
			{
				return;
			}
			challengeName.text = ScenarioSettings.Instance.challengeParameters.challengeName;
			scoreText.text = $"{info.score:F0}";
			bool flag2 = info.starAttained >= 3;
			tryToSection.SetActive(!flag2);
			if (!flag2)
			{
				nextStarText.text = ((info.starAttained < 2) ? ScenarioSettings.Instance.challengeParameters.star2Desc.ToLower() : ScenarioSettings.Instance.challengeParameters.star3Desc.ToLower());
			}
			bool isHighScore = ChallengeManager.isHighScore;
			highScoreSection.SetActive(isHighScore);
			if (isHighScore)
			{
				championName.text = info.championName;
				lowScoreSection.SetActive(value: false);
				return;
			}
			ChallengeScoreInfo highScoreOfChallenge = ChallengesProgress.GetHighScoreOfChallenge(info.challengeName);
			if (highScoreOfChallenge.starAttained > 0)
			{
				lowScoreSection.SetActive(value: true);
				oldHighscore.text = $"{highScoreOfChallenge.score:F0}";
				oldChampionName.text = highScoreOfChallenge.championName;
			}
			else
			{
				lowScoreSection.SetActive(value: false);
			}
		}

		public void ReturnToMenu()
		{
			ChallengeManager.Instance.ReturnToMenu();
		}

		public void ContinueAsScenario()
		{
			screenBlocker.SetActive(value: false);
			ChallengeManager.Instance.ContinueAsScenario();
		}
	}
}
