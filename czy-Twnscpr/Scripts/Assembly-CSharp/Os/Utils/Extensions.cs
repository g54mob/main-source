using System.Diagnostics;
using UnityEngine;

namespace Os.Utils
{
	public static class Extensions
	{
		public static void SetSingleLayer(this Camera camera, string layerName, bool enabled)
		{
		}

		public static bool KeepGoing(this Stopwatch stopwatch, int milliseconds)
		{
			return false;
		}
	}
}
