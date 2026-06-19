namespace System.Diagnostics.CodeAnalysis
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.Parameter)]
	internal sealed class NotNullWhenAttribute : Attribute
	{
		public bool ReturnValue { get; }

		public NotNullWhenAttribute(bool returnValue)
		{
			ReturnValue = returnValue;
		}
	}
}
