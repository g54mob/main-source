using System;
using System.Collections.Generic;
using NSMedieval.Components;
using NSMedieval.Components.Base;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	[FVSerializableKey("EventStorage", "")]
	public class EventStorage : IFVSerializable, IDisposable
	{
		[SerializeField]
		private Storage storage;

		public EventStorage(int capacity)
		{
			storage = new Storage(new StorageBase(999, ignoreWeigth: true));
		}

		public EventStorage(Storage migrationStorage)
		{
			storage = migrationStorage;
		}

		public void Dispose()
		{
			storage?.Dispose();
			storage = null;
		}

		public IEnumerable<ResourceInstance> GetResources()
		{
			if (storage != null)
			{
				return storage.Resources;
			}
			return new List<ResourceInstance>();
		}

		public int GetResourceCount(Resource resource)
		{
			return storage.GetTotalStoredCount(resource);
		}

		public void AddToStorage(ResourceInstance resource)
		{
			storage.Add(resource);
		}

		public ResourceInstance TakeFromStorage(Resource resource, int toTake)
		{
			return storage.Take(resource, toTake);
		}

		public void ClearEventStorage(Vec3Int dropPos)
		{
			storage.DropAll(dropPos);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("storage", storage);
		}

		public EventStorage(FVDeserializer deserializer)
		{
			storage = deserializer.ReadObject<Storage>("storage");
		}
	}
}
