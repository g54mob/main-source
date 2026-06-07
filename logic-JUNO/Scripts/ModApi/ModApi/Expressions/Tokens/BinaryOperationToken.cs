using System;
using System.Linq.Expressions;
using System.Reflection;
using ModApi.Expressions.Exceptions;
using UnityEngine;

namespace ModApi.Expressions.Tokens
{
	internal static class BinaryOperationToken
	{
		public static Token Create(Token left, OperatorToken op, Token right)
		{
			if (!left.IsFinal || !right.IsFinal)
			{
				throw new ExpressionParseException("Create binary op: operands not final.");
			}
			if (left is Token<string> || right is Token<string>)
			{
				if (op.Op == Operator.Plus)
				{
					return new BinaryOperationToken<string>(left, op, right);
				}
			}
			else
			{
				if (left is Token<Vector3d> || right is Token<Vector3d>)
				{
					switch (op.Op)
					{
					case Operator.Plus:
					case Operator.Minus:
						if (left is Token<Vector3d> && right is Token<Vector3d>)
						{
							return new BinaryOperationToken<Vector3d>(left, op, right);
						}
						break;
					case Operator.Multiply:
						if (!(left is Token<Vector3d>) || !(right is Token<Vector3d>))
						{
							return new BinaryOperationToken<Vector3d>(left, op, right);
						}
						break;
					case Operator.Divide:
						if (left is Token<Vector3d> && !(right is Token<Vector3d>))
						{
							return new BinaryOperationToken<Vector3d>(left, op, right);
						}
						break;
					case Operator.Equal:
					case Operator.NotEqual:
						return new BinaryOperationToken<bool>(left, op, right);
					}
					throw new ExpressionParseException($"Vector operation not supported: {left.GetType()} {op} {right.GetType()}");
				}
				switch (op.Op)
				{
				case Operator.And:
				case Operator.Or:
				case Operator.Gt:
				case Operator.Lt:
				case Operator.Gte:
				case Operator.Lte:
				case Operator.Equal:
				case Operator.NotEqual:
					return new BinaryOperationToken<bool>(left, op, right);
				case Operator.Plus:
				case Operator.Minus:
				case Operator.Multiply:
				case Operator.Divide:
				case Operator.Modulus:
					return new BinaryOperationToken<double>(left, op, right);
				}
			}
			throw new ExpressionCompileException($"Binary operation not supported: {op.Op}");
		}
	}
	internal class BinaryOperationToken<T> : Token<T>
	{
		private static MethodInfo _concatMethod;

		private readonly Token _left;

		private readonly Operator _op;

		private readonly Token _right;

		public override bool IsFinal
		{
			get
			{
				if (_left.IsFinal)
				{
					return _right.IsFinal;
				}
				return false;
			}
		}

		private static MethodInfo ConcatMethod
		{
			get
			{
				if (_concatMethod == null)
				{
					_concatMethod = typeof(string).GetMethod("Concat", BindingFlags.Static | BindingFlags.Public, null, new Type[2]
					{
						typeof(string),
						typeof(string)
					}, null);
				}
				return _concatMethod;
			}
		}

		public BinaryOperationToken(Token left, OperatorToken op, Token right)
		{
			_left = left;
			_right = right;
			_op = op.Op;
			if (left.Prev != null)
			{
				left.Prev.Next = this;
				Prev = left.Prev;
			}
			if (right.Next != null)
			{
				right.Next.Prev = this;
				Next = right.Next;
			}
		}

