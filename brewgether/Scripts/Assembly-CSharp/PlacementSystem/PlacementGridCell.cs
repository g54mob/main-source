using System;
using UnityEngine;

namespace PlacementSystem
{
	[Serializable]
	[Obsolete("PlacementGridCell is deprecated. The placement system now uses free placement without grids.")]
	public class PlacementGridCell
	{
		public int row;

		public int column;

		public Vector3 localPosition;

		public bool isOccupied;

		public ulong placedObjectNetId;

		public int anchorCellIndex;

		public PlacementGridCell(int row, int column, Vector3 localPosition)
		{
		}

		public void Occupy(ulong objectNetId, int anchorIndex)
		{
		}

		public void Clear()
		{
		}
	}
}
