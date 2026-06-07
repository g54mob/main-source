using System;
using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class CombinedMesh : IDisposable
	{
		private Mesh _mesh;

		private CombinedMeshDataInternal _meshData;

		private IMeshCombiner _combiner;

		private IMeshCutter _cutter;

		public Mesh Mesh => _mesh;

		public CombinedMeshData MeshData => _meshData;

		public CombinedMesh(IMeshCombiner combiner, IMeshCutter cutter)
		{
			if (combiner == null)
			{
				throw new ArgumentNullException("MeshCombiner not assigned");
			}
			if (cutter == null)
			{
				throw new ArgumentNullException("MeshCutter not assigned");
			}
			_mesh = new Mesh();
			_mesh.MarkDynamic();
			_combiner = combiner;
			_cutter = cutter;
			_meshData = CreateMeshData();
			_meshData.Initialize(this);
		}

		public CombinedMeshPart[] Combine(IList<MeshCombineInfo> infos)
		{
			_combiner.Combine(_mesh, infos);
			return _meshData.CreateParts(infos);
		}

		public void Cut(IList<CombinedMeshPart> parts)
		{
			MeshCuttingInfo[] array = new MeshCuttingInfo[parts.Count];
			for (int i = 0; i < parts.Count; i++)
			{
				CombinedMeshPart combinedMeshPart = parts[i];
				array[i] = new MeshCuttingInfo
				{
					vertexStart = combinedMeshPart.VertexStart,
					vertexCount = combinedMeshPart.VertexCount,
					triangleStart = combinedMeshPart.TrianglesStart,
					triangleCount = combinedMeshPart.TrianglesCount
				};
			}
			_cutter.Cut(_mesh, array);
			_meshData.RemoveParts(parts);
		}

		public void Dispose()
		{
			_meshData.Dispose();
		}

		protected virtual CombinedMeshDataInternal CreateMeshData()
		{
			return new CombinedMeshDataInternal();
		}
	}
	public class CombinedMesh<TCombinedMeshData> : CombinedMesh where TCombinedMeshData : CombinedMeshDataInternal, new()
	{
		public TCombinedMeshData MeshDataInternal => (TCombinedMeshData)base.MeshData;

		public CombinedMesh(IMeshCombiner combiner, IMeshCutter cutter)
			: base(combiner, cutter)
		{
		}

		protected override CombinedMeshDataInternal CreateMeshData()
		{
			return new TCombinedMeshData();
		}
	}
}
