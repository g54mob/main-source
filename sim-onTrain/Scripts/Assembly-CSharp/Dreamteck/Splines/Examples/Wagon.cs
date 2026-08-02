using UnityEngine;

namespace Dreamteck.Splines.Examples
{
	public class Wagon : MonoBehaviour
	{
		public class SplineSegment
		{
			public SplineComputer spline;

			public int start = -1;

			public int end = -1;

			public Spline.Direction direction;

			public SplineSegment(SplineComputer spline, int entryPoint, Spline.Direction direction)
			{
				this.spline = spline;
				start = entryPoint;
				this.direction = direction;
			}

			public SplineSegment(SplineSegment input)
			{
				spline = input.spline;
				start = input.start;
				end = input.end;
				direction = input.direction;
			}

			public double Travel(double percent, float distance, Spline.Direction direction, out float moved, bool loop)
			{
				double max = ((direction == Spline.Direction.Forward) ? 1.0 : 0.0);
				if (start >= 0)
				{
					max = spline.GetPointPercent(start);
				}
				return TravelClamped(percent, distance, direction, max, out moved, loop);
			}

			public double Travel(float distance, Spline.Direction direction, out float moved, bool loop)
			{
				double pointPercent = spline.GetPointPercent(end);
				double max = ((direction == Spline.Direction.Forward) ? 1.0 : 0.0);
				if (start >= 0)
				{
					max = spline.GetPointPercent(start);
				}
				return TravelClamped(pointPercent, distance, direction, max, out moved, loop);
			}

			private double TravelClamped(double percent, float distance, Spline.Direction direction, double max, out float moved, bool loop)
			{
				moved = 0f;
				float moved2 = 0f;
				double num = spline.Travel(percent, distance, out moved2, direction);
				moved += moved2;
				if (loop && moved < distance)
				{
					if (direction == Spline.Direction.Forward && Mathf.Approximately((float)num, 1f))
					{
						num = spline.Travel(0.0, distance - moved, out moved2, direction);
					}
					else if (direction == Spline.Direction.Backward && Mathf.Approximately((float)num, 0f))
					{
						num = spline.Travel(1.0, distance - moved, out moved2, direction);
					}
					moved += moved2;
				}
				if (direction == Spline.Direction.Forward && percent <= max)
				{
					if (num > max)
					{
						moved -= spline.CalculateLength(num, max);
						num = max;
					}
				}
				else if (direction == Spline.Direction.Backward && percent >= max && num < max)
				{
					moved -= spline.CalculateLength(max, num);
					num = max;
				}
				return num;
			}
		}

		private SplineTracer tracer;

		public bool isEngine;

		public Wagon back;

		public float offset;

		private Wagon front;

		private SplineSegment segment;

		private SplineSegment tempSegment;

		private void Awake()
		{
			tracer = GetComponent<SplineTracer>();
			if (isEngine)
			{
				SetupRecursively(null, new SplineSegment(tracer.spline, -1, tracer.direction));
			}
		}

		private void AddNewWagon()
		{
			if (isEngine)
			{
				SetupRecursively(null, new SplineSegment(tracer.spline, -1, tracer.direction));
			}
		}

		private void SetupRecursively(Wagon frontWagon, SplineSegment inputSegment)
		{
			front = frontWagon;
			segment = inputSegment;
			if (back != null)
			{
				back.SetupRecursively(this, segment);
			}
		}

		public void UpdateOffset()
		{
			ApplyOffset();
			if (back != null)
			{
				back.UpdateOffset();
			}
		}

		private Wagon GetRootWagon()
		{
			Wagon wagon = this;
			while (wagon.front != null)
			{
				wagon = wagon.front;
			}
			return wagon;
		}

		private void ApplyOffset()
		{
			if (isEngine)
			{
				ResetSegments();
				return;
			}
			float num = 0f;
			float moved = 0f;
			double percent = front.tracer.UnclipPercent(front.tracer.result.percent);
			Spline.Direction direction = front.segment.direction;
			InvertDirection(ref direction);
			SplineComputer spline = front.segment.spline;
			double percent2 = front.segment.Travel(percent, offset, direction, out moved, front.segment.spline.isClosed);
			num += moved;
			if (Mathf.Approximately(num, offset))
			{
				if (segment != front.segment && back != null)
				{
					back.segment = segment;
				}
				if (segment != front.segment)
				{
					segment = front.segment;
				}
				ApplyTracer(spline, percent2, front.tracer.direction);
				return;
			}
			if (segment != front.segment)
			{
				direction = segment.direction;
				InvertDirection(ref direction);
				spline = segment.spline;
				percent2 = segment.Travel(offset - num, direction, out moved, segment.spline.isClosed);
				num += moved;
			}
			ApplyTracer(spline, percent2, segment.direction);
		}

		private void ResetSegments()
		{
			Wagon wagon = back;
			bool flag = true;
			while (wagon != null)
			{
				if (wagon.segment != segment)
				{
					flag = false;
					break;
				}
				wagon = wagon.back;
			}
			if (flag)
			{
				segment.start = -1;
			}
		}

		private void ApplyTracer(SplineComputer spline, double percent, Spline.Direction direction)
		{
			bool num = tracer.spline != spline;
			tracer.spline = spline;
			if (num)
			{
				tracer.RebuildImmediate();
			}
			tracer.direction = direction;
			tracer.SetPercent(tracer.ClipPercent(percent));
		}

		public void EnterSplineSegment(int previousSplineExitPoint, SplineComputer spline, int entryPoint, Spline.Direction direction)
		{
			if (isEngine)
			{
				if (back != null)
				{
					segment.end = previousSplineExitPoint;
					back.segment = segment;
				}
				segment = new SplineSegment(spline, entryPoint, direction);
			}
		}

		private static void InvertDirection(ref Spline.Direction direction)
		{
			if (direction == Spline.Direction.Forward)
			{
				direction = Spline.Direction.Backward;
			}
			else
			{
				direction = Spline.Direction.Forward;
			}
		}
	}
}
