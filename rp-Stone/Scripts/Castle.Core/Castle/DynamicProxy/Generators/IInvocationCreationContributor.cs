using System.Reflection;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators
{
	public interface IInvocationCreationContributor
	{
		ConstructorEmitter CreateConstructor(ArgumentReference[] baseCtorArguments, AbstractTypeEmitter invocation);

		MethodInfo GetCallbackMethod();

		MethodInvocationExpression GetCallbackMethodInvocation(AbstractTypeEmitter invocation, Expression[] args, Reference targetField, MethodEmitter invokeMethodOnTarget);

		Expression[] GetConstructorInvocationArguments(Expression[] arguments, ClassEmitter proxy);
	}
}
