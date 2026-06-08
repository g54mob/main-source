using System.Reflection;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Generators
{
	public abstract class MethodGenerator : IGenerator<MethodEmitter>
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

		protected abstract MethodEmitter BuildProxiedMethodBody(MethodEmitter emitter, ClassEmitter @class, ProxyGenerationOptions options, INamingScope namingScope);

		public MethodEmitter Generate(ClassEmitter @class, ProxyGenerationOptions options, INamingScope namingScope)
		{
			MethodEmitter emitter = overrideMethod(method.Name, method.Attributes, MethodToOverride);
			MethodEmitter methodEmitter = BuildProxiedMethodBody(emitter, @class, options, namingScope);
			if (MethodToOverride.DeclaringType.GetTypeInfo().IsInterface)
			{
				@class.TypeBuilder.DefineMethodOverride(methodEmitter.MethodBuilder, MethodToOverride);
			}
			return methodEmitter;
		}
	}
}
