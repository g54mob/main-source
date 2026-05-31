using System.Collections.Generic;
using UnityEngine;

namespace MyBox
{
	public static class WarningsPool
	{
		private static readonly HashSet<string> Pool;

		public static bool Log(string message, Object target = null)
		{
			return false;
		}

		public static bool LogWarning(string message, Object target = null)
		{
			return false;
		}

		public static bool LogError(string message, Object target = null)
		{
			return false;
		}
	}
}
