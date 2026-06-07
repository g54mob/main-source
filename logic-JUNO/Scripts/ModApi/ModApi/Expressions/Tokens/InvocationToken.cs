using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ModApi.Expressions.Exceptions;
using UnityEngine;

namespace ModApi.Expressions.Tokens
{
	internal static class InvocationToken
	{
		public static (MethodInfo method, object instance) GetMethod(string name, int args, Context context)
		{
			MethodInfo methodInfo = null;
			object item = null;
			Func<Func<double>, (MethodInfo, object)> value2;
			if (context.Functions.TryGetValue(name, out (MethodInfo, object) value))
			{
				(methodInfo, item) = value;
			}
			else if (context.EnableMemory && context.SpecialFunctions.TryGetValue(name, out value2))
			{
				(methodInfo, item) = value2(context.GetDeltaTime);
			}
			if (methodInfo != null)
			{
				ParameterInfo[] parameters = methodInfo.GetParameters();
				if (parameters.Length != args)
				{
					throw new ExpressionCompileException($"Function {name} takes {parameters.Length} arguments, {args} were given.");
				}
				return (method: methodInfo, instance: item);
			}
			throw new ExpressionCompileException("Function not found: " + name);
		}

		public static (Token token, List<Token> args) Create(NameToken name, GroupToken args, Context context)
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
			MethodInfo item = GetMethod(name.Name, list.Count, context).method;
			Token token3 = (Token)Activator.CreateInstance(typeof(InvocationToken<>).MakeGenericType(item.ReturnType), name.Name, list);
			if (args.Next != null)
			{
				args.Next.Prev = token3;
			}
			if (name.Prev != null)
			{
				name.Prev.Next = token3;
			}
			token3.Prev = name.Prev;
			token3.Next = args.Next;
			return (token: token3, args: list);
		}

		public static Func<double[], T> WrapFunc0<T>(MethodInfo method, object instance)
		{
			Func<T> func = (Func<T>)Delegate.CreateDelegate(typeof(Func<T>), instance, method);
			return (double[] _) => func();
		}

		public static Func<double[], T> WrapFunc1<T, T1>(MethodInfo method, object instance, Func<double[], T1> arg1)
		{
			Func<T1, T> func = (Func<T1, T>)Delegate.CreateDelegate(typeof(Func<T1, T>), instance, method);
			return (double[] d) => func(arg1(d));
		}

		public static Func<double[], T> WrapFunc2<T, T1, T2>(MethodInfo method, object instance, Func<double[], T1> arg1, Func<double[], T2> arg2)
		{
			Func<T1, T2, T> func = (Func<T1, T2, T>)Delegate.CreateDelegate(typeof(Func<T1, T2, T>), instance, method);
			return (double[] d) => func(arg1(d), arg2(d));
		}

