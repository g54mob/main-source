using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Jundroo.Common.Expressions.Exceptions;

namespace Jundroo.Common.Expressions.Tokens
{
	public static class InvocationToken
	{
		public static (Token Token, List<Token> Args) Create(NameToken name, Token instance, GroupToken args, bool nullCoalesce, Context context)
		{
			List<Token> list = new List<Token>();
			Token token = args.First;
			for (Token token2 = args.First; token2 != null; token2 = token2.Next)
			{
				if (token2 is SeperatorToken)
				{
					if (token2.Prev == null)
					{
						throw new ExpressionCompileException("Expected argument for function \"" + name.Name + "\"");
					}
					token2.Prev.Next = null;
					list.Add(token);
					token = token2.Next;
					token.Prev = null;
				}
			}
			if (token != null)
			{
				list.Add(token);
			}
			var (methodInfo, obj) = GetMethod(name.Name, instance, list.Count, context);
			return (Token: (Token)Activator.CreateInstance(typeof(InvocationToken<>).MakeGenericType(methodInfo.ReturnType), name.Name, instance, nullCoalesce, methodInfo, obj, list), Args: list);
		}

		public static (MethodInfo Method, object Instance) GetMethod(string name, Token instance, int args, Context context)
		{
			MethodInfo methodInfo = null;
			object item = null;
			if (instance == null)
			{
				Func<Func<float>, (MethodInfo, object)> value2;
				if (context.Functions.TryGetValue(name, out (MethodInfo, object) value))
				{
					(methodInfo, item) = value;
				}
				else if (context.EnableMemory && context.SpecialFunctions.TryGetValue(name, out value2))
				{
					(methodInfo, item) = value2(context.GetDeltaTime);
				}
			}
			else
			{
				if (!instance.IsFinal)
				{
					throw new ExpressionCompileException("Invalid syntax");
				}
				methodInfo = context.GetMethod(name, instance.Type);
			}
			if (methodInfo != null)
			{
				ParameterInfo[] parameters = methodInfo.GetParameters();
				if (parameters.Length != args)
				{
					throw new ExpressionCompileException($"Function {name} takes {parameters.Length} arguments, {args} were given.");
				}
				return (Method: methodInfo, Instance: item);
			}
			throw new ExpressionCompileException("Function not found: " + name);
		}

		public static Func<T> WrapFunc0<T>(MethodInfo method, object instance)
		{
			return (Func<T>)Delegate.CreateDelegate(typeof(Func<T>), instance, method);
		}

		public static Func<T> WrapFunc1<T, T1>(MethodInfo method, object instance, Func<T1> arg1)
		{
			Func<T1, T> func = (Func<T1, T>)Delegate.CreateDelegate(typeof(Func<T1, T>), instance, method);
			return () => func(arg1());
		}

		public static Func<T> WrapFunc2<T, T1, T2>(MethodInfo method, object instance, Func<T1> arg1, Func<T2> arg2)
		{
			Func<T1, T2, T> func = (Func<T1, T2, T>)Delegate.CreateDelegate(typeof(Func<T1, T2, T>), instance, method);
			return () => func(arg1(), arg2());
		}

		public static Func<T> WrapFunc3<T, T1, T2, T3>(MethodInfo method, object instance, Func<T1> arg1, Func<T2> arg2, Func<T3> arg3)
		{
			Func<T1, T2, T3, T> func = (Func<T1, T2, T3, T>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T>), instance, method);
			return () => func(arg1(), arg2(), arg3());
		}

