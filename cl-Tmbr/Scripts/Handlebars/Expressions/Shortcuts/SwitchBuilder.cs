using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Expressions.Shortcuts
{
	internal class SwitchBuilder<T> : ExpressionContainer
	{
		protected Expression DefaultCase;

		protected List<SwitchCase> Cases { get; set; } = new List<SwitchCase>();

		protected ExpressionContainer<T> Value { get; }

		protected MethodInfo ComparerMethod { get; set; }

		public override Expression Expression
		{
			get
			{
				if (DefaultCase != null)
				{
					if (!(ComparerMethod != null))
					{
						return Expression.Switch(Value, DefaultCase, Cases.ToArray());
					}
					return Expression.Switch(Value, DefaultCase, ComparerMethod, Cases);
				}
				if (!(ComparerMethod != null))
				{
					return Expression.Switch(Value, Cases.ToArray());
				}
				return Expression.Switch(Value, Expression.Empty(), ComparerMethod, Cases);
			}
		}

		internal SwitchBuilder(ExpressionContainer<T> value)
			: base(Expression.Empty())
		{
			Value = value;
		}

		public SwitchBuilder<T, TR> Default<TR>(ExpressionContainer<TR> expression)
		{
			return new SwitchBuilder<T, TR>(Value)
			{
				Cases = Cases,
				ComparerMethod = ComparerMethod,
				DefaultCase = DefaultCase
			}.Default(expression);
		}

		public SwitchBuilder<T, TR> Default<TR>(Action<ExpressionContainer<T>, BlockBuilder> builder)
		{
			return new SwitchBuilder<T, TR>(Value)
			{
				Cases = Cases,
				ComparerMethod = ComparerMethod,
				DefaultCase = DefaultCase
			}.Default(builder);
		}

		public SwitchBuilder<T> Default(ExpressionContainer expression)
		{
			DefaultCase = expression;
			return this;
		}

		public SwitchBuilder<T> Default(Action<ExpressionContainer<T>, BlockBuilder> builder)
		{
			BlockBuilder blockBuilder = new BlockBuilder(typeof(void));
			builder(Value, blockBuilder);
			DefaultCase = blockBuilder;
			return this;
		}

		public SwitchBuilder<T, TR> Case<TR>(ExpressionContainer<TR> expression, params ExpressionContainer<T>[] testValues)
		{
			return new SwitchBuilder<T, TR>(Value)
			{
				Cases = Cases,
				ComparerMethod = ComparerMethod,
				DefaultCase = DefaultCase
			}.Case(expression, testValues);
		}

		public SwitchBuilder<T, TR> Case<TR>(Action<ExpressionContainer<T>, BlockBuilder> builder, params ExpressionContainer<T>[] testValues)
		{
			return new SwitchBuilder<T, TR>(Value)
			{
				Cases = Cases,
				ComparerMethod = ComparerMethod,
				DefaultCase = DefaultCase
			}.Case(builder, testValues);
		}

		public SwitchBuilder<T> Case(ExpressionContainer expression, params ExpressionContainer<T>[] testValues)
		{
			Cases.Add(Expression.SwitchCase(expression, testValues.Select((ExpressionContainer<T> o) => o.Expression)));
			return this;
		}

		public SwitchBuilder<T> Case(Action<ExpressionContainer<T>, BlockBuilder> builder, params ExpressionContainer<T>[] testValues)
		{
			BlockBuilder blockBuilder = new BlockBuilder(typeof(void));
			builder(Value, blockBuilder);
			Cases.Add(Expression.SwitchCase(blockBuilder, testValues.Select((ExpressionContainer<T> o) => o.Expression)));
			return this;
		}

		public SwitchBuilder<T> Comparer(MethodInfo comparer)
		{
			if (!comparer.IsStatic)
			{
				throw new ArgumentException("Method should be static", "comparer");
			}
			ParameterInfo[] parameters = comparer.GetParameters();
			if (parameters.Length != 2)
			{
				throw new ArgumentException("Method should accept to parameters", "comparer");
			}
			if (parameters.All((ParameterInfo o) => o.ParameterType == typeof(T)))
			{
				throw new ArgumentException("Method should accept to parameters", "comparer");
			}
			ComparerMethod = comparer;
			return this;
		}
	}
	internal class SwitchBuilder<T, TR> : SwitchBuilder<T>
	{
		internal SwitchBuilder(ExpressionContainer<T> value)
			: base(value)
		{
		}

		public SwitchBuilder<T, TR> Default(ExpressionContainer<TR> expression)
		{
			DefaultCase = expression;
			return this;
		}

		public new SwitchBuilder<T, TR> Default(Action<ExpressionContainer<T>, BlockBuilder> builder)
		{
			BlockBuilder blockBuilder = new BlockBuilder(typeof(TR));
			builder(base.Value, blockBuilder);
			DefaultCase = blockBuilder;
			return this;
		}

		public SwitchBuilder<T, TR> Case(ExpressionContainer<TR> expression, params ExpressionContainer<T>[] testValues)
		{
			base.Cases.Add(Expression.SwitchCase(expression, testValues.Select((ExpressionContainer<T> o) => o.Expression)));
			return this;
		}

		public new SwitchBuilder<T, TR> Case(Action<ExpressionContainer<T>, BlockBuilder> builder, params ExpressionContainer<T>[] testValues)
		{
			BlockBuilder blockBuilder = new BlockBuilder(typeof(TR));
			builder(base.Value, blockBuilder);
			base.Cases.Add(Expression.SwitchCase(blockBuilder, testValues.Select((ExpressionContainer<T> o) => o.Expression)));
			return this;
		}

		public new SwitchBuilder<T, TR> Comparer(MethodInfo comparer)
		{
			if (!comparer.IsStatic)
			{
				throw new ArgumentException("Method should be static", "comparer");
			}
			ParameterInfo[] parameters = comparer.GetParameters();
			if (parameters.Length != 2)
			{
				throw new ArgumentException("Method should accept to parameters", "comparer");
			}
			if (parameters.Any((ParameterInfo o) => o.ParameterType != typeof(T)))
			{
				throw new ArgumentException("Method should accept to parameters", "comparer");
			}
			base.ComparerMethod = comparer;
			return this;
		}
	}
}
