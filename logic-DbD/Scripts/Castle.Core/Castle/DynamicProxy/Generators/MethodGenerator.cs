using System.Reflection;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Generators
{
	internal abstract class MethodGenerator : IGenerator<MethodEmitter>
	{
		private readonly MetaMethod method;

		private readonly OverrideMethodDelegate overrideMethod;

		protected MethodInfo MethodOnTarget => method.MethodOnTarget;

		protected MethodInfo MethodToOverride => method.Method;

		protected MethodGenerator(MetaMethod method, OverrideMethodDelegate overrideMethod)
		{
			this.method = method;
			this.overrideMethod = overrideMethod;
		}

		protected abstract MethodEmitter BuildProxiedMethodBody(MethodEmitter emitter, ClassEmitter @class, INamingScope namingScope);

		public MethodEmitter Generate(ClassEmitter @class, INamingScope namingScope)
		{
			MethodEmitter emitter = overrideMethod(method.Name, method.Attributes, MethodToOverride);
			MethodEmitter methodEmitter = BuildProxiedMethodBody(emitter, @class, namingScope);
			if (MethodToOverride.DeclaringType.IsInterface)
			{
				@class.TypeBuilder.DefineMethodOverride(methodEmitter.MethodBuilder, MethodToOverride);
			}
			return methodEmitter;
		}
	}
}
