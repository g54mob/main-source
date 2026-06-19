using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Pug.Properties
{
	internal struct PropertyData
	{
		internal int PropertyId;

		internal int Count;

		internal BlobArray<byte> Data;

		public unsafe T Get<T>(int index) where T : unmanaged
		{
			int num = UnsafeUtility.SizeOf<T>();
			if (num * Count != Data.Length)
			{
				return default(T);
			}
			UnsafeUtility.CopyPtrToStructure<T>((byte*)Data.GetUnsafePtr() + index * num, out var output);
			return output;
		}

		public unsafe NativeArray<T> GetList<T>(AllocatorManager.AllocatorHandle allocatorHandle) where T : unmanaged
		{
			if (UnsafeUtility.SizeOf<T>() * Count != Data.Length)
			{
				return default(NativeArray<T>);
			}
			NativeArray<T> nativeArray = CollectionHelper.CreateNativeArray<T>(Count, allocatorHandle, NativeArrayOptions.UninitializedMemory);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr(), Data.GetUnsafePtr(), Data.Length);
			return nativeArray;
		}
	}
}
