using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Pug.ECS.Serialization.DOTS100
{
	internal class PagedAllocation : IDisposable
	{
		public struct PageInfo
		{
			public int FreeOffset;

			public unsafe byte* Buffer;

			public unsafe PageInfo(byte* buffer, int freeOffset)
			{
				FreeOffset = freeOffset;
				Buffer = buffer;
			}
		}

		private UnsafeList<PageInfo> _pages = new UnsafeList<PageInfo>(16, Unity.Collections.Allocator.Persistent);

		public ref UnsafeList<PageInfo> Pages => ref _pages;

		public int PageSize { get; }

		public AllocatorManager.AllocatorHandle Allocator { get; }

		public int CurrentGlobalOffset { get; private set; }

		public bool IsDisposed { get; private set; }

		public unsafe PagedAllocation(AllocatorManager.AllocatorHandle allocator, int pageSize = 65536)
		{
			PageSize = pageSize;
			Allocator = allocator;
			CurrentGlobalOffset = 0;
			Pages.Add(new PageInfo((byte*)UnsafeUtility.Malloc(PageSize, 16, Allocator.ToAllocator), 0));
		}

		public unsafe byte* Reserve(int size, bool clearMemory = true)
		{
			CurrentGlobalOffset += size;
			byte* ptr;
			if (size > PageSize)
			{
				ptr = (byte*)UnsafeUtility.Malloc(size, 16, Allocator.ToAllocator);
				Pages.Add(new PageInfo(ptr, size));
			}
			else
			{
				PageInfo* ptr2 = Pages.Ptr + (Pages.Length - 1);
				if (ptr2->FreeOffset + size <= PageSize)
				{
					ptr = ptr2->Buffer + ptr2->FreeOffset;
					ptr2->FreeOffset += size;
				}
				else
				{
					ptr = (byte*)UnsafeUtility.Malloc(PageSize, 16, Allocator.ToAllocator);
					PageInfo value = new PageInfo(ptr, size);
					Pages.Add(in value);
				}
			}
			if (clearMemory)
			{
				UnsafeUtility.MemClear(ptr, size);
			}
			return ptr;
		}

		public unsafe void Dispose()
		{
			if (!IsDisposed)
			{
				for (int i = 0; i < Pages.Length; i++)
				{
					UnsafeUtility.Free(Pages[i].Buffer, Allocator.ToAllocator);
				}
				Pages.Dispose();
				IsDisposed = true;
			}
		}
	}
}
