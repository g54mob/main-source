using System;
using JetBrains.Annotations;

namespace DevCmdLine
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class DevCmdVerifyAttribute : Attribute
	{
		public readonly string regexPattern;

		public DevCmdVerifyAttribute([RegexPattern] string regexPattern)
		{
			this.regexPattern = regexPattern;
		}
	}
}
