using System;

namespace Oculus.Platform.Models
{
	public class CalApplicationSuggestion
	{
		public readonly ulong ID;

		public readonly string SocialContext;

		public CalApplicationSuggestion(IntPtr o)
		{
			ID = CAPI.ovr_CalApplicationSuggestion_GetID(o);
			SocialContext = CAPI.ovr_CalApplicationSuggestion_GetSocialContext(o);
		}
	}
}
