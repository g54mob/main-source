using UnityEngine;

namespace RLD
{
	public static class ObjectPositionCalculator
	{
		private static ObjectBounds.QueryConfig _boundsQConfig;

		static ObjectPositionCalculator()
		{
			_boundsQConfig.NoVolumeSize = Vector3.zero;
			_boundsQConfig.ObjectTypes = GameObjectTypeHelper.AllCombined;
		}

		public static Vector3 CalculateRootPosition(GameObject root, Vector3 desiredOBBCenter, Vector3 desiredWorldScale, Quaternion desiredWorldRotation)
		{
			OBB oBB = ObjectBounds.CalcHierarchyWorldOBB(root, _boundsQConfig);
			Transform transform = root.transform;
			Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, transform.rotation, transform.lossyScale);
			Matrix4x4 matrix4x2 = Matrix4x4.TRS(Vector3.zero, desiredWorldRotation, desiredWorldScale) * matrix4x.inverse;
			Vector3 vector = transform.position - oBB.Center;
			vector = matrix4x2.MultiplyVector(vector);
			return desiredOBBCenter + vector;
		}
	}
}
