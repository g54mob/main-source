using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace LitMotion.Collections
{
	public struct UnsafeAnimationCurve : IDisposable
	{
		internal UnsafeList<Keyframe> keys;

		internal WrapMode preWrapMode;

		internal WrapMode postWrapMode;

		public readonly bool IsCreated => keys.IsCreated;

		public UnsafeAnimationCurve(AllocatorManager.AllocatorHandle allocator)
		{
			keys = new UnsafeList<Keyframe>(0, allocator);
			preWrapMode = WrapMode.Default;
			postWrapMode = WrapMode.Default;
		}

		public unsafe UnsafeAnimationCurve(AnimationCurve animationCurve, AllocatorManager.AllocatorHandle allocator)
		{
			int length = animationCurve.length;
			keys = new UnsafeList<Keyframe>(length, allocator);
			keys.Resize(length);
			fixed (Keyframe* source = &animationCurve.keys[0])
			{
				UnsafeUtility.MemCpy(keys.Ptr, source, length * sizeof(Keyframe));
			}
			keys.Sort(default(KeyframeComparer));
			preWrapMode = animationCurve.preWrapMode;
			postWrapMode = animationCurve.postWrapMode;
		}

		public unsafe void CopyFrom(AnimationCurve animationCurve)
		{
			int length = animationCurve.length;
			keys.Resize(length);
			fixed (Keyframe* source = &animationCurve.keys[0])
			{
				UnsafeUtility.MemCpy(keys.Ptr, source, length * sizeof(Keyframe));
			}
			keys.Sort(default(KeyframeComparer));
			preWrapMode = animationCurve.preWrapMode;
			postWrapMode = animationCurve.postWrapMode;
		}

		public void CopyFrom(in UnsafeAnimationCurve animationCurve)
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
			return NativeAnimationCurveHelper.Evaluate(keys.Ptr, keys.Length, preWrapMode, postWrapMode, time);
		}
	}
}
