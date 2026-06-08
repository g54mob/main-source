using System.Collections.Generic;
using Unity.Entities;

namespace Kitchen
{
	public class SystemReferenceCache<T>
	{
		private readonly Dictionary<SystemReference, T> ReferenceCache = new Dictionary<SystemReference, T>();

		public SystemReferenceCache(World world)
		{
			foreach (ComponentSystemBase system in world.Systems)
			{
				if (system is T value)
				{
					ReferenceCache.Add(system, value);
				}
			}
		}

		public bool Get(SystemReference reference, out T system)
		{
			return ReferenceCache.TryGetValue(reference, out system);
		}
	}
}
