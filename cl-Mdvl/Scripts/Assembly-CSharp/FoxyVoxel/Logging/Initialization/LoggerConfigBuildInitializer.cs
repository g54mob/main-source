using System;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using UnityEngine;

namespace FoxyVoxel.Logging.Initialization
{
	public class LoggerConfigBuildInitializer : MonoBehaviour
	{
		private void Awake()
		{
			try
			{
				Debug.Log("Loading logging system config (mode: PRODUCTION BUILD)");
				LoggerConfigFileUtil.LoadFromProductionConfig();
				Debug.Log("Successfully loaded logging system config");
			}
			catch (Exception arg)
			{
				Debug.LogError($"Failed to load logging system configuration: {arg}");
			}
			Debug.Log("Logging system minimum log level is " + FVLogger.Config.MinimumLevel);
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(9, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\FoxyVoxel\\Logging\\Initialization\\LoggerConfigBuildInitializer.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("DateTime ");
				messageBuilder.AppendFormatted(DateTime.Now);
			}
			Log.Info(messageBuilder);
			messageBuilder = new FVLogInfoInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\FoxyVoxel\\Logging\\Initialization\\LoggerConfigBuildInitializer.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Game version is ");
				messageBuilder.AppendFormatted(Application.version);
			}
			Log.Info(messageBuilder);
		}
	}
}
