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
				goto IL_0003;
			}
			goto IL_0075;
			IL_0003:
			int num = 713945848;
			goto IL_0008;
			IL_0008:
			UpdateLoopSetting valueAt = default(UpdateLoopSetting);
			EnumNameValueCache<UpdateLoopSetting> enumNameValueCache = default(EnumNameValueCache<UpdateLoopSetting>);
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				switch (num ^ 0x2A8DF2FF)
				{
				case 3:
					break;
				case 7:
					throw new ArgumentNullException("results");
				case 1:
					valueAt = enumNameValueCache.GetValueAt(num2);
					num = 713945851;
					continue;
				case 9:
					num2++;
					num = 713945850;
					continue;
				case 0:
					num2 = 0;
					num = 713945850;
					continue;
				case 8:
					goto IL_0075;
				case 4:
					goto IL_0092;
				case 2:
					if ((updateLoopSetting & valueAt) != UpdateLoopSetting.None)
					{
						results.Add(EnumNameValueCache<UpdateLoopType>.Default.GetValue(enumNameValueCache.GetName((long)valueAt)));
						num = 713945846;
						continue;
					}
					goto case 9;
				case 5:
					goto IL_00d0;
				default:
					return results.Count;
				}
				break;
				IL_00d0:
				int num3;
				if (num2 < count)
				{
					num = 713945854;
					num3 = num;
				}
				else
				{
					num = 713945849;
					num3 = num;
				}
				continue;
				IL_0092:
				int num4;
				if (valueAt == UpdateLoopSetting.None)
				{
					num = 713945846;
					num4 = num;
				}
				else
				{
					num = 713945853;
					num4 = num;
				}
			}
			goto IL_0003;
			IL_0075:
			results.Clear();
			enumNameValueCache = EnumNameValueCache<UpdateLoopSetting>.Default;
			count = enumNameValueCache.Count;
			num = 713945855;
			goto IL_0008;
		}

		public static AlternateAxisCalibrationType ToAlternateAxisCalibrationType(ThrottleCalibrationMode throttleCalibrationMode)
		{
			while (true)
			{
				switch (0x2B1A49A9 ^ 0x2B1A49AB)
				{
				case 0:
					continue;
				case 2:
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
