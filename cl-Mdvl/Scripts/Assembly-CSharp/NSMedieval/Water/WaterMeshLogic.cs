using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Tools;
using NSMedieval.Utils.Pool;
using UnityEngine;

namespace NSMedieval.Water
{
	public class WaterMeshLogic
	{
		private static int mapSizeX;

		private static int mapSizeY;

		private static int mapSizeZ;

		private List<Vector3> waterMeshVertices = new List<Vector3>();

		private List<int> waterMeshTriangles = new List<int>();

		private readonly List<Vector3>[] colliderMeshVertices;

		private readonly List<int>[] colliderMeshTriangles;

		private readonly List<Vector3>[] layersVertices;

		private readonly List<int>[] layersTriangles;

		private readonly Dictionary<Vector3, int>[] layersCache;

		private readonly Dictionary<Vector3, int> meshVertexIndexCache = new Dictionary<Vector3, int>();

		private readonly List<float> tempVoxelEdgeHeights0 = new List<float>();

		private readonly List<float> tempVoxelEdgeHeights1 = new List<float>();

		private readonly Dictionary<int, Vector3> vertexPositionSum = new Dictionary<int, Vector3>();

		private readonly Dictionary<int, int> vertexUsageCount = new Dictionary<int, int>();

		private readonly HashSet<Vector3> verticesSkipSmooth = new HashSet<Vector3>();

		private readonly HashSet<Vector3> verticesSkipSmoothY = new HashSet<Vector3>();

		private int[] obstacleData;

		private float[] waterDataDisplay;

		private Heightmap heightmap;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			mapSizeX = 0;
			mapSizeY = 0;
			mapSizeZ = 0;
		}

		public WaterMeshLogic(int mapSizeX, int mapSizeY, int mapSizeZ)
		{
			WaterMeshLogic.mapSizeX = mapSizeX;
			WaterMeshLogic.mapSizeY = mapSizeY;
			WaterMeshLogic.mapSizeZ = mapSizeZ;
			layersVertices = new List<Vector3>[mapSizeY];
			layersTriangles = new List<int>[mapSizeY];
			layersCache = new Dictionary<Vector3, int>[mapSizeY];
			colliderMeshVertices = new List<Vector3>[mapSizeY];
			colliderMeshTriangles = new List<int>[mapSizeY];
			for (int i = 0; i < mapSizeY; i++)
			{
				layersVertices[i] = new List<Vector3>();
				layersTriangles[i] = new List<int>();
				layersCache[i] = new Dictionary<Vector3, int>();
				colliderMeshVertices[i] = new List<Vector3>();
				colliderMeshTriangles[i] = new List<int>();
			}
			heightmap = MonoSingleton<Heightmap>.Instance;
		}

		public void GenerateWaterMeshData(float[] waterDataDisplay, int[] obstacleData, int mapSizeX, int mapSizeY, int mapSizeZ, bool meshSmoothOn)
		{
			waterMeshVertices.Clear();
			waterMeshTriangles.Clear();
			this.waterDataDisplay = waterDataDisplay;
			this.obstacleData = obstacleData;
			for (int i = 0; i < layersVertices.Length; i++)
			{
				layersVertices[i].Clear();
				layersTriangles[i].Clear();
			}
			WaterMeshLogic.mapSizeX = mapSizeX;
			WaterMeshLogic.mapSizeY = mapSizeY;
			WaterMeshLogic.mapSizeZ = mapSizeZ;
			GenerateWaterMeshData();
			GenerateColliderMeshData();
			if (meshSmoothOn)
			{
				SmoothMesh(ref waterMeshVertices, ref waterMeshTriangles);
				for (int j = 0; j < WaterMeshLogic.mapSizeY; j++)
				{
					List<Vector3> vertices = layersVertices[j];
					SmoothLayerMesh(vertices);
				}
			}
		}

