using System.Reflection;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Contributors
{
	public class MinimialisticMethodGenerator : MethodGenerator
	{
		public MinimialisticMethodGenerator(MetaMethod method, OverrideMethodDelegate overrideMethod)
			: base(method, overrideMethod)
		{
		}

		protected override MethodEmitter BuildProxiedMethodBody(MethodEmitter emitter, ClassEmitter @class, ProxyGenerationOptions options, INamingScope namingScope)
		{
			InitOutParameters(emitter, base.MethodToOverride.GetParameters());
			if (emitter.ReturnType == typeof(void))
			{
				emitter.CodeBuilder.AddStatement(new ReturnStatement());
			}
			else
			{
				emitter.CodeBuilder.AddStatement(new ReturnStatement(new DefaultValueExpression(emitter.ReturnType)));
			}
			return emitter;
		}

		private void InitOutParameters(MethodEmitter emitter, ParameterInfo[] parameters)
		{
			for (int i = 0; i < parameters.Length; i++)
			{
				ParameterInfo parameterInfo = parameters[i];
				if (parameterInfo.IsOut)
				{
					emitter.CodeBuilder.AddStatement(new AssignArgumentStatement(new ArgumentReference(parameterInfo.ParameterType, i + 1), new DefaultValueExpression(parameterInfo.ParameterType)));
				}
			}
		}
	}
}
