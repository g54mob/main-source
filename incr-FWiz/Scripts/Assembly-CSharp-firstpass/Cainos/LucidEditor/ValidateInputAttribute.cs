using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Field)]
	public class ValidateInputAttribute : Attribute
	{
		public readonly string condition;

		public readonly string message;

		public readonly HelpBoxMessageType type;

		public ValidateInputAttribute(string condition)
		{
		}

		public ValidateInputAttribute(string condition, string message)
		{
		}

		public ValidateInputAttribute(string condition, string message, HelpBoxMessageType type)
		{
		}
	}
}
