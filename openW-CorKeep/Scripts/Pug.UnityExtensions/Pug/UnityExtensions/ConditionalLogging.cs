using System.Diagnostics;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public static class ConditionalLogging
	{
		[Conditional("PUG_INCLUDE_LOG")]
		public static void Log(string message)
		{
			UnityEngine.Debug.Log(message);
		}
	}
}
