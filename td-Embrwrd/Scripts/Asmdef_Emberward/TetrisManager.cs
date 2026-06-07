using System.Collections.Generic;
using UnityEngine;

public class TetrisManager : Singleton<TetrisManager>
{
	[SerializeField]
	private List<Obj_TetrisBlock> list_Tetris;

	[SerializeField]
	private Obj_TetrisBlock lastPlacedTetris;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	public void RegisterTetris(Obj_TetrisBlock tetris)
	{
	}

	public void UnregisterTetris(Obj_TetrisBlock tetris)
	{
	}

	public List<Obj_TetrisBlock> GetAllTetrisOnField()
	{
		return null;
	}

	public int GetTetrisOnFieldCount()
	{
		return 0;
	}

	public void LockLastPlacedTetris(bool forceUpdateTerritory)
	{
	}

	private void Update()
	{
	}
}
