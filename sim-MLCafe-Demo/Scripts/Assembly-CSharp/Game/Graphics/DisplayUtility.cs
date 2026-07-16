using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Graphics
{
	public class DisplayUtility
	{
		public static (int, List<string>) LoadResolutionOptions(int currentWidth, int currentHeight, int monitor)
		{
			Resolution[] resolutions = Screen.resolutions;
			int item = 0;
			List<string> list = new List<string>();
			for (int i = 0; i < resolutions.Length; i++)
			{
				string item2 = Screen.resolutions[i].width + "x" + Screen.resolutions[i].height;
				if (Screen.resolutions[i].width == currentWidth && Screen.resolutions[i].height == currentHeight && Screen.resolutions[i].refreshRateRatio.numerator == Screen.currentResolution.refreshRateRatio.numerator)
				{
					item = i;
				}
				if (!list.Contains(item2))
				{
					list.Add(item2);
				}
			}
			return (item, list);
		}

		public static Resolution GetResolutionByIndex(int index)
		{
			Resolution result = Screen.resolutions[0];
			List<Resolution> list = Screen.resolutions.ToList().FindAll((Resolution x) => x.refreshRateRatio.numerator == Screen.currentResolution.refreshRateRatio.numerator);
			for (int num = 0; num < list.Count; num++)
			{
				if (num == index)
				{
					return new Resolution
					{
						width = list[num].width,
						height = list[num].height,
						refreshRateRatio = Screen.currentResolution.refreshRateRatio
					};
				}
			}
			return result;
		}

		public static int GetMainDisplay()
		{
			return Display.displays.ToList().FindIndex((Display x) => x == Display.main);
		}

		public static Resolution[] GetSupportedDisplayResolutions(int display)
		{
			Resolution[] resolutions = Screen.resolutions;
			List<Resolution> list = new List<Resolution>();
			Resolution[] array = resolutions;
			for (int i = 0; i < array.Length; i++)
			{
				Resolution item = array[i];
				if (item.width == GetDisplayLayout()[display].width && item.height == GetDisplayLayout()[display].height)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		public static List<DisplayInfo> GetDisplayLayout()
		{
			List<DisplayInfo> list = new List<DisplayInfo>();
			Screen.GetDisplayLayout(list);
			return list;
		}

		public static int GetCurrentDisplayIndex()
		{
			List<DisplayInfo> list = new List<DisplayInfo>();
			Screen.GetDisplayLayout(list);
			return list.IndexOf(Screen.mainWindowDisplayInfo);
		}

		public static int GetDisplayCount()
		{
			return Display.displays.Length;
		}
	}
}
