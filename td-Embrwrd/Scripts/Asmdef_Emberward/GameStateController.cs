using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : Singleton<GameStateController>
{
	protected AGameState state;

	protected Dictionary<eGameState, Type> dic_GameState;

	private bool isInBattle;

	private bool isInCinemetic;

	[SerializeField]
	[Header("遊戲是否開始了 (進場結束，玩家開始可以操控)")]
	private bool isGameStarted;

	private bool isLevelFinished;

	private int currentRound;

	private int totalRound;

	[SerializeField]
	[Header("遊戲是否被中斷 (玩家選擇離開)")]
	private bool isGameInterrupted;

	private bool isOpeningChest;

	public eGameState State => default(eGameState);

	public bool IsInBattle => false;

	public bool IsInCinemetic => false;

	public bool IsGameStarted => false;

	public bool IsLevelFinished => false;

	public int CurrentRound => 0;

	public int TotalRound => 0;

	public bool IsGameInterrupted => false;

	public bool IsOpeningChest => false;

	protected override void Awake()
	{
	}

	private void OnRequestSetGameInterrupted()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnRequestSetIsOpeningChest(bool isOpening)
	{
	}

	private void OnRoundStart(int currentRound, int totalRound)
	{
	}

	private void OnSetIsInCinematic(bool isInCinemetic)
	{
	}

	private void OnPlayerVictoryOrDefeat()
	{
	}

	private void OnShowCommonIngameUI()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnRequestChangeGameState(eGameState targetState)
	{
	}

	private void OnRequestChangeBattleState(bool isInBattle)
	{
	}

	public void SwitchState(eGameState targetState)
	{
	}

	public eGameState GetCurrentState()
	{
		return default(eGameState);
	}

	public bool IsCurrentState(eGameState targetState)
	{
		return false;
	}

	public bool IsFinalRound()
	{
		return false;
	}
}
