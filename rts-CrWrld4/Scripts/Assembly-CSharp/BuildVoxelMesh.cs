using System.Collections.Generic;
using UnityEngine;

public class BuildVoxelMesh
{
	public Mesh mesh;

	public Texture2D texture;

	private VoxelData data;

	private int w;

	private int h;

	private int d;

	private bool[,,] map;

	private List<Vector3Int> scanLine;

	private List<Vector3Int> starts;

	private List<Vector3Int> ends;

	private List<Vector3> verts;

	private List<int> idxs;

	private List<Texture2D> texs;

	private int pad;

	public BuildVoxelMesh()
	{
	}

	public BuildVoxelMesh(VoxelData vox, Vector3 pivot, int pad, float scale = 0.1f)
	{
	}

	public void BuildMesh(VoxelData voxData, Vector3 pivot, int Pad, float scale = 0.1f)
	{
	}

	private void ProcessAll()
	{
	}

	private void ProcessFaces(VoxelFace face)
	{
	}

	private void ProcessTextures(VoxelFace face)
	{
	}

	private void PadTexture(Texture2D tex)
	{
	}

	private void ProcessVerts(VoxelFace face)
	{
	}

	private void MakeMap(Vector3Int ov)
	{
	}

	private void MakeMap(int ox, int oy, int oz)
	{
	}

	private void AddScan(Vector3Int o)
	{
	}
}
