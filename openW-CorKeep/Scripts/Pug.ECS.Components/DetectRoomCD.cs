using Unity.Entities;
using Unity.Mathematics;

public struct DetectRoomCD : IComponentData, IQueryTypeParameter
{
	public bool roomDetected;

	public int roomSize;

	public int2 minPosition;

	public int2 maxPosition;

	public float updateTimer;
}
