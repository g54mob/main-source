using Unity.Entities;
using Unity.Mathematics;

public struct ProceduralSpawnArea : IComponentData, IQueryTypeParameter
{
	public int2 Position;

	public int2 Size;

	public int2 Center => Position + Size / 2;

	public int CenterX => Position.x + Size.x / 2;

	public int CenterY => Position.y + Size.y / 2;

	public int2 Min => Position;

	public int MinX => Position.x;

	public int MinY => Position.y;

	public int2 Max => Position + Size - 1;

	public int MaxX => Position.x + Size.x - 1;

	public int MaxY => Position.y + Size.y - 1;

	public static bool ContainsPoint(ProceduralSpawnArea area, int2 point)
	{
		if (point.x >= area.MinX && point.x <= area.MaxX && point.y >= area.MinY)
		{
			return point.y <= area.MaxY;
		}
		return false;
	}
}
