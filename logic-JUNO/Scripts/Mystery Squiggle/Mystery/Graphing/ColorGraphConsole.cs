using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mystery.Graphing
{
	public class ColorGraphConsole<T> : MultiGraphConsole<float, T> where T : IComparable<T>
	{
		public ColorGraphConsole(string name, NewGraphDelegate newGraphDelegate)
			: base(name, newGraphDelegate)
		{
		}

		public override void PlotGLLines()
		{
			T lowerY = (base.MinLocked ? ((T)base.MinLockValue) : base.MinY);
			T upperY = (base.MaxLocked ? ((T)base.MaxLockValue) : base.MaxY);
			PlotGLGradient(base.Zoom, base.Pan, base.MinX, base.MaxX, base.MinY, base.MaxY);
			foreach (LinearPlottableGraph<float, T> value in base.Graphs.Values)
			{
				value.PlotGLLines(base.Zoom, base.Pan, base.MinX, base.MaxX, lowerY, upperY);
			}
		}

		private void PlotGLGradient(float zoom, float pan, float lowerX, float upperX, T lowerY, T upperY)
		{
			base.Last.GetXRange(zoom, pan, ref lowerX, ref upperX);
			PlotGLGradient(lowerX, upperX, lowerY, upperY);
		}

		private void PlotGLGradient(float lowerX, float upperX, T lowerY, T upperY)
		{
			GL.Begin(5);
			double transformXToRangeScale = base.Last.GetTransformXToRangeScale(lowerX, upperX);
			base.Last.GetTransformYToRangeScale(lowerY, upperY);
			IEnumerator<PlottableGraphPoint<float, T>> enumerator = ((PlottableGraph<float, T>)base.Graphs[Color.red]).GetEnumerator();
			IEnumerator<PlottableGraphPoint<float, T>> enumerator2 = ((PlottableGraph<float, T>)base.Graphs[Color.green]).GetEnumerator();
			IEnumerator<PlottableGraphPoint<float, T>> enumerator3 = ((PlottableGraph<float, T>)base.Graphs[Color.blue]).GetEnumerator();
			bool flag = false;
			bool flag2 = false;
			Color color = Color.white;
			float num = 0f;
			Color c = Color.white;
			float x = 0f;
			while (enumerator.MoveNext())
			{
				enumerator2.MoveNext();
				enumerator3.MoveNext();
				PlottableGraphPoint<float, T> current = enumerator.Current;
				color = (((object)typeof(T) != typeof(long)) ? new Color(Convert.ToSingle(current.ValueY), Convert.ToSingle(enumerator2.Current.ValueY), Convert.ToSingle(enumerator3.Current.ValueY)) : ((Color)new Color32(Convert.ToByte(current.ValueY), Convert.ToByte(enumerator2.Current.ValueY), Convert.ToByte(enumerator3.Current.ValueY), byte.MaxValue)));
				num = (float)base.Last.ApplyTransformXToRange(current.ValueX, lowerX, transformXToRangeScale);
				if (!flag)
				{
					c = color;
					flag = true;
				}
				if (!base.Last.IsInXRange(current.ValueX, lowerX, upperX))
				{
					if (flag2)
					{
						GL.Color(color);
						GL.Vertex3(1f, 0f, 0f);
						GL.Vertex3(1f, 1f, 0f);
						break;
					}
				}
				else
				{
					if (!flag2)
					{
						GL.Color(c);
						GL.Vertex3(x, 0f, 0f);
						GL.Vertex3(x, 1f, 0f);
					}
					GL.Color(color);
					GL.Vertex3(num, 0f, 0f);
					GL.Vertex3(num, 1f, 0f);
					flag2 = true;
					x = num;
				}
				c = color;
			}
			GL.End();
		}
	}
}
