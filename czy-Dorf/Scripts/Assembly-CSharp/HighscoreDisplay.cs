using Dorfromantik;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreDisplay : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI textMeshProUgui;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private LeaderboardManager leaderboardManager;

	[SerializeField]
	private SceneLoader sceneLoader;

	private void Awake()
	{
		rewardSystem.OnReset += UpdateDisplayFromReset;
		rewardSystem.OnNewLocalHighscoreSet += UpdateHighscoreDisplayFromLocalHighscore;
		sceneLoader.OnSceneLoaded += UpdateDisplayFromSceneLoaded;
	}

	private void UpdateDisplayFromReset()
	{
		UpdateDisplay();
	}

	private void UpdateDisplayFromSceneLoaded(Scene obj)
	{
		Debug.Log("Update Highscore Display from Scene Loaded");
		UpdateDisplay(updateHighscore: false);
		if ((bool)OverwritingSingleton<GameSession>.Instance)
		{
			OverwritingSingleton<GameSession>.Instance.OnGameModeSet += UpdateDisplayFromGameModeSet;
			sceneLoader.OnSceneLoaded -= UpdateDisplayFromSceneLoaded;
		}
	}

	private void UpdateDisplayFromGameModeSet()
	{
		Debug.Log("Update Highscore Display from Game Mode set");
		UpdateDisplay(updateHighscore: false);
		OverwritingSingleton<GameSession>.Instance.OnGameModeSet -= UpdateDisplayFromGameModeSet;
	}

	public void UpdateDisplayFromMenuShown(bool show)
	{
		if (show)
		{
			UpdateDisplay();
		}
	}

	public void UpdateDisplay(bool updateHighscore = true)
	{
		rewardSystem.UpdateHighscore(forceUpdate: false);
		UpdateHighscoreDisplayFromLocalHighscore();
	}

	private void UpdateHighscoreDisplayFromLocalHighscore()
	{
		LeaderboardType currentLeaderboard = leaderboardManager.GetCurrentLeaderboard();
		if (currentLeaderboard == null)
		{
			Debug.Log("Not showing Highscore Display - currentScoreLeaderboard is null");
			return;
		}
		int num = PlayerPrefsAccessor.GetInt(currentLeaderboard.GetPlayerPrefsScoreKey(), -1);
		textMeshProUgui.text = ((num > 0) ? num.ToString() : "-");
	}

	private void OnDestroy()
	{
		rewardSystem.OnReset -= UpdateDisplayFromReset;
		rewardSystem.OnNewLocalHighscoreSet -= UpdateHighscoreDisplayFromLocalHighscore;
	}
}
