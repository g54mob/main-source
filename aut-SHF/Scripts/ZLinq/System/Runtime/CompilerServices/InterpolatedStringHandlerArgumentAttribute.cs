using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices
{
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class InterpolatedStringHandlerArgumentAttribute : Attribute
	{
		public string[] Arguments { get; }

		public InterpolatedStringHandlerArgumentAttribute(string argument)
		{
		}

		public InterpolatedStringHandlerArgumentAttribute(params string[] arguments)
		{
		}
	}
}