		public override Expression GetExpression(Context context, ParameterExpression dataSlots)
		{
			if (_left.IsFinal && _right.IsFinal)
			{
				Expression expression = _left.GetExpression(context, dataSlots);
				Expression expression2 = _right.GetExpression(context, dataSlots);
				if (_op == Operator.Plus && (expression.Type == typeof(string) || expression2.Type == typeof(string)))
				{
					return Expression.Call(ConcatMethod, Parser.ConvertIfNecessary(expression, typeof(string)), Parser.ConvertIfNecessary(expression2, typeof(string)));
				}
				Type type;
				Type type2;
				ExpressionType binaryType;
				if (expression.Type == typeof(string) || expression2.Type == typeof(string))
				{
					type = (type2 = typeof(string));
					binaryType = _op switch
					{
						Operator.Equal => ExpressionType.Equal, 
						Operator.NotEqual => ExpressionType.NotEqual, 
						_ => throw new ExpressionCompileException($"Operator {_op} does not support strings"), 
					};
				}
				else if (_op == Operator.And || _op == Operator.Or)
				{
					type = (type2 = typeof(bool));
					binaryType = ((_op == Operator.And) ? ExpressionType.AndAlso : ExpressionType.OrElse);
				}
				else if (_op == Operator.Equal || _op == Operator.NotEqual)
				{
					binaryType = ((_op == Operator.Equal) ? ExpressionType.Equal : ExpressionType.NotEqual);
					type = expression.Type;
					type2 = expression2.Type;
					if (expression.Type != expression2.Type)
					{
						if (expression.Type == typeof(Vector3d) || expression2.Type == typeof(Vector3d))
						{
							return Expression.Constant(false);
						}
						if (type2 == typeof(double))
						{
							type = typeof(double);
						}
					}
				}
				else
				{
					if (expression.Type == typeof(Vector3d) || expression2.Type == typeof(Vector3d))
					{
						if (expression.Type == typeof(Vector3d) && expression2.Type == typeof(Vector3d))
						{
							return _op switch
							{
								Operator.Plus => Expression.Add(expression, expression2), 
								Operator.Minus => Expression.Subtract(expression, expression2), 
								Operator.Multiply => Expression.Multiply(expression, expression2), 
								Operator.Divide => Expression.Divide(expression, expression2), 
								_ => throw new ExpressionCompileException($"Invalid vector operation: {_op}"), 
							};
						}
						if (expression.Type != typeof(double) && expression.Type != typeof(Vector3d))
						{
							expression = Parser.ConvertIfNecessary(expression, typeof(double));
						}
						else if (expression2.Type != typeof(double) && expression2.Type != typeof(Vector3d))
						{
							expression2 = Parser.ConvertIfNecessary(expression2, typeof(double));
						}
						return _op switch
						{
							Operator.Multiply => Expression.Multiply(expression, expression2), 
							Operator.Divide => Expression.Divide(expression, expression2), 
							_ => throw new ExpressionCompileException($"Invalid vector-scalar operation: {_op}"), 
						};
					}
					type = (type2 = typeof(double));
					binaryType = _op switch
					{
						Operator.Plus => ExpressionType.AddChecked, 
						Operator.Minus => ExpressionType.SubtractChecked, 
						Operator.Multiply => ExpressionType.MultiplyChecked, 
						Operator.Divide => ExpressionType.Divide, 
						Operator.Modulus => ExpressionType.Modulo, 
						Operator.Gt => ExpressionType.GreaterThan, 
						Operator.Lt => ExpressionType.LessThan, 
						Operator.Gte => ExpressionType.GreaterThanOrEqual, 
						Operator.Lte => ExpressionType.LessThanOrEqual, 
						_ => throw new ExpressionCompileException($"Operation {type.Name} {_op} {type2.Name} not supported"), 
					};
				}
				Expression left = Parser.ConvertIfNecessary(expression, type);
				Expression right = Parser.ConvertIfNecessary(expression2, type2);
				return Expression.MakeBinary(binaryType, left, right);
			}
			throw new ExpressionCompileException("Operands not final!");
		}

