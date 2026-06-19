using UnityEngine;

namespace Aggro.Core
{
	public struct PoolableEntityReference : IEntityStruct, IEntityTyped
	{
		internal PoolableReference reference;

		internal Entity entityInternal;

		public static PoolableEntityReference invalid;

		public bool isValid => reference.isValid;

		public PoolableReference generic => reference;

		public GameObject gameObject => reference.gameObject;

		public Entity entity => entityInternal;

		public void Release()
		{
			if (entityInternal.Exists(allowIsDying: true))
			{
				entityInternal.entityManager.DestroyEntity(entityInternal.key);
			}
			reference.Release();
		}
	}
}
