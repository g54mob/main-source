using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Statistics
{
	public class SimpleLineGraphData : ILineGraphData
	{
		private readonly IList<IList<Vector2>> _data;

		IEnumerable<Vector2> ILineGraphData.this[int lineId] => _data[lineId];

		int ILineGraphData.LinesCount => _data.Count;

		public SimpleLineGraphData(params IList<Vector2>[] rawData)
		{
			_data = new List<IList<Vector2>>(rawData);
		}

		(Vector2 min, Vector2 max) ILineGraphData.GetMinMaxValues()
		{
			float x = _data[0][0].x;
			float num = x;
			float y = _data[0][0].y;
			float num2 = y;
			foreach (Vector2 item in _data.SelectMany((IList<Vector2> result) => result))
			{
				if (x <= item.x)
				{
					x = item.x;
				}
				if (y <= item.y)
				{
					y = item.y;
				}
				if (num >= item.x)
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
