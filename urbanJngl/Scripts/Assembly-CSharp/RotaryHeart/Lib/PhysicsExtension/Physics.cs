using RotaryHeart.Lib.UnityGLDebug;
using UnityEngine;

namespace RotaryHeart.Lib.PhysicsExtension
{
	public static class Physics
	{
		private static Quaternion M_orientation = default(Quaternion);

		private static float M_maxDistance = float.PositiveInfinity;

		private static int M_layerMask = -1;

		private static QueryTriggerInteraction M_queryTriggerInteraction = QueryTriggerInteraction.UseGlobal;

		internal static Color M_castColor = new Color(1f, 0.5f, 0f, 1f);

		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return BoxCast(center, halfExtents, direction, out hitInfo, M_orientation, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return BoxCast(center, halfExtents, direction, out hitInfo, orientation, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit rayInfo, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCast(center, halfExtents, direction, out rayInfo, M_orientation, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit rayInfo, Quaternion orientation, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCast(center, halfExtents, direction, out rayInfo, orientation, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit rayInfo, Quaternion orientation, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCast(center, halfExtents, direction, out rayInfo, orientation, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, layerMask, queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit rayInfo, Quaternion orientation, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCast(center, halfExtents, direction, out rayInfo, orientation, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			bool flag = UnityEngine.Physics.BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				maxDistance = ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				if (flag)
				{
					DebugExtensions.DebugPoint(hitInfo.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					maxDistance = hitInfo.distance;
				}
				DebugExtensions.DebugBoxCast(center, halfExtents, direction, maxDistance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), orientation, drawDuration, drawType, preview, drawDepth);
			}
			return flag;
		}

		public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastAll(center, halfExtents, direction, M_orientation, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastAll(center, halfExtents, direction, orientation, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastAll(center, halfExtents, direction, orientation, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, LayerMask layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastAll(center, halfExtents, direction, orientation, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit[] array = UnityEngine.Physics.BoxCastAll(center, halfExtents, direction, orientation, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				float num = 0f;
				RaycastHit[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit raycastHit = array2[i];
					flag = true;
					if (raycastHit.distance > num)
					{
						num = raycastHit.distance;
					}
					DebugExtensions.DebugPoint(raycastHit.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugBox(center + direction * raycastHit.distance, halfExtents, hitColor ?? Color.green, orientation, drawDuration, preview, drawDepth);
				}
				DebugExtensions.DebugBoxCast(center, halfExtents, direction, maxDistance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), orientation, drawDuration, drawType, preview, drawDepth);
			}
			return array;
		}

		public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastNonAlloc(center, halfExtents, direction, results, M_orientation, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, Quaternion orientation, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastNonAlloc(center, halfExtents, direction, results, orientation, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, Quaternion orientation, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastNonAlloc(center, halfExtents, direction, results, orientation, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, Quaternion orientation, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastNonAlloc(center, halfExtents, direction, results, orientation, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, Quaternion orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			int num = UnityEngine.Physics.BoxCastNonAlloc(center, halfExtents, direction, results, orientation, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				float num2 = 0f;
				for (int i = 0; i < num; i++)
				{
					RaycastHit raycastHit = results[i];
					flag = true;
					if (raycastHit.distance > num2)
					{
						num2 = raycastHit.distance;
					}
					DebugExtensions.DebugPoint(raycastHit.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugBox(center + direction * raycastHit.distance, halfExtents, hitColor ?? Color.green, orientation, drawDuration, preview, drawDepth);
				}
				DebugExtensions.DebugBoxCast(center, halfExtents, direction, maxDistance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), orientation, drawDuration, drawType, preview, drawDepth);
			}
			return num;
		}

		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return CapsuleCast(point1, point2, radius, direction, out hitInfo, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCast(point1, point2, radius, direction, out hitInfo, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			bool flag = UnityEngine.Physics.CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				maxDistance = ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				if (flag)
				{
					maxDistance = hitInfo.distance;
					DebugExtensions.DebugPoint(hitInfo.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
				}
				DebugExtensions.DebugCapsuleCast(point1, point2, direction, maxDistance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return flag;
		}

		public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastAll(point1, point2, radius, direction, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastAll(point1, point2, radius, direction, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastAll(point1, point2, radius, direction, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit[] array = UnityEngine.Physics.CapsuleCastAll(point1, point2, radius, direction, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				float num = 0f;
				RaycastHit[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit raycastHit = array2[i];
					flag = true;
					if (raycastHit.distance > num)
					{
						num = raycastHit.distance;
					}
					DebugExtensions.DebugPoint(raycastHit.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugCapsule(point1 + direction * raycastHit.distance, point2 + direction * raycastHit.distance, hitColor ?? Color.green, radius, colorizeBase: true, drawDuration, preview, drawDepth);
				}
				maxDistance = ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				DebugExtensions.DebugCapsuleCast(point1, point2, direction, maxDistance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return array;
		}

		public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastNonAlloc(point1, point2, radius, direction, results, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastNonAlloc(point1, point2, radius, direction, results, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastNonAlloc(point1, point2, radius, direction, results, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			int num = UnityEngine.Physics.CapsuleCastNonAlloc(point1, point2, radius, direction, results, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				float num2 = 0f;
				for (int i = 0; i < num; i++)
				{
					flag = true;
					RaycastHit raycastHit = results[i];
					if (raycastHit.distance > num2)
					{
						num2 = raycastHit.distance;
					}
					DebugExtensions.DebugPoint(raycastHit.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugCapsule(point1 + direction * raycastHit.distance, point2 + direction * raycastHit.distance, hitColor ?? Color.green, radius, colorizeBase: true, drawDuration, preview, drawDepth);
				}
				maxDistance = ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				DebugExtensions.DebugCapsuleCast(point1, point2, direction, maxDistance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return num;
		}

		public static bool CheckBox(Vector3 center, Vector3 halfExtents, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return CheckBox(center, halfExtents, M_orientation, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return CheckBox(center, halfExtents, orientation, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return CheckBox(center, halfExtents, orientation, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			bool flag = UnityEngine.Physics.CheckBox(center, halfExtents, orientation, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				DebugExtensions.DebugBox(center, halfExtents, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), orientation, drawDuration, preview, drawDepth);
			}
			return flag;
		}

		public static bool CheckCapsule(Vector3 start, Vector3 end, float radius, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return CheckCapsule(start, end, radius, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool CheckCapsule(Vector3 start, Vector3 end, float radius, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return CheckCapsule(start, end, radius, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool CheckCapsule(Vector3 start, Vector3 end, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			bool flag = UnityEngine.Physics.CheckCapsule(start, end, radius, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				DebugExtensions.DebugCapsule(start, end, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, colorizeBase: false, drawDuration, preview, drawDepth);
			}
			return flag;
		}

		public static bool CheckSphere(Vector3 position, float radius, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return CheckSphere(position, radius, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool CheckSphere(Vector3 position, float radius, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return CheckSphere(position, radius, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool CheckSphere(Vector3 position, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			bool flag = UnityEngine.Physics.CheckSphere(position, radius, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				DebugExtensions.DebugWireSphere(position, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, preview, drawDepth);
			}
			return flag;
		}

		public static bool Linecast(Vector3 start, Vector3 end, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit hitInfo;
			return Linecast(start, end, out hitInfo, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Linecast(Vector3 start, Vector3 end, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit hitInfo;
			return Linecast(start, end, out hitInfo, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Linecast(Vector3 start, Vector3 end, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit hitInfo;
			return Linecast(start, end, out hitInfo, layerMask, queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Linecast(start, end, out hitInfo, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Linecast(start, end, out hitInfo, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			bool flag = UnityEngine.Physics.Linecast(start, end, out hitInfo, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				if (flag)
				{
					end = hitInfo.point;
					DebugExtensions.DebugPoint(end, Color.red, 0.5f, drawDuration, preview, drawDepth);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(start, end, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(start, end, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), drawDuration);
				}
			}
			return flag;
		}

		public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBox(center, halfExtents, M_orientation, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBox(center, halfExtents, orientation, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBox(center, halfExtents, orientation, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			Collider[] array = UnityEngine.Physics.OverlapBox(center, halfExtents, orientation, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = array.Length != 0;
				DebugExtensions.DebugBox(center, halfExtents, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), orientation, drawDuration, preview, drawDepth);
			}
			return array;
		}

		public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBoxNonAlloc(center, halfExtents, results, M_orientation, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBoxNonAlloc(center, halfExtents, results, orientation, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBoxNonAlloc(center, halfExtents, results, orientation, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics.OverlapBoxNonAlloc(center, halfExtents, results, orientation, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = num > 0;
				DebugExtensions.DebugBox(center, halfExtents, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), orientation, drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static Collider[] OverlapCapsule(Vector3 point0, Vector3 point1, float radius, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCapsule(point0, point1, radius, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider[] OverlapCapsule(Vector3 point0, Vector3 point1, float radius, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCapsule(point0, point1, radius, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider[] OverlapCapsule(Vector3 point0, Vector3 point1, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			Collider[] array = UnityEngine.Physics.OverlapCapsule(point0, point1, radius, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = array.Length != 0;
				DebugExtensions.DebugCapsule(point0, point1, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, colorizeBase: false, drawDuration, preview, drawDepth);
			}
			return array;
		}

		public static int OverlapCapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCapsuleNonAlloc(point0, point1, radius, results, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapCapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCapsuleNonAlloc(point0, point1, radius, results, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapCapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics.OverlapCapsuleNonAlloc(point0, point1, radius, results, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = num > 0;
				DebugExtensions.DebugCapsule(point0, point1, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, colorizeBase: false, drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static Collider[] OverlapSphere(Vector3 position, float radius, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapSphere(position, radius, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider[] OverlapSphere(Vector3 position, float radius, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapSphere(position, radius, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider[] OverlapSphere(Vector3 position, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			Collider[] array = UnityEngine.Physics.OverlapSphere(position, radius, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = array.Length != 0;
				DebugExtensions.DebugWireSphere(position, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, preview, drawDepth);
			}
			return array;
		}

		public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapSphereNonAlloc(position, radius, results, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapSphereNonAlloc(position, radius, results, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics.OverlapSphereNonAlloc(position, radius, results, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = num > 0;
				DebugExtensions.DebugWireSphere(position, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static bool Raycast(Vector3 origin, Vector3 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit hitInfo;
			return Raycast(origin, direction, out hitInfo, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit hitInfo;
			return Raycast(origin, direction, out hitInfo, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit hitInfo;
			return Raycast(origin, direction, out hitInfo, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit hitInfo;
			return Raycast(origin, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Raycast(origin, direction, out hitInfo, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Raycast(origin, direction, out hitInfo, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Raycast(origin, direction, out hitInfo, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			bool flag = UnityEngine.Physics.Raycast(origin, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				Vector3 vector = origin + direction * ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				if (flag)
				{
					vector = hitInfo.point;
					DebugExtensions.DebugPoint(vector, Color.red, 0.5f, drawDuration, preview, drawDepth);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(origin, vector, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(origin, vector, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), drawDuration);
				}
			}
			return flag;
		}

		public static bool Raycast(Ray ray, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit hitInfo;
			return Raycast(ray, out hitInfo, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Ray ray, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit hitInfo;
			return Raycast(ray, out hitInfo, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Ray ray, out RaycastHit hitInfo, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Raycast(ray, out hitInfo, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Ray ray, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit hitInfo;
			return Raycast(ray, out hitInfo, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Raycast(ray, out hitInfo, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Ray ray, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit hitInfo;
			return Raycast(ray, out hitInfo, maxDistance, layerMask, queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Raycast(ray, out hitInfo, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			bool flag = UnityEngine.Physics.Raycast(ray, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				Vector3 vector = ray.origin + ray.direction * ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				if (flag)
				{
					vector = hitInfo.point;
					DebugExtensions.DebugPoint(vector, Color.red, 0.5f, drawDuration, preview, drawDepth);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(ray.origin, vector, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(ray.origin, vector, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), drawDuration);
				}
			}
			return flag;
		}

		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastAll(origin, direction, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastAll(origin, direction, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance, LayerMask layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastAll(origin, direction, maxDistance, (int)layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit[] array = UnityEngine.Physics.RaycastAll(origin, direction, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				Vector3 end = origin + direction * ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				Vector3 vector = origin;
				Vector3 start = origin;
				RaycastHit[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit raycastHit = array2[i];
					DebugExtensions.DebugPoint(raycastHit.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
					{
						Debug.DrawLine(start, raycastHit.point, hitColor ?? Color.green, drawDuration);
					}
					if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
					{
						GLDebug.DrawLine(start, raycastHit.point, hitColor ?? Color.green, drawDuration);
					}
					if ((origin - raycastHit.point).sqrMagnitude > (origin - vector).sqrMagnitude)
					{
						vector = raycastHit.point;
					}
					start = raycastHit.point;
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector, end, noHitColor ?? Color.red, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector, end, noHitColor ?? Color.red, drawDuration);
				}
			}
			return array;
		}

		public static RaycastHit[] RaycastAll(Ray ray, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastAll(ray, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit[] RaycastAll(Ray ray, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastAll(ray, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit[] RaycastAll(Ray ray, float maxDistance, LayerMask layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastAll(ray, maxDistance, (int)layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit[] RaycastAll(Ray ray, float maxDistance, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit[] array = UnityEngine.Physics.RaycastAll(ray, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				Vector3 end = ray.origin + ray.direction * ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				Vector3 vector = ray.origin;
				Vector3 start = ray.origin;
				RaycastHit[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit raycastHit = array2[i];
					DebugExtensions.DebugPoint(raycastHit.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
					{
						Debug.DrawLine(start, raycastHit.point, hitColor ?? Color.green, drawDuration);
					}
					if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
					{
						GLDebug.DrawLine(start, raycastHit.point, hitColor ?? Color.green, drawDuration);
					}
					if ((ray.origin - raycastHit.point).sqrMagnitude > (ray.origin - vector).sqrMagnitude)
					{
						vector = raycastHit.point;
					}
					start = raycastHit.point;
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector, end, noHitColor ?? Color.red, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector, end, noHitColor ?? Color.red, drawDuration);
				}
			}
			return array;
		}

		public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastNonAlloc(origin, direction, results, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastNonAlloc(origin, direction, results, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float maxDistance, LayerMask layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastNonAlloc(origin, direction, results, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float maxDistance, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics.RaycastNonAlloc(origin, direction, results, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				Vector3 end = origin + direction * ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				Vector3 vector = origin;
				Vector3 start = origin;
				for (int i = 0; i < num; i++)
				{
					RaycastHit raycastHit = results[i];
					DebugExtensions.DebugPoint(raycastHit.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
					{
						Debug.DrawLine(start, raycastHit.point, hitColor ?? Color.green, drawDuration);
					}
					if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
					{
						GLDebug.DrawLine(start, raycastHit.point, hitColor ?? Color.green, drawDuration);
					}
					if ((origin - raycastHit.point).sqrMagnitude > (origin - vector).sqrMagnitude)
					{
						vector = raycastHit.point;
					}
					start = raycastHit.point;
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector, end, noHitColor ?? Color.red, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector, end, noHitColor ?? Color.red, drawDuration);
				}
			}
			return num;
		}

		public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastNonAlloc(ray, results, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastNonAlloc(ray, results, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, float maxDistance, LayerMask layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastNonAlloc(ray, results, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, float maxDistance, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics.RaycastNonAlloc(ray, results, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				Vector3 end = ray.origin + ray.direction * ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				Vector3 vector = ray.origin;
				Vector3 start = ray.origin;
				for (int i = 0; i < num; i++)
				{
					RaycastHit raycastHit = results[i];
					DebugExtensions.DebugPoint(raycastHit.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
					{
						Debug.DrawLine(start, raycastHit.point, hitColor ?? Color.green, drawDuration);
					}
					if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
					{
						GLDebug.DrawLine(start, raycastHit.point, hitColor ?? Color.green, drawDuration);
					}
					if ((ray.origin - raycastHit.point).sqrMagnitude > (ray.origin - vector).sqrMagnitude)
					{
						vector = raycastHit.point;
					}
					start = raycastHit.point;
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector, end, noHitColor ?? Color.red, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector, end, noHitColor ?? Color.red, drawDuration);
				}
			}
			return num;
		}

		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return SphereCast(origin, radius, direction, out hitInfo, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return SphereCast(origin, radius, direction, out hitInfo, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCast(origin, radius, direction, out hitInfo, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCast(origin, radius, direction, out hitInfo, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			bool flag = UnityEngine.Physics.SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				maxDistance = ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				if (flag)
				{
					maxDistance = hitInfo.distance;
					DebugExtensions.DebugPoint(hitInfo.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
				}
				DebugExtensions.DebugSphereCast(origin, direction, maxDistance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return flag;
		}

		public static bool SphereCast(Ray ray, float radius, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return SphereCast(ray, radius, out hitInfo, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Ray ray, float radius, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return SphereCast(ray, radius, out hitInfo, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCast(ray, radius, out hitInfo, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Ray ray, float radius, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return SphereCast(ray, radius, out hitInfo, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCast(ray, radius, out hitInfo, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Ray ray, float radius, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit hitInfo;
			return SphereCast(ray, radius, out hitInfo, maxDistance, layerMask, queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCast(ray, radius, out hitInfo, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			bool flag = UnityEngine.Physics.SphereCast(ray, radius, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				maxDistance = ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				if (flag)
				{
					maxDistance = hitInfo.distance;
					DebugExtensions.DebugPoint(hitInfo.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
				}
				DebugExtensions.DebugSphereCast(ray.origin, ray.direction, maxDistance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return flag;
		}

		public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCastAll(origin, radius, direction, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCastAll(origin, radius, direction, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCastAll(origin, radius, direction, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit[] array = UnityEngine.Physics.SphereCastAll(origin, radius, direction, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				float num = 0f;
				RaycastHit[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit raycastHit = array2[i];
					flag = true;
					if (raycastHit.distance > num)
					{
						num = raycastHit.distance;
					}
					DebugExtensions.DebugPoint(raycastHit.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugWireSphere(origin + direction * raycastHit.distance, hitColor ?? Color.green, radius, drawDuration, preview, drawDepth);
				}
				maxDistance = ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				DebugExtensions.DebugSphereCast(origin, direction, maxDistance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return array;
		}

		public static RaycastHit[] SphereCastAll(Ray ray, float radius, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCastAll(ray, radius, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCastAll(ray, radius, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCastAll(ray, radius, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit[] array = UnityEngine.Physics.SphereCastAll(ray, radius, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				float num = 0f;
				RaycastHit[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit raycastHit = array2[i];
					flag = true;
					if (raycastHit.distance > num)
					{
						num = raycastHit.distance;
					}
					DebugExtensions.DebugPoint(raycastHit.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugWireSphere(ray.origin + ray.direction * raycastHit.distance, hitColor ?? Color.green, radius, drawDuration, preview, drawDepth);
				}
				maxDistance = ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				DebugExtensions.DebugSphereCast(ray.origin, ray.direction, maxDistance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return array;
		}

		public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCastNonAlloc(origin, radius, direction, results, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCastNonAlloc(origin, radius, direction, results, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCastNonAlloc(origin, radius, direction, results, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			int num = UnityEngine.Physics.SphereCastNonAlloc(origin, radius, direction, results, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				float num2 = 0f;
				for (int i = 0; i < num; i++)
				{
					RaycastHit raycastHit = results[i];
					flag = true;
					if (raycastHit.distance > num2)
					{
						num2 = raycastHit.distance;
					}
					DebugExtensions.DebugPoint(raycastHit.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugWireSphere(origin + direction * raycastHit.distance, hitColor ?? Color.green, radius, drawDuration, preview, drawDepth);
				}
				maxDistance = ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				DebugExtensions.DebugSphereCast(origin, direction, maxDistance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return num;
		}

		public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCastNonAlloc(ray, radius, results, M_maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results, float maxDistance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCastNonAlloc(ray, radius, results, maxDistance, M_layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results, float maxDistance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return SphereCastNonAlloc(ray, radius, results, maxDistance, layerMask, M_queryTriggerInteraction, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			int num = UnityEngine.Physics.SphereCastNonAlloc(ray, radius, results, maxDistance, layerMask, queryTriggerInteraction);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				float num2 = 0f;
				for (int i = 0; i < num; i++)
				{
					RaycastHit raycastHit = results[i];
					flag = true;
					if (raycastHit.distance > num2)
					{
						num2 = raycastHit.distance;
					}
					DebugExtensions.DebugPoint(raycastHit.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugWireSphere(ray.origin + ray.direction * raycastHit.distance, hitColor ?? Color.green, radius, drawDuration, preview, drawDepth);
				}
				maxDistance = ((maxDistance == M_maxDistance) ? 1000000f : maxDistance);
				DebugExtensions.DebugSphereCast(ray.origin, ray.direction, maxDistance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return num;
		}
	}
}
