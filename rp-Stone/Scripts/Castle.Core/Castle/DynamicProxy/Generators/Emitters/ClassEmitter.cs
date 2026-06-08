using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters
{
	public class ClassEmitter : AbstractTypeEmitter
	{
		internal const TypeAttributes DefaultAttributes = TypeAttributes.Public | TypeAttributes.Serializable;

		private readonly ModuleScope moduleScope;

		public ModuleScope ModuleScope => moduleScope;

		internal bool InStrongNamedModule => base.TypeBuilder.Assembly.IsAssemblySigned();

		public ClassEmitter(ModuleScope modulescope, string name, Type baseType, IEnumerable<Type> interfaces)
			: this(modulescope, name, baseType, interfaces, TypeAttributes.Public | TypeAttributes.Serializable, ShouldForceUnsigned())
		{
		}

		public ClassEmitter(ModuleScope modulescope, string name, Type baseType, IEnumerable<Type> interfaces, TypeAttributes flags)
			: this(modulescope, name, baseType, interfaces, flags, ShouldForceUnsigned())
		{
		}

		public ClassEmitter(ModuleScope modulescope, string name, Type baseType, IEnumerable<Type> interfaces, TypeAttributes flags, bool forceUnsigned)
			: this(CreateTypeBuilder(modulescope, name, baseType, interfaces, flags, forceUnsigned))
		{
			interfaces = InitializeGenericArgumentsFromBases(ref baseType, interfaces);
			if (interfaces != null)
			{
				foreach (Type @interface in interfaces)
				{
					if (@interface.GetTypeInfo().IsInterface)
					{
						base.TypeBuilder.AddInterfaceImplementation(@interface);
					}
				}
			}
			base.TypeBuilder.SetParent(baseType);
			moduleScope = modulescope;
		}

		public ClassEmitter(TypeBuilder typeBuilder)
			: base(typeBuilder)
		{
		}

		protected virtual IEnumerable<Type> InitializeGenericArgumentsFromBases(ref Type baseType, IEnumerable<Type> interfaces)
		{
			if (baseType != null && baseType.GetTypeInfo().IsGenericTypeDefinition)
			{
				throw new NotSupportedException("ClassEmitter does not support open generic base types. Type: " + baseType.FullName);
			}
			if (interfaces == null)
			{
				return interfaces;
			}
			foreach (Type @interface in interfaces)
			{
				if (@interface.GetTypeInfo().IsGenericTypeDefinition)
				{
					throw new NotSupportedException("ClassEmitter does not support open generic interfaces. Type: " + @interface.FullName);
				}
			}
			return interfaces;
		}

		private static TypeBuilder CreateTypeBuilder(ModuleScope modulescope, string name, Type baseType, IEnumerable<Type> interfaces, TypeAttributes flags, bool forceUnsigned)
		{
			bool inSignedModulePreferably = !forceUnsigned && !StrongNameUtil.IsAnyTypeFromUnsignedAssembly(baseType, interfaces);
			return modulescope.DefineType(inSignedModulePreferably, name, flags);
		}

		private static bool ShouldForceUnsigned()
		{
			return !StrongNameUtil.CanStrongNameAssembly;
		}
	}
}
