using System;
using System.Linq.Expressions;

namespace Expressions.Shortcuts
{
	internal class ConditionBuilder : ExpressionContainer
	{
		private readonly Type _type;

		private Expression _condition;

		private Expression _then;

		private Expression _else;

		public override Expression Expression
		{
			get
			{
				if (_condition == null)
				{
					throw new InvalidOperationException("`if` statement is not defined");
				}
				if (_else != null)
				{
					if (!(_type == null))
					{
						return Expression.Condition(_condition, _then, _else, _type);
					}
					return Expression.Condition(_condition, _then, _else);
				}
				return Expression.IfThen(_condition, _then);
			}
		}

		internal ConditionBuilder(Type type)
			: base(Expression.Empty())
		{
			_type = type;
		}

		public ConditionBuilder If(Expression condition)
		{
			_condition = condition;
			return this;
		}

		public ConditionBuilder If(ExpressionContainer<bool> condition)
		{
			_condition = condition;
			return this;
		}

		public ConditionBuilder Then(Expression then)
		{
			_then = then;
			return this;
		}

		public ConditionBuilder Then(ExpressionContainer then)
		{
			_then = then.Expression;
			return this;
		}

		public ConditionBuilder Then<T>(ExpressionContainer<T> then)
		{
			_then = then.Expression;
			return this;
		}

		public ConditionBuilder Then(Action<BlockBuilder> then)
		{
			BlockBuilder blockBuilder = new BlockBuilder(null);
			then(blockBuilder);
			_then = blockBuilder;
			return this;
		}

		public ConditionBuilder Else(Expression then)
		{
			_else = then;
			return this;
		}

		public ConditionBuilder Else(ExpressionContainer then)
		{
			_else = then;
			return this;
		}

		public ConditionBuilder Else<T>(ExpressionContainer<T> then)
		{
			_else = then;
			return this;
		}

		public ConditionBuilder Else(Action<BlockBuilder> then)
		{
			BlockBuilder blockBuilder = new BlockBuilder(null);
			then(blockBuilder);
			_else = blockBuilder;
			return this;
		}
	}
}
