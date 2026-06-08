using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class NewInstanceExpression : Expression
	{
		private readonly Expression[] arguments;

		private readonly Type[] constructorArgs;

		private readonly Type type;

		private ConstructorInfo constructor;

		public NewInstanceExpression(ConstructorInfo constructor, params Expression[] args)
		{
			this.constructor = constructor;
			arguments = args;
		}

		public NewInstanceExpression(Type target, Type[] constructor_args, params Expression[] args)
		{
			type = target;
			constructorArgs = constructor_args;
			arguments = args;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			Expression[] array = arguments;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Emit(member, gen);
			}
			if (constructor == null)
			{
				constructor = type.GetConstructor(constructorArgs);
			}
			if (constructor == null)
			{
				throw new ProxyGenerationException("Could not find constructor matching specified arguments");
			}
			gen.Emit(OpCodes.Newobj, constructor);
		}
	}
}
