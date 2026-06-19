#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class ResolutionUtils
	{
		public static Resolution[] SortAndFilterResolutions(Resolution[] resolutions)
		{
			if (resolutions == null || resolutions.Length == 0)
			{
				return null;
			}
			Array.Sort(resolutions, (Resolution a, Resolution b) => -Mathf.Clamp(a.height.CompareTo(b.height), -1, 1) * 4 + -Mathf.Clamp(a.width.CompareTo(b.width), -1, 1) * 2 + -Mathf.Clamp(a.refreshRate.CompareTo(b.refreshRate), -1, 1));
			List<Resolution> list = new List<Resolution>(resolutions.Length);
			list.Add(resolutions[0]);
			for (int num = 1; num < resolutions.Length; num++)
			{
				if (!ResolutionsAreEqual(resolutions[num - 1], resolutions[num]))
				{
					list.Add(resolutions[num]);
				}
			}
			Resolution[] result = new Resolution[1] { list[0] };
			list.RemoveAll((Resolution x) => !ResolutionIsAllowed(x));
			if (list.Count == 0)
			{
				Logging.Warning("No resolutions are above min. spec! Using fail-safe; allowing a disallowed resolution.");
				return result;
			}
			return list.ToArray();
		}

		public static bool ResolutionIsAllowed(Resolution resolution)
		{
			return resolution.height >= 720;
		}

		public static bool ResolutionsAreEqual(Resolution lhs, Resolution rhs)
		{
			if (lhs.width == rhs.width)
			{
				return lhs.height == rhs.height;
			}
			return false;
		}

		public static int CurrentOrClosestResolutionIndex(Resolution[] resolutions)
		{
			Resolution currentResolution = new Resolution
			{
				height = Screen.height,
				width = Screen.width,
				refreshRate = Screen.currentResolution.refreshRate
			};
			return CurrentOrClosestResolutionIndex(resolutions, currentResolution);
		}

		public static int CurrentOrClosestResolutionIndex(Resolution[] resolutions, Resolution currentResolution)
		{
			if (resolutions == null)
			{
				return -1;
			}
			int result = -1;
			int num = int.MaxValue;
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution rhs = resolutions[i];
				if (ResolutionsAreEqual(currentResolution, rhs))
				{
					return i;
				}
				int num2 = Math.Abs(resolutions[i].height - currentResolution.height);
				if (num2 <= num)
				{
					result = i;
					num = num2;
				}
			}
			return result;
		}

		public static int LowerOrEqualResolutionIndex(Resolution[] resolutions, Resolution currentResolution)
		{
			if (resolutions == null)
			{
				return -1;
			}
			int result = -1;
			int num = int.MaxValue;
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution rhs = resolutions[i];
				if (ResolutionsAreEqual(currentResolution, rhs))
				{
					return i;
				}
				if (rhs.height <= currentResolution.height)
				{
					int num2 = Math.Abs(resolutions[i].height - currentResolution.height);
					if (num2 <= num)
					{
						result = i;
						num = num2;
					}
				}
			}
			return result;
		}

		public static KeyValuePair<int, int> AspectRatioOfResolution(int width, int height)
		{
			int num = GreatestCommonDivisor(width, height);
			return new KeyValuePair<int, int>(width / num, height / num);
		}

		public static int GreatestCommonDivisor(int a, int b)
		{
			while (a != 0 && b != 0)
			{
				if (a > b)
				{
					a %= b;
				}
				else
				{
					b %= a;
				}
			}
			if (a != 0)
			{
				return a;
			}
			return b;
		}
	}
}
