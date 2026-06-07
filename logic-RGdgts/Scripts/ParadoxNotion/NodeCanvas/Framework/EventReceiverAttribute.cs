using System;

namespace NodeCanvas.Framework
{
	[Obsolete]
	public class EventReceiverAttribute : Attribute
	{
		public readonly string[] eventMessages;

		public EventReceiverAttribute(params string[] args)
		{
		}
	}
}
