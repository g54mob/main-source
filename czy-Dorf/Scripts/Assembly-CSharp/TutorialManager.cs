using System;
using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	[SerializeField]
	private bool playOnStart;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private TileStack tileStack;

	[SerializeField]
	private SessionQuest tutorialSessionQuest;

	[SerializeField]
	private SessionQuestWatcher sessionQuestWatcher;

	private TutorialPhase[] tutorialPhases;

	[SerializeField]
	private int currentPhase;

	private float lastPhaseStartTime;

	private int lastPhaseStackCount;

	public int CurrentPhase
	{
		get
		{
			if (currentPhase != 9)
			{
				return currentPhase;
			}
			return 8;
		}
	}

	public event Action<int> OnPhaseChanged;

	private void Awake()
	{
		tutorialPhases = GetComponentsInChildren<TutorialPhase>();
		if (PlayerPrefsAccessor.GetInt("TutorialStartPhase", -1) != -1)
		{
			currentPhase = PlayerPrefsAccessor.GetInt("TutorialStartPhase", 0);
		}
		TutorialPhase[] componentsInChildren = GetComponentsInChildren<TutorialPhase>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].Setup(this);
		}
		if (playOnStart)
		{
			tileStack.OnInitialized += StartTutorial;
		}
	}

	private void StartTutorial()
	{
		rewardSystem.OnGameOver += FinishCurrentPhase;
		tileStack.OnInitialized -= StartTutorial;
		for (int i = 0; i < currentPhase; i++)
		{
			tutorialPhases[i].Skip();
		}
		StartCurrentPhase();
		sessionQuestWatcher.SetupWatchedChallenge(tutorialSessionQuest, 0);
		UnityAnalyticsAccessor.SendTutorialStartEvent();
	}

	public void SetInteractionRestriction(InteractionRestriction restriction)
	{
		inputRouter.SetInteractionRestriction(restriction);
	}

	private void StartCurrentPhase()
	{
		lastPhaseStartTime = Time.time;
		lastPhaseStackCount = tileStack.Height;
		tutorialPhases[currentPhase].Begin();
		this.OnPhaseChanged?.Invoke(currentPhase);
	}

	private void FinishCurrentPhase(bool animate, bool setHighscore)
	{
		rewardSystem.OnGameOver -= FinishCurrentPhase;
		if (currentPhase < tutorialPhases.Length)
		{
			tutorialPhases[currentPhase].Finish(startNextPhase: false);
		}
	}

	public void SetTutorialPlayed(bool newValue)
	{
		PlayerPrefsAccessor.SetInt("TutorialPlayed", newValue ? 1 : 0);
	}

	private void DebugTutorialPlayed()
	{
		Debug.Log(PlayerPrefsAccessor.GetInt("TutorialPlayed", 0));
	}

	public void NextPhase()
	{
		UnityAnalyticsAccessor.TriggerTutorialEvent(currentPhase, new Dictionary<string, object>
		{
			{
				"duration",
				Time.time - lastPhaseStartTime
			},
			{
				"usedTiles",
				tileStack.Height - lastPhaseStackCount
			}
		});
		currentPhase++;
		if (currentPhase < tutorialPhases.Length)
		{
			StartCurrentPhase();
		}
		else
		{
			UnityAnalyticsAccessor.SendTutorialCompleteEvent();
		}
	}

	private void OnDestroy()
	{
		FinishCurrentPhase(animate: true, setHighscore: true);
		SetInteractionRestriction(new InteractionRestriction());
		rewardSystem.OnGameOver -= FinishCurrentPhase;
	}
}
