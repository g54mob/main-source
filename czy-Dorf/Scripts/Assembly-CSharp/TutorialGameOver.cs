using Dorfromantik;
using UnityEngine;

public class TutorialGameOver : MonoBehaviour
{
	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private TutorialManager tutorialManager;

	private TutorialEvent[] tutorialEvents;

	private void Awake()
	{
		tutorialEvents = GetComponentsInChildren<TutorialEvent>();
	}

	private void Start()
	{
		rewardSystem.OnGameOver += ShowTutorialGameOver;
	}

	private void ShowTutorialGameOver(bool animate, bool setHighscore)
	{
		TutorialEvent[] array = tutorialEvents;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Begin();
		}
		PlayerPrefsAccessor.SetInt("TutorialStartPhase", tutorialManager.CurrentPhase);
	}

	private void OnDestroy()
	{
		rewardSystem.OnGameOver -= ShowTutorialGameOver;
	}
}
