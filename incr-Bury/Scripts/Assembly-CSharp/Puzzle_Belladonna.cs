using System;
using System.Collections;
using UnityEngine;

public class Puzzle_Belladonna : BlackStarPuzzle
{
	public static Puzzle_Belladonna Singleton;

	[Header("Belladonna Puzzle")]
	[SerializeField]
	private Transform tunnelEntrance_TeleportSpot;

	[SerializeField]
	private GameObject tunnelSealWall;

	private bool hasUsedWorldUsable;

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
		tunnelSealWall.SetActive(value: false);
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
	}

	public override void CompletePuzzle(bool _spawnOrb, bool _playSpawnSFX)
	{
		base.CompletePuzzle(_spawnOrb, _playSpawnSFX);
		EnableTunnelSealWall();
	}

	public void TeleportPlayerAfterUsingBelladonnaInTunnel()
	{
		GameManager.Singleton.playerObject.GetComponent<Rigidbody>().position = tunnelEntrance_TeleportSpot.position;
		AudioManager.Singleton.UnPauseAmbientTrack();
		GameManager.Singleton.isInsideBellaDonnaTunnel = false;
	}

	private void EnableTunnelSealWall()
	{
		tunnelSealWall.SetActive(value: true);
	}

	public void OnBelladonnaWorldUsableUse()
	{
		if (!puzzleCompleted && !hasUsedWorldUsable)
		{
			hasUsedWorldUsable = true;
			CompletePuzzle_WithDelay();
			EnableTunnelSealWall();
			TeleportPlayerAfterUsingBelladonnaInTunnel();
		}
	}

	public void CompletePuzzle_WithDelay()
	{
		StartCoroutine(WaitThenCompletePuzzle());
	}

	private IEnumerator WaitThenCompletePuzzle()
	{
		yield return new WaitForSeconds(2f);
		CompletePuzzle(true, true);
	}
}
