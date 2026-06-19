using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;

public class Seed : EntityMonoBehaviour
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		UpdateSeedSprite();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateSeedSprite();
	}

	private void UpdateSeedSprite()
	{
		int variant = (Manager.multiMap.GetTileLayerLookup().HasTile(base.WorldPosition.RoundToInt2(), TileType.wateredGround) ? SpriteAsset.StringToHash("watered") : 0);
		spriteObjects[0].SetVariant(variant);
		spriteObjects[1].SetVariant(variant);
	}
}
