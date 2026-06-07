using System;
using UnityEngine;

public class LevelMgr : MonoBehaviour
{
	public static LevelMgr I;

	public static readonly LevelType[] kLevelOrder;

	public static readonly int[] kLevelIdx;

	public LevelType CurLevel;

	public LevelInfo CurLevelInfo;

	public int CurDifficulty;

	public int CurNGPlusLvl;

	public const int kEndlessFuserSpacing = 30;

	public static readonly float[] kEndGameTimes;

	public static readonly float[] kTurnLenMult;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void SetLevel(LevelType t)
	{
	}

	public void GetPiecesToSpawn(LevelWave outWave, int curTurn, System.Random rnd)
	{
	}

	private void FillGraveyard(LevelWave outWave, int curTurn, System.Random rnd)
	{
	}

	private void FillSnowy(LevelWave outWave, int curTurn, System.Random rnd)
	{
	}

	private void FillDesert(LevelWave outWave, int curTurn, System.Random rnd)
	{
	}

	private void FillSavanna(LevelWave outWave, int curTurn, System.Random rnd)
	{
	}

	private void FillShroom(LevelWave outWave, int curTurn, System.Random rnd)
	{
	}

	private void FillHell(LevelWave outWave, int curTurn, System.Random rnd)
	{
	}

	private void FillHeaven(LevelWave outWave, int curTurn, System.Random rnd)
	{
	}

	private void FillMoon(LevelWave outWave, int curTurn, System.Random rnd)
	{
	}

	private GridPieceType PickRandomShield(System.Random rnd)
	{
		return default(GridPieceType);
	}

	public bool IsLastInTurn(GridPieceInst p)
	{
		return false;
	}

	public float GetEndGameTime()
	{
		return 0f;
	}

	public int GetFinalTurn()
	{
		return 0;
	}

	public bool IsBossTurn(int curTurn)
	{
		return false;
	}

	public bool DidSkipBossTurn(int curTurn, int numBossTurnsElapsed)
	{
		return false;
	}

	public int GetNextBossTurn()
	{
		return 0;
	}

	public int GetPrevBossTurn()
	{
		return 0;
	}

	public bool ShouldSpawnFuser(int curTurn)
	{
		return false;
	}

	public bool IsEndlessBossTurn(int curTurn)
	{
		return false;
	}

	public bool ShouldSpawnExtraGold(int curTurn)
	{
		return false;
	}

	public int GetGoldBonusPct(int difficulty)
	{
		return 0;
	}

	public int GetDefaultMaxHP(int turn)
	{
		return 0;
	}

	public int GetDefaultXP(int turn, float healthScale)
	{
		return 0;
	}

	public int GetDefaultGoldValue(int turn, float healthScale, System.Random rnd)
	{
		return 0;
	}

	public float GetTurnLen()
	{
		return 0f;
	}

	public bool IsLateGame()
	{
		return false;
	}

	public void PlayWallBounceSFX(Vector3 pos)
	{
	}

	public float GetEnemyDamageMultiplier()
	{
		return 0f;
	}

	public float GetEnemyDamageMultiplier(int diff)
	{
		return 0f;
	}

	public int ModifyEnemyDamage(int dmg)
	{
		return 0;
	}
}
