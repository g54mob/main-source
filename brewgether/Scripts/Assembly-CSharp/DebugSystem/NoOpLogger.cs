using UnityEngine;

namespace DebugSystem
{
	public class NoOpLogger : IDebugLogger
	{
		private static NoOpLogger instance;

		public static NoOpLogger Instance => null;

		private NoOpLogger()
		{
		}

		public void Log(string message, Object context = null)
		{
		}

		public void LogWarning(string message, Object context = null)
		{
		}

		public void LogError(string message, Object context = null)
		{
		}

		public void LogFormat(string format, params object[] args)
		{
		}

		public void DrawRay(Vector3 start, Vector3 direction, Color color, float duration = 0f)
		{
		}

		public void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0f)
		{
		}

		public void DrawWireSphere(Vector3 position, float radius, Color color, float duration = 0f)
		{
		}
	}
}
