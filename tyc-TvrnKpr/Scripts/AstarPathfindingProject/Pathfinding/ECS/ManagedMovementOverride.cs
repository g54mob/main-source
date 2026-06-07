using System;
using Unity.Entities;
using UnityEngine.Scripting;

namespace Pathfinding.ECS
{
	public class ManagedMovementOverride<T> : IComponentData, IQueryTypeParameter where T : class, Delegate
	{
		public T callback;

		public void AddCallback(T callback)
		{
		}

		public bool RemoveCallback(T callback)
		{
			return false;
		}

		[Preserve]
		public ManagedMovementOverride()
		{
		}
	}
}
