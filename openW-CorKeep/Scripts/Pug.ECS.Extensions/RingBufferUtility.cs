using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

public static class RingBufferUtility
{
	public static void AddToRingBuffer<T, D>(this DynamicBuffer<T> buffer, ref D pointer, in T item) where T : unmanaged, INetworkTickRingBuffer where D : unmanaged, INetworkTickRingBufferPointer
	{
		byte nextIndex = pointer.NextIndex;
		pointer.NextIndex++;
		if (pointer.NextIndex == buffer.Capacity)
		{
			pointer.NextIndex = 0;
		}
		if (buffer.Length < buffer.Capacity)
		{
			buffer.Add(item);
		}
		else
		{
			buffer[nextIndex] = item;
		}
	}

	public static NetworkTick GetTickForNextOverridenElement<T, D>(this DynamicBuffer<T> buffer, in D pointer) where T : unmanaged, INetworkTickRingBuffer where D : unmanaged, INetworkTickRingBufferPointer
	{
		if (buffer.Length >= buffer.Capacity)
		{
			return buffer[pointer.NextIndex].Tick;
		}
		return NetworkTick.Invalid;
	}

	public static NetworkTick GetNewestElementTick<T>(this DynamicBuffer<T> buffer) where T : unmanaged, INetworkTickRingBuffer
	{
		if (buffer.Length == 0)
		{
			return default(NetworkTick);
		}
		NetworkTick networkTick = NetworkTick.Invalid;
		for (int i = 0; i < buffer.Length; i++)
		{
			NetworkTick tick = buffer[i].Tick;
			if (!networkTick.IsValid || (tick.IsValid && tick.IsNewerThan(networkTick)))
			{
				networkTick = tick;
			}
		}
		return networkTick;
	}

	public static T GetLastAddedElement<T, D>(this DynamicBuffer<T> buffer, in D pointer) where T : unmanaged, INetworkTickRingBuffer where D : unmanaged, INetworkTickRingBufferPointer
	{
		if (buffer.Length == 0)
		{
			return default(T);
		}
		int index = pointer.NextIndex - 1;
		if (pointer.NextIndex == 0)
		{
			index = buffer.Length - 1;
		}
		return buffer[index];
	}

	public unsafe static void ResizePreserveOrder<T, D>(this DynamicBuffer<T> buffer, in D pointer, int newSize) where T : unmanaged, INetworkTickRingBuffer where D : unmanaged, INetworkTickRingBufferPointer
	{
		if (newSize <= buffer.Length)
		{
			Debug.LogError("New size must be larger than current size.");
			return;
		}
		int length = buffer.Length;
		buffer.Resize(newSize, NativeArrayOptions.ClearMemory);
		int num = length - pointer.NextIndex;
		int num2 = newSize - length;
		T* unsafePtr = (T*)buffer.GetUnsafePtr();
		int num3 = UnsafeUtility.SizeOf<T>();
		UnsafeUtility.MemMove(unsafePtr + (int)pointer.NextIndex + num2, unsafePtr + (int)pointer.NextIndex, num * num3);
		UnsafeUtility.MemClear(unsafePtr + (int)pointer.NextIndex, num2 * num3);
	}
}
