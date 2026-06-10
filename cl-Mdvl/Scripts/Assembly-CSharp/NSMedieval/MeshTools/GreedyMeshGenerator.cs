using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Extensions;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.MeshTools
{
	public class GreedyMeshGenerator : Singleton<GreedyMeshGenerator>
	{
		private GreedyMeshGenerator()
		{
		}

		public Mesh GetMesh2D(Vec3Int start, Vec3Int end, Vec3Int[,] positions, Vec3Int offset)
		{
			Vec3Int vec3Int = new Vec3Int(Mathf.Abs(start.x - end.x) + 1, 1, Mathf.Abs(start.z - end.z) + 1);
			return CalculateMeshHorizontal2D(GetMeshData(positions, vec3Int), vec3Int, offset);
		}

		public Mesh GetMesh2D(Vec3Int start, Vec3Int end, List<Vec3Int> positions, Vec3Int offset)
		{
			Vec3Int vec3Int = new Vec3Int(Mathf.Abs(start.x - end.x) + 1, 1, Mathf.Abs(start.z - end.z) + 1);
			Vec3Int[,] array = new Vec3Int[vec3Int.x, vec3Int.z];
			for (int i = 0; i < vec3Int.x; i++)
			{
				for (int j = 0; j < vec3Int.z; j++)
				{
					array[i, j] = Vec3Int.zero;
				}
			}
			Vec3Int vec3Int2 = start.Min(end);
			foreach (Vec3Int position in positions)
			{
				array[position.x - vec3Int2.x, position.z - vec3Int2.z] = position;
			}
			return CalculateMeshHorizontal2D(GetMeshData(array, vec3Int), vec3Int, offset);
		}

		public Tuple<Vec3Int[,], Vec3Int> GetPositionsAndOffset<T>(Vec3Int start, Vec3Int end, int maxSize, bool adjustPosition, Action<Vec3Int[,], int, int, int, int, Vec3Int, List<Vec3Int>, WorldObject> populateArray, List<Vec3Int> validPositions = null, T worldObject = null) where T : WorldObject
		{
			Vec3Int[,] array = new Vec3Int[maxSize, maxSize];
			Vec3Int item = Vec3Int.zero;
			if (start.x <= end.x)
			{
				int arg = ((Mathf.Abs(start.x - end.x) <= maxSize) ? end.x : (start.x + maxSize));
				array = new Vec3Int[Mathf.Abs(start.x - end.x) + 1, Mathf.Abs(start.z - end.z) + 1];
				if (start.z <= end.z)
				{
					int arg2 = ((Mathf.Abs(start.z - end.z) < maxSize) ? end.z : (start.z + maxSize));
					populateArray?.Invoke(array, start.x, end.x, start.z, arg2, start, validPositions, worldObject);
				}
				if (start.z > end.z)
				{
					int arg3 = ((Mathf.Abs(start.z - end.z) < maxSize) ? end.z : (start.z - maxSize));
					populateArray?.Invoke(array, start.x, arg, arg3, start.z, start, validPositions, worldObject);
					if (adjustPosition)
					{
						array = array.VerticalFlip();
						array = array.Rotate180();
					}
					item = new Vec3Int(0, 0, -array.GetLength(1) + 1);
				}
			}
			if (start.x > end.x)
			{
				int arg4 = ((Mathf.Abs(start.x - end.x) <= maxSize) ? end.x : (start.x - maxSize));
				array = new Vec3Int[Mathf.Abs(start.x - end.x) + 1, Mathf.Abs(start.z - end.z) + 1];
				if (start.z <= end.z)
				{
					int arg5 = ((Mathf.Abs(start.z - end.z) < maxSize) ? end.z : (start.z + maxSize));
					populateArray?.Invoke(array, arg4, start.x, start.z, arg5, start, validPositions, worldObject);
					if (adjustPosition)
					{
						array = array.VerticalFlip();
					}
					item = new Vec3Int(-array.GetLength(0) + 1, 0, 0);
				}
				if (start.z > end.z)
				{
					int arg6 = ((Mathf.Abs(start.z - end.z) < maxSize) ? end.z : (start.z - maxSize));
					populateArray?.Invoke(array, arg4, start.x, arg6, start.z, start, validPositions, worldObject);
					if (adjustPosition)
					{
						array = array.Rotate180();
					}
					item = new Vec3Int(-array.GetLength(0) + 1, 0, -array.GetLength(1) + 1);
				}
			}
			return new Tuple<Vec3Int[,], Vec3Int>(array, item);
		}

		public Mesh CalculateMeshHorizontal2D(Vec3Int start, Vec3Int end, Vec3Int offset)
		{
			int x = Mathf.Abs(start.x - end.x);
			int z = Mathf.Abs(start.z - end.z);
			byte[,,] chunkData = InitializeFullArray(start, end);
			return GreedyMeshing(chunkData, new Vec3Int(x, 1, z), 0, (Vector3)offset);
		}

		public Mesh CalculateMeshHorizontal2D(byte[,,] meshData, Vec3Int maxSize, Vec3Int offset)
		{
			return GreedyMeshing(meshData, maxSize, 0, (Vector3)offset);
		}

		public Mesh DrawQuad()
		{
			Mesh mesh = new Mesh();
			Vector3[] vertices = new Vector3[4]
			{
				new Vector3(-0.5f, 0f, -0.5f),
				new Vector3(0.5f, 0f, -0.5f),
				new Vector3(-0.5f, 0f, 0.5f),
				new Vector3(0.5f, 0f, 0.5f)
			};
			mesh.vertices = vertices;
			int[] triangles = new int[6] { 2, 1, 0, 1, 2, 3 };
			mesh.triangles = triangles;
			Vector3[] normals = new Vector3[4]
			{
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward
			};
			mesh.normals = normals;
			Vector2[] uv = new Vector2[4]
			{
				new Vector2(0f, 0f),
				new Vector2(1f, 0f),
				new Vector2(0f, 1f),
				new Vector2(1f, 1f)
			};
			mesh.uv = uv;
			return mesh;
		}

		public Mesh DrawQuad(Vec3Int startPoint, Vec3Int endPoint)
		{
			Mesh mesh = new Mesh();
			float num = Mathf.Abs(startPoint.x - endPoint.x);
			float num2 = Mathf.Abs(startPoint.z - endPoint.z);
			int[] triangles;
			Vector3[] vertices;
			if (startPoint.x < endPoint.x)
			{
				if (startPoint.z < endPoint.z)
				{
					triangles = new int[6] { 2, 1, 0, 1, 2, 3 };
					vertices = new Vector3[4]
					{
						new Vector3(0f, 0f, 0f),
						new Vector3(num + 1f, 0f, 0f),
						new Vector3(0f, 0f, num2 + 1f),
						new Vector3(num + 1f, 0f, num2 + 1f)
					};
				}
				else
				{
					num2 *= -1f;
					triangles = new int[6] { 0, 1, 2, 1, 3, 2 };
					vertices = new Vector3[4]
					{
						new Vector3(0f, 0f, 1f),
						new Vector3(num + 1f, 0f, 1f),
						new Vector3(0f, 0f, num2),
						new Vector3(num + 1f, 0f, num2)
					};
				}
			}
			else if (startPoint.z < endPoint.z)
			{
				num *= -1f;
				triangles = new int[6] { 0, 1, 2, 1, 3, 2 };
				vertices = new Vector3[4]
				{
					new Vector3(1f, 0f, 0f),
					new Vector3(num, 0f, 0f),
					new Vector3(1f, 0f, num2 + 1f),
					new Vector3(num, 0f, num2 + 1f)
				};
			}
			else
			{
				num *= -1f;
				num2 *= -1f;
				triangles = new int[6] { 2, 1, 0, 1, 2, 3 };
				vertices = new Vector3[4]
				{
					new Vector3(1f, 0f, 1f),
					new Vector3(num, 0f, 1f),
					new Vector3(1f, 0f, num2),
					new Vector3(num, 0f, num2)
				};
			}
			mesh.vertices = vertices;
			mesh.triangles = triangles;
			Vector3[] normals = new Vector3[4]
			{
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward
			};
			mesh.normals = normals;
			Vector2[] uv = new Vector2[4]
			{
				new Vector2(0f, 0f),
				new Vector2(1f, 0f),
				new Vector2(0f, 1f),
				new Vector2(1f, 1f)
			};
			mesh.uv = uv;
			return mesh;
		}

		private byte[,,] InitializeFullArray(Vec3Int start, Vec3Int end)
		{
			int num = Mathf.Abs(start.x - end.x);
			int num2 = Mathf.Abs(start.z - end.z);
			byte[,,] array = new byte[num, 1, num2];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					array[i, 0, j] = 1;
				}
			}
			return array;
		}

		private byte[,,] GetMeshData(Vec3Int[,] input, Vec3Int size)
		{
			byte[,,] array = new byte[size.x, size.y, size.z];
			for (int i = 0; i < size.x; i++)
			{
				for (int j = 0; j < size.y; j++)
				{
					for (int k = 0; k < size.z; k++)
					{
						if (input.GetLength(0) > i && input.GetLength(1) > k)
						{
							if (input[i, k] == Vec3Int.zero)
							{
								array[i, j, k] = 0;
							}
							else
							{
								array[i, j, k] = 1;
							}
						}
					}
				}
			}
			return array;
		}

		private Mesh GreedyMeshing(byte[,,] chunkData, Vec3Int maxSize, int blockHeight, Vector3 offset)
		{
			List<Vector3> list = new List<Vector3>();
			List<int> list2 = new List<int>();
			List<Vector3> list3 = new List<Vector3>();
			int num = ((maxSize.x > maxSize.z) ? maxSize.x : maxSize.z);
			Vector3[] array = new Vector3[3]
			{
				-Vector3.left,
				Vector3.up,
				Vector3.forward
			};
			int[] array2 = new int[(num + 1) * (num + 1)];
			int num2 = 0;
			for (int i = 0; i < 3; i++)
			{
				int num3 = (i + 1) % 3;
				int num4 = (i + 2) % 3;
				int[] array3 = new int[3];
				int[] array4 = new int[3];
				array4[i] = 1;
				array3[i] = -1;
				while (array3[i] < num)
				{
					int num5 = 0;
					array3[num4] = 0;
					while (array3[num4] < num)
					{
						array3[num3] = 0;
						while (array3[num3] < num)
						{
							int num6 = 0;
							if (array3[i] >= 0 && Block(array3[0], array3[1], array3[2], chunkData, maxSize) == 1)
							{
								num6 = 1;
							}
							int num7 = 0;
							if (array3[i] < num - 1 && Block(array3[0] + array4[0], array3[1] + array4[1], array3[2] + array4[2], chunkData, maxSize) == 1)
							{
								num7 = 1;
							}
							if (num6 == num7)
							{
								array2[num5] = 0;
							}
							else if (num6 > 0)
							{
								array2[num5] = num6;
							}
							else
							{
								array2[num5] = -num7;
							}
							array3[num3]++;
							num5++;
						}
						array3[num4]++;
					}
					array3[i]++;
					num5 = 0;
					for (int j = 0; j < num; j++)
					{
						int num8 = 0;
						while (num8 < num)
						{
							int num9 = array2[num5];
							if (num9 > -2)
							{
								int k;
								for (k = 1; num9 == array2[num5 + k] && num8 + k < num; k++)
								{
								}
								bool flag = false;
								int l;
								for (l = 1; j + l < num; l++)
								{
									for (int m = 0; m < k; m++)
									{
										if (num9 != array2[num5 + m + l * num])
										{
											flag = true;
											break;
										}
									}
									if (flag)
									{
										break;
									}
								}
								bool flag2 = false;
								array3[num3] = num8;
								array3[num4] = j;
								int[] array5 = new int[3];
								int[] array6 = new int[3];
								array5[num3] = k;
								array6[num4] = l;
								if (num9 <= -1)
								{
									flag2 = true;
									num9 = -num9;
								}
								int num10 = array3[1] * blockHeight;
								int num11 = (array3[1] + array5[1]) * blockHeight;
								int num12 = (array3[1] + array5[1] + array6[1]) * blockHeight;
								int num13 = (array3[1] + array6[1]) * blockHeight;
								Vector3 vector = new Vector3(array3[0], num10, array3[2]);
								Vector3 vector2 = new Vector3(array3[0] + array5[0], num11, array3[2] + array5[2]);
								Vector3 vector3 = new Vector3(array3[0] + array5[0] + array6[0], num12, array3[2] + array5[2] + array6[2]);
								Vector3 vector4 = new Vector3(array3[0] + array6[0], num13, array3[2] + array6[2]);
								vector2 += offset;
								vector += offset;
								vector3 += offset;
								vector4 += offset;
								if (num9 > 0 && !flag2)
								{
									AddQuad(vector, vector2, vector3, vector4, array[i], num2, list, list2, list3);
									num2 += 4;
								}
								else if (flag2)
								{
									AddQuad(vector4, vector3, vector2, vector, -array[i], num2, list, list2, list3);
									num2 += 4;
								}
								for (int n = 0; n < l; n++)
								{
									for (int m = 0; m < k; m++)
									{
										array2[num5 + m + n * num] = 0;
									}
								}
								num8 += k;
								num5 += k;
							}
							else
							{
								num8++;
								num5++;
							}
						}
					}
				}
			}
			Mesh mesh = new Mesh();
			mesh.Clear();
			mesh.vertices = list.ToArray();
			mesh.triangles = list2.ToArray();
			mesh.normals = list3.ToArray();
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			return mesh;
		}

		private void AddQuad(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4, Vector3 normalDir, int index, List<Vector3> vertices, List<int> triangles, List<Vector3> normals)
		{
			vertices.Add(v1);
			vertices.Add(v2);
			vertices.Add(v3);
			vertices.Add(v4);
			triangles.Add(index);
			triangles.Add(index + 1);
			triangles.Add(index + 2);
			triangles.Add(index + 2);
			triangles.Add(index + 3);
			triangles.Add(index);
			normals.Add(normalDir);
			normals.Add(normalDir);
			normals.Add(normalDir);
			normals.Add(normalDir);
		}

		private byte Block(int x, int y, int z, byte[,,] chunkData, Vec3Int limit)
		{
			if (x >= limit.x || x < 0 || y >= limit.y || y < 0 || z >= limit.z || z < 0)
			{
				return 0;
			}
			return chunkData[x, y, z];
		}
	}
}
