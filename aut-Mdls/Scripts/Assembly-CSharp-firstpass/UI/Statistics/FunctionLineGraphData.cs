using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Statistics
{
	public class FunctionLineGraphData : ILineGraphData
	{
		public readonly struct Function
		{
			public readonly Func<float, float> Func;

			public readonly IList<float> XValues;

			public Function(Func<float, float> func, IList<float> xValues)
			{
				Func = func;
				XValues = xValues;
			}
		}

		private readonly IList<Function> _lines;

		IEnumerable<Vector2> ILineGraphData.this[int lineId]
		{
			get
			{
				Function line = _lines[lineId];
				foreach (float xValue in line.XValues)
				{
					yield return new Vector2(xValue, line.Func(xValue));
				}
			}
		}

		int ILineGraphData.LinesCount => _lines.Count;

		public FunctionLineGraphData(params Function[] lines)
		{
			_lines = lines;
		}

		(Vector2 min, Vector2 max) ILineGraphData.GetMinMaxValues()
		{
			IEnumerable<Vector2> enumerable = _lines.SelectMany((Function function, int i) => ((ILineGraphData)this)[i]);
			Vector2 vector = enumerable.First();
			float x = vector.x;
			float num = x;
			float y = vector.y;
			float num2 = y;
			foreach (Vector2 item in enumerable)
			{
				if (x <= item.x)
				{
					x = item.x;
				}
				if (y <= item.y)
				{
					y = item.y;
				}
				if (num >= item.y)
				{
					num = item.x;
				}
				if (num2 >= item.y)
				{
					num2 = item.y;
				}
			}
			return new ValueTuple<Vector2, Vector2>(item2: new Vector2(x, y), item1: new Vector2(num, num2));
		}
	}
}
