using Unity.Collections;
using Unity.Entities;

namespace Pug.Properties
{
	public struct PropertyBlob
	{
		internal BlobAssetReference<ObjectData> ObjectData;

		public bool IsValid => ObjectData.IsCreated;

		public readonly bool TryGet<T>(int propertyId, out T value) where T : unmanaged
		{
			return ObjectData.Value.TryGet<T>(propertyId, out value);
		}

		public readonly T Get<T>(int propertyId) where T : unmanaged
		{
			return ObjectData.Value.Get<T>(propertyId);
		}

		public readonly bool TryGetList<T>(int propertyId, out NativeArray<T> value, AllocatorManager.AllocatorHandle allocatorHandle) where T : unmanaged
		{
			return ObjectData.Value.TryGetList(propertyId, out value, allocatorHandle);
		}

		public readonly NativeArray<T> GetList<T>(int propertyId, AllocatorManager.AllocatorHandle allocatorHandle) where T : unmanaged
		{
			return ObjectData.Value.GetList<T>(propertyId, allocatorHandle);
		}

		public bool Has(int propertyId)
		{
			return ObjectData.Value.Has(propertyId);
		}
	}
}
