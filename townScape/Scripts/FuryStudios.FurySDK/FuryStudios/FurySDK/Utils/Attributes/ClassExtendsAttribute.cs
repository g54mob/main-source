using System;

namespace FuryStudios.FurySDK.Utils.Attributes
{
	public sealed class ClassExtendsAttribute : ClassTypeConstraintAttribute
	{
		public Type BaseType { get; private set; }

		public ClassExtendsAttribute()
		{
		}

		public ClassExtendsAttribute(Type baseType)
		{
		}

		public override bool IsConstraintSatisfied(Type type)
		{
			return false;
		}
	}
}
