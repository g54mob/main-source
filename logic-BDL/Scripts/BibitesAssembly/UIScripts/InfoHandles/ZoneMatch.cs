using SettingScripts;
using UnityEngine;

namespace UIScripts.InfoHandles
{
	public struct ZoneMatch
	{
		public ZoneSettings zone;

		public float overlap;

		public ZoneMatch(ZoneSettings zone, Vector2 pos, Vector2 xAxis, Vector2 yAxis)
		{
			this.zone = zone;
			Vector2 rhs = new Vector2(zone.posX.val, zone.posY.val) - pos;
			float num = ((zone.distribution.val != SpawnDistribution.Rect) ? zone.relativeRadius : ((zone.relativeHeight + zone.relativeWidth) / 2f));
			float num2 = Mathf.Abs(Vector2.Dot(xAxis, rhs) / xAxis.sqrMagnitude);
			float num3 = Mathf.Abs(Vector2.Dot(yAxis, rhs) / yAxis.sqrMagnitude);
			float num4 = num / xAxis.magnitude;
			float num5 = num / yAxis.magnitude;
			overlap = Match(num2, num4) * Match(num3, num5);
			if (num4 > 1f)
			{
				overlap *= Mathf.Exp(num2 * (1f - num4) / (1f + num4 * num4));
			}
			if (num5 > 1f)
			{
				overlap *= Mathf.Exp(num3 * (1f - num5) / (1f + num5 * num5));
			}
		}

		private static float NormalInt(float z)
		{
			return 1f / (1f + Mathf.Exp(-1.67f * z));
		}

		private static float Match(float d, float r)
		{
			return NormalInt(r - d) / NormalInt(r);
		}
	}
}
