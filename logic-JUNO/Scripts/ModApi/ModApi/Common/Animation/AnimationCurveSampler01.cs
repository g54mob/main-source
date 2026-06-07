using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ModApi.Common.Animation
{
	public class AnimationCurveSampler01
	{
		private float[] _curveSamples;

		private int _curveSamplesCount;

		private float _curveSamplesMax;

		private float _stepSize;

		public AnimationCurve AnimationCurve { get; private set; }

		public float MaxValue { get; private set; }

		public float MinValue { get; private set; }

		public float ValueAtMax { get; private set; }

		public float ValueAtMin { get; private set; }

		public AnimationCurveSampler01(AnimationCurve animationCurve, int sampleCount = 1001)
		{
			if (animationCurve == null)
			{
				throw new ArgumentNullException("animationCurve");
			}
			if (animationCurve.keys.Length < 2)
			{
				throw new ArgumentException("The animation curve has less than two keys. Unable to create an animation curve sampler.", "animationCurve");
			}
			AnimationCurve = animationCurve;
			_curveSamplesCount = sampleCount;
			_curveSamplesMax = (float)sampleCount - 1f;
			_stepSize = 1f / _curveSamplesMax;
			MinValue = float.MaxValue;
			MaxValue = float.MinValue;
			_curveSamples = new float[_curveSamplesCount + 1];
			for (int i = 0; i < _curveSamplesCount; i++)
			{
				float num = AnimationCurve.Evaluate((float)i * _stepSize);
				if (num < MinValue)
				{
					MinValue = num;
				}
				if (num > MaxValue)
				{
					MaxValue = num;
				}
				_curveSamples[i] = num;
			}
			_curveSamples[_curveSamplesCount] = _curveSamples[_curveSamplesCount - 1];
			ValueAtMin = _curveSamples[0];
			ValueAtMax = _curveSamples[_curveSamplesCount];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Sample(float input)
		{
			float num = input * _curveSamplesMax;
			int num2 = (int)num;
			float num3 = _curveSamples[num2];
			float num4 = _curveSamples[num2 + 1];
			return num3 + (num4 - num3) * (num - (float)num2);
		}
	}
}
