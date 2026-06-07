using UnityEngine;

public class WaterSurfaceNode : GridNode
{
	private static Grid _grid;

	public override GraphBase Graph => _grid;

	public WaterSurfaceNode(Grid grid, Vector2 rootPosition)
		: base(grid, rootPosition)
	{
		_grid = grid;
	}
}