		public static Func<double[], T> WrapFunc3<T, T1, T2, T3>(MethodInfo method, object instance, Func<double[], T1> arg1, Func<double[], T2> arg2, Func<double[], T3> arg3)
		{
			Func<T1, T2, T3, T> func = (Func<T1, T2, T3, T>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T>), instance, method);
			return (double[] d) => func(arg1(d), arg2(d), arg3(d));
		}

		public static Func<double[], T> WrapFunc4<T, T1, T2, T3, T4>(MethodInfo method, object instance, Func<double[], T1> arg1, Func<double[], T2> arg2, Func<double[], T3> arg3, Func<double[], T4> arg4)
		{
			Func<T1, T2, T3, T4, T> func = (Func<T1, T2, T3, T4, T>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T4, T>), instance, method);
			return (double[] d) => func(arg1(d), arg2(d), arg3(d), arg4(d));
		}

		public static Func<double[], T> WrapFunc5<T, T1, T2, T3, T4, T5>(MethodInfo method, object instance, Func<double[], T1> arg1, Func<double[], T2> arg2, Func<double[], T3> arg3, Func<double[], T4> arg4, Func<double[], T5> arg5)
		{
			Func<T1, T2, T3, T4, T5, T> func = (Func<T1, T2, T3, T4, T5, T>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T4, T5, T>), instance, method);
			return (double[] d) => func(arg1(d), arg2(d), arg3(d), arg4(d), arg5(d));
		}
	}
	internal class InvocationToken<T> : Token<T>
	{
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

		public InvocationToken(string name, List<Token> arguments)
		{
			FunctionName = name;
			Arguments = arguments;
		}

		public override Expression GetExpression(Context context, ParameterExpression dataSlots)
		{
			(MethodInfo, object) method = InvocationToken.GetMethod(FunctionName, Arguments.Count, context);
			ParameterInfo[] parameters = method.Item1.GetParameters();
			Expression[] array = new Expression[parameters.Length];
			for (int i = 0; i < Arguments.Count; i++)
			{
				array[i] = Parser.ConvertIfNecessary(Arguments[i].GetExpression(context, dataSlots), parameters[i].ParameterType);
			}
			return Expression.Call((method.Item2 == null) ? null : Expression.Constant(method.Item2), method.Item1, array);
		}

		public override Func<double[], T> GetFunc(Context context)
		{
			Func<double[], double> func = (Parser.OptimizeFunctionTrees ? GetOptimizedFunc(context) : null);
			if (func != null)
			{
				if (!(func is Func<double[], T> result))
				{
					throw new NotSupportedException();
				}
				return result;
			}
			int count = Arguments.Count;
			var (methodInfo, obj) = InvocationToken.GetMethod(FunctionName, count, context);
			if (count <= 5)
			{
				MethodInfo method = typeof(InvocationToken).GetMethod($"WrapFunc{count}");
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
				method = method.MakeGenericMethod(array);
				return (Func<double[], T>)method.Invoke(null, array2);
			}
			throw new ExpressionCompileException("No support for functions with more than 5 arguments. Go add it, WNP.");
		}

		public override string ToString()
		{
			return FunctionName + "(" + string.Join(", ", Arguments.Select((Token a) => a.ToString())) + ")";
		}

		private Func<double[], double> GetOptimizedFunc(Context context)
		{
			Func<double[], double> result = null;
			try
			{
				if (FunctionName == "smoothstep")
				{
					if (Arguments.Count == 3 && Arguments[0] is ConstantToken<double> constantToken && Arguments[1] is ConstantToken<double> constantToken2)
					{
						Func<double[], double> funcT = Arguments[2].GetFuncAs<double>(context);
						double from = constantToken.Value;
						double to = constantToken2.Value;
						result = ((from == 0.0) ? ((to != 1.0) ? ((Func<double[], double>)delegate(double[] data)
						{
							double num = funcT(data);
							num = ((num < 0.0) ? 0.0 : ((num > 1.0) ? 1.0 : num));
							num = (3.0 - 2.0 * num) * num * num;
							return to * num;
						}) : ((Func<double[], double>)delegate(double[] data)
						{
							double num = funcT(data);
							num = ((num < 0.0) ? 0.0 : ((num > 1.0) ? 1.0 : num));
							return (3.0 - 2.0 * num) * num * num;
						})) : ((from != 1.0) ? ((Func<double[], double>)delegate(double[] data)
						{
							double num = funcT(data);
							num = ((num < 0.0) ? 0.0 : ((num > 1.0) ? 1.0 : num));
							num = (3.0 - 2.0 * num) * num * num;
							return to * num + from * (1.0 - num);
						}) : ((to != 0.0) ? ((Func<double[], double>)delegate(double[] data)
						{
							double num = funcT(data);
							num = ((num < 0.0) ? 0.0 : ((num > 1.0) ? 1.0 : num));
							num = (3.0 - 2.0 * num) * num * num;
							return from * (1.0 - num);
						}) : ((Func<double[], double>)delegate(double[] data)
						{
							double num = funcT(data);
							num = ((num < 0.0) ? 0.0 : ((num > 1.0) ? 1.0 : num));
							num = (3.0 - 2.0 * num) * num * num;
							return 1.0 - num;
						}))));
					}
				}
				else if (FunctionName == "max")
				{
					if (Arguments.Count == 2)
					{
						if (Arguments[0] is ConstantToken<double> constantToken3)
						{
							double constantValue = constantToken3.Value;
							if (Arguments[1] is DataSlotToken dataSlotToken)
							{
								int slotIndex = dataSlotToken.Index;
								result = (double[] data) => (!(data[slotIndex] > constantValue)) ? constantValue : data[slotIndex];
							}
							else
							{
								Func<double[], double> arg2Func = Arguments[1].GetFuncAs<double>(context);
								result = delegate(double[] data)
								{
									double num = arg2Func(data);
									return (!(num > constantValue)) ? constantValue : num;
								};
							}
						}
						else if (Arguments[1] is ConstantToken<double> constantToken4)
						{
							double constantValue2 = constantToken4.Value;
							if (Arguments[0] is DataSlotToken dataSlotToken2)
							{
								int slotIndex2 = dataSlotToken2.Index;
								result = (double[] data) => (!(data[slotIndex2] > constantValue2)) ? constantValue2 : data[slotIndex2];
							}
							else
							{
								Func<double[], double> arg1Func = Arguments[0].GetFuncAs<double>(context);
								result = delegate(double[] data)
								{
									double num = arg1Func(data);
									return (!(num > constantValue2)) ? constantValue2 : num;
								};
							}
						}
						else if (Arguments[0] is DataSlotToken dataSlotToken3 && Arguments[1] is DataSlotToken dataSlotToken4)
						{
							int arg1Index = dataSlotToken3.Index;
							int arg2Index = dataSlotToken4.Index;
							result = delegate(double[] data)
							{
								double num = data[arg1Index];
								double num2 = data[arg2Index];
								return (!(num > num2)) ? num2 : num;
							};
						}
					}
				}
				else if (FunctionName == "min")
				{
					if (Arguments.Count == 2)
					{
						if (Arguments[0] is ConstantToken<double> constantToken5)
						{
							double constantValue3 = constantToken5.Value;
							if (Arguments[1] is DataSlotToken dataSlotToken5)
							{
								int slotIndex3 = dataSlotToken5.Index;
								result = (double[] data) => (!(data[slotIndex3] < constantValue3)) ? constantValue3 : data[slotIndex3];
							}
							else
							{
								Func<double[], double> arg2Func2 = Arguments[1].GetFuncAs<double>(context);
								result = delegate(double[] data)
								{
									double num = arg2Func2(data);
									return (!(num < constantValue3)) ? constantValue3 : num;
								};
							}
						}
						else if (Arguments[1] is ConstantToken<double> constantToken6)
						{
							double constantValue4 = constantToken6.Value;
							if (Arguments[0] is DataSlotToken dataSlotToken6)
							{
								int slotIndex4 = dataSlotToken6.Index;
								result = (double[] data) => (!(data[slotIndex4] < constantValue4)) ? constantValue4 : data[slotIndex4];
							}
							else
							{
								Func<double[], double> arg1Func2 = Arguments[0].GetFuncAs<double>(context);
								result = delegate(double[] data)
								{
									double num = arg1Func2(data);
									return (!(num < constantValue4)) ? constantValue4 : num;
								};
							}
						}
						else if (Arguments[0] is DataSlotToken dataSlotToken7 && Arguments[1] is DataSlotToken dataSlotToken8)
						{
							int arg1Index2 = dataSlotToken7.Index;
							int arg2Index2 = dataSlotToken8.Index;
							result = delegate(double[] data)
							{
								double num = data[arg1Index2];
								double num2 = data[arg2Index2];
								return (!(num < num2)) ? num2 : num;
							};
						}
					}
				}
				else if (FunctionName == "pow")
				{
					if (Arguments.Count == 2 && Arguments[1] is ConstantToken<double> constantToken7)
					{
						Func<double[], double> arg1Func3 = Arguments[0].GetFuncAs<double>(context);
						double value = constantToken7.Value;
						if (value == 2.0)
						{
							result = delegate(double[] data)
							{
								double num = arg1Func3(data);
								return num * num;
							};
						}
						else if (value == 3.0)
						{
							result = delegate(double[] data)
							{
								double num = arg1Func3(data);
								return num * num * num;
							};
						}
						else if (value == 4.0)
						{
							result = delegate(double[] data)
							{
								double num = arg1Func3(data);
								return num * num * num * num;
							};
						}
						else if (value == 5.0)
						{
							result = delegate(double[] data)
							{
								double num = arg1Func3(data);
								return num * num * num * num * num;
							};
						}
						else if (value == 6.0)
						{
							result = delegate(double[] data)
							{
								double num = arg1Func3(data);
								return num * num * num * num * num * num;
							};
						}
					}
				}
				else if (FunctionName == "abs")
				{
					if (Arguments.Count == 1 && Arguments[0] is DataSlotToken dataSlotToken9)
					{
						int slotIndex5 = dataSlotToken9.Index;
						result = delegate(double[] data)
						{
							double num = data[slotIndex5];
							return (!(num >= 0.0)) ? (0.0 - num) : num;
						};
					}
				}
				else if (FunctionName == "clamp01" && Arguments.Count == 1 && Arguments[0] is DataSlotToken dataSlotToken10)
				{
					int slotIndex6 = dataSlotToken10.Index;
					result = delegate(double[] data)
					{
						double num = data[slotIndex6];
						return (!(num <= 0.0)) ? ((!(num >= 1.0)) ? num : 1.0) : 0.0;
					};
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				throw;
			}
			return result;
		}
	}
}
