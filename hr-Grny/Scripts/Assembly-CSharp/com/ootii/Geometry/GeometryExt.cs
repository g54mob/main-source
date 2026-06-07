using UnityEngine;

namespace com.ootii.Geometry
{
	public class GeometryExt
	{
		public const float EPSILON = 0.0001f;

		public static Vector3 VECTOR3_HALF;

		public static float LineMeshStepFactor;

		public static Transform Ignore;

		public static Transform[] IgnoreArray;

		public static Vector3[] SphericalDirections;

		static GeometryExt()
		{
		}

		public static Vector3 ClosestPoint(Vector3 rPoint, Collider rCollider, int rCollisionLayers = -1)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPoint(Vector3 rPoint, float rRadius, Collider rCollider, int rCollisionLayers = -1)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPoint(Vector3 rPoint, Vector3 rLineStart, Vector3 rLineEnd)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPoint(ref Vector3 point, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPoint(Vector3 rPoint, Vector3 rPosition, float rRadius)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPoint(Vector3 rPoint, Transform rTransform, Vector3 rCenter, Vector3 rColliderSize)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPoint(Vector3 rPoint, Vector3 rLineStart, Vector3 rLineEnd, float rRadius)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPoint(Vector3 rPoint, SphereCollider rCollider)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPoint(Vector3 rPoint, CapsuleCollider rCollider)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPoint(Vector3 rPoint, BoxCollider rCollider)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPoint(Vector3 rPoint, TerrainCollider rCollider, float rRadius = 4f, int rCollisionLayers = -1)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPoint(Vector3 rPoint, Vector3 rDirection, float rRadius, TerrainCollider rCollider, int rCollisionLayers = -1)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPoint(Vector3 rPoint, CharacterController rController)
		{
			return default(Vector3);
		}

		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, float rRadius, Collider rCollider, ref Vector3 rLinePoint, ref Vector3 rColliderPoint, int rCollisionLayers = -1)
		{
		}

		public static void ClosestPoints(Vector3 rStart1, Vector3 rEnd1, Vector3 rStart2, Vector3 rEnd2, ref Vector3 rLine1Point, ref Vector3 rLine2Point)
		{
		}

		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, Vector3 rPosition, float rRadius, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
		}

		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, Transform rTransform, Vector3 rCenter, Vector3 rColliderSize, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
		}

		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, SphereCollider rCollider, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
		}

		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, CapsuleCollider rCollider, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
		}

		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, BoxCollider rCollider, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
		}

		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, CharacterController rController, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
		}

		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, TerrainCollider rCollider, ref Vector3 rLinePoint, ref Vector3 rColliderPoint, float rRadius = 4f, int rCollisionLayers = -1)
		{
		}

		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, Vector3 rMovement, TerrainCollider rCollider, ref Vector3 rLinePoint, ref Vector3 rColliderPoint, float rRadius = 4f, int rCollisionLayers = -1)
		{
		}

		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, float rRadius, MeshCollider rCollider, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
		}

		public static bool RaySphereIntersect(Vector3 rRayStart, Vector3 rRayDirection, Vector3 rSphereCenter, float rSphereRadius)
		{
			return false;
		}

		public static bool LinePlaneIntersect(Vector3 rLineStart, Vector3 rLineEnd, Plane rPlane)
		{
			return false;
		}

		public static bool LineSphereIntersect(Vector3 rLineStart, Vector3 rLineEnd, Vector3 rSphereCenter, float rSphereRadius)
		{
			return false;
		}

		public static bool LineCylinderIntersect(Vector3 rLineStart, Vector3 rLineEnd, Transform rTransform, float rHeight, float rRadius)
		{
			return false;
		}

		public static bool LineCylinderFromBaseIntersect(Vector3 rLineStart, Vector3 rLineEnd, Transform rTransform, float rHeight, float rRadius)
		{
			return false;
		}

		public static bool LineBoxIntersect(Vector3 rLineStart, Vector3 rLineEnd, Transform rTransform, float rWidth, float rHeight, float rDepth)
		{
			return false;
		}

		public static bool LineBoxFromBaseIntersect(Vector3 rLineStart, Vector3 rLineEnd, Vector3 rPosition, Quaternion rRotation, float rWidth, float rHeight, float rDepth)
		{
			return false;
		}

		public static bool CylinderContainsPoint(Vector3 pt1, Vector3 pt2, float rRadius, Vector3 testpt)
		{
			return false;
		}

		public static bool ContainsPoint(Vector3 rPoint, BoxCollider rCollider)
		{
			return false;
		}

		private static bool IgnoreCollider(Collider rCollider)
		{
			return false;
		}

		private static bool IsDescendant(Transform rParent, Transform rDescendant)
		{
			return false;
		}

		private static void GetLineDistanceFromBoxFace(ref Vector3 rBoxExtents, ref Vector3 rBoxPoint, ref Vector3 rBoxDirection, ref Vector3 rExtentToPoint, int rIndex0, int rIndex1, int rIndex2, ref float mLineDistance)
		{
		}

		private static void GetLineDistanceFromBoxExtent(ref Vector3 rBoxExtents, ref Vector3 rBoxPoint, ref Vector3 rBoxDirection, ref float rLineDistance)
		{
		}

		private static void GetLineDistanceFromBoxExtent(ref Vector3 rBoxExtents, ref Vector3 rBoxPoint, ref Vector3 rBoxDirection, int rIndex0, int rIndex1, ref float rLineDistance)
		{
		}

		private static void GetLineDistanceFromBoxExtent(ref Vector3 rBoxExtents, ref Vector3 rBoxPoint, ref Vector3 rBoxDirection, int rIndex0, ref float mLineDistance)
		{
		}

		private static void GetClosestPointFromTerrain(TerrainCollider rCollider, Vector3 rStart, Vector3 rEnd)
		{
		}
	}
}
