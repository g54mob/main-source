using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mystery.Graphing
{
	public static class GraphConsoleEx
	{
		public static void FillVBO<X, Y>(this SingleGraphConsole<X, Y> console, List<UIVertex> vbo) where X : IComparable<X> where Y : IComparable<Y>
		{
			((PlottableGraph<X, Y>)console.Graph).FillVBO(vbo, console.Zoom, console.Pan);
		}

		public static void FillVBO(this StringGraphConsole console, List<UIVertex> vbo)
		{
			((StringLinearPlottableGraph)console.Graph).FillVBO(vbo, console.Zoom, console.Pan);
		}

		public static void FillVBO<X, Y>(this MultiGraphConsole<X, Y> console, List<UIVertex> vbo) where X : IComparable<X> where Y : IComparable<Y>
		{
			if (Application.isPlaying)
			{
				console.UpdateValueCache();
			}
			foreach (PlottableGraph<X, Y> value in console.Graphs.Values)
			{
				value.FillVBO(vbo, console.Zoom, console.Pan, console.MinX, console.MaxX, console.MinY, console.MaxY);
			}
		}

		public static void FillVBO<T>(this ColorGraphConsole<T> console, List<UIVertex> vbo) where T : IComparable<T>
		{
			console.FillVBO(vbo, console.Zoom, console.Pan, console.MinX, console.MaxX, console.MinY, console.MaxY);
			foreach (LinearPlottableGraph<float, T> value in console.Graphs.Values)
			{
				value.FillVBO(vbo, console.Zoom, console.Pan, console.MinX, console.MaxX, console.MinY, console.MaxY);
			}
		}

		private static void FillVBO<T>(this ColorGraphConsole<T> console, List<UIVertex> vbo, float zoom, float pan, float lowerX, float upperX, T lowerY, T upperY) where T : IComparable<T>
		{
			console.Last.GetXRange(zoom, pan, ref lowerX, ref upperX);
			console.FillVBO(vbo, lowerX, upperX, lowerY, upperY);
		}

		private static void FillVBO<T>(this ColorGraphConsole<T> console, List<UIVertex> vbo, float lowerX, float upperX, T lowerY, T upperY) where T : IComparable<T>
		{
		}
	}
}
