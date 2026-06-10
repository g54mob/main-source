using System.Collections.Generic;
using Rewired.Config;
using Rewired.Data.Mapping;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EnumConverter
	{
		public static int ToUpdateLoopTypes(UpdateLoopSetting updateLoopSetting, List<UpdateLoopType> results)
		{
			return 0;
		}

		public static AlternateAxisCalibrationType ToAlternateAxisCalibrationType(ThrottleCalibrationMode throttleCalibrationMode)
		{
			return default(AlternateAxisCalibrationType);
		}
	}
}
