using Pug.UnityExtensions;
using PugTilemap;
using Unity.Mathematics;

public class BrokenEventTerminal : EntityMonoBehaviour
{
	protected override void OnShow()
	{
		int2 int5 = base.WorldPosition.RoundToInt2();
		Manager.multiMap.SetHiddenTile(int5 + new int2(-1, -1), 4, TileType.circuitPlate, 0);
		Manager.multiMap.SetHiddenTile(int5 + new int2(1, -1), 4, TileType.circuitPlate, 0);
		Manager.multiMap.SetHiddenTile(int5 + new int2(1, 1), 4, TileType.circuitPlate, 0);
		Manager.multiMap.SetHiddenTile(int5 + new int2(-1, 1), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		int2 int5 = base.WorldPosition.RoundToInt2();
		Manager.multiMap.ClearHiddenTileOfType(int5, TileType.circuitPlate);
		Manager.multiMap.ClearHiddenTileOfType(int5 + new int2(-1, -1), TileType.circuitPlate);
		Manager.multiMap.ClearHiddenTileOfType(int5 + new int2(1, -1), TileType.circuitPlate);
		Manager.multiMap.ClearHiddenTileOfType(int5 + new int2(1, 1), TileType.circuitPlate);
		Manager.multiMap.ClearHiddenTileOfType(int5 + new int2(-1, 1), TileType.circuitPlate);
		base.OnHide();
	}
}
