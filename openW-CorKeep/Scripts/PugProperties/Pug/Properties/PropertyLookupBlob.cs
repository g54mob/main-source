using Unity.Collections;
using Unity.Entities;

namespace Pug.Properties
{
	public struct PropertyLookupBlob
	{
		internal BlobArray<ObjectData> Objects;

		internal T Get<T>(int index, int propertyId) where T : unmanaged
		{
			if (Objects.Length <= index)
			{
				return default(T);
			}
			return Objects[index].Get<T>(propertyId);
		}

		internal bool TryGet<T>(int index, int propertyId, out T value) where T : unmanaged
		{
			if (Objects.Length <= index)
			{
				value = default(T);
				return false;
			}
			return Objects[index].TryGet<T>(propertyId, out value);
		}

		internal NativeArray<T> GetList<T>(int index, int propertyId, AllocatorManager.AllocatorHandle allocatorHandle) where T : unmanaged
		{
			if (Objects.Length <= index)
			{
				return default(NativeArray<T>);
			}
			return Objects[index].GetList<T>(propertyId, allocatorHandle);
		}

		internal bool TryGetList<T>(int index, int propertyId, out NativeArray<T> value, AllocatorManager.AllocatorHandle allocatorHandle) where T : unmanaged
		{
			if (Objects.Length <= index)
			{
				value = default(NativeArray<T>);
				return false;
			}
			return Objects[index].TryGetList(propertyId, out value, allocatorHandle);
		}

		internal bool Has(int index, int propertyId)
		{
			if (Objects.Length <= index)
			{
				return false;
			}
			return Objects[index].Has(propertyId);
		}
	}
}
