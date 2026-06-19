using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.Parameter)]
	internal sealed class InterpolatedStringHandlerArgumentAttribute : Attribute
	{
		public string[] Arguments { get; }

		public InterpolatedStringHandlerArgumentAttribute(string argument)
		{
			Arguments = new string[1] { argument };
		}

		public InterpolatedStringHandlerArgumentAttribute(params string[] arguments)
		{
			Arguments = arguments;
		}
	}
}
