using System.Collections.Generic;
using UnityEngine;

namespace StringExtensionMethods
{
	public static class StringExtensionMethods
	{
		public enum SplitOptions
		{
			BEFORE_DELIMITER = 0,
			AFTER_DELIMITER = 1
		}

		public static string[] SplitAndKeep(this string strTargetString, char[] delims, SplitOptions splSplitOptions = SplitOptions.BEFORE_DELIMITER)
		{
			int num = 0;
			int num2 = 0;
			List<string> list = new List<string>();
			int num3 = 0;
			while ((num2 = strTargetString.IndexOfAny(delims, num)) != -1)
			{
				num3++;
				if (num3 > 9000)
				{
					Debug.LogError("infinite loop detected");
					break;
				}
				if (splSplitOptions == SplitOptions.BEFORE_DELIMITER)
				{
					list.Add(strTargetString.Substring(Mathf.Clamp(num - 1, 0, int.MaxValue), num2 - Mathf.Clamp(num - 1, 0, int.MaxValue)));
					num2++;
				}
				if (splSplitOptions == SplitOptions.AFTER_DELIMITER)
				{
					num2++;
					list.Add(strTargetString.Substring(num, num2 - num));
				}
				int num4 = num;
				num = num2;
				num2 = num4;
			}
			if (splSplitOptions == SplitOptions.BEFORE_DELIMITER)
			{
				list.Add(strTargetString.Substring(Mathf.Clamp(num - 1, 0, int.MaxValue)));
			}
			if (splSplitOptions == SplitOptions.AFTER_DELIMITER)
			{
				list.Add(strTargetString.Substring(num));
			}
			return list.ToArray();
		}
	}
}
