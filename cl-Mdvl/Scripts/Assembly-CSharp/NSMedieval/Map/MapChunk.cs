using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.MeshTools;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using Unity.Mathematics;
using UnityEngine;

namespace NSMedieval.Map
{
	public class MapChunk : MapGenThreadedTaskRunner
	{
		private const int NumberOfSubmeshes = 3;

		private const byte SlopePlace = 16;

		[SerializeField]
		private MeshCollider meshCollider;

		[SerializeField]
		private MeshFilter bottomBlackMesh;

		[SerializeField]
		private MeshFilter topTransparentMesh;

		[SerializeField]
		private ClickDetection clickDetection;

		[SerializeField]
		private TopMesh topMesh;

		[SerializeField]
		private MeshFilter meshFilter;

		[SerializeField]
		private MeshRenderer meshRenderer;

		[NonSerialized]
		protected readonly Dictionary<int, List<Vector3>> vertices = new Dictionary<int, List<Vector3>>();

		private readonly Dictionary<int, List<Vector3>> normals = new Dictionary<int, List<Vector3>>();

		private readonly Dictionary<int, Dictionary<Vector3, Dictionary<Vector3, int>>> normalToVertexToIndex = new Dictionary<int, Dictionary<Vector3, Dictionary<Vector3, int>>>();

		private readonly Dictionary<int, List<List<int>>> triangles = new Dictionary<int, List<List<int>>>();

		private Dictionary<int, Vector3[]> finalVertices = new Dictionary<int, Vector3[]>();

		private Dictionary<int, List<int[]>> finalTriangles = new Dictionary<int, List<int[]>>();

		private Dictionary<int, Vector3[]> finalNormals = new Dictionary<int, Vector3[]>();

		protected int mapSizeX;

		protected int mapSizeY;

		protected int mapSizeZ;

		[SerializeField]
		protected Mesh[] meshCache;

		[SerializeField]
		private Mesh currentMesh;

		protected int meshLevelUpdate;

		protected int chunkX;

		protected int chunkY;

		protected int chunkZ;

		protected int chunkSize;

		private int generateMeshChunkYStart;

		protected int maxHeight;

		protected bool updateMesh;

		private bool loadFromSave;

		private VillageMap map;

		private object locked = new object();

		private float selectedTime;

		public Vector3 clickPosition;

		public float SelectedTime => selectedTime;

		public Vector3 ClickPosition => clickPosition;

		public MeshRenderer TopRenderer => meshRenderer;

		public int ChunkX => chunkX;

		public int ChunkY => chunkY;

		public int ChunkZ => chunkZ;

		public int ChunkSize => chunkSize;

		public event Action ChunkGeneratedEvent;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int GetMaterialIndex(Vector3 surfaceNormal)
		{
			if (Mathf.Abs(surfaceNormal.y) > 0.75f)
			{
				return 0;
			}
			if (Mathf.Abs(surfaceNormal.x) > 0.75f)
			{
				return 1;
			}
			return 2;
		}

		public void Setup(bool loadFromSave, int chunkX, int chunkY, int chunkZ, Vec3Int mapSize, int chunkSize)
		{
			mapSizeX = mapSize.x;
			mapSizeY = mapSize.y;
			mapSizeZ = mapSize.z;
			this.loadFromSave = loadFromSave;
			this.chunkX = chunkX;
			this.chunkY = chunkY;
			this.chunkZ = chunkZ;
			this.chunkSize = chunkSize;
			map = VillageManager.ActiveVillage.Map;
		}

		public void SetClickData(float selectedTime, Vector3 clickPosition)
		{
			this.selectedTime = selectedTime;
			this.clickPosition = clickPosition;
		}

		public void SetupBottomBlackMesh(float realWorldLevel)
		{
			if (!(bottomBlackMesh == null))
			{
				Mesh sharedMesh = meshCache[GetMeshIndexForElevationLevel((int)(realWorldLevel - 0.4f))];
				bottomBlackMesh.sharedMesh = sharedMesh;
			}
		}

		public void SetupTopTransparentMesh(int elevationLevel)
		{
			if (!(topTransparentMesh == null))
			{
				Mesh sharedMesh = meshCache[GetMeshIndexForElevationLevel(elevationLevel + 1)];
				topTransparentMesh.sharedMesh = sharedMesh;
			}
		}

		public void UpdateMesh(int meshLevelUpdate)
		{
			updateMesh = true;
			this.meshLevelUpdate = Math.Min(this.meshLevelUpdate, meshLevelUpdate);
		}

