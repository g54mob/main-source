using System.Collections.Generic;

public class ComplexSlicerSplit
{
	public enum Type
	{
		Normal = 0,
		SingleVertexCollision = 1
	}

	public List<Vector2D> points;

	public Type type;

	public static List<ComplexSlicerSplit> GetSplitSlices(Polygon2D polygon, List<Vector2D> slice)
	{
		return null;
	}
}
