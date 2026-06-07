using System.Linq;
using UnityEngine;

public class MultiterrainTool : MonoBehaviour
{
	public Terrain master;

	public Terrain[] others;

	public int tilesPerAxis = 8;

	public string macroTilesPrefix = "Assets/path/to/tile_";

	[HideInInspector]
	public bool syncTerrainSettings = true;

	[HideInInspector]
	public bool syncScaleInLightmap = true;

	public Terrain[] allTerrains => new Terrain[1] { master }.Union(others).ToArray();

	public void CopySettings()
	{
	}

	public static int GetFileNumber(int terrainNum, int tilesPerAxis)
	{
		int num = terrainNum / tilesPerAxis;
		int num2 = terrainNum % tilesPerAxis;
		int num3 = num;
		return (tilesPerAxis - num2 - 1) * tilesPerAxis + num3;
	}

	public static string GetMacroTileForTerrain(Terrain terrain, string tileFilenameFormat, int tilesPerAxis)
	{
		string text = terrain.gameObject.name;
		int terrainNum = int.Parse(text.Substring(text.LastIndexOf("_") + 1));
		return string.Format(tileFilenameFormat, GetFileNumber(terrainNum, tilesPerAxis));
	}
}
