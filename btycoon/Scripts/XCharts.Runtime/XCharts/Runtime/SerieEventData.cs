using UnityEngine;

namespace XCharts.Runtime
{
	public class SerieEventData
	{
		public Vector3 pointerPos { get; set; }

		public int serieIndex { get; set; }

		public int dataIndex { get; set; }

		public int dimension { get; set; }

		public double value { get; set; }

		public void Reset()
		{
			serieIndex = -1;
			dataIndex = -1;
			dimension = -1;
			value = 0.0;
			pointerPos = Vector3.zero;
		}
	}
}
