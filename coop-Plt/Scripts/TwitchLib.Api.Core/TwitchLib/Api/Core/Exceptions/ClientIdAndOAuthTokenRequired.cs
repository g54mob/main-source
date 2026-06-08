using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class ClientIdAndOAuthTokenRequired : Exception
	{
		public ClientIdAndOAuthTokenRequired(string explanation)
			: base(explanation)
		{
		}
	}
}
