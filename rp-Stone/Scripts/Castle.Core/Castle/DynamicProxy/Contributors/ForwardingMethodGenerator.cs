using System.Reflection;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Contributors
{
	public class ForwardingMethodGenerator : MethodGenerator
	{
		private readonly GetTargetReferenceDelegate getTargetReference;

		public ForwardingMethodGenerator(MetaMethod method, OverrideMethodDelegate overrideMethod, GetTargetReferenceDelegate getTargetReference)
			: base(method, overrideMethod)
		{
			this.getTargetReference = getTargetReference;
		}

		protected override MethodEmitter BuildProxiedMethodBody(MethodEmitter emitter, ClassEmitter @class, ProxyGenerationOptions options, INamingScope namingScope)
		{
			Reference owner = getTargetReference(@class, base.MethodToOverride);
			ReferenceExpression[] array = ArgumentsUtil.ConvertToArgumentReferenceExpression(base.MethodToOverride.GetParameters());
			MethodCodeBuilder codeBuilder = emitter.CodeBuilder;
			MethodInfo methodToOverride = base.MethodToOverride;
			Expression[] args = array;
			codeBuilder.AddStatement(new ReturnStatement(new MethodInvocationExpression(owner, methodToOverride, args)
			{
				VirtualCall = true
			}));
			return emitter;
		}
	}
}
