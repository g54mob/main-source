using System;
using UnityEngine;

public class Puzzle_Taxi : BlackStarPuzzle
{
	public static Puzzle_Taxi Singleton;

	[Header("Puzzle Objects")]
	[SerializeField]
	private GameObject taxi;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	public override void Start()
	{
		base.Start();
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Combine(singleton.OnRoundStart_Action, new Action(OnRoundStart));
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Remove(singleton.OnRoundStart_Action, new Action(OnRoundStart));
	}

	private void OnRoundStart()
	{
	}

	private void Update()
	{
		if (GameManager.Singleton.gameState == GameManager.GameState.Playing && !puzzleCompleted && taxi == null)
		{
			CompletePuzzle(true, true);
		}
	}

	public override void CompletePuzzle(bool _spawnOrb, bool _playSpawnSFX)
	{
		base.CompletePuzzle(_spawnOrb, _playSpawnSFX);
	}
}
