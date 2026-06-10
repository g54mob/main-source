using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class MeshCutterSimpleLW : IMeshCutter
	{
		private static List<int> _triangles;

		static MeshCutterSimpleLW()
		{
			_triangles = new List<int>();
		}

		public void Cut(Mesh mesh, MeshCuttingInfo info)
		{
			Cut(mesh, new MeshCuttingInfo[1] { info });
		}

		public void Cut(Mesh mesh, IList<MeshCuttingInfo> infos)
		{
			ValidateMeshOrThrowException(mesh);
			mesh.GetTriangles(_triangles, 0);
			using (Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(mesh))
			{
				NativeArray<LightweightVertex> vertexData = meshDataArray[0].GetVertexData<LightweightVertex>();
				NativeList<LightweightVertex> list = new NativeList<LightweightVertex>(Allocator.Temp);
				list.CopyFrom(vertexData);
				foreach (MeshCuttingInfo item in infos.OrderByDescending((MeshCuttingInfo i) => i.triangleStart))
				{
					list.RemoveRange(item.vertexStart, item.vertexCount);
					_triangles.RemoveRange(item.triangleStart, item.triangleCount);
					OffsetTriangles(item);
				}
				mesh.SetTriangles(_triangles, 0);
				mesh.SetVertexBufferData(list.NativeListToArray(), 0, 0, list.Length);
			}
			_triangles.Clear();
		}

		private void ValidateMeshOrThrowException(Mesh mesh)
		{
			if (mesh == null)
			{
				throw new ArgumentNullException("mesh");
			}
			if (mesh.subMeshCount > 1)
			{
				throw new ArgumentException("SimpleMeshCutter::'mesh' should has only 1 submesh");
			}
		}

		private void OffsetTriangles(MeshCuttingInfo info)
		{
			int vertexCount = info.vertexCount;
			int triangleStart = info.triangleStart;
			int count = _triangles.Count;
			for (int i = triangleStart; i < count; i++)
			{
				_triangles[i] -= vertexCount;
			}
		}
	}
}
