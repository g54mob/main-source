using System;

namespace Jundroo.SocialPlatforms.Steam.Events
{
	public class NewLaunchParametersEventArgs : EventArgs
	{
		public string GetParameter(string parameterName)
		{
			return SocialExt.Steam?.GetLaunchQueryParam(parameterName);
		}
	}
}
