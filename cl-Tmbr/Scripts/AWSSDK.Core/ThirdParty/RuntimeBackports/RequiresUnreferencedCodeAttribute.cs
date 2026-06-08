using System;

namespace ThirdParty.RuntimeBackports
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
	public sealed class RequiresUnreferencedCodeAttribute : Attribute
	{
		public string Message { get; }

		public string Url { get; set; }

		public RequiresUnreferencedCodeAttribute(string message)
		{
			Message = message;
		}
	}
}
