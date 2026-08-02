using UnityEngine;

[CreateAssetMenu(fileName = "ChunkData", menuName = "TrainSurvival/Chunk Data", order = 1)]
public class ChunkData : ScriptableObject
{
	public float chunkScaleX;

	public float chunkScaleZ;

	public int xChunkCount;

	public int zChunkCount;
}
