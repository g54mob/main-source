using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	public class MeshRendererRaycastInfo
	{
		public MeshRenderer MeshRenderer;

		public Mesh Mesh;

		public Matrix4x4 LocalToWorldMatrix4X4;

		public Bounds Bounds;
	}
}
