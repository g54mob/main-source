using System;
using System.Linq.Expressions;
using Jundroo.Common.Expressions.Exceptions;

namespace Jundroo.Common.Expressions.Tokens
{
	public static class TernaryOperationToken
	{
		public static Token Create(Token operandA, Token operandB, Token operandC)
		{
			if (operandB is Token<string> || operandC is Token<string>)
			{
				return new TernaryOperationToken<string>(operandA, operandB, operandC);
			}
			if (operandB is Token<float> || operandC is Token<float> || operandB is Token<float> || operandC is Token<float>)
			{
				return new TernaryOperationToken<float>(operandA, operandB, operandC);
			}
			if (operandB is Token<bool> && operandC is Token<bool>)
			{
				return new TernaryOperationToken<bool>(operandA, operandB, operandC);
			}
			Type type = operandB.GetType();
			if (!type.IsGenericType)
			{
				type = operandC.GetType();
				if (!type.IsGenericType)
				{
					throw new ExpressionCompileException($"Can't do ternary result: {operandB.GetType()}, {operandC.GetType()}");
				}
			}
			Type type2 = type.GetGenericArguments()[0];
			return (Token)Activator.CreateInstance(typeof(TernaryOperationToken<>).MakeGenericType(type2), operandA, operandB, operandC);
		}
	}
	public class TernaryOperationToken<T> : Token<T>
	{
		private readonly Token _operandA;

		private readonly Token _operandB;

		private readonly Token _operandC;

		public override bool IsFinal => true;

		public TernaryOperationToken(Token operandA, Token operandB, Token operandC)
		{
			_operandA = operandA;
			_operandB = operandB;
			_operandC = operandC;
			Next = operandC.Next;
			Prev = operandA.Prev;
			if (operandC.Next != null)
			{
				operandC.Next.Prev = this;
			}
			if (_operandA.Prev != null)
			{
				operandA.Prev.Next = this;
			}
			operandA.Prev = null;
			operandC.Next = null;
		}

		public override Expression GetExpression(Context context)
		{
			Expression test = Parser.ConvertIfNecessary(_operandA.GetExpression(context), typeof(bool));
			Expression ifTrue = Parser.ConvertIfNecessary(_operandB.GetExpression(context), typeof(T));
			Expression ifFalse = Parser.ConvertIfNecessary(_operandC.GetExpression(context), typeof(T));
			return Expression.Condition(test, ifTrue, ifFalse);
		}

		public override Func<T> GetFunc(Context context)
		{
			Func<bool> condition = _operandA.GetFuncAs<bool>(context);
			Func<T> trueValue = _operandB.GetFuncAs<T>(context);
			Func<T> falseValue = _operandC.GetFuncAs<T>(context);
			return () => (!condition()) ? falseValue() : trueValue();
		}
	}
}
