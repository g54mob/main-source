using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true)]
	public class HelpBoxAttribute : Attribute
	{
		public readonly string message;

		public readonly HelpBoxMessageType type;

		public HelpBoxAttribute(string message)
		{
		}

		public HelpBoxAttribute(string message, HelpBoxMessageType type)
		{
		}
	}
}
