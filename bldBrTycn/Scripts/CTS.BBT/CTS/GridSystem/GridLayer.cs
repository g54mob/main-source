using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.GridSystem
{
	[Serializable]
	public record GridLayer(List<GridController> Grids)
	{
		public List<GridController> Grids { get; private set; } = Grids;

		public void ShowLayer(bool p_value)
		{
			foreach (GridController grid in Grids)
			{
				grid.ShowGrid(p_value);
			}
		}

		public Vector3 GetClosestVerticeOnLayer(Vector3 p_worldPosition)
		{
			float num = float.PositiveInfinity;
			Vector3 result = Vector3.zero;
			foreach (GridController grid in Grids)
			{
				Vector3 closestVerticeOnGrid = grid.GetClosestVerticeOnGrid(p_worldPosition);
				float sqrMagnitude = (p_worldPosition - closestVerticeOnGrid).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = closestVerticeOnGrid;
				}
			}
			return result;
		}
	}
}
