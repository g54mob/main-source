using System;
using UnityEngine;

namespace Jundroo.Common.Animation
{
	public class AnimationCurveSampler
	{
		private float[] _curveSamples;

		private int _curveSamplesCount;

		private float _curveSamplesMax;

		private float _oneOverStepSize;

		private float _sampleRange;

		private float _sampleRangeMaxValue;

		private float _sampleRangeMinValue;

		private float _stepSize;

		public AnimationCurve AnimationCurve { get; private set; }

		public float SampleRangeMaxValue
		{
			get
			{
				return _sampleRangeMaxValue;
			}
			private set
			{
				_sampleRangeMaxValue = value;
			}
		}

		public float SampleRangeMinValue
		{
			get
			{
				return _sampleRangeMinValue;
			}
			private set
			{
				_sampleRangeMinValue = value;
			}
		}

		public AnimationCurveSampler(AnimationCurve animationCurve, int sampleCount = 1001)
		{
			if (animationCurve == null)
			{
				throw new ArgumentNullException("animationCurve");
			}
			Keyframe[] keys = animationCurve.keys;
			if (keys.Length < 2)
			{
				throw new ArgumentException("The animation curve has less than two keys. Unable to create an animation curve sampler.", "animationCurve");
			}
			AnimationCurve = animationCurve;
			_curveSamplesCount = sampleCount;
			_curveSamplesMax = (float)sampleCount - 1f;
			float time = keys[0].time;
			float time2 = keys[^1].time;
			SampleRangeMinValue = time;
			SampleRangeMaxValue = time2;
			_sampleRange = time2 - time;
			_stepSize = _sampleRange / _curveSamplesMax;
			_oneOverStepSize = 1f / _stepSize;
			_curveSamples = new float[_curveSamplesCount];
			for (int i = 0; i < _curveSamplesCount; i++)
			{
				_curveSamples[i] = AnimationCurve.Evaluate(SampleRangeMinValue + (float)i * _stepSize);
			}
		}

		public float Sample(float input)
		{
			float num = (((input < _sampleRangeMinValue) ? _sampleRangeMinValue : ((input > _sampleRangeMaxValue) ? _sampleRangeMaxValue : input)) - _sampleRangeMinValue) * _oneOverStepSize;
			int num2 = (int)num;
			int num3 = num2 + 1;
			if (num3 == _curveSamplesCount)
			{
				return _curveSamples[num2];
			}
			float num4 = num - (float)num2;
			float num5 = _curveSamples[num2];
			float num6 = _curveSamples[num3];
			return num5 + (num6 - num5) * num4;
		}
	}
}
