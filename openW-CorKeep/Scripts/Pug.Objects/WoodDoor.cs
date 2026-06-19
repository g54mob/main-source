using Pug.UnityExtensions;
using PugTilemap;

public class WoodDoor : Gate
{
	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 34, TileType.thinWall, 0);
		for (int i = 41; i < 52; i++)
		{
			Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), i, TileType.thinWall, 0);
		}
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.thinWall);
		base.OnHide();
	}
}
