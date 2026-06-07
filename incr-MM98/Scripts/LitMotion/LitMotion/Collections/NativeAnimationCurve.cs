using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace LitMotion.Collections
{
	public struct NativeAnimationCurve : IDisposable
	{
		private NativeList<Keyframe> keys;

		private WrapMode preWrapMode;

		private WrapMode postWrapMode;

		public readonly bool IsCreated => keys.IsCreated;

		public NativeAnimationCurve(AllocatorManager.AllocatorHandle allocator)
		{
			keys = new NativeList<Keyframe>(0, allocator);
			preWrapMode = WrapMode.Default;
			postWrapMode = WrapMode.Default;
		}

		public unsafe NativeAnimationCurve(AnimationCurve animationCurve, AllocatorManager.AllocatorHandle allocator)
		{
			int length = animationCurve.length;
			keys = new NativeList<Keyframe>(length, allocator);
			keys.Resize(length, NativeArrayOptions.UninitializedMemory);
			fixed (Keyframe* source = &animationCurve.keys[0])
			{
				UnsafeUtility.MemCpy(keys.GetUnsafePtr(), source, length * sizeof(Keyframe));
			}
			keys.Sort(default(KeyframeComparer));
			preWrapMode = animationCurve.preWrapMode;
			postWrapMode = animationCurve.postWrapMode;
		}

		public unsafe void CopyFrom(AnimationCurve animationCurve)
		{
			int length = animationCurve.length;
			keys.Resize(length, NativeArrayOptions.UninitializedMemory);
			fixed (Keyframe* source = &animationCurve.keys[0])
			{
				UnsafeUtility.MemCpy(keys.GetUnsafePtr(), source, length * sizeof(Keyframe));
			}
			keys.Sort(default(KeyframeComparer));
			preWrapMode = animationCurve.preWrapMode;
			postWrapMode = animationCurve.postWrapMode;
		}

		public void CopyFrom(in NativeAnimationCurve animationCurve)
		{
			keys.CopyFrom(in animationCurve.keys);
			preWrapMode = animationCurve.preWrapMode;
			postWrapMode = animationCurve.postWrapMode;
		}

		public void Dispose()
		{
			keys.Dispose();
		}

		public unsafe float Evaluate(float time)
		{
			return NativeAnimationCurveHelper.Evaluate(keys.GetUnsafePtr(), keys.Length, preWrapMode, postWrapMode, time);
		}
	}
}
