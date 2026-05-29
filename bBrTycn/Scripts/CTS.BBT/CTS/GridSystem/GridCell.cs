using System;

namespace CTS.GridSystem
{
	[Serializable]
	public class GridCell
	{
		private GridGeneric<GridCell> _myGrid;

		private int _widthPos;

		private int _heightPos;

		public bool IsFree { get; private set; }

		public GridCell(GridGeneric<GridCell> p_grid, int p_widthPos, int p_heightPos)
		{
			_myGrid = p_grid;
			_widthPos = p_widthPos;
			_heightPos = p_heightPos;
		}

		public void AddValue(bool p_IsFree)
		{
			IsFree = p_IsFree;
		}

		public void Reset()
		{
			IsFree = true;
		}
	}
}
