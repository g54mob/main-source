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

		[SerializeField]
		private bool closed;

		public Type type;

		public bool linearAverageDirection;

		public AnimationCurve customValueInterpolation;

		public AnimationCurve customNormalInterpolation;

		public int sampleRate;

		private static Vector3[] catPoints;

		public bool isClosed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

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
			return null;
		}

		public SplineSample Evaluate(int pointIndex)
		{
			return null;
		}

		public void Evaluate(SplineSample result, int pointIndex)
		{
		}

		public void Evaluate(SplineSample result, double percent)
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

		public void EvaluatePosition(ref Vector3 point, double percent)
		{
		}

		public void EvaluateTangent(ref Vector3 tangent, double percent)
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

		private void GetPoint(ref Vector3 point, double percent, int pointIndex)
		{
		}

		private void GetTangent(ref Vector3 tangent, double percent, int pointIndex)
		{
		}

		private void LinearGetPoint(ref Vector3 point, double t, int i)
		{
		}

		private void LinearGetTangent(ref Vector3 tangent, double t, int i)
		{
		}

		private void BSPGetPoint(ref Vector3 point, double time, int i)
		{
		}

		private void BezierGetPoint(ref Vector3 point, double t, int i)
		{
		}

		private void BezierGetTangent(ref Vector3 tangent, double t, int i)
		{
		}

		private void CatmullRomGetPoint(ref Vector3 point, double t, int i)
		{
		}

		private void GetCatmullRomTangent(ref Vector3 direction, double t, int i)
		{
		}

		private void GetCatPoints(int i)
		{
		}

		public static void FormatFromTo(ref double from, ref double to, bool preventInvert = true)
		{
		}
	}
}
