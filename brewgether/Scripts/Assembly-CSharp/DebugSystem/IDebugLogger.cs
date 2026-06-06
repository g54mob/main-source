using UnityEngine;

namespace DebugSystem
{
	public interface IDebugLogger
	{
		void Log(string message, Object context = null);

		void LogWarning(string message, Object context = null);

		void LogError(string message, Object context = null);

		void LogFormat(string format, params object[] args);

		void DrawRay(Vector3 start, Vector3 direction, Color color, float duration = 0f);

		void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0f);

		void DrawWireSphere(Vector3 position, float radius, Color color, float duration = 0f);
	}
}
