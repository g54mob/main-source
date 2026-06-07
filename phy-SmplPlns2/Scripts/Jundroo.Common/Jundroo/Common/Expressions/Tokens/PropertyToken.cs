using System;
using System.Linq.Expressions;
using System.Reflection;
using Jundroo.Common.Expressions.Exceptions;

namespace Jundroo.Common.Expressions.Tokens
{
	public static class PropertyToken
	{
		public static Token Create(NameToken name, Token instance, bool nullCoalescing, Context context)
		{
			object constant;
			Token token;
			if (instance == null && (constant = context.GetConstant(name.Name)) != null)
			{
				token = ConstantToken.CreateFromObject(constant);
			}
			else
			{
				MethodInfo methodInfo = null;
				object obj = null;
				if (instance == null)
				{
					(MethodInfo, object)? property = context.GetProperty(name.Name);
					if (property.HasValue)
					{
						(methodInfo, obj) = property.Value;
					}
				}
				else
				{
					methodInfo = context.GetProperty(name.Name, instance.Type);
				}
				if (methodInfo != null)
				{
					return (Token)Activator.CreateInstance(typeof(PropertyToken<>).MakeGenericType(methodInfo.ReturnType), name, instance, nullCoalescing, methodInfo, obj);
				}
				token = context.ResolveVariable(name.Name);
			}
			if (token != null)
			{
				return token;
			}
			throw new ExpressionCompileException("Name not defined: " + name.Name);
		}
	}
	public class PropertyToken<T> : Token<T>
	{
		private MethodInfo _method;

		private object _invokeInstance;

		public override bool IsFinal => true;

		public string Name { get; private set; }

		public bool NullCoalescing { get; }

		public Token Instance { get; private set; }

		public PropertyToken(NameToken name, Token instance, bool nullCoalescing, MethodInfo method, object invokeInstance)
		{
			Instance = instance;
			NullCoalescing = nullCoalescing;
			Name = name.Name;
			Next = name.Next;
			Prev = name.Prev;
			_method = method;
			_invokeInstance = invokeInstance;
		}

		public override Expression GetExpression(Context context)
		{
			if (Instance != null)
			{
				Expression expression = Instance.GetExpression(context);
				if (NullCoalescing)
				{
					ParameterExpression parameterExpression = Expression.Variable(expression.Type);
					return Expression.Block(new ParameterExpression[1] { parameterExpression }, Expression.Assign(parameterExpression, expression), Expression.Condition(Expression.NotEqual(parameterExpression, Expression.Constant(null)), Expression.Call(parameterExpression, _method), Expression.Default(_method.ReturnType)));
				}
				return Expression.Call(expression, _method);
			}
			if (_invokeInstance != null)
			{
				return Expression.Call(Expression.Constant(_invokeInstance), _method);
			}
			return Expression.Call(_method);
		}

		public override Func<T> GetFunc(Context context)
		{
			if (Instance != null)
			{
				throw new NotImplementedException("member access not implemented for mobile backend");
			}
			(MethodInfo, object)? property = context.GetProperty(Name);
			if (property.HasValue)
			{
				return (Func<T>)Delegate.CreateDelegate(typeof(Func<T>), property.Value.Item2, property.Value.Item1);
			}
			throw new ExpressionCompileException("Variable not found: " + Name);
		}

		public override string ToString()
		{
			return "{" + Name + "}";
		}
	}
}
