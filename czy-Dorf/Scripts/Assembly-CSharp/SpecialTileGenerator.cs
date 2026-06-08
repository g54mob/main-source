using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpecialTileGenerator : ScriptableObject
{
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public TileData_003 tileData;

		internal bool _003CSetupSpecialTile_003Eb__0(SpecialTile x)
		{
			return x.specialTileId == tileData.specialTileId;
		}
	}

	[SerializeField]
	private List<SpecialTile> specialTiles;

	[SerializeField]
	private TileFactory tileFactory;

	public Tile SetupSpecialTile(TileData_003 tileData)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals3.tileData = tileData;
		SpecialTile specialTilePrefab = Enumerable.First(specialTiles, (SpecialTile x) => x.specialTileId == CS_0024_003C_003E8__locals3.tileData.specialTileId);
		return CreateSpecialTile(specialTilePrefab, CS_0024_003C_003E8__locals3.tileData.seed);
	}

	public SpecialTile CreateSpecialTile(SpecialTile specialTilePrefab, int overwriteSeed = -1)
	{
		SpecialTile specialTile = Object.Instantiate(specialTilePrefab);
		specialTile.InitializeSeed(overwriteSeed);
		tileFactory.InitializePrebuiltTile(specialTile);
		return specialTile;
	}
}
