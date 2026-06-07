using System;
using System.Collections.Generic;

[Serializable]
public class LevelWave
{
	public int CurTurn;

	public int Length;

	public EnemyPlacementType PlacementType;

	public List<List<GridPieceType>> Pieces;

	public List<List<EnemyPlacement>> EnemyPlacements;

	public int MinStackSize;

	public int MaxStackSize;

	public int NumStacks;

	public float HealthMult;

	public bool OverlapWithPrevWaves;

	public float SpawnTurnLength;

	public List<GridPieceType> this[int i]
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public LevelWave(int length)
	{
	}

	public void SetStackSize(int min, int max)
	{
	}

	public void SetStackSize(int sz)
	{
	}

	public void SetLength(int l)
	{
	}

	public void FillPieces(GridPieceType t, int amt)
	{
	}

	public void AddPieces(int row, GridPieceType t, int amt)
	{
	}

	public void AddBonusPieces()
	{
	}

	public void Clear()
	{
	}
}
