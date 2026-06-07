using UnityEngine;

namespace Mystery.Graphing
{
	public class IntegerLinearPlottableGraph : LinearPlottableGraphOverTime<long>
	{
		private long minY = long.MaxValue;

		private long maxY = long.MinValue;

		private double normalizeDivisorY = 1.0;

		private Vector2 previousTransformedPoint = new Vector2(float.PositiveInfinity, float.PositiveInfinity);

		private float previousX = float.PositiveInfinity;

		public override string YValueFormat => "F0";

		public override long MinY => minY;

		public override long MaxY => maxY;

		protected override void UpdateMinMaxY(long value)
		{
			if (value < minY)
			{
				minY = value;
				normalizeDivisorY = ((maxY == minY) ? 1.0 : (1.0 / (double)(maxY - minY)));
			}
			if (value > maxY)
			{
				maxY = value;
				normalizeDivisorY = ((maxY == minY) ? 1.0 : (1.0 / (double)(maxY - minY)));
			}
		}

		public override double NormalizeY(long value)
		{
			return (double)(value - minY) * normalizeDivisorY;
		}

		public override double GetTransformYToRangeScale(long lower, long upper)
		{
			previousX = float.PositiveInfinity;
			if (lower != upper)
			{
				return 1.0 / (double)(upper - lower);
			}
			return 1.0;
		}

		public override double ApplyTransformYToRange(long value, long lower, double inverseDivisor)
		{
			return (double)(value - lower) * inverseDivisor;
		}

		public override float YToFloat(long yValue)
		{
			return yValue;
		}

		public override string YToString(long yValue)
		{
			return yValue.ToString(YValueFormat);
		}

		public override void GetYRange(float zoom, float pan, ref long min, ref long max)
		{
			double num = min;
			double num2 = max;
			double num3 = max - min;
			double num4 = num3 * (double)pan;
			num += num4;
			num2 += num4;
			double num5 = num3 * (double)zoom;
			num += num5;
			num2 -= num5;
			min = (long)num;
			max = (long)num2;
		}

		public override long CalcYAt(long lower, long upper, float offset)
		{
			return lower + (long)((double)(upper - lower) * (double)offset);
		}

		public override void Clear()
		{
			base.Clear();
			minY = long.MaxValue;
			maxY = long.MinValue;
			normalizeDivisorY = 1.0;
		}

		public override object ParseY(string value, object fallback)
		{
			if (long.TryParse(value, out var result))
			{
				return result;
			}
			return fallback;
		}

		protected override void PlotGLGraphLine(float transformedPointX, float transformedPointY, float pointX, float pointY, float totalDistanceX, float totalDistanceY)
		{
			if (previousX < pointX)
			{
				float x = Mathf.Lerp(previousTransformedPoint.x, transformedPointX, 0.5f);
				GL.Vertex3(x, previousTransformedPoint.y, 0f);
				GL.Vertex3(x, previousTransformedPoint.y, 0f);
				GL.Vertex3(x, transformedPointY, 0f);
				GL.Vertex3(x, transformedPointY, 0f);
			}
			GL.Vertex3(transformedPointX, transformedPointY, 0f);
			GL.Vertex3(transformedPointX, transformedPointY, 0f);
			previousTransformedPoint = new Vector2(transformedPointX, transformedPointY);
			previousX = pointX;
		}
	}
}
