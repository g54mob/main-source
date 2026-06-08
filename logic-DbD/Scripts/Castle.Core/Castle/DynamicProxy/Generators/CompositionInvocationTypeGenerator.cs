using System;
using System.Reflection;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Generators
{
	internal class CompositionInvocationTypeGenerator : InvocationTypeGenerator
	{
		public static readonly Type BaseType = typeof(CompositionInvocation);

		public CompositionInvocationTypeGenerator(Type target, MetaMethod method, MethodInfo callback, bool canChangeTarget, IInvocationCreationContributor contributor)
			: base(target, method, callback, canChangeTarget, contributor)
		{
		}

		protected override ArgumentReference[] GetBaseCtorArguments(Type targetFieldType, out ConstructorInfo baseConstructor)
		{
			baseConstructor = InvocationMethods.CompositionInvocationConstructor;
			return new ArgumentReference[5]
			{
				new ArgumentReference(targetFieldType),
				new ArgumentReference(typeof(object)),
				new ArgumentReference(typeof(IInterceptor[])),
				new ArgumentReference(typeof(MethodInfo)),
				new ArgumentReference(typeof(object[]))
			};
		}

		protected override Type GetBaseType()
		{
			return BaseType;
		}

		protected override FieldReference GetTargetReference()
		{
			return new FieldReference(InvocationMethods.CompositionInvocationTarget);
		}

		protected override void ImplementInvokeMethodOnTarget(AbstractTypeEmitter invocation, ParameterInfo[] parameters, MethodEmitter invokeMethodOnTarget, Reference targetField)
		{
			invokeMethodOnTarget.CodeBuilder.AddStatement(new MethodInvocationExpression(SelfReference.Self, InvocationMethods.CompositionInvocationEnsureValidTarget));
			base.ImplementInvokeMethodOnTarget(invocation, parameters, invokeMethodOnTarget, targetField);
		}
	}
}
