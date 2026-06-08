using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class NotPartneredException : Exception
	{
		public NotPartneredException(string apiData)
			: base(apiData)
		{
		}
	}
}
