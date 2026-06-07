using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mystery.Graphing
{
	public static class PlottableGraphEx
	{
		public static void FillVBO<X, Y>(this LineGraph<X, Y> graph, List<UIVertex> vbo) where X : IComparable<X>
		{
			graph.FillVBO(graph.DefaultRangeX, graph.DefaultRangeY, vbo);
		}

		public static void FillVBO<X, Y>(this LineGraph<X, Y> graph, ValueRange<X> rangeX, ValueRange<Y> rangeY, List<UIVertex> vbo) where X : IComparable<X>
		{
			graph.FillVBO(rangeX, rangeY, vbo, 0f, 0f);
		}

		public static void FillVBO<X, Y>(this LineGraph<X, Y> graph, List<UIVertex> vbo, float zoom, float pan) where X : IComparable<X>
		{
			graph.FillVBO(graph.DefaultRangeX, graph.DefaultRangeY, vbo, zoom, pan);
		}

		public static void FillVBO<X, Y>(this LineGraph<X, Y> graph, ValueRange<X> rangeX, ValueRange<Y> rangeY, List<UIVertex> vbo, float zoom, float pan) where X : IComparable<X>
		{
			X min = rangeX.Min;
			X max = rangeX.Max;
			graph.ValueTransformerX.GetRange(zoom, pan, ref min, ref max);
			graph.FillVBO(vbo, min, max, rangeY.Min, rangeY.Max);
		}

		public static void FillVBO<X, Y>(this LineGraph<X, Y> graph, List<UIVertex> vbo, float zoom, float pan, X lowerX, X upperX, Y lowerY, Y upperY) where X : IComparable<X>
		{
			graph.ValueTransformerX.GetRange(zoom, pan, ref lowerX, ref upperX);
			graph.FillVBO(vbo, lowerX, upperX, lowerY, upperY);
		}

		public static void FillVBO<X, Y>(this LineGraph<X, Y> graph, List<UIVertex> vbo, X lowerX, X upperX, Y lowerY, Y upperY) where X : IComparable<X>
		{
			UIVertex simpleVert = UIVertex.simpleVert;
			graph.ValueTransformerX.GetTransformToRangeScale(lowerX, upperX);
			graph.ValueTransformerY.GetTransformToRangeScale(lowerY, upperY);
			bool flag = false;
			float num = 0f;
			float num2 = 0f;
			foreach (LineGraphPoint<X, Y> item in graph)
			{
				if (graph.ValueTransformerX.IsInRange(item.ValueX, lowerX, upperX))
				{
					simpleVert.color = item.Color;
					num = (float)graph.ValueTransformerX.ApplyTransformToRange(item.ValueX, lowerX, 1.0);
					num2 = (float)graph.ValueTransformerY.ApplyTransformToRange(item.ValueY, lowerY, 1.0);
					simpleVert.position = new Vector3(num, num2, 0f);
					if (!flag && graph.JoinPlottedLines)
					{
						vbo.Add(simpleVert);
					}
					simpleVert.position = new Vector3(num, num2, 0f);
					vbo.Add(simpleVert);
					vbo.Add(simpleVert);
					flag = true;
				}
			}
			if (flag && graph.JoinPlottedLines)
			{
				vbo.Add(simpleVert);
			}
		}
	}
}
