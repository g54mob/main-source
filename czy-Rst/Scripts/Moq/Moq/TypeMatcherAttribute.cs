using System;

namespace Moq
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = true)]
	public class TypeMatcherAttribute : Attribute
	{
		private readonly Type type;

		internal Type Type => type;

		public TypeMatcherAttribute()
		{
			type = null;
		}

		public TypeMatcherAttribute(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.type = type;
		}
	}
}
