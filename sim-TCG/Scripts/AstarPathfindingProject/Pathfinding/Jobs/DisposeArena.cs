using System.Collections.Generic;
using System.Runtime.InteropServices;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Pathfinding.Jobs
{
	public class DisposeArena
	{
		private List<NativeArray<byte>> buffer;

		private List<NativeList<byte>> buffer2;

		private List<NativeQueue<byte>> buffer3;

		private List<GCHandle> gcHandles;

		public void Add<T>(NativeArray<T> data) where T : unmanaged
		{
			if (buffer == null)
			{
				buffer = ListPool<NativeArray<byte>>.Claim();
			}
			buffer.Add(data.Reinterpret<byte>(UnsafeUtility.SizeOf<T>()));
		}

		public void Add<T>(NativeList<T> data) where T : unmanaged
		{
			NativeList<byte> item = UnsafeUtility.As<NativeList<T>, NativeList<byte>>(ref data);
			if (buffer2 == null)
			{
				buffer2 = ListPool<NativeList<byte>>.Claim();
			}
			buffer2.Add(item);
		}

		public void Add<T>(NativeQueue<T> data) where T : unmanaged
		{
			NativeQueue<byte> item = UnsafeUtility.As<NativeQueue<T>, NativeQueue<byte>>(ref data);
			if (buffer3 == null)
			{
				buffer3 = ListPool<NativeQueue<byte>>.Claim();
			}
			buffer3.Add(item);
		}

		public unsafe void Remove<T>(NativeArray<T> data) where T : unmanaged
		{
			if (buffer == null)
			{
				return;
			}
			void* unsafeBufferPointerWithoutChecks = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(data);
			for (int i = 0; i < buffer.Count; i++)
			{
				if (NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(buffer[i]) == unsafeBufferPointerWithoutChecks)
				{
					buffer.RemoveAtSwapBack(i);
					break;
				}
			}
		}

		public void Add<T>(T data) where T : IArenaDisposable
		{
			data.DisposeWith(this);
		}

		public void Add(GCHandle handle)
		{
			if (gcHandles == null)
			{
				gcHandles = ListPool<GCHandle>.Claim();
			}
			gcHandles.Add(handle);
		}

		public void DisposeAll()
		{
			if (buffer != null)
			{
				for (int i = 0; i < buffer.Count; i++)
				{
					buffer[i].Dispose();
				}
				ListPool<NativeArray<byte>>.Release(ref buffer);
			}
			if (buffer2 != null)
			{
				for (int j = 0; j < buffer2.Count; j++)
				{
					buffer2[j].Dispose();
				}
				ListPool<NativeList<byte>>.Release(ref buffer2);
			}
			if (buffer3 != null)
			{
				for (int k = 0; k < buffer3.Count; k++)
				{
					buffer3[k].Dispose();
				}
				ListPool<NativeQueue<byte>>.Release(ref buffer3);
			}
			if (gcHandles != null)
			{
				for (int l = 0; l < gcHandles.Count; l++)
				{
					gcHandles[l].Free();
				}
				ListPool<GCHandle>.Release(ref gcHandles);
			}
		}
	}
}
