using UnityEngine;

namespace Aggro.Core
{
	public static class EntityExtensions
	{
		public static Entity GetEntity(this Collider collider)
		{
			if (collider.TryGetComponent<EntityCollider>(out var component))
			{
				return component.entity;
			}
			return Entity.invalid;
		}

		public static bool TryGetEntity(this Collider collider, out Entity entity)
		{
			entity = collider.GetEntity();
			return entity != Entity.invalid;
		}

		public static Entity GetEntity(this GameObject gameObject)
		{
			return gameObject.transform.GetEntity();
		}

		public static bool TryGetEntity(this GameObject gameObject, out Entity entity)
		{
			return gameObject.transform.TryGetEntity(out entity);
		}

		public static Entity GetEntity<T>(this T comp) where T : Component
		{
			return comp.transform.GetEntity();
		}

		public static bool TryGetEntity<T>(this T comp, out Entity entity) where T : Component
		{
			return comp.transform.TryGetEntity(out entity);
		}

		public static Entity GetEntity(this Transform transform)
		{
			return transform.GetComponentInParent<EntityBehaviour>()?.entity ?? Entity.invalid;
		}

		public static bool TryGetEntity(this Transform transform, out Entity entity)
		{
			entity = transform.GetEntity();
			return entity != Entity.invalid;
		}
	}
}
