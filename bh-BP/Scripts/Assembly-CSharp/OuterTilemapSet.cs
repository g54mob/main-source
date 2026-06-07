using UnityEngine;

public class OuterTilemapSet : MonoBehaviour
{
	public Material EnviroMat;

	public bool ScaleGroundWithLevel;

	public Material TileableGroundMat;

	public Vector3 DefaultGroundScale;

	public Material[] ExtraWallMats;

	public Mesh GroundMesh;

	public Mesh[] LeftWallMeshes;

	public Mesh[] RightWallMeshes;

	public ChunkSet EarlyChunks;

	public ChunkSet MidChunks;

	public ChunkSet EndChunks;

	public Vector3 DefaultScale;

	public float GroundX;

	public float LeftWallX;

	public float RightWallX;

	public Vector3 DefaultWallRot;

	public float TileLength;

	public Transform WrapperRightParallax;

	public Transform WrapperLeftParallax;

	public bool HasChunkProgression()
	{
		return false;
	}

	public void PickWalls(float scrollPct, out ChunkSet leftSet, out ChunkSet rightSet, out int leftIdx, out int rightIdx)
	{
		leftSet = null;
		rightSet = null;
		leftIdx = default(int);
		rightIdx = default(int);
	}
}
