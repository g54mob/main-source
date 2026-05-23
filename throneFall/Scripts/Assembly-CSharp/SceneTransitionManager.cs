using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
	public enum SceneState
	{
		MainMenu = 0,
		LevelSelect = 1,
		InGame = 2
	}

	public static SceneTransitionManager instance;

	public string uiScene = "_UI";

	public string mainMenuScene = "_StartMenu";

	public string levelSelectScene;

	public Image placeholderCloudsTransition;

	public TMP_Text loadingText;

	public float cloudFadeInTime = 1f;

	public float cloudFadeOutTime = 2f;

	[HideInInspector]
	public UnityEvent onSceneChange = new UnityEvent();

	private SceneState currentSceneState;

	private SceneState lastSceneState;

	private int ingameScoreFromLastMatch;

	private int goldBonusScoreFromLastMatch;

	private int mutatorBonusScoreFromLastMatch;

	private int noRetryBonusScoreFromLastMatch;

	private string comingFromGameplayScene = "";

	private int totalScoreFromLastMatch;

	private bool totalScoreFromLastMatchIsNewPersonalRecord;

	private LevelData levelDataFromLastMatch;

	private bool sceneTransitionIsRunning;

	private Color cloudsIn;

	private Color cloudsOut;

	private Coroutine currentTransition;

	public SceneState CurrentSceneState => currentSceneState;

	public SceneState LastSceneState => lastSceneState;

	public int IngameScoreFromLastMatch => ingameScoreFromLastMatch;

	public int GoldBonusScoreFromLastMatch => goldBonusScoreFromLastMatch;

	public int MutatorBonusScoreFromLastMatch => mutatorBonusScoreFromLastMatch;

	public int NoRetryBonusScoreFromLastMatch => noRetryBonusScoreFromLastMatch;

	public int TotalScoreFromLastMatch => totalScoreFromLastMatch;

	public bool TotalScoreFromLastMatchIsNewPersonalRecord => totalScoreFromLastMatchIsNewPersonalRecord;

	public string ComingFromGameplayScene => comingFromGameplayScene;

	public LevelData LevelDataFromLastMatch => levelDataFromLastMatch;

	public bool SceneTransitionIsRunning => sceneTransitionIsRunning;

	private void Awake()
	{
		if ((bool)instance)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		Object.DontDestroyOnLoad(base.transform.root.gameObject);
		if (!SceneManager.GetSceneByName(uiScene).IsValid())
		{
			SceneManager.LoadScene(uiScene, LoadSceneMode.Additive);
		}
		cloudsIn = placeholderCloudsTransition.color;
		cloudsOut = cloudsIn;
		cloudsOut.a = 0f;
		loadingText.alpha = 0f;
	}

	private void Start()
	{
	}

	public void TransitionFromLevelSelectToLevel(string _levelname)
	{
		if (currentSceneState != SceneState.LevelSelect)
		{
			Debug.LogWarning("You should only transition to a specific level from the level selection scene.");
		}
		else
		{
			TransitionToScene(_levelname);
		}
	}

	public void TransitionFromNullToLevel(string _levelname)
	{
		TransitionToScene(_levelname);
	}

	public void RestartCurrentLevel()
	{
		TransitionToScene(SceneManager.GetActiveScene().name);
	}

	private void SetComingFromSceneToCurrentScene()
	{
		comingFromGameplayScene = SceneManager.GetActiveScene().name;
		if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.EternalTrial)
		{
			comingFromGameplayScene = "Eternal Trials";
		}
	}

	public void TransitionFromGameplayToEndScreen(int _score, int _goldBonusScore, int _mutatorBonusScore, int _noRetriesBonusScore)
	{
		SetComingFromSceneToCurrentScene();
		LevelData levelData = (levelDataFromLastMatch = LevelProgressManager.instance.GetLevelDataForScene(comingFromGameplayScene));
		if (currentSceneState != SceneState.InGame)
		{
			Debug.LogWarning("You should only transition to the end screen from a gameply level.");
			return;
		}
		ingameScoreFromLastMatch = _score;
		goldBonusScoreFromLastMatch = _goldBonusScore;
		mutatorBonusScoreFromLastMatch = _mutatorBonusScore;
		noRetryBonusScoreFromLastMatch = _noRetriesBonusScore;
		if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.Classic)
		{
			levelData.highscore = _score + _goldBonusScore + _mutatorBonusScore + _noRetriesBonusScore;
			totalScoreFromLastMatch = levelData.highscore;
			totalScoreFromLastMatchIsNewPersonalRecord = totalScoreFromLastMatch > levelData.highscoreBest;
		}
		else if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.EternalTrial)
		{
			totalScoreFromLastMatch = _score + _goldBonusScore;
			EternalTrialsRunManager.AddScore(totalScoreFromLastMatch);
		}
		UIFrameManager.TriggerEndOfMatch();
	}

	public void TransitionFromEndScreenToLevelSelect()
	{
		TransitionToScene(levelSelectScene);
	}

	private void TransitionToScene(string _scenename)
	{
		if (!sceneTransitionIsRunning)
		{
			lastSceneState = currentSceneState;
			if (_scenename == levelSelectScene)
			{
				currentSceneState = SceneState.LevelSelect;
			}
			else if (_scenename == mainMenuScene)
			{
				currentSceneState = SceneState.MainMenu;
			}
			else
			{
				currentSceneState = SceneState.InGame;
			}
			onSceneChange.Invoke();
			StartCoroutine(SceneTransitionAnimation(_scenename));
		}
	}

	private float FadeFormula(float f)
	{
		return Mathf.Pow(f, 4f);
	}

	private IEnumerator SceneTransitionAnimation(string _scenename)
	{
		sceneTransitionIsRunning = true;
		int sceneCount = SceneManager.sceneCount;
		placeholderCloudsTransition.gameObject.SetActive(value: true);
		float clock = 0f;
		while (clock <= cloudFadeInTime)
		{
			float num = Mathf.Clamp(Time.unscaledDeltaTime, 0f, 0.1f);
			clock += num;
			placeholderCloudsTransition.color = Color.Lerp(cloudsOut, cloudsIn, 1f - FadeFormula(1f - clock / cloudFadeInTime));
			loadingText.alpha = 1f - FadeFormula(1f - clock / cloudFadeInTime);
			yield return null;
		}
		placeholderCloudsTransition.color = cloudsIn;
		loadingText.alpha = 1f;
		List<AsyncOperation> loadOperations = new List<AsyncOperation>();
		if (sceneCount > 0)
		{
			for (int num2 = sceneCount - 1; num2 >= 0; num2--)
			{
				Scene sceneAt = SceneManager.GetSceneAt(num2);
				if (sceneAt.name != uiScene)
				{
					loadOperations.Add(SceneManager.UnloadSceneAsync(sceneAt));
				}
			}
		}
		loadOperations.Add(SceneManager.LoadSceneAsync(_scenename, LoadSceneMode.Additive));
		while (loadOperations.Count > 0)
		{
			for (int num3 = loadOperations.Count - 1; num3 >= 0; num3--)
			{
				if (loadOperations[num3].isDone)
				{
					loadOperations.RemoveAt(num3);
				}
			}
			yield return null;
		}
		SceneManager.SetActiveScene(SceneManager.GetSceneByName(_scenename));
		UIFrameManager.instance.CloseAllFrames();
		if (_scenename == mainMenuScene)
		{
			UIFrameManager.instance.SwitchToTitleFrame();
		}
		clock = 0f;
		while (clock <= cloudFadeOutTime)
		{
			float num4 = Mathf.Clamp(Time.unscaledDeltaTime, 0f, 0.1f);
			clock += num4;
			placeholderCloudsTransition.color = Color.Lerp(cloudsIn, cloudsOut, FadeFormula(clock / cloudFadeOutTime));
			loadingText.alpha = 1f - FadeFormula(1f - clock / cloudFadeInTime);
			yield return null;
		}
		placeholderCloudsTransition.color = cloudsOut;
		loadingText.alpha = 0f;
		placeholderCloudsTransition.gameObject.SetActive(value: false);
		sceneTransitionIsRunning = false;
	}

	public void TransitionFromNullToLevelSelect()
	{
		TransitionToScene(levelSelectScene);
	}

	public void TransitionFromLevelToLevelSelect()
	{
		SetComingFromSceneToCurrentScene();
		TransitionToScene(levelSelectScene);
	}

	public void TransitionToMainMenu()
	{
		TransitionToScene(mainMenuScene);
	}
}
