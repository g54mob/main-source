using System;
using System.Reflection;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators
{
	internal class OptionallyForwardingMethodGenerator : MethodGenerator
	{
		private readonly GetTargetReferenceDelegate getTargetReference;

		public OptionallyForwardingMethodGenerator(MetaMethod method, OverrideMethodDelegate overrideMethod, GetTargetReferenceDelegate getTargetReference)
			: base(method, overrideMethod)
		{
			this.getTargetReference = getTargetReference;
		}

		protected override MethodEmitter BuildProxiedMethodBody(MethodEmitter emitter, ClassEmitter @class, INamingScope namingScope)
		{
			Reference reference = getTargetReference(@class, base.MethodToOverride);
			emitter.CodeBuilder.AddStatement(new IfNullExpression(reference, IfNull(emitter.ReturnType), IfNotNull(reference)));
			return emitter;
		}

		private IStatement IfNotNull(Reference targetReference)
		{
			BlockStatement blockStatement = new BlockStatement();
			blockStatement.AddStatement(new ReturnStatement(new MethodInvocationExpression(args: ArgumentsUtil.ConvertToArgumentReferenceExpression(base.MethodToOverride.GetParameters()), owner: targetReference, method: base.MethodToOverride)
			{
				VirtualCall = true
			}));
			return blockStatement;
		}

		private IStatement IfNull(Type returnType)
		{
			BlockStatement blockStatement = new BlockStatement();
			InitOutParameters(blockStatement, base.MethodToOverride.GetParameters());
			if (returnType == typeof(void))
			{
				blockStatement.AddStatement(new ReturnStatement());
			}
			else
			{
				blockStatement.AddStatement(new ReturnStatement(new DefaultValueExpression(returnType)));
			}
			return blockStatement;
		}

		private void InitOutParameters(BlockStatement statements, ParameterInfo[] parameters)
		{
			for (int i = 0; i < parameters.Length; i++)
			{
				ParameterInfo parameterInfo = parameters[i];
				if (parameterInfo.IsOut)
				{
					statements.AddStatement(new AssignArgumentStatement(new ArgumentReference(parameterInfo.ParameterType, i + 1), new DefaultValueExpression(parameterInfo.ParameterType)));
				}
			}
		}
	}
}
