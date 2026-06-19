namespace System.Diagnostics.CodeAnalysis
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
	internal sealed class DisallowNullAttribute : Attribute
	{
	}
}
