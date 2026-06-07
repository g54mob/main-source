using System.Diagnostics;
using DV.Common;
using UnityEngine;

public static class TeleportRaycastLogic
{
	private const float PLAYER_CAPSULE_RADIUS = 0.23f;

	private const float MAX_DIST_BELOW = 2f;

	private const float MAX_DIST_ABOVE = 2f;

	private const float UP_THRESHOLD = 0.66f;

	private const float PREFER_BELOW_POINT_THRESHOLD = 0.6f;

	private const float DEPENETRATION_Y_THRESHOLD = 0.025f;

	private static SphereCollider utilSphereCollider;

	private static Collider[] clippingColliders = new Collider[3];

	private const string PROF_AdjustHit = "PROF_AdjustHit";

	public static Vector3 GetSphereCenterFromSpherecastHit(Vector3 rayOrigin, Vector3 hitPosition, float sphereRadius)
	{
		float num = Vector3.Distance(new Vector3(rayOrigin.x, 0f, rayOrigin.z), new Vector3(hitPosition.x, 0f, hitPosition.z));
		if (num > sphereRadius)
		{
			UnityEngine.Debug.LogError("Invalid hitPosition was passed, returning placeholder value");
			return rayOrigin;
		}
		float y = hitPosition.y + sphereRadius * Mathf.Cos(Mathf.Asin(num / sphereRadius));
		return new Vector3(rayOrigin.x, y, rayOrigin.z);
	}

	public static bool AdjustHit(Vector3 origin, RaycastHit originalHit, out RaycastHit adjustedHit, LayerMask layerMask, float playerHeight)
	{
		float num = Vector3.Dot(originalHit.normal, Vector3.up);
		if (num < -0.05f)
		{
			adjustedHit = originalHit;
			if (originalHit.collider.gameObject.layer == LayerMask.NameToLayer("Water"))
			{
				return true;
			}
			return false;
		}
		Vector3 vector = WorldBoundaryEnforcer.ClampVector(WorldBoundaryEnforcer.ClampPoint(origin, 0.15f), originalHit.point, usingWorldShift: true, 0.1f);
		if (vector != originalHit.point)
		{
			RaycastHit raycastHit = originalHit;
			raycastHit.point = vector;
			if (Below(raycastHit, out var adjustedHit2, layerMask, playerHeight))
			{
				adjustedHit = adjustedHit2;
				return true;
			}
			adjustedHit = raycastHit;
			return false;
		}
		if (num > 0.66f)
		{
			RaycastHit raycastHit2 = originalHit;
			if (!ClippingOK(originalHit.point, out var depenetration, layerMask))
			{
				raycastHit2.point += depenetration;
			}
			if (HeadClearanceOK(raycastHit2.point, layerMask, playerHeight))
			{
				adjustedHit = raycastHit2;
				return true;
			}
		}
		RaycastHit adjustedHit3;
		bool flag = Above(originalHit, out adjustedHit3, layerMask, playerHeight);
		RaycastHit adjustedHit4;
		bool flag2 = Below(originalHit, out adjustedHit4, layerMask, playerHeight);
		if (flag && flag2)
		{
			float num2 = Vector3.Distance(originalHit.point, adjustedHit3.point);
			float num3 = Vector3.Distance(originalHit.point, adjustedHit4.point);
			bool flag3 = num3 < (num2 + num3) * 0.6f;
			bool flag4 = adjustedHit4.rigidbody == originalHit.rigidbody;
			adjustedHit = ((flag3 && flag4) ? adjustedHit4 : adjustedHit3);
			return true;
		}
		if (flag)
		{
			adjustedHit = adjustedHit3;
			return true;
		}
		if (flag2)
		{
			adjustedHit = adjustedHit4;
			return true;
		}
		adjustedHit = originalHit;
		return false;
	}

	private static bool HeadClearanceOK(Vector3 position, LayerMask layerMask, float playerHeight)
	{
		if (Physics.SphereCast(position, 0.23f, Vector3.up, out var _, playerHeight - 0.23f, layerMask, QueryTriggerInteraction.Ignore))
		{
			return false;
		}
		return true;
	}

	private static bool WallCheckOK(Vector3 originalPos, Vector3 adjustedPos, int layerMask, float playerHeight)
	{
		Vector3 vector = adjustedPos + Vector3.up * (playerHeight / 2f);
		Vector3 vector2 = new Vector3(originalPos.x, vector.y, originalPos.z);
		Vector3 direction = vector - vector2;
		if (Physics.Raycast(vector2, direction, out var _, direction.magnitude, layerMask, QueryTriggerInteraction.Ignore))
		{
			return false;
		}
		return true;
	}

