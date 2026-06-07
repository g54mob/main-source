using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using Jundroo.Common.Expressions.Exceptions;
using Jundroo.Common.Expressions.Tokens;

namespace Jundroo.Common.Expressions
{
	public static class Parser
	{
		private static readonly List<Delegate> ConversionDelegates = new List<Delegate>
		{
			new Func<Func<bool>, Func<float>>(Converters.BoolToNumber),
			new Func<Func<float>, Func<bool>>(Converters.NumberToBool)
		};

		private static readonly Operator[][] OrderOfOperations = new Operator[5][]
		{
			new Operator[2]
			{
				Operator.Multiply,
				Operator.Divide
			},
			new Operator[1] { Operator.Modulus },
			new Operator[2]
			{
				Operator.Plus,
				Operator.Minus
			},
			new Operator[6]
			{
				Operator.Gt,
				Operator.Lt,
				Operator.Gte,
				Operator.Lte,
				Operator.Equal,
				Operator.NotEqual
			},
			new Operator[2]
			{
				Operator.And,
				Operator.Or
			}
		};

		private static readonly Dictionary<Regex, Func<string, Token>> TokenDefs = new Dictionary<Regex, Func<string, Token>>
		{
			{
				new Regex("\\G\\??\\.(?!\\d)"),
				(string s) => new MemberAccessorToken(s.Contains('?'))
			},
			{
				new Regex("\\G\"((?:[^\\\\\"]|\\\\.)*)\""),
				ConstantToken.CreateFromStringLiteral
			},
			{
				new Regex("\\G[0-9\\.]{2,}|\\G[0-9]+"),
				ConstantToken.CreateFromNumber
			},
			{
				new Regex("\\G(?:v:)?[A-z_][A-z_0-9]*"),
				(string s) => new NameToken(s)
			},
			{
				new Regex("\\G(?:(?:[<>!]=?)|[+\\-/*&|=\\?:%])"),
				(string s) => new OperatorToken(s)
			},
			{
				new Regex("\\G,"),
				(string s) => new SeperatorToken(s)
			},
			{
				new Regex("\\G[()]"),
				null
			}
		};

		private static readonly Regex WhitespacePat = new Regex("\\G\\s*");

		private static bool _commandsInited = false;

		private static MethodInfo _toStringMethod;

		private static MethodInfo _toStringSafeMethod;

		public static bool ForceFunk { get; set; } = false;

		public static bool Funk
		{
			get
			{
				InitCommands();
				return ForceFunk;
			}
		}

		public static bool OptimizeFunctionTrees { get; set; } = true;

		public static Expression ConvertIfNecessary(Expression from, Type to)
		{
			if (to.IsAssignableFrom(from.Type))
			{
				return from;
			}
			return ImplicitlyConvert(from, to);
		}

		public static Func<TTo> ConvertIfNecessary<TFrom, TTo>(Func<TFrom> func)
		{
			if (func is Func<TTo> result)
			{
				return result;
			}
			return ImplicitlyConvert<TFrom, TTo>(func);
		}

		public static Expression ImplicitlyConvert(Expression from, Type to)
		{
			if (to == typeof(string))
			{
				if (_toStringMethod == null)
				{
					_toStringSafeMethod = new Func<object, string>(ToStringNullSafe).Method;
					_toStringMethod = typeof(object).GetMethod("ToString");
				}
				if (from.Type.IsValueType)
				{
					return Expression.Call(from, _toStringMethod);
				}
				return Expression.Call(_toStringSafeMethod, from);
			}
			if (from.Type.IsClass && to == typeof(bool))
			{
				return Expression.NotEqual(from, Expression.Constant(null));
			}
			if (from.Type == typeof(float) && to == typeof(bool))
			{
				return Expression.GreaterThan(from, Expression.Constant(0f));
			}
			if (from.Type == typeof(bool) && to == typeof(float))
			{
				return Expression.Condition(from, Expression.Constant(1f), Expression.Constant(-1f));
			}
			throw new ExpressionCompileException($"Cannot convert type {from.Type} to {to}");
		}

