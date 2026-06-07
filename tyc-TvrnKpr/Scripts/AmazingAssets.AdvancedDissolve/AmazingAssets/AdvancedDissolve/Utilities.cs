using System;
using UnityEngine;

namespace AmazingAssets.AdvancedDissolve
{
	public static class Utilities
	{
		public static class Enum
		{
			public enum RenderPipeline
			{
				Unknown = 0,
				Builtin = 1,
				Universal = 2,
				HighDefinition = 3
			}
		}

		public static bool ShaderIsAdvancedDissolve(Shader shader)
		{
			return false;
		}

		public static Enum.RenderPipeline GetCurrentRenderPipeline()
		{
			return default(Enum.RenderPipeline);
		}

		public static void Log(string message)
		{
		}

		public static void Log(LogType logType, string message)
		{
		}

		public static void Log(LogType logType, string message, Exception exception, UnityEngine.Object context = null)
		{
		}
	}
}