		public bool IsMeshUpdateInProgressOrScheduled()
		{
			return updateMesh;
		}

		public virtual void LoadMesh(int elevationLevel)
		{
			currentMesh = meshCache[GetMeshIndexForElevationLevel(elevationLevel)];
			meshFilter.sharedMesh = currentMesh;
			if (meshCollider != null)
			{
				meshCollider.sharedMesh = currentMesh;
			}
			SetupTopTransparentMesh(elevationLevel);
			SetupBottomBlackMesh(elevationLevel);
		}

		internal void SetShadowCasterMesh()
		{
			topMesh.SetupTopMesh(meshCache[Math.Min(maxHeight + 1, meshCache.Length - 1)]);
		}

		private static string GetMeshNameInSave(int x, int z, int cacheIndex)
		{
			return $"MapChunks/{x}-{z}-{cacheIndex}.mesh";
		}

		private void Start()
		{
			base.gameObject.tag = "MapChunk";
			Transform[] componentsInChildren = base.transform.GetComponentsInChildren<Transform>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].tag = "MapChunk";
			}
			currentMesh = meshFilter.mesh;
			meshCache = new Mesh[mapSizeY + 1];
			if (loadFromSave)
			{
				LoadFromZip();
			}
			else
			{
				RecalculateMaxHeight();
				StartMeshGeneratingThread();
			}
			MonoSingleton<SceneController>.Instance.LateTick += OnLateTick;
			clickDetection.Clicked += OnClick;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			triangles.Clear();
			normals.Clear();
			vertices.Clear();
			normalToVertexToIndex.Clear();
			finalTriangles.Clear();
			finalNormals.Clear();
			finalVertices.Clear();
			currentMesh = null;
			meshCache = null;
			meshCollider = null;
			bottomBlackMesh = null;
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.LateTick -= OnLateTick;
			}
			if ((object)clickDetection != null)
			{
				clickDetection.Clicked -= OnClick;
			}
			this.ChunkGeneratedEvent = null;
			map = null;
		}

		private void OnLateTick(float deltaTime)
		{
			using (ProfilerSampleJanitor.Begin("MapChunk.LateTick"))
			{
				if (updateMesh)
				{
					updateMesh = false;
					chunkY = meshLevelUpdate;
					RecalculateMaxHeight();
					StartMeshGeneratingThread();
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual byte GetChunkDataAt(int x, int y, int z, int maxElevationLevel)
		{
			if (y >= maxElevationLevel)
			{
				return 0;
			}
			int x2 = x + chunkX;
			if (!GridDataIndexTools.InRangeX(x2))
			{
				return 0;
			}
			int z2 = z + chunkZ;
			if (!GridDataIndexTools.InRangeZ(z2))
			{
				return 0;
			}
			MapNode node = map.GridSpaceData[GridDataIndexTools.FastTo1DIndexNoCheck(x2, math.clamp(y, 0, mapSizeY - 1), z2)];
			return GetChunkByteData(node);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected int GetMeshIndexForElevationLevel(int elevation)
		{
			return Math.Min(meshCache.Length - 1, (elevation <= maxHeight + 1) ? elevation : (maxHeight + 1));
		}

		protected virtual void RecalculateMaxHeight()
		{
			MapNode[] gridSpaceData = map.GridSpaceData;
			maxHeight = 0;
			for (int i = 0; i < chunkSize; i++)
			{
				if (i + chunkX >= mapSizeX)
				{
					continue;
				}
				for (int j = 0; j < mapSizeY; j++)
				{
					for (int k = 0; k < chunkSize; k++)
					{
						if (k + chunkZ < mapSizeZ)
						{
							MapNode node = gridSpaceData[GridDataIndexTools.FastTo1DIndexNoCheck(i + chunkX, j, k + chunkZ)];
							if (!IsEmptyValue(GetChunkByteData(node)))
							{
								maxHeight = Math.Max(j, maxHeight);
							}
						}
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private byte GetChunkByteData(MapNode node)
		{
			if (node == null || node.IsVoxelAir())
			{
				return 0;
			}
			if (node.CheckIsDataType(GridDataType.Slope))
			{
				return 2;
			}
			return 1;
		}

		private void OnClick(Vector3 worldPos)
		{
			if (MonoSingleton<KeybindingManager>.IsInstantiated() && MonoSingleton<World>.IsInstantiated() && MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.LeftControl))
			{
				MonoSingleton<World>.Instance.SwitchToLowerLayer(GridUtils.GetGridPosition(worldPos, 0.01f));
			}
		}

		private void FillMeshWithData(int cacheIndex)
		{
			if (finalVertices.ContainsKey(cacheIndex) && cacheIndex < meshCache.Length)
			{
				if ((object)meshCache[cacheIndex] == null)
				{
					meshCache[cacheIndex] = new Mesh();
					meshCache[cacheIndex].name = $"Mesh{cacheIndex:00}";
				}
				Mesh newMesh = meshCache[cacheIndex];
				newMesh.Clear();
				if (finalVertices.ContainsKey(cacheIndex))
				{
					newMesh.vertices = finalVertices[cacheIndex];
					newMesh.normals = finalNormals[cacheIndex];
					newMesh.subMeshCount = 3;
					SetSubmeshes(cacheIndex, ref newMesh);
					newMesh.RecalculateBounds();
					newMesh.tangents = TangentSolver.CalculateMeshTangents(newMesh.triangles, newMesh.vertices, newMesh.normals, newMesh.uv);
				}
			}
		}

		private void SetSubmeshes(int cacheIndex, ref Mesh newMesh)
		{
			for (int i = 0; i < 3; i++)
			{
				newMesh.SetTriangles(finalTriangles[cacheIndex][i], i);
			}
		}

		private void GenerateMeshes()
		{
			while (chunkY <= maxHeight + 1)
			{
				GreedyMeshing(chunkSize, chunkY);
				if (chunkY == mapSizeY)
				{
					break;
				}
				chunkY++;
			}
			OnGenerateMeshesFinished();
		}

		protected virtual void OnGenerateMeshesFinished()
		{
		}

		private void GreedyMeshing(int chunkSize, int elevationLevel)
		{
			ClearMeshData(elevationLevel);
			int mapBlockHeight = World.MapBlockHeight;
			Vector3[] array = new Vector3[3]
			{
				-Vector3.left,
				Vector3.up,
				Vector3.forward
			};
			int[] array2 = new int[(chunkSize + 1) * (chunkSize + 1)];
			int num = 0;
			for (int i = 0; i < 3; i++)
			{
				int num2 = (i + 1) % 3;
				int num3 = (i + 2) % 3;
				int[] array3 = new int[3];
				int[] array4 = new int[3];
				array4[i] = 1;
				array3[i] = -1;
				while (array3[i] < chunkSize)
				{
					int num4 = 0;
					array3[num3] = 0;
					while (array3[num3] < chunkSize)
					{
						array3[num2] = 0;
						while (array3[num2] < chunkSize)
						{
							int num5 = ((!IsEmptyValue(GetChunkDataAt(array3[0], array3[1], array3[2], elevationLevel))) ? 1 : 0);
							int num6 = ((!IsEmptyValue(GetChunkDataAt(array3[0] + array4[0], array3[1] + array4[1], array3[2] + array4[2], elevationLevel))) ? 1 : 0);
							if (num5 == num6)
							{
								array2[num4] = 0;
							}
							else if (num5 > 0)
							{
								array2[num4] = num5;
							}
							else
							{
								array2[num4] = -num6;
							}
							array3[num2]++;
							num4++;
						}
						array3[num3]++;
					}
					array3[i]++;
					num4 = 0;
					for (int j = 0; j < chunkSize; j++)
					{
						int num7 = 0;
						while (num7 < chunkSize)
						{
							int num8 = array2[num4];
							if (num8 > -2)
							{
								int k;
								for (k = 1; num8 == array2[num4 + k] && num7 + k < chunkSize; k++)
								{
								}
								bool flag = false;
								int l;
								for (l = 1; j + l < chunkSize; l++)
								{
									for (int m = 0; m < k; m++)
									{
										if (num8 != array2[num4 + m + l * chunkSize])
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
								array3[num2] = num7;
								array3[num3] = j;
								int[] array5 = new int[3];
								int[] array6 = new int[3];
								array5[num2] = k;
								array6[num3] = l;
								if (num8 <= -1)
								{
									flag2 = true;
									num8 = -num8;
								}
								int num9 = array3[1] * mapBlockHeight;
								int num10 = (array3[1] + array5[1]) * mapBlockHeight;
								int num11 = (array3[1] + array5[1] + array6[1]) * mapBlockHeight;
								int num12 = (array3[1] + array6[1]) * mapBlockHeight;
								Vector3 vector = new Vector3(array3[0], num9, array3[2]);
								Vector3 vector2 = new Vector3(array3[0] + array5[0], num10, array3[2] + array5[2]);
								Vector3 vector3 = new Vector3(array3[0] + array5[0] + array6[0], num11, array3[2] + array5[2] + array6[2]);
								Vector3 vector4 = new Vector3(array3[0] + array6[0], num12, array3[2] + array6[2]);
								if (num8 > 0 && !flag2)
								{
									AddQuad(elevationLevel, vector, vector2, vector3, vector4, array[i], num);
									num += 4;
								}
								else if (flag2)
								{
									AddQuad(elevationLevel, vector4, vector3, vector2, vector, -array[i], num);
									num += 4;
								}
								for (int n = 0; n < l; n++)
								{
									for (int m = 0; m < k; m++)
									{
										array2[num4 + m + n * chunkSize] = 0;
									}
								}
								num7 += k;
								num4 += k;
							}
							else
							{
								num7++;
								num4++;
							}
						}
					}
				}
			}
		}

		private void CopyDataToFinalArrays()
		{
			finalVertices.Clear();
			finalNormals.Clear();
			finalTriangles.Clear();
			for (int i = generateMeshChunkYStart; i <= maxHeight + 1; i++)
			{
				if (!vertices.ContainsKey(i) || !triangles.ContainsKey(i) || !normals.ContainsKey(i) || vertices[i].Count == 0 || triangles[i].Count == 0 || normals[i].Count == 0)
				{
					continue;
				}
				finalVertices.Add(i, vertices[i].ToArray());
				finalNormals.Add(i, normals[i].ToArray());
				finalTriangles.Add(i, new List<int[]>());
				foreach (List<int> item in triangles[i])
				{
					finalTriangles[i].Add(item.ToArray());
				}
			}
			vertices.Clear();
			triangles.Clear();
			normals.Clear();
			normalToVertexToIndex.Clear();
		}

		private void ClearMeshData(int cacheIndex)
		{
			if (!vertices.TryGetValue(cacheIndex, out var value))
			{
				vertices.Add(cacheIndex, new List<Vector3>());
			}
			else
			{
				value.Clear();
			}
			if (!normalToVertexToIndex.TryGetValue(cacheIndex, out var value2))
			{
				normalToVertexToIndex.Add(cacheIndex, new Dictionary<Vector3, Dictionary<Vector3, int>>());
			}
			else
			{
				value2.Clear();
			}
			if (!normals.TryGetValue(cacheIndex, out var value3))
			{
				normals.Add(cacheIndex, new List<Vector3>());
			}
			else
			{
				value3.Clear();
			}
			if (!triangles.TryGetValue(cacheIndex, out var value4))
			{
				triangles.Add(cacheIndex, new List<List<int>>());
				for (int i = 0; i < 3; i++)
				{
					triangles[cacheIndex].Add(new List<int>());
				}
				return;
			}
			foreach (List<int> item in value4)
			{
				item.Clear();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected static bool IsEmptyValue(int value)
		{
			return value - (value & 0x10) == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void AddQuad(int cacheIndex, Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4, Vector3 normalDir, int index)
		{
			AddVertex(v1, normalDir);
			AddVertex(v2, normalDir);
			AddVertex(v3, normalDir);
			AddVertex(v4, normalDir);
			int materialIndex = GetMaterialIndex(normalDir);
			while (triangles[cacheIndex].Count <= materialIndex)
			{
				triangles[cacheIndex].Add(new List<int>());
			}
			triangles[cacheIndex][materialIndex].Add(GetIndex(v1, normalDir));
			triangles[cacheIndex][materialIndex].Add(GetIndex(v2, normalDir));
			triangles[cacheIndex][materialIndex].Add(GetIndex(v3, normalDir));
			triangles[cacheIndex][materialIndex].Add(GetIndex(v3, normalDir));
			triangles[cacheIndex][materialIndex].Add(GetIndex(v4, normalDir));
			triangles[cacheIndex][materialIndex].Add(GetIndex(v1, normalDir));
			int AddVertex(Vector3 vertex, Vector3 normal)
			{
				Dictionary<Vector3, Dictionary<Vector3, int>> dictionary = normalToVertexToIndex[cacheIndex];
				if (!dictionary.TryGetValue(normal, out var value))
				{
					value = new Dictionary<Vector3, int>();
					dictionary.Add(normal, value);
				}
				if (value.TryGetValue(vertex, out var value2))
				{
					return value2;
				}
				int result = (value[vertex] = vertices[cacheIndex].Count);
				vertices[cacheIndex].Add(vertex);
				normals[cacheIndex].Add(normal);
				return result;
			}
			int GetIndex(Vector3 vertex, Vector3 normal)
			{
				return normalToVertexToIndex[cacheIndex][normal][vertex];
			}
		}

		private void StartMeshGeneratingThread()
		{
			ExecuteThreaded(GenerateMeshOnThread, OnMeshGenerateThreadFinishedCallback);
		}

		private void GenerateMeshOnThread()
		{
			while (!CanStartGeneratingMesh())
			{
				Thread.Sleep(1);
			}
			lock (locked)
			{
				generateMeshChunkYStart = chunkY;
				GenerateMeshes();
				CopyDataToFinalArrays();
			}
		}

		protected virtual bool CanStartGeneratingMesh()
		{
			return true;
		}

		private void OnMeshGenerateThreadFinishedCallback()
		{
			for (int i = generateMeshChunkYStart; i <= maxHeight + 1; i++)
			{
				FillMeshWithData(i);
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				LoadMesh(MonoSingleton<World>.Instance.ElevationLevel);
			}
			meshLevelUpdate = chunkY + 1;
			SetShadowCasterMesh();
			this.ChunkGeneratedEvent?.Invoke();
		}

		public void SaveToZip()
		{
			int x = chunkX / chunkSize;
			int z = chunkZ / chunkSize;
			for (int i = 0; i < mapSizeY; i++)
			{
				if (i < meshCache.Length && (object)meshCache[i] != null && meshCache[i].vertexCount != 0)
				{
					SaveToZip(x, z, i);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SaveToZip(int x, int z, int cacheIndex)
		{
			byte[] data = MeshSerializer.SerializeMesh(meshCache[cacheIndex]);
			GlobalSaveController.CurrentVillageData.ZipWriteBytes(GetMeshNameInSave(x, z, cacheIndex), data);
		}

		private bool LoadFromZip(int x, int z)
		{
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			bool flag = ApplicationVersionUtils.CompareVersion("0.26.55", currentVillageData.ModifiedOnGameVersion) > 0;
			for (int i = 1; i <= maxHeight + 1; i++)
			{
				string meshNameInSave = GetMeshNameInSave(x, z, i);
				if (currentVillageData.ZipContains(meshNameInSave))
				{
					using (MemoryStream memoryStream = currentVillageData.ZipReadStream(meshNameInSave))
					{
						if (memoryStream == null)
						{
							meshLevelUpdate = i;
							return false;
						}
						memoryStream.Seek(0L, SeekOrigin.Begin);
						Mesh mesh = MeshSerializer.DeserializeMesh(new BinaryReader(memoryStream));
						mesh.name = $"Mesh{i:00}";
						meshCache[i] = mesh;
						if (flag)
						{
							bool isEnabled;
							FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(34, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\MapChunk.cs");
							if (isEnabled)
							{
								messageBuilder.AppendLiteral("Re-generating tangents for mesh ");
								messageBuilder.AppendFormatted(x);
								messageBuilder.AppendLiteral(" ");
								messageBuilder.AppendFormatted(z);
								messageBuilder.AppendLiteral(".");
							}
							Log.Debug(messageBuilder);
							mesh.tangents = TangentSolver.CalculateMeshTangents(mesh.triangles, mesh.vertices, mesh.normals, mesh.uv);
						}
					}
					continue;
				}
				meshLevelUpdate = i;
				return false;
			}
			return true;
		}

		private void LoadFromZip()
		{
			updateMesh = false;
			ClearMeshData(chunkY);
			RecalculateMaxHeight();
			int x = chunkX / chunkSize;
			int z = chunkZ / chunkSize;
			if (!LoadFromZip(x, z))
			{
				StartMeshGeneratingThread();
			}
			else
			{
				this.ChunkGeneratedEvent?.Invoke();
			}
		}

		public void SaveToCache()
		{
			int x = chunkX / chunkSize;
			int z = chunkZ / chunkSize;
			for (int i = 0; i < mapSizeY; i++)
			{
				if (i < meshCache.Length && !(meshCache[i] == null) && meshCache[i].vertexCount != 0)
				{
					SaveToCache(x, z, i);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SaveToCache(int x, int z, int cacheIndex)
		{
			byte[] data = MeshSerializer.SerializeMesh(meshCache[cacheIndex]);
			GlobalSaveController.CurrentVillageData.CacheWriteBytes(GetMeshNameInSave(x, z, cacheIndex), data);
		}
	}
}
