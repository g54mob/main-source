using System;
using System.Linq.Expressions;
using Jundroo.Common.Expressions.Exceptions;

namespace Jundroo.Common.Expressions.Tokens
{
	public static class UnaryOperationToken
	{
		public static Token Create(OperatorToken left, Token right)
		{
			return left.Op switch
			{
				Operator.Not => new UnaryOperationToken<bool>(left, right), 
				Operator.Minus => new UnaryOperationToken<float>(left, right), 
				_ => throw new ExpressionCompileException($"Unary operator not supported: {left.Op}"), 
			};
		}
	}
	public class UnaryOperationToken<T> : Token<T>
	{
		private readonly Operator _op;

		private readonly Token _operand;

		public override bool IsFinal => _operand.IsFinal;

		public UnaryOperationToken(OperatorToken left, Token right)
		{
			if (left.Prev != null)
			{
				left.Prev.Next = this;
			}
			if (right.Next != null)
			{
				right.Next.Prev = this;
			}
			Next = right.Next;
			Prev = left.Prev;
			_op = left.Op;
			_operand = right;
		}

		public override Expression GetExpression(Context context)
		{
			if (!IsFinal)
			{
				throw new ExpressionCompileException("Unary not final");
			}
			Expression expression = _operand.GetExpression(context);
			if (_op == Operator.Minus)
			{
				return Expression.MakeUnary(ExpressionType.Negate, Parser.ConvertIfNecessary(expression, typeof(float)), typeof(float));
			}
			if (_op == Operator.Not)
			{
				return Expression.Not(Parser.ConvertIfNecessary(expression, typeof(bool)));
			}
			throw new ExpressionCompileException("Unary operator not supported: " + _op.ToString() + expression.Type);
		}

		public override Func<T> GetFunc(Context context)
		{
			if (_op == Operator.Minus)
			{
				Func<float> operand = _operand.GetFuncAs<float>(context);
				if ((Func<float>)(() => 0f - operand()) is Func<T> result)
				{
					return result;
				}
			}
			else if (_op == Operator.Not)
			{
				Func<bool> operand2 = _operand.GetFuncAs<bool>(context);
				if ((Func<bool>)(() => !operand2()) is Func<T> result2)
				{
					return result2;
				}
			}
			throw new ExpressionCompileException($"Failed to build unary operation: {_op} : {typeof(T).Name}");
		}

		public override string ToString()
		{
			return _op.ToString() + _operand.ToString();
		}
	}
}
