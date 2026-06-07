namespace Mystery.Graphing
{
	public class Vector2ScatteredPlottableGraph : ScatteredPlottableGraph<float, float>
	{
		private float minX = float.MaxValue;

		private float maxX = float.MinValue;

		private float normalizeDivisorX = 1f;

		private float minY = float.MaxValue;

		private float maxY = float.MinValue;

		private float normalizeDivisorY = 1f;

		public override string YValueFormat => "F4";

		public override float MinX => minX;

		public override float MaxX => maxX;

		public override float MinY => minY;

		public override float MaxY => maxY;

		protected override void UpdateMinMaxX(float value)
		{
			if (value < minX)
			{
				minX = value;
				normalizeDivisorX = ((maxX == minX) ? 1f : (1f / (maxX - minX)));
			}
			if (value > maxX)
			{
				maxX = value;
				normalizeDivisorX = ((maxX == minX) ? 1f : (1f / (maxX - minX)));
			}
		}

		protected override void UpdateMinMaxY(float value)
		{
			if (value < minY)
			{
				minY = value;
				normalizeDivisorY = ((maxY == minY) ? 1f : (1f / (maxY - minY)));
			}
			if (value > maxY)
			{
				maxY = value;
				normalizeDivisorY = ((maxY == minY) ? 1f : (1f / (maxY - minY)));
			}
		}

		public override double NormalizeX(float value)
		{
			return (value - minX) * normalizeDivisorX;
		}

		public override double NormalizeY(float value)
		{
			return (value - minY) * normalizeDivisorY;
		}

		public override bool IsInXRange(float value, float lower, float upper)
		{
			if (!(value < lower))
			{
				return !(value > upper);
			}
			return false;
		}

		public override double GetTransformXToRangeScale(float lower, float upper)
		{
			if (lower != upper)
			{
				return 1.0 / (double)(upper - lower);
			}
			return 1.0;
		}

		public override double GetTransformYToRangeScale(float lower, float upper)
		{
			if (lower != upper)
			{
				return 1.0 / (double)(upper - lower);
			}
			return 1.0;
		}

		public override double ApplyTransformXToRange(float value, float lower, double inverseDivisor)
		{
			return (double)(value - lower) * inverseDivisor;
		}

		public override double ApplyTransformYToRange(float value, float lower, double inverseDivisor)
		{
			return (double)(value - lower) * inverseDivisor;
		}

		protected override float GetDistanceBetweenX(float a, float b)
		{
			float num = a - b;
			if (!(num < 0f))
			{
				return num;
			}
			return 0f - num;
		}

		protected override float GetSearchX(float xOffset)
		{
			return MinX + (MaxX - MinX) * xOffset;
		}

		public override float XToFloat(float xValue)
		{
			return xValue;
		}

		public override float YToFloat(float yValue)
		{
			return yValue;
		}

		public override string XToString(float xValue)
		{
			return xValue.ToString(XValueFormat);
		}

		public override string YToString(float yValue)
		{
			return yValue.ToString(YValueFormat);
		}

		public override void GetXRange(float zoom, float pan, ref float min, ref float max)
		{
			float num = min;
			float num2 = max;
			float num3 = max - min;
			float num4 = num3 * pan;
			num += num4;
			num2 += num4;
			float num5 = num3 * zoom;
			num += num5;
			num2 -= num5;
			min = num;
			max = num2;
		}

		public override void GetYRange(float zoom, float pan, ref float min, ref float max)
		{
			float num = min;
			float num2 = max;
			float num3 = max - min;
			float num4 = num3 * pan;
			num += num4;
			num2 += num4;
			float num5 = num3 * zoom;
			num += num5;
			num2 -= num5;
			min = num;
			max = num2;
		}

		public override float CalcXAt(float lower, float upper, float offset)
		{
			return lower + (upper - lower) * offset;
		}

		public override float CalcYAt(float lower, float upper, float offset)
		{
			return lower + (upper - lower) * offset;
		}

		public override void Clear()
		{
			base.Clear();
			minX = float.MaxValue;
			maxX = float.MinValue;
			normalizeDivisorX = 1f;
			minY = float.MaxValue;
			maxY = float.MinValue;
			normalizeDivisorY = 1f;
		}

		public override object ParseY(string value, object fallback)
		{
			if (float.TryParse(value, out var result))
			{
				return result;
			}
			return fallback;
		}
	}
}