		public static Func<TTo> ImplicitlyConvert<TFrom, TTo>(Func<TFrom> func)
		{
			Type typeFromHandle = typeof(TTo);
			if (typeFromHandle == typeof(string))
			{
				if (typeFromHandle.IsValueType)
				{
					return ((Func<string>)(() => func().ToString())) as Func<TTo>;
				}
				return ((Func<string>)(() => ToStringNullSafe(func()))) as Func<TTo>;
			}
			if (typeFromHandle == typeof(bool) && typeof(TFrom).IsClass)
			{
				return ((Func<bool>)(() => func() != null)) as Func<TTo>;
			}
			foreach (Delegate conversionDelegate in ConversionDelegates)
			{
				if (conversionDelegate is Func<Func<TFrom>, Func<TTo>> func2)
				{
					return func2(func);
				}
			}
			throw new ExpressionCompileException($"Could not convert type {typeof(TFrom)} to {typeof(TTo)}");
		}

		public static Token Parse(string inputString, bool allowDataSlotTokens)
		{
			Token token = null;
			Token token2 = null;
			Stack<GroupToken> stack = new Stack<GroupToken>();
			int num = 0;
			bool flag = true;
			while (flag)
			{
				flag = false;
				Match match = WhitespacePat.Match(inputString, num);
				if (match.Success)
				{
					num += match.Length;
				}
				foreach (KeyValuePair<Regex, Func<string, Token>> tokenDef in TokenDefs)
				{
					Regex key = tokenDef.Key;
					Func<string, Token> value = tokenDef.Value;
					match = key.Match(inputString, num);
					if (!match.Success)
					{
						continue;
					}
					if (match.Value == ")")
					{
						token2 = stack.Pop();
					}
					else
					{
						Token token3 = ((!(match.Value == "(")) ? value(match.Value) : new GroupToken(null));
						token3.Prev = token2;
						if (token3.Prev != null)
						{
							token3.Prev.Next = token3;
						}
						if (token3 is ConstantToken<float> constantToken && token2 != null && token2 is OperatorToken { Op: Operator.Minus } && (token2.Prev == null || token2.Prev is OperatorToken))
						{
							token3.Prev = token2.Prev;
							if (token3.Prev != null)
							{
								token3.Prev.Next = token3;
							}
							if (token == token2)
							{
								token = token3;
							}
							if (stack.Count != 0 && stack.Peek().First == token3)
							{
								stack.Peek().First = token3;
							}
							constantToken.Value = 0f - constantToken.Value;
							token2 = token3;
						}
						else
						{
							if (token2 == null && stack.Count != 0)
							{
								stack.Peek().First = token3;
							}
							if (token == null)
							{
								token = token3;
							}
							if (token3 is GroupToken)
							{
								token2 = null;
								stack.Push((GroupToken)token3);
							}
							else
							{
								token2 = token3;
							}
						}
					}
					num += match.Length;
					flag = true;
					break;
				}
			}
			if (num != inputString.Length)
			{
				throw new ExpressionParseException("Invalid syntax at pos: " + num + "\n" + inputString + "\n" + "^".PadLeft(num + 1));
			}
			if (token == null)
			{
				throw new ExpressionParseException("Invalid expression: No tokens recognised.");
			}
			return token;
		}

		public static void PrintStructure(Token first, int recurseLevel = 0)
		{
			for (Token token = first; token != null; token = token.Next)
			{
				for (int i = 0; i < recurseLevel; i++)
				{
					Console.Write("    ");
				}
				if (token is GroupToken)
				{
					Console.WriteLine("{");
					PrintStructure(((GroupToken)token).First, recurseLevel + 1);
					for (int j = 0; j < recurseLevel; j++)
					{
						Console.Write("    ");
					}
					Console.WriteLine("}");
				}
				else
				{
					Console.WriteLine(token.ToString());
				}
			}
		}

