using UnityEngine;

public class GateHardSectionEnd : MonoBehaviour
{
	private enum State
	{
		Waiting = 0,
		LevelEnded = 1,
		Done = 2
	}

	private State currentState;

	private void Start()
	{
		GetComponent<Enemy>().OnUpdateTic += HandleOnUpdateTic;
	}

	private void HandleOnUpdateTic(Character c)
	{
		if (currentState == State.Waiting && GameStates.Singleton.level.SecondsLeft() <= 0 && GameStates.Singleton.level.Enemies.Count == 1)
		{
			currentState = State.LevelEnded;
			GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
			gameCamera.SetupLerpToPos(gameCamera.PositionX, gameCamera.PositionY, gameCamera.PositionZ, 0f);
		}
		else if (currentState == State.LevelEnded && GameStates.Singleton.hero.PositionX - GameStates.Singleton.level.gameCamera.PositionX > 28)
		{
			currentState = State.Done;
		}
	}
}
