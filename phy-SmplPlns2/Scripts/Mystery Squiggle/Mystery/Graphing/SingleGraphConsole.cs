using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mystery.Graphing
{
	public class SingleGraphConsole<X, Y> : SingleGraphConsole where X : IComparable<X>
	{
		public override bool DisplayMidValue => (object)typeof(Y) != typeof(bool);

		public SingleGraphConsole(string name, LineGraph<X, Y> graph)
			: base(name, graph)
		{
		}

		public void Push(X valueX, Y valueY, Color color)
		{
			((LineGraph<X, Y>)base.Graph).AddPoint(valueX, valueY, color);
			UpdateValueRange();
		}
	}
	public class SingleGraphConsole : GraphConsole
	{
		public IPlottableGraph Graph { get; protected set; }

		public SingleGraphConsole(string name, IPlottableGraph graph)
			: base(name)
		{
			Graph = graph;
			base.RangeX = Graph.CreateRangeX();
			base.RangeY = Graph.CreateRangeY();
			base.TransformerX = Graph.ValueTransformerX;
			base.TransformerY = Graph.ValueTransformerY;
			if (base.RangeX is ITimeRange)
			{
				((ITimeRange)base.RangeX).UseSharedTime = true;
			}
			if (base.RangeY is ITimeRange)
			{
				((ITimeRange)base.RangeY).UseSharedTime = true;
			}
		}

		public override IEnumerator<IPlottableGraph> GetEnumerator()
		{
			yield return Graph;
		}

		public override void PlotGLLines()
		{
			UpdateValueRange();
			Graph.PlotGLLines(base.Zoom, base.Pan, base.RangeX, base.RangeY);
		}

		protected override void UpdateValueRange()
		{
			IValueRange defaultRangeX = Graph.DefaultRangeX;
			IValueRange defaultRangeY = Graph.DefaultRangeY;
			base.RangeX.UpdateMin(defaultRangeX.Min);
			base.RangeX.UpdateMax(defaultRangeX.Max);
			if (!base.MinLocked)
			{
				base.RangeY.UpdateMin(defaultRangeY.Min);
			}
			if (!base.MaxLocked)
			{
				base.RangeY.UpdateMax(defaultRangeY.Max);
			}
		}

		public override void GetSamplesAt(float x, List<GraphPointSample> samples)
		{
			UpdateValueRange();
			GraphPointSample ySampleAt = Graph.GetYSampleAt(base.RangeX, x);
			if (ySampleAt != null)
			{
				IEnumerator<string> enumerator = ((base.ValueNames == null || !GraphConsole.ValueNamesEnabled) ? null : base.ValueNames.GetEnumerator());
				string label = ((enumerator != null && enumerator.MoveNext() && enumerator.Current != null) ? enumerator.Current : null);
				ySampleAt.Label = label;
				samples.Add(ySampleAt);
			}
		}

		public override void SetUseSharedTime(bool value)
		{
			if (base.RangeX is TimeRange)
			{
				(base.RangeX as TimeRange).UseSharedTime = value;
			}
			if (Graph.DefaultRangeX is TimeRange)
			{
				(Graph.DefaultRangeX as TimeRange).UseSharedTime = value;
			}
		}
	}
}
