using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Mystery.Graphing
{
	public class SingleGraphConsole<X, Y> : SingleGraphConsole where X : IComparable<X> where Y : IComparable<Y>
	{
		public override bool DisplayMidValue => (object)typeof(Y) != typeof(bool);

		public SingleGraphConsole(string name, PlottableGraph<X, Y> graph)
			: base(name, graph)
		{
		}

		public void Push(X valueX, Y valueY, Color color)
		{
			((PlottableGraph<X, Y>)base.Graph).AddPoint(valueX, valueY, color);
		}
	}
	public class SingleGraphConsole : GraphConsole
	{
		public IPlottableGraph Graph { get; protected set; }

		public SingleGraphConsole(string name, IPlottableGraph graph)
			: base(name)
		{
			Graph = graph;
		}

		public override IEnumerator<IPlottableGraph> GetEnumerator()
		{
			yield return Graph;
		}

		public override void PlotGLLines()
		{
			Graph.PlotGLLines(base.Zoom, base.Pan, base.MinLocked ? base.MinLockValue : Graph.MinY, base.MaxLocked ? base.MaxLockValue : Graph.MaxY);
		}

		public override void BuildRTFSampleAt(float x, StringBuilder strBuilder, ref float labelWidth)
		{
			strBuilder.Length = 0;
			Graph.GetYSampleAt(x, out var valueString, out var valueColor);
			strBuilder.AppendFormat("<color=#{0}>{1}</color>", ColorToHex(valueColor), valueString);
			labelWidth = (valueString.Length + 1) * 6;
		}

		public override string GetYMaxString()
		{
			if (!base.MaxLocked)
			{
				return Graph.GetYMaxString();
			}
			return Graph.YToString(base.MaxLockValue);
		}

		public override string GetYMidString()
		{
			return Graph.GetYMidString(base.MinLocked ? base.MinLockValue : Graph.MinY, base.MaxLocked ? base.MaxLockValue : Graph.MaxY);
		}

		public override string GetYMinString()
		{
			if (!base.MinLocked)
			{
				return Graph.GetYMinString();
			}
			return Graph.YToString(base.MinLockValue);
		}

		public override void LockMin()
		{
			LockMin(Graph.MinY);
		}

		public override void LockMax()
		{
			LockMax(Graph.MaxY);
		}

		public override object ParseY(string value, object fallback)
		{
			return Graph.ParseY(value, fallback);
		}
	}
}
