using UnityEngine;

namespace DV
{
	public static class TimeUtil
	{
		public static bool IsFlowing
		{
			get
			{
				if (Time.timeScale > 0f)
				{
					return Time.deltaTime > 0f;
				}
				return false;
			}
		}
	}
}
