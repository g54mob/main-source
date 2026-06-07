using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using ModApi.Expressions.Exceptions;
using ModApi.Expressions.Tokens;
using UnityEngine;

namespace ModApi.Expressions
{
	public static class Parser
	{
		private static readonly Dictionary<Regex, Func<string, Token>> TokenDefs = new Dictionary<Regex, Func<string, Token>>
		{
			{
				new Regex("\\G\"((?:[^\\\\\"]|\\\\.)*)\""),
				ConstantToken.CreateFromStringLiteral
			},
			{
				new Regex("\\G\\[[^\\]]+\\]"),
				DataSlotToken.Create
			},
			{
				new Regex("\\G[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?"),
				ConstantToken.CreateFromNumber
			},
			{
				new Regex("\\G(?:v:)?[A-z_\\.\\$][A-z_0-9\\.]*"),
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

		private static bool _commandsInited = false;

		private static MethodInfo _toStringMethod;

		public static bool ForceFunk { get; set; } = false;

		public static bool OptimizeFunctionTrees { get; set; } = true;

		public static Func<T> Process<T>(string inputString, Context context)
		{
			Token first = Parse(inputString, allowDataSlotTokens: false);
			first = Squash(first, context);
			InitCommands();
			if (!ForceFunk)
			{
				Expression expression = first.GetExpression(context, null);
				if (expression.Type != typeof(T))
				{
					expression = Converters.Convert(expression, typeof(T));
				}
				return Expression.Lambda<Func<T>>(expression, Array.Empty<ParameterExpression>()).Compile();
			}
			Func<double[], T> f = first.GetFuncAs<T>(context);
			return () => f(null);
		}

		public static Delegate ProcessAnyType(string inputString, Context context)
		{
			Token first = Parse(inputString, allowDataSlotTokens: false);
			first = Squash(first, context);
			InitCommands();
			if (!ForceFunk)
			{
				Expression expression = first.GetExpression(context, null);
				if (expression.Type == typeof(int))
				{
					expression = ConvertIfNecessary(expression, typeof(double));
				}
				return Expression.Lambda(expression).Compile();
			}
			if (first.Type == typeof(int))
			{
				Func<double[], int> f = first.GetFuncAs<int>(context);
				return (Func<double>)(() => f(null));
			}
			return first.GetFuncNoData(context);
		}

		public static Func<double[], T> Process<T>(string inputString, Context context, List<int> dataSlotsUsed)
		{
			Token token = Parse(inputString, allowDataSlotTokens: true);
			if (dataSlotsUsed != null)
			{
				Scan(token);
			}
			token = Squash(token, context);
			InitCommands();
			if (!ForceFunk)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(double[]), "data");
				Expression expression = token.GetExpression(context, parameterExpression);
				if (expression.Type != typeof(T))
				{
					expression = Converters.Convert(expression, typeof(T));
				}
				return Expression.Lambda<Func<double[], T>>(expression, new ParameterExpression[1] { parameterExpression }).Compile();
			}
			Func<double[], T> f = token.GetFuncAs<T>(context);
			return (double[] data) => f(data);
			void Scan(Token next)
			{
				while (next != null)
				{
					if (next is GroupToken groupToken)
					{
						Scan(groupToken.First);
					}
					else if (next is DataSlotToken dataSlotToken)
					{
						dataSlotsUsed.Add(dataSlotToken.Index);
					}
					next = next.Next;
				}
			}
		}

		internal static Expression ConvertIfNecessary(Expression from, Type to)
		{
			if (to.IsAssignableFrom(from.Type))
			{
				return from;
			}
			return Converters.Convert(from, to);
		}

		internal static Func<double[], TTo> ConvertIfNecessary<TFrom, TTo>(Func<double[], TFrom> func)
		{
			if (func is Func<double[], TTo> result)
			{
				return result;
			}
			return Converters.Convert<TFrom, TTo>(func);
		}

		internal static Token Parse(string inputString, bool allowDataSlotTokens)
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
						Token token3;
						if (match.Value == "(")
						{
							token3 = new GroupToken(null);
						}
						else
						{
							token3 = value(match.Value);
							if (!allowDataSlotTokens && token3 is DataSlotToken)
							{
								token3 = new NameToken(match.Value.Substring(1, match.Value.Length - 2));
							}
						}
						token3.Prev = token2;
						if (token3.Prev != null)
						{
							token3.Prev.Next = token3;
						}
						if (token3 is ConstantToken<double> constantToken && token2 != null && token2 is OperatorToken { Op: Operator.Minus } && (token2.Prev == null || token2.Prev is OperatorToken))
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
							constantToken.Value = 0.0 - constantToken.Value;
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

		internal static Token Squash(Token first, Context context)
		{
			first = SquashInvocations(first, context);
			first = SquashVariables(first, context);
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

		internal static Token SquashInvocations(Token first, Context context)
		{
			for (Token token = first; token != null; token = token.Next)
			{
				if (token is GroupToken args && token.Prev is NameToken name)
				{
					(Token token, List<Token> args) tuple = InvocationToken.Create(name, args, context);
					Token item = tuple.token;
					List<Token> item2 = tuple.args;
					token = item;
					for (int i = 0; i < item2.Count; i++)
					{
						item2[i] = Squash(item2[i], context);
					}
				}
				if (token.Next == null)
				{
					return FindStart(token);
				}
			}
			return null;
		}

		internal static Token SquashVariables(Token first, Context context)
		{
			for (Token token = first; token != null; token = token.Next)
			{
				if (token is NameToken name)
				{
					token = VariableToken.Create(name, context);
				}
				if (token.Next == null)
				{
					return FindStart(token);
				}
			}
			return null;
		}

		internal static Token SquashGroups(Token first, Context context)
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

		internal static Token SquashUnary(Token first)
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

		internal static Token SquashBinary(Token first, Operator[] opsAllowed)
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

		internal static Token SquashTernary(Token first)
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

		internal static void PrintStructure(Token first, int recurseLevel = 0)
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

		private static Token FindStart(Token t)
		{
			while (t.Prev != null)
			{
				t = t.Prev;
			}
			return t;
		}

		private static void InitCommands()
		{
			if (Application.isPlaying && !_commandsInited)
			{
				_commandsInited = true;
				Game.Instance.DevConsole.RegisterCommand("ToggleExpressionsBackend", (Func<string>)ToggleFunk);
			}
			static string ToggleFunk()
			{
				ForceFunk = !ForceFunk;
				if (!ForceFunk)
				{
					return "Backend is now set to expressions (desktop). Restart level to take effect.";
				}
				return "Backend is now set to f u n k (mobile). Restart level to take effect.";
			}
		}
	}
}
