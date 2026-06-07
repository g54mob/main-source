using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mystery.Graphing
{
	public static class PlottableGraphEx
	{
		public static void FillVBO<X, Y>(this PlottableGraph<X, Y> graph, List<UIVertex> vbo) where X : IComparable<X> where Y : IComparable<Y>
		{
			graph.FillVBO(vbo, 0f, 0f);
		}

		public static void FillVBO<X, Y>(this PlottableGraph<X, Y> graph, List<UIVertex> vbo, float zoom, float pan) where X : IComparable<X> where Y : IComparable<Y>
		{
			X min = graph.MinX;
			X max = graph.MaxX;
			graph.GetXRange(zoom, pan, ref min, ref max);
			graph.FillVBO(vbo, min, max, graph.MinY, graph.MaxY);
		}

		public static void FillVBO<X, Y>(this PlottableGraph<X, Y> graph, List<UIVertex> vbo, float zoom, float pan, X lowerX, X upperX, Y lowerY, Y upperY) where X : IComparable<X> where Y : IComparable<Y>
		{
			graph.GetXRange(zoom, pan, ref lowerX, ref upperX);
			graph.FillVBO(vbo, lowerX, upperX, lowerY, upperY);
		}

		public static void FillVBO<X, Y>(this PlottableGraph<X, Y> graph, List<UIVertex> vbo, X lowerX, X upperX, Y lowerY, Y upperY) where X : IComparable<X> where Y : IComparable<Y>
		{
			UIVertex simpleVert = UIVertex.simpleVert;
			graph.EnsureMinMaxX();
			graph.EnsureMinMaxY();
			graph.GetTransformXToRangeScale(lowerX, upperX);
			graph.GetTransformYToRangeScale(lowerY, upperY);
			bool flag = false;
			float num = 0f;
			float num2 = 0f;
			foreach (PlottableGraphPoint<X, Y> item in graph)
			{
				if (graph.IsInXRange(item.ValueX, lowerX, upperX))
				{
					simpleVert.color = item.Color;
					num = (float)graph.ApplyTransformXToRange(item.ValueX, lowerX, 1.0);
					num2 = (float)graph.ApplyTransformYToRange(item.ValueY, lowerY, 1.0);
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
