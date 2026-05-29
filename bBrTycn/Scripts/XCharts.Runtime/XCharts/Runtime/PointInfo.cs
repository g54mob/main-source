using UnityEngine;

namespace XCharts.Runtime
{
	public struct PointInfo
	{
		public Vector3 position;

		public bool isIgnoreBreak;

		public PointInfo(Vector3 pos, bool ignore)
		{
			position = pos;
			isIgnoreBreak = ignore;
		}
	}
}
