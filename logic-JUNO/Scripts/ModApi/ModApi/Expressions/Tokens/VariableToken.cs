using System;
using System.Linq.Expressions;
using System.Reflection;
using ModApi.Expressions.Exceptions;

namespace ModApi.Expressions.Tokens
{
	internal static class VariableToken
	{
		public static Token Create(NameToken name, Context context)
		{
			object constant = context.GetConstant(name.Name);
			Token token;
			if (constant != null)
			{
				token = ConstantToken.CreateFromObject(constant);
			}
			else
			{
				(MethodInfo, object)? property = context.GetProperty(name.Name);
				token = ((!property.HasValue) ? context.ResolveVariable(name.Name) : ((Token)Activator.CreateInstance(typeof(VariableToken<>).MakeGenericType(property.Value.Item1.ReturnType), name.Name)));
			}
			if (token != null)
			{
				token.Prev = name.Prev;
				if (name.Prev != null)
				{
					name.Prev.Next = token;
					name.Prev = null;
				}
				token.Next = name.Next;
				if (name.Next != null)
				{
					name.Next.Prev = token;
					name.Next = null;
				}
				return token;
			}
			throw new ExpressionCompileException("Name not defined: " + name.Name);
		}
	}
	internal class VariableToken<T> : Token<T>
	{
		public override bool IsFinal => true;

		public string Name { get; private set; }

		public VariableToken(string val)
		{
			Name = val;
		}

		public override Expression GetExpression(Context context, ParameterExpression dataSlots)
		{
			(MethodInfo, object)? property = context.GetProperty(Name);
			if (property.HasValue)
			{
				return Expression.Call(Expression.Constant(property.Value.Item2), property.Value.Item1);
			}
			throw new ExpressionCompileException("Variable not found: " + Name);
		}

		public override Func<double[], T> GetFunc(Context context)
		{
			(MethodInfo, object)? property = context.GetProperty(Name);
			if (property.HasValue)
			{
				Func<T> del = (Func<T>)Delegate.CreateDelegate(typeof(Func<T>), property.Value.Item2, property.Value.Item1);
				return (double[] d) => del();
			}
			throw new ExpressionCompileException("Variable not found: " + Name);
		}

		public override string ToString()
		{
			return "{" + Name + "}";
		}
	}
}
