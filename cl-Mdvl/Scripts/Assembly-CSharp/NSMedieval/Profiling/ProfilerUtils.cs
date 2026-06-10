using System.IO;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using UnityEngine;
using UnityEngine.Profiling;

namespace NSMedieval.Profiling
{
	public static class ProfilerUtils
	{
		public static void BeginDeepProfileToDisk(string outputFilename)
		{
			Profiler.logFile = Path.Join(Application.persistentDataPath, outputFilename + ".raw");
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(48, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Utils\\ProfilerUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ProfilerUtils: writing deep profiling data to '");
				messageBuilder.AppendFormatted(Profiler.logFile);
				messageBuilder.AppendLiteral("'");
			}
			Log.Info(messageBuilder);
			Profiler.enableBinaryLog = true;
			Profiler.enabled = true;
			Profiler.maxUsedMemory = 268435456;
		}

		public static void EndDeepProfileToDisk()
		{
			Profiler.enabled = false;
			Profiler.logFile = "";
		}
	}
}
