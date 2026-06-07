using System;

namespace MoonSharp.Interpreter.Interop
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event, Inherited = false, AllowMultiple = false)]
	public sealed class MoonSharpVisibleAttribute : Attribute
	{
		public bool Visible { get; private set; }

		public MoonSharpVisibleAttribute(bool visible)
		{
			Visible = visible;
		}
	}
}
