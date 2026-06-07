using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mystery.Graphing
{
	public abstract class PlottableGraph<X, Y> : NodeSet<PlottableGraphPoint<X, Y>>, IPlottableGraph where X : IComparable<X> where Y : IComparable<Y>
	{
		public virtual string XValueFormat => "";

		public virtual string YValueFormat => "";

		public abstract X MinX { get; }

		public abstract X MaxX { get; }

		public abstract Y MinY { get; }

		public abstract Y MaxY { get; }

		public virtual bool JoinPlottedLines => true;

		protected virtual int GLPrimitive => 1;

		object IPlottableGraph.MinY => MinY;

		object IPlottableGraph.MaxY => MaxY;

		public abstract object ParseY(string value, object fallback);

		public X GetMidX()
		{
			return CalcXAt(MinX, MaxX, 0.5f);
		}

		public X GetMidX(X minX, X maxX)
		{
			return CalcXAt(minX, maxX, 0.5f);
		}

		public Y GetMidY()
		{
			return CalcYAt(MinY, MaxY, 0.5f);
		}

		public Y GetMidY(Y minY, Y maxY)
		{
			return CalcYAt(minY, maxY, 0.5f);
		}

		public PlottableGraph()
		{
		}

		public virtual void EnsureMinMaxX()
		{
		}

		public virtual void EnsureMinMaxY()
		{
		}

		protected abstract void UpdateMinMaxX(X value);

		protected abstract void UpdateMinMaxY(Y value);

		public abstract double NormalizeX(X value);

		public abstract double NormalizeY(Y value);

		public abstract void AddPoint(X valueX, Y valueY, Color color);

		public abstract void GetYSampleAt(float xOffset, out string valueString, out Color valueColor);

		public abstract string GetYStringAt(float xOffset);

		public string GetYMinString()
		{
			return YToString(MinY);
		}

		public string GetYMidString(object min, object max)
		{
			return YToString(GetMidY((Y)min, (Y)max));
		}

		public string GetYMidString()
		{
			return YToString(GetMidY());
		}

		public string GetYMaxString()
		{
			return YToString(MaxY);
		}

		public PlottableGraphPoint<X, Y> FindPointAt(float xOffset)
		{
			if (xOffset < 0f)
			{
				return base.First;
			}
			if (xOffset > 1f)
			{
				return base.Last;
			}
			return FindPoint(GetSearchX(xOffset));
		}

		public PlottableGraphPoint<X, Y> FindPoint(X searchX)
		{
			PlottableGraphPoint<X, Y> result = base.First;
			X other = GetDistanceBetweenX(result.ValueX, searchX);
			using IEnumerator<PlottableGraphPoint<X, Y>> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				PlottableGraphPoint<X, Y> current = enumerator.Current;
				X distanceBetweenX = GetDistanceBetweenX(current.ValueX, searchX);
				if (distanceBetweenX.CompareTo(other) < 0)
				{
					result = current;
					other = distanceBetweenX;
				}
			}
			return result;
		}

		public void PlotGLLines()
		{
			PlotGLLines(0f, 0f);
		}

		public void PlotGLLines(float zoom, float pan)
		{
			X min = MinX;
			X max = MaxX;
			GetXRange(zoom, pan, ref min, ref max);
			PlotGLLines(min, max, MinY, MaxY);
		}

		public void PlotGLLines(float zoom, float pan, object minY, object maxY)
		{
			X min = MinX;
			X max = MaxX;
			GetXRange(zoom, pan, ref min, ref max);
			PlotGLLines(min, max, (Y)minY, (Y)maxY);
		}

		public void PlotGLLines(float zoom, float pan, X lowerX, X upperX, Y lowerY, Y upperY)
		{
			GetXRange(zoom, pan, ref lowerX, ref upperX);
			PlotGLLines(lowerX, upperX, lowerY, upperY);
		}

		public void PlotGLLines(X lowerX, X upperX, Y lowerY, Y upperY)
		{
			EnsureMinMaxX();
			EnsureMinMaxY();
			GL.Begin(GLPrimitive);
			double transformXToRangeScale = GetTransformXToRangeScale(lowerX, upperX);
			double transformYToRangeScale = GetTransformYToRangeScale(lowerY, upperY);
			bool flag = false;
			bool flag2 = false;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			using (IEnumerator<PlottableGraphPoint<X, Y>> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PlottableGraphPoint<X, Y> current = enumerator.Current;
					num3 = XToFloat(current.ValueX);
					num4 = YToFloat(current.ValueY);
					if (!flag)
					{
						num = num3;
						num2 = num4;
						flag = true;
					}
					if (IsInXRange(current.ValueX, lowerX, upperX))
					{
						num5 = (float)ApplyTransformXToRange(current.ValueX, lowerX, transformXToRangeScale);
						num6 = (float)ApplyTransformYToRange(current.ValueY, lowerY, transformYToRangeScale);
						GL.Color(current.Color);
						GL.MultiTexCoord2(0, num3, num4);
						GL.MultiTexCoord2(1, num7, num8);
						GL.MultiTexCoord2(2, num5, num6);
						if (!flag2)
						{
							if (JoinPlottedLines)
							{
								GL.Vertex3(num5, num6, 0f);
							}
							flag2 = true;
						}
						PlotGLGraphLine(num5, num6, num3, num4, num7, num8);
					}
					num7 += Mathf.Abs(num3 - num);
					num8 += Mathf.Abs(num4 - num2);
					num = num3;
					num2 = num4;
				}
			}
			if (flag && JoinPlottedLines)
			{
				GL.Vertex3(num5, num6, 0f);
			}
			GL.End();
		}

		protected virtual void PlotGLGraphLine(float transformedPointX, float transformedPointY, float pointX, float pointY, float totalDistanceX, float totalDistanceY)
		{
			GL.Vertex3(transformedPointX, transformedPointY, 0f);
			GL.Vertex3(transformedPointX, transformedPointY, 0f);
		}

		public void PlotGLGrid(X lowerX, X upperX)
		{
			GL.Begin(1);
			using (IEnumerator<PlottableGraphPoint<X, Y>> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PlottableGraphPoint<X, Y> current = enumerator.Current;
					if (IsInXRange(current.ValueX, lowerX, upperX))
					{
						double transformXToRangeScale = GetTransformXToRangeScale(lowerX, upperX);
						PlotGLGridLine((float)ApplyTransformXToRange(current.ValueX, lowerX, transformXToRangeScale));
					}
				}
			}
			GL.End();
		}

		protected void PlotGLGridLine(float x)
		{
			GL.Vertex3(x, 0f, 0f);
			GL.Vertex3(x, 1f, 0f);
		}

		public abstract bool IsInXRange(X value, X lower, X upper);

		public abstract double GetTransformXToRangeScale(X lower, X upper);

		public abstract double GetTransformYToRangeScale(Y lower, Y upper);

		public abstract double ApplyTransformXToRange(X value, X lower, double inverseDivisor);

		public abstract double ApplyTransformYToRange(Y value, Y lower, double inverseDivisor);

		protected abstract X GetDistanceBetweenX(X a, X b);

		protected abstract X GetSearchX(float xOffset);

		public abstract string XToString(X xValue);

		public abstract string YToString(Y yValue);

		public string YToString(object yValue)
		{
			return YToString((Y)yValue);
		}

		public abstract float XToFloat(X xValue);

		public abstract float YToFloat(Y yValue);

		public abstract void GetXRange(float scale, float offset, ref X min, ref X max);

		public abstract void GetYRange(float scale, float offset, ref Y min, ref Y max);

		public abstract X CalcXAt(X a, X b, float offset);

		public abstract Y CalcYAt(Y a, Y b, float offset);

		public IPlottableGraphPoint[] ExportData()
		{
			IPlottableGraphPoint[] array = new IPlottableGraphPoint[base.Count];
			int num = 0;
			using IEnumerator<PlottableGraphPoint<X, Y>> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IPlottableGraphPoint plottableGraphPoint = enumerator.Current;
				array[num++] = plottableGraphPoint;
			}
			return array;
		}
	}
}
