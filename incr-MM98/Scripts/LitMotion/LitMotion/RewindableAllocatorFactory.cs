using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace LitMotion
{
	internal static class RewindableAllocatorFactory
	{
		private const int InitialSize = 131072;

		private static bool isInitialized;

		private static readonly Stack<AllocatorHelper<RewindableAllocator>> allocators = new Stack<AllocatorHelper<RewindableAllocator>>();

		public static AllocatorHelper<RewindableAllocator> CreateAllocator()
		{
			Initialize();
			AllocatorHelper<RewindableAllocator> allocatorHelper = new AllocatorHelper<RewindableAllocator>(Allocator.Persistent);
			allocatorHelper.Allocator.Initialize(131072, enableBlockFree: true);
			allocators.Push(allocatorHelper);
			return allocatorHelper;
		}

		private static void Initialize()
		{
			if (!isInitialized)
			{
				Application.quitting += Dispose;
				isInitialized = true;
			}
		}

		private static void Dispose()
		{
			AllocatorHelper<RewindableAllocator> result;
			while (allocators.TryPop(out result))
			{
				result.Allocator.Dispose();
				result.Dispose();
			}
		}
	}
}
