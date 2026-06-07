using System;
using UnityEngine;

namespace Mystery.Graphing
{
	public abstract class LinearPlottableGraphOverTime<T> : LinearPlottableGraph<float, T>, ILinearPlottableGraphOverTime, IPlottableGraph where T : IComparable<T>
	{
		private float minX;

		private float maxX = float.MinValue;

		private double normalizeDivisorX = 1.0;

		public override float MinX => minX;

		public override float MaxX => maxX;

		public override void EnsureMinMaxX()
		{
			minX = DebugGraph.MinDisplayTime;
			maxX = DebugGraph.MaxDisplayTime;
			normalizeDivisorX = ((maxX == minX) ? 1.0 : (1.0 / (double)(maxX - minX)));
		}

		protected override void UpdateMinMaxX(float value)
		{
		}

		public override double NormalizeX(float value)
		{
			return (double)(value - minX) * normalizeDivisorX;
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

		public override double ApplyTransformXToRange(float value, float lower, double inverseDivisor)
		{
			return (double)(value - lower) * inverseDivisor;
		}

		protected override float GetDistanceBetweenX(float a, float b)
		{
			return Mathf.Abs(a - b);
		}

		protected override float GetSearchX(float xOffset)
		{
			return MinX + (MaxX - MinX) * xOffset;
		}

		public override float XToFloat(float xValue)
		{
			return xValue;
		}

		public override string XToString(float xValue)
		{
			return xValue.ToString(XValueFormat);
		}

		public override void GetXRange(float zoom, float pan, ref float min, ref float max)
		{
			double num = min;
			double num2 = max;
			double num3 = MaxX - min;
			double num4 = num3 * (double)pan;
			num += num4;
			num2 += num4;
			double num5 = num3 * (double)zoom;
			num += num5;
			num2 -= num5;
			min = (float)num;
			max = (float)num2;
		}

		public override float CalcXAt(float lower, float upper, float offset)
		{
			return lower + (upper - lower) * offset;
		}

		public override void Clear()
		{
			base.Clear();
			minX = 0f;
			maxX = float.MinValue;
			normalizeDivisorX = 1.0;
		}

		public void CleanUpHistory(float beforeTime)
		{
			int count = base.Count;
			for (int i = 1; i < count; i++)
			{
				if (!(base.Second.ValueX < beforeTime))
				{
					break;
				}
				RemoveFirst();
			}
		}
	}
}
