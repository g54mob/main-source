using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;

namespace Pathfinding.Jobs
{
	public class DisposeArena
	{
		private List<NativeArray<byte>> buffer;

		private List<NativeList<byte>> buffer2;

		private List<NativeQueue<byte>> buffer3;

		private List<GCHandle> gcHandles;

		public void Add<T>(NativeArray<T> data) where T : struct
		{
		}

		public void Add<T>(NativeList<T> data) where T : struct
		{
		}

		public void Add<T>(NativeQueue<T> data) where T : struct
		{
		}

		public void Remove<T>(NativeArray<T> data) where T : struct
		{
		}

		public void Add<T>(T data) where T : IArenaDisposable
		{
		}

		public void Add(GCHandle handle)
		{
		}

		public void DisposeAll()
		{
		}
	}
}
