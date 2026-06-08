using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal class NestedClassEmitter : AbstractTypeEmitter
	{
		public NestedClassEmitter(AbstractTypeEmitter mainType, string name, Type baseType, Type[] interfaces)
			: this(mainType, CreateTypeBuilder(mainType, name, TypeAttributes.NestedPublic | TypeAttributes.Sealed, baseType, interfaces))
		{
		}

		public NestedClassEmitter(AbstractTypeEmitter mainType, string name, TypeAttributes attributes, Type baseType, Type[] interfaces)
			: this(mainType, CreateTypeBuilder(mainType, name, attributes, baseType, interfaces))
		{
		}

		public NestedClassEmitter(AbstractTypeEmitter mainType, TypeBuilder typeBuilder)
			: base(typeBuilder)
		{
			mainType.AddNestedClass(this);
		}

		private static TypeBuilder CreateTypeBuilder(AbstractTypeEmitter mainType, string name, TypeAttributes attributes, Type baseType, Type[] interfaces)
		{
			return mainType.TypeBuilder.DefineNestedType(name, attributes, baseType, interfaces);
		}
	}
}
