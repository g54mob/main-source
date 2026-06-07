using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Mystery.Graphing
{
	public class MultiGraphConsole<X, Y> : GraphConsole where X : IComparable<X> where Y : IComparable<Y>
	{
		public delegate PlottableGraph<X, Y> NewGraphDelegate(Type newGraphType);

		private NewGraphDelegate NewGraph;

		private List<string> valueNames = new List<string>();

		public Dictionary<Color, IPlottableGraph> Graphs { get; set; }

		public PlottableGraph<X, Y> Last { get; protected set; }

		public X MaxX { get; protected set; }

		public X MinX { get; protected set; }

		public Y MaxY { get; protected set; }

		public Y MidY { get; protected set; }

		public Y MinY { get; protected set; }

		public override bool DisplayMidValue => (object)typeof(Y) != typeof(bool);

		public void Push(X valueX, Y valueY, Color color, string valueName = null, Type newGraphType = null)
		{
			PlottableGraph<X, Y> plottableGraph;
			if (!Graphs.ContainsKey(color))
			{
				plottableGraph = (Last = NewGraph(newGraphType));
				Graphs.Add(color, plottableGraph);
				if (base.ValueNames == valueNames)
				{
					int num = 0;
					foreach (PlottableGraph<X, Y> value in Graphs.Values)
					{
						if (value == plottableGraph)
						{
							valueNames.Insert(num, valueName);
							break;
						}
						num++;
					}
				}
			}
			else
			{
				plottableGraph = (PlottableGraph<X, Y>)Graphs[color];
			}
			plottableGraph.AddPoint(valueX, valueY, color);
			UpdateValueCache();
		}

		public MultiGraphConsole(string name, NewGraphDelegate newGraphDelegate)
			: base(name)
		{
			Graphs = new Dictionary<Color, IPlottableGraph>();
			NewGraph = newGraphDelegate;
			base.ValueNames = valueNames;
		}

		public override IEnumerator<IPlottableGraph> GetEnumerator()
		{
			return Graphs.Values.GetEnumerator();
		}

		public void UpdateValueCache()
		{
			Dictionary<Color, IPlottableGraph>.ValueCollection.Enumerator enumerator = Graphs.Values.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				return;
			}
			MaxX = ((PlottableGraph<X, Y>)enumerator.Current).MaxX;
			MinX = ((PlottableGraph<X, Y>)enumerator.Current).MinX;
			MaxY = ((PlottableGraph<X, Y>)enumerator.Current).MaxY;
			MinY = ((PlottableGraph<X, Y>)enumerator.Current).MinY;
			while (enumerator.MoveNext())
			{
				if (enumerator.Current != null)
				{
					if (((PlottableGraph<X, Y>)enumerator.Current).MaxX.CompareTo(MaxX) > 0)
					{
						MaxX = ((PlottableGraph<X, Y>)enumerator.Current).MaxX;
					}
					if (((PlottableGraph<X, Y>)enumerator.Current).MinX.CompareTo(MinX) < 0)
					{
						MinX = ((PlottableGraph<X, Y>)enumerator.Current).MinX;
					}
					if (((PlottableGraph<X, Y>)enumerator.Current).MaxY.CompareTo(MaxY) > 0)
					{
						MaxY = ((PlottableGraph<X, Y>)enumerator.Current).MaxY;
					}
					if (((PlottableGraph<X, Y>)enumerator.Current).MinY.CompareTo(MinY) < 0)
					{
						MinY = ((PlottableGraph<X, Y>)enumerator.Current).MinY;
					}
				}
			}
			MidY = Last.CalcYAt(MinY, MaxY, 0.5f);
		}

		public override void PlotGLLines()
		{
			if (Application.isPlaying)
			{
				UpdateValueCache();
			}
			Y lowerY = (base.MinLocked ? ((Y)base.MinLockValue) : MinY);
			Y upperY = (base.MaxLocked ? ((Y)base.MaxLockValue) : MaxY);
			foreach (PlottableGraph<X, Y> value in Graphs.Values)
			{
				value.PlotGLLines(base.Zoom, base.Pan, MinX, MaxX, lowerY, upperY);
			}
		}

		public override void BuildRTFSampleAt(float x, StringBuilder strBuilder, ref float labelWidth)
		{
			if (Application.isPlaying)
			{
				UpdateValueCache();
			}
			Dictionary<Color, IPlottableGraph>.ValueCollection.Enumerator enumerator = Graphs.Values.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				return;
			}
			X searchX = ((PlottableGraph<X, Y>)enumerator.Current).CalcXAt(MinX, MaxX, x);
			IEnumerator<string> enumerator2 = ((base.ValueNames == null || !GraphConsole.ValueNamesEnabled) ? null : base.ValueNames.GetEnumerator());
			strBuilder.Length = 0;
			labelWidth = 6f;
			foreach (PlottableGraph<X, Y> value in Graphs.Values)
			{
				if (value.Count != 0)
				{
					PlottableGraphPoint<X, Y> plottableGraphPoint = value.FindPoint(searchX);
					string text = value.YToString(plottableGraphPoint.ValueY);
					Color color = plottableGraphPoint.Color;
					strBuilder.Append("<color=#");
					strBuilder.Append(ColorToHex(color));
					strBuilder.AppendFormat(">");
					if (enumerator2 != null && enumerator2.MoveNext() && enumerator2.Current != null)
					{
						strBuilder.Append(enumerator2.Current);
						strBuilder.Append(": ");
						labelWidth += (enumerator2.Current.Length + 2) * 6;
					}
					strBuilder.AppendFormat(text);
					strBuilder.AppendFormat("</color>  ");
					labelWidth += (text.Length + 2) * 6;
				}
			}
			labelWidth -= 12f;
			strBuilder.Length = Mathf.Clamp(strBuilder.Length - 2, 0, strBuilder.Length);
		}

		public override string GetYMaxString()
		{
			if (base.MaxLocked)
			{
				return Last.YToString(base.MaxLockValue);
			}
			if (Last == null)
			{
				return "-";
			}
			return Last.YToString(MaxY);
		}

		public override string GetYMidString()
		{
			if (Last == null)
			{
				return "-";
			}
			return Last.YToString(Last.GetMidY(base.MinLocked ? ((Y)base.MinLockValue) : MinY, base.MaxLocked ? ((Y)base.MaxLockValue) : MaxY));
		}

		public override string GetYMinString()
		{
			if (base.MinLocked)
			{
				return Last.YToString(base.MinLockValue);
			}
			if (Last == null)
			{
				return "-";
			}
			return Last.YToString(MinY);
		}

		public override void LockMin()
		{
			LockMin(MinY);
		}

		public override void LockMax()
		{
			LockMax(MaxY);
		}

		public override object ParseY(string value, object fallback)
		{
			return Last.ParseY(value, fallback);
		}
	}
}
