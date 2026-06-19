using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct DamageObjectStateCD : IComponentData, IQueryTypeParameter
{
	public enum InternalState
	{
		Init = 0,
		Anticipation = 1,
		Attacking = 2,
		Ending = 3
	}

	[GhostField]
	public int2 position;

	public TickTimer timer;

	public InternalState internalState;

	public Entity targetEntity;

	public TileCD targetTile;
}
