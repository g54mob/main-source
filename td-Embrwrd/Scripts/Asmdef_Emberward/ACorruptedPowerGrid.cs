using System.Collections.Generic;
using UnityEngine;

public abstract class ACorruptedPowerGrid : APowerGrid
{
	private bool doBlockTetrisPlacement;

	private bool isTemporarilyDisabled;

	private static List<Vector3> directions;

	public bool IsTemporarilyDisabled => false;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnRoundEnd()
	{
	}

	public void TemporaryDisable(Obj_TetrisBlock block)
	{
	}

	private void OnTemporaryDisableBlockRemove(Obj_TetrisBlock block)
	{
	}

	private void OnTemporaryDisableBlockSingleRemove(Obj_TetrisBlock block, Vector3Int pos)
	{
	}

	private void MoveToRandomPosition()
	{
	}

	protected abstract void OnCorruptGridMoveStart(Vector3 targetPosition);

	protected abstract void OnCorruptGridMoveEnd();
}
