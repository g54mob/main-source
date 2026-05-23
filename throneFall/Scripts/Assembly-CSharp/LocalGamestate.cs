using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LocalGamestate : MonoBehaviour
{
	public enum GameMode
	{
		Classic = 0,
		EternalTrial = 1
	}

	public enum State
	{
		PreMatch = 0,
		InMatch = 1,
		AfterMatchVictory = 2,
		AfterMatchDefeat = 3
	}

	private static GameMode selectedGameMode;

	private static bool gameModeSet;

	[SerializeField]
	private bool autoStartMatch = true;

	[SerializeField]
	private State currentState;

	[SerializeField]
	private List<Hp> objectsThatTriggerLoseWhenDestroyed = new List<Hp>();

	[HideInInspector]
	public UnityEvent OnGameStateChange = new UnityEvent();

	private static LocalGamestate instance;

	private bool playerFrozen;

	[HideInInspector]
	public bool endScreenShownThisMatch;

	public static GameMode SelectedGameMode
	{
		get
		{
			return selectedGameMode;
		}
		set
		{
			selectedGameMode = value;
			gameModeSet = true;
		}
	}

	public static bool GameModeSet => gameModeSet;

	public State CurrentState => currentState;

	public static LocalGamestate Instance => instance;

	public bool PlayerFrozen => playerFrozen;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("Multiple LocalGamestate Objects detected. Please make sure there is only on LocalGamestate in the scene. Old instance got destroyed.");
			Object.Destroy(instance.gameObject);
		}
		instance = this;
	}

	private void Start()
	{
		LevelProgressManager.instance.GetLevelDataForActiveScene()?.SaveScoreAndStatsToBestIfBest(_endOfMatch: false);
		if (autoStartMatch)
		{
			SetState(State.InMatch);
		}
		foreach (Hp item in objectsThatTriggerLoseWhenDestroyed)
		{
			if ((bool)item && item.OnKillOrKnockout != null)
			{
				item.OnKillOrKnockout.AddListener(OnVitalObjectKill);
			}
		}
	}

	public void SetState(State nextState, bool forceTransition = false, bool immediate = false)
	{
		if (currentState == State.AfterMatchVictory || currentState == State.AfterMatchDefeat || (nextState == currentState && !forceTransition))
		{
			return;
		}
		currentState = nextState;
		OnGameStateChange.Invoke();
		if (currentState == State.AfterMatchVictory)
		{
			LevelData levelDataForActiveScene = LevelProgressManager.instance.GetLevelDataForActiveScene();
			if (levelDataForActiveScene != null)
			{
				levelDataForActiveScene.beaten = true;
			}
			MatchSaveLoadHandler.MarkRunCompleteAndSave();
		}
		else
		{
			LevelData levelDataForActiveScene2 = LevelProgressManager.instance.GetLevelDataForActiveScene();
			if (levelDataForActiveScene2 != null)
			{
				levelDataForActiveScene2.beaten = false;
			}
		}
		if (CurrentState == State.AfterMatchDefeat)
		{
			MusicManager.instance.PlayMusic(null, 3f);
		}
		if (currentState == State.AfterMatchVictory || currentState == State.AfterMatchDefeat)
		{
			StartCoroutine(WaitThenTriggerEndOfMatchScreen(immediate));
		}
	}

	private IEnumerator WaitThenTriggerEndOfMatchScreen(bool immediate = false)
	{
		if (currentState == State.AfterMatchVictory)
		{
			if (selectedGameMode == GameMode.EternalTrial)
			{
				EternalTrialsRunManager.OnVictory();
			}
		}
		else if (currentState == State.AfterMatchDefeat && selectedGameMode == GameMode.EternalTrial)
		{
			EternalTrialsRunManager.OnDefeat();
		}
		if (immediate)
		{
			yield return null;
		}
		else
		{
			yield return new WaitForSeconds(1f);
		}
		if (currentState == State.AfterMatchVictory)
		{
			SceneTransitionManager.instance.TransitionFromGameplayToEndScreen(ScoreManager.Instance.CurrentScore, ScoreManager.Instance.VictoryGoldBonus, ScoreManager.Instance.VictoryMutatorBonus, ScoreManager.Instance.VictoryNoRetryBonus);
		}
		else
		{
			SceneTransitionManager.instance.TransitionFromGameplayToEndScreen(ScoreManager.Instance.CurrentScore, 0, 0, ScoreManager.Instance.DefeatNoRetryBonus);
		}
		yield return null;
	}

	private void OnVitalObjectKill()
	{
		if (currentState == State.InMatch)
		{
			SetState(State.AfterMatchDefeat);
		}
	}

	public void SetPlayerFreezeState(bool frozen)
	{
		playerFrozen = frozen;
	}
}