		public void GenerateDebugMeshData(float[] dataToDisplay, List<Vector3> outputVertices, List<int> outputTriangles)
		{
			outputVertices.Clear();
			outputTriangles.Clear();
			for (int i = 0; i < mapSizeX; i++)
			{
				for (int j = 0; j < mapSizeY; j++)
				{
					for (int k = 0; k < mapSizeZ; k++)
					{
						int num = GridDataIndexTools.FastTo1DIndexNoCheck(i, j, k);
						float num2 = dataToDisplay[num];
						if (num2 <= 0f)
						{
							continue;
						}
						float sizeY = num2;
						float num3 = 1f;
						if (GridDataIndexTools.InRangeY(j + 1))
						{
							int num4 = GridDataIndexTools.FastTo1DIndexNoCheck(i, j + 1, k);
							if (dataToDisplay[num4] > 0f)
							{
								sizeY = 1f;
								num3 = num2;
							}
						}
						MeshDataUtils.AppendCube(ref outputVertices, ref outputTriangles, i, j, k, 1.05f * num3, sizeY, 1.05f * num3);
					}
				}
			}
		}

		public static void GenerateDebugMeshDataInt(int[] dataToDisplay, float[] heightPerValue, List<Vector3> outputVertices, List<int> outputTriangles)
		{
			outputTriangles.Clear();
			outputTriangles.Clear();
			for (int i = 0; i < mapSizeX; i++)
			{
				for (int j = 0; j < mapSizeY; j++)
				{
					for (int k = 0; k < mapSizeZ; k++)
					{
						int num = GridDataIndexTools.FastTo1DIndexNoCheck(i, j, k);
						int num2 = dataToDisplay[num];
						if (num2 <= 0)
						{
							continue;
						}
						float sizeY = heightPerValue[num2];
						float num3 = 1f;
						if (GridDataIndexTools.InRangeY(j + 1))
						{
							int num4 = GridDataIndexTools.FastTo1DIndexNoCheck(i, j + 1, k);
							if ((float)dataToDisplay[num4] > 0f)
							{
								sizeY = 1f;
								num3 = num2;
							}
						}
						MeshDataUtils.AppendCube(ref outputVertices, ref outputTriangles, i, j, k, num3, sizeY, num3);
					}
				}
			}
		}

		public void GetWaterMesh(Mesh outMesh)
		{
			outMesh.Clear();
			outMesh.SetVertices(waterMeshVertices);
			outMesh.SetTriangles(waterMeshTriangles, 0);
			outMesh.RecalculateNormals();
			outMesh.RecalculateTangents();
		}

		public void FillColliderMesh(Mesh outMesh, int yLevel)
		{
			outMesh.Clear();
			outMesh.SetVertices(colliderMeshVertices[yLevel]);
			outMesh.SetTriangles(colliderMeshTriangles[yLevel], 0);
		}

		public void FillLayerSliceMesh(Mesh outMesh, int layerIndex)
		{
			outMesh.Clear();
			outMesh.SetVertices(layersVertices[layerIndex]);
			outMesh.SetTriangles(layersTriangles[layerIndex], 0);
		}

