using System;
using System.Reflection;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Contributors
{
	public class OptionallyForwardingMethodGenerator : MethodGenerator
	{
		private readonly GetTargetReferenceDelegate getTargetReference;

		public OptionallyForwardingMethodGenerator(MetaMethod method, OverrideMethodDelegate overrideMethod, GetTargetReferenceDelegate getTargetReference)
			: base(method, overrideMethod)
		{
			this.getTargetReference = getTargetReference;
		}

		protected override MethodEmitter BuildProxiedMethodBody(MethodEmitter emitter, ClassEmitter @class, ProxyGenerationOptions options, INamingScope namingScope)
		{
			Reference reference = getTargetReference(@class, base.MethodToOverride);
			emitter.CodeBuilder.AddStatement(new ExpressionStatement(new IfNullExpression(reference, IfNull(emitter.ReturnType), IfNotNull(reference))));
			return emitter;
		}

		private Expression IfNotNull(Reference targetReference)
		{
			MultiStatementExpression multiStatementExpression = new MultiStatementExpression();
			ReferenceExpression[] array = ArgumentsUtil.ConvertToArgumentReferenceExpression(base.MethodToOverride.GetParameters());
			MethodInfo methodToOverride = base.MethodToOverride;
			Expression[] args = array;
			multiStatementExpression.AddStatement(new ReturnStatement(new MethodInvocationExpression(targetReference, methodToOverride, args)
			{
				VirtualCall = true
			}));
			return multiStatementExpression;
		}

		private Expression IfNull(Type returnType)
		{
			MultiStatementExpression multiStatementExpression = new MultiStatementExpression();
			InitOutParameters(multiStatementExpression, base.MethodToOverride.GetParameters());
			if (returnType == typeof(void))
			{
				multiStatementExpression.AddStatement(new ReturnStatement());
			}
			else
			{
				multiStatementExpression.AddStatement(new ReturnStatement(new DefaultValueExpression(returnType)));
			}
			return multiStatementExpression;
		}

		private void InitOutParameters(MultiStatementExpression expression, ParameterInfo[] parameters)
		{
			for (int i = 0; i < parameters.Length; i++)
			{
				ParameterInfo parameterInfo = parameters[i];
				if (parameterInfo.IsOut)
				{
					expression.AddStatement(new AssignArgumentStatement(new ArgumentReference(parameterInfo.ParameterType, i + 1), new DefaultValueExpression(parameterInfo.ParameterType)));
				}
			}
		}
	}
}
