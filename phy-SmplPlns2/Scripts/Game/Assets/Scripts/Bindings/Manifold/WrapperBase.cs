using System;
using System.Threading;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Assets.Scripts.Bindings.Manifold
{
	public abstract class WrapperBase<T> : IDisposable where T : unmanaged
	{
		private unsafe readonly T* _pointer;

		private readonly Allocator _allocator;

		private int _disposed;

		public Allocator Allocator => _allocator;

		internal unsafe T* Ptr => _pointer;

		protected unsafe WrapperBase(T* ptr, Allocator allocator)
		{
			_disposed = 0;
			_pointer = ptr;
			_allocator = allocator;
		}

		~WrapperBase()
		{
			if (_disposed == 0)
			{
				if (_allocator == Allocator.Persistent)
				{
					Debug.LogWarning($"Disposing leaked wrapper: {this}");
					Dispose();
				}
				else
				{
					Debug.LogError("Leaked manifoldc wrapper! Cannot dispose as native allocation is potentially invalidated.");
				}
			}
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref _disposed, 1) == 0)
			{
				Destruct();
				UnsafeUtility.Free(_pointer, _allocator);
				GC.SuppressFinalize(this);
			}
		}

		protected abstract void Destruct();
	}
}
