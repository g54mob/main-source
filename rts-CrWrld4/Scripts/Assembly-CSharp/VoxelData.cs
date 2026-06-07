using UnityEngine;

public class VoxelData
{
	public Color32[] palette;

	public VoxMaterial[] materials;

	public byte[,,] voxels;

	public int height;

	public int width;

	public int depth;

	public VoxelData()
	{
	}

	public VoxelData(MagicaVoxel mv)
	{
	}

	public byte voxelByte(Vector3Int p)
	{
		return 0;
	}

	public byte voxelByte(int x, int y, int z)
	{
		return 0;
	}

	public Color32 voxelColor(Vector3Int p)
	{
		return default(Color32);
	}

	public Color32 voxelColor(int x, int y, int z)
	{
		return default(Color32);
	}

	public VoxMaterial voxelMaterial(Vector3Int p)
	{
		return null;
	}

	public VoxMaterial voxelMaterial(int x, int y, int z)
	{
		return null;
	}

	public bool validVoxel(Vector3Int p)
	{
		return false;
	}

	public bool validVoxel(int x, int y, int z)
	{
		return false;
	}

	public bool filledVoxel(int x, int y, int z)
	{
		return false;
	}

	public bool emptyVoxel(int x, int y, int z)
	{
		return false;
	}

	public int neighborCount(int x, int y, int z)
	{
		return 0;
	}

	public bool isVisible(int x, int y, int z)
	{
		return false;
	}

	public void ClearByByte(byte index, bool clearMatching)
	{
	}

	public void ClearByMat(VoxMaterialType type, bool clearMatching)
	{
	}

	public int voxelCount()
	{
		return 0;
	}
}
