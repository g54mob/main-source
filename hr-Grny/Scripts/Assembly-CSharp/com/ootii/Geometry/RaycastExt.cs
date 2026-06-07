using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Geometry
{
	public static class RaycastExt
	{
		public const int MAX_HITS = 40;

		public static RaycastHitDistanceComparer HitDistanceComparer;

		public static RaycastHit EmptyHitInfo;

		public static RaycastHit[] SharedHitArray;

		public static Collider[] SharedColliderArray;

		public static bool SafeRaycast(Vector3 rRayStart, Vector3 rRayDirection, float rDistance = 1000f, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true)
		{
			return false;
		}

		public static bool SafeRaycast(Vector3 rRayStart, Vector3 rRayDirection, out RaycastHit rHitInfo, float rDistance = 1000f, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true, bool rDebug = false)
		{
			rHitInfo = default(RaycastHit);
			return false;
		}

		public static int SafeRaycastAll(Vector3 rRayStart, Vector3 rRayDirection, out RaycastHit[] rHitArray, float rDistance = 1000f, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true)
		{
			rHitArray = null;
			return 0;
		}

		public static bool SafeSphereCast(Vector3 rRayStart, Vector3 rRayDirection, float rRadius, float rDistance = 1000f, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true)
		{
			return false;
		}

		public static bool SafeSphereCast(Vector3 rRayStart, Vector3 rRayDirection, float rRadius, out RaycastHit rHitInfo, float rDistance = 1000f, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true)
		{
			rHitInfo = default(RaycastHit);
			return false;
		}

		public static int SafeSphereCastAll(Vector3 rRayStart, Vector3 rRayDirection, float rRadius, out RaycastHit[] rHitArray, float rDistance = 1000f, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true)
		{
			rHitArray = null;
			return 0;
		}

		public static int SafeOverlapSphere(Vector3 rPosition, float rRadius, out Collider[] rColliderArray, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true)
		{
			rColliderArray = null;
			return 0;
		}

		public static bool SafeSpiralCast(Transform rRootTransform, out RaycastHit rHitInfo, float rRadius = 8f, float rDistance = 1000f, float rDegreesPerStep = 27f, int rLayerMask = -1, string rTag = null, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true, bool rDebug = false)
		{
			rHitInfo = default(RaycastHit);
			return false;
		}

		public static bool SafeCircularCast(Vector3 rRayStart, Vector3 rRayDirection, Vector3 rRayUp, out RaycastHit rHitInfo, float rDistance = 1000f, float rDegreesPerStep = 30f, int rLayerMask = -1, string rTag = null, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true, bool rDebug = false)
		{
			rHitInfo = default(RaycastHit);
			return false;
		}

		public static bool GetForwardEdge(Transform rTransform, float rMaxDistance, float rMaxHeight, int rCollisionLayers, out RaycastHit rEdgeHitInfo)
		{
			rEdgeHitInfo = default(RaycastHit);
			return false;
		}

		public static bool GetForwardEdge(Transform rTransform, Vector3 rPosition, float rMinHeight, float rMaxHeight, float rMaxDepth, int rCollisionLayers, out RaycastHit rEdgeHitInfo)
		{
			rEdgeHitInfo = default(RaycastHit);
			return false;
		}

		public static bool GetForwardEdge(Transform rTransform, float rMaxDistance, float rMaxHeight, float rMinHeight, int rCollisionLayers, out RaycastHit rEdgeHitInfo)
		{
			rEdgeHitInfo = default(RaycastHit);
			return false;
		}

		public static bool GetForwardEdge2(Transform rTransform, float rMinHeight, float rMaxHeight, float rEdgeDepth, float rMaxDepth, int rCollisionLayers, out RaycastHit rEdgeHitInfo, bool rDebug = false)
		{
			rEdgeHitInfo = default(RaycastHit);
			return false;
		}

		public static bool GetForwardEdge2(Transform rTransform, Vector3 rPosition, float rMinHeight, float rMaxHeight, float rEdgeDepth, float rMaxDepth, int rCollisionLayers, out RaycastHit rEdgeHitInfo, bool rDebug = false)
		{
			rEdgeHitInfo = default(RaycastHit);
			return false;
		}

		public static bool GetForwardEdge2(Transform rTransform, Vector3 rPosition, Vector3 rForward, Vector3 rUp, float rMinHeight, float rMaxHeight, float rEdgeDepth, float rMaxDepth, int rCollisionLayers, out RaycastHit rEdgeHitInfo, bool rDebug = false)
		{
			rEdgeHitInfo = default(RaycastHit);
			return false;
		}

		public static void Sort(RaycastHit[] rHitArray, int rCount)
		{
		}

		private static bool IsDescendant(Transform rParent, Transform rDescendant)
		{
			return false;
		}
	}
}
