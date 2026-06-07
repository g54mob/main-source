using System.IO;
using UnityEngine;

public class MagicaVoxel
{
	public Color32[] palette;

	public VoxMaterial[] materials;

	public byte[,,] voxels;

	public MagicaVoxel()
	{
	}

	public MagicaVoxel(string fileName)
	{
	}

	public MagicaVoxel(VoxelData data)
	{
	}

	private void InitVoxels()
	{
	}

	private void LoadData(VoxelData data)
	{
	}

	private void LoadFile(string fileName)
	{
	}

	private void ProcessChunk(string type, byte[] data)
	{
	}

	private string readDictString(BinaryReader br)
	{
		return null;
	}
}
