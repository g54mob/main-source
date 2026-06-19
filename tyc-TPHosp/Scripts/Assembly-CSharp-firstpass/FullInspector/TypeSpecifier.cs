using System;

namespace FullInspector
{
	public class TypeSpecifier<TBaseType>
	{
		public Type Type;

		public TypeSpecifier()
		{
		}

		public TypeSpecifier(Type type)
		{
			Type = type;
		}

		public static implicit operator Type(TypeSpecifier<TBaseType> specifier)
		{
			return specifier.Type;
		}

		public static implicit operator TypeSpecifier<TBaseType>(Type type)
		{
			return new TypeSpecifier<TBaseType>
			{
				Type = type
			};
		}

		public override bool Equals(object obj)
		{
			if (obj is TypeSpecifier<TBaseType> typeSpecifier)
			{
				return Type == typeSpecifier.Type;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Type.GetHashCode();
		}
	}
}
