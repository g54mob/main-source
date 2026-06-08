#define TRACE
using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Xml.Serialization;
using Castle.Core.Internal;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Generators
{
	public class MethodWithInvocationGenerator : MethodGenerator
	{
		private readonly IInvocationCreationContributor contributor;

		private readonly GetTargetExpressionDelegate getTargetExpression;

		private readonly GetTargetExpressionDelegate getTargetTypeExpression;

		private readonly Reference interceptors;

		private readonly Type invocation;

		public MethodWithInvocationGenerator(MetaMethod method, Reference interceptors, Type invocation, GetTargetExpressionDelegate getTargetExpression, OverrideMethodDelegate createMethod, IInvocationCreationContributor contributor)
			: this(method, interceptors, invocation, getTargetExpression, null, createMethod, contributor)
		{
		}

		public MethodWithInvocationGenerator(MetaMethod method, Reference interceptors, Type invocation, GetTargetExpressionDelegate getTargetExpression, GetTargetExpressionDelegate getTargetTypeExpression, OverrideMethodDelegate createMethod, IInvocationCreationContributor contributor)
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
			FieldReference fieldReference = @class.CreateField(namingScope.GetUniqueName($"interceptors_{method.Name}"), typeof(IInterceptor[]), serializable: false);
			@class.DefineCustomAttributeFor<XmlIgnoreAttribute>(fieldReference);
			return fieldReference;
		}

		protected override MethodEmitter BuildProxiedMethodBody(MethodEmitter emitter, ClassEmitter @class, ProxyGenerationOptions options, INamingScope namingScope)
		{
			Type type = invocation;
			Trace.Assert(base.MethodToOverride.IsGenericMethod == type.GetTypeInfo().IsGenericTypeDefinition);
			Type[] typeArguments = Type.EmptyTypes;
			ConstructorInfo constructor = invocation.GetConstructors()[0];
			Expression proxiedMethodTokenExpression;
			if (base.MethodToOverride.IsGenericMethod)
			{
				typeArguments = emitter.MethodBuilder.GetGenericArguments();
				type = type.MakeGenericType(typeArguments);
				constructor = TypeBuilder.GetConstructor(type, constructor);
				proxiedMethodTokenExpression = new MethodTokenExpression(base.MethodToOverride.MakeGenericMethod(typeArguments));
			}
			else
			{
				FieldReference fieldReference = @class.CreateStaticField(namingScope.GetUniqueName("token_" + base.MethodToOverride.Name), typeof(MethodInfo));
				@class.ClassConstructor.CodeBuilder.AddStatement(new AssignStatement(fieldReference, new MethodTokenExpression(base.MethodToOverride)));
				proxiedMethodTokenExpression = fieldReference.ToExpression();
			}
			Expression methodInterceptors = SetMethodInterceptors(@class, namingScope, emitter, proxiedMethodTokenExpression);
			TypeReference[] arguments = emitter.Arguments;
			TypeReference[] dereferencedArguments = IndirectReference.WrapIfByRef(arguments);
			bool flag = HasByRefArguments(emitter.Arguments);
			Expression[] ctorArguments = GetCtorArguments(@class, proxiedMethodTokenExpression, dereferencedArguments, methodInterceptors);
			Expression[] args = ModifyArguments(@class, ctorArguments);
			LocalReference localReference = emitter.CodeBuilder.DeclareLocal(type);
			emitter.CodeBuilder.AddStatement(new AssignStatement(localReference, new NewInstanceExpression(constructor, args)));
			if (base.MethodToOverride.ContainsGenericParameters)
			{
				EmitLoadGenricMethodArguments(emitter, base.MethodToOverride.MakeGenericMethod(typeArguments), localReference);
			}
			if (flag)
			{
				emitter.CodeBuilder.AddStatement(new TryStatement());
			}
			ExpressionStatement stmt = new ExpressionStatement(new MethodInvocationExpression(localReference, InvocationMethods.Proceed));
			emitter.CodeBuilder.AddStatement(stmt);
			if (flag)
			{
				emitter.CodeBuilder.AddStatement(new FinallyStatement());
			}
			GeneratorUtil.CopyOutAndRefParameters(dereferencedArguments, localReference, base.MethodToOverride, emitter);
			if (flag)
			{
				emitter.CodeBuilder.AddStatement(new EndExceptionBlockStatement());
			}
			if (base.MethodToOverride.ReturnType != typeof(void))
			{
				MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(localReference, InvocationMethods.GetReturnValue);
				if (emitter.ReturnType.GetTypeInfo().IsValueType && !emitter.ReturnType.IsNullableType())
				{
					LocalReference localReference2 = emitter.CodeBuilder.DeclareLocal(typeof(object));
					emitter.CodeBuilder.AddStatement(new AssignStatement(localReference2, methodInvocationExpression));
					emitter.CodeBuilder.AddExpression(new IfNullExpression(localReference2, new ThrowStatement(typeof(InvalidOperationException), "Interceptors failed to set a return value, or swallowed the exception thrown by the target")));
				}
				emitter.CodeBuilder.AddStatement(new ReturnStatement(new ConvertExpression(emitter.ReturnType, methodInvocationExpression)));
			}
			else
			{
				emitter.CodeBuilder.AddStatement(new ReturnStatement());
			}
			return emitter;
		}

		private Expression SetMethodInterceptors(ClassEmitter @class, INamingScope namingScope, MethodEmitter emitter, Expression proxiedMethodTokenExpression)
		{
			FieldReference field = @class.GetField("__selector");
			if (field == null)
			{
				return null;
			}
			FieldReference fieldReference = BuildMethodInterceptorsField(@class, base.MethodToOverride, namingScope);
			Expression expression = ((getTargetTypeExpression == null) ? new MethodInvocationExpression(null, TypeUtilMethods.GetTypeOrNull, getTargetExpression(@class, base.MethodToOverride)) : getTargetTypeExpression(@class, base.MethodToOverride));
			NewArrayExpression newArrayExpression = new NewArrayExpression(0, typeof(IInterceptor));
			MethodInvocationExpression expression2 = new MethodInvocationExpression(field, InterceptorSelectorMethods.SelectInterceptors, expression, proxiedMethodTokenExpression, interceptors.ToExpression())
			{
				VirtualCall = true
			};
			emitter.CodeBuilder.AddExpression(new IfNullExpression(fieldReference, new AssignStatement(fieldReference, new NullCoalescingOperatorExpression(expression2, newArrayExpression))));
			return fieldReference.ToExpression();
		}

		private void EmitLoadGenricMethodArguments(MethodEmitter methodEmitter, MethodInfo method, Reference invocationLocal)
		{
			Type[] array = method.GetGenericArguments().FindAll((Type t) => t.GetTypeInfo().IsGenericParameter);
			LocalReference localReference = methodEmitter.CodeBuilder.DeclareLocal(typeof(Type[]));
			methodEmitter.CodeBuilder.AddStatement(new AssignStatement(localReference, new NewArrayExpression(array.Length, typeof(Type))));
			for (int num = 0; num < array.Length; num++)
			{
				methodEmitter.CodeBuilder.AddStatement(new AssignArrayStatement(localReference, num, new TypeTokenExpression(array[num])));
			}
			methodEmitter.CodeBuilder.AddExpression(new MethodInvocationExpression(invocationLocal, InvocationMethods.SetGenericMethodArguments, new ReferenceExpression(localReference)));
		}

		private Expression[] GetCtorArguments(ClassEmitter @class, Expression proxiedMethodTokenExpression, TypeReference[] dereferencedArguments, Expression methodInterceptors)
		{
			return new Expression[5]
			{
				getTargetExpression(@class, base.MethodToOverride),
				SelfReference.Self.ToExpression(),
				methodInterceptors ?? interceptors.ToExpression(),
				proxiedMethodTokenExpression,
				new ReferencesToObjectArrayExpression(dereferencedArguments)
			};
		}

		private Expression[] ModifyArguments(ClassEmitter @class, Expression[] arguments)
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
				if (arguments[i].Type.GetTypeInfo().IsByRef)
				{
					return true;
				}
			}
			return false;
		}
	}
}
