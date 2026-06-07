using System;
using System.ComponentModel;

namespace Sirenix.Serialization
{
	[AttributeUsage(AttributeTargets.Class)]
	[Obsolete("Use a RegisterFormatterAttribute applied to the containing assembly instead.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CustomFormatterAttribute : Attribute
	{
		public readonly int Priority;

		public CustomFormatterAttribute()
		{
		}

		public CustomFormatterAttribute(int priority = 0)
		{
		}
	}
}
