using System;

namespace Ludiq
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public sealed class InspectableAttribute : Attribute, IInspectableAttribute
	{
		public int order { get; set; }
	}
}
