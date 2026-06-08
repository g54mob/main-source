using System;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Generators
{
	internal class MethodWithInvocationGenerator : MethodGenerator
	{
		private readonly IInvocationCreationContributor contributor;

		private readonly GetTargetExpressionDelegate getTargetExpression;

		private readonly GetTargetExpressionDelegate getTargetTypeExpression;

		private readonly IExpression interceptors;

		private readonly Type invocation;

		public MethodWithInvocationGenerator(MetaMethod method, IExpression interceptors, Type invocation, GetTargetExpressionDelegate getTargetExpression, OverrideMethodDelegate createMethod, IInvocationCreationContributor contributor)
			: this(method, interceptors, invocation, getTargetExpression, null, createMethod, contributor)
		{
		}

		public MethodWithInvocationGenerator(MetaMethod method, IExpression interceptors, Type invocation, GetTargetExpressionDelegate getTargetExpression, GetTargetExpressionDelegate getTargetTypeExpression, OverrideMethodDelegate createMethod, IInvocationCreationContributor contributor)
			: base(method, createMethod)
		{
			this.invocation = invocation;
			this.getTargetExpression = getTargetExpression;
			this.getTargetTypeExpression = getTargetTypeExpression;
			this.interceptors = interceptors;
			this.contributor = contributor;
		}

		protected FieldReference BuildMethodInterceptorsField(ClassEmitter @class, MethodInfo method, INamingScope namingScope)
		{
			return @class.CreateField(namingScope.GetUniqueName($"interceptors_{method.Name}"), typeof(IInterceptor[]), serializable: false);
		}

		protected override MethodEmitter BuildProxiedMethodBody(MethodEmitter emitter, ClassEmitter @class, INamingScope namingScope)
		{
			Type type = invocation;
			Type[] typeArguments = Type.EmptyTypes;
			ConstructorInfo constructor = invocation.GetConstructors()[0];
			IExpression proxiedMethodTokenExpression;
			if (base.MethodToOverride.IsGenericMethod)
			{
				typeArguments = emitter.MethodBuilder.GetGenericArguments();
				proxiedMethodTokenExpression = new MethodTokenExpression(base.MethodToOverride.MakeGenericMethod(typeArguments));
				if (type.IsGenericTypeDefinition)
				{
					type = type.MakeGenericType(typeArguments);
					constructor = TypeBuilder.GetConstructor(type, constructor);
				}
			}
			else
			{
				FieldReference fieldReference = @class.CreateStaticField(namingScope.GetUniqueName("token_" + base.MethodToOverride.Name), typeof(MethodInfo));
				@class.ClassConstructor.CodeBuilder.AddStatement(new AssignStatement(fieldReference, new MethodTokenExpression(base.MethodToOverride)));
				proxiedMethodTokenExpression = fieldReference;
			}
			IExpression methodInterceptors = SetMethodInterceptors(@class, namingScope, emitter, proxiedMethodTokenExpression);
			TypeReference[] arguments = emitter.Arguments;
			TypeReference[] dereferencedArguments = IndirectReference.WrapIfByRef(arguments);
			bool num = HasByRefArguments(emitter.Arguments);
			IExpression[] ctorArguments = GetCtorArguments(@class, proxiedMethodTokenExpression, dereferencedArguments, methodInterceptors);
			IExpression[] args = ModifyArguments(@class, ctorArguments);
			LocalReference localReference = emitter.CodeBuilder.DeclareLocal(type);
			emitter.CodeBuilder.AddStatement(new AssignStatement(localReference, new NewInstanceExpression(constructor, args)));
			if (base.MethodToOverride.ContainsGenericParameters)
			{
				EmitLoadGenericMethodArguments(emitter, base.MethodToOverride.MakeGenericMethod(typeArguments), localReference);
			}
			if (num)
			{
				emitter.CodeBuilder.AddStatement(new TryStatement());
			}
			MethodInvocationExpression statement = new MethodInvocationExpression(localReference, InvocationMethods.Proceed);
			emitter.CodeBuilder.AddStatement(statement);
			if (num)
			{
				emitter.CodeBuilder.AddStatement(new FinallyStatement());
			}
			GeneratorUtil.CopyOutAndRefParameters(dereferencedArguments, localReference, base.MethodToOverride, emitter);
			if (num)
			{
				emitter.CodeBuilder.AddStatement(new EndExceptionBlockStatement());
			}
			if (base.MethodToOverride.ReturnType != typeof(void))
			{
				MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(localReference, InvocationMethods.GetReturnValue);
				if (emitter.ReturnType.IsValueType && !emitter.ReturnType.IsNullableType())
				{
					LocalReference localReference2 = emitter.CodeBuilder.DeclareLocal(typeof(object));
					emitter.CodeBuilder.AddStatement(new AssignStatement(localReference2, methodInvocationExpression));
					emitter.CodeBuilder.AddStatement(new IfNullExpression(localReference2, new ThrowStatement(typeof(InvalidOperationException), "Interceptors failed to set a return value, or swallowed the exception thrown by the target")));
				}
				emitter.CodeBuilder.AddStatement(new ReturnStatement(new ConvertExpression(emitter.ReturnType, methodInvocationExpression)));
			}
			else
			{
				emitter.CodeBuilder.AddStatement(new ReturnStatement());
			}
			return emitter;
		}

		private IExpression SetMethodInterceptors(ClassEmitter @class, INamingScope namingScope, MethodEmitter emitter, IExpression proxiedMethodTokenExpression)
		{
			FieldReference field = @class.GetField("__selector");
			if (field == null)
			{
				return null;
			}
			FieldReference fieldReference = BuildMethodInterceptorsField(@class, base.MethodToOverride, namingScope);
			IExpression expression = ((getTargetTypeExpression == null) ? new MethodInvocationExpression(null, TypeUtilMethods.GetTypeOrNull, getTargetExpression(@class, base.MethodToOverride)) : getTargetTypeExpression(@class, base.MethodToOverride));
			NewArrayExpression newArrayExpression = new NewArrayExpression(0, typeof(IInterceptor));
			MethodInvocationExpression expression2 = new MethodInvocationExpression(field, InterceptorSelectorMethods.SelectInterceptors, expression, proxiedMethodTokenExpression, interceptors)
			{
				VirtualCall = true
			};
			emitter.CodeBuilder.AddStatement(new IfNullExpression(fieldReference, new AssignStatement(fieldReference, new NullCoalescingOperatorExpression(expression2, newArrayExpression))));
			return fieldReference;
		}

		private void EmitLoadGenericMethodArguments(MethodEmitter methodEmitter, MethodInfo method, Reference invocationLocal)
		{
			Type[] array = Array.FindAll(method.GetGenericArguments(), (Type t) => t.IsGenericParameter);
			LocalReference localReference = methodEmitter.CodeBuilder.DeclareLocal(typeof(Type[]));
			methodEmitter.CodeBuilder.AddStatement(new AssignStatement(localReference, new NewArrayExpression(array.Length, typeof(Type))));
			for (int num = 0; num < array.Length; num++)
			{
				methodEmitter.CodeBuilder.AddStatement(new AssignArrayStatement(localReference, num, new TypeTokenExpression(array[num])));
			}
			methodEmitter.CodeBuilder.AddStatement(new MethodInvocationExpression(invocationLocal, InvocationMethods.SetGenericMethodArguments, localReference));
		}

		private IExpression[] GetCtorArguments(ClassEmitter @class, IExpression proxiedMethodTokenExpression, TypeReference[] dereferencedArguments, IExpression methodInterceptors)
		{
			return new IExpression[5]
			{
				getTargetExpression(@class, base.MethodToOverride),
				SelfReference.Self,
				methodInterceptors ?? interceptors,
				proxiedMethodTokenExpression,
				new ReferencesToObjectArrayExpression(dereferencedArguments)
			};
		}

		private IExpression[] ModifyArguments(ClassEmitter @class, IExpression[] arguments)
		{
			if (contributor == null)
			{
				return arguments;
			}
			return contributor.GetConstructorInvocationArguments(arguments, @class);
		}

		private bool HasByRefArguments(ArgumentReference[] arguments)
		{
			for (int i = 0; i < arguments.Length; i++)
			{
				if (arguments[i].Type.IsByRef)
				{
					return true;
				}
			}
			return false;
		}
	}
}
