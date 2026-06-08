using System;
using System.Reflection;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Contributors
{
	internal class InvocationWithDelegateContributor : IInvocationCreationContributor
	{
		private readonly Type delegateType;

		private readonly MetaMethod method;

		private readonly INamingScope namingScope;

		private readonly Type targetType;

		public InvocationWithDelegateContributor(Type delegateType, Type targetType, MetaMethod method, INamingScope namingScope)
		{
			this.delegateType = delegateType;
			this.targetType = targetType;
			this.method = method;
			this.namingScope = namingScope;
		}

		public ConstructorEmitter CreateConstructor(ArgumentReference[] baseCtorArguments, AbstractTypeEmitter invocation)
		{
			ArgumentReference[] arguments = GetArguments(baseCtorArguments);
			ConstructorEmitter constructorEmitter = invocation.CreateConstructor(arguments);
			FieldReference target = invocation.CreateField("delegate", delegateType);
			constructorEmitter.CodeBuilder.AddStatement(new AssignStatement(target, arguments[0]));
			return constructorEmitter;
		}

		public MethodInfo GetCallbackMethod()
		{
			return delegateType.GetMethod("Invoke");
		}

		public MethodInvocationExpression GetCallbackMethodInvocation(AbstractTypeEmitter invocation, IExpression[] args, Reference targetField, MethodEmitter invokeMethodOnTarget)
		{
			IExpression[] allArgs = GetAllArgs(args, targetField);
			return new MethodInvocationExpression(invocation.GetField("delegate"), GetCallbackMethod(), allArgs);
		}

		public IExpression[] GetConstructorInvocationArguments(IExpression[] arguments, ClassEmitter proxy)
		{
			IExpression[] array = new IExpression[arguments.Length + 1];
			array[0] = BuildDelegateToken(proxy);
			Array.Copy(arguments, 0, array, 1, arguments.Length);
			return array;
		}

		private FieldReference BuildDelegateToken(ClassEmitter proxy)
		{
			FieldReference fieldReference = proxy.CreateStaticField(namingScope.GetUniqueName("callback_" + method.Method.Name), delegateType);
			MethodInvocationExpression right = new MethodInvocationExpression(null, DelegateMethods.CreateDelegate, new TypeTokenExpression(delegateType), NullExpression.Instance, new MethodTokenExpression(method.MethodOnTarget));
			AssignStatement statement = new AssignStatement(fieldReference, new ConvertExpression(delegateType, right));
			proxy.ClassConstructor.CodeBuilder.AddStatement(statement);
			return fieldReference;
		}

		private IExpression[] GetAllArgs(IExpression[] args, Reference targetField)
		{
			IExpression[] array = new IExpression[args.Length + 1];
			args.CopyTo(array, 1);
			array[0] = new ConvertExpression(targetType, targetField);
			return array;
		}

		private ArgumentReference[] GetArguments(ArgumentReference[] baseCtorArguments)
		{
			ArgumentReference[] array = new ArgumentReference[baseCtorArguments.Length + 1];
			array[0] = new ArgumentReference(delegateType);
			baseCtorArguments.CopyTo(array, 1);
			return array;
		}
	}
}
