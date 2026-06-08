using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Expressions.Shortcuts
{
	internal class BlockBuilder : ExpressionContainer
	{
		private readonly Type _returnType;

		private readonly List<Expression> _expressions;

		private readonly HashSet<ParameterExpression> _parameters;

		public IEnumerable<ParameterExpression> Parameters => _parameters;

		public override Expression Expression
		{
			get
			{
				if (!(_returnType == null))
				{
					return Expression.Block(_returnType, _parameters, _expressions);
				}
				return Expression.Block(_parameters, _expressions);
			}
		}

		internal BlockBuilder(Type returnType)
			: base(Expression.Empty())
		{
			_returnType = returnType;
			_expressions = new List<Expression>();
			_parameters = new HashSet<ParameterExpression>();
		}

		public BlockBuilder Parameter(Expression expression)
		{
			if (expression is ParameterExpression e)
			{
				return Parameter(e);
			}
			throw new ArgumentException("is not ParameterExpression", "expression");
		}

		public BlockBuilder Parameter<T>(out ExpressionContainer<T> parameter)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
			parameter = ExpressionShortcuts.Arg<T>(parameterExpression);
			return Parameter(parameterExpression);
		}

		public BlockBuilder Parameter<T>(string name, out ExpressionContainer<T> parameter)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(T), name);
			parameter = ExpressionShortcuts.Arg<T>(parameterExpression);
			return Parameter(parameterExpression);
		}

		public BlockBuilder Parameter<T>(out ExpressionContainer<T> parameter, ExpressionContainer<T> value)
		{
			ParameterExpression expression = Expression.Parameter(typeof(T));
			parameter = ExpressionShortcuts.Arg<T>(expression);
			return Parameter(parameter, value);
		}

		public BlockBuilder Parameter<T>(string name, out ExpressionContainer<T> parameter, ExpressionContainer<T> value)
		{
			ParameterExpression expression = Expression.Parameter(typeof(T), name);
			parameter = ExpressionShortcuts.Arg<T>(expression);
			return Parameter(parameter, value);
		}

		public BlockBuilder Parameter<T>(out ExpressionContainer<T> parameter, T value)
		{
			ParameterExpression expression = Expression.Parameter(typeof(T));
			parameter = ExpressionShortcuts.Arg<T>(expression);
			return Parameter(parameter, ExpressionShortcuts.Arg(value));
		}

		public BlockBuilder Parameter<T>(string name, out ExpressionContainer<T> parameter, T value)
		{
			ParameterExpression expression = Expression.Parameter(typeof(T), name);
			parameter = ExpressionShortcuts.Arg<T>(expression);
			return Parameter(parameter, ExpressionShortcuts.Arg(value));
		}

		public BlockBuilder Parameter<TV>(ExpressionContainer<TV> expression, ExpressionContainer<TV> value)
		{
			if (!(expression.Expression is ParameterExpression item))
			{
				throw new ArgumentException("is not ParameterExpression", "expression");
			}
			_parameters.Add(item);
			_expressions.Add(expression.Assign(value));
			return this;
		}

		public BlockBuilder Parameter<TV>(ExpressionContainer<TV> expression, Expression value)
		{
			if (!(expression.Expression is ParameterExpression item))
			{
				throw new ArgumentException("is not ParameterExpression", "expression");
			}
			_parameters.Add(item);
			_expressions.Add(expression.Assign(value));
			return this;
		}

		public BlockBuilder Parameter(ParameterExpression e)
		{
			_parameters.Add(e);
			return this;
		}

		public BlockBuilder Line(Expression e)
		{
			_expressions.Add(e);
			return this;
		}

		public BlockBuilder Line<TV>(ExpressionContainer<TV> e)
		{
			_expressions.Add(e);
			return this;
		}

		public BlockBuilder Lines(IEnumerable<Expression> e)
		{
			_expressions.AddRange(e);
			return this;
		}

		public BlockBuilder Lines(params Expression[] e)
		{
			_expressions.AddRange(e);
			return this;
		}

		public ExpressionContainer<T> Invoke<T>(params ExpressionContainer[] parameters)
		{
			return ExpressionShortcuts.Arg<T>(Expression.Invoke(Expression.Lambda(Expression, parameters.Select((ExpressionContainer o) => (ParameterExpression)o.Expression))));
		}

		public Expression<T> Lambda<T>(params ExpressionContainer[] parameters) where T : class
		{
			return Expression.Lambda<T>(Expression, parameters.Select((ExpressionContainer o) => (ParameterExpression)o.Expression));
		}

		public Expression<T> Lambda<T>(IEnumerable<ParameterExpression> parameters) where T : class
		{
			return Expression.Lambda<T>(Expression, parameters);
		}
	}
}
