using System;
using UnityEngine;

namespace Dreamteck.Splines
{
	[Serializable]
	public class Spline
	{
		public enum Direction
		{
			Forward = 1,
			Backward = -1
		}

		public enum Type
		{
			CatmullRom = 0,
			BSpline = 1,
			Bezier = 2,
			Linear = 3
		}

		public SplinePoint[] points;

		public Type type;

		public bool linearAverageDirection;

		public AnimationCurve customValueInterpolation;

		public AnimationCurve customNormalInterpolation;

		public int sampleRate;

		private static Vector3[] P;

		private static Vector3 A1;

		private static Vector3 A2;

		private static Vector3 A3;

		private static Vector3 B1;

		private static Vector3 B2;

		private static float t1;

		private static float t2;

		private static float t3;

		[SerializeField]
		private bool closed;

		[SerializeField]
		[Range(0f, 1f)]
		private float _knotParametrization;

		public bool isClosed => false;

		public double moveStep
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public int iterations => 0;

		public float knotParametrization
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Spline(Type type)
		{
		}

		public Spline(Type type, int sampleRate)
		{
		}

		public float CalculateLength(double from = 0.0, double to = 1.0, double resolution = 1.0)
		{
			return 0f;
		}

		public double Project(Vector3 position, int subdivide = 4, double from = 0.0, double to = 1.0)
		{
			return 0.0;
		}

		public bool Raycast(out RaycastHit hit, out double hitPercent, LayerMask layerMask, double resolution = 1.0, double from = 0.0, double to = 1.0, QueryTriggerInteraction hitTriggers = QueryTriggerInteraction.UseGlobal)
		{
			hit = default(RaycastHit);
			hitPercent = default(double);
			return false;
		}

		public bool RaycastAll(out RaycastHit[] hits, out double[] hitPercents, LayerMask layerMask, double resolution = 1.0, double from = 0.0, double to = 1.0, QueryTriggerInteraction hitTriggers = QueryTriggerInteraction.UseGlobal)
		{
			hits = null;
			hitPercents = null;
			return false;
		}

		public double GetPointPercent(int pointIndex)
		{
			return 0.0;
		}

		public Vector3 EvaluatePosition(double percent)
		{
			return default(Vector3);
		}

		public SplineSample Evaluate(double percent)
		{
			return default(SplineSample);
		}

		public SplineSample Evaluate(int pointIndex)
		{
			return default(SplineSample);
		}

		public void Evaluate(int pointIndex, ref SplineSample result)
		{
		}

		public void Evaluate(double percent, ref SplineSample sample)
		{
		}

		[Obsolete("This override is obsolete. Use Evaluate(int pointIndex, ref SplineSample sample) instead")]
		public void Evaluate(ref SplineSample sample, int pointIndex)
		{
		}

		[Obsolete("This override is obsolete. Use Evaluate(double percent, ref SplineSample sample) instead")]
		public void Evaluate(ref SplineSample sample, double percent)
		{
		}

		public void Evaluate(ref SplineSample[] samples, double from = 0.0, double to = 1.0)
		{
		}

		public void EvaluateUniform(ref SplineSample[] samples, ref double[] originalSamplePercents, double from = 0.0, double to = 1.0)
		{
		}

		public void EvaluatePositions(ref Vector3[] positions, double from = 0.0, double to = 1.0)
		{
		}

		public double Travel(double start, float distance, out float moved, Direction direction)
		{
			moved = default(float);
			return 0.0;
		}

		public double Travel(double start, float distance, Direction direction = Direction.Forward)
		{
			return 0.0;
		}

		public void EvaluatePosition(double percent, ref Vector3 position)
		{
		}

		[Obsolete("This override is obsolete. Use EvaluatePosition(double percent, ref Vector3 position) instead")]
		public void EvaluatePosition(ref Vector3 position, double percent)
		{
		}

		public void EvaluateTangent(double percent, ref Vector3 tangent)
		{
		}

		public void EvaluatePositionAndTangent(ref Vector3 position, ref Vector3 tangent, double percent)
		{
		}

		private double GetClosestPoint(int iterations, Vector3 point, double start, double end, int slices)
		{
			return 0.0;
		}

		public void Break()
		{
		}

		public void Break(int at)
		{
		}

		public void Close()
		{
		}

		public void CatToBezierTangents()
		{
		}

		private void CalculatePosition(ref Vector3 position, double percent, int pointIndex)
		{
		}

		private void CalculateTangent(ref Vector3 tangent, double percent, int pointIndex)
		{
		}

		private void CalculatePositionAndTangent(double percent, int pointIndex, ref Vector3 position, ref Vector3 tangent)
		{
		}

		private void CalculateLinearPosition(ref Vector3 position, double t, int i)
		{
		}

		private void CalculateLinearTangent(ref Vector3 tangent, double t, int i)
		{
		}

		private void CalculateBSplinePosition(ref Vector3 position, double time, int i)
		{
		}

		private void CalculateBezierPosition(ref Vector3 position, double t, int i)
		{
		}

		private void CalculateBezierTangent(ref Vector3 tangent, double t, int i)
		{
		}

		private void CalculateCatmullRomComponents(double t)
		{
		}

		private void CalculateCatmullRomPosition(double t, ref Vector3 position)
		{
		}

		private void CalculateCatmullRomTangent(double t, ref Vector3 tangent)
		{
		}

		private void CalculateCatmullRomPositionFast(ref Vector3 position, double t, int i)
		{
		}

		private void CalculateCatmullRomTangentFast(ref Vector3 tangent, double t, int i)
		{
		}

		private void ComputeCatPoints(int i)
		{
		}

		public static void FormatFromTo(ref double from, ref double to, bool preventInvert = true)
		{
		}
	}
}
