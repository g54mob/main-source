using System.Collections.Generic;
using Unity.Mathematics;

public class TilemapSetCollider : Collider
{
	private struct TilemapSet
	{
		public List<PhaserTilemap> _tilemaps;
	}

	private TilemapSet[] _tilemapSets;

	private float4[] _tilemapSetBounds;

	public TilemapSetCollider(World world, bool overlapOnly, ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback = null, ArcadePhysicsCallback processCallback = null, CallbackContext callbackContext = null)
		: base(null, overlapOnly: false, null, null, null, null, null)
	{
	}

	public void AddTilemap(int setID, PhaserTilemap tilemap)
	{
	}

	public override void update()
	{
	}
}
