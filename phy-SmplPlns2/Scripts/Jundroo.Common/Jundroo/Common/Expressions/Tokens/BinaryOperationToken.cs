using System;
using System.Linq.Expressions;
using System.Reflection;
using Jundroo.Common.Expressions.Exceptions;

namespace Jundroo.Common.Expressions.Tokens
{
	public static class BinaryOperationToken
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
				if (op.Op == Operator.Equal || op.Op == Operator.NotEqual)
				{
					return new BinaryOperationToken<bool>(left, op, right);
				}
			}
			else
			{
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
					return new BinaryOperationToken<float>(left, op, right);
				}
			}
			throw new ExpressionCompileException($"Binary operation not supported: {op.Op}");
		}
	}
	public class BinaryOperationToken<T> : Token<T>
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

		public override Expression GetExpression(Context context)
		{
			if (_left.IsFinal && _right.IsFinal)
			{
				Expression expression = _left.GetExpression(context);
				Expression expression2 = _right.GetExpression(context);
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
						if (type2 == typeof(float))
						{
							type = typeof(float);
						}
						else if (type == typeof(float))
						{
							type2 = typeof(float);
						}
					}
				}
				else
				{
					type = (type2 = typeof(float));
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

		public override Func<T> GetFunc(Context context)
		{
			if (typeof(T).IsAssignableFrom(typeof(string)) && _op == Operator.Plus)
			{
				Func<string> l = _left.GetFuncAs<string>(context);
				Func<string> r = _right.GetFuncAs<string>(context);
				if ((Func<string>)(() => l() + r()) is Func<T> result)
				{
					return result;
				}
				throw new ExpressionCompileException("[!!!] String binary operator failed to cast to result type.");
			}
			if (this is Token<bool>)
			{
				Func<bool> func;
				if (_op == Operator.Equal || _op == Operator.NotEqual)
				{
					if (_left is Token<string> || _right is Token<string>)
					{
						Func<string> l2 = _left.GetFuncAs<string>(context);
						Func<string> r2 = _right.GetFuncAs<string>(context);
						func = ((_op != Operator.Equal) ? ((Func<bool>)(() => l2() != r2())) : ((Func<bool>)(() => l2() == r2())));
					}
					else if (_left is Token<float> || _right is Token<float> || _left is Token<float> || _right is Token<float>)
					{
						Func<float> l3 = _left.GetFuncAs<float>(context);
						Func<float> r3 = _right.GetFuncAs<float>(context);
						func = ((_op != Operator.Equal) ? ((Func<bool>)(() => l3() != r3())) : ((Func<bool>)(() => l3() == r3())));
					}
					else
					{
						if (!(_left is Token<bool>) && !(_right is Token<bool>))
						{
							throw new ExpressionCompileException($"Type comparison not implemented: {_left.GetType()}, {_right.GetType()}");
						}
						Func<bool> l4 = _left.GetFuncAs<bool>(context);
						Func<bool> r4 = _right.GetFuncAs<bool>(context);
						func = ((_op != Operator.Equal) ? ((Func<bool>)(() => l4() != r4())) : ((Func<bool>)(() => l4() == r4())));
					}
				}
				else if (_op == Operator.And || _op == Operator.Or)
				{
					Func<bool> l5 = _left.GetFuncAs<bool>(context);
					Func<bool> r5 = _right.GetFuncAs<bool>(context);
					func = ((_op != Operator.And) ? ((Func<bool>)(() => l5() || r5())) : ((Func<bool>)(() => l5() && r5())));
				}
				else
				{
					Func<float> l6 = _left.GetFuncAs<float>(context);
					Func<float> r6 = _right.GetFuncAs<float>(context);
					func = _op switch
					{
						Operator.Gt => () => l6() > r6(), 
						Operator.Lt => () => l6() < r6(), 
						Operator.Lte => () => l6() <= r6(), 
						Operator.Gte => () => l6() >= r6(), 
						_ => throw new ExpressionCompileException("[!!!] Bool binary operator not supported."), 
					};
				}
				if (func is Func<T> result2)
				{
					return result2;
				}
				throw new ExpressionCompileException("[!!!] Bool binary operator failed to cast to result type.");
			}
			if (this is Token<float>)
			{
				Func<float> l7 = _left.GetFuncAs<float>(context);
				Func<float> r7 = _right.GetFuncAs<float>(context);
				Func<float> func2 = (Parser.OptimizeFunctionTrees ? GetOptimizedFunc(l7, r7) : null);
				if (func2 != null)
				{
					if (!(func2 is Func<T> result3))
					{
						throw new NotSupportedException();
					}
					return result3;
				}
				if (_op switch
				{
					Operator.Plus => (Func<float>)(() => l7() + r7()), 
					Operator.Minus => (Func<float>)(() => l7() - r7()), 
					Operator.Multiply => (Func<float>)(() => l7() * r7()), 
					Operator.Divide => (Func<float>)(() => l7() / r7()), 
					Operator.Modulus => (Func<float>)(() => l7() % r7()), 
					_ => throw new ExpressionCompileException($"Double binary operator not supported: {_op}"), 
				} is Func<T> result4)
				{
					return result4;
				}
				throw new ExpressionCompileException("[!!!] Double binary operator failed to cast to result type.");
			}
			throw new ExpressionCompileException("Binary operation: unknown return type: " + typeof(T).Name + ". Something real wrong.");
		}

		public override string ToString()
		{
			return "BIN(" + _left.ToString() + "  " + _op.ToString() + "  " + _right.ToString() + ")";
		}

		private Func<float> GetOptimizedFunc(Func<float> l, Func<float> r)
		{
			Func<float> result = null;
			ConstantToken<float> constantToken = _left as ConstantToken<float>;
			ConstantToken<float> constantToken2 = _right as ConstantToken<float>;
			if (constantToken != null)
			{
				float leftValue = constantToken.Value;
				if (constantToken2 == null)
				{
					result = _op switch
					{
						Operator.Plus => () => leftValue + r(), 
						Operator.Minus => () => leftValue - r(), 
						Operator.Multiply => () => leftValue * r(), 
						Operator.Divide => () => leftValue / r(), 
						Operator.Modulus => () => leftValue % r(), 
						_ => throw new ExpressionCompileException($"Number binary operator not supported: {_op}"), 
					};
				}
				else
				{
					float value = constantToken2.Value;
					float value2;
					switch (_op)
					{
					case Operator.Plus:
						value2 = leftValue + value;
						result = () => value2;
						break;
					case Operator.Minus:
						value2 = leftValue - value;
						result = () => value2;
						break;
					case Operator.Multiply:
						value2 = leftValue * value;
						result = () => value2;
						break;
					case Operator.Divide:
						value2 = leftValue / value;
						result = () => value2;
						break;
					case Operator.Modulus:
						value2 = leftValue % value;
						result = () => value2;
						break;
					default:
						throw new ExpressionCompileException($"Double binary operator not supported: {_op}");
					}
				}
			}
			else if (constantToken2 != null)
			{
				float rightValue = constantToken2.Value;
				result = _op switch
				{
					Operator.Plus => () => l() + rightValue, 
					Operator.Minus => () => l() - rightValue, 
					Operator.Multiply => () => l() * rightValue, 
					Operator.Divide => () => l() / rightValue, 
					Operator.Modulus => () => l() % rightValue, 
					_ => throw new ExpressionCompileException($"Number binary operator not supported: {_op}"), 
				};
			}
			return result;
		}
	}
}
