using Rewired;
using UnityEngine;

public class CancelOrOpenPauseMenu : MonoBehaviour
{
	private Player input;

	private ChoiceManager choiceManager;

	private void Start()
	{
		input = ReInput.players.GetPlayer(0);
		choiceManager = ChoiceManager.instance;
	}

	private void Update()
	{
		if (input.GetButtonDown("Pause Menu & Cancel"))
		{
			if (choiceManager.ChoiceCoroutineRunning)
			{
				choiceManager.CancelChoice();
			}
			else
			{
				SceneTransitionManager.instance.TransitionFromGameplayToEndScreen(ScoreManager.Instance.CurrentScore, 0, 0, 0);
			}
		}
	}
}
