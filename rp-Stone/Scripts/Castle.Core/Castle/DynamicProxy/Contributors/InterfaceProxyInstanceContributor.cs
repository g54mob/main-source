using System;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Contributors
{
	public class InterfaceProxyInstanceContributor : ProxyInstanceContributor
	{
		protected override Reference GetTargetReference(ClassEmitter emitter)
		{
			return emitter.GetField("__target");
		}

		public InterfaceProxyInstanceContributor(Type targetType, string proxyGeneratorId, Type[] interfaces)
			: base(targetType, interfaces, proxyGeneratorId)
		{
		}

		protected override void CustomizeGetObjectData(AbstractCodeBuilder codebuilder, ArgumentReference serializationInfo, ArgumentReference streamingContext, ClassEmitter emitter)
		{
			FieldReference field = emitter.GetField("__target");
			codebuilder.AddStatement(new ExpressionStatement(new MethodInvocationExpression(serializationInfo, SerializationInfoMethods.AddValue_Object, new ConstReference("__targetFieldType").ToExpression(), new ConstReference(field.Reference.FieldType.AssemblyQualifiedName).ToExpression())));
			codebuilder.AddStatement(new ExpressionStatement(new MethodInvocationExpression(serializationInfo, SerializationInfoMethods.AddValue_Object, new ConstReference("__theInterface").ToExpression(), new ConstReference(targetType.AssemblyQualifiedName).ToExpression())));
		}
	}
}
