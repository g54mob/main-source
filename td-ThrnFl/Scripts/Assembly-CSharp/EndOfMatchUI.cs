using TMPro;
using UnityEngine;

public class EndOfMatchUI : MonoBehaviour
{
	public GameObject victoryScreen;

	public GameObject defeatScreen;

	public TextMeshProUGUI scorePanel;

	private void Start()
	{
		victoryScreen.SetActive(value: false);
		defeatScreen.SetActive(value: false);
		scorePanel.gameObject.SetActive(value: false);
		if ((bool)LocalGamestate.Instance)
		{
			LocalGamestate.Instance.OnGameStateChange.AddListener(GamestateHasChanged);
		}
	}

	private void GamestateHasChanged()
	{
		switch (LocalGamestate.Instance.CurrentState)
		{
		case LocalGamestate.State.AfterMatchDefeat:
			defeatScreen.SetActive(value: true);
			scorePanel.gameObject.SetActive(value: true);
			scorePanel.text = "score: " + ScoreManager.Instance.CurrentScore;
			break;
		case LocalGamestate.State.AfterMatchVictory:
			victoryScreen.SetActive(value: true);
			scorePanel.gameObject.SetActive(value: true);
			scorePanel.text = "score: " + ScoreManager.Instance.CurrentScore;
			break;
		}
	}
}
