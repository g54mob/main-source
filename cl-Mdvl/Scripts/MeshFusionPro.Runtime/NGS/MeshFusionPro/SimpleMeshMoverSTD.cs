using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class SimpleMeshMoverSTD : ICombinedMeshMover
	{
		private MeshDataListsSTD _meshData;

		public SimpleMeshMoverSTD(MeshDataListsSTD meshData)
		{
			_meshData = meshData;
		}

		public void MoveParts(IList<PartMoveInfo> moveInfos)
		{
			List<Vector3> vertices = _meshData.Vertices;
			List<Vector3> normals = _meshData.Normals;
			List<Vector4> tangents = _meshData.Tangents;
			List<Bounds> partsBounds = _meshData.PartsBounds;
			List<Bounds> partsBoundsLocal = _meshData.PartsBoundsLocal;
			Bounds bounds = _meshData.GetBounds();
			bounds.size = Vector3.zero;
			for (int i = 0; i < moveInfos.Count; i++)
			{
				PartMoveInfo partMoveInfo = moveInfos[i];
				int partIndex = partMoveInfo.partIndex;
				int vertexStart = partMoveInfo.vertexStart;
				int num = vertexStart + partMoveInfo.vertexCount;
				Matrix4x4 targetTransform = partMoveInfo.targetTransform;
				Matrix4x4 inverse = partMoveInfo.currentTransform.inverse;
				for (int j = vertexStart; j < num; j++)
				{
					Vector3 point = vertices[j];
					Vector3 vector = normals[j];
					Vector4 vector2 = tangents[j];
					float w = vector2.w;
					point = inverse.MultiplyPoint3x4(point);
					point = targetTransform.MultiplyPoint3x4(point);
					vector = inverse.MultiplyVector(vector);
					vector = targetTransform.MultiplyVector(vector);
					vector2 = inverse.MultiplyVector(vector2);
					vector2 = targetTransform.MultiplyVector(vector2);
					vector2.w = w;
					vertices[j] = point;
					normals[j] = vector;
					tangents[j] = vector2;
				}
				partsBounds[partIndex] = partsBoundsLocal[partIndex].Transform(targetTransform);
			}
			for (int k = 0; k < partsBounds.Count; k++)
			{
				bounds.Encapsulate(partsBounds[k]);
			}
			_meshData.Bounds = bounds;
		}

		public void ApplyData()
		{
			_meshData.ApplyDataToMesh();
		}
	}
}
