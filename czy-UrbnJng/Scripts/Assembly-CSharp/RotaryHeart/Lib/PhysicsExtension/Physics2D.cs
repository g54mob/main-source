using System.Collections.Generic;
using RotaryHeart.Lib.UnityGLDebug;
using UnityEngine;

namespace RotaryHeart.Lib.PhysicsExtension
{
	public static class Physics2D
	{
		private static float M_maxDistance = float.PositiveInfinity;

		private static Color M_castColor = new Color(1f, 0.5f, 0f, 1f);

		public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCast(origin, size, angle, direction, M_maxDistance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCast(origin, size, angle, direction, distance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, LayerMask layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCast(origin, size, angle, direction, distance, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, LayerMask layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCast(origin, size, angle, direction, distance, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, LayerMask layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit2D result = UnityEngine.Physics2D.BoxCast(origin, size, angle, direction, distance, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				size /= 2f;
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				bool flag = result.collider != null;
				Quaternion orientation = Quaternion.Euler(0f, 0f, angle);
				if (flag)
				{
					DebugExtensions.DebugPoint(result.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					distance = result.distance;
				}
				DebugExtensions.DebugBoxCast(origin, size, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), orientation, drawDuration, drawType, preview, drawDepth);
			}
			return result;
		}

		public static int BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCast(origin, size, angle, direction, contactFilter, results, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			int num = UnityEngine.Physics2D.BoxCast(origin, size, angle, direction, contactFilter, results, distance);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				float num2 = 0f;
				size /= 2f;
				Quaternion orientation = Quaternion.Euler(0f, 0f, angle);
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					if (raycastHit2D.distance > num2)
					{
						num2 = raycastHit2D.distance;
					}
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugBox(origin + direction * raycastHit2D.distance, size, hitColor ?? Color.green, orientation, drawDuration, preview, drawDepth);
				}
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				DebugExtensions.DebugBoxCast(origin, size, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), Quaternion.identity, drawDuration, drawType, preview, drawDepth);
			}
			return num;
		}

