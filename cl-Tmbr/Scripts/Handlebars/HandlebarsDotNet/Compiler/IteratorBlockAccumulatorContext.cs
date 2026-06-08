using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class IteratorBlockAccumulatorContext : BlockAccumulatorContext
	{
		private readonly HelperExpression _startingNode;

		private Expression _accumulatedExpression;

		private List<Expression> _body = new List<Expression>();

		public sealed override string BlockName
		{
			get
			{
				return _startingNode.HelperName;
			}
			protected set
			{
				throw new NotSupportedException();
			}
		}

		public IteratorBlockAccumulatorContext(Expression startingNode)
			: base(startingNode)
		{
			startingNode = BlockAccumulatorContext.UnwrapStatement(startingNode);
			_startingNode = (HelperExpression)startingNode;
		}

		public override void HandleElement(Expression item)
		{
			if (IsElseBlock(item))
			{
				_accumulatedExpression = HandlebarsExpression.Iterator(BlockName, _startingNode.Arguments.Single((Expression o) => o.NodeType != (ExpressionType)6013), _startingNode.Arguments.OfType<BlockParamsExpression>().SingleOrDefault() ?? BlockParamsExpression.Empty(), Expression.Block(_body));
				_body = new List<Expression>();
			}
			else
			{
				_body.Add(item);
			}
		}

		public override bool IsClosingElement(Expression item)
		{
			if (!IsClosingNode(item))
			{
				return false;
			}
			List<Expression> expressions = ((_body.Count != 0) ? _body : new List<Expression> { Expression.Empty() });
			if (_accumulatedExpression == null)
			{
				_accumulatedExpression = HandlebarsExpression.Iterator(BlockName, _startingNode.Arguments.Single((Expression o) => o.NodeType != (ExpressionType)6013), _startingNode.Arguments.OfType<BlockParamsExpression>().SingleOrDefault() ?? BlockParamsExpression.Empty(), Expression.Block(expressions));
			}
			else
			{
				_accumulatedExpression = HandlebarsExpression.Iterator(BlockName, ((IteratorExpression)_accumulatedExpression).Sequence, ((IteratorExpression)_accumulatedExpression).BlockParams, ((IteratorExpression)_accumulatedExpression).Template, Expression.Block(expressions));
			}
			return true;
		}

		public override Expression GetAccumulatedBlock()
		{
			return _accumulatedExpression;
		}

		private static bool IsClosingNode(Expression item)
		{
			item = BlockAccumulatorContext.UnwrapStatement(item);
			if (item is PathExpression pathExpression)
			{
				return pathExpression.Path.Replace("#", "").Replace("^", "") == "/each";
			}
			return false;
		}

		private static bool IsElseBlock(Expression item)
		{
			item = BlockAccumulatorContext.UnwrapStatement(item);
			if (item is HelperExpression helperExpression)
			{
				return helperExpression.HelperName == "else";
			}
			return false;
		}
	}
}
