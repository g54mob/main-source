using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class NewInstanceExpression : IExpression, IExpressionOrStatement
	{
		private readonly IExpression[] arguments;

		private ConstructorInfo constructor;

		public NewInstanceExpression(ConstructorInfo constructor, params IExpression[] args)
		{
			this.constructor = constructor ?? throw new ArgumentNullException("constructor");
			arguments = args;
		}

		public NewInstanceExpression(Type target)
		{
			constructor = target.GetConstructor(Type.EmptyTypes) ?? throw new MissingMethodException("Could not find default constructor.");
			arguments = null;
		}

		public void Emit(ILGenerator gen)
		{
			if (arguments != null)
			{
				IExpression[] array = arguments;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Emit(gen);
				}
			}
			gen.Emit(OpCodes.Newobj, constructor);
		}
	}
}
