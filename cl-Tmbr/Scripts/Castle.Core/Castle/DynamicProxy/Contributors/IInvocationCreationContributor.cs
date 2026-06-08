using System.Reflection;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Contributors
{
	internal interface IInvocationCreationContributor
	{
		ConstructorEmitter CreateConstructor(ArgumentReference[] baseCtorArguments, AbstractTypeEmitter invocation);

		MethodInfo GetCallbackMethod();

		MethodInvocationExpression GetCallbackMethodInvocation(AbstractTypeEmitter invocation, IExpression[] args, Reference targetField, MethodEmitter invokeMethodOnTarget);

		IExpression[] GetConstructorInvocationArguments(IExpression[] arguments, ClassEmitter proxy);
	}
}
