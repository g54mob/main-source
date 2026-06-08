using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Contributors
{
	public class InterfaceProxyWithOptionalTargetContributor : InterfaceProxyWithoutTargetContributor
	{
		private readonly GetTargetReferenceDelegate getTargetReference;

		public InterfaceProxyWithOptionalTargetContributor(INamingScope namingScope, GetTargetExpressionDelegate getTarget, GetTargetReferenceDelegate getTargetReference)
			: base(namingScope, getTarget)
		{
			this.getTargetReference = getTargetReference;
			canChangeTarget = true;
		}

		protected override MethodGenerator GetMethodGenerator(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options, OverrideMethodDelegate overrideMethod)
		{
			if (!method.Proxyable)
			{
				return new OptionallyForwardingMethodGenerator(method, overrideMethod, getTargetReference);
			}
			return base.GetMethodGenerator(method, @class, options, overrideMethod);
		}
	}
}
