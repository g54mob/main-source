using UnityEngine;

namespace Mystery.Graphing
{
	public class BooleanLinearPlottableGraph : LinearPlottableGraphOverTime<bool>
	{
		private Vector2 previousTransformedPoint = new Vector2(float.PositiveInfinity, float.PositiveInfinity);

		private float previousX = float.PositiveInfinity;

		public override bool MinY => false;

		public override bool MaxY => true;

		protected override void UpdateMinMaxY(bool value)
		{
		}

		public override double NormalizeY(bool value)
		{
			if (!value)
			{
				return 0.0;
			}
			return 1.0;
		}

		public override double GetTransformYToRangeScale(bool lower, bool upper)
		{
			previousX = float.PositiveInfinity;
			return 1.0;
		}

		public override double ApplyTransformYToRange(bool value, bool lower, double inverseDivisor)
		{
			if (!value)
			{
				return 0.0;
			}
			return 1.0;
		}

		public override float YToFloat(bool value)
		{
			if (!value)
			{
				return 0f;
			}
			return 1f;
		}

		public override string YToString(bool yValue)
		{
			return yValue.ToString();
		}

		public override void GetYRange(float zoom, float pan, ref bool min, ref bool max)
		{
			min = false;
			max = true;
		}

		public override bool CalcYAt(bool lower, bool upper, float offset)
		{
			return lower;
		}

		public override object ParseY(string value, object fallback)
		{
			if (bool.TryParse(value, out var result))
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
