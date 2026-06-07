using UnityEngine.Scripting;

namespace IngameDebugConsole.Commands
{
	public class TimeCommands
	{
		[ConsoleMethod("time.scale", "Sets the Time.timeScale value", new string[] { })]
		[Preserve]
		public static void SetTimeScale(float value)
		{
		}

		[ConsoleMethod("time.scale", "Returns the current Time.timeScale value", new string[] { })]
		[Preserve]
		public static float GetTimeScale()
		{
			return 0f;
		}
	}
}
