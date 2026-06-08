using System;

namespace TwitchLib.Client.Exceptions
{
	public class BadListenException : Exception
	{
		public BadListenException(string eventName, string additionalDetails = "")
			: base(string.IsNullOrEmpty(additionalDetails) ? ("You are listening to event '" + eventName + "', which is not currently allowed. See details: " + additionalDetails) : ("You are listening to event '" + eventName + "', which is not currently allowed."))
		{
		}
	}
}
