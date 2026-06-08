using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators
{
	internal class ForwardingMethodGenerator : MethodGenerator
	{
		private readonly GetTargetReferenceDelegate getTargetReference;

		public ForwardingMethodGenerator(MetaMethod method, OverrideMethodDelegate overrideMethod, GetTargetReferenceDelegate getTargetReference)
			: base(method, overrideMethod)
		{
			this.getTargetReference = getTargetReference;
		}

		protected override MethodEmitter BuildProxiedMethodBody(MethodEmitter emitter, ClassEmitter @class, INamingScope namingScope)
		{
			Reference owner = getTargetReference(@class, base.MethodToOverride);
			IExpression[] args = ArgumentsUtil.ConvertToArgumentReferenceExpression(base.MethodToOverride.GetParameters());
			emitter.CodeBuilder.AddStatement(new ReturnStatement(new MethodInvocationExpression(owner, base.MethodToOverride, args)
			{
				VirtualCall = true
			}));
			return emitter;
		}
	}
}
