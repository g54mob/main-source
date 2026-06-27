using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal class ClassEmitter : AbstractTypeEmitter
	{
		internal const TypeAttributes DefaultAttributes = TypeAttributes.Public | TypeAttributes.Serializable;

		private readonly ModuleScope moduleScope;

		public ModuleScope ModuleScope => moduleScope;

		internal bool InStrongNamedModule => base.TypeBuilder.Assembly.IsAssemblySigned();

		public ClassEmitter(ModuleScope moduleScope, string name, Type baseType, IEnumerable<Type> interfaces)
			: this(moduleScope, name, baseType, interfaces, TypeAttributes.Public | TypeAttributes.Serializable, forceUnsigned: false)
		{
		}

		public ClassEmitter(ModuleScope moduleScope, string name, Type baseType, IEnumerable<Type> interfaces, TypeAttributes flags, bool forceUnsigned)
			: this(CreateTypeBuilder(moduleScope, name, baseType, interfaces, flags, forceUnsigned))
		{
			interfaces = InitializeGenericArgumentsFromBases(ref baseType, interfaces);
			if (interfaces != null)
			{
				foreach (Type @interface in interfaces)
				{
					if (@interface.IsInterface)
					{
						base.TypeBuilder.AddInterfaceImplementation(@interface);
					}
				}
			}
			base.TypeBuilder.SetParent(baseType);
			this.moduleScope = moduleScope;
		}

		public ClassEmitter(TypeBuilder typeBuilder)
			: base(typeBuilder)
		{
		}

		protected virtual IEnumerable<Type> InitializeGenericArgumentsFromBases(ref Type baseType, IEnumerable<Type> interfaces)
		{
			if (baseType != null && baseType.IsGenericTypeDefinition)
			{
				throw new NotSupportedException("ClassEmitter does not support open generic base types. Type: " + baseType.FullName);
			}
			if (interfaces == null)
			{
				return interfaces;
			}
			foreach (Type @interface in interfaces)
			{
				if (@interface.IsGenericTypeDefinition)
				{
					throw new NotSupportedException("ClassEmitter does not support open generic interfaces. Type: " + @interface.FullName);
				}
			}
			return interfaces;
		}

		private static TypeBuilder CreateTypeBuilder(ModuleScope moduleScope, string name, Type baseType, IEnumerable<Type> interfaces, TypeAttributes flags, bool forceUnsigned)
		{
			bool inSignedModulePreferably = !forceUnsigned && !StrongNameUtil.IsAnyTypeFromUnsignedAssembly(baseType, interfaces);
			return moduleScope.DefineType(inSignedModulePreferably, name, flags);
		}
	}
}
