using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class EnumConverter
	{
		public static int ToUpdateLoopTypes(UpdateLoopSetting updateLoopSetting, List<UpdateLoopType> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			int num2 = default(int);
			while (true)
			{
				results.Clear();
				EnumNameValueCache<UpdateLoopSetting> enumNameValueCache = EnumNameValueCache<UpdateLoopSetting>.Default;
				int count = enumNameValueCache.Count;
				int num = 1952312101;
				while (true)
				{
					switch (num ^ 0x745DEB23)
					{
					case 5:
						num = 1952312103;
						continue;
					case 1:
						num2++;
						num = 1952312097;
						continue;
					case 3:
					{
						UpdateLoopSetting valueAt = enumNameValueCache.GetValueAt(num2);
						if (valueAt != UpdateLoopSetting.None && (updateLoopSetting & valueAt) != UpdateLoopSetting.None)
						{
							results.Add(EnumNameValueCache<UpdateLoopType>.Default.GetValue(enumNameValueCache.GetName((long)valueAt)));
							num = 1952312098;
							continue;
						}
						goto case 1;
					}
					case 2:
					{
						int num3;
						if (num2 < count)
						{
							num = 1952312096;
							num3 = num;
						}
						else
						{
							num = 1952312099;
							num3 = num;
						}
						continue;
					}
					case 4:
						break;
					case 6:
						num2 = 0;
						num = 1952312097;
						continue;
					default:
						return results.Count;
					}
					break;
				}
			}
		}

		public static AlternateAxisCalibrationType ToAlternateAxisCalibrationType(ThrottleCalibrationMode throttleCalibrationMode)
		{
			while (true)
			{
				switch (-406005767 ^ -406005768)
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
