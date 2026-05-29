using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using DG.Tweening;

namespace Cysharp.Threading.Tasks
{
	internal sealed class PooledTweenCallback
	{
		private static readonly ConcurrentQueue<PooledTweenCallback> pool;

		private readonly TweenCallback runDelegate;

		private Action continuation;

		private PooledTweenCallback()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TweenCallback Create(Action continuation)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Run()
		{
		}
	}
}
