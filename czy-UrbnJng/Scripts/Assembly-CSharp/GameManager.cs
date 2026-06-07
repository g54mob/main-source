using UnityEngine;

public class GameManager : MonoBehaviour
{
	public enum State
	{
		MainMenu = 0,
		GamePlaying = 1,
		GamePaused = 2
	}

	private State state;

	public static GameManager Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public void SetState(State newState)
	{
		state = newState;
		Debug.Log(state);
	}

	public bool isMainMenu()
	{
		return state == State.MainMenu;
	}

	public bool isGamePlaying()
	{
		return state == State.GamePlaying;
	}

	public bool isGamePaused()
	{
		return state == State.GamePaused;
	}
}
