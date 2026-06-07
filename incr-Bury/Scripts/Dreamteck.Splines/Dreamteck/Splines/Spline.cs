using System;
using System.Collections.Generic;
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

		public SplinePoint[] points = new SplinePoint[0];

		public Type type = Type.Bezier;

		public bool linearAverageDirection = true;

		public AnimationCurve customValueInterpolation;

		public AnimationCurve customNormalInterpolation;

		public int sampleRate = 10;

		private static Vector3[] P = new Vector3[4];

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

		public bool isClosed
		{
			get
			{
				if (closed)
				{
					return points.Length >= 3;
				}
				return false;
			}
		}

		public double moveStep
		{
			get
			{
				if (type == Type.Linear)
				{
					return 1f / (float)(points.Length - 1);
				}
				return 1f / (float)(iterations - 1);
			}
			set
			{
			}
		}

		public int iterations
		{
			get
			{
				if (type == Type.Linear)
				{
					if (!closed)
					{
						return points.Length;
					}
					return points.Length + 1;
				}
				int num = (closed ? points.Length : (points.Length - 1));
				return sampleRate * num - num + 1;
			}
		}

		public float knotParametrization
		{
			get
			{
				return _knotParametrization;
			}
			set
			{
				_knotParametrization = Mathf.Clamp01(value);
			}
		}

		public Spline(Type type)
		{
			this.type = type;
			points = new SplinePoint[0];
		}

		public Spline(Type type, int sampleRate)
		{
			this.type = type;
			this.sampleRate = sampleRate;
			points = new SplinePoint[0];
		}

		public float CalculateLength(double from = 0.0, double to = 1.0, double resolution = 1.0)
		{
			if (points.Length == 0)
			{
				return 0f;
			}
			resolution = DMath.Clamp01(resolution);
			if (resolution == 0.0)
			{
				return 0f;
			}
			from = DMath.Clamp01(from);
			to = DMath.Clamp01(to);
			if (to < from)
			{
				to = from;
			}
			double num = from;
			Vector3 vector = EvaluatePosition(num);
			float num2 = 0f;
			do
			{
				num = DMath.Move(num, to, moveStep / resolution);
				Vector3 vector2 = EvaluatePosition(num);
				num2 += (vector2 - vector).magnitude;
				vector = vector2;
			}
			while (num != to);
			return num2;
		}

		public double Project(Vector3 position, int subdivide = 4, double from = 0.0, double to = 1.0)
		{
			if (points.Length == 0)
			{
				return 0.0;
			}
			if (closed && from == 0.0 && to == 1.0)
			{
				double closestPoint = GetClosestPoint(subdivide, position, from, to, Mathf.RoundToInt(Mathf.Max(iterations / points.Length, 10)) * 5);
				if (closestPoint < moveStep)
				{
					double closestPoint2 = GetClosestPoint(subdivide, position, 0.5, to, Mathf.RoundToInt(Mathf.Max(iterations / points.Length, 10)) * 5);
					if (Vector3.Distance(position, EvaluatePosition(closestPoint2)) < Vector3.Distance(position, EvaluatePosition(closestPoint)))
					{
						return closestPoint2;
					}
				}
				return closestPoint;
			}
			return GetClosestPoint(subdivide, position, from, to, Mathf.RoundToInt(Mathf.Max(iterations / points.Length, 10)) * 5);
		}

		public bool Raycast(out RaycastHit hit, out double hitPercent, LayerMask layerMask, double resolution = 1.0, double from = 0.0, double to = 1.0, QueryTriggerInteraction hitTriggers = QueryTriggerInteraction.UseGlobal)
		{
			resolution = DMath.Clamp01(resolution);
			from = DMath.Clamp01(from);
			to = DMath.Clamp01(to);
			double num = from;
			Vector3 vector = EvaluatePosition(num);
			hitPercent = 0.0;
			if (resolution == 0.0)
			{
				hit = default(RaycastHit);
				hitPercent = 0.0;
				return false;
			}
			do
			{
				double a = num;
				num = DMath.Move(num, to, moveStep / resolution);
				Vector3 vector2 = EvaluatePosition(num);
				if (Physics.Linecast(vector, vector2, out hit, layerMask, hitTriggers))
				{
					double t = (hit.point - vector).sqrMagnitude / (vector2 - vector).sqrMagnitude;
					hitPercent = DMath.Lerp(a, num, t);
					return true;
				}
				vector = vector2;
			}
			while (num != to);
			return false;
		}

		public bool RaycastAll(out RaycastHit[] hits, out double[] hitPercents, LayerMask layerMask, double resolution = 1.0, double from = 0.0, double to = 1.0, QueryTriggerInteraction hitTriggers = QueryTriggerInteraction.UseGlobal)
		{
			resolution = DMath.Clamp01(resolution);
			from = DMath.Clamp01(from);
			to = DMath.Clamp01(to);
			double num = from;
			Vector3 vector = EvaluatePosition(num);
			List<RaycastHit> list = new List<RaycastHit>();
			List<double> list2 = new List<double>();
			if (resolution == 0.0)
			{
				hits = new RaycastHit[0];
				hitPercents = new double[0];
				return false;
			}
			bool result = false;
			do
			{
				double a = num;
				num = DMath.Move(num, to, moveStep / resolution);
				Vector3 vector2 = EvaluatePosition(num);
				RaycastHit[] array = Physics.RaycastAll(vector, vector2 - vector, Vector3.Distance(vector, vector2), layerMask, hitTriggers);
				for (int i = 0; i < array.Length; i++)
				{
					result = true;
					double t = (array[i].point - vector).sqrMagnitude / (vector2 - vector).sqrMagnitude;
					list2.Add(DMath.Lerp(a, num, t));
					list.Add(array[i]);
				}
				vector = vector2;
			}
			while (num != to);
			hits = list.ToArray();
			hitPercents = list2.ToArray();
			return result;
		}

		public double GetPointPercent(int pointIndex)
		{
			if (closed)
			{
				return DMath.Clamp01((double)pointIndex / (double)points.Length);
			}
			return DMath.Clamp01((double)pointIndex / (double)(points.Length - 1));
		}

		public Vector3 EvaluatePosition(double percent)
		{
			if (points.Length == 0)
			{
				return Vector3.zero;
			}
			Vector3 position = default(Vector3);
			EvaluatePosition(percent, ref position);
			return position;
		}

		public SplineSample Evaluate(double percent)
		{
			SplineSample sample = default(SplineSample);
			Evaluate(percent, ref sample);
			return sample;
		}

		public SplineSample Evaluate(int pointIndex)
		{
			SplineSample sample = default(SplineSample);
			Evaluate(GetPointPercent(pointIndex), ref sample);
			return sample;
		}

		public void Evaluate(int pointIndex, ref SplineSample result)
		{
			Evaluate(GetPointPercent(pointIndex), ref result);
		}

		public void Evaluate(double percent, ref SplineSample sample)
		{
			if (points.Length == 0)
			{
				sample = default(SplineSample);
				return;
			}
			percent = DMath.Clamp01(percent);
			if (closed && points.Length <= 2)
			{
				closed = false;
			}
			if (points.Length == 1)
			{
				sample.position = points[0].position;
				sample.up = points[0].normal;
				sample.forward = Vector3.forward;
				sample.size = points[0].size;
				sample.color = points[0].color;
				sample.percent = percent;
				return;
			}
			double num = (double)(points.Length - 1) * percent;
			if (closed)
			{
				num = (double)points.Length * percent;
			}
			int num2 = DMath.FloorInt(num);
			int num3 = num2 + 1;
			if (closed)
			{
				if (num2 >= points.Length - 1)
				{
					num2 = points.Length - 1;
				}
				if (num3 > points.Length - 1)
				{
					num3 = 0;
				}
			}
			else if (num3 > points.Length - 1)
			{
				num3 = points.Length - 1;
			}
			double num4 = num - (double)num2;
			sample.percent = percent;
			float num5 = (float)num4;
			if (customValueInterpolation != null && customValueInterpolation.length > 0)
			{
				num5 = customValueInterpolation.Evaluate(num5);
			}
			float num6 = (float)num4;
			if (customNormalInterpolation != null && customNormalInterpolation.length > 0)
			{
				num6 = customNormalInterpolation.Evaluate(num6);
			}
			sample.size = Mathf.Lerp(points[num2].size, points[num3].size, num5);
			sample.color = Color.Lerp(points[num2].color, points[num3].color, num5);
			sample.up = Vector3.Slerp(points[num2].normal, points[num3].normal, num6);
			EvaluatePositionAndTangent(ref sample.position, ref sample.forward, percent);
			if (type == Type.BSpline)
			{
				double num7 = 1.0 / (double)(iterations - 1);
				if (percent <= 1.0 - num7 && percent >= num7)
				{
					sample.forward = EvaluatePosition(percent + num7) - EvaluatePosition(percent - num7);
				}
				else
				{
					Vector3 position = Vector3.zero;
					Vector3 position2 = Vector3.zero;
					if (closed)
					{
						if (percent < num7)
						{
							EvaluatePosition(1.0 - (num7 - percent), ref position);
						}
						else
						{
							EvaluatePosition(percent - num7, ref position);
						}
						if (percent > 1.0 - num7)
						{
							EvaluatePosition(num7 - (1.0 - percent), ref position2);
						}
						else
						{
							EvaluatePosition(percent + num7, ref position2);
						}
						sample.forward = position2 - position;
					}
					else
					{
						EvaluatePosition(percent - num7, ref position);
						position = sample.position - position;
						EvaluatePosition(percent + num7, ref position2);
						position2 -= sample.position;
						sample.forward = Vector3.Slerp(position2, position, position.magnitude / position2.magnitude);
					}
				}
			}
			sample.forward.Normalize();
		}

		[Obsolete("This override is obsolete. Use Evaluate(int pointIndex, ref SplineSample sample) instead")]
		public void Evaluate(ref SplineSample sample, int pointIndex)
		{
			Evaluate(pointIndex, ref sample);
		}

		[Obsolete("This override is obsolete. Use Evaluate(double percent, ref SplineSample sample) instead")]
		public void Evaluate(ref SplineSample sample, double percent)
		{
			Evaluate(percent, ref sample);
		}

		public void Evaluate(ref SplineSample[] samples, double from = 0.0, double to = 1.0)
		{
			if (points.Length == 0)
			{
				samples = new SplineSample[0];
				return;
			}
			from = DMath.Clamp01(from);
			to = DMath.Clamp(to, from, 1.0);
			double a = from * (double)(iterations - 1);
			int num = DMath.CeilInt(to * (double)(iterations - 1)) - DMath.FloorInt(a) + 1;
			if (samples == null)
			{
				samples = new SplineSample[num];
			}
			else if (samples.Length != num)
			{
				samples = new SplineSample[num];
			}
			double num2 = from;
			double amount = moveStep;
			int num3 = 0;
			while (true)
			{
				samples[num3] = Evaluate(num2);
				num3++;
				if (num3 < samples.Length)
				{
					num2 = DMath.Move(num2, to, amount);
					continue;
				}
				break;
			}
		}

		public void EvaluateUniform(ref SplineSample[] samples, ref double[] originalSamplePercents, double from = 0.0, double to = 1.0)
		{
			if (points.Length == 0)
			{
				samples = new SplineSample[0];
				return;
			}
			from = DMath.Clamp01(from);
			to = DMath.Clamp(to, from, 1.0);
			double a = from * (double)(iterations - 1);
			int num = DMath.CeilInt(to * (double)(iterations - 1)) - DMath.FloorInt(a) + 1;
			if (samples == null || samples.Length != num)
			{
				samples = new SplineSample[num];
			}
			if (originalSamplePercents == null || originalSamplePercents.Length != num)
			{
				originalSamplePercents = new double[num];
			}
			float distance = CalculateLength(from, to) / (float)(iterations - 1);
			Evaluate(from, ref samples[0]);
			samples[0].percent = (originalSamplePercents[0] = from);
			double num2 = from;
			float moved = 0f;
			for (int i = 1; i < samples.Length - 1; i++)
			{
				Evaluate(Travel(num2, distance, out moved, Direction.Forward), ref samples[i]);
				num2 = samples[i].percent;
				originalSamplePercents[i] = num2;
				samples[i].percent = DMath.Lerp(from, to, (double)i / (double)(samples.Length - 1));
			}
			Evaluate(to, ref samples[samples.Length - 1]);
			samples[samples.Length - 1].percent = (originalSamplePercents[originalSamplePercents.Length - 1] = to);
		}

		public void EvaluatePositions(ref Vector3[] positions, double from = 0.0, double to = 1.0)
		{
			if (points.Length == 0)
			{
				positions = new Vector3[0];
				return;
			}
			from = DMath.Clamp01(from);
			to = DMath.Clamp(to, from, 1.0);
			double a = from * (double)(iterations - 1);
			int num = DMath.CeilInt(to * (double)(iterations - 1)) - DMath.FloorInt(a) + 1;
			if (positions.Length != num)
			{
				positions = new Vector3[num];
			}
			double num2 = from;
			double amount = moveStep;
			int num3 = 0;
			while (true)
			{
				positions[num3] = EvaluatePosition(num2);
				num3++;
				if (num3 < positions.Length)
				{
					num2 = DMath.Move(num2, to, amount);
					continue;
				}
				break;
			}
		}

		public double Travel(double start, float distance, out float moved, Direction direction)
		{
			moved = 0f;
			if (points.Length <= 1)
			{
				return 0.0;
			}
			if (direction == Direction.Forward && start >= 1.0)
			{
				return 1.0;
			}
			if (direction == Direction.Backward && start <= 0.0)
			{
				return 0.0;
			}
			if (distance == 0f)
			{
				return DMath.Clamp01(start);
			}
			Vector3 position = Vector3.zero;
			EvaluatePosition(start, ref position);
			Vector3 b = position;
			double a = start;
			int num = iterations - 1;
			int num2 = ((direction == Direction.Forward) ? DMath.CeilInt(start * (double)num) : DMath.FloorInt(start * (double)num));
			float num3 = 0f;
			double num4 = start;
			while (true)
			{
				num4 = (double)num2 / (double)num;
				position = EvaluatePosition(num4);
				num3 = Vector3.Distance(position, b);
				b = position;
				moved += num3;
				if (moved >= distance)
				{
					break;
				}
				a = num4;
				if (direction == Direction.Forward)
				{
					if (num2 == num)
					{
						break;
					}
					num2++;
				}
				else
				{
					if (num2 == 0)
					{
						break;
					}
					num2--;
				}
			}
			return DMath.Lerp(a, num4, 1f - (moved - distance) / num3);
		}

		public double Travel(double start, float distance, Direction direction = Direction.Forward)
		{
			float moved;
			return Travel(start, distance, out moved, direction);
		}

		public void EvaluatePosition(double percent, ref Vector3 position)
		{
			if (points.Length == 0)
			{
				position = Vector3.zero;
				return;
			}
			if (points.Length == 1)
			{
				position = points[0].position;
				return;
			}
			percent = DMath.Clamp01(percent);
			double num = (double)(points.Length - 1) * percent;
			if (closed)
			{
				num = (double)points.Length * percent;
			}
			int num2 = DMath.FloorInt(num);
			if (type == Type.Bezier)
			{
				num2 = Mathf.Clamp(num2, 0, Mathf.Max(points.Length - 1, 0));
			}
			CalculatePosition(ref position, num - (double)num2, num2);
		}

		[Obsolete("This override is obsolete. Use EvaluatePosition(double percent, ref Vector3 position) instead")]
		public void EvaluatePosition(ref Vector3 position, double percent)
		{
			EvaluatePosition(percent, ref position);
		}

		public void EvaluateTangent(double percent, ref Vector3 tangent)
		{
			if (points.Length < 2)
			{
				tangent = Vector3.forward;
				return;
			}
			percent = DMath.Clamp01(percent);
			double num = (double)(points.Length - 1) * percent;
			if (closed)
			{
				num = (double)points.Length * percent;
			}
			int num2 = DMath.FloorInt(num);
			if (type == Type.Bezier)
			{
				num2 = Mathf.Clamp(num2, 0, Mathf.Max(points.Length - 1, 0));
			}
			CalculateTangent(ref tangent, num - (double)num2, num2);
		}

		public void EvaluatePositionAndTangent(ref Vector3 position, ref Vector3 tangent, double percent)
		{
			if (points.Length == 0)
			{
				position = Vector3.zero;
				tangent = Vector3.forward;
				return;
			}
			if (points.Length == 1)
			{
				position = points[0].position;
				tangent = Vector3.forward;
				return;
			}
			percent = DMath.Clamp01(percent);
			double num = (double)(points.Length - 1) * percent;
			if (closed)
			{
				num = (double)points.Length * percent;
			}
			int num2 = DMath.FloorInt(num);
			if (type == Type.Bezier)
			{
				num2 = Mathf.Clamp(num2, 0, Mathf.Max(points.Length - 1, 0));
			}
			CalculatePositionAndTangent(num - (double)num2, num2, ref position, ref tangent);
		}

		private double GetClosestPoint(int iterations, Vector3 point, double start, double end, int slices)
		{
			if (iterations <= 0)
			{
				float sqrMagnitude = (point - EvaluatePosition(start)).sqrMagnitude;
				float sqrMagnitude2 = (point - EvaluatePosition(end)).sqrMagnitude;
				if (sqrMagnitude < sqrMagnitude2)
				{
					return start;
				}
				if (sqrMagnitude2 < sqrMagnitude)
				{
					return end;
				}
				return (start + end) / 2.0;
			}
			double num = 0.0;
			float num2 = float.PositiveInfinity;
			double num3 = (end - start) / (double)slices;
			double num4 = start;
			Vector3 position = Vector3.zero;
			while (true)
			{
				EvaluatePosition(num4, ref position);
				float sqrMagnitude3 = (point - position).sqrMagnitude;
				if (sqrMagnitude3 < num2)
				{
					num2 = sqrMagnitude3;
					num = num4;
				}
				if (num4 == end)
				{
					break;
				}
				num4 = DMath.Move(num4, end, num3);
			}
			double num5 = num - num3;
			if (num5 < start)
			{
				num5 = start;
			}
			double num6 = num + num3;
			if (num6 > end)
			{
				num6 = end;
			}
			return GetClosestPoint(--iterations, point, num5, num6, slices);
		}

		public void Break()
		{
			Break(0);
		}

		public void Break(int at)
		{
			if (closed && at < points.Length && at >= 0)
			{
				SplinePoint[] array = new SplinePoint[points.Length];
				points.CopyTo(array, 0);
				for (int i = at; i < array.Length; i++)
				{
					points[i - at] = array[i];
				}
				for (int j = 0; j < at; j++)
				{
					points[points.Length - at + j] = array[j];
				}
				closed = false;
			}
		}

		public void Close()
		{
			if (points.Length < 3)
			{
				Debug.LogError("Points need to be at least 3 to close the spline");
			}
			else
			{
				closed = true;
			}
		}

		public void CatToBezierTangents()
		{
			switch (type)
			{
			case Type.Linear:
			{
				for (int j = 0; j < points.Length; j++)
				{
					points[j].type = SplinePoint.Type.Broken;
					points[j].SetTangentPosition(points[j].position);
					points[j].SetTangent2Position(points[j].position);
				}
				break;
			}
			case Type.CatmullRom:
			{
				for (int i = 0; i < points.Length; i++)
				{
					points[i].type = SplinePoint.Type.SmoothMirrored;
					double pointPercent = GetPointPercent(i);
					Vector3 tangent = Vector3.forward;
					EvaluateTangent(pointPercent, ref tangent);
					if (_knotParametrization > 0f)
					{
						ComputeCatPoints(i);
						points[i].SetTangent2Position(points[i].position + tangent.normalized * Vector3.Distance(P[0], P[2]) / 6f);
					}
					else
					{
						points[i].SetTangent2Position(points[i].position + tangent / 3f);
					}
				}
				break;
			}
			}
			type = Type.Bezier;
		}

		private void CalculatePosition(ref Vector3 position, double percent, int pointIndex)
		{
			switch (type)
			{
			case Type.CatmullRom:
				ComputeCatPoints(pointIndex);
				if (_knotParametrization < 1E-06f)
				{
					CalculateCatmullRomPositionFast(ref position, percent, pointIndex);
					break;
				}
				CalculateCatmullRomComponents(percent);
				CalculateCatmullRomPosition(percent, ref position);
				break;
			case Type.Bezier:
				CalculateBezierPosition(ref position, percent, pointIndex);
				break;
			case Type.BSpline:
				ComputeCatPoints(pointIndex);
				CalculateBSplinePosition(ref position, percent, pointIndex);
				break;
			case Type.Linear:
				ComputeCatPoints(pointIndex);
				CalculateLinearPosition(ref position, percent, pointIndex);
				break;
			}
		}

		private void CalculateTangent(ref Vector3 tangent, double percent, int pointIndex)
		{
			switch (type)
			{
			case Type.CatmullRom:
				ComputeCatPoints(pointIndex);
				if (_knotParametrization < 1E-06f)
				{
					CalculateCatmullRomTangentFast(ref tangent, percent, pointIndex);
					break;
				}
				CalculateCatmullRomComponents(percent);
				CalculateCatmullRomTangent(percent, ref tangent);
				break;
			case Type.Bezier:
				CalculateBezierTangent(ref tangent, percent, pointIndex);
				break;
			case Type.Linear:
				ComputeCatPoints(pointIndex);
				CalculateLinearTangent(ref tangent, percent, pointIndex);
				break;
			case Type.BSpline:
				break;
			}
		}

		private void CalculatePositionAndTangent(double percent, int pointIndex, ref Vector3 position, ref Vector3 tangent)
		{
			switch (type)
			{
			case Type.CatmullRom:
				ComputeCatPoints(pointIndex);
				if (_knotParametrization < 1E-06f)
				{
					CalculateCatmullRomPositionFast(ref position, percent, pointIndex);
					CalculateCatmullRomTangentFast(ref tangent, percent, pointIndex);
				}
				else
				{
					CalculateCatmullRomComponents(percent);
					CalculateCatmullRomPosition(percent, ref position);
					CalculateCatmullRomTangent(percent, ref tangent);
				}
				break;
			case Type.Bezier:
				CalculateBezierPosition(ref position, percent, pointIndex);
				CalculateBezierTangent(ref tangent, percent, pointIndex);
				break;
			case Type.BSpline:
				ComputeCatPoints(pointIndex);
				CalculateBSplinePosition(ref position, percent, pointIndex);
				break;
			case Type.Linear:
				ComputeCatPoints(pointIndex);
				CalculateLinearPosition(ref position, percent, pointIndex);
				CalculateLinearTangent(ref tangent, percent, pointIndex);
				break;
			}
		}

		private void CalculateLinearPosition(ref Vector3 position, double t, int i)
		{
			if (points.Length == 0)
			{
				position = Vector3.zero;
			}
			else
			{
				position = Vector3.Lerp(P[1], P[2], (float)t);
			}
		}

		private void CalculateLinearTangent(ref Vector3 tangent, double t, int i)
		{
			if (points.Length == 0)
			{
				tangent = Vector3.forward;
			}
			else if (linearAverageDirection)
			{
				tangent = Vector3.Slerp(P[1] - P[0], P[2] - P[1], 0.5f);
			}
			else
			{
				tangent = P[2] - P[1];
			}
		}

		private void CalculateBSplinePosition(ref Vector3 position, double time, int i)
		{
			if (points.Length != 0)
			{
				position = points[0].position;
			}
			if (points.Length > 1)
			{
				float num = (float)DMath.Clamp01(time);
				position = ((-P[0] + P[2]) / 2f + num * ((P[0] - 2f * P[1] + P[2]) / 2f + num * (-P[0] + 3f * P[1] - 3f * P[2] + P[3]) / 6f)) * num + (P[0] + 4f * P[1] + P[2]) / 6f;
			}
		}

		private void CalculateBezierPosition(ref Vector3 position, double t, int i)
		{
			if (points.Length == 0)
			{
				return;
			}
			position = points[0].position;
			if (closed || points.Length != 1)
			{
				t = DMath.Clamp01(t);
				int num = i + 1;
				if (num >= points.Length)
				{
					num = 0;
				}
				float num2 = (float)t;
				float num3 = 1f - num2;
				position = num3 * num3 * num3 * points[i].position + 3f * num3 * num3 * num2 * points[i].tangent2 + 3f * num3 * num2 * num2 * points[num].tangent + num2 * num2 * num2 * points[num].position;
			}
		}

		private void CalculateBezierTangent(ref Vector3 tangent, double t, int i)
		{
			if (points.Length == 0)
			{
				return;
			}
			tangent = points[0].tangent;
			if (closed || points.Length != 1)
			{
				t = DMath.Clamp01(t);
				int num = i + 1;
				if (num >= points.Length)
				{
					num = 0;
				}
				float num2 = (float)t;
				float num3 = 1f - num2;
				tangent = -3f * num3 * num3 * points[i].position + 3f * num3 * num3 * points[i].tangent2 - 6f * num2 * num3 * points[i].tangent2 - 3f * num2 * num2 * points[num].tangent + 6f * num2 * num3 * points[num].tangent + 3f * num2 * num2 * points[num].position;
			}
		}

		private void CalculateCatmullRomComponents(double t)
		{
			t1 = GetInterval(P[0], P[1]);
			t2 = GetInterval(P[1], P[2]) + t1;
			t3 = GetInterval(P[2], P[3]) + t2;
			float num = Mathf.LerpUnclamped(t1, t2, (float)t);
			A1 = (t1 - num) / (t1 - 0f) * P[0] + (num - 0f) / (t1 - 0f) * P[1];
			A2 = (t2 - num) / (t2 - t1) * P[1] + (num - t1) / (t2 - t1) * P[2];
			A3 = (t3 - num) / (t3 - t2) * P[2] + (num - t2) / (t3 - t2) * P[3];
			B1 = (t2 - num) / (t2 - 0f) * A1 + (num - 0f) / (t2 - 0f) * A2;
			B2 = (t3 - num) / (t3 - t1) * A2 + (num - t1) / (t3 - t1) * A3;
			float GetInterval(Vector3 a, Vector3 b)
			{
				return Mathf.Pow((a - b).sqrMagnitude, _knotParametrization * 0.5f);
			}
		}

		private void CalculateCatmullRomPosition(double t, ref Vector3 position)
		{
			float num = Mathf.LerpUnclamped(t1, t2, (float)t);
			position = (t2 - num) / (t2 - t1) * B1 + (num - t1) / (t2 - t1) * B2;
		}

		private void CalculateCatmullRomTangent(double t, ref Vector3 tangent)
		{
			float num = Mathf.LerpUnclamped(t1, t2, (float)t);
			Vector3 vector = (P[1] - P[0]) / t1;
			Vector3 vector2 = (P[2] - P[1]) / (t2 - t1);
			Vector3 vector3 = (P[3] - P[2]) / (t3 - t2);
			Vector3 vector4 = (A2 - A1) / t2 + (t2 - num) / t2 * vector + num / t2 * vector2;
			Vector3 vector5 = (A3 - A2) / (t3 - t1) + (t3 - num) / (t3 - t1) * vector2 + (num - t1) / (t3 - t1) * vector3;
			tangent = (B2 - B1) / (t2 - t1) + (t2 - num) / (t2 - t1) * vector4 + (num - t1) / (t2 - t1) * vector5;
		}

		private void CalculateCatmullRomPositionFast(ref Vector3 position, double t, int i)
		{
			float num = (float)t;
			float num2 = num * num;
			float num3 = num2 * num;
			if (points.Length != 0)
			{
				position = points[0].position;
			}
			if ((closed || i < points.Length) && points.Length > 1)
			{
				position = 0.5f * (2f * P[1] + (-P[0] + P[2]) * num + (2f * P[0] - 5f * P[1] + 4f * P[2] - P[3]) * num2 + (-P[0] + 3f * P[1] - 3f * P[2] + P[3]) * num3);
			}
		}

		private void CalculateCatmullRomTangentFast(ref Vector3 tangent, double t, int i)
		{
			float num = (float)t;
			float num2 = num * num;
			if ((closed || i < points.Length) && points.Length > 1)
			{
				tangent = (6f * num2 - 6f * num) * P[1] + (3f * num2 - 4f * num + 1f) * (P[2] - P[0]) * 0.5f + (-6f * num2 + 6f * num) * P[2] + (3f * num2 - 2f * num) * (P[3] - P[1]) * 0.5f;
			}
		}

		private void ComputeCatPoints(int i)
		{
			int num = i - 1;
			int num2 = i;
			int num3 = i + 1;
			int num4 = i + 2;
			if (closed)
			{
				if (num < 0)
				{
					num += points.Length;
				}
				if (num2 >= points.Length)
				{
					num2 -= points.Length;
				}
				if (num3 >= points.Length)
				{
					num3 -= points.Length;
				}
				if (num4 >= points.Length)
				{
					num4 -= points.Length;
				}
				P[0] = points[num].position;
				P[1] = points[num2].position;
				P[2] = points[num3].position;
				P[3] = points[num4].position;
				return;
			}
			if (num < 0)
			{
				P[0] = points[0].position;
				P[0] += P[0] - points[1].position;
			}
			else
			{
				P[0] = points[num].position;
			}
			P[1] = points[num2].position;
			if (num3 >= points.Length)
			{
				P[2] = points[points.Length - 1].position;
				Vector3 vector = P[2];
				P[2] += P[2] - points[points.Length - 2].position;
				P[3] = P[2] + (P[2] - vector);
			}
			else
			{
				P[2] = points[num3].position;
				if (num4 >= points.Length)
				{
					P[3] = P[2] + (P[2] - points[num3 - 1].position);
				}
				else
				{
					P[3] = points[num4].position;
				}
			}
		}

		public static void FormatFromTo(ref double from, ref double to, bool preventInvert = true)
		{
			from = DMath.Clamp01(from);
			to = DMath.Clamp01(to);
			if (preventInvert && from > to)
			{
				double num = from;
				from = to;
				to = num;
			}
			else
			{
				to = DMath.Clamp(to, 0.0, 1.0);
			}
		}
	}
}
