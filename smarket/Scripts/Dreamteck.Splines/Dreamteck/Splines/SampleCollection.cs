using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dreamteck.Splines
{
	[Serializable]
	public class SampleCollection
	{
		[HideInInspector]
		[FormerlySerializedAs("samples")]
		public SplineSample[] samples;

		public int[] optimizedIndices;

		public SplineComputer.SampleMode sampleMode;

		private SplineSample _workSample;

		public int length => 0;

		private bool hasSamples => false;

		public SampleCollection()
		{
		}

		public SampleCollection(SampleCollection input)
		{
		}

		public int GetClippedSampleCount(double clipFrom, double clipTo, out int startIndex, out int endIndex)
		{
			startIndex = default(int);
			endIndex = default(int);
			return 0;
		}

		public void GetSamplingValues(double percent, out int sampleIndex, out double lerp)
		{
			sampleIndex = default(int);
			lerp = default(double);
		}

		public Vector3 EvaluatePosition(double percent)
		{
			return default(Vector3);
		}

		public SplineSample Evaluate(double percent)
		{
			return default(SplineSample);
		}

		public void Evaluate(double percent, ref SplineSample result)
		{
		}

		public void Evaluate(ref SplineSample[] results, double from = 0.0, double to = 1.0)
		{
		}

		public void EvaluatePositions(ref Vector3[] positions, double from = 0.0, double to = 1.0)
		{
		}

		public double Travel(double start, float distance, Spline.Direction direction, out float moved, double clipFrom = 0.0, double clipTo = 1.0)
		{
			moved = default(float);
			return 0.0;
		}

		public double TravelWithOffset(double start, float distance, Spline.Direction direction, Vector3 offset, out float moved, double clipFrom = 0.0, double clipTo = 1.0)
		{
			moved = default(float);
			return 0.0;
		}

		public double Travel(double start, float distance, Spline.Direction direction = Spline.Direction.Forward)
		{
			return 0.0;
		}

		public void Project(Vector3 position, int controlPointCount, ref SplineSample result, double from = 0.0, double to = 1.0)
		{
		}

		private double GetSamplePercent(int sampleIndex)
		{
			return 0.0;
		}

		public float CalculateLength(double from = 0.0, double to = 1.0, bool preventInvert = true)
		{
			return 0f;
		}

		public float CalculateLengthWithOffset(Vector3 offset, double from = 0.0, double to = 1.0)
		{
			return 0f;
		}
	}
}
