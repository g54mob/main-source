using System.Collections.Generic;

public class Perk_SnowMountainFreezeEffect : APerkBase
{
	private class TetrisPlaceRoundRecord
	{
		public Obj_TetrisBlock tetrisBlock;

		public int roundCount;

		public TetrisPlaceRoundRecord(Obj_TetrisBlock tetrisBlock, int roundCount = 0)
		{
		}
	}

	private List<TetrisPlaceRoundRecord> list_TetrisBlockRecords;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	private void OnRoundStart(int round, int totalRound)
	{
	}
}
