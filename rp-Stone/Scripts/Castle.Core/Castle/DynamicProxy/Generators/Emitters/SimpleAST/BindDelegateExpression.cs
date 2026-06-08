using System;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class BindDelegateExpression : Expression
	{
		private readonly ConstructorInfo delegateCtor;

		private readonly MethodInfo methodToBindTo;

		private readonly Expression owner;

		public BindDelegateExpression(Type @delegate, Expression owner, MethodInfo methodToBindTo, GenericTypeParameterBuilder[] genericTypeParams)
		{
			delegateCtor = @delegate.GetConstructors()[0];
			this.methodToBindTo = methodToBindTo;
			if (@delegate.GetTypeInfo().IsGenericTypeDefinition)
			{
				Type[] typeArguments = genericTypeParams.AsTypeArray();
				Type type = @delegate.MakeGenericType(typeArguments);
				delegateCtor = TypeBuilder.GetConstructor(type, delegateCtor);
				this.methodToBindTo = methodToBindTo.MakeGenericMethod(typeArguments);
			}
			this.owner = owner;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			owner.Emit(member, gen);
			gen.Emit(OpCodes.Dup);
			if (methodToBindTo.IsFinal)
			{
				gen.Emit(OpCodes.Ldftn, methodToBindTo);
			}
			else
			{
				gen.Emit(OpCodes.Ldvirtftn, methodToBindTo);
			}
			gen.Emit(OpCodes.Newobj, delegateCtor);
		}
	}
}
