using UnityEngine;

namespace Assets.Scripts.MapGeneration.ProceduralTiles;

public class MapParameters : ScriptableObject
{
	public float volatility = 1f;

	public float centerHeightTarget;

	public float slopeStrength;

	public float yOffset;

	public float flatMapBias;

	public int size = 15;

	public int scale = 20;

	public int tileWidth = 2;

	public int tileHeight = 1;

	public EBiasStrategy biasStrategy;

	public EHeightGenerationStrategy heightGenerationStrategy;

	public int scaledTileWidth = 2;

	public int scaledTileHeight = 1;

	public StageData testStageData;

	private void OnValidate()
	{
		int num = tileHeight * scale;
		scaledTileHeight = num;
		int num2 = tileWidth * scale;
		scaledTileWidth = num2;
	}
}
