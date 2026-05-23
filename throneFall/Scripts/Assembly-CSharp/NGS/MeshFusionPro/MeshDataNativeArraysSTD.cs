using Unity.Collections;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class MeshDataNativeArraysSTD : CombinedMeshDataInternal
	{
		private CombinedMesh _root;

		private NativeList<Vector3> _vertices;

		private NativeList<Vector3> _normals;

		private NativeList<Vector4> _tangents;

		private NativeList<Bounds> _partsBounds;

		private NativeList<Bounds> _partsBoundsLocal;

		private NativeArray<Bounds> _bounds;

		public NativeArray<Vector3> Vertices => _vertices;

		public NativeArray<Vector3> Normals => _normals;

		public NativeArray<Vector4> Tangents => _tangents;

		public NativeArray<Bounds> PartsBounds => _partsBounds;

		public NativeArray<Bounds> PartsBoundsLocal => _partsBoundsLocal;

		public NativeArray<Bounds> Bounds => _bounds;

		public override Bounds GetBounds()
		{
			return _bounds[0];
		}

		public override Bounds GetBounds(CombinedMeshPart part)
		{
			return _partsBounds[part.Index];
		}

		public void ApplyDataToMesh()
		{
			Mesh mesh = _root.Mesh;
			mesh.SetVertices(Vertices);
			mesh.SetNormals(Normals);
			mesh.SetTangents(Tangents);
			mesh.bounds = _bounds[0];
		}

		protected override void OnInitialized()
		{
			_root = base.Root;
			_vertices = new NativeList<Vector3>(Allocator.Persistent);
			_normals = new NativeList<Vector3>(Allocator.Persistent);
			_tangents = new NativeList<Vector4>(Allocator.Persistent);
			_partsBounds = new NativeList<Bounds>(Allocator.Persistent);
			_partsBoundsLocal = new NativeList<Bounds>(Allocator.Persistent);
			_bounds = new NativeArray<Bounds>(1, Allocator.Persistent);
		}

		protected override void OnAddPart(CombinedMeshPart part, Mesh mesh, Matrix4x4 transform)
		{
			Bounds value = mesh.bounds;
			Bounds value2 = value.Transform(transform);
			_partsBounds.Add(in value2);
			_partsBoundsLocal.Add(in value);
		}

		protected override void OnRemovePart(CombinedMeshPart part)
		{
			_partsBounds.RemoveAt(part.Index);
			_partsBoundsLocal.RemoveAt(part.Index);
		}

		protected override void OnMeshUpdated()
		{
			Mesh mesh = _root.Mesh;
			int vertexCount = mesh.vertexCount;
			_vertices.ResizeUninitialized(vertexCount);
			_normals.ResizeUninitialized(vertexCount);
			_tangents.ResizeUninitialized(vertexCount);
			using (Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(mesh))
			{
				Mesh.MeshData meshData = meshDataArray[0];
				meshData.GetVertices(_vertices);
				meshData.GetNormals(_normals);
				meshData.GetTangents(_tangents);
			}
			_bounds[0] = mesh.bounds;
		}

		protected override void OnDispose()
		{
			_vertices.Dispose();
			_normals.Dispose();
			_tangents.Dispose();
			_partsBounds.Dispose();
			_partsBoundsLocal.Dispose();
			_bounds.Dispose();
		}
	}
}
