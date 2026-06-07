using UnityEngine;

namespace Mystery.Graphing
{
	public class StringLinearPlottableGraph : LinearPlottableGraphOverTime<string>
	{
		public override string MinY => string.Empty;

		public override string MaxY => string.Empty;

		public override bool JoinPlottedLines => false;

		protected override void UpdateMinMaxY(string value)
		{
		}

		public override double NormalizeY(string value)
		{
			return 0.5;
		}

		public override double GetTransformYToRangeScale(string lower, string upper)
		{
			return 0.5;
		}

		public override double ApplyTransformYToRange(string value, string lower, double inverseDivisor)
		{
			return 0.5;
		}

		public override float YToFloat(string yValue)
		{
			return 0f;
		}

		public override string YToString(string yValue)
		{
			return yValue;
		}

		public override void GetYRange(float zoom, float pan, ref string min, ref string max)
		{
			min = string.Empty;
			max = string.Empty;
		}

		public override string CalcYAt(string lower, string upper, float offset)
		{
			return lower;
		}

		protected override void PlotGLGraphLine(float transformedPointX, float transformedPointY, float pointX, float pointY, float totalDistanceX, float totalDistanceY)
		{
			GL.Vertex3(transformedPointX, 0f, 0f);
			GL.Vertex3(transformedPointX, 1f, 0f);
		}

		public override object ParseY(string value, object fallback)
		{
			return string.Empty;
		}
	}
}
