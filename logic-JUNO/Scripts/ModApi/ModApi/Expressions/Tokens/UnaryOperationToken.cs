using System;
using System.Linq.Expressions;
using ModApi.Expressions.Exceptions;
using UnityEngine;

namespace ModApi.Expressions.Tokens
{
	internal static class UnaryOperationToken
	{
		public static Token Create(OperatorToken left, Token right)
		{
			switch (left.Op)
			{
			case Operator.Not:
				return new UnaryOperationToken<bool>(left, right);
			case Operator.Minus:
				if (right is Token<Vector3d>)
				{
					return new UnaryOperationToken<Vector3d>(left, right);
				}
				return new UnaryOperationToken<double>(left, right);
			default:
				throw new ExpressionCompileException($"Unary operator not supported: {left.Op}");
			}
		}
	}
	internal class UnaryOperationToken<T> : Token<T>
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

		public override Expression GetExpression(Context context, ParameterExpression dataSlots)
		{
			if (!IsFinal)
			{
				throw new ExpressionCompileException("Unary not final");
			}
			Expression expression = _operand.GetExpression(context, dataSlots);
			if (_op == Operator.Minus)
			{
				if (this is Token<double>)
				{
					return Expression.MakeUnary(ExpressionType.Negate, Parser.ConvertIfNecessary(expression, typeof(double)), typeof(double));
				}
				return Expression.MakeUnary(ExpressionType.Negate, expression, typeof(Vector3d));
			}
			if (_op == Operator.Not)
			{
				return Expression.Not(Parser.ConvertIfNecessary(expression, typeof(bool)));
			}
			throw new ExpressionCompileException("Unary operator not supported: " + _op.ToString() + expression.Type);
		}

		public override Func<double[], T> GetFunc(Context context)
		{
			if (_op == Operator.Minus)
			{
				if (this is Token<double>)
				{
					Func<double[], double> operand = _operand.GetFuncAs<double>(context);
					if ((Func<double[], double>)((double[] data) => 0.0 - operand(data)) is Func<double[], T> result)
					{
						return result;
					}
				}
				else if (this is Token<Vector3d>)
				{
					Func<double[], Vector3d> operand2 = _operand.GetFuncAs<Vector3d>(context);
					if ((Func<double[], Vector3d>)((double[] data) => -operand2(data)) is Func<double[], T> result2)
					{
						return result2;
					}
				}
			}
			else if (_op == Operator.Not)
			{
				Func<double[], bool> operand3 = _operand.GetFuncAs<bool>(context);
				if ((Func<double[], bool>)((double[] data) => !operand3(data)) is Func<double[], T> result3)
				{
					return result3;
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