		public static int BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCast(origin, size, angle, direction, contactFilter, results, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			int num = UnityEngine.Physics2D.BoxCast(origin, size, angle, direction, contactFilter, results, distance);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				float num2 = 0f;
				size /= 2f;
				Quaternion orientation = Quaternion.Euler(0f, 0f, angle);
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					if (raycastHit2D.distance > num2)
					{
						num2 = raycastHit2D.distance;
					}
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugBox(origin + direction * raycastHit2D.distance, size, hitColor ?? Color.green, orientation, drawDuration, preview, drawDepth);
				}
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				DebugExtensions.DebugBoxCast(origin, size, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), Quaternion.identity, drawDuration, drawType, preview, drawDepth);
			}
			return num;
		}

		public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastAll(origin, size, angle, direction, M_maxDistance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastAll(origin, size, angle, direction, distance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastAll(origin, size, angle, direction, distance, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastAll(origin, size, angle, direction, distance, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit2D[] array = UnityEngine.Physics2D.BoxCastAll(origin, size, angle, direction, distance, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				float num = 0f;
				size /= 2f;
				Quaternion orientation = Quaternion.Euler(0f, 0f, angle);
				RaycastHit2D[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit2D raycastHit2D = array2[i];
					flag = true;
					if (raycastHit2D.distance > num)
					{
						num = raycastHit2D.distance;
					}
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugBox(origin + direction * raycastHit2D.distance, size, hitColor ?? Color.green, orientation, drawDuration, preview, drawDepth);
				}
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				DebugExtensions.DebugBoxCast(origin, size, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), orientation, drawDuration, drawType, preview, drawDepth);
			}
			return array;
		}

		public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastNonAlloc(origin, size, angle, direction, results, M_maxDistance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastNonAlloc(origin, size, angle, direction, results, distance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastNonAlloc(origin, size, angle, direction, results, distance, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return BoxCastNonAlloc(origin, size, angle, direction, results, distance, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			int num = UnityEngine.Physics2D.BoxCastNonAlloc(origin, size, angle, direction, results, distance, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				float num2 = 0f;
				size /= 2f;
				Quaternion orientation = Quaternion.Euler(0f, 0f, angle);
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					if (raycastHit2D.distance > num2)
					{
						num2 = raycastHit2D.distance;
					}
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugBox(origin + direction * raycastHit2D.distance, size, hitColor ?? Color.green, orientation, drawDuration, preview, drawDepth);
				}
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				DebugExtensions.DebugBoxCast(origin, size, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), orientation, drawDuration, drawType, preview, drawDepth);
			}
			return num;
		}

		public static RaycastHit2D CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCast(origin, size, capsuleDirection, angle, direction, M_maxDistance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit2D result = UnityEngine.Physics2D.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				size /= 2f;
				Quaternion quaternion = Quaternion.Euler(0f, 0f, angle);
				if (result.collider != null)
				{
					flag = true;
					distance = result.distance;
					DebugExtensions.DebugPoint(result.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
				}
				float radius;
				Vector2 vector;
				Vector2 vector2;
				if (capsuleDirection == CapsuleDirection2D.Vertical)
				{
					if (size.y > size.x)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.x;
				}
				else
				{
					if (size.x > size.y)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.y;
				}
				vector = (Vector2)(quaternion * vector) + origin;
				vector2 = (Vector2)(quaternion * vector2) + origin;
				DebugExtensions.DebugOneSidedCapsuleCast(vector, vector2, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return result;
		}

		public static int CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCast(origin, size, capsuleDirection, angle, direction, contactFilter, results, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			int num = UnityEngine.Physics2D.CapsuleCast(origin, size, capsuleDirection, angle, direction, contactFilter, results, distance);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				size /= 2f;
				Quaternion quaternion = Quaternion.Euler(0f, 0f, angle);
				float radius;
				Vector2 vector;
				Vector2 vector2;
				if (capsuleDirection == CapsuleDirection2D.Vertical)
				{
					if (size.y > size.x)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.x;
				}
				else
				{
					if (size.x > size.y)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.y;
				}
				vector = (Vector2)(quaternion * vector) + origin;
				vector2 = (Vector2)(quaternion * vector2) + origin;
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugOneSidedCapsule(vector + direction * raycastHit2D.distance, vector2 + direction * raycastHit2D.distance, hitColor ?? Color.green, radius, colorizeBase: true, drawDuration, preview, drawDepth);
				}
				DebugExtensions.DebugOneSidedCapsuleCast(vector, vector2, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return num;
		}

		public static int CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCast(origin, size, capsuleDirection, angle, direction, contactFilter, results, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			int num = UnityEngine.Physics2D.CapsuleCast(origin, size, capsuleDirection, angle, direction, contactFilter, results, distance);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				size /= 2f;
				Quaternion quaternion = Quaternion.Euler(0f, 0f, angle);
				float radius;
				Vector2 vector;
				Vector2 vector2;
				if (capsuleDirection == CapsuleDirection2D.Vertical)
				{
					if (size.y > size.x)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.x;
				}
				else
				{
					if (size.x > size.y)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.y;
				}
				vector = (Vector2)(quaternion * vector) + origin;
				vector2 = (Vector2)(quaternion * vector2) + origin;
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugOneSidedCapsule(vector + direction * raycastHit2D.distance, vector2 + direction * raycastHit2D.distance, hitColor ?? Color.green, radius, colorizeBase: true, drawDuration, preview, drawDepth);
				}
				DebugExtensions.DebugOneSidedCapsuleCast(vector, vector2, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return num;
		}

		public static RaycastHit2D[] CapsuleCastAll(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastAll(origin, size, capsuleDirection, angle, direction, M_maxDistance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D[] CapsuleCastAll(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastAll(origin, size, capsuleDirection, angle, direction, distance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D[] CapsuleCastAll(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastAll(origin, size, capsuleDirection, angle, direction, distance, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D[] CapsuleCastAll(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastAll(origin, size, capsuleDirection, angle, direction, distance, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D[] CapsuleCastAll(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit2D[] array = UnityEngine.Physics2D.CapsuleCastAll(origin, size, capsuleDirection, angle, direction, distance, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				size /= 2f;
				Quaternion quaternion = Quaternion.Euler(0f, 0f, angle);
				bool flag = false;
				float num = 0f;
				float radius;
				Vector2 vector;
				Vector2 vector2;
				if (capsuleDirection == CapsuleDirection2D.Vertical)
				{
					if (size.y > size.x)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.x;
				}
				else
				{
					if (size.x > size.y)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.y;
				}
				vector = (Vector2)(quaternion * vector) + origin;
				vector2 = (Vector2)(quaternion * vector2) + origin;
				RaycastHit2D[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit2D raycastHit2D = array2[i];
					flag = true;
					if (raycastHit2D.distance > num)
					{
						num = raycastHit2D.distance;
					}
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugOneSidedCapsule(vector + direction * raycastHit2D.distance, vector2 + direction * raycastHit2D.distance, hitColor ?? Color.green, radius, colorizeBase: true, drawDuration, preview, drawDepth);
				}
				DebugExtensions.DebugOneSidedCapsuleCast(vector, vector2, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return array;
		}

		public static int CapsuleCastNonAlloc(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, RaycastHit2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastNonAlloc(origin, size, capsuleDirection, angle, direction, results, M_maxDistance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CapsuleCastNonAlloc(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, RaycastHit2D[] results, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastNonAlloc(origin, size, capsuleDirection, angle, direction, results, distance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CapsuleCastNonAlloc(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastNonAlloc(origin, size, capsuleDirection, angle, direction, results, distance, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CapsuleCastNonAlloc(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CapsuleCastNonAlloc(origin, size, capsuleDirection, angle, direction, results, distance, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CapsuleCastNonAlloc(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			int num = UnityEngine.Physics2D.CapsuleCastNonAlloc(origin, size, capsuleDirection, angle, direction, results, distance, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				float num2 = 0f;
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				size /= 2f;
				Quaternion quaternion = Quaternion.Euler(0f, 0f, angle);
				float radius;
				Vector2 vector;
				Vector2 vector2;
				if (capsuleDirection == CapsuleDirection2D.Vertical)
				{
					if (size.y > size.x)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.x;
				}
				else
				{
					if (size.x > size.y)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.y;
				}
				vector = (Vector2)(quaternion * vector) + origin;
				vector2 = (Vector2)(quaternion * vector2) + origin;
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					if (raycastHit2D.distance > num2)
					{
						num2 = raycastHit2D.distance;
					}
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugOneSidedCapsule(vector + direction * raycastHit2D.distance, vector2 + direction * raycastHit2D.distance, hitColor ?? Color.green, radius, colorizeBase: true, drawDuration, preview, drawDepth);
				}
				DebugExtensions.DebugOneSidedCapsuleCast(vector, vector2, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return num;
		}

		public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCast(origin, radius, direction, M_maxDistance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCast(origin, radius, direction, distance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCast(origin, radius, direction, distance, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCast(origin, radius, direction, distance, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit2D result = UnityEngine.Physics2D.CircleCast(origin, radius, direction, distance, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				bool flag = result.collider != null;
				if (flag)
				{
					DebugExtensions.DebugPoint(result.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					distance = result.distance;
				}
				DebugExtensions.DebugCircleCast(origin, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return result;
		}

		public static int CircleCast(Vector2 origin, float radius, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCast(origin, radius, direction, contactFilter, results, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CircleCast(Vector2 origin, float radius, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			int num = UnityEngine.Physics2D.CircleCast(origin, radius, direction, contactFilter, results, distance);
			if (preview != PreviewCondition.None)
			{
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				bool flag = false;
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugCircle(origin + direction * raycastHit2D.distance, Vector3.forward, hitColor ?? Color.green, radius, drawDuration, preview, drawDepth);
				}
				DebugExtensions.DebugCircleCast(origin, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return num;
		}

		public static int CircleCast(Vector2 origin, float radius, Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCast(origin, radius, direction, contactFilter, results, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CircleCast(Vector2 origin, float radius, Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			int num = UnityEngine.Physics2D.CircleCast(origin, radius, direction, contactFilter, results, distance);
			if (preview != PreviewCondition.None)
			{
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				bool flag = false;
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugCircle(origin + direction * raycastHit2D.distance, Vector3.forward, hitColor ?? Color.green, radius, drawDuration, preview, drawDepth);
				}
				DebugExtensions.DebugCircleCast(origin, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return num;
		}

		public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCastAll(origin, radius, direction, M_maxDistance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCastAll(origin, radius, direction, distance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCastAll(origin, radius, direction, distance, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCastAll(origin, radius, direction, distance, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			RaycastHit2D[] array = UnityEngine.Physics2D.CircleCastAll(origin, radius, direction, distance, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				RaycastHit2D[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit2D raycastHit2D = array2[i];
					flag = true;
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugCircle(origin + direction * raycastHit2D.distance, Vector3.forward, hitColor ?? Color.green, radius, drawDuration, preview, drawDepth);
				}
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				DebugExtensions.DebugCircleCast(origin, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return array;
		}

		public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCastNonAlloc(origin, radius, direction, results, M_maxDistance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCastNonAlloc(origin, radius, direction, results, distance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCastNonAlloc(origin, radius, direction, results, distance, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			return CircleCastNonAlloc(origin, radius, direction, results, distance, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth, drawType);
		}

		public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false, CastDrawType drawType = CastDrawType.Minimal)
		{
			int num = UnityEngine.Physics2D.CircleCastNonAlloc(origin, radius, direction, results, distance, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					DebugExtensions.DebugCircle(origin + direction * raycastHit2D.distance, Vector3.forward, hitColor ?? Color.green, radius, drawDuration, preview, drawDepth);
				}
				distance = ((distance == M_maxDistance) ? 1000000f : distance);
				DebugExtensions.DebugCircleCast(origin, direction, distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, drawType, preview, drawDepth);
			}
			return num;
		}

		public static RaycastHit2D Linecast(Vector2 start, Vector2 end, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Linecast(start, end, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D Linecast(Vector2 start, Vector2 end, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Linecast(start, end, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D Linecast(Vector2 start, Vector2 end, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Linecast(start, end, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D Linecast(Vector2 start, Vector2 end, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit2D result = UnityEngine.Physics2D.Linecast(start, end, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				if (result.collider != null)
				{
					flag = true;
					end = result.point;
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
			return result;
		}

		public static int Linecast(Vector2 start, Vector2 end, ContactFilter2D contactFilter, RaycastHit2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.Linecast(start, end, contactFilter, results);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				Vector2 vector = start;
				Vector2 vector2 = start;
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
					{
						Debug.DrawLine(vector2, raycastHit2D.point, hitColor ?? Color.green, drawDuration);
					}
					if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
					{
						GLDebug.DrawLine(vector2, raycastHit2D.point, hitColor ?? Color.green, drawDuration);
					}
					if ((start - raycastHit2D.point).sqrMagnitude > (start - vector).sqrMagnitude)
					{
						vector = raycastHit2D.point;
					}
					vector2 = raycastHit2D.point;
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
			return num;
		}

		public static int Linecast(Vector2 start, Vector2 end, ContactFilter2D contactFilter, List<RaycastHit2D> results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.Linecast(start, end, contactFilter, results);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				Vector2 vector = start;
				Vector2 vector2 = start;
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
					{
						Debug.DrawLine(vector2, raycastHit2D.point, hitColor ?? Color.green, drawDuration);
					}
					if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
					{
						GLDebug.DrawLine(vector2, raycastHit2D.point, hitColor ?? Color.green, drawDuration);
					}
					if ((start - raycastHit2D.point).sqrMagnitude > (start - vector).sqrMagnitude)
					{
						vector = raycastHit2D.point;
					}
					vector2 = raycastHit2D.point;
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
			return num;
		}

		public static RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return LinecastAll(start, end, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return LinecastAll(start, end, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return LinecastAll(start, end, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit2D[] array = UnityEngine.Physics2D.LinecastAll(start, end, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				Vector2 vector = start;
				Vector2 vector2 = start;
				RaycastHit2D[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit2D raycastHit2D = array2[i];
					flag = true;
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
					{
						Debug.DrawLine(vector2, raycastHit2D.point, hitColor ?? Color.green, drawDuration);
					}
					if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
					{
						GLDebug.DrawLine(vector2, raycastHit2D.point, hitColor ?? Color.green, drawDuration);
					}
					if ((start - raycastHit2D.point).sqrMagnitude > (start - vector).sqrMagnitude)
					{
						vector = raycastHit2D.point;
					}
					vector2 = raycastHit2D.point;
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
			return array;
		}

		public static int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return LinecastNonAlloc(start, end, results, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return LinecastNonAlloc(start, end, results, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return LinecastNonAlloc(start, end, results, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.LinecastNonAlloc(start, end, results, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				Vector2 vector = start;
				Vector2 vector2 = start;
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
					{
						Debug.DrawLine(vector2, raycastHit2D.point, hitColor ?? Color.green, drawDuration);
					}
					if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
					{
						GLDebug.DrawLine(vector2, raycastHit2D.point, hitColor ?? Color.green, drawDuration);
					}
					if ((start - raycastHit2D.point).sqrMagnitude > (start - vector).sqrMagnitude)
					{
						vector = raycastHit2D.point;
					}
					vector2 = raycastHit2D.point;
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
			return num;
		}

		public static Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapArea(pointA, pointB, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapArea(pointA, pointB, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapArea(pointA, pointB, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			Collider2D collider2D = UnityEngine.Physics2D.OverlapArea(pointA, pointB, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				Vector2 vector = pointA;
				Vector2 vector2 = new Vector2(pointA.x, pointB.y);
				Vector2 vector3 = pointB;
				Vector2 vector4 = new Vector2(pointB.x, pointA.y);
				Color color = ((!(collider2D != null)) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green));
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector, vector2, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector, vector2, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector2, vector3, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector2, vector3, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector3, vector4, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector3, vector4, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector4, vector, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector4, vector, color, drawDuration);
				}
			}
			return collider2D;
		}

		public static int OverlapArea(Vector2 pointA, Vector2 pointB, ContactFilter2D contactFilter, Collider2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapArea(pointA, pointB, contactFilter, results);
			if (preview != PreviewCondition.None)
			{
				Vector2 vector = pointA;
				Vector2 vector2 = new Vector2(pointA.x, pointB.y);
				Vector2 vector3 = pointB;
				Vector2 vector4 = new Vector2(pointB.x, pointA.y);
				Color color = ((num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green));
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector, vector2, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector, vector2, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector2, vector3, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector2, vector3, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector3, vector4, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector3, vector4, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector4, vector, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector4, vector, color, drawDuration);
				}
			}
			return num;
		}

		public static int OverlapArea(Vector2 pointA, Vector2 pointB, ContactFilter2D contactFilter, List<Collider2D> results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapArea(pointA, pointB, contactFilter, results);
			if (preview != PreviewCondition.None)
			{
				Vector2 vector = pointA;
				Vector2 vector2 = new Vector2(pointA.x, pointB.y);
				Vector2 vector3 = pointB;
				Vector2 vector4 = new Vector2(pointB.x, pointA.y);
				Color color = ((num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green));
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector, vector2, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector, vector2, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector2, vector3, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector2, vector3, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector3, vector4, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector3, vector4, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector4, vector, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector4, vector, color, drawDuration);
				}
			}
			return num;
		}

		public static Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapAreaAll(pointA, pointB, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapAreaAll(pointA, pointB, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapAreaAll(pointA, pointB, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			Collider2D[] array = UnityEngine.Physics2D.OverlapAreaAll(pointA, pointB, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				Vector2 vector = pointA;
				Vector2 vector2 = new Vector2(pointA.x, pointB.y);
				Vector2 vector3 = pointB;
				Vector2 vector4 = new Vector2(pointB.x, pointA.y);
				Color color = ((array.Length == 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green));
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector, vector2, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector, vector2, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector2, vector3, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector2, vector3, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector3, vector4, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector3, vector4, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector4, vector, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector4, vector, color, drawDuration);
				}
			}
			return array;
		}

		public static int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapAreaNonAlloc(pointA, pointB, results, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapAreaNonAlloc(pointA, pointB, results, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapAreaNonAlloc(pointA, pointB, results, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapAreaNonAlloc(pointA, pointB, results, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				Vector2 vector = pointA;
				Vector2 vector2 = new Vector2(pointA.x, pointB.y);
				Vector2 vector3 = pointB;
				Vector2 vector4 = new Vector2(pointB.x, pointA.y);
				Color color = ((num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green));
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector, vector2, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector, vector2, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector2, vector3, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector2, vector3, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector3, vector4, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector3, vector4, color, drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector4, vector, color, drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector4, vector, color, drawDuration);
				}
			}
			return num;
		}

		public static Collider2D OverlapBox(Vector2 point, Vector2 size, float angle, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBox(point, size, angle, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapBox(Vector2 point, Vector2 size, float angle, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBox(point, size, angle, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapBox(Vector2 point, Vector2 size, float angle, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBox(point, size, angle, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapBox(Vector2 point, Vector2 size, float angle, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			Collider2D collider2D = UnityEngine.Physics2D.OverlapBox(point, size, angle, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				size /= 2f;
				DebugExtensions.DebugBox(point, size, (!collider2D) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), Quaternion.Euler(0f, 0f, angle), drawDuration, preview, drawDepth);
			}
			return collider2D;
		}

		public static int OverlapBox(Vector2 point, Vector2 size, float angle, ContactFilter2D contactFilter, Collider2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapBox(point, size, angle, contactFilter, results);
			if (preview != PreviewCondition.None)
			{
				size /= 2f;
				DebugExtensions.DebugBox(point, size, (num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), Quaternion.Euler(0f, 0f, angle), drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static int OverlapBox(Vector2 point, Vector2 size, float angle, ContactFilter2D contactFilter, List<Collider2D> results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapBox(point, size, angle, contactFilter, results);
			if (preview != PreviewCondition.None)
			{
				size /= 2f;
				DebugExtensions.DebugBox(point, size, (num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), Quaternion.Euler(0f, 0f, angle), drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static Collider2D[] OverlapBoxAll(Vector2 point, Vector2 size, float angle, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBoxAll(point, size, angle, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapBoxAll(Vector2 point, Vector2 size, float angle, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBoxAll(point, size, angle, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapBoxAll(Vector2 point, Vector2 size, float angle, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBoxAll(point, size, angle, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapBoxAll(Vector2 point, Vector2 size, float angle, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			Collider2D[] array = UnityEngine.Physics2D.OverlapBoxAll(point, size, angle, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				size /= 2f;
				DebugExtensions.DebugBox(point, size, (array == null || array.Length == 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), Quaternion.Euler(0f, 0f, angle), drawDuration, preview, drawDepth);
			}
			return array;
		}

		public static int OverlapBoxNonAlloc(Vector2 point, Vector2 size, float angle, Collider2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBoxNonAlloc(point, size, angle, results, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapBoxNonAlloc(Vector2 point, Vector2 size, float angle, Collider2D[] results, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBoxNonAlloc(point, size, angle, results, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapBoxNonAlloc(Vector2 point, Vector2 size, float angle, Collider2D[] results, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapBoxNonAlloc(point, size, angle, results, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapBoxNonAlloc(Vector2 point, Vector2 size, float angle, Collider2D[] results, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapBoxNonAlloc(point, size, angle, results, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				size /= 2f;
				DebugExtensions.DebugBox(point, size, (num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), Quaternion.Euler(0f, 0f, angle), drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static Collider2D OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCapsule(point, size, direction, angle, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCapsule(point, size, direction, angle, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCapsule(point, size, direction, angle, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			Collider2D collider2D = UnityEngine.Physics2D.OverlapCapsule(point, size, direction, angle, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				size /= 2f;
				float radius;
				Vector2 vector;
				Vector2 vector2;
				if (direction == CapsuleDirection2D.Vertical)
				{
					if (size.y > size.x)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.x;
				}
				else
				{
					if (size.x > size.y)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.y;
				}
				Quaternion quaternion = Quaternion.Euler(0f, 0f, angle);
				vector = (Vector2)(quaternion * vector) + point;
				vector2 = (Vector2)(quaternion * vector2) + point;
				DebugExtensions.DebugOneSidedCapsule(vector, vector2, (!collider2D) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, colorizeBase: true, drawDuration, preview, drawDepth);
			}
			return collider2D;
		}

		public static int OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, ContactFilter2D contactFilter, Collider2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapCapsule(point, size, direction, angle, contactFilter, results);
			if (preview != PreviewCondition.None)
			{
				size /= 2f;
				Quaternion quaternion = Quaternion.Euler(0f, 0f, angle);
				float radius;
				Vector2 vector;
				Vector2 vector2;
				if (direction == CapsuleDirection2D.Vertical)
				{
					if (size.y > size.x)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.x;
				}
				else
				{
					if (size.x > size.y)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.y;
				}
				vector = (Vector2)(quaternion * vector) + point;
				vector2 = (Vector2)(quaternion * vector2) + point;
				DebugExtensions.DebugOneSidedCapsule(vector, vector2, (num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, colorizeBase: true, drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static int OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, ContactFilter2D contactFilter, List<Collider2D> results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapCapsule(point, size, direction, angle, contactFilter, results);
			if (preview != PreviewCondition.None)
			{
				size /= 2f;
				Quaternion quaternion = Quaternion.Euler(0f, 0f, angle);
				float radius;
				Vector2 vector;
				Vector2 vector2;
				if (direction == CapsuleDirection2D.Vertical)
				{
					if (size.y > size.x)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.x;
				}
				else
				{
					if (size.x > size.y)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.y;
				}
				vector = (Vector2)(quaternion * vector) + point;
				vector2 = (Vector2)(quaternion * vector2) + point;
				DebugExtensions.DebugOneSidedCapsule(vector, vector2, (num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, colorizeBase: true, drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static Collider2D[] OverlapCapsuleAll(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCapsuleAll(point, size, direction, angle, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapCapsuleAll(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCapsuleAll(point, size, direction, angle, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapCapsuleAll(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCapsuleAll(point, size, direction, angle, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapCapsuleAll(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			Collider2D[] array = UnityEngine.Physics2D.OverlapCapsuleAll(point, size, direction, angle, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				size /= 2f;
				Quaternion quaternion = Quaternion.Euler(0f, 0f, angle);
				float radius;
				Vector2 vector;
				Vector2 vector2;
				if (direction == CapsuleDirection2D.Vertical)
				{
					if (size.y > size.x)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.x;
				}
				else
				{
					if (size.x > size.y)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.y;
				}
				vector = (Vector2)(quaternion * vector) + point;
				vector2 = (Vector2)(quaternion * vector2) + point;
				DebugExtensions.DebugOneSidedCapsule(vector, vector2, (array == null || array.Length == 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, colorizeBase: true, drawDuration, preview, drawDepth);
			}
			return array;
		}

		public static int OverlapCapsuleNonAlloc(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, Collider2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCapsuleNonAlloc(point, size, direction, angle, results, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapCapsuleNonAlloc(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, Collider2D[] results, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCapsuleNonAlloc(point, size, direction, angle, results, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapCapsuleNonAlloc(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, Collider2D[] results, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCapsuleNonAlloc(point, size, direction, angle, results, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapCapsuleNonAlloc(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, Collider2D[] results, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapCapsuleNonAlloc(point, size, direction, angle, results, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				size /= 2f;
				Quaternion quaternion = Quaternion.Euler(0f, 0f, angle);
				float radius;
				Vector2 vector;
				Vector2 vector2;
				if (direction == CapsuleDirection2D.Vertical)
				{
					if (size.y > size.x)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.x;
				}
				else
				{
					if (size.x > size.y)
					{
						vector = new Vector3(0f, 0f - size.y + size.x);
						vector2 = new Vector3(0f, 0f + size.y - size.x);
					}
					else
					{
						vector = new Vector3(-0.01f, 0f);
						vector2 = new Vector3(0.01f, 0f);
					}
					radius = size.y;
				}
				vector = (Vector2)(quaternion * vector) + point;
				vector2 = (Vector2)(quaternion * vector2) + point;
				DebugExtensions.DebugOneSidedCapsule(vector, vector2, (num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, colorizeBase: true, drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static Collider2D OverlapCircle(Vector2 point, float radius, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCircle(point, radius, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapCircle(Vector2 point, float radius, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCircle(point, radius, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapCircle(Vector2 point, float radius, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCircle(point, radius, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapCircle(Vector2 point, float radius, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			Collider2D collider2D = UnityEngine.Physics2D.OverlapCircle(point, radius, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				DebugExtensions.DebugCircle(point, Vector3.forward, (!collider2D) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, preview, drawDepth);
			}
			return collider2D;
		}

		public static int OverlapCircle(Vector2 point, float radius, ContactFilter2D contactFilter, Collider2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapCircle(point, radius, contactFilter, results);
			if (preview != PreviewCondition.None)
			{
				DebugExtensions.DebugCircle(point, Vector3.forward, (num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static int OverlapCircle(Vector2 point, float radius, ContactFilter2D contactFilter, List<Collider2D> results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapCircle(point, radius, contactFilter, results);
			if (preview != PreviewCondition.None)
			{
				DebugExtensions.DebugCircle(point, Vector3.forward, (num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static Collider2D[] OverlapCircleAll(Vector2 point, float radius, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCircleAll(point, radius, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCircleAll(point, radius, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCircleAll(point, radius, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			Collider2D[] array = UnityEngine.Physics2D.OverlapCircleAll(point, radius, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				DebugExtensions.DebugCircle(point, Vector3.forward, (array == null || array.Length == 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, preview, drawDepth);
			}
			return array;
		}

		public static int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCircleNonAlloc(point, radius, results, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCircleNonAlloc(point, radius, results, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapCircleNonAlloc(point, radius, results, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapCircleNonAlloc(point, radius, results, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				DebugExtensions.DebugCircle(point, Vector3.forward, (num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), radius, drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static Collider2D OverlapPoint(Vector2 point, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapPoint(point, -1, 0f - M_maxDistance, M_maxDistance, size, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapPoint(Vector2 point, int layerMask, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapPoint(point, layerMask, 0f - M_maxDistance, M_maxDistance, size, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapPoint(Vector2 point, int layerMask, float minDepth, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapPoint(point, layerMask, minDepth, M_maxDistance, size, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D OverlapPoint(Vector2 point, int layerMask, float minDepth, float maxDepth, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			Collider2D collider2D = UnityEngine.Physics2D.OverlapPoint(point, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				DebugExtensions.DebugPoint(point, (!collider2D) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), size, drawDuration, preview, drawDepth);
			}
			return collider2D;
		}

		public static int OverlapPoint(Vector2 point, ContactFilter2D contactFilter, Collider2D[] results, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapPoint(point, contactFilter, results);
			if (preview != PreviewCondition.None)
			{
				DebugExtensions.DebugPoint(point, (num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), size, drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static int OverlapPoint(Vector2 point, ContactFilter2D contactFilter, List<Collider2D> results, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapPoint(point, contactFilter, results);
			if (preview != PreviewCondition.None)
			{
				DebugExtensions.DebugPoint(point, (num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), size, drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static Collider2D[] OverlapPointAll(Vector2 point, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapPointAll(point, -1, 0f - M_maxDistance, M_maxDistance, size, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapPointAll(Vector2 point, int layerMask, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapPointAll(point, layerMask, 0f - M_maxDistance, M_maxDistance, size, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapPointAll(Vector2 point, int layerMask, float minDepth, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapPointAll(point, layerMask, minDepth, M_maxDistance, size, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static Collider2D[] OverlapPointAll(Vector2 point, int layerMask, float minDepth, float maxDepth, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			Collider2D[] array = UnityEngine.Physics2D.OverlapPointAll(point, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				DebugExtensions.DebugPoint(point, (array == null || array.Length == 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), size, drawDuration, preview, drawDepth);
			}
			return array;
		}

		public static int OverlapPointNonAlloc(Vector2 point, Collider2D[] results, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapPointNonAlloc(point, results, -1, 0f - M_maxDistance, M_maxDistance, size, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapPointNonAlloc(Vector2 point, Collider2D[] results, int layerMask, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapPointNonAlloc(point, results, layerMask, 0f - M_maxDistance, M_maxDistance, size, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapPointNonAlloc(Vector2 point, Collider2D[] results, int layerMask, float minDepth, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return OverlapPointNonAlloc(point, results, layerMask, minDepth, M_maxDistance, size, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int OverlapPointNonAlloc(Vector2 point, Collider2D[] results, int layerMask, float minDepth, float maxDepth, float size = 6f, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.OverlapPointNonAlloc(point, results, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				DebugExtensions.DebugPoint(point, (num <= 0) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), size, drawDuration, preview, drawDepth);
			}
			return num;
		}

		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Raycast(origin, direction, M_maxDistance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Raycast(origin, direction, distance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Raycast(origin, direction, distance, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Raycast(origin, direction, distance, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit2D result = UnityEngine.Physics2D.Raycast(origin, direction, distance, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				Vector3 vector = origin + direction * ((distance == M_maxDistance) ? 1000000f : distance);
				bool flag = false;
				if (result.collider != null)
				{
					flag = true;
					vector = result.point;
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
			return result;
		}

		public static int Raycast(Vector2 origin, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return Raycast(origin, direction, contactFilter, results, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int Raycast(Vector2 origin, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.Raycast(origin, direction, contactFilter, results, distance);
			if (preview != PreviewCondition.None)
			{
				Vector3 vector = origin + direction * ((distance == M_maxDistance) ? 1000000f : distance);
				bool flag = false;
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					vector = raycastHit2D.point;
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
			return num;
		}

		public static int Raycast(Vector2 origin, Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.Raycast(origin, direction, contactFilter, results, distance);
			if (preview != PreviewCondition.None)
			{
				Vector3 vector = origin + direction * ((distance == M_maxDistance) ? 1000000f : distance);
				bool flag = false;
				for (int i = 0; i < num; i++)
				{
					RaycastHit2D raycastHit2D = results[i];
					flag = true;
					vector = raycastHit2D.point;
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
			return num;
		}

		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastAll(origin, direction, M_maxDistance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastAll(origin, direction, distance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastAll(origin, direction, distance, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastAll(origin, direction, distance, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			RaycastHit2D[] array = UnityEngine.Physics2D.RaycastAll(origin, direction, distance, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				Vector2 vector = origin;
				Vector2 vector2 = origin;
				RaycastHit2D[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit2D raycastHit2D = array2[i];
					flag = true;
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
					{
						Debug.DrawLine(vector2, raycastHit2D.point, hitColor ?? Color.green, drawDuration);
					}
					if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
					{
						GLDebug.DrawLine(vector2, raycastHit2D.point, hitColor ?? Color.green, drawDuration);
					}
					if ((origin - raycastHit2D.point).sqrMagnitude > (origin - vector).sqrMagnitude)
					{
						vector = raycastHit2D.point;
					}
					vector2 = raycastHit2D.point;
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector, origin + direction * distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), drawDuration);
				}
				if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector, origin + direction * distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), drawDuration);
				}
			}
			return array;
		}

		public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastNonAlloc(origin, direction, results, M_maxDistance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastNonAlloc(origin, direction, results, distance, -1, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastNonAlloc(origin, direction, results, distance, layerMask, 0f - M_maxDistance, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			return RaycastNonAlloc(origin, direction, results, distance, layerMask, minDepth, M_maxDistance, preview, drawDuration, hitColor, noHitColor, drawDepth);
		}

		public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth, PreviewCondition preview = PreviewCondition.None, float drawDuration = 0f, Color? hitColor = null, Color? noHitColor = null, bool drawDepth = false)
		{
			int num = UnityEngine.Physics2D.RaycastNonAlloc(origin, direction, results, distance, layerMask, minDepth, maxDepth);
			if (preview != PreviewCondition.None)
			{
				bool flag = false;
				Vector2 vector = origin;
				Vector2 vector2 = origin;
				for (int i = 0; i < num; i++)
				{
					flag = true;
					RaycastHit2D raycastHit2D = results[i];
					DebugExtensions.DebugPoint(raycastHit2D.point, Color.red, 0.5f, drawDuration, preview, drawDepth);
					if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
					{
						Debug.DrawLine(vector2, raycastHit2D.point, hitColor ?? Color.green, drawDuration);
					}
					if (preview == PreviewCondition.Game || preview == PreviewCondition.Both)
					{
						GLDebug.DrawLine(vector2, raycastHit2D.point, hitColor ?? Color.green, drawDuration);
					}
					if ((origin - raycastHit2D.point).sqrMagnitude > (origin - vector).sqrMagnitude)
					{
						vector = raycastHit2D.point;
					}
					vector2 = raycastHit2D.point;
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					Debug.DrawLine(vector, origin + direction * distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), drawDuration);
				}
				if (preview == PreviewCondition.Editor || preview == PreviewCondition.Both)
				{
					GLDebug.DrawLine(vector, origin + direction * distance, (!flag) ? (noHitColor ?? Color.red) : (hitColor ?? Color.green), drawDuration);
				}
			}
			return num;
		}
	}
}
