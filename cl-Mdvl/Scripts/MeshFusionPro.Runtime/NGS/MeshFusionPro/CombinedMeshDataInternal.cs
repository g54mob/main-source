using System;
using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class CombinedMeshDataInternal : CombinedMeshData, IDisposable
	{
		private CombinedMesh _root;

		private List<CombinedMeshPartInternal> _parts;

		private int _vertexCount;

		private int _trianglesCount;

		private List<Bounds> _partsBounds;

		private Bounds _boundingBox;

		public override int PartsCount => _parts.Count;

		public override int VertexCount => _vertexCount;

		protected CombinedMesh Root => _root;

		public void Initialize(CombinedMesh root)
		{
			_root = root;
			_parts = new List<CombinedMeshPartInternal>();
			OnInitialized();
		}

		public override Bounds GetBounds()
		{
			return _boundingBox;
		}

		public override Bounds GetBounds(CombinedMeshPart part)
		{
			return _partsBounds[part.Index];
		}

		public override IEnumerable<CombinedMeshPart> GetParts()
		{
			for (int i = 0; i < _parts.Count; i++)
			{
				yield return _parts[i];
			}
		}

		public void Dispose()
		{
			OnDispose();
		}

		public CombinedMeshPart[] CreateParts(IList<MeshCombineInfo> infos)
		{
			CombinedMeshPart[] array = new CombinedMeshPart[infos.Count];
			for (int i = 0; i < array.Length; i++)
			{
				MeshCombineInfo meshCombineInfo = infos[i];
				Mesh mesh = meshCombineInfo.mesh;
				Matrix4x4 transformMatrix = meshCombineInfo.transformMatrix;
				int vertexCount = _vertexCount;
				int vertexCount2 = meshCombineInfo.vertexCount;
				int trianglesCount = _trianglesCount;
				int trianglesCount2 = meshCombineInfo.trianglesCount;
				CombinedMeshPartInternal combinedMeshPartInternal = new CombinedMeshPartInternal(_root, _parts.Count, vertexCount, vertexCount2, trianglesCount, trianglesCount2);
				_parts.Add(combinedMeshPartInternal);
				array[i] = combinedMeshPartInternal;
				_vertexCount += vertexCount2;
				_trianglesCount += trianglesCount2;
				OnAddPart(combinedMeshPartInternal, mesh, transformMatrix);
			}
			OnMeshUpdated();
			return array;
		}

		public void RemoveParts(IList<CombinedMeshPart> parts)
		{
			for (int i = 0; i < parts.Count; i++)
			{
				CombinedMeshPartInternal combinedMeshPartInternal = (CombinedMeshPartInternal)parts[i];
				OnRemovePart(combinedMeshPartInternal);
				int num = _parts.IndexOf(combinedMeshPartInternal);
				int vertexCount = combinedMeshPartInternal.VertexCount;
				int trianglesCount = combinedMeshPartInternal.TrianglesCount;
				for (int j = num + 1; j < _parts.Count; j++)
				{
					CombinedMeshPartInternal combinedMeshPartInternal2 = _parts[j];
					combinedMeshPartInternal2.Offset(newVertexStart: combinedMeshPartInternal2.VertexStart - vertexCount, newTrianglesStart: combinedMeshPartInternal2.TrianglesStart - trianglesCount, newIndex: combinedMeshPartInternal2.Index - 1);
				}
				_parts.Remove(combinedMeshPartInternal);
				_vertexCount -= combinedMeshPartInternal.VertexCount;
				_trianglesCount -= combinedMeshPartInternal.TrianglesCount;
			}
			OnMeshUpdated();
		}

		protected virtual void OnInitialized()
		{
			_partsBounds = new List<Bounds>();
		}

		protected virtual void OnAddPart(CombinedMeshPart part, Mesh mesh, Matrix4x4 transform)
		{
			_partsBounds.Add(mesh.bounds.Transform(transform));
		}

		protected virtual void OnRemovePart(CombinedMeshPart part)
		{
			_partsBounds.RemoveAt(part.Index);
		}

		protected virtual void OnMeshUpdated()
		{
			_boundingBox = _root.Mesh.bounds;
		}

		protected virtual void OnDispose()
		{
		}
	}
}
