using System;
using System.Linq.Expressions;

namespace Expressions.Shortcuts
{
	internal class ExpressionContainer
	{
		public virtual Expression Expression { get; }

		public ExpressionContainer(Expression expression)
		{
			Expression = expression;
		}

		public ExpressionContainer<T> Typed<T>()
		{
			return new ExpressionContainer<T>(Expression);
		}

		public ExpressionContainer<bool> Is<TV>()
		{
			return new ExpressionContainer<bool>(Expression.TypeIs(Expression, typeof(TV)));
		}

		public ExpressionContainer<bool> Is(Type type)
		{
			return new ExpressionContainer<bool>(Expression.TypeIs(Expression, type));
		}

		public ExpressionContainer<TV> As<TV>()
		{
			return new ExpressionContainer<TV>(Expression.TypeAs(Expression, typeof(TV)));
		}

		public UnaryExpression As(Type type)
		{
			return Expression.TypeAs(Expression, type);
		}

		public ExpressionContainer<TV> Cast<TV>()
		{
			return new ExpressionContainer<TV>(Expression.Convert(Expression, typeof(TV)));
		}

		public UnaryExpression Cast(Type type)
		{
			return Expression.Convert(Expression, type);
		}

		public static implicit operator Expression(ExpressionContainer expressionContainer)
		{
			return expressionContainer.Expression;
		}

		public static implicit operator ExpressionContainer(Expression expression)
		{
			return new ExpressionContainer(expression);
		}
	}
	internal class ExpressionContainer<T> : ExpressionContainer
	{
		public static implicit operator T(ExpressionContainer<T> _0)
		{
			return default(T);
		}

		public ExpressionContainer(Expression expression)
			: base(expression)
		{
		}
	}
}
