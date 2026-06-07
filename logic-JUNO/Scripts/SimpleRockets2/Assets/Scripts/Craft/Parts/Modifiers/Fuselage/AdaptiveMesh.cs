using System;
using System.Collections.Generic;
using Assets.Scripts.Tools;
using ModApi.Common.Meshes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Fuselage
{
	public class AdaptiveMesh
	{
		private class MeshDataCache
		{
			private const int _CacheSize = 4;

			private static int _currentIndex;

			private static int[] _indexByAge;

			private static Vector3[][] _normals;

			private static Vector4[][] _tangents;

			private static Vector3[][] _tempArray1;

			private static Vector3[][] _tempArray2;

			private static List<Vector4>[] _uvs;

			private static Vector3[][] _vertices;

			public Vector3[] Normals => _normals[_currentIndex];

			public Vector3[] OriginalNormals { get; private set; }

			public Vector2[] OriginalUV2s { get; private set; }

			public Vector2[] OriginalUVs { get; private set; }

			public Vector4[] Tangents => _tangents[_currentIndex];

			public Vector3[] TempArray1 => _tempArray1[_currentIndex];

			public Vector3[] TempArray2 => _tempArray2[_currentIndex];

			public int[] Triangles { get; private set; }

			public List<Vector4> UVs => _uvs[_currentIndex];

			public int VertexCount { get; private set; }

			public Vector3[] Vertices => _vertices[_currentIndex];

			static MeshDataCache()
			{
				_currentIndex = 0;
				_indexByAge = new int[4];
				_vertices = new Vector3[4][];
				_uvs = new List<Vector4>[4];
				_normals = new Vector3[4][];
				_tangents = new Vector4[4][];
				_tempArray1 = new Vector3[4][];
				_tempArray2 = new Vector3[4][];
				for (int i = 0; i < 4; i++)
				{
					_indexByAge[i] = i;
					Initialize(i, 0);
				}
			}

			public MeshDataCache(int[] triangles, Vector2[] uvs, Vector2[] uv2s, Vector3[] normals, int vertexCount)
			{
				Triangles = triangles;
				OriginalUVs = uvs;
				OriginalUV2s = uv2s;
				OriginalNormals = normals;
				VertexCount = vertexCount;
			}

			public void Update()
			{
				int vertexCount = VertexCount;
				int num = -1;
				for (int i = 0; i < 4; i++)
				{
					if (_vertices[i].Length == vertexCount)
					{
						num = i;
						break;
					}
				}
				if (num == -1)
				{
					num = _indexByAge[3];
					Initialize(num, vertexCount);
				}
				int num2 = -1;
				for (int j = 0; j < 4; j++)
				{
					if (_indexByAge[j] == num)
					{
						num2 = j;
						break;
					}
				}
				for (int num3 = num2; num3 > 0; num3--)
				{
					_indexByAge[num3] = _indexByAge[num3 - 1];
				}
				_indexByAge[0] = num;
				_currentIndex = num;
			}

			private static void Initialize(int index, int vertexCount)
			{
				_vertices[index] = new Vector3[vertexCount];
				_uvs[index] = new List<Vector4>(vertexCount);
				_normals[index] = new Vector3[vertexCount];
				_tangents[index] = new Vector4[vertexCount];
				_tempArray1[index] = new Vector3[vertexCount];
				_tempArray2[index] = new Vector3[vertexCount];
			}
		}

		private Vector3[] _designerBaseNormals;

		private MeshDataCache _meshDataCache;

		private bool _tileable;

		private bool _updated;

		public AnimationCurve DepthCurve { get; set; }

		public MeshCollider MeshCollider { get; private set; }

		public MeshFilter MeshFilter { get; private set; }

		public bool UseSimpleRadialScaling { get; }

		public List<AdaptiveVertex> Vertices { get; private set; }

		public AdaptiveMesh(MeshFilter meshFilter, bool anchorsEnabled, bool tileableTexture, bool useSimpleRadialScaling, MeshCollider meshCollider)
		{
			MeshFilter = meshFilter;
			MeshCollider = meshCollider;
			Vertices = new List<AdaptiveVertex>();
			_tileable = tileableTexture;
			UseSimpleRadialScaling = useSimpleRadialScaling;
			Mesh mesh = meshFilter.mesh;
			Vector3[] vertices = mesh.vertices;
			Vector2[] uv = mesh.uv2;
			for (short num = 0; num < vertices.Length; num++)
			{
				Vector3 vector = vertices[num];
				float? anchor = null;
				if (anchorsEnabled && uv != null && uv.Length != 0 && Mathf.Abs(uv[num].y) > 0.01f)
				{
					anchor = uv[num].y;
				}
				AdaptiveVertex item = new AdaptiveVertex(cornerIndex: (short)((!(vector.x < 0f) || !(vector.z > 0f)) ? ((vector.x > 0f && vector.z > 0f) ? 1 : ((!(vector.x > 0f) || !(vector.z < 0f)) ? 3 : 2)) : 0), v: new Vector2(vector.x, vector.z), depth: vector.y, anchor: anchor, index: num, useSimpleRadialScaling: useSimpleRadialScaling);
				Vertices.Add(item);
			}
		}

		public void Update(FuselageData data, MeshDefinitionScript meshDefinition, bool isReference = false)
		{
			meshDefinition.FlattenTopNormals = false;
			meshDefinition.FlattenBottomNormals = false;
			Update(meshDefinition, data.TopScale, data.BottomScale, data.CornerRadiuses, data.Offset, data.NormalSmoothingAngle, data.Deformations, data.ClampDistances, data.WallThickness, isReference);
		}

		public void Update(MeshDefinitionScript meshDefinition, Vector2 topScale, Vector2 bottomScale, float[] cornerRadiuses, Vector3 offset, float normalSmoothingAngle, Vector3 deformation = default(Vector3), float[] clampDistances = null, float[] wallThickness = null, bool isReference = false)
		{
			if (_updated && Game.InFlightScene && !isReference)
			{
				Debug.LogError("AdaptiveMesh.Update called multiple times in the Flight scene.", meshDefinition?.gameObject);
			}
			_updated = true;
			Mesh mesh = MeshFilter.mesh;
			MeshDataCache meshDataCache = GetMeshDataCache();
			Vector2[] originalUVs = meshDataCache.OriginalUVs;
			List<Vector4> uVs = meshDataCache.UVs;
			mesh.GetUVs(0, uVs);
			float num = 1f / (Mathf.Max((bottomScale.x + bottomScale.y) / 2f, (topScale.x + topScale.y) / 2f) * MathF.PI);
			foreach (AdaptiveVertex vertex in Vertices)
			{
				float num2 = vertex.Depth;
				if (vertex.Anchor.HasValue)
				{
					float num3 = vertex.Depth - vertex.Anchor.Value;
					num2 = vertex.Anchor.Value + num3 / offset.y;
					if (Mathf.Sign(num2) != Mathf.Sign(vertex.Depth))
					{
						num2 = 0f;
					}
				}
				float num4 = Mathf.Clamp01((num2 + 1f) / 2f);
				if (DepthCurve != null && DepthCurve.length > 0)
				{
					num4 = DepthCurve.Evaluate(num4);
				}
				else if (meshDefinition?.DepthCurve != null && meshDefinition.DepthCurve.length > 0)
				{
					num4 = meshDefinition.DepthCurve.Evaluate(num4);
				}
				Vector2 crossSectionScale = bottomScale * (1f - num4) + topScale * num4;
				float cornerRadius = cornerRadiuses[vertex.CornerIndex + 4] * (1f - num4) + cornerRadiuses[vertex.CornerIndex] * num4;
				float pinch = deformation.z * (1f - num4) + deformation.x * num4;
				float wallThickness2 = 1f;
				if (wallThickness != null)
				{
					wallThickness2 = wallThickness[1] * (1f - num4) + wallThickness[0] * num4;
				}
				Vector3 crossSectionOffset = offset * num2;
				float slant = 2f * offset.y * deformation.y * num4;
				Vector2 vector;
				Vector2 clampX;
				if (clampDistances == null)
				{
					vector = new Vector2(float.NegativeInfinity, float.PositiveInfinity);
					clampX = vector;
				}
				else
				{
					clampX = Vector2.Lerp(new Vector2(clampDistances[4], clampDistances[5]), new Vector2(clampDistances[0], clampDistances[1]), num4);
					vector = Vector2.Lerp(new Vector2(clampDistances[6], clampDistances[7]), new Vector2(clampDistances[2], clampDistances[3]), num4);
				}
				vertex.UpdateVertex(meshDataCache.Vertices, crossSectionScale, crossSectionOffset, cornerRadius, pinch, slant, clampX, vector, wallThickness2, UseSimpleRadialScaling);
				if (!(MeshCollider == null) || vertex.Index >= originalUVs.Length)
				{
					continue;
				}
				Vector2 vector2 = originalUVs[vertex.Index];
				if ((double)vector2.x >= 0.0 || (double)vector2.y >= 0.0)
				{
					float magnitude = new Vector3(crossSectionScale.x, 0f, crossSectionScale.y).magnitude;
					if (_tileable)
					{
						vector2.y = meshDataCache.Vertices[vertex.Index].y * num;
					}
					uVs[vertex.Index] = new Vector4(vector2.x * magnitude, vector2.y * magnitude, magnitude - 1f, uVs[vertex.Index].w);
				}
			}
			mesh.vertices = meshDataCache.Vertices;
			if (MeshCollider == null)
			{
				NormalSolver.Options options = NormalSolver.Options.None;
				if (meshDefinition.FlattenTopNormals)
				{
					options |= NormalSolver.Options.FlattenTop;
				}
				if (meshDefinition.FlattenBottomNormals)
				{
					options |= NormalSolver.Options.FlattenBottom;
				}
				Vector3[] normals = meshDataCache.Normals;
				if (!Game.InFlightScene)
				{
					if (_designerBaseNormals == null || _designerBaseNormals.Length != mesh.vertexCount)
					{
						_designerBaseNormals = new Vector3[mesh.vertexCount];
					}
					normals = _designerBaseNormals;
				}
				NormalSolver.RecalculateNormals(normalSmoothingAngle, meshDataCache.Triangles, meshDataCache.Vertices, normals, meshDataCache.OriginalUV2s, meshDataCache.OriginalNormals, options);
				if (originalUVs.Length != 0)
				{
					MeshTangentGenerator.CalculateTangents(meshDataCache.Triangles, meshDataCache.Vertices, originalUVs, normals, meshDataCache.TempArray1, meshDataCache.TempArray2, meshDataCache.Tangents);
					mesh.tangents = meshDataCache.Tangents;
				}
				mesh.normals = normals;
				mesh.SetUVs(0, uVs);
				mesh.RecalculateBounds();
			}
			else
			{
				MeshCollider.sharedMesh = null;
				if ((topScale.x != 0f || bottomScale.x != 0f) && (topScale.y != 0f || bottomScale.y != 0f))
				{
					MeshCollider.sharedMesh = MeshFilter.mesh;
					return;
				}
				PartScript componentInParent = MeshCollider.GetComponentInParent<PartScript>();
				Debug.LogError($"Could not update adaptive mesh collider for part {componentInParent?.Data.Name} (ID {componentInParent?.Data.Id}) because it had top or bottom scale with a 0 component.");
			}
		}

		public void RevertNormalsToLastUpdate()
		{
			if (Game.InFlightScene || MeshFilter.mesh.normals.Length != MeshFilter.mesh.vertexCount)
			{
				Debug.LogError("Cannot revert normals");
			}
			else
			{
				MeshFilter.mesh.normals = _designerBaseNormals;
			}
		}

		private MeshDataCache GetMeshDataCache()
		{
			if (_meshDataCache == null)
			{
				Mesh mesh = MeshFilter.mesh;
				MeshDataCache meshDataCache = new MeshDataCache(mesh.triangles, mesh.uv, mesh.uv2, mesh.normals, Vertices.Count);
				if (!Game.InDesignerScene)
				{
					meshDataCache.Update();
					return meshDataCache;
				}
				_meshDataCache = meshDataCache;
			}
			_meshDataCache.Update();
			return _meshDataCache;
		}
	}
}
