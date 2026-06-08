using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EnumConverter
	{
		public static int ToUpdateLoopTypes(UpdateLoopSetting updateLoopSetting, List<UpdateLoopType> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			while (true)
			{
				results.Clear();
				EnumNameValueCache<UpdateLoopSetting> enumNameValueCache = EnumNameValueCache<UpdateLoopSetting>.Default;
				int count = enumNameValueCache.Count;
				int num = 0;
				int num2 = -1007473332;
				while (true)
				{
					switch (num2 ^ -1007473329)
					{
					case 2:
						num2 = -1007473330;
						continue;
					case 4:
						num++;
						num2 = -1007473332;
						continue;
					case 0:
					{
						UpdateLoopSetting valueAt = enumNameValueCache.GetValueAt(num);
						if (valueAt != UpdateLoopSetting.None && (updateLoopSetting & valueAt) != UpdateLoopSetting.None)
						{
							results.Add(EnumNameValueCache<UpdateLoopType>.Default.GetValue(enumNameValueCache.GetName((long)valueAt)));
							num2 = -1007473333;
							continue;
						}
						goto case 4;
					}
					case 1:
						break;
					default:
						if (num >= count)
						{
							return results.Count;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public static AlternateAxisCalibrationType ToAlternateAxisCalibrationType(ThrottleCalibrationMode throttleCalibrationMode)
		{
			while (true)
			{
				switch (0x4A41AE8A ^ 0x4A41AE8B)
				{
				case 2:
					continue;
				case 1:
					switch (throttleCalibrationMode)
					{
					case ThrottleCalibrationMode.ZeroToOne:
						break;
					case ThrottleCalibrationMode.NegativeOneToOne:
						return AlternateAxisCalibrationType.ThrottleZeroCenter;
					default:
						throw new NotImplementedException();
					}
					break;
				}
				break;
			}
			return AlternateAxisCalibrationType.Default;
		}
	}
}
