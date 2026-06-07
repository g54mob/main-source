using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Jundroo.Common.Coroutines;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft
{
	public class PartGroupScript : MonoBehaviour
	{
		public delegate void PartGroupDelegate(PartGroupScript partGroup);

		protected struct CombinedMeshVertex
		{
			public Vector3 Position;

			public Vector3 Normal;

			public Vector2 UV0;

			public Vector3 UV1;

			public Vector3 UV2;

			public Vector3 UV3;
		}

		[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
		protected struct CombineJob : IJob
		{
			public Mesh.MeshData DestinationMesh;

			[ReadOnly]
			[NoAlias]
			public NativeArray<PartDragType> DragTypes;

			[ReadOnly]
			[NoAlias]
			public NativeArray<Matrix4x4> Matrices;

			[ReadOnly]
			public Mesh.MeshDataArray SourceMeshes;

			[ReadOnly]
			public int VertexCount;

			public void Execute()
			{
				NativeArray<CombinedMeshVertex> vertexData = DestinationMesh.GetVertexData<CombinedMeshVertex>();
				NativeArray<ushort> indexData = DestinationMesh.GetIndexData<ushort>();
				int num = 0;
				int num2 = 0;
				int length = SourceMeshes.Length;
				for (int i = 0; i < length; i++)
				{
					Mesh.MeshData meshData = SourceMeshes[i];
					Matrix4x4 matrix4x = Matrices[i];
					int vertexCount = meshData.vertexCount;
					if (vertexCount == 0)
					{
						continue;
					}
					NativeArray<Vector3> outVertices = new NativeArray<Vector3>(vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					NativeArray<Vector3> outNormals = new NativeArray<Vector3>(vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					NativeArray<Vector2> outUVs = new NativeArray<Vector2>(vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					NativeArray<Vector3> outUVs2 = new NativeArray<Vector3>(vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					NativeArray<Vector3> outUVs3 = new NativeArray<Vector3>(vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					NativeArray<Vector3> outUVs4 = new NativeArray<Vector3>(vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					meshData.GetVertices(outVertices);
					meshData.GetNormals(outNormals);
					if (meshData.HasVertexAttribute(VertexAttribute.TexCoord0))
					{
						meshData.GetUVs(0, outUVs);
					}
					if (meshData.HasVertexAttribute(VertexAttribute.TexCoord1))
					{
						meshData.GetUVs(1, outUVs2);
					}
					if (meshData.HasVertexAttribute(VertexAttribute.TexCoord2))
					{
						meshData.GetUVs(2, outUVs3);
					}
					if (meshData.HasVertexAttribute(VertexAttribute.TexCoord3))
					{
						meshData.GetUVs(3, outUVs4);
					}
					PartDragType partDragType = DragTypes[i];
					for (int j = 0; j < vertexCount; j++)
					{
						Vector3 uV = outUVs2[j];
						switch (partDragType)
						{
						case PartDragType.OccludeOnly:
							uV.z = 0f;
							break;
						case PartDragType.None:
							uV.z = -1f;
							break;
						}
						vertexData[j + num] = new CombinedMeshVertex
						{
							Position = matrix4x.MultiplyPoint3x4(outVertices[j]),
							Normal = matrix4x.MultiplyVector(outNormals[j]).normalized,
							UV0 = outUVs[j],
							UV1 = uV,
							UV2 = outUVs3[j],
							UV3 = outUVs4[j]
						};
					}
					outVertices.Dispose();
					outNormals.Dispose();
					outUVs.Dispose();
					outUVs2.Dispose();
					outUVs3.Dispose();
					outUVs4.Dispose();
					int subMeshCount = meshData.subMeshCount;
					for (int k = 0; k < subMeshCount; k++)
					{
						int indexCount = meshData.GetSubMesh(k).indexCount;
						NativeArray<ushort> outIndices = new NativeArray<ushort>(indexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
						meshData.GetIndices(outIndices, k, applyBaseVertex: false);
						for (int l = 0; l < indexCount; l++)
						{
							indexData[num2 + l] = (ushort)(outIndices[l] + num);
						}
						outIndices.Dispose();
						num2 += indexCount;
					}
					num += vertexCount;
				}
			}
		}

		protected class CombinedMeshPart
		{
			public PartScript Part;

			public Renderer Renderer;

			public int TriangleIndexCount;

			public int TriangleIndexStart;

			public CombinedMeshPart(PartScript part, Renderer renderer, int triangleIndexStart, int triangleIndexCount)
			{
				Part = part;
				Renderer = renderer;
				TriangleIndexStart = triangleIndexStart;
				TriangleIndexCount = triangleIndexCount;
			}
		}

		protected class PartMesh
		{
			public PartScript Part;

			public Renderer Renderer;

			public PartDragType DragType { get; set; }

			public int IndexCount { get; set; }

			public Matrix4x4 TransformMatrix { get; set; }

			public int VertexCount { get; set; }
		}

		protected class PartMeshSurvey
		{
			public Mesh.MeshDataArray? MeshData;

			public int IndexCount { get; set; }

			public int IndexCountSecondary { get; set; }

			public List<PartMesh> PartMeshes { get; private set; }

			public int SubmeshCount { get; set; }

			public int VertexCount { get; set; }

			public PartMeshSurvey()
			{
				PartMeshes = new List<PartMesh>();
			}
		}

		protected Mesh _combinedMesh;

		protected List<CombinedMeshPart> _combinedParts;

		protected PartMeshSurvey _partMeshSurvey;

		private RunOnceOnNextUpdate _initialize;

		private bool _initialized;

		private MeshFilter _meshFilter;

		private MeshRenderer _meshRenderer;

		public BodyScript Body { get; set; }

		public bool HasCockpit { get; set; }

		public int Id { get; set; }

		public Mesh Mesh => _combinedMesh;

		public List<PartScript> Parts { get; private set; }

		public Renderer Renderer => _meshRenderer;

		public event PartGroupDelegate Initialized
		{
			add
			{
				if (_initialized)
				{
					value(this);
				}
				else
				{
					_initializedEvent += value;
				}
			}
			remove
			{
				_initializedEvent -= value;
			}
		}

		private event PartGroupDelegate _initializedEvent;

		public void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
		}

		public void DecombineMesh()
		{
			if (_combinedParts == null || _combinedParts.Count == 0)
			{
				return;
			}
			foreach (CombinedMeshPart combinedPart in _combinedParts)
			{
				combinedPart.Renderer.enabled = true;
			}
			_combinedParts.Clear();
			_meshFilter.mesh = null;
			_meshRenderer.enabled = false;
			UnityEngine.Object.Destroy(_combinedMesh);
			_combinedMesh = null;
		}

		public void DecombineMesh(PartScript part)
		{
			if (_combinedParts == null)
			{
				return;
			}
			for (int i = 0; i < _combinedParts.Count; i++)
			{
				CombinedMeshPart combinedMeshPart = _combinedParts[i];
				if (!(combinedMeshPart.Part == part))
				{
					continue;
				}
				int[] triangles = _combinedMesh.triangles;
				int[] array = new int[triangles.Length - combinedMeshPart.TriangleIndexCount];
				int triangleIndexStart = combinedMeshPart.TriangleIndexStart;
				if (triangleIndexStart > 0)
				{
					Array.Copy(triangles, array, triangleIndexStart);
				}
				int num = triangles.Length - (combinedMeshPart.TriangleIndexStart + combinedMeshPart.TriangleIndexCount);
				if (num > 0)
				{
					Array.Copy(triangles, combinedMeshPart.TriangleIndexStart + combinedMeshPart.TriangleIndexCount, array, combinedMeshPart.TriangleIndexStart, num);
					for (int j = 0; j < _combinedParts.Count; j++)
					{
						if (_combinedParts[j].TriangleIndexStart > combinedMeshPart.TriangleIndexStart)
						{
							_combinedParts[j].TriangleIndexStart -= combinedMeshPart.TriangleIndexCount;
						}
					}
				}
				_combinedMesh.triangles = array;
				combinedMeshPart.Renderer.enabled = true;
				_combinedParts.RemoveAt(i);
				break;
			}
		}

		public void SetReflectionProbe(ReflectionProbe reflectionProbe)
		{
			Transform probeAnchor = reflectionProbe?.transform;
			_meshRenderer.probeAnchor = probeAnchor;
		}

		protected virtual void Awake()
		{
			Parts = new List<PartScript>();
		}

		protected virtual void CombineMeshes()
		{
			if (_partMeshSurvey.PartMeshes.Count == 0)
			{
				return;
			}
			Mesh mesh = new Mesh();
			mesh.name = $"PartGroup_{Id}_CombinedMesh";
			Mesh.MeshDataArray data = Mesh.AllocateWritableMeshData(1);
			Mesh.MeshData destinationMesh = data[0];
			destinationMesh.SetIndexBufferParams(_partMeshSurvey.IndexCount, IndexFormat.UInt16);
			destinationMesh.SetVertexBufferParams(_partMeshSurvey.VertexCount, new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0), new VertexAttributeDescriptor(VertexAttribute.Normal), new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2), new VertexAttributeDescriptor(VertexAttribute.TexCoord1), new VertexAttributeDescriptor(VertexAttribute.TexCoord2), new VertexAttributeDescriptor(VertexAttribute.TexCoord3));
			NativeArray<Matrix4x4> matrices = new NativeArray<Matrix4x4>(_partMeshSurvey.PartMeshes.Select((PartMesh x) => x.TransformMatrix).ToArray(), Allocator.TempJob);
			NativeArray<PartDragType> dragTypes = new NativeArray<PartDragType>(_partMeshSurvey.PartMeshes.Select((PartMesh x) => x.DragType).ToArray(), Allocator.TempJob);
			try
			{
				new CombineJob
				{
					SourceMeshes = _partMeshSurvey.MeshData.Value,
					DestinationMesh = destinationMesh,
					Matrices = matrices,
					DragTypes = dragTypes,
					VertexCount = _partMeshSurvey.VertexCount
				}.Schedule().Complete();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				throw;
			}
			matrices.Dispose();
			dragTypes.Dispose();
			destinationMesh.subMeshCount = 1;
			destinationMesh.SetSubMesh(0, new SubMeshDescriptor(0, _partMeshSurvey.IndexCount));
			Mesh.ApplyAndDisposeWritableMeshData(data, mesh);
			mesh.RecalculateBounds();
			int num = 0;
			_combinedParts = new List<CombinedMeshPart>(_partMeshSurvey.PartMeshes.Count);
			foreach (PartMesh partMesh in _partMeshSurvey.PartMeshes)
			{
				_combinedParts.Add(new CombinedMeshPart(partMesh.Part, partMesh.Renderer, num, partMesh.IndexCount));
				num += partMesh.IndexCount;
			}
			_combinedMesh = mesh;
		}

		protected virtual void OnDestroy()
		{
			if ((object)_combinedMesh != null)
			{
				UnityEngine.Object.Destroy(_combinedMesh);
				_combinedMesh = null;
			}
		}

		protected virtual void Start()
		{
			_initialize = new RunOnceOnNextUpdate(this, Initialize);
			_initialize.Queue();
		}

		protected virtual PartMeshSurvey SurveyPartMeshes()
		{
			Matrix4x4 worldToLocalMatrix = base.transform.worldToLocalMatrix;
			PartMeshSurvey partMeshSurvey = new PartMeshSurvey();
			List<Mesh> list = new List<Mesh>();
			int num = 0;
			foreach (PartScript part in Parts)
			{
				if (!part.Part.PartType.CombineMeshes)
				{
					continue;
				}
				foreach (PartMaterialScript.RendererMaterialMap rendererMap in part.PartMaterialScript.RendererMaps)
				{
					if (rendererMap.ExcludeFromMeshCombine)
					{
						continue;
					}
					MeshRenderer renderer = rendererMap.Renderer;
					MeshFilter component = renderer.GetComponent<MeshFilter>();
					if (!(component != null) || !renderer.enabled || !renderer.gameObject.activeInHierarchy)
					{
						continue;
					}
					Mesh sharedMesh = component.sharedMesh;
					int vertexCount = sharedMesh.vertexCount;
					if (vertexCount + partMeshSurvey.VertexCount < 65000 && vertexCount != 0)
					{
						int num2 = 0;
						for (int i = 0; i < sharedMesh.subMeshCount; i++)
						{
							num2 += sharedMesh.GetSubMesh(i).indexCount;
						}
						partMeshSurvey.VertexCount += vertexCount;
						partMeshSurvey.IndexCount += num2;
						partMeshSurvey.SubmeshCount += sharedMesh.subMeshCount;
						PartMesh partMesh = new PartMesh();
						partMesh.VertexCount = vertexCount;
						partMesh.IndexCount = num2;
						partMesh.TransformMatrix = worldToLocalMatrix * component.transform.localToWorldMatrix;
						partMesh.Part = part;
						partMesh.Renderer = renderer;
						partMesh.DragType = rendererMap.DragType;
						partMeshSurvey.PartMeshes.Add(partMesh);
						list.Add(sharedMesh);
					}
					else
					{
						num += vertexCount;
					}
				}
			}
			if (list.Count > 0)
			{
				partMeshSurvey.MeshData = Mesh.AcquireReadOnlyMeshData(list);
			}
			return partMeshSurvey;
		}

		protected virtual MeshRenderer SwitchToCombinedMesh()
		{
			foreach (PartMesh partMesh in _partMeshSurvey.PartMeshes)
			{
				partMesh.Renderer.enabled = false;
			}
			_meshFilter = base.gameObject.AddComponent<MeshFilter>();
			_meshFilter.mesh = _combinedMesh;
			_meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			_meshRenderer.material = Body.Aircraft.Theme.Material;
			_meshRenderer.motionVectorGenerationMode = MotionVectorGenerationMode.ForceNoMotion;
			_meshRenderer.probeAnchor = Body.Aircraft.ReflectionProbe?.transform;
			_partMeshSurvey = null;
			return _meshRenderer;
		}

		private void Initialize()
		{
			foreach (PartScript part in Parts)
			{
				if (part.Part.IsCockpit)
				{
					HasCockpit = true;
				}
			}
			if (Parts.Count >= 1)
			{
				_partMeshSurvey = SurveyPartMeshes();
				if (_partMeshSurvey.SubmeshCount > 1)
				{
					CombineMeshes();
				}
				_partMeshSurvey.MeshData?.Dispose();
			}
			if (_combinedMesh != null)
			{
				SwitchToCombinedMesh();
			}
			_initialized = true;
			this._initializedEvent?.Invoke(this);
		}
	}
}
