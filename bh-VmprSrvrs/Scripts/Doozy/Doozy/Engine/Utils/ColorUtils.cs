using Doozy.Engine.Utils.ColorModels;
using UnityEngine;

namespace Doozy.Engine.Utils
{
	public static class ColorUtils
	{
		public enum Conversions
		{
			RGB_TO_RGB = 0,
			HEX_TO_RGB = 1,
			RGB_TO_HEX = 2,
			RGB_TO_FGC = 3,
			HSL_TO_RGB = 4,
			RGB_TO_HSL = 5,
			HSV_TO_RGB = 6,
			RGB_TO_HSV = 7,
			CMY_TO_RGB = 8,
			RGB_TO_CMY = 9,
			CMYK_TO_RGB = 10,
			RGB_TO_CMYK = 11,
			XYZ_TO_RGB = 12,
			RGB_TO_XYZ = 13,
			Yxy_TO_RGB = 14,
			RGB_TO_Yxy = 15,
			LAB_TO_RGB = 16,
			RGB_TO_LAB = 17
		}

		public static Vector3 HUEtoRGB(float H)
		{
			return default(Vector3);
		}

		public static RGB HSLtoRGB(HSL values)
		{
			return null;
		}

		public static HSL RGBtoHSL(RGB values)
		{
			return null;
		}

		public static RGB HSVtoRGB(HSV values)
		{
			return null;
		}

		public static HSV RGBtoHSV(RGB values)
		{
			return null;
		}

		public static RGB CMYtoRGB(CMY values)
		{
			return null;
		}

		public static CMY RGBtoCMY(RGB values)
		{
			return null;
		}

		public static RGB CMYKtoRGB(CMYK values)
		{
			return null;
		}

		public static CMYK RGBtoCMYK(RGB values)
		{
			return null;
		}

		public static RGB XYZtoRGB(XYZ values)
		{
			return null;
		}

		public static XYZ RGBtoXYZ(RGB values)
		{
			return null;
		}
	}
}
