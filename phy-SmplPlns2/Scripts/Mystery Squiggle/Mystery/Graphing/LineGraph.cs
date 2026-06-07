using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mystery.Graphing
{
	public abstract class LineGraph<X, Y> : NodeSet<LineGraphPoint<X, Y>>, ILineGraph, IPlottableGraph, IEnumerable<ILineGraphPoint>, IEnumerable, ICollection where X : IComparable<X>
	{
		public abstract ValueTransformer<X> ValueTransformerX { get; }

		public abstract ValueTransformer<Y> ValueTransformerY { get; }

		public ValueRange<X> DefaultRangeX { get; protected set; }

		public ValueRange<Y> DefaultRangeY { get; protected set; }

		IValueTransformer IPlottableGraph.ValueTransformerX => ValueTransformerX;

		IValueTransformer IPlottableGraph.ValueTransformerY => ValueTransformerY;

		IValueRange IPlottableGraph.DefaultRangeX => DefaultRangeX;

		IValueRange IPlottableGraph.DefaultRangeY => DefaultRangeY;

		public virtual bool JoinPlottedLines => true;

		protected virtual int GLPrimitive => 1;

		public LineGraph()
		{
			DefaultRangeX = CreateRangeX();
			DefaultRangeY = CreateRangeY();
		}

		public abstract ValueRange<X> CreateRangeX();

		public abstract ValueRange<Y> CreateRangeY();

		IValueRange IPlottableGraph.CreateRangeX()
		{
			return CreateRangeX();
		}

		IValueRange IPlottableGraph.CreateRangeY()
		{
			return CreateRangeY();
		}

		public override void Clear()
		{
			base.Clear();
			DefaultRangeX.Reset();
			DefaultRangeY.Reset();
		}

		public void ResetBounds()
		{
			DefaultRangeX.Reset();
			DefaultRangeY.Reset();
			using IEnumerator<LineGraphPoint<X, Y>> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				LineGraphPoint<X, Y> current = enumerator.Current;
				DefaultRangeX.UpdateMinMax(current.ValueX);
				DefaultRangeY.UpdateMinMax(current.ValueY);
			}
		}

		public abstract void AddPoint(X valueX, Y valueY, Color color);

		public LineGraphPoint<X, Y>? FindPointAt(ValueRange<X> valueRange, float xOffset)
		{
			if (base.Count == 0)
			{
				return null;
			}
			if (xOffset < 0f)
			{
				return base.First;
			}
			if (xOffset > 1f)
			{
				return base.Last;
			}
			return FindPoint(valueRange.GetSearchValue(ValueTransformerX, xOffset));
		}

		public LineGraphPoint<X, Y>? FindPoint(X searchX)
		{
			if (base.Count == 0)
			{
				return null;
			}
			LineGraphPoint<X, Y> value = base.First;
			X other = ValueTransformerX.GetDistanceBetween(value.ValueX, searchX);
			using (IEnumerator<LineGraphPoint<X, Y>> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					LineGraphPoint<X, Y> current = enumerator.Current;
					X distanceBetween = ValueTransformerX.GetDistanceBetween(current.ValueX, searchX);
					if (distanceBetween.CompareTo(other) < 0)
					{
						value = current;
						other = distanceBetween;
					}
				}
			}
			return value;
		}

		GraphPointSample IPlottableGraph.GetYSampleAt(IValueRange rangeX, float xOffset)
		{
			return GetYSampleAt((ValueRange<X>)rangeX, xOffset);
		}

		public virtual GraphPointSample GetYSampleAt(ValueRange<X> rangeX, float xOffset)
		{
			if (base.Count == 0)
			{
				return null;
			}
			if (xOffset < 0f || xOffset > 1f)
			{
				return new GraphPointSample(this, null, null, "-", Color.black);
			}
			LineGraphPoint<X, Y> value = FindPointAt(rangeX, xOffset).Value;
			return new GraphPointSample(this, value.ValueX, value.ValueY, ValueTransformerY.ToString(value.ValueY), value.Color);
		}

		Vector2 IPlottableGraph.GetTransformedPoint(object valueX, object valueY)
		{
			return GetTransformedPoint((X)valueX, (Y)valueY);
		}

		Vector2 IPlottableGraph.GetTransformedPoint(object valueX, object valueY, float zoom, float pan)
		{
			return GetTransformedPoint((X)valueX, (Y)valueY, zoom, pan);
		}

		Vector2 IPlottableGraph.GetTransformedPoint(object valueX, object valueY, float zoom, float pan, IValueRange rangeX, IValueRange rangeY)
		{
			return GetTransformedPoint((X)valueX, (Y)valueY, zoom, pan, rangeX, rangeY);
		}

		public Vector2 GetTransformedPoint(X valueX, Y valueY)
		{
			return GetTransformedPoint(valueX, valueY, ValueTransformerX, ValueTransformerY);
		}

		public Vector2 GetTransformedPoint(X valueX, Y valueY, float zoom, float pan)
		{
			return GetTransformedPoint(valueX, valueY, ValueTransformerX, ValueTransformerY, zoom, pan);
		}

		public Vector2 GetTransformedPoint(X valueX, Y valueY, float zoom, float pan, IValueRange rangeX, IValueRange rangeY)
		{
			return GetTransformedPoint(valueX, valueY, ValueTransformerX, ValueTransformerY, zoom, pan, (X)rangeX.Min, (X)rangeX.Max, (Y)rangeY.Min, (Y)rangeY.Max);
		}

		public Vector2 GetTransformedPoint(X valueX, Y valueY, float zoom, float pan, X lowerX, X upperX, Y lowerY, Y upperY)
		{
			return GetTransformedPoint(valueX, valueY, ValueTransformerX, ValueTransformerY, zoom, pan, lowerX, upperX, lowerY, upperY);
		}

		public Vector2 GetTransformedPoint(X valueX, Y valueY, X lowerX, X upperX, Y lowerY, Y upperY)
		{
			return GetTransformedPoint(valueX, valueY, ValueTransformerX, ValueTransformerY, lowerX, upperX, lowerY, upperY);
		}

		public Vector2 GetTransformedPoint(X valueX, Y valueY, ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer)
		{
			return GetTransformedPoint(valueX, valueY, xTransformer, yTransformer, 0f, 0f);
		}

		public Vector2 GetTransformedPoint(X valueX, Y valueY, ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer, float zoom, float pan)
		{
			X min = DefaultRangeX.Min;
			X max = DefaultRangeX.Max;
			xTransformer.GetRange(zoom, pan, ref min, ref max);
			return GetTransformedPoint(valueX, valueY, xTransformer, yTransformer, min, max, DefaultRangeY.Min, DefaultRangeY.Max);
		}

		public Vector2 GetTransformedPoint(X valueX, Y valueY, ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer, float zoom, float pan, object minY, object maxY)
		{
			X min = DefaultRangeX.Min;
			X max = DefaultRangeX.Max;
			xTransformer.GetRange(zoom, pan, ref min, ref max);
			return GetTransformedPoint(valueX, valueY, xTransformer, yTransformer, min, max, (Y)minY, (Y)maxY);
		}

		public Vector2 GetTransformedPoint(X valueX, Y valueY, ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer, float zoom, float pan, X lowerX, X upperX, Y lowerY, Y upperY)
		{
			xTransformer.GetRange(zoom, pan, ref lowerX, ref upperX);
			return GetTransformedPoint(valueX, valueY, xTransformer, yTransformer, lowerX, upperX, lowerY, upperY);
		}

		public Vector2 GetTransformedPoint(X valueX, Y valueY, ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer, X lowerX, X upperX, Y lowerY, Y upperY)
		{
			double transformToRangeScale = xTransformer.GetTransformToRangeScale(lowerX, upperX);
			double transformToRangeScale2 = yTransformer.GetTransformToRangeScale(lowerY, upperY);
			return new Vector2((float)xTransformer.ApplyTransformToRange(valueX, lowerX, transformToRangeScale), (float)yTransformer.ApplyTransformToRange(valueY, lowerY, transformToRangeScale2));
		}

		public void PlotGLLines()
		{
			PlotGLLines(ValueTransformerX, ValueTransformerY);
		}

		public void PlotGLLines(float zoom, float pan)
		{
			PlotGLLines(ValueTransformerX, ValueTransformerY, zoom, pan);
		}

		public void PlotGLLines(float zoom, float pan, IValueRange rangeX, IValueRange rangeY)
		{
			PlotGLLines(ValueTransformerX, ValueTransformerY, zoom, pan, (X)rangeX.Min, (X)rangeX.Max, (Y)rangeY.Min, (Y)rangeY.Max);
		}

		public void PlotGLLines(float zoom, float pan, X lowerX, X upperX, Y lowerY, Y upperY)
		{
			PlotGLLines(ValueTransformerX, ValueTransformerY, zoom, pan, lowerX, upperX, lowerY, upperY);
		}

		public void PlotGLLines(X lowerX, X upperX, Y lowerY, Y upperY)
		{
			PlotGLLines(ValueTransformerX, ValueTransformerY, lowerX, upperX, lowerY, upperY);
		}

		public void PlotGLLines(ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer)
		{
			PlotGLLines(xTransformer, yTransformer, 0f, 0f);
		}

		public void PlotGLLines(ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer, float zoom, float pan)
		{
			X min = DefaultRangeX.Min;
			X max = DefaultRangeX.Max;
			xTransformer.GetRange(zoom, pan, ref min, ref max);
			PlotGLLines(xTransformer, yTransformer, min, max, DefaultRangeY.Min, DefaultRangeY.Max);
		}

		public void PlotGLLines(ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer, float zoom, float pan, object minY, object maxY)
		{
			X min = DefaultRangeX.Min;
			X max = DefaultRangeX.Max;
			xTransformer.GetRange(zoom, pan, ref min, ref max);
			PlotGLLines(xTransformer, yTransformer, min, max, (Y)minY, (Y)maxY);
		}

		public void PlotGLLines(ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer, float zoom, float pan, X lowerX, X upperX, Y lowerY, Y upperY)
		{
			xTransformer.GetRange(zoom, pan, ref lowerX, ref upperX);
			PlotGLLines(xTransformer, yTransformer, lowerX, upperX, lowerY, upperY);
		}

		public void PlotGLLines(ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer, X lowerX, X upperX, Y lowerY, Y upperY)
		{
			GL.Begin(GLPrimitive);
			BeginMesh();
			double transformToRangeScale = xTransformer.GetTransformToRangeScale(lowerX, upperX);
			double transformToRangeScale2 = yTransformer.GetTransformToRangeScale(lowerY, upperY);
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
			using (IEnumerator<LineGraphPoint<X, Y>> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					LineGraphPoint<X, Y> current = enumerator.Current;
					num3 = xTransformer.ToFloat(current.ValueX);
					num4 = yTransformer.ToFloat(current.ValueY);
					if (!flag)
					{
						num = num3;
						num2 = num4;
						flag = true;
					}
					if (xTransformer.IsInRange(current.ValueX, lowerX, upperX))
					{
						num5 = (float)xTransformer.ApplyTransformToRange(current.ValueX, lowerX, transformToRangeScale);
						num6 = (float)yTransformer.ApplyTransformToRange(current.ValueY, lowerY, transformToRangeScale2);
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

		protected virtual void BeginMesh()
		{
		}

		protected virtual void PlotGLGraphLine(float transformedPointX, float transformedPointY, float pointX, float pointY, float totalDistanceX, float totalDistanceY)
		{
			GL.Vertex3(transformedPointX, transformedPointY, 0f);
			GL.Vertex3(transformedPointX, transformedPointY, 0f);
		}

		public void PlotGLGrid(X lowerX, X upperX)
		{
			PlotGLGrid(ValueTransformerX, lowerX, upperX);
		}

		public void PlotGLGrid(ValueTransformer<X> transfomer, X lowerX, X upperX)
		{
			GL.Begin(1);
			using (IEnumerator<LineGraphPoint<X, Y>> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					LineGraphPoint<X, Y> current = enumerator.Current;
					if (transfomer.IsInRange(current.ValueX, lowerX, upperX))
					{
						double transformToRangeScale = transfomer.GetTransformToRangeScale(lowerX, upperX);
						PlotGLGridLine((float)transfomer.ApplyTransformToRange(current.ValueX, lowerX, transformToRangeScale));
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

		public Mesh CreateLineMesh(Mesh mesh = null)
		{
			return CreateLineMesh(ValueTransformerX, ValueTransformerY, mesh);
		}

		public Mesh CreateLineMesh(float zoom, float pan, Mesh mesh = null)
		{
			return CreateLineMesh(ValueTransformerX, ValueTransformerY, zoom, pan, mesh);
		}

		public Mesh CreateLineMesh(float zoom, float pan, IValueRange rangeX, IValueRange rangeY, Mesh mesh = null)
		{
			return CreateLineMesh(ValueTransformerX, ValueTransformerY, zoom, pan, (X)rangeX.Min, (X)rangeX.Max, (Y)rangeY.Min, (Y)rangeY.Max, mesh);
		}

		public Mesh CreateLineMesh(float zoom, float pan, X lowerX, X upperX, Y lowerY, Y upperY, Mesh mesh = null)
		{
			return CreateLineMesh(ValueTransformerX, ValueTransformerY, zoom, pan, lowerX, upperX, lowerY, upperY, mesh);
		}

		public Mesh CreateLineMesh(X lowerX, X upperX, Y lowerY, Y upperY, Mesh mesh = null)
		{
			return CreateLineMesh(ValueTransformerX, ValueTransformerY, lowerX, upperX, lowerY, upperY, mesh);
		}

		public Mesh CreateLineMesh(ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer, Mesh mesh = null)
		{
			return CreateLineMesh(xTransformer, yTransformer, 0f, 0f, mesh);
		}

		public Mesh CreateLineMesh(ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer, float zoom, float pan, Mesh mesh = null)
		{
			X min = DefaultRangeX.Min;
			X max = DefaultRangeX.Max;
			xTransformer.GetRange(zoom, pan, ref min, ref max);
			return CreateLineMesh(xTransformer, yTransformer, min, max, DefaultRangeY.Min, DefaultRangeY.Max, mesh);
		}

		public Mesh CreateLineMesh(ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer, float zoom, float pan, object minY, object maxY, Mesh mesh = null)
		{
			X min = DefaultRangeX.Min;
			X max = DefaultRangeX.Max;
			xTransformer.GetRange(zoom, pan, ref min, ref max);
			return CreateLineMesh(xTransformer, yTransformer, min, max, (Y)minY, (Y)maxY, mesh);
		}

		public Mesh CreateLineMesh(ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer, float zoom, float pan, X lowerX, X upperX, Y lowerY, Y upperY, Mesh mesh = null)
		{
			xTransformer.GetRange(zoom, pan, ref lowerX, ref upperX);
			return CreateLineMesh(xTransformer, yTransformer, lowerX, upperX, lowerY, upperY, mesh);
		}

		public Mesh CreateLineMesh(ValueTransformer<X> xTransformer, ValueTransformer<Y> yTransformer, X lowerX, X upperX, Y lowerY, Y upperY, Mesh mesh = null)
		{
			int count = base.Count;
			MeshBuilder meshBuilder = new MeshBuilder(count, normals: false, colors: true, uv1: true, uv2: true, uv3: true);
			BeginMesh();
			double transformToRangeScale = xTransformer.GetTransformToRangeScale(lowerX, upperX);
			double transformToRangeScale2 = yTransformer.GetTransformToRangeScale(lowerY, upperY);
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
			using (IEnumerator<LineGraphPoint<X, Y>> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					LineGraphPoint<X, Y> current = enumerator.Current;
					num3 = xTransformer.ToFloat(current.ValueX);
					num4 = yTransformer.ToFloat(current.ValueY);
					if (!flag)
					{
						num = num3;
						num2 = num4;
						flag = true;
					}
					if (xTransformer.IsInRange(current.ValueX, lowerX, upperX))
					{
						num5 = (float)xTransformer.ApplyTransformToRange(current.ValueX, lowerX, transformToRangeScale);
						num6 = (float)yTransformer.ApplyTransformToRange(current.ValueY, lowerY, transformToRangeScale2);
						meshBuilder.SetColor(current.Color);
						meshBuilder.SetUV1(num3, num4);
						meshBuilder.SetUV2(num7, num8);
						meshBuilder.SetUV3(num5, num6);
						if (!flag2)
						{
							if (JoinPlottedLines)
							{
								meshBuilder.SetVertex(num5, num6, 0f);
								meshBuilder.Push();
							}
							flag2 = true;
						}
						AddPointLineMesh(meshBuilder, num5, num6, num3, num4, num7, num8);
					}
					num7 += Mathf.Abs(num3 - num);
					num8 += Mathf.Abs(num4 - num2);
					num = num3;
					num2 = num4;
				}
			}
			if (flag && JoinPlottedLines)
			{
				meshBuilder.SetVertex(num5, num6, 0f);
				meshBuilder.Push();
			}
			return meshBuilder.Generate(mesh);
		}

		protected virtual void AddPointLineMesh(MeshBuilder meshBuilder, float transformedPointX, float transformedPointY, float pointX, float pointY, float totalDistanceX, float totalDistanceY)
		{
			meshBuilder.SetVertex(transformedPointX, transformedPointY, 0f);
			meshBuilder.Push();
			meshBuilder.SetVertex(transformedPointX, transformedPointY, 0f);
			meshBuilder.Push();
		}

		public ILineGraphPoint[] ExportData()
		{
			ILineGraphPoint[] array = new ILineGraphPoint[base.Count];
			int num = 0;
			using IEnumerator<LineGraphPoint<X, Y>> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				ILineGraphPoint lineGraphPoint = enumerator.Current;
				array[num++] = lineGraphPoint;
			}
			return array;
		}

		IEnumerator<ILineGraphPoint> IEnumerable<ILineGraphPoint>.GetEnumerator()
		{
			using IEnumerator<LineGraphPoint<X, Y>> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				LineGraphPoint<X, Y> current = enumerator.Current;
				yield return current;
			}
		}
	}
}
