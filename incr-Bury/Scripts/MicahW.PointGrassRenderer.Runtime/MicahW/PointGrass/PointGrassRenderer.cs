using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace MicahW.PointGrass
{
	[ExecuteAlways]
	public class PointGrassRenderer : MonoBehaviour
	{
		public struct DebugInformation
		{
			public int totalPointCount;

			public bool usingMultipleBuffers;

			public int bufferCount;

			public int smallestBuffer;

			public int largestBuffer;
		}

		[Header("Distribution Parameters")]
		public PointGrassCommon.DistributionSource distSource;

		public Mesh baseMesh;

		public TerrainData terrain;

		public TerrainLayer[] terrainLayers;

		public Vector2Int chunkCount = new Vector2Int(8, 8);

		public MeshFilter[] sceneFilters;

		private MeshFilter filter;

		[Header("Grass Parameters")]
		public PointGrassCommon.BladeType bladeType;

		public bool multipleMeshes;

		public Mesh grassBladeMesh;

		public Mesh[] grassBladeMeshes = new Mesh[1];

		public float[] meshDensityValues = new float[1] { 1f };

		public bool multipleMaterials;

		public Material material;

		public Material[] materials = new Material[1];

		public ShadowCastingMode shadowMode = ShadowCastingMode.On;

		public SingleLayer renderLayer;

		[Header("Point Parameters")]
		public float pointCount = 1000f;

		public bool multiplyByArea;

		[Range(0f, 1f)]
		public float pointLODFactor = 1f;

		public bool randomiseSeed = true;

		public int seed;

		public bool overwriteNormalDirection;

		public Vector3 forcedNormal = Vector3.up;

		public bool useDensity = true;

		[Range(0f, 1f)]
		public float densityCutoff = 0.5f;

		public bool useLength = true;

		public Vector2 lengthMapping = new Vector2(0f, 1f);

		private ComputeBuffer pointBuffer;

		private MaterialPropertyBlock materialBlock;

		private Bounds boundingBox;

		private ComputeBuffer[] pointBuffers;

		private MaterialPropertyBlock[] materialBlocks;

		private Bounds[] boundingBoxes;

		[Header("Projection Parameters")]
		public PointGrassCommon.ProjectionType projectType;

		public LayerMask projectMask = -1;

		[Header("Bounding Box Parameters")]
		public Bounds boundingBoxOffset = new Bounds(Vector3.zero, Vector3.one);

		private bool UsingMultipleMeshes
		{
			get
			{
				if (bladeType == PointGrassCommon.BladeType.Mesh)
				{
					return multipleMeshes;
				}
				return false;
			}
		}

		private void Reset()
		{
			ClearBuffers();
			bladeType = PointGrassCommon.BladeType.Flat;
			multipleMeshes = false;
			grassBladeMesh = null;
			grassBladeMeshes = new Mesh[1];
			meshDensityValues = new float[1] { 1f };
			multipleMaterials = false;
			material = null;
			materials = new Material[1];
			shadowMode = ShadowCastingMode.On;
			renderLayer.Set(base.gameObject.layer);
			pointCount = 1000f;
			multiplyByArea = false;
			pointLODFactor = 1f;
			randomiseSeed = true;
			seed = 0;
			overwriteNormalDirection = false;
			forcedNormal = Vector3.up;
			useDensity = true;
			densityCutoff = 0.5f;
			useLength = true;
			projectType = PointGrassCommon.ProjectionType.None;
			projectMask = -1;
		}

		private void OnEnable()
		{
			if (CompatibilityCheck())
			{
				if (!PointGrassCommon.PropertyIDsInitialized)
				{
					PointGrassCommon.FindPropertyIDs();
				}
				if (PointGrassCommon.grassMeshFlat == null || PointGrassCommon.grassMeshCyl == null)
				{
					PointGrassCommon.GenerateGrassMeshes();
				}
				BuildPoints();
			}
		}

		private void OnDisable()
		{
			ClearBuffers();
		}

		private void LateUpdate()
		{
			DrawGrass();
		}

		private bool CompatibilityCheck()
		{
			if (!SystemInfo.supportsInstancing)
			{
				Debug.LogError("This system doesn't support instanced draw calls. \"" + base.gameObject.name + "\" is unable to render its point grass");
				Disable();
				return false;
			}
			if (SystemInfo.graphicsShaderLevel < 45)
			{
				Debug.LogError("This system doesn't support shader model 4.5. Compute buffers are unsupported in the point grass shaders");
				Disable();
				return false;
			}
			return true;
			void Disable()
			{
				UnityEngine.Object.Destroy(this);
			}
		}

		public void BuildPoints()
		{
			ClearBuffers();
			int num = (randomiseSeed ? UnityEngine.Random.Range(int.MinValue, int.MaxValue) : seed);
			Vector3? overwriteNormal = null;
			if (overwriteNormalDirection)
			{
				forcedNormal = forcedNormal.normalized;
				overwriteNormal = base.transform.InverseTransformDirection(forcedNormal);
			}
			if (distSource == PointGrassCommon.DistributionSource.TerrainData && chunkCount.x > 1 && chunkCount.y > 1)
			{
				BuildPoints_Terrain(num, overwriteNormal);
			}
			else
			{
				BuildPoints_Mesh(num, overwriteNormal);
			}
		}

		private void BuildPoints_Mesh(int seed, Vector3? overwriteNormal)
		{
			if (GetMeshData(out var meshData))
			{
				if (projectType == PointGrassCommon.ProjectionType.ProjectMesh)
				{
					PointGrassCommon.ProjectBaseMesh(ref meshData, projectMask, base.transform);
				}
				boundingBox = meshData.bounds;
				PointGrassCommon.MeshPoint[] array = DistributePointsAlongMesh.DistributePoints(meshData, base.transform.localScale, pointCount, seed, multiplyByArea, overwriteNormal, useColours: true, useDensity, useLength, densityCutoff, lengthMapping);
				if (array != null && array.Length != 0)
				{
					CreateBuffers(array);
				}
			}
		}

		private void BuildPoints_Terrain(int seed, Vector3? overwriteNormal)
		{
			List<ComputeBuffer> list = new List<ComputeBuffer>();
			List<MaterialPropertyBlock> list2 = new List<MaterialPropertyBlock>();
			List<Bounds> list3 = new List<Bounds>();
			Vector3 size = terrain.size;
			size.x /= chunkCount.x;
			size.z /= chunkCount.y;
			PointGrassCommon.CacheTerrainData(terrain, terrainLayers);
			for (int i = 0; i < chunkCount.x; i++)
			{
				for (int j = 0; j < chunkCount.y; j++)
				{
					if (!GetTerrainMeshData(out var meshData, new Vector2Int(i, j)))
					{
						continue;
					}
					int num = seed + i + j * chunkCount.x;
					PointGrassCommon.MeshPoint[] array = DistributePointsAlongMesh.DistributePoints(meshData, base.transform.localScale, pointCount, num, multiplyByArea, overwriteNormal, useColours: true, useDensity, useLength, -1f, lengthMapping);
					if (array == null || array.Length == 0)
					{
						continue;
					}
					if (UsingMultipleMeshes)
					{
						CreateBuffersFromPoints_Multi(array, out var buffers, out var blocks);
						if (buffers == null)
						{
							continue;
						}
						list.AddRange(buffers);
						list2.AddRange(blocks);
					}
					else
					{
						CreateBufferFromPoints(array, out var buffer, out var block);
						list.Add(buffer);
						list2.Add(block);
					}
					Bounds item = new Bounds(array[0].position, Vector3.zero);
					for (int k = 1; k < array.Length; k++)
					{
						item.Encapsulate(array[k].position);
					}
					list3.Add(item);
				}
			}
			if (list.Count > 0)
			{
				pointBuffers = list.ToArray();
				materialBlocks = list2.ToArray();
				boundingBoxes = list3.ToArray();
			}
		}

		private bool GetMeshData(out PointGrassCommon.MeshData meshData)
		{
			meshData = PointGrassCommon.MeshData.Empty;
			switch (distSource)
			{
			case PointGrassCommon.DistributionSource.Mesh:
				if (!(baseMesh == null))
				{
					Vector2[] array = new Vector2[baseMesh.vertexCount];
					if (baseMesh.colors != null && baseMesh.colors.Length == baseMesh.vertexCount && (useDensity || useLength))
					{
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = new Vector2(baseMesh.colors[i].r, baseMesh.colors[i].g);
						}
					}
					else
					{
						for (int j = 0; j < array.Length; j++)
						{
							array[j] = Vector2.one;
						}
					}
					meshData = new PointGrassCommon.MeshData(baseMesh.vertices, baseMesh.normals, baseMesh.uv, baseMesh.triangles, array);
					return true;
				}
				goto case PointGrassCommon.DistributionSource.MeshFilter;
			case PointGrassCommon.DistributionSource.MeshFilter:
			{
				filter = GetComponent<MeshFilter>();
				if (!(filter != null))
				{
					break;
				}
				baseMesh = filter.sharedMesh;
				if (!(baseMesh != null))
				{
					break;
				}
				Vector2[] array2 = new Vector2[baseMesh.vertexCount];
				if (baseMesh.colors != null && baseMesh.colors.Length == baseMesh.vertexCount && (useDensity || useLength))
				{
					for (int k = 0; k < array2.Length; k++)
					{
						array2[k] = new Vector2(baseMesh.colors[k].r, baseMesh.colors[k].g);
					}
				}
				else
				{
					for (int l = 0; l < array2.Length; l++)
					{
						array2[l] = Vector2.one;
					}
				}
				meshData = new PointGrassCommon.MeshData(baseMesh.vertices, baseMesh.normals, baseMesh.uv, baseMesh.triangles, array2);
				return true;
			}
			case PointGrassCommon.DistributionSource.TerrainData:
				PointGrassCommon.CacheTerrainData(terrain, terrainLayers);
				return GetTerrainMeshData(out meshData, Vector2Int.zero);
			case PointGrassCommon.DistributionSource.SceneFilters:
				if (sceneFilters != null && sceneFilters.Length != 0)
				{
					meshData = PointGrassCommon.CreateMeshFromFilters(base.transform, sceneFilters);
					if (meshData.verts.Length != 0)
					{
						return true;
					}
				}
				break;
			}
			return false;
		}

		private bool GetTerrainMeshData(out PointGrassCommon.MeshData meshData, Vector2Int chunkCoord)
		{
			meshData = PointGrassCommon.MeshData.Empty;
			if (terrain != null && terrainLayers != null)
			{
				int heightmapResolution = terrain.heightmapResolution;
				int num = Mathf.FloorToInt((float)heightmapResolution * (float)chunkCoord.x / (float)chunkCount.x);
				int num2 = Mathf.FloorToInt((float)heightmapResolution * (float)chunkCoord.y / (float)chunkCount.y);
				int num3 = Mathf.CeilToInt((float)heightmapResolution * (float)(chunkCoord.x + 1) / (float)chunkCount.x);
				int num4 = Mathf.CeilToInt((float)heightmapResolution * (float)(chunkCoord.y + 1) / (float)chunkCount.y);
				float num5 = (useDensity ? densityCutoff : 0f);
				meshData = PointGrassCommon.CreateMeshFromTerrainData(terrain, num5, num, num2, num3 - num, num4 - num2);
				return true;
			}
			return false;
		}

		private void CreateBuffers(PointGrassCommon.MeshPoint[] points)
		{
			if (UsingMultipleMeshes)
			{
				CreateBuffersFromPoints_Multi(points, out pointBuffers, out materialBlocks);
			}
			else
			{
				CreateBufferFromPoints(points, out pointBuffer, out materialBlock);
			}
		}

		private void ClearBuffers()
		{
			if (pointBuffer != null)
			{
				pointBuffer.Release();
			}
			if (pointBuffers != null)
			{
				for (int i = 0; i < pointBuffers.Length; i++)
				{
					pointBuffers[i].Release();
				}
				pointBuffers = null;
			}
			if (boundingBoxes != null)
			{
				boundingBoxes = null;
			}
		}

		private void CreateBufferFromPoints(PointGrassCommon.MeshPoint[] points, out ComputeBuffer buffer, out MaterialPropertyBlock block)
		{
			if (points == null || points.Length == 0)
			{
				buffer = null;
				block = null;
			}
			else
			{
				buffer = new ComputeBuffer(points.Length, 56);
				buffer.SetData(points);
				block = CreateMaterialPropertyBlock(buffer);
			}
		}

		private void CreateBuffersFromPoints_Multi(PointGrassCommon.MeshPoint[] points, out ComputeBuffer[] buffers, out MaterialPropertyBlock[] blocks)
		{
			if (points == null || points.Length == 0)
			{
				buffers = null;
				blocks = null;
				return;
			}
			int num = points.Length;
			int num2 = grassBladeMeshes.Length;
			if (num < num2)
			{
				buffers = null;
				blocks = null;
				return;
			}
			float num3 = 0f;
			float[] array = new float[num2];
			for (int i = 0; i < num2; i++)
			{
				num3 += meshDensityValues[i];
			}
			if (num3 <= 0f)
			{
				float num4 = 1f / (float)num2;
				for (int j = 0; j < num2; j++)
				{
					array[j] = num4;
				}
			}
			else
			{
				for (int k = 0; k < num2; k++)
				{
					array[k] = meshDensityValues[k] / num3;
				}
			}
			buffers = new ComputeBuffer[num2];
			blocks = new MaterialPropertyBlock[num2];
			int num5 = 0;
			for (int l = 0; l < num2; l++)
			{
				int b = Mathf.RoundToInt((float)num * array[l]);
				int num6 = num - num5;
				int num7 = num2 - l - 1;
				int num8 = Mathf.Max(1, Mathf.Min(num6 - num7, b));
				buffers[l] = new ComputeBuffer(num8, 56);
				buffers[l].SetData(points, num5, 0, num8);
				blocks[l] = CreateMaterialPropertyBlock(buffers[l]);
				num5 += num8;
			}
		}

		private void DrawGrass()
		{
			if (pointBuffer == null && pointBuffers == null)
			{
				return;
			}
			Mesh mesh = GetGrassMesh();
			Material mat = material;
			Bounds bounds = TransformBounds(GetLocalBounds());
			bool flag = pointBuffers != null && pointBuffers.Length != 0;
			bool flag2 = UsingMultipleMeshes && grassBladeMeshes != null && flag;
			bool flag3 = multipleMaterials && materials != null && flag;
			if (boundingBoxes != null && boundingBoxes.Length != 0)
			{
				if (flag)
				{
					int num = pointBuffers.Length / boundingBoxes.Length;
					flag2 &= grassBladeMeshes.Length >= num;
					flag3 &= materials.Length >= num;
					for (int i = 0; i < boundingBoxes.Length; i++)
					{
						bounds = TransformBounds(boundingBoxes[i]);
						for (int j = 0; j < num; j++)
						{
							int num2 = i * num + j;
							if (flag2)
							{
								mesh = grassBladeMeshes[j];
								if (flag3)
								{
									mat = materials[j];
								}
							}
							DrawGrassBuffer(pointBuffers[num2], ref materialBlocks[num2], mesh, mat, bounds);
						}
					}
				}
				else
				{
					DrawGrassBuffer(pointBuffer, ref materialBlock, mesh, mat, TransformBounds(boundingBoxes[0]));
				}
			}
			else if (flag)
			{
				flag2 &= grassBladeMeshes.Length >= pointBuffers.Length;
				flag3 &= materials.Length >= pointBuffers.Length;
				for (int k = 0; k < pointBuffers.Length; k++)
				{
					if (flag2)
					{
						mesh = grassBladeMeshes[k];
						if (flag3)
						{
							mat = materials[k];
						}
					}
					DrawGrassBuffer(pointBuffers[k], ref materialBlocks[k], mesh, mat, bounds);
				}
			}
			else
			{
				DrawGrassBuffer(pointBuffer, ref materialBlock, mesh, mat, bounds);
			}
		}

		private void DrawGrassBuffer(ComputeBuffer buffer, ref MaterialPropertyBlock block, Mesh mesh, Material mat, Bounds bounds)
		{
			if (buffer != null && buffer.IsValid())
			{
				int num = Mathf.CeilToInt((float)buffer.count * pointLODFactor);
				if (mesh != null && mat != null && block != null && num > 0)
				{
					bounds = AddBoundsExtrusion(bounds);
					PointGrassCommon.UpdateMaterialPropertyBlock(ref block, base.transform);
					Graphics.DrawMeshInstancedProcedural(mesh, 0, mat, bounds, num, block, shadowMode, receiveShadows: true, renderLayer.LayerIndex);
				}
			}
		}

		private MaterialPropertyBlock CreateMaterialPropertyBlock(ComputeBuffer pointBuffer)
		{
			MaterialPropertyBlock block = new MaterialPropertyBlock();
			block.SetBuffer(PointGrassCommon.ID_PointBuff, pointBuffer);
			PointGrassCommon.UpdateMaterialPropertyBlock(ref block, base.transform);
			return block;
		}

		private Mesh GetGrassMesh()
		{
			return bladeType switch
			{
				PointGrassCommon.BladeType.Flat => PointGrassCommon.grassMeshFlat, 
				PointGrassCommon.BladeType.Cylindrical => PointGrassCommon.grassMeshCyl, 
				PointGrassCommon.BladeType.Mesh => grassBladeMesh, 
				_ => throw new ArgumentException("Invalid enum value"), 
			};
		}

		public Bounds GetLocalBounds()
		{
			switch (distSource)
			{
			case PointGrassCommon.DistributionSource.Mesh:
			case PointGrassCommon.DistributionSource.MeshFilter:
				return boundingBox;
			case PointGrassCommon.DistributionSource.TerrainData:
				if (!(terrain == null))
				{
					return new Bounds(terrain.size * 0.5f, terrain.size);
				}
				break;
			case PointGrassCommon.DistributionSource.SceneFilters:
				return boundingBox;
			}
			return new Bounds(Vector3.zero, Vector3.one);
		}

		private Bounds TransformBounds(Bounds localBounds)
		{
			Vector3 min = localBounds.min;
			Vector3 max = localBounds.max;
			Vector3[] array = new Vector3[8]
			{
				min,
				max,
				new Vector3(max.x, min.y, min.z),
				new Vector3(min.x, max.y, min.z),
				new Vector3(min.x, min.y, max.z),
				new Vector3(min.x, max.y, max.z),
				new Vector3(max.x, min.y, max.z),
				new Vector3(max.x, max.y, min.z)
			};
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = base.transform.TransformPoint(array[i]);
			}
			localBounds = new Bounds(array[0], Vector3.zero);
			for (int j = 1; j < array.Length; j++)
			{
				localBounds.Encapsulate(array[j]);
			}
			return localBounds;
		}

		private Bounds AddBoundsExtrusion(Bounds worldSpaceBounds)
		{
			worldSpaceBounds.center += boundingBoxOffset.center;
			worldSpaceBounds.size += boundingBoxOffset.size;
			return worldSpaceBounds;
		}

		public void SetDistributionSource(Mesh mesh)
		{
			if (mesh == null)
			{
				Debug.LogError("An attempt was made to set the distribution source on \"" + base.gameObject.name + "\" to null. Make sure the input distribution source is not null");
				return;
			}
			distSource = PointGrassCommon.DistributionSource.Mesh;
			baseMesh = mesh;
		}

		public void SetDistributionSource(MeshFilter filter)
		{
			if (filter == null)
			{
				Debug.LogError("An attempt was made to set the distribution source on \"" + base.gameObject.name + "\" to null. Make sure the input distribution source is not null");
				return;
			}
			if (filter.gameObject == base.gameObject)
			{
				distSource = PointGrassCommon.DistributionSource.MeshFilter;
				return;
			}
			SetDistributionSource(new MeshFilter[1] { filter });
		}

		public void SetDistributionSource(TerrainData terrain)
		{
			if (terrain == null)
			{
				Debug.LogError("An attempt was made to set the distribution source on \"" + base.gameObject.name + "\" to null. Make sure the input distribution source is not null");
				return;
			}
			distSource = PointGrassCommon.DistributionSource.TerrainData;
			this.terrain = terrain;
		}

		public void SetDistributionSource(MeshFilter[] sceneFilters)
		{
			if (sceneFilters == null)
			{
				Debug.LogError("An attempt was made to set the distribution source on \"" + base.gameObject.name + "\" to null. Make sure the input distribution source is not null");
				return;
			}
			distSource = PointGrassCommon.DistributionSource.SceneFilters;
			this.sceneFilters = sceneFilters;
		}

		public void SetBladeType(PointGrassCommon.BladeType type)
		{
			bladeType = type;
		}

		public void SetBladeMesh(Mesh mesh)
		{
			if (mesh == null)
			{
				Debug.LogError("An attempt was made to set the blade mesh on \"" + base.gameObject.name + "\" to null or an empty array. Make sure the input blade mesh is not null");
				return;
			}
			SetBladeType(PointGrassCommon.BladeType.Mesh);
			grassBladeMesh = mesh;
			multipleMeshes = false;
		}

		public void SetBladeMesh(Mesh[] meshes, float[] meshDensityValues = null, Material[] materials = null)
		{
			if (meshes == null || meshes.Length == 0)
			{
				Debug.LogError("An attempt was made to set the blade meshes on \"" + base.gameObject.name + "\" to null or an empty array. Make sure the input blade meshes are not null");
				return;
			}
			if (meshes.Length == 1)
			{
				SetBladeMesh(meshes[0]);
				return;
			}
			SetBladeType(PointGrassCommon.BladeType.Mesh);
			grassBladeMeshes = meshes;
			multipleMeshes = true;
			if (meshDensityValues != null && meshDensityValues.Length != 0)
			{
				this.meshDensityValues = meshDensityValues;
			}
			if (this.meshDensityValues.Length != meshes.Length)
			{
				Array.Resize(ref this.meshDensityValues, meshes.Length);
			}
			if (materials != null && materials.Length != 0)
			{
				SetMaterials(materials);
			}
		}

		public void SetBladeDensities(float[] densities)
		{
			if (densities == null || densities.Length == 0)
			{
				Debug.LogError("An attempt was made to set the blade densities on \"" + base.gameObject.name + "\" to null or an empty array. Make sure the input blade densities are not null");
				return;
			}
			if (densities.Length != grassBladeMeshes.Length)
			{
				Array.Resize(ref densities, grassBladeMeshes.Length);
			}
			meshDensityValues = densities;
		}

		public void SetMaterial(Material mat)
		{
			if (mat == null)
			{
				Debug.LogError("An attempt was made to set the blade material on \"" + base.gameObject.name + "\" to null or an empty array. Make sure the input blade material is not null");
				return;
			}
			multipleMaterials = false;
			material = mat;
		}

		public void SetMaterials(Material[] materials)
		{
			if (materials == null || materials.Length == 0)
			{
				Debug.LogError("An attempt was made to set the blade materials on \"" + base.gameObject.name + "\" to null or an empty array. Make sure the input blade materials are not null");
				return;
			}
			if (materials.Length == 1)
			{
				SetMaterial(materials[0]);
				return;
			}
			multipleMaterials = true;
			if (materials.Length != grassBladeMeshes.Length)
			{
				Array.Resize(ref materials, grassBladeMeshes.Length);
			}
			this.materials = materials;
		}

		public void SetShadowMode(ShadowCastingMode mode)
		{
			shadowMode = mode;
		}

		public void SetRenderLayer(int layer)
		{
			renderLayer.Set(layer);
		}

		public void SetRenderLayer(SingleLayer layer)
		{
			renderLayer = layer;
		}

		public void SetPointCount(float count, bool multiplyByArea = false)
		{
			pointCount = count;
			this.multiplyByArea = multiplyByArea;
		}

		public void SetPointLODFactor(float value)
		{
			pointLODFactor = Mathf.Clamp01(value);
		}

		public void SetSeed(int seed)
		{
			randomiseSeed = false;
			this.seed = seed;
		}

		public void SetSeed(bool randomise)
		{
			randomiseSeed = randomise;
		}

		public void SetOverwriteNormal(Vector3 normal)
		{
			overwriteNormalDirection = true;
			forcedNormal = normal.normalized;
		}

		public void SetOverwriteNormal(bool enabled)
		{
			overwriteNormalDirection = enabled;
		}

		public void SetDensity(bool enabled, float cutoff = 0.5f)
		{
			useDensity = enabled;
			densityCutoff = cutoff;
		}

		public void SetLength(bool enabled, float rangeMin = 0.25f, float rangeMax = 1f)
		{
			useLength = enabled;
			lengthMapping = new Vector2(rangeMin, rangeMax);
		}

		public void SetProjection(PointGrassCommon.ProjectionType type, LayerMask mask)
		{
			projectType = type;
			projectMask = mask;
		}

		public void SetBoundingBoxOffset(Bounds bounds)
		{
			boundingBoxOffset = bounds;
		}

		public DebugInformation GetDebugInfo()
		{
			if (!base.enabled)
			{
				return new DebugInformation
				{
					totalPointCount = 0,
					usingMultipleBuffers = false,
					bufferCount = 0,
					smallestBuffer = 0,
					largestBuffer = 0
				};
			}
			DebugInformation result = new DebugInformation
			{
				usingMultipleBuffers = (pointBuffers != null)
			};
			if (result.usingMultipleBuffers)
			{
				int num = int.MaxValue;
				int num2 = int.MinValue;
				for (int i = 0; i < pointBuffers.Length; i++)
				{
					if (pointBuffers[i] != null && pointBuffers[i].IsValid())
					{
						int count = pointBuffers[i].count;
						result.totalPointCount += pointBuffers[i].count;
						if (count < num)
						{
							num = count;
						}
						if (count > num2)
						{
							num2 = count;
						}
					}
				}
				result.bufferCount = pointBuffers.Length;
				result.smallestBuffer = num;
				result.largestBuffer = num2;
			}
			else if (pointBuffer != null && pointBuffer.IsValid())
			{
				result.totalPointCount = pointBuffer.count;
				result.bufferCount = 1;
				result.smallestBuffer = result.totalPointCount;
				result.largestBuffer = result.totalPointCount;
			}
			return result;
		}
	}
}
