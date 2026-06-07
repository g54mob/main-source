using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

namespace Gh
{
	public struct SampledAnimationCurve : IDisposable
	{
		[ReadOnly]
		private NativeArray<float> _sampledArray;

		private int _lengthMinusOne;

		public SampledAnimationCurve(AnimationCurve ac, int samples)
		{
			_sampledArray = default(NativeArray<float>);
			_lengthMinusOne = 0;
		}

		public void Dispose()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateLerp(float time)
		{
			return 0f;
		}
	}
}