	private static bool ClippingOK(Vector3 position, out Vector3 depenetration, LayerMask layerMask)
	{
		position.y += 0.23f;
		int num = Physics.OverlapSphereNonAlloc(position, 0.23f, clippingColliders, layerMask, QueryTriggerInteraction.Ignore);
		depenetration = Vector3.zero;
		if (num == 0)
		{
			return true;
		}
		MakeUtilSphereColliderIfNeeded();
		for (int i = 0; i < num; i++)
		{
			Collider collider = clippingColliders[i];
			if (Physics.ComputePenetration(utilSphereCollider, position, Quaternion.identity, collider, collider.transform.position, collider.transform.rotation, out var direction, out var distance) && Mathf.Abs(direction.y) < 0.025f)
			{
				Vector3 vector = direction * distance;
				depenetration += vector;
			}
		}
		depenetration *= 1.01f;
		return false;
	}

	private static bool Below(RaycastHit originalHit, out RaycastHit adjustedHit, LayerMask layerMask, float playerHeight)
	{
		Vector3 vector = originalHit.point + originalHit.normal * 0.28f + Vector3.up * 0.23f;
		Vector3 down = Vector3.down;
		if (Physics.SphereCast(vector, 0.23f, down, out var hitInfo, 2f, layerMask, QueryTriggerInteraction.Ignore))
		{
			bool num = hitInfo.collider.GetComponent<TeleportArcPassThrough>() != null;
			Vector3 sphereCenterFromSpherecastHit = GetSphereCenterFromSpherecastHit(vector, hitInfo.point, 0.23f);
			hitInfo.point = new Vector3(vector.x, sphereCenterFromSpherecastHit.y - 0.23f, vector.z);
			if (!num && HeadClearanceOK(hitInfo.point, layerMask, playerHeight) && WallCheckOK(vector, hitInfo.point, layerMask, playerHeight))
			{
				adjustedHit = hitInfo;
				return true;
			}
		}
		adjustedHit = originalHit;
		return false;
	}

	private static bool Above(RaycastHit originalHit, out RaycastHit adjustedHit, LayerMask layerMask, float playerHeight)
	{
		Vector3 origin = originalHit.point + Vector3.up * 2f - originalHit.normal * 0.23f;
		Vector3 vector = originalHit.point + originalHit.normal * 0.05f;
		Vector3 direction = new Vector3(vector.x, origin.y, vector.z) - vector;
		if (!Physics.Raycast(vector, direction, direction.magnitude, layerMask, QueryTriggerInteraction.Ignore) && Physics.SphereCast(origin, 0.23f, Vector3.down, out var hitInfo, 2f, layerMask, QueryTriggerInteraction.Ignore))
		{
			bool flag = hitInfo.collider.GetComponent<TeleportArcPassThrough>() != null;
			if (hitInfo.rigidbody == originalHit.rigidbody && HeadClearanceOK(hitInfo.point, layerMask, playerHeight) && !flag && WallCheckOK(vector, hitInfo.point, layerMask, playerHeight))
			{
				adjustedHit = hitInfo;
				return true;
			}
		}
		adjustedHit = originalHit;
		return false;
	}

	private static void MakeUtilSphereColliderIfNeeded()
	{
		if (!(utilSphereCollider != null))
		{
			GameObject gameObject = new GameObject("[TeleportRaycastLogic util]");
			gameObject.transform.position = new Vector3(1200f, -5000f, 1200f);
			SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
			sphereCollider.radius = 0.23f;
			utilSphereCollider = sphereCollider;
		}
	}

	[Conditional("DRAW_DEBUG_LINES")]
	private static void DrawRay(Vector3 position, Vector3 dir, Color color)
	{
		GLDebug.DrawRay(position, dir, color);
	}

	[Conditional("DRAW_DEBUG_LINES")]
	private static void DrawArrow(Vector3 position, Vector3 dir, Color color, float headLength = 0.25f)
	{
		Color? color2 = color;
		GLDebug.DrawArrow(position, dir, headLength, 20f, color2);
	}

	[Conditional("DRAW_DEBUG_LINES")]
	private static void DrawLineArrow(Vector3 start, Vector3 end, Color color, float headLength = 0.25f)
	{
		Color? color2 = color;
		GLDebug.DrawLineArrow(start, end, headLength, 20f, color2);
	}

	[Conditional("DRAW_DEBUG_LINES")]
	private static void DrawLine(Vector3 start, Vector3 end, Color color)
	{
		GLDebug.DrawLine(start, end, color);
	}
}
