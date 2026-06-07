using System;
using System.Collections.Generic;
using Logic.Shapes;
using UnityEngine;

namespace Data.Shapes
{
	[Serializable]
	public class ShapeDto
	{
		public const int UnoccupiedColorIndex = -1;

		public ShapeHashPair Hash;

		public int[] Voxels;

		public List<Color> Colors;

		public Vector3Int Bounds;

		public ShapeDto()
		{
		}

		public ShapeDto(ShapeHashPair hash, Voxel[] voxels, Vector3Int bounds)
		{
			Hash = hash;
			Colors = new List<Color>();
			Voxels = ConvertVoxels(voxels, Colors);
			Bounds = bounds;
		}

		public ShapeDto(ShapeData data)
		{
			Hash = data.GetShapeHash();
			Colors = new List<Color>();
			Voxels = ConvertVoxels(data.Voxels, Colors);
			Bounds = data.Bounds;
		}

		public Voxel[] GetVoxels()
		{
			Voxel[] array = new Voxel[Voxels.Length];
			for (int i = 0; i < Bounds.x; i++)
			{
				for (int j = 0; j < Bounds.y; j++)
				{
					for (int k = 0; k < Bounds.z; k++)
					{
						int num = i + j * Bounds.x + k * Bounds.x * Bounds.y;
						array[num] = GetVoxel(i, j, k);
					}
				}
			}
			return array;
		}

		public Voxel GetVoxel(int x, int y, int z)
		{
			int index = x + y * Bounds.x + z * Bounds.x * Bounds.y;
			return CreateVoxel(index, x, y, z);
		}

		private Voxel CreateVoxel(int index, int x, int y, int z)
		{
			int num = Voxels[index];
			bool flag = num != -1;
			Color color = Color.clear;
			if (flag)
			{
				color = Colors[num];
			}
			return new Voxel
			{
				Position = new Vector3Int(x, y, z),
				IsOccupied = flag,
				Color = color
			};
		}

		private int[] ConvertVoxels(Voxel[] voxels, List<Color> colors)
		{
			int[] array = new int[voxels.Length];
			for (int i = 0; i < voxels.Length; i++)
			{
				if (!voxels[i].IsOccupied)
				{
					array[i] = -1;
					continue;
				}
				int num = colors.IndexOf(voxels[i].Color);
				if (num < 0)
				{
					colors.Add(voxels[i].Color);
					array[i] = colors.Count - 1;
				}
				else
				{
					array[i] = num;
				}
			}
			return array;
		}
	}
}
