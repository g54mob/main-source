using System;
using System.Collections;
using System.Collections.Generic;
using ManagementScripts;
using SettingScripts;
using UIScripts;
using UIScripts.UIReferences;
using UnityEngine;
using UnityEngine.Events;

namespace SimulationScripts
{
	public class ChallengeManager : MonoBehaviour
	{
		public static ChallengeManager Instance;

		[SerializeField]
		private List<GameObject> objectsToHide = new List<GameObject>();

		[SerializeField]
		private List<GameObject> objectsToEnable = new List<GameObject>();

		[SerializeField]
		private ChallengeEndPopup challengePopup;

		[SerializeField]
		private ChallengeTrackerPanel tracker;

		private ChallengeParameters challenge;

		public ChallengeScoreInfo info;

		public static bool isHighScore;

		public UnityEvent onChallengeChecked = new UnityEvent();

		public static bool isChallenge => Instance != null;

		private void Awake()
		{
			if (Instance != null)
			{
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				Instance = this;
			}
		}

		private void Start()
		{
			if (ScenarioSettings.Instance.isChallenge && !SimulationManager.gameWasLoaded)
			{
				objectsToHide.ForEach(delegate(GameObject o)
				{
					o.SetActive(value: false);
				});
				objectsToEnable.ForEach(delegate(GameObject o)
				{
					o.SetActive(value: true);
				});
				challenge = ScenarioSettings.Instance.challengeParameters;
				StartCoroutine(RunChallenge());
				info.challengeName = challenge.challengeName;
				info.championName = challenge.championSettings.templateName;
				info.championFullPath = challenge.championSettings.fullPath;
				tracker.gameObject.SetActive(value: false);
			}
			else
			{
				ContinueAsScenario();
			}
		}

		public IEnumerator RunChallenge()
		{
			WaitForSeconds wait = new WaitForSeconds(1f);
			do
			{
				yield return wait;
			}
			while (UpdateAndCheck());
			TimeController.Instance.TogglePauseGame("ChallengeEnd");
			UserControl.SetKeyboardBlockFromSource("Challenge", block: true);
			CheckHighScore();
			challengePopup.Show(info);
		}

		public bool UpdateAndCheck()
		{
			bool result = !challenge.exitCondition.EvaluateIsMet();
			info.starAttained = GetStar();
			info.score = challenge.scoringMetric.Evaluate();
			onChallengeChecked.Invoke();
			return result;
		}

		public void CheckHighScore()
		{
			info.time = DateTime.Now;
			isHighScore = ChallengesProgress.TrySetHighScoreOfChallenge(info, challenge.highScoreIsBetter.val);
		}

		public int GetStar()
		{
			if (challenge.threeStarCondition.EvaluateIsMet())
			{
				return 3;
			}
			if (challenge.twoStarCondition.EvaluateIsMet())
			{
				return 2;
			}
			if (challenge.oneStarCondition.EvaluateIsMet())
			{
				return 1;
			}
			return 0;
		}

		public void ContinueAsScenario()
		{
			objectsToHide.ForEach(delegate(GameObject o)
			{
				o.SetActive(value: true);
			});
			objectsToEnable.ForEach(UnityEngine.Object.Destroy);
			UnityEngine.Object.Destroy(tracker.gameObject);
			UnityEngine.Object.Destroy(challengePopup.gameObject);
			TimeController.Instance.TogglePauseGame("ChallengeEnd", isUnpause: true);
			UserControl.SetKeyboardBlockFromSource("Challenge", block: false);
			ScenarioSettings.Instance.challengeParameters = null;
			Instance = null;
			UnityEngine.Object.Destroy(this);
		}

		public void ReturnToMenu()
		{
			ScenarioSettings.Instance.challengeParameters = null;
			TimeController.Instance.TogglePauseGame("ChallengeEnd", isUnpause: true);
			UserControl.SetKeyboardBlockFromSource("Challenge", block: false);
			GameManager.OpenMenu();
			Instance = null;
		}
	}
}
