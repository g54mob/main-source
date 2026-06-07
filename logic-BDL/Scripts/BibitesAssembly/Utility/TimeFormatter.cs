using System;

namespace Utility
{
	public static class TimeFormatter
	{
		public static TimeFormat TimeOfPointInSerialConfig(this LogLikeConfig config, int point)
		{
			int num = config.acquisitionFactor;
			int num2 = 0;
			int num3 = point + 1;
			LogLikeFormat[] formats = config.formats;
			for (int i = 0; i < formats.Length; i++)
			{
				int num4 = ((config.lastBucketIsInfinite && i == formats.Length - 1) ? int.MaxValue : formats[i].size);
				if (num3 > num4)
				{
					num2 += num * num4;
					num3 -= num4;
					num *= formats[i].feedRatio;
					continue;
				}
				num2 += num * num3;
				break;
			}
			return new TimeFormat(num2, config.acquisition);
		}

		public static TimeFormat TimeFormatOfParallelLogLikeScale(this LogLikeConfig config, int scale, int value)
		{
			int num = config.acquisitionFactor;
			LogLikeFormat[] formats = config.formats;
			if (scale >= formats.Length)
			{
				throw new IndexOutOfRangeException();
			}
			for (int i = 0; i < scale; i++)
			{
				num *= formats[i].feedRatio;
			}
			return new TimeFormat(num * value, config.acquisition);
		}
	}
}
