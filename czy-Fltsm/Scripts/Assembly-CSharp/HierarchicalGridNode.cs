using UnityEngine;

public class HierarchicalGridNode : AxisAllignedRectangle
{
	public int Size { get; private set; }

	public HierarchicalGridNode(Vector2 position, int size)
		: base(position, new Vector2(size, size))
	{
		Size = size;
	}
}
