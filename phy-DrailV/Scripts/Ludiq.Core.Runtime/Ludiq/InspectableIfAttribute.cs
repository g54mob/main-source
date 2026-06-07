using System;

namespace Ludiq
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public sealed class InspectableIfAttribute : Attribute, IInspectableAttribute
	{
		public int order { get; set; }

		public string conditionMember { get; }

		public InspectableIfAttribute(string conditionMember)
		{
			this.conditionMember = conditionMember;
		}
	}
}
