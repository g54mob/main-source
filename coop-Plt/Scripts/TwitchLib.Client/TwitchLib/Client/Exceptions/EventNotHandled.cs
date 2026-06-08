using System;

namespace TwitchLib.Client.Exceptions
{
	public class EventNotHandled : Exception
	{
		public EventNotHandled(string eventName, string additionalDetails = "")
			: base(string.IsNullOrEmpty(additionalDetails) ? ("To use this call, you must handle/subscribe to event: " + eventName) : ("To use this call, you must handle/subscribe to event: " + eventName + ", additional details: " + additionalDetails))
		{
		}
	}
}