		public static Func<T> WrapFunc4<T, T1, T2, T3, T4>(MethodInfo method, object instance, Func<T1> arg1, Func<T2> arg2, Func<T3> arg3, Func<T4> arg4)
		{
			Func<T1, T2, T3, T4, T> func = (Func<T1, T2, T3, T4, T>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T4, T>), instance, method);
			return () => func(arg1(), arg2(), arg3(), arg4());
		}

		public static Func<T> WrapFunc5<T, T1, T2, T3, T4, T5>(MethodInfo method, object instance, Func<T1> arg1, Func<T2> arg2, Func<T3> arg3, Func<T4> arg4, Func<T5> arg5)
		{
			Func<T1, T2, T3, T4, T5, T> func = (Func<T1, T2, T3, T4, T5, T>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T4, T5, T>), instance, method);
			return () => func(arg1(), arg2(), arg3(), arg4(), arg5());
		}

		public static Func<T> WrapFuncOpen0<T, TI>(MethodInfo method, Func<TI> instance)
		{
			Func<TI, T> func = (Func<TI, T>)Delegate.CreateDelegate(typeof(Func<TI, T>), method);
			return () => func(instance());
		}

		public static Func<T> WrapFuncOpen1<T, TI, T1>(MethodInfo method, Func<TI> instance, Func<T1> arg1)
		{
			Func<TI, T1, T> func = (Func<TI, T1, T>)Delegate.CreateDelegate(typeof(Func<TI, T1, T>), method);
			return () => func(instance(), arg1());
		}
	}
	public class InvocationToken<T> : Token<T>
	{
		private MethodInfo _method;

		private object _staticInstance;

		public Token Instance { get; }

		public List<Token> Arguments { get; set; }

		public string FunctionName { get; set; }

		public override bool IsFinal
		{
			get
			{
				foreach (Token argument in Arguments)
				{
					if (!argument.IsFinal || argument.Next != null)
					{
						return false;
					}
				}
				return true;
			}
		}

		public bool NullCoalescing { get; private set; }

		public InvocationToken(string name, Token instance, bool nullCoalescing, MethodInfo invokeMethod, object invokeObject, List<Token> arguments)
		{
			FunctionName = name;
			Instance = instance;
			NullCoalescing = nullCoalescing;
			Arguments = arguments;
			_method = invokeMethod;
			_staticInstance = invokeObject;
		}

		public override Expression GetExpression(Context context)
		{
			ParameterInfo[] parameters = _method.GetParameters();
			Expression[] array = new Expression[parameters.Length];
			for (int i = 0; i < Arguments.Count; i++)
			{
				array[i] = Parser.ConvertIfNecessary(Arguments[i].GetExpression(context), parameters[i].ParameterType);
			}
			Expression expression = Instance?.GetExpression(context);
			if (expression != null && NullCoalescing)
			{
				ParameterExpression parameterExpression = Expression.Variable(expression.Type);
				return Expression.Block(new ParameterExpression[1] { parameterExpression }, Expression.Assign(parameterExpression, expression), Expression.Condition(Expression.NotEqual(parameterExpression, Expression.Constant(null)), Expression.Call(parameterExpression, _method, array), Expression.Default(_method.ReturnType)));
			}
			if (expression == null)
			{
				expression = ((_staticInstance == null) ? null : Expression.Constant(_staticInstance));
			}
			return Expression.Call(expression, _method, array);
		}

		public override Func<T> GetFunc(Context context)
		{
			if (Instance != null)
			{
				throw new NotSupportedException("Member access has not been implemented for the mobile backend");
			}
			Func<float> func = (Parser.OptimizeFunctionTrees ? GetOptimizedFunc(context) : null);
			if (func != null)
			{
				if (!(func is Func<T> result))
				{
					throw new NotSupportedException();
				}
				return result;
			}
			int count = Arguments.Count;
			MethodInfo method = _method;
			object staticInstance = _staticInstance;
			MethodInfo methodInfo = method;
			object obj = staticInstance;
			if (count <= 5)
			{
				MethodInfo method2 = typeof(InvocationToken).GetMethod($"WrapFunc{count}");
				ParameterInfo[] parameters = methodInfo.GetParameters();
				if (count != parameters.Length)
				{
					throw new ExpressionCompileException($"Wrong number of arguments for function {FunctionName}, needed {parameters.Length}, got {count}");
				}
				Type[] array = new Type[count + 1];
				array[0] = typeof(T);
				object[] array2 = new object[count + 2];
				array2[0] = methodInfo;
				array2[1] = obj;
				for (int i = 0; i < count; i++)
				{
					array[i + 1] = parameters[i].ParameterType;
					array2[i + 2] = Arguments[i].GetType().GetMethod("GetFuncAs", BindingFlags.Instance | BindingFlags.Public).MakeGenericMethod(parameters[i].ParameterType)
						.Invoke(Arguments[i], new object[1] { context });
				}
				method2 = method2.MakeGenericMethod(array);
				return (Func<T>)method2.Invoke(null, array2);
			}
			throw new ExpressionCompileException("No support for functions with more than 5 arguments. Go add it, WNP.");
		}

		public override string ToString()
		{
			return FunctionName + "(" + string.Join(", ", Arguments.Select((Token a) => a.ToString())) + ")";
		}

		private Func<float> GetOptimizedFunc(Context context)
		{
			Func<float> result = null;
			try
			{
				if (FunctionName == "smoothstep")
				{
					if (Arguments.Count == 3 && Arguments[0] is ConstantToken<float> constantToken && Arguments[1] is ConstantToken<float> constantToken2)
					{
						Func<float> funcT = Arguments[2].GetFuncAs<float>(context);
						float from = constantToken.Value;
						float to = constantToken2.Value;
						result = ((from == 0f) ? ((to != 1f) ? ((Func<float>)delegate
						{
							float num = funcT();
							num = ((num < 0f) ? 0f : ((num > 1f) ? 1f : num));
							num = (3f - 2f * num) * num * num;
							return to * num;
						}) : ((Func<float>)delegate
						{
							float num = funcT();
							num = ((num < 0f) ? 0f : ((num > 1f) ? 1f : num));
							return (3f - 2f * num) * num * num;
						})) : ((from != 1f) ? ((Func<float>)delegate
						{
							float num = funcT();
							num = ((num < 0f) ? 0f : ((num > 1f) ? 1f : num));
							num = (3f - 2f * num) * num * num;
							return to * num + from * (1f - num);
						}) : ((to != 0f) ? ((Func<float>)delegate
						{
							float num = funcT();
							num = ((num < 0f) ? 0f : ((num > 1f) ? 1f : num));
							num = (3f - 2f * num) * num * num;
							return from * (1f - num);
						}) : ((Func<float>)delegate
						{
							float num = funcT();
							num = ((num < 0f) ? 0f : ((num > 1f) ? 1f : num));
							num = (3f - 2f * num) * num * num;
							return 1f - num;
						}))));
					}
				}
				else if (FunctionName == "max")
				{
					if (Arguments.Count == 2)
					{
						if (Arguments[0] is ConstantToken<float> constantToken3)
						{
							float constantValue = constantToken3.Value;
							Func<float> arg2Func = Arguments[1].GetFuncAs<float>(context);
							result = delegate
							{
								float num = arg2Func();
								return (!(num > constantValue)) ? constantValue : num;
							};
						}
						else if (Arguments[1] is ConstantToken<float> constantToken4)
						{
							float constantValue2 = constantToken4.Value;
							Func<float> arg1Func = Arguments[0].GetFuncAs<float>(context);
							result = delegate
							{
								float num = arg1Func();
								return (!(num > constantValue2)) ? constantValue2 : num;
							};
						}
					}
				}
				else if (FunctionName == "min")
				{
					if (Arguments.Count == 2)
					{
						if (Arguments[0] is ConstantToken<float> constantToken5)
						{
							float constantValue3 = constantToken5.Value;
							Func<float> arg2Func2 = Arguments[1].GetFuncAs<float>(context);
							result = delegate
							{
								float num = arg2Func2();
								return (!(num < constantValue3)) ? constantValue3 : num;
							};
						}
						else if (Arguments[1] is ConstantToken<float> constantToken6)
						{
							float constantValue4 = constantToken6.Value;
							Func<float> arg1Func2 = Arguments[0].GetFuncAs<float>(context);
							result = delegate
							{
								float num = arg1Func2();
								return (!(num < constantValue4)) ? constantValue4 : num;
							};
						}
					}
				}
				else if (FunctionName == "pow" && Arguments.Count == 2 && Arguments[1] is ConstantToken<float> constantToken7)
				{
					Func<float> arg1Func3 = Arguments[0].GetFuncAs<float>(context);
					float value = constantToken7.Value;
					if (value == 2f)
					{
						result = delegate
						{
							float num = arg1Func3();
							return num * num;
						};
					}
					else if (value == 3f)
					{
						result = delegate
						{
							float num = arg1Func3();
							return num * num * num;
						};
					}
					else if (value == 4f)
					{
						result = delegate
						{
							float num = arg1Func3();
							return num * num * num * num;
						};
					}
					else if (value == 5f)
					{
						result = delegate
						{
							float num = arg1Func3();
							return num * num * num * num * num;
						};
					}
					else if (value == 6f)
					{
						result = delegate
						{
							float num = arg1Func3();
							return num * num * num * num * num * num;
						};
					}
				}
			}
			catch (Exception inner)
			{
				throw new ExpressionCompileException("Failed optimising function: " + FunctionName, inner);
			}
			return result;
		}
	}
}