		public static Func<T> Process<T>(string inputString, Context context)
		{
			Token first = Parse(inputString, allowDataSlotTokens: false);
			first = Squash(first, context);
			if (!Funk)
			{
				Expression expression = first.GetExpression(context);
				if (expression.Type != typeof(T))
				{
					expression = ImplicitlyConvert(expression, typeof(T));
				}
				else if (expression.Type == typeof(string))
				{
					ParameterExpression parameterExpression = Expression.Parameter(typeof(string));
					expression = Expression.Block(new ParameterExpression[1] { parameterExpression }, Expression.Assign(parameterExpression, expression), Expression.Condition(Expression.NotEqual(parameterExpression, Expression.Constant(null)), parameterExpression, Expression.Constant("null")));
				}
				if (expression.Type == typeof(float))
				{
					MethodInfo method = new Func<float, bool>(float.IsFinite).Method;
					ParameterExpression parameterExpression2 = Expression.Parameter(typeof(float));
					expression = Expression.Block(new ParameterExpression[1] { parameterExpression2 }, Expression.Assign(parameterExpression2, expression), Expression.Condition(Expression.Call(method, parameterExpression2), parameterExpression2, Expression.Constant(0f)));
				}
				return Expression.Lambda<Func<T>>(expression, Array.Empty<ParameterExpression>()).Compile();
			}
			Func<T> funcAs = first.GetFuncAs<T>(context);
			if (first.Type == typeof(string) && typeof(T) == typeof(string))
			{
				Func<string> fs = funcAs as Func<string>;
				return ((Func<string>)delegate
				{
					string text = fs();
					return (text == null) ? "null" : text;
				}) as Func<T>;
			}
			if (first.Type == typeof(float))
			{
				Func<float> ff = funcAs as Func<float>;
				return ((Func<float>)delegate
				{
					float num = ff();
					return (!float.IsFinite(num)) ? 0f : num;
				}) as Func<T>;
			}
			return funcAs;
		}

		public static Token Squash(Token first, Context context)
		{
			first = SquashAccess(first, context);
			first = SquashGroups(first, context);
			first = SquashUnary(first);
			Operator[][] orderOfOperations = OrderOfOperations;
			foreach (Operator[] opsAllowed in orderOfOperations)
			{
				first = SquashBinary(first, opsAllowed);
			}
			first = SquashTernary(first);
			if (first.Next != null)
			{
				throw new ExpressionCompileException("Syntax error");
			}
			if (!first.IsFinal)
			{
				throw new ExpressionCompileException("Syntax error");
			}
			return first;
		}

		public static Token SquashBinary(Token first, Operator[] opsAllowed)
		{
			for (Token token = first; token != null; token = token.Next)
			{
				if (token is OperatorToken && token.Prev != null && token.Next != null && opsAllowed.Contains(((OperatorToken)token).Op))
				{
					token = BinaryOperationToken.Create(token.Prev, (OperatorToken)token, token.Next);
				}
				if (token.Next == null)
				{
					return FindStart(token);
				}
			}
			return null;
		}

		public static Token SquashGroups(Token first, Context context)
		{
			for (Token token = first; token != null; token = token.Next)
			{
				if (token is GroupToken groupToken)
				{
					groupToken.First = Squash(groupToken.First, context);
					if (groupToken.First.Next != null)
					{
						throw new ExpressionParseException("Invalid Syntax");
					}
					token = groupToken.First;
					if (groupToken.Prev != null)
					{
						groupToken.Prev.Next = token;
					}
					if (groupToken.Next != null)
					{
						groupToken.Next.Prev = token;
					}
					token.Prev = groupToken.Prev;
					token.Next = groupToken.Next;
					groupToken.Next = null;
					groupToken.Prev = null;
				}
				if (token.Next == null)
				{
					return FindStart(token);
				}
			}
			return null;
		}

