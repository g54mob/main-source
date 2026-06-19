using System.Collections.Generic;
using UnityEngine;

public static class ComputeBufferPool
{
	private struct TempBuffer
	{
		public int creationFrame;

		public ComputeBuffer buffer;

		public void Release()
		{
			buffer.Release();
		}
	}

	private class Pool
	{
		public List<TempBuffer> free;

		public List<TempBuffer> used;

		public void Release()
		{
			for (int i = 0; i < free.Count; i++)
			{
				free[i].Release();
			}
			for (int j = 0; j < used.Count; j++)
			{
				used[j].Release();
			}
		}

		public void Process()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			int num = 0;
			while (num < free.Count)
			{
				TempBuffer tempBuffer = free[num];
				if (Time.frameCount - tempBuffer.creationFrame > 4)
				{
					tempBuffer.Release();
					free.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
		}
	}

	private const int PERSIST_FOR_FRAMES = 4;

	private static readonly Dictionary<int, Pool> s_pools = new Dictionary<int, Pool>();

	private static Pool GetPool(int stride)
	{
		if (!s_pools.TryGetValue(stride, out var value))
		{
			value = new Pool
			{
				free = new List<TempBuffer>(),
				used = new List<TempBuffer>()
			};
			s_pools.Add(stride, value);
		}
		return value;
	}

	public static ComputeBuffer Get(int count, int stride)
	{
		Pool pool = GetPool(stride);
		int num = pool.free.FindIndex((TempBuffer x) => x.buffer.count >= count);
		TempBuffer item;
		if (num > -1)
		{
			item = pool.free[num];
			pool.free.RemoveAt(num);
		}
		else
		{
			item = new TempBuffer
			{
				creationFrame = Time.frameCount,
				buffer = new ComputeBuffer(count, stride)
			};
		}
		pool.used.Add(item);
		return item.buffer;
	}

	public static void Return(ComputeBuffer buffer)
	{
		Pool pool = GetPool(buffer.stride);
		int index = pool.used.FindIndex((TempBuffer x) => x.buffer == buffer);
		TempBuffer item = pool.used[index];
		pool.used.RemoveAt(index);
		pool.free.Add(item);
	}

	public static void Release()
	{
		foreach (KeyValuePair<int, Pool> s_pool in s_pools)
		{
			s_pool.Value.Release();
		}
		s_pools.Clear();
	}

	public static void Process()
	{
		foreach (KeyValuePair<int, Pool> s_pool in s_pools)
		{
			s_pool.Value.Process();
		}
	}
}
