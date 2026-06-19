using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public struct PugFloraGrowerCD : IComponentData, IQueryTypeParameter
{
	public int2 position;

	public int timer;

	public Entity entity;

	public FixedList64Bytes<Tileset> tilesets;
}
