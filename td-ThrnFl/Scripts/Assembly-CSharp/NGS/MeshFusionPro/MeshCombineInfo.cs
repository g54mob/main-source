using UnityEngine;
using UnityEngine.Rendering;

namespace NGS.MeshFusionPro
{
	public struct MeshCombineInfo
	{
		public Mesh mesh;

		public Matrix4x4 transformMatrix;

		public Vector4 lightmapScaleOffset;

		public Vector4 realtimeLightmapScaleOffset;

		public int submeshIndex;

		public readonly int vertexCount;

		public readonly int trianglesCount;

		public MeshCombineInfo(Mesh mesh, int submeshIndex = 0)
			: this(mesh, Matrix4x4.identity, submeshIndex)
		{
		}

		public MeshCombineInfo(Mesh mesh, Matrix4x4 transformMatrix, int submeshIndex = 0)
			: this(mesh, transformMatrix, new Vector4(1f, 1f, 0f, 0f), new Vector4(1f, 1f, 0f, 0f), submeshIndex)
		{
		}

		public MeshCombineInfo(Mesh mesh, Matrix4x4 transformMatrix, Vector4 lightmapScaleOffset, Vector4 realtimeLightmapScaleOffset, int submeshIndex = 0)
		{
			this.mesh = mesh;
			this.transformMatrix = transformMatrix;
			this.lightmapScaleOffset = lightmapScaleOffset;
			this.realtimeLightmapScaleOffset = realtimeLightmapScaleOffset;
			this.submeshIndex = submeshIndex;
			SubMeshDescriptor subMesh = mesh.GetSubMesh(submeshIndex);
			vertexCount = subMesh.vertexCount;
			trianglesCount = subMesh.indexCount;
		}
	}
}
