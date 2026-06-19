using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Aggro.Core
{
	internal class ContextEntry : IDisposable
	{
		public readonly EntityStore enabledAliveStore;

		public readonly EntityStore enabledDyingStore;

		public readonly EntityStore disableAliveStore;

		public readonly EntityStore disableDyingStore;

		public ContextEntry(int capacity, Allocator allocator)
		{
			enabledAliveStore = new EntityStore(capacity, allocator);
			enabledDyingStore = new EntityStore(capacity, allocator);
			disableAliveStore = new EntityStore(capacity, allocator);
			disableDyingStore = new EntityStore(capacity, allocator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public EntityStore GetStore(bool enabled, bool dying)
		{
			if (enabled)
			{
				if (dying)
				{
					return enabledDyingStore;
				}
				return enabledAliveStore;
			}
			if (dying)
			{
				return disableDyingStore;
			}
			return disableAliveStore;
		}

		public void Dispose()
		{
			enabledAliveStore.Dispose();
			enabledDyingStore.Dispose();
			disableAliveStore.Dispose();
			disableDyingStore.Dispose();
		}
	}
}