		public void Dispose()
		{
			heightmap = null;
			waterMeshVertices.Clear();
			waterMeshTriangles.Clear();
			List<Vector3>[] array = colliderMeshVertices;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Clear();
			}
			List<int>[] array2 = colliderMeshTriangles;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Clear();
			}
			array = layersVertices;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Clear();
			}
			array2 = layersTriangles;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Clear();
			}
			Dictionary<Vector3, int>[] array3 = layersCache;
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i].Clear();
			}
			meshVertexIndexCache?.Clear();
			tempVoxelEdgeHeights0?.Clear();
			tempVoxelEdgeHeights1?.Clear();
			vertexPositionSum?.Clear();
			vertexUsageCount?.Clear();
			verticesSkipSmooth?.Clear();
			verticesSkipSmoothY?.Clear();
			obstacleData = null;
			waterDataDisplay = null;
		}

		private void SmoothMesh(ref List<Vector3> vertices, ref List<int> triangles)
		{
			vertexPositionSum.Clear();
			vertexUsageCount.Clear();
			for (int i = 0; i < triangles.Count; i += 3)
			{
				int num = triangles[i];
				int num2 = triangles[i + 1];
				int num3 = triangles[i + 2];
				Vector3 vector = (vertices[num] + vertices[num2] + vertices[num3]) / 3f;
				if (!vertexPositionSum.ContainsKey(num))
				{
					vertexPositionSum.Add(num, vector);
					vertexUsageCount.Add(num, 1);
				}
				else
				{
					vertexPositionSum[num] += vector;
					vertexUsageCount[num]++;
				}
				if (!vertexPositionSum.ContainsKey(num2))
				{
					vertexPositionSum.Add(num2, vector);
					vertexUsageCount.Add(num2, 1);
				}
				else
				{
					vertexPositionSum[num2] += vector;
					vertexUsageCount[num2]++;
				}
				if (!vertexPositionSum.ContainsKey(num3))
				{
					vertexPositionSum.Add(num3, vector);
					vertexUsageCount.Add(num3, 1);
				}
				else
				{
					vertexPositionSum[num3] += vector;
					vertexUsageCount[num3]++;
				}
			}
			for (int j = 0; j < vertices.Count; j++)
			{
				Vector3 vector2 = vertices[j];
				if (!verticesSkipSmooth.Contains(vector2))
				{
					Vector3 value = Vector3.Lerp(vector2, vertexPositionSum[j] / vertexUsageCount[j], 0.9f);
					if (verticesSkipSmoothY.Contains(vector2) || vector2.y <= 0.001f)
					{
						value.y = vector2.y;
					}
					vertices[j] = value;
				}
			}
		}

		private void SmoothLayerMesh(IList<Vector3> vertices)
		{
			int count = vertices.Count;
			for (int i = 0; i < count; i++)
			{
				if (meshVertexIndexCache.ContainsKey(vertices[i]))
				{
					Vector3 vector = vertices[i];
					int index = meshVertexIndexCache[vector];
					Vector3 vector2 = waterMeshVertices[index];
					vector.x = vector2.x;
					vector.y = vector2.y;
					vector.z = vector2.z;
					vertices[i] = vector;
				}
			}
		}

		private void GenerateWaterMeshData()
		{
			if (obstacleData == null || obstacleData.Length == 0)
			{
				return;
			}
			meshVertexIndexCache.Clear();
			verticesSkipSmooth.Clear();
			verticesSkipSmoothY.Clear();
			for (int i = 0; i < mapSizeY; i++)
			{
				layersCache[i].Clear();
			}
			for (int num = mapSizeY - 1; num >= 0; num--)
			{
				for (int j = -80; j < mapSizeX + 80; j++)
				{
					for (int k = -80; k < mapSizeZ + 80; k++)
					{
						heightmap.MapFromEdgeFrameToMapCoords(j, k, out var xMapSpace, out var zMapSpace);
						int num2 = GridDataIndexTools.FastTo1DIndexNoCheck(xMapSpace, num, zMapSpace);
						if (obstacleData[num2] == 1)
						{
							continue;
						}
						if (waterDataDisplay[num2] <= 0f)
						{
							if (num < mapSizeY - 1)
							{
								int num3 = GridDataIndexTools.FastTo1DIndexNoCheck(xMapSpace, num + 1, zMapSpace);
								if (waterDataDisplay[num3] > 0f)
								{
									CreateBottomTriangles(j, num + 1, k);
								}
							}
							continue;
						}
						float num4 = waterDataDisplay[num2];
						CreateSideFaces(j, num, k, num4, 1, 0);
						CreateSideFaces(j, num, k, num4, -1, 0);
						CreateSideFaces(j, num, k, num4, 0, 1);
						CreateSideFaces(j, num, k, num4, 0, -1);
						if (num < mapSizeY - 1)
						{
							int num5 = GridDataIndexTools.FastTo1DIndexNoCheck(xMapSpace, num + 1, zMapSpace);
							if (waterDataDisplay[num5] <= 0f || obstacleData[num5] == 1)
							{
								CreateTopTriangles(j, num, k, num4);
							}
						}
					}
				}
			}
			for (int num6 = mapSizeY - 1; num6 >= 0; num6--)
			{
				for (int l = -80; l < mapSizeX + 80; l++)
				{
					for (int m = -80; m < mapSizeZ + 80; m++)
					{
						heightmap.MapFromEdgeFrameToMapCoords(l, m, out var xMapSpace2, out var zMapSpace2);
						int num7 = GridDataIndexTools.FastTo1DIndexNoCheck(xMapSpace2, num6, zMapSpace2);
						if (obstacleData[num7] != 1 && !(waterDataDisplay[num7] <= 0f) && num6 < mapSizeY - 1)
						{
							int indexUp = GridDataIndexTools.FastTo1DIndexNoCheck(xMapSpace2, num6 + 1, zMapSpace2);
							if (IsLayerSurface(indexUp))
							{
								CreateLayerFlatTop(l, num6, m, waterDataDisplay[num7]);
							}
						}
					}
				}
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(36, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Water\\WaterMeshLogic.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Mesh created: ");
				messageBuilder.AppendFormatted(waterMeshVertices.Count);
				messageBuilder.AppendLiteral(" vertices, ");
				messageBuilder.AppendFormatted(waterMeshTriangles.Count);
				messageBuilder.AppendLiteral(" triangles.");
			}
			Log.Trace(messageBuilder);
		}

		private void GenerateColliderMeshData()
		{
			for (int i = 0; i < mapSizeY; i++)
			{
				colliderMeshTriangles[i].Clear();
				colliderMeshVertices[i].Clear();
			}
			Dictionary<Vector3, int> dictionary = DictionaryPool<Vector3, int>.Get();
			for (int num = mapSizeY - 1; num >= 0; num--)
			{
				for (int j = 0; j < mapSizeX; j++)
				{
					for (int k = 0; k < mapSizeZ; k++)
					{
						int num2 = GridDataIndexTools.FastTo1DIndexNoCheck(j, num, k);
						if (obstacleData[num2] != 1 && !(waterDataDisplay[num2] <= WaterConstants.WaterLevelsDisplay[0]))
						{
							CreateLayerFlatTop(j, num, k, waterDataDisplay[num2], colliderMeshVertices[num], colliderMeshTriangles[num], dictionary);
						}
					}
				}
			}
			DictionaryPool<Vector3, int>.Return(dictionary);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool IsLayerSurface(int indexUp)
		{
			if (obstacleData[indexUp] == 0)
			{
				return waterDataDisplay[indexUp] > 0f;
			}
			return false;
		}

		private void CreateTopTriangles(int x, int y, int z, float waterLevel)
		{
			float y2 = (float)y + waterLevel;
			Vector3 vector = new Vector3(x, y2, z);
			Vector3 vector2 = new Vector3(x + 1, y2, z);
			Vector3 vector3 = new Vector3(x + 1, y2, z + 1);
			Vector3 vector4 = new Vector3(x, y2, z + 1);
			MeshDataUtils.CachedAppendTriangle(waterMeshVertices, waterMeshTriangles, meshVertexIndexCache, vector3, vector2, vector);
			MeshDataUtils.CachedAppendTriangle(waterMeshVertices, waterMeshTriangles, meshVertexIndexCache, vector, vector4, vector3);
			bool num = CheckEdgeShouldSkipSmooth(x, y + 1, z);
			if (num || CheckEdgeShouldSkipSmooth(x - 1, y, z) || CheckEdgeShouldSkipSmooth(x, y, z - 1))
			{
				verticesSkipSmooth.Add(vector);
			}
			if (num || CheckEdgeShouldSkipSmooth(x + 1, y, z) || CheckEdgeShouldSkipSmooth(x, y, z - 1))
			{
				verticesSkipSmooth.Add(vector2);
			}
			if (num || CheckEdgeShouldSkipSmooth(x + 1, y, z) || CheckEdgeShouldSkipSmooth(x, y, z + 1))
			{
				verticesSkipSmooth.Add(vector3);
			}
			if (num || CheckEdgeShouldSkipSmooth(x - 1, y, z) || CheckEdgeShouldSkipSmooth(x, y, z + 1))
			{
				verticesSkipSmooth.Add(vector4);
			}
		}

		private void CreateBottomTriangles(int x, int y, int z)
		{
			float y2 = y;
			Vector3 vector = new Vector3(x, y2, z);
			Vector3 v = new Vector3(x + 1, y2, z);
			Vector3 vector2 = new Vector3(x + 1, y2, z + 1);
			Vector3 v2 = new Vector3(x, y2, z + 1);
			MeshDataUtils.CachedAppendTriangle(waterMeshVertices, waterMeshTriangles, meshVertexIndexCache, vector, v, vector2);
			MeshDataUtils.CachedAppendTriangle(waterMeshVertices, waterMeshTriangles, meshVertexIndexCache, vector2, v2, vector);
		}

		private void CreateLayerFlatTop(int x, int y, int z, float waterLevel)
		{
			float y2 = (float)y + waterLevel;
			Vector3 vector = new Vector3(x, y2, z);
			Vector3 vector2 = new Vector3(x + 1, y2, z);
			Vector3 vector3 = new Vector3(x + 1, y2, z + 1);
			Vector3 vector4 = new Vector3(x, y2, z + 1);
			verticesSkipSmoothY.Add(vector);
			verticesSkipSmoothY.Add(vector2);
			verticesSkipSmoothY.Add(vector3);
			verticesSkipSmoothY.Add(vector4);
			MeshDataUtils.CachedAppendTriangle(layersVertices[y], layersTriangles[y], layersCache[y], vector3, vector2, vector);
			MeshDataUtils.CachedAppendTriangle(layersVertices[y], layersTriangles[y], layersCache[y], vector, vector4, vector3);
		}

		private static void CreateLayerFlatTop(int x, int y, int z, float waterLevel, List<Vector3> outputVertices, List<int> outputTriangles, Dictionary<Vector3, int> vertexIndexCache)
		{
			float y2 = (float)y + waterLevel;
			Vector3 vector = new Vector3(x, y2, z);
			Vector3 v = new Vector3(x + 1, y2, z);
			Vector3 vector2 = new Vector3(x + 1, y2, z + 1);
			Vector3 v2 = new Vector3(x, y2, z + 1);
			MeshDataUtils.CachedAppendTriangle(outputVertices, outputTriangles, vertexIndexCache, vector2, v, vector);
			MeshDataUtils.CachedAppendTriangle(outputVertices, outputTriangles, vertexIndexCache, vector, v2, vector2);
		}

		private void CreateSideFaces(int x, int y, int z, float maxWater, int xAdd, int zAdd)
		{
			int num = ((xAdd == 1 && zAdd == 0) ? 1 : 0);
			int num2 = ((xAdd == 0 && zAdd == 1) ? 1 : 0);
			int num3 = ((xAdd != 0) ? 1 : 0);
			int num4 = ((zAdd != 0) ? 1 : 0);
			int num5 = To1DIndexMapSpace(x + xAdd, y, z + zAdd);
			if (obstacleData[num5] == 1)
			{
				return;
			}
			float num6 = waterDataDisplay[num5];
			if (!(num6 < maxWater))
			{
				return;
			}
			GetVoxelEdgeHeights(x, y, z, num6, maxWater, tempVoxelEdgeHeights0, xAdd - num4, zAdd - num3, out var skipLowestVert);
			GetVoxelEdgeHeights(x, y, z, num6, maxWater, tempVoxelEdgeHeights1, xAdd + num4, zAdd + num3, out var skipLowestVert2);
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			Vector3 vector = default(Vector3);
			vector.x = x + num;
			Vector3 vector2 = default(Vector3);
			vector2.x = x + num + num4;
			Vector3 vector3 = default(Vector3);
			vector3.x = x + num;
			vector.z = z + num2;
			vector2.z = z + num2 + num3;
			vector3.z = z + num2;
			vector.y = y;
			vector2.y = y;
			bool num10 = CheckEdgeShouldSkipSmooth(x, y + 1, z);
			bool flag = num10 || CheckEdgeShouldSkipSmooth(x + xAdd - num4, y, z) || CheckEdgeShouldSkipSmooth(x, y, z + zAdd - num3);
			if (flag)
			{
				verticesSkipSmooth.Add(vector);
			}
			bool flag2 = num10 || CheckEdgeShouldSkipSmooth(x + xAdd + num4, y, z) || CheckEdgeShouldSkipSmooth(x, y, z + zAdd + num3);
			if (flag2)
			{
				verticesSkipSmooth.Add(vector2);
			}
			bool flag3 = false;
			do
			{
				vector.y = (float)y + tempVoxelEdgeHeights0[num7];
				vector2.y = (float)y + tempVoxelEdgeHeights1[num8];
				if (skipLowestVert && tempVoxelEdgeHeights0[num7] <= 0f)
				{
					verticesSkipSmoothY.Add(vector);
				}
				if (skipLowestVert2 && tempVoxelEdgeHeights1[num8] <= 0f)
				{
					verticesSkipSmoothY.Add(vector2);
				}
				if (num9++ % 2 == 0)
				{
					if (num8 < tempVoxelEdgeHeights1.Count - 1)
					{
						num8++;
					}
					vector3.y = (float)y + tempVoxelEdgeHeights1[num8];
					vector3.z = z + num3 + num2;
					vector3.x = x + num4 + num;
					flag3 = flag2;
				}
				else
				{
					if (num7 < tempVoxelEdgeHeights0.Count - 1)
					{
						num7++;
					}
					vector3.y = y;
					if (tempVoxelEdgeHeights0[num7] > 0f)
					{
						vector3.y += tempVoxelEdgeHeights0[num7];
					}
					vector3.z = z + num2;
					vector3.x = x + num;
					flag3 = flag;
				}
				if (xAdd > 0 || zAdd < 0)
				{
					MeshDataUtils.CachedAppendTriangle(waterMeshVertices, waterMeshTriangles, meshVertexIndexCache, vector3, vector2, vector);
				}
				else
				{
					MeshDataUtils.CachedAppendTriangle(waterMeshVertices, waterMeshTriangles, meshVertexIndexCache, vector, vector2, vector3);
				}
				if (flag3)
				{
					verticesSkipSmooth.Add(vector3);
				}
			}
			while (num7 < tempVoxelEdgeHeights0.Count - 1 || num8 < tempVoxelEdgeHeights1.Count - 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int To1DIndexMapSpace(int x, int y, int z)
		{
			heightmap.MapFromEdgeFrameToMapCoords(Heightmap.ClampEdgeX(x), Heightmap.ClampEdgeZ(z), out var xMapSpace, out var zMapSpace);
			return GridDataIndexTools.FastTo1DIndexNoCheck(xMapSpace, y, zMapSpace);
		}

		private void GetVoxelEdgeHeights(int posX, int posY, int posZ, float minWater, float maxWater, IList<float> heights, int xAdd, int zAdd, out bool skipLowestVert)
		{
			skipLowestVert = false;
			heights.Clear();
			heights.Add(minWater);
			heights.Add(maxWater);
			TryAddCornerVertexHeight(posX + xAdd, posY, posZ);
			TryAddCornerVertexHeight(posX, posY, posZ + zAdd);
			TryAddCornerVertexHeight(posX + xAdd, posY, posZ + zAdd);
			if (posY == 0)
			{
				skipLowestVert = true;
				return;
			}
			int num = To1DIndexMapSpace(posX, posY - 1, posZ);
			if (obstacleData[num] == 1)
			{
				skipLowestVert = true;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			static void SortedAddToList(IList<float> list, float height)
			{
				if (list.Count == 0)
				{
					list.Add(height);
				}
				else
				{
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i] > height)
						{
							list.Insert(i, height);
							break;
						}
					}
				}
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			void TryAddCornerVertexHeight(int x, int y, int z)
			{
				if (GridDataIndexTools.InRange(x, y, z))
				{
					int num2 = To1DIndexMapSpace(x, y, z);
					if (obstacleData[num2] != 1 && waterDataDisplay[num2] > minWater && waterDataDisplay[num2] < maxWater && !heights.Contains(waterDataDisplay[num2]))
					{
						float height = waterDataDisplay[num2];
						SortedAddToList(heights, height);
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool CheckEdgeShouldSkipSmooth(int x, int y, int z)
		{
			heightmap.MapFromEdgeFrameToMapCoords(Heightmap.ClampEdgeX(x), Heightmap.ClampEdgeZ(z), out var xMapSpace, out var zMapSpace);
			int num = GridDataIndexTools.FastTo1DIndexNoCheck(xMapSpace, y, zMapSpace);
			if (num != -1)
			{
				return obstacleData[num] == 1;
			}
			return true;
		}
	}
}
