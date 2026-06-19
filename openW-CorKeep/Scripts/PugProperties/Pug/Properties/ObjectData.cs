using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Pug.Properties
{
	internal struct ObjectData
	{
		private static PropertyData _default;

		internal BlobArray<PropertyData> Properties;

		public ref PropertyData Get(int propertyId)
		{
			for (int i = 0; i < Properties.Length; i++)
			{
				if (Properties[i].PropertyId == propertyId)
				{
					return ref Properties[i];
				}
			}
			return ref _default;
		}

		public bool TryGet<T>(int propertyId, out T value) where T : unmanaged
		{
			for (int i = 0; i < Properties.Length; i++)
			{
				if (Properties[i].PropertyId == propertyId && Properties[i].Count * UnsafeUtility.SizeOf<T>() == Properties[i].Data.Length)
				{
					value = Properties[i].Get<T>(0);
					return true;
				}
			}
			value = default(T);
			return false;
		}

		public T Get<T>(int propertyId) where T : unmanaged
		{
			for (int i = 0; i < Properties.Length; i++)
			{
				if (Properties[i].PropertyId == propertyId)
				{
					return Properties[i].Get<T>(0);
				}
			}
			return default(T);
		}

		public bool TryGetList<T>(int propertyId, out NativeArray<T> value, AllocatorManager.AllocatorHandle allocatorHandle) where T : unmanaged
		{
			for (int i = 0; i < Properties.Length; i++)
			{
				if (Properties[i].PropertyId == propertyId)
				{
					value = Properties[i].GetList<T>(allocatorHandle);
					return value.IsCreated;
				}
			}
			value = default(NativeArray<T>);
			return false;
		}

		public NativeArray<T> GetList<T>(int propertyId, AllocatorManager.AllocatorHandle allocatorHandle) where T : unmanaged
		{
			for (int i = 0; i < Properties.Length; i++)
			{
				if (Properties[i].PropertyId == propertyId)
				{
					return Properties[i].GetList<T>(allocatorHandle);
				}
			}
			return default(NativeArray<T>);
		}

		public bool Has(int propertyId)
		{
			for (int i = 0; i < Properties.Length; i++)
			{
				if (Properties[i].PropertyId == propertyId)
				{
					return true;
				}
			}
			return false;
		}
	}
}
