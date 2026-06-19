using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true)]
	public class HelpBoxIfAttribute : Attribute
	{
		public readonly string condition;

		public readonly string message;

		public readonly HelpBoxMessageType type;

		public HelpBoxIfAttribute(string condition, string message)
		{
		}

		public HelpBoxIfAttribute(string condition, string message, HelpBoxMessageType type)
		{
		}
	}
}
