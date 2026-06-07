public class MineCellData
{
	public enum CellState
	{
		Hidden = 0,
		Revealed = 1,
		Flagged = 2
	}

	public bool IsMine { get; private set; }

	public int AdjacentMineCount { get; private set; }

	public CellState State { get; private set; }

	public MineCellData(bool isMine)
	{
		IsMine = isMine;
		State = CellState.Hidden;
	}

	public void SetMine(bool isMine)
	{
		IsMine = isMine;
	}

	public void SetAdjacentMineCount(int count)
	{
		AdjacentMineCount = count;
	}

	public void Reveal(bool force = false)
	{
		if (force || State == CellState.Hidden)
		{
			State = CellState.Revealed;
		}
	}

	public void ToggleFlag()
	{
		if (State != CellState.Revealed)
		{
			State = ((State != CellState.Flagged) ? CellState.Flagged : CellState.Hidden);
		}
	}
}
