using System;
using Client;
using UnityEngine;

namespace Factory.Allocators
{
	public class NestedGameObjectAllocator<ComponentType, PrefabType> : IAllocator<ComponentType>, IDisposable where ComponentType : class, IView where PrefabType : Component
	{
		public ComponentType Allocate(IScope context)
		{
			PrefabType val = context.Get<PrefabType>();
			if (val == null)
			{
				return null;
			}
			return val.GetComponentInChildren<ComponentType>(includeInactive: true);
		}

		public bool Release(ComponentType obj, IScope context)
		{
			OnObjectReleased(obj, context);
			return true;
		}

		public virtual void OnObjectAssembled(ComponentType obj, IScope context)
		{
		}

		protected virtual void OnObjectReleased(ComponentType obj, IScope context)
		{
		}

		public void Dispose()
		{
		}
	}
}
