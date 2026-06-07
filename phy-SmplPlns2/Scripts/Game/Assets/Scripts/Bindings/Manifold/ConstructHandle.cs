using System;
using System.Threading;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Assets.Scripts.Bindings.Manifold
{
	internal struct ConstructHandle<TNative, TManaged> : IDisposable where TNative : unmanaged
	{
		private Allocator _allocator;

		private unsafe void* _pointer;

		private int _shouldDispose;

		private Func<IntPtr, Allocator, TManaged> _constructor;

		public unsafe ConstructHandle(long size, Allocator allocator, Func<IntPtr, Allocator, TManaged> constructor)
		{
			_pointer = UnsafeUtility.Malloc(size, 8, allocator);
			_shouldDispose = 1;
			_allocator = allocator;
			_constructor = constructor;
		}

		public unsafe static implicit operator void*(ConstructHandle<TNative, TManaged> handle)
		{
			return handle._pointer;
		}

		public unsafe TManaged Complete(TNative* ptr)
		{
			if (Interlocked.Exchange(ref _shouldDispose, 0) != 1)
			{
				throw new ObjectDisposedException("Manifold.ConstructHandle");
			}
			return _constructor((IntPtr)ptr, _allocator);
		}

		unsafe void IDisposable.Dispose()
		{
			if (Interlocked.Exchange(ref _shouldDispose, 0) == 1)
			{
				UnsafeUtility.Free(_pointer, _allocator);
			}
		}
	}
}
