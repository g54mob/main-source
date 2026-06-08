using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class ThrowStatement : Statement
	{
		private readonly string errorMessage;

		private readonly Type exceptionType;

		public ThrowStatement(Type exceptionType, string errorMessage)
		{
			this.exceptionType = exceptionType;
			this.errorMessage = errorMessage;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			ConstructorInfo constructor = exceptionType.GetConstructor(new Type[1] { typeof(string) });
			ConstReference constReference = new ConstReference(errorMessage);
			new NewInstanceExpression(constructor, constReference.ToExpression()).Emit(member, gen);
			gen.Emit(OpCodes.Throw);
		}
	}
}
