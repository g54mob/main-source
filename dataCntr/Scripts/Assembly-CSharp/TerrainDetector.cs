using UnityEngine;

public class TerrainDetector
{
	private TerrainData terrainData;

	private int alphamapWidth;

	private int alphamapHeight;

	private float[,,] splatmapData;

	private int numTextures;

	public Terrain currentTerrain;

	private Vector3 ConvertToSplatMapCoordinate(Vector3 worldPosition)
	{
		return default(Vector3);
	}

	public int GetActiveTerrainTextureIdx(Vector3 position)
	{
		return 0;
	}

	public void SetCurrentTerrain(Terrain _terrain)
	{
	}
}
