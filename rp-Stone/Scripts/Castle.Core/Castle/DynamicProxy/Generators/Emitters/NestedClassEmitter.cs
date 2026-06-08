using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters
{
	public class NestedClassEmitter : AbstractTypeEmitter
	{
		public NestedClassEmitter(AbstractTypeEmitter maintype, string name, Type baseType, Type[] interfaces)
			: this(maintype, CreateTypeBuilder(maintype, name, TypeAttributes.NestedPublic | TypeAttributes.Sealed, baseType, interfaces))
		{
		}

		public NestedClassEmitter(AbstractTypeEmitter maintype, string name, TypeAttributes attributes, Type baseType, Type[] interfaces)
			: this(maintype, CreateTypeBuilder(maintype, name, attributes, baseType, interfaces))
		{
		}

		public NestedClassEmitter(AbstractTypeEmitter maintype, TypeBuilder typeBuilder)
			: base(typeBuilder)
		{
			maintype.Nested.Add(this);
		}

		private static TypeBuilder CreateTypeBuilder(AbstractTypeEmitter maintype, string name, TypeAttributes attributes, Type baseType, Type[] interfaces)
		{
			return maintype.TypeBuilder.DefineNestedType(name, attributes, baseType, interfaces);
		}
	}
}