		public override Func<double[], T> GetFunc(Context context)
		{
			if (typeof(T).IsAssignableFrom(typeof(string)) && _op == Operator.Plus)
			{
				Func<double[], string> l = _left.GetFuncAs<string>(context);
				Func<double[], string> r = _right.GetFuncAs<string>(context);
				if ((Func<double[], string>)((double[] data) => l(data) + r(data)) is Func<double[], T> result)
				{
					return result;
				}
				throw new ExpressionCompileException("[!!!] String binary operator failed to cast to result type.");
			}
			if (this is Token<bool>)
			{
				Func<double[], bool> func;
				if (_op == Operator.Equal || _op == Operator.NotEqual)
				{
					if (_left is Token<string> || _right is Token<string>)
					{
						Func<double[], string> l2 = _left.GetFuncAs<string>(context);
						Func<double[], string> r2 = _right.GetFuncAs<string>(context);
						func = ((_op != Operator.Equal) ? ((Func<double[], bool>)((double[] data) => l2(data) != r2(data))) : ((Func<double[], bool>)((double[] data) => l2(data) == r2(data))));
					}
					else if (_left is Token<double> || _right is Token<double> || _left is Token<float> || _right is Token<float>)
					{
						Func<double[], double> l3 = _left.GetFuncAs<double>(context);
						Func<double[], double> r3 = _right.GetFuncAs<double>(context);
						func = ((_op != Operator.Equal) ? ((Func<double[], bool>)((double[] data) => l3(data) != r3(data))) : ((Func<double[], bool>)((double[] data) => l3(data) == r3(data))));
					}
					else
					{
						if (!(_left is Token<bool>) && !(_right is Token<bool>))
						{
							throw new ExpressionCompileException($"Type comparison not implemented: {_left.GetType()}, {_right.GetType()}");
						}
						Func<double[], bool> l4 = _left.GetFuncAs<bool>(context);
						Func<double[], bool> r4 = _right.GetFuncAs<bool>(context);
						func = ((_op != Operator.Equal) ? ((Func<double[], bool>)((double[] data) => l4(data) != r4(data))) : ((Func<double[], bool>)((double[] data) => l4(data) == r4(data))));
					}
				}
				else if (_op == Operator.And || _op == Operator.Or)
				{
					Func<double[], bool> l5 = _left.GetFuncAs<bool>(context);
					Func<double[], bool> r5 = _right.GetFuncAs<bool>(context);
					func = ((_op != Operator.And) ? ((Func<double[], bool>)((double[] data) => l5(data) || r5(data))) : ((Func<double[], bool>)((double[] data) => l5(data) && r5(data))));
				}
				else
				{
					Func<double[], double> l6 = _left.GetFuncAs<double>(context);
					Func<double[], double> r6 = _right.GetFuncAs<double>(context);
					func = _op switch
					{
						Operator.Gt => (double[] data) => l6(data) > r6(data), 
						Operator.Lt => (double[] data) => l6(data) < r6(data), 
						Operator.Lte => (double[] data) => l6(data) <= r6(data), 
						Operator.Gte => (double[] data) => l6(data) >= r6(data), 
						_ => throw new ExpressionCompileException("[!!!] Bool binary operator not supported."), 
					};
				}
				if (func is Func<double[], T> result2)
				{
					return result2;
				}
				throw new ExpressionCompileException("[!!!] Bool binary operator failed to cast to result type.");
			}
			if (this is Token<Vector3d>)
			{
				if (_left is Token<Vector3d> && _right is Token<Vector3d>)
				{
					Func<double[], Vector3d> func2 = null;
					Func<double[], Vector3d> l7 = _left.GetFuncAs<Vector3d>(context);
					Func<double[], Vector3d> r7 = _right.GetFuncAs<Vector3d>(context);
					switch (_op)
					{
					case Operator.Plus:
						func2 = (double[] d) => l7(d) + r7(d);
						break;
					case Operator.Minus:
						func2 = (double[] d) => l7(d) - r7(d);
						break;
					}
					if (func2 is Func<double[], T> result3)
					{
						return result3;
					}
					throw new ExpressionCompileException($"Invalid vector operation: {_op}");
				}
				if (_left is Token<Vector3d>)
				{
					Func<double[], Vector3d> func3 = null;
					Func<double[], Vector3d> l8 = _left.GetFuncAs<Vector3d>(context);
					Func<double[], double> r8 = _right.GetFuncAs<double>(context);
					switch (_op)
					{
					case Operator.Multiply:
						func3 = (double[] d) => l8(d) * r8(d);
						break;
					case Operator.Divide:
						func3 = (double[] d) => l8(d) / r8(d);
						break;
					}
					if (func3 is Func<double[], T> result4)
					{
						return result4;
					}
					throw new ExpressionCompileException($"Invalid vector-scalar operation: {_op}");
				}
				if (_op == Operator.Multiply)
				{
					Func<double[], double> l9 = _left.GetFuncAs<double>(context);
					Func<double[], Vector3d> r9 = _right.GetFuncAs<Vector3d>(context);
					if ((Func<double[], Vector3d>)((double[] data) => r9(data) * l9(data)) is Func<double[], T> result5)
					{
						return result5;
					}
					throw new ExpressionCompileException($"Invalid vector-scalar operation: {_op}");
				}
				throw new ExpressionCompileException($"Invalid vector-scalar operator: {_op}");
			}
			if (this is Token<double>)
			{
				Func<double[], double> l10 = _left.GetFuncAs<double>(context);
				Func<double[], double> r10 = _right.GetFuncAs<double>(context);
				Func<double[], double> func4 = (Parser.OptimizeFunctionTrees ? GetOptimizedFunc(l10, r10) : null);
				if (func4 != null)
				{
					if (!(func4 is Func<double[], T> result6))
					{
						throw new NotSupportedException();
					}
					return result6;
				}
				if (_op switch
				{
					Operator.Plus => (Func<double[], double>)((double[] data) => l10(data) + r10(data)), 
					Operator.Minus => (Func<double[], double>)((double[] data) => l10(data) - r10(data)), 
					Operator.Multiply => (Func<double[], double>)((double[] data) => l10(data) * r10(data)), 
					Operator.Divide => (Func<double[], double>)((double[] data) => l10(data) / r10(data)), 
					Operator.Modulus => (Func<double[], double>)((double[] data) => l10(data) % r10(data)), 
					_ => throw new ExpressionCompileException($"Double binary operator not supported: {_op}"), 
				} is Func<double[], T> result7)
				{
					return result7;
				}
				throw new ExpressionCompileException("[!!!] Double binary operator failed to cast to result type.");
			}
			throw new ExpressionCompileException("Binary operation: unknown return type: " + typeof(T).Name + ". Something real wrong.");
		}

