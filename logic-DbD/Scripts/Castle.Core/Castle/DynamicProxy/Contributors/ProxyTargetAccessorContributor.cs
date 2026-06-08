using System;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Contributors
{
	internal sealed class ProxyTargetAccessorContributor : ITypeContributor
	{
		private readonly Func<Reference> getTargetReference;

		private readonly Type targetType;

		public ProxyTargetAccessorContributor(Func<Reference> getTargetReference, Type targetType)
		{
			this.getTargetReference = getTargetReference;
			this.targetType = targetType;
		}

		public void CollectElementsToProxy(IProxyGenerationHook hook, MetaType model)
		{
		}

		public void Generate(ClassEmitter emitter)
		{
			FieldReference field = emitter.GetField("__interceptors");
			Reference reference = getTargetReference();
			emitter.CreateMethod("DynProxyGetTarget", typeof(object)).CodeBuilder.AddStatement(new ReturnStatement(new ConvertExpression(typeof(object), targetType, reference)));
			MethodEmitter methodEmitter = emitter.CreateMethod("DynProxySetTarget", typeof(void), typeof(object));
			if (reference is FieldReference fieldReference)
			{
				methodEmitter.CodeBuilder.AddStatement(new AssignStatement(fieldReference, new ConvertExpression(fieldReference.FieldBuilder.FieldType, methodEmitter.Arguments[0])));
			}
			else
			{
				methodEmitter.CodeBuilder.AddStatement(new ThrowStatement(typeof(InvalidOperationException), "Cannot change the target of the class proxy."));
			}
			methodEmitter.CodeBuilder.AddStatement(new ReturnStatement());
			emitter.CreateMethod("GetInterceptors", typeof(IInterceptor[])).CodeBuilder.AddStatement(new ReturnStatement(field));
		}
	}
}
