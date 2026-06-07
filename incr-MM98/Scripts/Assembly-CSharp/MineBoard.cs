using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MineBoard
{
	public enum State
	{
		Playing = 0,
		Won = 1,
		Lost = 2
	}

	private readonly MineCellData[,] _cells;

	private readonly List<Vector2Int> _revealedCellsCache = new List<Vector2Int>();

	private bool _minesGenerated;

	private int _totalSafeCells;

	private int _revealedCells;

	private int _flaggedCells;

	public Vector2Int Size { get; }

	public int MineCount { get; }

	public State CurrentState { get; private set; }

	public int RemainingMines => MineCount - _flaggedCells;

	public MineBoard(Vector2Int size, int mineCount)
	{
		Size = size;
		MineCount = mineCount;
		CurrentState = State.Playing;
		_cells = new MineCellData[Size.x, Size.y];
		GenerateBoard();
	}

	public MineCellData GetCell(Vector2Int position)
	{
		return GetCell(position.x, position.y);
	}

	public MineCellData GetCell(int x, int y)
	{
		if (!Size.IsWithinBounds(x, y))
		{
			return null;
		}
		return _cells[x, y];
	}

	public void ToggleFlag(Vector2Int position)
	{
		if (Size.IsWithinBounds(position))
		{
			MineCellData cell = GetCell(position);
			bool flag = cell.State == MineCellData.CellState.Flagged;
			cell.ToggleFlag();
			bool flag2 = cell.State == MineCellData.CellState.Flagged;
			if (flag && !flag2)
			{
				_flaggedCells--;
			}
			else if (!flag && flag2)
			{
				_flaggedCells++;
			}
		}
	}

	public List<Vector2Int> RevealCell(Vector2Int start)
	{
		_revealedCellsCache.Clear();
		if (CurrentState != State.Playing)
		{
			return _revealedCellsCache;
		}
		if (!Size.IsWithinBounds(start))
		{
			return _revealedCellsCache;
		}
		if (!_minesGenerated)
		{
			GenerateMines(start);
		}
		MineCellData cell = GetCell(start);
		if (cell.IsMine)
		{
			cell.Reveal();
			_revealedCellsCache.Add(start);
			CurrentState = State.Lost;
			return _revealedCellsCache;
		}
		Queue<Vector2Int> queue = new Queue<Vector2Int>();
		queue.Enqueue(new Vector2Int(start.x, start.y));
		while (queue.Count > 0)
		{
			Vector2Int vector2Int = queue.Dequeue();
			MineCellData mineCellData = _cells[vector2Int.x, vector2Int.y];
			if (mineCellData.State != MineCellData.CellState.Hidden)
			{
				continue;
			}
			mineCellData.Reveal();
			_revealedCellsCache.Add(vector2Int);
			if (!mineCellData.IsMine)
			{
				_revealedCells++;
			}
			if (mineCellData.AdjacentMineCount > 0 || mineCellData.IsMine)
			{
				continue;
			}
			foreach (Vector2Int item in vector2Int.Neighbours(Size))
			{
				queue.Enqueue(item);
			}
		}
		if (_revealedCells >= _totalSafeCells)
		{
			CurrentState = State.Won;
		}
		return _revealedCellsCache;
	}

	private void GenerateBoard()
	{
		foreach (Vector2Int item in Size.Grid())
		{
			_cells[item.x, item.y] = new MineCellData(isMine: false);
		}
		_totalSafeCells = Size.x * Size.y - MineCount;
		_revealedCells = 0;
		_flaggedCells = 0;
		_minesGenerated = false;
	}

	private void GenerateMines(Vector2Int firstClick)
	{
		HashSet<Vector2Int> hashSet = new HashSet<Vector2Int> { firstClick };
		foreach (Vector2Int item2 in firstClick.Neighbours(Size))
		{
			hashSet.Add(item2);
		}
		int num = Mathf.Min(MineCount, Size.x * Size.y - hashSet.Count);
		int num2 = 0;
		while (num2 < num)
		{
			Vector2Int item = Size.Random();
			if (!hashSet.Contains(item) && !_cells[item.x, item.y].IsMine)
			{
				_cells[item.x, item.y].SetMine(isMine: true);
				num2++;
			}
		}
		foreach (Vector2Int item3 in Size.Grid())
		{
			if (!_cells[item3.x, item3.y].IsMine)
			{
				_cells[item3.x, item3.y].SetAdjacentMineCount(CountAdjacentMines(item3));
			}
		}
		_minesGenerated = true;
		EventHub.Scene.Publish(default(MinesweeperTimerStarted));
	}

	private int CountAdjacentMines(Vector2Int cell)
	{
		return (from n in cell.Neighbours(Size)
			select _cells[n.x, n.y]).Count((MineCellData c) => c.IsMine);
	}
}
