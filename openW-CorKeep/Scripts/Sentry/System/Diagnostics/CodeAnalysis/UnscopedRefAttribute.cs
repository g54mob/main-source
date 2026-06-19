namespace System.Diagnostics.CodeAnalysis
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Parameter, Inherited = false)]
	internal sealed class UnscopedRefAttribute : Attribute
	{
	}
}
