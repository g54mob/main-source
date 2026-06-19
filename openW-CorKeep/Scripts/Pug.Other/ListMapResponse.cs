using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct ListMapResponse : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public int2 MapPosition;

	public ulong H1;

	public ulong H2;

	public MapTimestampHash TimestampHash => new MapTimestampHash(H1, H2);

	public ListMapResponse(int2 mapPosition, MapTimestampHash mapTimestampHash)
	{
		MapPosition = mapPosition;
		H1 = mapTimestampHash.H1;
		H2 = mapTimestampHash.H2;
	}
}
