using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class StreamOfflineException : Exception
	{
		public StreamOfflineException(string apiData)
			: base(apiData)
		{
		}
	}
}
