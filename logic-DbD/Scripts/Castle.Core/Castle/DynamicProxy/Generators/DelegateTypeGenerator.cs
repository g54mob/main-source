using System;
using System.Reflection;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators
{
	internal class DelegateTypeGenerator : IGenerator<AbstractTypeEmitter>
	{
		private const TypeAttributes DelegateFlags = TypeAttributes.Public | TypeAttributes.Sealed | TypeAttributes.AutoClass;

		private readonly MetaMethod method;

		private readonly Type targetType;

		public DelegateTypeGenerator(MetaMethod method, Type targetType)
		{
			this.method = method;
			this.targetType = targetType;
		}

		public AbstractTypeEmitter Generate(ClassEmitter @class, INamingScope namingScope)
		{
			AbstractTypeEmitter emitter = GetEmitter(@class, namingScope);
			BuildConstructor(emitter);
			BuildInvokeMethod(emitter);
			return emitter;
		}

		private void BuildConstructor(AbstractTypeEmitter emitter)
		{
			emitter.CreateConstructor(new ArgumentReference(typeof(object)), new ArgumentReference(typeof(IntPtr))).ConstructorBuilder.SetImplementationFlags(MethodImplAttributes.CodeTypeMask);
		}

		private void BuildInvokeMethod(AbstractTypeEmitter @delegate)
		{
			Type[] paramTypes = GetParamTypes(@delegate);
			@delegate.CreateMethod("Invoke", MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask, @delegate.GetClosedParameterType(method.MethodOnTarget.ReturnType), paramTypes).MethodBuilder.SetImplementationFlags(MethodImplAttributes.CodeTypeMask);
		}

		private AbstractTypeEmitter GetEmitter(ClassEmitter @class, INamingScope namingScope)
		{
			MethodInfo methodOnTarget = method.MethodOnTarget;
			string suggestedName = $"Castle.Proxies.Delegates.{methodOnTarget.DeclaringType.Name}_{method.Method.Name}";
			string uniqueName = namingScope.ParentScope.GetUniqueName(suggestedName);
			ClassEmitter classEmitter = new ClassEmitter(@class.ModuleScope, uniqueName, typeof(MulticastDelegate), Type.EmptyTypes, TypeAttributes.Public | TypeAttributes.Sealed | TypeAttributes.AutoClass, !@class.InStrongNamedModule);
			classEmitter.CopyGenericParametersFromMethod(method.Method);
			return classEmitter;
		}

		private Type[] GetParamTypes(AbstractTypeEmitter @delegate)
		{
			ParameterInfo[] parameters = method.MethodOnTarget.GetParameters();
			if (@delegate.TypeBuilder.IsGenericType)
			{
				Type[] array = new Type[parameters.Length];
				for (int i = 0; i < parameters.Length; i++)
				{
					array[i] = @delegate.GetClosedParameterType(parameters[i].ParameterType);
				}
				return array;
			}
			Type[] array2 = new Type[parameters.Length + 1];
			array2[0] = targetType;
			for (int j = 0; j < parameters.Length; j++)
			{
				array2[j + 1] = @delegate.GetClosedParameterType(parameters[j].ParameterType);
			}
			return array2;
		}
	}
}
