using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public abstract class FurnitureSyncObject : ScriptableObject
	{
		public abstract void Sync(StringKey category, FurnitureInteractor furniture, SyncManager syncManager);
	}
	public abstract class FurnitureSyncObject<T> : FurnitureSyncObject where T : IInteractiveFurniture
	{
		public sealed override void Sync(StringKey category, FurnitureInteractor furniture, SyncManager syncManager)
		{
			if (furniture is T furniture2)
			{
				Sync(category, furniture2, syncManager);
			}
		}

		protected abstract void Sync(StringKey category, T furniture, SyncManager syncManager);
	}
}
