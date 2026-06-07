using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Utilities/VRTK_CustomRaycast")]
	public class VRTK_CustomRaycast : MonoBehaviour
	{
		[Tooltip("The layers to ignore when raycasting.")]
		public LayerMask layersToIgnore = 4;

		[Tooltip("Determines whether the ray will interact with trigger colliders.")]
		public QueryTriggerInteraction triggerInteraction;

		public static bool Raycast(VRTK_CustomRaycast customCast, Ray ray, out RaycastHit hitData, LayerMask ignoreLayers, float length = float.PositiveInfinity, QueryTriggerInteraction affectTriggers = QueryTriggerInteraction.UseGlobal)
		{
			if (customCast != null)
			{
				return customCast.CustomRaycast(ray, out hitData, length);
			}
			return Physics.Raycast(ray, out hitData, length, ~(int)ignoreLayers, affectTriggers);
		}

		public static bool Linecast(VRTK_CustomRaycast customCast, Vector3 startPosition, Vector3 endPosition, out RaycastHit hitData, LayerMask ignoreLayers, QueryTriggerInteraction affectTriggers = QueryTriggerInteraction.UseGlobal)
		{
			if (customCast != null)
			{
				return customCast.CustomLinecast(startPosition, endPosition, out hitData);
			}
			return Physics.Linecast(startPosition, endPosition, out hitData, ~(int)ignoreLayers, affectTriggers);
		}

		public static bool CapsuleCast(VRTK_CustomRaycast customCast, Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, out RaycastHit hitData, LayerMask ignoreLayers, QueryTriggerInteraction affectTriggers = QueryTriggerInteraction.UseGlobal)
		{
			if (customCast != null)
			{
				return customCast.CustomCapsuleCast(point1, point2, radius, direction, maxDistance, out hitData);
			}
			return Physics.CapsuleCast(point1, point2, radius, direction, out hitData, maxDistance, ~(int)ignoreLayers, affectTriggers);
		}

		public static bool BoxCast(VRTK_CustomRaycast customCast, Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, out RaycastHit hitData, LayerMask ignoreLayers, QueryTriggerInteraction affectTriggers = QueryTriggerInteraction.UseGlobal)
		{
			if (customCast != null)
			{
				return customCast.CustomBoxCast(center, halfExtents, direction, orientation, maxDistance, out hitData);
			}
			return Physics.BoxCast(center, halfExtents, direction, out hitData, orientation, maxDistance, ~(int)ignoreLayers, affectTriggers);
		}

		public virtual bool CustomRaycast(Ray ray, out RaycastHit hitData, float length = float.PositiveInfinity)
		{
			return Physics.Raycast(ray, out hitData, length, ~(int)layersToIgnore, triggerInteraction);
		}

		public virtual bool CustomLinecast(Vector3 startPosition, Vector3 endPosition, out RaycastHit hitData)
		{
			return Physics.Linecast(startPosition, endPosition, out hitData, ~(int)layersToIgnore, triggerInteraction);
		}

		public virtual bool CustomCapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, out RaycastHit hitData)
		{
			return Physics.CapsuleCast(point1, point2, radius, direction, out hitData, maxDistance, ~(int)layersToIgnore, triggerInteraction);
		}

		public virtual bool CustomBoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, out RaycastHit hitData)
		{
			return Physics.BoxCast(center, halfExtents, direction, out hitData, orientation, maxDistance, ~(int)layersToIgnore, triggerInteraction);
		}
	}
}
