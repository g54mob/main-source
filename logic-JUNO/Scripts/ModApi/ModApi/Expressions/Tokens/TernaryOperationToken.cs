using System;
using System.Linq.Expressions;
using ModApi.Expressions.Exceptions;

namespace ModApi.Expressions.Tokens
{
	internal static class TernaryOperationToken
	{
		public static Token Create(Token selector, Token ifTrue, Token ifFalse)
		{
			if (ifTrue is Token<string> || ifFalse is Token<string>)
			{
				return new TernaryOperationToken<string>(selector, ifTrue, ifFalse);
			}
			if (ifTrue is Token<double> || ifFalse is Token<double> || ifTrue is Token<float> || ifFalse is Token<float>)
			{
				return new TernaryOperationToken<double>(selector, ifTrue, ifFalse);
			}
			if (ifTrue is Token<bool> && ifFalse is Token<bool>)
			{
				return new TernaryOperationToken<bool>(selector, ifTrue, ifFalse);
			}
			Type type = ifTrue.Type ?? ifFalse.Type;
			if (type == null)
			{
				throw new ExpressionCompileException($"Can't do ternary result: {ifTrue.GetType()}, {ifFalse.GetType()}");
			}
			return (Token)Activator.CreateInstance(typeof(TernaryOperationToken<>).MakeGenericType(type), selector, ifTrue, ifFalse);
		}
	}
	internal class TernaryOperationToken<T> : Token<T>
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

		public override Expression GetExpression(Context context, ParameterExpression dataSlots)
		{
			Expression test = Parser.ConvertIfNecessary(_operandA.GetExpression(context, dataSlots), typeof(bool));
			Expression expression = _operandB.GetExpression(context, dataSlots);
			Expression ifFalse = Parser.ConvertIfNecessary(_operandC.GetExpression(context, dataSlots), expression.Type);
			return Expression.Condition(test, expression, ifFalse);
		}

		public override Func<double[], T> GetFunc(Context context)
		{
			Func<double[], bool> condition = _operandA.GetFuncAs<bool>(context);
			Func<double[], T> trueValue = _operandB.GetFuncAs<T>(context);
			Func<double[], T> falseValue = _operandC.GetFuncAs<T>(context);
			return (double[] d) => (!condition(d)) ? falseValue(d) : trueValue(d);
		}
	}
}