		public override string ToString()
		{
			return "BIN(" + _left.ToString() + "  " + _op.ToString() + "  " + _right.ToString() + ")";
		}

		private Func<double[], double> GetOptimizedFunc(Func<double[], double> l, Func<double[], double> r)
		{
			Func<double[], double> result = null;
			DataSlotToken dataSlotToken = _left as DataSlotToken;
			ConstantToken<double> constantToken = _left as ConstantToken<double>;
			DataSlotToken dataSlotToken2 = _right as DataSlotToken;
			ConstantToken<double> constantToken2 = _right as ConstantToken<double>;
			if (dataSlotToken != null)
			{
				int leftIndex = dataSlotToken.Index;
				if (dataSlotToken2 != null)
				{
					int rightIndex = dataSlotToken2.Index;
					result = _op switch
					{
						Operator.Plus => (double[] data) => data[leftIndex] + data[rightIndex], 
						Operator.Minus => (double[] data) => data[leftIndex] - data[rightIndex], 
						Operator.Multiply => (double[] data) => data[leftIndex] * data[rightIndex], 
						Operator.Divide => (double[] data) => data[leftIndex] / data[rightIndex], 
						Operator.Modulus => (double[] data) => data[leftIndex] % data[rightIndex], 
						_ => throw new ExpressionCompileException($"Double binary operator not supported: {_op}"), 
					};
				}
				else if (constantToken2 == null)
				{
					result = _op switch
					{
						Operator.Plus => (double[] data) => data[leftIndex] + r(data), 
						Operator.Minus => (double[] data) => data[leftIndex] - r(data), 
						Operator.Multiply => (double[] data) => data[leftIndex] * r(data), 
						Operator.Divide => (double[] data) => data[leftIndex] / r(data), 
						Operator.Modulus => (double[] data) => data[leftIndex] % r(data), 
						_ => throw new ExpressionCompileException($"Double binary operator not supported: {_op}"), 
					};
				}
				else
				{
					double rightValue = constantToken2.Value;
					switch (_op)
					{
					case Operator.Plus:
						result = (double[] data) => data[leftIndex] + rightValue;
						break;
					case Operator.Minus:
						result = (double[] data) => data[leftIndex] - rightValue;
						break;
					case Operator.Multiply:
						result = (double[] data) => data[leftIndex] * rightValue;
						break;
					case Operator.Divide:
					{
						double oneOverRightValue = 1.0 / rightValue;
						result = (double[] data) => data[leftIndex] * oneOverRightValue;
						break;
					}
					case Operator.Modulus:
						result = (double[] data) => data[leftIndex] % rightValue;
						break;
					default:
						throw new ExpressionCompileException($"Double binary operator not supported: {_op}");
					}
				}
			}
			else if (constantToken != null)
			{
				double leftValue = constantToken.Value;
				if (dataSlotToken2 != null)
				{
					int rightIndex2 = dataSlotToken2.Index;
					result = _op switch
					{
						Operator.Plus => (double[] data) => leftValue + data[rightIndex2], 
						Operator.Minus => (double[] data) => leftValue - data[rightIndex2], 
						Operator.Multiply => (double[] data) => leftValue * data[rightIndex2], 
						Operator.Divide => (double[] data) => leftValue / data[rightIndex2], 
						Operator.Modulus => (double[] data) => leftValue % data[rightIndex2], 
						_ => throw new ExpressionCompileException($"Double binary operator not supported: {_op}"), 
					};
				}
				else if (constantToken2 == null)
				{
					result = _op switch
					{
						Operator.Plus => (double[] data) => leftValue + r(data), 
						Operator.Minus => (double[] data) => leftValue - r(data), 
						Operator.Multiply => (double[] data) => leftValue * r(data), 
						Operator.Divide => (double[] data) => leftValue / r(data), 
						Operator.Modulus => (double[] data) => leftValue % r(data), 
						_ => throw new ExpressionCompileException($"Double binary operator not supported: {_op}"), 
					};
				}
				else
				{
					double value = constantToken2.Value;
					double value2;
					switch (_op)
					{
					case Operator.Plus:
						value2 = leftValue + value;
						result = (double[] data) => value2;
						break;
					case Operator.Minus:
						value2 = leftValue - value;
						result = (double[] data) => value2;
						break;
					case Operator.Multiply:
						value2 = leftValue * value;
						result = (double[] data) => value2;
						break;
					case Operator.Divide:
						value2 = leftValue / value;
						result = (double[] data) => value2;
						break;
					case Operator.Modulus:
						value2 = leftValue % value;
						result = (double[] data) => value2;
						break;
					default:
						throw new ExpressionCompileException($"Double binary operator not supported: {_op}");
					}
				}
			}
			return result;
		}
	}
}
