using System.Collections.Generic;
using UnityEngine;

namespace DV.WeatherSystem
{
	internal class SnapshotComparer : IComparer<WeatherSnapshot>
	{
		public int Compare(WeatherSnapshot x, WeatherSnapshot y)
		{
			if (x.startTime < y.startTime)
			{
				return -1;
			}
			if (Mathf.Approximately(x.startTime, y.startTime))
			{
				return 0;
			}
			return 1;
		}
	}
}
