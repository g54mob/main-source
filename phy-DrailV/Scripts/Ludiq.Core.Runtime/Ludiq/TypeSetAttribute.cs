using System;

namespace Ludiq
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class TypeSetAttribute : Attribute
	{
		public TypeSet typeSet { get; }

		public TypeSetAttribute(TypeSet typeSet)
		{
			this.typeSet = typeSet;
		}
	}
}
