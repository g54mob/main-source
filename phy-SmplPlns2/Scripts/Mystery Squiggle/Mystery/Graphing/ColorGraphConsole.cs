using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mystery.Graphing
{
	public class ColorGraphConsole<T> : MultiGraphConsole<float, T>
	{
		public ColorGraphConsole(string name, NewGraphDelegate newGraphDelegate)
			: base(name, newGraphDelegate)
		{
		}

		public override void PlotGLLines()
		{
			PlotGLGradient(base.Zoom, base.Pan, base.RangeX.Min, base.RangeX.Max, base.RangeY.Min, base.RangeY.Max);
			foreach (LinearLineGraph<float, T> value in base.Graphs.Values)
			{
				value.PlotGLLines(base.Zoom, base.Pan, base.RangeX.Min, base.RangeX.Max, base.RangeY.Min, base.RangeY.Max);
			}
		}

		private void PlotGLGradient(float zoom, float pan, float lowerX, float upperX, T lowerY, T upperY)
		{
			base.TransformerX.GetRange(zoom, pan, ref lowerX, ref upperX);
			PlotGLGradient(lowerX, upperX, lowerY, upperY);
		}

		private void PlotGLGradient(float lowerX, float upperX, T lowerY, T upperY)
		{
			UpdateValueRange();
			GL.Begin(5);
			double transformToRangeScale = base.TransformerX.GetTransformToRangeScale(lowerX, upperX);
			base.TransformerY.GetTransformToRangeScale(lowerY, upperY);
			IEnumerator<LineGraphPoint<float, T>> enumerator = ((LineGraph<float, T>)base.Graphs[Color.red]).GetEnumerator();
			IEnumerator<LineGraphPoint<float, T>> enumerator2 = ((LineGraph<float, T>)base.Graphs[Color.green]).GetEnumerator();
			IEnumerator<LineGraphPoint<float, T>> enumerator3 = ((LineGraph<float, T>)base.Graphs[Color.blue]).GetEnumerator();
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
				LineGraphPoint<float, T> current = enumerator.Current;
				color = (((object)typeof(T) != typeof(long)) ? new Color(Convert.ToSingle(current.ValueY), Convert.ToSingle(enumerator2.Current.ValueY), Convert.ToSingle(enumerator3.Current.ValueY)) : ((Color)new Color32(Convert.ToByte(current.ValueY), Convert.ToByte(enumerator2.Current.ValueY), Convert.ToByte(enumerator3.Current.ValueY), byte.MaxValue)));
				num = (float)base.TransformerX.ApplyTransformToRange(current.ValueX, lowerX, transformToRangeScale);
				if (!flag)
				{
					c = color;
					flag = true;
				}
				if (!base.TransformerX.IsInRange(current.ValueX, lowerX, upperX))
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
