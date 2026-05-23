using UnityEngine;

namespace Deform
{
	public static class DeformerUtils
	{
		public static Matrix4x4 GetMeshToAxisSpace(Transform axis, Transform mesh)
		{
			return axis.worldToLocalMatrix * mesh.transform.localToWorldMatrix;
		}

		public static Vector3 GetAxisPositionRelativeToMesh(Transform axis, Transform mesh)
		{
			return mesh.worldToLocalMatrix.MultiplyPoint3x4(axis.position);
		}
	}
}
