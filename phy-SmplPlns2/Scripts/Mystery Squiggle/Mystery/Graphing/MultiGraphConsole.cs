using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mystery.Graphing
{
	public class MultiGraphConsole<X, Y> : GraphConsole where X : IComparable<X>
	{
		public delegate LineGraph<X, Y> NewGraphDelegate(Type newGraphType);

		private bool useSharedTime = true;

		private NewGraphDelegate NewGraph;

		private List<string> valueNames = new List<string>();

		public Dictionary<Color, IPlottableGraph> Graphs { get; set; }

		public new ValueRange<X> RangeX
		{
			get
			{
				return (ValueRange<X>)base.RangeX;
			}
			set
			{
				base.RangeX = value;
			}
		}

		public new ValueRange<Y> RangeY
		{
			get
			{
				return (ValueRange<Y>)base.RangeY;
			}
			set
			{
				base.RangeY = value;
			}
		}

		public new ValueTransformer<X> TransformerX
		{
			get
			{
				return (ValueTransformer<X>)base.TransformerX;
			}
			set
			{
				base.TransformerX = value;
			}
		}

		public new ValueTransformer<Y> TransformerY
		{
			get
			{
				return (ValueTransformer<Y>)base.TransformerY;
			}
			set
			{
				base.TransformerY = value;
			}
		}

		public override bool DisplayMidValue => (object)typeof(Y) != typeof(bool);

		public void Push(X valueX, Y valueY, Color color, string valueName = null, Type newGraphType = null)
		{
			LineGraph<X, Y> lineGraph;
			if (!Graphs.ContainsKey(color))
			{
				lineGraph = NewGraph(newGraphType);
				if (RangeX == null)
				{
					RangeX = lineGraph.CreateRangeX();
					if (RangeX is ITimeRange)
					{
						((ITimeRange)RangeX).UseSharedTime = useSharedTime;
					}
				}
				if (RangeY == null)
				{
					RangeY = lineGraph.CreateRangeY();
					if (RangeY is ITimeRange)
					{
						((ITimeRange)RangeY).UseSharedTime = useSharedTime;
					}
				}
				TransformerX = lineGraph.ValueTransformerX;
				TransformerY = lineGraph.ValueTransformerY;
				Graphs.Add(color, lineGraph);
				if (base.ValueNames == valueNames)
				{
					int num = 0;
					foreach (LineGraph<X, Y> value in Graphs.Values)
					{
						if (value == lineGraph)
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
				lineGraph = (LineGraph<X, Y>)Graphs[color];
			}
			lineGraph.AddPoint(valueX, valueY, color);
			UpdateValueRange();
		}

		protected override void UpdateValueRange()
		{
			Dictionary<Color, IPlottableGraph>.ValueCollection.Enumerator enumerator = Graphs.Values.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current != null)
				{
					ValueRange<X> valueRange = (ValueRange<X>)enumerator.Current.DefaultRangeX;
					ValueRange<Y> valueRange2 = (ValueRange<Y>)enumerator.Current.DefaultRangeY;
					RangeX.UpdateMin(valueRange.Min);
					RangeX.UpdateMax(valueRange.Max);
					if (!base.MinLocked)
					{
						RangeY.UpdateMin(valueRange2.Min);
					}
					if (!base.MaxLocked)
					{
						RangeY.UpdateMax(valueRange2.Max);
					}
				}
			}
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

		public override void PlotGLLines()
		{
			UpdateValueRange();
			foreach (LineGraph<X, Y> value in Graphs.Values)
			{
				value.PlotGLLines(base.Zoom, base.Pan, RangeX, RangeY);
			}
		}

		public override void GetSamplesAt(float x, List<GraphPointSample> samples)
		{
			UpdateValueRange();
			if (!Graphs.Values.GetEnumerator().MoveNext())
			{
				return;
			}
			X searchX = TransformerX.Lerp(RangeX.Min, RangeX.Max, x);
			IEnumerator<string> enumerator = ((base.ValueNames == null || !GraphConsole.ValueNamesEnabled) ? null : base.ValueNames.GetEnumerator());
			foreach (LineGraph<X, Y> value3 in Graphs.Values)
			{
				if (value3.Count != 0)
				{
					LineGraphPoint<X, Y> value = value3.FindPoint(searchX).Value;
					string value2 = value3.ValueTransformerY.ToString(value.ValueY);
					string label = ((enumerator != null && enumerator.MoveNext() && enumerator.Current != null) ? enumerator.Current : null);
					samples.Add(new GraphPointSample(value3, value.ValueX, value.ValueY, value2, value.Color, label));
				}
			}
		}

		public override void SetUseSharedTime(bool value)
		{
			useSharedTime = value;
			if (RangeX != null && RangeX is TimeRange)
			{
				(RangeX as TimeRange).UseSharedTime = value;
			}
			foreach (IPlottableGraph value2 in Graphs.Values)
			{
				if (value2.DefaultRangeX is TimeRange)
				{
					(value2.DefaultRangeX as TimeRange).UseSharedTime = value;
				}
			}
		}
	}
}
