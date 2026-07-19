using Crosstales.Common.Util;

namespace Crosstales.FB.Util
{
	public abstract class Helper : BaseHelper
	{
		public static bool isSupportedPlatform
		{
			get
			{
				if (!BaseHelper.isWindowsPlatform && !BaseHelper.isMacOSPlatform && !BaseHelper.isLinuxPlatform)
				{
					return BaseHelper.isWSAPlatform;
				}
				return true;
			}
		}
	}
}