		public static Token SquashAccess(Token first, Context context)
		{
			Token token = first;
			while (true)
			{
				if (token is NameToken name)
				{
					Token token2 = null;
					bool flag = false;
					if (token.Prev is MemberAccessorToken memberAccessorToken)
					{
						token2 = token.Prev.Prev;
						if (token2 == null)
						{
							throw new ExpressionParseException("Invalid syntax: member accessor (dot) without a preceding value.");
						}
						flag = memberAccessorToken.IsNullCoalescing;
						if (token2 is GroupToken groupToken)
						{
							token2 = Squash(groupToken.First, context);
						}
					}
					if (token.Next is GroupToken groupToken2)
					{
						var (token3, list) = InvocationToken.Create(name, token2, groupToken2, flag, context);
						Replace(token2 ?? token, groupToken2, token3);
						token = token3;
						for (int i = 0; i < list.Count; i++)
						{
							list[i] = Squash(list[i], context);
						}
					}
					else
					{
						Token token4 = PropertyToken.Create(name, token2, flag, context);
						Replace(token2 ?? token, token, token4);
						token = token4;
					}
				}
				if (token.Next == null)
				{
					break;
				}
				token = token.Next;
			}
			return FindStart(token);
		}

		public static Token SquashTernary(Token first)
		{
			for (Token token = first; token != null; token = token.Next)
			{
				if (token is OperatorToken { Op: Operator.ConditionalSelect })
				{
					if (token.Prev == null || !token.Prev.IsFinal)
					{
						throw new ExpressionCompileException("Invalid syntax before ? operator.");
					}
					if (token.Next == null || !token.Next.IsFinal)
					{
						throw new ExpressionCompileException("Invalid syntax after ? operator.");
					}
					if (token.Next.Next == null || !(token.Next.Next is OperatorToken { Op: Operator.ConditionalSeparator }))
					{
						throw new ExpressionCompileException("Expecting : after ?");
					}
					if (token.Next.Next.Next == null || !token.Next.Next.Next.IsFinal)
					{
						throw new ExpressionCompileException("Expecting expression after :");
					}
					Token prev = token.Prev;
					Token next = token.Next;
					Token next2 = token.Next.Next.Next;
					token = TernaryOperationToken.Create(prev, next, next2);
				}
				if (token.Next == null)
				{
					return FindStart(token);
				}
			}
			return null;
		}

		public static Token SquashUnary(Token first)
		{
			Token token = first;
			while (token != null)
			{
				if (!(token is OperatorToken) && token.Prev != null && token.Prev is OperatorToken left && (token.Prev.Prev == null || token.Prev.Prev is OperatorToken))
				{
					token = UnaryOperationToken.Create(left, token);
					continue;
				}
				if (token.Next == null)
				{
					return FindStart(token);
				}
				token = token.Next;
			}
			return null;
		}

		private static Token FindStart(Token t)
		{
			while (t.Prev != null)
			{
				t = t.Prev;
			}
			return t;
		}

		private static void Replace(Token oldFirst, Token oldLast, Token newToken)
		{
			newToken.Prev = oldFirst.Prev;
			oldFirst.Prev = null;
			if (newToken.Prev != null)
			{
				newToken.Prev.Next = newToken;
			}
			newToken.Next = oldLast.Next;
			oldLast.Next = null;
			if (newToken.Next != null)
			{
				newToken.Next.Prev = newToken;
			}
		}

		private static void Replace(Token oldFirst, Token oldLast, Token newFirst, Token newLast)
		{
			newFirst.Prev = oldFirst.Prev;
			oldFirst.Prev = null;
			if (newFirst.Prev != null)
			{
				newFirst.Prev.Next = newFirst;
			}
			newLast.Next = oldLast.Next;
			oldLast.Next = null;
			if (newLast.Next != null)
			{
				newLast.Next.Prev = newLast;
			}
		}

		private static string ToStringNullSafe(object obj)
		{
			if (obj != null)
			{
				return obj.ToString();
			}
			return "null";
		}

		private static void InitCommands()
		{
			if (!_commandsInited)
			{
				_commandsInited = true;
			}
		}
	}
}
