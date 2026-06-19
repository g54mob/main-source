using System;
using Unity.Entities;
using Unity.Mathematics;

public struct TileDamageBuffer : IBufferElementData, IComparable<TileDamageBuffer>
{
	public int2 position;

	public int damage;

	public bool skipWallAndRootsLootDropOnDestroy;

	public Entity causedByEntity;

	public bool canHitGround;

	public bool canHitLowColliders;

	public bool dontHitWalkableTiles;

	public bool dontHitBridges;

	public bool dontHitGroundSlime;

	public bool dontPlayDamageTileEffect;

	public bool bypassDamageReduction;

	public bool bypassMaxDamagePerHit;

	public bool pullAnyLootToPlayer;

	public bool damagedByExplosion;

	public int CompareTo(TileDamageBuffer other)
	{
		int num = position.y.CompareTo(other.position.y);
		if (num == 0)
		{
			return position.x.CompareTo(other.position.x);
		}
		return num;
	}
}
