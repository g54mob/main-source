using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Moq.Linq
{
	internal class MockQueryable<T> : IQueryable<T>, IEnumerable<T>, IEnumerable, IQueryable, IQueryProvider
	{
		private readonly Expression expression;

		public Type ElementType => typeof(T);

		public Expression Expression => expression;

		public IQueryProvider Provider => this;

		public MockQueryable(Expression expression)
		{
			Guard.ImplementsInterface(typeof(IQueryable<T>), expression.Type, "expression");
			this.expression = expression;
		}

		public IQueryable CreateQuery(Expression expression)
		{
			return CreateQuery<T>(expression);
		}

		public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
		{
			return new MockQueryable<TElement>(expression);
		}

		public object Execute(Expression expression)
		{
			return Execute<IQueryable<T>>(expression);
		}

		public TResult Execute<TResult>(Expression expression)
		{
			Expression body = new MockSetupsBuilder().Visit(expression);
			Expression<Func<TResult>> expression2 = System.Linq.Expressions.Expression.Lambda<Func<TResult>>(body, Array.Empty<ParameterExpression>());
			return expression2.CompileUsingExpressionCompiler()();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return Provider.Execute<IQueryable<T>>(Expression).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override string ToString()
		{
			if (Expression.NodeType == ExpressionType.Constant && ((ConstantExpression)Expression).Value == this)
			{
				return "Query(" + typeof(T)?.ToString() + ")";
			}
			return Expression.ToString();
		}
	}
}
