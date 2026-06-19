using System.Collections.Generic;
using UnityEngine;

namespace Aggro.Core
{
	public static class GameObjectPoolExtensions
	{
		public static bool HasPrefabPool(this GameObject prefab)
		{
			PrefabPool component;
			return prefab.TryGetComponent<PrefabPool>(out component);
		}

		public static void PopulateForPrefabPool(this GameObject prefab, int count)
		{
			prefab.GetComponent<PrefabPool>().Populate(count);
		}

		public static PoolableReference GetFromPrefabPool(this GameObject prefab)
		{
			return prefab.GetComponent<PrefabPool>().Get();
		}

		public static PoolableReference<T> GetFromPrefabPool<T>(this GameObject prefab) where T : Component
		{
			return prefab.GetComponent<PrefabPool>().Get().WithComponent<T>();
		}

		public static PoolableEntityReference GetEntityFromPrefabPool(this GameObject prefab)
		{
			PoolableReference<EntityBehaviour> fromPrefabPool = prefab.GetFromPrefabPool<EntityBehaviour>();
			if (!fromPrefabPool.component.entity.Exists(allowIsDying: true))
			{
				EntityWorldUtil.CreateEntities(EntityWorld.gameObjectWorld, fromPrefabPool.gameObject.transform, runStartRunning: true, checkForPool: false);
			}
			PoolableEntityReference poolableEntityReference = default(PoolableEntityReference);
			poolableEntityReference.reference = fromPrefabPool.reference;
			poolableEntityReference.entityInternal = fromPrefabPool.comp.entity;
			poolableEntityReference.entityInternal.AddStruct(poolableEntityReference);
			return poolableEntityReference;
		}

		public static void PopulateForTemplatePool(this GameObject template, int count)
		{
			template.GetComponent<TemplatePool>().Populate(count);
		}

		public static PoolableReference GetFromTemplatePool(this GameObject template)
		{
			return template.GetComponent<TemplatePool>().Get();
		}

		public static PoolableReference<T> GetFromTemplatePool<T>(this GameObject template) where T : Component
		{
			return template.GetComponent<TemplatePool>().Get().WithComponent<T>();
		}

		public static PoolableEntityReference GetEntityFromTemplatePool(this GameObject template)
		{
			PoolableReference<EntityBehaviour> fromTemplatePool = template.GetFromTemplatePool<EntityBehaviour>();
			if (!fromTemplatePool.component.entity.Exists(allowIsDying: true))
			{
				EntityWorldUtil.CreateEntities(EntityWorld.gameObjectWorld, fromTemplatePool.gameObject.transform, runStartRunning: true, checkForPool: false);
			}
			PoolableEntityReference poolableEntityReference = default(PoolableEntityReference);
			poolableEntityReference.reference = fromTemplatePool.reference;
			poolableEntityReference.entityInternal = fromTemplatePool.comp.entity;
			poolableEntityReference.entityInternal.AddStruct(poolableEntityReference);
			return poolableEntityReference;
		}

		public static void ReleaseToPool(this IList<PoolableEntityReference> list)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				list[i].Release();
			}
		}

		public static void ReleaseToPool(this IList<PoolableReference> list)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				list[i].Release();
			}
		}

		public static void ReleaseToPool<T>(this IList<PoolableReference<T>> list) where T : Component
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				list[i].Release();
			}
		}
	}
}
