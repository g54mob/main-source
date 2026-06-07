using DV.Common;
using DV.Localization;

namespace DV.UI
{
	public static class SaveTypeExtension
	{
		public static string ToLocalizedString(this SaveType type)
		{
			switch (type)
			{
			case SaveType.Auto:
				return LocalizationAPI.L("savetype/auto");
			case SaveType.Manual:
				return LocalizationAPI.L("savetype/manual");
			case SaveType.Quick:
				return "Quick";
			default:
				return "";
			}
		}
	}
}
