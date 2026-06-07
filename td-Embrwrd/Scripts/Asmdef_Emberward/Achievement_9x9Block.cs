using System.Collections.Generic;
using UnityEngine;

public class Achievement_9x9Block : AAchievementDetector
{
	private bool isAchievementSuccess;

	protected override void IngameDetectStartProc()
	{
	}

	protected override void IngameDetectStopProc()
	{
	}

	private void OnPlayerVictory()
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	private bool IsFilledInPos(Vector3Int pos)
	{
		return false;
	}

	private bool CheckFull13x13(List<Vector3Int> startPositions)
	{
		return false;
	}

	protected override void InstantCheckProc()
	{
	}
}
