using System.Collections;
using UnityEngine;

namespace Obi
{
	public class VoxelDistanceField
	{
		public Vector3Int[,,] distanceField;

		private MeshVoxelizer voxelizer;

		public VoxelDistanceField(MeshVoxelizer voxelizer)
		{
			this.voxelizer = voxelizer;
		}

		public float SampleUnfiltered(int x, int y, int z)
		{
			if (!voxelizer.VoxelExists(x, y, z))
			{
				return float.PositiveInfinity;
			}
			float num = Vector3.Distance(voxelizer.GetVoxelCenter(in distanceField[x, y, z]), voxelizer.GetVoxelCenter(new Vector3Int(x, y, z)));
			if (voxelizer[x, y, z] == MeshVoxelizer.Voxel.Inside)
			{
				return 0f - num;
			}
			return num;
		}

		public Vector4 SampleFiltered(float x, float y, float z)
		{
			Vector3 vector = new Vector3(x, y, z);
			Vector3 voxelCenter = voxelizer.GetVoxelCenter(new Vector3Int(0, 0, 0));
			Vector3 voxelCenter2 = voxelizer.GetVoxelCenter(new Vector3Int(voxelizer.resolution.x - 1, voxelizer.resolution.y - 1, voxelizer.resolution.z - 1));
			vector.x = Mathf.Clamp(vector.x, voxelCenter.x, voxelCenter2.x - voxelizer.voxelSize * 0.05f);
			vector.y = Mathf.Clamp(vector.y, voxelCenter.y, voxelCenter2.y - voxelizer.voxelSize * 0.05f);
			vector.z = Mathf.Clamp(vector.z, voxelCenter.z, voxelCenter2.z - voxelizer.voxelSize * 0.05f);
			Vector3Int coords = voxelizer.GetPointVoxel(vector - Vector3.one * voxelizer.voxelSize * 0.5f) - voxelizer.Origin;
			Vector3 voxelCenter3 = voxelizer.GetVoxelCenter(in coords);
			Vector3 vector2 = (vector - voxelCenter3) / voxelizer.voxelSize;
			float a = SampleUnfiltered(coords.x, coords.y, coords.z);
			float num = SampleUnfiltered(coords.x, coords.y, coords.z + 1);
			float num2 = SampleUnfiltered(coords.x + 1, coords.y, coords.z);
			float b = SampleUnfiltered(coords.x + 1, coords.y, coords.z + 1);
			float a2 = SampleUnfiltered(coords.x, coords.y + 1, coords.z);
			float num3 = SampleUnfiltered(coords.x, coords.y + 1, coords.z + 1);
			float num4 = SampleUnfiltered(coords.x + 1, coords.y + 1, coords.z);
			float b2 = SampleUnfiltered(coords.x + 1, coords.y + 1, coords.z + 1);
			float a3 = Mathf.Lerp(a, num2, vector2.x);
			float num5 = Mathf.Lerp(num, b, vector2.x);
			float num6 = Mathf.Lerp(a2, num4, vector2.x);
			float b3 = Mathf.Lerp(num3, b2, vector2.x);
			float num7 = Mathf.Lerp(a3, num5, vector2.z);
			float num8 = Mathf.Lerp(num6, b3, vector2.z);
			float num9 = Mathf.Lerp(Mathf.Lerp(num2, b, vector2.z), Mathf.Lerp(num4, b2, vector2.z), vector2.y);
			float num10 = Mathf.Lerp(Mathf.Lerp(a, num, vector2.z), Mathf.Lerp(a2, num3, vector2.z), vector2.y);
			float num11 = Mathf.Lerp(num5, b3, vector2.y);
			return new Vector4(z: (num11 - Mathf.Lerp(a3, num6, vector2.y)) / voxelizer.voxelSize, x: (num9 - num10) / voxelizer.voxelSize, y: (num8 - num7) / voxelizer.voxelSize, w: Mathf.Lerp(num7, num8, vector2.y));
		}

		public IEnumerator JumpFlood()
		{
			distanceField = new Vector3Int[voxelizer.resolution.x, voxelizer.resolution.y, voxelizer.resolution.z];
			Vector3Int[,,] auxBuffer = new Vector3Int[voxelizer.resolution.x, voxelizer.resolution.y, voxelizer.resolution.z];
			for (int i = 0; i < distanceField.GetLength(0); i++)
			{
				for (int j = 0; j < distanceField.GetLength(1); j++)
				{
					for (int k = 0; k < distanceField.GetLength(2); k++)
					{
						if (voxelizer[i, j, k] == MeshVoxelizer.Voxel.Boundary)
						{
							distanceField[i, j, k] = new Vector3Int(i, j, k);
						}
						else
						{
							distanceField[i, j, k] = new Vector3Int(-1, -1, -1);
						}
					}
				}
			}
			int size = Mathf.Max(distanceField.GetLength(0), distanceField.GetLength(1), distanceField.GetLength(2));
			int step = (int)((float)size / 2f);
			yield return new CoroutineJob.ProgressInfo("Generating voxel distance field...", 0f);
			float numPasses = (int)Mathf.Log(size, 2f);
			int i2 = 0;
			while (step >= 1)
			{
				JumpFloodPass(step, distanceField, auxBuffer);
				step /= 2;
				Vector3Int[,,] array = distanceField;
				distanceField = auxBuffer;
				auxBuffer = array;
				int num = i2 + 1;
				i2 = num;
				yield return new CoroutineJob.ProgressInfo("Generating voxel distance field...", (float)num / numPasses);
			}
		}

		private void JumpFloodPass(int stride, Vector3Int[,,] input, Vector3Int[,,] output)
		{
			for (int i = 0; i < input.GetLength(0); i++)
			{
				for (int j = 0; j < input.GetLength(1); j++)
				{
					for (int k = 0; k < input.GetLength(2); k++)
					{
						Vector3Int vector3Int = new Vector3Int(i, j, k);
						Vector3Int vector3Int2 = (output[i, j, k] = input[i, j, k]);
						if (vector3Int2.x == i && vector3Int2.y == j && vector3Int2.z == k)
						{
							continue;
						}
						float num = float.MaxValue;
						if (vector3Int2.x >= 0)
						{
							num = (vector3Int2 - vector3Int).sqrMagnitude;
						}
						for (int l = -1; l <= 1; l++)
						{
							for (int m = -1; m <= 1; m++)
							{
								for (int n = -1; n <= 1; n++)
								{
									int num2 = i + l * stride;
									int num3 = j + m * stride;
									int num4 = k + n * stride;
									if (!voxelizer.VoxelExists(num2, num3, num4))
									{
										continue;
									}
									Vector3Int vector3Int3 = input[num2, num3, num4];
									if (vector3Int3.x >= 0)
									{
										float num5 = (vector3Int3 - vector3Int).sqrMagnitude;
										if (num5 < num)
										{
											output[i, j, k] = vector3Int3;
											num = num5;
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
